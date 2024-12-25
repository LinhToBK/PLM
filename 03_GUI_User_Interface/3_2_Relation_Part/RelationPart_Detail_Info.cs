using PLM_Lynx._02_BLL_Bussiness_Logic_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PLM_Lynx._03_GUI_User_Interface
{
    public partial class frmRelationPart_Detail_Info : Form
    {


        private RelationPartBLL RelationPartBLL = new RelationPartBLL();
        private CommonBLL commonBLL = new CommonBLL();  
        public frmRelationPart_Detail_Info()
        {
            InitializeComponent();

            // Kích hoạt sự kiện KeyDown
            this.KeyDown += new KeyEventHandler(frmRelationPart_Detail_Info_KeyDown);
            this.KeyPreview = true; // Cần bật Key Preview để Form bắt được phím
        }

        // ==============================================================
        //          DANH SÁCH HÀM TỰ TẠO 
        // ==============================================================
        /// <summary>
        /// 01. Hiển thị các thuộc tính của Part lên các ô textbox
        /// </summary>
        /// <param name="partcode"></param>
        public void ShowDetailInfor( string partcode )
        {
           // Gọi BLL để lấy dữ liệu
           
            DataTable DetailInfor = RelationPartBLL.GetInforPartBLL( partcode );
            if(DetailInfor.Rows.Count > 0)
            {
                // Hiển thị dữ liệu lên các ô textbox. sẽ lấy hàng đầu tiên 
                DataRow row0 = DetailInfor.Rows[0];
                txtPartCode.Text = row0[0].ToString();
                txtPartName.Text = row0[1].ToString();
                txtPartStage.Text = row0[3].ToString();
                txtPartDescription.Text = row0[2].ToString();
                txtPartLog.Text = row0[4].ToString();

                // Hiển thị ảnh 
                if(commonBLL.UploadImagebyPartCode(partcode, PicPart) == true)
                {
                    txtPicStatus.Text = "Image is ";
                }   
                else
                {
                    txtPicStatus.Text = "No FindImage";
                }  
                // Hiển thị danh sách file
                if(commonBLL.GetAllFileinFolder(partcode, dgvListFile) == true)
                {
                    txtListFileStatus.Text = "Danh sách file hiển thị ở bên dưới ";

                } 
                else
                {
                    txtListFileStatus.Text = "Part đang trống dữ liệu, cần kiểm tra lại ";
                }    
                    
                
            } 
            else
            {
                MessageBox.Show("Lỗi, không tìm thấy dữ liệu ");
            }    
                
        }

        private void frmRelationPart_Detail_Info_Load(object sender, EventArgs e)
        {
           
        }

        private void frmRelationPart_Detail_Info_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
            {
                this.Close();
            } 
                
        }

        private void dgvListFile_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Nếu click đúp vào 1 Cells thì sẽ Preview File của dòng đó
            
            string filename = dgvListFile.CurrentRow.Cells[0].Value.ToString();
            // MessageBox.Show(dgvListFile.CurrentRow.Cells[1].Value.ToString());
            string filesize_A = dgvListFile.CurrentRow.Cells[1].Value.ToString();
            filesize_A = filesize_A.Substring(0,filesize_A.Length - 2);
            int filesize = Convert.ToInt32(filesize_A);
            


            string DataPath = Properties.Settings.Default.LinkDataPart;
            string[] input = txtPartCode.Text.Split('-');  // Chia XXX-YYYYY thành 2 phần : XXX và YYYYY
            filename = DataPath + input[0] + "\\" + input[1] + "\\" + filename;
            try     
            {

                if (filesize > 10000)
                {
                    DialogResult kq = MessageBox.Show("Kích thước file lớn hơn 10MB \n Bạn có muốn mở không ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (kq == DialogResult.Yes)
                    {
                        commonBLL.PreviewFile(filename);
                    }
                    else
                    {
                        return;
                    }    
                }
                else
                {
                    commonBLL.PreviewFile(filename);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi phát sinh khi  mở file : " + ex.Message);
            }
            
        }

        private void btnDownLoadFile_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra xem có dòng nào được chọn không
                if (dgvListFile.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Hãy chọn ít nhất một dòng trong DataGridView!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Mở Folder Browser Dialog để chọn thư mục đích
                using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
                {
                    folderDialog.Description = "Chọn thư mục đích để copy các file";
                    if (folderDialog.ShowDialog() == DialogResult.OK)
                    {
                        string destinationFolder = folderDialog.SelectedPath;

                        // Duyệt qua các dòng được chọn trong DataGridView
                        foreach (DataGridViewRow row in dgvListFile.SelectedRows)
                        {
                            // Lấy đường dẫn file từ cột đầu tiên
                            string sourceFilePath = row.Cells[0].Value?.ToString();
                            sourceFilePath = commonBLL.GetFilePath(txtPartCode.Text) + "\\" + sourceFilePath;

                            // Kiểm tra giá trị hợp lệ
                            if (!string.IsNullOrEmpty(sourceFilePath) && File.Exists(sourceFilePath))
                            {
                                try
                                {
                                    // Lấy tên file
                                    string fileName = Path.GetFileName(sourceFilePath);

                                    // Tạo đường dẫn đích
                                    string destinationFilePath = Path.Combine(destinationFolder, fileName);

                                    // Copy file
                                    File.Copy(sourceFilePath, destinationFilePath, overwrite: true);
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show($"Không thể copy file: {sourceFilePath}\n{ex.Message}",
                                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }

                        MessageBox.Show("Download file hoàn tất!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
    }
}
