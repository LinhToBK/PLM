using PLM_Lynx._01_DAL_Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.Data;

namespace PLM_Lynx._02_BLL_Bussiness_Logic_Layer
{
    public class Purchase_V2_BLL
    {
        private Purchase_V2_DAL _purchase_V2_DAL = new Purchase_V2_DAL();

        public List<string> convert_list_contact_person(string ContactPerson)
        {
            string[] contactPersons = ContactPerson.Split('|');
            List<string> contactPersonList = new List<string>();
            foreach (string person in contactPersons)
            {
                if (!string.IsNullOrWhiteSpace(person))
                {
                    contactPersonList.Add(person);
                }
            }
            return contactPersonList;
        }

        public DataTable convert_table_contact_person(string ContactPerson)
        {
            DataTable tbl_ContactPerson = new DataTable();

            string[] contactPersons = ContactPerson.Split('|');
            tbl_ContactPerson.Columns.Add("Name", typeof(string));
            tbl_ContactPerson.Columns.Add("Phone", typeof(string));
            foreach (string person in contactPersons)
            {
                if (!string.IsNullOrWhiteSpace(person))
                {
                    string[] details = person.Split('/');
                    if (details.Length == 2)
                    {
                        DataRow row = tbl_ContactPerson.NewRow();
                        row["Name"] = details[0].Trim();
                        row["Phone"] = details[1].Trim();
                        tbl_ContactPerson.Rows.Add(row);
                    }
                }
            }

            return tbl_ContactPerson;
        }

        public bool Insert_New_PO_BLL(DateTime PODateCreate, DateTime POEstimateDeliveryDate, int POSupplierID, string POSupplierContactPerson, int POCurrencyID, string POUser, int POStatusID, string PORemark, string POPaymentTerm, int WarehouseID, decimal POTotalPayment, int POTaxID, DataTable tblPur_PO_Detail)
        { return _purchase_V2_DAL.Insert_New_PO_DAL(PODateCreate, POEstimateDeliveryDate, POSupplierID, POSupplierContactPerson, POCurrencyID, POUser, POStatusID, PORemark, POPaymentTerm, WarehouseID, POTotalPayment, POTaxID, tblPur_PO_Detail); }

        public bool Insert_NewCurrency_BLL(string Name, decimal Rate)
        {
            return _purchase_V2_DAL.Insert_NewCurrency_DAL(Name, Rate);
        }

        public bool Insert_NewSupplier_BLL(string Code, string Name, string Phone, string Tax, string Location, string Note, string contactperson)
        {
            return _purchase_V2_DAL.Insert_NewSupplier_DAL(Code, Name, Phone, Tax, Location, Note, contactperson);
        }

        public bool Insert_NewUnit_BLL(string Name, decimal Value, string Content)
        {
            return _purchase_V2_DAL.Insert_NewUnit_DAL(Name, Value, Content);
        }

        public bool Insert_NewWareHouse_BLL(string Name)
        {
            return _purchase_V2_DAL.Insert_NewWareHouse_DAL(Name);
        }

        public bool Save_Attachment_File_BLL(int PONumber, DateTime Created_Date, DataTable tbl_Attachment_File)
        {
            bool isOK;
            try
            {
                string _folder_PO = Properties.Settings.Default.PurchaseData;
                string _month = Created_Date.Month.ToString("00");
                string _year = Created_Date.Year.ToString("0000");
                string _folderPath = System.IO.Path.Combine(_folder_PO, "PURCHASE", "PO", _year, _month, PONumber.ToString());
                if (!System.IO.Directory.Exists(_folderPath))
                {
                    System.IO.Directory.CreateDirectory(_folderPath);
                }
                foreach (DataRow row in tbl_Attachment_File.Rows)
                {
                    string fileName = row["FileName"].ToString();
                    string filePath = System.IO.Path.Combine(_folderPath, $"{PONumber}_{fileName}");
                    // Copy the file to _folderPath with the new name
                    System.IO.File.Copy(row["FilePath"].ToString(), filePath, true);
                }
                isOK = true;
            }
            catch (Exception ex)
            {
                isOK = false;
                throw new Exception("Error saving attachment files: " + ex.Message);
            }
            return isOK;
        }

