using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HQTCSDL
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
<<<<<<< HEAD
            //Application.Run(new FOrder());
            Application.Run(new Forms.Login.FLogin());

=======
            Application.Run(new StatisticChart());
>>>>>>> parent of 4308481 (Merge branch 'master' into Thoai)
        }
    }
}
