using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace TaskMonitor
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            new LogoForm(500, 1500, 30, global::TaskMonitor.Properties.Resources.LogoMed_Alpha, true);
            Application.Run(new MonitorMgr());
        }
    }
}