        /// <summary>
        ///  return table [PartCode, PartName, PartPurchasePrice, PartSalePrice, TaxCode, SupplierIDPrefer, TaxIDPrefer, Eable_Purchase, Eable_Inventory, Eable_Sale]
        /// </summary>
        /// <param name="KeySearch"></param>
        /// <returns></returns>
        public DataTable Select_Data_by_KeySearch_BLL(string KeySearch)
        {
            return _purchase_V2_DAL.Select_Data_by_KeySearch_DAL(KeySearch);
        }

        /// <summary>
        /// return int [Newest_PONumber]
        /// </summary>
        /// <returns></returns>
        public int Select_Newest_PONumber_BLL()
        {
            return _purchase_V2_DAL.Select_Newest_PONumber_DAL();
        }

        /// <summary>
        /// return table [ PartID, PartCode ]
        /// </summary>
        /// <param name="tbl_PartCode"></param>
        /// <returns></returns>
        public DataTable Select_PartID_PartCode_BLL(DataTable tbl_PartCode)
        {
            return _purchase_V2_DAL.Select_PartID_PartCode_DAL(tbl_PartCode);
        }

        /// <summary>
        /// return table [PONumber , PartCode, TaxCode, Quantity_Order, Received_Quantity, Price, Unit, Discount, TaxName, Total, CurrencyName, POUser, POWareHouse]
        /// </summary>
        /// <param name="tbl_ListPONumber"></param>
        /// <returns></returns>
        public DataTable Select_tbl_Pur_PO_Detail_for_GRPO_BLL(DataTable tbl_ListPONumber)
        {
            DataTable result = _purchase_V2_DAL.Select_tbl_Pur_PO_Detail_for_GRPO_DAL(tbl_ListPONumber);
            //// Tạo cột mới
            //DataColumn statusColumn = new DataColumn("Status", typeof(string));
            //result.Columns.Add(statusColumn);
            //statusColumn.SetOrdinal(0); // Di chuyển cột về vị trí đầu tiên

            return result;
        }

        /// <summary>
        /// return table [ CurrencyID, CurrencyName, CurrencyRate ]
        /// </summary>
        /// <returns></returns>
        public DataTable Select_tblPur_Currency_BLL()
        {
            return _purchase_V2_DAL.Select_tblPur_Currency_DAL();
        }

        /// <summary>
        /// return table [PartCode, PartName, PartPurchasePrice, PartSalePrice, Eable_Purchase, Eable_Inventory, Eable_Sale, TaxCode, SupplierIDPrefer, TaxIDPrefer]
        /// </summary>
        /// <param name="tbl_PartCode"></param>
        /// <returns></returns>
        public DataTable Select_tblPur_Part_BLL(DataTable tbl_PartCode)
        {
            return _purchase_V2_DAL.Select_tblPur_Part_DAL(tbl_PartCode);
        }

        /// <summary>
        /// return table [ PONumber, PODateCreate, PartCode, PartName, UnitPrice, Quantity_Order, Discount, Amount ]
        /// </summary>
        /// <param name="SupplierID"></param>
        /// <returns></returns>
        public DataTable Select_tblPur_Part_with_SupplierID_BLL(int SupplierID)
        {
            return _purchase_V2_DAL.Select_tblPur_Part_with_SupplierID_DAL(SupplierID);
        }

        public DataTable Select_tblPur_PO_by_CreateDate_BLL(DateTime DateFrom, DateTime DateTo)
        {
            DataTable result = _purchase_V2_DAL.Select_tblPur_PO_by_CreateDate_DAL(DateFrom, DateTo);

            //// Tạo cột mới
            //DataColumn statusColumn = new DataColumn("Status", typeof(bool));
            //result.Columns.Add(statusColumn);
            //statusColumn.SetOrdinal(0); // Di chuyển cột về vị trí đầu tiên

            //// Gán mặc định false cho tất cả các dòng
            //foreach (DataRow row in result.Rows)
            //{
            //    row["Status"] = false;
            //}

            return result;
        }

