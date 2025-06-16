using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Xps;

namespace PLM_Lynx._03_GUI_User_Interface._3_7_Purchase_version_Hue
{
    public partial class frm_Choose_Multi_Rows : Form
    {

        public int SelectedRowCount { get; private set; } = 0;
        public frm_Choose_Multi_Rows()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            SelectedRowCount = Convert.IsDBNull(txtRowCount.Text) ? 0 : Convert.ToInt32(txtRowCount.Text);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
