using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.CompilerServices.RuntimeHelpers;
using System.Xml.Linq;
using PLM_Lynx._02_BLL_Bussiness_Logic_Layer;
using System.Diagnostics;
using PLM_Lynx._03_GUI_User_Interface._3_2_Relation_Part;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using System.Globalization;
using System.Resources;
using System.Threading;

namespace PLM_Lynx._03_GUI_User_Interface
{
    public partial class frmRelationPart : Form
    {
        private RelationPartBLL relationpartBLL = new RelationPartBLL();
        private CommonBLL commonBLL = new CommonBLL();

        private DataTable danhcon = new DataTable();

        public int idProposal { get; set; } // ID của Proposal để truyền vào BLL
        public string nameProposal { get; set; }  // Tên của Proposal để truyền vào BLL

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

            rm = new ResourceManager("PLM_Lynx._03_GUI_User_Interface._3_2_Relation_Part.Lang.Lang_RelationPart", typeof(frmRelationPart).Assembly);
            // Hiển thị ngôn ngữ lên các điều khiển trong form
            this.Text = rm.GetString("i.form");
            label1.Text = rm.GetString("lb1");
            btnUpload.Text = rm.GetString("btnUpload");
            btnFindPart.Text = rm.GetString("btnHistory");
            btnSearch.Text = rm.GetString("btnSearch");
            btnAdd2Parent.Text = rm.GetString("btnAddParent");
            btnClearParent.Text = rm.GetString("btnDeleteParent");
            labelPartCode.Text = rm.GetString("lb2");
            labelPartName.Text = rm.GetString("lb3");
            labelPartDescript.Text = rm.GetString("lb4");
            labelFileStatus.Text = rm.GetString("lb5");
            labelNote.Text = rm.GetString("lb6");

            //
            btnAddChild.Text = rm.GetString("btnAddChild");
            btnDeleteChild.Text = rm.GetString("btnDelChild");
            btnClearChild.Text = rm.GetString("btnClearChild");
            btnCheckBefore.Text = rm.GetString("btnCheck");

            Properties.Settings.Default.Language = lang;
            Properties.Settings.Default.Save();
        }

        // =========== Language =========================
        public frmRelationPart()
        {
            InitializeComponent();
            LoadLanguage();
        }

        // ===============================================
        //             DANH SÁCH HÀM TỰ TẠO
        // ================================================