        public DataTable Select_tblPur_PO_by_CreateDate_BLL(DateTime DateFrom, DateTime DateTo, int ShowRow)
        {
            DataTable result = _purchase_V2_DAL.Select_tblPur_PO_by_CreateDate_DAL(DateFrom, DateTo, ShowRow);

            //// Tạo cột mới
            //DataColumn statusColumn = new DataColumn("Status", typeof(bool));
            //result.Columns.Add(statusColumn);
            //statusColumn.SetOrdinal(0); // Di chuyển cột về vị trí đầu tiên

            //// Gán mặc định false cho tất cả các dòng
            //foreach (DataRow row in result.Rows)
            //{
            //    row["Status"] = false;
            //}

            return result;
        }

        /// <summary>
        /// Method : Lấy dữ liệu bảng tblPur_PO theo PONumber
        /// </summary>
        /// <param name="PONumber"></param>
        /// <returns> Table (PONumber, PODateCreate, POEstimateDeliveryDate, POSupplierID, POSupplierContactPerson, POCurrencyID ,PORemark,POPaymentTerm , WareHouseID, POToTalPayment, POTaxID ) </returns>
        public DataTable Select_tblPur_PO_by_PONumber_BLL(int PONumber)
        {
            return _purchase_V2_DAL.Select_tblPur_PO_by_PONumber_DAL(PONumber);
        }

        /// <summary>
        /// return 
        /// </summary>
        /// <param name="SupplierID"></param>
        /// <param name="ShowRow"></param>
        /// <returns> table [ PONumber, PODateCreate, POEstimateDeliveryDate, SupplierName, POSupplierContactPerson, CurrencyName, POUser, StatusName, WareHouseName, POTotalPayment</returns>
        public DataTable Select_tblPur_PO_by_SupplierID_BLL(int SupplierID, int ShowRow)
        {
            DataTable result = _purchase_V2_DAL.Select_tblPur_PO_by_SupplierID_DAL(SupplierID, ShowRow);
            //// Tạo cột mới
            //DataColumn statusColumn = new DataColumn("Status", typeof(bool));
            //result.Columns.Add(statusColumn);
            //statusColumn.SetOrdinal(0); // Di chuyển cột về vị trí đầu tiên

            //// Gán mặc định false cho tất cả các dòng
            //foreach (DataRow row in result.Rows)
            //{
            //    row["Status"] = false;
            //}

            return result;
        }
        /// <summary>
        /// return 
        /// </summary>
        /// <param name="SupplierID"></param>
        /// <param name="ShowRow"></param>
        /// <returns> table [ PONumber, PODateCreate, POEstimateDeliveryDate, SupplierName, POSupplierContactPerson, CurrencyName, POUser, StatusName, WareHouseName, POTotalPayment</returns>
        public DataTable Select_tblPur_PO_by_SupplierID_BLL(int SupplierID)
        {
            DataTable result = _purchase_V2_DAL.Select_tblPur_PO_by_SupplierID_DAL(SupplierID);
            //// Tạo cột mới
            //DataColumn statusColumn = new DataColumn("Status", typeof(bool));
            //result.Columns.Add(statusColumn);
            //statusColumn.SetOrdinal(0); // Di chuyển cột về vị trí đầu tiên

            //// Gán mặc định false cho tất cả các dòng
            //foreach (DataRow row in result.Rows)
            //{
            //    row["Status"] = false;
            //}

            return result;
        }

        /// <summary>
        ///  return table [ GRPONumber, ReceivedDate, PONumber, WareHouseName, TaxName, ReceivedAmount, CurrencyName ]
        /// </summary>
        /// <param name="SupplierID"></param>
        /// <param name="ShowRow"></param>
        /// <returns> table [ GRPONumber, ReceivedDate, PONumber, WareHouseName, TaxName, ReceivedAmount, CurrencyName ]</returns>
        public DataTable Select_tblPur_GRPO_by_SupplierID_BLL(int SupplierID, int ShowRow)
        {
            DataTable result = _purchase_V2_DAL.Select_tblPur_GRPO_by_SupplierID_DAL(SupplierID, ShowRow);

            return result;
        }
        /// <summary>
        ///  return table [ GRPONumber, ReceivedDate, PONumber, WareHouseName, TaxName, ReceivedAmount, CurrencyName ]
        /// </summary>
        /// <param name="SupplierID"></param>
        /// <param name="ShowRow"></param>
        /// <returns> table [ GRPONumber, ReceivedDate, PONumber, WareHouseName, TaxName, ReceivedAmount, CurrencyName ]</returns>
        public DataTable Select_tblPur_GRPO_by_SupplierID_BLL(int SupplierID)
        {
            DataTable result = _purchase_V2_DAL.Select_tblPur_GRPO_by_SupplierID_DAL(SupplierID);

            return result;
        }

