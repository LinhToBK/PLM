using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PLM_Lynx._01_DAL_Data_Access_Layer;

namespace PLM_Lynx._02_BLL_Bussiness_Logic_Layer
{
    public class ManageFamilyCodeBLL
    {

        private ManageFamilyCodeDAL FamilyDAL = new ManageFamilyCodeDAL();


        /// <summary> 01. SELECT - Lấy tableFamilyCode
        /// <returns></returns>
        public DataTable  LayDataFamilyBLL()
        {
            // Có thêm thêm các nghiệp vụ xử lý ở đây
            return FamilyDAL.LayDataFamilyDAL();
        }



        /// <summary> 02. INSERT - Thêm 1 Code mới vào tblFamily
        /// <param name="FamilyCode"></param>
        /// <param name="FamilyType"></param>
        /// <param name="FamilyDescript"></param>
        /// <returns></returns>
        public bool ThemFamilyCodeBLL ( string FamilyCode, string FamilyType, string FamilyDescript)
        {
            // Kiểm tra dữ liệu đầu vào 
            if(string.IsNullOrEmpty(FamilyCode) || string.IsNullOrEmpty(FamilyType))
                { return false; }


            // Kiểm tra xem có family code nào chưa 
            if(FamilyDAL.CheckFamilyCode(FamilyCode) == true)
            {
                return false;
            }  
            
            return FamilyDAL.ThemFamilyCodeDAL(FamilyCode, FamilyType, FamilyDescript); 


        }



        /// <summary> 03. - UPDATE - Cập nhật 1 dòng của FamilyCode
        /// <param name="familycode"></param>
        /// <param name="familytype"></param>
        /// <param name="familydescript"></param>
        /// <returns></returns>
        public bool CapNhatFamilyCodeBLL(string familycode, string familytype, string familydescript)
        {
            // Kiểm tra dữ liệu đầu vào
            if (string.IsNullOrEmpty(familytype) || string.IsNullOrEmpty(familydescript)) { return false; }

            return FamilyDAL.CapnhatFamilyDAL(familycode, familytype, familydescript);
        }


        public bool XoaFamilyCodeBLL ( string familycode)
        {
            return FamilyDAL.XoaFamilyCodeDAL(familycode);
        }


    }
}
