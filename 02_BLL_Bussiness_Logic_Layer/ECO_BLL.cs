using PLM_Lynx._01_DAL_Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Windows.Forms.VisualStyles;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Resources;

namespace PLM_Lynx._02_BLL_Bussiness_Logic_Layer
{
    public class ECO_BLL
    {
        private FindPartDAL findpartDAL = new FindPartDAL();
        private ECO_DAL ecoDAL = new ECO_DAL();
        private CommonInforDAL commonInforDAL = new CommonInforDAL();

        // =========== Language =========================
        // private ResourceManager rm = new ResourceManager("PLM_Lynx._02_BLL_Bussiness_Logic_Layer.Lang_BLL", typeof(ECO_BLL).Assembly);

        // =========== Language =========================

        public DataTable GetListChildBLL(string ParentCode)
        {
            return ecoDAL.GetListChildDAL(ParentCode);
        }

        public bool CapnhatQuantityBLL(string parentcode, string childcode, int quantity , string ECONo)
        {
            bool check = false;

            if (ecoDAL.Write_ECONo_to_tblPart_DAL(parentcode, ECONo) && ecoDAL.CapnhatQuantityDAL(parentcode, childcode, quantity) )
            {
                check = true;
            }

            return check;
        }

        public bool XoaRelationBLL(string parentcode, string childcode , string ECONo)
        {
            bool check = false;
            if ( ecoDAL.XoaRelationDAL(parentcode, childcode) && ecoDAL.Write_ECONo_to_tblPart_DAL(parentcode, ECONo) )
            {
                check = true;
            }
            else
            {
                check = false;
            }
            return check;
        }

        public DataTable GetInforPartBLL(string PartCode)
        {
            return ecoDAL.GetInforPartDAL(PartCode);
        }

        public bool UpdateInforPart_BLL(string PartCode, int PartStageID, string PartMaterial, int ECONo)
        {
            return ecoDAL.Update_InforPart_DAL(PartCode, PartStageID, PartMaterial, ECONo);
        }

        public tblECO GetLastest_ECO_BLL()
        {
            return ecoDAL.GetLastest_ECO_DAL();
        }

        public bool InsertNewECO_BLL(int ECONo, int IDProposal, string NameProposal, int TypeID, string     ECOContent)
        {
            // Trường hợp 1 : Make New Part
            return ecoDAL.InsertNewECO_DAL(ECONo, IDProposal, NameProposal, TypeID, ECOContent);
        }

        public DataTable GetListNearECO_BLL(int NoRow)
        {
            return (ecoDAL.GetListNearECO_DAL(NoRow));
        }

        public DataTable GettblPartStage_BLL()
        {
            return ecoDAL.GettblPartStage_DAL();
        }

        /// <summary>
        /// Tạo số ECO Mới
        /// </summary>
        /// <returns></returns>
        public int LoadECONo()
        {
            string today = DateTime.Now.Date.ToString("yy/MM/dd");

            tblECO _ECOdata = GetLastest_ECO_BLL();
            int NewECONo;
            if (_ECOdata == null)
            {
                NewECONo = Convert.ToInt32(today.Replace("/", "") + "001");
            }
            else
            {
                NewECONo = _ECOdata.ECONo + 1;
            }

            return NewECONo;
        }

