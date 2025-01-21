using PLM_Lynx._01_DAL_Data_Access_Layer;
using System;
using System.Collections.Generic;
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
            return makeNewPODAL_.GetUserInfor(staffname);
        }
    }
}
