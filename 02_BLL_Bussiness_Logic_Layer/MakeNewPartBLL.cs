using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PLM_Lynx._01_DAL_Data_Access_Layer;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace PLM_Lynx._02_BLL_Bussiness_Logic_Layer
{
    public class MakeNewPartBLL
    {
        MakeNewPartDAL newpartDAL = new MakeNewPartDAL();


        /// 01. INSERT - Chèn New Part vào bảng dữ liệu tblPart
        /// <param name="PartFamily"></param>
        /// <param name="PartName"></param>
        /// <param name="PartDescript"></param>
        /// <returns></returns>
        public bool InsertNewPartBLL(string PartFamily, string PartName, string PartDescript, string PartMaterial)
        {

            // Kiểm tra thông tin nhập vào
            if (string.IsNullOrEmpty(PartFamily)) { return false; }
            if (string.IsNullOrEmpty(PartName)) { return false; }
            return (newpartDAL.InsertNewPartDAL(PartFamily, PartName, PartDescript , PartMaterial));
        }

        public DataTable LoadFamilyBLL()
        {
            return newpartDAL.LoadFamilyDAL();
        }

        public string NewestPartCodeBLL()
        {
            return newpartDAL.NewestPartCodeDAL();
        }

        public bool CapNhatPartLogBLL(string PartCode, string PartLogAdd)
        {
            // Kiểm tra tính hợp lệ của dữ liệu
            if (string.IsNullOrEmpty(PartCode)) { return false; }
            if (string.IsNullOrEmpty(PartLogAdd)) { return false; }

            //  Goi hàm CapNhatPartLogDAL để cập nhật dữ liệu
            return newpartDAL.CapNhatPartLogDAL(PartCode, PartLogAdd);

        }
    }

}
