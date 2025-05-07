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
using PLM_Lynx._03_GUI_User_Interface._3_6_Help;
using System.Globalization;
using System.Resources;
using System.Threading;

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
            LoadLanguage(); // Load ngôn ngữ từ ResourceManager
        }

        private ResourceManager rm { get; set; } // Để lấy ngôn ngữ từ ResourceManager

        private void LoadLanguage()
        {
            // Lấy ngôn ngữ đã lưu ( mặc định là en)
            string lang = Properties.Settings.Default.Language;
            SetLanguage(lang);
        }

        private void SetLanguage(string lang)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(lang);
            rm = new ResourceManager("PLM_Lynx.Strings", typeof(frmLogin).Assembly);
            this.Text = rm.GetString("1.2.6");
            groupBoxInfor.Text = rm.GetString("1.2.7");
            labelUser.Text = rm.GetString("1.2.8");
            labelPass.Text = rm.GetString("1.2.9");
            btnDangNhap.Text = rm.GetString("1.2.10");
            btnThoat.Text = rm.GetString("1.2.11");

            // Lưu lại lựa chọn ngôn ngữ
            Properties.Settings.Default.Language = lang;
            Properties.Settings.Default.Save();
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
                        BeginDate = expireddate.ToString("MM-dd-yyyy");
                        string tb1 = rm.GetString("1.2.1") + expireddate.ToString("MM-dd-yyyy");
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
                MessageBox.Show(rm.GetString("1.2.2"));

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
                MessageBox.Show(rm.GetString("1.2.12"));
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(rm.GetString("1.2.3"), rm.GetString("1.2.4"), MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
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

        private void frmLogin_Load(object sender, EventArgs e)
        {
            GetImageLogo();
        }

        private void GetImageLogo()
        {
            string ImageCompanyPath = Environment.CurrentDirectory;
            ImageCompanyPath = ImageCompanyPath + @"\04_CommonDoc\companylogo.jpg";
            if (File.Exists(ImageCompanyPath))
            {
                pictureLogo.Image = Image.FromFile(ImageCompanyPath);
                pictureLogo.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else
            {
                MessageBox.Show(rm.GetString("1.2.5"));
            }
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            // Mở nơi lưu file cài đặt
            string path = Environment.CurrentDirectory;
            string tb = "Do you want to open the setting folder ? \r\n If opening the config file, application will be closed. ";
            DialogResult kq = MessageBox.Show(tb, "Open folder ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(kq == DialogResult.Yes)
            {
                // System.Diagnostics.Process.Start("explorer.exe", path);
                // Lọc chỉ hiển thị file .config
                string[] files = Directory.GetFiles(path, "*.config");
                foreach (string file in files)
                {
                    string fileName = Path.GetFileName(file);
                    if (fileName == "PLM_Lynx.exe.config")
                    {
                        System.Diagnostics.Process.Start("explorer.exe", file);
                        break;
                    }
                }
                // Đóng ứng dụng
                Application.Exit();

            }
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
         
        }
    }
}