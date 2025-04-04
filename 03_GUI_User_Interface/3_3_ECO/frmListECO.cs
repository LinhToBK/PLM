using Newtonsoft.Json;
using PLM_Lynx._01_DAL_Data_Access_Layer;
using PLM_Lynx._02_BLL_Bussiness_Logic_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PLM_Lynx._03_GUI_User_Interface._3_3_ECO
{
    public partial class frmListECO : Form
    {
        public int userlevel { get; set; }
        public int userid { get; set; }
        public string username { get; set; }

        private bool IsLoading = true; // Flag để kiểm soát sự kiện

        private ECO_BLL _ecoBLL = new ECO_BLL();

        private DataTable _tblECO = new DataTable();
        private DataTable _content = new DataTable();
        private string this_ECOContent { get; set; }
        private int this_ECOType { get; set; }

        public frmListECO()
        {
            InitializeComponent();

            // Tạo danh sách
            List<ListNearECO> Chonsoluong = new List<ListNearECO>
            {
                new ListNearECO { NoListNearECO = 5, MeanListNearECO = "Chọn 5 cập nhật gần nhất" },
                new ListNearECO { NoListNearECO = 10, MeanListNearECO = "Chọn 10 cập nhật gần nhất" },
                new ListNearECO { NoListNearECO = 20, MeanListNearECO = "Chọn 20 cập nhật gần nhất" },
                new ListNearECO { NoListNearECO = 50, MeanListNearECO = "Chọn 50 cập nhật gần nhất" }
            };

            // Gán danh sách từ DataSource lên Combox
            cboListNear.DataSource = Chonsoluong;
            cboListNear.DisplayMember = "MeanListNearECO";
            cboListNear.ValueMember = "NoListNearECO";

            // Đặt giá trị mắc định là mục đầu tiên
            if (cboListNear.Items.Count > 0)
            {
                cboListNear.SelectedIndex = 0;
            }
            IsLoading = false;
        }

        private void frmListECO_Load(object sender, EventArgs e)
        {
            if (userlevel == 1)
            {
                btnApprove.Enabled = true;
                btnCancel.Enabled = true;
            }

            LoadDatatodgvListNearECO(5);
            ShowChecklist();
            this.BeginInvoke(new Action(ApplyFilter));
        }

        public void LoadDatatodgvListNearECO(int norow)
        {
            _tblECO = _ecoBLL.GetListNearECO_BLL(norow);
            dgvListECO.DataSource = _tblECO;

            dgvListECO.AllowUserToAddRows = false;
            dgvListECO.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void cboListNear_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                // Lấy giá trị NoListNearPart đang được chọn
                //int selectNo = Convert.ToInt32(cboChooseNoRow.SelectedValue);
                if (!IsLoading)
                {
                    LoadDatatodgvListNearECO(Convert.ToInt32(cboListNear.SelectedValue));
                    ShowChecklist();
                    this.BeginInvoke(new Action(ApplyFilter));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xuất hiện lỗi : " + ex.Message);
            }
        }

        // =============================
        // Hiển thị lên các checklistbox
        // =============================
        private void ShowChecklist()
        {
            if (dgvListECO.Rows.Count == 0)
            {
                //MessageBox.Show("Không có dữ liệu để chọn");
                return;
            }
            else
            {
                // Lấy danh sách Date
                var listDate = dgvListECO.Rows
                                      .Cast<DataGridViewRow>()
                                      .Where(row => !row.IsNewRow)
                                      .Select(row => row.Cells[1].Value?.ToString())
                                      .Distinct()
                                      .OrderBy(x => x)
                                      .ToList();
                foreach (var category in listDate)
                {
                    if (!ckcECODate.Items.Contains(category))
                    {
                        ckcECODate.Items.Add(category, false); // Mặc định tất cả các mục được chọn
                    }
                }

                // Lấy danh sách Proposal
                var listProposal = dgvListECO.Rows
                                      .Cast<DataGridViewRow>()
                                      .Where(row => !row.IsNewRow)
                                      .Select(row => row.Cells[3].Value?.ToString())
                                      .Distinct()
                                      .OrderBy(x => x)
                                      .ToList();
                foreach (var category in listProposal)
                {
                    if (!ckcProposal.Items.Contains(category))
                    {
                        ckcProposal.Items.Add(category, false); // Mặc định tất cả các mục được chọn
                    }
                }

                // Lấy danh sách Status
                var listStatus = dgvListECO.Rows
                                      .Cast<DataGridViewRow>()
                                      .Where(row => !row.IsNewRow)
                                      .Select(row => row.Cells[5].Value?.ToString())
                                      .Distinct()
                                      .OrderBy(x => x)
                                      .ToList();
                foreach (var category in listStatus)
                {
                    if (!ckcECOStatus.Items.Contains(category))
                    {
                        ckcECOStatus.Items.Add(category, false); // Mặc định tất cả các mục được chọn
                    }
                }

                // Lấy danh sách Type
                var listECOType = dgvListECO.Rows
                                      .Cast<DataGridViewRow>()
                                      .Where(row => !row.IsNewRow)
                                      .Select(row => row.Cells[2].Value?.ToString())
                                      .Distinct()
                                      .OrderBy(x => x)
                                      .ToList();
                foreach (var category in listECOType)
                {
                    if (!ckcECOType.Items.Contains(category))
                    {
                        ckcECOType.Items.Add(category, false); // Mặc định tất cả các mục được chọn
                    }
                }
            }
        }

        private void ApplyFilter()
        {
            if (dgvListECO.DataSource is DataTable dt)
            {
                List<string> filters = new List<string>();

                // Lọc theo ngày
                string DateFilter = GetCheckedItemsFilter(ckcECODate, "ECODate");
                if (!string.IsNullOrEmpty(DateFilter)) filters.Add(DateFilter);

                // Lọc theo Nhân viên
                string ProposalFilter = GetCheckedItemsFilter(ckcProposal, "ECONameProposal");
                if (!string.IsNullOrEmpty(ProposalFilter)) filters.Add(ProposalFilter);

                // Lọc theo Trạng thái
                string statusFilter = GetCheckedItemsFilter(ckcECOStatus, "ECOStatus");
                if (!string.IsNullOrEmpty(statusFilter)) filters.Add(statusFilter);

                // Lọc theo Type ECO
                string TypeFilter = GetCheckedItemsFilter(ckcECOStatus, "ECOType");
                if (!string.IsNullOrEmpty(TypeFilter)) filters.Add(TypeFilter);

                // Ghép các điều kiện với AND
                dt.DefaultView.RowFilter = string.Join(" AND ", filters);
            }
        }

        // Hàm lấy danh sách các mục đã chọn và tạo điều kiện lọc
        private string GetCheckedItemsFilter(CheckedListBox checkedListBox, string columnName)
        {
            if (checkedListBox.CheckedItems.Count == 0) return "";

            List<string> selectedValues = checkedListBox.CheckedItems.Cast<string>()
                                          .Select(item => $"'{item}'").ToList();

            return $"{columnName} IN ({string.Join(",", selectedValues)})";
        }

        private void ckcECODate_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            this.BeginInvoke(new Action(ApplyFilter));
        }

        private void ckcProposal_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            this.BeginInvoke(new Action(ApplyFilter));
        }

        private void ckcECOType_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            this.BeginInvoke(new Action(ApplyFilter));
        }

        private void ckcECOStatus_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            this.BeginInvoke(new Action(ApplyFilter));
        }

        // =============================

        // =============================
        // Hiển thị thông tin lên các textbox chi tiết của từng ECO
        // =============================
        private void dgvListECO_Click(object sender, EventArgs e)
        {
            if (dgvListECO.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để chọn");
                return;
            }
            else
            {
                LoadECOInformation();
            }
        }

        private void LoadECOInformation()
        {
            // Load lên textbox
            txtECONo.Text = dgvListECO.CurrentRow.Cells[0].Value.ToString();
            txtECODate.Text = dgvListECO.CurrentRow.Cells[1].Value.ToString();
            txtECOType.Text = dgvListECO.CurrentRow.Cells[2].Value.ToString();
            txtECOProposal.Text = dgvListECO.CurrentRow.Cells[3].Value.ToString();
            txtECOStatus.Text = dgvListECO.CurrentRow.Cells[5].Value.ToString();
            this_ECOContent = dgvListECO.CurrentRow.Cells[6].Value.ToString();
            this_ECOType = Convert.ToInt32(dgvListECO.CurrentRow.Cells[7].Value.ToString());
            // Load lên datagridview
            //
            // Lấy thông tin về Partlist
            _content.Clear();
            _content = JsonConvert.DeserializeObject<DataTable>(this_ECOContent);
            dgvECOContent.DataSource = _content;
            dgvECOContent.AllowUserToAddRows = false;
            dgvECOContent.EditMode = DataGridViewEditMode.EditProgrammatically;
            string ecoContent;

            // Tùy từng loại ECO mà hiển thị  tương ứng
            switch (this_ECOType)
            {
                case 1:
                    {
                        // Make New Part
                        dgvECOContent.Columns[0].HeaderText = "Part Code";
                        dgvECOContent.Columns[1].HeaderText = "Content";
                        dgvECOContent.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        ecoContent = "Tạo mới Part ";
                        ecoContent = ecoContent + "\n Part code : " + dgvECOContent.Rows[0].Cells[0].Value.ToString();
                        txtECOContent.Text = ecoContent;
                        break;
                    }

                case 2:
                    {
                        // Cập nhật thông tin Part
                        ecoContent = " +) Cập nhật Part :  ";
                        string partcode = dgvECOContent.Rows[0].Cells[0].Value.ToString();
                        ecoContent = ecoContent + partcode;
                        string stagestatus = dgvECOContent.Rows[0].Cells[1].Value.ToString();
                        // Check Stage
                        string oldstageID = dgvECOContent.Rows[0].Cells[2].Value.ToString();
                        string old_stage = "";
                        string newstageID = dgvECOContent.Rows[0].Cells[3].Value.ToString();
                        string new_stage = "";

                        DataTable tblPartStage = _ecoBLL.GettblPartStage_BLL();
                        foreach (DataRow row in tblPartStage.Rows)
                        {
                            if (row[0].ToString() == oldstageID)
                            {
                                old_stage = row[1].ToString();
                            }
                            if (row[0].ToString() == newstageID)
                            {
                                new_stage = row[1].ToString();
                            }
                        }
                        if (stagestatus == "1")
                        {
                            ecoContent = ecoContent + "\r\n +) Cập nhật Stage : " + old_stage + " => " + new_stage;

                        }
                        string notestatus = dgvECOContent.Rows[0].Cells[4].Value.ToString();
                        if (notestatus == "1")
                        {
                            
                            ecoContent = ecoContent + "\r\n +) Note : " + dgvECOContent.Rows[0].Cells[5].Value.ToString();
                        }
                        string materialstatus = dgvECOContent.Rows[0].Cells[6].Value.ToString();
                        if (materialstatus == "1")
                        {
                            ecoContent = ecoContent + "\r\n +) Cập nhật vật liệu : " + dgvECOContent.Rows[0].Cells[7].Value.ToString();
                            ecoContent = ecoContent + " => " + dgvECOContent.Rows[0].Cells[8].Value.ToString();
                        }
                        string drawingstatus = dgvECOContent.Rows[0].Cells[9].Value.ToString();
                        if (drawingstatus == "1")
                        {
                            ecoContent = ecoContent + "\r\n +) Có cập nhật bản vẽ : ";
                        }
                        txtECOContent.Text = ecoContent;

                        break;
                    }
            }
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            // Thực hiện việc Aprroved ECO
            if (this_ECOType == 2)
            {
                // Tiến hàng cập nhật :
                // Bước 1 : Ghi vào tblPart
                // Bước 2 : Có thêm phần bản vẽ thì phải copy
                string partcode = dgvECOContent.Rows[0].Cells[0].Value.ToString();
                MessageBox.Show(dgvECOContent.Rows[0].Cells[3].Value.ToString());
                int idstage = Convert.ToInt32(dgvECOContent.Rows[0].Cells[3].Value.ToString());
                //string[] FolderName = partcode.Split('-');
                // FolderName[0] : XXX : PartFamily
                // FolderName[1] : YYYYY : PartNo
                // -- Tạo Folder  bằng PartCode mới
                //string Folder_Part_Path = Properties.Settings.Default.LinkDataPart + "//" + FolderName[0] + "//" + FolderName[1];

                // Bước 3 : Folder chưa bản vẽ ECOTemp để cho đỡ nặng 
                //int  newstageID = Convert.ToInt32( dgvECOContent.Rows[0].Cells[3].Value.ToString());
                //float lasterversion = _ecoBLL.lastestVersion(Folder_Part_Path);
                // string[] files = Directory.GetFiles(Folder_Part_Path);



                //// Duyệt qua từng file và lấy số phiên bản từ tên file
                //foreach (string file in files)
                //{
                //    // Lấy tên file mà không có đường dẫn
                //    string fileName = Path.GetFileNameWithoutExtension(file);
                //    // BOL-00002_V1.0
                //    // Tách phần tên file để lấy số phiên bản
                //    //float i = Convert.ToSingle(fileName.Substring(11, fileName.Length - 11));
                //    MessageBox.Show(fileName.Substring(11, fileName.Length - 11));

                //}


            }


        }
    }
}