        public bool CopyFile_to_ECOTEMP_BLL(string ECONo, DataGridView dgvFileUpdate)
        {
            // Lấy đường đẫn thư mục :
            bool status;
            bool isFolderCreated = false; // Biến kiểm tra xem thư mục có được tạo hay không

            string FolderECONopath = Properties.Settings.Default.LinkDataPart;
            FolderECONopath = FolderECONopath + "\\ECOTEMP\\" + ECONo + "\\";

            // Tạo thư mục nếu chưa tồn tại
            if (Directory.Exists(FolderECONopath) == false)
            {
                Directory.CreateDirectory(FolderECONopath);
                isFolderCreated = true; // Đánh dấu đã tạo thư mục
            }
            // Duyệt qua các dòng trong DataGridView
            try
            {
                foreach (DataGridViewRow row in dgvFileUpdate.Rows)
                {
                    if (row.Cells[3].Value != null) // FullName nằm ở cột số 3
                    {
                        string originalFilePath = row.Cells[3].Value.ToString();
                        if (File.Exists(originalFilePath))
                        {
                            string fileName_withExtension = Path.GetFileName(originalFilePath);
                            string newFilePath = Path.Combine(FolderECONopath, fileName_withExtension);
                            //MessageBox.Show("Tên đường dẫn file mới : " + newFilePath);

                            // Copy file với phần mở rộng mới
                            File.Copy(originalFilePath, newFilePath, true);
                        }
                    }
                }
                status = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sao chép file: " + ex.Message);
                // Nếu xảy ra lỗi, kiểm tra và xóa thư mục vừa tạo
                if (isFolderCreated && Directory.Exists(FolderECONopath))
                {
                    try
                    {
                        Directory.Delete(FolderECONopath, true); // Xóa thư mục và tất cả file bên trong
                    }
                    catch (Exception deleteEx)
                    {
                        MessageBox.Show("Error when delete folder " + deleteEx.Message,  "", MessageBoxButtons.OK, MessageBoxIcon.Error);  // Lỗi khi xóa thư mục: 
                    }
                }
                status = false;
            }
            return status;
        }

        public bool DeleteECO_BLL(int ECONo)
        {
            return ecoDAL.DeleteECO_DAL(ECONo);
        }

        public bool Update_tblECO_Approved_BLL(int IDApproved, string NameApproved, int ECONo)
        {
            return ecoDAL.Update_tblECO_Approved_DAL(IDApproved, NameApproved, ECONo);
        }
        public bool Update_tblECO_Approved_BLL(int IDApproved, string NameApproved, int ECONo, string ECOContent)
        {
            return ecoDAL.Update_tblECO_Approved_DAL(IDApproved, NameApproved, ECONo, ECOContent);
        }

        public bool Update_tblECO_Canceled_BLL(int IDApproved, string NameApproved, int ECONo)
        {
            return ecoDAL.Update_tblECO_Canceled_DAL(IDApproved, NameApproved, ECONo);
        }




        public bool CopyFile_to_DataPart(string partcode, string version, int ECONo)
        {
            bool status;
            // -------------------------------------------------
            // ===        Bước 1 : Lấy các đường dẫn
            // -------------------------------------------------
            // Lấy đường dẫn thư mục ECOTEMP :
            string sourceDir = Properties.Settings.Default.LinkDataPart + "\\ECOTEMP\\" + ECONo.ToString() ;
            // Lấy đường dẫn thư mục chứa PartCode
            string[] FolderName = partcode.Split('-');
            // FolderName[0] : XXX : PartFamily
            // FolderName[1] : YYYYY : PartNo
            // -- Tạo Folder  bằng PartCode mới
            string targetDir = Properties.Settings.Default.LinkDataPart + "//" + FolderName[0] + "//" + FolderName[1];

            // Tên file 
            string newBaseName = partcode + "_V" + version;
            string[] files = Directory.GetFiles(sourceDir);

            try
            {
                //int count = 1;
                foreach (string filePath in files)
                {
                    string extension = Path.GetExtension(filePath); // Lấy đuôi file, ví dụ .pdf, .txt, .jpg
                    string newFileName = $"{newBaseName}{extension}";
                    string newFilePath = Path.Combine(targetDir, newFileName);

                    // Nếu có nhiều file, thêm số để tránh trùng tên
                    //if (File.Exists(newFilePath))
                    //{
                    //    newFileName = $"{newBaseName}_{count}{extension}";
                    //    newFilePath = Path.Combine(targetDir, newFileName);
                    //    count++;
                    //}

                    File.Copy(filePath, newFilePath);
                    //Console.WriteLine($"Đã copy: {newFileName}");
                }
                status = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                status = false;
            }


            return status;
        }