        /// <summary>
        /// 01. Hàm tải dữ liệu tra cứu lên dgvListTimKiem
        /// </summary>
        /// <param name="k; ;eysearch">; ;</param>
        public void LoadDataFindPart(string keysearch)
        {
            dgvListTimKiem.DataSource = relationpartBLL.FindWithWordBLL(keysearch);
            dgvListTimKiem.Columns[0].Width = 80; // PartCode
            dgvListTimKiem.Columns[1].Width = 200; // Part Name
            dgvListTimKiem.Columns[2].Width = 250; // Part Description
            dgvListTimKiem.AllowUserToAddRows = false;
            dgvListTimKiem.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        // ===============================================
        // ===============================================

        private void txtPartCode_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtTimKiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch.PerformClick();
                e.SuppressKeyPress = true; // Ngăn không cho tiếng Bíp kêu khi nhấn enter
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            // --- Kiểm tra các điều kiện ban đầu
            if (txtTimKiem.Text == "")
            {
                //MessageBox.Show("Bạn chưa nhập từ khóa vào ô tìm kiếm ");
                MessageBox.Show(rm.GetString("t1"));
                txtTimKiem.Focus();
            }
            else
            {
                LoadDataFindPart(txtTimKiem.Text);
                dgvListTimKiem.Focus();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            string tb = rm.GetString("t2");  // Bạn muốn thoát việc tạo liên kết giữa các Part phải không ?

            DialogResult result = MessageBox.Show(tb, rm.GetString("t0"), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            { this.Close(); } // Đóng cửa sổ hiện tại
            else
            { return; } // Không làm gì cả
        }

        private void dgvListTimKiem_Click(object sender, EventArgs e)
        {
            // Khi Click 1 vào ô thì cần lấy hình ảnh của partcode đang trỏ để hiển thị lên Picturebox

            // - Nếu dgvListTimKiem trống thì thông báo và quay lại ô tìm kiếm
            if (dgvListTimKiem.Rows.Count == 0)
            {
                //MessageBox.Show("Không tìm thấy dữ liệu phù hợp ");
                MessageBox.Show(rm.GetString("t3"));
                txtTimKiem.Focus();
                return;
            }

            
            string partcode = dgvListTimKiem.CurrentRow.Cells[0].Value.ToString(); // Code
          

            // -- Hiển thị ảnh
            if (commonBLL.UploadImagebyPartCode(partcode, picTimKiem) == true)
            {
                txtStatusImagePart.Text = "Image";
            }
            else
            {
                txtStatusImagePart.Text = "Not found Image";
            }
        }

        private void dgvListTimKiem_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Nếu Click đúp vào Cell trong dgvListTimKiem
            // Thì sẽ hiển thị form chi tiết của Part đang trỏ

            if (e.RowIndex >= 0)
            {
                // Lấy PartCode
                string PartCode = dgvListTimKiem.CurrentRow.Cells[0].Value.ToString(); // Code : XXX-000YY
                //MessageBox.Show("Đây là Partcode trước khi nhập vào : " + PartCode);

                // Mở Form Detail
                frmRelationPart_Detail_Info detailinfo = new frmRelationPart_Detail_Info();
                detailinfo.ShowDetailInfor(PartCode);


                //detailinfo.partcode = PartCode;
                detailinfo.ShowDialog();
            }
        }

        private void btnAdd2Parent_Click(object sender, EventArgs e)
        {
            // Lấy dữ liệu của dgvListTimKiem để đẩy lên các ô textbox của vùng Parrent
            if (dgvListTimKiem.Rows.Count == 0)
            {
                //MessageBox.Show("Không có giá trị để thêm vào "); ;
                MessageBox.Show(rm.GetString("t4")); ;
                txtTimKiem.Focus();
                return;
            }

            string partcode = dgvListTimKiem.CurrentRow.Cells[0].Value.ToString();
            string partname = dgvListTimKiem.CurrentRow.Cells[1].Value.ToString();
            string partdescript = dgvListTimKiem.CurrentRow.Cells[2].Value.ToString();

            // Kiểm tra xem partcode này có trong dgvChild không, nếu có thì thoát
            bool isDuplicate = false;
            foreach (DataGridViewRow row in dgvChild.Rows)
            {
                // Kiểm tra giá trị của cột đầu tiên
                if (row.Cells[0] != null && row.Cells[0].Value.ToString() == partcode)
                {
                    isDuplicate = true;

                    break;
                }
            }

            // Nếu không trùng thì mới thêm vào
            if (isDuplicate == true)
            {
                //MessageBox.Show("Giá trị này đã có trong danh sách con ");
                MessageBox.Show(rm.GetString("t5"));
                return;
            }
            else
            {
                txtPartCode.Text = partcode;
                txtPartName.Text = partname;
                txtPartDescripts.Text = partdescript;
                // Đẩy danh sách file
                if (commonBLL.GetAllFileinFolder(partcode, dgvListFile) == true)
                {
                    txtListFileStatus.Text = rm.GetString("t6"); // Tìm thấy files trong server.
                }
                else
                {
                    txtListFileStatus.Text = rm.GetString("t7"); // "Có vẻ không load được danh sách file";
                }
                // Load ảnh
                if (commonBLL.UploadImagebyPartCode(partcode, picParent) == false)
                {
                    MessageBox.Show(rm.GetString("t8"));                 //Không load được ảnh 
                }
            }
        }

        private void frmRelationPart_Load(object sender, EventArgs e)
        {
            danhcon.Columns.Add("PartCode", typeof(string));
            danhcon.Columns.Add("PartName", typeof(string));
            danhcon.Columns.Add("Quantity", typeof(int));
            dgvChild.AllowUserToAddRows = false;
        }

        private void btnClearParent_Click(object sender, EventArgs e)
        {
            // Xóa hết giá trị
            txtPartCode.Text = "";
            txtPartName.Text = "";
            txtPartDescripts.Text = "";
            picParent.Image.Dispose();
            picParent.Image = null;
            dgvListFile.Rows.Clear();
        }

        private void dgvListFile_DoubleClick(object sender, EventArgs e)
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
                MessageBox.Show("Error : " + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddChild_Click(object sender, EventArgs e)
        {
            // Thêm vào dgvChild
            if (dgvListTimKiem.Rows.Count == 0)
            {
                //MessageBox.Show("Không có đối tượng part trong danh sách tìm kiếm \n Hãy nhập từ khóa tìm kiếm");
                MessageBox.Show(rm.GetString("t9"));
                txtTimKiem.Focus();
                return;
            }

            string partcode = dgvListTimKiem.CurrentRow.Cells[0].Value.ToString();
            string partname = dgvListTimKiem.CurrentRow.Cells[1].Value.ToString();
            if (partcode == txtPartCode.Text)
            {
                MessageBox.Show(rm.GetString("t10"));    // Lỗi : Trùng với Part Cha 
                return;
            }
            else
            {
                // Kiểm tra giá trị này với giá trị của dgvChild hiện tại
                bool isDuplicate = false;
                foreach (DataRow rw in danhcon.Rows)
                {
                    // Kiểm tra giá trị của cột đầu tiên
                    if ((string)rw["PartCode"] == partcode)
                    {
                        isDuplicate = true;

                        break;
                    }
                }

                // Nếu trùng thì thông báo
                if (isDuplicate == true)
                {
                    MessageBox.Show(rm.GetString("t11"));        // Giá trị này đã thêm vào danh sách con rồi 
                    return;
                }
                else
                {
                    // Nếu không trùng thì mới thêm vào
                    //MessageBox.Show("Sẽ thêm : || " + partcode + " || vào danh sách Part Child");
                    MessageBox.Show(rm.GetString("t12") + partcode + " || " + rm.GetString("t13"));
                    danhcon.Rows.Add(partcode, partname, 1);
                    dgvChild.DataSource = danhcon;

                    // Đặt các cột không được chỉnh sửa
                    dgvChild.Columns[0].ReadOnly = true;
                    dgvChild.Columns[1].ReadOnly = true;
                    dgvChild.Columns[2].ReadOnly = false; // chỉ cột quantity mới được phép sửa
                }
            }
        }

        private void btnDeleteChild_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có hàng nào được chọn không
            if (dgvChild.SelectedRows.Count > 0)
            {
                string tb = rm.GetString("t14"); // Bạn có muốn xóa dòng này không ?

                DialogResult result = MessageBox.Show(tb, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    foreach (DataGridViewRow rw in dgvChild.SelectedRows)
                    {
                        if (!rw.IsNewRow)
                        {
                            dgvChild.Rows.Remove(rw);
                        }
                    }
                }
                else
                {
                    MessageBox.Show(rm.GetString("t15"));   //Đang chưa chọn dòng nào để xóa
                }
            }
        }

        private void btnClearChild_Click(object sender, EventArgs e)
        {
            string tb = rm.GetString("t16"); // Bạn có muốn xóa toàn bộ dữ liệu của List Child phải không ?

            DialogResult result = MessageBox.Show(tb, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                if (dgvChild.DataSource is DataTable dt)
                {
                    dt.Clear();
                }
                else
                {
                    dgvChild.Rows.Clear();
                }
            }
        }

        private void dgvChild_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string PartCode = dgvChild.CurrentRow.Cells[0].Value.ToString(); // Code : XXX-000YY

            // Mở Form Detail
            frmRelationPart_Detail_Info detailinfo = new frmRelationPart_Detail_Info();

            detailinfo.ShowDetailInfor(PartCode);
            detailinfo.ShowDialog();
        }

