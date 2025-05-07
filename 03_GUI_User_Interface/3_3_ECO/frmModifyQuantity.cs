using Newtonsoft.Json;
using PLM_Lynx._02_BLL_Bussiness_Logic_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
    public partial class frmModifyQuantity : Form
    {
        private ECO_BLL ecoBLL = new ECO_BLL();

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

            rm = new ResourceManager("PLM_Lynx._03_GUI_User_Interface._3_3_ECO.Lang.Lange_ModifyQuantity", typeof(frmModifyQuantity).Assembly);
            // Hiển thị ngôn ngữ lên các điều khiển trong form
            this.Text = rm.GetString("i.form");
            labelTilte.Text = rm.GetString("lb1");
            labelParent.Text = rm.GetString("lb2");
            labelChild.Text = rm.GetString("lb3");
            labelOldQuantity.Text = rm.GetString("lb4");
            labelNewQuantity.Text = rm.GetString("lb5");
            btnUpdate.Text = rm.GetString("lb6");





            Properties.Settings.Default.Language = lang;
            Properties.Settings.Default.Save();
        }

        // =========== Language =========================
        public frmModifyQuantity()
        {
            InitializeComponent();
            LoadLanguage();
        }

        public string parentcode { get; set; }
        public string parentname { get; set; }
        public string childcode { get; set; }
        public string childname { get; set; }
        public string  oldquantity { get; set; }
        public string  newquantity { get; set; }
        public int idnguoiyeucau { get; set; } // ID người yêu cầu ECO này
        public string tennguoiyc { get; set; } // Tên người yêu cầu ECO này

        public void CapnhatControlModifyQuantity()
        {
            txtParentCode.Text = parentcode;
            txtParentName.Text = parentname;
            txtChildCode.Text = childcode;
            txtChildName.Text = childname;
            txtOldQuantity.Text = oldquantity;
            txtNewQuantity.Text = newquantity;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Đẩy dữ liệu này lên tblRelationTemp => Việc này có vẻ không cần thiết
            // Đồng thời , tạo ECONo cho việc phê duyệt
            int ECONo = ecoBLL.LoadECONo();
            

            List<Tuple<string, object>> tableData = new List<Tuple<string, object>>
                {
                    new Tuple<string, object>("ParentCode", parentcode),
                    new Tuple<string, object>("ChildCode", childcode),
                    new Tuple<string, object>("Quantity", Convert.ToInt32(newquantity))

                };
            Dictionary<string, object> jsonData = new Dictionary<string, object>();
            foreach (var row in tableData)
            {
                jsonData[row.Item1] = row.Item2;
            }

            // Chuyển thành chuỗi JSON
            string ECOContent = JsonConvert.SerializeObject(jsonData, Formatting.Indented);
            ECOContent = "[" + ECOContent + "]";
            int ECOTypeID = 4 ; // 4 là ECO cho sửa số lượng Part

            string tb = rm.GetString("t1");
            tb = tb + "\r\n ParentCode : " + parentcode;
            tb = tb + "\r\n ChildCode : " + childcode;
            tb = tb + "\r\n Old Quantity : " + oldquantity + " => New Quantity " + newquantity;

            DialogResult kq = MessageBox.Show(tb, rm.GetString("t0"), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq == DialogResult.No)
            {
                return;
            }
            else
            {
                // Bước 2 : Thực hiện cập nhật ECO
                if (ecoBLL.InsertNewECO_BLL(ECONo, idnguoiyeucau, tennguoiyc, ECOTypeID, ECOContent))
                {
                    MessageBox.Show(rm.GetString("t2"));      // Tạo ECO thành công
                    this.Close();
                }
                else
                {
                    MessageBox.Show(rm.GetString("t3"));  // Xuất hiện lỗi khi tạo ECO \n Kiểm tra lại dữ liệu
                    return;
                }
            }    

            // if(ecoBLL.InsertNewECO_BLL(ECONo, idnguoiyeucau, tennguoiyc,))

            // Bước 1 : Kiểm tra xem 

            //if(ecoBLL.CapnhatQuantityBLL(txtParentCode.Text, txtChildCode.Text, Convert.ToInt32(txtNewQuantity.Text)))
            //{
            //    MessageBox.Show("Cập nhật Quantity = " + txtNewQuantity.Text + " của Part " + txtChildCode.Text + " thành công");
            //    this.Close();
            //}    
            //else
            //{
            //    MessageBox.Show("Xuất hiện lỗi khi cập nhật \n Kiểm tra lại dữ liệu");
            //    return;
            //}    


        }

        private void frmModifyQuantity_Load(object sender, EventArgs e)
        {
            CapnhatControlModifyQuantity();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtOldQuantity_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
