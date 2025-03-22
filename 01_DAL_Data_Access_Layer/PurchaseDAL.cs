using Microsoft.Data.SqlClient;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
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

        /// <summary>
        /// 02. SELECT - Get All information of Supplier
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllInforSupplierDAL()
        {
            DataTable BangDuLieu = new DataTable();
            using (SqlConnection conn = new SqlConnection(Dataconnect))
            {
                string sql_query = @" select * from tblSupplier";

                SqlCommand cmd = new SqlCommand(sql_query, conn);

                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                conn.Open();
                adap.Fill(BangDuLieu);
            }
            return BangDuLieu;
        }

        /// <summary>
        /// 03. INSERT - Insert 1 new Supplier to the tblSupplier
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="Phone"></param>
        /// <param name="Tax"></param>
        /// <param name="Location"></param>
        /// <param name="Rep"></param>
        /// <param name="Note"></param>
        /// <returns></returns>
        public bool InsertNewSupplierDAL(string Name, string Phone, string Tax, string Location, string Rep, string Note)
        {
            using (SqlConnection con = new SqlConnection(Dataconnect))
            {
                // Mở kết nối
                con.Open();

                // Tạo một giao dịch (Transaction) C#
                using (SqlTransaction transaction = con.BeginTransaction())
                {
                    string sql_query = @"insert tblSupplier(SupName, SupPhoneNumber, SupTaxID, SupLocation, SupRepresentative, SupNote)
                             VALUES (@Name, @Phone, @Tax, @Location, @Rep, @Note );";

                    SqlCommand cmd = new SqlCommand(sql_query, con, transaction);

                    // Sử dụng Add với kiểu dữ liệu cụ thể thay vì AddWithValue
                    cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = Name;
                    cmd.Parameters.Add("@Phone", SqlDbType.NVarChar).Value = Phone;
                    cmd.Parameters.Add("@Tax", SqlDbType.NVarChar).Value = Tax;
                    cmd.Parameters.Add("@Location", SqlDbType.NVarChar).Value = Location;
                    cmd.Parameters.Add("@Rep", SqlDbType.NVarChar).Value = Rep;
                    cmd.Parameters.Add("@Note", SqlDbType.NVarChar).Value = Note;

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

        /// <summary>
        /// 04. UPDATE - Update 1 Supplier by SupplierID
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="Phone"></param>
        /// <param name="TaxID"></param>
        /// <param name="Location"></param>
        /// <param name="Representative"></param>
        /// <param name="Note"></param>
        /// <param name="ID"></param>
        /// <returns></returns>
        public bool UpdateOneSupplierDAL(string Name, string Phone, string TaxID, string Location, string Representative, string Note, int ID)
        {
            using (SqlConnection con = new SqlConnection(Dataconnect))
            {
                con.Open();
                SqlTransaction transaction = con.BeginTransaction();

                try
                {
                    string sql_query = "UPDATE tblSupplier SET ";
                    sql_query += "SupName = @Name , SupPhoneNumber = @Phone, SupTaxID = @TaxID, SupLocation = @Location , SupRepresentative = @Representative, SupNote = @Note where SupID = @ID ";
                    MessageBox.Show(sql_query);

                    using (SqlCommand cmd = new SqlCommand(sql_query, con, transaction))
                    {
                        cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = Name;
                        cmd.Parameters.Add("@Phone", SqlDbType.NVarChar).Value = Phone;
                        cmd.Parameters.Add("@TaxID", SqlDbType.NVarChar).Value = TaxID;
                        cmd.Parameters.Add("@Location", SqlDbType.NVarChar).Value = Location;
                        cmd.Parameters.Add("@Representative", SqlDbType.NVarChar).Value = Representative;
                        cmd.Parameters.Add("@Note", SqlDbType.NVarChar).Value = Note;
                        //cmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
                        cmd.Parameters.AddWithValue("@ID", ID);

                        cmd.ExecuteNonQuery(); // Thực thi lệnh UPDATE
                    }

                    transaction.Commit(); // Xác nhận giao dịch nếu không có lỗi
                    return true;
                }
                catch (Exception ex)
                {
                    transaction.Rollback(); // Hoàn tác nếu có lỗi
                    Console.WriteLine("Lỗi: " + ex.Message);
                    return false;
                }
            }
        }

        /// <summary>
        /// 05. DELETE - Delete 1 Supplier by SupplierName
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        public bool DeleteOneSupplierDAL(string Name)
        {
            using (SqlConnection con = new SqlConnection(Dataconnect))
            {
                string sql_query = "delete tblSupplier where SupName = @Name";
                SqlCommand cmd = new SqlCommand(sql_query, con);
                cmd.Parameters.AddWithValue("@Name", Name);
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

        public DataTable AllInforPObyKeySearchDAL(string keysearch, bool byPart)
        {
            DataTable BangDuLieu = new DataTable();
            using (SqlConnection conn = new SqlConnection(Dataconnect))
            {
                string sql_query;
                if (byPart == true)
                {
                    sql_query = @"WITH ID AS (
                                        SELECT TOP 1 tblPart.PartID
                                        FROM tblPart
                                        WHERE PartCode = @keysearch
                                    )
                                    SELECT p.POCode, p.PONhanVien, p.POSupplierID , p.POAmount ,p.POStatus, MONTH(p.PODate) AS pMonth, DAY(p.PODate) AS pDate
                                    FROM tblPO AS p
                                    WHERE p.POPartCode LIKE '%' + CAST((SELECT PartID FROM ID) AS NVARCHAR) + '%';";

                    SqlCommand cmd = new SqlCommand(sql_query, conn);
                    cmd.Parameters.Add("@keysearch", SqlDbType.NVarChar).Value = keysearch;
                    SqlDataAdapter adap = new SqlDataAdapter(cmd);
                    conn.Open();
                    adap.Fill(BangDuLieu);
                    return BangDuLieu;
                }
                else
                {
                    sql_query = @"select p.POCode,p.PONhanVien, p.POSupplierID, p.POAmount, p.POStatus, MONTH(p.PODate) AS pMonth, DAY(p.PODate) AS pDate from tblPO as p where p.POCode LIKE '%' + @keysearch + '%';";
                    SqlCommand cmd = new SqlCommand(sql_query, conn);
                    cmd.Parameters.Add("@keysearch", SqlDbType.NVarChar).Value = keysearch;
                    SqlDataAdapter adap = new SqlDataAdapter(cmd);
                    conn.Open();
                    adap.Fill(BangDuLieu);
                    return BangDuLieu;
                }
            }
        }

        public DataTable GetInfor1PObyPOCodeDAL(string POCode)
        {
            DataTable BangDuLieu = new DataTable();
            using (SqlConnection conn = new SqlConnection(Dataconnect))
            {
                string sql_query;

                sql_query = @"select Top 1 * from tblPO where POCode = @Pocode";
                SqlCommand cmd = new SqlCommand(sql_query, conn);
                cmd.Parameters.Add("@Pocode", SqlDbType.NVarChar).Value = POCode;
                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                conn.Open();
                adap.Fill(BangDuLieu);
                return BangDuLieu;
            }
        }

        /// <summary>
        /// 06. SELECT - Get information of specific Supplier by SupplierID
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public DataTable GetInfor1Supplier_ByID_DAL(int ID)
        {
            DataTable BangDuLieu = new DataTable();
            using (SqlConnection conn = new SqlConnection(Dataconnect))
            {
                string sql_query;

                sql_query = @"select Top 1 * from tblSupplier where SupID = @ID";
                SqlCommand cmd = new SqlCommand(sql_query, conn);
                cmd.Parameters.Add("@ID", SqlDbType.NVarChar).Value = ID;
                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                conn.Open();
                adap.Fill(BangDuLieu);
                return BangDuLieu;
            }
        }


        /// <summary>
        /// 07. SELECT - Get PartCode by PartID
        /// </summary>
        /// <param name="IDPart"></param>
        /// <returns></returns>
        public string GetPartCode_DAL(int IDPart)
        {
            string PartCode = "";
            using (SqlConnection conn = new SqlConnection(Dataconnect))
            {
                string sql_query = @"select PartCode from tblPart where PartID = @ID";
                SqlCommand cmd = new SqlCommand(sql_query, conn);
                cmd.Parameters.AddWithValue("@ID", IDPart);
                conn.Open();
                PartCode = (string)cmd.ExecuteScalar();
            }
            return PartCode;
        }
        /// <summary>
        /// 08. SELECT - Get PartCode by PartID
        /// </summary>
        /// <param name="IDPart"></param>
        /// <returns></returns>
        public string GetPartName_DAL(int IDPart)
        {
            string PartCode = "";
            using (SqlConnection conn = new SqlConnection(Dataconnect))
            {
                string sql_query = @"select PartName from tblPart where PartID = @ID";
                SqlCommand cmd = new SqlCommand(sql_query, conn);
                cmd.Parameters.AddWithValue("@ID", IDPart);
                conn.Open();
                PartCode = (string)cmd.ExecuteScalar();
            }
            return PartCode;
        }


        public bool UpdateStatusPO_DAL(string POCode, string Status)
        {
            using (SqlConnection con = new SqlConnection(Dataconnect))
            {
                con.Open();
                SqlTransaction transaction = con.BeginTransaction();

                try
                {
                    string sql_query;
                    sql_query = @"  UPDATE tblPO 
                                    SET 
                                        POStatus = @Status ,
                                        POLog = CONCAT(POLog, CHAR(13), CHAR(10), @Status , CONVERT(VARCHAR, GETDATE(), 120))
                                    WHERE POCode = @POCode ";

                    
                    using (SqlCommand cmd = new SqlCommand(sql_query, con, transaction))
                    {
                        cmd.Parameters.Add("@POCode", SqlDbType.NVarChar).Value = POCode;
                        cmd.Parameters.Add("@Status", SqlDbType.NVarChar).Value = Status;


                        cmd.ExecuteNonQuery(); // Thực thi lệnh UPDATE
                    }

                    transaction.Commit(); // Xác nhận giao dịch nếu không có lỗi
                    return true;
                }
                catch (Exception ex)
                {
                    transaction.Rollback(); // Hoàn tác nếu có lỗi
                    Console.WriteLine("Lỗi: " + ex.Message);
                    return false;
                }
            }
        }

    }

    // end  Class : PurchaseDAL
    //=======================================================================================================
    //=======================================================================================================

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

        /// 05. SELECT - Get "PartCode" and "PartName" with keysearch
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

        /// 06. INSERT - Insert 1 new PO to the tblPO
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