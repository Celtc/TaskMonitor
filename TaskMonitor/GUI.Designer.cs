namespace TaskMonitor
{
    partial class AddMonitor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddMonitor));
            this.button_listServices = new System.Windows.Forms.Button();
            this.listBox_results = new System.Windows.Forms.ListBox();
            this.button_listProccess = new System.Windows.Forms.Button();
            this.textBox_username = new System.Windows.Forms.TextBox();
            this.textBox_password = new System.Windows.Forms.TextBox();
            this.label_username = new System.Windows.Forms.Label();
            this.label_password = new System.Windows.Forms.Label();
            this.label_domain = new System.Windows.Forms.Label();
            this.label_machineName = new System.Windows.Forms.Label();
            this.textBox_domain = new System.Windows.Forms.TextBox();
            this.textBox_machineName = new System.Windows.Forms.TextBox();
            this.groupBox_listOptions = new System.Windows.Forms.GroupBox();
            this.groupBox_serviceObjective = new System.Windows.Forms.GroupBox();
            this.label_critic = new System.Windows.Forms.Label();
            this.comboBox_serv_critic = new System.Windows.Forms.ComboBox();
            this.label_state = new System.Windows.Forms.Label();
            this.comboBox_serv_state = new System.Windows.Forms.ComboBox();
            this.label_startMode = new System.Windows.Forms.Label();
            this.comboBox_serv_startMode = new System.Windows.Forms.ComboBox();
            this.label_status = new System.Windows.Forms.Label();
            this.comboBox_serv_status = new System.Windows.Forms.ComboBox();
            this.groupBox_processObjective = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_proc_cpuUsageValue = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox_proc_cpuUsageRelative = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBox_proc_cpuUsage = new System.Windows.Forms.CheckBox();
            this.label_mustrun = new System.Windows.Forms.Label();
            this.comboBox_proc_mustRun = new System.Windows.Forms.ComboBox();
            this.button_cancelNewMonitor = new System.Windows.Forms.Button();
            this.button_addNewMonitor = new System.Windows.Forms.Button();
            this.groupBox_monitorName = new System.Windows.Forms.GroupBox();
            this.textBox_monitorName = new System.Windows.Forms.TextBox();
            this.groupBox_listOptions.SuspendLayout();
            this.groupBox_serviceObjective.SuspendLayout();
            this.groupBox_processObjective.SuspendLayout();
            this.groupBox_monitorName.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_listServices
            // 
            this.button_listServices.Location = new System.Drawing.Point(6, 19);
            this.button_listServices.Name = "button_listServices";
            this.button_listServices.Size = new System.Drawing.Size(75, 23);
            this.button_listServices.TabIndex = 0;
            this.button_listServices.Text = "Servicios";
            this.button_listServices.UseVisualStyleBackColor = true;
            this.button_listServices.Click += new System.EventHandler(this.button_listServices_Click);
            // 
            // listBox_results
            // 
            this.listBox_results.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox_results.FormattingEnabled = true;
            this.listBox_results.Location = new System.Drawing.Point(15, 137);
            this.listBox_results.Name = "listBox_results";
            this.listBox_results.Size = new System.Drawing.Size(446, 407);
            this.listBox_results.TabIndex = 20;
            // 
            // button_listProccess
            // 
            this.button_listProccess.Location = new System.Drawing.Point(98, 19);
            this.button_listProccess.Name = "button_listProccess";
            this.button_listProccess.Size = new System.Drawing.Size(75, 23);
            this.button_listProccess.TabIndex = 1;
            this.button_listProccess.Text = "Procesos";
            this.button_listProccess.UseVisualStyleBackColor = true;
            this.button_listProccess.Click += new System.EventHandler(this.button_listProccess_Click);
            // 
            // textBox_username
            // 
            this.textBox_username.Location = new System.Drawing.Point(61, 45);
            this.textBox_username.Name = "textBox_username";
            this.textBox_username.Size = new System.Drawing.Size(161, 20);
            this.textBox_username.TabIndex = 2;
            // 
            // textBox_password
            // 
            this.textBox_password.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_password.Location = new System.Drawing.Point(300, 45);
            this.textBox_password.Name = "textBox_password";
            this.textBox_password.PasswordChar = '*';
            this.textBox_password.Size = new System.Drawing.Size(161, 20);
            this.textBox_password.TabIndex = 3;
            this.textBox_password.UseSystemPasswordChar = true;
            // 
            // label_username
            // 
            this.label_username.AutoSize = true;
            this.label_username.Location = new System.Drawing.Point(12, 48);
            this.label_username.Name = "label_username";
            this.label_username.Size = new System.Drawing.Size(43, 13);
            this.label_username.TabIndex = 6;
            this.label_username.Text = "Usuario";
            // 
            // label_password
            // 
            this.label_password.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_password.AutoSize = true;
            this.label_password.Location = new System.Drawing.Point(233, 48);
            this.label_password.Name = "label_password";
            this.label_password.Size = new System.Drawing.Size(61, 13);
            this.label_password.TabIndex = 7;
            this.label_password.Text = "Contraseña";
            // 
            // label_domain
            // 
            this.label_domain.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_domain.AutoSize = true;
            this.label_domain.Location = new System.Drawing.Point(233, 15);
            this.label_domain.Name = "label_domain";
            this.label_domain.Size = new System.Drawing.Size(45, 13);
            this.label_domain.TabIndex = 11;
            this.label_domain.Text = "Dominio";
            // 
            // label_machineName
            // 
            this.label_machineName.AutoSize = true;
            this.label_machineName.Location = new System.Drawing.Point(12, 15);
            this.label_machineName.Name = "label_machineName";
            this.label_machineName.Size = new System.Drawing.Size(40, 13);
            this.label_machineName.TabIndex = 10;
            this.label_machineName.Text = "Equipo";
            // 
            // textBox_domain
            // 
            this.textBox_domain.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_domain.Location = new System.Drawing.Point(300, 12);
            this.textBox_domain.Name = "textBox_domain";
            this.textBox_domain.Size = new System.Drawing.Size(161, 20);
            this.textBox_domain.TabIndex = 1;
            // 
            // textBox_machineName
            // 
            this.textBox_machineName.Location = new System.Drawing.Point(61, 12);
            this.textBox_machineName.Name = "textBox_machineName";
            this.textBox_machineName.Size = new System.Drawing.Size(161, 20);
            this.textBox_machineName.TabIndex = 0;
            // 
            // groupBox_listOptions
            // 
            this.groupBox_listOptions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox_listOptions.Controls.Add(this.button_listServices);
            this.groupBox_listOptions.Controls.Add(this.button_listProccess);
            this.groupBox_listOptions.Location = new System.Drawing.Point(281, 81);
            this.groupBox_listOptions.Name = "groupBox_listOptions";
            this.groupBox_listOptions.Size = new System.Drawing.Size(180, 50);
            this.groupBox_listOptions.TabIndex = 4;
            this.groupBox_listOptions.TabStop = false;
            this.groupBox_listOptions.Text = "Listar";
            // 
            // groupBox_serviceObjective
            // 
            this.groupBox_serviceObjective.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox_serviceObjective.Controls.Add(this.label_critic);
            this.groupBox_serviceObjective.Controls.Add(this.comboBox_serv_critic);
            this.groupBox_serviceObjective.Controls.Add(this.label_state);
            this.groupBox_serviceObjective.Controls.Add(this.comboBox_serv_state);
            this.groupBox_serviceObjective.Controls.Add(this.label_startMode);
            this.groupBox_serviceObjective.Controls.Add(this.comboBox_serv_startMode);
            this.groupBox_serviceObjective.Controls.Add(this.label_status);
            this.groupBox_serviceObjective.Controls.Add(this.comboBox_serv_status);
            this.groupBox_serviceObjective.Location = new System.Drawing.Point(15, 555);
            this.groupBox_serviceObjective.Name = "groupBox_serviceObjective";
            this.groupBox_serviceObjective.Size = new System.Drawing.Size(446, 79);
            this.groupBox_serviceObjective.TabIndex = 5;
            this.groupBox_serviceObjective.TabStop = false;
            this.groupBox_serviceObjective.Text = "Propiedades Deseadas";
            // 
            // label_critic
            // 
            this.label_critic.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_critic.AutoSize = true;
            this.label_critic.Location = new System.Drawing.Point(252, 49);
            this.label_critic.Name = "label_critic";
            this.label_critic.Size = new System.Drawing.Size(38, 13);
            this.label_critic.TabIndex = 7;
            this.label_critic.Text = "Crítico";
            // 
            // comboBox_serv_critic
            // 
            this.comboBox_serv_critic.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_serv_critic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_serv_critic.FormattingEnabled = true;
            this.comboBox_serv_critic.Items.AddRange(new object[] {
            "Si",
            "No"});
            this.comboBox_serv_critic.Location = new System.Drawing.Point(300, 46);
            this.comboBox_serv_critic.Name = "comboBox_serv_critic";
            this.comboBox_serv_critic.Size = new System.Drawing.Size(121, 21);
            this.comboBox_serv_critic.TabIndex = 6;
            // 
            // label_state
            // 
            this.label_state.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_state.AutoSize = true;
            this.label_state.Location = new System.Drawing.Point(252, 22);
            this.label_state.Name = "label_state";
            this.label_state.Size = new System.Drawing.Size(40, 13);
            this.label_state.TabIndex = 5;
            this.label_state.Text = "Estado";
            // 
            // comboBox_serv_state
            // 
            this.comboBox_serv_state.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_serv_state.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_serv_state.FormattingEnabled = true;
            this.comboBox_serv_state.Items.AddRange(new object[] {
            "Ejecutando",
            "Pausado",
            "Detenido",
            "No instalado",
            "No interesa"});
            this.comboBox_serv_state.Location = new System.Drawing.Point(300, 19);
            this.comboBox_serv_state.Name = "comboBox_serv_state";
            this.comboBox_serv_state.Size = new System.Drawing.Size(121, 21);
            this.comboBox_serv_state.TabIndex = 4;
            // 
            // label_startMode
            // 
            this.label_startMode.AutoSize = true;
            this.label_startMode.Location = new System.Drawing.Point(26, 49);
            this.label_startMode.Name = "label_startMode";
            this.label_startMode.Size = new System.Drawing.Size(32, 13);
            this.label_startMode.TabIndex = 3;
            this.label_startMode.Text = "Inicio";
            // 
            // comboBox_serv_startMode
            // 
            this.comboBox_serv_startMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_serv_startMode.FormattingEnabled = true;
            this.comboBox_serv_startMode.Items.AddRange(new object[] {
            "Automatico",
            "Manual",
            "Deshabilitado",
            "No interesa"});
            this.comboBox_serv_startMode.Location = new System.Drawing.Point(74, 46);
            this.comboBox_serv_startMode.Name = "comboBox_serv_startMode";
            this.comboBox_serv_startMode.Size = new System.Drawing.Size(121, 21);
            this.comboBox_serv_startMode.TabIndex = 2;
            // 
            // label_status
            // 
            this.label_status.AutoSize = true;
            this.label_status.Location = new System.Drawing.Point(26, 22);
            this.label_status.Name = "label_status";
            this.label_status.Size = new System.Drawing.Size(42, 13);
            this.label_status.TabIndex = 1;
            this.label_status.Text = "Estatus";
            // 
            // comboBox_serv_status
            // 
            this.comboBox_serv_status.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_serv_status.FormattingEnabled = true;
            this.comboBox_serv_status.Items.AddRange(new object[] {
            "OK",
            "Error",
            "No Interesa"});
            this.comboBox_serv_status.Location = new System.Drawing.Point(74, 19);
            this.comboBox_serv_status.Name = "comboBox_serv_status";
            this.comboBox_serv_status.Size = new System.Drawing.Size(121, 21);
            this.comboBox_serv_status.TabIndex = 0;
            // 
            // groupBox_processObjective
            // 
            this.groupBox_processObjective.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox_processObjective.Controls.Add(this.label3);
            this.groupBox_processObjective.Controls.Add(this.textBox_proc_cpuUsageValue);
            this.groupBox_processObjective.Controls.Add(this.label2);
            this.groupBox_processObjective.Controls.Add(this.comboBox_proc_cpuUsageRelative);
            this.groupBox_processObjective.Controls.Add(this.label1);
            this.groupBox_processObjective.Controls.Add(this.checkBox_proc_cpuUsage);
            this.groupBox_processObjective.Controls.Add(this.label_mustrun);
            this.groupBox_processObjective.Controls.Add(this.comboBox_proc_mustRun);
            this.groupBox_processObjective.Location = new System.Drawing.Point(15, 555);
            this.groupBox_processObjective.Name = "groupBox_processObjective";
            this.groupBox_processObjective.Size = new System.Drawing.Size(446, 79);
            this.groupBox_processObjective.TabIndex = 5;
            this.groupBox_processObjective.TabStop = false;
            this.groupBox_processObjective.Text = "Propiedades Deseadas";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(336, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(15, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "%";
            // 
            // textBox_proc_cpuUsageValue
            // 
            this.textBox_proc_cpuUsageValue.Location = new System.Drawing.Point(244, 46);
            this.textBox_proc_cpuUsageValue.Name = "textBox_proc_cpuUsageValue";
            this.textBox_proc_cpuUsageValue.Size = new System.Drawing.Size(86, 20);
            this.textBox_proc_cpuUsageValue.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(213, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "que";
            // 
            // comboBox_proc_cpuUsageRelative
            // 
            this.comboBox_proc_cpuUsageRelative.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_proc_cpuUsageRelative.FormattingEnabled = true;
            this.comboBox_proc_cpuUsageRelative.Items.AddRange(new object[] {
            "mayor",
            "menor"});
            this.comboBox_proc_cpuUsageRelative.Location = new System.Drawing.Point(122, 46);
            this.comboBox_proc_cpuUsageRelative.Name = "comboBox_proc_cpuUsageRelative";
            this.comboBox_proc_cpuUsageRelative.Size = new System.Drawing.Size(85, 21);
            this.comboBox_proc_cpuUsageRelative.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Uso de CPU";
            // 
            // checkBox_proc_cpuUsage
            // 
            this.checkBox_proc_cpuUsage.AutoSize = true;
            this.checkBox_proc_cpuUsage.Location = new System.Drawing.Point(29, 49);
            this.checkBox_proc_cpuUsage.Name = "checkBox_proc_cpuUsage";
            this.checkBox_proc_cpuUsage.Size = new System.Drawing.Size(15, 14);
            this.checkBox_proc_cpuUsage.TabIndex = 2;
            this.checkBox_proc_cpuUsage.UseVisualStyleBackColor = true;
            // 
            // label_mustrun
            // 
            this.label_mustrun.AutoSize = true;
            this.label_mustrun.Location = new System.Drawing.Point(26, 22);
            this.label_mustrun.Name = "label_mustrun";
            this.label_mustrun.Size = new System.Drawing.Size(54, 13);
            this.label_mustrun.TabIndex = 1;
            this.label_mustrun.Text = "Ejecución";
            // 
            // comboBox_proc_mustRun
            // 
            this.comboBox_proc_mustRun.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_proc_mustRun.FormattingEnabled = true;
            this.comboBox_proc_mustRun.Items.AddRange(new object[] {
            "Obligatoria",
            "No debe ejecutar",
            "No interesa"});
            this.comboBox_proc_mustRun.Location = new System.Drawing.Point(86, 19);
            this.comboBox_proc_mustRun.Name = "comboBox_proc_mustRun";
            this.comboBox_proc_mustRun.Size = new System.Drawing.Size(137, 21);
            this.comboBox_proc_mustRun.TabIndex = 0;
            // 
            // button_cancelNewMonitor
            // 
            this.button_cancelNewMonitor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_cancelNewMonitor.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_cancelNewMonitor.Location = new System.Drawing.Point(361, 658);
            this.button_cancelNewMonitor.Name = "button_cancelNewMonitor";
            this.button_cancelNewMonitor.Size = new System.Drawing.Size(100, 33);
            this.button_cancelNewMonitor.TabIndex = 8;
            this.button_cancelNewMonitor.Text = "Cancelar";
            this.button_cancelNewMonitor.UseVisualStyleBackColor = true;
            this.button_cancelNewMonitor.Click += new System.EventHandler(this.button_cancelNewMonitor_Click);
            // 
            // button_addNewMonitor
            // 
            this.button_addNewMonitor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_addNewMonitor.Location = new System.Drawing.Point(245, 658);
            this.button_addNewMonitor.Name = "button_addNewMonitor";
            this.button_addNewMonitor.Size = new System.Drawing.Size(100, 33);
            this.button_addNewMonitor.TabIndex = 7;
            this.button_addNewMonitor.Text = "Agregar";
            this.button_addNewMonitor.UseVisualStyleBackColor = true;
            this.button_addNewMonitor.Click += new System.EventHandler(this.button_addNewMonitor_Click);
            // 
            // groupBox_monitorName
            // 
            this.groupBox_monitorName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox_monitorName.Controls.Add(this.textBox_monitorName);
            this.groupBox_monitorName.Location = new System.Drawing.Point(15, 646);
            this.groupBox_monitorName.Name = "groupBox_monitorName";
            this.groupBox_monitorName.Size = new System.Drawing.Size(219, 47);
            this.groupBox_monitorName.TabIndex = 6;
            this.groupBox_monitorName.TabStop = false;
            this.groupBox_monitorName.Text = "Nombre de Monitor";
            // 
            // textBox_monitorName
            // 
            this.textBox_monitorName.Location = new System.Drawing.Point(6, 19);
            this.textBox_monitorName.Name = "textBox_monitorName";
            this.textBox_monitorName.Size = new System.Drawing.Size(207, 20);
            this.textBox_monitorName.TabIndex = 0;
            // 
            // AddMonitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(470, 705);
            this.Controls.Add(this.groupBox_monitorName);
            this.Controls.Add(this.button_addNewMonitor);
            this.Controls.Add(this.button_cancelNewMonitor);
            this.Controls.Add(this.groupBox_processObjective);
            this.Controls.Add(this.groupBox_serviceObjective);
            this.Controls.Add(this.groupBox_listOptions);
            this.Controls.Add(this.label_domain);
            this.Controls.Add(this.label_machineName);
            this.Controls.Add(this.textBox_domain);
            this.Controls.Add(this.textBox_machineName);
            this.Controls.Add(this.label_password);
            this.Controls.Add(this.label_username);
            this.Controls.Add(this.textBox_password);
            this.Controls.Add(this.textBox_username);
            this.Controls.Add(this.listBox_results);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(486, 400);
            this.Name = "AddMonitor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Agregar Monitoreo";
            this.groupBox_listOptions.ResumeLayout(false);
            this.groupBox_serviceObjective.ResumeLayout(false);
            this.groupBox_serviceObjective.PerformLayout();
            this.groupBox_processObjective.ResumeLayout(false);
            this.groupBox_processObjective.PerformLayout();
            this.groupBox_monitorName.ResumeLayout(false);
            this.groupBox_monitorName.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_listServices;
        private System.Windows.Forms.ListBox listBox_results;
        private System.Windows.Forms.Button button_listProccess;
        private System.Windows.Forms.TextBox textBox_username;
        private System.Windows.Forms.TextBox textBox_password;
        private System.Windows.Forms.Label label_username;
        private System.Windows.Forms.Label label_password;
        private System.Windows.Forms.Label label_domain;
        private System.Windows.Forms.Label label_machineName;
        private System.Windows.Forms.TextBox textBox_domain;
        private System.Windows.Forms.TextBox textBox_machineName;
        private System.Windows.Forms.GroupBox groupBox_listOptions;
        private System.Windows.Forms.GroupBox groupBox_serviceObjective;
        private System.Windows.Forms.Label label_critic;
        private System.Windows.Forms.ComboBox comboBox_serv_critic;
        private System.Windows.Forms.Label label_state;
        private System.Windows.Forms.ComboBox comboBox_serv_state;
        private System.Windows.Forms.Label label_startMode;
        private System.Windows.Forms.ComboBox comboBox_serv_startMode;
        private System.Windows.Forms.Label label_status;
        private System.Windows.Forms.ComboBox comboBox_serv_status;
        private System.Windows.Forms.GroupBox groupBox_processObjective;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_proc_cpuUsageValue;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox_proc_cpuUsageRelative;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBox_proc_cpuUsage;
        private System.Windows.Forms.Label label_mustrun;
        private System.Windows.Forms.ComboBox comboBox_proc_mustRun;
        private System.Windows.Forms.Button button_cancelNewMonitor;
        private System.Windows.Forms.Button button_addNewMonitor;
        private System.Windows.Forms.GroupBox groupBox_monitorName;
        private System.Windows.Forms.TextBox textBox_monitorName;
    }
}

