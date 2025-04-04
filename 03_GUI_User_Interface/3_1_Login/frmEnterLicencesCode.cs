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

namespace PLM_Lynx._03_GUI_User_Interface._3_1_Login
{
    public partial class frmEnterLicencesCode : Form
    {
        private string LicencePath = @"C:\ProgramData\window.lic";

        public frmEnterLicencesCode()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            // Lấy code từ textbox   và ghi và file lic
            string Code = txtCode.Text.Trim();
            if (Code == null)
            {
                MessageBox.Show("Vui lòng nhập code");
                return;
            }

            try
            {
                int decimalValue = Convert.ToInt32(Code, 16) - 1234;

                //MessageBox.Show(decimalValue.ToString("MM-dd-yyyy"));
                string valuedate = decimalValue.ToString();

                if (valuedate.Length < 7 || valuedate.Length > 8) { MessageBox.Show("Nhập lỗi , \n Vui lòng nhập lại"); return; }

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
                    MessageBox.Show("Đã mở khóa thành công \n Vui lòng khởi động lại ứng dụng");
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
                    MessageBox.Show("Nhập sai code \n Vui lòng kiểm tra lại");
                    return;
                }
            }
            catch
            {
                MessageBox.Show("Nhập lỗi code. \n Vui lòng nhập lại ");
                return;
            } 
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}