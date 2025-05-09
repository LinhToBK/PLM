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
using System.Globalization;
using System.Resources;
using System.Threading;

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

            rm = new ResourceManager("PLM_Lynx._03_GUI_User_Interface._3_5_Purchase.Lang.Lang_frmFindPO", typeof(frmFindPO).Assembly);
            // Hiển thị ngôn ngữ lên các điều khiển trong form
            this.Text = rm.GetString("i.form");
            labelSearch.Text = rm.GetString("lb1");
            BtnKeySearch.Text = rm.GetString("lb2");
            btnFilter.Text = rm.GetString("lb3");
            labelCode.Text = rm.GetString("lb4");
            labelAmount.Text = rm.GetString("lb5");
            labelSupplier.Text = rm.GetString("lb6");
            labelCreator.Text = rm.GetString("lb7");
            labelStatus.Text = rm.GetString("lb8");
            btnExportExcel.Text = rm.GetString("lb9");
            btnUpdateStatus.Text = rm.GetString("lb10");


            Properties.Settings.Default.Language = lang;
            Properties.Settings.Default.Save();
        }

        // =========== Language =========================
        public frmFindPO()
        {
            InitializeComponent();
            LoadLanguage();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult kq = MessageBox.Show(rm.GetString("t1"), rm.GetString("t0"), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq == DialogResult.Yes)
            {
                this.Close();
            }
            else return;
        }

        private void LoadDataFindtblPO(string text)
        {
            InforSearch = purchaseBLL.AllInforPObyKeySearchBLL(txtKeySearch.Text, radioPart.Checked);
            dgvSearchAD.DataSource = InforSearch;
            dgvSearchAD.AllowUserToAddRows = false;
            dgvSearchAD.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvSearchAD.Columns[0].Width = 120;
            dgvSearchAD.Columns[1].Width = 100;
        }

        public void LoadPartlist()
        {
            InforthisPO = purchaseBLL.GetInfor1PObyPOCodeBLL(dgvSearchAD.CurrentRow.Cells[0].Value.ToString());
            PODate = InforthisPO.Rows[0]["PODate"].ToString();
            PONhanVien = InforthisPO.Rows[0]["PONhanVien"].ToString();
            POPartlist = InforthisPO.Rows[0]["POPartlist"].ToString();
            //POAmount = InforthisPO.Rows[0]["POAmount"].ToString();
            POAmount = Convert.ToDouble(InforthisPO.Rows[0]["POAmount"]).ToString("N0");
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
            txtPOCode.Text = dgvSearchAD.CurrentRow.Cells[0].Value.ToString();
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
            dgvPartlist.AllowUserToDeleteRows = false;
       
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
                LoadDataFindtblPO(txtKeySearch.Text.Trim());
            }
            else
            {
                MessageBox.Show(rm.GetString("t2"));  // Bạn cần nhập thông tin vào ô tìm kiếm
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            // Lấy giá trị của datatimepicker
            string dateFrom = dtpFilter.Value.ToString("yyyy-MM-dd");

            dgvSearchAD.DataSource = purchaseBLL.AllInforPObyKeySearchBLL(dateFrom, false);
            dgvSearchAD.AllowUserToAddRows = false;
            dgvSearchAD.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvSearchAD.Columns[0].Width = 120;
            dgvSearchAD.Columns[1].Width = 100;
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
            cboTemplate.SelectedIndex = 0; // Chọn template đầu tiên
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            if (InforPartlist.Rows.Count == 0)
            {
                MessageBox.Show(rm.GetString("t3")); // PO hiện tại đang trống ! \n Vui lòng điền các chi tiết để mua 
                return;
            }
            else
            {
                string tb = rm.GetString("t4"); // 

                DialogResult dialogResult = MessageBox.Show(tb, rm.GetString("t5"), MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.No)
                {
                    return;
                }
                else
                {
                    if(cboTemplate.SelectedIndex == 0 )
                    {
                        RunTemplate_0();
                    }    
                    else
                    {
                        MessageBox.Show("Have not creat new template");
                    }    
                }
            }
        }


        private void RunTemplate_0()
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

        private void btnUpdateStatus_Click(object sender, EventArgs e)
        {
            if (InforPartlist.Rows.Count == 0)
            {
                MessageBox.Show(rm.GetString("t6"));      // PO hiện tại đang trống ! \n Vui lòng chọn PO để cập nhật
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

     

        private void dgvSearchAD_Click(object sender, EventArgs e)
        {
            if (dgvSearchAD.Rows.Count == 0)
            {
                //MessageBox.Show("Không có dữ liệu để chọn");
                return;
            }
            else
            {
                LoadPartlist();
            }
        }

        private void dgvSearchAD_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            if (dgvSearchAD.Rows.Count == 0)
            {
                //MessageBox.Show("Không có dữ liệu để chọn");
                return;
            }
            else
            {
                string code = dgvSearchAD.CurrentRow.Cells[0].Value.ToString();
                string date; 
                string status = dgvSearchAD.CurrentRow.Cells[4].Value.ToString();

                InforthisPO = purchaseBLL.GetInfor1PObyPOCodeBLL(dgvSearchAD.CurrentRow.Cells[0].Value.ToString());
                //select Top 1
                //                p.POCode, 
                //                p.PODate,
                //                p.PONhanVien,
                //                p.POAmount,
                //                p.PONote,
                //                p.POStatus,
                //                p.POLog,
                //                p.POSupplierID,
                //                p.POPartCode
                //                from tblPO as p where POCode = @Pocode";
                date = InforthisPO.Rows[0]["PODate"].ToString();



                frmUpdateStatus frm = new frmUpdateStatus();
                frm.POCode = code;
                frm.PODate = InforthisPO.Rows[0]["PODate"].ToString();
                frm.POStatus = InforthisPO.Rows[0]["POStatus"].ToString();

                // thêm sự kiện frmStatus_FormClosed vào sự kiện UpdateStatus của frm
                frm.UpdateStatus += frmStatus_FormClosed;   // Nếu đóng thì load lại partlist
                frm.ShowDialog();
            }

        }
    }
}