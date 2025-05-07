using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Globalization;
using System.Resources;
using System.Threading;

namespace PLM_Lynx._03_GUI_User_Interface._3_1_Login
{
    public partial class frmEnterLicencesCode : Form
    {
        private string LicencePath = @"C:\ProgramData\window.lic";
        public string begindate { get; set; } // Ngày bắt đầu sử dụng phần mềm

        private string _servername { get; set; } // Tên máy chủ

        public frmEnterLicencesCode()
        {
            InitializeComponent();
            LoadLanguage(); // Load ngôn ngữ từ ResourceManager
            // Lấy tên máy chủ
            string Connect = Properties.Settings.Default.Datacon;
            string[] ServerNameList = Connect.Split(';');
            string ServerName = ServerNameList[1];
            string[] Server = ServerName.Split('=');
            _servername = Server[1].ToString().Trim();
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
            rm = new ResourceManager("PLM_Lynx.Strings", typeof(frmEnterLicencesCode).Assembly);

            // Lưu lại lựa chọn ngôn ngữ
            Properties.Settings.Default.Language = lang;
            Properties.Settings.Default.Save();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            // Lấy code từ textbox   và ghi và file lic
            // Dạng code : MMDDyyyy

            if(CHECKServerName() == false)
            {
                // MessageBox.Show(rm.GetString("1.1.1")); // Please enter the correct code
                MessageBox.Show("Nhập sai tên server");
                txtCode.Focus();
                return;
            }

            string Code = txtCode.Text.Trim().Split('_')[1];  // Lấy phần sau dấu gạch dưới

            // Giá trị đúng = ngày hết hạn trừ đi 1 năm + 1234
            if (Code == null)
            {
                MessageBox.Show(rm.GetString("1.1.1")   );   // Please enter the active code
                return;
            }

            try
            {
                int decimalValue = Convert.ToInt32(Code, 16) - 1234;     // Chỗ này quan trọng 

                //MessageBox.Show(decimalValue.ToString("MM-dd-yyyy"));
                string valuedate = decimalValue.ToString();

                if (valuedate.Length < 7 || valuedate.Length > 8) { MessageBox.Show(rm.GetString("1.1.2")); return; }    //   Error !!! Please enter active code again

                if (valuedate.Length == 7)
                {
                    // Định dạng : M-dd-yyyy
                    valuedate = "0" + valuedate;
                }

                // Tách ngày, tháng, năm
                string month = valuedate.Substring(0, 2);
                string day = valuedate.Substring(2, 2);
                string year = valuedate.Substring(4, 4);

                valuedate = month + "-" + day + "-" + year;
                //MessageBox.Show(valuedate);

                // Kiểm tra với giá trị cũ
                string savedDate = File.ReadLines(LicencePath).FirstOrDefault();
                if (savedDate == valuedate)
                {
                    MessageBox.Show(rm.GetString("1.1.3")); // Active  successfully ! Please reset application
                    // ghi valuedate vào dòng thứ 2
                    // Đọc tất cả các dòng trong file
                    string[] lines = File.Exists(LicencePath) ? File.ReadAllLines(LicencePath) : new string[0];

                    // Chèn nội dung vào dòng thứ 2
                    if (lines.Length >= 1)
                    {
                        lines = lines.Take(1).Concat(new string[] { valuedate }).Concat(lines.Skip(1)).ToArray();
                    }
                    else
                    {
                        lines = new string[] { "", valuedate };
                    }

                    // Ghi lại nội dung vào file
                    File.WriteAllLines(LicencePath, lines);

                    Application.Exit();
                }
                else
                {
                    MessageBox.Show(rm.GetString("1.1.4")); 
                    return;
                }
            }
            catch
            {
                MessageBox.Show(rm.GetString("1.1.5"));
                return;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmEnterLicencesCode_Load(object sender, EventArgs e)
        {
            txtbegindate.Text = begindate;
            txtServer.Text = _servername;
        }

        private bool CHECKServerName()
        {
            SKGL.Validate vld = new SKGL.Validate();
            vld.secretPhase = _servername;
            // string keyservernamesplit = txtCode.Text.Trim().Split('_')[0];
            vld.Key = txtCode.Text.Trim().Split('_')[0]; // Lấy phần đầu của chuỗi code là check server
            if(vld.IsValid)
            {
                return true;
            }
            else
            {
                
                return false;
            }


        }
    }
}