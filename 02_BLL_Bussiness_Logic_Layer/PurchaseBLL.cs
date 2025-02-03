using Azure.Core;
using PLM_Lynx._01_DAL_Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
              return makeNewPODAL_.InsertNewPODAL(POCode, PODate, PONhanVien, POPartlist, POAmount, PONote, POSupplierID);
        }

    }
}
