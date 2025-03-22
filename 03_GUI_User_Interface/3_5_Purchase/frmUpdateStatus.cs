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

namespace PLM_Lynx._03_GUI_User_Interface._3_5_Purchase
{
    public partial class frmUpdateStatus: Form
    {

        public event EventHandler UpdateStatus;
        private PurchaseBLL purchaseBLL = new PurchaseBLL();


        public string POCode { get; set; }
        public string PODate { get; set; }
        public string POStatus { get; set; }

        public frmUpdateStatus()
        {
            InitializeComponent();
        }

        private void frmUpdateStatus_Load(object sender, EventArgs e)
        {
            txtPOCode.Text = POCode;
            txtPODate.Text = PODate;
            txtPOStatus.Text = POStatus;
        }

        private void frmUpdateStatus_FormClosed(object sender, FormClosedEventArgs e)
        {
            UpdateStatus?.Invoke(this, EventArgs.Empty);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string NewStatus = cboNewStatus.SelectedItem.ToString();
            string tb = "Update from [ " + POStatus + " ] to [ " + NewStatus + " ]";
            DialogResult kq = MessageBox.Show(tb, "",MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq == DialogResult.Yes)
            {
                // Cập nhật status
                if(purchaseBLL.UpdateStatusPO_BLL(POCode, NewStatus)==true)
                {
                    MessageBox.Show("Cập nhật Status thành công", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Phát sinh lỗi. \n Kiểm tra lại thông tin", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                return;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
