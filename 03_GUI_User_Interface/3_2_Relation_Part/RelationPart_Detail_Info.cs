//using Microsoft.Office.Interop.Excel;
using PLM_Lynx._02_BLL_Bussiness_Logic_Layer;
using PLM_Lynx._03_GUI_User_Interface._3_2_Relation_Part;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Resources;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PLM_Lynx._03_GUI_User_Interface
{
    public partial class frmRelationPart_Detail_Info : Form
    {
        private RelationPartBLL RelationPartBLL = new RelationPartBLL();
        private CommonBLL commonBLL = new CommonBLL();
        private FindPartBLL _findPartBLL = new FindPartBLL();
        private string idpart ;

        public DataTable tb_ListFileinFolder { get; set; }

        private DataTable _tblChild = new DataTable();

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

            rm = new ResourceManager("PLM_Lynx._03_GUI_User_Interface._3_2_Relation_Part.Lang.Lang_RelationPart_Detail_Info", typeof(frmRelationPart_Detail_Info).Assembly);
            // Hiển thị ngôn ngữ lên các điều khiển trong form
            this.Text = rm.GetString("i.form");

            labelPartCode.Text = rm.GetString("lb1");
            labelPartName.Text = rm.GetString("lb2");
            labelPartStage.Text = rm.GetString("lb3");
            labelPartDescription.Text = rm.GetString("lb5");
            labelPartMaterial.Text = rm.GetString("lb4");
            labelPartPrice.Text = rm.GetString("lb8");
            labelNote1.Text = rm.GetString("lb6");
            labelNote2.Text = rm.GetString("lb7");


            Properties.Settings.Default.Language = lang;
            Properties.Settings.Default.Save();
        }

        // =========== Language =========================

        public frmRelationPart_Detail_Info()
        {
            InitializeComponent();
            LoadLanguage(); // Load ngôn ngữ từ ResourceManager

            // Kích hoạt sự kiện KeyDown
            this.KeyDown += new KeyEventHandler(frmRelationPart_Detail_Info_KeyDown);
            this.KeyPreview = true; // Cần bật Key Preview để Form bắt được phím

            // Đặt mặc định checkbox = true
            // Đặt tất cả các mục là Checked mặc định = true
            
        }

        // ==============================================================
        //          DANH SÁCH HÀM TỰ TẠO
        // ==============================================================
        /// <summary>
        /// 01. Hiển thị các thuộc tính của Part lên các ô textbox
        /// </summary>
        /// <param name="partcode"></param>
        public void ShowDetailInfor(string partcode)
        {
            // Gọi BLL để lấy dữ liệu

            DataTable DetailInfor = RelationPartBLL.GetInforPartBLL(partcode);
            if (DetailInfor.Rows.Count > 0)
            {
                // Hiển thị dữ liệu lên các ô textbox. sẽ lấy hàng đầu tiên
                DataRow row0 = DetailInfor.Rows[0];
                txtPartCode.Text = row0[0].ToString();
                txtPartName.Text = row0[1].ToString();
                txtPartStage.Text = row0[3].ToString();
                txtPartDescription.Text = row0[2].ToString();

                //txtPartLog.Text = row0[4].ToString();
                LoadListECO(row0[4].ToString()); // Load danh sách ECO lên DataGridView
                txtPartMaterial.Text = row0[6].ToString();
                decimal partprice;
                if (row0[5].ToString() == "" || row0[5].ToString() == "0")
                {
                    partprice = 0;
                }
                else
                {
                    partprice = Convert.ToDecimal(row0[5].ToString());
                }
                idpart = row0[7].ToString();
                LoadChild();

                txtPartPrice.Text = partprice.ToString("N0");

                // Hiển thị ảnh
                if (commonBLL.UploadImagebyPartCode(partcode, PicPart) == true)
                {
                    txtPicStatus.Text = rm.GetString("t1");
                }
                else
                {
                    txtPicStatus.Text = rm.GetString("t2");
                }
                // Hiển thị danh sách file
                if (commonBLL.GetAllFileinFolder(partcode, dgvListFile) == false)
                {
                    //MessageBox.Show("Không tìm thấy file nào trong thư mục này ! \n Vui lòng kiểm tra lại đường dẫn hoặc tên PartCode");
                    MessageBox.Show(rm.GetString("t3"));
                }

                dgvListFile.AllowUserToAddRows = false; // Không cho phép thêm dòng mới
                // dgvListFile.AutoResizeColumns();
                dgvListFile.AllowUserToDeleteRows = false; // Không cho phép xóa dòng
                //dgvListFile.CellClick -= dgvListFile_CellClick;
                //dgvListFile.Click -= dgvListFile_Click;
            }
            else
            {
                //MessageBox.Show("Lỗi, không tìm thấy dữ liệu ");
                MessageBox.Show(rm.GetString("t4"));
            }
        }

        private void frmRelationPart_Detail_Info_Load(object sender, EventArgs e)
        {
            //dgvListFile.CellClick -= dgvListFile_CellClick;
            //dgvListFile.Click -= dgvListFile_Click;
            splitContainer1.FixedPanel = FixedPanel.Panel1;
        }

        private void frmRelationPart_Detail_Info_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        

        private void dgvListFile_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Nếu click đúp vào 1 Cells thì sẽ Preview File của dòng đó

            string filename = dgvListFile.CurrentRow.Cells[0].Value.ToString();
            // MessageBox.Show(dgvListFile.CurrentRow.Cells[1].Value.ToString());
            string filesize_A = dgvListFile.CurrentRow.Cells[1].Value.ToString();
            filesize_A = filesize_A.Substring(0, filesize_A.Length - 2);
            int filesize = Convert.ToInt32(filesize_A);

            string DataPath = Properties.Settings.Default.LinkDataPart;
            string[] input = txtPartCode.Text.Split('-');  // Chia XXX-YYYYY thành 2 phần : XXX và YYYYY
            filename = DataPath + input[0] + "\\" + input[1] + "\\" + filename;
            try
            {
                if (filesize > 10000)
                {
                    string tb = rm.GetString("t5"); // "File lớn hơn 10MB, bạn có muốn mở không ?"
                    DialogResult kq = MessageBox.Show(tb, rm.GetString("t0"), MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (kq == DialogResult.Yes)
                    {
                        // Hiện popup
                        commonBLL.popup(5000);
                        commonBLL.PreviewFile(filename);
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    // Hiện popup
                    commonBLL.popup(2000);
                    commonBLL.PreviewFile(filename);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(rm.GetString("t6") + ex.Message);
            }
        }

        private void btnDownLoadFile_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra xem có dòng nào được chọn không
                if (dgvListFile.SelectedRows.Count == 0)
                {
                    //MessageBox.Show("Hãy chọn ít nhất một dòng trong DataGridView!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    MessageBox.Show(rm.GetString("t7"), rm.GetString("t0"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Mở Folder Browser Dialog để chọn thư mục đích
                using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
                {
                    folderDialog.Description = "Chọn thư mục để lưu file";
                    if (folderDialog.ShowDialog() == DialogResult.OK)
                    {
                        string destinationFolder = folderDialog.SelectedPath;

                        // Duyệt qua các dòng được chọn trong DataGridView
                        foreach (DataGridViewRow row in dgvListFile.SelectedRows)
                        {
                            // Lấy đường dẫn file từ cột đầu tiên
                            string sourceFilePath = row.Cells[0].Value?.ToString();
                            sourceFilePath = commonBLL.GetFilePath(txtPartCode.Text) + "\\" + sourceFilePath;

                            // Kiểm tra giá trị hợp lệ
                            if (!string.IsNullOrEmpty(sourceFilePath) && File.Exists(sourceFilePath))
                            {
                                try
                                {
                                    // Lấy tên file
                                    string fileName = Path.GetFileName(sourceFilePath);

                                    // Tạo đường dẫn đích
                                    string destinationFilePath = Path.Combine(destinationFolder, fileName);

                                    // Copy file
                                    File.Copy(sourceFilePath, destinationFilePath, overwrite: true);
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show($"Không thể copy file: {sourceFilePath}\n{ex.Message}",
                                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }

                        MessageBox.Show(rm.GetString("t8"));      // Download file hoàn tất!
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message, rm.GetString("t0"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnApplyFilter_Click(object sender, EventArgs e)
        {
            
           
        }

        private void label3_Click(object sender, EventArgs e)
        {
        }

        private void LoadListECO(string PartLog)
        {
            string[] ecoNo = PartLog.Split('|');

            DataTable dt = new DataTable();
            // Tạo các cột
            dt.Columns.Add("ECONo", typeof(int));
            dt.Columns.Add("ECO Date", typeof(DateTime));
            dt.Columns.Add("ECO Type", typeof(string));

            // Ghi từng phần tử vào DataTable
            foreach (string eco in ecoNo)
            {
                if (!string.IsNullOrWhiteSpace(eco)) // tránh dòng rỗng
                {
                    DataTable ecoinfor = RelationPartBLL.Get_tblECO_BLL(Convert.ToInt32(eco));
                    if (ecoinfor.Rows.Count > 0)
                    {
                        // Tạo một hàng mới
                        DataRow row = dt.NewRow();
                        DataRow rowinfor = ecoinfor.Rows[0];
                        row["ECONo"] = rowinfor[0];
                        row["ECO Date"] = rowinfor[1];
                        row["ECO Type"] = rowinfor[2];
                        dt.Rows.Add(row);
                    }
                }
            }

            dgvListECO.DataSource = dt;
            dgvListECO.AllowUserToAddRows = false; // Không cho phép thêm dòng mới
            dgvListECO.Columns[0].Width = 100;
            dgvListECO.Columns[1].Width = 100;
            dgvListECO.Columns[2].Width = 200;
            dgvListECO.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Tự động điều chỉnh kích thước cột
        }

        private void dgvListECO_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Lấy thong tin ECONo của dòng được chọn
            int ECONo = Convert.ToInt32(dgvListECO.CurrentRow.Cells[0].Value.ToString());
            frmECO_Infor_Detail frm = new frmECO_Infor_Detail();
            frm.ECONo = ECONo;
            frm.ShowDialog();
        }

        private void dgvListFile_CellClick(object sender, DataGridViewCellEventArgs e)
        {
         

        }

        private void dgvListFile_Click(object sender, EventArgs e)
        {
            
        }

        private int formwidth { get; set; }

        private void LoadChild ()
        {
            // hiển thị child
            _tblChild = _findPartBLL.GetChildBLL(idpart);
            dgvChild.DataSource = _tblChild;
            dgvChild.Columns[4].Visible = false; // Ẩn cột Dir
            dgvChild.Columns[0].Width = 80;
            dgvChild.Columns[1].Width = 80;
            dgvChild.Columns[2].Width = 200;
            dgvChild.Columns[3].Width = 50;

            dgvChild.AllowUserToAddRows = false;
            dgvChild.EditMode = DataGridViewEditMode.EditProgrammatically;
            foreach (DataGridViewColumn column in dgvChild.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable; // Không cho phép sort lại danh sách
            }
        }
        private void btnExpand_Click(object sender, EventArgs e)
        {
            btnCollapse.Enabled = true;
            splitContainer1.Panel2Collapsed = false;
            formwidth = this.Width;

            this.Width = (int)(formwidth * 1.7) ;
            splitContainer1.SplitterDistance = (int)(splitContainer1.Width * 0.6);

            
            


            
            btnExpand.Enabled = false;
        }

        private void btnCollapse_Click(object sender, EventArgs e)
        {
            btnExpand.Enabled = true;
            this.Width = formwidth;
            
            splitContainer1.Panel2Collapsed = true;


            btnCollapse.Enabled = false;
            
        }

        private void dgvChild_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Chỉ định cột "Tên" để thực hiện việc tạo phân cấp
            dgvChild.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            if (e.ColumnIndex == dgvChild.Columns[0].Index && e.RowIndex >= 0)
            {
                int level = Convert.ToInt32(dgvChild.Rows[e.RowIndex].Cells[0].Value);

                // Thêm khoảng trắng hoặc dấu gạch ngang để biểu thị cấp độ
                e.Value = new string('-', level * 3) + e.Value.ToString();
            }
        }
    }
}