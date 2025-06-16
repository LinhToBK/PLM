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
    public partial class frm_Choose_WareHouse : Form
    {
        private Purchase_V2_BLL _purchase_V2_BLL = new Purchase_V2_BLL();
        private DataTable tblPur_WareHouse = new DataTable();
        public int SelectedWareHouseID { get; set; }
        public string SelectedWareHouseName { get; set; }

        public frm_Choose_WareHouse()
        {
            InitializeComponent();
            tblPur_WareHouse = _purchase_V2_BLL.Select_tblPur_WareHouse_BLL();
        }

        private void frm_Choose_WareHouse_Load(object sender, EventArgs e)
        {
            dgv_tblPur_WareHouse.DataSource = tblPur_WareHouse;
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

        private void dgv_tblPur_WareHouse_Click(object sender, EventArgs e)
        {
            

            if (dgv_tblPur_WareHouse.Rows.Count > 0 )
            {
                txtWareHouseID.Text = dgv_tblPur_WareHouse.CurrentRow.Cells["WareHouseID"].Value.ToString();
                txtWareHouseName.Text = dgv_tblPur_WareHouse.CurrentRow.Cells["WareHouseName"].Value.ToString();
            }
            else
            {
                MessageBox.Show("Please select a warehouse from the list.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }    
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtWareHouseID.Text) || string.IsNullOrEmpty(txtWareHouseName.Text))
            {
                MessageBox.Show("Please select a warehouse from the list.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            SelectedWareHouseID = Convert.ToInt32(txtWareHouseID.Text);
            SelectedWareHouseName = txtWareHouseName.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}