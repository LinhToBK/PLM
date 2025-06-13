using PLM_Lynx._02_BLL_Bussiness_Logic_Layer;
using System;
using System.Data;
using System.Windows.Forms;

namespace PLM_Lynx._03_GUI_User_Interface._3_7_Purchase_version_Hue
{
    public partial class frm_Choose_Supplier : Form
    {
        // SupplierID, SupplierCode, SupplierName, SupplierLocation, SupplierPhone, SupplierTaxNumber, SupplierNote, SupplierContactPerson
        private DataTable tblPur_Supplier = new DataTable();

        private Purchase_V2_BLL _purchase_V2_BLL = new Purchase_V2_BLL();

        public string SelectedSupplierID { get; set; }
        public string SelectedSupplierName { get; set; }

        public frm_Choose_Supplier()
        {
            InitializeComponent();
            tblPur_Supplier = _purchase_V2_BLL.Select_tblPur_Supplier_BLL();
        }

        private void frm_Choose_Supplier_Load(object sender, EventArgs e)
        {
            dgv_tblPur_Supplier.DataSource = tblPur_Supplier;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            string message = "Are you sure you want to cancel?";
            DialogResult result = MessageBox.Show(message, "Cancel", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void dgv_tblPur_Supplier_Click(object sender, EventArgs e)
        {
            if (dgv_tblPur_Supplier.Rows.Count > 0)
            {
                txtSupplierID.Text = dgv_tblPur_Supplier.CurrentRow.Cells["SupplierID"].Value.ToString();
                txtSupplierName.Text = dgv_tblPur_Supplier.CurrentRow.Cells["SupplierName"].Value.ToString();
            }
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSupplierID.Text) || string.IsNullOrEmpty(txtSupplierName.Text))
            {
                MessageBox.Show("Please select a supplier before applying.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string message = "Are you sure you want to apply this supplier?";
            DialogResult result = MessageBox.Show(message, "Apply", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                SelectedSupplierID = txtSupplierID.Text;
                SelectedSupplierName = txtSupplierName.Text;
                this.DialogResult = DialogResult.OK; // Set the dialog result to OK
                this.Close(); // Close the form
            }
        }
    }
}