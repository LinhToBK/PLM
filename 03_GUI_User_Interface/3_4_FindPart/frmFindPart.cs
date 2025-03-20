using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PLM_Lynx._01_DAL_Data_Access_Layer;
using PLM_Lynx._02_BLL_Bussiness_Logic_Layer;
using PLM_Lynx._03_GUI_User_Interface;
using PLM_Lynx._03_GUI_User_Interface._3_4_FindPart;

namespace PLM_Lynx._03_GUI_User_Interface
{
    public partial class frmFindPart : Form
    {

        private FindPartBLL PartBLL = new FindPartBLL();
        private CommonBLL CommonBLL = new CommonBLL();
        private DataTable DulieuTimKiem = new DataTable();
        DataTransfer data = new DataTransfer();



        public frmFindPart()
        {
            InitializeComponent();
            // Đăng ký sự kiện
            txtHighLight.TextChanged += txtHighLight_TextChanged;
            dgvSearch.CellPainting += dgvSearch_CellPainting;
            
            ckcWithImage.Checked = false;

        }


        public void LoadDataFindPart(string keysearch)
        {
            DulieuTimKiem = PartBLL.FindWithWordBLL(keysearch);
            dgvSearch.DataSource = DulieuTimKiem;
            dgvSearch.Columns[0].Width = 80; // PartCode
            dgvSearch.Columns[1].Width = 200; // PartName
            dgvSearch.Columns[2].Width = 100; // PartDescript
            dgvSearch.Columns[3].Width = 50; // PartStage
            //dgvSearch.Columns[4].Width = 50; // PartPrice
            //dgvSearch.Columns[5].Width = 100; // PartLog
            //dgvSearch.Columns[6].Width = 100; // Partfile
            dgvSearch.Columns[0].HeaderText = "Code";
            dgvSearch.Columns[1].HeaderText = "Name";
            dgvSearch.Columns[2].HeaderText = "Description";
            dgvSearch.Columns[3].HeaderText = "Stage";
            //dgvSearch.Columns[4].HeaderText = "Price";
            //dgvSearch.Columns[5].HeaderText = "Log";
            //dgvSearch.Columns[6].HeaderText = "LinkFile";


            dgvSearch.AllowUserToAddRows = false;
            dgvSearch.EditMode = DataGridViewEditMode.EditProgrammatically;

        }

        public void LoadDataChild(string idpart)
        {
            dgvChild.DataSource = PartBLL.GetChildBLL(idpart);
            dgvChild.Columns[4].Visible = false; // Ẩn cột Dir

            dgvChild.AllowUserToAddRows = false;
            dgvChild.EditMode = DataGridViewEditMode.EditProgrammatically;
            foreach (DataGridViewColumn column in dgvChild.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable; // Không cho phép sort lại danh sách
            }
        }

        public void LoadDataParent(string idpart)
        {
            dgvParent.DataSource = PartBLL.GetParentBLL(idpart);
            dgvParent.Columns[0].Visible = false; // Ẩn cộtID
            dgvParent.Columns[1].Visible = false; // Ẩn cột Family
            dgvParent.Columns[2].Visible = false; // Ẩn cột PartNo
            dgvParent.Columns[7].Visible = false; // Ẩn cột PartFile
            dgvParent.Columns[8].Visible = false; // Ẩn cột PartPrice
            dgvParent.Columns[9].Visible = false; // Ẩn cột PartLog

            // Hiệu chỉnh độ rộng của các cột
            //dgvParent.Columns[3].Width = 200; // Cột ParentName
            //dgvParent.Columns[4].Width = 80;  // Cột ParentCode
            dgvParent.Columns[5].Width = 100; // Cột ParentDescript
            dgvParent.Columns[6].Width = 40;  // Cột ParentStage


            dgvParent.AllowUserToAddRows = false;
            dgvParent.EditMode = DataGridViewEditMode.EditProgrammatically;

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtKeySearch.Text != "")
            {
                LoadDataFindPart(txtKeySearch.Text);
            }
            else
            {
                MessageBox.Show("Bạn cần nhập ô tìm kiếm");
            }

        }

