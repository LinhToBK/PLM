﻿using System;
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

namespace PLM_Lynx._03_GUI_User_Interface
{
    public partial class frmRelationPart : Form
    {

        private RelationPartBLL relationpartBLL = new RelationPartBLL();
        private CommonBLL commonBLL = new CommonBLL();
        
        DataTable danhcon = new DataTable();
        
        
        
        public frmRelationPart()
        {
            InitializeComponent();
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
            if(txtTimKiem.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập từ khóa vào ô tìm kiếm ");
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
            DialogResult result = MessageBox.Show("Bạn muốn thoát việc tạo liên kết giữa các Part phải không ?","Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes) 
            { this.Close(); } // Đóng cửa sổ hiện tại 
            else 
            { return; } // Không làm gì cả

        }

        private void dgvListTimKiem_Click(object sender, EventArgs e)
        {
            // Khi Click 1 vào ô thì cần lấy hình ảnh của partcode đang trỏ để hiển thị lên Picturebox


            // - Nếu dgvListTimKiem trống thì thông báo và quay lại ô tìm kiếm
            if(dgvListTimKiem.Rows.Count == 0 )
            {
                MessageBox.Show("Không tìm thấy dữ liệu phù hợp "); 
                txtTimKiem.Focus();
                return;
            }

            // Nếu tìm thấy - Tìm kiếm hình ảnh
            string imagefilepath = Properties.Settings.Default.LinkDataPart;
            string Partcode = dgvListTimKiem.CurrentRow.Cells[0].Value.ToString(); // Code : XXX-000YY
            //string Partcode = txtCode.Text;
            string[] input = Partcode.Split('-');
            string filepath = imagefilepath + "\\" + input[0] + "\\" + input[1];
            imagefilepath = imagefilepath + "\\" + input[0] + "\\" + input[1] + "\\" + Partcode + ".jpg";
            

            // Kiểm tra file có tồn tại
            if (System.IO.File.Exists(imagefilepath))
            {
                picTimKiem.SizeMode = PictureBoxSizeMode.StretchImage;
                using (Image newimage = Image.FromFile(imagefilepath))
                {
                    // Nếu có thì copy và hiển thị lên trên Picturebox
                    picTimKiem.Image = (Image)newimage.Clone();
                    txtStatusImagePart.Text = "Image is : ";

                }

            }
            else
            {
                txtStatusImagePart.Text = "Not found image";
                picTimKiem.Image = null;
            }
        }

        private void dgvListTimKiem_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Nếu Click đúp vào Cell trong dgvListTimKiem
            // Thì sẽ hiển thị form chi tiết của Part đang trỏ

            if(e.RowIndex >= 0)
            {
                // Lấy PartCode
                string PartCode = dgvListTimKiem.CurrentRow.Cells[0].Value.ToString(); // Code : XXX-000YY 


                // Mở Form Detail
                frmRelationPart_Detail_Info detailinfo = new frmRelationPart_Detail_Info();
                
                detailinfo.ShowDetailInfor(PartCode);
                detailinfo.ShowDialog();


            } 
                
        }

        private void btnAdd2Parent_Click(object sender, EventArgs e)
        {
            // Lấy dữ liệu của dgvListTimKiem để đẩy lên các ô textbox của vùng Parrent
            if(dgvListTimKiem.Rows.Count == 0)
            {
                MessageBox.Show("Không có giá trị để thêm vào ");;
                txtTimKiem.Focus();
                return;
            } 

            string partcode = dgvListTimKiem.CurrentRow.Cells[0].Value.ToString() ;
            string partname = dgvListTimKiem.CurrentRow.Cells[1].Value.ToString();
            string partdescript = dgvListTimKiem.CurrentRow.Cells[2].Value.ToString();
            
            // Kiểm tra xem partcode này có trong dgvChild không, nếu có thì thoát
            bool isDuplicate = false ;
            foreach (DataGridViewRow row in dgvChild.Rows)
            {
                // Kiểm tra giá trị của cột đầu tiên
                if (row.Cells[0] !=null && row.Cells[0].Value.ToString() == partcode)
                {
                    isDuplicate = true ;
                 
                    break;
                }    
            }    

            // Nếu không trùng thì mới thêm vào 
            if(isDuplicate == true )
            {
                MessageBox.Show("Giá trị này đã có trong danh sách con ");
                return;
            }  
            else
            {
                txtPartCode.Text = partcode;
                txtPartName.Text = partname;
                txtPartDescripts.Text = partdescript;
                // Đẩy danh sách file 
                if(commonBLL.GetAllFileinFolder(partcode,dgvListFile) == true)
                {
                    txtListFileStatus.Text = "Danh sách file ở bên dưới ";
                }    
                else
                {
                    txtListFileStatus.Text = "Có vẻ không load được danh sách file";
                } 
                // Load ảnh 
                if(commonBLL.UploadImagebyPartCode(partcode,picParent) == false)
                {
                    MessageBox.Show("Không load được ảnh ");
                }    
            }    
        }

        private void frmRelationPart_Load(object sender, EventArgs e)
        {
            //dgvChild.ColumnCount = 3;
            //dgvChild.Columns.Add("ColumnPartCode", "Part Code");
            //dgvChild.Columns.Add("ColumnPartName", "Part Name");
            //dgvChild.Columns.Add("ColumnQuantity", "Quantity");

            //dgvChild = new DataGridView();
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
                MessageBox.Show("Lỗi phát sinh khi  mở file : " + ex.Message);
            }

            ////-- Thử chạy trực tiếp
            //try
            //{
            //    //Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.Open(dwgFilePath, false);
            //    //Autodesk.Windows.DocumentView.Large.Equals(dwgFilePath);
            //    // Đường dẫn tới ứng dụng DWG TrueView
            //    string dwgTrueViewPath = @"C:\Program Files\Autodesk\DWG TrueView 2022 - English\dwgviewr.exe";
            //    // "C:\Program Files\Autodesk\DWG TrueView 2022 - English\dwgviewr.exe"
            //    MessageBox.Show("Tên File là : " + filename);
            //    try
            //    {
            //        // Khởi chạy ứng dụng với tệp .dwg
            //        Process.Start(dwgTrueViewPath, $"\"{filename}\"");
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show($"Không thể mở tệp: {ex.Message}");
            //    }
            //}
            //catch (System.Exception ex)
            //{
            //    MessageBox.Show("Lỗi khi dùng hàm Open File : " + ex.Message);
            //}

            //// -- End : Thử chạy trực tiếp

        }

