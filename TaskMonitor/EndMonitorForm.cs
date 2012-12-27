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
    public partial class EndMonitorForm : Form
    {
        public EndMonitorForm(MonitorMgr caller)
        {
            InitializeComponent();

            this.caller = caller;
            this.comboBox_type.SelectedIndex = 0;
        }

        #region Events
        private void button_remove_Click(object sender, EventArgs e)
        {
            if (this.comboBox_monitorName.SelectedIndex == -1)
            {
                MessageBox.Show("La opción seleccionada no es válida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            caller.EndMonitor(monitors[this.comboBox_monitorName.SelectedIndex].name, this.comboBox_type.SelectedIndex == 0 ? Mode.service : Mode.process);

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void comboBox_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.monitors = this.getMonitors(this.comboBox_type.SelectedIndex == 0 ? Mode.service : Mode.process);
            this.comboBox_monitorName.DataSource = this.monitors;
            this.comboBox_monitorName.DisplayMember = "name";
        }
        #endregion

        //Crea el vector de datasource para el combobox de monitores
        private List<Monitor> getMonitors(Mode type)
        {
            List<Monitor> monitors = new List<Monitor>();

            if (type == Mode.service)
            {
                foreach (ServiceMonitor sMonitor in caller.InfoServiceMonitors())
                {
                    monitors.Add(sMonitor);
                }
            }
            else //(type == Mode.process)
            {
                foreach (ProcessMonitor pMonitor in caller.InfoProcessMonitors())
                {
                    monitors.Add(pMonitor);
                }
            }

            return monitors;
        }

        //Atributos privados
        List<Monitor> monitors;
        private MonitorMgr caller;
    }
}
