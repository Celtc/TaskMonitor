using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TaskMonitor.Sources;
using System.Threading;

namespace TaskMonitor
{
    public partial class MonitorMgr : Form
    {
        public struct ThreadContext
        {
            public ThreadContext(Thread threadMgr, MonitorThread threadObject)
            {
                this.threadMgr = threadMgr;
                this.threadObject = threadObject;
            }

            public Thread threadMgr;
            public MonitorThread threadObject;
        }

        //Builder
        public MonitorMgr()
        {
            InitializeComponent();
            this.monitoring = false;
            this.serviceMonitorThreads = new List<ThreadContext>();
            this.processMonitorThreads = new List<ThreadContext>();

            _gralConfigData.queryingInterval = 5000;
            _gralConfigData.updateInterval = 1000;
        }

        #region Buttons
        //Opciones
        private void iniciarMonitoreoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.statusReporter.RequestUpdateValues(true);

            foreach (ThreadContext threadCtxt in serviceMonitorThreads)
            {
                threadCtxt.threadObject.ReleaseThread();
            }

            this.iniciarMonitoreoToolStripMenuItem.Enabled = false;
            this.detenerMonitoreosToolStripMenuItem.Enabled = true;
            this.monitoring = true;
        }

        private void detenerMonitoreosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.statusReporter.RequestUpdateValues(false);

            foreach (ThreadContext threadCtxt in serviceMonitorThreads)
            {
                threadCtxt.threadObject.SuspendThread();
            }

