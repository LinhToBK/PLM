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

namespace PLM_Lynx._03_GUI_User_Interface._3_7_Purchase_version_Hue
{
    public partial class frmPurchase_Common_Information : Form
    {
        private Purchase_V2_BLL _purchase_V2_BLL = new Purchase_V2_BLL();

        // SupplierID , SupplierCode, SupplierName, SupplierLocation, SupplierPhone, SupplierTaxNumber, SupplierNote, SupplierContactPerson
        private DataTable tblPur_Supplier = new DataTable();

        private DataTable tbl_ContactPerson = new DataTable();

        // StatusID, StatusName
        private DataTable tbl_Pur_Status = new DataTable();

        // UnitID, UnitName, UnitValue, UnitContent
        private DataTable tbl_Pur_Unit = new DataTable();

        // CurrencyID, CurrencyName, CurrencyRate
        private DataTable tbl_Pur_Currency = new DataTable();

        // WareHouseID, WareHouseName
        private DataTable tbl_Pur_WareHouse = new DataTable();

        public frmPurchase_Common_Information()
        {
            InitializeComponent();
        }

        private void frmPurchase_Common_Information_Load(object sender, EventArgs e)
        {
            LoadAllInformation();
        }

        /// <summary>
        /// Lấy các thông tin
        /// </summary>
        private void LoadAllInformation()
        {
            // ==> 01. Load thông tin của Supplier
            tblPur_Supplier.Columns.Clear();
            tblPur_Supplier = _purchase_V2_BLL.Select_tblPur_Supplier_BLL();
            dgv_tblPur_Supplier.DataSource = tblPur_Supplier;
            dgv_tblPur_Supplier_ViewFit();

            // ==> 02. Load thông tin của Status
            tbl_Pur_Status.Columns.Clear();
            tbl_Pur_Status = _purchase_V2_BLL.Select_tblPur_Status_BLL();
            dgv_tblPur_Status.DataSource = tbl_Pur_Status;
            dgv_tblPur_Status.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_tblPur_Status.AllowUserToAddRows = false;
            dgv_tblPur_Status.AllowUserToDeleteRows = false;
            dgv_tblPur_Status.Columns[0].ReadOnly = true;
            dgv_tblPur_Status.Columns[1].ReadOnly = true;

            // ==> 03.  Load thông tin của Unit

            tbl_Pur_Unit.Columns.Clear();
            tbl_Pur_Unit = _purchase_V2_BLL.Select_tblPur_Unit_BLL();
            dgv_tblPur_Unit.DataSource = tbl_Pur_Unit;
            dgv_tblPur_Unit_ViewFit();

            // ==> 04. Load thông tin của Currency
            tbl_Pur_Currency.Columns.Clear();
            tbl_Pur_Currency = _purchase_V2_BLL.Select_tblPur_Currency_BLL();
            dgv_tblPur_Currency.DataSource = tbl_Pur_Currency;

            dgv_tblPur_Currency.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgv_tblPur_Currency.AllowUserToAddRows = false;
            dgv_tblPur_Currency.AllowUserToDeleteRows = false;
            dgv_tblPur_Currency.Columns["CurrencyID"].ReadOnly = true;
            dgv_tblPur_Currency.Columns["CurrencyName"].ReadOnly = true;
            dgv_tblPur_Currency.Columns["CurrencyRate"].ReadOnly = true;

            // ==> 05. Load thông tin của WareHouse
            tbl_Pur_WareHouse.Columns.Clear();
            tbl_Pur_WareHouse = _purchase_V2_BLL.Select_tblPur_WareHouse_BLL();
            dgv_tblPur_WareHouse.DataSource = tbl_Pur_WareHouse;
            dgv_tblPur_WareHouse.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_tblPur_WareHouse.AllowUserToAddRows = false;
            dgv_tblPur_WareHouse.AllowUserToDeleteRows = false;
        }

