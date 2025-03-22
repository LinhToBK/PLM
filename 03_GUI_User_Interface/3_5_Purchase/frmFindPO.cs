using PLM_Lynx._02_BLL_Bussiness_Logic_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Security.AccessControl;
using PLM_Lynx._01_DAL_Data_Access_Layer;
//using Microsoft.Office.Interop.Excel;

//using Microsoft.Office.Interop.Excel;

namespace PLM_Lynx._03_GUI_User_Interface._3_5_Purchase
{
    public partial class frmFindPO : Form
    {
        private PurchaseBLL purchaseBLL = new PurchaseBLL();
        private DataTable InforthisPO = new DataTable();
        private DataTable InforthisSupplier = new DataTable();
        private DataTable InforPartlist = new DataTable();
        private DataTable InforSearch = new DataTable();

        private string PODate { get; set; }
        private string PONhanVien { get; set; }
        private string POPartlist { get; set; }
        private string POAmount { get; set; }
        private string PONote { get; set; }
        private string POSupplierID { get; set; }
        private string POStatus { get; set; }
        private string SupplierName { get; set; }
        private string SupplierPhone { get; set; }
        private string SupplierTax { get; set; }
        private string SupplierLocation { get; set; }
        private string SupplierRep { get; set; }

        private CommonBLL _commonbll = new CommonBLL();

        // Lấy thông tin của công ty

        public frmFindPO()
        {
            InitializeComponent();
            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult kq = MessageBox.Show("Bạn có muốn thoát không ", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq == DialogResult.Yes)
            {
                this.Close();
            }
            else return;
        }

        private void LoadDataFindtblPO(string text)
        {
            InforSearch =    purchaseBLL.AllInforPObyKeySearchBLL(txtKeySearch.Text, radioPart.Checked);
            dgvSearch.DataSource = InforSearch;
            

            dgvSearch.AllowUserToAddRows = false;
            dgvSearch.EditMode = DataGridViewEditMode.EditProgrammatically;
           dgvSearch.Columns[0].Width = 120;
            dgvSearch.Columns[1].Width = 100;
        }

        private void dgvSearch_Click(object sender, EventArgs e)
        {



            if (dgvSearch.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để chọn");
                return;
            }
            else
            {
                LoadPartlist();
               
            }


        }


        public void LoadPartlist()
        {
            InforthisPO = purchaseBLL.GetInfor1PObyPOCodeBLL(dgvSearch.CurrentRow.Cells[0].Value.ToString());
            PODate = InforthisPO.Rows[0]["PODate"].ToString();
            PONhanVien = InforthisPO.Rows[0]["PONhanVien"].ToString();
            POPartlist = InforthisPO.Rows[0]["POPartlist"].ToString();
            //POAmount = InforthisPO.Rows[0]["POAmount"].ToString();
            POAmount =  Convert.ToDouble( InforthisPO.Rows[0]["POAmount"] ).ToString("N0");
            PONote = InforthisPO.Rows[0]["PONote"].ToString();
            POSupplierID = InforthisPO.Rows[0]["POSupplierID"].ToString();
            POStatus = InforthisPO.Rows[0]["POStatus"].ToString();

            int SupplierID = Convert.ToInt32(POSupplierID);
            InforthisSupplier = purchaseBLL.GetInfor1Supplier_ByID_BLL(SupplierID);
            SupplierName = InforthisSupplier.Rows[0]["SupName"].ToString();
            SupplierPhone = InforthisSupplier.Rows[0]["SupPhoneNumber"].ToString();
            SupplierTax = InforthisSupplier.Rows[0]["SupTaxID"].ToString();
            SupplierRep = InforthisSupplier.Rows[0]["SupRepresentative"].ToString();
            SupplierLocation = InforthisSupplier.Rows[0]["SupLocation"].ToString();

            dgvPartlist.Refresh();

            // Hiển thị thông tin lên textbox
            txtPOCode.Text = dgvSearch.CurrentRow.Cells[0].Value.ToString();
            txtNhanvien.Text = PONhanVien;
            txtPOAmount.Text = POAmount;
            txtStatus.Text = POStatus;
            txtPOSupplier.Text = SupplierName;

            // Lấy thông tin về Partlist
            InforPartlist.Clear();
            InforPartlist = JsonConvert.DeserializeObject<DataTable>(POPartlist);

            DataColumn ColPartCode = new DataColumn("PartCode", typeof(string));
            InforPartlist.Columns.Add(ColPartCode);
            DataColumn ColPartName = new DataColumn("PartName", typeof(string));
            InforPartlist.Columns.Add(ColPartName);
            DataColumn ColAmount = new DataColumn("Amount", typeof(string));
            InforPartlist.Columns.Add(ColAmount);
            //
            try
            {
                foreach (DataRow row in InforPartlist.Rows)
                {
                    row["PartCode"] = purchaseBLL.GetPartCode_BLL(Convert.ToInt32(row["C"]));
                    row["PartName"] = purchaseBLL.GetPartName_BLL(Convert.ToInt32(row["C"]));
                    row["Amount"] = (Convert.ToDecimal(row["P"]) * Convert.ToDecimal(row["Q"]) * (1 - Convert.ToDecimal(row["D"]) * 0.01m)).ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            InforPartlist.Columns.Remove("C");
            InforPartlist.Columns["PartCode"].SetOrdinal(0);
            InforPartlist.Columns["PartName"].SetOrdinal(1);

            dgvPartlist.DataSource = InforPartlist;
            dgvPartlist.AllowUserToAddRows = false;
            dgvPartlist.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvPartlist.Columns[1].Width = 250; // PartName
            dgvPartlist.Columns[2].Width = 80; // Quantity
            dgvPartlist.Columns[2].HeaderText = "Quantity";

            dgvPartlist.Columns[3].HeaderText = "UnitPrice";
            dgvPartlist.Columns[4].Width = 80; // Discount
            dgvPartlist.Columns[4].HeaderText = "Discount";
        }

        private void txtKeySearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BtnKeySearch.PerformClick();
                e.SuppressKeyPress = true; // Ngăn không cho tiếng Bíp kêu khi nhấn enter
            }
        }

