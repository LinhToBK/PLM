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

        private DataTable tblPur_Search_GRPO = new DataTable();
        private DataTable tblPur_Search_PO = new DataTable();
        private DataTable tblPurchase_Search_APInvoice = new DataTable();

        private DataTable tblPur_Status = new DataTable();

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
            tblPur_Status = _purchase_V2_BLL.Select_tblPur_Status_BLL();
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

        private void Refresh_Data()
        {
            btnSearch_by_Supplier.PerformClick(); // Refresh the data by searching again with the selected supplier
            string cancelledStatus = string.Empty;
            string closedStatus = string.Empty;
            foreach (DataRow row in tblPur_Status.Rows)
            {
                int statusID = Convert.ToInt32(row["StatusID"]);
                if (statusID == 2)
                {
                    closedStatus = row["StatusName"].ToString();
                }
                else if (statusID == 3)
                {
                    cancelledStatus = row["StatusName"].ToString();
                }
            }

            // Tô màu cho các ô Status là "Cancelled" trong dgv_Search_PO
            foreach (DataGridViewRow row in dgv_Search_PO.Rows)
            {
                if (row.Cells["StatusName"].Value.ToString() == cancelledStatus)
                {
                    row.Cells["StatusName"].Style.BackColor = Color.Orange; // Tô đỏ cho các ô Status là "Cancelled"
                }
                else if (row.Cells["StatusName"].Value.ToString() == closedStatus)
                {
                    row.Cells["StatusName"].Style.BackColor = Color.LightGray; // Tô xám cho các ô Status là "Closed"
                }
                else
                {
                    row.DefaultCellStyle.BackColor = Color.White; // Màu nền mặc định cho các ô khác
                }
            }
            // Tô đỏ cho các ô Status là "Cancelled" trong dgv_Search_GRPO
            foreach (DataGridViewRow row in dgv_Search_GRPO.Rows)
            {
                if (row.Cells["Status"].Value.ToString() == cancelledStatus)
                {
                    row.Cells["Status"].Style.BackColor = Color.Orange; // Tô đỏ cho các ô Status là "Cancelled"
                }
                else if (row.Cells["Status"].Value.ToString() == closedStatus)
                {
                    row.Cells["Status"].Style.BackColor = Color.LightGray; // Tô xám cho các ô Status là "Closed"
                }
                else
                {
                    row.DefaultCellStyle.BackColor = Color.White; // Màu nền mặc định cho các ô khác
                }
            }

            // Tô đỏ cho các ô Status là "Cancelled" trong dgv_Search_APInvoice
            foreach (DataGridViewRow row in dgv_Search_GRPO.Rows)
            {
                if (row.Cells["Status"].Value.ToString() == cancelledStatus)
                {
                    row.Cells["Status"].Style.BackColor = Color.Orange; // Tô đỏ cho các ô Status là "Cancelled"
                }
                else if (row.Cells["Status"].Value.ToString() == closedStatus)
                {
                    row.Cells["Status"].Style.BackColor = Color.LightGray; // Tô xám cho các ô Status là "Closed"
                }
                else
                {
                    row.DefaultCellStyle.BackColor = Color.White; // Màu nền mặc định cho các ô khác
                }
            }
        }

        #endregion ===== 03. METHOD  =====

        // =====================================
        // =====================================

        #region ===== 04. EVENT HANDLER =====

        private void btnCopy_to_AP_Invoice_Click(object sender, EventArgs e)
        {
            string messsage = "Do you want to copy this GRPO to AP Invoice ? ";
            DialogResult result = MessageBox.Show(messsage, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes)
            {
                return; // If user clicks No, exit the method
            }

            using (frm_Make_New_APInvoice frm = new frm_Make_New_APInvoice())
            {
                int GRPONumber = Convert.ToInt32(dgv_Search_GRPO.CurrentRow.Cells["GRPONumber"].Value.ToString());
                frm.GRPONumber = GRPONumber;

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    // Refresh the data after copying to AP Invoice
                    Refresh_Data();
                }
            }
        }

        private void btnCopytoGRPO_Click(object sender, EventArgs e)
        {
            string messsage = "Do you want to copy this PO to GRPO ? ";
            DialogResult result = MessageBox.Show(messsage, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                int _supplierID = Convert.ToInt32(cbo_tblPur_Supplier.SelectedValue);
                int PONumber = Convert.ToInt32(dgv_Search_PO.CurrentRow.Cells["PONumber"].Value.ToString());
                DataTable dt = _purchase_V2_BLL.Select_tblPur_GRPO_by_SupplierID_BLL(_supplierID);
                if (dt != null)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        if (Convert.ToInt32(row["PONumber"]) == PONumber)
                        {
                            MessageBox.Show("This PO has been copied to GRPO already.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return;
                        }
                    }
                }

                frm_Make_New_GRPO frm = new frm_Make_New_GRPO();

                frm._poNumber = PONumber;
                frm.ShowDialog();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            string message = "Do you want to close the form?";
            DialogResult result = MessageBox.Show(message, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnMake_New_PO_Click(object sender, EventArgs e)
        {
            frmMake_New_PO_V2 frm = new frmMake_New_PO_V2();
            frm._UserName = _userName;
            frm.Show();
        }

        private void btnModifyPO_Click(object sender, EventArgs e)
        {
            string messsage = "Do you want to modify this PO ? ";
            DialogResult result = MessageBox.Show(messsage, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                frmModify_PO frm = new frmModify_PO();
                int PONumber = Convert.ToInt32(dgv_Search_PO.CurrentRow.Cells["PONumber"].Value.ToString());
                frm._poNumber = PONumber;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    // Refresh the data after modifying PO
                    Refresh_Data();
                }
            }
        }

        private void btnSearch_By_Date_Click(object sender, EventArgs e)
        {
            DateTime DateFrom = dtp_DateFrom.Value.Date;
            DateTime DateTo = dtp_DateTo.Value.Date;

            switch (tab_Control.SelectedIndex)
            {
                case 0:  // Tab - View PO
                    // Search by date in the first tab
                    {
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

                case 1:  // Tab - View GRPO
                    {
                        if (DateFrom > DateTo)
                        {
                            MessageBox.Show("The start date cannot be later than the end date.", "Invalid Date Range", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        if (ckcViewTop100.Checked == true)
                        {
                            tblPur_Search_GRPO = _purchase_V2_BLL.Select_tblPur_GRPO_by_CreateDate_BLL(DateFrom, DateTo, 100);
                            dgv_Search_GRPO.DataSource = tblPur_Search_GRPO;
                        }
                        else
                        {
                            tblPur_Search_GRPO = _purchase_V2_BLL.Select_tblPur_GRPO_by_CreateDate_BLL(DateFrom, DateTo);
                            dgv_Search_GRPO.DataSource = tblPur_Search_GRPO;
                        }
                    }
                    break;

                case 2: // Tab - View APInvoice
                    {
                        if (DateFrom > DateTo)
                        {
                            MessageBox.Show("The start date cannot be later than the end date.", "Invalid Date Range", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        if (ckcViewTop100.Checked == true)
                        {
                            tblPurchase_Search_APInvoice = _purchase_V2_BLL.Select_tblPur_APInvoice_by_CreateDate_BLL(DateFrom, DateTo, 100);
                            dgv_Search_APInvoice.DataSource = tblPurchase_Search_APInvoice; 
                        }
                        else
                        {
                            tblPurchase_Search_APInvoice = _purchase_V2_BLL.Select_tblPur_APInvoice_by_CreateDate_BLL(DateFrom, DateTo);
                            dgv_Search_APInvoice.DataSource = tblPurchase_Search_APInvoice;
                        }
                        break;
                    }

                default:
                    MessageBox.Show("Please select a valid tab.");
                    break;
            }
        }

        private void btnSearch_by_Supplier_Click(object sender, EventArgs e)
        {
            int _supplierID = Convert.ToInt32(cbo_tblPur_Supplier.SelectedValue);

            switch (tab_Control.SelectedIndex)
            {
                case 0:
                    // View PO Tab 1 -
                    {
                        if (ckcViewTop100.Checked == true)
                        {
                            tblPur_Search_PO = _purchase_V2_BLL.Select_tblPur_PO_by_SupplierID_BLL(_supplierID, 100);

                            dgv_Search_PO.DataSource = tblPur_Search_PO;
                        }
                        else
                        {
                            tblPur_Search_PO = _purchase_V2_BLL.Select_tblPur_PO_by_SupplierID_BLL(_supplierID);
                            dgv_Search_PO.DataSource = tblPur_Search_PO;
                        }
                        break;
                    }

                case 1:
                    // View GRPO Tab 2 -
                    {
                        if (ckcViewTop100.Checked == true)
                        {
                            tblPur_Search_GRPO = _purchase_V2_BLL.Select_tblPur_GRPO_by_SupplierID_BLL(_supplierID, 100);
                            dgv_Search_GRPO.DataSource = tblPur_Search_GRPO;
                        }
                        else
                        {
                            tblPur_Search_GRPO = _purchase_V2_BLL.Select_tblPur_GRPO_by_SupplierID_BLL(_supplierID);
                            dgv_Search_GRPO.DataSource = tblPur_Search_GRPO;
                        }
                        break;
                    }

                case 2: // View APInvoice Tab 3 -
                    {
                        if (ckcViewTop100.Checked == true)
                        {
                            tblPurchase_Search_APInvoice = _purchase_V2_BLL.Select_tblPur_APInvoice_by_SupplierID_BLL(_supplierID, 100);
                            dgv_Search_APInvoice.DataSource = tblPurchase_Search_APInvoice;
                        }
                        else
                        {
                            tblPurchase_Search_APInvoice = _purchase_V2_BLL.Select_tblPur_APInvoice_by_SupplierID_BLL(_supplierID);
                            dgv_Search_APInvoice.DataSource = tblPurchase_Search_APInvoice;
                        }
                        break;
                    }
                default:
                    // Handle other tabs if needed
                    MessageBox.Show("Please select a valid tab.");
                    break;
            }
        }

        private void btnUpdate_GRPO_Click(object sender, EventArgs e)
        {
            string messsage = "Do you want to update this GRPO ? ";
            DialogResult result = MessageBox.Show(messsage, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                frm_Update_GRPO frm = new frm_Update_GRPO();
                frm._GRPO_Number = Convert.ToInt32(dgv_Search_GRPO.CurrentRow.Cells["GRPONumber"].Value.ToString());
                frm._PO_Number = Convert.ToInt32(dgv_Search_GRPO.CurrentRow.Cells["PONumber"].Value.ToString());
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    // Refresh the data after updating GRPO
                    Refresh_Data();
                }
            }
        }

        private void cms_dgv_Search_GRPO_Copy_AP_Invoice_Click(object sender, EventArgs e)
        {
            btnCopy_to_AP_Invoice.PerformClick();
        }

        private void cms_dgv_Search_GRPO_Edit_Table_Viewing_Click(object sender, EventArgs e)
        {
            string Col_Mode = dgv_Search_GRPO.AutoSizeColumnsMode.ToString();

            frmDataGridView_Modify frm = new frmDataGridView_Modify(_commonBLL.Get_Attribute_from_DatagridView(dgv_Search_GRPO), Col_Mode);

            if (frm.ShowDialog() == DialogResult.OK)
            {
                _commonBLL.Set_Attribute_to_DatagridView(dgv_Search_GRPO, frm.table_Updated_Att, frm.Col_ModeID);
            }
        }

        private void cms_dgv_Search_GRPO_Refresh_Data_Click(object sender, EventArgs e)
        {
            Refresh_Data();
        }

        private void cms_dgv_Search_GRPO_Update_GRPO_Click(object sender, EventArgs e)
        {
            btnUpdate_GRPO.PerformClick();
        }

        private void cms_dgv_Search_PO_Copy_to_GRPO_Click(object sender, EventArgs e)
        {
            btnCopytoGRPO.PerformClick();
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

        private void cms_dgv_Search_PO_Refresh_Data_Click(object sender, EventArgs e)
        {
            Refresh_Data();
        }

        private void dgv_Search_GRPO_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Bỏ tô màu các dòng khác (nếu muốn chỉ highlight dòng vừa click)
            foreach (DataGridViewRow row in dgv_Search_GRPO.Rows)
            {
                row.DefaultCellStyle.BackColor = Color.White; // Màu nền mặc định
            }

            // Kiểm tra dòng được chọn có hợp lệ không
            if (e.RowIndex >= 0 && e.RowIndex < dgv_Search_GRPO.Rows.Count)
            {
                DataGridViewRow selectedRow = dgv_Search_GRPO.Rows[e.RowIndex];
                selectedRow.DefaultCellStyle.BackColor = Color.AliceBlue; // Màu nền highlight cho dòng được chọn
            }
        }

        private void dgv_Search_GRPO_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
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
            // 4. Ctrl + U to btnUpdate_GRPO_Click
            else if (e.Control && e.KeyCode == Keys.U)
            {
                e.SuppressKeyPress = true; // Ngăn chặn hành động mặc định của Ctrl + U
                btnUpdate_GRPO.PerformClick(); // Gọi sự kiện click của nút Update GRPO
            }
            // 5. Ctrl + tab to switch to next tab
            else if (e.Control && e.KeyCode == Keys.Tab)
            {
                int currentIndex = tab_Control.SelectedIndex;
                int newIndex = currentIndex - 1; //
                if (newIndex < 0) // Nếu đã ở tab đầu tiên, quay lại tab cuối cùng
                {
                    newIndex = tab_Control.TabCount - 1;
                }
                tab_Control.SelectedIndex = newIndex;
                e.Handled = true;
            }
            // 6. Ctrl + 1 to switch to first tab
            else if (e.Control && e.KeyCode == Keys.D1)
            {
                e.SuppressKeyPress = true; // Ngăn chặn hành động mặc định của Ctrl + 1
                tab_Control.SelectedIndex = 0; // Chọn tab đầu tiên
            }
            // 7. Ctrl + 2 to switch to second tab
            else if (e.Control && e.KeyCode == Keys.D2)
            {
                e.SuppressKeyPress = true; // Ngăn chặn hành động mặc định của Ctrl + 2
                tab_Control.SelectedIndex = 1; // Chọn tab thứ hai
            }
            // 8. Ctrl + 3 to switch to third tab
            else if (e.Control && e.KeyCode == Keys.D3)
            {
                e.SuppressKeyPress = true; // Ngăn chặn hành động mặc định của Ctrl + 3
                tab_Control.SelectedIndex = 2; // Chọn tab thứ ba
            }
        }

        private void tab_Control_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tab_Control.SelectedIndex)
            {
                case 0:
                    btnSearch_by_Supplier.PerformClick();
                    break;

                case 1:
                    btnSearch_by_Supplier.PerformClick();
                    break;

                case 2:
                    btnSearch_by_Supplier.PerformClick();
                    break;
            }
        }
        

        private void cms_dgv_Search_APInvoice_Refresh_Data_Click(object sender, EventArgs e)
        {
            Refresh_Data();
        }

        private void dgv_Search_APInvoice_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Bỏ tô màu các dòng khác (nếu muốn chỉ highlight dòng vừa click)
            foreach (DataGridViewRow row in dgv_Search_APInvoice.Rows)
            {
                row.DefaultCellStyle.BackColor = Color.White; // Màu nền mặc định
            }

            // Kiểm tra dòng được chọn có hợp lệ không
            if (e.RowIndex >= 0 && e.RowIndex < dgv_Search_APInvoice.Rows.Count)
            {
                DataGridViewRow selectedRow = dgv_Search_APInvoice.Rows[e.RowIndex];
                selectedRow.DefaultCellStyle.BackColor = Color.AliceBlue; // Màu nền highlight cho dòng được chọn
            }
        }

        private void dgv_Search_APInvoice_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
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


        #endregion ===== 04. EVENT HANDLER =====

        private void cms_dgv_Search_APInvoice_Edit_Table_Viewing_Click(object sender, EventArgs e)
        {
            string Col_Mode = dgv_Search_APInvoice.AutoSizeColumnsMode.ToString();

            frmDataGridView_Modify frm = new frmDataGridView_Modify(_commonBLL.Get_Attribute_from_DatagridView(dgv_Search_APInvoice), Col_Mode);

            if (frm.ShowDialog() == DialogResult.OK)
            {
                _commonBLL.Set_Attribute_to_DatagridView(dgv_Search_APInvoice, frm.table_Updated_Att, frm.Col_ModeID);
            }
        }

        private void btnUpdate_APInvoice_Click(object sender, EventArgs e)
        {
            string messsage = "Do you want to update this AP Invoice ? ";
            DialogResult result = MessageBox.Show(messsage, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                frm_Update_APInvoice frm = new frm_Update_APInvoice();
                frm.APInvoiceID = Convert.ToInt32(dgv_Search_APInvoice.CurrentRow.Cells["ID"].Value.ToString());
                frm.ShowDialog();
            }
        }

        private void cms_dgv_Search_APInvoice_Update_APInvoice_Click(object sender, EventArgs e)
        {
            btnUpdate_APInvoice.PerformClick();
        }
    }
}