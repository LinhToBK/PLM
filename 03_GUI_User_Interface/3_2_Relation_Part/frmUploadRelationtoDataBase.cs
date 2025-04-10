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
using Newtonsoft.Json;

//using Microsoft.Office.Interop.Excel;

namespace PLM_Lynx._03_GUI_User_Interface._3_2_Relation_Part
{
    public partial class frmUploadRelationtoDataBase : Form
    {
        private RelationPartBLL relationBLL = new RelationPartBLL();
        private ECO_BLL _ecoBLL = new ECO_BLL();
        public int idProposal { get; set; } // ID của Proposal để truyền vào BLL
        public string nameProposal { get; set; }  // Tên của Proposal để truyền vào BLL

        public frmUploadRelationtoDataBase()
        {
            InitializeComponent();
            btnUpload.Enabled = false; // Ban đầu khi khởi động thì phải khóa  Upload dữ liệu
        }

        private DataTable DataECOContent;
        private string ECOContent { get; set; }

        // =============================================
        // ============== CÁC HÀM TỰ TẠO ===============
        // =============================================

        /// <summary>
        /// 01. Hàm Lấy DataChild từ Form : RelationPart và hiển thị lên Form hiện tại
        /// </summary>
        /// <param name="parentcode"></param>
        /// <param name="parentname"></param>
        /// <param name="ListChild"></param>
        public void LayDatafrom_frmRelationPart(string parentcode, string parentname, DataTable ListChild)
        {
            txtParentCode.Text = parentcode;
            txtParentName.Text = parentname;
            //dgvListChild.DataSource = ListChild;
            dgvListChild.AllowUserToAddRows = false;
            dgvListChild.EditMode = DataGridViewEditMode.EditProgrammatically;
            int UpdateStatus = 0;

            // Thêm 1 cột Status  để kiểm tra trạng thái , nếu có rồi thì không thêm
            if (!ListChild.Columns.Contains("Status"))
            {
                ListChild.Columns.Add("Status", typeof(string));
            }

            // Bước 1 : Kiểm tra xem cột Quantity có âm không,, nếu âm thì thông báo những đội tượng âm

            foreach (DataRow dr in ListChild.Rows)
            {
                string tb = "OK";
                bool statusNguyenDuong = true;
                if ((IsNguyenDuong(dr[2].ToString()) == false))
                {
                    tb = "Quantity đang không phải là số nguyên dương";
                    statusNguyenDuong = false;
                    UpdateStatus = UpdateStatus + 1;
                }
                if (statusNguyenDuong == true)
                {
                    // Check trùng lặp trong tblRelation
                    if (relationBLL.CheckPartChild(parentcode, dr[0].ToString()))
                    {
                        tb = "Đã trùng với 1 Part Con trong DataBase";
                        UpdateStatus = UpdateStatus + 1;
                    }
                    if (relationBLL.CheckPartParent(parentcode, dr[0].ToString()))
                    {
                        tb = "Đã trùng với 1 Part Parent trong DataBase";
                        UpdateStatus = UpdateStatus + 1;
                    }
                    if (relationBLL.CheckPartChild_in_tblRelationTemp_BLL(parentcode, dr[0].ToString()))
                    {
                        tb = "Đã trùng với 1 Part Con trong danh sách chờ phê duyệt ECO ";
                        UpdateStatus = UpdateStatus + 1;
                    }
                    if (relationBLL.CheckPartParent_in_tblRelationTemp_BLL(parentcode, dr[0].ToString()))
                    {
                        tb = "Đã trùng với 1 Part Parent trong danh sách chờ phê duyệt ECO";
                        UpdateStatus = UpdateStatus + 1;
                    }
                }

                dr["Status"] = tb; // Gán lại giá trị cho cột Status

                //if (IsNguyenDuong(dr[2].ToString()))
                //{
                //    // Nếu là số nguyên dương  thì kiểm tra việc trùng lặp trong cơ ở dữ liệu không
                //    // Trường hợp 1 : Kiểm tra việc trùng lặp trong tblRelation
                //    string tb;
                //    if(relationBLL.CheckPartChild(parentcode, dr[0].ToString()))
                //    {
                //        //dr["Status"] = "Đã trùng với 1 Part Con trong DataBase";
                //        //UpdateStatus = UpdateStatus + 1;
                //        tb = "Đã trùng với 1 Part Con trong DataBase";
                //    }
                //    else
                //    {
                //        if(relationBLL.CheckPartParent(parentcode, dr[0].ToString()))
                //        {
                //            dr["Status"] = "Đã trùng với 1 Part Child trong DataBase";
                //            UpdateStatus = UpdateStatus + 1;
                //        }
                //        else
                //        {
                //            dr["Status"] = "OK";
                //        }

                //    }

                //    // Trường hợp 2 :

                //}
                //else
                //{
                //    dr["Status"] = "Quantity đang không phải là số nguyên dương";
                //    UpdateStatus = UpdateStatus + 1;
                //}
            }
            dgvListChild.DataSource = ListChild;

            if (UpdateStatus == 0)
            {
                btnUpload.Enabled = true;
                GetECOContent(ListChild, parentcode);
            }
        }

