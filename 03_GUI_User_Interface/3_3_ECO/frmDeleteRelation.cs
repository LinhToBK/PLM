using Newtonsoft.Json;
using PLM_Lynx._02_BLL_Bussiness_Logic_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PLM_Lynx._03_GUI_User_Interface._3_3_ECO
{
    public partial class frmDeleteRelation : Form
    {
        // Khai báo biến
        public string parentname { get; set; }

        public string parentcode { get; set; }
        public DataTable tblListChildSelected { get; set; }
        public int idnguoiyeucau { get; set; }
        public string tennguoiyc { get; set; }

        private ECO_BLL _ecoBLL = new ECO_BLL();

        private DataTable tblECOContent = new DataTable();

        public frmDeleteRelation()
        {
            InitializeComponent();
        }

        private void frmDeleteRelation_Load(object sender, EventArgs e)
        {
            // Hiển thị các thông tin
            txtParentCode.Text = parentcode;
            txtParentName.Text = parentname;
            // Hiển thị danh sách các child đã chọn
            dgvListChildSelected.DataSource = tblListChildSelected;
            dgvListChildSelected.Columns[0].HeaderText = "Child Code";
            dgvListChildSelected.Columns[1].HeaderText = "Child Name";
            dgvListChildSelected.AllowUserToAddRows = false;
            dgvListChildSelected.AllowUserToDeleteRows = false;
            dgvListChildSelected.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvListChildSelected.Columns[0].Width = 100;
            dgvListChildSelected.Columns[0].ReadOnly = true;
            dgvListChildSelected.Columns[1].ReadOnly = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            string tb = "Do you want to cancel?";
            DialogResult result = MessageBox.Show(tb, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnMakeRequest_Click(object sender, EventArgs e)
        {
            string mes = "Do you want to make request delete relation ?";
            DialogResult result = MessageBox.Show(mes, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                // Tạo ECONo cho việc phê duyệt
                int ECONo = _ecoBLL.LoadECONo();
                // Tạo bảng ECO Content
                GetECOContent();
                // Chuyển thành chuỗi JSON
                string ECOContent = JsonConvert.SerializeObject(tblECOContent, Formatting.Indented);
                // MessageBox.Show("Thông tin ECOContent : \r\n " + ECOContent);

                int ECOTypeID = 5; // 5 là ECO cho xóa các ràng buộc giữa các đối tượng

                // Bước 2 : Thực hiện cập nhật ECO
                if (_ecoBLL.InsertNewECO_BLL(ECONo, idnguoiyeucau, tennguoiyc, ECOTypeID, ECOContent))
                {
                    MessageBox.Show("Make request [ delete relation ] successfully. ");      // Tạo ECO thành công
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Can not make the request [ delete relation ]");  // Xuất hiện lỗi khi tạo ECO \n
                }
            }
        }

        private void GetECOContent()
        {
            tblECOContent.Clear(); // Xóa dữ liệu cũ trong DataTable tblECOContent
            // ParentCode || ChildCode

            DataTable newTable = new DataTable();
            newTable.Columns.Add("p", typeof(string)); // Parent Code
            newTable.Columns.Add("c", typeof(string));   // Child Code

            // Copy dữ liệu từng dòng, trừ cột "Tuổi"
            foreach (DataGridViewRow row in dgvListChildSelected.Rows)
            {
                DataRow newRow = newTable.NewRow();
                newRow["p"] = txtParentCode.Text; // Part Code
                newRow["c"] = row.Cells[0].Value.ToString();  // Old Quantity

                newTable.Rows.Add(newRow);
            }

            // Gán DataTable mới vào biến DataECOContent
            tblECOContent = newTable;
        }
    }
}