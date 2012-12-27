namespace TaskMonitor
{
    partial class ConfigForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigForm));
            this.tabControl_options = new System.Windows.Forms.TabControl();
            this.tabPage_gral = new System.Windows.Forms.TabPage();
            this.checkBox_disconnectError = new System.Windows.Forms.CheckBox();
            this.checkBox_confirmDelete = new System.Windows.Forms.CheckBox();
            this.groupBox_intervals = new System.Windows.Forms.GroupBox();
            this.textBox_intervals_monitoring = new System.Windows.Forms.TextBox();
            this.textBox_intervals_tableUpdate = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage_email = new System.Windows.Forms.TabPage();
            this.listBox_addressee = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.checkBox_enableEmails = new System.Windows.Forms.CheckBox();
            this.textBox_sender = new System.Windows.Forms.TextBox();
            this.textBox_hostSMTP = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button_cancel = new System.Windows.Forms.Button();
            this.button_accept = new System.Windows.Forms.Button();
            this.tabControl_options.SuspendLayout();
            this.tabPage_gral.SuspendLayout();
            this.groupBox_intervals.SuspendLayout();
            this.tabPage_email.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl_options
            // 
            this.tabControl_options.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl_options.Controls.Add(this.tabPage_gral);
            this.tabControl_options.Controls.Add(this.tabPage_email);
            this.tabControl_options.Location = new System.Drawing.Point(12, 12);
            this.tabControl_options.Name = "tabControl_options";
            this.tabControl_options.SelectedIndex = 0;
            this.tabControl_options.Size = new System.Drawing.Size(334, 280);
            this.tabControl_options.TabIndex = 0;
            // 
            // tabPage_gral
            // 
            this.tabPage_gral.Controls.Add(this.checkBox_disconnectError);
            this.tabPage_gral.Controls.Add(this.checkBox_confirmDelete);
            this.tabPage_gral.Controls.Add(this.groupBox_intervals);
            this.tabPage_gral.Location = new System.Drawing.Point(4, 22);
            this.tabPage_gral.Name = "tabPage_gral";
            this.tabPage_gral.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_gral.Size = new System.Drawing.Size(326, 254);
            this.tabPage_gral.TabIndex = 0;
            this.tabPage_gral.Text = "Generales";
            this.tabPage_gral.UseVisualStyleBackColor = true;
            // 
            // checkBox_disconnectError
            // 
            this.checkBox_disconnectError.AutoSize = true;
            this.checkBox_disconnectError.Location = new System.Drawing.Point(15, 152);
            this.checkBox_disconnectError.Name = "checkBox_disconnectError";
            this.checkBox_disconnectError.Size = new System.Drawing.Size(204, 17);
            this.checkBox_disconnectError.TabIndex = 4;
            this.checkBox_disconnectError.Text = "Interpretar la desconexión como error.";
            this.checkBox_disconnectError.UseVisualStyleBackColor = true;
            this.checkBox_disconnectError.CheckedChanged += new System.EventHandler(this.checkBox_disconnectError_CheckedChanged);
            // 
            // checkBox_confirmDelete
            // 
            this.checkBox_confirmDelete.AutoSize = true;
            this.checkBox_confirmDelete.Location = new System.Drawing.Point(15, 120);
            this.checkBox_confirmDelete.Name = "checkBox_confirmDelete";
            this.checkBox_confirmDelete.Size = new System.Drawing.Size(217, 17);
            this.checkBox_confirmDelete.TabIndex = 3;
            this.checkBox_confirmDelete.Text = "Pedir confirmación al eliminar un monitor.";
            this.checkBox_confirmDelete.UseVisualStyleBackColor = true;
            this.checkBox_confirmDelete.CheckedChanged += new System.EventHandler(this.checkBox_confirmDelete_CheckedChanged);
            // 
            // groupBox_intervals
            // 
            this.groupBox_intervals.Controls.Add(this.textBox_intervals_monitoring);
            this.groupBox_intervals.Controls.Add(this.textBox_intervals_tableUpdate);
            this.groupBox_intervals.Controls.Add(this.label1);
            this.groupBox_intervals.Controls.Add(this.label2);
            this.groupBox_intervals.Location = new System.Drawing.Point(6, 12);
            this.groupBox_intervals.Name = "groupBox_intervals";
            this.groupBox_intervals.Size = new System.Drawing.Size(314, 93);
            this.groupBox_intervals.TabIndex = 2;
            this.groupBox_intervals.TabStop = false;
            this.groupBox_intervals.Text = "Intervalos";
            // 
            // textBox_intervals_monitoring
            // 
            this.textBox_intervals_monitoring.Location = new System.Drawing.Point(128, 22);
            this.textBox_intervals_monitoring.Name = "textBox_intervals_monitoring";
            this.textBox_intervals_monitoring.Size = new System.Drawing.Size(180, 20);
            this.textBox_intervals_monitoring.TabIndex = 3;
            this.textBox_intervals_monitoring.Leave += new System.EventHandler(this.textBox_intervals_monitoring_Leave);
            // 
            // textBox_intervals_tableUpdate
            // 
            this.textBox_intervals_tableUpdate.Location = new System.Drawing.Point(128, 57);
            this.textBox_intervals_tableUpdate.Name = "textBox_intervals_tableUpdate";
            this.textBox_intervals_tableUpdate.Size = new System.Drawing.Size(180, 20);
            this.textBox_intervals_tableUpdate.TabIndex = 2;
            this.textBox_intervals_tableUpdate.Leave += new System.EventHandler(this.textBox_intervals_tableUpdate_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Monitoreo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Actualización de tablas";
            // 
            // tabPage_email
            // 
            this.tabPage_email.Controls.Add(this.listBox_addressee);
            this.tabPage_email.Controls.Add(this.label4);
            this.tabPage_email.Controls.Add(this.checkBox_enableEmails);
            this.tabPage_email.Controls.Add(this.textBox_sender);
            this.tabPage_email.Controls.Add(this.textBox_hostSMTP);
            this.tabPage_email.Controls.Add(this.label5);
            this.tabPage_email.Controls.Add(this.label3);
            this.tabPage_email.Location = new System.Drawing.Point(4, 22);
            this.tabPage_email.Name = "tabPage_email";
            this.tabPage_email.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_email.Size = new System.Drawing.Size(326, 254);
            this.tabPage_email.TabIndex = 1;
            this.tabPage_email.Text = "Email";
            this.tabPage_email.UseVisualStyleBackColor = true;
            // 
            // listBox_addressee
            // 
            this.listBox_addressee.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox_addressee.FormattingEnabled = true;
            this.listBox_addressee.HorizontalScrollbar = true;
            this.listBox_addressee.Location = new System.Drawing.Point(10, 122);
            this.listBox_addressee.Name = "listBox_addressee";
            this.listBox_addressee.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBox_addressee.Size = new System.Drawing.Size(310, 121);
            this.listBox_addressee.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Destinatarios";
            // 
            // checkBox_enableEmails
            // 
            this.checkBox_enableEmails.AutoSize = true;
            this.checkBox_enableEmails.Location = new System.Drawing.Point(10, 16);
            this.checkBox_enableEmails.Name = "checkBox_enableEmails";
            this.checkBox_enableEmails.Size = new System.Drawing.Size(145, 17);
            this.checkBox_enableEmails.TabIndex = 6;
            this.checkBox_enableEmails.Text = "Habilitar envío de emails.";
            this.checkBox_enableEmails.UseVisualStyleBackColor = true;
            this.checkBox_enableEmails.CheckedChanged += new System.EventHandler(this.checkBox_enableEmails_CheckedChanged);
            // 
            // textBox_sender
            // 
            this.textBox_sender.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_sender.Location = new System.Drawing.Point(92, 44);
            this.textBox_sender.Name = "textBox_sender";
            this.textBox_sender.Size = new System.Drawing.Size(228, 20);
            this.textBox_sender.TabIndex = 5;
            this.textBox_sender.Leave += new System.EventHandler(this.textBox_sender_Leave);
            // 
            // textBox_hostSMTP
            // 
            this.textBox_hostSMTP.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_hostSMTP.Location = new System.Drawing.Point(92, 73);
            this.textBox_hostSMTP.Name = "textBox_hostSMTP";
            this.textBox_hostSMTP.Size = new System.Drawing.Size(228, 20);
            this.textBox_hostSMTP.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 76);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Servidor SMTP";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Remitente";
            // 
            // button_cancel
            // 
            this.button_cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_cancel.Location = new System.Drawing.Point(271, 298);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(75, 26);
            this.button_cancel.TabIndex = 1;
            this.button_cancel.Text = "Cancelar";
            this.button_cancel.UseVisualStyleBackColor = true;
            this.button_cancel.Click += new System.EventHandler(this.button_cancel_Click);
            // 
            // button_accept
            // 
            this.button_accept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_accept.Location = new System.Drawing.Point(190, 298);
            this.button_accept.Name = "button_accept";
            this.button_accept.Size = new System.Drawing.Size(75, 26);
            this.button_accept.TabIndex = 2;
            this.button_accept.Text = "Aceptar";
            this.button_accept.UseVisualStyleBackColor = true;
            this.button_accept.Click += new System.EventHandler(this.button_accept_Click);
            // 
            // ConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(358, 336);
            this.Controls.Add(this.button_accept);
            this.Controls.Add(this.button_cancel);
            this.Controls.Add(this.tabControl_options);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(364, 364);
            this.Name = "ConfigForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Config";
            this.tabControl_options.ResumeLayout(false);
            this.tabPage_gral.ResumeLayout(false);
            this.tabPage_gral.PerformLayout();
            this.groupBox_intervals.ResumeLayout(false);
            this.groupBox_intervals.PerformLayout();
            this.tabPage_email.ResumeLayout(false);
            this.tabPage_email.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl_options;
        private System.Windows.Forms.TabPage tabPage_gral;
        private System.Windows.Forms.GroupBox groupBox_intervals;
        private System.Windows.Forms.TextBox textBox_intervals_monitoring;
        private System.Windows.Forms.TextBox textBox_intervals_tableUpdate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage tabPage_email;
        private System.Windows.Forms.Button button_cancel;
        private System.Windows.Forms.Button button_accept;
        private System.Windows.Forms.CheckBox checkBox_disconnectError;
        private System.Windows.Forms.CheckBox checkBox_confirmDelete;
        private System.Windows.Forms.TextBox textBox_sender;
        private System.Windows.Forms.TextBox textBox_hostSMTP;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox listBox_addressee;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkBox_enableEmails;

    }
}