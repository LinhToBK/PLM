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
using Newtonsoft.Json;

namespace PLM_Lynx._03_GUI_User_Interface._3_3_ECO
{
    public partial class frmUpdateInforPart : Form
    {
        private ECO_BLL ecoBLL = new ECO_BLL();
        private CommonBLL commonBLL = new CommonBLL();
        private int _oldPartStage;
        private int _newPartStage;
        private string _oldPartMaterial;
        private string _newPartMaterial;
        private DataTable _tblPartStage = new DataTable();
        public int IDProposal;
        public string NameProposal;

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
                filternote = filternote + @"JPG Files (*.jpg)|*.jpg|";
                filternote = filternote + @"DWG Files (*.dwg)|*.dwg|";
                filternote = filternote + @"DXF Files (*.dxf)|*.dxf|";
                filternote = filternote + @"PRT Files (*.prt)|*.prt|";
                filternote = filternote + @"All Supported Files (*.prt;*.pdf;*.stp;*.dwg;*.dxf;*.jpg)|*.prt;*.jpg;*.pdf;*.stp;*.dwg;*.dxf";
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
            if (dt.Rows.Count > 0)
            {
                // Có dữ liệu thì sẽ đẩy lên các ô textbox
                //                p.PartCode,   0
                //                p.PartName,   1
                //                p.PartDescript,  2
                //                s.Stage as PartStage,  3
                //                p.PartLog,         4
                //                p.PartPrice,    5
                //                p.PartMaterial       6
                //                p.PartStageID   7
                txtPartName.Text = dt.Rows[0][1].ToString();
                txtPartDescript.Text = dt.Rows[0][2].ToString();
                txtPartLog.Text = dt.Rows[0][4].ToString();
                txtPartStage.Text = dt.Rows[0][3].ToString();
                txtPartMaterial.Text = dt.Rows[0][6].ToString();
                _oldPartStage = Convert.ToInt16(dt.Rows[0][7].ToString());
                _oldPartMaterial = dt.Rows[0][6].ToString();

                // Cập nhật lên danh sách file
                if (commonBLL.GetAllFileinFolder(partcode, dgvListFile) == false)
                {
                    MessageBox.Show("Không thể load folder chứa dữ liệu ");
                }
                else
                {
                    txtListFileStatus.Text = "Kết nối được với dữ liệu của Part";
                }
            }
            else
            {
                MessageBox.Show("Không lấy được dữ liệu từ Database");
                this.Close();
            }
        }

