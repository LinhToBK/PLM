using PLM_Lynx._01_DAL_Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PLM_Lynx._02_BLL_Bussiness_Logic_Layer;

namespace PLM_Lynx._03_GUI_User_Interface._3_5_Purchase
{
    public partial class frmFindPO_Update : Form
    {
        private PurchaseBLL _purchaseBLL = new PurchaseBLL();
        private FindPartBLL _findPartBLL = new FindPartBLL();
        public string UserName { get; set; } // Tên người dùng

        private DataTable _tblresult = new DataTable();
        // Date Create || PO Number || Supplier Name || PO Status || User Create || Total Amount

        public frmFindPO_Update()
        {
            InitializeComponent();
        }

        private void btnSearchByDateTime_Click(object sender, EventArgs e)
        {
            // Get the selected date range from the DateTimePicker controls
            DateTime startDate = dtpStartDate.Value.Date; // Get the date part only
            DateTime endDate = dtpEndDate.Value.Date; // Get the date part only

            if (ckcOnlyDay.Checked == false)
            {
                _tblresult.Rows.Clear();
                _tblresult = _purchaseBLL.Get_POInformation_BLL(startDate, endDate);
            }
            else
            {
                _tblresult.Rows.Clear();
                _tblresult = _purchaseBLL.Get_POInformation_BLL(startDate);
            }

            dgvResult.DataSource = _tblresult;
            dgvResult_ViewFit();
        }

        private void dgvResult_ViewFit()
        {
            // Set the DataGridView to fit the content of the cells
            dgvResult.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvResult.Columns[0].Width = 150; // Date Create
            dgvResult.Columns[1].Width = 150; // PO Number
            dgvResult.Columns[2].Width = 120; // Status ;
            dgvResult.Columns[3].Width = 100; // Currency
            dgvResult.Columns[4].Width = 150; // Supplier Name
            dgvResult.Columns[5].Width = 100; // User Create
            //dgvResult.Columns[6].Width = 100; // Total Amount

            // Chỉnh tên các cột
            dgvResult.Columns[0].HeaderText = "Date Create";
            dgvResult.Columns[1].HeaderText = "PO Number";
            dgvResult.Columns[2].HeaderText = "Status";
            dgvResult.Columns[3].HeaderText = "Currency";
            dgvResult.Columns[4].HeaderText = "Supplier Name";
            dgvResult.Columns[5].HeaderText = "User Create";
            dgvResult.Columns[6].HeaderText = "Total Amount";

            // Chỉnh Align các cột
            dgvResult.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Date Create
            dgvResult.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // PO Number
            dgvResult.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Status
            dgvResult.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Currency
            dgvResult.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft; // Supplier Name
            dgvResult.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // User Create
            dgvResult.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight; // Total Amount



        }

        private void btnSearchByPartCode_Click(object sender, EventArgs e)
        {
            if (txtPartCode.Text == "")
            {
                MessageBox.Show("Please enter Part Code to search!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                _tblresult.Rows.Clear();
                _tblresult = _purchaseBLL.Get_POInformation_BLL(txtPartCode.Text.Trim());
                dgvResult.DataSource = _tblresult;
                dgvResult_ViewFit();
            }
        }

        private void btnFindItem_Click(object sender, EventArgs e)
        {
            if (txtPartCode.Text == "")
            {
                MessageBox.Show("Please enter Part Code to search!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                dgvListPartCode.DataSource = _findPartBLL.FindWithWordBLL(txtPartCode.Text.Trim());
                dgvListPartCode_ViewFit();

            }
        }

        private void dgvListPartCode_ViewFit()
        {
            dgvListPartCode.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvListPartCode.Columns["PartCode"].Width = 100; // Part Code
            dgvListPartCode.Columns["PartName"].Width = 150; // Part Name
            dgvListPartCode.Columns["PartDescript"].Visible = false; // Part Description
            dgvListPartCode.Columns["PartStage"].Width = 100; // Part Stage
            dgvListPartCode.Columns["PartID"].Visible = false; // PartID
            dgvListPartCode.Columns["PartMaterial"].Visible = false; // PartMaterial
            dgvListPartCode.Columns["PartPrice"].Visible = false; // PartPrice
            dgvListPartCode.Columns["PartPriceSale"].Visible = false; // PartPriceSale
            dgvListPartCode.Columns["PartPriceLog"].Visible = false; // PartPriceLog




        }

        private void txtPartCode_KeyDown(object sender, KeyEventArgs e)
        {
            // Khi nhấn enter trong txtPartCode 
            if (e.KeyCode == Keys.Enter)
            {
                btnFindItem.PerformClick();
            }
        }

        private void findPOThisPartCodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Lấy giá trị PartCode từ dgvListPartCode
            if (dgvListPartCode.CurrentRow != null)
            {
                string partCode = dgvListPartCode.CurrentRow.Cells["PartCode"].Value.ToString();
                txtPartCode.Text = partCode;
                btnSearchByPartCode.PerformClick();
            }
            else
            {
                MessageBox.Show("Please select a Part Code from the list!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void openPartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Mở form PartCode
            if (dgvListPartCode.CurrentRow != null)
            {
                string partCode = dgvListPartCode.CurrentRow.Cells["PartCode"].Value.ToString();
                if (dgvListPartCode.Rows.Count > 0)
                {

                    frmRelationPart_Detail_Info frm = new frmRelationPart_Detail_Info();
                   
                    frm.ShowDetailInfor(partCode);
                    frm.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Please select a Part Code from the list!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void cms_dgvResult_ViewDetail_Click(object sender, EventArgs e)
        {
            frmPOInformation frm = new frmPOInformation();
            if (dgvResult.CurrentRow != null)
            {
                // Lấy giá trị PO Number từ dgvResult
                string poNumber = dgvResult.CurrentRow.Cells["PONumber"].Value.ToString();
                frm.PONumber = Convert.ToInt32(poNumber);
               
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select a PO Number from the list!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
        }

        private void frmFindPO_Update_Load(object sender, EventArgs e)
        {
            txtPartCode.Focus();
        }
    }
}