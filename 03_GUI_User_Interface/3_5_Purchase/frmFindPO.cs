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
    public partial class frmFindPO : Form
    {
        public frmFindPO()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult kq = MessageBox.Show("Bạn có muốn thoát không ", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq == DialogResult.Yes)
            {
                this.Close();
            }
            else return;
        }

        private void BtnKeySearch_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Đây là đang search tài liệu ");
        }
    }
}
