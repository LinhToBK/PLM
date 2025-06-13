using Azure.Core;
using PLM_Lynx._02_BLL_Bussiness_Logic_Layer;
using PLM_Lynx._03_GUI_User_Interface._00_Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Media.Media3D;
using System.Xml.Linq;

namespace PLM_Lynx._03_GUI_User_Interface._3_7_Purchase_version_Hue
{
    public partial class frmMake_New_PO_V2 : Form
    {
        /// <summary>
        /// 01. Khởi tạo các biến
        /// </summary>

        private CommonBLL _commonBLL = new CommonBLL();
        private Purchase_V2_BLL _purchase_V2_BLL = new Purchase_V2_BLL();
        private decimal _Total_After_Tax = 0.00m;
        private decimal _Total_Before_Tax = 0.00m;
        private decimal _Total_Discount = 0.00m;
        private decimal _Total_Tax = 0.00m;
        private DataTable tbl_ContactPerson = new DataTable();
        private DataTable tblAttached_File = new DataTable();

        // PartCode, PartName, Quantity, UnitPrice, Unit, Discount, Total, TaxCode
        private DataTable tblPur_Content = new DataTable();

        // CurrencyID, CurrencyName, CurrencyRate
        private DataTable tblPur_Currency = new DataTable();

        private DataTable tblPur_Search_Items = new DataTable();

        // StatusID, StatusName
        private DataTable tblPur_Status = new DataTable();

        // SupplierID , SupplierCode, SupplierName, SupplierLocation, SupplierPhone, SupplierTaxNumber, SupplierNote, SupplierContactPerson
        private DataTable tblPur_Supplier = new DataTable();

        // TaxID, TaxName, TaxValue
        private DataTable tblPur_Tax = new DataTable();

        // UnitID, UnitName, UnitValue, UnitContent
        private DataTable tblPur_Unit = new DataTable();

        // WareHouseID, WareHouseName
        private DataTable tblPur_WareHouse = new DataTable();

        /// <summary>
        /// 01. Xử lý các sự kiện
        /// </summary>
        public frmMake_New_PO_V2()
        {
            InitializeComponent();
            Load_Common_Information();
            Create_tblPur_Content();
            Create_tblAttached_File();

            this.cbo_tblPur_Supplier.SelectedIndexChanged += new System.EventHandler(this.cbo_tblPur_Supplier_SelectedIndexChanged);
        }

        public string _UserName { get; set; }

        private void addFileToAttachmentListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnAddFile.PerformClick();
        }

