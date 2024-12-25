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
    public class ManageFamilyCodeDAL
    {

        // Lưu DataConnnect
        private string Datacon = Properties.Settings.Default.Datacon;

        /// <summary> 01. SELECT - Lấy dữ liệu từ tblFamilyCode
        /// <returns></returns>
        public DataTable LayDataFamilyDAL()
        {
            DataTable BangDuLieu = new DataTable();
            using (SqlConnection conn = new SqlConnection(Datacon))
            {
                string sql_query = "select * from tblFamily";

                SqlCommand cmd = new SqlCommand(sql_query, conn);
                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                conn.Open();
                adap.Fill(BangDuLieu);
            }
            return BangDuLieu;
        }

        /// <summary> 02. INSERT - Thêm Family Code mới
        /// <returns></returns>
        public bool ThemFamilyCodeDAL(string familycode, string familytype, string familydescript)
        {
            using (SqlConnection con = new SqlConnection(Datacon))
            {
                string sql_query = "insert into tblFamily ( FamilyCode, FamilyType, FamilyDescript ) values (";
                sql_query = sql_query + "@FamilyCode, @FamilyType, @FamilyDescript )";
                SqlCommand cmd = new SqlCommand(sql_query, con);
                cmd.Parameters.Add("@FamilyCode", SqlDbType.NVarChar).Value = familycode;
                cmd.Parameters.Add("FamilyType", SqlDbType.NVarChar).Value = familytype;
                cmd.Parameters.Add("@FamilyDescript", SqlDbType.NVarChar).Value = familydescript;
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

        /// <summary> 03. CHECK - Kiểm tra xem Family Code đã tồn tại hay chưa 
        /// <param name="FamilyCode"></param>
        /// <returns></returns>
        public bool CheckFamilyCode(string FamilyCode)
        {
            using (SqlConnection conn = new SqlConnection(Datacon))
            {
                conn.Open();
                string sql_query = @"select COUNT(1) from tblFamily where FamilyCode = @FamilyCode  ";
                SqlCommand cmd = new SqlCommand(sql_query, conn);
                cmd.Parameters.AddWithValue("@FamilyCode", FamilyCode);

                int count;
                try
                {
                    count = (int)cmd.ExecuteScalar();
                }
                catch { return false; }
                return count == 1; // Trả về giá trị true nếu tìm thấy bản ghi
            }
        }


        /// <summary> 04. UPDATE - Cập nhật dữ liệu của 1 FamilyCode lên Database
        /// <param name="familycode"></param>
        /// <param name="familytype"></param>
        /// <param name="familydescript"></param>
        /// <returns></returns>
        public bool CapnhatFamilyDAL(string familycode, string familytype, string familydescript)
        {
            using (SqlConnection con = new SqlConnection(Datacon))
            {

                string sql_query = "update tblFamily set ";
                sql_query = sql_query + "FamilyType = @FamilyType, FamilyDescript = @FamilyDescript ";
                sql_query = sql_query + "where FamilyCode = @FamilyCode ";
                SqlCommand cmd = new SqlCommand(sql_query, con);
                cmd.Parameters.Add("@FamilyCode", SqlDbType.NVarChar).Value = familycode;
                cmd.Parameters.Add("FamilyType", SqlDbType.NVarChar).Value = familytype;
                cmd.Parameters.Add("@FamilyDescript", SqlDbType.NVarChar).Value = familydescript;
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



        /// <summary> 05. DELETE - Xóa 1 dòng Family Code
        /// <param name="familycode"></param>
        /// <returns></returns>
        public bool XoaFamilyCodeDAL(string familycode)
        {
            using (SqlConnection con = new SqlConnection(Datacon))
            {

                string sql_query;
                sql_query = "DELETE FROM tblRelation ";
                sql_query = sql_query + "WHERE EXISTS (SELECT 1 FROM tblPart WHERE (tblPart.PartID = tblRelation.ParentID OR tblPart.PartID = tblRelation.ChildID) ";
                sql_query = sql_query + "AND tblPart.PartFamily = @FamilyCode ); ";
                sql_query = sql_query + "\n delete tblFamily where FamilyCode = @FamilyCode";
                SqlCommand cmd = new SqlCommand(sql_query, con);
                cmd.Parameters.AddWithValue("@FamilyCode", familycode);
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
