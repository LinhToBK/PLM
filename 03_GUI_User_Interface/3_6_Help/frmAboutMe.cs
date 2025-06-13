using Azure.Core;
using PLM_Lynx._01_DAL_Data_Access_Layer;
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
using System.Data.SqlClient;
using PLM_Lynx._03_GUI_User_Interface._3_5_Purchase;
using System.Globalization;
using System.Resources;
using System.Threading;
using PLM_Lynx._03_GUI_User_Interface._3_1_Login;
using System.Net.NetworkInformation;
using System.IO;

namespace PLM_Lynx._03_GUI_User_Interface._3_6_Help
{
    public partial class frmAboutMe : Form
    {
        private CommonBLL _commonbll = new CommonBLL();

        public int iduser { get; set; } // Lấy iduser từ form login để kiểm tra quyền truy cập của người dùng
        public string username { get; set; } // Lấy tên người dùng từ form login để kiểm tra quyền truy cập của người dùng
        public int userlevel { get; set; } // Lấy quyền truy cập của người dùng từ form login để kiểm tra quyền truy cập của người dùng

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

            rm = new ResourceManager("PLM_Lynx._03_GUI_User_Interface._3_6_Help.Lang.Lang_frmAboutMe", typeof(frmAboutMe).Assembly);
            // Hiển thị ngôn ngữ lên các điều khiển trong form
            this.Text = rm.GetString("i.form");

            // Đặt ngôn ngữ
            // Cho Label
            labelName.Text = rm.GetString("lb1");
            labelPhone.Text = rm.GetString("lb2");
            labelTax.Text = rm.GetString("lb3");
            labelLocation.Text = rm.GetString("lb4");   
            // Cho button
            btnModifyCompany.Text = rm.GetString("lb6");
            btnSaveInfor.Text = rm.GetString("lb7");
            btnAddVersion.Text = rm.GetString("lb8");
            btnSaveVersion.Text = rm.GetString("lb9");


            Properties.Settings.Default.Language = lang;
            Properties.Settings.Default.Save();
        }

        // =========== Language =========================
        public frmAboutMe()
        {
            InitializeComponent();
            LoadLanguage();
        }

        private void frmAboutMe_Load(object sender, EventArgs e)
        {
            //------------
            LoadCommonInfor();
            LoadAllVersionInfor();
            if (userlevel == 1)
            {
                // Nếu là admin thì cho phép sửa thông tin
                btnSaveInfor.Enabled = false;
                txtCompanyName.Enabled = false;
                txtCompanyLocation.Enabled = false;
                txtCompanyTaxCode.Enabled = false;
                txtCompanyPhone.Enabled = false;
                btnSaveInfor.Enabled = false;
                btnDataPart.Enabled = false;
                btnTrashPart.Enabled = false;
                btnPO.Enabled = false;
                //-------------
                txtVersionID.Enabled = false;
                txtVersionContent.Enabled = false;
                btnSaveVersion.Enabled = false;
            }
            else
            {
                // Nếu không phải là admin thì không cho sửa bất cứ thông tin gì cả
                btnSaveInfor.Enabled = false;
                txtCompanyName.Enabled = false;
                txtCompanyLocation.Enabled = false;
                txtCompanyTaxCode.Enabled = false;
                txtCompanyPhone.Enabled = false;
                btnSaveInfor.Enabled = false;
                btnDataPart.Enabled = false;
                btnTrashPart.Enabled = false;
                btnPO.Enabled = false;
                //-------------
                txtVersionID.Enabled = false;
                txtVersionContent.Enabled = false;
                btnSaveVersion.Enabled = false;
       
                btnAddVersion.Enabled = false;
           
                txtServer.Enabled = false;
                txtVPS.Enabled = false;
                txtDataPart.Enabled = false;
                txtDataTrash.Enabled = false;
                txtDataPO.Enabled = false;

            } 
                
        }

