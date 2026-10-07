using BL;
using BL.Contracts;
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

            ILogger logger = LoggerFactory.Create(LogType.console);
            ILessonData lessonData = new LessonData();
            ILessonService lessonService = new LessonService(lessonData, logger);

            Application.Run(new FrmLessons(lessonService));
        }
    }
}
