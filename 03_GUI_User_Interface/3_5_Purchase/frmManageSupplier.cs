using Azure.Core;
using PLM_Lynx._02_BLL_Bussiness_Logic_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PLM_Lynx._03_GUI_User_Interface._3_5_Purchase
{
    public partial class frmManageSupplier : Form
    {
        private PurchaseBLL purchaseBLL = new PurchaseBLL();

        // =========== Language =========================
        private ResourceManager rm { get; set; } // Để lấy ngôn ngữ từ ResourceManager

        private void LoadLanguage()
        {
            // Lấy ngôn ngữ đã lưu ( mặc định là en)
            string lang = Properties.Settings.Default.Language;
            SetLanguage(lang);
        }

        private void SetLanguage(string lang)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(lang);

            rm = new ResourceManager("PLM_Lynx._03_GUI_User_Interface._3_5_Purchase.Lang.Lang_frmManageSupplier", typeof(frmManageSupplier).Assembly);
            // Hiển thị ngôn ngữ lên các điều khiển trong form
            this.Text = rm.GetString("i.form");
            labelName.Text = rm.GetString("lb1");
            labelPhone.Text = rm.GetString("lb2");
            labelLocation.Text = rm.GetString("lb3");
            labelTax.Text = rm.GetString("lb6");
            labelNote.Text = rm.GetString("lb4");
            labelRepresentative.Text = rm.GetString("lb5");
            btnAddSupplier.Text = rm.GetString("lb7");
            btnModifySupplier.Text = rm.GetString("lb8");
            btnDeleteSupplier.Text = rm.GetString("lb9");
            btnSaveChange.Text = rm.GetString("lb10");
            btnExit.Text = rm.GetString("lb11");




            Properties.Settings.Default.Language = lang;
            Properties.Settings.Default.Save();
        }

        // =========== Language =========================
        public frmManageSupplier()
        {
            InitializeComponent();
            // -- Load ngôn ngữ
            LoadLanguage();
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
            dgvSupplier.DataSource = purchaseBLL.GetAllInforSupplier_BLL();
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
                MessageBox.Show(rm.GetString("t1"));   // Đang không có dữ liệu, cần kiểm tra lại 
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
            string notice = rm.GetString("t2");  // Bạn có muốn lưu thay đổi thông tin nhà cung cấp không ?
            DialogResult result = MessageBox.Show(notice, rm.GetString("t0"), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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
                    MessageBox.Show(rm.GetString("t3"));   // Đã cập nhật thông tin nhà cung cấp thành công 

                    LoadAllInforSupplier();
                }
                else
                {
                    MessageBox.Show(rm.GetString("t4"));  // Đã phát sinh lỗi khi cập nhật dữ liệu. \n Kiểm tra lại các thông tin.
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
                MessageBox.Show(rm.GetString("t5")); // Vui lòng nhập đầy đủ thông tin
                return;
            }

            string tb = rm.GetString("t6"); // Bạn có muốn lưu thay đổi thông tin nhà cung cấp không ?
            tb = rm.GetString("t7") + Name + "\n";   // Tên : 
            tb = tb + rm.GetString("t8")+ Phone + "\n";   // Phone : 
            tb = tb + rm.GetString("t9") + Tax + "\n";     // Tax : 
            tb = tb + rm.GetString("10") + Location + "\n";   // Location : 
            tb = tb + rm.GetString("t11") + Representative + "\n";  // Representative : 
            tb = tb + rm.GetString("t12") + Note + "\n";   // Note : 


            DialogResult result = MessageBox.Show(tb, "Thông báo !", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                // Gọi phương thức  "ThemUserBLL" để  thêm dữ liệu
                if (purchaseBLL.InsertNewSupplierBLL(Name, Phone, Tax, Location, Representative, Note) == true)
                {
                    // Nếu OK
                    MessageBox.Show(rm.GetString("t13")); // Đã thêm Supplier mới thành công 
                    ClearAllTextbox();
                    LoadAllInforSupplier();
                }
                else
                {
                    // Nếu NG
                    MessageBox.Show(rm.GetString("t14"));  // Kiểm tra lại dữ liệu \n Chú ý Tên nhà cung cấp đã tồn tại trong danh sách chưa ? 
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
            DialogResult kq = MessageBox.Show(rm.GetString("t15"), rm.GetString("t0"), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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