using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using DataTable = System.Data.DataTable;

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

        /// <summary>
        /// 01. SELECT - Get information of specific user by username
        /// </summary>
        /// <param name="staffname"></param>
        /// <returns></returns>
        public tblUsers GetUserInfor_DAL(string staffname)
        {
            tblUsers _tbluser = null;

            using (SqlConnection conn = new SqlConnection(Dataconnect))
            {
                string sql_query = @"
                            select u.UserID, u.Username, u.Passwords, u.Roles, u.Position, u.Department, d.Deptname
                            from tblUsers as u
                            join tblDepartment as d on u.Department = d.DeptID
                            where u.Username = @Username   ;
                        ";

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

        /// <summary>
        /// 02. SELECT - Get information of the lastest PO
        /// </summary>
        /// <param name="staffname"></param>
        /// <returns></returns>
        public tblPO GetInforPO_DAL()
        {
            tblPO _tblpo = null;

            using (SqlConnection conn = new SqlConnection(Dataconnect))
            {
                string sql_query = @"
                       select top 1 tblPO.PODate, tblPO.POCode  from tblPO order by PODate desc , POCode desc ";

                SqlCommand cmd = new SqlCommand(sql_query, conn);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read()) // Nếu đọc được giá trị thì :
                {
                    _tblpo = new tblPO
                    {
                        PODate = Convert.ToDateTime(reader[0]),
                        POCode = reader[1].ToString()
                    };
                }

                conn.Close();
            }

            return _tblpo;
        }

        /// <summary>
        /// 03. SELECT - Get All Supplier Name
        /// </summary>
        /// <returns></returns>
        public DataTable GetListSupplier_DAL()
        {
            DataTable BangDuLieu = new DataTable();
            using (SqlConnection conn = new SqlConnection(Dataconnect))
            {
                string sql_query = @"  select tblSupplier.SupName from tblSupplier";

                SqlCommand cmd = new SqlCommand(sql_query, conn);

                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                conn.Open();
                adap.Fill(BangDuLieu);
            }
            return BangDuLieu;
        }

        /// <summary>
        /// 04. SELECT - Get information of Supplier by SupplierName
        /// </summary>
        /// <param name="SupplierName"></param>
        /// <returns></returns>
        public tblSupplier GetInforSupplier_DAL(string SupplierName)
        {
            tblSupplier _tblsupplier = null;

            using (SqlConnection conn = new SqlConnection(Dataconnect))
            {
                string sql_query = @"
                            select Top 1 s.SupName, s.SupPhoneNumber, s.SupTaxID, s.SupLocation,s.SupRepresentative, s.SupID
                            from tblSupplier as s where SupName = @SupName  ;
                        ";

                SqlCommand cmd = new SqlCommand(sql_query, conn);
                cmd.Parameters.AddWithValue("@SupName", SupplierName);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read()) // Nếu đọc được giá trị thì :
                {
                    _tblsupplier = new tblSupplier
                    {
                        SupName = reader[0].ToString(),
                        SupPhoneNumber = reader[1].ToString(),
                        SupTaxID = reader[2].ToString(),
                        SupLocation = reader[3].ToString(),
                        SupRepesentative = reader[4].ToString(),
                        SupID = Convert.ToInt32(reader[5].ToString())
                    };
                }

                conn.Close();
            }

            return _tblsupplier;
        }

        /// 01. SELECT - Get "PartCode" and "PartName" with keysearch
        /// <param name="KeySearch"></param>
        /// <returns> Bảng chứa danh sách các Part Chứa từ khóa đó
        public DataTable FindwithwordDAL(string KeySearch)
        {
            DataTable BangDuLieu = new DataTable();
            using (SqlConnection conn = new SqlConnection(Dataconnect))
            {
                string sql_query = @"
                        SELECT
                            p.PartCode,
                            p.PartName,
                            p.PartPrice,
                            p.PartID

                        FROM
                            tblPart AS p
                        WHERE
                            p.PartName LIKE '%' + @KeySearch + '%'
                            OR p.PartCode LIKE '%' + @KeySearch + '%'
                            OR p.PartDescript LIKE '%' + @KeySearch + '%'";

                SqlCommand cmd = new SqlCommand(sql_query, conn);
                cmd.Parameters.AddWithValue("@KeySearch", KeySearch);

                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                conn.Open();
                adap.Fill(BangDuLieu);
            }
            return BangDuLieu;
        }

        /// 03. INSERT - Insert 1 new PO to the tblPO
        /// <param name="PartFamily"></param>
        /// <param name="PartName"></param>
        /// <param name="PartDescript"></param>
        /// <returns></returns>
        public bool InsertNewPODAL(string POCode, string PODate, string PONhanVien, string POPartlist, decimal POAmount, string PONote, int POSupplierID)
        {
            using (SqlConnection con = new SqlConnection(Dataconnect))
            {
                // Mở kết nối
                con.Open();
                string POStatus = "Created";
                string POLog = POStatus + " " + PODate;

                // Tạo một giao dịch (Transaction) C#
                using (SqlTransaction transaction = con.BeginTransaction())
                {
                    string sql_query = @"insert tblPO(POCode, PODate, PONhanVien, POPartlist, POAmount, PONote, POStatus, POLog, POSupplierID )
                             VALUES (@POCode, @PODate, @PONhanvien, @POPartlist, @POAmount, @PONote , @POStatus, @POLog, @POSupplierID );";

                    SqlCommand cmd = new SqlCommand(sql_query, con, transaction);

                    // Sử dụng Add với kiểu dữ liệu cụ thể thay vì AddWithValue
                    cmd.Parameters.Add("@POCode", SqlDbType.NVarChar).Value = POCode;
                    cmd.Parameters.Add("@PODate", SqlDbType.NVarChar).Value = PODate;
                    cmd.Parameters.Add("@PONhanvien", SqlDbType.NVarChar).Value = PONhanVien;
                    cmd.Parameters.Add("@POPartlist", SqlDbType.NVarChar).Value = POPartlist;
                    cmd.Parameters.Add("@POAmount", SqlDbType.Decimal).Value = POAmount;
                    cmd.Parameters.Add("@PONote", SqlDbType.NVarChar).Value = PONote;
                    cmd.Parameters.Add("@POStatus", SqlDbType.NVarChar).Value = POStatus;
                    cmd.Parameters.Add("@POLog", SqlDbType.NVarChar).Value = POLog;
                    cmd.Parameters.Add("@POSupplierID", SqlDbType.Int).Value = POSupplierID;

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
    }
}