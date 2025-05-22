using Newtonsoft.Json;
using PLM_Lynx._01_DAL_Data_Access_Layer;
using PLM_Lynx._02_BLL_Bussiness_Logic_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO.Ports;
using System.Linq;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;

namespace PLM_Lynx._03_GUI_User_Interface._3_5_Purchase
{
    public partial class frmMakePO : Form
    {
        private PurchaseBLL _purchasebll = new PurchaseBLL();
        private CommonBLL _commonbll = new CommonBLL();
        public string _usercurrent { get; set; }
        private DataTable table_ListTimKiem;

        public DataTable table_ListItem = new DataTable();

        private DataTable tblMoneyType = new DataTable();

        private void GetMoneyType()
        {
            tblMoneyType = _purchasebll.Get_tblMoneytype_BLL();// Lấy danh sách các loại tiền tệ và lưu lại vào DataTable

            cboCurrency.DataSource = tblMoneyType;
            cboCurrency.DisplayMember = "CurrencyName";
            cboCurrency.ValueMember = "CurrencyID";
        }

        private int GetMoneyID(string MoneyName)
        {
            int MoneyTypeID = 0;
            foreach (DataRow rw in tblMoneyType.Rows)
            {
                if (rw["CurrencyName"].ToString() == MoneyName)
                {
                    MoneyTypeID = Convert.ToInt32(rw["CurrencyID"]);
                    break;
                }
            }
            return MoneyTypeID;
        }

        private string GetMoneyName(int MoneyTypeID)
        {
            string MoneyTypeName = string.Empty;
            foreach (DataRow rw in tblMoneyType.Rows)
            {
                if (Convert.ToInt32(rw["CurrencyID"]) == MoneyTypeID)
                {
                    MoneyTypeName = rw["CurrencyName"].ToString();
                    break;
                }
            }
            return MoneyTypeName;
        }

        private DataTable tblUnitType = new DataTable();

        private int GetUnitID(string UnitName)
        {
            int UnitTypeID = 0;
            foreach (DataRow rw in tblUnitType.Rows)
            {
                if (rw["UnitName"].ToString() == UnitName)
                {
                    UnitTypeID = Convert.ToInt32(rw["UnitID"]);
                    break;
                }
            }
            return UnitTypeID;
        }

        private string GetUnitName(int UnitTypeID)
        {
            string UnitTypeName = string.Empty;
            foreach (DataRow rw in tblUnitType.Rows)
            {
                if (Convert.ToInt32(rw["UnitID"]) == UnitTypeID)
                {
                    UnitTypeName = rw["UnitName"].ToString();
                    break;
                }
            }
            return UnitTypeName;
        }

        private void GetUnitType()
        {
            tblUnitType = _purchasebll.Get_tblUnitType_BLL();// Lấy danh sách các loại tiền tệ và lưu lại vào DataTable
        }

        /// <summary>
        /// List Method
        /// </summary>
        /// <param name="SupplierName"></param>
        public void LoadInforSupplier(string SupplierName)
        {
            tblSupplier _tblsupplier = _purchasebll.GetInforSupplier(SupplierName);

            txtSupplierID.Text = _tblsupplier.SupID.ToString();
            txtSupplierLocation.Text = _tblsupplier.SupLocation;
            txtSupplierPhone.Text = _tblsupplier.SupPhoneNumber.ToString();
            txtSupplierTax.Text = _tblsupplier.SupTaxID.ToString();
        }

        /// <summary>
        /// [ Method ] ==>  Load Common Information
        /// </summary>
        public void LoadCommonInfor()
        {
            tblCommonInfor companyname = _commonbll.GetCommonInforValue("CompanyName");
            if (companyname != null)
            {
                txtCompanyName.Text = companyname.InforValue.ToString();
            }
            else
            {
                txtCompanyName.Text = " Error !!! \n Cannot access the data";
            }
            tblCommonInfor companyphone = _commonbll.GetCommonInforValue("CompanyPhoneNumber");
            if (companyphone != null)
            {
                txtCompanyPhone.Text = companyphone.InforValue.ToString();
            }
            else
            {
                txtCompanyPhone.Text = " Error !!! \n Cannot access the data";
            }
            tblCommonInfor companylocation = _commonbll.GetCommonInforValue("CompanyLocation");
            if (companylocation != null)
            {
                txtCompanyLocation.Text = companylocation.InforValue.ToString();
            }
            else
            {
                txtCompanyLocation.Text = " Error !!! \n Cannot access the data";
            }
            tblCommonInfor companytaxcode = _commonbll.GetCommonInforValue("CompanyTaxCode");
            if (companytaxcode != null)
            {
                txtCompanyTaxCode.Text = companytaxcode.InforValue.ToString();
            }
            else
            {
                txtCompanyTaxCode.Text = " Error !!! \n Cannot access the data";
            }
        }

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