        private void btnCheckBefore_Click(object sender, EventArgs e)
        {
            // Tạo form để kiểm tra việc upload dữ liệu
            frmUploadRelationtoDataBase frm = new frmUploadRelationtoDataBase();
            string parentcode = txtPartCode.Text;
            string parentname = txtPartName.Text;
            frm.idProposal = idProposal;
            frm.nameProposal = nameProposal;

            // Copy dữ liệu từ DataGridView lên Form Check Data Upload
            frm.LayDatafrom_frmRelationPart(parentcode, parentname, danhcon);

            frm.ShowDialog();
            // Nếu OK hết thì button Upload DataBase mới được bật
        }

        private void btnFindPart_Click(object sender, EventArgs e)
        {
            frmFindPart frm = new frmFindPart();
            frm.ShowDialog();
        }

        private void txtStatusImagePart_TextChanged(object sender, EventArgs e)
        {
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            string tb = rm.GetString("t17"); // Cần kiểm tra thông tin trước khi gửi yêu cầu tạo ràng buộc giữa các part
            DialogResult kq = MessageBox.Show(tb, rm.GetString("t0"), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq == DialogResult.No)
            {
                return;
            }
            else
            {
                // Tạo form để kiểm tra việc upload dữ liệu
                frmUploadRelationtoDataBase frm = new frmUploadRelationtoDataBase();
                string parentcode = txtPartCode.Text;
                string parentname = txtPartName.Text;
                frm.idProposal = idProposal;
                frm.nameProposal = nameProposal;

                // Copy dữ liệu từ DataGridView lên Form Check Data Upload
                frm.LayDatafrom_frmRelationPart(parentcode, parentname, danhcon);

                frm.ShowDialog();
                // Nếu OK hết thì button Upload DataBase mới được bật
            }
        }
    }
}