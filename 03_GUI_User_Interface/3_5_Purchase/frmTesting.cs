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
    public partial class frmTesting : Form
    {
        public frmTesting()
        {
            InitializeComponent();
        }
        private PurchaseBLL purchaseBLL = new PurchaseBLL();

        private void frmTesting_Load(object sender, EventArgs e)
        {
        
        }
    }
}
