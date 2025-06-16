using PLM_Lynx._02_BLL_Bussiness_Logic_Layer;
using PLM_Lynx._03_GUI_User_Interface._00_Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PLM_Lynx._03_GUI_User_Interface._3_7_Purchase_version_Hue
{
    public partial class frm_Make_New_GRPO : Form
    {
        #region ====== 01. FORM CONSTRUCTORS ========

        private CommonBLL _commonBLL = new CommonBLL();

        private Dictionary<int, string> _dic_RowID_PartCode = new Dictionary<int, string>();

        private bool _is_Received_Other_PartCode_Valid;
        private bool _is_Received_Quantity_Bigger_Valid;
        private bool _is_Received_Quantity_Smaller_Valid;
        private DateTime _poDateCreate;

        private DateTime _poEstimateDeliveryDate;

        private string _poPaymentTerm;

        private string _poRemark;

        private string _poSupplierContactPerson;

        /// <summary>
        /// 1.1  Kế thừa các class
        /// </summary>
        private Purchase_V2_BLL _purchase_V2_BLL = new Purchase_V2_BLL();

        private int _statusID;

        private int _supplierID;

        private int _taxID;

        /// <summary>
        /// 1.2
        /// </summary>
        private decimal _Total_After_Tax = 0.00m;

        private decimal _Total_Before_Tax = 0.00m;
        private decimal _Total_Discount = 0.00m;
        private decimal _Total_Tax = 0.00m;
        private decimal _totalPayment;
        private int _wareHouseID;
        private DataTable tbl_ContactPerson = new DataTable();
        private DataTable tbl_Pur_GRPO_Items = new DataTable();
        private DataTable tblAttached_File = new DataTable();

        // PartID, PartCode
        private DataTable tblPartID_PartCode = new DataTable();

        // PartCode, PartName, Quantity, UnitPrice, Unit, Discount, Total, TaxCode
        private DataTable tblPur_Content = new DataTable();

        private DataTable tblPur_Content_Original = new DataTable();

        // CurrencyID, CurrencyName, CurrencyRate
        private DataTable tblPur_Currency = new DataTable();

        // PONumber, PODateCreate, POEstimateDeliveryDate, POSupplierID, POSupplierContactPerson, POCurrencyID, POUser, POStatusID, PORemark, POPaymentTerm, WareHouseID, POTotalPayment ,POTaxID
        private DataTable tblPur_PO_by_PONumber = new DataTable();

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

        public int _poNumber { get; set; }
        public string _UserName { get; set; }

        #endregion ====== 01. FORM CONSTRUCTORS ========

        //==========================================================
        //==========================================================

        #region ======= 02.FORM EVENTS ========

        public frm_Make_New_GRPO()
        {
            InitializeComponent();
            Load_Common_Information();
        }

        private void frm_Make_New_GRPO_Load(object sender, EventArgs e)
        {
            tblPur_PO_by_PONumber = _purchase_V2_BLL.Select_tblPur_PO_by_PONumber_BLL(_poNumber);
            tblPur_Content = _purchase_V2_BLL.Select_tblPur_PO_Detail_by_PONumber_BLL(_poNumber);
            tblPur_Content_Original = tblPur_Content.Copy();
            // Get dictionary of RowID and PartCode
            foreach (DataRow row in tblPur_Content_Original.Rows)
            {
                if (row["PartCode"] != DBNull.Value && row["RowID"] != DBNull.Value)
                {
                    string partCode = row["PartCode"].ToString().Trim();
                    int rowID = Convert.ToInt32(row["RowID"]);
                    if (!_dic_RowID_PartCode.ContainsKey(rowID))
                    {
                        _dic_RowID_PartCode[rowID] = partCode;
                    }
                }
            }

            tblPur_Content.Columns.Add("Status", typeof(string));
            tblPur_Content.Columns.Add("Received_Quantity", typeof(int));

            // Set "Status" column  is first column, and "Received_Quantity" is 4th column
            tblPur_Content.Columns["Status"].SetOrdinal(0);
            tblPur_Content.Columns["Received_Quantity"].SetOrdinal(4);

            tblPur_Content_Original = tblPur_Content.Copy();

            dgv_AttachmentFiles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Textbox, combobox, datetimepicker
            // - Supplier
            int supplierID = Convert.ToInt32(tblPur_PO_by_PONumber.Rows[0]["POSupplierID"]);
            cbo_tblPur_Supplier.SelectedValue = supplierID;
            // Contact Person
            string supplierContactPerson = tblPur_PO_by_PONumber.Rows[0]["POSupplierContactPerson"].ToString();
            cboSupplierContactPerson.Text = supplierContactPerson;
            // StatusID
            int statusID = Convert.ToInt32(tblPur_PO_by_PONumber.Rows[0]["POStatusID"]);
            cbo_tblPur_Status.SelectedValue = statusID;
            cbo_tblPur_Status.Enabled = false;
            // Datetime
            DateTime EstimateDeliveryDate = Convert.ToDateTime(tblPur_PO_by_PONumber.Rows[0]["POEstimateDeliveryDate"]);
            dtpEstimateDelivery.Value = EstimateDeliveryDate;
            DateTime CreateDate = Convert.ToDateTime(tblPur_PO_by_PONumber.Rows[0]["PODateCreate"]);
            dtpCreatingDate.Value = CreateDate;
            dtpCreatingDate.Enabled = false;

            // PONumber
            txtPONumber.Text = _poNumber.ToString();
            int currencyID = Convert.ToInt32(tblPur_PO_by_PONumber.Rows[0]["POCurrencyID"]);
            cbo_tblPur_Currency.SelectedValue = currencyID;
            int wareHouseID = Convert.ToInt32(tblPur_PO_by_PONumber.Rows[0]["WareHouseID"]);
            cbo_tblPur_WareHouse.SelectedValue = wareHouseID;
            txtRemark.Text = tblPur_PO_by_PONumber.Rows[0]["PORemark"].ToString();
            txtPaymentTerm.Text = tblPur_PO_by_PONumber.Rows[0]["POPaymentTerm"].ToString();
            txtTotalPayment.Text = tblPur_PO_by_PONumber.Rows[0]["POTotalPayment"].ToString();
            txtStaffName.Text = tblPur_PO_by_PONumber.Rows[0]["POUser"].ToString();
            int TaxID = Convert.ToInt32(tblPur_PO_by_PONumber.Rows[0]["POTaxID"]);
            cbo_tblPur_Tax.SelectedValue = Convert_TaxID_to_TaxValue(TaxID);

            // Datagridview

            dgv_List_Content.DataSource = tblPur_Content;
            ViewFit_dgv_List_Content();

            string _year = CreateDate.Year.ToString("D4");
            string _month = CreateDate.Month.ToString("D2");

            string _folderpath = System.IO.Path.Combine(Properties.Settings.Default.PurchaseData, "PURCHASE", "PO", _year, _month, _poNumber.ToString());
            if (System.IO.Directory.Exists(_folderpath))
            {
                tblAttached_File = _commonBLL.Get_All_File_In_Folder(_folderpath);
                dgv_AttachmentFiles.DataSource = tblAttached_File;
            }

            // Disable the all comboboxes
            cbo_tblPur_Supplier.Enabled = false;
            cbo_tblPur_Status.Enabled = false;
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
        }

        // ViewFit_dgv_ListContent - Xử lý hiển thị của DatagridView dgv_List_Content
        private void ViewFit_dgv_List_Content()
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
            dgv_List_Content.Columns["RowID"].ReadOnly = true;
            dgv_List_Content.Columns["Status"].ReadOnly = true;
            dgv_List_Content.Columns["Quantity"].ReadOnly = true;

            dgv_List_Content.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Đặt Styel cho các cốt
            dgv_List_Content.Columns["UnitPrice"].DefaultCellStyle.Format = "N2";
            dgv_List_Content.Columns["Discount"].DefaultCellStyle.Format = "N2";
            dgv_List_Content.Columns["Total"].DefaultCellStyle.Format = "N2";
        }

        #endregion ======= 02.FORM EVENTS ========

        //==========================================================
        //==========================================================

        #region ===== 03. BUSINESS LOGIC =======

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

        private bool Check_Col_PartCode_Valid()
        {
            bool isValid = true;
            List<string> _list_partCodes = new List<string>();
            foreach (DataGridViewRow row in dgv_List_Content.Rows)
            {
                if (row.Cells["PartCode"].Value != null)
                {
                    string partCode = row.Cells["PartCode"].Value.ToString().Trim();
                    if (_list_partCodes.Contains(partCode))
                    {
                        isValid = false;
                        row.DefaultCellStyle.BackColor = Color.Red;
                    }
                    else
                    {
                        _list_partCodes.Add(partCode);
                        row.DefaultCellStyle.BackColor = Color.White; // Reset background color if valid
                    }
                }
            }

            return isValid;
        }

        /// <summary>
        /// return true : nếu không có lỗi,
        /// return false : Nếu có 1 PartCode không hợp lệ so với RowID
        /// </summary>
        /// <returns></returns>
        private bool Check_Col_PartCode_vs_RowID()
        {
            bool isValid = true;

            foreach (DataGridViewRow row in dgv_List_Content.Rows)
            {
                if (row.Cells["PartCode"].Value != null)
                {
                    string partCode = row.Cells["PartCode"].Value.ToString().Trim();
                    int rowID = Convert.IsDBNull(row.Cells["RowID"].Value) ? 0 : Convert.ToInt32(row.Cells["RowID"].Value);
                    if (_dic_RowID_PartCode.ContainsKey(rowID) && _dic_RowID_PartCode[rowID] == partCode)
                    {
                        //// Là OK
                        //row.Cells["Status"].Value = "PartCode is is PO";
                        //row.Cells["PartCode"].Style.BackColor = Color.LightGreen;
                    }
                    else
                    {
                        // Không hợp lệ

                        isValid = false;
                        row.Cells["Status"].Value = "PartCode is not in PO";
                        row.Cells["PartCode"].Style.BackColor = Color.Yellow;
                    }
                }
            }
            return isValid;
        }

        private void Check_Col_Received_Quantity_Valid()
        {
            // Check if Received_Quantity is valid
            bool is_Received_Quantity_Bigger_Valid = true;
            bool is_Received_Quantity_Smaller_Valid = true;

            foreach (DataGridViewRow row in dgv_List_Content.Rows)
            {
                int recceived_quantity = Convert.IsDBNull(row.Cells["Received_Quantity"].Value) ? 0 : Convert.ToInt32(row.Cells["Received_Quantity"].Value);
                if (recceived_quantity < 0)
                {
                    row.Cells["Received_Quantity"].Style.BackColor = Color.DodgerBlue;
                    row.Cells["Status"].Value = row.Cells["Status"].Value.ToString() + "Received Quantity is invalid"; // Set status message
                }
                else
                {
                    // Compare with Quantity
                    int quantity = Convert.IsDBNull(row.Cells["Quantity"].Value) ? 0 : Convert.ToInt32(row.Cells["Quantity"].Value);
                    if (recceived_quantity > quantity)
                    {
                        row.Cells["Received_Quantity"].Style.BackColor = Color.Red; // Highlight the row in orange
                        row.Cells["Status"].Value = row.Cells["Status"].Value.ToString() + "Received Quantity > Quantity"; // Set status message
                        is_Received_Quantity_Bigger_Valid = false;
                    }
                    else if (recceived_quantity == quantity)
                    {
                        row.Cells["Received_Quantity"].Style.BackColor = Color.LightGreen; // Highlight the row in light green
                    }
                    else
                    {
                        row.Cells["Status"].Value = row.Cells["Status"].Value.ToString() + "Received Quantity < Quantity"; // Set status message
                        row.Cells["Received_Quantity"].Style.BackColor = Color.DodgerBlue;
                        is_Received_Quantity_Smaller_Valid = false;
                    }
                }
            }

            if (is_Received_Quantity_Bigger_Valid) { ckcReceived_Quantity_Bigger.Checked = false; }
            else { ckcReceived_Quantity_Bigger.Checked = true; }
            if (is_Received_Quantity_Smaller_Valid) { ckcReceived_Quantity_Smaller.Checked = false; }
            else { ckcReceived_Quantity_Smaller.Checked = true; }
        }

        private void Check_tblPur_Content_Data_Valid()
        {
            // Check if tblPur_Content has valid data
            foreach (DataRow row in tblPur_Content.Rows)
            {
                if (row["PartCode"] == DBNull.Value || string.IsNullOrWhiteSpace(row["PartCode"].ToString()))
                {
                    MessageBox.Show("PartCode cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (row["Quantity"] == DBNull.Value || Convert.ToInt32(row["Quantity"]) < 0)
                {
                    MessageBox.Show("Quantity must be greater than 0.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (row["UnitPrice"] == DBNull.Value || Convert.ToDecimal(row["UnitPrice"]) < 0)
                {
                    MessageBox.Show("UnitPrice cannot be negative.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
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

        private decimal Convert_TaxID_to_TaxValue(int taxID)
        {
            decimal taxValue = 0.00m;
            if (tblPur_Tax != null && tblPur_Tax.Rows.Count > 0)
            {
                DataRow[] foundRows = tblPur_Tax.Select($"TaxID = {taxID}");
                if (foundRows.Length > 0)
                {
                    taxValue = Convert.ToDecimal(foundRows[0]["TaxValue"]);
                }
            }
            return taxValue;
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

        private void Delete_EmptyRow_in_dgv_List_Content()
        {
            // Clear empty rows in dgv_List_Content
            for (int i = dgv_List_Content.Rows.Count - 1; i >= 0; i--)
            {
                DataGridViewRow row = dgv_List_Content.Rows[i];
                if (row.IsNewRow) continue; // Skip the new row placeholder
                if (row.Cells["PartCode"].Value == null || string.IsNullOrWhiteSpace(row.Cells["PartCode"].Value.ToString()))
                {
                    dgv_List_Content.Rows.RemoveAt(i);
                }
            }
            txtCountRow.Text = tblPur_Content.Rows.Count.ToString();
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

                    // Don't allow to paste "RowID" column , if Current Column is "RowID" => Dont paste
                    if (dgv_List_Content.CurrentCell != null && dgv_List_Content.CurrentCell.OwningColumn.Name == "RowID")
                    {
                        MessageBox.Show("Cannot paste data into RowID column.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (tbl_ClipBoard.Columns.Contains("RowID"))
                    {
                        tbl_ClipBoard.Columns.Remove("RowID");
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

        private void Insert_New_GRPO()
        {
            DataTable tbl_Pur_GRPO = new DataTable();
            // PONumber, RecevedDate, ReceivedAmount, GRPORemark, GRPOStatusID, Over_Quantity, Under_Quantity, Other_PartCode
            tbl_Pur_GRPO.Columns.Add("PONumber", typeof(int));
            tbl_Pur_GRPO.Columns.Add("ReceivedDate", typeof(DateTime));
            tbl_Pur_GRPO.Columns.Add("ReceivedAmount", typeof(decimal));
            tbl_Pur_GRPO.Columns.Add("GRPORemark", typeof(string));
            tbl_Pur_GRPO.Columns.Add("GRPOStatusID", typeof(int));
            tbl_Pur_GRPO.Columns.Add("Over_Quantity", typeof(bool));
            tbl_Pur_GRPO.Columns.Add("Under_Quantity", typeof(bool));
            tbl_Pur_GRPO.Columns.Add("Other_PartCode", typeof(bool));

            // Add values to the DataTable
            DataRow newRow = tbl_Pur_GRPO.NewRow();
            newRow["PONumber"] = _poNumber;
            newRow["ReceivedDate"] = dtpReceived_Date.Value;
            newRow["ReceivedAmount"] = Convert.ToDecimal(txtTotalPayment.Text.Trim());
            newRow["GRPORemark"] = txtRemark.Text.Trim();
            newRow["GRPOStatusID"] = Convert.ToInt32(cbo_tblPur_Status.SelectedValue);
            newRow["Over_Quantity"] = ckcReceived_Quantity_Bigger.Checked;
            newRow["Under_Quantity"] = ckcReceived_Quantity_Smaller.Checked;
            nameof(newRow["Other_PartCode"]) = ckcReceived_Other_PartCode.Checked;


            DataTable tblPur_GRPO_Detail = new DataTable();
            // GRPOID, PODetail-RowID, Quantity_Received, UnitReceivedID
            
            tbl_Pur_GRPO_Detail.Columns.Add("PODetail_RowID", typeof(int));
            tbl_Pur_GRPO_Detail.Columns.Add("Quantity_Received", typeof(int));
            tbl_Pur_GRPO_Detail.Columns.Add("UnitReceivedID", typeof(int)); // Assuming you have a UnitReceivedID column

            foreach (DataRow row in tblPur_Content.Rows)
            {
               
                    DataRow newDetailRow = tblPur_GRPO_Detail.NewRow();
                    newDetailRow["PODetail_RowID"] = Convert.ToInt32(row["RowID"]);
                    newDetailRow["Quantity_Received"] = Convert.ToInt32(row["Received_Quantity"]);
                    newDetailRow["UnitReceivedID"] = 
                    tblPur_GRPO_Detail.Rows.Add(newDetailRow);
               
            }

        }

        #endregion ===== 03. BUSINESS LOGIC =======

        //==========================================================
        //==========================================================

        #region ===== 04.CONTROL EVENTS =======

        private void btn_Add_GRPO_Click(object sender, EventArgs e)
        {
            cms_dgv_List_Content_Check_Data.PerformClick();

            Calculate_Total();

            if (ckcReceived_Quantity_Smaller.Checked == true)
            {
                string mes3 = "Received Quantity is smaller than Quantity. \r\n Do you want to continue?";
                DialogResult result3 = MessageBox.Show(mes3, "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result3 == DialogResult.No)
                {
                    return; // If user chooses No, exit the method
                }
            }
            ckcReceived_Quantity_Smaller.Checked = false;

            if (ckcReceived_Other_PartCode.Checked || ckcReceived_Quantity_Bigger.Checked || ckcReceived_Quantity_Smaller.Checked == true)
            {
                string message2 = "There are some issues with the data. Please check the status column for details.";
                string title2 = "Data Validation Error";
                MessageBox.Show(message2, title2, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string message = "Do you want to create a new GRPO?";
            string title = "Create GRPO";
            DialogResult result = MessageBox.Show(message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Insert_New_GRPO();
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
            string message = "Do you want to cancel the creation of this GRPO?";
            string title = "Cancel GRPO Creation";
            DialogResult result = MessageBox.Show(message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
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

        private void btnModify_This_PO_Click(object sender, EventArgs e)
        {
            string message = "Do you want to modify this Purchase Order?";
            string title = "Modify Purchase Order";
            DialogResult result = MessageBox.Show(message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                frmModify_PO frm = new frmModify_PO();
                frm._poNumber = Convert.ToInt32(txtPONumber.Text.Trim());
                frm.ShowDialog();
            }
        }

        private void cm_dgv_List_Content_Insert_Multi_Rows_Click(object sender, EventArgs e)
        {
            using (frm_Choose_Multi_Rows frm = new frm_Choose_Multi_Rows())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    int numberOfRows = frm.SelectedRowCount;
                    if (numberOfRows > 0)
                    {
                        for (int i = 0; i < numberOfRows; i++)
                        {
                            DataRow newRow = tblPur_Content.NewRow();
                            tblPur_Content.Rows.Add(newRow);
                        }
                        dgv_List_Content.Refresh(); // Refresh the DataGridView to show the new rows
                    }
                }
            }
            txtCountRow.Text = tblPur_Content.Rows.Count.ToString();
        }

        private void cms_dgv_List_Content_Check_Data_Click(object sender, EventArgs e)
        {
            //  1. Xóa các thông báo của "Status" column
            foreach (DataGridViewRow row in dgv_List_Content.Rows)
            {
                row.Cells["Status"].Value = string.Empty;
                row.DefaultCellStyle.BackColor = Color.White;
            }

            // 2. Xóa các hàng trống trong dgv_List_Content
            Delete_EmptyRow_in_dgv_List_Content();

            // 3. Không cho phép 2 PartCode giống nhau

            if (!Check_Col_PartCode_Valid())
            {
                MessageBox.Show("PartCode must be unique.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 4. Kiểm tra xem PartCode có nằm trong PONumber không ?
            if (Check_Col_PartCode_vs_RowID() == false)
            {
                MessageBox.Show("PartCode does not match RowID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _is_Received_Other_PartCode_Valid = true;
                ckcReceived_Other_PartCode.Checked = true;
            }
            // 5. Kiểm tra lại giá trị của "Received_Quantity"
            Check_Col_Received_Quantity_Valid();

            // 6. Kiểm tra các cột dữ liệu khác trong tblPur_Content
            Check_tblPur_Content_Data_Valid();
        }

        private void cms_dgv_List_Content_Delete_Row_Click(object sender, EventArgs e)
        {
            // Delete the selected row from the DataGridView
            if (dgv_List_Content.SelectedRows.Count > 1)
            {
                DataTable dt = (DataTable)dgv_List_Content.DataSource;

                // Sắp xếp SelectedRows theo Index giảm dần để tránh lỗi khi xóa
                var rowsToDelete = dgv_List_Content.SelectedRows
                    .Cast<DataGridViewRow>()
                    .OrderByDescending(r => r.Index);

                foreach (DataGridViewRow row in rowsToDelete)
                {
                    if (!row.IsNewRow)
                    {
                        dt.Rows[row.Index].Delete();  // đánh dấu hàng xóa
                    }
                }

                dt.AcceptChanges();  // Gọi một lần duy nhất sau khi xóa xong

                Calculate_Total(); // Recalculate totals after deletion
            }
            else
            {
                // Delete the currently selected row
                if (dgv_List_Content.CurrentRow != null && !dgv_List_Content.CurrentRow.IsNewRow)
                {
                    int rowIndex = dgv_List_Content.CurrentCell.RowIndex;
                    if (rowIndex >= 0)
                    {
                        DataTable dt = (DataTable)dgv_List_Content.DataSource;
                        dt.Rows[rowIndex].Delete();   // Đánh dấu hàng là deleted
                        dt.AcceptChanges();           // Tùy ý: xác nhận thay đổi (nếu cần)
                    }
                    Calculate_Total();
                }
                else
                {
                    MessageBox.Show("Please select a row to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            txtCountRow.Text = tblPur_Content.Rows.Count.ToString();
        }

        private void cms_dgv_List_Content_Edit_Table_Viewing_Click(object sender, EventArgs e)
        {
            string Col_Mode = dgv_List_Content.AutoSizeColumnsMode.ToString();

            frmDataGridView_Modify frm = new frmDataGridView_Modify(_commonBLL.Get_Attribute_from_DatagridView(dgv_List_Content), Col_Mode);

            if (frm.ShowDialog() == DialogResult.OK)
            {
                _commonBLL.Set_Attribute_to_DatagridView(dgv_List_Content, frm.table_Updated_Att, frm.Col_ModeID);
            }
        }

        private void cms_dgv_List_Content_Insert_New_Row_Click(object sender, EventArgs e)
        {
            // Insert a new row at the current position in the DataGridView
            int currentRowIndex = dgv_List_Content.CurrentCell == null ? 0 : dgv_List_Content.CurrentCell.RowIndex;
            if (currentRowIndex < 0 || currentRowIndex >= tblPur_Content.Rows.Count)
            {
                currentRowIndex = tblPur_Content.Rows.Count; // If no valid row is selected, add at the end
            }
            DataRow newRow = tblPur_Content.NewRow();
            tblPur_Content.Rows.InsertAt(newRow, currentRowIndex + 1);
            dgv_List_Content.CurrentCell = dgv_List_Content.Rows[currentRowIndex + 1].Cells[0]; // Set focus to the first cell of the new row
            dgv_List_Content.Refresh(); // Refresh the DataGridView to show the new row
        }

        private void cms_dgv_List_Content_Open_Part_Feature_Click(object sender, EventArgs e)
        {
            if (dgv_Search_Items.Rows.Count > 0)
            {
                frmRelationPart_Detail_Info frm = new frmRelationPart_Detail_Info();
                string partcode = dgv_Search_Items.CurrentRow.Cells["PartCode"].Value.ToString();
                frm.ShowDetailInfor(partcode);
                frm.ShowDialog();
            }
        }

        private void cms_dgv_List_Content_Reset_Original_Data_Click(object sender, EventArgs e)
        {
            string message = "Do you want to reset the content to the original data?";
            string title = "Reset Content";
            DialogResult result = MessageBox.Show(message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                tblPur_Content = tblPur_Content_Original.Copy();
                dgv_List_Content.DataSource = tblPur_Content;
                ViewFit_dgv_List_Content();
                Calculate_Total();
            }
        }

        private void cms_dgv_Search_Items_Edit_Table_Viewing_Click(object sender, EventArgs e)
        {
            string Col_Mode = dgv_Search_Items.AutoSizeColumnsMode.ToString();

            frmDataGridView_Modify frm = new frmDataGridView_Modify(_commonBLL.Get_Attribute_from_DatagridView(dgv_Search_Items), Col_Mode);

            if (frm.ShowDialog() == DialogResult.OK)
            {
                _commonBLL.Set_Attribute_to_DatagridView(dgv_Search_Items, frm.table_Updated_Att, frm.Col_ModeID);
            }
        }

        private void cms_dgv_Search_Items_Insert_to_Content_Click(object sender, EventArgs e)
        {
            string message = "Do you want to insert the selected items into the GRPO content?";
            string title = "Insert Items to GRPO Content";
            DialogResult result = MessageBox.Show(message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                string _partcode = dgv_Search_Items.CurrentRow.Cells["PartCode"].Value.ToString();
                string _partname = dgv_Search_Items.CurrentRow.Cells["PartName"].Value.ToString();
                decimal _UnitPrice = Convert.ToDecimal(dgv_Search_Items.CurrentRow.Cells["UnitPrice"].Value.ToString());
                DataRow row = tblPur_Content.NewRow();
                row["PartCode"] = _partcode;
                row["PartName"] = _partname;
                row["Quantity"] = 1; // Default value for Quantity
                row["UnitPrice"] = _UnitPrice;
                row["Unit"] = tblPur_Unit.DefaultView[0]["UnitName"];
                row["Discount"] = 0.00m; // Default value for Discount
                row["Total"] = 0.00m; // Default value for Total
                row["Received_Quantity"] = 0; // Default value for Received_Quantity
                row["Status"] = "New"; // Default value for Status
                row["RowID"] = 0; // Default value for RowID
                tblPur_Content.Rows.Add(row);
                MessageBox.Show("Item inserted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            txtCountRow.Text = tblPur_Content.Rows.Count.ToString();
        }

        private void cms_dgv_Search_Items_Open_Part_Feature_Click(object sender, EventArgs e)
        {
            if (dgv_Search_Items.Rows.Count > 0)
            {
                frmRelationPart_Detail_Info frm = new frmRelationPart_Detail_Info();
                string partcode = dgv_Search_Items.CurrentRow.Cells["PartCode"].Value.ToString();
                frm.ShowDetailInfor(partcode);
                frm.ShowDialog();
            }
        }

        private void cms_dgv_Search_Items_Show_PartCode_Only_Click(object sender, EventArgs e)
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

        private void dgv_List_Content_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_List_Content.Columns[e.ColumnIndex].Name == "Quantity" || dgv_List_Content.Columns[e.ColumnIndex].Name == "UnitPrice" || dgv_List_Content.Columns[e.ColumnIndex].Name == "Discount")
            {
                Calculate_Total();
            }
        }

        private void dgv_List_Content_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.V)
            {
                PasteClipboardToGrid();
            }
        }

        private void dgv_List_Content_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //var grid = sender as DataGridView;
            //string stt = (e.RowIndex + 1).ToString();
            //var centerFormat = new StringFormat()
            //{
            //    Alignment = StringAlignment.Center,
            //    LineAlignment = StringAlignment.Center
            //};

            //Rectangle headerBounds = new Rectangle(
            //    e.RowBounds.Left,
            //    e.RowBounds.Top,
            //    grid.RowHeadersWidth,
            //    e.RowBounds.Height);

            //e.Graphics.DrawString(stt, this.Font, SystemBrushes.ControlText, headerBounds, centerFormat);
        }

        #endregion ===== 04.CONTROL EVENTS =======
    }
}