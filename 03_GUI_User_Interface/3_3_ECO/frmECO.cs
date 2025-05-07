using Newtonsoft.Json;
using PLM_Lynx._02_BLL_Bussiness_Logic_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PLM_Lynx._03_GUI_User_Interface._3_3_ECO
{
    public partial class frmECO : Form
    {
        private CommonBLL commonBLL = new CommonBLL();
        private ECO_BLL ecoBLL = new ECO_BLL();
        public int IDNguoidung;
        public string Username;

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

            rm = new ResourceManager("PLM_Lynx._03_GUI_User_Interface._3_3_ECO.Lang.Lang_frmECO", typeof(frmECO).Assembly);
            // Hiển thị ngôn ngữ lên các điều khiển trong form
            this.Text = rm.GetString("i.form");
            labelNote1.Text = rm.GetString("lb1");
            labelNote2.Text = rm.GetString("lb2");
            btnTimKiem.Text = rm.GetString("lb4");
            labelNote3.Text = rm.GetString("lb3");
            btnOpenRelationManage.Text = rm.GetString("lb6");

            btnSearchDetail.Text = rm.GetString("lb7");

            // --
            groupBoxPart.Text = rm.GetString("lb8");
            labelNote4.Text = rm.GetString("lb9");
            btnUpdatePart.Text = rm.GetString("lb10");
            btnAddPart.Text = rm.GetString("lb5");

            // --
            labelParent.Text = rm.GetString("lb11");
            labelChild.Text = rm.GetString("lb12");
            btnCheckListChild.Text = rm.GetString("lb13");
            btnModifyQuantity.Text = rm.GetString("lb14");
            btnDelete.Text = rm.GetString("lb15");
            labelQuantity.Text = rm.GetString("lb16");
            labelNote5.Text = rm.GetString("lb17");
            btnAddParent.Text = rm.GetString("lb18");
            btnAddChild.Text = rm.GetString("lb19");

            Properties.Settings.Default.Language = lang;
            Properties.Settings.Default.Save();
        }

        // =========== Language =========================
        public frmECO()
        {
            InitializeComponent();
            LoadLanguage();
        }

        //==================================================
        //******************* HÀM TỰ TẠO *******************
        //==================================================

        // --- Hàm Load dữ liệu từ DataBase bên dgvListTimKiem
        public void LoadListTimkiem(string keysearch)
        {
            dgvListTimKiem.DataSource = commonBLL.FindwithworBLL(keysearch);
            dgvListTimKiem.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvListTimKiem.Columns[0].Width = 80; // PartCode
            dgvListTimKiem.Columns[1].Width = 300; // PartName
            dgvListTimKiem.AllowUserToAddRows = false;
        }

        // - Hàm Load dữ liệu từ DataBase lên dgvListChild
        public void LoadListChild(string parentcode)
        {
            dgvListChild.DataSource = ecoBLL.GetListChildBLL(parentcode);
            dgvListChild.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvListChild.AllowUserToAddRows = false;
            dgvListChild.Columns[0].Width = 80;
            dgvListChild.Columns[1].Width = 300;
        }

        // -- Hàm kiểm tra 1 số có phải là số nguyên dương hay không
        private bool IsPosivtiveInteger(int num)
        {
            return num > 0;
        }

        // -- Hàm tìm Quantity tương ứng với 1 PartCode trong dgvListChild
        private string FindQuantity(string childcode)
        {
            string qty = null;
            // Duyệt qua tất cả các hàng trong DatagridView
            foreach (DataGridViewRow rw in dgvListChild.Rows)
            {
                if (childcode == rw.Cells[0].Value.ToString())
                {
                    // Nếu tìm thấy
                    qty = rw.Cells[2].Value.ToString();
                    break;
                }
            }

            if (qty == null)
            {
                //MessageBox.Show("Xuất hiện lỗi khi lấy dữ liệu quantity của part " + childcode);
                MessageBox.Show(rm.GetString("t1") + childcode);
            }
            return qty;
        }

        //==================================================
        // ************FINISH HAM TU TAO *******************
        //==================================================

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (txtTimKiem.Text == "")
            {
                MessageBox.Show(rm.GetString("t2"));      // Cần nhập từ khóa tìm kiếm 
                txtTimKiem.Focus();
                return;
            }
            else
            {
                LoadListTimkiem(txtTimKiem.Text);
                dgvListTimKiem.Focus();
            }
        }

        private void txtTimKiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnTimKiem.PerformClick();
                e.SuppressKeyPress = true; // Ngăn không cho tiếng Bíp kêu khi nhấn enter
            }
        }

        private void dgvListTimKiem_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Lấy dữ liệu code của ô đang trỏ đến
            frmRelationPart_Detail_Info frm = new frmRelationPart_Detail_Info();
            string partcode = dgvListTimKiem.CurrentRow.Cells[0].Value.ToString();
            frm.ShowDetailInfor(partcode);
            frm.ShowDialog();
        }

        private void frmECO_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Hiển thị hộp thoại xác nhận
            string tb = rm.GetString("t3");//  "Bạn có muốn thoát không ?";
            DialogResult kq = MessageBox.Show(tb, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (kq == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void btnAddPart_Click(object sender, EventArgs e)
        {
            // Cập nhật lên các ô textbox
            if (dgvListTimKiem.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu nào để thêm cả ");
                txtTimKiem.Focus();
                return;
            }
            else
            {
                txtPartCode.Text = dgvListTimKiem.CurrentRow.Cells[0].Value.ToString();
                txtPartName.Text = dgvListTimKiem.CurrentRow.Cells[1].Value.ToString();
            }
        }

        private void btnAddParent_Click(object sender, EventArgs e)
        {
            // Xóa dữ liệu của các ô textbox trong danh sách child
            txtChildCode.Text = "";
            txtChildName.Text = "";
            dgvListChild.DataSource = null;
            txtQuantity.Text = string.Empty;

            // Cập nhật lên các ô textbox
            if (dgvListTimKiem.Rows.Count == 0)
            {
                MessageBox.Show(rm.GetString("t4"));    // "Không có dữ liệu nào để thêm cả "
                txtTimKiem.Focus();
                return;
            }
            else
            {
                txtParentCode.Text = dgvListTimKiem.CurrentRow.Cells[0].Value.ToString();
                txtParentName.Text = dgvListTimKiem.CurrentRow.Cells[1].Value.ToString();
            }
        }

        private void btnCheckListChild_Click(object sender, EventArgs e)
        {
            //
            if (txtParentCode.Text == "")
            {
                MessageBox.Show(rm.GetString("t5"));   // Không có dữ liệu Parent Code
                return;
            }
            else
            {
                LoadListChild(txtParentCode.Text);
            }
        }

        private void btnAddChild_Click(object sender, EventArgs e)
        {
            // Thêm dữ liệu từ DataGridView vào textbox
            txtChildCode.Text = dgvListChild.CurrentRow.Cells[0].Value.ToString();
            txtChildName.Text = dgvListChild.CurrentRow.Cells[1].Value.ToString();
            txtQuantity.Text = dgvListChild.CurrentRow.Cells[2].Value.ToString();
            btnModifyQuantity.Enabled = true;
            btnDelete.Enabled = true;
        }

        private void btnSearchDetail_Click(object sender, EventArgs e)
        {
            frmFindPart frm = new frmFindPart();
            frm.ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
        }

        private void btnModifyQuantity_Click(object sender, EventArgs e)
        {
            // Kiểm tra số lượng, nếu là số nguyên thì mới thực hiện bước tiếp theo
            int quantity;
            if (int.TryParse(txtQuantity.Text, out quantity))
            {
                if (!IsPosivtiveInteger(quantity))
                {
                    //MessageBox.Show("Giá trị Quantity nhập vào không phải là số nguyên dương");
                    MessageBox.Show(rm.GetString("t6"), rm.GetString("t0"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            string oldquantity = FindQuantity(txtChildCode.Text);
            if (oldquantity == txtQuantity.Text)

            {
                //MessageBox.Show("Giá trị quantity đang không thay đổi , vui lòng sửa quantity mới");
                MessageBox.Show(rm.GetString("t7"), rm.GetString("t0"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            frmModifyQuantity frm = new frmModifyQuantity();
            frm.parentcode = txtParentCode.Text;
            frm.parentname = txtParentName.Text;
            frm.childcode = txtChildCode.Text;
            frm.childname = txtChildName.Text;
            frm.oldquantity = oldquantity;
            frm.newquantity = txtQuantity.Text;
            frm.idnguoiyeucau = IDNguoidung;
            frm.tennguoiyc = Username;
            frm.ShowDialog();

            // Sau khi cập nhật thì cần load lại DataGridView dgvListChild
            LoadListChild(txtParentCode.Text);
            btnDelete.Enabled = false;
            btnModifyQuantity.Enabled = false;
            txtChildCode.Text = "";
            txtChildName.Text = "";
            txtQuantity.Text = "";
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            // Cần thông báo để tránh nhấn nhầm.
            string tb;
            tb = rm.GetString("t8") + txtParentCode.Text + " && " + txtChildCode.Text ;
            tb += "\n" + rm.GetString("t9");

            DialogResult kq = MessageBox.Show(tb, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (kq == DialogResult.Yes)
            {
                

                int ECONo = ecoBLL.LoadECONo();

                List<Tuple<string, object>> tableData = new List<Tuple<string, object>>
                {
                    new Tuple<string, object>("ParentCode", txtParentCode.Text),
                    new Tuple<string, object>("ChildCode", txtChildCode.Text)
                };
                Dictionary<string, object> jsonData = new Dictionary<string, object>();
                foreach (var row in tableData)
                {
                    jsonData[row.Item1] = row.Item2;
                }

                // Chuyển thành chuỗi JSON
                string ECOContent = JsonConvert.SerializeObject(jsonData, Formatting.Indented);
                ECOContent = "[" + ECOContent + "]";
                int ECOTypeID = 5; // 4 là ECO cho sửa số lượng Part

                if (ecoBLL.InsertNewECO_BLL(ECONo, IDNguoidung, Username, ECOTypeID, ECOContent))
                {
                    //MessageBox.Show("Tạo ECO : Xóa ràng buộc  thành công");
                    MessageBox.Show(rm.GetString("t10"));
                    //this.Close();
                }
                else
                {
                    //MessageBox.Show("Xuất hiện lỗi khi tạo ECO \n Kiểm tra lại dữ liệu");
                    MessageBox.Show(rm.GetString("t11"));
                    return;
                }
            }
            else
            {
                return;
            }
        }

        private void btnOpenRelationManage_Click(object sender, EventArgs e)
        {
            frmRelationPart frm = new frmRelationPart();
            frm.ShowDialog();
        }

        private void dgvListChild_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Lấy dữ liệu code của ô đang trỏ đến
            frmRelationPart_Detail_Info frm = new frmRelationPart_Detail_Info();
            string partcode = dgvListChild.CurrentRow.Cells[0].Value.ToString();
            frm.ShowDetailInfor(partcode);
            frm.ShowDialog();
        }

        private void btnUpdatePart_Click(object sender, EventArgs e)
        {
            if (txtPartCode.Text.Length > 0)
            {
                frmUpdateInforPart frm = new frmUpdateInforPart();

                frm.LoadDataPart(txtPartCode.Text);
                frm.IDProposal = IDNguoidung;
                frm.NameProposal = Username;
                frm.ShowDialog();
            }
            else
            {
                //MessageBox.Show("Bạn chưa chọn Part để cập nhật dữ liệu. \n Vui lòng chọn trước ");
                MessageBox.Show(rm.GetString("t12"), rm.GetString("t0"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}