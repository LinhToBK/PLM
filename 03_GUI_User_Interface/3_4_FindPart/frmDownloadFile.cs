using Azure.Core;
using PLM_Lynx._01_DAL_Data_Access_Layer;
using PLM_Lynx._02_BLL_Bussiness_Logic_Layer;
using PLM_Lynx._03_GUI_User_Interface._3_3_ECO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Resources;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PLM_Lynx._03_GUI_User_Interface._3_4_FindPart
{
    public partial class frmDownloadFile : Form
    {
        public string fldpart { get; set; }
        public DataTransfer inputData { get; set; }

        private CommonBLL commonbLL = new CommonBLL();

        // Create Data
        public string partcode { get; set; }

        public int partstage { get; set; }
        public string partname { get; set; }

        private List<string> extensionList = new List<string>();

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

            rm = new ResourceManager("PLM_Lynx._03_GUI_User_Interface._3_4_FindPart.Lang.Lang_DownloadFile", typeof(frmDownloadFile).Assembly);
            // Hiển thị ngôn ngữ lên các điều khiển trong form
            this.Text = rm.GetString("i.form");
            groupBoxinfor.Text = rm.GetString("lb1");
            labelPartCode.Text = rm.GetString("lb2");
            labelPartName.Text = rm.GetString("lb3");
            labelCurrentVersion.Text = rm.GetString("lb4");
            groupBoxListChildPart.Text = rm.GetString("lb5");
            groupBoxTypeFile.Text = rm.GetString("lb6");
            groupBoxOnlyPartChild.Text = rm.GetString("lb7");
            groupBoxLastestVersion.Text = rm.GetString("lb8");
            groupBoxDownload.Text = rm.GetString("lb9");
            radioCurrentPart.Text = rm.GetString("lb10");
            radioChildren.Text = rm.GetString("lb11");
            radioNearestDocument.Text = rm.GetString("lb12");
            radioAllDocument.Text = rm.GetString("lb13");
            labelSaveFolder.Text = rm.GetString("lb14");
            btnDownLoad.Text = rm.GetString("lb9");




            Properties.Settings.Default.Language = lang;
            Properties.Settings.Default.Save();
        }

        // =========== Language =========================



        public frmDownloadFile()
        {
            InitializeComponent();
            LoadLanguage();

            radioCurrentPart.Checked = true;
            radioNearestDocument.Checked = true;
        }

        private void frmDownloadFile_Load(object sender, EventArgs e)
        {
            txtPartCode.Text = inputData._currentPartCode;
            txtPartName.Text = inputData._currentPartName;
            dgvListChild.DataSource = inputData.listchild;
            partcode = inputData._currentPartCode;
            partname = inputData._currentPartName;
            partstage = inputData._currentPartStageID;
            txtPartVersion.Text = commonbLL.GetLastestVersion(partcode);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnChooseFolder_Click(object sender, EventArgs e)
        {
            // Mở 1 hộp thoại lưu folder
            using (FolderBrowserDialog fld = new FolderBrowserDialog())
            {
                // Tùy chỉnh hộp thoại
                fld.Description = "Choose folder to save : ";
                fld.ShowNewFolderButton = true; // Cho phép tạo thư mục mới
                fld.RootFolder = Environment.SpecialFolder.Desktop;

                // Hiển thị hộp thoại và xử lý kết quả
                if (fld.ShowDialog() == DialogResult.OK)
                {
                    fldpart = fld.SelectedPath;
                }
                txtFolderDownload.Text = fldpart;
            }
        }

        private void btnDownLoad_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(txtFolderDownload.Text) == false)
            {
                MessageBox.Show(rm.GetString("t1"));  // Cần chọn Folder Lưu File 
                btnChooseFolder.Focus();
                return;
            }
            else
            {
                // Lấy danh sách extension
                Getextension();
                if (extensionList.Count == 0)
                {
                    MessageBox.Show(rm.GetString("t2"));     // Cần chọn ít nhất 1 định dạng file để tải về
                    return;
                }

                // Download "Only Part" or with children
                try
                {
                    if (radioCurrentPart.Checked == true)
                    {
                        // Download OnlyPart
                        if (radioNearestDocument.Checked == true)
                        {
                            // Case 1 : Download "Only Part" and Lastest Version
                            if (DownloadCase1() == true)
                            {
                                MessageBox.Show("Success Download !!! ", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Download Fail !!! ", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            // Case 2 : Download "Only Part" and All Version
                            if (DownloadCase2() == true)
                            {
                                MessageBox.Show("Success Download !!! ", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Download Fail !!! ", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    else
                    {
                        // Download Contains Child Part
                        if (radioNearestDocument.Checked == true)
                        {
                            // Case 3 : Download "With Child Part" and Lastest Version
                            if (DownloadCase3() == true)
                            {
                                MessageBox.Show("Success Download !!! ", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Download Fail !!! ", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            // Case 4 : Download "With Child Part" and All Version
                            if (DownloadCase4() == true)
                            {
                                MessageBox.Show("Success Download !!! ", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Download Fail !!! ", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
                ;
            }
        }

        /// <summary>
        /// Lấy danh sách extension
        /// </summary>
        private void Getextension()
        {
            // Xóa list trước khi thêm mới
            extensionList.Clear();

            if (ckcStepFile.Checked)
            {
                extensionList.Add(".step");
                extensionList.Add(".stp");
            }
            if (ckcDwgFile.Checked)
            {
                extensionList.Add(".dwg");
                extensionList.Add(".dxf");
            }
            if (ckcJpgFile.Checked)
            {
                extensionList.Add(".jpg");
            }
            if (ckcPdfFile.Checked)
            {
                extensionList.Add(".pdf");
            }
            if (ckcPrtFile.Checked)
            {
                extensionList.Add(".prt");
            }
        }

        // Case 1 :Download "Only Part" and Lastest Version
        private bool DownloadCase1()
        {
           

            if (commonbLL.CopyFileByExtension_LastestVersion(partcode, partname, fldpart, extensionList) == true)
            {
                
                return true;
            }
            else
            {
                
                return false;
            }
        }

        // Case 2 : Download "Only Part" and All Version
        private bool DownloadCase2()
        {
            
            if (commonbLL.CopyFileByExtension(partcode, partname, fldpart, extensionList) == true)
            {
                
                return true;
            }
            else
            {
               
                return false;
            }
        }

        // Case 3 : Download "Without Child Part" and Lastest Version
        private bool DownloadCase3()
        {
            bool istatus = false;
            if (DownloadCase1() == false) istatus = false;

            // Download Child Part
            if (inputData.listchild.Rows.Count > 0)
            {
                try
                {
                    foreach (DataRow dr in inputData.listchild.Rows)
                    {
                        string childcode = dr[1].ToString();
                        string childname = dr[2].ToString();
                        int dem = 0;

                        if (commonbLL.CopyFileByExtension_LastestVersion(childcode, childname, fldpart, extensionList) == true)
                        {
                            dem = dem + 1;
                        }
                        
                        if(dem == 0)
                        {
                            istatus = false;
                        }
                        else
                        {
                            istatus = true;
                        }
                    }
                    istatus = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    istatus = false;
                }
            }
            return istatus;
        }

        // Case 4 : Download "Without Child Part" and All Version
        private bool DownloadCase4()
        {
            bool istatus = false;
            if (DownloadCase2() == false) istatus = false;

            if (inputData.listchild.Rows.Count > 0)
            {
                try
                {
                    foreach (DataRow dr in inputData.listchild.Rows)
                    {
                        string childcode = dr[1].ToString();
                        string childname = dr[2].ToString();
                        
                        commonbLL.CopyFileByExtension(childcode, childname, fldpart, extensionList);
                        
                    }
                    istatus = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    istatus = false;
                }
            }
            return istatus;
        }

        private void ckcAll_CheckedChanged(object sender, EventArgs e)
        {
            if (ckcAll.Checked == true)
            {
                ckcJpgFile.Checked = true;
                ckcPdfFile.Checked = true;
                ckcDwgFile.Checked = true;
                ckcStepFile.Checked = true;
                ckcPrtFile.Checked = true;
            }
            else
            {
                ckcJpgFile.Checked = false;
                ckcPdfFile.Checked = false;
                ckcDwgFile.Checked = false;
                ckcStepFile.Checked = false;
                ckcPrtFile.Checked = false;
            }
           
        }
    }
}