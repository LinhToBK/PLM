using Newtonsoft.Json;
using PLM_Lynx._02_BLL_Bussiness_Logic_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PLM_Lynx._03_GUI_User_Interface._3_3_ECO
{
    public partial class frmModifyQuantity : Form
    {
        private ECO_BLL ecoBLL = new ECO_BLL();
        public frmModifyQuantity()
        {
            InitializeComponent();
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

            string tb = "Bạn có muốn tạo request cập nhật số lương không ?";
            tb = tb + "\nParentCode : " + parentcode;
            tb = tb + "\nChildCode : " + childcode;
            tb = tb + "\n Từ : " + oldquantity + " => " + newquantity;

            DialogResult kq = MessageBox.Show(tb, "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq == DialogResult.No)
            {
                return;
            }
            else
            {
                // Bước 2 : Thực hiện cập nhật ECO
                if (ecoBLL.InsertNewECO_BLL(ECONo, idnguoiyeucau, tennguoiyc, ECOTypeID, ECOContent))
                {
                    MessageBox.Show("Tạo ECO thành công");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Xuất hiện lỗi khi tạo ECO \n Kiểm tra lại dữ liệu");
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
    }
}
