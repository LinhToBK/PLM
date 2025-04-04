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

namespace PLM_Lynx._02_BLL_Bussiness_Logic_Layer
{
    public class ECO_BLL
    {
        private FindPartDAL findpartDAL = new FindPartDAL();
        private ECO_DAL ecoDAL = new ECO_DAL();

        public DataTable GetListChildBLL(string ParentCode)
        {
            return ecoDAL.GetListChildDAL(ParentCode);
        }

        public bool CapnhatQuantityBLL(string parentcode, string childcode, int quantity)
        {
            bool check = false;

            if (ecoDAL.CapnhatLogPartDAL(parentcode, childcode, quantity) && ecoDAL.CapnhatQuantityDAL(parentcode, childcode, quantity))
            {
                check = true;
            }

            return check;


        }

        public bool XoaRelationBLL(string parentcode, string childcode)
        {
            bool check = false;
            if (ecoDAL.DeleteLogPartDAL(parentcode, childcode) && ecoDAL.XoaRelationDAL(parentcode, childcode))
            {
                check = true;
            }
            return check;
        }

        public DataTable GetInforPartBLL(string PartCode)
        {
            return ecoDAL.GetInforPartDAL(PartCode);
        }


        public bool UpdateInforPart_BLL(string PartCode, int PartStageID, string PartMaterial, int ECONo)
        {
            return ecoDAL.Update_InforPart_DAL(PartCode, PartStageID, PartMaterial,  ECONo);
        }


        public tblECO GetLastest_ECO_BLL()
        {
            return ecoDAL.GetLastest_ECO_DAL();
        }

        public bool InsertNewECO_BLL(int ECONo, int IDProposal, string NameProposal, int TypeID, string ECOContent)
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
                            MessageBox.Show("Tên đường dẫn file mới : " + newFilePath);

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
                        MessageBox.Show("Lỗi khi xóa thư mục: " + deleteEx.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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


        public bool CopyFile_to_DataPart(string partcode, int ECONo, int PartStageID)
        {
            bool status = false;
            // -------------------------------------------------
            // ===        Bước 1 : Lấy các đường dẫn 
            // -------------------------------------------------
            // Lấy đường dẫn thư mục ECOTEMP :
            string FolderECONopath = Properties.Settings.Default.LinkDataPart + "\\ECOTEMP\\" + ECONo.ToString() + "\\";
            // Lấy đường dẫn thư mục chứa PartCode
            string[] FolderName = partcode.Split('-');
            // FolderName[0] : XXX : PartFamily
            // FolderName[1] : YYYYY : PartNo
            // -- Tạo Folder  bằng PartCode mới
            string Folder_Part_Path = Properties.Settings.Default.LinkDataPart + "//" + FolderName[0] + "//" + FolderName[1];

            // -------------------------------------------------
            // ===        Bước 2 : Lấy Datatable là bảng ghi tất cả file trong thư mục
            // -------------------------------------------------

            //------------------------------------------------------------
            // --- Đổi tên  và save as copy các file vào folder vừa tạo
            //------------------------------------------------------------
            //try
            //{
            //    // Duyệt qua các hàng  trong DataGridView
            //    foreach (DataGridViewRow row in dgvFileAttachment.Rows)
            //    {
            //        if (row.Cells[3].Value != null) //Kiểm tra tại cột FileName
            //        {
            //            // Lấy đường dẫn của file từ cột trong Datagridview
            //            string SourceFilePath = row.Cells[3].Value.ToString();
            //            string FileExtension = row.Cells[2].Value.ToString();

            //            // Tạo tên File mới dựa trên  tên thư mục và phần mở rộng của file
            //            string NewFileName = FolderPath + "//" + newestpartcode + "_V1.0" + FileExtension;
            //            // Tên đường dẫn đến folder + tên partcode mới + . đuôi file
            //            string TargetFilePart = Path.Combine(FolderPath, NewFileName);

            //            // Sao chép file vào thư mục đích với tên mới
            //            File.Copy(SourceFilePath, TargetFilePart, true);
            //            //MessageBox.Show("Đã sao chép thành công ");
            //        }
            //    }
            //}


            return status;
        }


        public float lastestVersion(string folderPath)
        {
            // Lấy tất cả các file trong thư mục
            string[] files = Directory.GetFiles(folderPath);
            // Tạo danh sách để lưu trữ các số phiên bản
            float maxversion = 1;
            
            
            // Duyệt qua từng file và lấy số phiên bản từ tên file
            foreach (string file in files)
            {
                // Lấy tên file mà không có đường dẫn
                string fileName = Path.GetFileNameWithoutExtension(file);
                // BOL-00002_V1.0
                // Tách phần tên file để lấy số phiên bản
                float i = Convert.ToSingle(fileName.Substring(11, fileName.Length - 11));
                if(i > maxversion)
                {
                    maxversion = i;
                }

            }

            return maxversion;
            
        }

    }
}