        public int lastestVersion(string folderPath, int stage)
        {
            // Lấy tất cả các file trong thư mục
            string[] files = Directory.GetFiles(folderPath);
            // Tạo danh sách để lưu trữ các số phiên bản
            int maxversion = 0;
            int i;

            // Duyệt qua từng file và lấy số phiên bản từ tên file
            foreach (string file in files)
            {
                // Lấy tên file mà không có đường dẫn
                string fileName = Path.GetFileNameWithoutExtension(file);
                if (getstage(fileName) == stage)
                {
                    // Chỉ kiểm tra với stage hiện tại
                    i = getversion(fileName);
                    if (i > maxversion)
                    {
                        maxversion = i;
                    }
                }
            }

            return maxversion + 1;
        }

        public int getversion(string filename)
        {
            string[] parts = filename.Split('_');
            string version = parts[1]; // "V1.10"

            string[] versionParts = version.Split('.');
            return Convert.ToInt16(versionParts[1]);
        }

        public int getstage(string filename)
        {
            // Ví dụ: CLP-00001_V1.0
            string[] parts = filename.Trim().Split('_');
            if (parts.Length < 2)
                throw new FormatException("Tên file không đúng định dạng. Cần có dấu gạch dưới (_) và phần version.");

            string version = parts[1]; // "V1.0"
            string[] versionParts = version.Split('.');
            if (versionParts.Length < 1 || !versionParts[0].StartsWith("V"))
                throw new FormatException("Version is not in correct format. Must start with V, for example: V1.0");

            return Convert.ToInt16(versionParts[0].Substring(1)); // Lấy số sau chữ V
        }

