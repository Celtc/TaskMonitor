using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Data;

namespace TaskMonitor.Sources
{
    public class StatusReporter
    {
        //Builder
        public StatusReporter(MonitorMgr callerForm)
        {
            this._ready = false;
            this._endThread = false;
            this.callerForm = callerForm;
        }

        //Funcion inicial
        public void MaintMethod()
        {
            this.serviceDataTable = createServiceTable();
            this.processDataTable = createProcessTable();
            this._updateAndCheck = false;
            this._ready = true;
            this.updateLoop();
        }

        //Crea las tablas
        private DataTable createServiceTable()
        {
            DataTable dataTable = new DataTable("Servicios");

            //Columnas
            DataColumn nameColumn = new DataColumn();
            nameColumn.DataType = System.Type.GetType("System.String");
            nameColumn.ColumnName = "Nombre de Monitor";
            dataTable.Columns.Add(nameColumn);

            DataColumn machineName = new DataColumn();
            machineName.DataType = System.Type.GetType("System.String");
            machineName.ColumnName = "Equipo";
            dataTable.Columns.Add(machineName);

            DataColumn targetColumn = new DataColumn();
            targetColumn.DataType = System.Type.GetType("System.String");
            targetColumn.ColumnName = "Objetivo";
            dataTable.Columns.Add(targetColumn);

            DataColumn estatusColumn = new DataColumn();
            estatusColumn.DataType = System.Type.GetType("System.String");
            estatusColumn.ColumnName = "Estatus";
            dataTable.Columns.Add(estatusColumn);

            DataColumn estadoColumn = new DataColumn();
            estadoColumn.DataType = System.Type.GetType("System.String");
            estadoColumn.ColumnName = "Estado";
            dataTable.Columns.Add(estadoColumn);

            DataColumn startModeColumn = new DataColumn();
            startModeColumn.DataType = System.Type.GetType("System.String");
            startModeColumn.ColumnName = "Inicio";
            dataTable.Columns.Add(startModeColumn);

            DataColumn criticColumn = new DataColumn();
            criticColumn.DataType = System.Type.GetType("System.String");
            criticColumn.ColumnName = "Crítico";
            dataTable.Columns.Add(criticColumn);

            DataColumn enableColumn = new DataColumn();
            enableColumn.DataType = System.Type.GetType("System.String");
            enableColumn.ColumnName = "Habilitado";
            dataTable.Columns.Add(enableColumn);

            return dataTable;
        }
        private DataTable createProcessTable()
        {
            DataTable dataTable = new DataTable("Procesos");

            //Columnas
            DataColumn nameColumn = new DataColumn();
            nameColumn.DataType = System.Type.GetType("System.String");
            nameColumn.ColumnName = "Nombre de Monitor";
            dataTable.Columns.Add(nameColumn);

            DataColumn machineName = new DataColumn();
            machineName.DataType = System.Type.GetType("System.String");
            machineName.ColumnName = "Equipo";
            dataTable.Columns.Add(machineName);

            DataColumn targetColumn = new DataColumn();
            targetColumn.DataType = System.Type.GetType("System.String");
            targetColumn.ColumnName = "Objetivo";
            dataTable.Columns.Add(targetColumn);

            DataColumn estatusColumn = new DataColumn();
            estatusColumn.DataType = System.Type.GetType("System.String");
            estatusColumn.ColumnName = "Ejecutando";
            dataTable.Columns.Add(estatusColumn);

            DataColumn estadoColumn = new DataColumn();
            estadoColumn.DataType = System.Type.GetType("System.Int32");
            estadoColumn.ColumnName = "Carga de CPU";
            dataTable.Columns.Add(estadoColumn);

            DataColumn startModeColumn = new DataColumn();
            startModeColumn.DataType = System.Type.GetType("System.Int32");
            startModeColumn.ColumnName = "Carga deseada";
            dataTable.Columns.Add(startModeColumn);

            DataColumn enableColumn = new DataColumn();
            enableColumn.DataType = System.Type.GetType("System.String");
            enableColumn.ColumnName = "Habilitado";
            dataTable.Columns.Add(enableColumn);

            return dataTable;
        }

