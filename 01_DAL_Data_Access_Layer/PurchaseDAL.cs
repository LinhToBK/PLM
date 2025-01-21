using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using DataTable = System.Data.DataTable;
using Azure.Core;

namespace PLM_Lynx._01_DAL_Data_Access_Layer
{
    public class PurchaseDAL
    {
        private string Dataconnect = Properties.Settings.Default.Datacon;

        /// <summary>
        /// 01. [UPDATE] - Cập nhật PartPrice của 1 Part Code
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="role"></param>
        /// <param name="position"></param>
        /// <param name="dept"></param>
        /// <returns></returns>
        public bool CapnhatPriceDAL(string PartCode, string PartPrice)
        {
            using (SqlConnection con = new SqlConnection(Dataconnect))
            {
                string sql_query;
                sql_query = @"update tblPart
                set PartLog =CONCAT(FORMAT(GETDATE(), 'MM-dd-yyyy HH:mm'), ' Update Price from [ ', (select top 1 PartPrice  from tblPart  where PartCode = @PartCode), ' ] to [ ', @PartPrice , ' ]', CHAR(13), CHAR(10), '|', PartLog),
                PartPrice = @PartPrice
                where PartCode = @PartCode ;";
                SqlCommand cmd = new SqlCommand(sql_query, con);
                cmd.Parameters.Add("@PartCode", SqlDbType.NVarChar).Value = PartCode;
                cmd.Parameters.Add("@PartPrice", SqlDbType.Decimal).Value = Convert.ToInt32(PartPrice);

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
    }   // end  Class : PurchaseDAL

    /// <summary>
    /// DAL - Class for Make New PO
    /// </summary>
    public class MakeNewPO_DAL
    {
        private string Dataconnect = Properties.Settings.Default.Datacon;

        public tblUsers GetUserInfor(string staffname)
        {
            tblUsers _tbluser = null;

            DataTable BangDuLieu = new System.Data.DataTable();
            using (SqlConnection conn = new SqlConnection(Dataconnect))
            {
                string sql_query = @"
                        select top 1 tblDepartment.Deptname, tblUsers.Roles, tblUsers.Position from tblUsers
                        join tblDepartment on tblUsers.Department = tblDepartment.DeptID
                        where Username = @Username ";

                SqlCommand cmd = new SqlCommand(sql_query, conn);
                cmd.Parameters.AddWithValue("@Username", staffname);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read()) // Nếu đọc được giá trị thì :
                {
                    _tbluser = new tblUsers
                    {
                        UserID = Convert.ToInt32(reader[0]),
                        Username = reader[1].ToString(),
                        Passwords = reader[2].ToString(),
                        Roles = reader[3].ToString(),
                        Position = reader[4].ToString(),
                        Department = Convert.ToInt32(reader[5]),
                        DepartmentName = reader[6].ToString()
                    };
                }

                conn.Close();
            }

            return _tbluser;
        }
    }
}