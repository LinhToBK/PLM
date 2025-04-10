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

        public DataTable GetInforPartBLL(string partcode)
        {
            return (relation_partDAL.GetInforPartDAL(partcode));
        }

        /// <summary>
        /// 01 . Kiểm tra xem PartChild có nằm trong tblRelation hay không ?
        /// </summary>
        /// <param name="partcode"></param>
        /// <param name="partchild"></param>
        /// <returns></returns>
        public bool CheckPartChild(string partcode, string partchild)
        {
            DataTable dt = relation_partDAL.FindChildDAL(partcode);
            if (dt.Rows.Count == 0)
            {
                return false; // không có dữ liệu
            }

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

        /// <summary>
        /// 02. Kiểm tra xem PartChild có nằm trong tblRelationTemp hay không ?
        /// </summary>
        /// <param name="partcode"></param>
        /// <param name="partchild"></param>
        /// <returns></returns>
        public bool CheckPartChild_in_tblRelationTemp_BLL(string partcode, string partchild)
        {
            DataTable dt = relation_partDAL.FindChild_In_tblRelationTemp_DAL(partcode);
            if (dt.Rows.Count == 0)
            {
                return false;
            }

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

        /// <summary>
        /// 03. Kiểm tra xem PartParent có nằm trong tblRelation hay không ?
        /// </summary>
        /// <param name="partcode"></param>
        /// <param name="partparent"></param>
        /// <returns></returns>
        public bool CheckPartParent(string partcode, string partparent)
        {
            DataTable dt = relation_partDAL.FindParentDAL(partcode);
            if (dt.Rows.Count == 0)
            {
                return false; // không có dữ liệu
            }

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

        /// <summary>
        ///  04. Kiểm tra xem PartParent có nằm trong tblRelationTemp hay không ?
        /// </summary>
        /// <param name="partcode"></param>
        /// <param name="partparent"></param>
        /// <returns></returns>
        public bool CheckPartParent_in_tblRelationTemp_BLL(string partcode, string partparent)
        {
            DataTable dt = relation_partDAL.FindParent_in_tblRelationTemp_DAL(partcode);
            if (dt.Rows.Count == 0)
            {
                return false; // không có dữ liệu
            }

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