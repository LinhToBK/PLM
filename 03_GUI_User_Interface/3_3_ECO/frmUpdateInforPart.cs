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

namespace PLM_Lynx._03_GUI_User_Interface._3_3_ECO
{
    public partial class frmUpdateInforPart : Form
    {
        private ECO_BLL ecoBLL = new ECO_BLL();
        private CommonBLL commonBLL = new CommonBLL();
        
        public frmUpdateInforPart()
        {
            InitializeComponent();


        }

        //==========================================================================
        //              DANH SÁCH HÀM TỰ TẠO 
        //==========================================================================


        /// <summary>
        /// 01. Hàm sẽ lấy 1 file trong máy tính và hiển thị lên dgvListUpload
        /// </summary>
        private void HienthiFile_To_dgvListUpload()
        {
            // Tạo OpenFileDiaglog đển chọn file
            using (OpenFileDialog open = new OpenFileDialog())
            {
                // Giới hạn các định dạng file được chọn
                open.Title = "Vui lòng chọn file ";
                string filternote = @"PDF Files (*.pdf)|*.pdf|";
                filternote = filternote + @"STP Files (*.stp)|*.stp|";
                filternote = filternote + @"STP Files (*.jpg)|*.jpg|";
                filternote = filternote + @"DWG Files (*.dwg)|*.dwg|";
                filternote = filternote + @"DXF Files (*.dxf)|*.dxf|";
                filternote = filternote + @"All Supported Files (*.pdf;*.stp;*.dwg;*.dxf;*.jpg)|*.jpg;*.pdf;*.stp;*.dwg;*.dxf";
                open.Filter = filternote;


                // Nếu người dùng chọn 1 file 
                if (open.ShowDialog() == DialogResult.OK)
                {
                    FileInfo in4 = new FileInfo(open.FileName);
                    string ExtensionFile = in4.Extension;
                    // Kiểm tra nếu phần mở rộng đã tồn tại trong DataGridView 
                    bool IsTrungExtension = false;

                    foreach (DataGridViewRow row in dgvListUpload.Rows)
                    {
                        // Kiểm tra giá trị của từng phần tử trong cột
                        string ExtensionExist = row.Cells[2].Value?.ToString();
                        if (ExtensionFile == ExtensionExist)
                        {
                            IsTrungExtension = true;
                            break;
                        }

                    }

                    // Nếu không có phần mở rộng trùng, thêm tệp vào DataGritview
                    if (!IsTrungExtension)
                    {

                        dgvListUpload.Rows.Add(in4.Name, in4.Length / 1024 + "KB", in4.Extension, in4.FullName);
                    }
                    else
                    {
                        MessageBox.Show("Đã có tệp có phần Entension trùng ");
                        return;
                    }

                }

            }
        }

        /// <summary>
        /// 02. Load các thông tin của 1 Part và hiển thị lên form
        /// </summary>
        /// <param name="partcode"></param>
        public void LoadDataPart(string partcode)
        {
            txtPartCode.Text = partcode;
            
            DataTable dt = ecoBLL.GetInforPartBLL(partcode);
            // Kiểm tra xem Datatable có dữ liệu không
            if(dt.Rows.Count > 0)
            {
                // Có dữ liệu thì sẽ đẩy lên các ô textbox
                txtPartName.Text=   dt.Rows[0][3].ToString();
                txtPartDescript.Text = dt.Rows[0][5].ToString();
                txtPartLog.Text = dt.Rows[0][9].ToString();
                txtPartStage.Text = dt.Rows[0][6].ToString();


                // Cập nhật lên danh sách file
                if(commonBLL.GetAllFileinFolder(partcode, dgvListFile)== false)
                {
                    MessageBox.Show("Không thể load folder chứa dữ liệu ");
                }
                else
                {
                    txtListFileStatus.Text = "Kết nối được với dữ liệu của Part";
                }  
                
                // Đặt giá trị DV là giá trị mặc định trong Combo Box
                cboNewStage.SelectedIndex = 0;
                
                

            } 
            else
            {
                MessageBox.Show("Không lấy được dữ liệu từ Database");
                this.Close();
            }    

        }

