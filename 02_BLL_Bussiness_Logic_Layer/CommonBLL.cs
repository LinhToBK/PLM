using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.CompilerServices.RuntimeHelpers;
using System.Drawing;
using System.IO;
using System.Diagnostics;
using System.Xml.Linq;
using System.Data;
using PLM_Lynx._01_DAL_Data_Access_Layer;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Core;
using System.Security.Cryptography;
using PLM_Lynx._03_GUI_User_Interface._3_6_Help;
using System.Globalization;
using System.Resources;
using System.Threading;

namespace PLM_Lynx._02_BLL_Bussiness_Logic_Layer
{
    public class CommonBLL
    {
        private FindPartDAL PartDAL = new FindPartDAL();
        private CommonInforDAL _commoninforDAL = new CommonInforDAL();
        private ECO_BLL _eco_BLL = new ECO_BLL();

        // =========== Language =========================
        // private ResourceManager rm  = new ResourceManager("PLM_Lynx._02_BLL_Bussiness_Logic_Layer.Lang_BLL", typeof(CommonBLL).Assembly);

        // =========== Language =========================

        /// <summary>
        /// 01. UPLOAD - Tải ảnh của 1 PartCode lên trên PictureBox
        /// </summary>
        /// <param name="partCode"></param>
        /// <param name="pictureBox"></param>
        /// <returns></returns>
        public bool UploadImagebyPartCode(string partCode, PictureBox pictureBox)
        {
            // -- Hiển thị ảnh

            // -- Lấy version lớn nhất của ảnh

            //string imagefilepath = Properties.Settings.Default.LinkDataPart;
            //string[] input = partCode.Split('-');
            //string filepath = imagefilepath + "\\" + input[0] + "\\" + input[1];
            //imagefilepath = imagefilepath + "\\" + input[0] + "\\" + input[1] + "\\" + partCode + "_DV-0" + ".jpg";
            bool result = false;

            string imagefilepath = GetFilePath(partCode) + "\\" + GetImagePath_Lastest(partCode);
            try
            {
                // Kiểm tra file có tồn tại
                if (System.IO.File.Exists(imagefilepath))
                {
                    //picPart.Image = Image.FromFile(imagefilepath);
                    pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                    using (System.Drawing.Image newimage = System.Drawing.Image.FromFile(imagefilepath))
                    {
                        result = true;
                        pictureBox.Image = (System.Drawing.Image)newimage.Clone();

                    }
                }
                else
                {
                    
                    pictureBox.Image = null;
                    return false;

                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show( ex.Message, "Error");
                result = false;
            }
            return result;
        }

        private string GetImagePath_Lastest(string partCode)
        {
            // CLP-00001
            string imagefilepath = Properties.Settings.Default.LinkDataPart;
            string[] input = partCode.Split('-');
            string filepath = imagefilepath + "\\" + input[0] + "\\" + input[1];

            string[] files = Directory.GetFiles(filepath,  "*.jpg");
            //double maxversion = 1.0;
            // Nếu chỉ có 1 file thì sao 

            if(files.Length == 0)
            {
                return null;
            };
            if(files.Length == 1)
            {
                //MessageBox.Show("Chỉ có 1 file .jpg");
                return Path.GetFileName(files[0]);
            }
            else
            {
                //MessageBox.Show(files.Length.ToString() + " file .jpg");
                int stage = 1;
                int version = 0;

                // Duyệt qua từng file và lấy số phiên bản từ tên file
                foreach (string file in files)
                {
                    // Lấy tên file mà không có đường dẫn
                    string fileName = Path.GetFileNameWithoutExtension(file);
                    int checkstage = _eco_BLL.getstage(fileName);
                    if (checkstage >= stage)
                    {
                        stage = checkstage;
                        int checkversion = _eco_BLL.getversion(fileName);
                        if (checkversion > version)
                        {
                            version = checkversion;
                        }
                    }
                }

                string result = partCode + "_V" + stage.ToString() + "." + version.ToString() + ".jpg";
                //MessageBox.Show(result);
                return result;
            } 
                

            
        }

        /// <summary>
        /// 02. SHOW - Hiển thị danh sách các file trong 1 folder là PartCode bất kỳ lên DataGridView
        /// </summary>
        /// <param name="filepath"></param>
        public bool GetAllFileinFolder(string partcode, DataGridView dgvListFile)
        {
            // Chuyển partcode thành đường dẫn

            //dgvListFile.AutoGenerateColumns = true;

            string DataPath = Properties.Settings.Default.LinkDataPart;
            string[] input = partcode.Split('-');  // Chia XXX-YYYYY thành 2 phần : XXX và YYYYY
            string filepath = DataPath + "\\" + input[0] + "\\" + input[1];
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
                dgvListFile.Columns[0].HeaderText = "Name";
                dgvListFile.Columns[1].HeaderText = "Size";
                dgvListFile.Columns[2].HeaderText = "Type";
                dgvListFile.Columns[3].HeaderText = "Date modified";

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

        /// <summary>
        /// 03. Hàm Preview 1 file bất kỳ
        /// </summary>
        /// <param name="docfile"></param>
        public void PreviewFile(string docfile)
        {
            if (System.IO.File.Exists(docfile))
            {
                // Kiểm tra xem có đang được mở trong ứng dụng khác hay không
                // Nếu file là .jpg thì sẽ bỏ qua bước check
                try
                {
                    if (Path.GetExtension(docfile).ToLower() == ".pdf")
                    {
                        Process.Start("chrome", $"--kiosk \"{docfile}\"");
                    }

                    // Nếu là file .dwg hoặc dxf thì mở bằng phần mềm DWG True View
                    if (Path.GetExtension(docfile).ToLower() == ".dwg" || Path.GetExtension(docfile).ToLower() == ".dxf")
                    {
                        try
                        {
                            string dwgTrueViewPath = Properties.Settings.Default.eDrawingView;
                            // "C:\Program Files\Autodesk\DWG TrueView 2022 - English\dwgviewr.exe"
                            try
                            {
                                // Kiểm tra nếu DWG TrueView đã chạy
                                var runningProcesses = Process.GetProcessesByName(dwgTrueViewPath);

                                if (runningProcesses.Any())
                                {
                                    // Ứng dụng đã chạy, mở file mới
                                    Process.Start(docfile);
                                }
                                else
                                {
                                    // Ứng dụng chưa chạy, mở ứng dụng với file

                                    Process.Start(dwgTrueViewPath, $"\"{docfile}\"");
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($" Can not open this file : {ex.Message}");
                            }
                        }
                        catch (System.Exception ex)
                        {
                            MessageBox.Show("Error when open autocad file :" + ex.Message, "Error");
                        }

                        //Process.Start("dwgviewr.exe", $"\"{docfile}\"");
                    }

                    // Nếu là file. jpg thì mở bằng phần mềm mặc định
                    if (Path.GetExtension(docfile).ToLower() == ".jpg")
                    {
                        // Mở file bằng phần mềm mặc định
                        Process.Start(new ProcessStartInfo
                        {
                            FileName = docfile,
                            UseShellExecute = true // Sử dụng ứng dụng mặc định của hệ thống
                        });
                    }

                    // Nếu là file.stp hoặc .step thì mở bằng eDrawing Solidwork
                    if (Path.GetExtension(docfile).ToLower() == ".stp" 
                        || Path.GetExtension(docfile).ToLower() == ".step" 
                        || Path.GetExtension(docfile).ToLower() == ".prt"
                        || Path.GetExtension(docfile).ToLower() == ".sldprt"
                        || Path.GetExtension(docfile).ToLower() == ".sldasm"
                        || Path.GetExtension(docfile).ToLower() == ".slddrw")

                    {
                        try
                        {
                            string edrawingpath = Properties.Settings.Default.eDrawingView;

                            try
                            {
                                // Kiểm tra nếu DWG TrueView đã chạy
                                var runningProcesses = Process.GetProcessesByName(edrawingpath);

                                if (runningProcesses.Any())
                                {
                                    // Ứng dụng đã chạy, mở file mới
                                    Process.Start(docfile);
                                }
                                else
                                {
                                    // Ứng dụng chưa chạy, mở ứng dụng với file

                                    Process.Start(edrawingpath, $"\"{docfile}\"");
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"Can not open file : {ex.Message}");
                            }
                        }
                        catch (System.Exception ex)
                        {
                            MessageBox.Show("Error when open file .stp / /step by Edrawing :" + ex.Message);
                        }
                    }
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show("Can not open file :" + ex.Message, "Error");
                }
            }
            else
            {
                MessageBox.Show("Cannot open this file \n maybe the file does not exist. ");
            }
        }

        /// <summary>
        /// Hàm để thông báo là có file đang mở
        /// </summary>
        /// <param name="delaytime"></param>
        public async void popup(int delaytime)
        {
            // Đang mở file 
            Label lbl = new Label
            {
                Text = "Opening File ....",
                AutoSize = true,
                //Font = new Font("Segoe UI", 12),
                //TextAlign = ContentAlignment.MiddleCenter
            };
            Form thongbao = new Form
            {
                //Size = new Size(200, 100),
                StartPosition = FormStartPosition.CenterScreen,
                ControlBox = false,
                TopMost = true
            };
            thongbao.Controls.Add(lbl);
            lbl.Dock = DockStyle.Fill;

            thongbao.Show();
            await Task.Delay(delaytime); // Đợi form hiển thị
            thongbao.Close();

        }

        private bool IsFileLocked(string filePath)
        {
            try
            {
                // Cần đảm bảo khi mở file, chỉ cho phép xem không cho phép sửa
                using (FileStream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    // Nếu tệp mở được ở chế độ đọc/ghi, nó không bị khóa
                }
            }
            catch (IOException)
            {
                // Nếu gặp IOException, tệp đang bị khóa
                return true;
            }

            return false; // Tệp không bị khóa
        }

        /// <summary>
        /// 04. SELECT : Hiển thị 1 bảng datatable tìm kiếm
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public DataTable FindwithworBLL(string word)
        {
            return PartDAL.FindwithwordDAL(word);
        }

        /// <summary>
        /// 05. Lấy đường dẫn của 1 partcode nếu tham số nhập vào là 1 PartCode
        /// </summary>
        /// <param name="partcode"></param>
        /// <returns></returns>
        public string GetFilePath(string partcode)
        {
            string[] foldername = partcode.Split('-');
            string FolderPath = Properties.Settings.Default.LinkDataPart + foldername[0] + "//" + foldername[1];

            if (!Directory.Exists(FolderPath))
            {
                MessageBox.Show("Không tìm thấy thư mục chứa dữ liệu của " + partcode);
                return null;
            }
            else return FolderPath;
        }

        public void FilterDataGridView(DataGridView dgv, string[] filterValues, int STTColumn)
        {
            //if(dgv.Columns.Count == 0) return; // Kiểm tra nếu không có cột nào thì thôi

            //string columnName = dgv.Columns[STTColumn].Name; // Lấy tên cột

            //// Duyệt qua từng hàng trong datagridview
            //foreach (DataGridViewRow rw in dgv.Rows)
            //{
            //    var cellValue = rw.Cells[STTColumn].Value?.ToString(); // Lấy giá trị của cột
            //    if(!string.IsNullOrEmpty(cellValue) && filterValues.Contains(cellValue))
            //    {
            //        rw.Visible = true; // Hiển thị nếu dòng khớp
            //    }
            //    else
            //    {
            //        rw.Visible = false; // Nếu không thì ẩn
            //    }
            //}
            //

            if (dgv.DataSource is DataTable dataTable)
            {
                string columnName = dgv.Columns[STTColumn].Name;

                foreach (DataRow row in dataTable.Rows)
                {
                    var cellValue = row[columnName]?.ToString();
                    if (!string.IsNullOrEmpty(cellValue) && !filterValues.Contains(cellValue))
                    {
                        row["Visible"] = false; // Ẩn dòng nếu không khớp
                    }
                }
            }
            else
            {
                MessageBox.Show("DataSource không phải là DataTable.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Xuất BOM ra file Excel không kèm hình ảnh
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="filePath"></param>
        public void ExportToExcel(DataGridView dgv, string filePath)
        {
            try
            {
                // Tạo ứng dụng Excel
                Excel.Application excelApp = new Excel.Application
                {
                    Visible = true // Ẩn Excel trong khi xử lý
                };

                // Tạo Workbook và Worksheet
                Excel.Workbook workbook = excelApp.Workbooks.Add(Type.Missing);
                Excel.Worksheet worksheet = workbook.Sheets[1];
                worksheet = workbook.ActiveSheet;
                worksheet.Name = "ExportedWithChild";

                // Ghi tiêu đề cột
                for (int i = 1; i <= dgv.Columns.Count; i++)
                {
                    worksheet.Cells[1, i] = dgv.Columns[i - 1].HeaderText;
                }

                // Ghi dữ liệu từ DataGridView
                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    for (int j = 0; j < dgv.Columns.Count; j++)
                    {
                        worksheet.Cells[i + 2, j + 1] = dgv.Rows[i].Cells[j].Value?.ToString();
                    }
                }

                // Lưu file Excel
                workbook.SaveAs(filePath);
                workbook.Close();
                excelApp.Quit();

                MessageBox.Show("Xuất Dữ Liệu Thành Công !", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Xuất BOM ra file Excel kèm hình ảnh
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="filePath"></param>
        public void ExportToExcelWithImages(DataGridView dgv, string filePath)
        {
            try
            {
                // Tạo ứng dụng Excel
                Excel.Application excelApp = new Excel.Application
                {
                    Visible = true   // hiển thị để dễ theo dõi nhỡ có lỗi
                };

                // Tạo Workbook và Worksheet
                Excel.Workbook workbook = excelApp.Workbooks.Add(Type.Missing);
                Excel.Worksheet worksheet = workbook.Sheets[1];
                worksheet = workbook.ActiveSheet;
                worksheet.Name = "ExportedData";

                // Ghi tiêu đề cột
                for (int i = 1; i <= dgv.Columns.Count; i++)
                {
                    worksheet.Cells[1, i] = dgv.Columns[i - 1].HeaderText;
                }

                // Ghi dữ liệu và chèn ảnh (nếu có)
                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    for (int j = 0; j < dgv.Columns.Count; j++)
                    {
                        worksheet.Cells[i + 2, j + 1] = dgv.Rows[i].Cells[j].Value?.ToString();
                    }

                    // Đính kèm ảnh
                    string partcode = dgv.Rows[i].Cells[1].Value.ToString();

                    string imagepart = GetFilePath(partcode) + "\\" + GetImagePath_Lastest(partcode);
                    //MessageBox.Show("PartCode Load : " + partcode);
                    // string imagepart = GetFilePath(partcode) + "/" + partcode + "_DV-0.jpg";
                    // MessageBox.Show("Đường dẫn file" + imagepart);

                    // Xác định ô cần chèn ảnh
                    Excel.Range targetCell = worksheet.Cells[i + 2, 8]; // Ô J10
                    targetCell.RowHeight = 50; // Đặt chiều cao ô
                    targetCell.ColumnWidth = 50; // Đặt chiều rộng ô
                    // Kiểm tra ảnh có tồn tại khay không
                    if (System.IO.File.Exists(imagepart))
                    {
                        // Lấy tọa độ của ô
                        float cellLeft = (float)targetCell.Left;   // Vị trí từ lề trái
                        float cellTop = (float)targetCell.Top;     // Vị trí từ lề trên
                        //float cellWidth = (float)targetCell.Width; // Chiều rộng ô
                        //float cellHeight = (float)targetCell.Height; // Chiều cao ô
                        float cellWidth = 50; // Chiều rộng ô
                        float cellHeight = 50; // Chiều cao ô

                        // Chèn ảnh vào vị trí ô
                        var picture = worksheet.Shapes.AddPicture(
                                imagepart,
                            LinkToFile: MsoTriState.msoFalse,
                            SaveWithDocument: MsoTriState.msoTrue,
                            Left: cellLeft,  // Vị trí lề trái của ô
                            Top: cellTop,    // Vị trí lề trên của ô
                            Width: cellWidth,  // Đặt chiều rộng khớp với ô
                            Height: cellHeight // Đặt chiều cao khớp với ô
                        );
                    }
                    else
                    {
                        targetCell.Value = "Không tìm thấy ảnh";
                    }
                }

                // Align all c
                worksheet.Columns.AutoFit();

                Excel.Range chooserange = worksheet.Range[worksheet.Cells[1][1], worksheet.Cells[dgv.Rows.Count + 2][7]];
                chooserange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                chooserange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                // Lưu file Excel
                workbook.SaveAs(filePath);
                workbook.Close();
                excelApp.Quit();

                MessageBox.Show("Export BOM cùng ảnh  thành công !", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Copy File từ DataBase về máy tính
        /// </summary>
        /// <param name="parcode"></param>
        /// <param name="DestinationFolder"></param>
        /// <param name="stp"></param>
        /// <param name="dwg"></param>
        /// <param name="pdf"></param>
        /// <param name="jpg"></param>
        ///
        // Overloading - Download All File
        public bool CopyFileByExtension(string partcode, string partname, string DestinationFolder, List<string> ListExtension)
        {
            string SourceFolder = GetFilePath(partcode);

            bool result = false;
            string downloadlog = DestinationFolder + "\\" + "Log.txt";
            string content = "";

            try
            {
                string imagefilepath = Properties.Settings.Default.LinkDataPart;
                string[] input = partcode.Split('-');
                string filepath = imagefilepath + "\\" + input[0] + "\\" + input[1];

                string[] files = Directory.GetFiles(filepath);

                int dem = 0;

                foreach (string file in files)
                {
                    string fileName = Path.GetFileNameWithoutExtension(file);
                    string[] namecut = fileName.Split('_');
                    string extension = Path.GetExtension(file);
                    if (ListExtension.Contains(extension) == true)
                    {
                        string destinationPath = Path.Combine(DestinationFolder, partcode + "-" + partname + namecut[1] + extension);
                        File.Copy(file, destinationPath, overwrite: true);
                        dem = dem + 1;
                    }
                }
                if (dem == 0)
                {
                    result = true;    // Nếu không có file nào
                    content = DateTime.Now.ToString() + " || " + partcode + " || " + partname + " || There is no file with the same extension. \r\n";
                    File.AppendAllText(downloadlog, content);
                }
                else
                {
                    result = true; // Nếu có file nào được tải về
                    content = DateTime.Now.ToString() + " || " + partcode + " || " + partname + " || Download successfully. \r\n";
                    File.AppendAllText(downloadlog, content);
                }
            }
            catch (Exception ex)
            {
                // MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}");
                content = "Error: " + ex.Message;
                File.AppendAllText(downloadlog, content);
                result = false;
            }
            return result;
        }

        public string GetLastestVersion(string partcode)
        {
            string imagefilepath = Properties.Settings.Default.LinkDataPart;
            string[] input = partcode.Split('-');
            string filepath = imagefilepath + "\\" + input[0] + "\\" + input[1];

            string[] files = Directory.GetFiles(filepath);

            // Xác định version mới nhất
            int stage = 1;
            int version = 0;


            // Duyệt qua từng file và lấy số phiên bản từ tên file
            foreach (string file in files)
            {
                // Lấy tên file mà không có đường dẫn
                string fileName = Path.GetFileNameWithoutExtension(file);
                int checkstage = _eco_BLL.getstage(fileName);
                if (checkstage >= stage)
                {
                    stage = checkstage;
                    int checkversion = _eco_BLL.getversion(fileName);
                    if (checkversion > version)
                    {
                        version = checkversion;
                    }
                }
            }

            string lastesversion = "_V" + stage.ToString() + "." + version.ToString();
            return lastesversion;
        }

        /// <summary>
        /// Download Version mới nhất
        /// </summary>
        /// <param name="partcode"></param>
        /// <param name="partname"></param>
        /// <param name="DestinationFolder"></param>
        /// <param name="allowedExtensions"></param>
        /// <param name="Version"></param>
        public bool CopyFileByExtension_LastestVersion(string partcode, string partname, string DestinationFolder, List<string> ListExtension)
        {
            string SourceFolder = GetFilePath(partcode);
            bool result = false;
            string downloadlog = DestinationFolder + "\\" + "Log.txt";
            string content = "";

            try
            {
                string imagefilepath = Properties.Settings.Default.LinkDataPart;
                string[] input = partcode.Split('-');
                string filepath = imagefilepath + "\\" + input[0] + "\\" + input[1];

                string[] files = Directory.GetFiles(filepath);
                
                // Xác định version mới nhất
                int stage = 1;
                int version = 0;

                // Duyệt qua từng file và lấy số phiên bản từ tên file
                foreach (string file in files)
                {
                    // Lấy tên file mà không có đường dẫn
                    string fileName = Path.GetFileNameWithoutExtension(file);
                    int checkstage = _eco_BLL.getstage(fileName);
                    if (checkstage >= stage)
                    {
                        stage = checkstage;
                        int checkversion = _eco_BLL.getversion(fileName);
                        if (checkversion > version)
                        {
                            version = checkversion;
                        }
                    }
                }

                string lastesversion = "_V" + stage.ToString() + "." + version.ToString();
                int dem = 0;
                foreach (string file in files)
                {
                    string fileName = Path.GetFileNameWithoutExtension(file);
                    string extension = Path.GetExtension(file);
                    if (ListExtension.Contains(extension) == true)
                    {
                        if (fileName.Contains(partcode + lastesversion) == true)
                        {
                            string destinationPath = Path.Combine(DestinationFolder, partcode + "-" + partname + lastesversion + extension);
                            File.Copy(file, destinationPath, overwrite: true);
                            dem = dem + 1; 
                        }
                    }
                }

                if (dem == 0)
                {
                    result = true;    // Nếu không có file nào
                    content = DateTime.Now.ToString() + " || " + partcode + " || " + partname + " || There is no file with the same extension. \r\n";
                    File.AppendAllText(downloadlog, content);
                }
                else
                {
                    result = true; // Nếu có file nào được tải về
                    content = DateTime.Now.ToString() + " || " + partcode + " || " + partname + " || Download successfully. \r\n";
                    File.AppendAllText(downloadlog, content);
                }
            }
               
        

            catch (Exception ex)
            {
                content = DateTime.Now.ToString() + " || " + partcode + " || " + partname + " || " + ex.Message + " \r\n";
                File.AppendAllText(downloadlog, content);
                result = false;
            }

            return result;
        }

private CommonInforDAL _commonInforDAL = new CommonInforDAL();

public tblCommonInfor GetCommonInforValue(string inforname)
{
    return _commonInforDAL.GetCommonInforValue_DAL(inforname);
}

public DataTable GetAllVersionInfor_BLL()
{
    return _commoninforDAL.GetAllVersionInfor_DAL();
}

public bool UpdateCompanyInfor_BLL(string name, string location, string phone, string tax)
{
    return _commonInforDAL.UpdateCompanyInfor_DAL(name, location, phone, tax);
}

public bool InsertNewVersion_BLL(string ID, string content)
{
    return _commoninforDAL.InsertNewVersion_DAL(ID, content);
}
    } // End Class CommonBLL
} // End NameSpace