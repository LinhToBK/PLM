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
    public partial class frmUnitType : Form
    {


        public DataTable ListUnitType { get; set; }
        public string OldUnitType { get; set; }
        private string NewUnit { get; set; }

        public frmUnitType()
        {
            InitializeComponent();
        }

        private void frmUnitType_Load(object sender, EventArgs e)
        {
            txtOldUnit.Text = OldUnitType;
            btnChange.Enabled = false; // Khởi tạo nút Apply không được kích hoạt
            // Lấy danh sách các loại tiền tệ và lưu lại vào DataTable
            dgvListUnitType.DataSource = ListUnitType;
            // Hiệu chỉnh kích thước các cột
            dgvListUnitType.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvListUnitType.Columns["UnitID"].Width = 80;
            dgvListUnitType.AllowUserToAddRows = false; // Không cho phép thêm dòng mới
            dgvListUnitType.AllowUserToDeleteRows = false; // Không cho phép xóa dòng
        }

        private void dgvListUnitType_Click(object sender, EventArgs e)
        {
            btnChange.Enabled = true;
            if (ListUnitType != null)
            {
                txtNewUnit.Text = dgvListUnitType.CurrentRow.Cells["UnitName"].Value.ToString();
            }
        }

        public string NewUnitType
        {
            get
            {
                return txtNewUnit.Text;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            txtNewUnit.Text = dgvListUnitType.CurrentRow.Cells["UnitName"].Value.ToString();
            this.Close();
        }
    }
}