        /// <summary>
        /// 02. Hàm kiểm tra là số nguyên dương hay không ?
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private bool IsNguyenDuong(string quantity)
        {
            if (int.TryParse(quantity, out int number))
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
            string thongbao = @"Bạn có muốn tạo ràng buộc giữa các Part này hay không ? ";

            DialogResult kq = MessageBox.Show(thongbao, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq == DialogResult.Yes)
            {
                // Bước 1 : Tạo 1 file để insert vào tblECO,
                string jsonfile = JsonConvert.SerializeObject(DataECOContent, Formatting.Indented);
                //MessageBox.Show(jsonfile);
                int ECONo = _ecoBLL.LoadECONo();
                if (_ecoBLL.InsertNewECO_BLL(ECONo, idProposal, nameProposal, 3, jsonfile) == true && InsertRequest_to_tblRelationTemp())
                {
                    MessageBox.Show("Tạo request : [Thêm ràng buộc thành công ] \n Hãy thông báo cho quản lý để phê duyệt ");
                    this.Close(); // Nếu thành công thì tắt luôn form

                }
                else
                {
                    MessageBox.Show("Phát sinh lỗi khi tạo ràng buộc mới giữa các part ");
                }

                // Bước 2 : Nếu OK thì sẽ insert các giá trị vào tblRelationTemp

                // ============= Đây là code cũ  =============================
                //string jsonfile = ConvertDataGridViewToJson(dgvListItem);
                //string POPartlist = jsonfile.Replace("\r", "").Replace("\n  ", "");
                // ==============================================================
                //try
                //{
                //    // Kiểm tra giá trị và xử lý trước khi truyền vào BLL
                //    if (dr.Cells[0].Value != null && dr.Cells[2].Value != null)
                //    {
                //        string childCode = dr.Cells[0].Value.ToString();
                //        int quantity = int.Parse(dr.Cells[2].Value.ToString());

                //        // Gọi BLL để insert
                //        if (relationBLL.InsertNewRelationBLL(txtParentCode.Text, childCode, quantity))
                //        {
                //            thongbao2 =  thongbao2 + "(+) Đã upload --" + txtParentCode.Text + "---" + childCode +" -- thành công \n";
                //            this.Close() ; // Nếu thành công thì tắt luôn form
                //        }
                //        else
                //        {
                //            thongbao2 = thongbao2 + "(-) Lỗi: --  + txtParentCode + \"---\" + childCode +\" -- không upload được. \n";
                //        }
                //    }
                //    else
                //    {
                //        thongbao2 += "(*) Lỗi: Dữ liệu dòng không hợp lệ hoặc thiếu giá trị. \n";
                //    }
                //}
                //catch (Exception ex)
                //{
                //    thongbao2 += $"(!) Lỗi ngoại lệ: {ex.Message} \n";
                //}
            }
            else
            {
                return;
            }
        }

        private void GetECOContent(DataTable DataListChild, string parentcode)
        {
            // Copy các cột từ originalTable, trừ cột "Tuổi"
            DataTable newTable = new DataTable();
            foreach (DataColumn col in DataListChild.Columns)
            {
                if (col.ColumnName != "PartName" && col.ColumnName != "Status")
                {
                    newTable.Columns.Add(col.ColumnName, col.DataType);
                }
            }

            // Copy dữ liệu từng dòng, trừ cột "Tuổi"
            foreach (DataRow row in DataListChild.Rows)
            {
                DataRow newRow = newTable.NewRow();
                foreach (DataColumn col in newTable.Columns)
                {
                    newRow[col.ColumnName] = row[col.ColumnName];
                }
                newTable.Rows.Add(newRow);
            }

            // Thêm dữ liệu parentcode  cho hàng đầu tiên
            DataRow Row = newTable.NewRow();
            Row["PartCode"] = parentcode;
            Row["Quantity"] = 1;

            // Thêm vào vị trí đầu tiên (index 0)
            newTable.Rows.InsertAt(Row, 0);

            // Gán DataTable mới vào biến DataECOContent
            DataECOContent = newTable;
        }

        private bool InsertRequest_to_tblRelationTemp()
        {
            bool insertstatus = false;
            foreach (DataGridViewRow dr in dgvListChild.Rows)
            {
                try
                {
                    // Kiểm tra giá trị và xử lý trước khi truyền vào BLL
                    if (dr.Cells[0].Value != null && dr.Cells[2].Value != null)
                    {
                        string childCode = dr.Cells[0].Value.ToString();
                        int quantity = int.Parse(dr.Cells[2].Value.ToString());

                        // Gọi BLL để insert
                        if (_ecoBLL.InsertNewRelation_in_tblRelationTemp_BLL(txtParentCode.Text, childCode, quantity))
                        {
                            insertstatus = true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    insertstatus = false;
                    MessageBox.Show(ex.Message);
                }
            }

            return insertstatus;
        }
    }
}