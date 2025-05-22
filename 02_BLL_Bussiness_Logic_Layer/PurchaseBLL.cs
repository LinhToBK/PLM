using PLM_Lynx._01_DAL_Data_Access_Layer;
using System;
using System.Data;

namespace PLM_Lynx._02_BLL_Bussiness_Logic_Layer
{
    public class PurchaseBLL
    {
        private PurchaseDAL purchaseDAL = new PurchaseDAL();
        private MakeNewPO_DAL makeNewPODAL_ = new MakeNewPO_DAL();

        public bool CapnhatPriceBLL(string PartCode, string PartPrice, string ExportPrice, string username)
        {
            return purchaseDAL.CapnhatPriceDAL(PartCode, PartPrice, ExportPrice, username);
        }

        public bool CapnhatPriceBLL(DataTable ListItem_Update_Price)
        {
            return purchaseDAL.CapnhatPriceDAL(ListItem_Update_Price);
        }

        public tblUsers GetUserInfor(string staffname)
        {
            return makeNewPODAL_.GetUserInfor_DAL(staffname);
        }

        public int Get_PONumber_BLL()
        {
            return makeNewPODAL_.Get_PONumber_DAL();
        }

        public DataTable GetListSupplier()
        {
            return makeNewPODAL_.GetListSupplier_DAL();
        }

        public DataTable GetAllInforSupplier_BLL()
        {
            return purchaseDAL.GetAllInforSupplier_DAL();
        }

        public tblSupplier GetInforSupplier(string SupplierName)
        {
            return makeNewPODAL_.GetInforSupplier_DAL(SupplierName);
        }

        public DataTable FindwithwordBLL(string KeySearch)
        {
            return makeNewPODAL_.FindwithwordDAL(KeySearch);
        }

        public bool InsertNewPO_BLL(int PONumber, int POSupplierID, DateTime PODateCreate, int POCurrencyID, int POStatusID, string POUser, string POPaymentTerm, string PORemark, decimal TotalAmount)
        {
            return makeNewPODAL_.InsertNewPO_DAL(PONumber, POSupplierID, PODateCreate, POCurrencyID, POStatusID, POUser, POPaymentTerm, PORemark, TotalAmount);
        }

        public bool InsertListItems_to_tblPOItems_BLL(DataTable data_ListItems)
        {
            return makeNewPODAL_.InsertListItems_to_tblPOItems_DAL(data_ListItems);
        }

        public bool InsertNewSupplierBLL(string Name, string Phone, string Tax, string Location, string Rep, string Note)
        {
            return purchaseDAL.InsertNewSupplierDAL(Name, Phone, Tax, Location, Rep, Note);
        }

        public bool UpdateOneSupplierBLL(string Name, string Phone, string TaxID, string Location, string Representative, string Note, int ID)
        {
            return purchaseDAL.UpdateOneSupplierDAL(Name, Phone, TaxID, Location, Representative, Note, ID);
        }

        public bool DeleteOneSupplierBLL(string Name)
        {
            return purchaseDAL.DeleteOneSupplierDAL(Name);
        }

        public DataTable AllInforPObyKeySearchBLL(string keysearch, bool byPart)
        {
            return purchaseDAL.AllInforPObyKeySearchDAL(keysearch, byPart);
        }

        public DataTable GetInfor1PObyPOCodeBLL(string POCode)
        {
            return purchaseDAL.GetInfor1PObyPOCodeDAL(POCode);
        }

        public DataTable GetInfor1Supplier_ByID_BLL(int ID)
        {
            return purchaseDAL.GetInfor1Supplier_ByID_DAL(ID);
        }

        public string GetPartCode_BLL(int IDPart)
        {
            return purchaseDAL.GetPartCode_DAL(IDPart);
        }

        public string GetPartName_BLL(int IDPart)
        {
            return purchaseDAL.GetPartName_DAL(IDPart);
        }

        public bool UpdateStatusPO_BLL(string POCode, string NewStatus)
        {
            return purchaseDAL.UpdateStatusPO_DAL(POCode, NewStatus);
        }

