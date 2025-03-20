using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PLM_Lynx._02_BLL_Bussiness_Logic_Layer;

namespace PLM_Lynx._03_GUI_User_Interface._3_1_Login
{
    public partial class frmManageUser : Form
    {
        private QuanlyUserBLL UserBLL = new QuanlyUserBLL();

        public frmManageUser()
        {
            InitializeComponent();
        }

        private void frmManageUser_Load(object sender, EventArgs e)
        {
            // -- Load dữ liệu

            LoadDatatblUser();
            LoadDatatblDepartments();
            
            // -- Đặt mặc định các control
            btnSaveUser.Enabled = false;
            //btnSaveDept.Enabled = false;
            txtUserName.Enabled = false;
            txtIdDept.Enabled = false;

        }

        private void ResetTextboxValue(bool tb)
        {
            if (tb== true)
            {
                // Reset bảng User
                txtUserName.Text = "";
                txtUserPassword.Text = "";
                txtUserRoles.Text = "";
                txtUserDepartment.Text = "";
                txtUserPosition.Text = "";
            }
            else
            {
                //  Reset bẳng Department
                txtDepartmentName.Text = "";
                txtIdDept.Text = "";
            } 
                
        }


        private void LoadDatatblDepartments()
        {
            //throw new NotImplementedException();
            dgvListDepartment.DataSource = UserBLL.LayDatatblDepartment();
            dgvListDepartment.Columns[0].HeaderText = "STT";
            dgvListDepartment.Columns[1].HeaderText = "Tên Phòng";
            dgvListDepartment.Columns[0].Width = 30;
            dgvListDepartment.Columns[1].Width = 100;
            dgvListDepartment.AllowUserToAddRows = false; // Không cho người dùng thêm hàng dữ liệu
            dgvListDepartment.EditMode = DataGridViewEditMode.EditProgrammatically;
            

        }

        private void LoadDatatblUser()
        {
            //throw new NotImplementedException();
            dgvListUser.DataSource = UserBLL.LayDatatblUserBLL();
            dgvListUser.Columns[0].HeaderText = "Nhân viên";
            dgvListUser.Columns[0].Width = 150;
            dgvListUser.Columns[1].HeaderText = "Password";
            dgvListUser.Columns[1].Width = 100;
            dgvListUser.Columns[2].HeaderText = "Quyền";
            dgvListUser.Columns[2].Width = 50;
            dgvListUser.Columns[3].HeaderText = "Vị trí";
            dgvListUser.Columns[3].Width = 100;
            dgvListUser.Columns[4].HeaderText = "Phòng";
            dgvListUser.Columns[4].Width = 100;
            dgvListUser.AllowUserToAddRows=false; 
            dgvListUser.EditMode = DataGridViewEditMode.EditProgrammatically;


        }

        /// <summary>
        /// Phương thức : Click vào 1 dòng thì hiển thị từng trường của datagritview lên các textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvListUser_Click(object sender, EventArgs e)
        {
            if(dgvListUser.Rows.Count==0)
            {
                // Nếu Dữ liệu trống  
                MessageBox.Show("Đang không có dữ liệu, cần kiểm tra lại ");
                txtUserName.Focus();
                return;

            }

            // Nếu button "Add User" đang  bị khóa 
            if(btnAddUser.Enabled == false)
            {
                MessageBox.Show("Đang ở thêm mới","Thông báo ",MessageBoxButtons.OK,MessageBoxIcon.Information);
                txtUserName.Focus();
                return;
            } 
                
            txtUserName.Text = dgvListUser.CurrentRow.Cells[0].Value.ToString();
            txtUserPassword.Text = dgvListUser.CurrentRow.Cells[1].Value.ToString();
            txtUserRoles.Text = dgvListUser.CurrentRow.Cells[2].Value.ToString();
            txtUserPosition.Text = dgvListUser.CurrentRow.Cells[3].Value.ToString();
            txtUserDepartment.Text = dgvListUser.CurrentRow.Cells[4].Value.ToString();

            // -- Các control button 
            btnModifyUser.Enabled = true;
            btnDeleteUser.Enabled = true;

        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            btnModifyUser.Enabled = false;
            btnDeleteUser.Enabled = false;
            btnSaveUser.Enabled = true;
            btnAddUser.Enabled = false;
            ResetTextboxValue(true);
            txtUserName.Enabled = true; // cho phép nhập tên nhân viên mới
            txtUserName.Focus();
        }

