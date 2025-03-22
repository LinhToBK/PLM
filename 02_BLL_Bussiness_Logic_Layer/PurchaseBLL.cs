using Azure.Core;
using PLM_Lynx._01_DAL_Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PLM_Lynx._02_BLL_Bussiness_Logic_Layer
{
    public class PurchaseBLL
    {
        private PurchaseDAL purchaseDAL = new PurchaseDAL();
        private MakeNewPO_DAL makeNewPODAL_  = new MakeNewPO_DAL();

        public bool CapnhatPriceBLL(string PartCode, string PartPrice)
        {
            return purchaseDAL.CapnhatPriceDAL(PartCode, PartPrice);
        }

        public tblUsers GetUserInfor(string staffname)
        {
            return makeNewPODAL_.GetUserInfor_DAL(staffname);
        }

        public tblPO GetInforPO()
        {
            return makeNewPODAL_.GetInforPO_DAL();
        }

        public DataTable GetListSupplier()
        {
            return makeNewPODAL_.GetListSupplier_DAL();
        }


        public tblSupplier GetInforSupplier(string SupplierName)
        {
            return makeNewPODAL_.GetInforSupplier_DAL(SupplierName);
        }

        public DataTable FindwithwordBLL(string KeySearch)
        {
            return makeNewPODAL_.FindwithwordDAL(KeySearch); 
        }
        public bool InsertNewPOBLL(string POCode, string PODate, string PONhanVien, string POPartlist, decimal POAmount, string PONote, int POSupplierID)
        {
            //MessageBox.Show("POCode: " + POCode + "\nPODate: " + PODate + "\nPONhanVien: " + PONhanVien + "\nPOPartlist: " + POPartlist + "\nPOAmount: " + POAmount + "\nPONote: " + PONote + "\nPOSupplierID: " + POSupplierID);
            return makeNewPODAL_.InsertNewPODAL(POCode, PODate, PONhanVien, POPartlist, POAmount, PONote, POSupplierID);
        }


        public DataTable GetAllInforSupplierBLL()
        {
           return purchaseDAL.GetAllInforSupplierDAL();
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

    }
}