        public bool CheckFolderExist(string POCode)
        {
            bool status = false;
            // MessageBox.Show("CheckExist: " + POCode);
            POCode = POCode.Replace("/", "_");
            string[] devide = POCode.Split('-');
            string POYear = devide[0];
            string POMonth = devide[1];
            string POPath = Properties.Settings.Default.POData;

            // Kiểm tra đường dẫn, nếu không có thì tạo mới
            if (!System.IO.Directory.Exists(POPath))
            {
                //System.IO.Directory.CreateDirectory(POPath);
                // Kiểm tra điều kiện FolderData phải chung với đường dẫn của file config
                status = false;
            }
            else
            {
                // Kiểm tra đường dẫn năm, nếu không có thì tạo mới
                if (!System.IO.Directory.Exists(POPath + "\\" + POYear))
                {
                    System.IO.Directory.CreateDirectory(POPath + "\\" + POYear);
                    status = false;
                }
                // Kiểm tra đường dẫn tháng, nếu không có thì tạo mới
                if (!System.IO.Directory.Exists(POPath + "\\" + POYear + "\\" + POMonth))
                {
                    System.IO.Directory.CreateDirectory(POPath + "\\" + POYear + "\\" + POMonth);
                    status = false;
                }
                // Kiểm tra đường dẫn PO, nếu không có thì tạo mới
                if (!System.IO.Directory.Exists(POPath + "\\" + POYear + "\\" + POMonth + "\\" + POCode))
                {
                    System.IO.Directory.CreateDirectory(POPath + "\\" + POYear + "\\" + POMonth + "\\" + POCode);
                    status = false;
                }
                else
                {
                    status = true;
                }
            }

            return status;
        }

        public DataTable GetFileList(string POCode)
        {
            POCode = POCode.Replace("/", "_");
            string[] devide = POCode.Split('-');
            string POYear = devide[0];
            string POMonth = devide[1];
            string POPath = Properties.Settings.Default.POData;
            DataTable dt = new DataTable();
            dt.Columns.Add("Name");
            dt.Columns.Add("Exension");
            dt.Columns.Add("Path");
            dt.Columns.Add("Size");
            dt.Columns.Add("Date");

            if (System.IO.Directory.Exists(POPath + "\\" + POYear + "\\" + POMonth + "\\" + POCode))
            {
                System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(POPath + "\\" + POYear + "\\" + POMonth + "\\" + POCode);
                foreach (var file in dir.GetFiles())
                {
                    DataRow dr = dt.NewRow();

                    dr["Name"] = System.IO.Path.GetFileNameWithoutExtension(file.Name);
                    dr["Path"] = file.FullName;
                    dr["Size"] = file.Length / 1024;
                    dr["Date"] = file.LastWriteTime.ToString();
                    dr["Exension"] = file.Extension;
                    dt.Rows.Add(dr);
                }
            }
            return dt;
        }

        public string GetFolderPONO(string POCode)
        {
            POCode = POCode.Replace("/", "_");
            string[] devide = POCode.Split('-');
            string POYear = devide[0];
            string POMonth = devide[1];
            string POPath = Properties.Settings.Default.POData;
            string path = "";
            if (System.IO.Directory.Exists(POPath + "\\" + POYear + "\\" + POMonth + "\\" + POCode))
            {
                path = POPath + "\\" + POYear + "\\" + POMonth + "\\" + POCode;
            }
            return path;
        }

        public DataTable GetChildPartBLL(int IDPart)
        {
            return purchaseDAL.GetChildPartDAL(IDPart);
        }

        // =========================================================
        // ========= CHANGE FORMAT PURCHASE ================
        // =========================================================

        /// <summary>
        ///  01. Lấy bảng danh sách đơn vị tiền tệ
        /// </summary>
        /// <returns></returns>
        public DataTable Get_tblMoneytype_BLL()
        {
            return purchaseDAL.Get_tblMoneyType_DAL();
        }

        /// <summary>
        /// 02. Lấy bảng thông tin chi tiết của Part từ danh sách PartCode
        /// </summary>
        /// <param name="ListPartCode"></param>
        /// <returns></returns>
        public DataTable QueryInforItemPO_BLL(DataTable ListPartCode)
        {
            return purchaseDAL.QueryInforItemPO_DAL(ListPartCode);
        }

        public DataTable Get_tblUnitType_BLL()
        {
            return purchaseDAL.Get_tblUnitType_DAL();
        }

        public DataTable Get_POInformation_BLL(DateTime startdate, DateTime endate)
        {
            return purchaseDAL.Get_POInformation_DAL(startdate, endate);
        }

        public DataTable Get_POInformation_BLL(DateTime startdate)
        {
            return purchaseDAL.Get_POInformation_DAL(startdate);
        }

        public DataTable Get_POInformation_BLL(string PartCode)
        {
            return purchaseDAL.Get_POInformation_DAL(PartCode);
        }

        public DataTable Get_tblPOItems_BLL(int PONumber)
        {
            return purchaseDAL.Get_tblPOItems_DAL(PONumber);
        }

        public DataTable Get_tblPOInformation_BLL(int PONumber)
        {
            return purchaseDAL.Get_tblPOInformation_DAL(PONumber);
        }

        public DataTable Get_tblPOStatus_BLL()
        {
            return purchaseDAL.Get_tblPOStatus_DAL();
        }
    }
}