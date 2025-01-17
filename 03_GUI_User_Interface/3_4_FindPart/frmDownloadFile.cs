using PLM_Lynx._01_DAL_Data_Access_Layer;
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
    public partial class frmDownloadFile : Form
    {

        public DataTransfer inputData  {  get; set; }

        // Create Data
        public string _partcode { get; set; }

        public frmDownloadFile()
        {
            InitializeComponent();

        }

        private void frmDownloadFile_Load(object sender, EventArgs e)
        {
            txtPartCode.Text = inputData._currentPartCode;
            txtPartName.Text = inputData._currentPartName;
            dgvListChild.DataSource = inputData.listchild;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnChooseFolder_Click(object sender, EventArgs e)
        {
            SaveFileDialog sv = new SaveFileDialog();
        }
    }
}