        /// <summary>
        /// return table [ PartCode, PartName, Quantity, UnitPrice, Unit, Discount, Total, TaxCode, RowID ]
        /// </summary>
        /// <param name="PONumber"></param>
        /// <returns></returns>
        public DataTable Select_tblPur_PO_Detail_by_PONumber_BLL(int PONumber)
        {
            return _purchase_V2_DAL.Select_tblPur_PO_Detail_by_PONumber_DAL(PONumber);
        }

        /// <summary>
        /// return table [ StatusID, StatusName ]
        /// </summary>
        /// <returns></returns>
        public DataTable Select_tblPur_Status_BLL()
        {
            return _purchase_V2_DAL.Select_tblPur_Status_DAL();
        }

        /// <summary>
        /// return table [ SupplierID, SupplierCode, SupplierName, SupplierLocation, SupplierPhone, SupplierTaxNumber, SupplierNote, SupplierContactPerson ]
        /// </summary>
        /// <returns></returns>
        public DataTable Select_tblPur_Supplier_BLL()
        {
            return _purchase_V2_DAL.Select_tblPur_Supplier_DAL();
        }

        /// <summary>
        /// return table [ TaxID, TaxCode, TaxName, TaxRate, TaxNote ]
        /// </summary>
        /// <returns></returns>
        public DataTable Select_tblPur_Tax_BLL()
        {
            return _purchase_V2_DAL.Select_tblPur_Tax_DAL();
        }

        /// <summary>
        /// return table [ UnitID, UnitName, UnitValue, UnitContent ]
        /// </summary>
        /// <returns></returns>
        public DataTable Select_tblPur_Unit_BLL()
        {  //
            return _purchase_V2_DAL.Select_tblPur_Unit_DAL();
        }

        /// <summary>
        /// return table [ WareHouseID, WareHouseName ]
        /// </summary>
        /// <returns></returns>
        public DataTable Select_tblPur_WareHouse_BLL()
        {
            return _purchase_V2_DAL.Select_tblPur_WareHouse_DAL();
        }

        /// <summary>
        /// return table [ GRPONumber, ReceivedDate, PONumber, Status, WareHouseName, TaxType, TotalAmount, Currency ]
        /// </summary>
        /// <param name="DateFrom"></param>
        /// <param name="DateTo"></param>
        /// <param name="ShowRow"></param>
        /// <returns></returns>
        public DataTable Select_tblPur_GRPO_by_CreateDate_BLL(DateTime DateFrom, DateTime DateTo, int ShowRow)
        {
            return _purchase_V2_DAL.Select_tblPur_GRPO_by_CreateDate_DAL(DateFrom, DateTo, ShowRow);
        }

        /// <summary>
        /// return table [ GRPONumber, ReceivedDate, PONumber, Status, WareHouseName, TaxType, TotalAmount, Currency ]
        /// </summary>
        /// <param name="DateFrom"></param>
        /// <param name="DateTo"></param>
        /// <returns></returns>
        public DataTable Select_tblPur_GRPO_by_CreateDate_BLL(DateTime DateFrom, DateTime DateTo)
        {
            return _purchase_V2_DAL.Select_tblPur_GRPO_by_CreateDate_DAL(DateFrom, DateTo);
        }

