using Newtonsoft.Json;
using PLM_Lynx._01_DAL_Data_Access_Layer;
using PLM_Lynx._02_BLL_Bussiness_Logic_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace PLM_Lynx._03_GUI_User_Interface._3_5_Purchase
{
    public partial class frmMakePO : Form
    {
        private PurchaseBLL _purchasebll = new PurchaseBLL();
        private CommonBLL _commonbll = new CommonBLL();
        public string _usercurrent { get; set; }
        private DataTable table_ListTimKiem;

        //private DataTable table_ListItem {  get; set; }
        public DataTable table_ListItem = new DataTable();

        /// <summary>
        /// ********** REGION - [1]  : => Common Method
        /// </summary>
        #region

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

        #endregion

        /// <summary>
        /// ********** REGION - [2]  : => List Event  Load
        /// </summary>
        #region

        public frmMakePO()
        {
            InitializeComponent();
            dgvListItem.CellValueChanged += dgvListItem_CellValueChanged;
        }

        private void DgvListItem_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void frmMakePO_Load(object sender, EventArgs e)
        {
            // ---> Load  information of users
            txtKeySearch.Focus();
            txtStaffName.Text = _usercurrent;
            tblUsers _user_data = _purchasebll.GetUserInfor(_usercurrent);
            txtStaffDept.Text = _user_data.DepartmentName;
            txtStaffPosition.Text = _user_data.Position;

            // ---> Load information of PO No
            DateTime today = DateTime.Now.Date;
            tblPO _po_data = _purchasebll.GetInforPO();
            DateTime thelastestdate = DateTime.Now.Date;
            string thelastestPO = today.Date.ToString("yyyy-MM-dd") + "/000";
            if (_po_data != null)
            {
                thelastestdate = _po_data.PODate;
                thelastestPO = _po_data.POCode;
                //MessageBox.Show(thelastestPO);
            }

            string PO_no;

            if (thelastestdate.Date == today)
            {
                // If the lastest day match with today
                // Cut string  "yyyy-MM-dd/001"
                PO_no = thelastestPO.Substring(11);
                PO_no = today.Date.ToString("yyyy-MM-dd") + "/" + (Convert.ToInt32(PO_no) + 1).ToString("D3");
            }
            else
            {
                // If the lastest day is old   => get today
                PO_no = today.Date.ToString("yyyy-MM-dd") + "/001";
            }
            txtPONo.Text = PO_no;
            txtOrderDate.Text = today.Date.ToString("yyyy-MM-dd");

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

            // ---> Load Common information
            LoadCommonInfor();

            //// ---> Create DataTable ListItem
            table_ListItem.Columns.Add("PartCode", typeof(string));
            table_ListItem.Columns.Add("PartName", typeof(string));
            table_ListItem.Columns.Add("Quantity", typeof(int));
            table_ListItem.Columns.Add("UnitPrice", typeof(int));
            table_ListItem.Columns.Add("Discount", typeof(double));
            table_ListItem.Columns.Add("Amount", typeof(decimal));
            table_ListItem.Columns.Add("ID", typeof(int));

            dgvListItem.AllowUserToAddRows = false;

            // ---> Load Tolerance VND/USD : 0.0/0.00/0.00
            CboTolerance.SelectedIndex = 1; //  Precision : 0.00

            txtKeySearch.Focus();
        }

        private void cboSupplierName_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectitem = cboSupplierName.SelectedItem.ToString();
            LoadInforSupplier(selectitem);
        }

        #endregion

        /// <summary>
        /// ********** REGION - [3]  : =>  LIST EVENT HANDLE SEARCH PART
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        #region

        ///Load database to view search
        public void LoadDataFindPart(string keysearch)
        {
            table_ListTimKiem = _purchasebll.FindwithwordBLL(keysearch);
            dgvListTimKiem.DataSource = table_ListTimKiem;
            dgvListTimKiem.Columns[0].Width = 70; // PartCode
            dgvListTimKiem.Columns[1].Width = 200; // PartName
            dgvListTimKiem.Columns[2].Width = 60; // PartPrice
            dgvListTimKiem.Columns[3].Width = 10; // PartPrice

            //dgvListTimKiem.Columns[0].HeaderText = "Code";
            //dgvListTimKiem.Columns[1].HeaderText = "Name";

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
                MessageBox.Show("Hãy nhập từ khóa vào ô tìm kiếm Part");
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
            frmRelationPart_Detail_Info frm = new frmRelationPart_Detail_Info();
            string partcode = dgvListTimKiem.CurrentRow.Cells[0].Value.ToString();
            frm.ShowDetailInfor(partcode);
            frm.ShowDialog();
        }

        private void btnAddItems_Click(object sender, EventArgs e)
        {
            // Thêm vào dgvChild
            if (dgvListTimKiem.Rows.Count == 0)
            {
                MessageBox.Show("Không có đối tượng part trong danh sách tìm kiếm \n Hãy nhập từ khóa tìm kiếm");
                txtKeySearch.Focus();
                return;
            }

            string partcode = dgvListTimKiem.CurrentRow.Cells[0].Value.ToString();
            string partname = dgvListTimKiem.CurrentRow.Cells[1].Value.ToString();
            int partid = Convert.ToInt32(dgvListTimKiem.CurrentRow.Cells[3].Value.ToString());

            //decimal partprice = Convert.ToDecimal(dgvListTimKiem.CurrentRow.Cells[2].Value);
            decimal partprice;
            if (dgvListTimKiem.CurrentRow.Cells[2].Value.ToString() == "" || dgvListTimKiem.CurrentRow.Cells[2].Value.ToString() == "0")
            {
                partprice = 0;
            }
            else
            {
                partprice = Convert.ToDecimal(dgvListTimKiem.CurrentRow.Cells[2].Value);
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
                MessageBox.Show("Giá trị này đã thêm vào danh sách con rồi ");
                return;
            }
            else
            {
                // Nếu không trùng thì mới thêm vào
                string supplier = cboSupplierName.Items.ToString();

                table_ListItem.Rows.Add(partcode, partname, 1, partprice, 0, 0, partid);
                dgvListItem.DataSource = table_ListItem;

                // Set up formart for Column
                dgvListItem.Columns[3].DefaultCellStyle.Format = "D";   // Formate : Current

                // Đặt các cột không được chỉnh sửa
                dgvListItem.Columns[0].ReadOnly = true;   // PartCode can not modify
                dgvListItem.Columns[1].ReadOnly = true;   // PartName can not modify
                dgvListItem.Columns[2].ReadOnly = false;  // Quantity can modify
                dgvListItem.Columns[3].ReadOnly = false;  // Unit Price can modify
                dgvListItem.Columns[4].ReadOnly = false;  // Discount can modify
                dgvListItem.Columns[5].ReadOnly = false;  // Amount can modify
                dgvListItem.Columns[6].ReadOnly = true;  // ID can not  modify
            }

            CalculateTotal();
        }

        private void btnDeletePart_Click(object sender, EventArgs e)
        {
            // Check Row.Count before
            if (dgvListItem.SelectedRows.Count > 0)
            {
                string notice = dgvListItem.CurrentRow.Cells[1].Value.ToString();
                notice = "Do you want to delete item : " + notice + "? ";

                DialogResult result = MessageBox.Show(notice, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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
                    MessageBox.Show("The List Item is EMPTY \n Please choose the items firstly. ");
                    return;
                }
            }
            CalculateTotal();
        }

        private void btnClearList_Click(object sender, EventArgs e)
        {
            string notice = "Do you want to CLEAR ALL ITEM ? ";

            DialogResult result = MessageBox.Show(notice, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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
            string notice = "Do you want to cancel about - [ Make the New Purchase Order ] ?";
            DialogResult kp = MessageBox.Show(notice, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kp == DialogResult.Yes)
            {
                this.Close();
            }
            else
            { return; }
        }

        /// <summary>
        /// [ External Method ] : Calculate and show in textbox "Total"
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

                        if (isValidPrice && isValidQuantity)
                        {
                            discount = isValidDiscount ? discount : 0; // Nếu discount không hợp lệ, đặt mặc định là 0
                            amount = priceUnit * quantity * (1 - discount * 0.01m);
                            row.Cells["Amount"].Value = amount;
                            total += amount;
                        }
                    }
                }

                txtTotalVND.Text = total.ToString("N0"); // Hiển thị số có dấu phân cách
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvListItem_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Đảm bảo không phải hàng tiêu đề
            {
                CalculateTotal();
            }
        }

        private void convertvnd2usd()
        {
            if (float.TryParse(txtTotalVND.Text, out float vndprice) && float.TryParse(txtRate.Text, out float rate) && rate != 0)
            {
                // Tính giá sang USD
                float usdprice = vndprice / rate;

                // Kiểm tra SelectedIndex trước khi sử dụng
                if (CboTolerance.SelectedIndex >= 0)
                {
                    string tolerance = @"N" + (CboTolerance.SelectedIndex + 1).ToString();
                    txtTotalUSD.Text = usdprice.ToString(tolerance);
                }
                else
                {
                    txtTotalUSD.Text = usdprice.ToString("N2"); // Mặc định làm tròn 2 chữ số thập phân nếu chưa chọn độ chính xác
                }
            }
            else
            {
                txtTotalUSD.Text = "0"; // Hoặc để trống tùy theo yêu cầu
            }
        }

        private void CboTolerance_SelectedIndexChanged(object sender, EventArgs e)
        {
            convertvnd2usd();
        }

        private void txtTotalVND_TextChanged(object sender, EventArgs e)
        {
            convertvnd2usd();
        }

        private void txtRate_TextChanged(object sender, EventArgs e)
        {
            convertvnd2usd();
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
            //  Check : Do "dgvListItem" have data ?
            if (dgvListItem.Rows.Count == 0) { return; }

            // Check : Are "txtTotalVN" is number ?
            if (decimal.TryParse(txtTotalVND.Text, out decimal number) == false) { return; }

            // Nếu OK mới có JsonFile

            DialogResult savedlg = MessageBox.Show("Do you want to save new PO", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (savedlg == DialogResult.Yes)
            {
                string jsonfile = ConvertDataGridViewToJson(dgvListItem);
                string POPartlist = jsonfile.Replace("\r", "").Replace("\n  ", "");
                POPartlist = POPartlist.Replace("  ", " ");
                //string POPartlist = Regex.Replace(jsonfile, @"\s+", " ");
                string POnote = "+)" + txtPaymentTerms.Text + "\n" + "+)" + txtRemark.Text;

                //MessageBox.Show(POPartlist);

                if (_purchasebll.InsertNewPOBLL(txtPONo.Text, txtOrderDate.Text, txtStaffName.Text, POPartlist, decimal.Parse(txtTotalVND.Text), POnote, Convert.ToInt32(txtSupplierID.Text)) == true)
                {
                    string notice = "Đã lưu PO này vào database";
                    MessageBox.Show(notice);
                    IdentityPONO();
                }
                else
                {
                    string notice = "Lỗi!!! \n Vui lòng kiểm tra lại dữ liệu. ";
                    MessageBox.Show(notice, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                };
            }
            else { return; }
        }

        private void IdentityPONO()
        {
            string PO_no;
            DateTime today = DateTime.Now.Date;
            PO_no = txtPONo.Text.Substring(11);
            PO_no = today.Date.ToString("yyyy-MM-dd") + "/" + (Convert.ToInt32(PO_no) + 1).ToString("D3");
            txtPONo.Text = PO_no;
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
        }

        private void btnExportPO_Click(object sender, EventArgs e)
        {
            if (table_ListItem.Rows.Count == 0)
            {
                MessageBox.Show("PO hiện tại đang trống ! \n Vui lòng điền các chi tiết để mua ");
                return;
            }
            else
            {
                string tb = "Lưu ý ! \n Bạn nên lưu PO trước khi xuất Excel \n  ";
                tb += tb + "Bạn có muốn tiếp tục không ?";
                DialogResult kp = MessageBox.Show(tb, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (kp == DialogResult.No)
                {
                    return;
                }
                else
                {

                    ExcelRunning _exportTemplate = new ExcelRunning();
                    _exportTemplate._orderPOno = txtPONo.Text.Replace("/", "_");
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
            }
        }

        private void btnOldPO_Click(object sender, EventArgs e)
        {
            frmFindPO frm = new frmFindPO();
            frm.ShowDialog();
        }
    }
}