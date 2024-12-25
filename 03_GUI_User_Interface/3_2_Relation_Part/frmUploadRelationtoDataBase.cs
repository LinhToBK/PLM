using PLM_Lynx._02_BLL_Bussiness_Logic_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PLM_Lynx._03_GUI_User_Interface._3_2_Relation_Part
{
    public partial class frmUploadRelationtoDataBase : Form
    {

        private RelationPartBLL relationBLL = new RelationPartBLL();
        public frmUploadRelationtoDataBase()
        {
            InitializeComponent();
            btnUpload.Enabled = false; // Ban đầu khi khởi động thì phải khóa  Upload dữ liệu

        }

        // =============================================
        // ============== CÁC HÀM TỰ TẠO ===============
        // =============================================


        /// <summary>
        /// 01. Hàm Lấy DataChild từ Form : RelationPart và hiển thị lên Form hiện tại
        /// </summary>
        /// <param name="parentcode"></param>
        /// <param name="parentname"></param>
        /// <param name="ListChild"></param>
        public void LayDatafrom_frmRelationPart (string parentcode,string parentname, DataTable ListChild)
        {
            txtParentCode.Text = parentcode;
            txtParentName.Text = parentname;
            //dgvListChild.DataSource = ListChild;
            dgvListChild.AllowUserToAddRows = false;
            dgvListChild.EditMode = DataGridViewEditMode.EditProgrammatically;
            int UpdateStatus = 0;


            // Thêm 1 cột Status  để kiểm tra trạng thái , nếu có rồi thì không thêm
            if(!ListChild.Columns.Contains("Status"))
            {
                   ListChild.Columns.Add("Status", typeof(string));
            }    
            

            // Bước 1 : Kiểm tra xem cột Quantity có âm không,, nếu âm thì thông báo những đội tượng âm

            foreach (DataRow dr in ListChild.Rows)
            {
                if (IsNguyenDuong(dr[2].ToString()))
                {
                    // Nếu là số nguyên dương  thì kiểm tra việc trùng lặp trong cơ ở dữ liệu không
                    if(relationBLL.CheckPartChild(parentcode, dr[0].ToString()))
                    {
                        dr["Status"] = "Đã trùng với 1 Part Con trong DataBase";
                        UpdateStatus = UpdateStatus + 1;
                    } 
                    else
                    {
                        if(relationBLL.CheckPartParent(parentcode, dr[0].ToString()))
                        {
                            dr["Status"] = "Đã trùng với 1 Part Child trong DataBase";
                            UpdateStatus = UpdateStatus + 1;    
                        }  
                        else
                        {
                            dr["Status"] = "OK";
                        }    
                            
                    }    

                } 
                else
                {
                    dr["Status"] = "Quantity đang không phải là số nguyên dương";
                    UpdateStatus = UpdateStatus + 1;
                }    
                    
            } 
            dgvListChild.DataSource = ListChild;

            if(UpdateStatus ==0) { btnUpload.Enabled = true; }
        }


        /// <summary>
        /// 02. Hàm kiểm tra là số nguyên dương hay không ?
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private bool IsNguyenDuong(string quantity)
        {
            if(int.TryParse(quantity, out int number))
            {
                return number > 0; // Kiểm tra số nguyên dương 
            } 
            return false;
                
        }



        // =============================================
        // =============================================


        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            string thongbao = @"Bạn có muốn upload Relation này lên trên DataBase hay không ? ";

            DialogResult kq = MessageBox.Show(thongbao, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(kq == DialogResult.Yes)
            {
                // Thực hiện việc upload dữ liệu lên database
                string thongbao2;
                thongbao2 = "Ghi chú việc cập nhật \n";
                foreach ( DataGridViewRow dr in dgvListChild.Rows)
                {
                    try
                    {
                        // Kiểm tra giá trị và xử lý trước khi truyền vào BLL
                        if (dr.Cells[0].Value != null && dr.Cells[2].Value != null)
                        {
                            string childCode = dr.Cells[0].Value.ToString();
                            int quantity = int.Parse(dr.Cells[2].Value.ToString());

                            // Gọi BLL để insert
                            if (relationBLL.InsertNewRelationBLL(txtParentCode.Text, childCode, quantity))
                            {
                                thongbao2 =  thongbao2 + "(+) Đã upload --" + txtParentCode.Text + "---" + childCode +" -- thành công \n";
                                this.Close() ; // Nếu thành công thì tắt luôn form
                            }
                            else
                            {
                                thongbao2 = thongbao2 + "(-) Lỗi: --  + txtParentCode + \"---\" + childCode +\" -- không upload được. \n";
                            }
                        }
                        else
                        {
                            thongbao2 += "(*) Lỗi: Dữ liệu dòng không hợp lệ hoặc thiếu giá trị. \n";
                        }
                    }
                    catch (Exception ex)
                    {
                        thongbao2 += $"(!) Lỗi ngoại lệ: {ex.Message} \n";
                    }

                }
                MessageBox.Show(thongbao2);

            }
            else
            {
                return;
            } 
                
                
        }
    }
}
