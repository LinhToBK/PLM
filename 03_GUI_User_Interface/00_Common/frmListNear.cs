using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PLM_Lynx._01_DAL_Data_Access_Layer;
using PLM_Lynx._02_BLL_Bussiness_Logic_Layer;

using System.Globalization;
using System.Threading;
using System.Resources;

namespace PLM_Lynx._03_GUI_User_Interface
{
    public partial class frmListNear : Form
    {
        private bool IsLoading = true; // Flag để kiểm soát sự kiện
        private FindPartBLL PartBLL = new FindPartBLL();
        private ResourceManager rm { get; set; } // Để lấy ngôn ngữ từ ResourceManager

        public void LoadDatatodgvListNear(int norow)
        {
            dgvListNearPart.DataSource = PartBLL.GetListNearBLL(norow);

            dgvListNearPart.AllowUserToAddRows = false;
            dgvListNearPart.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void LoadLanguage()
        {
            // Lấy ngôn ngữ đã lưu ( mặc định là en)
            string lang = Properties.Settings.Default.Language;
            SetLanguage(lang);
        }
        private void SetLanguage(string lang)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(lang);
            rm = new ResourceManager("PLM_Lynx.Strings", typeof(frmListNear).Assembly);

            this.Text = rm.GetString("0.1");
            lblChooseQuantity.Text = rm.GetString("0.2");
            lblEscape.Text = rm.GetString("0.3");

            // Lưu lại lựa chọn ngôn ngữ
            Properties.Settings.Default.Language = lang;
            Properties.Settings.Default.Save();
        }

        

       

        public frmListNear()
        {
            InitializeComponent();
            this.KeyPreview = true; // Cho phép Form nhận sự kiện phím trước
            this.KeyDown += new KeyEventHandler(frmListNear_KeyDown);
            LoadLanguage();

            // Tạo danh sách
            List<ListNearPart> Chonsoluong = new List<ListNearPart>
            {
                new ListNearPart { NoListNearPart = 5, MeanListNearPart = rm.GetString("0.5") },
                new ListNearPart { NoListNearPart = 10, MeanListNearPart = rm.GetString("0.6") },
                new ListNearPart { NoListNearPart = 20, MeanListNearPart = rm.GetString("0.7") },
                new ListNearPart { NoListNearPart = 50, MeanListNearPart = rm.GetString("0.8") }
            };

            // Gán danh sách từ DataSource lên Combox
            cboChooseNoRow.DataSource = Chonsoluong;
            cboChooseNoRow.DisplayMember = "MeanListNearPart";
            cboChooseNoRow.ValueMember = "NoListNearPart";

            // Đặt giá trị mắc định là mục đầu tiên
            if (cboChooseNoRow.Items.Count > 0)
            {
                cboChooseNoRow.SelectedIndex = 0;
            }
            IsLoading = false;

            // LoadDatatodgvListNear(cboChooseNoRow.SelectedValue);
        }

        private void cboChooseNoRow_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (!IsLoading)
                {
                    LoadDatatodgvListNear(Convert.ToInt32(cboChooseNoRow.SelectedValue));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(rm.GetString("0.9") + ex.Message);
            }
        }

        private void frmListNear_Load(object sender, EventArgs e)
        {
            LoadDatatodgvListNear(5);
        }

        private void frmListNear_KeyDown(object sender, KeyEventArgs e)
        {
            // Đóng Form khi nhấn Escape ;
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}