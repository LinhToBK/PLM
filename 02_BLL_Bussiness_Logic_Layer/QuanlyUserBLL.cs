using System;
using System.Collections.Generic;
using System.Data;
using PLM_Lynx._01_DAL_Data_Access_Layer;
using System.Data.SqlClient;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PLM_Lynx._02_BLL_Bussiness_Logic_Layer
{
    public class QuanlyUserBLL
    {
        private QuanlyUserDAL UsersDAL = new QuanlyUserDAL();

        /// 01. SELECT - Lấy dữ liệu từ tblUsers
        /// <returns></returns>
        public DataTable LayDatatblUserBLL()
        {
            // có thể thêm xử lý nghiệp vụ tại đây nếu cần
            return UsersDAL.LayDatatblUsers();

        }

        /// 02. SELECT - Lấy dữ liệu từ tblDepartment
        /// <returns></returns>
        public DataTable LayDatatblDepartment()
        {
            // Có thể thêm xử lý nghiệp vụ tại đây nếu cần 
            return UsersDAL.LayDatatblDepartment();
        }

        /// 03. INSERT - Thêm dữ liệu vào tblUsers
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="roles"></param>
        /// <param name="position"></param>
        /// <param name="dept"></param>
        /// <returns></returns>
        public bool ThemUserBLL(string username, string password, string roles, string position, string dept, int level)
        {
            // Kiểm tra dữ liệu đầu vào  nếu cần
            if (string.IsNullOrEmpty(username)) { return false; }
            if (string.IsNullOrEmpty(password)) { return false; }
            if (string.IsNullOrEmpty(roles)) { return false; }
            if (string.IsNullOrEmpty(position)) { return false; }
            if (string.IsNullOrEmpty(dept)) { return false; }



            // Kiểm tra xem dept đã có trong list chưa
            if (UsersDAL.CheckNameDept(dept) == false) { return false; }

            // Nếu không phát sinh vấn đề thì tiến hành thêm dữ liệu
            return UsersDAL.ThemUserDAL(username, password, roles, position, UsersDAL.ConvertNameDept2IDDept(dept), level);
        }


        /// 04. UPDATE - Cập nhật dữ liệu cho tblUsers
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="roles"></param>
        /// <param name="position"></param>
        /// <param name="dept"></param>
        /// <returns></returns>
        public bool CapnhatUserBLL(string username, string password, string roles, string position, string dept, int level)
        {
            //  // Kiểm tra dữ liệu đầu vào  nếu cần
            if (string.IsNullOrEmpty(username)) { return false; }
            if (string.IsNullOrEmpty(password)) { return false; }
            if (string.IsNullOrEmpty(roles)) { return false; }
            if (string.IsNullOrEmpty(position)) { return false; }
            if (string.IsNullOrEmpty(dept)) { return false; }

            // Nếu không phát sinh vấn đề thì tiến hành cập nhật dữ liệu
            return UsersDAL.CapnhatUserDAL(username, password, roles, position, UsersDAL.ConvertNameDept2IDDept(dept), level);
        }


        /// 05. DELETE - Xóa 1 user trong tblUsers 
        /// <param name="username"></param>
        /// <returns></returns>
        public bool XoaUserBLL(string username)
        {
            //  // Kiểm tra dữ liệu đầu vào  nếu cần
            if (string.IsNullOrEmpty(username)) { return false; }

            // Kiểm tra xem Username đã có trong list chưa
            return UsersDAL.XoaUserDAL(username);
        }


        //******************************************************************
        //        THAO TÁC VỚI TBLDEPARTMENT 
        //******************************************************************

        /// 06. INSERT - Thêm 1 department mới vào database
        /// <param name="IDDept"></param>
        /// <param name="NameDept"></param>
        /// <returns></returns>
        public bool ThemDeptBLL(int IDDept, string NameDept)
        {
            if(UsersDAL.CheckNameDept(NameDept)) { return false;} // có đã xuất hiện thì báo lỗi
            
            if(UsersDAL.CheckIDDept(IDDept)) { return false;}

            return UsersDAL.ThemDeptDAL(IDDept, NameDept);
        }

        /// 07. UPDATE - Cập nhật một department vào database
        /// <param name="IDDept"></param>
        /// <param name="NameDept"></param>
        /// <returns></returns>
        public bool CapnhatDeptBLL ( int IDDept, string NameDept)
        {
            return UsersDAL.CapnhatDeptDAL(IDDept,NameDept);
        }


        /// 08. DELETE - Xóa 1 Dept ra khỏi Database
        /// <param name="IDDept"></param>
        /// <returns></returns>
        public bool XoaDeptBLL (int IDDept)
        {
             return UsersDAL.XoaDeptDAL(IDDept);
        }


        //******************************************************************
        //       HỆ THỐNG QUYỀN QUẢN TRỊ
        //******************************************************************
        /// 09. CHECK - Kiểm tra có phải là Admin không
        /// <param name="username"></param>
        /// <returns></returns>
        public  bool IsAdminBLL (string username)
        {
            return UsersDAL.IsAdminDAL(username);
        }

        public bool IsPurchase_BLL(string username)
        {
            return UsersDAL.IsPurchase_DAL(username);
        }



    }
}


