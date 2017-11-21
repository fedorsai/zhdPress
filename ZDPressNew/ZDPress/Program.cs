using System;
using System.Windows.Forms;
using log4net;
using log4net.Config;

namespace ZDPress.UI
{
    static class Program
    {
        public static readonly ILog Log = LogManager.GetLogger(typeof(Program));


        public static OpcLayer OpcLayer { get; set; }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();

            Application.SetCompatibleTextRenderingDefault(false);

            XmlConfigurator.Configure();

            OpcLayer = new OpcLayer();

            OpcLayer.StartWork();

            Application.Run(new ShellForm());
        }
    }
}
