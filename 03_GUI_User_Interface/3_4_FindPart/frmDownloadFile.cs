using Azure.Core;
using PLM_Lynx._01_DAL_Data_Access_Layer;
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

namespace PLM_Lynx._03_GUI_User_Interface._3_4_FindPart
{
    public partial class frmDownloadFile : Form
    {
        public string    fldpart {  get; set; }
        public DataTransfer inputData  {  get; set; }

        private CommonBLL commonbLL = new CommonBLL();

        // Create Data
        public string _partcode { get; set; }

        public frmDownloadFile()
        {
            InitializeComponent();
            
            radioCurrentPart.Checked = true;
            radioNearestDocument.Checked = true;
            

        }

        private void frmDownloadFile_Load(object sender, EventArgs e)
        {
            txtPartCode.Text = inputData._currentPartCode;
            txtPartName.Text = inputData._currentPartName;
            dgvListChild.DataSource = inputData.listchild;
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
                fld.Description = "Chọn 1 thư mục để lưu bản vẽ ";
                fld.ShowNewFolderButton = true; // Cho phép tạo thư mục mới
                fld.RootFolder = Environment.SpecialFolder.Desktop;

                // Hiển thị hộp thoại và xử lý kết quả
                if(fld.ShowDialog() == DialogResult.OK)
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
                MessageBox.Show("Cần chọn Folder Lưu File ");
                btnChooseFolder.Focus();
                return;
            }
            else
            {

                // Download "Only Part" or without children 
                try
                {
                    if (radioCurrentPart.Checked == true)
                    {
                        // Download OnlyPart
                        // Kiểm tra xem có sẽ Download mới nhất hay tất cả
                        if (radioNearestDocument.Checked == true)
                        {
                            //  CopyFileByExtension(string partcode, string DestinationFolder, bool stp, bool dwg, bool pdf, bool jpg, bool prt)
                            commonbLL.CopyFileByExtension(inputData._currentPartCode, inputData._currentPartName, fldpart, ckcStepFile.Checked, ckcDwgFile.Checked, ckcPdfFile.Checked, ckcJpgFile.Checked, ckcPrtFile.Checked);
                            MessageBox.Show("Success Download !!! ", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            commonbLL.CopyFileByExtension(inputData._currentPartCode,inputData._currentPartName, fldpart, ckcStepFile.Checked, ckcDwgFile.Checked, ckcPdfFile.Checked, ckcJpgFile.Checked, ckcPrtFile.Checked, ckcDV.Checked, ckcPV.Checked, ckcMP.Checked);
                            MessageBox.Show("Success Download !!! ", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }



                    }

                    else
                    {
                        // Download All   ( contains Child Part )
                        if (radioNearestDocument.Checked == true)
                        {
                            //  CopyFileByExtension(string partcode, string DestinationFolder, bool stp, bool dwg, bool pdf, bool jpg, bool prt)
                            commonbLL.CopyFileByExtension(inputData._currentPartCode, inputData._currentPartName, fldpart, ckcStepFile.Checked, ckcDwgFile.Checked, ckcPdfFile.Checked, ckcJpgFile.Checked, ckcPrtFile.Checked);
                            // Download Child Part
                            if(inputData.listchild.Rows.Count >0) 
                            {
                                foreach (DataRow dr in inputData.listchild.Rows)
                                {
                                    string childcode = dr[1].ToString();
                                    string childname = dr[2].ToString();
                                    commonbLL.CopyFileByExtension(childcode, childname, fldpart, ckcStepFile.Checked, ckcDwgFile.Checked, ckcPdfFile.Checked, ckcJpgFile.Checked, ckcPrtFile.Checked);

                                }
                                MessageBox.Show("Success Download !!! ", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            } 
                                
                            
                        }
                        else
                        {

                            // Download Part
                            commonbLL.CopyFileByExtension(inputData._currentPartCode, inputData._currentPartName, fldpart, ckcStepFile.Checked, ckcDwgFile.Checked, ckcPdfFile.Checked, ckcJpgFile.Checked, ckcPrtFile.Checked, ckcDV.Checked, ckcPV.Checked, ckcMP.Checked);

                            if (inputData.listchild.Rows.Count > 0)
                            {
                                foreach (DataRow dr in inputData.listchild.Rows)
                                {
                                    string childcode = dr[1].ToString();
                                    string childname = dr[2].ToString();
                                    commonbLL.CopyFileByExtension(childcode,childname, fldpart, ckcStepFile.Checked, ckcDwgFile.Checked, ckcPdfFile.Checked, ckcJpgFile.Checked, ckcPrtFile.Checked, ckcDV.Checked, ckcPV.Checked, ckcMP.Checked);

                                }
                                MessageBox.Show("Success Download !!! ", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }

                        }

                    }


                }
                catch (Exception ex) { MessageBox.Show(ex.Message); };
            }
        }
    }
}
