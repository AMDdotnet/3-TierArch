using Common;
using DL;
using System;
using System.Windows.Forms;

namespace UI
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ILogger logger = new ConoleLogger();
            Application.Run(new ValidationTeacher());
        }
    }
}
