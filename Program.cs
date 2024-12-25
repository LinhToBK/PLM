using PLM_Lynx._03_GUI_User_Interface._3_1_Login;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PLM_Lynx
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
            //Application.Run(new frmLogin());

            frmLogin frm = new frmLogin();
            frm.ShowDialog();
            //if(frm.ShowDialog() == DialogResult.OK)
            //{
            //    Application.Run(new frmMain());
                
            //}    
            //else
            //{
            //    Application.Exit();
            //}

            
   
        }
    }
}