            rm = new ResourceManager("PLM_Lynx._03_GUI_User_Interface._3_5_Purchase.Lang.Lang_frmMakePO", typeof(frmMakePO).Assembly);
            // Hiển thị ngôn ngữ lên các điều khiển trong form
            this.Text = rm.GetString("i.form");
            labelStaffName.Text = rm.GetString("lb1");
            //btnHelp.Text = rm.GetString("lb2");
            labelStaffDept.Text = rm.GetString("lb3");
            labelStaffPosition.Text = rm.GetString("lb4");
            //btnViewNearPO.Text = rm.GetString("lb5");
            btnOldPO.Text = rm.GetString("lb6");
            labelFinditem.Text = rm.GetString("lb7");
            btnCancelPO.Text = rm.GetString("lb8");
            BtnManageSupplier.Text = rm.GetString("lb9");
            labelPONo.Text = rm.GetString("lb10");
            labelPurchaseOrder.Text = rm.GetString("lb11");
            labelOrderDate.Text = rm.GetString("lb12");
            labelSupplierName.Text = rm.GetString("lb13");
            labelSupplierID.Text = rm.GetString("lb14");
            labelSupplierLocation.Text = rm.GetString("lb15");
            labelSupplierTel.Text = rm.GetString("lb16");
            labelSupplierTax.Text = rm.GetString("lb17");
            labelCompanyTelephone.Text = rm.GetString("lb18");
            labelPaymentTerm.Text = rm.GetString("lb19");
            btnAddItems.Text = rm.GetString("lb20");
            btnAddchild.Text = rm.GetString("lb20");
            btnDeletePart.Text = rm.GetString("lb21");
            btnClearList.Text = rm.GetString("lb22");
            btnExportPO.Text = rm.GetString("lb23");
            btnSavePO.Text = rm.GetString("lb24");
            labelRemark.Text = rm.GetString("lb25");
            labelTotalAmount.Text = rm.GetString("lb26");
            labelRate.Text = rm.GetString("lb27");

            Properties.Settings.Default.Language = lang;
            Properties.Settings.Default.Save();
        }

        // =========== Language =========================
        public frmMakePO()
        {
            InitializeComponent();
            // Load ngôn ngữ mặc định
            LoadLanguage();
            dgvListItem.CellValueChanged += dgvListItem_CellValueChanged;

            // Tạo sự kiện liên quan đến phím tắt
            this.KeyPreview = true;
        }

        private void DgvListItem_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Lấy số PONo và điền vào txtPONo
        /// </summary>
        private void Load_PONumber()
        {
            txtPONumber.Text = _purchasebll.Get_PONumber_BLL().ToString();
            txtOrderDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
        }

        private string Unit_default = "EA"; // Đơn vị mặc định là EA

        private void Load_Supplier()
        {
            // ---> Load information of Supplier
            DataTable ListSupplier = _purchasebll.GetListSupplier();
            if (ListSupplier != null && ListSupplier.Rows.Count > 0)
            {
                foreach (DataRow dr in ListSupplier.Rows)
                {
                    cboSupplierName.Items.Add(dr[0].ToString());
                }
                cboSupplierName.SelectedIndex = 0; // Choose the first
                LoadInforSupplier(cboSupplierName.Items[0].ToString());
            }
            else
            {
                MessageBox.Show("Error !!! \n Can not find the list Supplier Name");
                this.Close();
            }
        }

        private void frmMakePO_Load(object sender, EventArgs e)
        {
            // ---> Load  information of users
            txtKeySearch.Focus();
            txtStaffName.Text = _usercurrent;
            tblUsers _user_data = _purchasebll.GetUserInfor(_usercurrent);
            txtStaffDept.Text = _user_data.DepartmentName;
            txtStaffPosition.Text = _user_data.Position;

            cboTemplate.SelectedIndex = 0; // Choose the first

            // Load PONo
            Load_PONumber();
            // Load MoneyType
            GetMoneyType();
            GetUnitType();
            Unit_default = tblUnitType.Rows[0]["UnitName"].ToString(); // Đơn vị mặc định là EA

            // Load Supplier
            Load_Supplier();

            // ---> Load Common information
            LoadCommonInfor();

            // ---> Create DataTable ListItem
            // PartCode || PartName || Quantity || Unit || UnitPrice || Discount ||  Amount || Currency ||  Tax || TaxCode
            // BOL-0001 || Bolt M3x10|| 30      || EA   ||   200     || 5        ||  5700   ||    VND   ||  1.5 ||  

            table_ListItem.Columns.Add("PartCode", typeof(string));
            table_ListItem.Columns.Add("PartName", typeof(string));
            table_ListItem.Columns.Add("Quantity", typeof(int));
            table_ListItem.Columns.Add("Unit", typeof(string));
            table_ListItem.Columns.Add("UnitPrice", typeof(decimal));
            table_ListItem.Columns.Add("Discount", typeof(double));
            table_ListItem.Columns.Add("Amount", typeof(decimal));
            table_ListItem.Columns.Add("Currency", typeof(string));
            table_ListItem.Columns.Add("Tax", typeof(decimal));   
            table_ListItem.Columns.Add("TaxCode", typeof(string));

            dgvListItem.DataSource = table_ListItem;
            dgvListItem.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvListItem.AllowUserToAddRows = false;
            dgvListItem.AllowUserToDeleteRows = false;
            dgvListItem_ViewFit();

            txtKeySearch.Focus();
        }

