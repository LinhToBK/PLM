using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Resources;
using System.Security.AccessControl;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using PLM_Lynx._01_DAL_Data_Access_Layer;
using PLM_Lynx._02_BLL_Bussiness_Logic_Layer;
using PLM_Lynx._03_GUI_User_Interface._3_2_Relation_Part;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PLM_Lynx._03_GUI_User_Interface

{
    public partial class frmMakeNewPart : Form
    {
        private MakeNewPartBLL partBLL = new MakeNewPartBLL();
        private CommonBLL commonBLL = new CommonBLL();
        public int IDProposal { get; set; }
        public string NameProposal { get; set; }
        private ECO_BLL _ecoBLL = new ECO_BLL();

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

            rm = new ResourceManager("PLM_Lynx._03_GUI_User_Interface._3_2_Relation_Part.Lang.Lang_MakeNewPart", typeof(frmMakeNewPart).Assembly);
            // Hiển thị ngôn ngữ lên các điều khiển trong form
            this.Text = rm.GetString("i.form");
            labelFamily.Text = rm.GetString("lb1");
            labelName.Text = rm.GetString("lb2");
            labelDescript.Text = rm.GetString("lb10");
            labelMaterial.Text = rm.GetString("lb9");
            labelTemplate.Text = rm.GetString("lb7");
            groupBoxFile.Text = rm.GetString("lb8");

            labelNote1.Text = rm.GetString("note1");
            labelNote2.Text = rm.GetString("note2");
            labelNote3.Text = rm.GetString("note3");

            btnAddPart.Text = rm.GetString("btn.NewPart");
            btnAddFileAttachment.Text = rm.GetString("btn.Add");
            btnApplyTemplate.Text = rm.GetString("btn.Apply");
            btnDeleteFile.Text = rm.GetString("btn.Delete");
            btnListNear.Text = rm.GetString("btn.Show");



            Properties.Settings.Default.Language = lang;
            Properties.Settings.Default.Save();
        }

        // =========== Language =========================

        public frmMakeNewPart()
        {
            InitializeComponent();
            LoadLanguage();
            this.KeyPreview = true; // Cho phép Form nhận sự kiện nhấn phím trước
            this.KeyDown += new KeyEventHandler(frmMakeNewPart_KeyDown);

            // Gán sự kiện kéo thả file vào  dgvFileAttachment
            dgvFileAttachment.AllowDrop = true;
            dgvFileAttachment.DragEnter += dgvFileAttachment_DragEnter;
            dgvFileAttachment.DragDrop += dgvFileAttachment_DragDrop;
        }

        /// <summary>
        /// 01. Hàm tự tạo : Kiểm tra files khi nạp vào có là .jpg, .dwg, .dxf, .pdf không.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="NotImplementedException"></exception>
        ///
        private bool IsAllowedExtension(string filePath)
        {
            string[] allowedExtensions = { ".stp", ".jpg", ".dwg", ".dxf", ".pdf", ".prt", ".step" };
            string fileExtension = System.IO.Path.GetExtension(filePath).ToLower();
            return allowedExtensions.Contains(fileExtension);
        }

        private void LoadMaterial()
        {
            string MaterialLib = Environment.CurrentDirectory;
            MaterialLib = MaterialLib + @"\04_CommonDoc\ListMaterial.txt";
            if (File.Exists(MaterialLib))
            {
                string[] lines = File.ReadAllLines(MaterialLib); // Đọc tất cả các dòng trong file
                cboMaterial.Items.AddRange(lines); // Thêm vào ComboBox
            }
            else
            {
                //MessageBox.Show("Không load được danh sách vật liệu", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show(rm.GetString("t1"), rm.GetString("t0"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvFileAttachment_DragEnter(object sender, DragEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void label3_Click(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnListNear_Click(object sender, EventArgs e)
        {
            frmListNear frm = new frmListNear();
            frm.ShowDialog();
        }

        private void frmMakeNewPart_KeyDown(object sender, KeyEventArgs e)
        {
            // Đóng Form khi nhấn Escape
            if (e.KeyCode == Keys.Escape)
            {
                string tb = rm.GetString("t2");
                DialogResult kq = MessageBox.Show(tb, rm.GetString("t0"), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (kq == DialogResult.Yes)
                {
                    this.Close();
                }
                else
                {
                    return;
                }
            }
        }

        private void frmMakeNewPart_Load(object sender, EventArgs e)
        {
            LoadFamily();
            LoadFamilytoComboBox();
            LoadMaterial();
            // Thiết lập cấu hình cho dgvFileAttachment
            // Thiết lập các cột cho dgvListFile
            dgvFileAttachment.ColumnCount = 4;
            dgvFileAttachment.Columns[0].Name = "Name";
            dgvFileAttachment.Columns[1].Name = "Size";
            dgvFileAttachment.Columns[2].Name = "Type";
            dgvFileAttachment.Columns[3].Name = "FullName";
            dgvFileAttachment.Columns[0].Width = 250;
            dgvFileAttachment.Columns[1].Width = 50;
            dgvFileAttachment.Columns[2].Width = 50;
            //dgvFileAttachment.Columns[3].Width = 250;

            // Thêm vào Phần PartDecription
            string descript = "+) Feature :  \r\n+) Dimension : \r\n+) Finishing : ";
            txtPartDescript.Text = descript;
            txtApplyTemPlate.Text = descript;
        }

        /// <summary>
        /// 01. Hàm : Lấy dữ liệu từ tblFamily để đưa lên Datagrid view
        /// </summary>
        private void LoadFamily()
        {
            dgvFamily.DataSource = partBLL.LoadFamilyBLL();
            //dgvFamily.Columns[0].Width = 100;
            //dgvFamily.Columns[1].Width = 100;
            //dgvFamily.Columns[2].Width = 250;
            dgvFamily.AllowUserToAddRows = false;
            dgvFamily.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        /// <summary>
        /// 02. Hàm : Lấy dữ liệu cột đầu tiên của Datagrid View rồi đưa lên Combobox
        /// </summary>
        private void LoadFamilytoComboBox()
        {
            cboPartFamily.Items.Clear();

            foreach (DataGridViewRow row in dgvFamily.Rows)
            {
                // Kiểm tra nếu hàng không phải là hàng mới ( để tránh lỗi )
                if (!row.IsNewRow)
                {
                    // Lấy giá trị từ cột đầu tiên
                    var value = row.Cells[0].Value?.ToString();
                    if (!string.IsNullOrEmpty(value))
                    {
                        cboPartFamily.Items.Add(value);
                    }
                }
            }
        }

        /// </summary> 03. Hàm : Lấy  tên file từ Add file và thêm vào DataGridView dgvFileAttachment
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HienthiFiletoDataGridView()
        {
            // Tạo OpenFileDiaglog đển chọn file
            using (OpenFileDialog open = new OpenFileDialog())
            {
                // Giới hạn các định dạng file được chọn
                open.Title = "Choose file ";
                string filternote = @"PDF Files (*.pdf)|*.pdf|";
                filternote = filternote + @"STP Files (*.stp)|*.stp|";
                filternote = filternote + @"JPG Files (*.jpg)|*.jpg|";
                filternote = filternote + @"DWG Files (*.dwg)|*.dwg|";
                filternote = filternote + @"DXF Files (*.dxf)|*.dxf|";
                filternote = filternote + @"PRT Files (*.prt)|*.prt|";
                filternote = filternote + @"All Supported Files (*.pdf;*.stp;*.dwg;*.dxf;*.jpg;*.prt)|*.jpg;*.pdf;*.stp;*.dwg;*.dxf;*.prt";
                open.Filter = filternote;

                // Nếu người dùng chọn 1 file
                if (open.ShowDialog() == DialogResult.OK)
                {
                    FileInfo in4 = new FileInfo(open.FileName);
                    string ExtensionFile = in4.Extension;

                    // Lấy phần mở rộng của tệp đã chọn

                    // Kiểm tra nếu phần mở rộng đã tồn tại trong DataGridView
                    bool IsTrungExtension = false;

                    foreach (DataGridViewRow row in dgvFileAttachment.Rows)
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
                        dgvFileAttachment.Rows.Add(in4.Name, in4.Length / 1024 + "KB", in4.Extension, in4.FullName);
                    }
                    else
                    {
                        MessageBox.Show(rm.GetString("t3"));  // Đã có tệp có phần Entension trùng 
                        return;
                    }
                }
            }
        }

        private void btnAddPart_Click(object sender, EventArgs e)
        {
            string PartName = txtPartName.Text;
            string PartDescript = txtPartDescript.Text;
            string PartFamily = cboPartFamily.Text;
            string PartMaterial = txtPartMaterial.Text;
            string ThongBao = rm.GetString("t5");
            ThongBao += "\r\n " + "+) PartName : " + PartName + "\n +) PartFamily : " + PartFamily + "\n +) Part Description : " + PartDescript;
            ThongBao = ThongBao + "\n +) Part Material : " + PartMaterial;
            if (PartMaterial.Length > 20)
            {
                //MessageBox.Show("Vật liệu không được quá 20 ký tự");
                MessageBox.Show(rm.GetString("t4"), rm.GetString("t0"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int NewECONo = _ecoBLL.LoadECONo();

            DialogResult result = MessageBox.Show(ThongBao, rm.GetString("t0"), MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                // Nếu Yes thì thực hiện việc Insert
                if (partBLL.InsertNewPartBLL(PartFamily, PartName, PartDescript, PartMaterial))
                {
                    //--------------------------------------
                    //--  Lấy PartCode từ PartName vừa tạo
                    //--------------------------------------
                    string newestpartcode = partBLL.NewestPartCodeBLL();
                    //--------------------------------------
                    //-- Tạo folder từ PartCode
                    //--------------------------------------
                    if (newestpartcode != null)
                    {
                        string[] FolderName = newestpartcode.Split('-');
                        // FolderName[0] : XXX : PartFamily
                        // FolderName[1] : YYYYY : PartNo
                        // -- Tạo Folder  bằng PartCode mới
                        string FolderPath = Properties.Settings.Default.LinkDataPart + "//" + FolderName[0] + "//" + FolderName[1];
                        //string Ghichep;
                        try
                        {
                            // Tạo thư mục
                            if (!Directory.Exists(FolderPath))
                            {
                                Directory.CreateDirectory(FolderPath);
                                //Ghichep = "Thư mục đã được tạo : " + newestpartcode;
                                //MessageBox.Show("Thư mục đã được tạo : " + newestpartcode);
                            }
                            else
                            {
                                MessageBox.Show("Thư mục đã tồn tại ");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error : " + ex.Message, rm.GetString("t0"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        //------------------------------------------------------------
                        // --- Đổi tên  và save as copy các file vào folder vừa tạo
                        //------------------------------------------------------------
                        try
                        {
                            // Duyệt qua các hàng  trong DataGridView
                            foreach (DataGridViewRow row in dgvFileAttachment.Rows)
                            {
                                if (row.Cells[3].Value != null) //Kiểm tra tại cột FileName
                                {
                                    // Lấy đường dẫn của file từ cột trong Datagridview
                                    string SourceFilePath = row.Cells[3].Value.ToString();
                                    string FileExtension = row.Cells[2].Value.ToString();

                                    // Tạo tên File mới dựa trên  tên thư mục và phần mở rộng của file
                                    string NewFileName = FolderPath + "//" + newestpartcode + "_V1.0" + FileExtension;
                                    // Tên đường dẫn đến folder + tên partcode mới + . đuôi file
                                    string TargetFilePart = Path.Combine(FolderPath, NewFileName);

                                    // Sao chép file vào thư mục đích với tên mới
                                    File.Copy(SourceFilePath, TargetFilePart, true);
                                    //MessageBox.Show("Đã sao chép thành công ");
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error : " + ex.Message, rm.GetString("t0"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        //------------------------------------------------------------
                        // ---  Ghi lại vào LogFile với newest Part Code
                        // Phần này gồm 2 bước :
                        // Bước 1 : Ghi ECONo vào PartLog trong tblPart
                        // Bước 2 : Ghi nội dụng cho ECONo vào tblECO

                        //------------------------------------------------------------
                        string PartLogAdd = NewECONo.ToString(); ;
                        if (_ecoBLL.Write_ECONo_to_tblPart_BLL(newestpartcode, PartLogAdd) == true)
                        {
                            //MessageBox.Show("Tạo thành công Part mới");

                            string ECOContent = "[{ \"p\": \"" + newestpartcode + "\", \"c\": \"created new part\" }]";
                            int ECOTypeID = 1; // 1 - Tạo mới Part
                            if (_ecoBLL.InsertNewECO_BLL(NewECONo, IDProposal, NameProposal, ECOTypeID, ECOContent) == true)
                            {
                                MessageBox.Show(rm.GetString("t6"));    // MessageBox.Show("Tạo thành công Part mới");
                            }
                            else
                            {
                                MessageBox.Show(rm.GetString("t7"));   //MessageBox.Show("Ghi ECO Thất Bại");
                            }
                            //frmListNear frm = new frmListNear();
                            //frm.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show(rm.GetString("t8"));//MessageBox.Show("Ghi File Log Thất Bại");
                        }
                        // xóa dữ liệu của các ô textbox
                        cboPartFamily.SelectedIndex = -1;
                        txtPartName.Text = "";
                        txtPartDescript.Text = txtApplyTemPlate.Text;
                        txtFamilyDescription.Text = "";
                        dgvFileAttachment.Rows.Clear();
                    }
                    else
                    {
                        MessageBox.Show(rm.GetString("t9"));//MessageBox.Show("Không tạo được PartCode mới");
                        txtPartName.Focus();
                        return;
                    }
                }
                else
                {
                    MessageBox.Show(rm.GetString("t10"));//MessageBox.Show("Phát sinh lỗi \n Kiểm tra lại PartName");
                }
            }
            else
            {
                // Nếu No thì return
                return;
            }

            // Chương trình mới ;
        }

        private void btnAddFileAttachment_Click(object sender, EventArgs e)
        {
            HienthiFiletoDataGridView();
        }

        private void btnDeleteFile_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có hàng nào được chọn không ?
            if (dgvFileAttachment.SelectedRows.Count > 0)
            {
                // Xóa hàng đầu tiên trong danh sách chọn
                try
                {
                    dgvFileAttachment.Rows.RemoveAt(dgvFileAttachment.SelectedRows[0].Index);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error : " + ex.Message, rm.GetString("t0"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                MessageBox.Show(rm.GetString("t11"));//MessageBox.Show("Vui lòng chọn 1 hàng để xóa");
            }
        }

        private void dgvFileAttachment_DragEnter(object sender, DragEventArgs e)
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

        private void dgvFileAttachment_DragDrop(object sender, DragEventArgs e)
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
                    MessageBox.Show($"Tệp không hợp lệ ( File not allow ): {file}", rm.GetString("t0"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void ThemFile2listFile(string file)
        {
            FileInfo in4 = new FileInfo(file);
            string ExtensionFile = in4.Extension;
            bool CheckTrung;
            CheckTrung = false;
            foreach (DataGridViewRow row in dgvFileAttachment.Rows)
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
                dgvFileAttachment.Rows.Add(in4.Name, in4.Length / 1024 + "KB", in4.Extension, in4.FullName);
            }
            else
            {
                // MessageBox.Show("Đã có tệp có phần Entension trùng  thì phải ");
                return;
            }
        }

        private void cboPartFamily_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string selectfamily = cboPartFamily.SelectedItem.ToString();
            foreach (DataGridViewRow dr in dgvFamily.Rows)
            {
                if (dr.Cells[0].Value != null && dr.Cells[0].Value.ToString() == selectfamily)
                {
                    // Nếu thấy giá trị trùng
                    txtFamilyDescription.Text = dr.Cells[2].Value.ToString();
                    return;
                }
            }
            // Nếu không thấy thì để giá trị của ô textbox là trống
            txtFamilyDescription.Text = "";
        }

        private void dgvFileAttachment_DoubleClick(object sender, EventArgs e)
        {
            // Click đúp vào 1 dòng , thì sẽ Preview File
            commonBLL.PreviewFile(dgvFileAttachment.CurrentRow.Cells[3].Value.ToString());
        }

        private void btnApplyTemplate_Click(object sender, EventArgs e)
        {
            txtPartDescript.Text = txtApplyTemPlate.Text;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //
        }

        private void cboMaterial_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtPartMaterial.Text = cboMaterial.SelectedItem.ToString();
        }
    }
}