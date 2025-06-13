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
    public partial class frm_Choose_Unit : Form
    {
         private Purchase_V2_BLL _purchase_V2_BLL = new Purchase_V2_BLL();
        private DataTable tblPur_Unit = new DataTable();
        public int SelectedUnitID { get; set; }
        public string SelectedUnitName { get; set; }
        public frm_Choose_Unit()
        {
            InitializeComponent();
            tblPur_Unit = _purchase_V2_BLL.Select_tblPur_Unit_BLL();
        }

        private void frm_Choose_Unit_Load(object sender, EventArgs e)
        {
            dgv_tblPur_Unit.DataSource = tblPur_Unit;
            
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

        private void dgv_tblPur_Unit_Click(object sender, EventArgs e)
        {
            if(dgv_tblPur_Unit.Rows.Count > 0)
            {
                txtUnitID.Text = dgv_tblPur_Unit.CurrentRow.Cells["UnitID"].Value.ToString();
                txtUnitName.Text = dgv_tblPur_Unit.CurrentRow.Cells["UnitName"].Value.ToString();
                txtUnitValue.Text = dgv_tblPur_Unit.CurrentRow.Cells["UnitValue"].Value.ToString();
                txtUnitContent.Text = dgv_tblPur_Unit.CurrentRow.Cells["UnitContent"].Value.ToString();
            }    
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUnitID.Text) || string.IsNullOrEmpty(txtUnitName.Text) || string.IsNullOrEmpty(txtUnitValue.Text) || string.IsNullOrEmpty(txtUnitContent.Text))
            {
                MessageBox.Show("Please select a unit from the list.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string message = "Are you sure you want to apply this unit?";
            DialogResult result = MessageBox.Show(message, "Apply", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                SelectedUnitID = Convert.ToInt32(txtUnitID.Text);
                SelectedUnitName = txtUnitName.Text;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
