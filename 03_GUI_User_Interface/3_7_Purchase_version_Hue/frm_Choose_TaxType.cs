using PLM_Lynx._02_BLL_Bussiness_Logic_Layer;
using System;
using System.Data;
using System.Windows.Forms;

namespace PLM_Lynx._03_GUI_User_Interface._3_7_Purchase_version_Hue
{
    public partial class frm_Choose_TaxType : Form
    {
        // TaxID, TaxName, TaxValue
        private DataTable tblPur_Tax = new DataTable();

        private Purchase_V2_BLL _purchase_V2_BLL = new Purchase_V2_BLL();
        public int SelectedTaxID { get; set; }
        public string SelectedTaxName { get; set; }

        public frm_Choose_TaxType()
        {
            InitializeComponent();
            tblPur_Tax = _purchase_V2_BLL.Select_tblPur_Tax_BLL();
        }

        private void frm_Choose_TaxType_Load(object sender, EventArgs e)
        {
            dgv_tblPur_Tax.DataSource = tblPur_Tax;
        }

        private void dgv_tblPur_Tax_Click(object sender, EventArgs e)
        {
            if (dgv_tblPur_Tax.Rows.Count > 0)
            {
                txtTaxID.Text = dgv_tblPur_Tax.CurrentRow.Cells["TaxID"].Value.ToString();
                txtTaxName.Text = dgv_tblPur_Tax.CurrentRow.Cells["TaxName"].Value.ToString();
                txtTaxValue.Text = dgv_tblPur_Tax.CurrentRow.Cells["TaxValue"].Value.ToString();
            }
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

        private void btnApply_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTaxID.Text) || string.IsNullOrEmpty(txtTaxName.Text) || string.IsNullOrEmpty(txtTaxValue.Text))
            {
                MessageBox.Show("Please select a tax type before applying.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string message = "Are you sure you want to apply this tax type?";
            DialogResult result = MessageBox.Show(message, "Apply", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                if (dgv_tblPur_Tax.Rows.Count > 0)
                {
                    SelectedTaxID = txtTaxID.Text != "" ? Convert.ToInt32(txtTaxID.Text) : 0;
                    SelectedTaxName = txtTaxName.Text;
                    this.DialogResult = DialogResult.OK; 
                    this.Close();
                }
                else
                {
                    MessageBox.Show("No tax type selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}