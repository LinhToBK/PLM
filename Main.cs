using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PLM_Lynx._03_GUI_User_Interface._3_1_Login;
using PLM_Lynx._02_BLL_Bussiness_Logic_Layer;
using PLM_Lynx._03_GUI_User_Interface;
using PLM_Lynx._03_GUI_User_Interface._3_3_ECO;
using PLM_Lynx._03_GUI_User_Interface._3_5_Purchase;

namespace PLM_Lynx
{
    public partial class frmMain : Form
    {

        // Thuộc tính lưu tên người dùng
        public string tennguoidung {  get; set; }
        QuanlyUserBLL Nguoidung = new QuanlyUserBLL();
        


        public frmMain()
        {
            InitializeComponent();

        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            tstripUser.Text = "User : " +  tennguoidung + @"|| Đã kết nói với Database ";
            if(Nguoidung.IsAdminBLL(tennguoidung) == false)
            {
                // Không là admin thì sẽ khóa 1 số tab
                mnuMakeNewPart.Enabled = false;
                mnuMakeNewPO.Enabled = false;
                mnuManagerUser.Enabled = false;
                mnuECO.Enabled  = false;

            }

            frmFindPart frm = new frmFindPart();
           
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();



        }

        private void mnuManagerUser_Click(object sender, EventArgs e)
        {
            frmManageUser frm = new frmManageUser();
            frm.ShowDialog();
        }

        private void frmMain_Click(object sender, EventArgs e)
        {

            
        }

        private void mnuFindPart_Click(object sender, EventArgs e)
        {
            // Nếu đang có menu thì tắt đi.
            foreach (Form frm in Application.OpenForms)
            {
                if(frm is frmFindPart)
                {
                    // Nếu đang mở thì phải đóng  lại
                    frm.Close();
                    break;
                }    
            }    

            // Mở lại from mới
            frmFindPart newfrm = new frmFindPart();
            newfrm.ShowDialog();
        }

        private void mnuMakeNewPart_Click(object sender, EventArgs e)
        {
            frmMakeNewPart frm = new frmMakeNewPart();
            frm.ShowDialog();
        }

        private void mnuManageFamily_Click(object sender, EventArgs e)
        {
            frmManageFamilyCode frm = new frmManageFamilyCode();
            frm.ShowDialog();
        }

        private void mnuRelationPart_Click(object sender, EventArgs e)
        {
            frmRelationPart frm = new frmRelationPart();
            frm.ShowDialog();
        }

        private void mnuECO_Click(object sender, EventArgs e)
        {
             frmECO frm = new frmECO();
            frm.ShowDialog();
        }

        private void mnuManagePrice_Click(object sender, EventArgs e)
        {
            frmManagePrice frm = new frmManagePrice();
            frm.ShowDialog();
        }

        private void mnuMakeNewPO_Click(object sender, EventArgs e)
        {
            frmMakePO frm = new frmMakePO();
            frm._usercurrent = tennguoidung;
            frm.ShowDialog();
        }

        private void mnuManageSupplier_Click(object sender, EventArgs e)
        {
            frmManageSupplier frm = new frmManageSupplier();
            frm.ShowDialog();
        }
    }
}
