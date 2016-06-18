using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameEditor.Wcf.Harness.IoC;
using GameEditor.Wcf.Harness.Views;

namespace GameEditor.Wcf.Harness
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
            //Application.Run(IoCContainer.Resolve<MainPageViewForm>());
            Application.Run(new MainPageViewForm());
        }
    }
}
