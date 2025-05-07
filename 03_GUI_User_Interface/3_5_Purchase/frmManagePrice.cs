using PLM_Lynx._02_BLL_Bussiness_Logic_Layer;
using System;
using System.Data;
using System.Globalization;
using System.Resources;
using System.Threading;
using System.Windows.Forms;

namespace PLM_Lynx._03_GUI_User_Interface._3_5_Purchase
{
    public partial class frmManagePrice : Form
    {
        private PurchaseBLL purchaseBLL = new PurchaseBLL();
        public string tennguoidung;

        private bool allowmodify = false; // Cho phép sửa đổi giá không 


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

            rm = new ResourceManager("PLM_Lynx._03_GUI_User_Interface._3_5_Purchase.Lang.Lang_frmManagePrice", typeof(frmManagePrice).Assembly);
            // Hiển thị ngôn ngữ lên các điều khiển trong form
            this.Text = rm.GetString("i.form");
            groupBoxSearchPart.Text = rm.GetString("lb1");
            btnSearch.Text = rm.GetString("lb2");
            btnMakeNewPO.Text = rm.GetString("lb3");
            btnTraCuuPO.Text = rm.GetString("lb4");
            groupBoxPartInformation.Text = rm.GetString("lb5");
            labelPartCode.Text = rm.GetString("lb6");
            labelPartName.Text = rm.GetString("lb8");
            labelPartStage.Text = rm.GetString("lb7");
            labelPrecision.Text = rm.GetString("lb9");
            labelDescription.Text = rm.GetString("lb10");
            groupBoxCurrentPrice.Text = rm.GetString("lb11");
            labelImportPrice.Text = rm.GetString("lb12");
            labelExportPrice.Text = rm.GetString("lb13");
            ckcAllowModifyRate.Text = rm.GetString("lb14");
            groupBoxLog.Text = rm.GetString("lb15");
            btnModify.Text = rm.GetString("lb16");
            btnSaveNewPrice.Text = rm.GetString("lb17");
            btnExit.Text = rm.GetString("lb18");



            Properties.Settings.Default.Language = lang;
            Properties.Settings.Default.Save();
        }

