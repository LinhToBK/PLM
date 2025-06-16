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
using System.Windows.Markup.Localizer;

namespace PLM_Lynx._03_GUI_User_Interface._3_7_Purchase_version_Hue
{
    public partial class frmManage_Purchasing : Form
    {
        #region ===== 01. FORM CONSTRUCTOR =====

        private CommonBLL _commonBLL = new CommonBLL();

        private Purchase_V2_BLL _purchase_V2_BLL = new Purchase_V2_BLL();

        private int _selected_Tab;

        private DataTable tblPur_Search_PO = new DataTable();

        // -- private variables
        private DataTable tblPur_Supplier = new DataTable();

        // -- public variables
        public string _userName { get; set; } = string.Empty;

        #endregion ===== 01. FORM CONSTRUCTOR =====

        // =====================================
        // =====================================

        #region ===== 02. FORM LOAD =====

        public frmManage_Purchasing()
        {
            InitializeComponent();
            Load_Datebase_Information();
        }

        private void frmManage_Purchasing_Load(object sender, EventArgs e)
        {
            Load_Component_Information();
            btnSearch_by_Supplier.PerformClick();
            dgv_Search_PO.Focus();
            View_dgv_Search_PO();
        }

        private void Load_Component_Information()
        {
            cbo_tblPur_Supplier.DataSource = tblPur_Supplier;
            cbo_tblPur_Supplier.DisplayMember = "SupplierName";
            cbo_tblPur_Supplier.ValueMember = "SupplierID";
        }

        private void Load_Datebase_Information()
        {
            tblPur_Supplier = _purchase_V2_BLL.Select_tblPur_Supplier_BLL();
        }

