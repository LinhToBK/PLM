using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PLM_Lynx._03_GUI_User_Interface._3_5_Purchase
{
    public partial class frmMoneyType : Form
    {
        public frmMoneyType()
        {
            InitializeComponent();
        }
        public DataTable ListMoneyType { get; set; }
        public string OldMoneyType { get; set; }
        private string NewMoney { get; set; }   

        private void frmMoneyType_Load(object sender, EventArgs e)
        {
             txtOldCurrency.Text = OldMoneyType;
            btnApply.Enabled = false; // Khởi tạo nút Apply không được kích hoạt
            // Lấy danh sách các loại tiền tệ và lưu lại vào DataTable
            dgvListMoneyType.DataSource = ListMoneyType;
            // Hiệu chỉnh kích thước các cột
            dgvListMoneyType.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvListMoneyType.Columns["CurrencyID"].Width = 80;
            dgvListMoneyType.AllowUserToAddRows = false; // Không cho phép thêm dòng mới
            dgvListMoneyType.AllowUserToDeleteRows = false; // Không cho phép xóa dòng
        }

        private void dgvListMoneyType_Click(object sender, EventArgs e)
        {

            btnApply.Enabled = true;
            if (ListMoneyType != null)
            {
                txtNewCurrency.Text = dgvListMoneyType.CurrentRow.Cells["CurrencyName"].Value.ToString();
            }
        }

        public string NewMoneyType
        {
            get
            {
                return txtNewCurrency.Text;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            txtNewCurrency.Text = dgvListMoneyType.CurrentRow.Cells["CurrencyName"].Value.ToString();
            this.Close();
        }
    }
}
