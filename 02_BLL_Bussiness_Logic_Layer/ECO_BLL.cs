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
    public class ECO_BLL
    {
        private FindPartDAL findpartDAL = new FindPartDAL();
        private ECO_DAL ecoDAL = new ECO_DAL();

        public DataTable GetListChildBLL(string ParentCode)
        {
            return ecoDAL.GetListChildDAL(ParentCode);
        }

        public bool CapnhatQuantityBLL(string parentcode, string childcode, int quantity)
        {
            bool check = false;
            
            if(ecoDAL.CapnhatLogPartDAL(parentcode, childcode, quantity) && ecoDAL.CapnhatQuantityDAL(parentcode,childcode, quantity))
            {
                check = true;
            }  
            
            return check;
            
            
        }

        public bool XoaRelationBLL(string parentcode, string childcode)
        {
            bool check = false;
            if(ecoDAL.DeleteLogPartDAL(parentcode,childcode) && ecoDAL.XoaRelationDAL(parentcode,childcode))
            {
                check = true;
            }    
            return check;
        }

        public DataTable GetInforPartBLL(string PartCode)
        {
            return ecoDAL.GetInforPartDAL(PartCode);
        }


        public bool CapnhatInforPartBLL(string partcode, string partname, string partdescipt, string partstage, string statuspartstage)
        {
            return ecoDAL.CapnhatInforPartDAL(partcode,partname,partdescipt,partstage,statuspartstage);
        }
    }
}
