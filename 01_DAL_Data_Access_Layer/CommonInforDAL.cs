using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using DataTable = System.Data.DataTable;

namespace PLM_Lynx._01_DAL_Data_Access_Layer
{
    public class CommonInforDAL
    {
        private string Dataconnect = Properties.Settings.Default.Datacon;

        public tblCommonInfor GetCommonInforValue_DAL(string inforname)
        {
            tblCommonInfor _tblcommoninfor = null;

            using (SqlConnection conn = new SqlConnection(Dataconnect))
            {
                string sql_query = @"
                       select  tblCommonInfor.InforValue from tblCommonInfor where tblCommonInfor.InforName = @InforName  ";

                SqlCommand cmd = new SqlCommand(sql_query, conn);
                cmd.Parameters.AddWithValue("@InforName", inforname);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read()) // Nếu đọc được giá trị thì :
                {
                    _tblcommoninfor = new tblCommonInfor
                    {
                        InforValue = reader[0].ToString()
                    };
                }

                conn.Close();
            }

            return _tblcommoninfor;
        }
    
    
    }
}