using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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



    }
}