        private void btnSaveUser_Click(object sender, EventArgs e)
        {
            // Description : Kiểm tra thông tin của user và lưu vào Database
            // Lấy dữ liệu từ các textbox 
            string username = txtUserName.Text;
            string pass = txtUserPassword.Text;
            string role = txtUserRoles.Text;
            string pos = txtUserPosition.Text;
            string dept = txtUserDepartment.Text;
            string thongbao;
            

            thongbao = "Bạn có muốn thêm dữ liệu : \n Tên :   " + username + "\n Vai trò :" + role + "\n Chức vụ : " + pos + "\n Phòng : " + dept;
            DialogResult result = MessageBox.Show(thongbao, "Notice !!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                // Gọi phương thức  "ThemUserBLL" để  thêm dữ liệu
                if (UserBLL.ThemUserBLL(username, pass, role, pos, dept))
                {
                    // Nếu OK
                    MessageBox.Show("Đã thêm User mới thành công ");
                    ResetTextboxValue(true);
                    btnDeleteUser.Enabled = true;
                    btnAddUser.Enabled = true;
                    btnModifyUser.Enabled = true;
                    btnSaveUser.Enabled = false;
                    txtUserName.Enabled = false;
                }
                else
                {
                    // Nếu NG
                    MessageBox.Show("Kiểm tra lại dữ liệu, chú ý đến tên phòng xem có trong list  Dept không ");
                }
            }
            LoadDatatblUser();
  
        }

