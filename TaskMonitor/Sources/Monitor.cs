using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TaskMonitor.Sources
{
    public class Monitor
    {
        //Builder
        public Monitor(string monitorName, string target, string remoteMachine, string username, string password, string domain)
        {
            this.name = monitorName;
            this.target = target;
            this.remoteMachine = remoteMachine;
            this.username = username;
            this.password = password;
            this.domain = domain;
            this.error = false;
            this.enable = true;
        }

        //Setter & Getters
        public string Name { get { return name; } }

        public bool enable;
        public string name;
        public string target;
        public string remoteMachine;
        public string username;
        public string password;
        public string domain;
        public bool error;
        public Mode mode;
    }

    public class ServiceMonitor : Monitor
    {
        //Builder (Hereda el constructor base)
        public ServiceMonitor(string monitorName,string target, string remoteMachine, string username, string password, string domain,
                              ServiceState? state, ServiceStatus? status, ServiceStartMode? startMode, bool critic) :
            base(monitorName, target, remoteMachine, username, password, domain)
        {
            this.wantedState = state;
            this.wantedStatus = status;
            this.wantedStartMode = startMode;

            this.actualState = null;
            this.actualStatus = null;
            this.actualStartMode = null;

            this.critic = critic;
            this.mode = Mode.service;
        }

        public ServiceState? wantedState;
        public ServiceStatus? wantedStatus;
        public ServiceStartMode? wantedStartMode;

        public ServiceState? actualState;
        public ServiceStatus? actualStatus;
        public ServiceStartMode? actualStartMode;

        public bool critic;
    }

    public class ProcessMonitor : Monitor
    {
        //Builder (Hereda el constructor base)
        public ProcessMonitor(string monitorName, string target, string remoteMachine, string username, string password, string domain,
                              bool? mustRun, bool checkCpuUsage, int cpuUsageRelative, int wantedCpuUsageValue) :
            base(monitorName, target, remoteMachine, username, password, domain)
        {
            this.mustRun = mustRun;
            this.checkCpuUsage = checkCpuUsage;
            this.cpuUsageRelative = cpuUsageRelative;
            this.wantedCpuUsageValue = wantedCpuUsageValue;

            this.running = false;
            this.actualCpuUsageValue = 0;

            this.mode = Mode.process;
        }

        public bool? mustRun;
        public bool running;
        public bool checkCpuUsage;
        public int cpuUsageRelative;
        public int wantedCpuUsageValue;
        public int actualCpuUsageValue;
    }
}
