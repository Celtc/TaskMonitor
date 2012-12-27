using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace TaskMonitor.Sources
{
    public class MonitorThread
    {
        //Builder
        public MonitorThread(Monitor monitor, bool running)
        {
            this.monitor = monitor;
            this.suspensionLvl = 0;
            this.serviceMgr = new ServiceTools();
            this.suspendMtx = new Mutex();

            if (!running)
                SuspendThread();
        }

        //Funcion inicial
        public void MainMethod()
        {
            //Loop de chequeo
            if (monitor.mode == Mode.service)
                ServiceCheckLoop();
            else
                ProcessCheckLoop();
        }

        //Ciclo de verificación: servicio
        private void ServiceCheckLoop()
        {
            //Castea el monitor al tipo adecuado
            ServiceMonitor sMonitor = (ServiceMonitor)this.monitor;

            //Variable de devolucion de la consulta
            List<TaskMonitor.Sources.ServiceTools.Service> queryResult;

            //Consulta a la DB de windows
            string query = "Select name, displayname, state, status, startmode From Win32_Service Where name = '" + monitor.target + "'";

            //Loop
            while(!_endThread)
            {
                //Garantiza la atomicidad del proceso
                this.suspendMtx.WaitOne();

                //Setea los parametros en null para luego reemplazarlo por su valor real
                bool dataGathered = true;

                //Verifica la conexion
                if (!this._connected && this.serviceMgr.ConnectRemoteMachine(monitor.remoteMachine, monitor.domain, monitor.username, monitor.password) != 0)
                {
                    //Error: no se pudo conectar
                    dataGathered = false;
                }

                //Trae los datos
                else if ((queryResult = serviceMgr.GetRemoteServices(query)) == null)
                {
                    //Error: error en la busqueda, reconectando
                    this._connected = false;
                    dataGathered = false;
                }
                else
                {
                    if (queryResult.Count == 0)
                    {
                        //Error: no lo encontro
                        dataGathered = false;
                    }
                    else
                    {
                        sMonitor.actualStatus = queryResult[0].Status;
                        sMonitor.actualState = queryResult[0].State;
                        sMonitor.actualStartMode = queryResult[0].StartMode;
                    }
                }

                //Si no logro conseguir la info por algun motivo informa el error y reinicia el loop
                if (!dataGathered)
                {
                    sMonitor.actualStatus = null;
                    sMonitor.actualState = null;
                    sMonitor.actualStartMode = null;
                    this.monitor.error = true;
                    this.suspendMtx.ReleaseMutex();
                    Thread.Sleep(MonitorMgr.GralConfig.queryingInterval);
                    continue;
                }

                //Verifica contra los objetivos del monitor
                if (sMonitor.wantedStatus != null && sMonitor.wantedStatus != sMonitor.actualStatus)
                {
                    this.monitor.error = true;
                    this.suspendMtx.ReleaseMutex();
                    Thread.Sleep(MonitorMgr.GralConfig.queryingInterval);
                    continue;
                }
                if (sMonitor.wantedState != null && sMonitor.wantedState != sMonitor.actualState)
                {
                    this.monitor.error = true;
                    this.suspendMtx.ReleaseMutex();
                    Thread.Sleep(MonitorMgr.GralConfig.queryingInterval);
                    continue;
                }
                if (sMonitor.wantedStartMode != null && sMonitor.wantedStartMode != sMonitor.actualStartMode)
                {
                    this.monitor.error = true;
                    this.suspendMtx.ReleaseMutex();
                    Thread.Sleep(MonitorMgr.GralConfig.queryingInterval);
                    continue;
                }

                //Si llega hasta aca todos los chequeos fueron correctos
                this.monitor.error = false;
                this.suspendMtx.ReleaseMutex();
                Thread.Sleep(MonitorMgr.GralConfig.queryingInterval);
            }

            //Finaliza el hilo
            this.StopThread();
        }

        //Ciclo de verificación: proceso
        private void ProcessCheckLoop()
        {
        }

        //Funcion de finalizacion del thread
        public void RequestStop()
        {
            while (suspensionLvl > 0) this.ReleaseThread();
            this._endThread = true;
        }

        //Deshabilita el monitoreo
        public void DisableThread()
        {
            this.monitor.enable = false;
            this.SuspendThread();
        }

        //Habilita el hilo
        public void EnableThread()
        {
            this.monitor.enable = true;
            this.ReleaseThread();
        }

        //Suspende el hilo
        public void SuspendThread()
        {
            this.suspendMtx.WaitOne();
            this.suspensionLvl++;
        }

        //Libera el hilo
        public void ReleaseThread()
        {
            this.suspendMtx.ReleaseMutex();
            this.suspensionLvl--;
        }

        //Funcion de finalizacion
        private void StopThread()
        {
            Thread.CurrentThread.Abort();
        }

        //Atributos publicos
        public Monitor monitor;

        //Atributos privados
        private int suspensionLvl;
        private Mutex suspendMtx;
        private ServiceTools serviceMgr;
        private volatile bool _endThread = false;
        private bool _connected = false;
    }
}