        private void dgvSearch_Click(object sender, EventArgs e)
        {


            if (dgvSearch.Rows.Count == 0) { txtKeySearch.Focus(); return; }
            txtCode.Text = dgvSearch.CurrentRow.Cells[0].Value.ToString(); // Code
            txtName.Text = dgvSearch.CurrentRow.Cells[1].Value.ToString(); // Name
            txtDescript.Text = dgvSearch.CurrentRow.Cells[2].Value.ToString(); // Description
            //txtLog.Text = dgvSearch.CurrentRow.Cells[5].Value.ToString(); // Log

            // -- Hiển thị ảnh
            if (CommonBLL.UploadImagebyPartCode(txtCode.Text, picPart) == true)
            {
                groupboxImagePart.Text = "";
            }
            else
            {
                groupboxImagePart.Text = "No find Image";
            }

            // Load các file trong partcode lên dgvListFile
            CommonBLL.GetAllFileinFolder(txtCode.Text, dgvListFile);
            //-----
            //string imagefilepath = Properties.Settings.Default.LinkDataPart;
            ////string Partcode = dgvSearch.CurrentRow.Cells[0].Value.ToString(); // Code : XXX-000YY
            //string Partcode = txtCode.Text;
            //string[] input = Partcode.Split('-');
            //string filepath = imagefilepath + "\\" + input[0] + "\\" + input[1];
            //imagefilepath = imagefilepath  + input[0] + "\\" + input[1] + "\\" + Partcode + ".jpg";



            //// Kiểm tra file có tồn tại
            //if (System.IO.File.Exists(imagefilepath))
            //{
            //    //picPart.Image = Image.FromFile(imagefilepath);
            //    picPart.SizeMode = PictureBoxSizeMode.StretchImage;
            //    using (Image newimage = Image.FromFile(imagefilepath))
            //    {
            //        picPart.Image = (Image)newimage.Clone();
            //        groupboxImagePart.Text = "";

            //    }

            //}   
            //else
            //{
            //    groupboxImagePart.Text = "Không có ảnh";
            //    //MessageBox.Show("Không có ảnh ");
            //    picPart.Image = null;
            //    //picChild.Image.Dispose();
            //}
            //------

            // Hiển thị danh sách các PartParent và PartChild
            string idpart = dgvSearch.CurrentRow.Cells[4].Value.ToString();
            LoadDataChild(idpart);
            LoadDataParent(idpart);

            // Hiển thị danh sách các file có trong folder Partcode




        }