        private bool IsAllowedExtension(string filePath)
        {
            string[] allowedExtensions = { ".stp", ".jpg", ".dwg", ".dxf", ".pdf", ".step", ".prt" };
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
            if (kq == DialogResult.Yes)
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

        private void LoadMaterialLib()
        {
            string MaterialLib = Environment.CurrentDirectory;
            MaterialLib = MaterialLib + @"\04_CommonDoc\ListMaterial.txt";
            if (File.Exists(MaterialLib))
            {
                string[] lines = File.ReadAllLines(MaterialLib); // Đọc tất cả các dòng trong file
                cboMaterialLib.Items.AddRange(lines); // Thêm vào ComboBox
            }
            else
            {
                MessageBox.Show("Không load được danh sách vật liệu", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Load giá trị của Stage lên ComboBox
            _tblPartStage = ecoBLL.GettblPartStage_BLL();
            cboNewStage.Items.Clear();
            if (_tblPartStage.Rows.Count == 0)
            {
                MessageBox.Show("Không load được danh sách Stage", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                foreach (DataRow dr in _tblPartStage.Rows)
                {
                    cboNewStage.Items.Add(dr[1].ToString());
                }
            }
        }

        private void frmUpdateInforPart_Load(object sender, EventArgs e)
        {
            LoadMaterialLib();
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
            // Bước 1 : Đặt tên các giá trị của ECO
            string p = txtPartCode.Text;
            if(txtNewMaterial.Text.Length > 20) { MessageBox.Show("Vật liệu mới không được quá 20 ký tự"); return; }
            string thongbao;

            thongbao = "Kiểm tra lại các thông tin sau trước khi cập nhật dữ liệu ";
            thongbao += "\n +) PartName : " + txtPartName.Text;
            thongbao += "\n +) Part Descript :" + txtPartDescript.Text;

           
            // 1.1  Status cho việc update stage kay không ?
            int s;
            int os = _oldPartStage;
            int ns;

            _newPartStage = cboNewStage.SelectedIndex + 1;
            if (_newPartStage > _oldPartStage)
            {
                s = 1;  // Nếu lớn hơn chứng tỏ sẽ cập nhật stage mới
                ns = _newPartStage;
                thongbao += "\n +) Có cập nhật Stage mới : " + cboNewStage.SelectedItem.ToString();
            }
            else
            {
                s = 0;
                ns = _oldPartStage;
            }
            // 1.2 Có cập nhật nội dung thêm hay không ?
            int i;
            string ic = "";
            if (txtNoteMore.Text != "")
            {
                i = 1;
                ic = txtNoteMore.Text;
                thongbao += "\n +) Có cập nhật thêm nội dung " + txtNoteMore.Text;
            }
            else
            {
                i = 0;
            }
            // 1.3 Có cập nhật Material hay không ?
            int m;
            string om = txtPartMaterial.Text;
            string nm = txtNewMaterial.Text.Trim();
            if (om != nm && nm != "")
            {
                m = 1;
                thongbao += "\n +) Có cập nhật Vật liệu mới : " + txtNewMaterial.Text;
            }
            else
            {
                m = 0;
            }

            // 1.4 Có cập nhật bản vẽ hay không
            int d;
            if (dgvListUpload.Rows.Count > 1)
            {
                d = 1;
                thongbao += "\n +) Có cập nhật bản vẽ mới : ";
            }
            else
            {
                d = 0;
            }

            // Bước 2 : Lấy số ECO và tạo content
            int NewECONo = ecoBLL.LoadECONo();

            List<Tuple<string, object>> tableData = new List<Tuple<string, object>>
                {
                    new Tuple<string, object>("p", p),
                    new Tuple<string, object>("s", s),
                    new Tuple<string, object>("os", os),
                    new Tuple<string, object>("ns", ns),
                    new Tuple<string, object>("i", i),
                    new Tuple<string, object>("ic", ic),
                    new Tuple<string, object>("m", m),
                    new Tuple<string, object>("om", om),
                    new Tuple<string, object>("nm", nm),
                    new Tuple<string, object>("d", d),
                    new Tuple<string, object>("od", ""),
                    new Tuple<string, object>("nd", ""),

                };
            Dictionary<string, object> jsonData = new Dictionary<string, object>();
            foreach (var row in tableData)
            {
                jsonData[row.Item1] = row.Item2;
            }

            // Chuyển thành chuỗi JSON
            string ECOContent = JsonConvert.SerializeObject(jsonData, Formatting.Indented);
            ECOContent = "[" + ECOContent + "]";
            int ECOTypeID = 2; // 2 là ECO cho việc cập nhật thông tin của Part
            //MessageBox.Show(ECOContent);

            // Bước 3 : Tiến hành tạo ECO
            // Ghi ECO vào tblECO, nếu ghi OK thì sẽ tiến hành copy các file mới vào thư mục ECOTEMP với tên thư mục là ECONo.
            // Nếu lưu thư mục bị lỗi thì sẽ xóa ECONo vừa tạo , xóa follderECONo nếu có , và thông báo lỗi

            DialogResult kq = MessageBox.Show(thongbao, "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq == DialogResult.Yes)
            {
                // Bước 3.1 Ghi ECO vào tblECO 
                if (ecoBLL.InsertNewECO_BLL(NewECONo, IDProposal, NameProposal, ECOTypeID, ECOContent) == true)
                {
                   if(d == 1)
                    {
                        // MessageBox.Show("Tiến hàng copy vào thư mục tạm thời");
                        // Nếu cập nhật bản vẽ   => Copy file vào thư mục ECOTEMP
                        if(ecoBLL.CopyFile_to_ECOTEMP_BLL(NewECONo.ToString(),dgvListUpload) == true )
                        {
                            MessageBox.Show("Đã copy thành công vào thư mục ECOTEMP \n Tạo request [ Cập nhật Part ] thành công ");
                        }
                        else
                        {
                            MessageBox.Show("Không thể copy file vào thư mục ECOTEMP");
                            //Xóa ECO vừa tạo 
                            ecoBLL.DeleteECO_BLL(NewECONo);
                            return;
                        }

                    }
                   else
                    {
                        MessageBox.Show("Tạo request [ Cập nhật Part ] thành công");
                    }    
                }

            }
            else
            {
                return;
            }

        }

        private void cboMaterialLib_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtNewMaterial.Text = cboMaterialLib.SelectedItem.ToString();
        }
    }
}