        private void btnSaveDept_Click(object sender, EventArgs e)
        {
            if (txtIdDept.Text == "") { MessageBox.Show("Chưa nhập ID"); }
            if (txtDepartmentName.Text == "") { MessageBox.Show("Chưa nhập tên phòng mới"); }
            string Thongbao = "Bạn sẽ thêm phòng : " + txtDepartmentName.Text + "    nhé ";

            DialogResult dia = MessageBox.Show(Thongbao, "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dia == DialogResult.Yes)
            {
                if (UserBLL.ThemDeptBLL(Convert.ToInt32(txtIdDept.Text), txtDepartmentName.Text))
                {
                    MessageBox.Show("Đã thêm thành công ");
                    LoadDatatblDepartments();
                    btnSaveDept.Enabled = false;
                    ResetTextboxValue(false);
                }
                else { MessageBox.Show("Có lỗi, kiểm tra lại thông tin nhập vào"); }
            } 
            else txtIdDept.Focus();
        }


        private void btnModifyUser_Click(object sender, EventArgs e)
        {
            // -----------------------------------------
            // Description  : Khi người dùng nháy chuột vào 1 dòng bản ghi bất kì trên Grit View
            //              để hiển thị dữ liệu  và người dùng có thể sửa thông tin đó
            //              khi click vào thì sẽ lưu thông tin người dùng đã sửa và Database
            // -----------------------------------------
            // Trạng thái button
            //btnAddUser.Enabled = false;
            

            
            // Lấy dữ liệu từ các textbox 
            string username = txtUserName.Text;
            string pass = txtUserPassword.Text;
            string role = txtUserRoles.Text;
            string pos = txtUserPosition.Text;
            string dept = txtUserDepartment.Text;
            string thongbao;
            thongbao = "Bạn có muốn sửa dữ liệu : \n Tên :   " + username + "\n Vai trò :" + role + "\n Chức vụ : " + pos + "\n Phòng : " + dept;
            DialogResult result = MessageBox.Show(thongbao, "Notice !!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                // Gọi phương thức  "CapnhatUserBLL" để  sửa dữ liệu
                if (UserBLL.CapnhatUserBLL(username, pass, role, pos, dept))
                {
                    // Nếu OK
                    MessageBox.Show("Đã sửa User mới thành công ");
                    ResetTextboxValue(true);
                    btnDeleteUser.Enabled = true;
                    btnAddUser.Enabled = true;
                    btnModifyUser.Enabled = false;
                    btnSaveUser.Enabled = false;
                    txtUserName.Enabled = false;
                    LoadDatatblUser();
                    ResetTextboxValue(true);
                }
                else
                {
                    // Nếu NG
                    MessageBox.Show("Kiểm tra lại dữ liệu, chú ý đến tên phòng xem có trong list  Dept không ");
                }
            }

        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            if ( dgvListUser.Rows.Count ==0 )
            {
                MessageBox.Show("Không có dữ liệu","Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string thongbao = "Bạn có thực sự muốn xóa ----  " + dgvListUser.CurrentRow.Cells[0].Value.ToString() + " ----- không? ";

            DialogResult dia = MessageBox.Show(thongbao, "Thông báo ", MessageBoxButtons.YesNo,MessageBoxIcon.Warning);

            if(dia == DialogResult.Yes)
            {
                if (UserBLL.XoaUserBLL(dgvListUser.CurrentRow.Cells[0].Value.ToString()))
                {
                    MessageBox.Show("Đã xóa thành công ");
                    LoadDatatblUser();
                    ResetTextboxValue(true );
                }  
                else
                {
                    MessageBox.Show("Đã phát sinh lỗi");
                }
            } 
                

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void dgvListDepartment_Click(object sender, EventArgs e)
        {

            if (dgvListDepartment.Rows.Count == 0)
            {
                // Nếu Dữ liệu trống  
                MessageBox.Show("Đang không có dữ liệu, cần kiểm tra lại ");
                txtDepartmentName.Focus();
                return;

            }

            // Nếu button "Add User" đang  bị khóa 
            if (btnAddDept.Enabled == false)
            {
                MessageBox.Show("Đang ở thêm phòng mới", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDepartmentName.Focus();
                return;
            }
            txtIdDept.Text = dgvListDepartment.CurrentRow.Cells[0].Value.ToString();
            txtDepartmentName.Text = dgvListDepartment.CurrentRow.Cells[1].Value.ToString();

            // -- Các control button 
            btnModifyDept.Enabled = true;
            btnDeleteDept.Enabled = true;

        }

        private void btnAddDept_Click(object sender, EventArgs e)
        {
            btnAddDept.Enabled = false;
            btnDeleteDept.Enabled = false;
            btnModifyDept.Enabled = false ;
            btnSaveDept.Enabled = true;
            txtIdDept.Enabled = true ;
            ResetTextboxValue(false );
        }

        private void btnModifyDept_Click(object sender, EventArgs e)
        {
            if (txtDepartmentName.Text != "")
            {
                DialogResult result = MessageBox.Show("Bạn định sửa " + txtDepartmentName.Text + " phải không ?");
                if (result == DialogResult.OK)
                {
                    if (UserBLL.CapnhatDeptBLL(Convert.ToInt32(txtIdDept.Text), txtDepartmentName.Text))
                    {
                        MessageBox.Show("Đã sửa  thành công phòng :  " + txtDepartmentName.Text);
                        LoadDatatblDepartments();
                        LoadDatatblUser();
                        // ResetTextboxValue(false);
                        btnModifyDept.Enabled=false;
                    }
                    else
                    {
                        MessageBox.Show("Lỗi !!! \n Kiểm tra lại tên phòng ");
                    }
                }
                else
                {
                    txtDepartmentName.Focus();
                }
            }
            else
            {
                MessageBox.Show("Chưa nhập tên phòng mới");
            }    
        }

        private void btnDeleteDept_Click(object sender, EventArgs e)
        {

            string thongbao = "Bạn có muốn delete phòng" + txtIdDept.Text + " -- " + txtDepartmentName.Text;
            DialogResult result = MessageBox.Show(thongbao, "Cảnh báo nè !!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                if (UserBLL.XoaDeptBLL(Convert.ToInt32(txtIdDept.Text)))
                {
                    MessageBox.Show("Đã xóa thành công ");
                    LoadDatatblUser();
                    LoadDatatblDepartments();
                    ResetTextboxValue(false);
                }
                else
                {
                    MessageBox.Show("Xuất hiện lỗi !!! \n Không xóa được ");
                }
            }
            else return;
        }
    }
}
