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
using PLM_Lynx._03_GUI_User_Interface._3_6_Help;

namespace PLM_Lynx
{
    public partial class frmMain : Form
    {
        // Thuộc tính lưu tên người dùng
        public string tennguoidung { get; set; }
        public int idnguoidung { get; set; }
        public int UserLevel { get; set; }  

        private QuanlyUserBLL Nguoidung = new QuanlyUserBLL();

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            tstripUser.Text = "User : " + tennguoidung + @"|| Đã kết nói với Database ";

            // Kiểm tra xem có phải là admin không ?
            if (Nguoidung.IsAdminBLL(tennguoidung) == false)
            {
                mnuManagerUser.Enabled = false;
                mnuECO.Enabled = false;
                mnuManageFamily.Enabled = false;
                mnuRelationPart.Enabled = false;
                mnuManagePrice.Enabled = false;
                mnuMakeNewPO.Enabled = false;
                mnuManageSupplier.Enabled = false;
            }

            // Kiểm tra xem có phải là purchase không
            if (Nguoidung.IsPurchase_BLL(tennguoidung) == true)
            {
                mnuManagePrice.Enabled = true;
                mnuManageSupplier.Enabled = true;
                mnuMakeNewPO.Enabled = true;
                mnuMakeNewPart.Enabled = false;
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
                if (frm is frmFindPart)
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
            frm.IDProposal = idnguoidung;
            frm.NameProposal = tennguoidung;
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
            frm.idProposal = idnguoidung;
            frm.nameProposal = tennguoidung;
            frm.ShowDialog();
        }

        private void mnuECO_Click(object sender, EventArgs e)
        {
            frmECO frm = new frmECO();
            frm.IDNguoidung = idnguoidung;
            frm.Username = tennguoidung;
            frm.ShowDialog();
        }

        private void mnuManagePrice_Click(object sender, EventArgs e)
        {
            frmManagePrice frm = new frmManagePrice();
            frm.tennguoidung = tennguoidung;
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

        private void mnuFindPO_Click(object sender, EventArgs e)
        {
            frmFindPO frm = new frmFindPO();
            frm.ShowDialog();
        }

        private void mnuAboutMe_Click(object sender, EventArgs e)
        {
            frmAboutMe frm = new frmAboutMe();
            frm.ShowDialog();


        }

        private void mnuUserGuide_Click(object sender, EventArgs e)
        {
            frmUserGuide frm = new frmUserGuide();
            frm.ShowDialog();
        }

        private void viewListUpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListECO frm = new frmListECO();
            frm.userid = idnguoidung;
            frm.userlevel = UserLevel;
            frm.username = tennguoidung;
            frm.ShowDialog();
        }
    }
}