            this.iniciarMonitoreoToolStripMenuItem.Enabled = true;
            this.detenerMonitoreosToolStripMenuItem.Enabled = false;
            this.monitoring = false;
        }

        private void configuraciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (ConfigForm configForm = new ConfigForm(GralConfig, EmailConfig))
            {
                var ans = configForm.ShowDialog();
                if (ans == System.Windows.Forms.DialogResult.OK)
                {
                    _gralConfigData = configForm.GetGralConfigData;
                    _emailConfigData = configForm.GetEmailConfigData;
                }
            }
        }

        private void guardarMonitoreosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Monitor
        private void agregarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TaskMonitor.Sources.Monitor newMonitor = null;
            using (AddMonitorForm addMonitorForm = new AddMonitorForm(this))
            {
                var ans = addMonitorForm.ShowDialog();
                if (ans == System.Windows.Forms.DialogResult.OK)
                {
                    newMonitor = addMonitorForm.ReturnValue;
                }
            }

            if (newMonitor != null)
            {
                MonitorThread newMonitorThread = new MonitorThread(newMonitor, monitoring);
                Thread newThreadMgr = new Thread(new ThreadStart(newMonitorThread.MainMethod));

                if (newMonitor.mode == Mode.service)
                {
                    //Crea el monitor y su hilo
                    newThreadMgr.Name = "ThreadService" + serviceMonitorThreads.Count.ToString();
                    serviceMonitorThreads.Add(new ThreadContext(newThreadMgr, newMonitorThread));
                    newThreadMgr.Start();

                    //Lo agrega al datagrid
                    this.statusReporter.AddServiceMonitorData((ServiceMonitor)newMonitor, this);
                }
                else
                {
                    //Crea el monitor y su hilo
                    newThreadMgr.Name = "ThreadProcess" + processMonitorThreads.Count.ToString();
                    processMonitorThreads.Add(new ThreadContext(newThreadMgr, newMonitorThread));
                    newThreadMgr.Start();

                    //Lo agrega al datagrid
                    this.statusReporter.AddProcessMonitorData((ProcessMonitor)newMonitor, this);
                }
            }
        }

        private void quitarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (EndMonitorForm endMonitorForm = new EndMonitorForm(this))
            {
                endMonitorForm.ShowDialog();
            }
        }

        //Ayuda
        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Herramienta de monitereo simultaneo de procesos y servicios remotos. Frente a cualquier error comuniquese con Nicolas.Ezcurra@xerox.com", "Acerca", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //Datagrid context menu
        private void dataGridView_services_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ContextMenu m = new ContextMenu();
                m.MenuItems.Add(new MenuItem("Agregar monitoreo...", new System.EventHandler(this.agregarToolStripMenuItem_Click)));
                m.MenuItems.Add(new MenuItem("Quitar monitoreo...", new System.EventHandler(this.quitarToolStripMenuItem_Click)));

                int currentMouseOverRow = dataGridView_services.HitTest(e.X, e.Y).RowIndex;

                if (currentMouseOverRow >= 0)
                {
                    //Monitor seleccionado
                    string selectedMonitor = (string)this.dataGridView_services.Rows[currentMouseOverRow].Cells[0].Value;

                    //Quitar
                    m.MenuItems.Add(new MenuItem(string.Format("Quitar {0}", selectedMonitor), new System.EventHandler(this.quitarServiceMonitor)));

                    //Habilitar / Deshabilitar
                    string option = null;
                    if ((string)this.dataGridView_services.Rows[currentMouseOverRow].Cells[7].Value == "True")
                        option = "Deshabilitar ";
                    else
                        option = "Habilitar ";

                    m.MenuItems.Add(option + selectedMonitor, new System.EventHandler(this.habilitarDeshabilitarServiceMonitor));
                }

                m.Show(dataGridView_services, new Point(e.X, e.Y));
            }
        }

        private void dataGridView_process_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ContextMenu m = new ContextMenu();
                m.MenuItems.Add(new MenuItem("Agregar monitoreo...", new System.EventHandler(this.agregarToolStripMenuItem_Click)));
                m.MenuItems.Add(new MenuItem("Quitar monitoreo...", new System.EventHandler(this.quitarToolStripMenuItem_Click)));

                int currentMouseOverRow = dataGridView_process.HitTest(e.X, e.Y).RowIndex;

                if (currentMouseOverRow >= 0)
                {
                    //Monitor seleccionado
                    string selectedMonitor = (string)this.dataGridView_process.Rows[currentMouseOverRow].Cells[0].Value;

                    //Quitar
                    m.MenuItems.Add(new MenuItem(string.Format("Quitar {0}", selectedMonitor), new System.EventHandler(this.quitarProcessMonitor)));

                    //Habilitar / Deshabilitar
                    string option = null;
                    if ((string)this.dataGridView_process.Rows[currentMouseOverRow].Cells[6].Value == "True")
                        option = "Deshabilitar ";
                    else
                        option = "Habilitar ";

                    m.MenuItems.Add(option + selectedMonitor, new System.EventHandler(this.habilitarDeshabilitarProcessMonitor));
                }

                m.Show(dataGridView_process, new Point(e.X, e.Y));
            }
        }  
        #endregion

        #region Events
        private void MonitorMgr_Load(object sender, EventArgs e)
        {
            this.Activate();
        }

        private void MonitorMgr_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.statusReporter.RequestStopThread();
            foreach (ThreadContext threadCtxt in serviceMonitorThreads)
            {
                threadCtxt.threadObject.RequestStop();
            }
            foreach (ThreadContext threadCtxt in processMonitorThreads)
            {
                threadCtxt.threadObject.RequestStop();
            }
        }

        private void MonitorMgr_Shown(object sender, EventArgs e)
        {
            //Inicia el hilo
            this.statusReporter = new StatusReporter(this);
            this.statusReporterUpdater = new Thread(new ThreadStart(statusReporter.MaintMethod));
            this.statusReporterUpdater.Start();

            //Espera que este listo
            while (!statusReporter.IsReady()) { Thread.Sleep(10); }
            this.dataGridView_services.DataSource = statusReporter.ServiceDataTable;
            this.dataGridView_process.DataSource = statusReporter.ProcessDataTable;
        }

        private void dataGridView_services_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                //Alarma
                if (e.ColumnIndex == 3 || e.ColumnIndex == 4 || e.ColumnIndex == 5)
                {
                    if (((String)e.Value).EndsWith("!"))
                    {
                        e.CellStyle.BackColor = Color.Red;
                        e.CellStyle.SelectionForeColor = Color.Red;
                        e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Bold);
                    }
                }

                //Colorea lo deshabilitado
                if (e.Value.GetType() != typeof(System.DBNull))
                {
                    if ((string)this.dataGridView_services.Rows[e.RowIndex].Cells[7].Value == "False")
                    {
                        e.CellStyle.BackColor = Color.Gray;
                        e.CellStyle.SelectionForeColor = Color.Gray;
                        e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Bold);
                    }
                }
            }
            catch { }
        }

        private void quitarServiceMonitor(object sender, EventArgs e)
        {
            MenuItem caller = (MenuItem)sender;
            string monitorName = caller.Text.Substring(6).Trim();
            this.endMonitor(monitorName, Mode.service);
        }

        private void quitarProcessMonitor(object sender, EventArgs e)
        {
            MenuItem caller = (MenuItem)sender;
            string monitorName = caller.Text.Substring(6).Trim();
            this.endMonitor(monitorName, Mode.process);
        }

        private void habilitarDeshabilitarServiceMonitor(object sender, EventArgs e)
        {
            MenuItem caller = (MenuItem)sender;
            string monitorName = caller.Text.Substring(caller.Text.IndexOf(' ')).Trim();

            bool enabling;
            if (caller.Text.StartsWith("Habilitar"))
                enabling = true;
            else
                enabling = false;

            if (enabling)
                this.enableMonitorThread(monitorName, Mode.service);
            else
                this.disableMonitorThread(monitorName, Mode.service);

            statusReporter.ForceUpdateTables(Mode.service, this);
        }

        private void habilitarDeshabilitarProcessMonitor(object sender, EventArgs e)
        {
            MenuItem caller = (MenuItem)sender;
            string monitorName = caller.Text.Substring(caller.Text.IndexOf(' ')).Trim();

            bool enabling;
            if (caller.Text.StartsWith("Habilitar"))
                enabling = true;
            else
                enabling = false;

            if (enabling)
                this.enableMonitorThread(monitorName, Mode.process);
            else
                this.disableMonitorThread(monitorName, Mode.process);

            statusReporter.ForceUpdateTables(Mode.process, this);
        }
        #endregion
        
        //Habilita o deshabilita un hilo de monitoreo
        private void disableMonitorThread(string monitorName, Mode type)
        {
            MonitorThread monitorAffected = null;
            List<ThreadContext> listAffected = null;

            if (type == Mode.service)
                listAffected = this.serviceMonitorThreads;
            else
                listAffected = this.processMonitorThreads;

            foreach (ThreadContext threadCtxt in listAffected)
            {
                if (threadCtxt.threadObject.monitor.name == monitorName)
                {
                    monitorAffected = threadCtxt.threadObject;
                    break;
                }
            }

            if (monitorAffected == null)
                return;

            monitorAffected.DisableThread();
        }
        private void enableMonitorThread(string monitorName, Mode type)
        {
            MonitorThread monitorAffected = null;
            List<ThreadContext> listAffected = null;

            if (type == Mode.service)
                listAffected = this.serviceMonitorThreads;
            else
                listAffected = this.processMonitorThreads;

            foreach (ThreadContext threadCtxt in listAffected)
            {
                if (threadCtxt.threadObject.monitor.name == monitorName)
                {
                    monitorAffected = threadCtxt.threadObject;
                    break;
                }
            }

            if (monitorAffected == null)
                return;

            monitorAffected.EnableThread();
        }

        //Remuevo un monitoreo
        public void EndMonitor(string monitorName, Mode type)
        {
            this.endMonitor(monitorName, type);
        }
        private void endMonitor(string monitorName, Mode type)
        {
            //Determina la lista afectada
            List<ThreadContext> affectedList;
            if (type == Mode.service)
                affectedList = this.serviceMonitorThreads;
            else
                affectedList = this.processMonitorThreads;

            //Termina el hilo y lo saca de la lista
            for (int i = 0; i < affectedList.Count; i++)
            {
                if (affectedList[i].threadObject.monitor.name == monitorName)
                {
                    affectedList[i].threadObject.RequestStop();
                    affectedList[i].threadMgr.Join();
                    affectedList.RemoveAt(i);
                }
            }

            //Lo saca de la data del datagridview
            statusReporter.RemoveServiceMonitorData(monitorName, this);
        }

        //Informa si el nombre del monitor solicitado es único
        public bool IsUnique(string monitorName, Mode type)
        {
            bool unique = true;

            if (type == Mode.service)
            {
                foreach(ThreadContext monitorCtxt in serviceMonitorThreads)
                {
                    if(monitorCtxt.threadObject.monitor.name == monitorName)
                    {
                        unique = false;
                        break;
                    }

                }
            }
            else //(type == Mode.process)
            {
                foreach(ThreadContext monitorCtxt in processMonitorThreads)
                {
                    if(monitorCtxt.threadObject.monitor.name == monitorName)
                    {
                        unique = false;
                        break;
                    }

                }
            }

            return unique;
        }

        //Solicita actualizacion de los datagrid
        public void RefreshDataGrids(bool services, bool process)
        {
            if (this.InvokeRequired)
            {
                try
                {
                    MethodInvoker del = delegate { RefreshDataGrids(services, process); };
                    this.Invoke(del);
                }
                catch
                {
                }

                return;
            }

            refreshDataGrids(services, process);
        }
        private void refreshDataGrids(bool services, bool process)
        {
            if (services)
                this.dataGridView_services.Refresh();
            if (process)
                this.dataGridView_process.Refresh();
        }

        //Devuelve los valores recolectados por los hilos
        public List<ServiceMonitor> InfoServiceMonitors()
        {
            List<ServiceMonitor> _monitors = new List<ServiceMonitor>();
            foreach (ThreadContext threadCtxt in serviceMonitorThreads)
            {
                _monitors.Add((ServiceMonitor) threadCtxt.threadObject.monitor);
            }
            
            return _monitors;
        }
        public List<ProcessMonitor> InfoProcessMonitors()
        {
            List<ProcessMonitor> _monitors = new List<ProcessMonitor>();
            foreach (ThreadContext threadCtxt in processMonitorThreads)
            {
                _monitors.Add((ProcessMonitor)threadCtxt.threadObject.monitor);
            }

            return _monitors;
        }

        //Setters & Getters
        public static ConfigForm.GralConfigData GralConfig { get { return _gralConfigData; } }
        public static ConfigForm.EmailConfigData EmailConfig { get { return _emailConfigData; } }

        //Atributos
        bool monitoring;
        private Thread statusReporterUpdater;
        private StatusReporter statusReporter;
        private List<ThreadContext> serviceMonitorThreads;
        private List<ThreadContext> processMonitorThreads;

        private static ConfigForm.GralConfigData _gralConfigData;
        private static ConfigForm.EmailConfigData _emailConfigData;
    }
}
