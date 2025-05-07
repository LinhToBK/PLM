using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using PLM_Lynx._02_BLL_Bussiness_Logic_Layer;

namespace PLM_Lynx._03_GUI_User_Interface._3_1_Login
{
    public partial class frmManageUser : Form
    {
        private QuanlyUserBLL UserBLL = new QuanlyUserBLL();
        private DataTable _tbldepartment = new DataTable();

        public frmManageUser()
        {
            InitializeComponent();
            LoadLanguage(); // Load ngôn ngữ từ ResourceManager
        }

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
            //rm = new ResourceManager("PLM_Lynx.03_GUI_User_Interface.3_1_Login.Language_Login", typeof(frmManageUser).Assembly);
            rm = new ResourceManager("PLM_Lynx._03_GUI_User_Interface._3_1_Login.Language_Login", typeof(frmManageUser).Assembly);

            this.Text = rm.GetString("lb.form");
            btnAddUser.Text = rm.GetString("btn.Add");
            btnModifyUser.Text = rm.GetString("btn.Modify");
            btnDeleteUser.Text = rm.GetString("btn.Del");
            btnSaveUser.Text = rm.GetString("btn.Save");
            labelUserName.Text = rm.GetString("lb.Name");
            labelUserPass.Text = rm.GetString("lb.Pass");
            labelUserRoles.Text = rm.GetString("lb.Rol");
            labelUserPosition.Text = rm.GetString("lb.Pos");
            labelUserDept.Text = rm.GetString("lb.Dept");
            labelUserLevel.Text = rm.GetString("lb.Level");

            // Phòng bàn
            labelDeptName.Text = rm.GetString("lb.DeptName");
            btnAddDept.Text = rm.GetString("btn.AddDept");
            btnModifyDept.Text = rm.GetString("btn.Modify");
            btnDeleteDept.Text = rm.GetString("btn.Del");
            btnSaveDept.Text = rm.GetString("btn.Save");
            // Groupbox
            groupBoxUser.Text = rm.GetString("gr.ManageListUser");
            groupBoxDept.Text = rm.GetString("gr.ManageDept");

            // Lưu lại lựa chọn ngôn ngữ
            Properties.Settings.Default.Language = lang;
            Properties.Settings.Default.Save();
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
            cboDepartment.Enabled = false;
            cboLevel.Enabled = false;
        }

