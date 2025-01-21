using PLM_Lynx._01_DAL_Data_Access_Layer;
using PLM_Lynx._02_BLL_Bussiness_Logic_Layer;
using PLM_Lynx._03_GUI_User_Interface._3_1_Login;
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
    public partial class frmMakePO : Form
    {

        

        public string _usercurrent {  get; set; }

        public frmMakePO()
        {
            InitializeComponent();
        }

        private void frmMakePO_Load(object sender, EventArgs e)
        {
            // Load thông tin user
            txtStaffName.Text =  _usercurrent;
            tblUsers _user = 

        }
    }
}
