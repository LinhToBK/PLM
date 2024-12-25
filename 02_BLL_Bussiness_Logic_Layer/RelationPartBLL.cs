
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
    public class RelationPartBLL
    {
        private RelationPartDAL relation_partDAL = new RelationPartDAL();

        /// 01.SELECT -  Tìm kiếm danh sách Part theo từ khóa
        /// <param name="word"></param>
        /// <returns></returns>
        public DataTable FindWithWordBLL(string word)
        {
            return (relation_partDAL.FindwithwordDAL(word));
        }

        public DataTable GetInforPartBLL ( string partcode)
        {
            return (relation_partDAL.GetInforPartDAL(partcode));
        }


        public bool CheckPartChild(string partcode, string partchild)
        {
            DataTable dt = relation_partDAL.FindChildDAL(partcode);

            foreach (DataRow dr in dt.Rows)
            {
                if (dr[0].Equals(partchild))   // So sanh với cột đầu tiền
                {
                     // nếu trùng
                     return true;
                }   
            } 
            return false;
                
        }

        public bool CheckPartParent(string partcode, string partparent)
        {
            DataTable dt = relation_partDAL.FindParentDAL(partcode);

            foreach (DataRow dr in dt.Rows)
            {
                if (dr[0].Equals(partparent))   // So sanh với cột đầu tiền
                {
                    // nếu trùng
                    return true;
                }
            }
            return false;

        }


        public bool InsertNewRelationBLL(string ParentCode, string ChildCode, int Quantity)
        {
            return relation_partDAL.InsertNewRelationDAL(ParentCode, ChildCode, Quantity);
        }




    }
}
