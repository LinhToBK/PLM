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
using Newtonsoft.Json;
using System.Security.AccessControl;
using PLM_Lynx._03_GUI_User_Interface._3_1_Login;
using System.Globalization;
using System.Resources;
using System.Threading;

namespace PLM_Lynx._03_GUI_User_Interface._3_2_Relation_Part
{
    public partial class frmECO_Infor_Detail : Form
    {
        public int ECONo { get; set; }
        private DateTime ECODate { get; set; }
        private string ECOStatus { get; set; }
        private string ECOType { get; set; }
        private string ECOLog { get; set; }
        private int ECOStatusID { get; set; }
        private int ECOTypeID { get; set; }
        private string ECORequester { get; set; }
        private string ECOApprover { get; set; }
        private string ECOContent { get; set; }

        private ECO_BLL _ecoBLL = new ECO_BLL();
        private CommonBLL _commonBLL = new CommonBLL();

        private DataTable _ECO = new DataTable();
        private DataTable _tblContent = new DataTable();

        // =========== Language =========================
        private ResourceManager rm { get; set; } // Để lấy ngôn ngữ từ ResourceManager

        private void LoadLanguage()
        {
            // Lấy ngôn ngữ đã lưu ( mặc định là en)
            string lang = Properties.Settings.Default.Language;
            SetLanguage(lang);
        }

        private void SetLanguage(string lang)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(lang);
           
            rm = new ResourceManager("PLM_Lynx._03_GUI_User_Interface._3_2_Relation_Part.Lang.Lang_ECO_Infor_Detail", typeof(frmECO_Infor_Detail).Assembly);
            // Hiển thị ngôn ngữ lên các điều khiển trong form
            this.Text = rm.GetString("i.form");
            labelECONo.Text = rm.GetString("lb1");
            labelECODate.Text = rm.GetString("lb8");
            labelStatus.Text = rm.GetString("lb6");
            labelType.Text = rm.GetString("lb7");
            labelLog.Text = rm.GetString("lb5");
            labelRequester.Text = rm.GetString("lb3");
            labelApprover.Text = rm.GetString("lb2");


            Properties.Settings.Default.Language = lang;
            Properties.Settings.Default.Save();

        }






        // =========== Language =========================
        public frmECO_Infor_Detail()
        {
            InitializeComponent();
            LoadLanguage();

            this.KeyDown += new KeyEventHandler(frmECO_Infor_Detail_KeyDown);
            this.KeyPreview = true; // Cần bật Key Preview để Form bắt được phím
        }

        private void frmECO_Infor_Detail_Load(object sender, EventArgs e)
        {
            LoadECOInformation();
        }

        private void LoadECOInformation()
        {
            _ECO = _ecoBLL.Get_ECO_Information_BLL(ECONo);
            if (_ECO.Rows.Count > 0)
            {
                // Lấy thông tin từ DataTable
                ECODate = Convert.ToDateTime(_ECO.Rows[0]["ECODate"]);
                ECOStatus = _ECO.Rows[0]["ECOStatus"].ToString();
                ECOType = _ECO.Rows[0]["ECOType"].ToString();
                ECOLog = _ECO.Rows[0]["ECOLog"].ToString();
                ECOStatusID = Convert.ToInt32(_ECO.Rows[0]["ECOStatusID"]);
                ECOTypeID = Convert.ToInt32(_ECO.Rows[0]["ECOTypeID"]);
                ECORequester = _ECO.Rows[0]["ECONameProposal"].ToString();
                ECOApprover = _ECO.Rows[0]["ECONameApproved"].ToString();
                ECOContent = _ECO.Rows[0]["ECOContent"].ToString();

                // Hiển thị thông tin lên các điều khiển trong form
                txtECONo.Text = ECONo.ToString();
                txtECODate.Text = ECODate.ToString("dd/MM/yyyy");
                txtECOStatus.Text = ECOStatus;
                txtECOType.Text = ECOType;
                txtECOLog.Text = ECOLog;
                txtRequester.Text = ECORequester;
                txtApprover.Text = ECOApprover;

                _tblContent = JsonConvert.DeserializeObject<DataTable>(ECOContent);
                dgvECOContent.DataSource = _tblContent;
                dgvECOContent.AutoResizeColumns();
                dgvECOContent.AllowUserToAddRows = false;

                // Kiểm tra ECOStatus
                // Nếu chưa được Approved và là cập nhật Part Information
                if (ECOStatusID == 1 && ECOTypeID == 2)
                {
                    string version = _tblContent.Rows[0]["nd"].ToString();
                    string partcode = _tblContent.Rows[0]["p"].ToString();
                    _ecoBLL.GetAllFileinFolder_ECOTEMP(ECONo.ToString(), dgvECOListFile);
                }
                // Nếu đã Approved và là cập nhật Part Information
                if (ECOStatusID == 2 && ECOTypeID == 2)
                {
                    string version = _tblContent.Rows[0]["nd"].ToString();
                    string partcode = _tblContent.Rows[0]["p"].ToString();
                    _ecoBLL.GetAllFileinFolder_ECOTEMP(partcode, dgvECOListFile, version);
                }

                // Nếu là tạo part mới
                if (ECOTypeID == 1)
                {
                    string partcode = _tblContent.Rows[0]["p"].ToString();
                    _ecoBLL.GetAllFileinFolder_ECOTEMP(partcode, dgvECOListFile, "1.0");
                }
            }
            else
            {
                //MessageBox.Show("Không tìm thấy thông tin cho số ECO này.");
                MessageBox.Show(rm.GetString("t1"));
            }
        }

        private void dgvECOListFile_CellClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dgvECOListFile_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string filename = dgvECOListFile.CurrentRow.Cells[0].Value.ToString();
            // MessageBox.Show(dgvListFile.CurrentRow.Cells[1].Value.ToString());
            string filesize_A = dgvECOListFile.CurrentRow.Cells[1].Value.ToString();
            filesize_A = filesize_A.Substring(0, filesize_A.Length - 2);
            int filesize = Convert.ToInt32(filesize_A);

            string DataPath = Properties.Settings.Default.LinkDataPart;

            // Kiểm tra ECOStatus
            // Nếu chưa được Approved và là cập nhật Part Information
            if (ECOStatusID == 1 && ECOTypeID == 2)
            {
                filename = DataPath + "ECOTEMP" + "\\" + ECONo.ToString() + "\\" + filename;
            }
            // Nếu đã Approved và là cập nhật Part Information
            if (ECOStatusID == 2 && ECOTypeID == 2)
            {
                string partcode = _tblContent.Rows[0]["p"].ToString();
                string[] items = partcode.Split('-');
                filename = DataPath + items[0] + "\\" + items[1] + "\\" + filename;
            }

            // Nếu là tạo part mới
            if (ECOTypeID == 1)
            {
                string partcode = _tblContent.Rows[0]["p"].ToString();
                string[] items = partcode.Split('-');
                filename = DataPath + items[0] + "\\" + items[1] + "\\" + filename;
            }

            try
            {
                if (filesize > 10000)
                {
                    DialogResult kq = MessageBox.Show(rm.GetString("t2"), "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (kq == DialogResult.Yes)
                    {
                        _commonBLL.PreviewFile(filename);
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    _commonBLL.PreviewFile(filename);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(rm.GetString("t3") + ex.Message);
            }
        }

        private void frmECO_Infor_Detail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}