        private void ResetTextboxValue(bool tb)
        {
            if (tb == true)
            {
                // Reset bảng User
                txtUserName.Text = "";
                txtUserPassword.Text = "";
                txtUserRoles.Text = "";
                //txtUserDepartment.Text = "";
                txtUserPosition.Text = "";
                cboDepartment.SelectedIndex = 1;
                cboLevel.SelectedIndex = 2;
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
            _tbldepartment = UserBLL.LayDatatblDepartment();
            dgvListDepartment.Columns[0].HeaderText = "STT";
            dgvListDepartment.Columns[1].HeaderText = "Department";
            dgvListDepartment.Columns[0].Width = 30;
            dgvListDepartment.Columns[1].Width = 100;
            dgvListDepartment.AllowUserToAddRows = false; // Không cho người dùng thêm hàng dữ liệu
            dgvListDepartment.EditMode = DataGridViewEditMode.EditProgrammatically;

            // Load các department lên combox
            // Xóa dữ liệu cũ trước khi load
            cboDepartment.Items.Clear();
            foreach (DataRow dr in _tbldepartment.Rows)
            {
                cboDepartment.Items.Add(dr[1].ToString());
            }
        }

        private void LoadDatatblUser()
        {
            //throw new NotImplementedException();
            dgvListUser.DataSource = UserBLL.LayDatatblUserBLL();
            dgvListUser.Columns[0].HeaderText = "UserName";
            dgvListUser.Columns[0].Width = 150;
            dgvListUser.Columns[1].HeaderText = "Password";
            dgvListUser.Columns[1].Width = 100;
            dgvListUser.Columns[2].HeaderText = "Roles";
            dgvListUser.Columns[2].Width = 50;
            dgvListUser.Columns[3].HeaderText = "Position";
            dgvListUser.Columns[3].Width = 100;
            dgvListUser.Columns[4].HeaderText = "Department";
            dgvListUser.Columns[4].Width = 100;
            dgvListUser.AllowUserToAddRows = false;
            dgvListUser.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        /// <summary>
        /// Phương thức : Click vào 1 dòng thì hiển thị từng trường của datagritview lên các textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvListUser_Click(object sender, EventArgs e)
        {
            if (dgvListUser.Rows.Count == 0)
            {
                // Nếu Dữ liệu trống
                MessageBox.Show(rm.GetString("t10"));
                txtUserName.Focus();
                return;
            }

            // Nếu button "Add User" đang  bị khóa
            if (btnAddUser.Enabled == false)
            {
                MessageBox.Show(rm.GetString("t11"), rm.GetString("t7"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtUserName.Focus();
                return;
            }

            txtUserName.Text = dgvListUser.CurrentRow.Cells[0].Value.ToString();
            txtUserPassword.Text = dgvListUser.CurrentRow.Cells[1].Value.ToString();
            txtUserRoles.Text = dgvListUser.CurrentRow.Cells[2].Value.ToString();
            txtUserPosition.Text = dgvListUser.CurrentRow.Cells[3].Value.ToString();
            //txtUserDepartment.Text = dgvListUser.CurrentRow.Cells[4].Value.ToString();
            cboDepartment.Text = dgvListUser.CurrentRow.Cells[4].Value.ToString();
            cboLevel.SelectedIndex = Convert.ToInt32(dgvListUser.CurrentRow.Cells[5].Value.ToString()) - 1;

            // -- Các control button
            btnModifyUser.Enabled = true;
            btnDeleteUser.Enabled = true;
            cboDepartment.Enabled = true;
            cboLevel.Enabled = true;
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            // Kiểm tra giới hạn số lượng user
            DataTable quatitys = UserBLL.Get_Count_tblUsers_BLL();
            int quatity = Convert.ToInt16(quatitys.Rows[0]["c"].ToString());
            // Kiểm tra số lượng User không được vượt quá 20
            if (quatity > 20)
            {
                MessageBox.Show(rm.GetString("t1"));
                return;
            }
            else
            {
                btnModifyUser.Enabled = false;
                btnDeleteUser.Enabled = false;
                btnSaveUser.Enabled = true;
                btnAddUser.Enabled = false;
                ResetTextboxValue(true);
                txtUserName.Enabled = true; // cho phép nhập tên nhân viên mới
                cboDepartment.Enabled = true; // Cho phép chọn Department
                cboLevel.Enabled = true; // Cho phép chọn Level
                cboDepartment.SelectedIndex = 0;
                cboLevel.SelectedIndex = 2;
                txtUserName.Focus();
            }
        }

        private void btnSaveUser_Click(object sender, EventArgs e)
        {
            // Description : Kiểm tra thông tin của user và lưu vào Database
            // Lấy dữ liệu từ các textbox
            string username = txtUserName.Text;
            string pass = txtUserPassword.Text;
            string role = txtUserRoles.Text;
            string pos = txtUserPosition.Text;
            string dept = cboDepartment.SelectedItem.ToString();
            int level = cboLevel.SelectedIndex + 1;
            string thongbao;

            thongbao = rm.GetString("t2") + "\n " + rm.GetString("t3") + username + " \n " + rm.GetString("t4") + role + "\n" + rm.GetString("t5") + pos + "\n" + rm.GetString("t6") + dept;
            thongbao = thongbao + "\n" + rm.GetString("lb.Level") + level;
            DialogResult result = MessageBox.Show(thongbao, rm.GetString("t7"), MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                // Gọi phương thức  "ThemUserBLL" để  thêm dữ liệu
                if (UserBLL.ThemUserBLL(username, pass, role, pos, dept, level))
                {
                    // Nếu OK
                    MessageBox.Show(rm.GetString("t8"));
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
                    MessageBox.Show(rm.GetString("t9"));
                }
            }
            LoadDatatblUser();
        }

        private void btnSaveDept_Click(object sender, EventArgs e)
        {
            if (txtIdDept.Text == "") { MessageBox.Show(rm.GetString("t12")); }
            if (txtDepartmentName.Text == "") { MessageBox.Show(rm.GetString("t13")); }
            string Thongbao = rm.GetString("t14") + txtDepartmentName.Text;

            DialogResult dia = MessageBox.Show(Thongbao, rm.GetString("t7"), MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dia == DialogResult.Yes)
            {
                if (UserBLL.ThemDeptBLL(Convert.ToInt32(txtIdDept.Text), txtDepartmentName.Text))
                {
                    MessageBox.Show(rm.GetString("t15"));
                    LoadDatatblDepartments();
                    btnSaveDept.Enabled = false;
                    ResetTextboxValue(false);
                }
                else { MessageBox.Show(rm.GetString("t16")); }           // "Có lỗi, kiểm tra lại thông tin nhập vào"
            }
            else txtIdDept.Focus();
        }

        private void btnModifyUser_Click(object sender, EventArgs e)
        {
            // -----------------------------------------
            // Description  : Khi người dùng nháy chuột vào 1 dòng bản ghi bất kì trên Grid View
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
            string dept = cboDepartment.SelectedItem.ToString();
            int level = cboLevel.SelectedIndex + 1;
            string thongbao;
            thongbao = rm.GetString("t17");     //"Bạn có muốn sửa dữ liệu : ";
            thongbao = thongbao + "\n " + rm.GetString("t3") + username;
            thongbao = thongbao + "\n " + rm.GetString("t4") + role;
            thongbao = thongbao + "\n " + rm.GetString("t5") + pos;
            thongbao = thongbao + "\n " + rm.GetString("t6") + dept;
            thongbao = thongbao + "\n " + rm.GetString("lb.Level") + level;
            DialogResult result = MessageBox.Show(thongbao, rm.GetString("t7"), MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                // Gọi phương thức  "CapnhatUserBLL" để  sửa dữ liệu
                if (UserBLL.CapnhatUserBLL(username, pass, role, pos, dept, level))
                {
                    // Nếu OK
                    MessageBox.Show(rm.GetString("t18"));          // Đã sửa User mới thành công
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
                    MessageBox.Show(rm.GetString("t9"));  //Kiểm tra lại dữ liệu nhập vào.
                }
            }
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            if (dgvListUser.Rows.Count == 0)
            {
                //MessageBox.Show("Không có dữ liệu", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MessageBox.Show(rm.GetString("t19"), rm.GetString("t7"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //string thongbao = "Bạn có thực sự muốn xóa ----  " + dgvListUser.CurrentRow.Cells[0].Value.ToString() + " ----- ? ";
            string thongbao = rm.GetString("t20") + dgvListUser.CurrentRow.Cells[0].Value.ToString() + " ----- ? ";

            DialogResult dia = MessageBox.Show(thongbao, rm.GetString("t7"), MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dia == DialogResult.Yes)
            {
                if (UserBLL.XoaUserBLL(dgvListUser.CurrentRow.Cells[0].Value.ToString()))
                {
                    MessageBox.Show(rm.GetString("t21"));   // Đã xóa thành công
                    LoadDatatblUser();
                    ResetTextboxValue(true);
                }
                else
                {
                    MessageBox.Show(rm.GetString("t22"));      // Đã phát sinh lỗi
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
                MessageBox.Show(rm.GetString("t10"));      //Đang không có dữ liệu, cần kiểm tra lại
                txtDepartmentName.Focus();
                return;
            }

            // Nếu button "Add User" đang  bị khóa
            if (btnAddDept.Enabled == false)
            {
                //MessageBox.Show("Đang ở thêm phòng mới", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MessageBox.Show(rm.GetString("t23"), rm.GetString("t7"), MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            btnModifyDept.Enabled = false;
            btnSaveDept.Enabled = true;
            txtIdDept.Enabled = true;
            ResetTextboxValue(false);
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
                        //MessageBox.Show("Đã sửa  thành công phòng :  " + txtDepartmentName.Text);
                        MessageBox.Show(rm.GetString("t24") + txtDepartmentName.Text);
                        LoadDatatblDepartments();
                        LoadDatatblUser();
                        // ResetTextboxValue(false);
                        btnModifyDept.Enabled = false;
                    }
                    else
                    {
                        //MessageBox.Show("Lỗi !!! \n Kiểm tra lại tên phòng ");
                        MessageBox.Show(rm.GetString("t25"));
                    }
                }
                else
                {
                    txtDepartmentName.Focus();
                }
            }
            else
            {
                //MessageBox.Show("Chưa nhập tên phòng mới");
                MessageBox.Show(rm.GetString("t26"));
            }
        }

        private void btnDeleteDept_Click(object sender, EventArgs e)
        {
            //string thongbao = "Bạn có muốn delete phòng" + txtIdDept.Text + " -- " + txtDepartmentName.Text;
            string thongbao = rm.GetString("t27") + txtIdDept.Text + " -- " + txtDepartmentName.Text;
            DialogResult result = MessageBox.Show(thongbao, rm.GetString("t7"), MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                if (UserBLL.XoaDeptBLL(Convert.ToInt32(txtIdDept.Text)))
                {
                    //MessageBox.Show("Đã xóa thành công ");
                    MessageBox.Show(rm.GetString("t28"));
                    LoadDatatblUser();
                    LoadDatatblDepartments();
                    ResetTextboxValue(false);
                }
                else
                {
                    //MessageBox.Show("Xuất hiện lỗi !!! \n Không xóa được ");
                    MessageBox.Show(rm.GetString("t29"));
                }
            }
            else return;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}