        // =========== Language =========================
        public frmManagePrice()
        {
            InitializeComponent();
            LoadLanguage();

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

            //p.0.PartCode,
            //p.1.PartName,
            //p.2.PartDescript,
            //s.3.Stage as PartStage,
            //p.4.PartID,
            //p.5.PartPrice,
            //p.6.PartMaterial,
            //p.7.PartPriceSale
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
            dgvListTimKiem.Columns[5].HeaderText = "ImportPrice";
            dgvListTimKiem.Columns[7].HeaderText = "ExportPrice";


            dgvListTimKiem.AllowUserToAddRows = false;
            dgvListTimKiem.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void convertvnd2usd()
        {
            string vndprice = txtPartPrice.Text;
            string vndexportprice = txtExportPrice.Text;
            if (vndprice.Length > 0)
            {
                try
                {
                    float usdprice = (float)Convert.ToInt32(vndprice) / Convert.ToInt32(txtRate.Text);
                    txtUSDPrice.Text = usdprice.ToString(cboPrecision.SelectedItem.ToString());

                    float usdexportprice = (float)Convert.ToInt32(vndexportprice) / Convert.ToInt32(txtRate.Text);
                    txtExportPriceUSD.Text = usdexportprice.ToString(cboPrecision.SelectedItem.ToString());
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void convertusd2vnd()
        {
            string usdprice = txtUSDPrice.Text;
            string usdexportprice = txtExportPriceUSD.Text;
            if (usdprice.Length > 0)
            {
                try
                {
                    float vndprice = (float)Convert.ToInt32(usdprice) * Convert.ToInt32(txtRate.Text);
                    txtPartPrice.Text = vndprice.ToString(cboPrecision.SelectedItem.ToString());
                    float vndexportprice = (float)Convert.ToInt32(usdexportprice) * Convert.ToInt32(txtRate.Text);
                    txtExportPrice.Text = vndexportprice.ToString(cboPrecision.SelectedItem.ToString());
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

            string tb = rm.GetString("t1"); // Bạn có muốn thoát tab [ Quản lý giá ] không ?
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtKeySearch.Text != "")
            {
                LoadDataFindPart(txtKeySearch.Text);
            }
            else
            {
                MessageBox.Show(rm.GetString("t2"));    // Bạn cần nhập ô tìm kiếm
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
           // convertusd2vnd();
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            string tb = rm.GetString("t3"); // Bạn có muốn sửa giá của Part không ?
            DialogResult kq = MessageBox.Show(tb, rm.GetString("t0"), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq == DialogResult.Yes)
            {
                allowmodify = true;
                if (rdioVND.Checked == true)
                {
                    txtPartPrice.Enabled = true;
                    txtPartPrice.ReadOnly = false;
                    txtExportPrice.Enabled = true;
                    txtExportPrice.ReadOnly = false;
                    txtPartPrice.Focus();
                }
                else
                {
                    txtUSDPrice.Enabled = true;
                    txtUSDPrice.ReadOnly = false;
                    txtExportPriceUSD.Enabled = true;
                    txtExportPriceUSD.ReadOnly = false;
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
                txtPartPrice.Text = vndprice.ToString("N0");
            }
            else
            {
                txtPartPrice.Text = string.Empty; // Nếu nhập sai định dạng số thì sẽ trả về giá trị = 0
            }
        }

        private void btnSaveNewPrice_Click(object sender, EventArgs e)
        {
            // Kiểm tra giá trị  vndPrice có phải là số nguyên dương hay không ?
            if (int.TryParse(txtPartPrice.Text.Trim().Replace(",",""), out int vndprice) && int.TryParse(txtExportPrice.Text.Trim().Replace(",", ""), out int vndexportprice))
            {
                string tb;
                tb = rm.GetString("t5") + txtPartCode.Text + "]";     // Bạn có muốn update giá của Part Code:  [ 
                tb += " \r\n " + rm.GetString("t6")  + " : " + dgvListTimKiem.CurrentRow.Cells[5].Value.ToString() + " (VND) --- => --- " + txtPartPrice.Text + " --- (VND) ";   // +)  Giá nhập :  
                tb += " \r\n " + rm.GetString("t7") + " : " +  dgvListTimKiem.CurrentRow.Cells[7].Value.ToString() + " (VND) --- => --- " + txtExportPrice.Text + " (VND)   ?"; // +)  Giá xuất : 

                DialogResult kq = MessageBox.Show(tb, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (kq == DialogResult.Yes)
                {
                    if (purchaseBLL.CapnhatPriceBLL(txtPartCode.Text, txtPartPrice.Text.Trim().Replace(",", ""), txtExportPrice.Text.Trim().Replace(",", ""), tennguoidung))
                    {
                        MessageBox.Show(rm.GetString("t8")); // Đã cập nhật thành công giá 
                        LoadDataFindPart(txtPartCode.Text);
                    }
                    else
                    {
                        MessageBox.Show(rm.GetString("t9")); // Cập nhật thất bại
                    }
                }
            }
            else
            {
                MessageBox.Show(rm.GetString("t10"));    // Price đang không hơp lệ 
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
                txtExportPrice.Text = dgvListTimKiem.CurrentRow.Cells[7].Value.ToString(); // ExportPrice
                txtPartPriceLog.Text = dgvListTimKiem.CurrentRow.Cells[8].Value.ToString();
            }
        }

        private void btnMakeNewPO_Click(object sender, EventArgs e)
        {
            frmMakePO frm = new frmMakePO();
            frm._usercurrent = tennguoidung;
            frm.ShowDialog();
        }

        private void btnTraCuuPO_Click(object sender, EventArgs e)
        {
            frmFindPO frm = new frmFindPO();
            frm.ShowDialog();
        }



        /// <summary>
        /// Thêm tính năng cho phần Exportprice
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void txtExportPrice_TextChanged(object sender, EventArgs e)
        {
            // Khi sửa giá trị trong ô này thì ô txtUSDExportPrice cũng sẽ tự động thay đổi
            if (float.TryParse(txtExportPrice.Text, out float vndexportprice))
            {
                // Tính giá sang USD
                float usdexportprice = vndexportprice / float.Parse(txtRate.Text);
                txtExportPriceUSD.Text = usdexportprice.ToString();
            }
            else
            {
                txtExportPriceUSD.Text = string.Empty; // Nếu nhập sai định dạng số thì sẽ trả về giá trị = 0
            }
        }

        private void txtExportPriceUSD_TextChanged(object sender, EventArgs e)
        {
            // Khi sửa giá trị trong ô này thì ô txtExportPrice cũng sẽ tự động thay đổi
            if (float.TryParse(txtExportPriceUSD.Text , out float usdexportprice))
            {
                // Tính giá sang USD
                float vndexportprice = usdexportprice * float.Parse(txtRate.Text);
                txtExportPrice.Text = vndexportprice.ToString("N0");
            }
            else
            {
                txtExportPrice.Text = string.Empty; // Nếu nhập sai định dạng số thì sẽ trả về giá trị = 0
            }
        }

        private void rdioUSD_CheckedChanged(object sender, EventArgs e)
        {
            if(allowmodify == true)
            {
                txtUSDPrice.Enabled = true;
                txtUSDPrice.ReadOnly = false;
                txtExportPriceUSD.Enabled = true;
                txtExportPriceUSD.ReadOnly = false;
                txtUSDPrice.Focus();
            }    


                
        }

        private void rdioVND_CheckedChanged(object sender, EventArgs e)
        {
            if (allowmodify== true)
            {
                txtPartPrice.Enabled = true;
                txtPartPrice.ReadOnly = false;
                txtExportPrice.Enabled = true;
                txtExportPrice.ReadOnly = false;
                txtPartPrice.Focus();
            }
        }
    }
}