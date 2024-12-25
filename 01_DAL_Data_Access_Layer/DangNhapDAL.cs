using System;
using System.Collections.Generic;
using System.Data;
//using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace PLM_Lynx._01_DAL_Data_Access_Layer
{
    public class DangNhapDAL
    {
        private string Dataconnect = Properties.Settings.Default.Datacon;


        // ========================================================================
        // PHƯƠNG THỨC :01.  Kiểm tra xem đúng với tên và mật khẩu đăng nhập không 
        // ========================================================================

        public bool CheckDangnhapDAL (string username , string password )
        {
            using (SqlConnection conn = new SqlConnection(Dataconnect))
            {
                conn.Open();
                string sql_query = @"select COUNT(1) from tblUsers where Username = @Username and Passwords = @Password ";
                SqlCommand cmd = new SqlCommand (sql_query, conn);
                cmd.Parameters.Add("@Username", SqlDbType.NVarChar).Value = username;
                cmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = password;

                //cmd.Parameters.AddWithValue("@Password", password);


                int count; 
                try
                {
                    count = (int)cmd.ExecuteScalar ();

                }
                catch 
                {
                    return false;
                }

                return count == 1; // trả về true nếu tìm thấy bản ghi

            }


        }

        //-- ----------------------------------------------------------------------

        // ========================================================================
        // PHƯƠNG THỨC :02. Lấy tên của Database
        // ========================================================================
        public string LayDatabaseName()
        {
            using (SqlConnection conn = new SqlConnection(Dataconnect))
            {
                conn.Open();
                return conn.Database;
            }
        }
    }
}
