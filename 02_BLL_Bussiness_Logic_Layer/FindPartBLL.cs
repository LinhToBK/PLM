using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PLM_Lynx._01_DAL_Data_Access_Layer;

namespace PLM_Lynx._02_BLL_Bussiness_Logic_Layer
{
    public class FindPartBLL
    {

        private FindPartDAL PartDAL = new FindPartDAL();


        /// 01. Tìm kiếm danh sách Part theo từ khóa
        /// <param name="word"></param>
        /// <returns></returns>
        public  DataTable FindWithWordBLL(string word)
        {
             return(PartDAL.FindwithwordDAL(word));
        }

        public DataTable FindWithWordBLL(string word, string viewrow)
        {
            return (PartDAL.FindwithwordDAL(word, viewrow));
        }



        /// 02. Lấy danh sách ChildPart
        /// <param name="idpart"></param>
        /// <returns></returns>
        public DataTable GetChildBLL( string idpart)
        {
            return(PartDAL.GetChildDAL(Convert.ToInt32(idpart)));
        }


        public DataTable GetParentBLL( string idpart)
        {
            return(PartDAL.GetParentDAL(Convert.ToInt32(idpart)));
        }

        public DataTable GetListNearBLL ( int NoRow)
        {
            return ( PartDAL.GetListNearDAL(NoRow) );
        }

        public DataTable GetBOMBLL(string IDPart)
        {
            return PartDAL.GetBOMDAL(Convert.ToInt32(IDPart));
        }


    }
}
