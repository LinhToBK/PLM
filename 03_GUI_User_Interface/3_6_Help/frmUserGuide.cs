using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PLM_Lynx._03_GUI_User_Interface._3_6_Help
{
    public partial class frmUserGuide : Form
    {
        public frmUserGuide()
        {
            InitializeComponent();
        }

        private void buttonApply_Click(object sender, EventArgs e)
        {
            // Lấy giá trị hiện tại từ combobox
            int selectedIndex = cboLanguage.SelectedIndex;

            switch (selectedIndex)
            {

                case 0:
                    // Tiếng Anh
                    Properties.Settings.Default.Language = "";
                    MessageBox.Show("Language set to English successfully.");
                    Properties.Settings.Default.Save();
                    // Đóng ứng dụng và mở lại
                    
                    break;

                case 1: 
                    // Tiếng Việt
                    Properties.Settings.Default.Language = "vi";
                    MessageBox.Show("Ngôn ngữ đã được đặt thành tiếng Việt thành công.");
                    Properties.Settings.Default.Save();
                    
                    break;
                case 2:
                    // Tiếng Hàn
                    Properties.Settings.Default.Language = "kr";
                    MessageBox.Show("언어가 한국어로 성공적으로 설정되었습니다.");
                    Properties.Settings.Default.Save();
                    break;
            }
            Application.Restart();


        }

        private void frmUserGuide_Load(object sender, EventArgs e)
        {
            cboLanguage.SelectedIndex = 0;
        }

        private void btnOpenPDF_Click(object sender, EventArgs e)
        {
            // Mở file pdf user guide
            string filepath = Path.Combine(Environment.CurrentDirectory, @"04_CommonDoc\User Guide.pdf");

            // Kiểm tra có tồn tại không ?
            if (File.Exists(filepath))
            {
                System.Diagnostics.Process.Start(filepath);
            }
            else
            {
                MessageBox.Show("File not found: " + filepath);
            }
        }
    }
}