        //Llena las tablas
        private bool updateServiceTable(List<ServiceMonitor> monitors, ref DataTable dataTable)
        {
            //Variable de retorno
            bool updated = false;

            //Para cada monitor
            foreach (ServiceMonitor monitor in monitors)
            {
                //Identifica la fila a traves del nombre de monitor
                DataRow targetRow = null;
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    if ((string) dataTable.Rows[i][0] == monitor.name)
                    {
                        targetRow = dataTable.Rows[i];
                        break;
                    }
                }
                if (targetRow == null)
                    continue;

                //Acutaliza los valores si hace falta
                if (_updateAndCheck)
                {
                    string actualStatus = (monitor.actualStatus == null) ? "Desconocido" : monitor.actualStatus.ToString();
                    string actualState = monitor.actualState == null ? "Desconocido" : monitor.actualState.ToString();
                    string actualStartMode = monitor.actualStartMode == null ? "Desconocido" : monitor.actualStartMode.ToString();

                    if (targetRow[3].GetType() == typeof(System.DBNull) || !((string)targetRow[3]).StartsWith(actualStatus))
                    {
                        targetRow[3] = actualStatus;
                        updated = true;
                    }
                    if (targetRow[4].GetType() == typeof(System.DBNull) || !((string)targetRow[4]).StartsWith(actualState))
                    {
                        targetRow[4] = actualState;
                        updated = true;
                    }
                    if (targetRow[5].GetType() == typeof(System.DBNull) || !((string)targetRow[5]).StartsWith(actualStartMode))
                    {
                        targetRow[5] = actualStartMode;
                        updated = true;
                    }
                }

                //El valor de habilitado / deshabilitado lo actualiza siempre
                if ((string)targetRow[7] != monitor.enable.ToString())
                {
                    targetRow[7] = monitor.enable.ToString();
                    updated = true;
                }

                //Si hay error lo marca para colorear
                if (_updateAndCheck && updated && monitor.error)
                {
                    if (monitor.wantedStatus != null && monitor.actualStatus != monitor.wantedStatus)
                        if (!((string) targetRow[3]).EndsWith("!")) targetRow[3] = targetRow[3] + "!";
                    if (monitor.wantedState != null && monitor.actualState != monitor.wantedState)
                        if (!((string) targetRow[4]).EndsWith("!")) targetRow[4] = targetRow[4] + "!";
                    if (monitor.wantedStartMode != null && monitor.actualStartMode != monitor.wantedStartMode)
                        if (!((string) targetRow[5]).EndsWith("!")) targetRow[5] = targetRow[5] + "!";
                }
            }

            return updated;
        }
        private bool updateProcessTable(List<ProcessMonitor> monitors, ref DataTable dataTable)
        {
            return false;
        }

        //Delegados para quitar nuevos monitores de la lista
        public void RemoveServiceMonitorData(string monitorName, object sender)
        {
            if (sender != null)
            {
                ((Form)sender).Invoke((MethodInvoker)delegate { removeServiceMonitorData(monitorName); });
                return;
            }
        }
        private void removeServiceMonitorData(string monitorName)
        {
            for (int i = 0; i < this.serviceDataTable.Rows.Count; i++)
            {
                if ((string) this.serviceDataTable.Rows[i][0] == monitorName)
                {
                    this.serviceDataTable.Rows.RemoveAt(i);
                    break;
                }
            }
        }

        public void RemoveProcessMonitorData(string monitorName, object sender)
        {
            if (sender != null)
            {
                ((Form)sender).Invoke((MethodInvoker)delegate { removeProcessMonitorData(monitorName); });
                return;
            }
        }
        private void removeProcessMonitorData(string monitorName)
        {
            for (int i = 0; i < this.processDataTable.Rows.Count; i++)
            {
                if ((string)this.processDataTable.Rows[i][0] == monitorName)
                {
                    this.processDataTable.Rows.RemoveAt(i);
                    break;
                }
            }
        }

