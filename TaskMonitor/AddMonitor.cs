using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using TaskMonitor.Sources;

namespace TaskMonitor
{
    public partial class AddMonitor : Form
    {
        //Builder
        public AddMonitor(MonitorMgr caller)
        {
            InitializeComponent();

            this.comboBox_proc_cpuUsageRelative.SelectedIndex = 0;
            this.comboBox_proc_mustRun.SelectedIndex = 0;
            this.comboBox_serv_critic.SelectedIndex = 0;
            this.comboBox_serv_startMode.SelectedIndex = 0;
            this.comboBox_serv_state.SelectedIndex = 0;
            this.comboBox_serv_status.SelectedIndex = 0;

            serviceMgr = new ServiceTools();
            showGroupBoxMode(Mode.service);
            this.caller = caller;
            connected = false;
            mode = null;
        }

        //Conexion
        private bool connect()
        {
            int ans;
            Form connectingMsg = new MessageForm("Info", "Conectando...");
            connectingMsg.Show();

            if ((ans = serviceMgr.ConnectRemoteMachine(this.textBox_machineName.Text, this.textBox_domain.Text, this.textBox_username.Text, this.textBox_password.Text)) != 0)
            {
                string errorCause;
                if (ans == 1)
                    errorCause = "Acceso denegado.";
                else if (ans == 2)
                    errorCause = "Servidor remoto no disponible o no autorizado.";
                else
                    errorCause = "Intente nuevamente.";

                connectingMsg.Close();
                connected = false;
                MessageBox.Show("No se pudo conectar al equipo remoto: " + errorCause, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                connected = true;
                connectingMsg.Close();
            }

            return connected;
        }

        #region Botones
        private void button_listServices_Click(object sender, EventArgs e)
        {
            if (!connected && !this.connect())
                return;

            Form retrievingMsg = new MessageForm("Info", "Solicitando datos...");
            retrievingMsg.Show();

            var state = serviceMgr.GetRemoteServices();
            this.listBox_results.DataSource = state;
            this.listBox_results.DisplayMember = "FullName";

            showGroupBoxMode(Mode.service);
            retrievingMsg.Close();
        }

        private void button_listProccess_Click(object sender, EventArgs e)
        {
            if (!connected && !this.connect())
                return;

            Form retrievingMsg = new MessageForm("Info", "Solicitando datos...");
            retrievingMsg.Show();

            var state = serviceMgr.GetRemoteProcess();
            this.listBox_results.DataSource = state;
            this.listBox_results.DisplayMember = "";

            showGroupBoxMode(Mode.process);
            retrievingMsg.Close();
        }
        
        private void button_cancelNewMonitor_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_addNewMonitor_Click(object sender, EventArgs e)
        {
            if (!this.connected)
            {
                MessageBox.Show("Debe conectar a un equipo remoto primero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (this.listBox_results.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un proceso o servicio a monitorear.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (this.textBox_monitorName.Text == null || this.textBox_monitorName.Text == "")
            {
                MessageBox.Show("El nombre del monitor no es válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!caller.IsUnique(this.textBox_monitorName.Text, (Mode)this.mode))
            {
                MessageBox.Show("Ya existe un monitor con ese nombre.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (this.mode == Mode.service)
            {
                ReturnValue = createNewServiceMonitor();
            }
            else // mode == Mode.process
            {
                MessageBox.Show("Monitor de procesos no disponible.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
                //ReturnValue = createNewProcessMonitor();
            }

            if (ReturnValue == null)
            {
                MessageBox.Show("Las opciones seleccioandas para el nuevo monitor no son validas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }
        #endregion

        private void showGroupBoxMode(Mode mode)
        {
            if (mode == Mode.service)
            {
                this.groupBox_processObjective.Hide();
                this.groupBox_serviceObjective.Show();
                this.mode = Mode.service;
            }
            else
            {
                this.groupBox_serviceObjective.Hide();
                this.groupBox_processObjective.Show();
                this.mode = Mode.process;
            }
        }

        private ServiceMonitor createNewServiceMonitor()
        {
            string targetName = ((List<TaskMonitor.Sources.ServiceTools.Service>)this.listBox_results.DataSource)[this.listBox_results.SelectedIndex].Name;
            ServiceState? selectedState = null;
            ServiceStatus? selectedStatus = null;
            ServiceStartMode? selectedStartMode = null;
            bool selectedCritic;

            switch(this.comboBox_serv_state.SelectedIndex)
            {
                case 0: selectedState = ServiceState.Running; break;
                case 1: selectedState = ServiceState.Paused; break;
                case 2: selectedState = ServiceState.Stopped; break;
                case 3: selectedState = ServiceState.NotFound; break;
                case 4: selectedState = null; break;
            }

            switch(this.comboBox_serv_status.SelectedIndex)
            {
                case 0: selectedStatus = ServiceStatus.OK; break;
                case 1: selectedStatus = ServiceStatus.Error; break;
                case 2: selectedStatus = null; break;
            }

            switch(this.comboBox_serv_startMode.SelectedIndex)
            {
                case 0: selectedStartMode = ServiceStartMode.Auto; break;
                case 1: selectedStartMode = ServiceStartMode.Manual; break;
                case 2: selectedStartMode = ServiceStartMode.Disabled; break;
                case 3: selectedStartMode = null; break;
            }

            selectedCritic = (this.comboBox_serv_critic.SelectedText == "Si");

            if(selectedState == null && selectedStatus == null && selectedStartMode == null)
                return null;

            ServiceMonitor monitor = new ServiceMonitor(this.textBox_monitorName.Text, targetName ,this.textBox_machineName.Text, this.textBox_username.Text, 
                                                        this.textBox_password.Text, this.textBox_domain.Text, selectedState, selectedStatus, selectedStartMode, 
                                                        selectedCritic);

            return monitor;
        }

        private ProcessMonitor createNewProcessMonitor()
        {
            string targetName = ((List<string>)this.listBox_results.DataSource)[this.listBox_results.SelectedIndex];
            bool? selectedMustRun = null;
            bool selectedCheckCpuUsage;
            int selectedCpuUsageRelative;
            int selectedCpuUsageValue;

            switch (this.comboBox_proc_mustRun.SelectedIndex)
            {
                case 0: selectedMustRun = true; break;
                case 1: selectedMustRun = false; break;
                case 2: selectedMustRun = null; break;
            }

            selectedCpuUsageValue = int.Parse(this.textBox_proc_cpuUsageValue.Text);
            selectedCpuUsageRelative = this.comboBox_proc_cpuUsageRelative.SelectedIndex;
            selectedCheckCpuUsage = this.checkBox_proc_cpuUsage.Checked;

            if (selectedMustRun == null && !selectedCheckCpuUsage)
                return null;

            ProcessMonitor monitor = new ProcessMonitor(this.textBox_monitorName.Text, targetName, this.textBox_machineName.Text, this.textBox_username.Text, 
                                                        this.textBox_password.Text, this.textBox_domain.Text, selectedMustRun, selectedCheckCpuUsage, 
                                                        selectedCpuUsageRelative, selectedCpuUsageValue);

            return monitor;
        }

        //Public attrib.
        public Monitor ReturnValue { get; set; }

        //Private attrib.
        private MonitorMgr caller;
        private ServiceTools serviceMgr;
        private bool connected;
        private Mode? mode;
    }

    public enum Mode
    {
        service = 1,
        process = 2
    }       
}