        private void dgvListItem_ViewFit()
        {
            dgvListItem.Columns[3].DefaultCellStyle.Format = "D";   // Formate : Current
            // Chỉnh lại kích thước cột cho đẹp
            dgvListItem.Columns[0].Width = 100; // PartCode
            dgvListItem.Columns[1].Width = 200; // PartName
            dgvListItem.Columns[2].Width = 60; // Quantity
            dgvListItem.Columns[3].Width = 60; // Unit
            dgvListItem.Columns[4].Width = 100; // UnitPrice
            dgvListItem.Columns[5].Width = 60; // Discount
            dgvListItem.Columns[6].Width = 100; // Amount
            dgvListItem.Columns[7].Width = 60; // Currency
            dgvListItem.Columns[8].Width = 50; // Tax
            // dgvListItem.Columns[9].Width = 100; // TaxCode


            // Đặt chế độ chỉnh sửa cho từng cột
            dgvListItem.Columns[0].ReadOnly = true; // PartCode
            dgvListItem.Columns[1].ReadOnly = true; // PartName
            dgvListItem.Columns[2].ReadOnly = false; // Quantity
            dgvListItem.Columns[3].ReadOnly = true; // Unit
            dgvListItem.Columns[4].ReadOnly = false; // UnitPrice
            dgvListItem.Columns[5].ReadOnly = false; // Discount
            dgvListItem.Columns[6].ReadOnly = true; // Amount
            dgvListItem.Columns[7].ReadOnly = true; // Currency
            dgvListItem.Columns[8].ReadOnly = false; // Tax
            dgvListItem.Columns[9].ReadOnly = false; // TaxCode

            // Đặt Align lai cho các cột
            dgvListItem.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // PartCode
            dgvListItem.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft; // PartName
            dgvListItem.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Quantity
            dgvListItem.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Unit
            dgvListItem.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight; // UnitPrice
            dgvListItem.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight; // Discount
            dgvListItem.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight; // Amount
            dgvListItem.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Currency
            dgvListItem.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Tax
            dgvListItem.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // TaxCode

        }

