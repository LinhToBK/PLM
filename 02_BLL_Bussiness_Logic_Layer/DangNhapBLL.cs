using PLM_Lynx._01_DAL_Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PLM_Lynx._02_BLL_Bussiness_Logic_Layer
{
    public class DangNhapBLL
    {
        // Khởi tạo đối tượng DangNhapDAl được kế thừa từ class DangNhapDAL.cs
        private DangNhapDAL userDAL = new DangNhapDAL();

        // ===========================================================
        // Phương thức : Kiểm tra xem đúng tên và mật khẩu hay chưa 
        // ===========================================================
        public bool CheckDangnhapBLL (string username, string password)
        {
            // Có thể bổ sung các xử lý khác , ví dụ mã hóa mật khẩu trước khi gọi đến DAL
            return userDAL.CheckDangnhapDAL(username, password);
        }



        public int GetUserID_BLL(string UserName)
        {
            return userDAL.GetUserID_DAL(UserName);
        }

        public int GetLevel_BLL(string UserName)
        {
            return userDAL.GetLevel_DAL(UserName);
        }

    }
}
