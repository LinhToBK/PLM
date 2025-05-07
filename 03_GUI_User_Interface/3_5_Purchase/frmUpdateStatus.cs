using PLM_Lynx._02_BLL_Bussiness_Logic_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Security.AccessControl;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PLM_Lynx._03_GUI_User_Interface._3_5_Purchase
{
    public partial class frmUpdateStatus : Form
    {
        public event EventHandler UpdateStatus;

        private PurchaseBLL purchaseBLL = new PurchaseBLL();

        public string POCode { get; set; }
        public string PODate { get; set; }
        public string POStatus { get; set; }

        private bool isnewfolder { get; set; }
        private string folderPONO { get; set; }

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

            rm = new ResourceManager("PLM_Lynx._03_GUI_User_Interface._3_5_Purchase.Lang.Lang_frmUpdateStatus", typeof(frmUpdateStatus).Assembly);
            // Hiển thị ngôn ngữ lên các điều khiển trong form
            this.Text = rm.GetString("i.form");
            labeNo.Text = rm.GetString("lb1");
            labelDate.Text = rm.GetString("lb2");
            labelCurrentStatus.Text = rm.GetString("lb3");
            labelUpdateStatus.Text = rm.GetString("lb4");
            btnUpdate.Text = rm.GetString("lb5");
            btnCancel.Text = rm.GetString("lb6");
            buttonDownloadFile.Text = rm.GetString("lb7");
            groupBoxAddFile.Text = rm.GetString("lb8");
            groupBoxCurrentListFiel.Text = rm.GetString("lb9");
            btnAddFile.Text = rm.GetString("lb10");
            btnDeleteFile.Text = rm.GetString("lb11");


            Properties.Settings.Default.Language = lang;
            Properties.Settings.Default.Save();
        }

        // =========== Language =========================
        public frmUpdateStatus()
        {
            InitializeComponent();

            // Load ngôn ngữ
            LoadLanguage();
        }

        private void frmUpdateStatus_Load(object sender, EventArgs e)
        {
            txtPOCode.Text = POCode;
            txtPODate.Text = PODate;
            txtPOStatus.Text = POStatus;

            splitContainer1.FixedPanel = FixedPanel.Panel1;
            cboNewStatus.Focus();
            ShowListFile();

            // Tạo cột trong dgvNewFile
            dgvNewFile.Columns.Add("Name", "Name");
            dgvNewFile.Columns.Add("Extension", "Extension");
            dgvNewFile.Columns.Add("Path", "Path");
        }

        private void frmUpdateStatus_FormClosed(object sender, FormClosedEventArgs e)
        {
            UpdateStatus?.Invoke(this, EventArgs.Empty);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem đã chọn giá trị của comboBox chưa ?
            if (cboNewStatus.SelectedItem == null)
            {
                MessageBox.Show(rm.GetString("t1"), rm.GetString("t0"), MessageBoxButtons.OK, MessageBoxIcon.Error);   // Chưa chọn trạng thái mới
                return;
            }


            string NewStatus = cboNewStatus.SelectedItem.ToString();
            // Kiểm tra tính hợp lệ của listnewfile
            if (CheckNewFile() != 0)
            {
                MessageBox.Show(rm.GetString("t2"), rm.GetString("t0"), MessageBoxButtons.OK, MessageBoxIcon.Error);  // Có file đã tồn tại trong folder này
                return;
            }

            if (NewStatus == POStatus)
            {
                MessageBox.Show(rm.GetString("t3"), rm.GetString("t0"), MessageBoxButtons.OK, MessageBoxIcon.Error); // Bạn đang không cập nhật trạng thái mới
                return;
            }
            string tb = "Update :  [ " + POStatus + " ] =>  [ " + NewStatus + " ]";
            DialogResult kq = MessageBox.Show(tb, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq == DialogResult.Yes)
            {
                // Cập nhật status
                if (purchaseBLL.UpdateStatusPO_BLL(POCode, NewStatus) == true && CopyNewFileList() == true)
                {
                    MessageBox.Show(rm.GetString("t4"), rm.GetString("t0"), MessageBoxButtons.OK, MessageBoxIcon.Information);  // Cập nhật Status thành công
                    this.Close();
                }
                else
                {
                    MessageBox.Show(rm.GetString("t5"), rm.GetString("t0"), MessageBoxButtons.OK, MessageBoxIcon.Error); // Phát sinh lỗi. \n Kiểm tra lại thông tin
                }
            }
            else
            {
                return;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Hiển thị danh sách nếu có
        private void ShowListFile()
        {
            if (purchaseBLL.CheckFolderExist(POCode) == true)
            {
                isnewfolder = true; // Có tồn tại folder này rồi.
                txtListFile.Text = "Folder này có tồn tại";

                // Lấy danh sách file trong folder này
                dgvListFile.DataSource = purchaseBLL.GetFileList(POCode);
                dgvListFile.Columns[0].Width = 200;  // Name
                dgvListFile.Columns[1].Width = 30;
                dgvListFile.Columns["Path"].Visible = false;
            }
            else
            {
                // Nếu không tồn tại thì tạo mới
                isnewfolder = false;
                txtListFile.Text = rm.GetString("t6"); // Chưa tồn tại folder PO No
            }
        }

        private void buttonDownloadFile_Click(object sender, EventArgs e)
        {
            // Lấy File từ dgvListFile và tạo tính năng tải xuống
            if (dgvListFile.Rows.Count > 0)
            {
                // Lấy tên file
                string filepath = dgvListFile.CurrentRow.Cells[2].Value.ToString();
                string extension = dgvListFile.CurrentRow.Cells[1].Value.ToString();

                // Mở hộp thoai để save as file
                SaveFileDialog sv = new SaveFileDialog();

                sv.FileName = dgvListFile.CurrentRow.Cells[0].Value.ToString();
                sv.Filter = "All files (*.*)|*.*";
                // saveFileDialog.InitialDirectory = "C:\\Users\\Admin\\Desktop";
                sv.Title = "Save File As";
                sv.RestoreDirectory = true;
                sv.OverwritePrompt = true;
                if (sv.ShowDialog() == DialogResult.OK)
                {
                    // Lưu file vào đường dẫn đã chọn
                    string path = sv.FileName + extension;

                    System.IO.File.Copy(filepath, path, true);
                    MessageBox.Show(rm.GetString("t7"), rm.GetString("t0"), MessageBoxButtons.OK, MessageBoxIcon.Information);   // Download file thành công
                }
                else
                {
                    MessageBox.Show(rm.GetString("t8"), rm.GetString("t0"), MessageBoxButtons.OK, MessageBoxIcon.Error); //Download file không thành công
                }
            }
            else
            {
                MessageBox.Show(rm.GetString("t9"), rm.GetString("t0"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddFile_Click(object sender, EventArgs e)
        {
            // Mở hộp thoại để chọn file và hiển thị lên trên dgvNewFile
            OpenFileDialog FileDialog = new OpenFileDialog();
            FileDialog.RestoreDirectory = true;
            FileDialog.Multiselect = true; // Cho phép chọn nhiều file
            FileDialog.Filter = "All files (*.*)|*.*";

           

            if (FileDialog.ShowDialog() == DialogResult.OK)
            {
                // Lấy danh sách file đã chọn
                string[] files = FileDialog.FileNames;
                // Lặp qua từng file và thêm vào dgvNewFile
                foreach (string file in files)
                {
                    // Lấy tên file
                    string filename = System.IO.Path.GetFileNameWithoutExtension(file);
                    // Lấy đường dẫn file
                    string filepath = System.IO.Path.GetFullPath(file);
                    // Lấy phần mở rộng của file
                    string extension = System.IO.Path.GetExtension(file);
                    // Thêm vào dgvNewFile
                    dgvNewFile.Rows.Add(filename, extension, filepath);
                    
                    
                }
                dgvNewFile.Columns["Path"].Visible = false;
            }
        }

        private void btnDeleteFile_Click(object sender, EventArgs e)
        {
            // Xóa 1 dòng trong DatagridView dgvNewFile
            if (dgvNewFile.Rows.Count > 0)
            {
                // Lấy dòng hiện tại
                int index = dgvNewFile.CurrentRow.Index;
                // Xóa dòng hiện tại
                dgvNewFile.Rows.RemoveAt(index);
            }
            else
            {
                MessageBox.Show(rm.GetString("t9"), rm.GetString("t0"), MessageBoxButtons.OK, MessageBoxIcon.Error); // Chưa có file nào trong danh sách này
            }
        }

        private int CheckNewFile()
        {
            int samename = 0;

            if (dgvNewFile.Rows.Count > 0 && dgvListFile.Rows.Count > 0)
            {
                for (int i = 0; i < dgvNewFile.Rows.Count; i++)
                {
                    var cellValue = dgvNewFile.Rows[i].Cells[0].Value;
                    if (cellValue == null || cboNewStatus.SelectedItem == null)
                        continue;

                    string filename = cellValue.ToString() + "_" + cboNewStatus.SelectedItem.ToString();

                    for (int j = 0; j < dgvListFile.Rows.Count; j++)
                    {
                        var cellValue2 = dgvListFile.Rows[j].Cells[0].Value;
                        if (cellValue2 == null)
                            continue;

                        string filename2 = cellValue2.ToString();
                        MessageBox.Show(filename2);

                        if (filename == filename2)
                        {
                            samename++;
                        }
                    }
                }
            }

            return samename;
        }


        private bool CopyNewFileList()
        {
            // Kiểm tra xem có file nào trong dgvNewFile không
            if (dgvNewFile.Rows.Count > 0)
            {
                for (int i = 0; i < dgvNewFile.Rows.Count; i++)
                {
                    DataGridViewRow row = dgvNewFile.Rows[i];

                    // Bỏ qua dòng trống
                    if (row.IsNewRow)
                        continue;

                    // Kiểm tra null cho từng cell
                    var filepathCell = row.Cells[2].Value;
                    var filenameCell = row.Cells[0].Value;
                    var extensionCell = row.Cells[1].Value;
                    var status = cboNewStatus.SelectedItem;

                    if (filepathCell == null || filenameCell == null || extensionCell == null || status == null)
                        continue;

                    string filepath = filepathCell.ToString().Trim();
                    string filename = filenameCell.ToString().Trim();
                    string extension = extensionCell.ToString().Trim();

                    if (string.IsNullOrEmpty(filepath) || string.IsNullOrEmpty(filename))
                        continue;

                    // Lấy đường dẫn folder
                    string folder = purchaseBLL.GetFolderPONO(POCode);

                    // Tạo tên file mới
                    string newFileName = filename + "_" + status.ToString() + extension;
                    string newFilePath = System.IO.Path.Combine(folder, newFileName);

                    // Copy file vào folder
                    System.IO.File.Copy(filepath, newFilePath, true);
                }

                return true;
            }
            else
            {
                return false;
            }
        }

        private CommonBLL _commonBLL = new CommonBLL();

        private void dgvNewFile_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            // Click đúp sẽ xem file
            string filename = dgvNewFile.CurrentRow.Cells[2].Value.ToString();
            
            try
            {
                _commonBLL.popup(1500);
                _commonBLL.PreviewFile(filename);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
            }
        }

        private void dgvListFile_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Click đúp sẽ xem file
            string filename = dgvListFile.CurrentRow.Cells[2].Value.ToString();

            try
            {
                _commonBLL.popup(1500);
                _commonBLL.PreviewFile(filename);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
            }

        }
    }
}