        private void View_dgv_Search_PO()
        {
            // Read Only for all columns except for the fist column
            foreach (DataGridViewColumn column in dgv_Search_PO.Columns)
            {
                if (column.Index != 0) // Assuming the first column is editable
                {
                    column.ReadOnly = true;
                }
            }
            // If type of column is decimal, set the format to 0.00
            foreach (DataGridViewColumn column in dgv_Search_PO.Columns)
            {
                if (column.ValueType == typeof(decimal) || column.ValueType == typeof(double))
                {
                    column.DefaultCellStyle.Format = "0.00"; // Set the format to 2 decimal places
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
            }
        }

        #endregion ===== 02. FORM LOAD =====

        // =====================================
        // =====================================

        #region ===== 03. METHOD  =====

        private bool Check_Supplier()
        {
            bool isOK = true;

            return isOK;
        }

        #endregion ===== 03. METHOD  =====

        // =====================================
        // =====================================

        #region ===== 04. EVENT HANDLER =====

        private void btnExit_Click(object sender, EventArgs e)
        {
            string message = "Do you want to close the form?";
            DialogResult result = MessageBox.Show(message, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnModifyPO_Click(object sender, EventArgs e)
        {
            string messsage = "Do you want to modify this PO ? ";
            DialogResult result = MessageBox.Show(messsage, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                frmModify_PO frm = new frmModify_PO();
                frm._poNumber = Convert.ToInt32(dgv_Search_PO.CurrentRow.Cells["PONumber"].Value.ToString());
                frm.ShowDialog();
            }
        }

        private void btnSearch_By_Date_Click(object sender, EventArgs e)
        {
            switch (tab_Control.SelectedIndex)
            {
                case 0:
                    // Search by date in the first tab
                    {
                        DateTime DateFrom = dtp_DateFrom.Value.Date;
                        DateTime DateTo = dtp_DateTo.Value.Date;
                        if (DateFrom > DateTo)
                        {
                            MessageBox.Show("The start date cannot be later than the end date.", "Invalid Date Range", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        if (ckcViewTop100.Checked == true)
                        {
                            tblPur_Search_PO = _purchase_V2_BLL.Select_tblPur_PO_by_CreateDate_BLL(DateFrom, DateTo, 100);
                            dgv_Search_PO.DataSource = tblPur_Search_PO;
                        }
                        else
                        {
                            tblPur_Search_PO = _purchase_V2_BLL.Select_tblPur_PO_by_CreateDate_BLL(DateFrom, DateTo);
                            dgv_Search_PO.DataSource = tblPur_Search_PO;
                        }
                    }
                    break;

                case 1:
                    // Handle search by date in the second tab if needed
                    MessageBox.Show("Searching by date in the second tab is not implemented yet.");
                    break;

                default:
                    MessageBox.Show("Please select a valid tab.");
                    break;
            }
        }

        private void btnSearch_by_Supplier_Click(object sender, EventArgs e)
        {
            if (tab_Control.SelectedIndex == 0)
            {
                int _supplierID = Convert.ToInt32(cbo_tblPur_Supplier.SelectedValue);
                if (ckcViewTop100.Checked == true)
                {
                    tblPur_Search_PO = _purchase_V2_BLL.Select_tblPur_PO_by_SupplierID_BLL(_supplierID, 100);
                    dgv_Search_PO.DataSource = tblPur_Search_PO;
                    dgv_Search_PO.Focus();
                }
                else
                {
                    tblPur_Search_PO = _purchase_V2_BLL.Select_tblPur_PO_by_SupplierID_BLL(_supplierID);
                    dgv_Search_PO.DataSource = tblPur_Search_PO;
                }
            }
            else
            {
                MessageBox.Show("Đang ở tab khác ");
            }
        }

        private void cms_dgv_Search_PO_Edit_View_Table_Click(object sender, EventArgs e)
        {
            string Col_Mode = dgv_Search_PO.AutoSizeColumnsMode.ToString();

            frmDataGridView_Modify frm = new frmDataGridView_Modify(_commonBLL.Get_Attribute_from_DatagridView(dgv_Search_PO), Col_Mode);

            if (frm.ShowDialog() == DialogResult.OK)
            {
                _commonBLL.Set_Attribute_to_DatagridView(dgv_Search_PO, frm.table_Updated_Att, frm.Col_ModeID);
            }
        }

        private void cms_dgv_Search_PO_ModifyPO_Click(object sender, EventArgs e)
        {
            string messsage = "Do you want to modify this PO ? ";
            DialogResult result = MessageBox.Show(messsage, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                frmModify_PO frm = new frmModify_PO();
                frm._poNumber = Convert.ToInt32(dgv_Search_PO.CurrentRow.Cells["PONumber"].Value.ToString());
                frm.ShowDialog();
            }
        }

        #endregion ===== 04. EVENT HANDLER =====

        private void btnCopytoGRPO_Click(object sender, EventArgs e)
        {
            string messsage = "Do you want to copy this PO to GRPO ? ";
            DialogResult result = MessageBox.Show(messsage, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                frm_Make_New_GRPO frm = new frm_Make_New_GRPO();
                int PONumber = Convert.ToInt32(dgv_Search_PO.CurrentRow.Cells["PONumber"].Value.ToString());
                frm._poNumber = PONumber;
                frm.ShowDialog();
            }
        }

        private void cms_dgv_Search_PO_Copy_to_GRPO_Click(object sender, EventArgs e)
        {
            btnCopytoGRPO.PerformClick();
        }

        // Đánh số thứ tự cho các hàng trong DataGridView
        private void dgv_Search_PO_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
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

        private void dgv_Search_PO_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Bỏ tô màu các dòng khác (nếu muốn chỉ highlight dòng vừa click)
            foreach (DataGridViewRow row in dgv_Search_PO.Rows)
            {
                row.DefaultCellStyle.BackColor = Color.White; // Màu nền mặc định
            }

            // Kiểm tra dòng được chọn có hợp lệ không
            if (e.RowIndex >= 0 && e.RowIndex < dgv_Search_PO.Rows.Count)
            {
                DataGridViewRow selectedRow = dgv_Search_PO.Rows[e.RowIndex];
                selectedRow.DefaultCellStyle.BackColor = Color.AliceBlue; // Màu nền highlight cho dòng được chọn
            }
        }

        private void frmManage_Purchasing_KeyDown(object sender, KeyEventArgs e)
        {
            // Creat shortkey
            // 1. Alt + F4 to close the form
            if (e.Alt && e.KeyCode == Keys.F4)
            {
                e.SuppressKeyPress = true; // Ngăn chặn hành động mặc định của Alt + F4
                btnExit.PerformClick(); // Gọi sự kiện click của nút thoát
            }
            // 2. Ctrl + G to btnCopytoGRPO_Click
            else if (e.Control && e.KeyCode == Keys.G)
            {
                e.SuppressKeyPress = true; // Ngăn chặn hành động mặc định của Ctrl + G
                btnCopytoGRPO.PerformClick(); // Gọi sự kiện click của nút Copy to GRPO
            }
            // 3. Ctrl + M to btnModifyPO_Click
            else if (e.Control && e.KeyCode == Keys.M)
            {
                e.SuppressKeyPress = true; // Ngăn chặn hành động mặc định của Ctrl + M
                btnModifyPO.PerformClick(); // Gọi sự kiện click của nút Modify PO
            }
        }

        private void tab_Control_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tab_Control.SelectedIndex)
            {
                case 0:
                    dgv_Search_PO.Focus();
                    break;

                case 1:
                    btnExit.Focus();
                    break;
            }
        }
    }
}