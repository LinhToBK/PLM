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
            frm.CheckLicense();
            if (frm.licstatus == true)
            {
                //MessageBox.Show("Vẫn còn hạn sử dụng");
                frm.ShowDialog();
            }
            else
            {
                 DialogResult kq =   MessageBox.Show("Hết hạn sử dụng \n Vui lòng nhập code","",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if (kq == DialogResult.Yes)
                {
                    frmEnterLicencesCode frmlic = new frmEnterLicencesCode();
                    frmlic.begindate = frm.BeginDate;
                    frmlic.ShowDialog();
                }
                else
                {
                    Application.Exit();
                }





                }


            // frm.ShowDialog();
            
   
        }
    }
}