        private bool IsAllowedExtension(string filePath)
        {
            string[] allowedExtensions = { ".stp", ".jpg", ".dwg", ".dxf", ".pdf" };
            string fileExtension = System.IO.Path.GetExtension(filePath).ToLower();
            return allowedExtensions.Contains(fileExtension);
        }


        //==========================================================================
        //   KẾT THÚC-    DANH SÁCH HÀM TỰ TẠO 
        //==========================================================================



        private void dgvListFile_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Nếu click đúp vào 1 Cells thì sẽ Preview File của dòng đó
            string filename = dgvListFile.CurrentRow.Cells[0].Value.ToString();
            string DataPath = Properties.Settings.Default.LinkDataPart;
            string[] input = txtPartCode.Text.Split('-');  // Chia XXX-YYYYY thành 2 phần : XXX và YYYYY
            filename = DataPath + input[0] + "\\" + input[1] + "\\" + filename;
            try
            {
                commonBLL.PreviewFile(filename);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi phát sinh khi  mở file : " + ex.Message);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            
            DialogResult kq = MessageBox.Show("Bạn có muốn thoát việc cập nhật không ", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if( kq == DialogResult.Yes)
            {
                this.Close();
            } 
            else
            {
                return;
            }    
                
        }

        private void btnAddNewFile_Click(object sender, EventArgs e)
        {
            HienthiFile_To_dgvListUpload();
        }

        private void btnDeleteFile_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có hàng nào được chọn không ?
            if (dgvListUpload.SelectedRows.Count > 0)
            {
                // Xóa hàng đầu tiên trong danh sách chọn
                try
                {
                    dgvListUpload.Rows.RemoveAt(dgvListUpload.SelectedRows[0].Index);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Phát sinh lỗi" + ex.Message);
                    return;
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn 1 hàng để xóa");
            }
        }

        private void dgvListUpload_DragEnter(object sender, DragEventArgs e)
        {
            // Xác định khi con trỏ chuột kéo tệp vào vùng DatagridView
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                if (files.All(file => IsAllowedExtension(file)))
                {
                    e.Effect = DragDropEffects.Copy;
                }
                else
                {
                    e.Effect = DragDropEffects.None;
                }
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void dgvListUpload_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            foreach (string file in files)
            {
                if (IsAllowedExtension(file))
                {
                    // Hàm thêm dòng vào dgvFile Attachment
                    ThemFile2listFile(file);

                }
                else
                {
                    MessageBox.Show($"Tệp không hợp lệ: {file}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

        }

        private void ThemFile2listFile(string file)
        {

            FileInfo in4 = new FileInfo(file);
            string ExtensionFile = in4.Extension;
            bool CheckTrung;
            CheckTrung = false;
            foreach (DataGridViewRow row in dgvListUpload.Rows)
            {
                // Kiểm tra giá trị của từng phần tử trong cột
                string ExtensionExist = row.Cells[2].Value?.ToString();
                if (ExtensionFile == ExtensionExist)
                {
                    CheckTrung = true;
                    break;
                }
            }

            //Nếu không có phần mở rộng trùng, thêm tệp vào DataGritview
            if (!CheckTrung)
            {

                dgvListUpload.Rows.Add(in4.Name, in4.Length / 1024 + "KB", in4.Extension, in4.FullName);
            }
            else
            {
                // MessageBox.Show("Đã có tệp có phần Entension trùng  thì phải ");
                return;
            }
        }

        private void frmUpdateInforPart_Load(object sender, EventArgs e)
        {
            // Thiết lập cấu hình cho dgvFileAttachment
            // Thiết lập các cột cho dgvListFile
            dgvListUpload.ColumnCount = 4;
            dgvListUpload.Columns[0].Name = "Name";
            dgvListUpload.Columns[1].Name = "Size";
            dgvListUpload.Columns[2].Name = "Type";
            dgvListUpload.Columns[3].Name = "FullName";
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem combobox NewStage đang dùng là Stage nào:
            // MessageBox.Show(dgvListUpload.Rows.Count.ToString());
            string statusnewstage;
            statusnewstage = "";
            

            if(cboNewStage.SelectedItem.ToString() != txtPartStage.Text)
            {
                statusnewstage = "Đã cập nhật stage ";
            }    

            // Tổng hợp các thông báo trước khi cập nhật
            string thongbao;
            thongbao = "Kiểm tra lại các thông tin sau trước khi upload lên DataBase";
            thongbao += "\n +) PartName : " + txtPartName.Text;
            thongbao += "\n +) Part Descript :" + txtPartDescript.Text;
            
            string LogInfor;
            LogInfor = txtNoteMore.Text;
            string stage;
            if(statusnewstage == "")
            {
                thongbao += "\n +) Part Stage : " + txtPartStage.Text;
                LogInfor +=  " , Stage [ " + txtPartStage.Text + " ] No Change --- ";
                stage = txtPartStage.Text;
            }   
            else
            {
                // Đã cập nhật stage mới
                thongbao += "\n +) Part Stage : " + cboNewStage.SelectedItem.ToString();
                LogInfor += " , Stage Change : from [ " + txtPartStage.Text  + " ] to [ "  + cboNewStage.SelectedItem.ToString() + " ]";
                stage = cboNewStage.SelectedItem.ToString();
            }

            // Kiểm tra xem trong ListFileUpload có file hay không  
            
            if(dgvListUpload.Rows.Count > 1)
            {
                // Nếu có thì thêm thông báo
                thongbao += "\n +) Có đình kèm bản vẽ update";
                LogInfor += " - Have File Attachment. ";
                
            } 
            else
            {
                thongbao += "\n +) Không có file nào được thêm mới ";
                LogInfor += " - No have file attachment. ";
            }    
            
            
            // Chọn update hay không update
            DialogResult kq = MessageBox.Show(thongbao, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq == DialogResult.Yes)
            {
                // Tiến hàng việc cập nhật
                // 
                //  Bước 1 : Update các du lieu len Base
                string uploadstatus;

                if (ecoBLL.CapnhatInforPartBLL(txtPartCode.Text, txtPartName.Text, txtPartDescript.Text, stage, LogInfor))
                {
                    uploadstatus = "1. Đã cập nhật thành công DataBase \n";
                    // Nếu OK thì mới cho copy file
                    // Bước 2 : Đổi tên các file trong dgvFileUpload và lưu vào trong thư mục chứa dữ liệu
                    string[] FolderName = txtPartCode.Text.Split('-');
                    // FolderName[0] : XXX : PartFamily 
                    // FolderName[1] : YYYYY : PartNo

                    string FolderPath = Properties.Settings.Default.LinkDataPart  + FolderName[0] + "\\" + FolderName[1];
                    try
                    {
                        // Duyệt qua các hàng  trong DataGridView
                        foreach (DataGridViewRow row in dgvListUpload.Rows)
                        {
                            if (row.Cells[3].Value != null) //Kiểm tra tại cột FileName
                            {
                                // Lấy đường dẫn của file từ cột trong Datagridview 
                                string SourceFilePath = row.Cells[3].Value.ToString();
                                string FileExtension = row.Cells[2].Value.ToString();

                                // Tạo tên File mới dựa trên  tên thư mục và phần mở rộng của file
                                string NewFileName = FolderPath + "//" + txtPartCode.Text + "-" + cboNewStage.SelectedItem.ToString() + DateTime.Now.ToString("MM-dd-yyyy HH-mm") + FileExtension;
                                // Tên đường dẫn đến folder + tên partcode mới + . đuôi file
                                string TargetFilePart = Path.Combine(FolderPath, NewFileName);

                                // Sao chép file vào thư mục đích với tên mới
                                File.Copy(SourceFilePath, TargetFilePart, true);
                                //MessageBox.Show("Đã sao chép thành công ");
                            }
                         
                        }
                        uploadstatus += " +) Thành công copy file attachment vào DataBase \n";

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        uploadstatus += " +) Thất bại trong việc copy file vào Database \n ";

                    }
                }
                else
                {
                    uploadstatus = " +) Lỗi khi cập nhật DataBase \n ";
                }

                MessageBox.Show(uploadstatus);
            }
            else
            {

                return;
            }


        }
    }
}
