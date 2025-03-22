using Azure.Core;
using PLM_Lynx._02_BLL_Bussiness_Logic_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PLM_Lynx._03_GUI_User_Interface._3_5_Purchase
{
    public partial class frmManageSupplier : Form
    {
        private PurchaseBLL purchaseBLL = new PurchaseBLL();

        public frmManageSupplier()
        {
            InitializeComponent();
        }

        private void frmManageSupplier_Load(object sender, EventArgs e)
        {
            // -- Load dữ liệu

            LoadAllInforSupplier();

            // -- Turnoff button
            btnSaveChange.Enabled = false;
            btnAddSupplier.Enabled = false;
            btnDeleteSupplier.Enabled = false;
            btnModifySupplier.Enabled = false;

           
        }

        private void LoadAllInforSupplier()
        {
            //throw new NotImplementedException();
            dgvSupplier.DataSource = purchaseBLL.GetAllInforSupplierBLL();
            //dgvListDepartment.Columns[0].HeaderText = "STT";
            //dgvListDepartment.Columns[1].HeaderText = "Tên Phòng";
            //dgvListDepartment.Columns[0].Width = 30;
            //dgvListDepartment.Columns[1].Width = 100;
            dgvSupplier.AllowUserToAddRows = false; // Không cho người dùng thêm hàng dữ liệu
            dgvSupplier.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void dgvSupplier_Click(object sender, EventArgs e)
        {
            if (dgvSupplier.Rows.Count == 0)
            {
                // Nếu Dữ liệu trống
                MessageBox.Show("Đang không có dữ liệu, cần kiểm tra lại ");
                txtName.Focus();
                return;
            }

            txtName.Text = dgvSupplier.CurrentRow.Cells[0].Value.ToString();
            txtPhone.Text = dgvSupplier.CurrentRow.Cells[1].Value.ToString();
            txtTax.Text = dgvSupplier.CurrentRow.Cells[2].Value.ToString();
            txtLocation.Text = dgvSupplier.CurrentRow.Cells[3].Value.ToString();
            txtRepresentative.Text = dgvSupplier.CurrentRow.Cells[4].Value.ToString();
            txtNote.Text = dgvSupplier.CurrentRow.Cells[5].Value.ToString();
            txtID.Text = dgvSupplier.CurrentRow.Cells[6].Value.ToString();

            // -- Các control button
            btnModifySupplier.Enabled = true;
            btnDeleteSupplier.Enabled = true;
            btnAddSupplier.Enabled = true;
            btnSaveChange.Enabled = false;
        }

        private void btnAddSupplier_Click(object sender, EventArgs e)
        {
            ClearAllTextbox();
            // TurnOnTextbox();
            btnDeleteSupplier.Enabled = false;
            btnSaveChange.Enabled = true;
            txtName.Focus();
        }

        private void ClearAllTextbox()
        {
            txtID.Text = "";
            txtName.Text = "";
            txtPhone.Text = "";
            txtLocation.Text = "";
            txtRepresentative.Text = "";
            txtTax.Text = "";
            txtNote.Text = "";
        }

        private void TurnOnTextbox()
        {
            txtName.Enabled = true;
            txtPhone.Enabled = true;
            txtTax.Enabled = true;
            txtLocation.Enabled = true;
            txtRepresentative.Enabled = true;
            txtNote.Enabled = true;
        }

        private void btnModifySupplier_Click(object sender, EventArgs e)
        {
            string notice = "Bạn có muốn lưu thay đổi thông tin nhà cung cấp không ?";
            DialogResult result = MessageBox.Show(notice, "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                string Name = txtName.Text.Trim();
                string Phone = txtPhone.Text.Trim();
                string Tax = txtTax.Text.Trim();
                string Location = txtLocation.Text.Trim();
                string Representative = txtRepresentative.Text.Trim();
                string Note = txtNote.Text.Trim();
                int ID = int.Parse(txtID.Text.Trim());
                if(purchaseBLL.UpdateOneSupplierBLL(Name, Phone, Tax, Location, Representative, Note, ID) == true)
                {
                    MessageBox.Show("Đã cập nhật thông tin nhà cung cấp thành công ");
                    
                    LoadAllInforSupplier();
                }
                else
                {
                    MessageBox.Show("Đã phát sinh lỗi khi cập nhật dữ liệu. \n Kiểm tra lại các thông tin. ");
                }

            }
            else
            {
                return;
            }
        }

        private void btnSaveChange_Click(object sender, EventArgs e)
        {
            string Name = txtName.Text.Trim();
            string Phone = txtPhone.Text.Trim();
            string Tax = txtTax.Text.Trim();
            string Location = txtLocation.Text.Trim();
            string Representative = txtRepresentative.Text.Trim();
            string Note = txtNote.Text.Trim();
            if(Name == "" || Phone == "" || Tax == "" || Location == "" || Representative == "" || Note == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
                return;
            }

            string tb = "Bạn có muốn lưu thay đổi thông tin nhà cung cấp không ?";
            tb = "Tên : " + Name + "\n" + "Phone : " + Phone + "\n" + "Tax : " + Tax + "\n"
                + "Location : " + Location + "\n" + "Representative : " + Representative + "\n" + "Note : " + Note;

            DialogResult result = MessageBox.Show(tb, "Thông báo !", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                // Gọi phương thức  "ThemUserBLL" để  thêm dữ liệu
                if (purchaseBLL.InsertNewSupplierBLL(Name, Phone, Tax, Location, Representative, Note) == true)
                {
                    // Nếu OK
                    MessageBox.Show("Đã thêm Supplier mới thành công ");
                    ClearAllTextbox();
                    LoadAllInforSupplier();
                }
                else
                {
                    // Nếu NG
                    MessageBox.Show("Kiểm tra lại dữ liệu \n Chú ý Tên nhà cung cấp đã tồn tại trong danh sách chưa ? ");
                }
            }
        }

        private void btnDeleteSupplier_Click(object sender, EventArgs e)
        {
            //    if (dgvSupplier.Rows.Count == 0)
            //    {
            //        MessageBox.Show("Không có dữ liệu", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        return;
            //    }
            //    string thongbao = "Bạn có thực sự muốn xóa ----  " + dgvSupplier.CurrentRow.Cells[0].Value.ToString() + " ----- không? ";

            //    DialogResult dia = MessageBox.Show(thongbao, "Thông báo ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            //    if (dia == DialogResult.Yes)
            //    {
            //        if (purchaseBLL.DeleteOneSupplierBLL(dgvSupplier.CurrentRow.Cells[0].Value.ToString()))
            //        {
            //            MessageBox.Show("Đã xóa thành công ");
            //            LoadAllInforSupplier();
            //            ClearAllTextbox();
            //        }
            //        else
            //        {
            //            MessageBox.Show("Đã phát sinh lỗi");
            //            return;
            //        }
            //    }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult kq = MessageBox.Show("Bạn có muốn thoát không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq == DialogResult.Yes)
            {
                this.Close();
            }
            else
            {
                return;
            }
        }
    }
}