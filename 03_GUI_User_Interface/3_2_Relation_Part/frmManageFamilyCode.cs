using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PLM_Lynx._02_BLL_Bussiness_Logic_Layer;

namespace PLM_Lynx._03_GUI_User_Interface
{
    public partial class frmManageFamilyCode : Form
    {

        private ManageFamilyCodeBLL FamilyCodeBLL = new ManageFamilyCodeBLL(); 
        public frmManageFamilyCode()
        {
            InitializeComponent();
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
            string FamilyCode = txtFamilyCode.Text;
            string FamilyType = txtFamilyType.Text;
            string FamilyDescript = txtFamilyDescript.Text;
            string Thongbao = " Bạn muốn thêm dữ liệu : \n " + FamilyCode + "]";
            Thongbao = Thongbao + "\n [ " + FamilyType + "] ";
            Thongbao = Thongbao + "\n [ "  + FamilyDescript + "]";

            DialogResult result = MessageBox.Show (Thongbao,"Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(result == DialogResult.Yes)
            {
                // --- Gọi phương thức thêm dữ liệu ThemFamilyBLL 
                if(FamilyCodeBLL.ThemFamilyCodeBLL(FamilyCode, FamilyType, FamilyDescript))
                {
                    // Nếu OK

                    // Thêm Foldermoi trong Database Folder
                    try
                    {
                        string NewFolderPath = Path.Combine(Properties.Settings.Default.LinkDataPart, FamilyCode);
                        Directory.CreateDirectory(NewFolderPath);
                        MessageBox.Show("Đã thêm Family code mới thành công");
                        ResetallTextbox();
                        btnDelete.Enabled = true;
                        btnModify.Enabled = true;
                        btnSave.Enabled = true;
                        btnSave.Enabled = false; // Vừa cập nhật xong thì cần tắt nút Save
                        txtFamilyCode.Enabled = false; // Tắt để không thể sửa được dữ liệu
                        LoadFamilyCode();
                    }
                    catch ( Exception ex)
                    {
                        MessageBox.Show("Xuất hiện lỗi : " + ex.Message );
                    }
                    
                }    
                else
                {
                    // Nếu NG
                    MessageBox.Show("Không thể thêm User mới. \n Kiểm tra lại các thông tin nhập vào ");
                    txtFamilyCode.Focus ();
                    txtFamilyCode.Enabled = true ; // Nếu lỗi thì quay trở lại sửa dữ liệu
                }    

            } 
                
        }

        private void dgvFamilyCode_Click(object sender, EventArgs e)
        {
            // Khi click thì cần khóa lại Textbox Family Code trước
            txtFamilyCode.Enabled = false;
            if(dgvFamilyCode.Rows.Count == 0)
            {
                MessageBox.Show("Đang không có dữ liệu, cần kiểm tra lại ");
                return;
            }

            //if(btnAdd.Enabled ==false)
            //{
            //    // Nếu button Add FamilyCode đang bị khóa
            //    return;
            //}

            // Lấy thông tin từ DataGrid View để show lên Textbox
            txtFamilyCode.Text = dgvFamilyCode.CurrentRow.Cells[0].Value.ToString();
            txtFamilyType.Text = dgvFamilyCode.CurrentRow.Cells[1].Value.ToString();
            txtFamilyDescript.Text = dgvFamilyCode.CurrentRow.Cells[2].Value.ToString();

            // --- Mode Button
            btnModify.Enabled = true;
            btnDelete.Enabled = true ;
            btnAdd.Enabled = true ;
     
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            if(txtFamilyCode.Text !="")
            {
                DialogResult result = MessageBox.Show("Bạn định sửa code :  " + txtFamilyCode.Text + " phải không ?","Thông báo",MessageBoxButtons.OKCancel);
                if(result == DialogResult.OK)
                {
                    // Tạo hàm để cập nhật 
                    string familycode = txtFamilyCode.Text;
                    string familytype = txtFamilyType.Text;
                    string familydescript = txtFamilyDescript.Text;
                    if(FamilyCodeBLL.CapNhatFamilyCodeBLL(familycode, familytype, familydescript) == true)
                    {
                        MessageBox.Show("Đã cập nhật dữ liệu thành công");
                        LoadFamilyCode();
                    }    
                    else
                    {
                        MessageBox.Show("Xuất hiện lỗi, Cần kiểm tra lại thông tin");
                    }    
                }
                else
                {
                    txtFamilyCode.Focus();
                }        
            }
            else
            {
                MessageBox.Show("Bạn chưa nhập tên phòng mới ");
                txtFamilyCode.Focus();
            } 
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string Thongbao = "Bạn có muốn xóa Family code : " + txtFamilyCode.Text + " không ?";
            Thongbao = Thongbao + "\n Khi xóa , thì toàn bộ dữ liệu của family code sẽ bị mất.";
            Thongbao = Thongbao + "\n Không thể khôi phục lại được.";
            DialogResult result = MessageBox.Show(Thongbao,"Cảnh báo",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                // Nếu vẫn chấp nhận xóa
                try
                {
                    // 1.--- Xóa dữ liệu ở trên DataBase
                    if (FamilyCodeBLL.XoaFamilyCodeBLL(txtFamilyCode.Text))
                    {
                        MessageBox.Show("Đã xóa thành công trong Database " + txtFamilyCode.Text);
                        LoadFamilyCode();
                        
                    }
                    else
                    {
                        MessageBox.Show("Đã xuất hiện lỗi, không xóa được trong Database");
                    }
                    // 2. --- Xóa Folder trong DataBaseFolder
                    
                    string DeleteFolder = Path.Combine(Properties.Settings.Default.LinkDataPart, txtFamilyCode.Text);
                    //MessageBox.Show("Sẽ xóa thư mục : " + DeleteFolder);
                    string DestinationFolder = Properties.Settings.Default.TrashDataPart;
                    //MessageBox.Show("Thư mục đích : " +  DestinationFolder);
                    string DestinationFolderWithName = Path.Combine(DestinationFolder, new DirectoryInfo(DeleteFolder).Name);

                    // Kiểm  tra thư mục gốc PartCode có khoong 
                    // Kiểm tra xem thư mục đích đã tồn tại chưa, nếu chưa thì tạo mới
                    if(!Directory.Exists(DestinationFolder))
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
                    MessageBox.Show("Xuất hiện lỗi : " + ex.Message);
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
            btnSave.Enabled = !string.IsNullOrWhiteSpace(txtFamilyCode.Text);
        }
    }
}
