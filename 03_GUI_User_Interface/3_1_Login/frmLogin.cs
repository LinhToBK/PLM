using PLM_Lynx._01_DAL_Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PLM_Lynx._02_BLL_Bussiness_Logic_Layer;

namespace PLM_Lynx._03_GUI_User_Interface._3_1_Login
{
    public partial class frmLogin : Form
    {
        // Kế thừa lớp DangNhapBLL.cs
        private DangNhapBLL userBLL = new DangNhapBLL();
        


        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có trùng với điều kiện không
            string username = txtDangNhap.Text;
            string password = txtMatKhau.Text;

            bool IsStaff = userBLL.CheckDangnhapBLL(username, password);
            if (IsStaff)
            {
                MessageBox.Show("Đăng nhập thành công ");
                frmMain frm = new frmMain();
                frm.tennguoidung = username;
                this.Hide();
                frm.ShowDialog();
                this.Close();
                
                //this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mất khẩu không đúng");
                
            } 
                 
            
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result =  MessageBox.Show("Không mở ứng dụng nữa à ? ","Thông báo", MessageBoxButtons.OKCancel,MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void txtDangNhap_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }    
        }

        private void txtMatKhau_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                btnDangNhap.PerformClick();
                e.SuppressKeyPress = true; // Ngăn không cho tiếng Bíp kêu khi nhấn enter
            }    
        }
    }
}
