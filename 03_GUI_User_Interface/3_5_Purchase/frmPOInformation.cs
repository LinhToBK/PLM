using PLM_Lynx._02_BLL_Bussiness_Logic_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PLM_Lynx._03_GUI_User_Interface._3_5_Purchase
{
    public partial class frmPOInformation : Form
    {
        /// <summary>
        /// 01. Khởi tạo các biến
        /// </summary>
        ///
        private PurchaseBLL _purchaseBLL = new PurchaseBLL(); // Khởi tạo lớp PurchaseBLL để gọi các hàm trong lớp này

        public int PONumber { get; set; } // Số PO

        /// <summary>
        /// Thông tin nhà cung cấp
        /// </summary>
        // SupplierID , SupplierName, SupplierPhone, SupplierLocation, SupplierTaxNumber, SupplierReprsentative, SupplierNote
        private int SupplierID { get; set; } // ID nhà cung cấp

        private string SupplierName { get; set; } // Tên nhà cung cấp
        private string SupplierPhone { get; set; } // Số điện thoại nhà cung cấp
        private string SupplierLocation { get; set; } // Địa chỉ nhà cung cấp
        private string SupplierTaxNumber { get; set; } // Mã số thuế nhà cung cấp
        private string SupplierReprsentative { get; set; } // Người đại diện nhà cung cấp
        private string SupplierNote { get; set; } // Ghi chú nhà cung cấp

        /// <summary>
        /// Thông tin chung của PO
        /// </summary>
        /// PONumber, PODateCreate, POStatus, POCurrency, POAmount, POPayment, PORemark
        private DateTime PODateCreate { get; set; } // Ngày tạo PO

        private string POStatus { get; set; } // Trạng thái PO
        private string POCurrency { get; set; } // Loại tiền tệ của PO
        private double POAmount { get; set; } // Tổng số tiền của PO

        private string POPayment { get; set; } // Hình thức thanh toán của PO
        private string PORemark { get; set; } // Ghi chú của PO
        private string POUSer { get; set; } // Người tạo PO

        private DataTable tblPOItems = new DataTable(); // Bảng chứa thông tin PO Items
        private DataTable tblSupplierInformation = new DataTable(); // Bảng chứa thông tin nhà cung cấp
        private DataTable tblPO_Information = new DataTable(); // Bảng chứa thông tin PO
        private DataTable tblPOStatus = new DataTable();

        public frmPOInformation()
        {
            InitializeComponent();
        }

        private void frmPOInformation_Load(object sender, EventArgs e)
        {
            Load_Data();
            dgvListItems_ViewFit();
            dgvListStatus.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Đặt chế độ tự động điều chỉnh kích thước cột
            dgvListStatus.Columns["POStatusID"].Width = 50; // Đặt kích thước cột POStatusName
        }

        private void Load_Data()
        {
            tblPOItems.Columns.Clear();
            tblPOItems = _purchaseBLL.Get_tblPOItems_BLL(PONumber); // Lấy bảng tblPOItems từ lớp PurchaseBLL
            dgvListItems.DataSource = tblPOItems;

            tblPOStatus = _purchaseBLL.Get_tblPOStatus_BLL(); // Lấy bảng tblPOStatus từ lớp PurchaseBLL
            dgvListStatus.DataSource = tblPOStatus;

            tblPO_Information.Columns.Clear();
            tblPO_Information = _purchaseBLL.Get_tblPOInformation_BLL(PONumber); // Lấy bảng tblPO_Information từ lớp PurchaseBLL
                                                                                 //   p.POSupplierID ,
                                                                                 //p.PODateCreate,
                                                                                 //p.POCurrentID,
                                                                                 //p.POStatusID,
                                                                                 //p.POUser ,
                                                                                 //p.POPaymentTerm,
                                                                                 //p.PORemark,
                                                                                 //p.TotalAmount,
                                                                                 //c.CurrentName,
                                                                                 //s.POStatusName
            PODateCreate = Convert.ToDateTime(tblPO_Information.Rows[0]["PODateCreate"].ToString());
            POStatus = tblPO_Information.Rows[0]["POStatusName"].ToString();
            POCurrency = tblPO_Information.Rows[0]["CurrentName"].ToString();
            POAmount = Convert.ToDouble(tblPO_Information.Rows[0]["TotalAmount"].ToString());
            POPayment = tblPO_Information.Rows[0]["POPaymentTerm"].ToString();
            PORemark = tblPO_Information.Rows[0]["PORemark"].ToString();
            POUSer = tblPO_Information.Rows[0]["POUser"].ToString();

            txtPOUser.Text = POUSer;
            txtPONumber.Text = PONumber.ToString();
            txtPayment.Text = POPayment;
            txtRemark.Text = PORemark;
            txtPODateCreate.Text = PODateCreate.ToString("dd/MM/yyyy");
            txtPOStatus.Text = POStatus;
            txtPOCurrency.Text = POCurrency;
            txtTotalAmount.Text = POAmount.ToString("N0"); // Định dạng số tiền với dấu phân cách hàng nghìn

            /// => Supplier
            SupplierID = Convert.ToInt32(tblPO_Information.Rows[0]["POSupplierID"].ToString());
            tblSupplierInformation.Columns.Clear();
            tblSupplierInformation = _purchaseBLL.GetInfor1Supplier_ByID_BLL(SupplierID);

            SupplierName = tblSupplierInformation.Rows[0]["SupplierName"].ToString();
            SupplierPhone = tblSupplierInformation.Rows[0]["SupplierPhone"].ToString();
            SupplierLocation = tblSupplierInformation.Rows[0]["SupplierLocation"].ToString();
            SupplierTaxNumber = tblSupplierInformation.Rows[0]["SupplierTaxNumber"].ToString();
            SupplierNote = tblSupplierInformation.Rows[0]["SupplierNote"].ToString();
            SupplierReprsentative = tblSupplierInformation.Rows[0]["SupplierRepresentative"].ToString();
            // => Hiển thị lên tabcontrol - Suplier Information
            txtSupplierID.Text = SupplierID.ToString();
            txtSupplierName.Text = SupplierName;
            txtSupplierLocation.Text = SupplierLocation;
            txtSupplierTelephone.Text = SupplierPhone;
            txtSupplierRepresentative.Text = SupplierReprsentative;
            txtSupplierTax.Text = SupplierTaxNumber;
            txtSupplierNote.Text = SupplierNote;
        }

        private void dgvListItems_ViewFit()
        {
            // Đặt kích thước cho các cột trong dgvListItems
            // PartID, PartCode,  PartName, Quantity, Unit, Price, Amount, Currency, Tax
            dgvListItems.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Đặt chế độ tự động điều chỉnh kích thước cột
            dgvListItems.Columns["PartID"].Width = 80 ;
            dgvListItems.Columns["PartCode"].Width = 100;
            // dgvListItems.Columns["PartName"].Width = 200;
            dgvListItems.Columns["Quantity"].Width = 80;
            dgvListItems.Columns["Unit"].Width = 80;
            dgvListItems.Columns["Price"].Width = 100;
            dgvListItems.Columns["Amount"].Width = 100;
            dgvListItems.Columns["Tax"].Width = 80;

            // Align các cột
            dgvListItems.Columns["PartID"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvListItems.Columns["PartCode"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvListItems.Columns["PartName"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvListItems.Columns["Quantity"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvListItems.Columns["Unit"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvListItems.Columns["Price"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvListItems.Columns["Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvListItems.Columns["Tax"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Đặt tên cho các cột
            dgvListItems.Columns["PartID"].HeaderText = "ID";

            // Khóa các tính năng thêm sửa xóa trên dgvListItems
            dgvListItems.AllowUserToAddRows = false; // Không cho phép thêm dòng mới
            dgvListItems.AllowUserToDeleteRows = false; // Không cho phép xóa dòng
            dgvListItems.ReadOnly = true; // Chỉ cho phép đọc dữ liệu
        }
    }
}