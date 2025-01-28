using PLM_Lynx._01_DAL_Data_Access_Layer;
using PLM_Lynx._02_BLL_Bussiness_Logic_Layer;
using System;
using System.Data;
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
        }

        #endregion

        /// <summary>
        /// ********** REGION - [2]  : => List Event  Load
        /// </summary>
        #region

        public frmMakePO()
        {
            InitializeComponent();
        }

        private void InitialTableListItem()
        {
            // ---> Create DataTable ListItem
            //table_ListItem.Columns.Add("PartCode", typeof(string));
            //table_ListItem.Columns.Add("PartName", typeof(string));
            //table_ListItem.Columns.Add("Quantity", typeof(int));
            //table_ListItem.Columns.Add("UnitPrice", typeof(int));
            //table_ListItem.Columns.Add("Discount", typeof(int));
            //table_ListItem.Columns.Add("Amount", typeof(decimal));
        }

        private void frmMakePO_Load(object sender, EventArgs e)
        {
            // ---> Load  information of users
            txtStaffName.Text = _usercurrent;
            tblUsers _user_data = _purchasebll.GetUserInfor(_usercurrent);
            txtStaffDept.Text = _user_data.DepartmentName;
            txtStaffPosition.Text = _user_data.Position;

            // ---> Load information of PO No
            tblPO _po_data = _purchasebll.GetInforPO();
            DateTime thelastestdate = _po_data.PODate;
            DateTime today = DateTime.Now.Date;

            string PO_no;
            string thelastestPO = _po_data.POCode;
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
            table_ListItem.Columns.Add("Discount", typeof(int));
            table_ListItem.Columns.Add("Amount", typeof(decimal));

            dgvListItem.AllowUserToAddRows = false;
            
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

            //decimal partprice = Convert.ToDecimal(dgvListTimKiem.CurrentRow.Cells[2].Value);
            decimal partprice ;
            if (dgvListTimKiem.CurrentRow.Cells[2].Value.ToString() == "" || dgvListTimKiem.CurrentRow.Cells[2].Value.ToString() =="0")
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

                table_ListItem.Rows.Add(partcode, partname, 1, partprice, 0, 0);
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
            }
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
            }
        }

        #endregion
    }
}