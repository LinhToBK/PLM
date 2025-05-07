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
    public partial class frmSiemenNX : Form
    {
        public frmSiemenNX()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult kq = MessageBox.Show("Bạn có muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq == DialogResult.Yes)
            {
                this.Close();
            }
        }

        string foldercommon = Environment.CurrentDirectory + @"\04_CommonDoc\";
                    

        private void frmSiemenNX_Load(object sender, EventArgs e)
        {

        }

        private void btnImage_Click(object sender, EventArgs e)
        {
            // Copy file vào thư mục mới
            SaveFileDialog sv = new SaveFileDialog();
            sv.RestoreDirectory = true;
            sv.Title = "Lưu file VB cho export image và BOM ";
            sv.Filter = "VB files (*.vb)|*.vb|All files (*.*)|*.*";

            string sourcefile = foldercommon + "NX_Export_Image_And_Excel.txt";
            

            if (!System.IO.File.Exists(sourcefile))
            {
                MessageBox.Show("Không tìm thấy file nguồn: " + sourcefile, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (sv.ShowDialog() == DialogResult.OK)
            {
                string fileName = sv.FileName;
                string destinationfile = fileName;
                if (!destinationfile.EndsWith(".vb", StringComparison.OrdinalIgnoreCase))
                {
                    destinationfile += ".vb";
                }

                try
                {
                    System.IO.File.Copy(sourcefile, destinationfile, true);
                    MessageBox.Show("Đã lưu file .vb cho export image và BOM thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi sao chép file: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void btnDWG_Click(object sender, EventArgs e)
        {
            // Copy file vào thư mục mới
            SaveFileDialog sv = new SaveFileDialog();
            sv.RestoreDirectory = true;
            sv.Title = "Lưu file C Sharp cho export .dwg file";
            sv.Filter = "CS files (*.cs)|*.cs|All files (*.*)|*.*";

            string sourcefile = foldercommon + "Export DWG.txt";


            if (!System.IO.File.Exists(sourcefile))
            {
                MessageBox.Show("Không tìm thấy file nguồn: " + sourcefile, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (sv.ShowDialog() == DialogResult.OK)
            {
                string fileName = sv.FileName;
                string destinationfile = fileName;
                if (!destinationfile.EndsWith(".cs", StringComparison.OrdinalIgnoreCase))
                {
                    destinationfile += ".cs";
                }

                try
                {
                    System.IO.File.Copy(sourcefile, destinationfile, true);
                    MessageBox.Show("Đã lưu file .cs cho export .dwg file thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi sao chép file: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void btnPDF_Click(object sender, EventArgs e)
        {
            // Copy file vào thư mục mới
            SaveFileDialog sv = new SaveFileDialog();
            sv.RestoreDirectory = true;
            sv.Title = "Lưu file C Sharp cho export .pdf file";
            sv.Filter = "CS files (*.cs)|*.cs|All files (*.*)|*.*";

            string sourcefile = foldercommon + "Export PDF.txt";


            if (!System.IO.File.Exists(sourcefile))
            {
                MessageBox.Show("Không tìm thấy file nguồn: " + sourcefile, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (sv.ShowDialog() == DialogResult.OK)
            {
                string fileName = sv.FileName;
                string destinationfile = fileName;
                if (!destinationfile.EndsWith(".cs", StringComparison.OrdinalIgnoreCase))
                {
                    destinationfile += ".cs";
                }

                try
                {
                    System.IO.File.Copy(sourcefile, destinationfile, true);
                    MessageBox.Show("Đã lưu file .cs cho export .pdf file thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi sao chép file: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSTEP_Click(object sender, EventArgs e)
        {
            // Copy file vào thư mục mới
            SaveFileDialog sv = new SaveFileDialog();
            sv.RestoreDirectory = true;
            sv.Title = "Lưu file C Sharp cho export .step file";
            sv.Filter = "CS files (*.cs)|*.cs|All files (*.*)|*.*";

            string sourcefile = foldercommon + "Save As Step File.txt";


            if (!System.IO.File.Exists(sourcefile))
            {
                MessageBox.Show("Không tìm thấy file nguồn: " + sourcefile, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (sv.ShowDialog() == DialogResult.OK)
            {
                string fileName = sv.FileName;
                string destinationfile = fileName;
                if (!destinationfile.EndsWith(".cs", StringComparison.OrdinalIgnoreCase))
                {
                    destinationfile += ".cs";
                }

                try
                {
                    System.IO.File.Copy(sourcefile, destinationfile, true);
                    MessageBox.Show("Đã lưu file .cs cho export .step file thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi sao chép file: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnNX10_Click(object sender, EventArgs e)
        {
            SaveFileDialog sv = new SaveFileDialog();
            sv.RestoreDirectory = true;
            sv.Title = "Lưu file VB cho export .dwg file ";
            sv.Filter = "VB files (*.vb)|*.vb|All files (*.*)|*.*";

            string sourcefile = foldercommon + "Export_Drawing_NX10.txt";


            if (!System.IO.File.Exists(sourcefile))
            {
                MessageBox.Show("Không tìm thấy file nguồn: " + sourcefile, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (sv.ShowDialog() == DialogResult.OK)
            {
                string fileName = sv.FileName;
                string destinationfile = fileName;
                if (!destinationfile.EndsWith(".vb", StringComparison.OrdinalIgnoreCase))
                {
                    destinationfile += ".vb";
                }

                try
                {
                    System.IO.File.Copy(sourcefile, destinationfile, true);
                    MessageBox.Show("Đã lưu file .vb cho export .dwg file thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi sao chép file: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            SaveFileDialog sv = new SaveFileDialog();
            sv.RestoreDirectory = true;
            sv.Title = "Lưu file VB cho xử lý trên Excel ";
            sv.Filter = "VB files (*.vb)|*.vb|All files (*.*)|*.*";

            string sourcefile = foldercommon + "Excel_Handle.txt";


            if (!System.IO.File.Exists(sourcefile))
            {
                MessageBox.Show("Không tìm thấy file nguồn: " + sourcefile, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (sv.ShowDialog() == DialogResult.OK)
            {
                string fileName = sv.FileName;
                string destinationfile = fileName;
                if (!destinationfile.EndsWith(".vb", StringComparison.OrdinalIgnoreCase))
                {
                    destinationfile += ".vb";
                }

                try
                {
                    System.IO.File.Copy(sourcefile, destinationfile, true);
                    MessageBox.Show("Đã lưu file .vb  thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi sao chép file: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnPartlist_Click(object sender, EventArgs e)
        {
            //SaveFileDialog sv = new SaveFileDialog();
            //sv.RestoreDirectory = true;
            //sv.Title = "Lưu file VBA cho xử lý Partlist trên Excel";
            //string sourcefilefrm = foldercommon + "BOM_to_Partlist.frm";
            //string sourcefilebfrx = foldercommon + "BOM_to_Partlist.frx";
            //if(sv.ShowDialog() == DialogResult.OK)
            //{
            //    string fileName = sv.FileName;
            //    string destinationfilefrm = fileName + ".frm";
            //    string destinationfilebfrx = fileName + ".frx";
            //    System.IO.File.Copy(sourcefilefrm, destinationfilefrm, true);
            //    System.IO.File.Copy(sourcefilebfrx, destinationfilebfrx, true);
            //    MessageBox.Show("Đã lưu file .frm và .frx cho xử lý Partlist trên Excel thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}

            SaveFileDialog sv = new SaveFileDialog();
            sv.RestoreDirectory = true;
            sv.Title = "Lưu file VBA cho xử lý Partlist trên Excel";
            sv.Filter = "VBA files (*.frm)|*.frm|All files (*.*)|*.*";


            string sourcefile = foldercommon + "BOM_to_Partlist.frm";
            string sourcefilebfrx = foldercommon + "BOM_to_Partlist.frx";   


            if (!System.IO.File.Exists(sourcefile))
            {
                MessageBox.Show("Không tìm thấy file nguồn: " + sourcefile, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (sv.ShowDialog() == DialogResult.OK)
            {
                string fileName = sv.FileName;
                string destinationfile = fileName;
                string foldersave = System.IO.Path.GetDirectoryName(destinationfile);

                if (!destinationfile.EndsWith(".frm", StringComparison.OrdinalIgnoreCase))
                {
                    destinationfile += ".frm";
                    
                }

                

                try
                {
                    System.IO.File.Copy(sourcefile, destinationfile, true);
                    string namefile = System.IO.Path.GetFileNameWithoutExtension(destinationfile);
                    string destinationfilebfrx = System.IO.Path.Combine(foldersave, namefile + ".frx");
                    
                    System.IO.File.Copy(sourcefilebfrx, destinationfilebfrx, true);
                    MessageBox.Show("Đã lưu file VBA thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi sao chép file: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }



        }
    }
}
