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

namespace PLM_Lynx._03_GUI_User_Interface._3_3_ECO
{
    public partial class frmModifyQuantity : Form
    {
        private ECO_BLL ecoBLL = new ECO_BLL();
        public frmModifyQuantity()
        {
            InitializeComponent();
        }

        public void CapnhatControlModifyQuantity(string parentcode, string parentname, string childcode, string childname, string oldquantity, string newquantity)
        {
            txtParentCode.Text = parentcode;
            txtParentName.Text = parentname;
            txtChildCode.Text = childcode;
            txtChildName.Text = childname;
            txtOldQuantity.Text = oldquantity;
            txtNewQuantity.Text = newquantity;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // 
            if(ecoBLL.CapnhatQuantityBLL(txtParentCode.Text, txtChildCode.Text, Convert.ToInt32(txtNewQuantity.Text)))
            {
                MessageBox.Show("Cập nhật Quantity = " + txtNewQuantity.Text + " của Part " + txtChildCode.Text + " thành công");
                this.Close();
            }    
            else
            {
                MessageBox.Show("Xuất hiện lỗi khi cập nhật \n Kiểm tra lại dữ liệu");
                return;
            }    
        }

        private void frmModifyQuantity_Load(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
