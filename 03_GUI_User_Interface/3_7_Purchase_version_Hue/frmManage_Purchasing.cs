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
        #endregion 

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
        #endregion

        // =====================================
        // =====================================
        #region ===== 03. METHOD  =====
        private void Test()
        {
            MessageBox.Show("");
        }



        #endregion
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
                if(ckcViewTop100.Checked ==true)
                {
                    tblPur_Search_PO = _purchase_V2_BLL.Select_tblPur_PO_by_SupplierID_BLL(_supplierID, 100);
                    dgv_Search_PO.DataSource = tblPur_Search_PO;
                }    
                else
                {
                    tblPur_Search_PO = _purchase_V2_BLL.Select_tblPur_PO_by_SupplierID_BLL(_supplierID);
                    dgv_Search_PO.DataSource= tblPur_Search_PO;
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

        #endregion

        private void dgv_Search_PO_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // Brush green color for the row if the "Status" is true
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewRow row = dgv_Search_PO.Rows[e.RowIndex];
                if (row.Cells["Status"].Value != null && Convert.ToBoolean(row.Cells["Status"].Value) == true)
                {
                    row.DefaultCellStyle.BackColor = Color.LightGreen;
                }
                else
                {
                    row.DefaultCellStyle.BackColor = Color.White; // Reset to default color
                }
            }
        }

        private void dgv_Search_PO_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if(dgv_Search_PO.IsCurrentCellDirty)
            {
                // Commit the change to the cell value
                dgv_Search_PO.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }
    }
}