        public bool Update_Existing_PO_BLL(int PONumber, DateTime _dcreate, DateTime _destimate, int SupID, string SupPerson, int CurID, string user, int StatusID, string Remark,
            string PaymentTerm, int WareHouseID, decimal TotalPayment, int TaxID, DataTable tblUpdate, DataTable tblDelete, DataTable tblInsert)
        {
            return _purchase_V2_DAL.Update_Existing_PO_DAL(PONumber, _dcreate, _destimate, SupID, SupPerson, CurID, user, StatusID, Remark,
                PaymentTerm, WareHouseID, TotalPayment, TaxID, tblUpdate, tblDelete, tblInsert);
        }

        public bool Update_ExistingCurrency_BLL(int ID, string Name, decimal Rate)
        {
            return _purchase_V2_DAL.Update_ExistingCurrency_DAL(ID, Name, Rate);
        }

        public bool Update_ExistingStatus_BLL(int StatusID, string StatusName)
        {
            return _purchase_V2_DAL.Update_ExistingStatus_DAL(StatusID, StatusName);
        }

        public bool Update_ExistingSupplier_BLL(int ID, string Code, string Name, string Phone, string Tax, string Location, string Note, string ContactPerson)
        {
            return _purchase_V2_DAL.Update_ExistingSupplier_DAL(ID, Code, Name, Phone, Tax, Location, Note, ContactPerson);
        }

        public bool Update_ExistingUnit_BLL(int ID, string Name, decimal Value, string Content)
        {
            return _purchase_V2_DAL.Update_ExistingUnit_DAL(ID, Name, Value, Content);
        }

        public bool Update_ExistingWareHouse_BLL(int ID, string Name)
        {
            return _purchase_V2_DAL.Update_ExistingWareHouse_DAL(ID, Name);
        }

        public bool Update_tblPur_Part_BLL(DataTable tblUpdated_Part)
        {
            return _purchase_V2_DAL.Update_tblPur_Part_DAL(tblUpdated_Part);
        }

        public bool Insert_New_GRPO_BLL(DataTable _tblPur_GRPO, DataTable _tblPur_GPPO_Detail, DataTable _tblInventory, DataTable _tblInventory_Summary)
        {
            return _purchase_V2_DAL.Insert_New_GRPO_DAL(_tblPur_GRPO, _tblPur_GPPO_Detail , _tblInventory, _tblInventory_Summary);
        }

        /// <summary>
        /// return table [ GRPOID, GRPONumber, PONumber, ReceivedDate, ReceivedAmount, GRPORemark, GRPOStatusID, GRPOCurrencyID, GRPOWareHouseID, GRPOTaxID ]
        /// </summary>
        /// <param name="GRPONumber"></param>
        /// <returns></returns>
        public DataTable Select_tblPur_GRPO_by_GRPONumber_BLL(int GRPONumber)
        {
            return _purchase_V2_DAL.Select_tblPur_GRPO_by_GRPONumber_DAL(GRPONumber);
        }

        /// <summary>
        /// Method : Lấy dữ liệu bảng tblPur_GRPO_Detail theo GRPONumber
        /// </summary>
        /// <param name="GRPONumber"></param>
        /// <returns>Table ( PartCode, PartName, Quantity_Order, QuantityReceived, UnitPriceReceived, DiscountReceived,UnitName, PODetail_RowID , ExpiredDate, TaxCode )</returns>
        public DataTable Select_tblPur_GRPO_Detail_by_GRPONumber_BLL(int GRPONumber)

        {
            return _purchase_V2_DAL.Select_tblPur_GRPO_Detail_by_GRPONumber_DAL(GRPONumber);
        }

        public bool Update_Existing_GRPO_BLL(DataTable _tblPur_Existing_GRPO, DataTable _tblPur_GRPO_Detail , DataTable _tblInventory, DataTable _tblInventory_Summary)
        {
            return _purchase_V2_DAL.Update_Existing_GRPO_DAL(_tblPur_Existing_GRPO, _tblPur_GRPO_Detail, _tblInventory, _tblInventory_Summary);
        }

        public bool Cancelation_Existing_GRPO_BLL(int GRPOID)
        {
            return _purchase_V2_DAL.Cancelation_Existing_GRPO_DAL(GRPOID);
        }

        public bool Cancelation_Existing_PO_BLL(int PONumber)
        {
            return  _purchase_V2_DAL.Cancelation_Existing_PO_DAL(PONumber);
        }

