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
    public partial class frm_Make_New_APInvoice : Form
    {
        // Tạo các region chia các các phầ của code để dễ quản lý

        #region ===== 01. Khai báo biến toàn cục =====

        private Purchase_V2_BLL _purchase_V2_BLL = new Purchase_V2_BLL();
        private CommonBLL _commonBLL = new CommonBLL();
        public int GRPONumber { get; set; }

        // 1.1 Các bảng dùng chung
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

        // 1.2 Local variables
        private decimal _Total_After_Tax = 0.00m;

        private decimal _Total_Before_Tax = 0.00m;

        private decimal _Total_Discount = 0.00m;

        private decimal _Total_Tax = 0.00m;

        private bool Have_Other_PartCode = false; // Biến kiểm tra xem có PartCode khác với RowID hay không
        private bool is_Loading_form = false; // Biến kiểm tra xem form có đang được load hay không, để tránh việc gọi lại các sự kiện không cần thiết khi load form
        private bool Payment_Full_Quantity = false;

        /// <summary>
        /// Các biến chung của GRPO : GRPOID, GRPONumber, PONumber, ReceivedDate , GRPORemark, GRPOCurrencyID, GRPOWareHouseID, GRPOTaxID
        /// </summary>
        private int _GRPOID;

        private int _GRPONumber;
        private int _PONumber;
        private DateTime _ReceivedDate;
        private string _GRPORemark;
        private int _GRPOCurrencyID;
        private int _GRPOWareHouseID;
        private int _GRPOTaxID;
        private Dictionary<int, string> _dic_RowID_vs_PartCode = new Dictionary<int, string>(); // Lưu ánh xạ RowID với PartCode

        /// <summary>
        /// Return Table (PartCode, PartName, Qty_Received, Qty_Payment, UnitPrice, Discount, Total, Unit, RowID )
        /// </summary>
        private DataTable tblPur_Content = new DataTable();

        private DataTable _tblPur_Content_Reset = new DataTable();

        #endregion ===== 01. Khai báo biến toàn cục =====

        #region ===== 02. Khởi tạo form =====

        private void Create_tblPur_Content()
        {
            tblPur_Content.Columns.Add("PartCode", typeof(string));
            tblPur_Content.Columns.Add("PartName", typeof(string));
            tblPur_Content.Columns.Add("Qty_Received", typeof(int));
            tblPur_Content.Columns.Add("Qty_Payment", typeof(int));
            tblPur_Content.Columns.Add("UnitPrice", typeof(decimal));
            tblPur_Content.Columns.Add("Discount", typeof(decimal));
            tblPur_Content.Columns.Add("Total", typeof(decimal));
            tblPur_Content.Columns.Add("Unit", typeof(string)); // UnitName
            tblPur_Content.Columns.Add("TaxCode", typeof(string)); // TaxCode
            tblPur_Content.Columns.Add("RowID", typeof(int));
        }

        public frm_Make_New_APInvoice()
        {
            InitializeComponent();
            Load_Common_Information();
            Create_tblPur_Content();
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

        private void frm_Make_New_APInvoice_Load(object sender, EventArgs e)
        {
            Load_this_APInvoice_Information();

            dgv_List_Content.DataSource = tblPur_Content;
            Calculate_Total();
            View_dgv_List_Content();
            is_Loading_form = true;
        }

        private void Load_this_APInvoice_Information()
        {
            // 1. Lấy thông tin của APInvoice từ GRPO
            if (GRPONumber > 0)
            {
                // 1.0 Lấy thông tin của GRPO từ GRPONumber
                DataTable _tblThis_GRPO = _purchase_V2_BLL.Select_tblPur_GRPO_by_GRPONumber_BLL(GRPONumber);
                if (_tblThis_GRPO != null && _tblThis_GRPO.Rows.Count > 0)
                {
                    // 1.1 Lấy thông tin của GRPO
                    _GRPOID = Convert.ToInt32(_tblThis_GRPO.Rows[0]["GRPOID"]);
                    _GRPONumber = Convert.ToInt32(_tblThis_GRPO.Rows[0]["GRPONumber"]);
                    _PONumber = Convert.ToInt32(_tblThis_GRPO.Rows[0]["PONumber"]);
                    _ReceivedDate = Convert.ToDateTime(_tblThis_GRPO.Rows[0]["ReceivedDate"]);
                    _GRPORemark = _tblThis_GRPO.Rows[0]["GRPORemark"].ToString();
                    _GRPOCurrencyID = Convert.ToInt32(_tblThis_GRPO.Rows[0]["GRPOCurrencyID"]);
                    _GRPOWareHouseID = Convert.ToInt32(_tblThis_GRPO.Rows[0]["GRPOWareHouseID"]);
                    _GRPOTaxID = Convert.ToInt32(_tblThis_GRPO.Rows[0]["GRPOTaxID"]);
                    // 1.2 Hiển thị các thông tin lên các control
                    dtpReceived_Date.Value = _ReceivedDate;
                    dtpPostingDate.Value = DateTime.Now;
                    dtpCreatingDate.Value = DateTime.Now;
                    cbo_tblPur_WareHouse.SelectedValue = _GRPOWareHouseID;
                    cbo_tblPur_Currency.SelectedValue = _GRPOCurrencyID;
                    cbo_tblPur_Tax.SelectedValue = Convert_TaxID_to_TaxValue(_GRPOTaxID);
                    cbo_tblPur_Status.SelectedValue = 1; // Default status is "Opened"

                    DataTable _tblThisPO = _purchase_V2_BLL.Select_tblPur_PO_by_PONumber_BLL(_PONumber);
                    if (_tblThisPO.Rows.Count > 0)
                    {
                        cbo_tblPur_Supplier.SelectedValue = _tblThisPO.Rows[0]["POSupplierID"];
                        cboSupplierContactPerson.Text = _tblThisPO.Rows[0]["POSupplierContactPerson"].ToString();
                    }

                    txtRemark.Text = _GRPORemark;
                    txtTax.Text = Convert.ToDecimal(cbo_tblPur_Tax.SelectedValue).ToString("N2");
                    lblCurrencyA.Text = cbo_tblPur_Currency.Text;
                    lblCurrencyC.Text = cbo_tblPur_Currency.Text;
                    lblCurrencyD.Text = cbo_tblPur_Currency.Text;
                    cbo_tblPur_Supplier.Enabled = false; // Khóa lại lựa chọn nhà cung cấp
                    cbo_tblPur_Status.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy thông tin của GRPO. Vui lòng kiểm tra lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Close();
                }
                DataTable _tblThis_GRPO_Detail = _purchase_V2_BLL.Select_tblPur_GRPO_Detail_by_GRPONumber_BLL(GRPONumber);
                foreach (DataRow row in _tblThis_GRPO_Detail.Rows)
                {
                    // 1.3 Thêm các dòng vào bảng _tblPur_Content
                    DataRow newRow = tblPur_Content.NewRow();
                    newRow["PartCode"] = row["PartCode"];
                    newRow["PartName"] = row["PartName"];
                    newRow["Qty_Received"] = Convert.ToInt32(row["QuantityReceived"]);
                    newRow["Qty_Payment"] = 0; // Default
                    newRow["UnitPrice"] = Convert.ToDecimal(row["UnitPriceReceived"]);
                    newRow["Discount"] = Convert.ToDecimal(row["DiscountReceived"]);
                    newRow["TaxCode"] = row["TaxCode"];
                    newRow["Unit"] = row["UnitName"];
                    newRow["RowID"] = Convert.ToInt32(row["PODetail_RowID"]);
                    tblPur_Content.Rows.Add(newRow);
                }

                // 1.4 Lưu ánh xạ RowID với PartCode
                _dic_RowID_vs_PartCode.Clear(); // Reset the dictionary
                foreach (DataRow rw in _tblThis_GRPO_Detail.Rows)
                {
                    if (rw["PODetail_RowID"] != DBNull.Value && rw["PartCode"] != DBNull.Value)
                    {
                        int rowID = Convert.ToInt32(rw["PODetail_RowID"]);
                        string partCode = rw["PartCode"].ToString();
                        if (!_dic_RowID_vs_PartCode.ContainsKey(rowID))
                        {
                            _dic_RowID_vs_PartCode.Add(rowID, partCode);
                        }
                    }
                }

                // Copy để backup
                _tblPur_Content_Reset = tblPur_Content.Copy();
            }
            else
            {
                MessageBox.Show("Không tìm thấy thông tin của GRPO. Vui lòng kiểm tra lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
            }
        }

        private void View_dgv_List_Content()
        {
            // 1. Hiển thị

            dgv_List_Content.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_List_Content.Columns["UnitPrice"].DefaultCellStyle.Format = "N2";
            dgv_List_Content.Columns["Discount"].DefaultCellStyle.Format = "N2";
            dgv_List_Content.Columns["Total"].DefaultCellStyle.Format = "N2";

            dgv_List_Content.Columns["Qty_Received"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv_List_Content.Columns["Qty_Payment"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            // Qty_Add  column is green color
            dgv_List_Content.Columns["Qty_Payment"].DefaultCellStyle.BackColor = Color.LightCyan;
            // 2. Cho phép chỉnh sửa các cột
            dgv_List_Content.Columns["PartCode"].ReadOnly = true;
            dgv_List_Content.Columns["PartName"].ReadOnly = true;
            dgv_List_Content.Columns["Qty_Received"].ReadOnly = true;
            dgv_List_Content.Columns["Qty_Payment"].ReadOnly = false;
            dgv_List_Content.Columns["UnitPrice"].ReadOnly = false;
            dgv_List_Content.Columns["Discount"].ReadOnly = false;
            dgv_List_Content.Columns["Total"].ReadOnly = true;
            dgv_List_Content.Columns["Unit"].ReadOnly = true;
            dgv_List_Content.Columns["TaxCode"].ReadOnly = true;
            dgv_List_Content.Columns["RowID"].Visible = false;

            // Đặt Styel cho các cốt
        }

        #endregion ===== 02. Khởi tạo form =====

        #region ===== 03. Xử lý logic của của các events =====

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
                    if (row["UnitPrice"] != DBNull.Value && row["Qty_Received"] != DBNull.Value && row["Qty_Payment"] != DBNull.Value && row["Discount"] != DBNull.Value)
                    {
                        decimal unitPrice = Convert.ToDecimal(row["UnitPrice"]);
                        // Số lượng nhận = "Qty_Receipt"  + "Qty_Add" (Số lượng cần nhận)
                        int quantity = Convert.ToInt32(row["Qty_Payment"]);
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
            txtCountRow.Text = tblPur_Content.Rows.Count.ToString();
            Paint_dgv_List_Content(); // Highlight the rows based on the condition
        }

        private void Paint_dgv_List_Content()
        {
            // Resert all row colors to default
            foreach (DataGridViewRow row in dgv_List_Content.Rows)
            {
                row.DefaultCellStyle.BackColor = Color.White; // Reset to default color
            }

            // Nếu bằng nhau : Màu LightGreen, Nếu ít hơn số lượng nhận : Màu đỏ, Nếu lớn hơn số lượng nhận : Màu DodgerBlue
            foreach (DataGridViewRow row in dgv_List_Content.Rows)
            {
                if (row.Cells["Qty_Received"].Value != null && row.Cells["Qty_Payment"].Value != null)
                {
                    int qty_Received = Convert.ToInt32(row.Cells["Qty_Received"].Value);
                    int qty_Payment = Convert.ToInt32(row.Cells["Qty_Payment"].Value);

                    if (qty_Payment == qty_Received)
                    {
                        row.DefaultCellStyle.BackColor = Color.LightGreen; // Highlight the row in green
                        row.Cells["Qty_Payment"].Style.BackColor = Color.LightGreen;
                    }
                    else if (qty_Payment > qty_Received)
                    {
                        row.DefaultCellStyle.BackColor = Color.Red; // Highlight the row in red
                        row.Cells["Qty_Payment"].Style.BackColor = Color.Red;
                    }
                    else if (qty_Payment < qty_Received)
                    {
                        row.Cells["Qty_Payment"].Style.BackColor = Color.DodgerBlue;
                    }
                }
            }

            // Kiểm tra dãy tương ứng của PartCode và RowID , cần phải khớp nhau.
            // Nếu PartCode không khớp với RowID thì tô màu vàng cho ô PartCode

            Have_Other_PartCode = false; // Reset the flag

            // Kiểm tra PartCode trong DataGridView với ánh xạ RowID
            foreach (DataGridViewRow row in dgv_List_Content.Rows)
            {
                if (row.Cells["RowID"].Value != null && row.Cells["PartCode"].Value != null)
                {
                    int rowID = Convert.ToInt32(row.Cells["RowID"].Value);
                    string partCode = row.Cells["PartCode"].Value.ToString();
                    // Kiểm tra ánh xạ
                    if (_dic_RowID_vs_PartCode.ContainsKey(rowID) && _dic_RowID_vs_PartCode[rowID] != partCode)
                    {
                        row.Cells["PartCode"].Style.BackColor = Color.Yellow; // Highlight the PartCode cell in yellow
                        Have_Other_PartCode = true; // Nếu có
                    }
                }
            }
        }

        private void Refresh_Data()
        {
            tblPur_Content.Columns.Clear();
            tblPur_Content = _tblPur_Content_Reset.Copy();
            dgv_List_Content.DataSource = tblPur_Content;
            View_dgv_List_Content();
            Calculate_Total();
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

                if (tbl_ClipBoard.Columns.Count != 1)
                {
                    MessageBox.Show("Chỉ nhận 1 cột dữ liệu để copy"); return;
                }

                // Kiểm tra current column của datagrid view có phải là Qty_Payment hay không ?
                // Chỉ cho phép dán vào cột Qty_Payment
                if (dgv_List_Content.CurrentCell == null || dgv_List_Content.CurrentCell.OwningColumn.Name != "Qty_Payment")
                {
                    MessageBox.Show("Cột đang chọn không phải là cột Qty_Payment", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Bắt đầu dán dữ liệu từ tbl_ClipBoard vào dgv_List_Content
                int currentRowIndex = dgv_List_Content.CurrentCell.RowIndex;
                int currentColumnIndex = dgv_List_Content.CurrentCell.ColumnIndex;
                foreach (DataRow row in tbl_ClipBoard.Rows)
                {
                    if (currentRowIndex < tblPur_Content.Rows.Count)
                    {
                        // Update existing row
                        tblPur_Content.Rows[currentRowIndex]["Qty_Payment"] = row[0];
                    }
                    else
                    {
                        // Add new row if currentRowIndex exceeds existing rows
                        DataRow newRow = tblPur_Content.NewRow();
                        newRow["Qty_Payment"] = row[0];
                        tblPur_Content.Rows.Add(newRow);
                    }
                    currentRowIndex++;
                }

                //if (tbl_ClipBoard.Columns.Count > 1 && tbl_ClipBoard != null)
                //{
                //    _commonBLL.Insert_data_to_Datatable(tbl_ClipBoard, tblPur_Content);
                //}
                //else
                //{
                //    // Nếu chỉ có 1 cột trong clipboard
                //    if (tbl_ClipBoard == null)
                //    {
                //        MessageBox.Show("Clipboard data is not valid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //        return;
                //    }

                //    // Don't allow to paste "RowID" column , if Current Column is "RowID" => Dont paste
                //    if (dgv_List_Content.CurrentCell != null && dgv_List_Content.CurrentCell.OwningColumn.Name == "RowID")
                //    {
                //        MessageBox.Show("Cannot paste data into RowID column.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //        return;
                //    }

                //    if (tbl_ClipBoard.Columns.Contains("RowID"))
                //    {
                //        tbl_ClipBoard.Columns.Remove("RowID");
                //    }
                //    else
                //    {
                //        int currentRowIndex = dgv_List_Content.CurrentCell == null ? 0 : dgv_List_Content.CurrentCell.RowIndex;

                //        int currentColumnIndex = dgv_List_Content.CurrentCell == null ? 0 : dgv_List_Content.CurrentCell.ColumnIndex;

                //        foreach (DataRow row in tbl_ClipBoard.Rows)
                //        {
                //            if (currentRowIndex < tblPur_Content.Rows.Count)
                //            {
                //                // Update existing row
                //                tblPur_Content.Rows[currentRowIndex][currentColumnIndex] = row[0];
                //            }
                //            else
                //            {
                //                // Add new row if currentRowIndex exceeds existing rows
                //                DataRow newRow = tblPur_Content.NewRow();
                //                newRow[currentColumnIndex] = row[0];
                //                tblPur_Content.Rows.Add(newRow);
                //            }
                //            currentRowIndex++;
                //        }
                //    }
                //}

                dgv_List_Content.Refresh();
                Calculate_Total();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi dán dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion ===== 03. Xử lý logic của của các events =====

        #region ===== 04. Xử lý sự kiện của các control =====

        private void btnCancel_Click(object sender, EventArgs e)
        {
            string message = "Bạn có chắc chắn muốn hủy không?";
            string title = "Xác nhận hủy bỏ";
            DialogResult result = MessageBox.Show(message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
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
                cbo_tblPur_Currency.SelectedValue = _GRPOCurrencyID;
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
                cbo_tblPur_Tax.SelectedValue = Convert_TaxID_to_TaxValue(_GRPOTaxID);
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
                cbo_tblPur_WareHouse.SelectedValue = _GRPOWareHouseID;
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

        private void dgv_List_Content_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_List_Content.Columns[e.ColumnIndex].Name == "Qty_Payment" || dgv_List_Content.Columns[e.ColumnIndex].Name == "UnitPrice" || dgv_List_Content.Columns[e.ColumnIndex].Name == "Discount")
            {
                Calculate_Total();
                Check_tblPur_Content();
                if (Payment_Full_Quantity == true)
                {
                    MessageBox.Show("Tất cả các mặt hàng đã được thanh toán đầy đủ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Không cho phép thay đổi giá trị các cột khác ngoài Qty_Payment, UnitPrice và Discount.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void dgv_List_Content_KeyDown(object sender, KeyEventArgs e)
        {
            // Ctrl + V to paste data from clipboard
            if (e.Control && e.KeyCode == Keys.V)
            {
                PasteClipboardToGrid();
            }
        }

        private void cms_dgv_List_Content_Paste_Data_Click(object sender, EventArgs e)
        {
            PasteClipboardToGrid();
        }

        #endregion ===== 04. Xử lý sự kiện của các control =====

        private void btn_Add_New_APInvoice_Click(object sender, EventArgs e)
        {
            string message = "Do you want to create a new AP Invoice?";
            string title = "Create New AP Invoice";
            DialogResult result = MessageBox.Show(message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Insert_New_APInvoice();
            }
            else
            {
                // Nếu người dùng chọn No, không làm gì cả
                return;
            }
        }

        private void Insert_New_APInvoice()
        {
             // Bước 1 : Kiểm tra dữ liệu đầu vào
            if(Check_tblPur_Content() == false)
            {
                //MessageBox.Show("Dữ liệu không hợp lệ. Vui lòng kiểm tra lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if(Payment_Full_Quantity == false)
            {
                string message = "Số lượng thanh toán không bằng số lượng nhận. Bạn có muốn tiếp tục không?";
                string title = "Xác nhận thanh toán";
                DialogResult result = MessageBox.Show(message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                {
                    return; // Nếu người dùng chọn No, không làm gì cả
                }
            }    



            // Bước 2 : Tạo bảng _tblAPInvoice
            // APInvoiceID, GRPOID, PONumber, APInvoice_SupplierID, CreatedDate, UpdatedDate, APInvoice_TotalPayment,
            // APInvoice_Remark, APInvoice_StatusID, APInvoice_CurrencyID, APInvoice_TaxID
            DataTable _tblAPInvoice = new DataTable();
            _tblAPInvoice.Columns.Add("APInvoiceID", typeof(int)); // Tự động tăng
            _tblAPInvoice.Columns.Add("GRPOID", typeof(int)); // Khóa ngoại từ GRPO
            _tblAPInvoice.Columns.Add("PONumber", typeof(int)); // Khóa ngoại từ PO
            _tblAPInvoice.Columns.Add("APInvoice_SupplierID", typeof(int)); 
            _tblAPInvoice.Columns.Add("CreatedDate", typeof(DateTime)); // Ngày tạo
            _tblAPInvoice.Columns.Add("UpdatedDate", typeof(DateTime)); // Ngày cập nhật
            _tblAPInvoice.Columns.Add("APInvoice_TotalPayment", typeof(decimal)); // Tổng tiền thanh toán
            _tblAPInvoice.Columns.Add("APInvoice_Remark", typeof(string)); // Ghi chú
            _tblAPInvoice.Columns.Add("APInvoice_StatusID", typeof(int)); // Trạng thái (1: Mở, 2: Đã thanh toán, 3: Đã hủy)
            _tblAPInvoice.Columns.Add("APInvoice_CurrencyID", typeof(int)); // Khóa ngoại từ Currency
            _tblAPInvoice.Columns.Add("APInvoice_TaxID", typeof(int)); // Khóa ngoại từ Tax

            DataRow dtrw = _tblAPInvoice.NewRow();
            dtrw["APInvoiceID"] = 0; 
            dtrw["GRPOID"] = _GRPOID; 
            dtrw["PONumber"] = _PONumber;
            dtrw["APInvoice_SupplierID"] = cbo_tblPur_Supplier.SelectedValue; 
            dtrw["CreatedDate"] = dtpCreatingDate.Value; // Ngày tạo
            dtrw["UpdatedDate"] = dtpPostingDate.Value; // 
            dtrw["APInvoice_TotalPayment"] = _Total_After_Tax; // Tổng tiền thanh toán
            dtrw["APInvoice_Remark"] = txtRemark.Text; // Ghi chú
            dtrw["APInvoice_StatusID"] = cbo_tblPur_Status.SelectedValue;
            dtrw["APInvoice_CurrencyID"] = cbo_tblPur_Currency.SelectedValue; 
            dtrw["APInvoice_TaxID"] = Convert_TaxValue_to_TaxID(Convert.ToDecimal(txtTax.Text)); 
            
            _tblAPInvoice.Rows.Add(dtrw);


            // Bước 3 : Tạo bảng _tblAPInvoice_Detail
            DataTable _tblAPInvoice_Detail = new DataTable();
            // APInvoiceID, PODetail_RowID, APInvoice_Quantity, APInvoice_UnitPrice, APInvoice_UnitID, APInvoice_Discount, APInvoice_TotalPayment, APInvoice_PaymentDate
            _tblAPInvoice_Detail.Columns.Add("APInvoiceID", typeof(int)); 
            _tblAPInvoice_Detail.Columns.Add("PODetail_RowID", typeof(int)); 
            _tblAPInvoice_Detail.Columns.Add("APInvoice_Quantity", typeof(int)); 
            _tblAPInvoice_Detail.Columns.Add("APInvoice_UnitPrice", typeof(decimal)); 
            _tblAPInvoice_Detail.Columns.Add("APInvoice_UnitID", typeof(int)); 
            _tblAPInvoice_Detail.Columns.Add("APInvoice_Discount", typeof(decimal)); 
            _tblAPInvoice_Detail.Columns.Add("APInvoice_TotalPayment", typeof(decimal)); 
            _tblAPInvoice_Detail.Columns.Add("APInvoice_PaymentDate", typeof(DateTime));
            
            foreach (DataRow row in tblPur_Content.Rows)
            {
                DataRow newRow = _tblAPInvoice_Detail.NewRow();
                newRow["APInvoiceID"] = 0; // Sẽ được cập nhật sau khi insert
                newRow["PODetail_RowID"] = Convert.ToInt32(row["RowID"]);
                newRow["APInvoice_Quantity"] = Convert.ToInt32(row["Qty_Payment"]);
                newRow["APInvoice_UnitPrice"] = Convert.ToDecimal(row["UnitPrice"]);
                newRow["APInvoice_UnitID"] = Convert_UnitName_to_UnitID(row["Unit"].ToString());
                newRow["APInvoice_Discount"] = Convert.ToDecimal(row["Discount"]);
                newRow["APInvoice_TotalPayment"] = Convert.ToDecimal(row["Total"]);
                newRow["APInvoice_PaymentDate"] = dtpPostingDate.Value; // Ngày thanh toán
                
                _tblAPInvoice_Detail.Rows.Add(newRow);
            }

            // Bước 4 : Thực hiện insert vào cơ sở dữ liệu
            if(_purchase_V2_BLL.Insert_New_APInvoice_BLL(_tblAPInvoice, _tblAPInvoice_Detail))
            {
                MessageBox.Show("Tạo mới AP Invoice thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close(); // Đóng form sau khi tạo thành công
            }
            else
            {
                MessageBox.Show("Lỗi khi tạo mới AP Invoice. Vui lòng kiểm tra lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private bool  Check_tblPur_Content()
        {
            bool isOK = true;
            // Bước 1 : Kiểm tra cột "Qty_Payment" không được để trống hoặc <= 0
            foreach (DataRow row in tblPur_Content.Rows)
            {
                if (row["Qty_Payment"] == DBNull.Value || Convert.ToInt32(row["Qty_Payment"]) < 0)
                {
                    isOK = false;
                    MessageBox.Show("Số lượng thanh toán không được để trống hoặc nhỏ hơn 0.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                }
            }


            // Bước 2 : So sánh cột "Qty_Payment" với cột "Qty_Received"
            Payment_Full_Quantity = true;
            foreach (DataRow row in tblPur_Content.Rows)
            {
                if (row["Qty_Payment"] != DBNull.Value && row["Qty_Received"] != DBNull.Value)
                {
                    int qtyPayment = Convert.ToInt32(row["Qty_Payment"]);
                    int qtyReceived = Convert.ToInt32(row["Qty_Received"]);
                    if(qtyPayment != qtyReceived)
                    {
                        
                        Payment_Full_Quantity = false;
                        break;
                    }    
                }
            }





            return isOK;
        }

    }
}