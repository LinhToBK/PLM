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
using PLM_Lynx._03_GUI_User_Interface._3_4_FindPart;
using PLM_Lynx._03_GUI_User_Interface._3_7_Purchase_version_Hue;

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
            tstripUser.Text = "User : " + tennguoidung;

            switch (UserLevel)
            {
                case 2: // Kỹ sư
                    // Chặn các menu system
                    mnuManagerUser.Enabled = false;
                    mnuManageFamily.Enabled = false;

                    // Chặn các menu Purchase
                    mnuManagePrice.Enabled = false;
                    mnuMakeNewPO.Enabled = false;
                    mnuFindPO.Enabled = false;
                    mnuManageSupplier.Enabled = false;

                    // Mở form tìm Part
                    frmFindPart frmPart = new frmFindPart();
                    frmPart.MdiParent = this;
                    frmPart.WindowState = FormWindowState.Maximized;
                    frmPart.Show();
                    break;

                case 3: // Mua hàng
                    // Chặn các menu system
                    mnuMakeNewPart.Enabled = false;
                    mnuECO.Enabled = false;
                    mnuManagerUser.Enabled = false;
                    mnuRelationPart.Enabled = false;

                    frmManage_Purchasing frm = new frmManage_Purchasing();
                    frm._userName = tennguoidung;
                    frm.MdiParent = this;
                    frm.WindowState = FormWindowState.Maximized;
                    frm.Show();
                    break;


                case 4: // NPI và QC
                    // Chặn các menu system
                    mnuMakeNewPart.Enabled = false;
                    mnuECO.Enabled = false;
                    mnuManagerUser.Enabled = false;
                    mnuRelationPart.Enabled = false;

                    mnuListMaterial.Enabled = false;
                    solidworkToolStripMenuItem.Enabled = false;
                    siemenNXToolStripMenuItem.Enabled = false;

                    // Chặn menu Purchase
                    mnuManagePrice.Enabled = false;
                    mnuMakeNewPO.Enabled = false;
                    mnuManageSupplier.Enabled = false;
                    mnuFindPO.Enabled = false;

                    // Mở form tìm Part
                    frmFindPart frmPart2 = new frmFindPart();
                    frmPart2.MdiParent = this;
                    frmPart2.WindowState = FormWindowState.Maximized;
                    frmPart2.Show();
                    break;

                default: // Đối với admin
                         //frmFindPart defaultFrm = new frmFindPart();
                         //defaultFrm.MdiParent = this;
                         //defaultFrm.WindowState = FormWindowState.Maximized;
                         //defaultFrm.Show();
                         //break;

                    //Mở form Make New PO V2
                    frmManage_Purchasing frmA = new frmManage_Purchasing();
                    frmA._userName = tennguoidung;
                    frmA.MdiParent = this;
                    frmA.WindowState = FormWindowState.Maximized;
                    frmA.Show();
                    break;
                  

            }
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
            frm.userlevel = UserLevel;
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
            //frmManagePrice frm = new frmManagePrice();
            //frm.tennguoidung = tennguoidung;
            //frm.ShowDialog();

            frmManagePrice_Update frm = new frmManagePrice_Update();
            frm.username = tennguoidung;
            frm.ShowDialog();
        }

        private void mnuMakeNewPO_Click(object sender, EventArgs e)
        {
           frmMake_New_PO_V2 frm = new frmMake_New_PO_V2();
            frm._UserName = tennguoidung;
            frm.Show();
        }

        private void mnuManageSupplier_Click(object sender, EventArgs e)
        {
            frmPurchase_Common_Information frm = new frmPurchase_Common_Information();
            frm.ShowDialog();
        }

        private void mnuFindPO_Click(object sender, EventArgs e)
        {
            // Mở lại from mới

            //if (UserLevel == 3 || UserLevel == 1)
            //{
            //    foreach (Form frm in Application.OpenForms)
            //    {
            //        if (frm is frmFindPO_Update)
            //        {
            //            // Nếu đang mở thì phải đóng  lại
            //            frm.Close();
            //            break;
            //        }
            //    }
            //    frmFindPO_Update newfrm = new frmFindPO_Update();
            //    newfrm.UserName = tennguoidung;
            //    newfrm.ShowDialog();
            //}

            frmTesting frm = new frmTesting();
            frm.ShowDialog();
        }

        private void mnuAboutMe_Click(object sender, EventArgs e)
        {
            frmAboutMe frm = new frmAboutMe();
            frm.iduser = idnguoidung;
            frm.username = tennguoidung;
            frm.userlevel = UserLevel;
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

        private void solidworkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSolidwork frm = new frmSolidwork();
            frm.ShowDialog();
        }

        private void siemenNXToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSiemenNX frm = new frmSiemenNX();
            frm.ShowDialog();
        }

        private void mnuListMaterial_Click(object sender, EventArgs e)
        {
            frmListmaterial frm = new frmListmaterial();
            frm.ShowDialog();
        }

        private void mnuRestart_Click(object sender, EventArgs e)
        {
            DialogResult kq = MessageBox.Show("Do you want to restart apps?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (kq == DialogResult.Yes)
            {
                Application.Restart();
            }
            else
            {
                return;
            }
        }
    }
}