        private void btnAddChild_Click(object sender, EventArgs e)
        {
            // Thêm vào dgvChild
            if(dgvListTimKiem.Rows.Count ==0)
            {
                MessageBox.Show("Không có đối tượng part trong danh sách tìm kiếm \n Hãy nhập từ khóa tìm kiếm");
                txtTimKiem.Focus();
                return;
            }
                                             
            string partcode = dgvListTimKiem.CurrentRow.Cells[0].Value.ToString();
            string partname = dgvListTimKiem.CurrentRow.Cells[1].Value.ToString();
            if(partcode == txtPartCode.Text)
            {
                MessageBox.Show("Lỗi : Trùng với Part Cha ");
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
                    MessageBox.Show("Giá trị này đã thêm vào danh sách con rồi ");
                    return;
                }
                else
                {
                    // Nếu không trùng thì mới thêm vào
                    MessageBox.Show("Sẽ thêm : || " + partcode + " || vào danh sách Part Child");
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
            if(dgvChild.SelectedRows.Count >0)
            {
                DialogResult result = MessageBox.Show("Bạn muốn xóa dòng này phải không", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    foreach(DataGridViewRow rw in dgvChild.SelectedRows)
                    {
                        if(!rw.IsNewRow)
                        {
                            dgvChild.Rows.Remove(rw);
                        }    
                    }    
                } 
                else
                {
                    MessageBox.Show("Đang chưa chọn dòng nào để xóa");
                }    
                    
            }    
        }

        private void btnClearChild_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn muốn xóa toàn bộ dữ liệu của List Child phải không ?","", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                if(dgvChild.DataSource is DataTable dt)
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
    }
}
