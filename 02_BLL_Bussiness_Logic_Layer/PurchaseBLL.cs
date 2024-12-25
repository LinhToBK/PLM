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

        public bool CapnhatPriceBLL(string PartCode, string PartPrice)
        {
            return purchaseDAL.CapnhatPriceDAL(PartCode, PartPrice);
        }
    }
}