        private void dgv_tblPur_Supplier_ViewFit()
        {
            if (dgv_tblPur_Supplier.Rows.Count > 0)
            {
                dgv_tblPur_Supplier.AllowUserToAddRows = false;
                dgv_tblPur_Supplier.AllowUserToDeleteRows = false;
                dgv_tblPur_Supplier.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                // Hiển thị tên các cột
                dgv_tblPur_Supplier.Columns["SupplierID"].HeaderText = "ID";
                dgv_tblPur_Supplier.Columns["SupplierCode"].HeaderText = "Code";
                dgv_tblPur_Supplier.Columns["SupplierName"].HeaderText = "Name";
                dgv_tblPur_Supplier.Columns["SupplierLocation"].HeaderText = "Location";
                dgv_tblPur_Supplier.Columns["SupplierPhone"].HeaderText = "Phone";
                dgv_tblPur_Supplier.Columns["SupplierTaxNumber"].HeaderText = "Tax Number";

                // Chỉnh kích thước các cột
                dgv_tblPur_Supplier.Columns["SupplierID"].Width = 30;
                dgv_tblPur_Supplier.Columns["SupplierCode"].Width = 60;
                //dgv_tblPur_Supplier.Columns["SupplierName"].Width = 200;
                dgv_tblPur_Supplier.Columns["SupplierLocation"].Width = 200;
                dgv_tblPur_Supplier.Columns["SupplierPhone"].Width = 100;
                dgv_tblPur_Supplier.Columns["SupplierTaxNumber"].Width = 100;

                // Ẩn các cột không cần thiết
                dgv_tblPur_Supplier.Columns["SupplierNote"].Visible = false; // Ẩn cột này nếu không cần thiết
                dgv_tblPur_Supplier.Columns["SupplierContactPerson"].Visible = false; // Ẩn cột này nếu không cần thiết
            }
        }

        private void dgv_tblPur_Unit_ViewFit()
        {
            if (dgv_tblPur_Unit.Rows.Count > 0)
            {
                //dgv_tblPur_Unit.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                // Chỉnh kích thước các cột
                dgv_tblPur_Unit.Columns["UnitID"].Width = 30;
                dgv_tblPur_Unit.Columns["UnitName"].Width = 100;
                dgv_tblPur_Unit.Columns["UnitValue"].Width = 100;
                dgv_tblPur_Unit.Columns["UnitContent"].Width = 200;
                dgv_tblPur_Unit.AllowUserToAddRows = false;
                dgv_tblPur_Unit.AllowUserToDeleteRows = false;
                // Hiển thị tên các cột
                dgv_tblPur_Unit.Columns["UnitID"].HeaderText = "ID";
                dgv_tblPur_Unit.Columns["UnitName"].HeaderText = "Name";
                dgv_tblPur_Unit.Columns["UnitValue"].HeaderText = "Value";
                dgv_tblPur_Unit.Columns["UnitContent"].HeaderText = "Content";

                dgv_tblPur_Unit.Columns["UnitID"].ReadOnly = true;
                dgv_tblPur_Unit.Columns["UnitName"].ReadOnly = true;
                dgv_tblPur_Unit.Columns["UnitValue"].ReadOnly = true;
                dgv_tblPur_Unit.Columns["UnitContent"].ReadOnly = true;
            }
        }

        private void dgv_tblContactPerson_ViewFit()
        {
            if (dgvContactPersonList.Rows.Count > 0)
            {
                dgvContactPersonList.AllowUserToAddRows = false;
                dgvContactPersonList.AllowUserToDeleteRows = false;
                dgvContactPersonList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                // Chỉnh kích thước các cột
                dgvContactPersonList.Columns[0].Width = 150;
            }
        }

        private void convert_table_contact_person(string ContactPerson)
        {
            //|| Linh / +84333568236 || Lê Thị A / +841234578 ||
            tbl_ContactPerson.Columns.Clear();
            string[] contactPersons = ContactPerson.Split('|');
            tbl_ContactPerson.Columns.Add("Name", typeof(string));
            tbl_ContactPerson.Columns.Add("Phone", typeof(string));
            foreach (string person in contactPersons)
            {
                if (!string.IsNullOrWhiteSpace(person))
                {
                    string[] details = person.Split('/');
                    if (details.Length == 2)
                    {
                        DataRow row = tbl_ContactPerson.NewRow();
                        row["Name"] = details[0].Trim();
                        row["Phone"] = details[1].Trim();
                        tbl_ContactPerson.Rows.Add(row);
                    }
                }
            }
        }

