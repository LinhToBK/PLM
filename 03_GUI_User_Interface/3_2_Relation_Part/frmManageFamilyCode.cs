using PLM_Lynx._02_BLL_Bussiness_Logic_Layer;
using System;
using System.Globalization;
using System.IO;
using System.Resources;
using System.Threading;
using System.Windows.Forms;

namespace PLM_Lynx._03_GUI_User_Interface
{
    public partial class frmManageFamilyCode : Form
    {
        private ManageFamilyCodeBLL FamilyCodeBLL = new ManageFamilyCodeBLL();
        public int userlevel { get; set; } // Để kiểm tra quyền của User đang đăng nhập vào hệ thống

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

            rm = new ResourceManager("PLM_Lynx._03_GUI_User_Interface._3_2_Relation_Part.Lang.Lang_ManageFamilyCode", typeof(frmManageFamilyCode).Assembly);
            // Hiển thị ngôn ngữ lên các điều khiển trong form
            this.Text = rm.GetString("i.form");

            btnAdd.Text = rm.GetString("btnAdd");
            btnDelete.Text = rm.GetString("btnDelete");
            btnModify.Text = rm.GetString("btnModify");
            btnSave.Text = rm.GetString("btnSave");

            label1.Text = rm.GetString("lb1");
            label2.Text = rm.GetString("lb2");
            label3.Text = rm.GetString("lb3");
            label4.Text = rm.GetString("lb4");
            groupBox1.Text = rm.GetString("lb5");

            Properties.Settings.Default.Language = lang;
            Properties.Settings.Default.Save();
        }

        // =========== Language =========================

        public frmManageFamilyCode()
        {
            InitializeComponent();
            LoadLanguage();
            // Gán sự kiện TexChanged cho textbox  txtFamilyCode
            txtFamilyCode.TextChanged += txtFamilyCode_TextChanged;
            btnSave.Enabled = false;
        }

        private void txtFamilyDescript_TextChanged(object sender, EventArgs e)
        {
        }

        private void frmManageFamilyCode_Load(object sender, EventArgs e)
        {
            // - Load dữ liệu lên tableFamilyCode
            LoadFamilyCode();

            // - Đặt mode cho button
            txtFamilyCode.Enabled = false;

            // Nếu là quản trị viên mới cho phép thêm sửa xóa
            if (userlevel != 1)
            {
                btnAdd.Enabled = false;
                btnDelete.Enabled = false;
                btnModify.Enabled = false;
                btnSave.Enabled = false;
                txtFamilyCode.Enabled = false; // Không cho sửa FamilyCode
                txtFamilyDescript.Enabled = false; // Không cho sửa FamilyDescript
                txtFamilyType.Enabled = false; // Không cho sửa FamilyType
            }
        }