        public bool Delete_Folder_ECO (int ECONo)
        {
            // Xóa thư mục ECONo
            bool status = false;
            string FolderECONopath = Properties.Settings.Default.LinkDataPart;
            FolderECONopath = FolderECONopath + "\\ECOTEMP\\" + ECONo.ToString() ;

            if (Directory.Exists(FolderECONopath))
            {
                try
                {
                    RemoveFolderAttributes(FolderECONopath);
                    Directory.Delete(FolderECONopath, true); // Xóa thư mục và tất cả file bên trong
                    //MessageBox.Show("Cập nhật thành công");
                    status = true;
                }
                catch (Exception deleteEx)
                {
                    MessageBox.Show("Error when delete folder " + deleteEx.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    status = false;
                }
            }
            return status;
        }

        private void RemoveFolderAttributes(string path)
        {
            DirectoryInfo dir = new DirectoryInfo(path);
            dir.Attributes = FileAttributes.Normal;

            foreach (FileInfo file in dir.GetFiles("*", SearchOption.AllDirectories))
            {
                file.Attributes = FileAttributes.Normal;
            }
        }


        public bool CopyFile_to_DataPart_If_UpStage(string partcode, int newstageID, int oldstageID)
        {
            bool status= false;
            // -------------------------------------------------
            // ===        Bước 1 : Lấy các đường dẫn
            // ------------------------------------------------
            string[] FolderName = partcode.Split('-');
            // FolderName[0] : XXX : PartFamily
            // FolderName[1] : YYYYY : PartNo
            // -- Tạo Folder  bằng PartCode mới
            string folderPath = Properties.Settings.Default.LinkDataPart + "//" + FolderName[0] + "//" + FolderName[1];
            string[] files = Directory.GetFiles(folderPath);
            int lastestversion = lastestVersion(folderPath, oldstageID) - 1;
            // Tạo tên file mới
            string newBaseName = partcode + "_V" + newstageID.ToString() + ".0";

            

            try
            {
                
                foreach (string filePath in files)
                {
                    string extension = Path.GetExtension(filePath); // Lấy đuôi file, ví dụ .pdf, .txt, .jpg
                    string filename = Path.GetFileNameWithoutExtension(filePath); // Lấy tên file không có đuôi
                    int ver = getversion(filename);
                    int stage = getstage(filename);
                    if(stage == oldstageID && ver == lastestversion)
                    {
                        // Nếu trùng hợp hết thì sẽ lấy file  và copy với tên mới
                        string newFileName = Path.Combine(folderPath, newBaseName + extension);
                        File.Copy(filePath, newFileName, true);
                    }
                   
                }
                status = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                status = false;
            }


            return status;
            
            
        }

        public bool InsertNewRelation_in_tblRelationTemp_BLL (string ParentCode, string ChildCode, int Quantity)
        {
            return ecoDAL.InsertNewRelation_in_tblRelationTemp_DAL(ParentCode, ChildCode, Quantity);
        }

        public bool Delete_tblRelationTemp_BLL(string parentcode, string childcode)
        {
            return ecoDAL.Delete_tblRelationTemp_DAL(parentcode, childcode);
        }

        public bool Write_ECONo_to_tblPart_BLL(string PartCode, string ECONo)
        {
            return ecoDAL.Write_ECONo_to_tblPart_DAL(PartCode, ECONo);
        }

        public DataTable Get_ECO_Information_BLL ( int ECONo)
        {
            return commonInforDAL.Get_ECO_Information_DAL(ECONo);
        }


        public bool GetAllFileinFolder_ECOTEMP(string ECONo, DataGridView dgvListFile)
        {
            // Chuyển partcode thành đường dẫn

            //dgvListFile.AutoGenerateColumns = true;

            string DataPath = Properties.Settings.Default.LinkDataPart;
            
            string filepath = DataPath + "\\" + "ECOTEMP" + "\\" + ECONo ;
            try
            {
                // Xóa dữ liệu cũ trong DataGritView
                dgvListFile.Rows.Clear();
                dgvListFile.Columns.Clear();

                dgvListFile.ColumnCount = 4;
                dgvListFile.Columns[0].Name = "Name";
                dgvListFile.Columns[1].Name = "Size";
                dgvListFile.Columns[2].Name = "Type";
                dgvListFile.Columns[3].Name = "Created";
                dgvListFile.Columns[0].Width = 200;
                dgvListFile.Columns[1].Width = 80;
                dgvListFile.Columns[2].Width = 80;
                dgvListFile.Columns[3].Width = 200;

                // Lấy danh sách tất cả các file trong thư mục
                string[] files = Directory.GetFiles(filepath);

                // Duyệt qua danh sách file và thêm vào DataGritView
                foreach (string file in files)
                {
                    FileInfo fileInfor = new FileInfo(file);

                    // Thêm 1 dòng vào DataGritView
                    dgvListFile.Rows.Add(fileInfor.Name, fileInfor.Length / 1024 + "KB", fileInfor.Extension, fileInfor.CreationTime);
                    // Tên - Kích thước file - Đuôi file - Ngày khởi tạo
                }
                return true;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra : " + ex.Message);
                return false;
            }
        }

        public bool GetAllFileinFolder_ECOTEMP(string partcode, DataGridView dgvListFile , string version)
        {
            // Chuyển partcode thành đường dẫn

            //dgvListFile.AutoGenerateColumns = true;

            string DataPath = Properties.Settings.Default.LinkDataPart;
            string[] items = partcode.Split('-');

            string filepath = DataPath + "\\" + items[0] + "\\" + items[1];
            try
            {
                // Xóa dữ liệu cũ trong DataGritView
                dgvListFile.Rows.Clear();
                dgvListFile.Columns.Clear();

                dgvListFile.ColumnCount = 4;
                dgvListFile.Columns[0].Name = "Name";
                dgvListFile.Columns[1].Name = "Size";
                dgvListFile.Columns[2].Name = "Type";
                dgvListFile.Columns[3].Name = "Created";
                dgvListFile.Columns[0].Width = 200;
                dgvListFile.Columns[1].Width = 80;
                dgvListFile.Columns[2].Width = 80;
                dgvListFile.Columns[3].Width = 200;

                // Lấy danh sách tất cả các file trong thư mục
                string[] files = Directory.GetFiles(filepath);
                string ver = "_V" + version;

                // Duyệt qua danh sách file và thêm vào DataGridView
                foreach (string file in files)
                {
                    FileInfo fileInfor = new FileInfo(file);
                    if(file.Contains(ver))
                    {
                        // Thêm 1 dòng vào DataGritView
                        dgvListFile.Rows.Add(fileInfor.Name, fileInfor.Length / 1024 + "KB", fileInfor.Extension, fileInfor.CreationTime);
                        // Tên - Kích thước file - Đuôi file - Ngày khởi tạo
                    }


                }
                return true;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(" Error : " + ex.Message);
                return false;
            }
        }




    }
}