        private void dgv_tblPur_Supplier_Click(object sender, EventArgs e)
        {
            // Khi click vào dòng của dgv_tblPur_Supplier, lấy thông tin liên hệ
            // và hiển thị vào các ô textbox
            if (dgv_tblPur_Supplier.Rows.Count > 0)
            {
                txtSupplierID.Text = dgv_tblPur_Supplier.CurrentRow.Cells["SupplierID"].Value.ToString();
                txtSupplierCode.Text = dgv_tblPur_Supplier.CurrentRow.Cells["SupplierCode"].Value.ToString();
                txtSupplierName.Text = dgv_tblPur_Supplier.CurrentRow.Cells["SupplierName"].Value.ToString();
                txtSupplierLocation.Text = dgv_tblPur_Supplier.CurrentRow.Cells["SupplierLocation"].Value.ToString();
                txtSupplierPhone.Text = dgv_tblPur_Supplier.CurrentRow.Cells["SupplierPhone"].Value.ToString();
                txtSupplierTaxNumber.Text = dgv_tblPur_Supplier.CurrentRow.Cells["SupplierTaxNumber"].Value.ToString();
                txtSupplierNote.Text = dgv_tblPur_Supplier.CurrentRow.Cells["SupplierNote"].Value.ToString();
                string contactPerson = dgv_tblPur_Supplier.CurrentRow.Cells["SupplierContactPerson"].Value.ToString();
                tbl_ContactPerson.Rows.Clear(); // Xóa dữ liệu cũ trong bảng tbl_ContactPerson
                convert_table_contact_person(contactPerson);
                dgvContactPersonList.DataSource = tbl_ContactPerson;
                dgv_tblContactPerson_ViewFit();
            }
        }

        private void addNewSupplierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Mở form để thêm mới nhà cung cấp
            frm_Pur_Supplier_Infor frm = new frm_Pur_Supplier_Infor();
            frm.SupplierID = string.Empty;
            frm.SupplierCode = string.Empty;
            frm.SupplierName = string.Empty;
            frm.SupplierLocation = string.Empty;
            frm.SupplierPhone = string.Empty;
            frm.SupplierTaxNumber = string.Empty;
            frm.SupplierNote = string.Empty;
            frm.SupplierContactPerson = string.Empty;
            frm.ShowDialog();

            // Sau khi đóng form, load lại thông tin nhà cung cấp
            LoadAllInformation();
        }

        private void modifyThisSupplierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Mở form để sửa thông tin nhà cung cấp đã chọn
            frm_Pur_Supplier_Infor frm = new frm_Pur_Supplier_Infor();
            frm.SupplierID = dgv_tblPur_Supplier.CurrentRow.Cells["SupplierID"].Value.ToString();
            frm.SupplierCode = dgv_tblPur_Supplier.CurrentRow.Cells["SupplierCode"].Value.ToString();
            frm.SupplierName = dgv_tblPur_Supplier.CurrentRow.Cells["SupplierName"].Value.ToString();
            frm.SupplierLocation = dgv_tblPur_Supplier.CurrentRow.Cells["SupplierLocation"].Value.ToString();
            frm.SupplierPhone = dgv_tblPur_Supplier.CurrentRow.Cells["SupplierPhone"].Value.ToString();
            frm.SupplierTaxNumber = dgv_tblPur_Supplier.CurrentRow.Cells["SupplierTaxNumber"].Value.ToString();
            frm.SupplierNote = dgv_tblPur_Supplier.CurrentRow.Cells["SupplierNote"].Value.ToString();
            frm.SupplierContactPerson = dgv_tblPur_Supplier.CurrentRow.Cells["SupplierContactPerson"].Value.ToString();
            frm.ShowDialog();

