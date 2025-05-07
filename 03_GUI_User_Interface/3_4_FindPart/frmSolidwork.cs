using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;
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
    public partial class frmSolidwork : Form
    {
        /// <summary>
        /// Initialize SolidWorks application
        /// </summary>
        private SldWorks swApp;

        private ModelDoc2 swModel;
        private DrawingDoc swDrawing;

        public frmSolidwork()
        {
            InitializeComponent();
            ConnectToSolidWorks();
        }

        /// <summary>
        /// Connect to SolidWorks application
        /// </summary>
        private void ConnectToSolidWorks()
        {
            try
            {
                swApp = (SldWorks)System.Runtime.InteropServices.Marshal.GetActiveObject("SldWorks.Application");
                swModel = (ModelDoc2)swApp.ActiveDoc;

                if (swModel == null)
                {
                    MessageBox.Show("Bạn cần mở 1 file Solidwork");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi kết nối SolidWorks: " + ex.Message);
                // this.Close();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            string tb = "Bạn có muốn thoát tab xử lý Solidworks không ?";
            string caption = "Thông báo ";
            DialogResult kq = MessageBox.Show(tb, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq == DialogResult.Yes)
            {
                this.Close();
            }
            else
            {
                return;
            }
        }

        /// <summary>
        /// Method : Load các file đang mở vào combobox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmSolidwork_Load(object sender, EventArgs e)
        {
            LoadOpenAssemblyIntoComboBox();
            LoadOpenDrawingsIntoComboBox();
        }
        private void LoadOpenDrawingsIntoComboBox()
        {
            cboListDrawing.Items.Clear();

            if (swApp == null)
            {
                //MessageBox.Show("Không kết nối được với SolidWorks.");
                txtDrawingFileStatus.Text = "Không kết nối được với SolidWorks.";
                btnExportDWG.Enabled = false;
                btnExportPDF.Enabled = false;
                btnChangeNameSheets.Enabled = false;
                return;
            }

            ModelDoc2 doc = (ModelDoc2)swApp.GetFirstDocument();

            while (doc != null)
            {
                if (doc.GetType() == (int)swDocumentTypes_e.swDocDRAWING)
                {
                    swDrawing = (DrawingDoc)doc;
                    string title = doc.GetTitle();
                    string fullPath = doc.GetPathName();

                    if (!string.IsNullOrEmpty(fullPath))
                    {
                        cboListDrawing.Items.Add(new SolidworkFileInfo(title, fullPath));
                    }
                }

                doc = (ModelDoc2)doc.GetNext();
            }

            if (cboListDrawing.Items.Count > 0)
            {
                cboListDrawing.SelectedIndex = 0;
                txtDrawingFileStatus.Text = "Có  " + cboListDrawing.Items.Count.ToString() + " file bản vẽ (.slddrw) đang mở.";
            }
            else
            {
                btnExportDWG.Enabled = false;
                btnExportPDF.Enabled = false;
                btnChangeNameSheets.Enabled = false;
            }
        }

        private void LoadOpenAssemblyIntoComboBox()
        {
            cboListAssemblyFiles.Items.Clear();

            if (swApp == null)
            {
                txtAssemblyFileStatus.Text = "Không kết nối được với Solidwork";
                btnExportJPG.Enabled = false;
                btnExportStep.Enabled = false;
                return;
            }

            ModelDoc2 doc = (ModelDoc2)swApp.GetFirstDocument();

            while (doc != null)
            {
                if (doc.GetType() == (int)swDocumentTypes_e.swDocASSEMBLY)
                {
                    string title = doc.GetTitle();
                    string fullPath = doc.GetPathName();

                    if (!string.IsNullOrEmpty(fullPath))
                    {
                        cboListAssemblyFiles.Items.Add(new SolidworkFileInfo(title, fullPath));
                    }
                }

                doc = (ModelDoc2)doc.GetNext();
            }

            if (cboListAssemblyFiles.Items.Count > 0)
            {
                cboListAssemblyFiles.SelectedIndex = 0;
                txtAssemblyFileStatus.Text = "Có" + cboListAssemblyFiles.Items.Count.ToString() + " file assembly (.sldasm) đang mở.";
            }
            else
            {
                //MessageBox.Show("Không có file bản vẽ (.slddrw) nào đang mở.");
                txtAssemblyFileStatus.Text = "Không có file lắp ráp (.sldasm) nào đang mở.";
                btnExportJPG.Enabled = false;
                btnExportStep.Enabled = false;
            }
        }


        private void btnReload_Click(object sender, EventArgs e)
        {
            this.Hide(); // Ẩn form hiện tại (tuỳ chọn)
            frmSolidwork form1 = new frmSolidwork(); // Tạo một instance mới của Form1
            form1.Show();
            this.Close(); // Đóng form cũ
        }


        /// <summary>
        /// Method : Đổi tên các sheet trong file .slddrw theo tên của model view
        /// </summary>
        private void RenameSheetsByModelName()
        {
            string[] sheetNames = (string[])swDrawing.GetSheetNames();

            foreach (string sheetName in sheetNames)
            {
                //MessageBox.Show("bắt đầu đổi tên : " + sheetName);
                swDrawing.ActivateSheet(sheetName);
                var myDrawingSheet = swDrawing.GetCurrentSheet();

                SolidWorks.Interop.sldworks.View firstView = (SolidWorks.Interop.sldworks.View)swDrawing.GetFirstView();

                if (firstView != null)
                {
                    // View đầu tiên là "Sheet Format" nên cần lấy next
                    SolidWorks.Interop.sldworks.View modelView = (SolidWorks.Interop.sldworks.View)firstView.GetNextView();

                    if (modelView != null)
                    {
                        string modelPath = modelView.GetReferencedModelName();

                        if (!string.IsNullOrEmpty(modelPath))
                        {
                            string fileName = System.IO.Path.GetFileNameWithoutExtension(modelPath);
                            string newSheetName = fileName;

                            // Tránh trùng tên
                            if (Array.Exists(sheetNames, name => name.Equals(newSheetName, StringComparison.OrdinalIgnoreCase)))
                                newSheetName += "_copy";

                            //swDrawing.RenameSheet(sheetName, newSheetName);
                            myDrawingSheet.SetName(newSheetName);
                        }
                    }
                }
            }

            MessageBox.Show("Đã đổi tên các sheet thành công.");
        }

        private void btnChangeNameSheets_Click(object sender, EventArgs e)
        {
            RenameSheetsByModelName();
        }

        /// <summary>
        /// Method : Xuất các sheet trong file .slddrw ra định dạng DWG
        /// </summary>
        /// <param name="drawingPath"></param>
        /// <param name="folderPath"></param>
        private void ExportSheetsToDWG(string drawingPath, string folderPath)
        {
            ModelDoc2 swModel = null;

            ModelDoc2 doc = (ModelDoc2)swApp.GetFirstDocument();
            while (doc != null)
            {
                if (doc.GetPathName().Equals(drawingPath, StringComparison.OrdinalIgnoreCase))
                {
                    swModel = doc;
                    break;
                }
                doc = (ModelDoc2)doc.GetNext();
            }

            if (swModel == null)
            {
                MessageBox.Show("Không tìm thấy file trong các tài liệu đang mở.");
                return;
            }

            DrawingDoc swDrawing = (DrawingDoc)swModel;
            string[] sheetNames = (string[])swDrawing.GetSheetNames();
            // string folderPath = Path.GetDirectoryName(drawingPath);
            string drawingName = Path.GetFileNameWithoutExtension(drawingPath);
            ModelDocExtension swExt = swModel.Extension;

            foreach (string sheetName in sheetNames)
            {
                swDrawing.ActivateSheet(sheetName);

                string exportPath = Path.Combine(folderPath, $"{sheetName}.dwg");

                int saveOpts = (int)swSaveAsOptions_e.swSaveAsOptions_Silent |
                               (int)swSaveAsOptions_e.swSaveAsOptions_Copy |
                               (int)swSaveAsOptions_e.swSaveAsOptions_UpdateInactiveViews;

                bool status = swExt.SaveAs(
                    exportPath,
                    (int)swSaveAsVersion_e.swSaveAsCurrentVersion,
                    saveOpts,
                    null, ref saveOpts, ref saveOpts);

                if (!status)
                    MessageBox.Show($"❌ Không thể export sheet: {sheetName}");
            }

            MessageBox.Show("✅ Export DWG hoàn tất.");
        }

        private void btnExportDWG_Click(object sender, EventArgs e)
        {
            //ExportSheetsToDWG();
            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                dialog.Description = "Chọn thư mục để lưu file";
                dialog.ShowNewFolderButton = true;

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedPath = dialog.SelectedPath;
                    if (cboListDrawing.SelectedItem == null)
                    {
                        MessageBox.Show("Vui lòng chọn một file bản vẽ.");
                        return;
                    }

                    SolidworkFileInfo selectedDrawing = (SolidworkFileInfo)cboListDrawing.SelectedItem;
                    string filePath = selectedDrawing.FullPath;
                    ExportSheetsToDWG(filePath, selectedPath);
                }
            }
        }



        /// <summary>
        /// Method : Xuất các sheet trong file .slddrw ra định dạng PDF
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExportPDF_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                dialog.Description = "Chọn thư mục để lưu file PDF";
                dialog.ShowNewFolderButton = true;

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedPath = dialog.SelectedPath;
                    if (cboListDrawing.SelectedItem == null)
                    {
                        MessageBox.Show("Vui lòng chọn một file drawing");

                        return;
                    }

                    SolidworkFileInfo selectedDrawing = (SolidworkFileInfo)cboListDrawing.SelectedItem;
                    string filePath = selectedDrawing.FullPath;
                    ExportSheetsToPDF(filePath, selectedPath);
                }
            }
        }
        private void ExportSheetsToPDF(string drawingPath, string folderPath)
        {
            ModelDoc2 swModel = null;

            // Tìm file đang mở với đường dẫn tương ứng
            ModelDoc2 doc = (ModelDoc2)swApp.GetFirstDocument();
            while (doc != null)
            {
                if (doc.GetPathName().Equals(drawingPath, StringComparison.OrdinalIgnoreCase))
                {
                    swModel = doc;
                    break;
                }
                doc = (ModelDoc2)doc.GetNext();
            }

            if (swModel == null)
            {
                MessageBox.Show("Không tìm thấy file trong các tài liệu đang mở.");
                return;
            }

            DrawingDoc swDrawing = (DrawingDoc)swModel;
            string[] sheetNames = (string[])swDrawing.GetSheetNames();
            // string folderPath = Path.GetDirectoryName(drawingPath);
            string drawingName = Path.GetFileNameWithoutExtension(drawingPath);
            ModelDocExtension swExt = swModel.Extension;
            //swExportPDFData = (ExportPdfData)swApp.GetExportFileData((int)swExportDataFileType_e.swExportPdfData);

            IExportPdfData exportPdfData = (IExportPdfData)swApp.GetExportFileData((int)swExportDataFileType_e.swExportPdfData);

            foreach (string sheetName in sheetNames)
            {
                swDrawing.ActivateSheet(sheetName);
                var myDrawingSheet = swDrawing.GetCurrentSheet();
                var drawingDoc = (IDrawingDoc)swModel;

                string exportPath = Path.Combine(folderPath, $"{sheetName}.pdf");

                int saveOpts = (int)swSaveAsOptions_e.swSaveAsOptions_Silent |
                               (int)swSaveAsOptions_e.swSaveAsOptions_Copy |
                               (int)swSaveAsOptions_e.swSaveAsOptions_UpdateInactiveViews;

                exportPdfData.SetSheets((int)swExportDataSheetsToExport_e.swExportData_ExportCurrentSheet, myDrawingSheet);
                exportPdfData.ViewPdfAfterSaving = false;

                // Save as sang PDF
                bool status = swExt.SaveAs(
                    exportPath,
                    (int)swSaveAsVersion_e.swSaveAsCurrentVersion,
                    (int)swSaveAsOptions_e.swSaveAsOptions_Silent,
                    exportPdfData,
                    ref saveOpts, ref saveOpts);

                if (!status)
                    MessageBox.Show($"❌ Không thể export sheet: {sheetName}");
            }

            MessageBox.Show("✅ Export PDF hoàn tất.");
        }


        /// <summary>
        /// METHOD : Xuất file  ảnh JPG của từng Part từ file assembly
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExportJPG_Click(object sender, EventArgs e)
        {
            if (cboListAssemblyFiles.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn một file Assembly đang mở.");
                return;
            }

            SolidworkFileInfo selectedAssembly = (SolidworkFileInfo)cboListAssemblyFiles.SelectedItem;
            string selectedTitle = selectedAssembly.FullPath;
            ModelDoc2 assemblyDoc = swApp.ActivateDoc2(selectedTitle, false, 0);

            if (assemblyDoc == null)
            {
                MessageBox.Show("Không thể tìm thấy file Assembly.");
                return;
            }

            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                dialog.Description = "Chọn thư mục để lưu file ảnh";
                dialog.ShowNewFolderButton = true;

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedPath = dialog.SelectedPath;
                    string fileName = Path.GetFileNameWithoutExtension(selectedTitle);
                    string filepath = Path.Combine(selectedPath, fileName + ".jpg");
                    if (!File.Exists(filepath))
                    {
                        // Xuất assembly chính
                        // int errors = 0, warnings = 0;
                        ModelDoc2 model2 = swApp.OpenDoc6(selectedTitle, GetDocumentType(selectedTitle), (int)swOpenDocOptions_e.swOpenDocOptions_Silent, "", 0, 0);
                        swApp.ActivateDoc2(model2.GetTitle(), false, 0);
                        model2.ShowNamedView2("*Isometric", (int)swStandardViews_e.swIsometricView);
                        model2.ViewZoomtofit2();
                        model2.SaveAs3(filepath, (int)swSaveAsVersion_e.swSaveAsCurrentVersion, (int)swSaveAsOptions_e.swSaveAsOptions_Silent);
                    }

                    // Xuất các component
                    ExportAllComponentsAsJPG((AssemblyDoc)assemblyDoc, selectedPath);
                    // ExportJPG(selectedTitle, selectedPath); // Xuất file JPG từ assembly

                    //// Xuất assembly chính
                    //////string asmPath = assemblyDoc.GetPathName();
                    //////ExportJPG(asmPath, selectedPath);

                    MessageBox.Show("Đã lưu các file ảnh thành công");
                }
            }
        }
        private void ExportAllComponentsAsJPG(AssemblyDoc asmDoc, string saveFolder)
        {
            object[] components = (object[])asmDoc.GetComponents(true);

            HashSet<string> exportedPaths = new HashSet<string>(StringComparer.OrdinalIgnoreCase); // Tránh trùng đường dẫn

            foreach (Component2 comp in components)
            {
                ModelDoc2 compModel = comp.GetModelDoc2();
                string path = compModel.GetPathName();
                ExportJPG(path, saveFolder); // Xuất file JPG
                exportedPaths.Add(compModel.GetPathName());
            }
        }

        private void ExportJPG(string modelPath, string saveFolder)
        {
            int errors = 0, warnings = 0;
            string fileName = Path.GetFileNameWithoutExtension(modelPath);
            string jpgPath = Path.Combine(saveFolder, fileName + ".jpg");

            if (File.Exists(jpgPath))
                return;

            ModelDoc2 model = swApp.OpenDoc6(
                modelPath,
                GetDocumentType(modelPath),
                (int)swOpenDocOptions_e.swOpenDocOptions_Silent,
                "",
                ref errors,
                ref warnings);

            if (model != null)
            {
                // Chia làm 2 trường hợp
                // Nếu là file assembly thì cần chụp ảnh của assembly , sau đó chụp ảnh của từng part
                //MessageBox.Show("Đang xuất file " + fileName);
                if (GetDocumentType(modelPath) == (int)swDocumentTypes_e.swDocASSEMBLY)
                {
                    swApp.ActivateDoc2(model.GetTitle(), false, 0);
                    model.ShowNamedView2("*Isometric", (int)swStandardViews_e.swIsometricView);
                    model.ViewZoomtofit2();
                    model.SaveAs3(jpgPath, (int)swSaveAsVersion_e.swSaveAsCurrentVersion, (int)swSaveAsOptions_e.swSaveAsOptions_Silent);
                    swApp.CloseDoc(model.GetTitle());
                    // Xuất từng part trong assembly
                    AssemblyDoc assemblyDoc = (AssemblyDoc)model;
                    ExportAllComponentsAsJPG(assemblyDoc, saveFolder);
                    //swApp.CloseDoc(model.GetTitle());
                }
                if (GetDocumentType(modelPath) == (int)swDocumentTypes_e.swDocPART)
                {
                    swApp.ActivateDoc2(model.GetTitle(), false, 0);
                    model.ShowNamedView2("*Isometric", (int)swStandardViews_e.swIsometricView);
                    model.ViewZoomtofit2();
                    model.SaveAs3(jpgPath, (int)swSaveAsVersion_e.swSaveAsCurrentVersion, (int)swSaveAsOptions_e.swSaveAsOptions_Silent);
                    swApp.CloseDoc(model.GetTitle());
                }
            }
        }
        private int GetDocumentType(string path)
        {
            string ext = Path.GetExtension(path).ToLower();
            switch (ext)
            {
                case ".sldprt": return (int)swDocumentTypes_e.swDocPART;
                case ".sldasm": return (int)swDocumentTypes_e.swDocASSEMBLY;
                case ".slddrw": return (int)swDocumentTypes_e.swDocDRAWING;
                default: return -1;
            }
        }



        /// <summary>
        /// Method : Xuất file STEP từ file assembly
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExportStep_Click(object sender, EventArgs e)
        {
            if (cboListAssemblyFiles.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn một file Assembly đang mở.");
                return;
            }

            SolidworkFileInfo selectedAssembly = (SolidworkFileInfo)cboListAssemblyFiles.SelectedItem;
            string selectedTitle = selectedAssembly.FullPath;
            ModelDoc2 assemblyDoc = swApp.ActivateDoc2(selectedTitle, false, 0);

            if (assemblyDoc == null)
            {
                MessageBox.Show("Không thể tìm thấy file Assembly.");
                return;
            }

            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                dialog.Description = "Chọn thư mục để lưu file step";
                dialog.ShowNewFolderButton = true;

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedPath = dialog.SelectedPath;
                    string fileName = Path.GetFileNameWithoutExtension(selectedTitle);
                    string filepath = Path.Combine(selectedPath, fileName + ".step");
                    if (!File.Exists(filepath))
                    {
                        // Xuất assembly chính
                        // int errors = 0, warnings = 0;
                        ModelDoc2 model2 = swApp.OpenDoc6(selectedTitle, GetDocumentType(selectedTitle), (int)swOpenDocOptions_e.swOpenDocOptions_Silent, "", 0, 0);
                        swApp.ActivateDoc2(model2.GetTitle(), false, 0);
                        //model2.ShowNamedView2("*Isometric", (int)swStandardViews_e.swIsometricView);
                        //model2.ViewZoomtofit2();
                        model2.SaveAs3(filepath, (int)swSaveAsVersion_e.swSaveAsCurrentVersion, (int)swSaveAsOptions_e.swSaveAsOptions_Silent);
                    }

                    // Xuất các component
                    ExportAllComponentsAsStep((AssemblyDoc)assemblyDoc, selectedPath);


                    MessageBox.Show("Đã lưu các file step thành công");
                }
            }
        }
        private void ExportAllComponentsAsStep(AssemblyDoc asmDoc, string saveFolder)
        {
            object[] components = (object[])asmDoc.GetComponents(true);

            HashSet<string> exportedPaths = new HashSet<string>(StringComparer.OrdinalIgnoreCase); // Tránh trùng đường dẫn

            foreach (Component2 comp in components)
            {
                ModelDoc2 compModel = comp.GetModelDoc2();
                string path = compModel.GetPathName();
                ExportStep(path, saveFolder); // Xuất file Step File
                exportedPaths.Add(compModel.GetPathName());
            }
        }

        private void ExportStep(string modelPath, string saveFolder)
        {
            int errors = 0, warnings = 0;
            string fileName = Path.GetFileNameWithoutExtension(modelPath);
            string StepPath = Path.Combine(saveFolder, fileName + ".step");

            if (File.Exists(StepPath))
                return;

            ModelDoc2 model = swApp.OpenDoc6(
                modelPath,
                GetDocumentType(modelPath),
                (int)swOpenDocOptions_e.swOpenDocOptions_Silent,
                "",
                ref errors,
                ref warnings);

            if (model != null)
            {
                // Chia làm 2 trường hợp
                // Nếu là file assembly thì cần chụp ảnh của assembly , sau đó chụp ảnh của từng part
                //MessageBox.Show("Đang xuất file " + fileName);
                if (GetDocumentType(modelPath) == (int)swDocumentTypes_e.swDocASSEMBLY)
                {
                    swApp.ActivateDoc2(model.GetTitle(), false, 0);
                    //model.ShowNamedView2("*Isometric", (int)swStandardViews_e.swIsometricView);
                    //model.ViewZoomtofit2();
                    model.SaveAs3(StepPath, (int)swSaveAsVersion_e.swSaveAsCurrentVersion, (int)swSaveAsOptions_e.swSaveAsOptions_Silent);
                    swApp.CloseDoc(model.GetTitle());
                    // Xuất từng part trong assembly
                    AssemblyDoc assemblyDoc = (AssemblyDoc)model;
                    ExportAllComponentsAsStep(assemblyDoc, saveFolder);
                    //swApp.CloseDoc(model.GetTitle());
                }
                if (GetDocumentType(modelPath) == (int)swDocumentTypes_e.swDocPART)
                {
                    swApp.ActivateDoc2(model.GetTitle(), false, 0);
                    //model.ShowNamedView2("*Isometric", (int)swStandardViews_e.swIsometricView);
                    //model.ViewZoomtofit2();
                    model.SaveAs3(StepPath, (int)swSaveAsVersion_e.swSaveAsCurrentVersion, (int)swSaveAsOptions_e.swSaveAsOptions_Silent);
                    swApp.CloseDoc(model.GetTitle());
                }
            }
        }

        private void btnDownloadVBA_Click(object sender, EventArgs e)
        {
            string tb = "Bạn có muốn tải file VBA không ?";
            string caption = "Thông báo ";
            DialogResult kq = MessageBox.Show(tb, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq == DialogResult.Yes)
            {
                // Lấy đường dẫn 04_CommonDoc
                string commonpath = System.Environment.CurrentDirectory;
                string frmpath =  commonpath + @"\04_CommonDoc\BOM_to_Partlist.frm";
                string frxpath = commonpath + @"\04_CommonDoc\BOM_to_Partlist.frx";

                using (FolderBrowserDialog dialog = new FolderBrowserDialog())
                {
                    dialog.Description = "Chọn thư mục để lưu file VBA";
                    dialog.ShowNewFolderButton = true;

                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        // Copy file BOM_to_Partlist.frm và BOM_to_Partlist.frx vào thư mục đã chọn
                        string selectedPath = dialog.SelectedPath;
                        string destinationPath = Path.Combine(selectedPath, "BOM_to_Partlist.frm");
                        string destinationPath2 = Path.Combine(selectedPath, "BOM_to_Partlist.frx");
                        File.Copy(frmpath, destinationPath, true);
                        File.Copy(frxpath, destinationPath2, true);
                        MessageBox.Show("Đã tải file VBA thành công");
                    }
                }



            }

        }
    }
}