using PLM_Lynx._01_DAL_Data_Access_Layer;
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
    public partial class frm_Update_GRPO : Form
    {
        #region ====== 01. FORM CONSTRUCTORS ========

        private CommonBLL _commonBLL = new CommonBLL();
        private int _GRPOID;
        private Purchase_V2_BLL _purchase_V2_BLL = new Purchase_V2_BLL();

        // ==> 1.1 Database Tables - Danh sách các bảng dùng chung
        /// <summary>
        /// return Table (CurrencyID, CurrencyName, CurrencyRate)
        /// </summary>
        private DataTable tblPur_Currency = new DataTable();

        /// <summary>
        /// return Table (StatusID, StatusName)
        /// </summary>
        private DataTable tblPur_Status = new DataTable();

        /// <summary>
        /// SupplierID , SupplierCode, SupplierName, SupplierLocation, SupplierPhone, SupplierTaxNumber, SupplierNote, SupplierContactPerson
        /// </summary>
        private DataTable tblPur_Supplier = new DataTable();

        /// <summary>
        /// Return Table (TaxID, TaxName, TaxValue)
        /// </summary>
        private DataTable tblPur_Tax = new DataTable();

        /// <summary>
        /// return Table (UnitID, UnitName, UnitValue, UnitContent)
        /// </summary>
        private DataTable tblPur_Unit = new DataTable();

        /// <summary>
        /// return Table (WareHouseID, WareHouseName)
        /// </summary>
        private DataTable tblPur_WareHouse = new DataTable();

        // 1.2 ==> Private Variables
        private decimal _Total_After_Tax = 0.00m;

        private decimal _Total_Before_Tax = 0.00m;

        private decimal _Total_Discount = 0.00m;

        private decimal _Total_Tax = 0.00m;

        private bool Full_Quantity_Status = false;

        private bool Have_Other_PartCode = false;
        private bool Have_Over_Quantity = false;

        private bool is_Loading_form = false;

        /// <summary>
        /// Return Table (PartCode, PartName, Quantity_Order, QuantityReceived, DiscountReceived, UnitName, PODetail_RowID , ExpiredDate)
        /// </summary>
        private DataTable tblPur_Content = new DataTable();

        private DataTable tblPur_Content_Original = new DataTable();

        private DataTable tblPur_GRPO_Detail_Original = new DataTable();

        private DataTable tblPur_GRPO_Original = new DataTable();

        private DataTable tblPur_PO_Detail_Original = new DataTable();

        private DataTable tblPur_PO_Original = new DataTable();

        private DataTable tblPur_Reset = new DataTable();

        // GRPOID, GRPONumber, PONumber, ReceivedDate, ReceivedAmount, GRPORemark, GRPOStatusID, GRPOCurrencyID, GRPOWareHouseID, GRPOTaxID
        private DataTable _tbl_Pur_GRPO_Input;

        /// <summary>
        /// Return Table (GRPOID,  PODetail_RowID, QuantityReceived, UnitPriceReceived, DiscountReceived, ExpiredDate )
        /// </summary>
        private DataTable _tblPur_GRPO_Detail_Update;

        /// <summary>
        ///  Return Table ( Inventory_RowID, PartID, PODetail_RowID, SODetail_RowID, UnitID, CreatedDate, ExpiredDate, WareHouseID, Quantity )
        /// </summary>
        private DataTable _tblInventory_Update = new DataTable();

        /// <summary>
        /// Return Table ( PartID, PartName, TaxCode, UnitID, WareHouseID, Quantity_Inventory, UpdatedDate )
        /// </summary>
        private DataTable _tblInventory_Summary_Update = new DataTable();

        public int _GRPO_Number { get; set; }

        // return table [ PartCode, PartName, Quantity_Order, QuantityReceived, DiscountReceived, UnitName, PODetail_RowID ]
        // return table [ PONumber, PODateCreate, POEstimateDeliveryDate, SupplierName, POSupplierContactPerson, CurrencyName, POUser, StatusName, WareHouseName, POTotalPayment, POTaxID ]
        // return table [PartCode, PartName, Quantity, UnitPrice, Unit, Discount, Total, TaxCode, RowID]
        // return table [ GRPOID, GRPONumber, PONumber, ReceivedDate, ReceivedAmount, GRPORemark, GRPOStatusID, GRPOCurrencyID, GRPOWareHouseID, GRPOTaxID ]
        // return table [ PartCode, PartName, Quantity_Order, QuantityReceived, DiscountReceived, UnitName, PODetail_RowID ]
        // 1.3 ==> Public Variables
        public int _PO_Number { get; set; }

        #endregion ====== 01. FORM CONSTRUCTORS ========

        //==========================================================
        //==========================================================

        #region ======= 02.FORM EVENTS ========

        public frm_Update_GRPO()
        {
            InitializeComponent();
            Load_Common_Information();
        }

        /// <summary>
        /// 01.PartCode || 02.PartName || 03.Qty_Order || 04.Qty_Receipt || 05.Qty_Add || 06.UnitPrice || 07.Discount || 08.Total || 09.Unit || 10.TaxCode || 11.RowID
        /// </summary>
        private void Create_tblPur_Content()
        {
            tblPur_Content.Columns.Add("PartCode", typeof(string));
            tblPur_Content.Columns.Add("PartName", typeof(string));
            tblPur_Content.Columns.Add("Qty_Order", typeof(int));
            tblPur_Content.Columns.Add("Qty_Receipt", typeof(int));
            tblPur_Content.Columns.Add("Qty_Add", typeof(int));
            tblPur_Content.Columns.Add("UnitPrice", typeof(decimal));
            tblPur_Content.Columns.Add("Discount", typeof(decimal));
            tblPur_Content.Columns.Add("Total", typeof(decimal));
            tblPur_Content.Columns.Add("Unit", typeof(string));
            tblPur_Content.Columns.Add("TaxCode", typeof(string));
            tblPur_Content.Columns.Add("ExpiredDate", typeof(DateTime));
            tblPur_Content.Columns.Add("RowID", typeof(int));
        }

        private void frm_Update_GRPO_Load(object sender, EventArgs e)
        {
            tblPur_PO_Original = _purchase_V2_BLL.Select_tblPur_PO_by_PONumber_BLL(_PO_Number);
            // return table [ PONumber, PODateCreate, POEstimateDeliveryDate, SupplierName, POSupplierContactPerson, CurrencyName, POUser, StatusName, WareHouseName, POTotalPayment, POTaxID ]
            tblPur_PO_Detail_Original = _purchase_V2_BLL.Select_tblPur_PO_Detail_by_PONumber_BLL(_PO_Number);
            // return table [PartCode, PartName, Quantity, UnitPrice, Unit, Discount, Total, TaxCode, RowID]
            tblPur_GRPO_Original = _purchase_V2_BLL.Select_tblPur_GRPO_by_GRPONumber_BLL(_GRPO_Number);
            // return table [ GRPOID, GRPONumber, PONumber, ReceivedDate, ReceivedAmount, GRPORemark, GRPOStatusID, GRPOCurrencyID, GRPOWareHouseID, GRPOTaxID ]
            tblPur_GRPO_Detail_Original = _purchase_V2_BLL.Select_tblPur_GRPO_Detail_by_GRPONumber_BLL(_GRPO_Number);
            // return table [ PartCode, PartName, Quantity_Order, QuantityReceived, DiscountReceived, UnitName, PODetail_RowID , ExpiredDate ]

            _GRPOID = Convert.ToInt32(tblPur_GRPO_Original.Rows[0]["GRPOID"]);

            Create_tblPur_Content();
            // PartCode || PartName || Qty_Order || Qty_Receipt || Qty_Add ||  UnitPrice || Discount || Total || UnitName || RowID
            foreach (DataRow row in tblPur_PO_Detail_Original.Rows)
            {
                DataRow newRow = tblPur_Content.NewRow();
                newRow["PartCode"] = row["PartCode"];
                newRow["PartName"] = row["PartName"];
                newRow["Qty_Order"] = Convert.ToInt32(row["Quantity"]);
                int _rowID = Convert.ToInt32(row["RowID"]);
                int _Qty_Receipt = 0;
                decimal _UnitPrice = row["UnitPrice"] != DBNull.Value ? Convert.ToDecimal(row["UnitPrice"]) : 0.00m;
                decimal _Discount = row["Discount"] != DBNull.Value ? Convert.ToDecimal(row["Discount"]) : 0.00m;
                string _UnitName = row["Unit"] != DBNull.Value ? row["Unit"].ToString() : string.Empty;
                string _ExpiredDate = string.Empty;
                foreach (DataRow grporow in tblPur_GRPO_Detail_Original.Rows)
                {
                    if (Convert.ToInt32(grporow["PODetail_RowID"]) == _rowID)
                    {
                        _Qty_Receipt = Convert.ToInt32(grporow["QuantityReceived"]);
                        _UnitPrice = Convert.ToDecimal(grporow["UnitPriceReceived"]);
                        _Discount = Convert.ToDecimal(grporow["DiscountReceived"]);
                        _UnitName = grporow["UnitName"].ToString();
                        _ExpiredDate = grporow["ExpiredDate"] != DBNull.Value ? grporow["ExpiredDate"].ToString() : string.Empty; // Default to today if ExpiredDate is null
                        break;
                    }
                }

                newRow["Qty_Receipt"] = _Qty_Receipt;
                newRow["Qty_Add"] = 0;
                newRow["UnitPrice"] = _UnitPrice;
                newRow["Discount"] = _Discount;
                newRow["Total"] = _Qty_Receipt * _UnitPrice * (100 - _Discount) / 100;
                newRow["Unit"] = _UnitName;
                newRow["TaxCode"] = row["TaxCode"] != DBNull.Value ? row["TaxCode"].ToString() : string.Empty;
                if (_ExpiredDate != string.Empty)
                {
                    newRow["ExpiredDate"] = Convert.ToDateTime(_ExpiredDate);
                }

                newRow["RowID"] = _rowID;
                tblPur_Content.Rows.Add(newRow);
            }

            tblPur_Content_Original = tblPur_Content.Copy();
            tblPur_Reset = tblPur_Content.Copy();

            Load_This_GRPO_Information();
            Calculate_Total();
            is_Loading_form = true;
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

        private void Load_This_GRPO_Information()
        {
            // Load the GRPO Information
            if (tblPur_GRPO_Original != null && tblPur_GRPO_Original.Rows.Count > 0)
            {
                // Textbox, combobox, datetimepicker
                // - Supplier
                int supplierID = Convert.ToInt32(tblPur_PO_Original.Rows[0]["POSupplierID"]);
                cbo_tblPur_Supplier.SelectedValue = supplierID;
                // Contact Person
                string supplierContactPerson = tblPur_PO_Original.Rows[0]["POSupplierContactPerson"].ToString();
                cboSupplierContactPerson.Text = supplierContactPerson;

                // -- StatusID
                int StatusID = Convert.ToInt32(tblPur_GRPO_Original.Rows[0]["GRPOStatusID"]);
                cbo_tblPur_Status.SelectedValue = StatusID;

                // Nếu StatusID = 2 ( Đã đóng ) hoặc StatusID = 3 ( Đã hủy ) thì không cho phép chỉnh sửa
                if (StatusID == 2 || StatusID == 3)
                {
                    MessageBox.Show("GRPO đã được đóng hoặc hủy, không thể chỉnh sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnModify_This_PO.Enabled = false;
                    btn_Update_GRPO.Enabled = false;
                    cms_dgv_List_Content_Delete_This_GRPO.Enabled = false;
                }

                // Datetime

                dtpEstimateDelivery.Value = Convert.ToDateTime(tblPur_PO_Original.Rows[0]["POEstimateDeliveryDate"]);

                dtpCreatingDate.Value = Convert.ToDateTime(tblPur_PO_Original.Rows[0]["PODateCreate"]);

                dtpReceived_Date.Value = DateTime.Now.Date; // Khi cập nhật GRPO thì ngày nhận hàng sẽ là ngày hiện tại

                dtpCreatingDate.Enabled = false;

                // PONumber
                txtGRPONumber.Text = tblPur_GRPO_Original.Rows[0]["GRPONumber"].ToString();

                // Currency
                int currencyID = Convert.ToInt32(tblPur_GRPO_Original.Rows[0]["GRPOCurrencyID"]);
                cbo_tblPur_Currency.SelectedValue = currencyID;
                lblCurrencyA.Text = cbo_tblPur_Currency.Text;
                lblCurrencyC.Text = cbo_tblPur_Currency.Text;
                lblCurrencyD.Text = cbo_tblPur_Currency.Text;

                // WareHouse
                int wareHouseID = Convert.ToInt32(tblPur_GRPO_Original.Rows[0]["GRPOWareHouseID"]);
                cbo_tblPur_WareHouse.SelectedValue = wareHouseID;

                // Tax
                int taxID = Convert.ToInt32(tblPur_GRPO_Original.Rows[0]["GRPOTaxID"]);
                cbo_tblPur_Tax.SelectedValue = Convert_TaxID_to_TaxValue(taxID);

                txtRemark.Text = tblPur_GRPO_Original.Rows[0]["GRPORemark"].ToString();
                txtStaffName.Text = tblPur_PO_Original.Rows[0]["POUser"].ToString();

                // Datagridview

                dgv_List_Content.DataSource = tblPur_Content;
                View_dgv_List_Content();

                // Disable the all comboboxes
                cbo_tblPur_Supplier.Enabled = false;
                cbo_tblPur_Status.Enabled = false;
            }
        }

        private void View_dgv_List_Content()
        {
            // 1. Hiển thị

            dgv_List_Content.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_List_Content.Columns["UnitPrice"].DefaultCellStyle.Format = "N2";
            dgv_List_Content.Columns["Discount"].DefaultCellStyle.Format = "N2";
            dgv_List_Content.Columns["Total"].DefaultCellStyle.Format = "N2";

            dgv_List_Content.Columns["Qty_Order"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv_List_Content.Columns["Qty_Receipt"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv_List_Content.Columns["Qty_Add"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            // Qty_Add  column is green color
            dgv_List_Content.Columns["Qty_Add"].DefaultCellStyle.BackColor = Color.LightCyan;
            // 2. Cho phép chỉnh sửa các cột
            dgv_List_Content.Columns["PartCode"].ReadOnly = true;
            dgv_List_Content.Columns["PartName"].ReadOnly = true;
            dgv_List_Content.Columns["Qty_Order"].ReadOnly = true;
            dgv_List_Content.Columns["Qty_Receipt"].ReadOnly = true;
            dgv_List_Content.Columns["Qty_Add"].ReadOnly = false;
            dgv_List_Content.Columns["UnitPrice"].ReadOnly = false;
            dgv_List_Content.Columns["Discount"].ReadOnly = false;
            dgv_List_Content.Columns["Total"].ReadOnly = true;
            dgv_List_Content.Columns["Unit"].ReadOnly = true;
            dgv_List_Content.Columns["TaxCode"].ReadOnly = true;
            dgv_List_Content.Columns["RowID"].Visible = false;

            // Đặt Styel cho các cốt
        }

        #endregion ======= 02.FORM EVENTS ========

        //==========================================================
        //==========================================================

        #region ===== 03. BUSINESS LOGIC =======

        private void Calculate_Total()
        {
            _Total_Before_Tax = 0.00m;
            _Total_Discount = 0.00m;
            _Total_Tax = 0.00m;
            _Total_After_Tax = 0.00m;
            if (tblPur_Content.Rows.Count > 0)
            {
                foreach (DataRow row in tblPur_Content.Rows)
                {
                    if (row["UnitPrice"] != DBNull.Value && row["Qty_Receipt"] != DBNull.Value && row["Qty_Add"] != DBNull.Value && row["Discount"] != DBNull.Value)
                    {
                        decimal unitPrice = Convert.ToDecimal(row["UnitPrice"]);
                        // Số lượng nhận = "Qty_Receipt"  + "Qty_Add" (Số lượng cần nhận)
                        int received_quantity = Convert.ToInt32(row["Qty_Receipt"]) + Convert.ToInt32(row["Qty_Add"]);
                        decimal _discount = Convert.ToDecimal(row["Discount"]);
                        decimal total = (unitPrice * received_quantity) * (100 - _discount) / 100;
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
            txtCountRow.Text = tblPur_Content.Rows.Count.ToString();
            Paint_dgv_List_Content(); // Highlight the rows based on the condition
        }

        private bool Check_Content_Items()
        {
            bool isOK = true;

            // Không cho phép 2 PartCode trùng nhau trong tblPur_Content
            HashSet<string> partCodes = new HashSet<string>();
            foreach (DataGridViewRow row in dgv_List_Content.Rows)
            {
                if (row.Cells["PartCode"].Value != null)
                {
                    string partCode = row.Cells["PartCode"].Value.ToString();
                    if (!partCodes.Add(partCode))
                    {
                        MessageBox.Show($"PartCode '{partCode}' is duplicated. Please ensure all PartCodes are unique.", "Duplicate PartCode", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        isOK = false;
                    }
                }
            }

            // Số lượng dòng của tblPur_Content  = tblPur_PO_Detail_Original
            if (tblPur_Content.Rows.Count != tblPur_PO_Detail_Original.Rows.Count)
            {
                MessageBox.Show("Số lượng Items đang bị thiếu trong PO. \n\r Vui lòng điền đủ trước khi update.", "Row Count Mismatch", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                isOK = false;
            }

            // 1. Kiểm tra cột Qty_Add
            // Nếu tất cả bằng 0 => Không update GRPO
            bool allQtyAddZero = true;
            foreach (DataGridViewRow row in dgv_List_Content.Rows)
            {
                if (row.Cells["Qty_Add"].Value != null && Convert.ToInt32(row.Cells["Qty_Add"].Value) > 0)
                {
                    allQtyAddZero = false;
                    break;
                }
            }
            if (allQtyAddZero)
            {
                MessageBox.Show("Cột Qty_Add đang tất cả là 0, nên không cập nhật", "No Items to Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                isOK = false;
            }

            // 2. So sánh cột Qty_Order với (Qty_Receipt + Qty_Add), nếu Qty_Order < (Qty_Receipt + Qty_Add) thì không cho phép cập nhật GRPO
            bool qtyOrderLessThanReceiptAdd = false;
            foreach (DataGridViewRow row in dgv_List_Content.Rows)
            {
                if (row.Cells["Qty_Order"].Value != null && row.Cells["Qty_Receipt"].Value != null && row.Cells["Qty_Add"].Value != null)
                {
                    int qtyOrder = Convert.ToInt32(row.Cells["Qty_Order"].Value);
                    int qtyReceipt = Convert.ToInt32(row.Cells["Qty_Receipt"].Value);
                    int qtyAdd = Convert.ToInt32(row.Cells["Qty_Add"].Value);
                    if (qtyOrder < (qtyReceipt + qtyAdd))
                    {
                        qtyOrderLessThanReceiptAdd = true;
                        break;
                    }
                }
            }
            if (qtyOrderLessThanReceiptAdd)
            {
                Have_Over_Quantity = true;
                MessageBox.Show("Số lượng nhận (Qty_Receipt + Qty_Add) lớn hơn Số lượng đặt hàng (Qty_Order). \r\n Vui lòng kiểm tra lại.", "Quantity Mismatch", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                isOK = false;
            }
            else
            {
                Have_Over_Quantity = false;
            }

            // 3. Kiểu tra PartCode và RowID có khớp nhau không
            if (Have_Other_PartCode == true)
            {
                MessageBox.Show("Xuất hiện PartCode không nằm trong PO. \r\n Vui lòng modify PO nếu muốn nhận mã hàng khác.");
                isOK = false;
            }

            // 4. So sánh Qty_Order  và (Qty_Receipt + Qty_Add) , Nếu bằng nhau thì Full_Quantity_Status = true

            bool allQtyOrderEqualReceiptAdd = true;
            foreach (DataGridViewRow row in dgv_List_Content.Rows)
            {
                if (row.Cells["Qty_Order"].Value != null && row.Cells["Qty_Receipt"].Value != null && row.Cells["Qty_Add"].Value != null)
                {
                    int qtyOrder = Convert.ToInt32(row.Cells["Qty_Order"].Value);
                    int qtyReceipt = Convert.ToInt32(row.Cells["Qty_Receipt"].Value);
                    int qtyAdd = Convert.ToInt32(row.Cells["Qty_Add"].Value);
                    if (qtyOrder != (qtyReceipt + qtyAdd))
                    {
                        allQtyOrderEqualReceiptAdd = false;
                        break;
                    }
                }
            }
            if (allQtyOrderEqualReceiptAdd)
            {
                Full_Quantity_Status = true; // Đóng GRPO nếu tất cả các hàng đều bằng nhau
            }
            else
            {
                Full_Quantity_Status = false; // Không đóng GRPO nếu có hàng không bằng nhau
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

        private void Get_table_GRPO_Existing_GRPO()
        {
            // Clear _tbl_Pur_GROP_Input if it already exists
            if (_tbl_Pur_GRPO_Input != null)
            {
                _tbl_Pur_GRPO_Input.Columns.Clear();
            }

            DataTable _tblPur_GRPO_Update = new DataTable();
            _tblPur_GRPO_Update.Columns.Add("GRPOID", typeof(int));
            _tblPur_GRPO_Update.Columns.Add("GRPONumber", typeof(string));
            _tblPur_GRPO_Update.Columns.Add("PONumber", typeof(string));
            _tblPur_GRPO_Update.Columns.Add("ReceivedDate", typeof(DateTime));
            _tblPur_GRPO_Update.Columns.Add("ReceivedAmount", typeof(decimal));
            _tblPur_GRPO_Update.Columns.Add("GRPORemark", typeof(string));
            _tblPur_GRPO_Update.Columns.Add("GRPOStatusID", typeof(int));
            _tblPur_GRPO_Update.Columns.Add("GRPOCurrencyID", typeof(int));
            _tblPur_GRPO_Update.Columns.Add("GRPOWareHouseID", typeof(int));
            _tblPur_GRPO_Update.Columns.Add("GRPOTaxID", typeof(int));

            DataRow newrow = _tblPur_GRPO_Update.NewRow();
            newrow["GRPOID"] = _GRPOID;
            newrow["GRPONumber"] = txtGRPONumber.Text.Trim();
            newrow["PONumber"] = _PO_Number;
            newrow["ReceivedDate"] = DateTime.Now.Date; // Ngày nhận hàng sẽ là ngày hiện tại
            newrow["ReceivedAmount"] = _Total_After_Tax;
            newrow["GRPORemark"] = txtRemark.Text.Trim();
            newrow["GRPOStatusID"] = Convert.ToInt32(cbo_tblPur_Status.SelectedValue);
            newrow["GRPOCurrencyID"] = Convert.ToInt32(cbo_tblPur_Currency.SelectedValue);
            newrow["GRPOWareHouseID"] = Convert.ToInt32(cbo_tblPur_WareHouse.SelectedValue);
            newrow["GRPOTaxID"] = Convert_TaxValue_to_TaxID(Convert.ToDecimal(cbo_tblPur_Tax.SelectedValue));
            _tblPur_GRPO_Update.Rows.Add(newrow);

            _tbl_Pur_GRPO_Input = _tblPur_GRPO_Update;
        }

        /// <summary>
        /// Lấy dữ liệu từ tblPur_Content và tạo bảng _tblPur_GRPO_Detail_Update để cập nhật GRPO
        /// </summary>
        private void Get_tblPur_GRPO_Detail_Update()
        {
            // Clear _tblPur_GRPO_Detail_Update if it already exists
            if (_tblPur_GRPO_Detail_Update != null)
            {
                _tblPur_GRPO_Detail_Update.Columns.Clear();
            }

            DataTable dt = new DataTable();
            dt.Columns.Add("GRPOID", typeof(int));
            dt.Columns.Add("PODetail_RowID", typeof(int));
            dt.Columns.Add("QuantityReceived", typeof(int));
            dt.Columns.Add("UnitReceivedID", typeof(int));
            dt.Columns.Add("UnitPriceReceived", typeof(decimal));
            dt.Columns.Add("DiscountReceived", typeof(decimal));
            dt.Columns.Add("AmountReceived", typeof(decimal));
            dt.Columns.Add("ExpiredDate", typeof(DateTime)); // ExpiredDate is added to the DataTable

            // Lấy dữ liệu từ tblPur_Content và thêm vào DataTable dt
            foreach (DataRow rw in tblPur_Content.Rows)
            {
                DataRow newRow = dt.NewRow();
                newRow["GRPOID"] = _GRPOID; // Assuming GRPOID is always 1 for this update
                newRow["PODetail_RowID"] = Convert.ToInt32(rw["RowID"]);
                newRow["QuantityReceived"] = Convert.ToInt32(rw["Qty_Receipt"]) + Convert.ToInt32(rw["Qty_Add"]);
                newRow["UnitReceivedID"] = Convert_UnitName_to_UnitID(rw["Unit"].ToString());
                newRow["UnitPriceReceived"] = Convert.ToDecimal(rw["UnitPrice"]);
                newRow["DiscountReceived"] = Convert.ToDecimal(rw["Discount"]);
                newRow["AmountReceived"] = Convert.ToDecimal(rw["Total"]);
                if (rw["ExpiredDate"] != DBNull.Value && string.IsNullOrWhiteSpace(rw["ExpiredDate"].ToString()) == false)
                {
                    newRow["ExpiredDate"] = rw["ExpiredDate"]; // Use the ExpiredDate from the DataRow if it exists
                }

                dt.Rows.Add(newRow);
            }

            _tblPur_GRPO_Detail_Update = dt;

            MessageBox.Show("Số dòng cần update " + _tblPur_GRPO_Detail_Update.Rows.Count.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Lấy dữ liệu để cập nhật vào bảng tblInventory và tblInventory_Summary trong SQL Server.
        /// </summary>
        private void Get_tblInventory_Update()
        {
            if (_tblInventory_Update != null)
            {
                _tblInventory_Update.Columns.Clear();
            }

            DataTable _dt = new DataTable();
            // Inventory_RowID, PartID, PODetail_RowID,SODetail_RowID, UnitID, CreatedDate, ExpiredDate, WareHouseID, Quantity
            _dt.Columns.Add("Inventory_RowID", typeof(int));
            _dt.Columns.Add("PartID", typeof(int));
            _dt.Columns.Add("PODetail_RowID", typeof(int));
            _dt.Columns.Add("SODetail_RowID", typeof(int));
            _dt.Columns.Add("UnitID", typeof(int));
            _dt.Columns.Add("CreatedDate", typeof(DateTime));
            _dt.Columns.Add("ExpiredDate", typeof(DateTime));
            _dt.Columns.Add("WareHouseID", typeof(int));
            _dt.Columns.Add("Quantity", typeof(int));

            // Clear _tblInventory_Summary_Update if it already exists
            if (_tblInventory_Summary_Update != null)
            {
                _tblInventory_Summary_Update.Columns.Clear();
            }
            // // Bước 4 : Tạo bảng tblInventory_Summary
            DataTable _dtSum = new DataTable();
            // PartID, PartName, TaxCode , UnitID, WareHouseID, Quantity_Inventory, UpdatedDate
            _dtSum.Columns.Add("PartID", typeof(int));
            _dtSum.Columns.Add("PartName", typeof(string));
            _dtSum.Columns.Add("TaxCode", typeof(string)); // Assuming TaxCode is a string, adjust as needed
            _dtSum.Columns.Add("UnitID", typeof(int));
            _dtSum.Columns.Add("WareHouseID", typeof(int));
            _dtSum.Columns.Add("Quantity_Inventory", typeof(int));
            _dtSum.Columns.Add("UpdatedDate", typeof(DateTime));

            DataTable _tbl_PartID_PartCode = _purchase_V2_BLL.Select_PartID_PartCode_BLL(_commonBLL.Copy_Single_Column_to_NewTable(tblPur_Content, "PartCode"));

            // Convert _tbl_PartID_PartCode to Dictionary<int, string> for quick lookup
            Dictionary<int, string> _dic_PartID_vs_PartCode = new Dictionary<int, string>();
            foreach (DataRow row in _tbl_PartID_PartCode.Rows)
            {
                if (row["PartID"] != DBNull.Value && row["PartCode"] != DBNull.Value)
                {
                    int partID = Convert.ToInt32(row["PartID"]);
                    string partCode = row["PartCode"].ToString().Trim();
                    if (!_dic_PartID_vs_PartCode.ContainsKey(partID))
                    {
                        _dic_PartID_vs_PartCode[partID] = partCode;
                    }
                }
            }

            // Convert tblPur_Content to Dictionary<int, string> for quick lookup of PartCode by PODetail_RowID
            Dictionary<int, string> _dic_RowID_vs_PartCode = new Dictionary<int, string>();
            foreach (DataRow row in tblPur_Content.Rows)
            {
                if (row["RowID"] != DBNull.Value && row["PartCode"] != DBNull.Value)
                {
                    int podetail_RowID = Convert.ToInt32(row["RowID"]);
                    string partCode = row["PartCode"].ToString().Trim();
                    if (!_dic_RowID_vs_PartCode.ContainsKey(podetail_RowID))
                    {
                        _dic_RowID_vs_PartCode[podetail_RowID] = partCode;
                    }
                }
            }

            int count = _tblPur_GRPO_Detail_Update.Rows.Count;

            // Tạo dữ liệu cho _dt từ _tblPur_GRPO_Detail_Update
            for (int i = 0; i < count; i++)
            {
                DataRow row = _dt.NewRow();
                // Danh sách các cột của _dt
                // Inventory_RowID, PartID, PODetail_RowID, SODetail_RowID, UnitID, CreatedDate, ExpiredDate, WareHouseID, Quantity
                row["Inventory_RowID"] = 0;
                int podetail_RowID = Convert.ToInt32(_tblPur_GRPO_Detail_Update.Rows[i]["PODetail_RowID"]);
                row["PODetail_RowID"] = podetail_RowID; // PODetail_RowID from GRPO Detail
                row["SODetail_RowID"] = DBNull.Value; // Assuming SODetail_RowID is not used in this context
                // Find PartCode using _dic_RowID_vs_PartCode
                string partCode = _dic_RowID_vs_PartCode.ContainsKey(podetail_RowID) ? _dic_RowID_vs_PartCode[podetail_RowID] : string.Empty;
                // Find PartID using _dic_PartID_vs_PartCode
                int partID = _dic_PartID_vs_PartCode.FirstOrDefault(x => x.Value == partCode).Key;
                row["PartID"] = partID; // PartID from PartCode
                row["UnitID"] = _tblPur_GRPO_Detail_Update.Rows[i]["UnitReceivedID"];
                row["CreatedDate"] = DateTime.Now.Date;
                if (row["ExpiredDate"] == DBNull.Value || string.IsNullOrWhiteSpace(row["ExpiredDate"].ToString()))
                {
                    // Do nothing, keep ExpiredDate as DBNull
                }
                else
                {
                    row["ExpiredDate"] = Convert.ToDateTime(_tblPur_GRPO_Detail_Update.Rows[i]["ExpiredDate"]);
                }
                row["WareHouseID"] = Convert.ToInt32(cbo_tblPur_WareHouse.SelectedValue);
                row["Quantity"] = Convert.ToInt32(_tblPur_GRPO_Detail_Update.Rows[i]["QuantityReceived"]);

                // Add the row to the DataTable
                _dt.Rows.Add(row);
            }
            _tblInventory_Update = _dt;

            // Tạo dữ liệu cho_dtSum
            // Danh sách cột của _dtSum
            // PartID, PartName, TaxCode , UnitID, WareHouseID, Quantity_Inventory, UpdatedDate
            DataTable _tblPartCode_PartName = _purchase_V2_BLL.Select_PartCode_PartName_BLL(_commonBLL.Copy_Single_Column_to_NewTable(tblPur_Content, "PartCode"));
            // Tạo Dictionary <string, string> để ánh xạ PartCode với PartName
            Dictionary<string, string> _dic_PartCode_vs_PartName = new Dictionary<string, string>();
            foreach (DataRow row in _tblPartCode_PartName.Rows)
            {
                if (row["PartCode"] != DBNull.Value && row["PartName"] != DBNull.Value)
                {
                    string partCode = row["PartCode"].ToString().Trim();
                    string partName = row["PartName"].ToString().Trim();
                    if (!_dic_PartCode_vs_PartName.ContainsKey(partCode))
                    {
                        _dic_PartCode_vs_PartName[partCode] = partName;
                    }
                }
            }

            // Tạo Dictionary <int, string> để ánh xạ RowID với TaxCode
            Dictionary<int, string> _dic_RowID_vs_TaxCode = new Dictionary<int, string>();
            foreach (DataRow row in tblPur_Content.Rows)
            {
                if (row["RowID"] != DBNull.Value && row["TaxCode"] != DBNull.Value)
                {
                    int podetail_RowID = Convert.ToInt32(row["RowID"]);
                    string taxCode = row["TaxCode"].ToString().Trim();
                    if (!_dic_RowID_vs_TaxCode.ContainsKey(podetail_RowID))
                    {
                        _dic_RowID_vs_TaxCode[podetail_RowID] = taxCode;
                    }
                }
            }

            for (int i = 0; i < count; i++)
            {
                DataRow row = _dtSum.NewRow();
                // Danh sách các cột của _dtSum
                // PartID, PartName, TaxCode , UnitID, WareHouseID, Quantity_Inventory, UpdatedDate
                int podetail_RowID = Convert.ToInt32(_tblPur_GRPO_Detail_Update.Rows[i]["PODetail_RowID"]);
                string partCode = _dic_RowID_vs_PartCode.ContainsKey(podetail_RowID) ? _dic_RowID_vs_PartCode[podetail_RowID] : string.Empty;
                row["PartID"] = _dic_PartID_vs_PartCode.FirstOrDefault(x => x.Value == partCode).Key; // PartID from PartCode
                row["PartName"] = _dic_PartCode_vs_PartName.ContainsKey(partCode) ? _dic_PartCode_vs_PartName[partCode] : string.Empty; // PartName from PartCode
                row["TaxCode"] = _dic_RowID_vs_TaxCode.ContainsKey(podetail_RowID) ? _dic_RowID_vs_TaxCode[podetail_RowID] : string.Empty; // TaxCode from PODetail_RowID
                row["UnitID"] = 1; // Default
                row["WareHouseID"] = Convert.ToInt32(cbo_tblPur_WareHouse.SelectedValue);
                int unitvalue = 1;
                foreach (DataRow unitRow in tblPur_Unit.Rows)
                {
                    if (Convert.ToInt32(unitRow["UnitID"]) == Convert.ToInt32(_tblPur_GRPO_Detail_Update.Rows[i]["UnitReceivedID"]))
                    {
                        unitvalue = Convert.ToInt32(unitRow["UnitValue"]);
                        break;
                    }
                }
                row["Quantity_Inventory"] = Convert.ToInt32(_tblPur_GRPO_Detail_Update.Rows[i]["QuantityReceived"]) * unitvalue; // Quantity_Inventory = QuantityReceived * UnitValue

                row["UpdatedDate"] = DateTime.Now.Date;

                // Add the row to the DataTable
                _dtSum.Rows.Add(row);
            }

            _tblInventory_Summary_Update = _dtSum;
        }

        private void Paint_dgv_List_Content()
        {
            // Resert all row colors to default
            foreach (DataGridViewRow row in dgv_List_Content.Rows)
            {
                row.DefaultCellStyle.BackColor = Color.White; // Reset to default color
            }

            // If QuantityOrder = Quantity_Rceipt + Quantity_Add,
            foreach (DataGridViewRow row in dgv_List_Content.Rows)
            {
                if (row.Cells["Qty_Order"].Value != null && row.Cells["Qty_Receipt"].Value != null && row.Cells["Qty_Add"].Value != null)
                {
                    int qtyOrder = Convert.ToInt32(row.Cells["Qty_Order"].Value);
                    int qtyReceipt = Convert.ToInt32(row.Cells["Qty_Receipt"].Value);
                    int qtyAdd = Convert.ToInt32(row.Cells["Qty_Add"].Value);
                    if (qtyOrder == (qtyReceipt + qtyAdd))
                    {
                        row.DefaultCellStyle.BackColor = Color.LightGreen; // Highlight the row in green
                        row.Cells["Qty_Order"].Style.BackColor = Color.LightGreen;
                    }
                    else if (qtyOrder < (qtyReceipt + qtyAdd))
                    {
                        row.DefaultCellStyle.BackColor = Color.Red; // Highlight the row in red
                        row.Cells["Qty_Order"].Style.BackColor = Color.Red;
                    }
                    else if (qtyOrder > (qtyReceipt + qtyAdd))
                    {
                        row.Cells["Qty_Order"].Style.BackColor = Color.DodgerBlue;
                    }
                }
            }

            // Kiểm tra dãy tương ứng của PartCode và RowID , cần phải khớp nhau.
            // Nếu PartCode không khớp với RowID thì tô màu vàng cho ô PartCode

            Have_Other_PartCode = false; // Reset the flag

            // Tạo 1 Dictionary để ánh xạ RowID với PartCode
            Dictionary<int, string> partCodeToRowIDMap = new Dictionary<int, string>();
            foreach (DataRow rw in tblPur_PO_Detail_Original.Rows)
            {
                if (rw["RowID"] != DBNull.Value && rw["PartCode"] != DBNull.Value)
                {
                    int rowID = Convert.ToInt32(rw["RowID"]);
                    string partCode = rw["PartCode"].ToString();
                    if (!partCodeToRowIDMap.ContainsKey(rowID))
                    {
                        partCodeToRowIDMap.Add(rowID, partCode);
                    }
                }
            }

            // Kiểm tra PartCode trong DataGridView với ánh xạ RowID
            foreach (DataGridViewRow row in dgv_List_Content.Rows)
            {
                if (row.Cells["RowID"].Value != null && row.Cells["PartCode"].Value != null)
                {
                    int rowID = Convert.ToInt32(row.Cells["RowID"].Value);
                    string partCode = row.Cells["PartCode"].Value.ToString();
                    // Kiểm tra ánh xạ
                    if (partCodeToRowIDMap.ContainsKey(rowID) && partCodeToRowIDMap[rowID] != partCode)
                    {
                        row.Cells["PartCode"].Style.BackColor = Color.Yellow; // Highlight the PartCode cell in yellow
                        Have_Other_PartCode = true; // Nếu có
                    }
                }
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
                    // Nếu chỉ có 1 cột trong clipboard
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
                Calculate_Total();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi dán dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Refresh_Data()
        {
            tblPur_Content.Columns.Clear();
            tblPur_Content = tblPur_Reset.Copy();
            dgv_List_Content.DataSource = tblPur_Content;
            View_dgv_List_Content();
            Calculate_Total();
        }

        #endregion ===== 03. BUSINESS LOGIC =======

        //==========================================================
        //==========================================================

        #region ===== 04.CONTROL EVENTS =======

        private void btn_Update_GRPO_Click(object sender, EventArgs e)
        {
            Get_table_GRPO_Existing_GRPO();

            if (Check_Content_Items() == false)
            {
                return;
            }

            Get_tblPur_GRPO_Detail_Update();

            Get_tblInventory_Update();

            MessageBox.Show("Dừng ở đây thôi");

            if (Full_Quantity_Status == true)
            {
                string message = "Số lượng nhận đã đủ. \r\n Bạn có muốn đóng GPRO này không ?";
                string caption = "Close GRPO Confirmation";
                DialogResult result = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    _tbl_Pur_GRPO_Input.Rows[0]["GRPOStatusID"] = 2;
                    _tbl_Pur_GRPO_Input.Rows[0]["GRPORemark"] = _tbl_Pur_GRPO_Input.Rows[0]["GRPORemark"].ToString() + " - Closed on " + DateTime.Now.ToString("dd/MM/yyyy");
                    if (_purchase_V2_BLL.Update_Existing_GRPO_BLL(_tbl_Pur_GRPO_Input, _tblPur_GRPO_Detail_Update, _tblInventory_Update, _tblInventory_Summary_Update) == true)
                    {
                        MessageBox.Show("Cập nhật GRPO thành công và đã đóng.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (_purchase_V2_BLL.Closed_Existing_PO_BLL(_PO_Number) == true)
                        {
                            MessageBox.Show("Đóng PO thành công.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Đóng PO thất bại.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật GRPO thất bại.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    if (_purchase_V2_BLL.Update_Existing_GRPO_BLL(_tbl_Pur_GRPO_Input, _tblPur_GRPO_Detail_Update, _tblInventory_Update, _tblInventory_Summary_Update) == true)
                    {
                        MessageBox.Show("Cập nhật GRPO thành công.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật GRPO thất bại.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {    // Nếu chưa Full
                string message = "Bạn có muốn cập nhật GRPO này không?";
                string caption = "Update GRPO Confirmation";
                DialogResult result = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (_purchase_V2_BLL.Update_Existing_GRPO_BLL(_tbl_Pur_GRPO_Input, _tblPur_GRPO_Detail_Update, _tblInventory_Update, _tblInventory_Summary_Update) == true)
                    {
                        MessageBox.Show("Cập nhật GRPO thành công.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK; // Set the dialog result to OK
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật GRPO thất bại.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            string message = "Are you sure you want to cancel? All changes will be lost.";
            string caption = "Cancel Update";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, caption, buttons, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnModify_This_PO_Click(object sender, EventArgs e)
        {
            string message = "Do you want to modify this Purchase Order?";
            string title = "Modify Purchase Order";
            DialogResult result = MessageBox.Show(message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                frmModify_PO frm = new frmModify_PO();
                frm._poNumber = _PO_Number;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    this.Close();
                }
            }
        }

        private void cbo_tblPur_Currency_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (is_Loading_form == false)
            {
                return;
            }

            string message = "Do you want to change the currency for all items?";
            string title = "Change Currency";
            DialogResult result = MessageBox.Show(message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                string currencyValue = Convert_CurrencyID_to_CurrencyName(cbo_tblPur_Currency.SelectedIndex + 1);
                lblCurrencyA.Text = currencyValue;
                lblCurrencyC.Text = currencyValue;
                lblCurrencyD.Text = currencyValue;
            }
            else
            {
                // If user selects No, revert the selection to the previous value
                cbo_tblPur_Currency.SelectedValue = tblPur_GRPO_Original.Rows[0]["GRPOCurrencyID"];
            }
        }

        private void cbo_tblPur_Tax_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (is_Loading_form == false)
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
                return;
            }

            string message = "Do you want to change the tax rate for all items?";
            string title = "Change Tax Rate";
            DialogResult result = MessageBox.Show(message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
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
            else
            {
                // If user selects No, revert the selection to the previous value
                cbo_tblPur_Tax.SelectedValue = tblPur_GRPO_Original.Rows[0]["GRPOTaxID"];
            }
        }

        private void cbo_tblPur_WareHouse_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (is_Loading_form == false)
            {
                return;
            }

            string message = "Do you want to change the  Warehouse Location ?";
            string title = "Change Warehouse";
            DialogResult result = MessageBox.Show(message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
            }
            else
            {
                cbo_tblPur_WareHouse.SelectedValue = tblPur_GRPO_Original.Rows[0]["GRPOWareHouseID"];
            }
        }

        private void cms_dgv_List_Content_Change_Unit_Items_Click(object sender, EventArgs e)
        {
            using (frm_Choose_Unit frm = new frm_Choose_Unit())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    int selectedUnitID = Convert.ToInt32(frm.SelectedUnitID);
                    string selectedUnitName = frm.SelectedUnitName;
                    foreach (DataGridViewCell cell in dgv_List_Content.SelectedCells)
                    {
                        int rowIndex = cell.RowIndex;

                        if (!dgv_List_Content.Rows[rowIndex].IsNewRow)
                        {
                            dgv_List_Content.Rows[rowIndex].Cells["Unit"].Value = selectedUnitName;
                        }
                    }
                    MessageBox.Show("Unit updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
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

        private void cms_dgv_List_Content_Open_Part_Feature_Click(object sender, EventArgs e)
        {
            if (dgv_List_Content.Rows.Count > 0)
            {
                frmRelationPart_Detail_Info frm = new frmRelationPart_Detail_Info();
                string partcode = dgv_List_Content.CurrentRow.Cells["PartCode"].Value.ToString();
                frm.ShowDetailInfor(partcode);
                frm.ShowDialog();
            }
        }

        private void cms_dgv_List_Content_Paste_Data_Click(object sender, EventArgs e)
        {
        }

        private void cms_dgv_List_Content_Reset_Original_Data_Click(object sender, EventArgs e)
        {
            string message = "Do you want to reset the content to the original data?";
            string title = "Reset Content";
            DialogResult result = MessageBox.Show(message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Refresh_Data();
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

        private void dgv_List_Content_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_List_Content.Columns[e.ColumnIndex].Name == "Qty_Receipt" || dgv_List_Content.Columns[e.ColumnIndex].Name == "Qty_Add" || dgv_List_Content.Columns[e.ColumnIndex].Name == "UnitPrice" || dgv_List_Content.Columns[e.ColumnIndex].Name == "Discount")
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

        #endregion ===== 04.CONTROL EVENTS =======

        private void cms_dgv_List_Content_Delete_This_GRPO_Click(object sender, EventArgs e)
        {
            string message = "Do you want to delete this GRPO? This action cannot be undone.";
            string title = "Delete GRPO Confirmation";
            DialogResult result = MessageBox.Show(message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                // Update StatusID in GRPO is Canceled (StatusID = 3)
                if (_purchase_V2_BLL.Cancelation_Existing_GRPO_BLL(_GRPOID) == true)
                {
                    MessageBox.Show("GRPO has been successfully canceled.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK; // Set the dialog result to OK
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Failed to cancel GRPO. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cms_dgv_List_Content_Closed_This_GRPO_Click(object sender, EventArgs e)
        {
            string message = "Bạn có muốn đóng GRPO không ? \r\n Sau khi đóng, bạn sẽ không thể chỉnh sửa GRPO này nữa.";
            message += "\r\n Lưu ý, khi đã đóng GRPO thì PO cũng sẽ tự động closed ";
            string title = "Close GRPO Confirmation";
            DialogResult result = MessageBox.Show(message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                // Update StatusID in GRPO is Closed (StatusID = 2)
                if (_purchase_V2_BLL.Closed_Existing_GRPO_BLL(_GRPO_Number) == true && _purchase_V2_BLL.Closed_Existing_PO_BLL(_PO_Number) == true)
                {
                    MessageBox.Show("GRPO has been successfully closed.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK; // Set the dialog result to OK
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Failed to close GRPO. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}