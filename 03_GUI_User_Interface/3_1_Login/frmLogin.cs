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
using PLM_Lynx._03_GUI_User_Interface._3_5_Purchase;
using System.IO;

namespace PLM_Lynx._03_GUI_User_Interface._3_1_Login
{
    public partial class frmLogin : Form
    {
        // Kế thừa lớp DangNhapBLL.cs
        private DangNhapBLL userBLL = new DangNhapBLL();
        

        private string LicencePath = @"C:\ProgramData\window.lic";

        public bool licstatus { get; set; }
        public string BeginDate { get; set; }

        public frmLogin()
        {
            InitializeComponent();
        }

        // ===========================================================
        // ===========================================================
        /// <summary>
        //  Liên quan đến kiểm tra license
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        // Đầu tiền kiểm tra xem có tồn tại file license không ?
        // Nếu chưa tồn tại thì tạo mới và ghi ngày hiện tại vào file
        // Nếu đã tồn tại thì kiểm tra xem ngày hiện tại có
        // lớn hơn ngày ghi trong file không ? Nếu lớn hơn 365 ngày thì thông báo hết hạn
        public void CheckLicense()
        {
            if (!File.Exists(LicencePath)) // Lần đầu mở ứng dụng
            {
                File.WriteAllText(LicencePath, DateTime.Now.ToString("MM-dd-yyyy"));
                licstatus = true;
                return;
            }
            else
            {
                string savedDate = File.ReadLines(LicencePath).FirstOrDefault();
                
                string kichhoatdate = File.ReadLines(LicencePath).Skip(1).FirstOrDefault();

                if (kichhoatdate == savedDate)
                {
                    licstatus = true;
                    return;
                }

                if (DateTime.TryParse(savedDate, out DateTime activationDate))
                {
                    if ((DateTime.Now - activationDate).TotalDays > 365)
                    {
                        DateTime expireddate = activationDate.AddDays(365);
                        string tb1 = "Hạn sử dụng miễn phí đã hết sau ngày " + expireddate.ToString("MM-dd-yyyy");
                        //MessageBox.Show(tb, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        MessageBox.Show(tb1);
                        licstatus = false;
                        //Application.Exit();
                    }
                    else
                    {
                        licstatus = true;
                    }
                }
            }
        }




        // ===========================================================
        // ===========================================================
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có trùng với điều kiện không
            string username = txtDangNhap.Text.Trim(); ;
            string password = txtMatKhau.Text.Trim(); ;

            bool IsStaff = userBLL.CheckDangnhapBLL(username, password);
            if (IsStaff)
            {
                MessageBox.Show("Đăng nhập thành công ");

                frmMain frm = new frmMain();
                frm.tennguoidung = username;
                frm.idnguoidung = userBLL.GetUserID_BLL(username);
                frm.UserLevel = userBLL.GetLevel_BLL(username);

                this.Hide(); // form Login này bị ẩn đi
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
            DialogResult result = MessageBox.Show("Không mở ứng dụng nữa à ? ", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void txtDangNhap_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtMatKhau_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnDangNhap.PerformClick();
                e.SuppressKeyPress = true; // Ngăn không cho tiếng Bíp kêu khi nhấn enter
            }
        }
    }
}