        // Đẩy các thông tin lên textbox
        public void LoadCommonInfor()
        {
            tblCommonInfor companyname = _commonbll.GetCommonInforValue("CompanyName");
            if (companyname != null)
            {
                txtCompanyName.Text = companyname.InforValue.ToString();
            }
            else
            {
                txtCompanyName.Text = rm.GetString("t1");   // Error !!! \n Cannot access the data
            }
            tblCommonInfor companyphone = _commonbll.GetCommonInforValue("CompanyPhoneNumber");
            if (companyphone != null)
            {
                txtCompanyPhone.Text = companyphone.InforValue.ToString();
            }
            else
            {
                txtCompanyPhone.Text = rm.GetString("t1");
            }
            tblCommonInfor companylocation = _commonbll.GetCommonInforValue("CompanyLocation");
            if (companylocation != null)
            {
                txtCompanyLocation.Text = companylocation.InforValue.ToString();
            }
            else
            {
                txtCompanyLocation.Text = rm.GetString("t1");
            }
            tblCommonInfor companytaxcode = _commonbll.GetCommonInforValue("CompanyTaxCode");
            if (companytaxcode != null)
            {
                txtCompanyTaxCode.Text = companytaxcode.InforValue.ToString();
            }
            else
            {
                txtCompanyTaxCode.Text = rm.GetString("t1");
            }

            // Điền thông tin chung vào các ô textbox
            txtDataPart.Text = Properties.Settings.Default.LinkDataPart;
            txtDataTrash.Text = Properties.Settings.Default.TrashDataPart;
            txtDataPO.Text = Properties.Settings.Default.PurchaseData;
            string Connect = Properties.Settings.Default.Datacon;
            string[] ServerNameList = Connect.Split(';');
            string ServerName = ServerNameList[1];
            string VPSname = ServerNameList[0];
            string[] Server = ServerName.Split('=');
            txtServer.Text = Server[1].ToString().Trim();
            string[] VPS = VPSname.Split('=');
            txtVPS.Text = VPS[1].ToString().Trim();
        }

