using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Mail;

namespace TaskMonitor
{
    public partial class ConfigForm : Form
    {        
        public struct GralConfigData
        {
            public GralConfigData(int queryingInterval, int updateInterval, bool confirmDelete, bool disconnectError)
            {
                this.queryingInterval = queryingInterval;
                this.updateInterval = updateInterval;
                this.confirmDelete = confirmDelete;
                this.disconnectError = disconnectError;
            }

            public int queryingInterval;
            public int updateInterval;
            public bool confirmDelete;
            public bool disconnectError;
        }

        public struct EmailConfigData
        {
            public EmailConfigData(bool enable, string sender, List <string> addressee, string hostSMTP)
            {
                this.enableEmails = enable;
                this.addressee = addressee;
                this.sender = sender;
                this.hostSMTP = hostSMTP;
            }

            public bool enableEmails;
            public string sender;
            public string hostSMTP;
            public List<string> addressee;
        }

        //Builder
        public ConfigForm(GralConfigData actualGralConfigData, EmailConfigData actualEmailConfigData)
        {
            InitializeComponent();

            this.gralConfigData = actualGralConfigData;
            this.emailConfigData = actualEmailConfigData;
            if (this.emailConfigData.addressee == null)
                this.emailConfigData.addressee = new List<string>();

            this.textBox_intervals_monitoring.Text = this.gralConfigData.queryingInterval.ToString();
            this.textBox_intervals_tableUpdate.Text = this.gralConfigData.updateInterval.ToString();
            this.checkBox_confirmDelete.Checked = this.gralConfigData.confirmDelete;
            this.checkBox_disconnectError.Checked = this.gralConfigData.disconnectError;

            this.checkBox_enableEmails.Checked = this.emailConfigData.enableEmails;
            this.textBox_hostSMTP.Text = this.emailConfigData.hostSMTP;
            this.textBox_sender.Text = this.emailConfigData.sender;
            this.listBox_addressee.DataSource = this.emailConfigData.addressee;
        }

        #region Events
        private void textBox_intervals_tableUpdate_Leave(object sender, EventArgs e)
        {
            try
            {
                this.gralConfigData.updateInterval = int.Parse(((TextBox)sender).Text);
            }
            catch
            {
                MessageBox.Show("El dato introducido no es válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.textBox_intervals_tableUpdate.Text = this.gralConfigData.updateInterval.ToString();
            }
        }

        private void textBox_intervals_monitoring_Leave(object sender, EventArgs e)
        {
            try
            {
                this.gralConfigData.queryingInterval = int.Parse(((TextBox)sender).Text);
            }
            catch
            {
                MessageBox.Show("El dato introducido no es válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.textBox_intervals_monitoring.Text = this.gralConfigData.queryingInterval.ToString();
            }
        }

        private void checkBox_confirmDelete_CheckedChanged(object sender, EventArgs e)
        {
            this.gralConfigData.confirmDelete = ((CheckBox)sender).Checked;
        }

        private void checkBox_disconnectError_CheckedChanged(object sender, EventArgs e)
        {
            this.gralConfigData.disconnectError = ((CheckBox)sender).Checked;
        }

        private void checkBox_enableEmails_CheckedChanged(object sender, EventArgs e)
        {
            this.emailConfigData.enableEmails = ((CheckBox)sender).Checked;
        }

        private void textBox_sender_Leave(object sender, EventArgs e)
        {
            try
            {
                TextBox tSender = (TextBox)sender;
                if (tSender.Text.Length != 0)
                {
                    MailAddress mail = new MailAddress(tSender.Text);
                    this.emailConfigData.sender = mail.Address;
                }
            }
            catch
            {
                MessageBox.Show("El mail introducido no es válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.textBox_sender.Text = this.emailConfigData.sender;
            }

        }
        #endregion

        //Setter & Getters
        public ConfigForm.GralConfigData GetGralConfigData { get { return this.gralConfigData; } }
        public ConfigForm.EmailConfigData GetEmailConfigData { get { return this.emailConfigData; } }

        //Atributos privados
        private GralConfigData gralConfigData;
        private EmailConfigData emailConfigData;

        private void button_cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void button_accept_Click(object sender, EventArgs e)
        {
            //Chequeos de datos grales
            if (this.gralConfigData.queryingInterval == 0 || this.gralConfigData.updateInterval == 0)
            {
                MessageBox.Show("Los intervalos deben ser mayores a cero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //Chequeo de datos de emails
            if (this.emailConfigData.enableEmails && this.emailConfigData.addressee.Count == 0)
            {
                MessageBox.Show("Debe indicarse al menos un destinatario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (this.emailConfigData.enableEmails && this.emailConfigData.sender.Length == 0)
            {
                MessageBox.Show("Debe especificarse un remitente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (this.emailConfigData.enableEmails && this.emailConfigData.hostSMTP.Length == 0)
            {
                MessageBox.Show("Debe especificarse el servidor SMTP.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}
