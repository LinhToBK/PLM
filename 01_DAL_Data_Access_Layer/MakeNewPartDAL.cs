using System;
using System.Collections.Generic;

//using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Xml.Linq;

namespace PLM_Lynx._01_DAL_Data_Access_Layer
{
    public class MakeNewPartDAL
    {
        private string Dataconnect = Properties.Settings.Default.Datacon;

        /// 01. INSERT - chèn New Part vào  bảng tblPart
        /// <param name="PartFamily"></param>
        /// <param name="PartName"></param>
        /// <param name="PartDescript"></param>
        /// <returns></returns>
        public bool InsertNewPartDAL(string PartFamily, string PartName, string PartDescript, string PartMaterial)
        {
            using (SqlConnection con = new SqlConnection(Dataconnect))
            {
                // Mở kết nối
                con.Open();

                // Tạo một giao dịch (Transaction) C#
                using (SqlTransaction transaction = con.BeginTransaction())
                {
                    string sql_query = @"INSERT INTO tblPart (PartFamily, PartName, PartDescript, PartMaterial)
                             VALUES (@PartFamily, @PartName, @PartDescript, @PartMaterial);";

                    SqlCommand cmd = new SqlCommand(sql_query, con, transaction);

                    // Sử dụng Add với kiểu dữ liệu cụ thể thay vì AddWithValue
                    cmd.Parameters.Add("@PartFamily", SqlDbType.NVarChar).Value = PartFamily;
                    cmd.Parameters.Add("@PartName", SqlDbType.NVarChar).Value = PartName;
                    cmd.Parameters.Add("@PartDescript", SqlDbType.NVarChar).Value = PartDescript;
                    cmd.Parameters.Add("@PartMaterial", SqlDbType.NVarChar).Value = PartMaterial;

                    try
                    {
                        // Thực thi lệnh SQL
                        int result = cmd.ExecuteNonQuery();

                        // Nếu không có lỗi, xác nhận (Commit) giao dịch
                        transaction.Commit();
                        return true; // Trả về true nếu thêm thành công
                    }
                    catch (Exception ex)
                    {
                        // Khôi phục lại giao dịch khi có lỗi
                        transaction.Rollback();
                        Console.WriteLine("Error: " + ex.Message);
                        return false;
                    }
                }
            }
        }

        /// 02. SELECT - Lấy dữ liệu của bảng tblFamily
        /// <returns></returns>
        public DataTable LoadFamilyDAL()
        {
            DataTable BangDuLieu = new DataTable();
            using (SqlConnection conn = new SqlConnection(Dataconnect))
            {
                string sql_query = @"select * from tblFamily ";

                SqlCommand cmd = new SqlCommand(sql_query, conn);

                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                conn.Open();
                adap.Fill(BangDuLieu);
            }
            return BangDuLieu;
        }

        /// <summary> 03. SELECT - Lấy  PartCode mới nhất
        /// <returns></return > Trả về chuỗi PartCode lớn nhất
        public string NewestPartCodeDAL()
        {
            using (SqlConnection conn = new SqlConnection(Dataconnect))
            {
                conn.Open();
                string sql_query = @"select  PartCode from tblPart where PartID = (select max(PartID) from tblPart ) ;";
                SqlCommand cmd = new SqlCommand(sql_query, conn);

                object result = cmd.ExecuteScalar();

                // Kiểm tra kết quả
                if (result != null)
                {
                    return result.ToString();
                }
                else
                {
                    return null;
                }
            }
        }

        /// <summary> 04. UPDATE - Cập nhật PartLog cho PartCode bất kì
        /// <param name="PartCode"></param>
        /// <returns></returns>
        public bool CapNhatPartLogDAL(string PartCode, string PartLogAdd)
        {
            using (SqlConnection conn = new SqlConnection(Dataconnect))
            {
                try
                {
                    conn.Open();
                    string query = "update tblPart set PartLog = @PartLogAdd + PartLog  where PartCode = @PartCode";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        //cmd.Parameters.AddWithValue("@PartLogAdd", PartLogAdd);
                        //cmd.Parameters.AddWithValue("@PartCode", PartCode);
                        cmd.Parameters.Add("@PartLogAdd", SqlDbType.NVarChar).Value = PartLogAdd;
                        cmd.Parameters.Add("@PartCode", SqlDbType.NVarChar).Value = PartCode;

                        int rows = cmd.ExecuteNonQuery();
                        return rows > 0; // Trả về true nếu cập nhật thành công
                    }
                }
                catch (Exception ex)
                {
                    // Log lỗi nếu cần thiết
                    Console.WriteLine(ex.Message);
                    return false;
                }
            }
        }
    }
}