        //Delegados para forzar la actualizacion de las tablas
        public void ForceUpdateTables(Mode type, object sender)
        {
            if (sender != null)
            {
                ((Form)sender).Invoke((MethodInvoker)delegate { forceUpdateTables(type); });
                return;
            }

        }
        private void forceUpdateTables(Mode type)
        {
            if (type == Mode.service)
            {
                List<ServiceMonitor> sMonitors = this.callerForm.InfoServiceMonitors();
                if (sMonitors.Count != 0)
                    this.callerForm.RefreshDataGrids(this.updateServiceTable(sMonitors, ref this.serviceDataTable), false);
            }
            else
            {
                List<ProcessMonitor> pMonitors = this.callerForm.InfoProcessMonitors();
                if (pMonitors.Count != 0)
                    this.callerForm.RefreshDataGrids(false, this.updateProcessTable(pMonitors, ref this.processDataTable));
            }
        }

        //Delegados para agregar nuevos monitores a la lista
        public void AddServiceMonitorData(ServiceMonitor monitor, object sender)
        {
            if (sender != null)
            {
                ((Form)sender).Invoke((MethodInvoker)delegate { addServiceMonitorData(monitor); });
                return;
            }
        }
        private void addServiceMonitorData(ServiceMonitor monitor)
        {
            DataRow targetRow = serviceDataTable.NewRow();

            targetRow[0] = monitor.name;
            targetRow[1] = monitor.remoteMachine;
            targetRow[2] = monitor.target;
            targetRow[6] = monitor.critic.ToString();
            targetRow[7] = monitor.enable.ToString();

            if (_updateAndCheck)
            {
                targetRow[3] = monitor.actualStatus.ToString();
                targetRow[4] = monitor.actualState.ToString();
                targetRow[5] = monitor.actualStartMode.ToString();
            }

            serviceDataTable.Rows.Add(targetRow);
        }

        public void AddProcessMonitorData(ProcessMonitor monitor, object sender)
        {
            if (sender != null)
            {
                ((Form)sender).Invoke((MethodInvoker)delegate { addProcessMonitorData(monitor); });
                return;
            }
        }
        private void addProcessMonitorData(ProcessMonitor monitor)
        {
        }

        //Ciclo de verificación: servicio
        private void updateLoop()
        {
            //Variable que indica si es necesario refrescar el datagrid
            bool sRefresh = false, pRefresh = false;

            //Loop
            while (!_endThread)
            {
                //Servicios
                List<ServiceMonitor> sMonitors = this.callerForm.InfoServiceMonitors();
                if (sMonitors.Count != 0)
                    sRefresh = this.updateServiceTable(sMonitors, ref this.serviceDataTable);

                //Procesos
                List<ProcessMonitor> pMonitors = this.callerForm.InfoProcessMonitors();
                if (pMonitors.Count != 0)
                    pRefresh = this.updateProcessTable(pMonitors, ref this.processDataTable);

                //Solicita el refresh de los datagrid
                this.callerForm.RefreshDataGrids(sRefresh, pRefresh);
               
                //Intervalo de update
                Thread.Sleep(MonitorMgr.GralConfig.updateInterval);
            }

            //Termina el hilo
            Thread.CurrentThread.Abort();
        }

        //Solicita que se inicien o detengan las actualizaciones de los valores
        public void RequestUpdateValues(bool update)
        {
            this._updateAndCheck = update;
        }

        //Solicita que se detenga la actualizacion de las tablas
        public void RequestStopThread()
        {
            this._endThread = true;
        }

        //Pregunta si el hilo esta listo para comenzar a ejecutar el ciclo de actualizacion
        public bool IsReady()
        {
            return this._ready;
        }

        //Getters
        public DataTable ServiceDataTable { get { return this.serviceDataTable; } }
        public DataTable ProcessDataTable { get { return this.processDataTable; } }

        //Atributos privados
        private bool _ready;
        private bool _endThread;
        private bool _updateAndCheck;
        private MonitorMgr callerForm;
        private DataTable serviceDataTable;
        private DataTable processDataTable;
    }
}
