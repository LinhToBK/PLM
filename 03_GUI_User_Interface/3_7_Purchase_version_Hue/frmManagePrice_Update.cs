using PLM_Lynx._02_BLL_Bussiness_Logic_Layer;
using PLM_Lynx._03_GUI_User_Interface._00_Common;
using PLM_Lynx._03_GUI_User_Interface._3_7_Purchase_version_Hue;
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
        /// <summary>
        /// 01. Khởi tạo các biến
        /// </summary>
        // - 01. public
        public string username { get; set; }

        // - 02. private -static

        // SupplierID || SupplierCode || SupplierName || SupplierLocation || SupplierPhone || SupplierTaxNumber || SupplierNote || SupplierContactPerson
        private DataTable tblPur_Supplier = new DataTable();

        private string Convert_SupplierID_to_SupplierName(int SupplierID)
        {
            string SupplierName = "";
            if (tblPur_Supplier != null && tblPur_Supplier.Rows.Count > 0)
            {
                DataRow[] foundRows = tblPur_Supplier.Select($"SupplierID = {SupplierID}");
                if (foundRows.Length > 0)
                {
                    SupplierName = foundRows[0]["SupplierName"].ToString();
                }
            }
            return SupplierName;
        }

        private int Convert_SupplierName_to_SupplierID(string SupplierName)
        {
            int SupplierID = 0;
            if (tblPur_Supplier != null && tblPur_Supplier.Rows.Count > 0)
            {
                DataRow[] foundRows = tblPur_Supplier.Select($"SupplierName = '{SupplierName}'");
                if (foundRows.Length > 0)
                {
                    SupplierID = Convert.ToInt32(foundRows[0]["SupplierID"]);
                }
            }
            return SupplierID;
        }

        // TaxID || TaxName || TaxValue
        private DataTable tblPur_Tax = new DataTable();

        private string Convert_TaxID_to_TaxName(int TaxID)
        {
            string TaxName = "";
            if (tblPur_Tax != null && tblPur_Tax.Rows.Count > 0)
            {
                DataRow[] foundRows = tblPur_Tax.Select($"TaxID = {TaxID}");
                if (foundRows.Length > 0)
                {
                    TaxName = foundRows[0]["TaxName"].ToString();
                }
            }
            return TaxName;
        }

        private int Convert_TaxName_to_TaxID(string TaxName)
        {
            int TaxID = 0;
            if (tblPur_Tax != null && tblPur_Tax.Rows.Count > 0)
            {
                DataRow[] foundRows = tblPur_Tax.Select($"TaxName = '{TaxName}'");
                if (foundRows.Length > 0)
                {
                    TaxID = Convert.ToInt32(foundRows[0]["TaxID"]);
                }
            }
            return TaxID;
        }

        // CurrencyID || CurrencyName || CurrencyRate
        private DataTable tblPur_Currency = new DataTable();

        // PartCode || PartName || PartPurchasePrice || PartSalePrice || TaxCode || SupplierIDPrefer || TaxIDPrefer || Eable_Purchase || Eable_Inventory || Eable_Sale

        private DataTable tblData_by_KeySearch = new DataTable();

        // - 03. class
        private Purchase_V2_BLL _purchase_V2_BLL = new Purchase_V2_BLL();

        private PurchaseBLL _purchaseBLL = new PurchaseBLL();
        private CommonBLL _commonBLL = new CommonBLL();

        // - 04. priate - non-static
        private DataTable tbl_Items_Now = new DataTable();  // Danh sách Item hiện tại trong datagdriview dgvListItems

        private void Create_table_List_Items_Now()
        {
            tbl_Items_Now.Columns.Add("Code", typeof(string));
            tbl_Items_Now.Columns.Add("Name", typeof(string));
            tbl_Items_Now.Columns.Add("OldImport", typeof(decimal)); // Giá nhập cũ
            tbl_Items_Now.Columns.Add("NewImport", typeof(decimal)); // Giá nhập mới
            tbl_Items_Now.Columns.Add("OldExport", typeof(decimal)); // Giá xuất cũ
            tbl_Items_Now.Columns.Add("NewExport", typeof(decimal)); // Giá xuất mới
            tbl_Items_Now.Columns.Add("SupplierPrefer", typeof(string));  // Nhà cung cấp ưu tiên
            tbl_Items_Now.Columns.Add("TaxCode", typeof(string)); // Mã thuế
            tbl_Items_Now.Columns.Add("TaxTypePrefer", typeof(string)); // Loại thuế
            tbl_Items_Now.Columns.Add("Pur_OK", typeof(bool)); // Cho phép Purchase
            tbl_Items_Now.Columns.Add("Inventory_OK", typeof(bool)); // Cho phép Inventory
            tbl_Items_Now.Columns.Add("Sale_OK", typeof(bool)); // Cho phép Sale
        }

        public frmManagePrice_Update()
        {
            InitializeComponent();

            Create_table_List_Items_Now();
            Load_Purchase_Common(); // Load các bảng chung của Purchase
        }

        private void Load_Purchase_Common()
        {
            tblPur_Supplier = _purchase_V2_BLL.Select_tblPur_Supplier_BLL();
            tblPur_Tax = _purchase_V2_BLL.Select_tblPur_Tax_BLL();
            tblPur_Currency = _purchase_V2_BLL.Select_tblPur_Currency_BLL();
            dgvListItems.DataSource = tbl_Items_Now; // Gán DataTable vào DataGridView
            dgvListItems_Fix_Attribute(); // Thiết lập thuộc tính cho DataGridView
        }

        private void dgvListItems_Fix_Attribute()
        {
            dgvListItems.AllowUserToAddRows = false;
            dgvListItems.AllowUserToDeleteRows = false;
            dgvListItems.Columns["Code"].ReadOnly = true;
            dgvListItems.Columns["SupplierPrefer"].ReadOnly = true;
            dgvListItems.Columns["TaxTypePrefer"].ReadOnly = true;
        }

        private void dgvListSearch_Fix_Attribute()
        {
            dgvListSearch.AllowUserToAddRows = false;
            dgvListSearch.AllowUserToDeleteRows = false;
            dgvListSearch.Columns["TaxCode"].Visible = false;
            dgvListSearch.Columns["SupplierIDPrefer"].Visible = false;
            dgvListSearch.Columns["TaxIDPrefer"].Visible = false;
            dgvListSearch.Columns["Eable_Purchase"].Visible = false;
            dgvListSearch.Columns["Eable_Inventory"].Visible = false;
            dgvListSearch.Columns["Eable_Sale"].Visible = false;
        }

        private void frmManagePrice_Update_Load(object sender, EventArgs e)
        {
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
            string keysearch = txtSearch.Text.Trim();
            if (keysearch != "")
            {
                // Clear dữ liệu cũ
                tblData_by_KeySearch.Clear();
                tblData_by_KeySearch = _purchase_V2_BLL.Select_Data_by_KeySearch_BLL(keysearch);

                if (tblData_by_KeySearch.Rows.Count > 0)
                {
                    dgvListSearch.DataSource = tblData_by_KeySearch;
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

        private bool Check_PartCode_in_tbl_tbl_Items_Now(string partCode)
        {
            if (tbl_Items_Now != null && tbl_Items_Now.Rows.Count > 0)
            {
                foreach (DataRow row in tbl_Items_Now.Rows)
                {
                    if (row["Code"] != DBNull.Value)
                    {
                        if (row["Code"].ToString() == partCode)
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
            if (dgvListSearch.Rows.Count == 0)
            {
                MessageBox.Show("Please search for items first!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSearch.Focus();
                return;
            }
            foreach (DataGridViewRow row in dgvListSearch.SelectedRows)
            {
                if (row.Cells["PartCode"].Value == null)
                    continue;

                string partCode = row.Cells["PartCode"].Value.ToString();

                if (Check_PartCode_in_tbl_tbl_Items_Now(partCode))
                {
                    MessageBox.Show($"[{partCode}]  is existing ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    continue; // hoặc return nếu bạn muốn dừng luôn
                }
                else
                {
                    DataRow nrow = tbl_Items_Now.NewRow();
                    nrow["Code"] = partCode; // Mã hàng
                    nrow["Name"] = row.Cells["PartName"].Value.ToString();
                    if (row.Cells["PartPurchasePrice"].Value == null || row.Cells["PartPurchasePrice"].Value == DBNull.Value)
                    {
                        nrow["OldImport"] = 0; // Giá nhập cũ (mặc định là 0 nếu không có giá nhập cũ)
                    }
                    else
                    {
                        nrow["OldImport"] = Convert.ToDecimal(row.Cells["PartPurchasePrice"].Value); // Giá nhập cũ
                    }

                    nrow["NewImport"] = 0; // Giá nhập mới (mặc định là 0)
                    if (row.Cells["PartSalePrice"].Value == null || row.Cells["PartSalePrice"].Value == DBNull.Value)
                    {
                        nrow["OldExport"] = 0; // Giá xuất cũ (mặc định là 0 nếu không có giá xuất cũ)
                    }
                    else
                    {
                        nrow["OldExport"] = Convert.ToDecimal(row.Cells["PartSalePrice"].Value); // Giá xuất cũ
                    }
                    nrow["NewExport"] = 0; // Giá xuất mới (mặc định là 0)
                    nrow["TaxCode"] = row.Cells["TaxCode"].Value.ToString(); // Mã thuế

                    nrow["Pur_OK"] = Convert.ToBoolean(row.Cells["Eable_Purchase"].Value); // Cho phép Purchase
                    nrow["Inventory_OK"] = Convert.ToBoolean(row.Cells["Eable_Inventory"].Value); // Cho phép Inventory
                    nrow["Sale_OK"] = Convert.ToBoolean(row.Cells["Eable_Sale"].Value); // Cho phép Sale

                    // Lấy nhà cung cấp ưu tiên
                    if (row.Cells["SupplierIDPrefer"].Value != null && row.Cells["SupplierIDPrefer"].Value != DBNull.Value)
                    {
                        int supplierID = Convert.ToInt32(row.Cells["SupplierIDPrefer"].Value);
                        DataRow[] supplierRows = tblPur_Supplier.Select($"SupplierID = {supplierID}");
                        if (supplierRows.Length > 0)
                        {
                            nrow["SupplierPrefer"] = supplierRows[0]["SupplierName"].ToString(); // Lấy tên nhà cung cấp
                        }
                        else
                        {
                            nrow["SupplierPrefer"] = ""; // Nếu không tìm thấy nhà cung cấp
                        }
                    }
                    else
                    {
                        nrow["SupplierPrefer"] = ""; // Nếu không có nhà cung cấp ưu tiên
                    }
                    // Lấy loại thuế ưu tiên
                    if (row.Cells["TaxIDPrefer"].Value != null && row.Cells["TaxIDPrefer"].Value != DBNull.Value)
                    {
                        int taxID = Convert.ToInt32(row.Cells["TaxIDPrefer"].Value);
                        DataRow[] taxRows = tblPur_Tax.Select($"TaxID = {taxID}");
                        if (taxRows.Length > 0)
                        {
                            nrow["TaxTypePrefer"] = taxRows[0]["TaxName"].ToString(); // Lấy tên loại thuế
                        }
                        else
                        {
                            nrow["TaxTypePrefer"] = ""; // Nếu không tìm thấy loại thuế
                        }
                    }
                    else
                    {
                        nrow["TaxTypePrefer"] = ""; // Nếu không có loại thuế ưu tiên
                    }

                    tbl_Items_Now.Rows.Add(nrow);
                }
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
                tbl_Items_Now.Clear(); // Xóa hết danh sách Item hiện tại
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
                tbl_Items_Now.Clear();
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            using (frmImportListItems formA = new frmImportListItems())
            {
                formA.tbl_Items_Now = tbl_Items_Now;

                var result = formA.ShowDialog();  // Dùng ShowDialog để chờ form A đóng
                if (result == DialogResult.OK || result == DialogResult.Cancel) // hoặc chỉ cần kiểm tra nếu != null
                {
                    DataTable ListItemImportOK = formA.tbl_Items_OK;
                    if (ListItemImportOK == null)
                    {
                        MessageBox.Show("No data imported!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    //Lấy danh sách từ datatabeLisstItemImportOK điền thêm  vào dgvListItems
                    if (ListItemImportOK.Rows.Count > 0 && ListItemImportOK != null)
                    {
                        foreach (DataRow row in ListItemImportOK.Rows)
                        {
                            if (row["PartCode"] != DBNull.Value)
                            {
                                string partCode = row["PartCode"].ToString();
                                if (!Check_PartCode_in_tbl_tbl_Items_Now(partCode))
                                {
                                    DataRow nrow = tbl_Items_Now.NewRow();
                                    nrow["Code"] = partCode; // Mã hàng
                                    nrow["Name"] = row["PartName"].ToString(); // Tên hàng
                                    nrow["OldImport"] = row["PartPurchasePrice"] != DBNull.Value ? Convert.ToDecimal(row["PartPurchasePrice"]) : 0; // Giá nhập cũ
                                    nrow["NewImport"] = 0; // Giá nhập mới (mặc định là 0)
                                    nrow["OldExport"] = row["PartSalePrice"] != DBNull.Value ? Convert.ToDecimal(row["PartSalePrice"]) : 0; // Giá xuất cũ
                                    nrow["NewExport"] = 0; // Giá xuất mới (mặc định là 0)
                                    nrow["TaxCode"] = row["TaxCode"].ToString(); // Mã thuế
                                    nrow["Pur_OK"] = Convert.ToBoolean(row["Eable_Purchase"]); // Cho phép Purchase
                                    nrow["Inventory_OK"] = Convert.ToBoolean(row["Eable_Inventory"]); // Cho phép Inventory
                                    nrow["Sale_OK"] = Convert.ToBoolean(row["Eable_Sale"]); // Cho phép Sale
                                    // Lấy nhà cung cấp ưu tiên
                                    if (row["SupplierIDPrefer"] != DBNull.Value)
                                    {
                                        int supplierID = Convert.ToInt32(row["SupplierIDPrefer"]);
                                        DataRow[] supplierRows = tblPur_Supplier.Select($"SupplierID = {supplierID}");
                                        if (supplierRows.Length > 0)
                                        {
                                            nrow["SupplierPrefer"] = supplierRows[0]["SupplierName"].ToString(); // Lấy tên nhà cung cấp
                                        }
                                        else
                                        {
                                            nrow["SupplierPrefer"] = ""; // Nếu không tìm thấy nhà cung cấp
                                        }
                                    }
                                    else
                                    {
                                        nrow["SupplierPrefer"] = ""; // Nếu không có nhà cung cấp ưu tiên
                                    }
                                    // Lấy loại thuế ưu tiên
                                    if (row["TaxIDPrefer"] != DBNull.Value)
                                    {
                                        int taxID = Convert.ToInt32(row["TaxIDPrefer"]);
                                        DataRow[] taxRows = tblPur_Tax.Select($"TaxID = {taxID}");
                                        if (taxRows.Length > 0)
                                        {
                                            nrow["TaxTypePrefer"] = taxRows[0]["TaxName"].ToString(); // Lấy tên loại thuế
                                        }
                                        else
                                        {
                                            nrow["TaxTypePrefer"] = ""; // Nếu không tìm thấy loại thuế
                                        }
                                    }
                                    else
                                    {
                                        nrow["TaxTypePrefer"] = ""; // Nếu không có loại thuế ưu tiên
                                    }
                                    tbl_Items_Now.Rows.Add(nrow); // Thêm dòng mới vào DataTable
                                }
                            }
                        }
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

            // Tìm kiếm trên ô textbox : Ctrl + F
            if (e.Control && e.KeyCode == Keys.F)
            {
                // Ngăn tiếng bíp
                e.SuppressKeyPress = true;
                txtSearch.Focus();
            }
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            // Điền lại những dữ liệu còn thiếu trong dgvListItems
            if (Fill_Old_Information())
            {
                MessageBox.Show("Old information filled successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Failed to fill old information!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool Fill_Old_Information()
        {
            bool isOK = true;
            try
            {
                DataTable tbl_Pur_Part = _purchase_V2_BLL.Select_tblPur_Part_BLL(_commonBLL.Copy_Single_Column_to_NewTable(tbl_Items_Now, "Code"));
                // PartCode, PartName, PartPurchasePrice, PartSalePrice, Eable_Purchase, Eable_Inventory, Eable_Sale, TaxCode, SupplierIDPrefer, TaxIDPrefer
                foreach (DataRow row in tbl_Items_Now.Rows)
                {
                    // Fill OldImportPrice , OldExportPrice
                    if (row["Code"] != DBNull.Value)
                    {
                        string partCode = row["Code"].ToString();

                        DataRow[] foundRows = tbl_Pur_Part.Select($"PartCode = '{partCode}'");
                        string partname = foundRows[0]["PartName"].ToString();
                        if (foundRows.Length > 0 && partname != "")
                        {
                            row["Name"] = foundRows[0]["PartName"].ToString();
                            row["OldImport"] = foundRows[0]["PartPurchasePrice"] != DBNull.Value ? Convert.ToDecimal(foundRows[0]["PartPurchasePrice"]) : 0;
                            row["OldExport"] = foundRows[0]["PartSalePrice"] != DBNull.Value ? Convert.ToDecimal(foundRows[0]["PartSalePrice"]) : 0;
                            if (row["SupplierPrefer"] == DBNull.Value || row["SupplierPrefer"].ToString() == "")
                            {
                                string oldSupplierID = foundRows[0]["SupplierIDPrefer"].ToString();
                                if (oldSupplierID == "")
                                {
                                    oldSupplierID = "0"; // Nếu SupplierIDPrefer là rỗng thì gán về 0
                                }
                                else
                                {
                                    row["SupplierPrefer"] = Convert_SupplierID_to_SupplierName(Convert.ToInt32(foundRows[0]["SupplierIDPrefer"]));
                                }
                            }
                            if (row["TaxTypePrefer"] == DBNull.Value || row["TaxTypePrefer"].ToString() == "")
                            {
                                string oldtaxID = foundRows[0]["TaxIDPrefer"].ToString();
                                if (oldtaxID == "")
                                {
                                    oldtaxID = "0"; // Nếu TaxIDPrefer là rỗng thì gán về 0
                                }
                                else
                                {
                                    row["TaxTypePrefer"] = Convert_TaxID_to_TaxName(Convert.ToInt32(foundRows[0]["TaxIDPrefer"]));
                                }
                            }
                            if (row["TaxCode"] == DBNull.Value || row["TaxCode"].ToString() == "")
                            {
                                row["TaxCode"] = foundRows[0]["TaxCode"].ToString();
                            }
                        }
                        else
                        {
                            row["Code"] = "Unknown_" + partCode;
                            isOK = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                isOK = false;
            }
            return isOK;
        }

        private DataTable Convert_tbl_Items_Now_to_tbl_UpdatedPart()
        {
            DataTable updatetable = new DataTable();
            DataTable tbl_Part_ID_PartCode = _purchase_V2_BLL.Select_PartID_PartCode_BLL(_commonBLL.Copy_Single_Column_to_NewTable(tbl_Items_Now, "Code"));
            // Copy from tbl_Items_Now
            updatetable = tbl_Items_Now.Copy();
            updatetable.Columns.Add("PartPriceLog", typeof(string));
            updatetable.Columns.Add("PreferSupplierID", typeof(int));
            updatetable.Columns.Add("PreferTaxID", typeof(int));
            updatetable.Columns.Add("PartID", typeof(int)); 

            foreach (DataRow row in updatetable.Rows)
            {
                // Lấy PreferSupplierID và PreferTaxID
                row["PreferSupplierID"] = Convert_SupplierName_to_SupplierID(row["SupplierPrefer"].ToString());
                row["PreferTaxID"] = Convert_TaxName_to_TaxID(row["TaxTypePrefer"].ToString());
                // Lấy giá trị của các cột và tạo chuỗi PriceLog
            
                string PriceLog = DateTime.Now.Date.ToString("MM/dd/yyyy") + "|";
                PriceLog += "User :" + username + "|";
                PriceLog += "I : " + row["OldImport"].ToString() + "|";
                PriceLog += "=> " + row["NewImport"].ToString() + "|";
                PriceLog += "O : " + row["OldExport"].ToString() + "|";
                PriceLog += "=> " + row["NewExport"].ToString() + "|";
                PriceLog += "S: " + Convert_SupplierName_to_SupplierID(row["SupplierPrefer"].ToString()) + "|";
                PriceLog += "T: " + Convert_TaxName_to_TaxID(row["TaxTypePrefer"].ToString()) + "|";
                PriceLog += "C: " + row["TaxCode"].ToString() + "|";
                PriceLog += (Convert.ToBoolean(row["Pur_OK"]) ? "1" : "0") + "|";
                PriceLog += (Convert.ToBoolean(row["Inventory_OK"]) ? "1" : "0") + "|";
                PriceLog += (Convert.ToBoolean(row["Sale_OK"]) ? "1" : "0") + "|";
                row["PartPriceLog"] = PriceLog;

                // Find PartID from tbl_Part_ID_PartCode
                DataRow[] foundRows = tbl_Part_ID_PartCode.Select($"PartCode = '{row["Code"]}'");
                if (foundRows.Length > 0)
                {
                    row["PartID"] = Convert.ToInt32(foundRows[0]["PartID"]); // Lấy PartID từ tbl_Part_ID_PartCode
                }
                else
                {
                    
                    row["PartID"] = 0; // Nếu không tìm thấy, gán giá trị DBNull
                }


            }

            // Delete các cootj PreferSupplier, PreferTaxType , OldImport, OldExport,name
            updatetable.Columns.Remove("SupplierPrefer");
            updatetable.Columns.Remove("TaxTypePrefer");
            updatetable.Columns.Remove("OldImport");
            updatetable.Columns.Remove("OldExport");
            updatetable.Columns.Remove("Name");
            updatetable.Columns.Remove("Code"); 

            DataTable sortedTable = new DataTable();
            sortedTable.Columns.Add("PartID", typeof(int));
            sortedTable.Columns.Add("NewImport", typeof(decimal));
            sortedTable.Columns.Add("NewExport", typeof(decimal));
            sortedTable.Columns.Add("PartPriceLog", typeof(string));
            sortedTable.Columns.Add("PreferTaxID", typeof(int));
            sortedTable.Columns.Add("TaxCode", typeof(string));
            sortedTable.Columns.Add("PreferSupplierID", typeof(int));
            sortedTable.Columns.Add("Pur_OK", typeof(bool));
            sortedTable.Columns.Add("Inventory_OK", typeof(bool));
            sortedTable.Columns.Add("Sale_OK", typeof(bool));

            foreach (DataRow row in updatetable.Rows)
            {
                DataRow newRow = sortedTable.NewRow();
                newRow["PartID"] = row["PartID"];
                newRow["NewImport"] = row["NewImport"];
                newRow["NewExport"] = row["NewExport"];
                newRow["PartPriceLog"] = row["PartPriceLog"];
                newRow["PreferTaxID"] = row["PreferTaxID"];
                newRow["TaxCode"] = row["TaxCode"];
                newRow["PreferSupplierID"] = row["PreferSupplierID"];
                newRow["Pur_OK"] = row["Pur_OK"];
                newRow["Inventory_OK"] = row["Inventory_OK"];
                newRow["Sale_OK"] = row["Sale_OK"];
                sortedTable.Rows.Add(newRow);
            }

            return sortedTable;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string tb = "Do you want to update the purchase data?";
            DialogResult kq = MessageBox.Show(tb, "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (kq == DialogResult.No)
            {
                return; // Nếu người dùng chọn No, thoát khỏi hàm
            }
          

            if (Fill_Old_Information() == false || tbl_Items_Now.Rows.Count == 0)
            {
                MessageBox.Show("Please check the data again!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataTable tbl_Pur_Updated_Part = Convert_tbl_Items_Now_to_tbl_UpdatedPart();

            if(_purchase_V2_BLL.Update_tblPur_Part_BLL(tbl_Pur_Updated_Part))
            {
                MessageBox.Show("Update purchase data successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbl_Items_Now.Clear(); // Xóa hết danh sách Item hiện tại sau khi cập nhật thành công
            }
            else
            {
                MessageBox.Show("Failed to update purchase data!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                string partcode = dgvListItems.CurrentRow.Cells["Code"].Value.ToString();
                frm.ShowDetailInfor(partcode);
                frm.ShowDialog();
            }
        }

        private void btnSearchPO_Click(object sender, EventArgs e)
        {
        }

        private void viewTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string colmode = dgvListItems.AutoSizeColumnsMode.ToString();
            frmDataGridView_Modify frm = new frmDataGridView_Modify(_commonBLL.Get_Attribute_from_DatagridView(dgvListItems), colmode);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                _commonBLL.Set_Attribute_to_DatagridView(dgvListItems, frm.table_Updated_Att, frm.Col_ModeID);
            }
        }

        private void dgvListItems_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var grid = sender as DataGridView;
            string stt = (e.RowIndex + 1).ToString();
            var centerFormat = new StringFormat()
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            Rectangle headerBounds = new Rectangle(
                e.RowBounds.Left,
                e.RowBounds.Top,
                grid.RowHeadersWidth,
                e.RowBounds.Height);

            e.Graphics.DrawString(stt, this.Font, SystemBrushes.ControlText, headerBounds, centerFormat);
        }

        private void PasteClipboardToGrid()
        {
            try
            {
                string clipboardText = Clipboard.GetText();
                if (string.IsNullOrWhiteSpace(clipboardText))
                {
                    MessageBox.Show("Clipboard trống hoặc không có dữ liệu.");
                    return;
                }

                DataTable tbl_ClipBoard = _commonBLL.Convert_ClipBoard_to_Datatable_V2(clipboardText);

                foreach (DataRow row_clipboard in tbl_ClipBoard.Rows)
                {
                    // Nếu tồn tại cột "Code" trong DataTable từ clipboard
                    string partCode = string.Empty;
                    string partName = string.Empty;
                    decimal newImport = 0;
                    decimal newExport = 0;
                    string supplierPrefer = string.Empty;
                    string taxCode = string.Empty;
                    string taxTypePrefer = string.Empty;
                    if (row_clipboard.Table.Columns.Contains("Code"))
                    {
                        partCode = row_clipboard["Code"].ToString();
                    }
                    // PartName
                    if (row_clipboard.Table.Columns.Contains("Name"))
                    {
                        partName = row_clipboard["Name"].ToString();
                    }
                    // NewImportPrice
                    if (row_clipboard.Table.Columns.Contains("NewImport"))
                    {
                        newImport = Convert.ToDecimal(row_clipboard["NewImport"]);
                    }
                    // NewExportPrice
                    if (row_clipboard.Table.Columns.Contains("NewExport"))
                    {
                        newExport = Convert.ToDecimal(row_clipboard["NewExport"]);
                    }
                    // SupplierPrefer
                    if (row_clipboard.Table.Columns.Contains("SupplierPrefer"))
                    {
                        supplierPrefer = row_clipboard["SupplierPrefer"].ToString();
                    }
                    // TaxCode
                    if (row_clipboard.Table.Columns.Contains("TaxCode"))
                    {
                        taxCode = row_clipboard["TaxCode"].ToString();
                    }
                    // TaxTypePrefer
                    if (row_clipboard.Table.Columns.Contains("TaxTypePrefer"))
                    {
                        taxTypePrefer = row_clipboard["TaxTypePrefer"].ToString();
                    }
                    // Pur_OK
                    bool pur_OK = true;
                    if (row_clipboard.Table.Columns.Contains("Pur_OK"))
                    {
                        pur_OK = Convert.ToBoolean(row_clipboard["Pur_OK"]);
                    }
                    // Inventory_OK
                    bool inventory_OK = true;
                    if (row_clipboard.Table.Columns.Contains("Inventory_OK"))
                    {
                        inventory_OK = Convert.ToBoolean(row_clipboard["Inventory_OK"]);
                    }
                    // Sale_OK
                    bool sale_OK = true;
                    if (row_clipboard.Table.Columns.Contains("Sale_OK"))
                    {
                        sale_OK = Convert.ToBoolean(row_clipboard["Sale_OK"]);
                    }

                    // Add to tbl_Items_Now
                    DataRow nrow = tbl_Items_Now.NewRow();
                    nrow["Code"] = partCode;
                    nrow["Name"] = partName; // Tên hàng
                    nrow["OldImport"] = 0; // Giá nhập cũ (mặc định là 0 nếu không có giá nhập cũ)
                    nrow["NewImport"] = newImport; // Giá nhập mới
                    nrow["OldExport"] = 0; // Giá xuất cũ (mặc định là 0 nếu không có giá xuất cũ)
                    nrow["NewExport"] = newExport; // Giá xuất mới
                    nrow["TaxCode"] = taxCode; // Mã thuế
                    nrow["SupplierPrefer"] = supplierPrefer; // Nhà cung cấp ưu tiên
                    nrow["TaxTypePrefer"] = taxTypePrefer; // Loại thuế ưu tiên
                    nrow["Pur_OK"] = pur_OK; // Cho phép Purchase
                    nrow["Inventory_OK"] = inventory_OK; // Cho phép Inventory
                    nrow["Sale_OK"] = sale_OK; // Cho phép Sale
                    tbl_Items_Now.Rows.Add(nrow);
                }

                dgvListItems.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi dán dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvListItems_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.V)
            {
                PasteClipboardToGrid(); // Không cần truyền tên cột nữa
            }
        }

        private void changePreferSupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frm_Choose_Supplier frm_choose_sup = new frm_Choose_Supplier())
            {
                if (frm_choose_sup.ShowDialog() == DialogResult.OK)
                {
                    dgvListItems.CurrentRow.Cells["SupplierPrefer"].Value = frm_choose_sup.SelectedSupplierName;
                }
            }
        }

        private void pToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frm_Choose_TaxType frm_choose_tax = new frm_Choose_TaxType())
            {
                if (frm_choose_tax.ShowDialog() == DialogResult.OK)
                {
                    dgvListItems.CurrentRow.Cells["TaxTypePrefer"].Value = frm_choose_tax.SelectedTaxName;
                }
            }
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PasteClipboardToGrid();
        }

        private void checkListItemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Fill_Old_Information())
            {
                MessageBox.Show("Old information filled successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Failed to fill old information!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}