using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PLM_Lynx._03_GUI_User_Interface._3_4_FindPart
{
    public partial class frmFilterSearch : Form
    {

        private List<string> DulieuBandau;
        public List<string> DanhsachFamilyCodeOK { get; private set; } = new List<string>();
        public frmFilterSearch(List<string> giatri)
        {
            InitializeComponent();
            DulieuBandau = giatri;    
        }

        
        



        // ==> Xây dựng hàm load dữ liệu từ DataGridView lên trên CheckedListbox
        public void LoadDatatoCheckList (DataTable dt)
        {
            // Xóa dữ liệu cũ trong CheckListBox ( nếu có )
            ckclstFilterPartCode.Items.Clear();

            // Duyệt qua từng hàng trong DataGridview
            
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (ckclstFilterPartCode.CheckedItems.Count > 0)
            {
                if(ckcPartCodeAll.Checked==true)
                {
                    // Nếu chọn là all
                    DanhsachFamilyCodeOK = DulieuBandau;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }  
                else
                {
                    DanhsachFamilyCodeOK = ckclstFilterPartCode.CheckedItems.Cast<string>().ToList();
                    this.DialogResult = DialogResult.OK;
                    this.Close ();
                }    


            }
            else
            {
                // Nếu không chọn gì
                MessageBox.Show("Bạn đang chưa chọn FamilyCode nào để lọc cả ");
            }    

        }

   

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close ();
        }

        private void frmFilterSearch_Load(object sender, EventArgs e)
        {
            // Hiển thị dữ liệu vào CheckedListBox
            foreach (var item in DulieuBandau)
            {
                string partcode = item.ToString();
                string[] codesplit = partcode.Split('-');
                string familycode = codesplit[0];
                
                // Kiểm tra nếu không có code thì thêm vào
                if(!ckclstFilterPartCode.Items.Contains(familycode))
                {
                    ckclstFilterPartCode.Items.Add(familycode);
                }    
            } 
                
        }

        private void ckcPartCodeAll_CheckedChanged(object sender, EventArgs e)
        {
            // Duyệt qua tất cả các mục trong CheckListBox
            for (int i = 0; i < ckclstFilterPartCode.Items.Count; i++)
            {
                // Nếu "All " được check thì đặt tất cả các mục thành true
                ckclstFilterPartCode.SetItemChecked(i, ckcPartCodeAll.Checked);
            } 
                
        }
    }
}