            // Sau khi đóng form, load lại thông tin nhà cung cấp
            LoadAllInformation();
        }

        private void btnModifyStatus_Click(object sender, EventArgs e)
        {
            string tb = "Are you sure you want to modify this status?";
            DialogResult kq = MessageBox.Show(tb, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq == DialogResult.No)
            {
                return; // Nếu người dùng chọn No, không thực hiện gì cả
            }
            else
            {
                if (dgv_tblPur_Status.Rows.Count > 0)
                {
                    txtStatusName.ReadOnly = false; // Cho phép sửa tên trạng thái
                }
            }
        }

        private void btnSaveStatus_Click(object sender, EventArgs e)
        {
            string tb = "Are you sure you want to save about modifying status?";
            DialogResult kq = MessageBox.Show(tb, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq == DialogResult.Yes)
            {
                // Lưu thông tin trạng thái
                int statusID = Convert.ToInt16(txtStatusID.Text.Trim());
                string statusName = txtStatusName.Text.Trim();
                if (!string.IsNullOrEmpty(statusName))
                {
                    // Cập nhật thông tin trạng thái
                    if (_purchase_V2_BLL.Update_ExistingStatus_BLL(statusID, statusName))
                    {
                        MessageBox.Show("Status updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadAllInformation(); // Load lại thông tin trạng thái
                    }
                    else
                    {
                        MessageBox.Show("Failed to update status.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void dgv_tblPur_Status_Click(object sender, EventArgs e)
        {
            if (dgv_tblPur_Status.Rows.Count > 0)
            {
                txtStatusID.Text = dgv_tblPur_Status.CurrentRow.Cells[0].Value.ToString();
                txtStatusName.Text = dgv_tblPur_Status.CurrentRow.Cells[1].Value.ToString();
            }
        }

        private void dgv_tblPur_Unit_Click(object sender, EventArgs e)
        {
            if (dgv_tblPur_Unit.Rows.Count > 0)
            {
                txtUnitID.Text = dgv_tblPur_Unit.CurrentRow.Cells["UnitID"].Value.ToString();
                txtUnitName.Text = dgv_tblPur_Unit.CurrentRow.Cells["UnitName"].Value.ToString();
                txtUnitValue.Text = dgv_tblPur_Unit.CurrentRow.Cells["UnitValue"].Value.ToString();
                txtUnitContent.Text = dgv_tblPur_Unit.CurrentRow.Cells["UnitContent"].Value.ToString();
            }
        }

        private void btnNewUnit_Click(object sender, EventArgs e)
        {
            string tb = "Are you sure you want to add a new unit?";
            DialogResult kq = MessageBox.Show(tb, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq == DialogResult.Yes)
            {
                txtUnitID.Text = string.Empty;
                txtUnitName.Text = string.Empty;
                txtUnitValue.Text = string.Empty;
                txtUnitContent.Text = string.Empty;
                txtUnitName.ReadOnly = false;
                txtUnitValue.ReadOnly = false;
                txtUnitContent.ReadOnly = false;
            }
        }

        private void btnModifyUnit_Click(object sender, EventArgs e)
        {
            string tb = "Are you sure you want to modify this unit?";
            DialogResult kq = MessageBox.Show(tb, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq == DialogResult.Yes)
            {
                if (txtUnitID.Text == string.Empty)
                {
                    MessageBox.Show("Please select a unit to modify.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                txtUnitName.ReadOnly = false;
                txtUnitValue.ReadOnly = false;
                txtUnitContent.ReadOnly = false;
            }
        }

        private void btnSaveUnit_Click(object sender, EventArgs e)
        {
            string tb = "Are you sure you want to save this unit?";
            DialogResult kq = MessageBox.Show(tb, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq == DialogResult.Yes)
            {
                string ID = txtUnitID.Text.Trim();
                string Name = txtUnitName.Text.Trim();
                string Value = txtUnitValue.Text.Trim();
                // Check Value is decimal
                decimal valueDecimal;
                if (!decimal.TryParse(Value, out valueDecimal))
                {
                    MessageBox.Show("Value must be a decimal number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (Name.Length > 20 || Value.Length > 64)
                {
                    MessageBox.Show("Name must be less than 20 characters and Value must be less than 64 characters.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (Name == string.Empty)
                {
                    MessageBox.Show("Name cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string Content = txtUnitContent.Text.Trim();
                if (ID == string.Empty)
                {
                    // Add New Unit

                    if (_purchase_V2_BLL.Insert_NewUnit_BLL(Name, valueDecimal, Content))
                    {
                        MessageBox.Show("New unit added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadAllInformation(); // Load lại thông tin đơn vị
                    }
                    else
                    {
                        MessageBox.Show("Failed to add new unit.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    // Update Existing Unit
                    if (_purchase_V2_BLL.Update_ExistingUnit_BLL(Convert.ToInt32(ID), Name, valueDecimal, Content))
                    {
                        MessageBox.Show("Unit updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadAllInformation(); // Load lại thông tin đơn vị
                    }
                    else
                    {
                        MessageBox.Show("Failed to update unit.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void dgv_tblPur_Currency_Click(object sender, EventArgs e)
        {
            if (dgv_tblPur_Currency.Rows.Count > 0)
            {
                txtCurrencyID.Text = dgv_tblPur_Currency.CurrentRow.Cells["CurrencyID"].Value.ToString();
                txtCurrencyName.Text = dgv_tblPur_Currency.CurrentRow.Cells["CurrencyName"].Value.ToString();
                txtCurrencyRate.Text = dgv_tblPur_Currency.CurrentRow.Cells["CurrencyRate"].Value.ToString();
            }
        }

        private void btnNewCurrency_Click(object sender, EventArgs e)
        {
            string tb = "Are you sure you want to add a new currency?";
            DialogResult kq = MessageBox.Show(tb, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq == DialogResult.Yes)
            {
                txtCurrencyID.Text = string.Empty;
                txtCurrencyName.Text = string.Empty;
                txtCurrencyRate.Text = string.Empty;
                txtCurrencyName.ReadOnly = false;
                txtCurrencyRate.ReadOnly = false;
            }
        }

        private void btnModifyCurrency_Click(object sender, EventArgs e)
        {
            string tb = "Are you sure you want to modify this currency?";
            DialogResult kq = MessageBox.Show(tb, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq == DialogResult.Yes)
            {
                if (txtCurrencyID.Text == string.Empty)
                {
                    MessageBox.Show("Please select a currency to modify.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                txtCurrencyName.ReadOnly = false;
                txtCurrencyRate.ReadOnly = false;
            }
        }

        private void btnSaveCurrency_Click(object sender, EventArgs e)
        {
            string tb = "Are you sure you want to save this currency?";
            DialogResult kq = MessageBox.Show(tb, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq == DialogResult.Yes)
            {
                string id = txtCurrencyID.Text.Trim();
                string name = txtCurrencyName.Text.Trim();
                string rate = txtCurrencyRate.Text.Trim();
                // Check rate is decimal
                decimal rateDecimal;
                if (!decimal.TryParse(rate, out rateDecimal))
                {
                    MessageBox.Show("Rate must be a decimal number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (name.Length > 10)
                {
                    MessageBox.Show("Name must be less than 10 characters ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (name == string.Empty && rate == string.Empty)
                {
                    MessageBox.Show("Name / Rate cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (id == string.Empty)
                {
                    // Add New Currency
                    if (_purchase_V2_BLL.Insert_NewCurrency_BLL(name, rateDecimal))
                    {
                        MessageBox.Show("New currency added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadAllInformation(); // Load lại thông tin tiền tệ
                    }
                    else
                    {
                        MessageBox.Show("Failed to add new currency.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    // Update Existing Currency
                    if (_purchase_V2_BLL.Update_ExistingCurrency_BLL(Convert.ToInt32(id), name, rateDecimal))
                    {
                        MessageBox.Show("Currency updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadAllInformation(); // Load lại thông tin tiền tệ
                    }
                    else
                    {
                        MessageBox.Show("Failed to update currency.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void dgv_tblPur_WareHouse_Click(object sender, EventArgs e)
        {
            if (dgv_tblPur_WareHouse.Rows.Count > 0)
            {
                txtWareHouseID.Text = dgv_tblPur_WareHouse.CurrentRow.Cells["WareHouseID"].Value.ToString();
                txtWareHouseName.Text = dgv_tblPur_WareHouse.CurrentRow.Cells["WareHouseName"].Value.ToString();
            }
        }

        private void btnNewWareHouse_Click(object sender, EventArgs e)
        {
            string tb = "Are you sure you want to add a new warehouse?";
            DialogResult kq = MessageBox.Show(tb, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq == DialogResult.Yes)
            {
                txtWareHouseID.Text = string.Empty;
                txtWareHouseName.Text = string.Empty;
                txtWareHouseName.ReadOnly = false;
            }
        }

        private void btnModifyWareHouse_Click(object sender, EventArgs e)
        {
            string tb = "Are you sure you want to modify this warehouse?";
            DialogResult kq = MessageBox.Show(tb, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq == DialogResult.Yes)
            {
                if (txtWareHouseID.Text == string.Empty)
                {
                    MessageBox.Show("Please select a warehouse to modify.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                txtWareHouseName.ReadOnly = false;
            }
        }

        private void btnSaveWareHouse_Click(object sender, EventArgs e)
        {
            string tb = "Are you sure you want to save this warehouse?";
            DialogResult kq = MessageBox.Show(tb, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq == DialogResult.Yes)
            {
                string id = txtWareHouseID.Text.Trim();
                string name = txtWareHouseName.Text.Trim();

                if (name.Length > 64)
                {
                    MessageBox.Show("Name must be less than 50 characters.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (name == string.Empty)
                {
                    MessageBox.Show("Name cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (id == string.Empty)
                {
                    // Add New Warehouse
                    if (_purchase_V2_BLL.Insert_NewWareHouse_BLL(name))
                    {
                        MessageBox.Show("New warehouse added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadAllInformation(); // Load lại thông tin kho hàng
                    }
                    else
                    {
                        MessageBox.Show("Failed to add new warehouse.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    // Update Existing Warehouse
                    if (_purchase_V2_BLL.Update_ExistingWareHouse_BLL(Convert.ToInt32(id), name))
                    {
                        MessageBox.Show("Warehouse updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadAllInformation(); // Load lại thông tin kho hàng
                    }
                    else
                    {
                        MessageBox.Show("Failed to update warehouse.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}