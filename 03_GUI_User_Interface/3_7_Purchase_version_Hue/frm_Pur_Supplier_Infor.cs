using PLM_Lynx._02_BLL_Bussiness_Logic_Layer;
using System;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace PLM_Lynx._03_GUI_User_Interface._3_7_Purchase_version_Hue
{
    public partial class frm_Pur_Supplier_Infor : Form
    {
        private Purchase_V2_BLL _purchase_V2_BLL = new Purchase_V2_BLL();

        public string SupplierID { get; set; }
        public string SupplierCode { get; set; }
        public string SupplierName { get; set; }
        public string SupplierLocation { get; set; }
        public string SupplierPhone { get; set; }
        public string SupplierTaxNumber { get; set; }

        public string SupplierNote { get; set; }
        public string SupplierContactPerson { get; set; }

        private DataTable tbl_ContactPerson = new DataTable();

        public frm_Pur_Supplier_Infor()
        {
            InitializeComponent();
        }

        private void frm_Pur_Supplier_Infor_Load(object sender, EventArgs e)
        {
            LoadAllInformation();
        }

        private void LoadAllInformation()
        {
            txtSupplierID.Text = SupplierID;
            txtSupplierCode.Text = SupplierCode;
            txtSupplierName.Text = SupplierName;
            txtSupplierLocation.Text = SupplierLocation;
            txtSupplierPhone.Text = SupplierPhone;
            txtSupplierTaxNumber.Text = SupplierTaxNumber;
            txtSupplierNote.Text = SupplierNote;
            string contactPerson = SupplierContactPerson;
            if (string.IsNullOrEmpty(contactPerson))
            {
                tbl_ContactPerson.Columns.Clear();
                tbl_ContactPerson.Columns.Add("Name", typeof(string));
                tbl_ContactPerson.Columns.Add("Phone", typeof(string));
                dgvContactPerson.DataSource = tbl_ContactPerson;
            }
            else
            {
                convert_table_contact_person(contactPerson);
                // Clear dgvContactPerson
                dgvContactPerson.DataSource = null;
                dgvContactPerson.DataSource = tbl_ContactPerson;
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            string tb = "Are you sure you want to close this form?";
            DialogResult kq = MessageBox.Show(tb, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string tb = "Are you sure you want to save this information?";
            DialogResult kq = MessageBox.Show(tb, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq == DialogResult.No)
            {
                return;
            }
            else
            {
                string code = txtSupplierCode.Text.Trim();
                string name = txtSupplierName.Text.Trim();
                string phone = txtSupplierPhone.Text.Trim();
                string tax = txtSupplierTaxNumber.Text.Trim();
                string location = txtSupplierLocation.Text.Trim();
                string note = txtSupplierNote.Text.Trim();
                string contactPerson = ConvertDataGridViewToString(dgvContactPerson);

                if (txtSupplierID.Text == string.Empty)
                {
                    // Add new supplier
                    if (_purchase_V2_BLL.Insert_NewSupplier_BLL(code, name, phone, tax, location, note, contactPerson))
                    {
                        MessageBox.Show("New supplier added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Failed to add new supplier.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    // Modify existing supplier
                    int id;
                    if (int.TryParse(txtSupplierID.Text.Trim(), out id))
                    {
                        if (_purchase_V2_BLL.Update_ExistingSupplier_BLL(id, code, name, phone, tax, location, note, contactPerson))
                        {
                            MessageBox.Show("Supplier information updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Failed to update supplier information.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private string ConvertDataGridViewToString(DataGridView dgv)
        {
            if (dgv == null || dgv.Rows.Count == 0)
            {
                return string.Empty; // Return empty string if DataGridView is null or has no rows
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    if (row.IsNewRow) continue; // Skip the new row placeholder
                    string name = row.Cells["Name"].Value?.ToString() ?? string.Empty;
                    string phone = row.Cells["Phone"].Value?.ToString() ?? string.Empty;
                    sb.Append($"|| {name} / {phone} || ");
                }
                return sb.ToString().Trim();
            }
        }
    }
}