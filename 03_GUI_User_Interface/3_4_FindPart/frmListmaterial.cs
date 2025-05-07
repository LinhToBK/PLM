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
    public partial class frmListmaterial : Form
    {
        public frmListmaterial()
        {
            InitializeComponent();
        }

        private void btnOpenFileMaterial_Click(object sender, EventArgs e)
        {
            string foldercomon = Environment.CurrentDirectory;
            string filematerial_path = System.IO.Path.Combine(foldercomon, "04_CommonDoc", "ListMaterial.txt");
            if(System.IO.File.Exists(filematerial_path))
            {
                System.Diagnostics.Process.Start(filematerial_path);
            }
            else
            {
                MessageBox.Show("File not found: " + filematerial_path, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
