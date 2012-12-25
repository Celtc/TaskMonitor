using System;
using System.Management;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Threading;
using System.Security.Principal;
using System.Security.Permissions;
using System.Diagnostics;
using System.Management.Instrumentation;


namespace TaskMonitor.Sources
{
    public class ServiceTools
    {
        private const int STANDARD_RIGHTS_REQUIRED = 0xF0000;
        private const int SERVICE_WIN32_OWN_PROCESS = 0x00000010;

        [StructLayout(LayoutKind.Sequential)]
        private class SERVICE_STATUS
        {
            public int dwServiceType = 0;
            public ServiceState dwCurrentState = 0;
            public int dwControlsAccepted = 0;
            public int dwWin32ExitCode = 0;
            public int dwServiceSpecificExitCode = 0;
            public int dwCheckPoint = 0;
            public int dwWaitHint = 0;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct Service : IComparable<Service>
        {
            public Service(string name, string displayName, ServiceState state, ServiceStatus status, ServiceStartMode startMode)
            {
                this.name = name;
                this.displayName = displayName;
                this.state = state;
                this.status = status;
                this.startMode = startMode;
            }

            public int CompareTo(Service b)
            {
                return this.displayName.CompareTo(b.displayName);
            }

            public string Name { get { return name; } }
            public string DisplayName { get { return displayName; } }
            public string FullName { get { return displayName + " (" + name + ".exe)"; } }
            public ServiceState State { get { return state; } }
            public ServiceStatus Status { get { return status; } }
            public ServiceStartMode StartMode { get { return startMode; } }

            string name;
            string displayName;
            ServiceState state;
            ServiceStatus status;
            ServiceStartMode startMode;
        }

        #region OpenSCManager
        [DllImport("advapi32.dll", EntryPoint = "OpenSCManagerW", ExactSpelling = true, CharSet = CharSet.Unicode, SetLastError = true)]
        static extern IntPtr OpenSCManager(string machineName, string databaseName, ScmAccessRights dwDesiredAccess);
        #endregion

