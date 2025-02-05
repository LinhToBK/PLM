using PLM_Lynx._02_BLL_Bussiness_Logic_Layer;
using System;
using System.Data;
using System.Windows.Forms;

namespace PLM_Lynx._03_GUI_User_Interface._3_5_Purchase
{
    public partial class frmManagePrice : Form
    {
        private PurchaseBLL purchaseBLL = new PurchaseBLL();

        public frmManagePrice()
        {
            InitializeComponent();

            // Gán sự kiện CheckedBox Rate : Cho phép sửa đổi tỷ giá
            ckcAllowModifyRate.CheckedChanged += ckcAllowModifyRate_CheckedChanged;
        }

        private CommonBLL commonBLL = new CommonBLL();
        private DataTable DulieuTimKiem = new DataTable();

        // =================================================================
        //                          HÀM TỰ TẠO
        // =================================================================
        public void LoadDataFindPart(string keysearch)
        {

            //0-p.PartCode,  
            //1-p.PartName,    
            //2-p.PartDescript,    
            //3-p.PartStage,           
            //4-p.PartID,                          
            //5-p.PartPrice
            DulieuTimKiem = commonBLL.FindwithworBLL(keysearch);
            dgvListTimKiem.DataSource = DulieuTimKiem;
            dgvListTimKiem.Columns[0].Width = 80; // PartCode
            dgvListTimKiem.Columns[1].Width = 200; // PartName
            
            dgvListTimKiem.Columns[3].Width = 50; // PartStage
            dgvListTimKiem.Columns[5].Width = 50; // PartPrice

            dgvListTimKiem.Columns[0].HeaderText = "PartCode";
            dgvListTimKiem.Columns[1].HeaderText = "PartName";
            dgvListTimKiem.Columns[2].Visible = false; //  "Description";
            dgvListTimKiem.Columns[3].HeaderText = "Stage";
            dgvListTimKiem.Columns[4].Visible = false;
            dgvListTimKiem.Columns[5].HeaderText = "Price";
            

            dgvListTimKiem.AllowUserToAddRows = false;
            dgvListTimKiem.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void convertvnd2usd()
        {
            string vndprice = txtPartPrice.Text;
            if (vndprice.Length > 0)
            {
                try
                {
                    float usdprice = (float)Convert.ToInt32(vndprice) / Convert.ToInt32(txtRate.Text);
                    txtUSDPrice.Text = usdprice.ToString(cboPrecision.SelectedItem.ToString());
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        // =================================================================
        //               FINISH :     HÀM TỰ TẠO
        // =================================================================

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult kq = MessageBox.Show("Bạn muốn thoát việc quản lý giá phải không ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq == DialogResult.Yes)
            {
                this.Close();
            }
            else
            {
                return;
            }
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

        private void txtKeySearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch.PerformClick();
                e.SuppressKeyPress = true; // Ngăn không cho tiếng Bíp kêu khi nhấn enter
            }
        }

        private void dgvListTimKiem_Click(object sender, EventArgs e)
        {
        }

        private void frmManagePrice_Load(object sender, EventArgs e)
        {
            // chỉnh các thong số lúc đầu
            ckcAllowModifyRate.Checked = false;
            txtRate.Text = "25000";
            txtRate.Enabled = false;
            rdioVND.Checked = true;
            cboPrecision.SelectedIndex = 1; //  Precision : 0.00
        }

        private void ckcAllowModifyRate_CheckedChanged(object sender, EventArgs e)
        {
            // Nếu Checkbox được chọn thì sẽ bật cho chỉnh tỷ giá
            txtRate.Enabled = ckcAllowModifyRate.Checked;
        }

        private void cboPrecision_SelectedIndexChanged(object sender, EventArgs e)
        {
            convertvnd2usd();
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            DialogResult kq = MessageBox.Show("Bạn muốn sửa giá của Part không ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq == DialogResult.Yes)
            {
                if (rdioVND.Checked == true)
                {
                    txtPartPrice.Enabled = true;
                    txtPartPrice.ReadOnly = false;
                    txtPartPrice.Focus();
                }
                else
                {
                    txtUSDPrice.Enabled = true;
                    txtUSDPrice.ReadOnly = false;
                    txtUSDPrice.Focus();
                }
            }
            else
            {
                return;
            }
        }

        private void txtPartPrice_TextChanged(object sender, EventArgs e)
        {
            // Khi sửa giá trị tiền của ô này thì đồng thời sẽ hiển thị giá USD
            if (float.TryParse(txtPartPrice.Text, out float vndprice))
            {
                // Tính giá sang USD
                float usdprice = vndprice / float.Parse(txtRate.Text);
                txtUSDPrice.Text = usdprice.ToString();
            }
            else
            {
                txtUSDPrice.Text = string.Empty; // Nếu nhập sai định dạng số thì sẽ trả về giá trị = 0
            }
        }

        private void txtUSDPrice_TextChanged(object sender, EventArgs e)
        {
            // Khi sửa giá trị tiền của ô này thì đồng thời sẽ hiển thị giá USD
            if (float.TryParse(txtUSDPrice.Text, out float usdprice))
            {
                // Tính giá sang USD
                float vndprice = usdprice * float.Parse(txtRate.Text);
                txtPartPrice.Text = vndprice.ToString();
            }
            else
            {
                txtPartPrice.Text = string.Empty; // Nếu nhập sai định dạng số thì sẽ trả về giá trị = 0
            }
        }

        private void btnSaveNewPrice_Click(object sender, EventArgs e)
        {
            // Kiểm tra giá trị  vndPrice có phải là số nguyên dương hay không ?
            if (int.TryParse(txtPartPrice.Text.Trim(), out int vndprice))
            {
                string tb;
                tb = "Bạn có muốn update giá của Part Code [ " + txtPartCode.Text + "]";
                tb += " từ --- " + dgvListTimKiem.CurrentRow.Cells[4].Value.ToString() + " (VND) --- sang --- " + txtPartPrice.Text + " --- (VND) không ?";

                DialogResult kq = MessageBox.Show(tb, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (kq == DialogResult.Yes)
                {
                    if (purchaseBLL.CapnhatPriceBLL(txtPartCode.Text, txtPartPrice.Text))
                    {
                        MessageBox.Show("Đã cập nhật thành công giá ");
                        LoadDataFindPart(txtPartCode.Text);
                    }
                    else
                    {
                        MessageBox.Show("Cập<< nhật thất bại");
                    }
                }
            }
            else
            {
                MessageBox.Show("Price đang không hơp lệ ");
                txtPartPrice.Focus();
                return;
            }
        }

        private void dgvListTimKiem_DoubleClick(object sender, EventArgs e)
        {
        }

        private void dgvListTimKiem_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            frmRelationPart_Detail_Info frm = new frmRelationPart_Detail_Info();
            string partcode = dgvListTimKiem.CurrentRow.Cells[0].Value.ToString();
            frm.ShowDetailInfor(partcode);
            frm.ShowDialog();
        }

        private void dgvListTimKiem_SelectionChanged(object sender, EventArgs e)
        {
            // Mỗi khi lên xuống bất kỳ 1 dòng nào thì giá trị sẽ tự động được thay đổi
            if (dgvListTimKiem.CurrentRow != null)
            {
                //            p.PartCode,
                //            p.PartName,
                //            p.PartDescript,
                //            p.PartStage,
                //            p.PartID,
                //            p.PartPrice
                txtPartCode.Text = dgvListTimKiem.CurrentRow.Cells[0].Value.ToString();  // Code
                txtPartName.Text = dgvListTimKiem.CurrentRow.Cells[1].Value.ToString();  // Name
                txtDescript.Text = dgvListTimKiem.CurrentRow.Cells[2].Value.ToString();  // Descript
                txtPartStage.Text = dgvListTimKiem.CurrentRow.Cells[3].Value.ToString();  // Stage
                txtPartPrice.Text = dgvListTimKiem.CurrentRow.Cells[5].Value.ToString();   // Price
            }
        }
    }
}