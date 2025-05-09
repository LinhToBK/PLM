using Newtonsoft.Json;
using PLM_Lynx._02_BLL_Bussiness_Logic_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PLM_Lynx._03_GUI_User_Interface._3_3_ECO
{
    public partial class frmModifyQuantity : Form
    {
        private ECO_BLL ecoBLL = new ECO_BLL();

        // =========== Language =========================
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

            rm = new ResourceManager("PLM_Lynx._03_GUI_User_Interface._3_3_ECO.Lang.Lange_ModifyQuantity", typeof(frmModifyQuantity).Assembly);
            // Hiển thị ngôn ngữ lên các điều khiển trong form
            this.Text = rm.GetString("i.form");

            btnUpdate.Text = rm.GetString("lb6");

            Properties.Settings.Default.Language = lang;
            Properties.Settings.Default.Save();
        }

        // =========== Language =========================
        public frmModifyQuantity()
        {
            InitializeComponent();
            LoadLanguage();
        }


        // ====================================
        // Danh sách các biến 
        // ====================================

        public string parentcode { get; set; }
        public string parentname { get; set; }
        public DataTable tblListChildSelected { get; set; } // Danh sách các Part đã chọn

        public int idnguoiyeucau { get; set; } // ID người yêu cầu ECO này
        public string tennguoiyc { get; set; } // Tên người yêu cầu ECO này

        private bool accepted_update = false;

        private DataTable _ecoContent = new DataTable();


        public void CapnhatControlModifyQuantity()
        {
            txtParentCode.Text = parentcode;
            txtParentName.Text = parentname;

            // từ tblListChildSelected, cập nhật lên trên dgv  dgvListChildSelected

            foreach (DataRow row in tblListChildSelected.Rows)
            {
                dgvListChildSelected.Rows.Add(row[0].ToString(), row[1].ToString(), row[2].ToString(), "", "");
            }
            dgvListChildSelected.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvListChildSelected.Columns[0].Width = 80; // PartCode

            dgvListChildSelected.Columns[2].Width = 50; // Old Quantity
            dgvListChildSelected.Columns[3].Width = 50; // New Quantity
            dgvListChildSelected.Columns[4].Width = 200; // Status
            dgvListChildSelected.AllowUserToAddRows = false;
            dgvListChildSelected.AllowUserToDeleteRows = false;

            // Khóa lại các cột
            dgvListChildSelected.Columns[0].ReadOnly = true; // PartCode
            dgvListChildSelected.Columns[1].ReadOnly = true; // PartName
            dgvListChildSelected.Columns[2].ReadOnly = true; // Old Quantity
            dgvListChildSelected.Columns[4].ReadOnly = false; // Status
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            /* Version chỉ cập nhật riêng cho từng part
            // Đẩy dữ liệu này lên tblRelationTemp => Việc này có vẻ không cần thiết
            // Đồng thời , tạo ECONo cho việc phê duyệt
            int ECONo = ecoBLL.LoadECONo();

            List<Tuple<string, object>> tableData = new List<Tuple<string, object>>
                {
                    new Tuple<string, object>("ParentCode", parentcode),
                    new Tuple<string, object>("ChildCode", childcode),
                    new Tuple<string, object>("Quantity", Convert.ToInt32(newquantity))
                };
            Dictionary<string, object> jsonData = new Dictionary<string, object>();
            foreach (var row in tableData)
            {
                jsonData[row.Item1] = row.Item2;
            }

            // Chuyển thành chuỗi JSON
            string ECOContent = JsonConvert.SerializeObject(jsonData, Formatting.Indented);
            ECOContent = "[" + ECOContent + "]";
            int ECOTypeID = 4 ; // 4 là ECO cho sửa số lượng Part

            string tb = rm.GetString("t1");
            tb = tb + "\r\n ParentCode : " + parentcode;
            tb = tb + "\r\n ChildCode : " + childcode;
            tb = tb + "\r\n Old Quantity : " + oldquantity + " => New Quantity " + newquantity;

            DialogResult kq = MessageBox.Show(tb, rm.GetString("t0"), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq == DialogResult.No)
            {
                return;
            }
            else
            {
                // Bước 2 : Thực hiện cập nhật ECO
                if (ecoBLL.InsertNewECO_BLL(ECONo, idnguoiyeucau, tennguoiyc, ECOTypeID, ECOContent))
                {
                    MessageBox.Show(rm.GetString("t2"));      // Tạo ECO thành công
                    this.Close();
                }
                else
                {
                    MessageBox.Show(rm.GetString("t3"));  // Xuất hiện lỗi khi tạo ECO \n Kiểm tra lại dữ liệu
                    return;
                }
            }
            */

            CheckInput();
            if (accepted_update == false)
            {
                MessageBox.Show(rm.GetString("t4")); // Có lỗi xảy ra trong quá trình kiểm tra dữ liệu nhập vào. \r\n Vui lòng kiểm tra lại.
                return;
            }
            if (accepted_update == true)
            {

                // Tạo ECONo cho việc phê duyệt
                int ECONo = ecoBLL.LoadECONo();

                // Tạo file JSON
                GetECOContent();
                // Chuyển thành chuỗi JSON
                string ECOContent = JsonConvert.SerializeObject(_ecoContent, Formatting.Indented);
                // MessageBox.Show("Thông tin ECOContent : \r\n " + ECOContent);

                int ECOTypeID = 4; // 4 là ECO cho sửa số lượng Part
                string tb = "Do you want to make ECO Request ?";
                DialogResult kq = MessageBox.Show(tb, rm.GetString("t0"), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (kq == DialogResult.No)
                {
                    return;
                }
                else
                {
                    // Bước 2 : Thực hiện cập nhật ECO
                    if (ecoBLL.InsertNewECO_BLL(ECONo, idnguoiyeucau, tennguoiyc, ECOTypeID, ECOContent))
                    {                  
                        MessageBox.Show(rm.GetString("t2"));      // Tạo ECO thành công
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show(rm.GetString("t3"));  // Xuất hiện lỗi khi tạo ECO \n
                    }


                }
            }
        }

        private void frmModifyQuantity_Load(object sender, EventArgs e)
        {
            CapnhatControlModifyQuantity();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtOldQuantity_TextChanged(object sender, EventArgs e)
        {
        }

        private void CheckInput()
        {
            int OK_Row = 0;

            // Kiểm tra giá trị nhập vào của quantity
            foreach (DataGridViewRow row in dgvListChildSelected.Rows)
            {
                string oldQuantity = row.Cells[2].Value.ToString();
                string newQuantity = row.Cells[3].Value.ToString().Trim();

                if (oldQuantity == newQuantity) {
                    row.Cells[4].Value = rm.GetString("t5");     // Giá trị nhập vào không thay đổi
                    continue;
                }

                // Kiểm tra xem giá trị nhập vào có phải là số nguyên dương hay không
                if (!int.TryParse(newQuantity, out int result) || result < 0)
                {
                    row.Cells[4].Value = rm.GetString("t6");     // Giá trị nhập vào không hợp lệ

                }
                else
                {
                    row.Cells[4].Value = "OK";
                    OK_Row++;
                }

            }
            if (OK_Row == dgvListChildSelected.Rows.Count)
            {
                accepted_update = true;

            }
            else
            {
                accepted_update = false;

            }

        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            CheckInput();
        }

        private void GetECOContent()
        {
            // dgvListChildSelected
            // PartCode | PartName | Old Quantity | New Quantity | Status

            DataTable newTable = new DataTable();
            foreach (DataGridViewColumn col in dgvListChildSelected.Columns)
            {
                if(col.Name == "PartCode")
                {
                    newTable.Columns.Add("p", typeof(string));
                } 
                if(col.Name == "OldQuantity")
                {
                    newTable.Columns.Add("o", typeof(int));
                }
                if (col.Name == "NewQuantity")
                {
                    newTable.Columns.Add("n", typeof(int));
                }

            }

            // Copy dữ liệu từng dòng, trừ cột "Tuổi"
            foreach (DataGridViewRow row in dgvListChildSelected.Rows)
            {
                DataRow newRow = newTable.NewRow();
                newRow["p"] = row.Cells[0].Value.ToString();  // Part Code
                newRow["o"] = row.Cells[2].Value.ToString();  // Old Quantity
                newRow["n"] = row.Cells[3].Value.ToString();  // New Quantity


                newTable.Rows.Add(newRow);
            }

            // Thêm dữ liệu parentcode  cho hàng đầu tiên
            DataRow Row = newTable.NewRow();
            Row["p"] = parentcode;
            Row["o"] = 1;
            Row["n"] = 1;

            // Thêm vào vị trí đầu tiên (index 0)
            newTable.Rows.InsertAt(Row, 0);

            // Gán DataTable mới vào biến DataECOContent
            _ecoContent = newTable;
        }
    }
}