        private void BtnKeySearch_Click(object sender, EventArgs e)
        {
            if (txtKeySearch.Text != "")
            {
                LoadDataFindtblPO(txtKeySearch.Text);
                ShowChecklist();
            }
            else
            {
                MessageBox.Show("Bạn cần nhập thông tin vào ô tìm kiếm");
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            // Lấy giá trị của datatimepicker
            string dateFrom = dtpFilter.Value.ToString("yyyy-MM-dd");

            dgvSearch.DataSource = purchaseBLL.AllInforPObyKeySearchBLL(dateFrom, false);
            dgvSearch.AllowUserToAddRows = false;
            dgvSearch.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvSearch.Columns[0].Width = 120;
            dgvSearch.Columns[1].Width = 100;

            ShowChecklist();
        }

        private void dtpFilter_ValueChanged(object sender, EventArgs e)
        {
        }

        private void frmFindPO_Load(object sender, EventArgs e)
        {
            dtpFilter.Format = DateTimePickerFormat.Custom;
            dtpFilter.CustomFormat = "yyyy-MM-dd";
            radioPO.Checked = true;
            txtKeySearch.Focus();
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            if (InforPartlist.Rows.Count == 0)
            {
                MessageBox.Show("PO hiện tại đang trống ! \n Vui lòng điền các chi tiết để mua ");
                return;
            }
            else
            {
                string tb = "Bạn có muốn xuất file Excel không ?";

                DialogResult dialogResult = MessageBox.Show(tb, "Xác nhận", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.No)
                {
                    return;
                }
                else
                {

                    ExcelRunning _exportTemplate = new ExcelRunning();
                    _exportTemplate._orderPOno = txtPOCode.Text.Replace("/", "_");
                    _exportTemplate._orderDate = PODate;
                    //// Company Information
                    tblCommonInfor companyname = _commonbll.GetCommonInforValue("CompanyName");
                    tblCommonInfor companyphone = _commonbll.GetCommonInforValue("CompanyPhoneNumber");
                    tblCommonInfor companylocation = _commonbll.GetCommonInforValue("CompanyLocation");
                    tblCommonInfor companytaxcode = _commonbll.GetCommonInforValue("CompanyTaxCode");

                    _exportTemplate._companyName = companyname.InforValue.ToString();
                    _exportTemplate._companyLocation = companylocation.InforValue.ToString();
                    _exportTemplate._companyTelephone = companyphone.InforValue.ToString();
                    _exportTemplate._companyTaxcode = companytaxcode.InforValue.ToString();
                    //// Supplier Information
                    _exportTemplate._supplierName = SupplierName;
                    _exportTemplate._supplierLocation = SupplierLocation;
                    _exportTemplate._supplierTelephone = SupplierPhone;
                    _exportTemplate._supplierTaxcode = SupplierTax;

                    //// Remark
                    _exportTemplate._paymentterms = PONote;
                    _exportTemplate._remark = "";
                    _exportTemplate._purchasePerson = PONhanVien;
                    _exportTemplate._totalVND = txtPOAmount.Text;

                    //// Partlist
                    _exportTemplate.Partlist = InforPartlist;

                    _exportTemplate.PurchaseTemplate_A();
                }
            }
        }

        private void btnUpdateStatus_Click(object sender, EventArgs e)
        {
            if(InforPartlist.Rows.Count == 0)
            {
                MessageBox.Show("PO hiện tại đang trống ! \n Vui lòng chọn PO để cập nhật ");
                return;
            }
            {
                frmUpdateStatus frm = new frmUpdateStatus();
                frm.POCode = txtPOCode.Text;
                frm.PODate = PODate;
                frm.POStatus = txtStatus.Text;

                // thêm sự kiện frmStatus_FormClosed vào sự kiện UpdateStatus của frm
                frm.UpdateStatus += frmStatus_FormClosed;   // Nếu đóng thì load lại partlist
                frm.ShowDialog();
            }

            


            
        }

        private void frmStatus_FormClosed(object sender, EventArgs e)
        {
            //MessageBox.Show("Partlist sẽ được load lại ");
            LoadPartlist();
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {

           

        }

        private void ShowChecklist()
        {
            if(dgvSearch.Rows.Count == 0)
            {
                //MessageBox.Show("Không có dữ liệu để chọn");
                return;
            }
            else
            {
                // Lấy danh sách Month
                var listMonth = dgvSearch.Rows
                                      .Cast<DataGridViewRow>()
                                      .Where(row => !row.IsNewRow)
                                      .Select(row => row.Cells[5].Value?.ToString())
                                      .Distinct()
                                      .OrderBy(x => x)
                                      .ToList();
                foreach (var category in listMonth)
                {
                    ckcMonth.Items.Add(category, false ); // Mặc định tất cả các mục được chọn
                }
                // Lấy danh sách Date
                var listDate = dgvSearch.Rows
                                      .Cast<DataGridViewRow>()
                                      .Where(row => !row.IsNewRow)
                                      .Select(row => row.Cells[6].Value?.ToString())
                                      .Distinct()
                                      .OrderBy(x => x)
                                      .ToList();
                foreach (var category in listDate)
                {
                    ckcDate.Items.Add(category, false); // Mặc định tất cả các mục được chọn
                }

                // Lấy danh sách Staff
                var listStaff = dgvSearch.Rows
                                      .Cast<DataGridViewRow>()
                                      .Where(row => !row.IsNewRow)
                                      .Select(row => row.Cells[1].Value?.ToString())
                                      .Distinct()
                                      .OrderBy(x => x)
                                      .ToList();
                foreach (var category in listStaff)
                {
                    ckcStaff.Items.Add(category, false); // Mặc định tất cả các mục được chọn
                }

                // Lấy danh sách Status
                var listStatus = dgvSearch.Rows
                                      .Cast<DataGridViewRow>()
                                      .Where(row => !row.IsNewRow)
                                      .Select(row => row.Cells[4].Value?.ToString())
                                      .Distinct()
                                      .OrderBy(x => x)
                                      .ToList();
                foreach (var category in listStatus)
                {
                    ckcStatus.Items.Add(category, false); // Mặc định tất cả các mục được chọn
                }
            }    

            

        }

        private void ckcStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void ApplyFilter()
        {
            if (dgvSearch.DataSource is DataTable dt)
            {
                List<string> filters = new List<string>();

                // Lọc theo Tháng
                string monthFilter = GetCheckedItemsFilter(ckcMonth, "pMonth");
                if (!string.IsNullOrEmpty(monthFilter)) filters.Add(monthFilter);

                // Lọc theo Năm
                string DateFilter = GetCheckedItemsFilter(ckcDate, "pDate");
                if (!string.IsNullOrEmpty(DateFilter)) filters.Add(DateFilter);

                // Lọc theo Nhân viên
                string staffFilter = GetCheckedItemsFilter(ckcStaff, "PONhanvien");
                if (!string.IsNullOrEmpty(staffFilter)) filters.Add(staffFilter);

                // Lọc theo Trạng thái
                string statusFilter = GetCheckedItemsFilter(ckcStatus, "POStatus");
                if (!string.IsNullOrEmpty(statusFilter)) filters.Add(statusFilter);

                // Ghép các điều kiện với AND
                dt.DefaultView.RowFilter = string.Join(" AND ", filters);
            }
        }

        // Hàm lấy danh sách các mục đã chọn và tạo điều kiện lọc
        private string GetCheckedItemsFilter(CheckedListBox checkedListBox, string columnName)
        {
            if (checkedListBox.CheckedItems.Count == 0) return "";

            List<string> selectedValues = checkedListBox.CheckedItems.Cast<string>()
                                          .Select(item => $"'{item}'").ToList();

            return $"{columnName} IN ({string.Join(",", selectedValues)})";
        }

        private void ckcStatus_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            this.BeginInvoke(new Action(ApplyFilter));
        }

        private void ckcStaff_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            this.BeginInvoke(new Action(ApplyFilter));
        }

        private void ckcDate_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            this.BeginInvoke(new Action(ApplyFilter));
        }

        private void ckcMonth_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            this.BeginInvoke(new Action(ApplyFilter));
        }
    }
}