using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;
using Azure.Core;
using PLM_Lynx._02_BLL_Bussiness_Logic_Layer;

namespace PLM_Lynx._03_GUI_User_Interface._3_5_Purchase
{
    public partial class frmImportListItems : Form
    {
        private PurchaseBLL _purchaseBLL = new PurchaseBLL();

        public frmImportListItems()
        {
            InitializeComponent();
        }

        public DataTable ListItem_Now { get; set; }

        public DataTable ListItem_OK { get; set; }

        private void frmImportListItems_Load(object sender, EventArgs e)
        {
            AutoFill_dgvListitems();
            GetList_ItemNow();
        }

        private List<String> d_sach_ItemNow = new List<string>();

        private DataTable Convert_d_sach_ItemNow_to_datatable(List<String> d_sach)
        {
            // Kiểm tra trước, nếu d_sach rỗng thì không cần làm gì cả
            if (d_sach == null || d_sach.Count == 0)
            {
                return null;
            }
            // Convert từ List String sang 1 datatable
            DataTable dt = new DataTable();
            dt.Columns.Add("PartCode", typeof(string));
            foreach (string item in d_sach)
            {
                dt.Rows.Add(item);
            }

            return dt;
        }

        private void GetList_ItemNow()
        {
            // Lấy danh sách Item hiện tại từ datatable    ListItem_Now
            d_sach_ItemNow.Clear();
            if (ListItem_Now != null && ListItem_Now.Rows.Count > 0)
            {
                foreach (DataRow row in ListItem_Now.Rows)
                {
                    string partCode = row["PartCode"].ToString();
                    d_sach_ItemNow.Add(partCode);
                }
            }
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            // Load dữ liệu của danh sách vừa thêm trong dgvImportListItems
            if (dgvListItem.Rows.Count > 0)
            {
                List<string> dsach_PartCode = new List<string>();

                foreach (DataGridViewRow row in dgvListItem.Rows)
                {
                    // Bỏ qua dòng "new row" của DataGridView nếu nó có
                    // if (row.IsNewRow) continue;

                    object cellValue = row.Cells["PartCode"].Value;

                    // Kiểm tra nếu PartCode bị null hoặc rỗng thì bỏ qua
                    if (cellValue == null || string.IsNullOrWhiteSpace(cellValue.ToString().Trim()))
                        continue;

                    string partCode = cellValue.ToString().Trim();

                    if (dsach_PartCode.Contains(partCode))
                    {
                        // Tô màu đỏ cho dòng trùng
                        row.DefaultCellStyle.BackColor = Color.Red;
                        row.Cells["Status"].Value = "This Part Code already exists in the list.";
                    }
                    else
                    {
                        // Kiểm tra có trong danh sách code đang có hay khônng
                        if (d_sach_ItemNow.Contains(partCode))
                        {
                            // Tô màu vàng cho dòng trùng
                            row.DefaultCellStyle.BackColor = Color.Yellow;
                            row.Cells["Status"].Value = "This Part Code already exists in the current list.";
                        }
                        else
                        {
                            row.Cells["Status"].Value = "";
                            dsach_PartCode.Add(partCode);
                        }
                    }
                }

                // Lấy danh sách PartCode này đi kiểm tra trong database

                DataTable GetPartCode_database = _purchaseBLL.QueryInforItemPO_BLL(Convert_d_sach_ItemNow_to_datatable(dsach_PartCode));

                List<string> d_sach_PartCode_NG = new List<string>();
                if (GetPartCode_database != null && GetPartCode_database.Rows.Count > 0)
                {
                    foreach (DataRow row in GetPartCode_database.Rows)
                    {
                        string partCode = row["PartCode"].ToString();
                        string partName = row["PartName"].ToString();
                        if (partName == null || partName == "")
                        {
                            d_sach_PartCode_NG.Add(partCode);
                        }
                    }
                }

                // Kiểm tra từng dòng trong dgvListItem với danh sách PartCode trong database
                foreach (DataGridViewRow row in dgvListItem.Rows)
                {
                    object cellValue = row.Cells["PartCode"].Value;
                    // Kiểm tra nếu PartCode bị null hoặc rỗng thì bỏ qua
                    if (cellValue == null || string.IsNullOrWhiteSpace(cellValue.ToString().Trim()))
                        continue;
                    string partCode = cellValue.ToString().Trim();
                    string status = row.Cells["Status"].Value.ToString();
                    if (d_sach_PartCode_NG.Contains(partCode) && status == "")
                    {
                        // Tô màu xanh cho dòng trùng
                        row.DefaultCellStyle.BackColor = Color.BlueViolet;
                        row.Cells["Status"].Value = "This partcode does not exist in the database.";
                    }
                    else
                    {
                        row.Cells["Status"].Value = "OK";
                    }    
                }

                // Xóa những dòng trắng nếu có
                foreach (DataGridViewRow row in dgvListItem.Rows)
                {
                    if (row.IsNewRow) continue; // Bỏ qua dòng mới
                    if (string.IsNullOrWhiteSpace(row.Cells["PartCode"].Value?.ToString()))
                    {
                        dgvListItem.Rows.Remove(row);
                    }
                }

                if(CheckOK() == true)
                {
                    MessageBox.Show("All items are OK.", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Some items are not OK.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("List items is empty.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void AutoFill_dgvListitems()
        {
            // Hiệu chỉnh lại dgvListItems
            dgvListItem.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvListItem.Columns["Check"].Width = 50;
            dgvListItem.Columns["PartCode"].Width = 100;
            dgvListItem.Columns["PartName"].Width = 200;
            //dgvListItem.Columns["Status"].Width = 200;
        }

        private void dgvListItem_KeyDown(object sender, KeyEventArgs e)

        {
            if (e.Control && e.KeyCode == Keys.V)
            {
                PasteClipboardToGrid("PartCode");
            }
        }

        private void PasteClipboardToGrid(string columnName)
        {
            try
            {
                // Lấy nội dung từ clipboard
                string clipboardText = Clipboard.GetText();
                if (string.IsNullOrWhiteSpace(clipboardText))
                {
                    MessageBox.Show("Clipboard trống hoặc không có dữ liệu.");
                    return;
                }

                // Tách từng dòng (Excel thường phân tách bằng \r\n)
                string[] lines = clipboardText.Split(new[] { "\r\n", "\n", "\r" }, StringSplitOptions.RemoveEmptyEntries);

                // Vị trí dòng đang chọn trong DataGridView
                int startRowIndex = dgvListItem.CurrentCell?.RowIndex ?? 0;

                // Thêm dòng nếu chưa đủ
                while (dgvListItem.Rows.Count < startRowIndex + lines.Length)
                {
                    dgvListItem.Rows.Add();
                }

                // Gán từng dòng vào cột được chọn
                for (int i = 0; i < lines.Length; i++)
                {
                    DataGridViewRow row = dgvListItem.Rows[startRowIndex + i];
                    row.Cells["PartCode"].Value = lines[i].Trim();
                }

                AutoFill_dgvListitems();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi dán dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            string tb = "Do you want to close this tab ? ";
            DialogResult result = MessageBox.Show(tb, "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnDeleteRow_Click(object sender, EventArgs e)
        {
            // Xóa những hàng đang chọn
            foreach (DataGridViewRow row in dgvListItem.SelectedRows)
            {
                if (!row.IsNewRow && dgvListItem.Rows.Count > 1) // Bỏ qua dòng mới
                {
                    dgvListItem.Rows.Remove(row);
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            // Xóa hết dữ liệu trong dgvListItems
            string tb = "Do you want to clear all data in this list ?";
            DialogResult result = MessageBox.Show(tb, "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                dgvListItem.Rows.Clear();
            }
        }

        private void btnClean_Click(object sender, EventArgs e)
        {
            string tb = "Do you want to clean input data?";
            DialogResult result = MessageBox.Show(tb, "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.No)
            {
                return;
            }
            else
            {
                for (int i = dgvListItem.Rows.Count - 1; i >= 0; i--)
                {
                    DataGridViewRow row = dgvListItem.Rows[i];

                    if (row.DefaultCellStyle.BackColor == Color.Red ||
                        row.DefaultCellStyle.BackColor == Color.Yellow ||
                        row.DefaultCellStyle.BackColor == Color.BlueViolet)
                    {
                        if (!row.IsNewRow) // tránh xóa dòng trống cuối cùng của DataGridView
                        {
                            dgvListItem.Rows.RemoveAt(i);
                        }
                    }
                }
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            string tb = "Do you want to import this list ?";
            DialogResult result = MessageBox.Show(tb, "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                btnCheck.PerformClick(); // Gọi hàm Check trước khi import
                if (CheckOK() == true)
                {
                    // Lấy danh sách code từ dgvListItem
                    DataTable dt_OK = new DataTable();
                    dt_OK.Columns.Add("PartCode", typeof(string));
                    foreach(DataGridViewRow row in dgvListItem.Rows)
                    {
                        // Bỏ qua dòng "new row" của DataGridView nếu nó có
                        
                        object cellValue = row.Cells["PartCode"].Value;
                        // Kiểm tra nếu PartCode bị null hoặc rỗng thì bỏ qua
                        if (cellValue == null || string.IsNullOrWhiteSpace(cellValue.ToString().Trim()))
                            continue;
                        string partCode = cellValue.ToString().Trim();
                        dt_OK.Rows.Add(partCode);
                    }

                    // Gán danh sách này cho ListItem_OK
                    ListItem_OK = _purchaseBLL.QueryInforItemPO_BLL(dt_OK);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Please check the list again.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private bool CheckOK()
        {
            // Thực hiện việc click Check trước
            

            bool status = true ;
            
            if (dgvListItem.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvListItem.Rows)
                {
                    if (row.DefaultCellStyle.BackColor == Color.Red ||
                            row.DefaultCellStyle.BackColor == Color.Yellow ||
                            row.DefaultCellStyle.BackColor == Color.BlueViolet)
                    {
                        status = false; ; // Có dòng bị tô màu đỏ
                        break;
                    }
                }
            }
            else
            {
                status = false; // Không có dòng nào bị tô màu đỏ
            }

            return status;

        }
    }
}