        // Đẩy thông tin lên datagrid view
        public void LoadAllVersionInfor()
        {
            dgvVersion.DataSource = _commonbll.GetAllVersionInfor_BLL();
            dgvVersion.AllowUserToAddRows = false;
            dgvVersion.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void btnModifyCompany_Click(object sender, EventArgs e)
        {
            if(userlevel == 1)
            {
                txtCompanyName.Enabled = true;
                txtCompanyPhone.Enabled = true;
                txtCompanyLocation.Enabled = true;
                txtCompanyTaxCode.Enabled = true;
                txtDataPart.Enabled = true;
                txtDataTrash.Enabled = true;
                txtDataPO.Enabled = true;


                btnDataPart.Enabled = true;
                btnTrashPart.Enabled = true;
                btnPO.Enabled = true;
            } 
            else
            {
                // Nếu không phải là admin thì  chỉ cho phép sửa đường dẫn
                btnDataPart.Enabled = true;
                btnTrashPart.Enabled = true;
                btnPO.Enabled = true;

                txtDataPart.Enabled = true;
                txtDataTrash.Enabled = true;
                txtDataPO.Enabled = true;

            }    
                

            
        }

        private void txtCompanyName_TextChanged(object sender, EventArgs e)
        {
            btnSaveInfor.Enabled = true;
        }

        private void txtCompanyPhone_TextChanged(object sender, EventArgs e)
        {
            btnSaveInfor.Enabled = true;
        }

        private void txtCompanyTaxCode_TextChanged(object sender, EventArgs e)
        {
            btnSaveInfor.Enabled = true;
        }

        private void txtCompanyLocation_TextChanged(object sender, EventArgs e)
        {
            btnSaveInfor.Enabled = true;
        }

        private void txtVersionID_TextChanged(object sender, EventArgs e)
        {
            btnSaveVersion.Enabled = true;
        }

        private void txtVersionContent_TextChanged(object sender, EventArgs e)
        {
            btnSaveVersion.Enabled = true;
        }

        private void btnAddVersion_Click(object sender, EventArgs e)
        {
            txtVersionID.Enabled = true;
            txtVersionContent.Enabled = true;
        }

        private void btnSaveInfor_Click(object sender, EventArgs e)
        {
            // Tiến hành cập nhật
            string contentname = txtCompanyName.Text.Trim();
            string contentphone = txtCompanyPhone.Text.Trim();
            string contentlocation = txtCompanyLocation.Text.Trim();
            string contenttax = txtCompanyTaxCode.Text.Trim();
            string datapart = txtDataPart.Text.Trim();
            string datatrash = txtDataTrash.Text.Trim();
            string dataPO = txtDataPO.Text.Trim();
            string tb = rm.GetString("t2");   // Bạn có muốn cập nhật những thông tin của công ty :
            tb = tb + rm.GetString("t3") + contentname;
            tb = tb + rm.GetString("t4") + contentphone;
            tb = tb + rm.GetString("t5") + contentlocation;
            tb = tb + rm.GetString("t6") + contenttax;
            tb = tb + rm.GetString("t7") + datapart;
            tb = tb + rm.GetString("t8") + datatrash;
            tb = tb + rm.GetString("t13") + dataPO;

            DialogResult kq = MessageBox.Show(tb, rm.GetString("t0"), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq == DialogResult.Yes)
            {
                if (_commonbll.UpdateCompanyInfor_BLL(contentname, contentlocation, contentphone, contenttax) && UpdateLinkFolder(datapart, datatrash, dataPO))
                {
                    MessageBox.Show(rm.GetString("t9"));
                    LoadCommonInfor();
                    btnSaveInfor.Enabled = false;
                    txtCompanyName.Enabled = false;
                    txtCompanyPhone.Enabled = false;
                    txtCompanyLocation.Enabled = false;
                    txtCompanyTaxCode.Enabled = false;
                    txtDataPart.Enabled = false;
                    txtDataTrash.Enabled = false;
                    txtDataPO.Enabled = false;
                }
                else
                {
                    MessageBox.Show(rm.GetString("t10"));
                }
            }
            else
            {
                return;
            }
        }

        private void btnSaveVersion_Click(object sender, EventArgs e)
        {
            string tb = "Do you want to add new version information ?";
            tb = tb + "\n Version No : " + txtVersionID.Text.Trim();
            tb = tb + "\n Content : " + txtVersionContent.Text.Trim();
            DialogResult kq = MessageBox.Show(tb, "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq == DialogResult.Yes)
            {
                if (_commonbll.InsertNewVersion_BLL(txtVersionID.Text.Trim(), txtVersionContent.Text.Trim()) == true)
                {
                    MessageBox.Show("Add new version successfully.");
                    LoadAllVersionInfor();
                    btnSaveVersion.Enabled = false;
                    txtVersionID.Enabled = false;
                    txtVersionContent.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Error : Can not add new version. ");
                }
            }
            else
            {
                return;
            }
        }

        private bool UpdateLinkFolder(string datapart, string trashpart, string popath)
        {
            // Kiểm tra đường dẫn có tồn tại hay không
            if (System.IO.Directory.Exists(datapart) && System.IO.Directory.Exists(trashpart))
            {
                // Cập nhật đường dẫn vào file config
                Properties.Settings.Default.LinkDataPart = datapart;
                Properties.Settings.Default.TrashDataPart = trashpart;
                Properties.Settings.Default.PurchaseData = popath;
                Properties.Settings.Default.Save();
                return true;
            }
            else
            {
                MessageBox.Show(rm.GetString("t12"));  //Đường dẫn không tồn tại. Vui lòng kiểm tra lại.
                return false;
            }
        }

        private void btnDataPart_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = "Choose folder";
                folderDialog.ShowNewFolderButton = true;

                DialogResult result = folderDialog.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderDialog.SelectedPath))
                {
                    string selectedPath = folderDialog.SelectedPath + "\\";
                    // MessageBox.Show("Đường dẫn đã chọn: " + selectedPath);

                    // Ví dụ: gán vào TextBox
                    txtDataPart.Text = selectedPath;
                }
            }
        }

        private void btnTrashPart_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = "Choose folder";
                folderDialog.ShowNewFolderButton = true;

                DialogResult result = folderDialog.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderDialog.SelectedPath))
                {
                    string selectedPath = folderDialog.SelectedPath + "\\";
                    //MessageBox.Show("Đường dẫn đã chọn: " + selectedPath);

                    // Ví dụ: gán vào TextBox
                    txtDataTrash.Text = selectedPath;
                }
            }
        }

        private void btnPO_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = "Choose folder";
                folderDialog.ShowNewFolderButton = true;

                DialogResult result = folderDialog.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderDialog.SelectedPath))
                {
                    string selectedPath = folderDialog.SelectedPath + "\\";
                    //MessageBox.Show("Đường dẫn đã chọn: " + selectedPath);

                    // Ví dụ: gán vào TextBox
                    txtDataPO.Text = selectedPath;
                }
            }
        }

        private void btnActive_Click(object sender, EventArgs e)
        {
            CheckLicense();
            if (licstatus == true)
            {
                MessageBox.Show("License is activated"); //
                return;
            }
            else
            {
                frmEnterLicencesCode frm = new frmEnterLicencesCode();
                frm.begindate = BeginDate;
                frm.ShowDialog();
            }
        }

        // ===========================================================
        // ===========================================================
        /// <summary>
        //  Liên quan đến kiểm tra license
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        ///
        // Đầu tiền kiểm tra xem có tồn tại file license không ?
        // Nếu chưa tồn tại thì tạo mới và ghi ngày hiện tại vào file
        // Nếu đã tồn tại thì kiểm tra xem ngày hiện tại có
        // lớn hơn ngày ghi trong file không ? Nếu lớn hơn 365 ngày thì thông báo hết hạn
        private string LicencePath = @"C:\ProgramData\window.lic";

        private bool licstatus { get; set; }
        private string BeginDate { get; set; }

        private void CheckLicense()
        {
            if (!File.Exists(LicencePath)) // Lần đầu mở ứng dụng
            {
                File.WriteAllText(LicencePath, DateTime.Now.ToString("MM-dd-yyyy"));
                licstatus = true;
                return;
            }
            else
            {
                string savedDate = File.ReadLines(LicencePath).FirstOrDefault();     // Dòng đầu tiên

                string kichhoatdate = File.ReadLines(LicencePath).Skip(1).FirstOrDefault();   // Dòng thứ 2

                if (kichhoatdate == savedDate)
                {
                    licstatus = true;
                    return;
                }

                if (DateTime.TryParse(savedDate, out DateTime activationDate))
                {
                    if ((DateTime.Now - activationDate).TotalDays > 365)
                    {
                        DateTime expireddate = activationDate.AddDays(365);
                        string tb1 = rm.GetString("1.2.1") + expireddate.ToString("MM-dd-yyyy");
                        BeginDate = expireddate.ToString("MM-dd-yyyy");
                        //MessageBox.Show(tb, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        MessageBox.Show(tb1);
                        licstatus = false;
                        //Application.Exit();
                    }
                    else
                    {
                        DateTime expireddate = activationDate.AddDays(365);
                        BeginDate = expireddate.ToString("MM-dd-yyyy");
                        licstatus = false; // tuy chưa đến ngày sau 365 ngày sử dụng những vẫn có thể kích hoạt
                    }
                }
            }
        }

        private void txtDataPart_TextChanged(object sender, EventArgs e)
        {
            btnSaveInfor.Enabled = true;    
            
        }

        private void txtDataTrash_TextChanged(object sender, EventArgs e)
        {
            btnSaveInfor.Enabled = true;
        }

        private void txtDataPO_TextChanged(object sender, EventArgs e)
        {
            btnSaveInfor.Enabled = true;
        }
    }
}