        private bool Auto_Fill_Data()
        {
            bool isSuccess = false;

            DataTable tbl_Pur_Part_Information = new DataTable();

            tbl_Pur_Part_Information = _purchase_V2_BLL.Select_tblPur_Part_BLL(_commonBLL.Copy_Single_Column_to_NewTable(tblPur_Content, "PartCode"));
            // PartCode, PartName, PartPurchasePrice, PartSalePrice, Eable_Purchase, Eable_Inventory, Eable_Sale, TaxCode, SupplierIDPrefer, TaxIDPrefer
            int count = tblPur_Content.Rows.Count;
            if (count == 0)
            {
                MessageBox.Show("No data to auto-fill.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                isSuccess = false;
            }
            else
            {
                for (int i = 0; i < count; i++)
                {
                    string partCode = tblPur_Content.Rows[i]["PartCode"].ToString();
                    if (!string.IsNullOrEmpty(partCode))
                    {
                        tblPur_Content.Rows[i]["PartName"] = tbl_Pur_Part_Information.Rows[i]["PartName"] ?? string.Empty;

                        // Fill PartPurchasePrice  to UnitPrice
                        if (tbl_Pur_Part_Information.Rows[i]["PartPurchasePrice"] != DBNull.Value)
                        {
                            tblPur_Content.Rows[i]["UnitPrice"] = Convert.ToDecimal(tbl_Pur_Part_Information.Rows[i]["PartPurchasePrice"]);
                        }
                        else
                        {
                            tblPur_Content.Rows[i]["UnitPrice"] = 0.00m; // Default value if PartPurchasePrice is null
                        }
                        // Fill TaxCode to TaxCode
                        if (tbl_Pur_Part_Information.Rows[i]["TaxCode"] != DBNull.Value)
                        {
                            tblPur_Content.Rows[i]["TaxCode"] = tbl_Pur_Part_Information.Rows[i]["TaxCode"].ToString();
                        }
                        else
                        {
                            tblPur_Content.Rows[i]["TaxCode"] = string.Empty; // Default value if TaxCode is null
                        }
                    }

                    // Fill Quantity
                    if (tblPur_Content.Rows[i]["Quantity"] != DBNull.Value && tblPur_Content.Rows[i]["Quantity"] != DBNull.Value)
                    {
                    }
                    else
                    {
                        tblPur_Content.Rows[i]["Quantity"] = 1; // Default value if Quantity is null
                    }
                    // Fill Unit
                    if (tblPur_Content.Rows[i]["Unit"] == null || string.IsNullOrEmpty(tblPur_Content.Rows[i]["Unit"].ToString()))
                    {
                        tblPur_Content.Rows[i]["Unit"] = tblPur_Unit.Rows[0]["UnitName"].ToString(); // Default to first unit if Unit is null or empty
                    }

                    // Fill Discount
                    if (tblPur_Content.Rows[i]["Discount"] == null || string.IsNullOrEmpty(tblPur_Content.Rows[i]["Discount"].ToString()))
                    {
                        tblPur_Content.Rows[i]["Discount"] = 0.00m; // Default value if Discount is null or empty
                    }
                }
                Calculate_Total();
                isSuccess = true;
            }

            return isSuccess;
        }

        private void autoFillDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Auto_Fill_Data() == true)
            {
                MessageBox.Show("Auto fill data successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Auto fill data failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (Check_tblPur_Content() == false || Check_Input_Information() == false)
            {
                return;
            }

            string message = "Do you want to create a new Purchase Order?";
            DialogResult result = MessageBox.Show(message, "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                return; // If user clicks No, exit the method
            }

            DateTime PODateCreate = dtpPostingDate.Value;
            DateTime POEstimateDeliveryDate = dtpEstimateDelivery.Value;
            int SupplierID = Convert.ToInt32(cbo_tblPur_Supplier.SelectedValue);
            int StatusID = Convert.ToInt32(cbo_tblPur_Status.SelectedValue);
            int TaxID = Convert_TaxValue_to_TaxID(Convert.ToDecimal(cbo_tblPur_Tax.SelectedValue));
            string PORemark = txtRemark.Text.Trim();
            string POPaymentTerm = txtPaymentTerm.Text.Trim();
            string POSupplierContactPerson = cboSupplierContactPerson.SelectedItem?.ToString() ?? string.Empty;
            int WareHouseID = Convert.ToInt32(cbo_tblPur_WareHouse.SelectedValue);
            decimal TotalPayemnt = _Total_After_Tax;

            DataTable tbl_Part_ID_Part_Code = _purchase_V2_BLL.Select_PartID_PartCode_BLL(_commonBLL.Copy_Single_Column_to_NewTable(tblPur_Content, "PartCode"));
            // tbl_Part_ID_Part_Code : [ PartID, PartCode ]

            DataTable tblPur_PO_Detail = new DataTable();
            // Table : [PartID, Quantity_Order, UnitID, UnitPrice, Discount, Amount, TaxID ]
            tblPur_PO_Detail.Columns.Add("PartID", typeof(int));
            tblPur_PO_Detail.Columns.Add("Quantity_Order", typeof(int));
            tblPur_PO_Detail.Columns.Add("UnitID", typeof(int));
            tblPur_PO_Detail.Columns.Add("UnitPrice", typeof(decimal));
            tblPur_PO_Detail.Columns.Add("Discount", typeof(decimal));
            tblPur_PO_Detail.Columns.Add("Amount", typeof(decimal));

            // Copy columns from tbl_Part_ID_Part_Code and tblPur_Content to tblPur_PO_Detail
            for (int i = 0; i < tblPur_Content.Rows.Count; i++)
            {
                DataRow newRow = tblPur_PO_Detail.NewRow();
                newRow["PartID"] = Convert.ToInt32(tbl_Part_ID_Part_Code.Rows[i]["PartID"]);
                newRow["Quantity_Order"] = Convert.ToInt32(tblPur_Content.Rows[i]["Quantity"]);
                newRow["UnitID"] = Convert.ToInt32(tblPur_Unit.Select($"UnitName = '{tblPur_Content.Rows[i]["Unit"]}'")[0]["UnitID"]);
                newRow["UnitPrice"] = Convert.ToDecimal(tblPur_Content.Rows[i]["UnitPrice"]);
                newRow["Discount"] = Convert.ToDecimal(tblPur_Content.Rows[i]["Discount"]);
                newRow["Amount"] = Convert.ToDecimal(tblPur_Content.Rows[i]["Total"]);

                tblPur_PO_Detail.Rows.Add(newRow);
            }

            if (_purchase_V2_BLL.Insert_New_PO_BLL(PODateCreate, POEstimateDeliveryDate, SupplierID, POSupplierContactPerson,
                Convert.ToInt32(cbo_tblPur_Currency.SelectedValue), _UserName, StatusID, PORemark, POPaymentTerm, WareHouseID, TotalPayemnt, TaxID,
                tblPur_PO_Detail) == true)
            {
                if (tblAttached_File.Rows.Count == 0)
                {
                    MessageBox.Show("New Purchase Order created successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    if (_purchase_V2_BLL.Save_Attachment_File_BLL(_purchase_V2_BLL.Select_Newest_PONumber_BLL() - 1, DateTime.Now, tblAttached_File) == true)
                    {
                        MessageBox.Show("New Purchase Order created successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // Reopen the form to show the new Purchase Order
                        this.Close();
                    }
                    else
                    {
                        string message2 = "New Purchase Order created successfully, but failed to save attachment files. Do you want to continue?";
                        MessageBox.Show(message2, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Failed to create new Purchase Order.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddFile_Click(object sender, EventArgs e)
        {
            // Open a file dialog to select files to attach
            OpenFileDialog _file_dialog = new OpenFileDialog();
            _file_dialog.Title = "Select Files to Attach";
            _file_dialog.Multiselect = true; // Allow multiple file selection
            _file_dialog.RestoreDirectory = true;
            _file_dialog.Filter = "All Files (*.*)|*.*";

            // if OK => show the selected files in the dgv_Attach_File
            if (_file_dialog.ShowDialog() == DialogResult.OK)
            {
                foreach (string filePath in _file_dialog.FileNames)
                {
                    DataRow dt = tblAttached_File.NewRow();
                    dt["FileName"] = System.IO.Path.GetFileName(filePath);
                    dt["FilePath"] = filePath; // Full path to the file
                    dt["FileSize"] = new System.IO.FileInfo(filePath).Length;
                    dt["FileType"] = System.IO.Path.GetExtension(filePath).TrimStart('.');
                    dt["DateCreated"] = System.IO.File.GetCreationTime(filePath);
                    tblAttached_File.Rows.Add(dt);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            string message = "Do you want to cancel the operation?";
            DialogResult result = MessageBox.Show(message, "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close(); // Đóng form nếu người dùng chọn "Yes"
            }
        }

        private void btnDeleteFile_Click(object sender, EventArgs e)
        {
            // Delete the selected file from the DataGridView
            if (dgv_AttachmentFiles.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in dgv_AttachmentFiles.SelectedRows)
                {
                    if (!row.IsNewRow) // Ensure not to delete the new row placeholder
                    {
                        // Remove the file from the DataTable
                        tblAttached_File.Rows.RemoveAt(row.Index);
                    }
                }
                dgv_AttachmentFiles.Refresh(); // Refresh the DataGridView to show the updated list
            }
            else
            {
                MessageBox.Show("Please select a file to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnFind_Item_Supplier_Click(object sender, EventArgs e)
        {
            int supplierID = Convert.ToInt32(cbo_tblPur_Supplier.SelectedValue);
            tblPur_Search_Items = _purchase_V2_BLL.Select_tblPur_Part_with_SupplierID_BLL(supplierID);
            dgv_Search_Items.DataSource = tblPur_Search_Items;
        }

        private void Calculate_Total()
        {
            if (tblPur_Content.Rows.Count > 0)
            {
                foreach (DataRow row in tblPur_Content.Rows)
                {
                    if (row["UnitPrice"] != DBNull.Value && row["Quantity"] != DBNull.Value && row["Discount"] != DBNull.Value)
                    {
                        decimal unitPrice = Convert.ToDecimal(row["UnitPrice"]);
                        int quantity = Convert.ToInt32(row["Quantity"]);
                        decimal _discount = Convert.ToDecimal(row["Discount"]);
                        decimal total = (unitPrice * quantity) * (100 - _discount) / 100;
                        row["Total"] = total;
                    }
                    else
                    {
                        row["Total"] = 0.00m; // Default value if any of the required fields are null
                    }
                }
            }

            foreach (DataRow row in tblPur_Content.Rows)
            {
                if (row["Total"] != DBNull.Value)
                {
                    _Total_Before_Tax += Convert.ToDecimal(row["Total"]);
                }
            }
            // If txtDiscount is not empty, apply discount

            decimal taxRate = string.IsNullOrWhiteSpace(txtTax.Text) ? 0 : Convert.ToDecimal(txtTax.Text);
            _Total_Tax = _Total_Before_Tax * taxRate / 100;

            _Total_After_Tax = _Total_Before_Tax - _Total_Discount + _Total_Tax;

            // Update the textboxs
            txtTotalBeforeDiscount.Text = _Total_Before_Tax.ToString("N2");

            txtTotalTax.Text = _Total_Tax.ToString("N2");
            txtTotalPayment.Text = _Total_After_Tax.ToString("N2");
        }

        private void cbo_tblPur_Currency_SelectedIndexChanged(object sender, EventArgs e)
        {
            string currencyValue = Convert_CurrencyID_to_CurrencyName(cbo_tblPur_Currency.SelectedIndex + 1);
            lblCurrencyA.Text = currencyValue;
            lblCurrencyC.Text = currencyValue;
            lblCurrencyD.Text = currencyValue;
        }

        private void cbo_tblPur_Supplier_SelectedIndexChanged(object sender, EventArgs e)
        {
            Load_Supplier_Infor();
        }

        private void cbo_tblPur_Tax_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Lấy giá trị thuế từ ComboBox và cập nhật vào TextBox
            if (cbo_tblPur_Tax.SelectedValue != null)
            {
                string taxValue = cbo_tblPur_Tax.SelectedValue.ToString();
                if (decimal.TryParse(taxValue, out decimal taxDecimal))
                {
                    txtTax.Text = taxDecimal.ToString("0.00"); // Hiển thị giá trị thuế với 2 chữ số thập phân
                    Calculate_Total();
                }
                else
                {
                    txtTax.Text = "0.00"; // Nếu không phải là số hợp lệ, đặt về 0.00
                    Calculate_Total();
                }
            }
            else
            {
                txtTax.Text = "0.00"; // Nếu không có giá trị nào được chọn, đặt về 0.00
                Calculate_Total();
            }
        }

        private void changeUnitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frm_Choose_Unit frm = new frm_Choose_Unit())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    dgv_List_Content.CurrentRow.Cells["Unit"].Value = frm.SelectedUnitName;
                }
            }
        }

        private bool Check_Input_Information()
        {
            bool isOK = true;
            if (dtpEstimateDelivery.Value.Date < DateTime.Now.Date)
            {
                MessageBox.Show("Estimated delivery date cannot be in the past.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                isOK = false;
            }

            return isOK;
        }

        private bool Check_tblPur_Content()
        {
            List<string> _listPartCode = new List<string>();
            bool isOK = true;
            if (tblPur_Content.Rows.Count == 0)
            {
                MessageBox.Show("No data in the purchase order content.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                isOK = false;
            }
            else
            {
                foreach (DataRow row in tblPur_Content.Rows)
                {
                    string partCode = row["PartCode"].ToString().Trim();
                    if (_listPartCode.Contains(partCode))
                    {
                        MessageBox.Show($"Duplicate Part Code: {partCode}. Please remove duplicates.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        isOK = false;
                        break;
                    }
                    else
                    {
                        _listPartCode.Add(partCode);
                    }
                    if (string.IsNullOrEmpty(row["PartCode"].ToString()) || string.IsNullOrEmpty(row["PartName"].ToString()))
                    {
                        MessageBox.Show("Part Code and Part Name cannot be empty.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        isOK = false;
                        break;
                    }

                    if (row["Quantity"] == DBNull.Value || Convert.ToInt32(row["Quantity"]) <= 0)
                    {
                        MessageBox.Show("Quantity must be greater than 0.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        isOK = false;
                        break;
                    }
                    if (row["UnitPrice"] == DBNull.Value || Convert.ToDecimal(row["UnitPrice"]) <= 0)
                    {
                        MessageBox.Show("Unit Price must be greater than  0.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        isOK = false;
                        break;
                    }
                }
            }

            return isOK;
        }

        private void checkInputDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Auto_Fill_Data();
            Paint_PartCode_Cell();

            MessageBox.Show("Check input data successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void clearDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Clear all data in the DataGridView
            string message = "Do you want to clear all data?";
            DialogResult result = MessageBox.Show(message, "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                tblPur_Content.Clear(); // Clear the DataTable
                Load_dgv_List_Content(); // Reload the DataGridView
                Calculate_Total(); // Recalculate totals after clearing
            }
        }

        private string Convert_CurrencyID_to_CurrencyName(int currencyID)
        {
            DataRow[] rows = tblPur_Currency.Select($"CurrencyID = {currencyID}");
            if (rows.Length > 0)
            {
                return rows[0]["CurrencyName"].ToString();
            }
            return string.Empty; // Return empty string if no match found
        }

        private int Convert_TaxValue_to_TaxID(decimal taxValue)
        {
            int TaxID = 0;
            if (tblPur_Tax != null && tblPur_Tax.Rows.Count > 0)
            {
                DataRow[] foundRows = tblPur_Tax.Select($"TaxValue = '{taxValue}'");
                if (foundRows.Length > 0)
                {
                    TaxID = Convert.ToInt32(foundRows[0]["TaxID"]);
                }
            }
            return TaxID;
        }

        private string Convert_UnitID_to_UnitName(int unitID)
        {
            DataRow[] rows = tblPur_Unit.Select($"UnitID = {unitID}");
            if (rows.Length > 0)
            {
                return rows[0]["UnitName"].ToString();
            }
            return string.Empty; // Return empty string if no match found
        }

        private void Create_tblAttached_File()
        {
            // FileName, FilePath, FileSize, FileType, DateCreated
            tblAttached_File.Columns.Add("FileName", typeof(string));
            tblAttached_File.Columns.Add("FilePath", typeof(string));
            tblAttached_File.Columns.Add("FileSize", typeof(long)); // Size in bytes
            tblAttached_File.Columns.Add("FileType", typeof(string)); // e.g., "pdf", "docx"
            tblAttached_File.Columns.Add("DateCreated", typeof(DateTime)); // Date when the file was created
        }

        private void Create_tblPur_Content()
        {
            // PartCode, PartName, Quantity, UnitPrice, Unit, Discount,  Total ,  Currency, TaxCode
            tblPur_Content.Columns.Add("PartCode", typeof(string));
            tblPur_Content.Columns.Add("PartName", typeof(string));
            tblPur_Content.Columns.Add("Quantity", typeof(int));
            tblPur_Content.Columns.Add("UnitPrice", typeof(decimal));
            tblPur_Content.Columns.Add("Unit", typeof(string));
            tblPur_Content.Columns.Add("Discount", typeof(decimal));
            tblPur_Content.Columns.Add("Total", typeof(decimal));
            tblPur_Content.Columns.Add("TaxCode", typeof(string));
        }

        private void deleteDupliCatePartCodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string message = "Do you want to delete the duplicate PartCode?";
            DialogResult result = MessageBox.Show(message, "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                _commonBLL.Delete_Duplicate_Row_In_DataTable(tblPur_Content, "PartCode");
                MessageBox.Show("Duplicate PartCode deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void deleteFileInAttachmentListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnDeleteFile.PerformClick();
        }

        private void deleteRowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Delete the selected row from the DataGridView
            if (dgv_List_Content.SelectedRows.Count > 1)
            {
                foreach (DataGridViewRow row in dgv_List_Content.SelectedRows)
                {
                    if (!row.IsNewRow) // Ensure not to delete the new row placeholder
                    {
                        dgv_List_Content.Rows.Remove(row);
                    }
                }
                Calculate_Total(); // Recalculate totals after deletion
            }
            else
            {
                // Delete the currently selected row
                if (dgv_List_Content.CurrentRow != null && !dgv_List_Content.CurrentRow.IsNewRow)
                {
                    dgv_List_Content.Rows.Remove(dgv_List_Content.CurrentRow);
                    Calculate_Total(); // Recalculate totals after deletion
                }
                else
                {
                    MessageBox.Show("Please select a row to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void dgv_List_Content_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_List_Content.Columns[e.ColumnIndex].Name == "Quantity" || dgv_List_Content.Columns[e.ColumnIndex].Name == "UnitPrice" || dgv_List_Content.Columns[e.ColumnIndex].Name == "Discount")
            {
                Calculate_Total();
            }
        }

        private void dgv_List_Content_KeyDown(object sender, KeyEventArgs e)
        {
            // Kiểm tra nếu phím Ctrl + V được nhấn
            if (e.Control && e.KeyCode == Keys.V)
            {
                PasteClipboardToGrid();
            }
        }

        private void dgv_List_Content_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
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

        private void dgv_List_Content_ViewFit()
        {
            //dgv_List_Content.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_List_Content.Columns["PartCode"].Width = 80;
            dgv_List_Content.Columns[1].Width = 120; // PartName
            dgv_List_Content.Columns[2].Width = 50; // Quantity
            dgv_List_Content.Columns[3].Width = 100; // UnitPrice
            dgv_List_Content.Columns[4].Width = 50; // Unit
            dgv_List_Content.Columns[5].Width = 50; // Discount
            dgv_List_Content.Columns[6].Width = 100; // Total
            dgv_List_Content.Columns[7].Width = 50; // TaxCode

            // Không cho phép chỉnh sửa các cột này
            //dgv_List_Content.Columns["PartCode"].ReadOnly = true;
            dgv_List_Content.Columns["PartName"].ReadOnly = true;
            dgv_List_Content.Columns["Unit"].ReadOnly = true;
            dgv_List_Content.Columns["TaxCode"].ReadOnly = true;
            dgv_List_Content.Columns["Total"].ReadOnly = true;

            dgv_List_Content.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Đặt Styel cho các cốt
            dgv_List_Content.Columns["UnitPrice"].DefaultCellStyle.Format = "N2";
            dgv_List_Content.Columns["Discount"].DefaultCellStyle.Format = "N2";
            dgv_List_Content.Columns["Total"].DefaultCellStyle.Format = "N2";
        }

        private void dgv_Search_Item_Show_OnlyPartCode()
        {
            List<string> listPartCode = new List<string>();
            List<DataRow> rowsToDelete = new List<DataRow>();

            foreach (DataRow row in tblPur_Search_Items.Rows)
            {
                string partCode = row["PartCode"].ToString();
                if (!listPartCode.Contains(partCode))
                {
                    listPartCode.Add(partCode);
                }
                else
                {
                    rowsToDelete.Add(row); // Đánh dấu dòng trùng
                }
            }

            // Xóa các dòng trùng sau khi duyệt xong
            foreach (DataRow row in rowsToDelete)
            {
                tblPur_Search_Items.Rows.Remove(row);
            }

            tblPur_Search_Items.AcceptChanges(); // Cập nhật thay đổi
        }

        private void editTableVieingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string Col_Mode = dgv_Search_Items.AutoSizeColumnsMode.ToString();

            frmDataGridView_Modify frm = new frmDataGridView_Modify(_commonBLL.Get_Attribute_from_DatagridView(dgv_Search_Items), Col_Mode);

            if (frm.ShowDialog() == DialogResult.OK)
            {
                _commonBLL.Set_Attribute_to_DatagridView(dgv_Search_Items, frm.table_Updated_Att, frm.Col_ModeID);
            }
        }

        private void frmMake_New_PO_V2_Load(object sender, EventArgs e)
        {
            Load_dgv_List_Content();
            // 06. Show UserName
            txtStaffName.Text = _UserName;
            dgv_AttachmentFiles.DataSource = tblAttached_File;
            dgv_AttachmentFiles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            cbo_tblPur_Status.DropDownStyle = ComboBoxStyle.DropDownList;
            cbo_tblPur_Status.Enabled = false;
        }

        private void insertNewRowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Insert a new row at the current position in the DataGridView
            int currentRowIndex = dgv_List_Content.CurrentCell == null ? 0 : dgv_List_Content.CurrentCell.RowIndex;
            if (currentRowIndex < 0 || currentRowIndex >= tblPur_Content.Rows.Count)
            {
                currentRowIndex = tblPur_Content.Rows.Count; // If no valid row is selected, add at the end
            }
            DataRow newRow = tblPur_Content.NewRow();
            tblPur_Content.Rows.InsertAt(newRow, currentRowIndex);
            dgv_List_Content.CurrentCell = dgv_List_Content.Rows[currentRowIndex].Cells[0]; // Set focus to the first cell of the new row
            dgv_List_Content.Refresh(); // Refresh the DataGridView to show the new row
        }

        private void Load_Common_Information()
        {
            tblPur_Supplier = _purchase_V2_BLL.Select_tblPur_Supplier_BLL();
            tblPur_Unit = _purchase_V2_BLL.Select_tblPur_Unit_BLL();
            tblPur_Currency = _purchase_V2_BLL.Select_tblPur_Currency_BLL();
            tblPur_WareHouse = _purchase_V2_BLL.Select_tblPur_WareHouse_BLL();
            tblPur_Status = _purchase_V2_BLL.Select_tblPur_Status_BLL();
            tblPur_Tax = _purchase_V2_BLL.Select_tblPur_Tax_BLL();

            // 01. Bind the Supplier DataTable to the ComboBox
            if (tblPur_Supplier != null && tblPur_Supplier.Rows.Count > 0)
            {
                cbo_tblPur_Supplier.DataSource = tblPur_Supplier;
                cbo_tblPur_Supplier.DisplayMember = "SupplierName";
                cbo_tblPur_Supplier.ValueMember = "SupplierID";
                cbo_tblPur_Supplier.SelectedIndex = 0;
                Load_Supplier_Infor();
            }
            else
            {
                cbo_tblPur_Supplier.DataSource = null;
            }

            // 02. Bind the Status DataTable to the ComboBox
            if (tblPur_Status != null && tblPur_Status.Rows.Count > 0)
            {
                cbo_tblPur_Status.DataSource = tblPur_Status;
                cbo_tblPur_Status.DisplayMember = "StatusName";
                cbo_tblPur_Status.ValueMember = "StatusID";
            }
            else
            {
                cbo_tblPur_Status.DataSource = null;
            }

            // 03. Bind the Tax DataTable to the ComboBox
            if (tblPur_Tax != null && tblPur_Tax.Rows.Count > 0)
            {
                cbo_tblPur_Tax.DataSource = tblPur_Tax;
                cbo_tblPur_Tax.DisplayMember = "TaxName";
                cbo_tblPur_Tax.ValueMember = "TaxValue";
            }
            else
            {
                cbo_tblPur_Tax.DataSource = null;
            }
            // 04. Bind the WareHouse DataTable to the ComboBox
            if (tblPur_WareHouse != null && tblPur_WareHouse.Rows.Count > 0)
            {
                cbo_tblPur_WareHouse.DataSource = tblPur_WareHouse;
                cbo_tblPur_WareHouse.DisplayMember = "WareHouseName";
                cbo_tblPur_WareHouse.ValueMember = "WareHouseID";
            }
            else
            {
                cbo_tblPur_WareHouse.DataSource = null;
            }

            // 05. Bind the Currency DataTable to the ComboBox
            if (tblPur_Currency != null && tblPur_Currency.Rows.Count > 0)
            {
                cbo_tblPur_Currency.DataSource = tblPur_Currency;
                cbo_tblPur_Currency.DisplayMember = "CurrencyName";
                cbo_tblPur_Currency.ValueMember = "CurrencyID";
            }
            else
            {
                cbo_tblPur_Currency.DataSource = null;
            }

            // 07. Load PONumber
            txtPONumber.Text = _purchase_V2_BLL.Select_Newest_PONumber_BLL().ToString();
        }

        private void Load_dgv_List_Content()
        {
            dgv_List_Content.DataSource = tblPur_Content;
            dgv_List_Content_ViewFit();
        }

        private void Load_Supplier_Infor()
        {
            // Show the selected supplier information in the textboxes
            var supid = cbo_tblPur_Supplier.SelectedValue;

            if (int.TryParse(supid.ToString(), out int selectedSupplierID) == true)
            {
                // MessageBox.Show(" Là ID " + supid);
            }
            else
            {
                // MessageBox.Show(" Không phải là ID");
                MessageBox.Show("Value selected is not a valid Supplier ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DataRow[] selectedRows = tblPur_Supplier.Select($"SupplierID = {selectedSupplierID}");
            if (selectedRows.Length > 0)
            {
                DataRow row = selectedRows[0];

                txtSupplierLocation.Text = row["SupplierLocation"].ToString();

                txtSupplierNote.Text = row["SupplierNote"].ToString();
                cboSupplierContactPerson.Items.Clear();
                string listperson = row["SupplierContactPerson"].ToString();
                List<string> contactPersons = _purchase_V2_BLL.convert_list_contact_person(listperson);

                cboSupplierContactPerson.Items.AddRange(contactPersons.ToArray());
                if (cboSupplierContactPerson.Items.Count > 0)
                {
                    cboSupplierContactPerson.SelectedIndex = 0; // Select the first contact person by default
                }
            }
        }

        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgv_AttachmentFiles.SelectedRows.Count > 0)
            {
                // Get the file path from the selected row
                string filePath = dgv_AttachmentFiles.SelectedRows[0].Cells["FilePath"].Value.ToString();

                // Check if the file exists
                if (System.IO.File.Exists(filePath))
                {
                    // Open the file using the default application
                    System.Diagnostics.Process.Start(filePath);
                }
                else
                {
                    MessageBox.Show("The selected file does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select a file to open.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void openPartFeatureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgv_Search_Items.Rows.Count > 0)
            {
                frmRelationPart_Detail_Info frm = new frmRelationPart_Detail_Info();
                string partcode = dgv_Search_Items.CurrentRow.Cells["PartCode"].Value.ToString();
                frm.ShowDetailInfor(partcode);
                frm.ShowDialog();
            }
        }

        private void openPartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgv_List_Content.Rows.Count > 0)
            {
                frmRelationPart_Detail_Info frm = new frmRelationPart_Detail_Info();
                string partcode = dgv_List_Content.CurrentRow.Cells["PartCode"].Value.ToString();
                frm.ShowDetailInfor(partcode);
                frm.ShowDialog();
            }
        }

        private void Paint_PartCode_Cell()
        {
            if (dgv_List_Content.Rows.Count > 0)
            {
                // Duplicate PartCode cells will be painted yellow
                for (int i = 0; i < dgv_List_Content.Rows.Count - 1; i++)
                {
                    for (int j = i + 1; j < dgv_List_Content.Rows.Count; j++)
                    {
                        if (dgv_List_Content.Rows[i].Cells["PartCode"].Value != null &&
                            dgv_List_Content.Rows[j].Cells["PartCode"].Value != null &&
                            dgv_List_Content.Rows[i].Cells["PartCode"].Value.ToString() ==
                            dgv_List_Content.Rows[j].Cells["PartCode"].Value.ToString())
                        {
                            dgv_List_Content.Rows[j].Cells["PartCode"].Style.BackColor = Color.Yellow;
                        }
                    }
                }

                // PartName is string.Empwill be painted red
                for (int i = 0; i < dgv_List_Content.Rows.Count; i++)
                {
                    var partNameCell = dgv_List_Content.Rows[i].Cells["PartName"];
                    var partCodeCell = dgv_List_Content.Rows[i].Cells["PartCode"];

                    string partName = partNameCell?.Value?.ToString();
                    string partCode = partCodeCell?.Value?.ToString();

                    if (string.IsNullOrEmpty(partName))
                    {
                        // Nếu partCode null thì gán tạm là "NULL"
                        string newPartCode = string.IsNullOrEmpty(partCode) ? "NULL" : partCode;
                        dgv_List_Content.Rows[i].Cells["PartCode"].Value = "Unknown_" + newPartCode;
                        dgv_List_Content.Rows[i].Cells["PartCode"].Style.BackColor = Color.Red;
                    }
                }
            }
            else
            {
                MessageBox.Show("Have not Data");
            }
        }

        private void PasteClipboardToGrid()
        {
            try
            {
                string clipboardText = Clipboard.GetText();
                if (string.IsNullOrWhiteSpace(clipboardText))
                {
                    MessageBox.Show("Clipboard is empty data.");
                    return;
                }

                DataTable tbl_ClipBoard = _commonBLL.Convert_ClipBoard_to_Datatable_V2(clipboardText);
                if (tbl_ClipBoard.Columns.Count > 1 && tbl_ClipBoard != null)
                {
                    _commonBLL.Insert_data_to_Datatable(tbl_ClipBoard, tblPur_Content);
                }
                else
                {
                    // Insert data to tblPur_Content
                    if (tbl_ClipBoard == null)
                    {
                        MessageBox.Show("Clipboard data is not valid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        int currentRowIndex = dgv_List_Content.CurrentCell == null ? 0 : dgv_List_Content.CurrentCell.RowIndex;

                        int currentColumnIndex = dgv_List_Content.CurrentCell == null ? 0 : dgv_List_Content.CurrentCell.ColumnIndex;

                        foreach (DataRow row in tbl_ClipBoard.Rows)
                        {
                            if (currentRowIndex < tblPur_Content.Rows.Count)
                            {
                                // Update existing row
                                tblPur_Content.Rows[currentRowIndex][currentColumnIndex] = row[0];
                            }
                            else
                            {
                                // Add new row if currentRowIndex exceeds existing rows
                                DataRow newRow = tblPur_Content.NewRow();
                                newRow[currentColumnIndex] = row[0];
                                tblPur_Content.Rows.Add(newRow);
                            }
                            currentRowIndex++;
                        }
                    }
                }

                dgv_List_Content.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi dán dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pasteDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PasteClipboardToGrid();
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dgv_Search_Item_Show_OnlyPartCode();
        }

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            Calculate_Total();
        }

        private void viewTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string Col_Mode = dgv_List_Content.AutoSizeColumnsMode.ToString();

            frmDataGridView_Modify frm = new frmDataGridView_Modify(_commonBLL.Get_Attribute_from_DatagridView(dgv_List_Content), Col_Mode);

            if (frm.ShowDialog() == DialogResult.OK)
            {
                _commonBLL.Set_Attribute_to_DatagridView(dgv_List_Content, frm.table_Updated_Att, frm.Col_ModeID);
            }
        }
    }
}