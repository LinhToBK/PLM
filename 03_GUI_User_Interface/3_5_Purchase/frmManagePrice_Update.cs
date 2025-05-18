using PLM_Lynx._02_BLL_Bussiness_Logic_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PLM_Lynx._03_GUI_User_Interface._3_5_Purchase
{
    public partial class frmManagePrice_Update : Form
    {
        public frmManagePrice_Update()
        {
            InitializeComponent();
        }

        private PurchaseBLL _purchaseBLL = new PurchaseBLL();

        // Load các thông tin trước
        private DataTable tblMoneyType = new DataTable();

        public string username { get; set; }

        // Tạo các biến để lưu lại các thông tin
        private DataTable List_Items_Now = new DataTable();

        // ========== Load Data ==============
        private void frmManagePrice_Update_Load(object sender, EventArgs e)
        {
            GetMoneyType();
        }

        private void Convert_dgvListItem_to_datatable(DataGridView dgv)
        {
            // Xóa datatable List_Items_Now
            List_Items_Now.Clear();

            DataTable dt = new DataTable();

            // Tạo các cột trong DataTable từ DataGridView
            foreach (DataGridViewColumn column in dgv.Columns)
            {
                dt.Columns.Add(column.Name, column.ValueType ?? typeof(string));
            }

            // Thêm từng dòng dữ liệu
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.IsNewRow) continue; // Bỏ dòng trống cuối

                DataRow dr = dt.NewRow();
                foreach (DataGridViewCell cell in row.Cells)
                {
                    dr[cell.OwningColumn.Name] = cell.Value ?? DBNull.Value;
                }
                dt.Rows.Add(dr);
            }

            List_Items_Now = dt; // Lưu lại danh sách Item hiện tại
        }

        // dgvListItem
        // PartCode || PartName || OldImportPrice || NewImportPrice|| OldExportPrice  || NewExportPrice ||Status || Current Price ||

        private void GetMoneyType()
        {
            tblMoneyType = _purchaseBLL.Get_tblMoneytype_BLL();// Lấy danh sách các loại tiền tệ và lưu lại vào DataTable
            
        }

        private void View_Fit_dgvListItems()
        {
            // Thiết lập cho datagridview

            // Chỉnh kích thước các cột còn lại
            dgvListItems.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvListItems.Columns["PartCode"].Width = 100;
            dgvListItems.Columns["PartName"].Width = 150;
            dgvListItems.Columns["OldImportPrice"].Width = 60;
            dgvListItems.Columns["NewImportPrice"].Width = 60;
            dgvListItems.Columns["OldExportPrice"].Width = 60;
            dgvListItems.Columns["NewExportPrice"].Width = 60;

            dgvListItems.Columns["Currency"].Width = 50;

            // Không cho phép thêm / xóa từ người dùng
            dgvListItems.AllowUserToAddRows = false; // Không cho phép thêm dòng mới
            dgvListItems.AllowUserToDeleteRows = false; // Không cho phép xóa dòng

            // Khóa 1 số dòng , không cho hiệu chỉnh 
            dgvListItems.Columns["PartCode"].ReadOnly = true;
            dgvListItems.Columns["PartName"].ReadOnly = true;
            dgvListItems.Columns["Currency"].ReadOnly = true;
            dgvListItems.Columns["Status"].ReadOnly = true;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            string tb = "Do you want to exit [UPDATE PRICE ] ?";
            DialogResult kq = MessageBox.Show(tb, "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (kq == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            // Kiểm tra ô tìm kiếm có rỗng hay không
            if (txtSearch.Text.Trim() != "")
            {
                // Nếu không rỗng thì gọi hàm tìm kiếm
                DataTable dt = _purchaseBLL.FindwithwordBLL(txtSearch.Text.Trim());
                if (dt.Rows.Count > 0)
                {
                    //   p.PartCode,  0
                    //   p.PartName,     1
                    //   p.PartPriceSale,  2
                    //   p.PartID,  3
                    //p.PartPrice,   4
                    //p.PartCurrentID       5
                    // Nếu có kết quả thì hiển thị lên DataGridView
                    dgvListSearch.DataSource = dt;

                    // Thiết lập cho datagridview
                    // Ẩn các cột không cần thiết
                    dgvListSearch.Columns["PartID"].Visible = false;
                    dgvListSearch.Columns["PartCurrentID"].Visible = false;
                    dgvListSearch.Columns["PartPrice"].Visible = false;
                    dgvListSearch.Columns["PartPriceSale"].Visible = false;
                    // Chỉnh kích thước các cột còn lại
                    dgvListSearch.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dgvListSearch.Columns["PartCode"].Width = 100;
                }
                else
                {
                    // Nếu không có kết quả thì thông báo
                    MessageBox.Show("No result found!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Please enter a keyword to search!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Ngăn tiếng 'beep' khi nhấn Enter
                btnSearch.PerformClick(); // Gọi sự kiện click của nút Search
            }
        }


        private bool PartCode_in_dgvListItems(string partCode)
        {

            if (dgvListItems.Rows.Count > 0)
            {
                // Kiểm tra xem mã hàng đã có trong dgvListItems chưa
                foreach (DataGridViewRow row in dgvListItems.Rows)
                {
                    // Kiêm tra nếu row khác trắng thì mới kiểm tra
                    if(row.Cells["PartCode"].Value != null)
                    {
                        if (row.Cells["PartCode"].Value.ToString() == partCode)
                        {
                            return true; // Đã có mã hàng
                        }
                    }
                }
            }
            return false; // Chưa có mã hàng
        }

        private void btnAddItems_Click(object sender, EventArgs e)
        {

            // Thêm hàng vào dgvListItem
            if (dgvListSearch.Rows.Count > 0)
            {
                // Lấy thông tin hàng được chọn
                string partCode = dgvListSearch.CurrentRow.Cells["PartCode"].Value.ToString();

                if(PartCode_in_dgvListItems(partCode) == true)

                {
                    MessageBox.Show("PartCode : [ " + partCode + " ] already exists in the list!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string partName = dgvListSearch.CurrentRow.Cells["PartName"].Value.ToString();
                string OldImportPrice = dgvListSearch.CurrentRow.Cells["PartPrice"].Value.ToString();
                string OldExportPrice = dgvListSearch.CurrentRow.Cells["PartPriceSale"].Value.ToString();
                int partID = Convert.ToInt32(dgvListSearch.CurrentRow.Cells["PartID"].Value);
                // Lấy  loại tiền tệ của code
                object value = dgvListSearch.CurrentRow.Cells["PartCurrentID"].Value;

                int partCurrentID = value != null && value != DBNull.Value
                    ? Convert.ToInt32(value) : 1;

                // Thêm hàng vào dgvListItem
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dgvListItems);

                // Gán giá trị cho từng ô
                row.Cells[0].Value = partCode;         // Mã hàng
                row.Cells[1].Value = partName;         // Tên hàng
                row.Cells[2].Value = OldImportPrice;   // Giá nhập cũ
                row.Cells[3].Value = "";               // Giá nhập mới
                row.Cells[4].Value = OldExportPrice;   // Giá xuất cũ
                row.Cells[5].Value = "";               // Giá xuất mới

                foreach (DataRow row1 in tblMoneyType.Rows)
                {
                    if (Convert.ToInt32(row1["CurrencyID"]) == partCurrentID)
                    {
                        row.Cells[6].Value = row1["CurrencyName"]; // Loại tiền tệ
                        break;
                    }
                }
                row.Cells[7].Value = "";  // Status

                dgvListItems.Rows.Add(row); // Thêm hàng vào DataGridView
                View_Fit_dgvListItems(); // Gọi hàm để điều chỉnh kích thước cột
            }
            else
            {
                MessageBox.Show("Please select a row to add!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvListSearch_MouseDown(object sender, MouseEventArgs e)
        {
            // Khi click chuột phải vào , sẽ hiển thị contextmenustrip  :Option
            if (e.Button == MouseButtons.Right)
            {
                int currentMouseOverRow = dgvListSearch.HitTest(e.X, e.Y).RowIndex;
                if (currentMouseOverRow >= 0)
                {
                    dgvListSearch.ClearSelection();
                    dgvListSearch.Rows[currentMouseOverRow].Selected = true;
                    cmsOption.Show(dgvListSearch, e.Location);
                }
            }
        }

        private void addItemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnAddItems.PerformClick();
        }

        private void btnDeleteRow_Click(object sender, EventArgs e)
        {
            // Xóa những dòng đang chọn trong dgvListItems
            string tb = "Do you want to delete the selected rows?";
            DialogResult kq = MessageBox.Show(tb, "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (kq == DialogResult.Yes)
            {
                Clear_dgvListItems();
            }
        }

        private void Clear_dgvListItems()
        {
            if (dgvListItems.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvListItems.SelectedRows)
                {
                    if (!row.IsNewRow) // Kiểm tra không phải là dòng mới
                    {
                        dgvListItems.Rows.Remove(row);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a row to delete!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnClearList_Click(object sender, EventArgs e)
        {
            // Xóa hết danh sách đang có trong dgvListItems
            string tb = "Do you want to clear the list?";
            DialogResult kq = MessageBox.Show(tb, "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (kq == DialogResult.Yes)
            {
                dgvListItems.Rows.Clear();
            }
        }

        private void cms_ChangeMoney_Type_Click(object sender, EventArgs e)
        {
            using (frmMoneyType formA = new frmMoneyType())
            {
                formA.ListMoneyType = tblMoneyType; // Truyền danh sách loại tiền tệ vào Form A
                formA.OldMoneyType = dgvListItems.CurrentRow.Cells["Currency"].Value.ToString();

                var result = formA.ShowDialog();  // Dùng ShowDialog để chờ form A đóng
                if (result == DialogResult.OK || result == DialogResult.Cancel) // hoặc chỉ cần kiểm tra nếu != null
                {
                    string receivedText = formA.NewMoneyType; // Lấy dữ liệu từ Form A
                    // Thay đổi loại tiền tệ cho các hàng đã chọn
                    dgvListItems.CurrentRow.Cells["Currency"].Value = receivedText;
                }
            }
        }

        private void dgvListItems_MouseDown(object sender, MouseEventArgs e)
        {
            // Khi click chuột phải vào , sẽ hiển thị contextmenustrip  :Option
            if (e.Button == MouseButtons.Right)
            {
                int currentMouseOverRow = dgvListItems.HitTest(e.X, e.Y).RowIndex;
                if (currentMouseOverRow >= 0)
                {
                    dgvListItems.ClearSelection();
                    dgvListItems.Rows[currentMouseOverRow].Selected = true;
                    cms_dgvListItems.Show(dgvListItems, e.Location);
                }
            }
        }

        private void cms_Delete_Click(object sender, EventArgs e)
        {
            Clear_dgvListItems();
        }

        private void cms_Clear_Click(object sender, EventArgs e)
        {
            // Xóa hết danh sách đang có trong dgvListItems
            string tb = "Do you want to clear the list?";
            DialogResult kq = MessageBox.Show(tb, "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (kq == DialogResult.Yes)
            {
                dgvListItems.Rows.Clear();
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            //frmImportListItems frm = new frmImportListItems();
            //Convert_dgvListItem_to_datatable(dgvListItems); // Chuyển đổi dgvListItems thành datatable List_Items_Now
            //frm.ListItem_Now = List_Items_Now; // Truyền danh sách Item hiện tại vào Form A

            //frm.ShowDialog();

            using (frmImportListItems formA = new frmImportListItems())
            {
                Convert_dgvListItem_to_datatable(dgvListItems); // Chuyển đổi dgvListItems thành datatable List_Items_Now
                formA.ListItem_Now = List_Items_Now; // Truyền danh sách Item hiện tại vào Form A

                var result = formA.ShowDialog();  // Dùng ShowDialog để chờ form A đóng
                if (result == DialogResult.OK || result == DialogResult.Cancel) // hoặc chỉ cần kiểm tra nếu != null
                {
                    DataTable ListItemImportOK = formA.ListItem_OK;
                    if(ListItemImportOK == null)
                    {
                        MessageBox.Show("No data imported!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    //Lấy danh sách từ datatabeLisstItemImportOK điền thêm  vào dgvListItems
                    if (ListItemImportOK.Rows.Count > 0 && ListItemImportOK !=null )
                    {
                        foreach (DataRow row in ListItemImportOK.Rows)
                        {
                            // Thêm hàng vào dgvListItem
                            DataGridViewRow newRow = new DataGridViewRow();
                            newRow.CreateCells(dgvListItems);
                            // Gán giá trị cho từng ô
                            newRow.Cells[0].Value = row["PartCode"];         // Mã hàng
                            newRow.Cells[1].Value = row["PartName"];         // Tên hàng
                            newRow.Cells[2].Value = row["PartPrice"];   // Giá nhập cũ
                            newRow.Cells[3].Value = "";   // Giá nhập mới
                            newRow.Cells[4].Value = row["PartPriceSale"];   // Giá xuất cũ
                            newRow.Cells[5].Value = "";   // Giá xuất mới

                            object value = row["PartCurrentID"];

                            int partCurrentID = value != null && value != DBNull.Value
                                ? Convert.ToInt32(value) : 1;
                            foreach (DataRow row1 in tblMoneyType.Rows)
                            {
                                if (Convert.ToInt32(row1["CurrencyID"]) == partCurrentID)
                                {
                                    newRow.Cells[6].Value = row1["CurrencyName"]; // Loại tiền tệ
                                    break;
                                }
                            }
                            newRow.Cells[7].Value = "";  // Status
                            dgvListItems.Rows.Add(newRow); // Thêm hàng vào DataGridView
                        }

                        View_Fit_dgvListItems(); // Gọi hàm để điều chỉnh kích thước cột

                        MessageBox.Show("Import successful!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void frmManagePrice_Update_KeyDown(object sender, KeyEventArgs e)
        {
            // Tạo các phím tắt trong form
            // click vào button Import : Ctrl + I
            if (e.Control && e.KeyCode == Keys.I)
            {
                // Ngăn tiếng bíp
                e.SuppressKeyPress = true;
                btnImport.PerformClick();
            }

            // đóng form :  Alt + F4
            if (e.Alt && e.KeyCode == Keys.F4)
            {
                // Ngăn tiếng bíp
                e.SuppressKeyPress = true;
                btnExit.PerformClick();
            }

            // Tìm kiếm trên ô textbot : Ctrl + F
            if (e.Control && e.KeyCode == Keys.F)
            {
                // Ngăn tiếng bíp
                e.SuppressKeyPress = true;
                txtSearch.Focus();
            }
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            // Kiểm tra dữ liệu nhập vào 
            Check_InputOK();
        }

        private void Check_InputOK()
        {
            
            // Nếu có dòng nào chưa nhập thì thông báo
            foreach (DataGridViewRow row in dgvListItems.Rows)
            {
                
                if (string.IsNullOrEmpty(row.Cells["NewImportPrice"].Value?.ToString()) ||
                    string.IsNullOrEmpty(row.Cells["NewExportPrice"].Value?.ToString()))
                {
                    row.Cells["Status"].Value = "Value is empty"; 
                }
                // Nếu không phải là số cũng thông báo
                else if (!decimal.TryParse(row.Cells["NewImportPrice"].Value.ToString(), out _) ||
                         !decimal.TryParse(row.Cells["NewExportPrice"].Value.ToString(), out _))
                {
                    row.Cells["Status"].Value = "Value is not number";
                }
                else
                {
                    row.Cells["Status"].Value = "OK"; // Nếu không có gì thì OK
                    // Tô vàng cho dòng này
                    row.DefaultCellStyle.BackColor = Color.Yellow;
                }

            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string tb = "Do you want to update the price?";
            DialogResult kq = MessageBox.Show(tb, "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (kq == DialogResult.Yes)
            {
                // Kiểm tra dữ liệu nhập vào 
                Check_InputOK();
                // Nếu có dòng nào chưa nhập thì thông báo
                foreach (DataGridViewRow row in dgvListItems.Rows)
                {
                    if (row.Cells["Status"].Value.ToString() != "OK")
                    {
                        MessageBox.Show("Please check the data again!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                // Convert sang 1 datatable 
                // PartCode || NewImportPrice || NewExportPrice || UserName || CurrencyID || CurrencyName || PriceLog
                DataTable dt_import = new DataTable();
                dt_import.Columns.Add("PartCode", typeof(string));
                dt_import.Columns.Add("PartPrice", typeof(decimal));
                dt_import.Columns.Add("PartPriceSale", typeof(decimal));
                dt_import.Columns.Add("PartPriceLog", typeof(string));
                dt_import.Columns.Add("PartCurrentID", typeof(int));
                // Lấy dữ liệu từ dgvListItems vào datatable
                foreach (DataGridViewRow row in dgvListItems.Rows)
                {
                    if (row.Cells["Status"].Value.ToString() == "OK")
                    {
                        DataRow dr = dt_import.NewRow();
                        dr["PartCode"] = row.Cells["PartCode"].Value.ToString();
                        // dr["PartPrice"] = row.Cells["NewImportPrice"].Value.ToString();
                        // dr["PartPriceSale"] = row.Cells["NewExportPrice"].Value.ToString();
                        // Convert sang decimal
                        if(decimal.TryParse(row.Cells["NewImportPrice"].Value.ToString(), out decimal newImportPrice))
                        {
                            dr["PartPrice"] = newImportPrice;
                        }
                        else
                        {
                            MessageBox.Show("New Import Price is not a number!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return; ;
                        }

                        if (decimal.TryParse(row.Cells["NewExportPrice"].Value.ToString(), out decimal newExportPrice))
                        {
                            dr["PartPriceSale"] = newExportPrice;
                        }
                        else
                        {
                            MessageBox.Show("New Export Price is not a number!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }




                        string CurrencyName = row.Cells["Currency"].Value.ToString();
                        // Lấy giá trí của CurrencyName để quy đổi ra CurrencyID
                        foreach (DataRow row1 in tblMoneyType.Rows)
                        {
                            if (row1["CurrencyName"].ToString() == CurrencyName)
                            {
                                dr["PartCurrentID"]  = Convert.ToInt32(row1["CurrencyID"]);
                                break;
                            }
                        }

                        string PriceLog;
                        PriceLog = DateTime.Now.ToString() + "||";
                        PriceLog = PriceLog +  "User :" + username + "||";
                        PriceLog = PriceLog + "Old Import Price : " + row.Cells["OldImportPrice"].Value.ToString() + "||";
                        PriceLog = PriceLog + "New Import Price : " + row.Cells["NewImportPrice"].Value.ToString() + "||";
                        PriceLog = PriceLog + "Old Export Price : " + row.Cells["OldExportPrice"].Value.ToString() + "||";
                        PriceLog = PriceLog + "New Export Price : " + row.Cells["NewExportPrice"].Value.ToString() + "||";
                        PriceLog = PriceLog + "Currency : " + row.Cells["Currency"].Value.ToString() + "||";
                        dr["PartPriceLog"] = PriceLog;

                        dt_import.Rows.Add(dr);
                    }
                }

                if(_purchaseBLL.CapnhatPriceBLL(dt_import) == true)
                {
                    MessageBox.Show("Update successful!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Xóa hết danh sách đang có trong dgvListItems
                    dgvListItems.Rows.Clear();
                }
                else
                {
                    MessageBox.Show("Update failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

               

            }
        }

        private void viewFeatureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Mở Part
            // Khi double click vào cell, hiển thị Part
            // Mở form
            if (dgvListItems.Rows.Count > 0)
            {

                frmRelationPart_Detail_Info frm = new frmRelationPart_Detail_Info();
                string partcode = dgvListSearch.CurrentRow.Cells["PartCode"].Value.ToString();
                frm.ShowDetailInfor(partcode);
                frm.ShowDialog();
            }
        }

        private void cms_Item_ViewFeature_Click(object sender, EventArgs e)
        {
            if (dgvListItems.Rows.Count > 0)
            {

                frmRelationPart_Detail_Info frm = new frmRelationPart_Detail_Info();
                string partcode = dgvListItems.CurrentRow.Cells["PartCode"].Value.ToString();
                frm.ShowDetailInfor(partcode);
                frm.ShowDialog();
            }
        }
    }
}