        private void GetAllFileinFolder(string filepath)
        {
            //throw new NotImplementedException();
            try
            {
                // Xóa dữ liệu cũ trong DataGritView
                dgvListFile.Rows.Clear();

                // Lấy danh sách tất cả các file trong thư mục
                string[] files = Directory.GetFiles(filepath);

                // Duyệt qua danh sách file và thêm vào DataGritView
                foreach (string file in files)
                {
                    FileInfo fileInfor = new FileInfo(file);

                    // Thêm 1 dòng vào DataGritView 
                    dgvListFile.Rows.Add(fileInfor.Name, fileInfor.Length / 1024 + "KB", fileInfor.Extension, fileInfor.CreationTime);
                    // Tên - Kích thước file - Đôi file - Ngày khởi tạo
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra : " + ex.Message);
            }


        }

        private void txtKeySearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch.PerformClick();
                e.SuppressKeyPress = true; // Ngăn không cho tiếng Bíp kêu khi nhấn enter
            }
        }

        /// <summary>
        /// Tạo hiệu ứng chia level của part con - chia theo màu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvChild_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            // Áp dụng hiệu ứng DataBar cho cột 0
            //if (e.ColumnIndex == 0 && e.RowIndex >= 0)
            //{
            //    if (e.Value != null && int.TryParse(e.Value.ToString(), out int cellValue))
            //    {
            //        int minValue = 0;
            //        int maxValue = 5;

            //        Tính chiều rộng của DataBar dựa trên tỷ lệ
            //        int barWidth = (int)((float)(cellValue - minValue) / (maxValue - minValue) * e.CellBounds.Width);

            //        Vẽ nền của ô
            //        e.Graphics.FillRectangle(Brushes.White, e.CellBounds);

            //        Vẽ DataBar với màu xanh dương
            //        using (Brush brush = new SolidBrush(Color.LightBlue))
            //        {
            //            e.Graphics.FillRectangle(brush, e.CellBounds.X, e.CellBounds.Y, barWidth, e.CellBounds.Height);
            //        }

            //        Vẽ giá trị văn bản trong ô
            //        e.Graphics.DrawString(cellValue.ToString(), e.CellStyle.Font, Brushes.Black, e.CellBounds.X + 2, e.CellBounds.Y + 2);

            //        e.Handled = true; // Đánh dấu sự kiện là đã xử lý
            //    }
            //}
        }

        /// Tạo hiệu ứng chia Level của Part con
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Khi click vào 1 dòng trên DatagritView "dgvParent"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvParent_Click(object sender, EventArgs e)
        {
            if (dgvParent.Rows.Count == 0)
            {
                txtKeySearch.Focus();
                return;
            }
            picParent.Refresh();

            txtParentCode.Text = dgvParent.CurrentRow.Cells[4].Value.ToString();
            txtParentName.Text = dgvParent.CurrentRow.Cells[3].Value.ToString();
            txtParentLog.Text = dgvParent.CurrentRow.Cells[9].Value.ToString();


            // Hiển thị ảnh
            if (CommonBLL.UploadImagebyPartCode(txtParentCode.Text, picParent) == true)
            {

                groupboxParentImage.Text = "Have Image";
            }
            {
                groupboxParentImage.Text = "No Image";
            }


        }

        private void dgvChild_Click(object sender, EventArgs e)
        {
            if (dgvChild.Rows.Count == 0)
            {
                txtKeySearch.Focus();
                return;
            }
            picChild.Refresh();
            txtChildCode.Text = dgvChild.CurrentRow.Cells[1].Value.ToString();
            txtChildName.Text = dgvChild.CurrentRow.Cells[2].Value.ToString();
            //// -- Hiển thị ảnh
            if (CommonBLL.UploadImagebyPartCode(txtChildCode.Text, picChild) == true)
            {
                groupboxChildImage.Text = "Have Image";
            }
            {
                groupboxChildImage.Text = "No Find Image";
            }


        }

        private void frmFindPart_Load(object sender, EventArgs e)
        {
            // Thiết lập các cột cho dgvListFile
            dgvListFile.ColumnCount = 4;
            dgvListFile.Columns[0].Name = "Name";
            dgvListFile.Columns[1].Name = "Size";
            dgvListFile.Columns[2].Name = "Type";
            dgvListFile.Columns[3].Name = "Created";


        }

        private void dgvSearch_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Khi double click vào cell, hiển thị Part
            // Mở form
            frmRelationPart_Detail_Info frm = new frmRelationPart_Detail_Info();
            string partcode = dgvSearch.CurrentRow.Cells[0].Value.ToString();
            frm.ShowDetailInfor(partcode);
            frm.ShowDialog();
        }

        private void dgvParent_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            frmRelationPart_Detail_Info frm = new frmRelationPart_Detail_Info();
            string partcode = dgvParent.CurrentRow.Cells[4].Value.ToString();
            frm.ShowDetailInfor(partcode);
            frm.ShowDialog();
        }

        private void dgvChild_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            frmRelationPart_Detail_Info frm = new frmRelationPart_Detail_Info();
            string partcode = dgvChild.CurrentRow.Cells[1].Value.ToString();
            frm.ShowDetailInfor(partcode);
            frm.ShowDialog();
        }

        private void btnThemGanDay_Click(object sender, EventArgs e)
        {
            frmListNear frm = new frmListNear();
            frm.ShowDialog();

        }

        // private System.Timers.Timer debounceTimer;
        private void txtHighLight_TextChanged(object sender, EventArgs e)
        {
            dgvSearch.Refresh(); // Khi từ khóa thay đổi thì sẽ cập nhật giá trị của datagridview

        }

        private void dgvSearch_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            // Highlight những từ khóa 
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0) // Kiểm tra ô hợp lệ
            {
                string searchKeyword = txtHighLight.Text; // Lấy từ khóa từ TextBox
                if (!string.IsNullOrEmpty(searchKeyword) && e.Value != null)
                {
                    string cellText = e.Value.ToString(); // Lấy nội dung ô
                    int startIndex = cellText.IndexOf(searchKeyword, StringComparison.OrdinalIgnoreCase); // Tìm vị trí từ khóa

                    if (startIndex >= 0) // Nếu tìm thấy từ khóa trong ô
                    {
                        e.Handled = true; // Ngăn vẽ nội dung mặc định
                        e.PaintBackground(e.ClipBounds, true); // Vẽ nền ô

                        // Vẽ các ký tự trước và sau từ khóa
                        using (var brush = new SolidBrush(e.CellStyle.ForeColor))
                        {
                            // Vẽ phần trước từ khóa
                            e.Graphics.DrawString(cellText.Substring(0, startIndex),
                                e.CellStyle.Font, brush, e.CellBounds.Location.X + 2, e.CellBounds.Location.Y + 2);

                            // Vẽ từ khóa (highlight)
                            SizeF textBeforeSize = e.Graphics.MeasureString(cellText.Substring(0, startIndex), e.CellStyle.Font);
                            using (var highlightBrush = new SolidBrush(Color.Yellow))
                            {
                                e.Graphics.FillRectangle(highlightBrush,
                                    e.CellBounds.Location.X + 2 + textBeforeSize.Width,
                                    e.CellBounds.Location.Y + 2,
                                    e.Graphics.MeasureString(searchKeyword, e.CellStyle.Font).Width,
                                    e.CellBounds.Height - 4);
                            }
                            e.Graphics.DrawString(searchKeyword,
                                e.CellStyle.Font, Brushes.Black, e.CellBounds.Location.X + 2 + textBeforeSize.Width,
                                e.CellBounds.Location.Y + 2);

                            // Vẽ phần sau từ khóa
                            float textKeywordWidth = e.Graphics.MeasureString(searchKeyword, e.CellStyle.Font).Width;
                            e.Graphics.DrawString(cellText.Substring(startIndex + searchKeyword.Length),
                                e.CellStyle.Font, brush, e.CellBounds.Location.X + 2 + textBeforeSize.Width + textKeywordWidth,
                                e.CellBounds.Location.Y + 2);
                        }
                    }
                }
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            // Lấy danh sách giá trị duy nhất từ 1 cột 
            var GiaTri = DulieuTimKiem.AsEnumerable()
                                        .Select(row => row.Field<string>("PartCode"))
                                        .Distinct()
                                        .ToList();

            // Tạo form FilterSearch
            frmFilterSearch frm = new frmFilterSearch(GiaTri);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                // Lấy các giá trị đã chọn từ frmFilterSearch
                List<string> DanhsachFamilyCode = frm.DanhsachFamilyCodeOK;

                // Áp dụng Row Filter
                string Filter = string.Join(" OR ", DanhsachFamilyCode.Select(k => $"PartCode LIKE '%{k}%'"));
                DataView dv = new DataView(DulieuTimKiem);
                dv.RowFilter = Filter;

                //// Gán DataView làm nguồn dữ liệu cho DataGridView
                dgvSearch.DataSource = dv;
            }
        }

        private void txtKeySearch_TextChanged(object sender, EventArgs e)
        {
            //dgvSearch.Refresh();
        }

        private void btnExportOnly_Click(object sender, EventArgs e)
        {
            if (dgvChild.Rows.Count == 0)
            {
                MessageBox.Show("Dữ liệu đang trống");
                return;
            }


            DialogResult kq = MessageBox.Show("Bạn muốn xuất dữ liệu dạng Excel không", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq == DialogResult.Yes)
            {
                // Hiển thị SaveFileDialog
                SaveFileDialog sv = new SaveFileDialog
                {
                    Filter = "Excel Files|*.xlsx",
                    Title = "Save an Excel File",
                    FileName = "ExportedBOM.xlsx"
                };
                if (sv.ShowDialog() == DialogResult.OK)
                {
                    // Gọi hàm xuất dữ liệu
                    string idpart = dgvSearch.CurrentRow.Cells[4].Value.ToString();
                    dgvChild.DataSource = PartBLL.GetBOMBLL(idpart);

                    if (ckcWithImage.Checked == true)
                    {
                        CommonBLL.ExportToExcelWithImages(dgvChild, sv.FileName);
                    }
                    else
                    {
                        CommonBLL.ExportToExcel(dgvChild, sv.FileName);
                    }

                    // Khi xong thì trả về giá trị cho dgvChild
                    LoadDataChild(idpart);
                }

            }
            else
            {
                return;
            }

        }

        //private void btnExportAll_Click(object sender, EventArgs e)
        //{
            
        //}

        private void btnExportFile_Click(object sender, EventArgs e)
        {
            
            data._currentPartCode = dgvSearch.CurrentRow.Cells[0].Value.ToString();
            data._currentPartName = dgvSearch.CurrentRow.Cells[1].Value.ToString();
            data.listchild = dgvChild.DataSource as DataTable;
            frmDownloadFile frm = new frmDownloadFile();


            // Lấy dữ liệu partcode hiện tại
            
            
            frm.inputData = data; // Do lưu  giá trị của currentpartcode rồi,, nên lát sẽ lấy lại
            
            frm.ShowDialog();
        }
    }
}
