using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using PLM_Lynx._01_DAL_Data_Access_Layer;
using PLM_Lynx._02_BLL_Bussiness_Logic_Layer;
using PLM_Lynx._03_GUI_User_Interface;
using PLM_Lynx._03_GUI_User_Interface._3_4_FindPart;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PLM_Lynx._03_GUI_User_Interface
{
    public partial class frmFindPart : Form
    {
        private FindPartBLL PartBLL = new FindPartBLL();
        private CommonBLL CommonBLL = new CommonBLL();
        private DataTable DulieuTimKiem = new DataTable();
        private DataTransfer data = new DataTransfer();

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

            rm = new ResourceManager("PLM_Lynx._03_GUI_User_Interface._3_4_FindPart.Lang.Lang_FindPart", typeof(frmFindPart).Assembly);
            // Hiển thị ngôn ngữ lên các điều khiển trong form
            this.Text = rm.GetString("i.form");
            //groupBoxSearch.Text = rm.GetString("lb1");
            ckcSearchAll.Text = rm.GetString("lb2");
            btnThemGanDay.Text = rm.GetString("lb3" );
            groupBoxResult.Text = rm.GetString("lb4");
            groupBoxPartInfor.Text = rm.GetString("lb5");
            groupBoxListParent.Text = rm.GetString("lb6");
            groupBoxListChild.Text = rm.GetString("lb7");
            btnExportOnly.Text = rm.GetString("lb8");
            btnExportFile.Text = rm.GetString("lb9");
            ckcWithImage.Text = rm.GetString("lb10");

            Properties.Settings.Default.Language = lang;
            Properties.Settings.Default.Save();
        }

        // =========== Language =========================

        public frmFindPart()
        {
            InitializeComponent();
            // Load ngôn ngữ
            LoadLanguage();
            // Đăng ký sự kiện
            txtHighLight.TextChanged += txtHighLight_TextChanged;
            dgvSearch.CellPainting += dgvSearch_CellPainting;

            ckcWithImage.Checked = false;
        }

        public void LoadDataFindPart(string keysearch)
        {
            if(ckcSearchAll.Checked == true)
            {
                DulieuTimKiem = PartBLL.FindWithWordBLL(keysearch);
            }
            else
            {
                string input = txtViewRow.Text;

                if (int.TryParse(input, out int number) && number >= 0)
                {
                    DulieuTimKiem = PartBLL.FindWithWordBLL(keysearch, input);
                }
                else
                {
                    MessageBox.Show(rm.GetString("t1")); // Bạn cần nhập số dòng lớn hơn 0
                }// Kiểm tra số dòng


            }


            //0p.PartCode,
            //1p.PartName,
            //2p.PartDescript,
            //3s.Stage as PartStage,
            //4p.PartID,
            //5p.PartPrice,
            //6p.PartMaterial,
            //7p.PartPriceSale,
            //8p.PartPriceLog
            dgvSearch.DataSource = DulieuTimKiem;

            dgvSearch.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSearch.Columns[0].Width = 80; // PartCode
            dgvSearch.Columns[1].Width = 200; // PartName
            // dgvSearch.Columns[2].Width = 250; // PartDescript
            dgvSearch.Columns[3].Width = 100; // PartStage
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
            // Các cột còn lại đều bị ẩn 
            dgvSearch.Columns[4].Visible = false; // IDPart
            dgvSearch.Columns[5].Visible = false; // PartPrice
            dgvSearch.Columns[6].Visible = false; // PartMaterial
            dgvSearch.Columns[7].Visible = false; // PartPriceSale
            dgvSearch.Columns[8].Visible = false; // PartPriceLog


            dgvSearch.AllowUserToAddRows = false;
            dgvSearch.AllowUserToDeleteRows = false;
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

            //  p.PartCode, p.PartName, p.PartDescript, p.PartMaterial
            dgvParent.DataSource = PartBLL.GetParentBLL(idpart);
            

            dgvParent.AllowUserToAddRows = false;
            dgvParent.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtKeySearch.Text != "")
            {
                LoadDataFindPart(txtKeySearch.Text.Trim());
            }
            else
            {
                MessageBox.Show(rm.GetString("t2")); // Bạn cần nhập ô tìm kiếm
            }
        }

        private void dgvSearch_Click(object sender, EventArgs e)
        {
            if (dgvSearch.Rows.Count == 0) { txtKeySearch.Focus(); return; }
            txtCode.Text = dgvSearch.CurrentRow.Cells[0].Value.ToString(); // Code
            txtName.Text = dgvSearch.CurrentRow.Cells[1].Value.ToString(); // Name
            txtDescript.Text = dgvSearch.CurrentRow.Cells[2].Value.ToString(); // Description
            txtStage.Text = dgvSearch.CurrentRow.Cells[3].Value.ToString(); // Stage
            txtMaterial.Text = dgvSearch.CurrentRow.Cells[6].Value.ToString(); // Material
            //txtLog.Text = dgvSearch.CurrentRow.Cells[5].Value.ToString(); // Log

            // -- Hiển thị ảnh
            if (CommonBLL.UploadImagebyPartCode(txtCode.Text, picPart) == true)
            {
                groupboxImagePart.Text = "Image";
            }
            else
            {
                groupboxImagePart.Text = "Not found Image";
            }

            // Load các file trong partcode lên dgvListFile
            CommonBLL.GetAllFileinFolder(txtCode.Text, dgvListFile);
            //-----

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
                MessageBox.Show(rm.GetString("t4"));  // Dữ liệu đang trống
                txtKeySearch.Focus();
                return;
            }
            picParent.Refresh();

            txtParentCode.Text = dgvParent.CurrentRow.Cells[0].Value.ToString();
            txtParentName.Text = dgvParent.CurrentRow.Cells[1].Value.ToString();
            txtParentDescript.Text = dgvParent.CurrentRow.Cells[2].Value.ToString();
            txtParentMaterial.Text = dgvParent.CurrentRow.Cells[3].Value.ToString();

            // Hiển thị ảnh
            if (CommonBLL.UploadImagebyPartCode(txtParentCode.Text, picParent) == true)
            {
                groupboxParentImage.Text = "Parent Image";
            }
            else
            {
                groupboxParentImage.Text = "Not found image";
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
                groupboxChildImage.Text = "Child Image";
            }
            else
            {
                groupboxChildImage.Text = "Not found image";
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
            if (dgvSearch.Rows.Count > 0)
            {

                frmRelationPart_Detail_Info frm = new frmRelationPart_Detail_Info();
                string partcode = dgvSearch.CurrentRow.Cells[0].Value.ToString();
                frm.ShowDetailInfor(partcode);
                frm.ShowDialog();
            }
        }

        private void dgvParent_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dgvParent.Rows.Count >0)
            {
                frmRelationPart_Detail_Info frm = new frmRelationPart_Detail_Info();
                string partcode = dgvParent.CurrentRow.Cells[0].Value.ToString();
                frm.ShowDetailInfor(partcode);
                frm.ShowDialog();
            }    
            
        }

        private void dgvChild_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvChild.Rows.Count == 0)
            {
                txtKeySearch.Focus();
                return;
            }
            else
            {
                frmRelationPart_Detail_Info frm = new frmRelationPart_Detail_Info();
                string partcode = dgvChild.CurrentRow.Cells[1].Value.ToString();
                frm.ShowDetailInfor(partcode);
                frm.ShowDialog();
            }
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
        }

        private void txtKeySearch_TextChanged(object sender, EventArgs e)
        {
            //dgvSearch.Refresh();
        }

        private void btnExportOnly_Click(object sender, EventArgs e)
        {
            if (dgvChild.Rows.Count == 0)
            {
                MessageBox.Show(rm.GetString("t3"));  // Dữ liệu đang trống
                return;
            }

            string tb = rm.GetString("t4"); // Bạn có muốn xuất dữ liệu không ? 
            DialogResult kq = MessageBox.Show(tb, rm.GetString("t0"), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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
            if (dgvSearch.Rows.Count == 0)
            {
                MessageBox.Show(rm.GetString("t3")); // Dữ liệu đang trống
                txtKeySearch.Focus();
                return;
            }
            else
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
}