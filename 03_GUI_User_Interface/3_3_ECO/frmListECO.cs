using Newtonsoft.Json;
using PLM_Lynx._01_DAL_Data_Access_Layer;
using PLM_Lynx._02_BLL_Bussiness_Logic_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
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
        private int this_ECOStatus { get; set; } // Trạng thái ECO (1: Đã duyệt, 2: Chưa duyệt)

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
            this_ECOStatus = Convert.ToInt32(dgvListECO.CurrentRow.Cells[8].Value.ToString());
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
                case 3:
                    {
                        // Tạo ràng buộc mới
                        ecoContent = "Tạo ràng buộc mới cho Part : ";
                        string partcode = dgvECOContent.Rows[0].Cells[0].Value.ToString();
                        ecoContent = ecoContent + partcode;
                        txtECOContent.Text = ecoContent;
                        break;
                    }
                case 4:
                    { // Cập nhật số lượng
                        ecoContent = "Cập nhật số lượng cho Part : ";
                        string parentcode = dgvECOContent.Rows[0].Cells[0].Value.ToString();
                        string childcode = dgvECOContent.Rows[0].Cells[1].Value.ToString();
                        string quantity = dgvECOContent.Rows[0].Cells[2].Value.ToString();
                        ecoContent = ecoContent + "\r\n Parent code : " + parentcode;
                        ecoContent = ecoContent + "\r\n Child code : " + childcode;
                        ecoContent = ecoContent + "\r\n Số lượng : " + quantity;
                        txtECOContent.Text = ecoContent;
                        break;
                    }
                case 5:
                    {
                        // Xóa ràng buộc
                        ecoContent = "Xóa ràng buộc giữa các part : ";
                        string parentcode = dgvECOContent.Rows[0].Cells[0].Value.ToString();
                        string childcode = dgvECOContent.Rows[0].Cells[1].Value.ToString();
                        ecoContent = ecoContent + "\r\n Parent code : " + parentcode;
                        ecoContent = ecoContent + "\r\n Child code : " + childcode;
                        txtECOContent.Text = ecoContent;
                        break;
                    }
            }
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            if (this_ECOStatus == 1)
            {
                // Case 1 : Tạo Part Mới
                if (this_ECOType == 1)
                {
                    MessageBox.Show("Tạo Part mới thì không  cần phải Approved");
                    return;
                }
                // Case 2 : Cập nhật thông tin Part
                if (this_ECOType == 2)
                {
                    Approved_Case2();
                }
                // Case 3 : Tạo ràng buộc mới
                if (this_ECOType == 3)
                {
                    Approved_Case3();
                }

                // Case 4 : Cập nhật số lư
                // ợng
                if (this_ECOType == 4)
                {
                    Approved_Case4();
                }

                // Case 5 : Xóa ràng buộc
                if (this_ECOType == 5)
                {
                    Approved_Case5();
                }
            }

            if (this_ECOStatus == 2)
            {
                MessageBox.Show("ECO đã được duyệt rồi");
                return;
            }

            if (this_ECOStatus == 3)
            {
                // Cancel ECO
                MessageBox.Show("ECO đã bị hủy rồi \n Cần tạo request mới để phê duyệt");
                return;
            }
        }

        // Case 2 : Update Infor của Part
        private void Approved_Case2()
        {
            string partcode = dgvECOContent.Rows[0].Cells[0].Value.ToString();
            string tb = "Bạn có muốn phê duyệt cập nhật thông tin của Part : " + partcode + " không ?";
            DialogResult kq = MessageBox.Show(tb, "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq == DialogResult.No)
            {
                return;
            }
            else
            {
                // Chấp nhận cập nhật
                int ECONo = Convert.ToInt32(txtECONo.Text);
                string PartMaterial = dgvECOContent.Rows[0].Cells[8].Value.ToString();
                string drawingstatus = dgvECOContent.Rows[0].Cells[9].Value.ToString();
                string stagestatus = dgvECOContent.Rows[0].Cells[1].Value.ToString();
                int oldstage = Convert.ToInt32(dgvECOContent.Rows[0].Cells[2].Value.ToString());
                int newstage = Convert.ToInt32(dgvECOContent.Rows[0].Cells[3].Value.ToString());
                string Version;
                string[] FolderName = partcode.Split('-');
                string Folder_Part_Path = Properties.Settings.Default.LinkDataPart + "//" + FolderName[0] + "//" + FolderName[1];

                if (_ecoBLL.UpdateInforPart_BLL(partcode, newstage, PartMaterial, ECONo) == true)
                {
                    // Trường hợp 1  :  thay đổi Stage và có đính kèm bản vẽ
                    if (stagestatus == "1" && drawingstatus == "1")
                    {
                        MessageBox.Show("TH1 : Thay đổi cả Stage và có bản vẽ đính kèm");
                        Version = dgvECOContent.Rows[0].Cells[3].Value.ToString() + ".0";     // 2.0,, 3.0
                                                                                              // Copy file từ ECOTEMP sang DataPart
                        if (_ecoBLL.CopyFile_to_DataPart(partcode, Version, ECONo))
                        {
                            // Nếu copy xong thì xóa thư mục trong ECOTEMP
                            if (_ecoBLL.Delete_Folder_ECO(ECONo))
                            {
                                MessageBox.Show("Đã copy thành công vào datapart và xóa file trong  thư mục ECONo");
                            }
                            else
                            {
                                MessageBox.Show("Lỗi , không xóa được file trong thư mục ECONo File");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Lỗi không copy được file vào thư mục DataPart");
                        }
                    } // Hết trường hợp 1 :

                    // Trường hợp 2 : Thay đổi Stage nhưng không có bản vẽ đính kèm
                    else if (stagestatus == "1" && drawingstatus == "0")
                    {
                        MessageBox.Show("TH2 : Thay đổi Stage nhưng không có bản vẽ đính kèm");
                        Version = dgvECOContent.Rows[0].Cells[3].Value.ToString() + ".0";     // 2.0,, 3.0
                                                                                              // Copy file từ DataPart version mới nhất của stage cũ
                        if (_ecoBLL.CopyFile_to_DataPart_If_UpStage(partcode, newstage, oldstage))
                        {
                            MessageBox.Show("Đã copy bản mới nhất của stage cũ sang stage mới");
                        }
                        else
                        {
                            MessageBox.Show("Lỗi khi không copy lên bản mới nhât của stage cũ lên stage mới ");
                        }
                    } // Hết trường hợp 2 :

                    // Trường hợp 3 : Chỉ cập nhật bản vẽ và không cập nhật Stage
                    else if (stagestatus == "" && drawingstatus == "1")
                    {
                        Version = oldstage.ToString() + "." + _ecoBLL.lastestVersion(Folder_Part_Path, oldstage).ToString();
                        MessageBox.Show("Chỉ cập nhật bản vẽ, không cập nhật Stage");
                        // Copy file từ ECOTEMP sang DataPart
                        if (_ecoBLL.CopyFile_to_DataPart(partcode, Version, ECONo))
                        {
                            // Nếu copy xong thì xóa thư mục trong ECOTEMP
                            if (_ecoBLL.Delete_Folder_ECO(ECONo))
                            {
                                MessageBox.Show("Đã copy thành công vào datapart và xóa file trong  thư mục ECONo");
                            }
                            else
                            {
                                MessageBox.Show("Lỗi , không xóa được file trong thư mục ECONo File");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Lỗi không copy được file vào thư mục DataPart");
                        }
                    }  // Hết trường hợp 3

                    // Load lại danh sách ECO
                    if (_ecoBLL.Update_tblECO_Approved_BLL(userid, username, ECONo) == true)
                    {
                        LoadDatatodgvListNearECO(Convert.ToInt32(cboListNear.SelectedValue));
                        ShowChecklist();
                        this.BeginInvoke(new Action(ApplyFilter));
                    }
                    else
                    {
                        MessageBox.Show("Lỗi không cập nhật được thông tin tblECO");
                    }
                }
                else
                {
                    MessageBox.Show("Lỗi không cập nhật được thông tin Part");
                }
            }
        }

        // Case 3 : Tạo ràng buộc mới
        private RelationPartBLL relationBLL = new RelationPartBLL();

        private void Approved_Case3()
        {
            string tb = "Bạn có muốn tạo ràng buộc mới cho những Part trong danh sách không ?";
            DialogResult kq = MessageBox.Show(tb, "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq == DialogResult.Yes)
            {
                // Chấp nhận cập nhật
                if (Insert_Relation() == true)
                {
                    // Ghi ECNO vào parentcode
                    string parentcode = dgvECOContent.Rows[0].Cells[0].Value.ToString();
                    if (_ecoBLL.Write_ECONo_to_tblPart_BLL(parentcode, txtECONo.Text) && _ecoBLL.Update_tblECO_Approved_BLL(userid, username, Convert.ToInt32(txtECONo.Text)))
                    {
                        MessageBox.Show("Đã phê duyệt ECO [ Thêm ràng buộc mới ] thành công");
                        LoadDatatodgvListNearECO(Convert.ToInt32(cboListNear.SelectedValue));
                        ShowChecklist();
                        this.BeginInvoke(new Action(ApplyFilter));
                    }
                    else
                    {
                        MessageBox.Show("Lỗi phê duyệt ");
                    }
                }
            }
        }

        private bool Insert_Relation()
        {
            int insertstatus = 0;
            string parentcode = dgvECOContent.Rows[0].Cells[0].Value.ToString();
            string thongbao2 = "";
            foreach (DataGridViewRow dr in dgvECOContent.Rows)
            {
                try
                {
                    // Kiểm tra giá trị và xử lý trước khi truyền vào BLL
                    if (dr.Cells[0].Value != null && dr.Cells[1].Value != null && dr.Cells[0].Value.ToString() != parentcode)
                    {
                        string childCode = dr.Cells[0].Value.ToString();
                        int quantity = int.Parse(dr.Cells[1].Value.ToString());

                        MessageBox.Show("Cập nhật ràng buộc Parent code : " + parentcode + " Child code : " + childCode + " Quantity : " + quantity);

                        if (relationBLL.InsertNewRelationBLL(parentcode, childCode, quantity) && _ecoBLL.Delete_tblRelationTemp_BLL(parentcode, childCode) && _ecoBLL.Write_ECONo_to_tblPart_BLL(childCode, txtECONo.Text))
                        {
                            thongbao2 = thongbao2 + "(+) Đã upload --" + parentcode + "---" + childCode + " -- thành công \n";
                        }
                        else
                        {
                            thongbao2 = thongbao2 + "(!) Lỗi không thể upload --" + parentcode + "---" + childCode + " -- \n";
                            insertstatus++;
                        }
                    }
                }
                catch (Exception ex)
                {
                    thongbao2 += $"(!) Lỗi ngoại lệ: {ex.Message} \n";
                    insertstatus++;
                }
            }

            if (insertstatus == 0)
            {
                MessageBox.Show(thongbao2);
                return true;
            }
            else
            {
                MessageBox.Show(thongbao2);
                return false;
            }
        }

        private void Approved_Case4()
        {
            string parentcode = dgvECOContent.Rows[0].Cells[0].Value.ToString();
            string childcode = dgvECOContent.Rows[0].Cells[1].Value.ToString();
            string quantity = dgvECOContent.Rows[0].Cells[2].Value.ToString();

            string tb = "Bạn có muốn phê duyệt cập nhật số lương của Part  : " + parentcode + " không ?";
            tb = tb + "\r\n Child code : " + childcode;
            tb = tb + "\r\n Số lượng : " + quantity;

            DialogResult kq = MessageBox.Show(tb, "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq == DialogResult.Yes)
            {
                if (_ecoBLL.CapnhatQuantityBLL(parentcode, childcode, Convert.ToInt32(quantity), txtECONo.Text))
                {
                    if (_ecoBLL.Update_tblECO_Approved_BLL(userid, username, Convert.ToInt32(txtECONo.Text)))
                    {
                        MessageBox.Show("Đã phê duyệt ECO [ Cập nhật số lương của Part ] thành công");
                        LoadDatatodgvListNearECO(Convert.ToInt32(cboListNear.SelectedValue));
                        ShowChecklist();
                        this.BeginInvoke(new Action(ApplyFilter));
                    }
                    else
                    {
                        MessageBox.Show("Xuất hiện lỗi khi cập nhật \n Kiểm tra lại dữ liệu");
                        return;
                    }
                }
            }
        }

        public void Approved_Case5()
        {
            string parentcode = dgvECOContent.Rows[0].Cells[0].Value.ToString();
            string childcode = dgvECOContent.Rows[0].Cells[1].Value.ToString();
            string tb = "Bạn có muốn phê duyệt xóa ràng buộc giữa 2 Part : " + parentcode + " và " + childcode + " không ?";
            DialogResult kq = MessageBox.Show(tb, "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq == DialogResult.Yes)
            {
                if (_ecoBLL.XoaRelationBLL(parentcode, childcode, txtECONo.Text) && _ecoBLL.Update_tblECO_Approved_BLL(userid, username, Convert.ToInt32(txtECONo.Text)))
                {
                    MessageBox.Show("Đã phê duyệt ECO [ Xóa ràng buộc giữa 2 Part ] thành công");
                    LoadDatatodgvListNearECO(Convert.ToInt32(cboListNear.SelectedValue));
                    ShowChecklist();
                    this.BeginInvoke(new Action(ApplyFilter));
                }
                else
                {
                    MessageBox.Show("Xuất hiện lỗi khi cập nhật \n Kiểm tra lại dữ liệu");
                    return;
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (this_ECOStatus == 1)
            {
                // Case 1 : Tạo Part Mới
                if (this_ECOType == 1)
                {
                    MessageBox.Show("Tạo Part mới thì không  cần phải Approved hay Canceled");
                    return;
                }
                // Case 2 : Cập nhật thông tin Part
                if (this_ECOType == 2)
                {
                    Cancel_Case2();
                }
                // Case 3 : Tạo ràng buộc mới
                if (this_ECOType == 3)
                {
                    Cancel_Case3();
                }

                // Case 4 : Cập nhật số lượng
                if (this_ECOType == 4 )
                {
                    string tb = "Bạn có muốn hủy việc cập nhật số lượng không ? ";
                    DialogResult kq = MessageBox.Show(tb, "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if(kq == DialogResult.Yes)
                    {
                        if (_ecoBLL.Update_tblECO_Canceled_BLL(userid, username, Convert.ToInt32(txtECONo.Text)))
                        {
                            MessageBox.Show("Đã đưa request về trạng thái hủy ");
                            LoadDatatodgvListNearECO(Convert.ToInt32(cboListNear.SelectedValue));
                            ShowChecklist();
                            this.BeginInvoke(new Action(ApplyFilter));
                        }
                        else
                        {
                            MessageBox.Show("Phát sinh lỗi trong quá trình cập nhật ");
                        }
                    }
                    else
                    {
                        return;
                    }
                }

                // Case 5 : Xóa ràng buộc
                if (this_ECOType == 5)
                {
                    //Approved_Case5();
                    string tb = "Bạn có muốn hủy việc xóa ràng buộc không ? ";
                    DialogResult kq = MessageBox.Show(tb, "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (kq == DialogResult.Yes)
                    {
                        if (_ecoBLL.Update_tblECO_Canceled_BLL(userid, username, Convert.ToInt32(txtECONo.Text)))
                        {
                            MessageBox.Show("Đã đưa request về trạng thái hủy ");
                            LoadDatatodgvListNearECO(Convert.ToInt32(cboListNear.SelectedValue));
                            ShowChecklist();
                            this.BeginInvoke(new Action(ApplyFilter));
                        }
                        else
                        {
                            MessageBox.Show("Phát sinh lỗi trong quá trình cập nhật ");
                        }
                    }
                    else
                    {
                        return;
                    }
                }
            }

            if (this_ECOStatus == 2)
            {
                MessageBox.Show("ECO đã được duyệt rồi. Không thể hủy bỏ");
                return;
            }

            if (this_ECOStatus == 3)
            {
                // Cancel ECO
                MessageBox.Show("ECO đã hủy rồi, cần gì hủy lại lần nữa đâu ");
                return;
            }
        }

        /// <summary>
        /// Canceled - Case 2 : Hủy việc cập nhật thông tin cho Part
        /// </summary>
        private void Cancel_Case2()
        {
            int ECONo = Convert.ToInt32(txtECONo.Text);
            string partcode = dgvECOContent.Rows[0].Cells[0].Value.ToString();
            string drawingstatus = dgvECOContent.Rows[0].Cells[9].Value.ToString();
            string tb = "Bạn có muốn hủy phê duyệt cập nhật thông tin của " + partcode + " không ?";
            DialogResult kq = MessageBox.Show(tb, "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq == DialogResult.Yes)
            {
                // Chấp nhận cập nhật

                if (drawingstatus == "1")
                {
                    // Có bản vẽ đính kèm
                    if (_ecoBLL.Delete_Folder_ECO(ECONo) && _ecoBLL.Update_tblECO_Canceled_BLL(userid, username, ECONo))
                    {
                        MessageBox.Show("Đã đưa request về trạng thái hủy ");
                        LoadDatatodgvListNearECO(Convert.ToInt32(cboListNear.SelectedValue));
                        ShowChecklist();
                        this.BeginInvoke(new Action(ApplyFilter));
                    }
                    else
                    {
                        MessageBox.Show("Phát sinh lỗi trong quá trình cập nhật ");
                    }
                }
                else
                {
                    if (_ecoBLL.Update_tblECO_Canceled_BLL(userid, username, ECONo))
                    {
                        MessageBox.Show("Đã đưa request về trạng thái hủy ");
                        LoadDatatodgvListNearECO(Convert.ToInt32(cboListNear.SelectedValue));
                        ShowChecklist();
                        this.BeginInvoke(new Action(ApplyFilter));
                    }
                    else
                    {
                        MessageBox.Show("Phát sinh lỗi trong quá trình cập nhật ");
                    }
                }
            }
            else
            {
                return;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult kq = MessageBox.Show("Bạn có muốn thoát view ECO không ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq == DialogResult.Yes)
            {
                this.Close();
            }
            else
            { return; }
        }

        /// <summary>
        /// Canceled - Case 3 : Hủy việc tạo ràng buộc mới
        /// </summary>
        private void Cancel_Case3()
        {
            // Bước 1 : update việc là canceled lên tblECO
            // Bước 2 : Xóa các ràng buộc trong tblRelationTemp

            string tb = "Bạn có muốn hủy việc tạo ràng buộc mới không ?";
            DialogResult kq = MessageBox.Show(tb, "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq == DialogResult.Yes)
            {
                  if(Delete_Relation_in_tblRelationTemp() && _ecoBLL.Update_tblECO_Canceled_BLL(userid, username, Convert.ToInt32(txtECONo.Text)))
                {
                    MessageBox.Show("Đã đưa request về trạng thái hủy ");
                    LoadDatatodgvListNearECO(Convert.ToInt32(cboListNear.SelectedValue));
                    ShowChecklist();
                    this.BeginInvoke(new Action(ApplyFilter));
                }    
                  else
                {
                    MessageBox.Show("Phát sinh lỗi trong quá trình xóa các ràng buộc tạm thời trong tblRelationTemp ");
                }
            }
            else
            {
                return;
            }

        }

        private bool Delete_Relation_in_tblRelationTemp()
        {
            int insertstatus = 0;
            string parentcode = dgvECOContent.Rows[0].Cells[0].Value.ToString();
            string thongbao2 = "";
            foreach (DataGridViewRow dr in dgvECOContent.Rows)
            {
                try
                {
                    // Kiểm tra giá trị và xử lý trước khi truyền vào BLL
                    if (dr.Cells[0].Value != null && dr.Cells[1].Value != null && dr.Cells[0].Value.ToString() != parentcode)
                    {
                        string childCode = dr.Cells[0].Value.ToString();
                        int quantity = int.Parse(dr.Cells[1].Value.ToString());

                        MessageBox.Show("Cập nhật ràng buộc Parent code : " + parentcode + " Child code : " + childCode + " Quantity : " + quantity);

                        if (_ecoBLL.Delete_tblRelationTemp_BLL(parentcode, childCode))
                        {
                            thongbao2 = thongbao2 + "(+) Đã xóa --" + parentcode + "---" + childCode + " -- thành công \n";
                        }
                        else
                        {
                            thongbao2 = thongbao2 + "(!) Lỗi không thể xóa --" + parentcode + "---" + childCode + " -- \n";
                            insertstatus++;
                        }
                    }
                }
                catch (Exception ex)
                {
                    thongbao2 += $"(!) Lỗi ngoại lệ: {ex.Message} \n";
                    insertstatus++;
                }
            }

            if (insertstatus == 0)
            {
                MessageBox.Show(thongbao2);
                return true;
            }
            else
            {
                MessageBox.Show(thongbao2);
                return false;
            }
        }
    }
}