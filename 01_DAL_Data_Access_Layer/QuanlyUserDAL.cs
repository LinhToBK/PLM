using System;
using System.Collections.Generic;
using System.Data;
//using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace PLM_Lynx._01_DAL_Data_Access_Layer
{
    public class QuanlyUserDAL
    {
        private  string Datacon = Properties.Settings.Default.Datacon;

  
        /// 01. [SELECT] Lấy Database từ bảng tblUsers
        /// 
        /// </summary>
        /// <returns></returns>
        public DataTable LayDatatblUsers ()
        {
            DataTable BangDuLieu = new DataTable ();
            using (SqlConnection conn = new SqlConnection(Datacon))
            {
                string sql_query = "select c.Username, c.Passwords, c.Roles, c.Position,d.Deptname   from tblUsers as c inner join tblDepartment as d on c.Department = d.DeptID";

                SqlCommand cmd = new SqlCommand (sql_query, conn);
                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                conn.Open ();
                adap.Fill(BangDuLieu);
            } 
            return BangDuLieu;
        }

        /// 02. [SELECT] Lấy Database từ bảng tblDepartment
        /// 
        /// </summary>
        /// <returns></returns>
        public DataTable LayDatatblDepartment()
        {
            DataTable BangDuLieu = new DataTable();
            using ( SqlConnection conn = new SqlConnection(Datacon))
            {
                string sql_query = "select * from tblDepartment";
                SqlCommand cmd = new SqlCommand(sql_query, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                conn.Open ();
                adapter.Fill(BangDuLieu);
            }    
            return BangDuLieu ;
        }

        /// 03. [INSERT] Thêm User mới vào bảng tblUser
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="role"></param>
        /// <param name="position"></param>
        /// <param name="dept"></param>
        /// <returns></returns>
        public bool ThemUserDAL(string username, string password , string role , string position,int dept )
        {
            using (SqlConnection con = new SqlConnection(Datacon))
            {
                string sql_query = "insert into tblUsers ( Username, Passwords, Roles, Position, Department) values (";
                sql_query = sql_query + "@Username, @Password, @Roles, @Position , @Department )";
                SqlCommand cmd = new SqlCommand(sql_query, con);
                //cmd.Parameters.AddWithValue("@Username", username);
                //cmd.Parameters.AddWithValue("@Password", password);
                //cmd.Parameters.AddWithValue("@Roles", role);
                //cmd.Parameters.AddWithValue("@Position", position);
                cmd.Parameters.Add("@Username", SqlDbType.NVarChar).Value = username;
                cmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = password;
                cmd.Parameters.Add("@Roles", SqlDbType.NVarChar).Value = role;
                cmd.Parameters.Add("@Position", SqlDbType.NVarChar).Value = position;
                cmd.Parameters.AddWithValue("@Department", dept);
                //--------------------------
                con.Open ();
                int result;
                try
                {
                     result = cmd.ExecuteNonQuery();
                }
                catch
                {
                    return false;
                }
                return result ==1 ;  // Trả về giá trị true nếu thêm thành công 

            }

        }

        /// 04. [CHECK] Kiểm tra User có trùng với giá trị nào trong bảng tblUsers không ?
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="role"></param>
        /// <param name="position"></param>
        /// <param name="dept"></param>
        /// <returns></returns>
        public bool CheckUser(string username, string password, string role, string position, int dept)
        {
            using (SqlConnection conn = new SqlConnection(Datacon))
            {
                conn.Open();
                string sql_query = @"select COUNT(1) from tblUsers where Username = @Username and Passwords = @Password ";
                sql_query = sql_query + " and Roles = @Roles and Position = @Position and Department = @Department ";

                SqlCommand cmd = new SqlCommand(sql_query, conn);
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Password", password);
                cmd.Parameters.AddWithValue("@Roles", role);
                cmd.Parameters.AddWithValue("@Position", position);
                cmd.Parameters.AddWithValue("@Department", dept);

                int count;
                try
                {
                    count = (int)cmd.ExecuteNonQuery();
                }
                catch
                {
                    return false; // Nếu không tìm thấy thì là OK
                }
                return count == 1; // trả về true nếu tìm thấy bản ghi

            }
        }

        /// 05. [CHECK] Kiểm tra Deptname có tồn tại trong tblDepartment hay không 
        /// 
        /// </summary>
        /// <param name="NameDept"></param>
        /// <returns></returns>
        public bool CheckNameDept ( string NameDept)
        {
            using(SqlConnection conn = new SqlConnection(Datacon))
            {
                conn.Open();
                string sql_query = @"select COUNT(1) from tblDepartment where Deptname = @NameDept";
                SqlCommand cmd = new SqlCommand(sql_query, conn);
                cmd.Parameters.AddWithValue("@NameDept", NameDept);

                int count;
                try
                {
                    count = (int)cmd.ExecuteScalar();
                }
                catch { return false; }
                return count == 1; // Trả về giá trị true nếu tìm thấy bản ghi
            } 
                
        }

        /// 06. [CONVERT] Chuyển đổi từ DeptName sang ID Dept
        /// 
        /// </summary>
        /// <param name="NameDept"></param>
        /// <returns></returns>
        public int ConvertNameDept2IDDept(string NameDept)
        {
            using (SqlConnection conn = new SqlConnection(Datacon))
            {
                conn.Open();
                string sql_query = "select DeptID  from tblDepartment where Deptname = @Namedept";
                SqlCommand cmd = new SqlCommand (sql_query, conn);
                cmd.Parameters.AddWithValue("@Namedept", NameDept);
                int i;
                try
                {
                    // Thực thi câu lệnh và kiểm tra giá trị trả về
                    object result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        i= Convert.ToInt32 (result);
                    }
                    else
                    {
                       i =  0; // Không có kết quả
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex.Message);
                    i = 0;
                }
                return i;
            }
        }

        /// 07. [UPDATE] Cập nhật một Username trong database
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="role"></param>
        /// <param name="position"></param>
        /// <param name="dept"></param>
        /// <returns></returns>
        public bool CapnhatUserDAL(string username, string password, string role, string position, int dept)
        {
            using (SqlConnection con = new SqlConnection(Datacon))
            {

                string sql_query = "update tblUsers set ";
                sql_query = sql_query + "Passwords = @Password, Roles = @Roles, Position = @Position ,Department = @Department  ";
                sql_query = sql_query + "where Username = @Username ";
                SqlCommand cmd = new SqlCommand(sql_query, con);
                cmd.Parameters.Add("@Username", SqlDbType.NVarChar).Value = username;
                cmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = password;
                cmd.Parameters.Add("@Roles", SqlDbType.NVarChar).Value = role;
                cmd.Parameters.Add("@Position", SqlDbType.NVarChar).Value = position;
                cmd.Parameters.AddWithValue("@Department", dept);
                //--------------------------
                con.Open();
                int result;
                try
                {
                    result = cmd.ExecuteNonQuery();
                }
                catch
                {
                    return false;
                }
                return result == 1;  // Trả về giá trị true nếu thêm thành công 

            }

        }

        /// 08. [DELETE] Xóa User đang trỏ trong Database 
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public bool XoaUserDAL(string username )
        {
            using (SqlConnection con = new SqlConnection(Datacon))
            {

                string sql_query = "delete tblUsers where Username = @Username";
                SqlCommand cmd = new SqlCommand(sql_query, con);
                cmd.Parameters.AddWithValue("@Username", username);
                //--------------------------
                con.Open();
                int result;
                try
                {
                    result = cmd.ExecuteNonQuery();
                }
                catch
                {
                    return false;
                }
                return result == 1;  // Trả về giá trị true nếu thêm thành công 

            }

        }

        /// 10. [CHECK] Kiểm tra User có tồn tại trong database không ?
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public bool KiemtraUsernameTontaiOK(string username)
        {
            using (SqlConnection conn = new SqlConnection(Datacon))
            {
                conn.Open();
                string sql_query = @"select COUNT(1)  from tblUsers where Username = @Username";
                SqlCommand cmd = new SqlCommand(sql_query, conn);
                cmd.Parameters.AddWithValue("@Username", username);
                int count;
                try
                {
                    count = (int)cmd.ExecuteScalar();
                }
                catch { return false; }
                return count == 1; // Trả về giá trị true nếu tìm thấy bản ghi
            }

        }

        /// 11. [INSERT] Department mới vào Database
        /// </summary>
        /// <param name="DeptId"></param>
        /// <param name="NameDept"></param>
        /// <returns></returns>
        public bool ThemDeptDAL(int DeptId, string NameDept)
        {
            using (SqlConnection con = new SqlConnection(Datacon))
            {
                string sql_query = " insert into tblDepartment(DeptID, Deptname) values ( ";
                sql_query = sql_query + " @DeptID ,  @Deptname ) ";
                SqlCommand cmd = new SqlCommand(sql_query, con);
                cmd.Parameters.AddWithValue("@DeptID", DeptId);
                cmd.Parameters.AddWithValue("@Deptname", NameDept );
                //--------------------------
                con.Open();
                int result;
                try
                {
                    result = cmd.ExecuteNonQuery();
                }
                catch
                {
                    return false;
                }
                return result == 1;  // Trả về giá trị true nếu thêm thành công 
            }

        }  

        /// 12.[CHECK] IDDept có tồn tại hay không ? 
        /// </summary>
        /// <param name="IDDept"></param>
        /// <returns></returns>
        public bool CheckIDDept(int IDDept)
        {
            using (SqlConnection conn = new SqlConnection(Datacon))
            {
                conn.Open();
                string sql_query = @"select COUNT(1) from tblDepartment where DeptID = @IDDept";
                SqlCommand cmd = new SqlCommand(sql_query, conn);
                cmd.Parameters.AddWithValue("@IDDept", IDDept);

                int count;
                try
                {
                    count = (int)cmd.ExecuteScalar();
                }
                catch { return false; }
                return count == 1; // Trả về giá trị true nếu tìm thấy bản ghi
            }

        }   

        /// 13.[UPDATE] sửa tên của một Department
        /// </summary>
        /// <param name="IDDept"></param>
        /// <param name="NameDept"></param>
        /// <returns></returns>
        public bool CapnhatDeptDAL(int IDDept, string NameDept)
        {
            using (SqlConnection con = new SqlConnection(Datacon))
            {
                // update tblDepartment set Deptname = 'HR Nhan su' where DeptID = 6

                string sql_query = @"update tblDepartment set Deptname = @Deptname where DeptID = @DeptID ";
                //sql_query = sql_query + "where DeptID = @DeptID ";
                SqlCommand cmd = new SqlCommand(sql_query, con);
                cmd.Parameters.AddWithValue("@Deptname", NameDept);
                cmd.Parameters.AddWithValue("@DeptID", IDDept);
                //--------------------------
                con.Open();
                int result;
                try
                {
                    result = cmd.ExecuteNonQuery();
                }
                catch
                {
                    return false;
                }
                return result == 1;  // Trả về giá trị true nếu thêm thành công 

            }
        } 

        /// 14. [DELETE] Xóa 1 department ra khỏi Database
        /// <param name="IDDept"></param>
        /// <returns></returns>
        public bool XoaDeptDAL(int IDDept)
        {
            using (SqlConnection con = new SqlConnection(Datacon))
            {
                string sql_query = "delete tblDepartment where DeptID = @DeptID";
                SqlCommand cmd = new SqlCommand(sql_query, con);
                cmd.Parameters.AddWithValue("@DeptID", IDDept);
                //--------------------------
                con.Open();
                int result;
                try
                {
                    result = cmd.ExecuteNonQuery();
                }
                catch
                {
                    return false;
                }
                return result == 1;  // Trả về giá trị true nếu thêm thành công 

            }
        }


        /// 15. [CHECK] Kiểm tra xem có phải là Admin hay không? 
        /// <param name="username"></param>
        /// <returns></returns>
        public bool IsAdminDAL(string username)
        {
            using (SqlConnection conn = new SqlConnection(Datacon))
            {
                // select COUNT(1) from tblUsers where Username = N'Tô Văn Linh' and Roles = N'Admin'

                conn.Open();
                string sql_query = @"select COUNT(1) from tblUsers where Username = @Username and Roles = 'Admin' ";
                SqlCommand cmd = new SqlCommand(sql_query, conn);
                cmd.Parameters.AddWithValue("@Username", username);

                int count;
                try
                {
                    count = (int)cmd.ExecuteScalar();
                }
                catch { return false; }
                return count == 1; // Trả về giá trị true nếu tìm thấy bản ghi
            }

        }
    }
}
