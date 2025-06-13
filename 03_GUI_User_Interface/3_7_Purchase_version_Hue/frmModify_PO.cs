using PLM_Lynx._01_DAL_Data_Access_Layer;
using PLM_Lynx._02_BLL_Bussiness_Logic_Layer;
using PLM_Lynx._03_GUI_User_Interface._00_Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PLM_Lynx._03_GUI_User_Interface._3_7_Purchase_version_Hue
{
    public partial class frmModify_PO : Form
    {
        //==========================================================

        #region ====== 01. FORM CONSTRUCTORS ========

        /// <summary>
        /// 1.1  Kế thừa các class
        /// </summary>
        private Purchase_V2_BLL _purchase_V2_BLL = new Purchase_V2_BLL();

        private CommonBLL _commonBLL = new CommonBLL();

        /// <summary>
        /// 1.2
        /// </summary>
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

        // PONumber, PODateCreate, POEstimateDeliveryDate, POSupplierID, POSupplierContactPerson, POCurrencyID, POUser, POStatusID, PORemark, POPaymentTerm, WareHouseID, POTotalPayment ,POTaxID
        private DataTable tblPur_PO_by_PONumber = new DataTable();

        private DataTable tblPur_PO_Details_Old = new DataTable();

        // PartID, Quantity_Order, UnitID, UnitPrice, Discount, Amount, RowID
        private DataTable tblPur_PO_Details_Update = new DataTable();

        // PartID, Quantity_Order, UnitID, UnitPrice, Discount, Amount, RowID
        private DataTable tblPur_PO_Details_Delete = new DataTable();

        // PartID, Quantity_Order, UnitID, UnitPrice, Discount, Amount
        private DataTable tblPur_PO_Details_Insert = new DataTable();

        // PartID, PartCode
        private DataTable tblPartID_PartCode = new DataTable();

        public string _UserName { get; set; }

        public int _poNumber { get; set; }

        private DateTime _poDateCreate;
        private DateTime _poEstimateDeliveryDate;
        private int _supplierID;
        private int _statusID;
        private int _taxID;
        private string _poRemark;
        private string _poPaymentTerm;
        private string _poSupplierContactPerson;
        private int _wareHouseID;
        private decimal _totalPayment;

        #endregion ====== 01. FORM CONSTRUCTORS ========

        //==========================================================
        //==========================================================

        #region ======= 02.FORM EVENTS ========

        public frmModify_PO()
        {
            InitializeComponent();
            Load_Common_Information();

            // Tạo các bảng table cho việc update
            Create_tblPur_PO_Details_Update();
            Create_tblPur_PO_Details_Delete();
            Create_tblPur_PO_Details_Insert();
        }

        private void frmModify_PO_Load(object sender, EventArgs e)
        {
            tblPur_PO_by_PONumber = _purchase_V2_BLL.Select_tblPur_PO_by_PONumber_BLL(_poNumber);
            tblPur_Content = _purchase_V2_BLL.Select_tblPur_PO_Detail_by_PONumber_BLL(_poNumber);
            tblPur_PO_Details_Old = _purchase_V2_BLL.Select_tblPur_PO_Detail_by_PONumber_BLL(_poNumber);

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
            tblAttached_File = _commonBLL.Get_All_File_In_Folder(_folderpath);
            dgv_AttachmentFiles.DataSource = tblAttached_File;
        }

        private void Create_tblPur_Content()
        {
            // PartCode, PartName, Quantity, UnitPrice, Unit, Discount,  Total ,  Currency, TaxCode
            //tblPur_Content.Columns.Add("PartCode", typeof(string));
            //tblPur_Content.Columns.Add("PartName", typeof(string));
            //tblPur_Content.Columns.Add("Quantity", typeof(int));
            //tblPur_Content.Columns.Add("UnitPrice", typeof(decimal));
            //tblPur_Content.Columns.Add("Unit", typeof(string));
            //tblPur_Content.Columns.Add("Discount", typeof(decimal));
            //tblPur_Content.Columns.Add("Total", typeof(decimal));
            //tblPur_Content.Columns.Add("TaxCode", typeof(string));
        }

        private void Create_tblPur_PO_Details_Update()
        {
            tblPur_PO_Details_Update.Columns.Add("RowID", typeof(int));
            tblPur_PO_Details_Update.Columns.Add("PONumber", typeof(int));
            tblPur_PO_Details_Update.Columns.Add("PartID", typeof(int));
            tblPur_PO_Details_Update.Columns.Add("Quantity_Order", typeof(int));
            tblPur_PO_Details_Update.Columns.Add("UnitID", typeof(int));
            tblPur_PO_Details_Update.Columns.Add("UnitPrice", typeof(decimal));
            tblPur_PO_Details_Update.Columns.Add("Discount", typeof(decimal));
            tblPur_PO_Details_Update.Columns.Add("Amount", typeof(decimal));
        }

        private void Create_tblPur_PO_Details_Delete()
        {
            tblPur_PO_Details_Delete.Columns.Add("RowID", typeof(int));
            tblPur_PO_Details_Delete.Columns.Add("PONumber", typeof(int));
            tblPur_PO_Details_Delete.Columns.Add("PartID", typeof(int));
            tblPur_PO_Details_Delete.Columns.Add("Quantity_Order", typeof(int));
            tblPur_PO_Details_Delete.Columns.Add("UnitID", typeof(int));
            tblPur_PO_Details_Delete.Columns.Add("UnitPrice", typeof(decimal));
            tblPur_PO_Details_Delete.Columns.Add("Discount", typeof(decimal));
            tblPur_PO_Details_Delete.Columns.Add("Amount", typeof(decimal));
        }

        private void Create_tblPur_PO_Details_Insert()
        {
            tblPur_PO_Details_Insert.Columns.Add("PartID", typeof(int));
            tblPur_PO_Details_Insert.Columns.Add("Quantity_Order", typeof(int));
            tblPur_PO_Details_Insert.Columns.Add("UnitID", typeof(int));
            tblPur_PO_Details_Insert.Columns.Add("UnitPrice", typeof(decimal));
            tblPur_PO_Details_Insert.Columns.Add("Discount", typeof(decimal));
            tblPur_PO_Details_Insert.Columns.Add("Amount", typeof(decimal));
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

        #endregion ======= 02.FORM EVENTS ========

        //==========================================================
        //==========================================================

        #region ===== 03. BUSINESS LOGIC =======

        // Calculate Total - Tính tổng tiền trước thuế, tổng tiền giảm giá, tổng tiền sau thuế
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

        /// <summary>
        /// 3.1 Function for Converting Data
        /// </summary>
        /// <param name="unitID"></param>
        /// <returns></returns>
        private string Convert_UnitID_to_UnitName(int unitID)
        {
            DataRow[] rows = tblPur_Unit.Select($"UnitID = {unitID}");
            if (rows.Length > 0)
            {
                return rows[0]["UnitName"].ToString();
            }
            return string.Empty; // Return empty string if no match found
        }

        private int Convert_UnitName_to_UnitID(string unitName)
        {
            int unitID = 0;
            if (tblPur_Unit != null && tblPur_Unit.Rows.Count > 0)
            {
                DataRow[] foundRows = tblPur_Unit.Select($"UnitName = '{unitName}'");
                if (foundRows.Length > 0)
                {
                    unitID = Convert.ToInt32(foundRows[0]["UnitID"]);
                }
            }
            return unitID;
        }

        /// <summary>
        /// 3.2 Function for Handling Data
        /// </summary>
        /// <returns></returns>

        // Fill Data Auto - Điền thêm PartName, UnitPrice, TaxCode, Quantity, Unit, Discount tự động
        private bool Fill_Data_Auto()
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

                    // Fill UnitPrice
                    if (tblPur_Content.Rows[i]["UnitPrice"] != DBNull.Value)
                    {
                        // Nothing to do, already has value
                    }
                    else
                    {
                        if (tbl_Pur_Part_Information.Rows[i]["PartPurchasePrice"] == DBNull.Value)
                        {
                            tblPur_Content.Rows[i]["UnitPrice"] = 0.00m; // Default value if UnitPrice is null
                        }
                        else
                        {
                            tblPur_Content.Rows[i]["UnitPrice"] = tbl_Pur_Part_Information.Rows[i]["PartPurchasePrice"];
                        }
                    }

                    // Fill Quantity
                    if (tblPur_Content.Rows[i]["Quantity"] != DBNull.Value)
                    {
                        // Nothing do, already has value
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

        // Paint_PartCode_Cell - Highlight duplicate PartCode cells and handle PartName and PartCode logic
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

        // PasteClipboardToGrid - Dán dữ liệu từ Clipboard vào DataGridView dgv_List_Content
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

        /// <summary>
        /// Show_OnlyPartCode_dgv_Search_Item - Chỉ hiển thị các PartCode duy nhất trong DataGridView tblPur_Search_Items
        /// </summary>
        private void Show_OnlyPartCode_dgv_Search_Item()
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

            dgv_List_Content.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Đặt Styel cho các cốt
            dgv_List_Content.Columns["UnitPrice"].DefaultCellStyle.Format = "N2";
            dgv_List_Content.Columns["Discount"].DefaultCellStyle.Format = "N2";
            dgv_List_Content.Columns["Total"].DefaultCellStyle.Format = "N2";
        }

        private void Get_tblPur_PO_Details_Update()
        {
            List<int> _listRowID_Old = new List<int>();
            foreach (DataRow row in tblPur_PO_Details_Old.Rows)
            {
                if (row["RowID"] != DBNull.Value)
                {
                    _listRowID_Old.Add(Convert.ToInt32(row["RowID"]));
                }
            }
            List<int> _listRowID_Content = new List<int>();
            foreach (DataRow row in tblPur_Content.Rows)
            {
                if (row["RowID"] != DBNull.Value)
                {
                    _listRowID_Content.Add(Convert.ToInt32(row["RowID"]));
                }
            }
            int icount = tblPur_Content.Rows.Count;
            for (int i = 0; i < icount; i++)
            {
                DataRow row = tblPur_Content.Rows[i];
                
                if (row["RowID"] != DBNull.Value)
                {
                    if(Check_Value_of_Content_is_in_Old(row) == true)
                    {
                        continue; // Hàng này không thay đổi giá trị gì cả , không cần update
                    }

                    DataRow newRow = tblPur_PO_Details_Update.NewRow();
                    newRow["RowID"] = row["RowID"];
                    string partCode = row["PartCode"].ToString().Trim();
                    int partID = 0;
                    foreach (DataRow partRow in tblPartID_PartCode.Rows)
                    {
                        if (partRow["PartCode"].ToString().Trim().Equals(partCode, StringComparison.OrdinalIgnoreCase))
                        {
                            partID = Convert.ToInt32(partRow["PartID"]);
                            break; // Found the matching PartID, no need to continue checking
                        }
                    }
                    newRow["PartID"] = partID;
                    newRow["PONumber"] = _poNumber; 
                    newRow["Quantity_Order"] = row["Quantity"];
                    newRow["UnitID"] = Convert_UnitName_to_UnitID(row["Unit"].ToString());
                    newRow["UnitPrice"] = row["UnitPrice"];
                    newRow["Discount"] = row["Discount"];
                    newRow["Amount"] = row["Total"];
                    tblPur_PO_Details_Update.Rows.Add(newRow);
                }
            }

            int count = tblPur_PO_Details_Update.Rows.Count;
            if (tblPur_PO_Details_Update.Rows.Count > 0)
            {
                MessageBox.Show("Update : " + count);
            }
            else
            {
                MessageBox.Show("Không có dữ liệu để update", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Get_tblPur_PO_Details_Delete()
        {
            List<int> listRowID_Content = new List<int>();
            foreach (DataRow row in tblPur_Content.Rows)
            {
                if (row["RowID"] != DBNull.Value)
                {
                    listRowID_Content.Add(Convert.ToInt32(row["RowID"]));
                }
            }

            foreach (DataRow row in tblPur_PO_Details_Old.Rows)
            {
                if (row["RowID"] != DBNull.Value && !listRowID_Content.Contains(Convert.ToInt32(row["RowID"])))
                {
                    DataRow newRow = tblPur_PO_Details_Delete.NewRow();
                    newRow["RowID"] = row["RowID"];
                    string partCode = row["PartCode"].ToString().Trim();
                    int partID = 0;
                    foreach (DataRow partRow in tblPartID_PartCode.Rows)
                    {
                        if (partRow["PartCode"].ToString().Trim().Equals(partCode, StringComparison.OrdinalIgnoreCase))
                        {
                            partID = Convert.ToInt32(partRow["PartID"]);
                            break; // Found the matching PartID, no need to continue checking
                        }
                    }
                    newRow["PartID"] = partID;
                    newRow["PONumber"] = _poNumber;
                    newRow["Quantity_Order"] = row["Quantity"];
                    newRow["UnitID"] = Convert_UnitName_to_UnitID(row["Unit"].ToString());
                    newRow["UnitPrice"] = row["UnitPrice"];
                    newRow["Discount"] = row["Discount"];
                    newRow["Amount"] = row["Total"];
                    newRow["RowID"] = row["RowID"];
                    tblPur_PO_Details_Delete.Rows.Add(newRow);
                }
            }

            if(tblPur_PO_Details_Delete.Rows.Count > 0)
            {
                MessageBox.Show("Delete: " + tblPur_PO_Details_Delete.Rows.Count);
            }
            else
            {
                MessageBox.Show("Không có dữ liệu để delete", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private bool Check_Value_of_Content_is_in_Old(DataRow dataRow)
        {
            // return true : Hàng này giống với hàng trong tblPur_PO_Details_Old
            bool isInOld = false;
            if (dataRow["RowID"] != DBNull.Value)
            {
                int rowID = Convert.ToInt32(dataRow["RowID"]);
                string partCode = dataRow["PartCode"].ToString().Trim();
                int quantity = Convert.ToInt32(dataRow["Quantity"]);
                decimal unitPrice = Convert.ToDecimal(dataRow["UnitPrice"]);
                string unit = dataRow["Unit"].ToString().Trim();
                decimal discount = Convert.ToDecimal(dataRow["Discount"]);

                foreach (DataRow oldRow in tblPur_PO_Details_Old.Rows)
                {
                    int oldRowID = Convert.ToInt32(oldRow["RowID"]);
                    string oldPartCode = oldRow["PartCode"].ToString().Trim();
                    int oldQuantity = Convert.ToInt32(oldRow["Quantity"]);
                    decimal oldUnitPrice = Convert.ToDecimal(oldRow["UnitPrice"]);
                    string oldUnit = oldRow["Unit"].ToString().Trim();
                    decimal oldDiscount = Convert.ToDecimal(oldRow["Discount"]);

                    if( oldRowID == rowID &&
                        oldPartCode.Equals(partCode, StringComparison.OrdinalIgnoreCase) &&
                        oldQuantity == quantity &&
                        oldUnitPrice == unitPrice &&
                        oldUnit.Equals(unit, StringComparison.OrdinalIgnoreCase) &&
                        oldDiscount == discount)
                    {
                        isInOld = true;
                        break; // Found a match, no need to continue checking
                    }
                }
            }
            return isInOld;
        }

        private void Get_tblPur_PO_Details_Insert()
        {
            foreach (DataRow row in tblPur_Content.Rows)
            {
                if (row["RowID"] == DBNull.Value || Convert.ToInt32(row["RowID"]) <= 0) // Check if ID is null or less than or equal to 0
                {
                    DataRow newRow = tblPur_PO_Details_Insert.NewRow();
                    string partCode = row["PartCode"].ToString().Trim();
                    int partID = 0;
                    foreach (DataRow partRow in tblPartID_PartCode.Rows)
                    {
                        if (partRow["PartCode"].ToString().Trim().Equals(partCode, StringComparison.OrdinalIgnoreCase))
                        {
                            partID = Convert.ToInt32(partRow["PartID"]);
                            break; // Found the matching PartID, no need to continue checking
                        }
                    }
                    newRow["PartID"] = partID; 
                    newRow["Quantity_Order"] = row["Quantity"];
                    newRow["UnitID"] = Convert_UnitName_to_UnitID(row["Unit"].ToString());
                    newRow["UnitPrice"] = row["UnitPrice"];
                    newRow["Discount"] = row["Discount"];
                    newRow["Amount"] = row["Total"];
                    tblPur_PO_Details_Insert.Rows.Add(newRow);
                }
            }

            if(tblPur_PO_Details_Insert.Rows.Count > 0)
            {
                MessageBox.Show("Inseert: " + tblPur_PO_Details_Insert.Rows.Count);
            }
            else
            {
                MessageBox.Show("Không có dữ liệu để insert", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #endregion ===== 03. BUSINESS LOGIC =======

        //==========================================================
        //==========================================================

        #region ===== 04.CONTROL EVENTS =======

        private void addFileToAttachmentListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnAddFile.PerformClick();
        }

        private void autoFillDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Fill_Data_Auto() == true)
            {
                MessageBox.Show("Auto fill data successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Auto fill data failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (Check_tblPur_Content() == false || Check_Input_Information() == false)
            {
                return;
            }

            string message = "Do you want to update the purchase order?";
            DialogResult result = MessageBox.Show(message, "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                DateTime _dcreate = dtpCreatingDate.Value;
                DateTime _destimate = dtpEstimateDelivery.Value;
                int SupID = Convert.ToInt32(cbo_tblPur_Supplier.SelectedValue);
                int StatusID = Convert.ToInt32(cbo_tblPur_Status.SelectedValue);
                int TaxID = Convert_TaxValue_to_TaxID(Convert.ToDecimal(cbo_tblPur_Tax.SelectedValue));
                int CurID = Convert.ToInt32(cbo_tblPur_Currency.SelectedValue);
                string Remark = txtRemark.Text.Trim();
                string PaymentTerm = txtPaymentTerm.Text.Trim();
                string SupPerson = cboSupplierContactPerson.SelectedItem?.ToString() ?? string.Empty;
                int WareHouseID = Convert.ToInt32(cbo_tblPur_WareHouse.SelectedValue);
                decimal TotalPayemnt = _Total_After_Tax;
                string user = txtStaffName.Text.Trim();

                tblPartID_PartCode = _purchase_V2_BLL.Select_PartID_PartCode_BLL(_commonBLL.Copy_Single_Column_to_NewTable(tblPur_Content, "PartCode"));
                Get_tblPur_PO_Details_Update();
                Get_tblPur_PO_Details_Delete();
                Get_tblPur_PO_Details_Insert();
                

                if (_purchase_V2_BLL.Update_Existing_PO_BLL(_poNumber,_dcreate,_destimate,SupID,SupPerson,CurID,user,StatusID,Remark,PaymentTerm,WareHouseID,
                    TotalPayemnt,TaxID,tblPur_PO_Details_Update, tblPur_PO_Details_Delete, tblPur_PO_Details_Insert) == true)
                {
                    MessageBox.Show("Update purchase order successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK; // Set the dialog result to OK
                    this.Close(); // Close the form
                }
                else
                {
                    MessageBox.Show("Update purchase order failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cbo_tblPur_Currency_SelectedIndexChanged(object sender, EventArgs e)
        {
            string currencyValue = Convert_CurrencyID_to_CurrencyName(cbo_tblPur_Currency.SelectedIndex + 1);
            lblCurrencyA.Text = currencyValue;
            lblCurrencyC.Text = currencyValue;
            lblCurrencyD.Text = currencyValue;
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

        private void checkInputDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Fill_Data_Auto();
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

                Calculate_Total(); // Recalculate totals after clearing
            }
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

        private void editTableVieingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string Col_Mode = dgv_Search_Items.AutoSizeColumnsMode.ToString();

            frmDataGridView_Modify frm = new frmDataGridView_Modify(_commonBLL.Get_Attribute_from_DatagridView(dgv_Search_Items), Col_Mode);

            if (frm.ShowDialog() == DialogResult.OK)
            {
                _commonBLL.Set_Attribute_to_DatagridView(dgv_Search_Items, frm.table_Updated_Att, frm.Col_ModeID);
            }
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

        private void pasteDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PasteClipboardToGrid();
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Show_OnlyPartCode_dgv_Search_Item();
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

        #endregion ===== 04.CONTROL EVENTS =======
    }
}