        private void cboSupplierName_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectitem = cboSupplierName.SelectedItem.ToString();
            LoadInforSupplier(selectitem);
        }

        /// <summary>
        /// ********** REGION - [3]  : =>  LIST EVENT HANDLE SEARCH PART
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        #region

        ///Load database to view search
        public void LoadDataFindPart(string keysearch)
        {
            //   p.PartCode as PartCode,
            //   p.PartName as PartName,
            //   p.PartPriceSale as PartPriceSale,
            //   p.PartID as PartID,
            //p.PartPrice as PartPrice,
            //p.PartCurrentID as PartCurrentID
            table_ListTimKiem = _purchasebll.FindwithwordBLL(keysearch);
            dgvListTimKiem.DataSource = table_ListTimKiem;
            dgvListTimKiem.Columns[0].Width = 70; // PartCode
            dgvListTimKiem.Columns[1].Width = 200; // PartName
            dgvListTimKiem.Columns[2].Width = 60; // PartPrice
            dgvListTimKiem.Columns[3].Width = 10; // PartID

            dgvListTimKiem.AllowUserToAddRows = false;
            dgvListTimKiem.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtKeySearch.Text != "")
            {
                LoadDataFindPart(txtKeySearch.Text);
            }
            else
            {
                MessageBox.Show(rm.GetString("t1"));   // Hãy nhập từ khóa vào ô tìm kiếm Part
                txtKeySearch.Focus();
            }
        }

        private void txtKeySearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch.PerformClick();
                e.SuppressKeyPress = true; // Ngăn không cho tiếng Bíp kêu khi nhấn enter
            }
        }

        private void dgvListTimKiem_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Open Detail of Part
            if (dgvListTimKiem.Rows.Count > 0)
            {
                frmRelationPart_Detail_Info frm = new frmRelationPart_Detail_Info();
                string partcode = dgvListTimKiem.CurrentRow.Cells[0].Value.ToString();
                frm.ShowDetailInfor(partcode);
                frm.ShowDialog();
            }
        }

        private void btnAddItems_Click(object sender, EventArgs e)
        {
            // Thêm vào dgvChild
            if (dgvListTimKiem.Rows.Count == 0)
            {
                MessageBox.Show(rm.GetString("t2"));   // Không có đối tượng part trong danh sách tìm kiếm \n Hãy nhập từ khóa tìm kiếm
                txtKeySearch.Focus();
                return;
            }

            string partcode = dgvListTimKiem.CurrentRow.Cells["PartCode"].Value.ToString();
            string partname = dgvListTimKiem.CurrentRow.Cells["PartName"].Value.ToString();
            int partid = Convert.ToInt32(dgvListTimKiem.CurrentRow.Cells["PartID"].Value.ToString());
            int partcurrentid;
            if (dgvListTimKiem.CurrentRow.Cells["PartCurrentID"].Value.ToString() == null || dgvListTimKiem.CurrentRow.Cells["PartCurrentID"].Value.ToString() == "")
            {
                partcurrentid = 1;
            }
            else
            {
                partcurrentid = Convert.ToInt32(dgvListTimKiem.CurrentRow.Cells["PartCurrentID"].Value.ToString());
            }

            //decimal partprice = Convert.ToDecimal(dgvListTimKiem.CurrentRow.Cells[2].Value);
            decimal partprice;
            if (dgvListTimKiem.CurrentRow.Cells["PartPrice"].Value.ToString() == "" || dgvListTimKiem.CurrentRow.Cells["PartPrice"].Value.ToString() == "0")
            {
                partprice = 0;
            }
            else
            {
                partprice = Convert.ToDecimal(dgvListTimKiem.CurrentRow.Cells["PartPrice"].Value);
            }

            // Kiểm tra giá trị này với giá trị của dgvListItem hiện tại
            bool isDuplicate = false;
            foreach (DataRow rw in table_ListItem.Rows)
            {
                // Kiểm tra giá trị của cột đầu tiên
                if ((string)rw["PartCode"] == partcode)
                {
                    isDuplicate = true;

                    break;
                }
            }

            // Nếu trùng thì thông báo
            if (isDuplicate == true)
            {
                MessageBox.Show(rm.GetString("t3")); // Giá trị này đã thêm vào danh sách con rồi
                return;
            }
            else
            {
                // Nếu không trùng thì mới thêm vào
                DataRow newrow = table_ListItem.NewRow();
                newrow["PartCode"] = partcode;
                newrow["PartName"] = partname;
                newrow["Quantity"] = 1; // Giá trị mặc định là 1
                newrow["Unit"] = Unit_default; // Đơn vị mặc định là EA
                newrow["UnitPrice"] = partprice; // Giá trị mặc định là 0
                newrow["Discount"] = 0; // Giá trị mặc định là 0
                newrow["Amount"] = partprice; // Giá trị mặc định là 0
                newrow["Currency"] = GetMoneyName(partcurrentid); // Giá trị mặc định là VND
                newrow["Tax"] = 0; // Giá trị mặc định là 0
                newrow["TaxCode"] = ""; // Giá trị mặc định là 0

                table_ListItem.Rows.Add(newrow);
                CalculateTotal();
            }
        }

        private void btnDeletePart_Click(object sender, EventArgs e)
        {
            // Check Row.Count before
            if (dgvListItem.SelectedRows.Count > 0)
            {
                string notice = dgvListItem.CurrentRow.Cells[1].Value.ToString();
                notice = rm.GetString("t4") + "? ";    // Do you want to delete item :

                DialogResult result = MessageBox.Show(notice, rm.GetString("t0"), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    foreach (DataGridViewRow rw in dgvListItem.SelectedRows)
                    {
                        if (!rw.IsNewRow)
                        {
                            dgvListItem.Rows.Remove(rw);
                        }
                    }
                }
                else
                {
                    MessageBox.Show(rm.GetString("t5"));   // The List Item is EMPTY \n Please choose the items firstly.
                    return;
                }
            }
            CalculateTotal();
        }

        private void btnClearList_Click(object sender, EventArgs e)
        {
            string notice = rm.GetString("t6");  // Do you want to CLEAR ALL ITEM ?

            DialogResult result = MessageBox.Show(notice, rm.GetString("t0"), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                if (dgvListItem.DataSource is DataTable dt)
                {
                    dt.Clear();
                }
                else
                {
                    dgvListItem.Rows.Clear();
                }
                CalculateTotal();
            }
        }

        #endregion

        private void btnCancelPO_Click(object sender, EventArgs e)
        {
            string notice = rm.GetString("t7");  // Do you want to cancel about - [ Make the New Purchase Order ] ?
            DialogResult kp = MessageBox.Show(notice, rm.GetString("t0"), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kp == DialogResult.Yes)
            {
                this.Close();
            }
            else
            { return; }
        }

        /// <summary>
        /// [ External Method ] : Tính toán tổng tiền và hiển thị vào txtTotalVND
        /// </summary>
        private void CalculateTotal()
        {
            decimal total = 0;
            decimal amount = 0;

            try
            {
                foreach (DataGridViewRow row in dgvListItem.Rows.Cast<DataGridViewRow>())
                {
                    if (row.Cells["UnitPrice"].Value != null && row.Cells["Quantity"].Value != null)
                    {
                        bool isValidPrice = decimal.TryParse(row.Cells["UnitPrice"].Value?.ToString(), out decimal priceUnit);
                        bool isValidQuantity = decimal.TryParse(row.Cells["Quantity"].Value?.ToString(), out decimal quantity);
                        bool isValidDiscount = decimal.TryParse(row.Cells["Discount"]?.Value?.ToString(), out decimal discount);
                        bool isValidTax = decimal.TryParse(row.Cells["Tax"]?.Value?.ToString(), out decimal tax);

                        if (isValidPrice && isValidQuantity)
                        {
                            discount = isValidDiscount ? discount : 0; // Nếu discount không hợp lệ, đặt mặc định là 0
                            amount = priceUnit * quantity * (1 - discount * 0.01m + tax*0.01m);
                            row.Cells["Amount"].Value = amount;
                            total += amount;
                        }
                    }
                }

                txtTotalVND.Text = total.ToString("N0"); // Hiển thị số có dấu phân cách
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error : {ex.Message}", rm.GetString("t0"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvListItem_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Đảm bảo không phải hàng tiêu đề
            {
                CalculateTotal();
            }
        }

        private void CboTolerance_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void txtTotalVND_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtRate_TextChanged(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// [ METHOD ] : Convert DataGridView =>  JSON File
        /// </summary>
        /// <param name="dataGridView"></param>
        /// <returns></returns>
        private string ConvertDataGridViewToJson(DataGridView dataGridView)
        {
            var rows = new List<Dictionary<string, object>>();

            // Iterate through each row in the DataGridView
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                if (!row.IsNewRow) // Skip the new row placeholder
                {
                    var rowData = new Dictionary<string, object>();

                    // Iterate through each cell in the row
                    //foreach (DataGridViewCell cell in row.Cells)
                    //{
                    //    string columnName = dataGridView.Columns[cell.ColumnIndex].HeaderText;
                    //    rowData[columnName] = cell.Value;
                    //}

                    rowData["C"] = row.Cells[6].Value;
                    rowData["Q"] = row.Cells[2].Value;
                    rowData["P"] = row.Cells[3].Value;
                    rowData["D"] = row.Cells[4].Value;

                    rows.Add(rowData);
                }
            }

            // Serialize the list of dictionaries to JSON
            return JsonConvert.SerializeObject(rows, Formatting.Indented);
        }

        private void btnSavePO_Click(object sender, EventArgs e)
        {
            if (Check_dgvListItem() == false)
            {
                MessageBox.Show("Please check input data again !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string tb = "Do you want to save this PO";
            DialogResult kq = MessageBox.Show("" + tb, rm.GetString("t0"), MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (kq == DialogResult.Yes)
            {
                // =>  Tạo bảng dữ liệu DataTable để lưu trữ thông tin tblPOItems

                // PONumber || PartCode || Quantity || UnitID || UnitPrice || Discount || Amount
                // int || string || int || int || decimal || decimal || decimal
                DataTable data_InserttblPOItems = new DataTable();
                data_InserttblPOItems.Columns.Add("PONumber", typeof(int));
                data_InserttblPOItems.Columns.Add("PartCode", typeof(string));
                data_InserttblPOItems.Columns.Add("Quantity", typeof(int));
                data_InserttblPOItems.Columns.Add("UnitID", typeof(int));
                data_InserttblPOItems.Columns.Add("UnitPrice", typeof(decimal));
                data_InserttblPOItems.Columns.Add("Discount", typeof(decimal));
                data_InserttblPOItems.Columns.Add("Amount", typeof(decimal));
                
                data_InserttblPOItems.Columns.Add("Tax", typeof(decimal)); // Thêm cột Tax nếu cần thiết
                data_InserttblPOItems.Columns.Add("TaxCode", typeof(string)); // Thêm cột TaxCode nếu cần thiết

                // => Lấy dữ liệu từ daGridView và thêm vào DataTable
                foreach (DataGridViewRow row in dgvListItem.Rows)
                {
                    DataRow newRow = data_InserttblPOItems.NewRow();
                    newRow["PONumber"] = Convert.ToInt32(txtPONumber.Text);
                    newRow["PartCode"] = row.Cells["PartCode"].Value.ToString();
                    newRow["Quantity"] = Convert.ToInt32(row.Cells["Quantity"].Value.ToString());
                    newRow["UnitID"] = GetUnitID(row.Cells["Unit"].Value.ToString());
                    newRow["UnitPrice"] = Convert.ToDecimal(row.Cells["UnitPrice"].Value.ToString());
                    newRow["Discount"] = Convert.ToDecimal(row.Cells["Discount"].Value.ToString());
                    newRow["Amount"] = Convert.ToDecimal(row.Cells["Amount"].Value.ToString());
                    newRow["Tax"] = Convert.ToDecimal(row.Cells["Tax"].Value.ToString()); // Thêm giá trị thuế nếu cần thiết
                    newRow["TaxCode"] = row.Cells["TaxCode"].Value.ToString(); // Thêm giá trị mã thuế nếu cần thiết
                    data_InserttblPOItems.Rows.Add(newRow);
                }

                // Lấy các dữ liệu cần thiết
                // int PONumber, int POSupplierID, DateTime PODateCreate, int POCurrencyID, int POStatusID,
                // string POUser, string POPaymentTerm, string PORemark, decimal TotalAmount)
                int PONumber = Convert.ToInt32(txtPONumber.Text);
                int SupplierID = Convert.ToInt32(txtSupplierID.Text);
                DateTime PODateCreate = DateTime.Now.Date;
                int POCurrencyID = cboCurrency.SelectedIndex + 1;// Lấy chỉ số của loại tiền tệ
                int POStatusID = 1; // Đặt trạng thái mặc định là 1 (Mới tạo)
                string POUser = txtStaffName.Text;
                string POPaymentTerm = txtPaymentTerms.Text;
                string PORemark = txtRemark.Text;
                decimal TotalAmount = Convert.ToDecimal(txtTotalVND.Text); // Tổng tiền

                // Lưu vào database
                if (_purchasebll.InsertNewPO_BLL(PONumber, SupplierID, PODateCreate, POCurrencyID, POStatusID, POUser, POPaymentTerm, PORemark, TotalAmount))
                {
                    MessageBox.Show("Save PO successfully !", rm.GetString("t0"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Ghi dữ liệu vào tblPOItem
                    if(_purchasebll.InsertListItems_to_tblPOItems_BLL(data_InserttblPOItems) == true)
                    {
                        MessageBox.Show("Save PO Items successfully !", rm.GetString("t0"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // Identity PONo
                        Load_PONumber();
                        // Clear DataGridView
                        dgvListItem.DataSource = null;
                        table_ListItem.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Error when save PO Items !", rm.GetString("t0"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Error when save PO !", rm.GetString("t0"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


  
        private void btnPreview_Click(object sender, EventArgs e)
        {
        }

        private void btnExportPO_Click(object sender, EventArgs e)
        {
            if (table_ListItem.Rows.Count == 0)
            {
                MessageBox.Show(rm.GetString("t10")); // PO hiện tại đang trống ! \n Vui lòng điền các chi tiết để mua
                return;
            }
            else
            {
                string tb = rm.GetString("t11");  // Bạn có muốn xuất ra file Excel để xem trước không ?

                DialogResult kp = MessageBox.Show(tb, rm.GetString("t0"), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (kp == DialogResult.No)
                {
                    return;
                }
                else
                {
                    if (cboTemplate.SelectedIndex == 0)
                    {
                        // Chạy template 0
                        ExcelRunning _exportTemplate = new ExcelRunning();
                        _exportTemplate._orderPOno = txtPONumber.Text.Replace("/", "_");
                        _exportTemplate._orderDate = txtOrderDate.Text;
                        // Company Information
                        _exportTemplate._companyName = txtCompanyName.Text;
                        _exportTemplate._companyLocation = txtCompanyLocation.Text;
                        _exportTemplate._companyTelephone = txtCompanyPhone.Text;
                        _exportTemplate._companyTaxcode = txtCompanyTaxCode.Text;
                        // Supplier Information
                        _exportTemplate._supplierName = cboSupplierName.SelectedItem.ToString();
                        _exportTemplate._supplierLocation = txtSupplierLocation.Text;
                        _exportTemplate._supplierTelephone = txtSupplierPhone.Text;
                        _exportTemplate._supplierTaxcode = txtSupplierTax.Text;

                        // Remark
                        _exportTemplate._paymentterms = txtPaymentTerms.Text;
                        _exportTemplate._remark = txtRemark.Text;
                        _exportTemplate._purchasePerson = txtStaffName.Text;
                        _exportTemplate._totalVND = txtTotalVND.Text;

                        // Partlist
                        _exportTemplate.Partlist = table_ListItem;

                        _exportTemplate.PurchaseTemplate_A();
                    }
                    if (cboTemplate.SelectedIndex == 1)
                    {
                        MessageBox.Show("Template 1 is not ready yet");
                    }
                }
            }
        }

        private void btnOldPO_Click(object sender, EventArgs e)
        {
            frmFindPO frm = new frmFindPO();
            frm.ShowDialog();
        }

        private void BtnManageSupplier_Click(object sender, EventArgs e)
        {
            using (frmManageSupplier frm = new frmManageSupplier())
            {
                var result = frm.ShowDialog();
                if (result == DialogResult.OK || result == DialogResult.Cancel)
                {
                    Load_Supplier(); // Load lại danh sách nhà cung cấp
                }
            }
        }

        private void btnViewNearPO_Click(object sender, EventArgs e)
        {
        }

        private void dgvListTimKiem_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvListTimKiem.Rows.Count > 0)
            {
                txtPartCode.Text = dgvListTimKiem.CurrentRow.Cells["PartCode"].Value.ToString();
                txtPartName.Text = dgvListTimKiem.CurrentRow.Cells["PartName"].Value.ToString();
                txtPartPrice.Text = dgvListTimKiem.CurrentRow.Cells["PartPrice"].Value.ToString();
                int PartID = Convert.ToInt32(dgvListTimKiem.CurrentRow.Cells["PartID"].Value.ToString());
                if (ckcViewChild.Checked == true)
                {
                    dgvListChild.DataSource = _purchasebll.GetChildPartBLL(PartID);
                    dgvListChild.Columns[0].Width = 40;
                    dgvListChild.Columns[1].Width = 80;
                    dgvListChild.Columns[2].Width = 150;
                    dgvListChild.Columns[3].Visible = false; // Dir
                    dgvListChild.Columns[5].Visible = false;       // ID
                    dgvListChild.Columns[4].Width = 80;       // ID
                }
                else
                {
                    dgvListChild.DataSource = null;
                    return;
                }
            }
        }

        private void btnAddchild_Click(object sender, EventArgs e)
        {
            // Thêm vào dgvChild
            if (dgvListChild.Rows.Count == 0)
            {
                MessageBox.Show("Not have data child");   // Không có đối tượng part trong danh sách tìm kiếm \n Hãy nhập từ khóa tìm kiếm
                txtKeySearch.Focus();
                return;
            }

            string partcode = dgvListChild.CurrentRow.Cells["PartCode"].Value.ToString();
            string partname = dgvListChild.CurrentRow.Cells["PartName"].Value.ToString();
            int partid = Convert.ToInt32(dgvListChild.CurrentRow.Cells[6].Value.ToString());

            //decimal partprice = Convert.ToDecimal(dgvListTimKiem.CurrentRow.Cells[2].Value);
            decimal partprice;
            // Kiểm tra PartPrice
            if (dgvListChild.CurrentRow.Cells[5].Value.ToString() == "" || dgvListChild.CurrentRow.Cells[5].Value.ToString() == "0")
            {
                partprice = 0;
            }
            else
            {
                partprice = Convert.ToDecimal(dgvListChild.CurrentRow.Cells[5].Value);
            }

            // Kiểm tra giá trị này với giá trị của dgvListItem hiện tại
            bool isDuplicate = false;
            foreach (DataRow rw in table_ListItem.Rows)
            {
                // Kiểm tra giá trị của cột đầu tiên
                if ((string)rw["PartCode"] == partcode)
                {
                    isDuplicate = true;

                    break;
                }
            }

            // Nếu trùng thì thông báo
            if (isDuplicate == true)
            {
                MessageBox.Show(rm.GetString("t3")); // Giá trị này đã thêm vào danh sách con rồi
                return;
            }
            else
            {
                // Nếu không trùng thì mới thêm vào
                DataTable add1code = new DataTable();
                add1code.Columns.Add("PartCode", typeof(string));
                DataRow dtr = add1code.NewRow();
                dtr["PartCode"] = partcode;
                add1code.Rows.Add(dtr);
                DataTable inforcode = _purchasebll.QueryInforItemPO_BLL(add1code);

                DataRow row = inforcode.Rows[0];

                DataRow newrow = table_ListItem.NewRow();
                newrow["PartCode"] = row["PartCode"];
                newrow["PartName"] = row["PartName"];
                newrow["Quantity"] = 1;
                newrow["Unit"] = Unit_default;
                newrow["UnitPrice"] = row["PartPrice"];
                newrow["Discount"] = 0;
                newrow["Amount"] = row["PartPrice"];
                newrow["Tax"] = 0; // Giá trị mặc định là 0
                newrow["TaxCode"] = ""; // Giá trị mặc định là 0

                if (row["PartCurrentID"].ToString() == null || row["PartCurrentID"].ToString() == "")
                {
                    newrow["Currency"] = GetMoneyName(1);
                }
                else
                {
                    newrow["Currency"] = GetMoneyName(Convert.ToInt32(row["PartCurrentID"].ToString()));
                }
                table_ListItem.Rows.Add(newrow);
                CalculateTotal();
            }
        }

        private void ckcViewChild_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void dgvListChild_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Open Detail of Part
            if (dgvListChild.Rows.Count > 0)
            {
                frmRelationPart_Detail_Info frm = new frmRelationPart_Detail_Info();
                string partcode = dgvListChild.CurrentRow.Cells[1].Value.ToString();
                frm.ShowDetailInfor(partcode);
                frm.ShowDialog();
            }
        }

        private void dgvListItem_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvListItem.Rows.Count > 0)
            {
                frmRelationPart_Detail_Info frm = new frmRelationPart_Detail_Info();
                string partcode = dgvListItem.CurrentRow.Cells[0].Value.ToString();
                frm.ShowDetailInfor(partcode);
                frm.ShowDialog();
            }
        }

        private void frmMakePO_KeyDown(object sender, KeyEventArgs e)
        {
            // Tạo các phím tắt
            // Shift + A : Add Items
            if (e.Shift && e.KeyCode == Keys.A)
            {
                e.Handled = true;
                e.SuppressKeyPress = true; // Ngăn không cho tiếng Bíp kêu khi nhấn enter
                btnAddItems.PerformClick();
            }

            // Shift + C : Add child items
            if (e.Shift && e.KeyCode == Keys.C)
            {
                e.Handled = true;
                e.SuppressKeyPress = true; // Ngăn không cho tiếng Bíp kêu khi nhấn enter
                btnAddchild.PerformClick();
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            using (frmImportListItems formA = new frmImportListItems())
            {
                // Lấy cột PartCode trong table_ListItem
                DataTable List_Items_Now = new DataTable();
                List_Items_Now.Columns.Add("PartCode", typeof(string));
                foreach (DataRow row in table_ListItem.Rows)
                {
                    List_Items_Now.Rows.Add(row["PartCode"]);
                }

                formA.ListItem_Now = List_Items_Now; // Truyền danh sách Item hiện tại vào Form A

                var result = formA.ShowDialog();  // Dùng ShowDialog để chờ form A đóng
                if (result == DialogResult.OK || result == DialogResult.Cancel) // hoặc chỉ cần kiểm tra nếu != null
                {
                    DataTable ListItemImportOK = formA.ListItem_OK;
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
                            // Thêm dữ liệu cho table_ListItem
                            DataRow newrow = table_ListItem.NewRow();
                            newrow["PartCode"] = row["PartCode"];
                            newrow["PartName"] = row["PartName"];
                            newrow["Quantity"] = 1;
                            newrow["Unit"] = Unit_default;
                            newrow["UnitPrice"] = row["PartPrice"];
                            newrow["Discount"] = 0;
                            newrow["Amount"] = row["PartPrice"];
                            newrow["Tax"] = 0; // Giá trị mặc định là 0
                            newrow["TaxCode"] = ""; // Giá trị mặc định là 0

                            if (row["PartCurrentID"].ToString() == null || row["PartCurrentID"].ToString() == "")
                            {
                                newrow["Currency"] = GetMoneyName(1);
                            }
                            else
                            {
                                newrow["Currency"] = GetMoneyName(Convert.ToInt32(row["PartCurrentID"].ToString()));
                            }
                            table_ListItem.Rows.Add(newrow);
                        }

                        dgvListItem.DataSource = table_ListItem;

                        dgvListItem_ViewFit(); // Gọi hàm để điều chỉnh kích thước cột

                        MessageBox.Show("Import successful!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CalculateTotal(); // Tính toán lại tổng tiền
                    }
                }
            }
        }

        private void addItemToPOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnAddchild.PerformClick();
        }

        private void openPartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Open Detail of Part
            if (dgvListChild.Rows.Count > 0)
            {
                frmRelationPart_Detail_Info frm = new frmRelationPart_Detail_Info();
                string partcode = dgvListChild.CurrentRow.Cells[1].Value.ToString();
                frm.ShowDetailInfor(partcode);
                frm.ShowDialog();
            }
        }

        private void addItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnAddItems.PerformClick();
        }

        private void openPartToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (dgvListTimKiem.Rows.Count > 0)
            {
                frmRelationPart_Detail_Info frm = new frmRelationPart_Detail_Info();
                string partcode = dgvListTimKiem.CurrentRow.Cells[0].Value.ToString();
                frm.ShowDetailInfor(partcode);
                frm.ShowDialog();
            }
        }

        private void changeMoneyTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frmMoneyType formA = new frmMoneyType())
            {
                formA.ListMoneyType = tblMoneyType; // Truyền danh sách loại tiền tệ vào Form A
                formA.OldMoneyType = dgvListItem.CurrentRow.Cells["Currency"].Value.ToString();

                var result = formA.ShowDialog();  // Dùng ShowDialog để chờ form A đóng
                if (result == DialogResult.OK || result == DialogResult.Cancel) // hoặc chỉ cần kiểm tra nếu != null
                {
                    string receivedText = formA.NewMoneyType; // Lấy dữ liệu từ Form A
                    // Thay đổi loại tiền tệ cho các hàng đã chọn
                    dgvListItem.CurrentRow.Cells["Currency"].Value = receivedText;
                }
            }
        }

        private void changeUnitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frmUnitType frm = new frmUnitType())
            {
                frm.ListUnitType = tblUnitType; // Truyền danh sách loại tiền tệ vào Form A
                frm.OldUnitType = dgvListItem.CurrentRow.Cells["Unit"].Value.ToString();

                var result = frm.ShowDialog();  // Dùng ShowDialog để chờ form A đóng
                if (result == DialogResult.OK || result == DialogResult.Cancel) // hoặc chỉ cần kiểm tra nếu != null
                {
                    string receivedText = frm.NewUnitType; // Lấy dữ liệu từ Form A
                    // Thay đổi loại tiền tệ cho các hàng đã chọn
                    dgvListItem.CurrentRow.Cells["Unit"].Value = receivedText;
                }
            }
        }

        private bool Check_dgvListItem()
        {
            // Kiểm tra cột quantity có là số nguyên không ?
            // Kiểm tra cột UnitPrice có là số không ?
            // Kiểm tra cột Discount có là số không ?
            // Kiểm tra cột Amount có là số không ?
            bool status = true;

            // Xóa những hàng trắng trong dgvListItem
            foreach (DataGridViewRow row in dgvListItem.Rows)
            {
                if (row.IsNewRow) continue; // Bỏ qua hàng mới
                if (row.Cells["PartCode"].Value == null || string.IsNullOrWhiteSpace(row.Cells["PartCode"].Value.ToString()))
                {
                    dgvListItem.Rows.Remove(row);
                }
            }

            if (dgvListItem.Rows.Count == 0)
            {
                MessageBox.Show(rm.GetString("t10")); // PO hiện tại đang trống ! \n Vui lòng điền các chi tiết để mua
                status = false;
            }
            else
            {
                foreach (DataGridViewRow row in dgvListItem.Rows)
                {
                    if (row.Cells["Quantity"].Value != null && row.Cells["UnitPrice"].Value != null && row.Cells["Discount"].Value != null && row.Cells["Amount"].Value != null)
                    {
                        bool isValidQuantity = int.TryParse(row.Cells["Quantity"].Value?.ToString(), out int quantity);
                        bool isValidPrice = decimal.TryParse(row.Cells["UnitPrice"].Value?.ToString(), out decimal priceUnit);
                        bool isValidDiscount = double.TryParse(row.Cells["Discount"]?.Value?.ToString(), out double discount);
                        bool isValidAmount = decimal.TryParse(row.Cells["Amount"]?.Value?.ToString(), out decimal amount);
                        if (!isValidQuantity || !isValidPrice || !isValidDiscount || !isValidAmount)
                        {
                            row.DefaultCellStyle.BackColor = Color.Red; // Đánh dấu hàng có lỗi bằng màu đỏ

                            status = false;
                        }
                        if (quantity == 0 || priceUnit == 0 || amount == 0)
                        {
                            row.DefaultCellStyle.BackColor = Color.Cyan; // Đánh dấu hàng có lỗi bằng màu đỏ
                            status = false;
                        }
                    }
                }
            }
            return status;
        }

        private void deleteItemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnDeletePart.PerformClick();

        }

        private void clearListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnClearList.PerformClick();
        }
    }
}