        #region OpenService
        [DllImport("advapi32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static extern IntPtr OpenService(IntPtr hSCManager, string lpServiceName, ServiceAccessRights dwDesiredAccess);
        #endregion

        #region CreateService
        [DllImport("advapi32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern IntPtr CreateService(IntPtr hSCManager, string lpServiceName, string lpDisplayName, ServiceAccessRights dwDesiredAccess, int dwServiceType, ServiceBootFlag dwStartType, ServiceError dwErrorControl, string lpBinaryPathName, string lpLoadOrderGroup, IntPtr lpdwTagId, string lpDependencies, string lp, string lpPassword);
        #endregion

        #region CloseServiceHandle
        [DllImport("advapi32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool CloseServiceHandle(IntPtr hSCObject);
        #endregion

        #region QueryServiceStatus
        [DllImport("advapi32.dll")]
        private static extern int QueryServiceStatus(IntPtr hService, SERVICE_STATUS lpServiceStatus);
        #endregion

        #region DeleteService
        [DllImport("advapi32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool DeleteService(IntPtr hService);
        #endregion

        #region ControlService
        [DllImport("advapi32.dll")]
        private static extern int ControlService(IntPtr hService, ServiceControl dwControl, SERVICE_STATUS lpServiceStatus);
        #endregion

        #region StartService
        [DllImport("advapi32.dll", SetLastError = true)]
        private static extern int StartService(IntPtr hService, int dwNumServiceArgs, int lpServiceArgVectors);
        #endregion

        //Builder
        public ServiceTools()
        {
            this.scopeConnected = false;
            this.scope = null;
        }

        public void Uninstall(string serviceName)
        {
            IntPtr scm = OpenSCManager(ScmAccessRights.AllAccess);

            try
            {
                IntPtr service = OpenService(scm, serviceName, ServiceAccessRights.AllAccess);
                if (service == IntPtr.Zero)
                    throw new ApplicationException("Service not installed.");

                try
                {
                    StopService(service);
                    if (!DeleteService(service))
                        throw new ApplicationException("Could not delete service " + Marshal.GetLastWin32Error());
                }
                finally
                {
                    CloseServiceHandle(service);
                }
            }
            finally
            {
                CloseServiceHandle(scm);
            }
        }

        public bool ServiceIsInstalled(string serviceName)
        {
            IntPtr scm = OpenSCManager(ScmAccessRights.Connect);

            try
            {
                IntPtr service = OpenService(scm, serviceName, ServiceAccessRights.QueryStatus);

                if (service == IntPtr.Zero)
                    return false;

                CloseServiceHandle(service);
                return true;
            }
            finally
            {
                CloseServiceHandle(scm);
            }
        }

        public void InstallAndStart(string serviceName, string displayName, string fileName)
        {
            IntPtr scm = OpenSCManager(ScmAccessRights.AllAccess);

            try
            {
                IntPtr service = OpenService(scm, serviceName, ServiceAccessRights.AllAccess);

                if (service == IntPtr.Zero)
                    service = CreateService(scm, serviceName, displayName, ServiceAccessRights.AllAccess, SERVICE_WIN32_OWN_PROCESS, ServiceBootFlag.AutoStart, ServiceError.Normal, fileName, null, IntPtr.Zero, null, null, null);

                if (service == IntPtr.Zero)
                    throw new ApplicationException("Failed to install service.");

                try
                {
                    StartService(service);
                }
                finally
                {
                    CloseServiceHandle(service);
                }
            }
            finally
            {
                CloseServiceHandle(scm);
            }
        }

        public void StartService(string serviceName)
        {
            IntPtr scm = OpenSCManager(ScmAccessRights.Connect);

            try
            {
                IntPtr service = OpenService(scm, serviceName, ServiceAccessRights.QueryStatus | ServiceAccessRights.Start);
                if (service == IntPtr.Zero)
                    throw new ApplicationException("Could not open service.");

                try
                {
                    StartService(service);
                }
                finally
                {
                    CloseServiceHandle(service);
                }
            }
            finally
            {
                CloseServiceHandle(scm);
            }
        }

        public void StopService(string serviceName)
        {
            IntPtr scm = OpenSCManager(ScmAccessRights.Connect);

            try
            {
                IntPtr service = OpenService(scm, serviceName, ServiceAccessRights.QueryStatus | ServiceAccessRights.Stop);
                if (service == IntPtr.Zero)
                    throw new ApplicationException("Could not open service.");

                try
                {
                    StopService(service);
                }
                finally
                {
                    CloseServiceHandle(service);
                }
            }
            finally
            {
                CloseServiceHandle(scm);
            }
        }

        public ServiceState GetServiceStatus(string serviceName)
        {
            IntPtr scm = OpenSCManager(ScmAccessRights.Connect);

            try
            {
                IntPtr service = OpenService(scm, serviceName, ServiceAccessRights.QueryStatus);
                if (service == IntPtr.Zero)
                    return ServiceState.NotFound;

                try
                {
                    return GetServiceStatus(service);
                }
                finally
                {
                    CloseServiceHandle(service);
                }
            }
            finally
            {
                CloseServiceHandle(scm);
            }
        }

        public List<Service> GetRemoteServices()
        {
            if (!scopeConnected)
                return null;

            try
            {
                ObjectQuery selectQuery = new ObjectQuery("Select name, displayname, state, status, startmode from Win32_Service");
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, selectQuery);

                List<Service> services = new List<Service>();
                foreach (ManagementObject servicio in searcher.Get())
                {
                    services.Add(new Service(servicio["Name"].ToString(),
                                             servicio["DisplayName"].ToString(),
                                             (ServiceState)Enum.Parse(typeof(ServiceState),servicio["State"].ToString()),
                                             (ServiceStatus)Enum.Parse(typeof(ServiceStatus), servicio["Status"].ToString()),
                                             (ServiceStartMode)Enum.Parse(typeof(ServiceStartMode), servicio["StartMode"].ToString())));
                }

                services.Sort();
                return services;
            }
            catch
            {
                return null;
            }
        }

        public List<Service> GetRemoteServices(string query)
        {
            if (!scopeConnected)
                return null;

            try
            {
                ObjectQuery selectQuery = new ObjectQuery(query);
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, selectQuery);

                List<Service> services = new List<Service>();
                foreach (ManagementObject servicio in searcher.Get())
                {
                    services.Add(new Service(servicio["Name"].ToString(),
                                             servicio["DisplayName"].ToString(),
                                             (ServiceState)Enum.Parse(typeof(ServiceState), servicio["State"].ToString()),
                                             (ServiceStatus)Enum.Parse(typeof(ServiceStatus), servicio["Status"].ToString()),
                                             (ServiceStartMode)Enum.Parse(typeof(ServiceStartMode), servicio["StartMode"].ToString())));
                }

                services.Sort();
                return services;
            }
            catch
            {
                return null;
            }
        }

        public List<string> GetRemoteProcess()
        {
            if (!scopeConnected)
                return null;

            try
            {
                ObjectQuery selectQuery = new ObjectQuery("Select * from Win32_Process");
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, selectQuery);

                List<string> services = new List<string>();
                foreach (ManagementObject servicio in searcher.Get())
                {
                    services.Add(servicio["Name"].ToString());
                }

                return services;
            }
            catch
            {
                return null;
            }
        }

        public int ConnectRemoteMachine(string remoteMachine, string domain, string username, string password)
        {
            try
            {
                //Ruta de administración del equipo remoto (la conexion necesita acceso RPC: "netsh firewall set service RemoteAdmin")
                ManagementPath path = new ManagementPath("\\\\" + remoteMachine + "\\root\\cimv2");
                ConnectionOptions conexion = new ConnectionOptions();
                conexion.Username = username;
                conexion.Password = password;
                if (domain != null && domain != "")
                    conexion.Authority = "ntlmdomain:" + domain;

                scope = new ManagementScope(path, conexion);
                scope.Connect();
                scopeConnected = true;
            }
            catch (Exception e)
            {
                if (e.Message.Contains("80070005"))
                    return 1;
                else if (e.Message.Contains("800706BA"))
                    return 2;
                else
                    return 3;
            }

            return 0;
        }

        #region Private Methods
        private void StartService(IntPtr service)
        {
            SERVICE_STATUS status = new SERVICE_STATUS();
            StartService(service, 0, 0);
            var changedStatus = WaitForServiceStatus(service, ServiceState.StartPending, ServiceState.Running);
            if (!changedStatus)
                throw new ApplicationException("Unable to start service");
        }

        private void StopService(IntPtr service)
        {
            SERVICE_STATUS status = new SERVICE_STATUS();
            ControlService(service, ServiceControl.Stop, status);
            var changedStatus = WaitForServiceStatus(service, ServiceState.StopPending, ServiceState.Stopped);
            if (!changedStatus)
                throw new ApplicationException("Unable to stop service");
        }

        private ServiceState GetServiceStatus(IntPtr service)
        {
            SERVICE_STATUS status = new SERVICE_STATUS();

            if (QueryServiceStatus(service, status) == 0)
                throw new ApplicationException("Failed to query service status.");

            return status.dwCurrentState;
        }

        private bool WaitForServiceStatus(IntPtr service, ServiceState waitStatus, ServiceState desiredStatus)
        {
            SERVICE_STATUS status = new SERVICE_STATUS();

            QueryServiceStatus(service, status);
            if (status.dwCurrentState == desiredStatus) return true;

            int dwStartTickCount = Environment.TickCount;
            int dwOldCheckPoint = status.dwCheckPoint;

            while (status.dwCurrentState == waitStatus)
            {
                // Do not wait longer than the wait hint. A good interval is
                // one tenth the wait hint, but no less than 1 second and no
                // more than 10 seconds.

                int dwWaitTime = status.dwWaitHint / 10;

                if (dwWaitTime < 1000) dwWaitTime = 1000;
                else if (dwWaitTime > 10000) dwWaitTime = 10000;

                Thread.Sleep(dwWaitTime);

                // Check the status again.

                if (QueryServiceStatus(service, status) == 0) break;

                if (status.dwCheckPoint > dwOldCheckPoint)
                {
                    // The service is making progress.
                    dwStartTickCount = Environment.TickCount;
                    dwOldCheckPoint = status.dwCheckPoint;
                }
                else
                {
                    if (Environment.TickCount - dwStartTickCount > status.dwWaitHint)
                    {
                        // No progress made within the wait hint
                        break;
                    }
                }
            }
            return (status.dwCurrentState == desiredStatus);
        }

        private IntPtr OpenSCManager(ScmAccessRights rights)
        {
            IntPtr scm = OpenSCManager(null, null, rights);
            if (scm == IntPtr.Zero)
                throw new ApplicationException("Could not connect to service control manager.");

            return scm;
        }
        #endregion

        private ManagementScope scope;
        private bool scopeConnected;
    }

    public enum ServiceStatus
    {
        OK = 0,
        Error = 1
    }

    public enum ServiceState
    {
        Unknown = -1, // The state cannot be (has not been) retrieved.
        NotFound = 0, // The service is not known on the host server.
        Stopped = 1,
        StartPending = 2,
        StopPending = 3,
        Running = 4,
        ContinuePending = 5,
        PausePending = 6,
        Paused = 7
    }

    public enum ServiceStartMode
    {
        Disabled = 0x1,
        Manual = 0x2,
        Auto = 0x3
    }

    [Flags]
    public enum ScmAccessRights
    {
        Connect = 0x0001,
        CreateService = 0x0002,
        EnumerateService = 0x0004,
        Lock = 0x0008,
        QueryLockStatus = 0x0010,
        ModifyBootConfig = 0x0020,
        StandardRightsRequired = 0xF0000,
        AllAccess = (StandardRightsRequired | Connect | CreateService |
                     EnumerateService | Lock | QueryLockStatus | ModifyBootConfig)
    }

    [Flags]
    public enum ServiceAccessRights
    {
        QueryConfig = 0x1,
        ChangeConfig = 0x2,
        QueryStatus = 0x4,
        EnumerateDependants = 0x8,
        Start = 0x10,
        Stop = 0x20,
        PauseContinue = 0x40,
        Interrogate = 0x80,
        UserDefinedControl = 0x100,
        Delete = 0x00010000,
        StandardRightsRequired = 0xF0000,
        AllAccess = (StandardRightsRequired | QueryConfig | ChangeConfig |
                     QueryStatus | EnumerateDependants | Start | Stop | PauseContinue |
                     Interrogate | UserDefinedControl)
    }

    public enum ServiceBootFlag
    {
        Start = 0x00000000,
        SystemStart = 0x00000001,
        AutoStart = 0x00000002,
        DemandStart = 0x00000003,
        Disabled = 0x00000004
    }

    public enum ServiceControl
    {
        Stop = 0x00000001,
        Pause = 0x00000002,
        Continue = 0x00000003,
        Interrogate = 0x00000004,
        Shutdown = 0x00000005,
        ParamChange = 0x00000006,
        NetBindAdd = 0x00000007,
        NetBindRemove = 0x00000008,
        NetBindEnable = 0x00000009,
        NetBindDisable = 0x0000000A
    }

    public enum ServiceError
    {
        Ignore = 0x00000000,
        Normal = 0x00000001,
        Severe = 0x00000002,
        Critical = 0x00000003
    }
}
