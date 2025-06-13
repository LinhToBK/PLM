using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PLM_Lynx._03_GUI_User_Interface._00_Common
{
    public partial class frmDataGridView_Modify : Form
    {

        // Show , ColumnName, ColumnWidth, ColumnHeader
        public DataTable table_Attribute { get; set; }

        public DataTable table_Updated_Att { get; set; }
        private DataTable tbl_AutoColumnsSize_Options = new DataTable();
        public int Col_ModeID { get; set; } = 0;
        public string Col_ModeName { get; set; } 
        private void Create_AutoColumnsSize_Options()
        {
            // Tạo DataTable cho tùy chọn tự động điều chỉnh kích thước cột
           
            tbl_AutoColumnsSize_Options.Columns.Add("OptionID", typeof(int));
            tbl_AutoColumnsSize_Options.Columns.Add("OptionName", typeof(string));
            // Thêm dữ liệu vào DataTable
            tbl_AutoColumnsSize_Options.Rows.Add(0, "None");
            tbl_AutoColumnsSize_Options.Rows.Add(1, "ColumnHeader");
            tbl_AutoColumnsSize_Options.Rows.Add(2, "AllCellsExceptHeader");
            tbl_AutoColumnsSize_Options.Rows.Add(3, "AllCells");
            tbl_AutoColumnsSize_Options.Rows.Add(4, "DisplayedCellsExceptHeader");
            tbl_AutoColumnsSize_Options.Rows.Add(5, "Displayed Cells");
            tbl_AutoColumnsSize_Options.Rows.Add(6, "Fill");
        }
        public frmDataGridView_Modify(DataTable Original_Attribute , string Col_Mode)
        {
            InitializeComponent();
            table_Attribute = Original_Attribute.Copy();
            Col_ModeName = Col_Mode;
        }

        private void frmDataGridView_Modify_Load(object sender, EventArgs e)
        {
            dgv_Table_Feature.DataSource = table_Attribute;
            dgv_Table_Feature.AllowUserToAddRows = false;
            dgv_Table_Feature.AllowUserToDeleteRows = false;
            dgv_Table_Feature.Columns["ColumnName"].ReadOnly = true;

            Create_AutoColumnsSize_Options();
            cbo_AutoSizeColumn.DataSource = tbl_AutoColumnsSize_Options;
            cbo_AutoSizeColumn.DisplayMember = "OptionName";
            cbo_AutoSizeColumn.ValueMember = "OptionID";
            foreach (var item in cbo_AutoSizeColumn.Items)
            {
                if (cbo_AutoSizeColumn.GetItemText(item) == Col_ModeName )
                {
                    cbo_AutoSizeColumn.SelectedItem = item;
                    break;
                }
            }



        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            string mes = "Do you want to cancel the changes?";
            DialogResult result = MessageBox.Show(mes, "Cancel Changes", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            table_Updated_Att = ((DataTable)dgv_Table_Feature.DataSource).Copy();
            Col_ModeID = Convert.ToInt32(cbo_AutoSizeColumn.SelectedValue);
            if (table_Updated_Att != null && table_Updated_Att.Rows.Count > 0)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("No data to save.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }
    }
}