        public bool Closed_Existing_PO_BLL(int PONumber)
        {
            return _purchase_V2_DAL.Closed_Existing_PO_DAL(PONumber);
        }

        public bool Closed_Existing_GRPO_BLL(int GRPONumber)
        {
            return _purchase_V2_DAL.Closed_Existing_GRPO_DAL(GRPONumber);
        }

        public DataTable Select_PartCode_PartName_BLL(DataTable ListPartCode)
        {
            return _purchase_V2_DAL.Select_PartCode_PartName_DAL(ListPartCode);
        }

        public bool Insert_New_APInvoice_BLL(DataTable _tblAPInvoice, DataTable _tblAPInvoice_Detail)
        {
            return _purchase_V2_DAL.Insert_New_APInvoice_DAL(_tblAPInvoice, _tblAPInvoice_Detail);
        }

        /// <summary>
        /// Lấy dữ liệu bảng tblPur_APInvoice trong 1 khoảng thời gian
        /// </summary>
        /// <param name="DateFrom"></param>
        /// <param name="DateTo"></param>
        /// <param name="ShowRow"></param>
        /// <returns> Table ( ID, GRPOID, PONumber, Status, Supplier, Created, Updated, Payment, Currency, Tax )</returns>
        public DataTable Select_tblPur_APInvoice_by_CreateDate_BLL(DateTime DateFrom, DateTime DateTo, int ShowRow)
        {
            return _purchase_V2_DAL.Select_tblPur_APInvoice_by_CreateDate_DAL(DateFrom, DateTo, ShowRow);
        }
        public DataTable Select_tblPur_APInvoice_by_CreateDate_BLL(DateTime DateFrom, DateTime DateTo)
        {
            return _purchase_V2_DAL.Select_tblPur_APInvoice_by_CreateDate_DAL(DateFrom, DateTo);
        }
        /// <summary>
        /// Lấy dữ liệu bảng tblPur_APInvoice theo SupplierID
        /// </summary>
        /// <param name="SupplierID"></param>
        /// <returns>Table ( ID, GRPOID, PONumber, Status, Supplier, Created, Updated, Payment, Currency, Tax )</returns>
        public DataTable Select_tblPur_APInvoice_by_SupplierID_BLL(int SupplierID)
        {
            return _purchase_V2_DAL.Select_tblPur_APInvoice_by_SupplierID_DAL(SupplierID);
        }
        public DataTable Select_tblPur_APInvoice_by_SupplierID_BLL(int SupplierID, int ShowRow)
        {
            return _purchase_V2_DAL.Select_tblPur_APInvoice_by_SupplierID_DAL(SupplierID, ShowRow);
        }


        /// <summary>
        /// Lấy dữ liệu bảng tblPur_APInvoice_Detail theo APInvoiceID
        /// </summary>
        /// <param name="APInvoiceID"></param>
        /// <returns> 
        /// return table (PartCode, PartName, Qty_Received, Qty_Payment, UnitPrice, Discount, Total, Unit, TaxCode, RowID)
        /// </returns>
        public DataTable Select_tblPur_APInvoice_Detail_by_APInvoiceID_BLL(int APInvoiceID)
        {
            return _purchase_V2_DAL.Select_tblPur_APInvoice_Detail_by_APInvoiceID_DAL(APInvoiceID);
        }


        /// <summary>
        /// Lấy dữ liệu bảng tblPur_APInvoice theo APInvoiceID
        /// </summary>
        /// <param name="APInvoiceID"></param>
        /// <returns>
        /// return table ( APInvoiceID, GRPOID, PONumber, APInvoice_SupplierID, CreatedDate, UpdatedDate, APInvoice_ToTalPayment, APInvoice_Remark, APInvoice_StatusID, APInvoice_CurrencyID, APInvoice_TaxID )
        /// </returns>
        public DataTable Select_tblPur_APInvoice_by_APInvoiceID_BLL(int APInvoiceID)
        {
            return _purchase_V2_DAL.Select_tblPur_APInvoice_by_APInvoiceID_DAL(APInvoiceID);
        }


    }
}