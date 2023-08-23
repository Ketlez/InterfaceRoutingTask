using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Diplom
{
    public class CurrentForm
    {
        public static Form f;
    }
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            CurrentForm.f = new FormMain();

            while (CurrentForm.f != null)
            {
                Application.Run(CurrentForm.f);
            }
        }
    }
}