        /// <summary>
        /// Danh sách các hàm tự tạo
        /// </summary>
        private void LoadFamilyCode()
        {
            dgvFamilyCode.DataSource = FamilyCodeBLL.LayDataFamilyBLL();

            dgvFamilyCode.AllowUserToAddRows = false;
            dgvFamilyCode.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void ResetallTextbox()
        {
            txtFamilyCode.Text = "";
            txtFamilyType.Text = "";
            txtFamilyDescript.Text = "";
        }

        /// <summary>
        /// =====================================================
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            btnAdd.Enabled = false;
            btnDelete.Enabled = false;
            btnModify.Enabled = false;

            ResetallTextbox();
            txtFamilyCode.Enabled = true;
            txtFamilyCode.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string FamilyCode = txtFamilyCode.Text.Trim();
            string FamilyType = txtFamilyType.Text.Trim();
            string FamilyDescript = txtFamilyDescript.Text.Trim();
            // Kiểm tra dữ liệu đầu vào
            if (CheckFamilyCode(FamilyCode, FamilyType, FamilyDescript) == false)
            {
                return;
            }
            string Thongbao = rm.GetString("t01") + " \n " + FamilyCode + "]";   //  Bạn muốn thêm dữ liệu :
            Thongbao = Thongbao + "\n [ " + FamilyType + "] ";
            Thongbao = Thongbao + "\n [ " + FamilyDescript + "]";

            DialogResult result = MessageBox.Show(Thongbao, rm.GetString("t0"), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                // --- Gọi phương thức thêm dữ liệu ThemFamilyBLL
                if (FamilyCodeBLL.ThemFamilyCodeBLL(FamilyCode, FamilyType, FamilyDescript))
                {
                    // Nếu OK

                    // Thêm Foldermoi trong Database Folder
                    try
                    {
                        string NewFolderPath = Path.Combine(Properties.Settings.Default.LinkDataPart, FamilyCode);
                        Directory.CreateDirectory(NewFolderPath);
                        MessageBox.Show(rm.GetString("t16")); // Đã thêm Family code mới thành công
                        ResetallTextbox();
                        btnDelete.Enabled = true;
                        btnModify.Enabled = true;

                        btnSave.Enabled = false; // Vừa cập nhật xong thì cần tắt nút Save
                        txtFamilyCode.Enabled = false; // Tắt để không thể sửa được dữ liệu
                        LoadFamilyCode();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error : " + ex.Message, rm.GetString("t0"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    // Nếu NG
                    // MessageBox.Show("Không thể thêm User mới. \n Kiểm tra lại các thông tin nhập vào ");
                    MessageBox.Show(rm.GetString("t02"));
                    txtFamilyCode.Focus();
                    txtFamilyCode.Enabled = true; // Nếu lỗi thì quay trở lại sửa dữ liệu
                }
            }
        }

        private void dgvFamilyCode_Click(object sender, EventArgs e)
        {
            // Khi click thì cần khóa lại Textbox Family Code trước
            txtFamilyCode.Enabled = false;
            if (dgvFamilyCode.Rows.Count == 0)
            {
                //MessageBox.Show("Đang không có dữ liệu, cần kiểm tra lại ");
                MessageBox.Show(rm.GetString("t03"));
                return;
            }

            // Lấy thông tin từ DataGrid View để show lên Textbox
            txtFamilyCode.Text = dgvFamilyCode.CurrentRow.Cells[0].Value.ToString();
            txtFamilyType.Text = dgvFamilyCode.CurrentRow.Cells[1].Value.ToString();
            txtFamilyDescript.Text = dgvFamilyCode.CurrentRow.Cells[2].Value.ToString();

            // --- Mode Button
            if (userlevel == 1)
            {
                btnModify.Enabled = true;
                btnDelete.Enabled = true;
                btnAdd.Enabled = true;
                btnSave.Enabled = true;
                txtFamilyType.Enabled = true; // Cho phép sửa FamilyType
                txtFamilyDescript.Enabled = true; // Cho phép sửa FamilyDescript
            }
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            if (txtFamilyCode.Text.Trim() != "")
            {
                string tb = rm.GetString("t04") + " \n [ " + txtFamilyCode.Text.Trim() + " ]"; // Bạn có muốn sửa dữ liệu :

                DialogResult result = MessageBox.Show(tb, rm.GetString("t0"), MessageBoxButtons.OKCancel);
                if (result == DialogResult.OK)
                {
                    // Tạo hàm để cập nhật
                    string familycode = txtFamilyCode.Text.Trim();
                    string familytype = txtFamilyType.Text.Trim();
                    string familydescript = txtFamilyDescript.Text.Trim();

                    if (CheckFamilyCode(familycode, familytype, familydescript) == false)
                    {
                        return;
                    }
                    if (FamilyCodeBLL.CapNhatFamilyCodeBLL(familycode, familytype, familydescript) == true)
                    {
                        //MessageBox.Show("Đã cập nhật dữ liệu thành công");
                        MessageBox.Show(rm.GetString("t05"));
                        LoadFamilyCode();
                    }
                    else
                    {
                        //MessageBox.Show("Xuất hiện lỗi, Cần kiểm tra lại thông tin");
                        MessageBox.Show(rm.GetString("t06"));
                    }
                }
                else
                {
                    txtFamilyCode.Focus();
                }
            }
            else
            {
                MessageBox.Show(rm.GetString("t07"));    // Bạn chưa nhập tên Family Code mới
                txtFamilyCode.Focus();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string Thongbao = rm.GetString("t08") + txtFamilyCode.Text;    // "Bạn có muốn xóa Family code : "
            Thongbao = Thongbao + rm.GetString("t09");

            DialogResult result = MessageBox.Show(Thongbao, rm.GetString("t0"), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                // Nếu vẫn chấp nhận xóa
                try
                {
                    // 1.--- Xóa dữ liệu ở trên DataBase
                    if (FamilyCodeBLL.XoaFamilyCodeBLL(txtFamilyCode.Text))
                    {
                        MessageBox.Show(rm.GetString("t10") + txtFamilyCode.Text);
                        LoadFamilyCode();
                    }
                    else
                    {
                        //MessageBox.Show("Đã xuất hiện lỗi, không xóa được trong Database");
                        MessageBox.Show(rm.GetString("t11"));
                    }
                    // 2. --- Xóa Folder trong DataBaseFolder

                    string DeleteFolder = Path.Combine(Properties.Settings.Default.LinkDataPart, txtFamilyCode.Text.Trim());

                    string DestinationFolder = Properties.Settings.Default.TrashDataPart;

                    string DestinationFolderWithName = Path.Combine(DestinationFolder, new DirectoryInfo(DeleteFolder).Name);

                    // Kiểm  tra thư mục gốc PartCode có khoong
                    // Kiểm tra xem thư mục đích đã tồn tại chưa, nếu chưa thì tạo mới
                    if (!Directory.Exists(DestinationFolder))
                    {
                        Directory.CreateDirectory(DestinationFolder);
                    }
                    // Kiểm tra ở trong thư mục đích đã có thư mục xóa hay chưa ? Nếu trùng , thì xóa thư mục trùng trước đó
                    if (Directory.Exists(DestinationFolderWithName))
                    {
                        Directory.Delete(DestinationFolderWithName, true); // Xóa thư mục trùng  trên
                    }

                    // Di chuyển thư mục
                    Directory.Move(DeleteFolder, DestinationFolderWithName);
                    MessageBox.Show("Đã di chuyển vào thùng rác thành công ");
                    ResetallTextbox();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error : " + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                return;
            }
        }

        private void txtFamilyCode_TextChanged(object sender, EventArgs e)
        {
            // Nếu dữ liệu được thay đổi thì button Save New được bật
            // btnSave.Enabled = !string.IsNullOrWhiteSpace(txtFamilyCode.Text);
        }

        private bool CheckFamilyCode(string FamilyCode, string FamilyType, string FamilyDescript)
        {
            bool _checkcode = false;
            bool _checktype = false;
            bool _checkdescript = false;
            if (FamilyCode.Length == 3)
            { _checkcode = true; }
            else
            {
                MessageBox.Show(rm.GetString("t13"));
            }

            if (FamilyType.Length < 30)
            { _checktype = true; }
            else
            {
                MessageBox.Show(rm.GetString("t14"));
            }

            if (FamilyDescript.Length < 50)
            { _checkdescript = true; }
            else
            {
                MessageBox.Show(rm.GetString("t15"));
            }

            if (_checkcode && _checktype && _checkdescript)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}