using Azure.Core;
using PLM_Lynx._01_DAL_Data_Access_Layer;
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

namespace PLM_Lynx._03_GUI_User_Interface._3_6_Help
{
    public partial class frmAboutMe : Form
    {
        private CommonBLL _commonbll = new CommonBLL();

        public frmAboutMe()
        {
            InitializeComponent();
        }

        private void frmAboutMe_Load(object sender, EventArgs e)
        {
            //------------
            btnSaveInfor.Enabled = false;
            txtCompanyName.Enabled = false;
            txtCompanyLocation.Enabled = false;
            txtCompanyTaxCode.Enabled = false;
            txtCompanyPhone.Enabled = false;
            btnSaveInfor.Enabled = false;
            //-------------
            txtVersionID.Enabled = false;
            txtVersionContent.Enabled = false;
            btnSaveVersion.Enabled = false;

            LoadCommonInfor();
            LoadAllVersionInfor();
        }

        // Đẩy các thông tin lên textbox
        public void LoadCommonInfor()
        {
            tblCommonInfor companyname = _commonbll.GetCommonInforValue("CompanyName");
            if (companyname != null)
            {
                txtCompanyName.Text = companyname.InforValue.ToString();
            }
            else
            {
                txtCompanyName.Text = " Error !!! \n Cannot access the data";
            }
            tblCommonInfor companyphone = _commonbll.GetCommonInforValue("CompanyPhoneNumber");
            if (companyphone != null)
            {
                txtCompanyPhone.Text = companyphone.InforValue.ToString();
            }
            else
            {
                txtCompanyPhone.Text = " Error !!! \n Cannot access the data";
            }
            tblCommonInfor companylocation = _commonbll.GetCommonInforValue("CompanyLocation");
            if (companylocation != null)
            {
                txtCompanyLocation.Text = companylocation.InforValue.ToString();
            }
            else
            {
                txtCompanyLocation.Text = " Error !!! \n Cannot access the data";
            }
            tblCommonInfor companytaxcode = _commonbll.GetCommonInforValue("CompanyTaxCode");
            if (companytaxcode != null)
            {
                txtCompanyTaxCode.Text = companytaxcode.InforValue.ToString();
            }
            else
            {
                txtCompanyTaxCode.Text = " Error !!! \n Cannot access the data";
            }
        }

        // Đẩy thông tin lên datagrid view
        public void LoadAllVersionInfor()
        {
            dgvVersion.DataSource = _commonbll.GetAllVersionInfor_BLL();
            dgvVersion.AllowUserToAddRows = false;
            dgvVersion.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void btnModifyCompany_Click(object sender, EventArgs e)
        {
            txtCompanyName.Enabled = true;
            txtCompanyPhone.Enabled = true;
            txtCompanyLocation.Enabled = true;
            txtCompanyTaxCode.Enabled = true;
        }

        private void txtCompanyName_TextChanged(object sender, EventArgs e)
        {
            btnSaveInfor.Enabled = true;
        }

        private void txtCompanyPhone_TextChanged(object sender, EventArgs e)
        {
            btnSaveInfor.Enabled = true;
        }

        private void txtCompanyTaxCode_TextChanged(object sender, EventArgs e)
        {
            btnSaveInfor.Enabled = true;
        }

        private void txtCompanyLocation_TextChanged(object sender, EventArgs e)
        {
            btnSaveInfor.Enabled = true;
        }

        private void txtVersionID_TextChanged(object sender, EventArgs e)
        {
            btnSaveVersion.Enabled = true;
        }

        private void txtVersionContent_TextChanged(object sender, EventArgs e)
        {
            btnSaveVersion.Enabled = true;
        }

        private void btnAddVersion_Click(object sender, EventArgs e)
        {
            txtVersionID.Enabled = true;
            txtVersionContent.Enabled = true;
        }

        private void btnSaveInfor_Click(object sender, EventArgs e)
        {
            // Tiến hành cập nhật
            string contentname = txtCompanyName.Text.Trim();
            string contentphone = txtCompanyPhone.Text.Trim();
            string contentlocation = txtCompanyLocation.Text.Trim();
            string contenttax = txtCompanyTaxCode.Text.Trim();
            string tb = "Bạn có muốn cập nhật những thông tin của công ty : ";
            tb = tb + "\n Tên công ty : " + contentname;
            tb = tb + "\n Số điện thoại : " + contentphone;
            tb = tb + "\n Địa chỉ : " + contentlocation;
            tb = tb + "\n Mã số thuế : " + contenttax;

            DialogResult kq = MessageBox.Show(tb, "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq == DialogResult.Yes)
            {
                if (_commonbll.UpdateCompanyInfor_BLL(contentname, contentlocation, contentphone, contenttax) == true)
                {
                    MessageBox.Show("Đã cập nhật thành công thông tin công ty");
                    LoadCommonInfor();
                    btnSaveInfor.Enabled = false;
                    txtCompanyName.Enabled = false;
                    txtCompanyPhone.Enabled = false;
                    txtCompanyLocation.Enabled = false;
                    txtCompanyTaxCode.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Lỗi!!! Không thể cập nhật thông tin này được ");
                }
            }
            else
            {
                return;
            }
        }

        private void btnSaveVersion_Click(object sender, EventArgs e)
        {
            string tb = "Bạn có muốn thêm cập nhật ";
            tb = tb + "\n Version No : " + txtVersionID.Text.Trim();
            tb = tb + "\n Nội dung : " + txtVersionContent.Text.Trim();
            DialogResult kq = MessageBox.Show(tb, "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq == DialogResult.Yes)
            {
                if (_commonbll.InsertNewVersion_BLL(txtVersionID.Text.Trim(), txtVersionContent.Text.Trim()) == true)
                {
                    MessageBox.Show("Thêm thông tin cập nhật version thành công.");
                    LoadAllVersionInfor();
                    btnSaveVersion.Enabled = false;
                    txtVersionID.Enabled = false;
                    txtVersionContent.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Phát sinh lỗi khi cập nhật. \n Vui lòng kiểm tra lại thông tin ");
                }    
            }
            else
            {
                return;
            }
        }
    }
}