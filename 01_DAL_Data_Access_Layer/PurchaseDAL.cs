using Azure.Core;
using Microsoft.Data.SqlClient;
using Microsoft.Office.Interop.Excel;
using SolidWorks.Interop.sldworks;
using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.InteropServices;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
        public bool CapnhatPriceDAL(string PartCode, string PartPrice, string ExportPrice, string UserName)
        {
            using (SqlConnection con = new SqlConnection(Dataconnect))
            {
                string PartPriceLog;
                string Date = DateTime.Now.Date.ToString("yyyy-MM-dd");
                PartPriceLog = Date + " : Import -" + PartPrice + " - " + "Export-" + ExportPrice + "- User: " + UserName + "|";

                string sql_query;
                sql_query = @"update tblPart
                set PartPriceSale = @ExportPrice ,
                PartPrice = @PartPrice,
                PartPriceLog = CONCAT(PartPriceLog, CHAR(13), CHAR(10), @PartPriceLog )
                where PartCode = @PartCode ;";
                SqlCommand cmd = new SqlCommand(sql_query, con);
                cmd.Parameters.Add("@PartCode", SqlDbType.NVarChar).Value = PartCode;
                cmd.Parameters.Add("@PartPrice", SqlDbType.Decimal).Value = Convert.ToInt32(PartPrice);
                cmd.Parameters.Add("@ExportPrice", SqlDbType.Decimal).Value = Convert.ToInt32(ExportPrice);
                cmd.Parameters.Add("@PartPriceLog", SqlDbType.NVarChar).Value = PartPriceLog;

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

        public bool CapnhatPriceDAL(DataTable ListItem_Update_Price)
        {
            using (SqlConnection con = new SqlConnection(Dataconnect))
            {
                con.Open();
                using (SqlTransaction tran = con.BeginTransaction())
                {
                    try
                    {
                        using (SqlCommand cmd = new SqlCommand("dbo.[UpdatePrice_in_tblPart]", con, tran))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;

                            SqlParameter tvpParam = cmd.Parameters.AddWithValue("@ListItemUpdate", ListItem_Update_Price);
                            tvpParam.SqlDbType = SqlDbType.Structured;
                            tvpParam.TypeName = "dbo.[tblListItemPrice]";

                            cmd.ExecuteNonQuery();
                        }

                        tran.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi: " + ex.Message);
                        tran.Rollback();
                        // Ghi log nếu cần
                        return false;
                    }
                }
            }
        }

        /// <summary>
        /// 02. SELECT - Get All information of Supplier
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllInforSupplier_DAL()
        {
            DataTable BangDuLieu = new DataTable();
            using (SqlConnection conn = new SqlConnection(Dataconnect))
            {
                string sql_query = @" select s.SupplierID,
	                                s.SupplierName,
	                                s.SupplierPhone,
	                                s.SupplierLocation,
	                                s.SupplierTaxNumber ,
	                                s.SupplierRepresentative,
	                                s.SupplierNote
                                from tblSupplier as s";

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
                    //MessageBox.Show(sql_query);

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
                                    WHERE p.POPartCode LIKE '%' + CAST((SELECT PartID FROM ID) AS NVARCHAR) + '%'
                                    order by p.PODate desc";

                    SqlCommand cmd = new SqlCommand(sql_query, conn);
                    cmd.Parameters.Add("@keysearch", SqlDbType.NVarChar).Value = keysearch;
                    SqlDataAdapter adap = new SqlDataAdapter(cmd);
                    conn.Open();
                    adap.Fill(BangDuLieu);
                    return BangDuLieu;
                }
                else
                {
                    sql_query = @"select p.POCode,p.PONhanVien, p.POSupplierID, p.POAmount, p.POStatus, MONTH(p.PODate) AS pMonth, DAY(p.PODate) AS pDate from tblPO as p where p.POCode LIKE '%' + @keysearch + '%' order by p.PODate desc ;";
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

                sql_query = @"select Top 1 p.POCode,
                                p.PODate,
                                p.PONhanVien,
                                p.POAmount,
                                p.PONote,
                                p.POStatus,
                                p.POLog,
                                p.POSupplierID,
                                p.POPartCode
                                from tblPO as p where POCode = @Pocode";
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

                sql_query = @"select Top 1 * from tblSupplier where SupplierID = @ID";
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

        public DataTable GetChildPartDAL(int IDPart)
        {
            DataTable BangDuLieu = new DataTable();
            using (SqlConnection conn = new SqlConnection(Dataconnect))
            {
                string sql_query = @" exec GetPartChild_Purchase @PartID = @ID ";

                SqlCommand cmd = new SqlCommand(sql_query, conn);
                cmd.Parameters.AddWithValue("@ID", IDPart);

                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                conn.Open();
                adap.Fill(BangDuLieu);
            }
            return BangDuLieu;
        }

        /// <summary>
        /// 09. SELECT - Lấy bảng danh sách các loại tiền tệ
        /// </summary>
        /// <returns></returns>
        public DataTable Get_tblMoneyType_DAL()
        {
            DataTable BangDuLieu = new DataTable();
            using (SqlConnection conn = new SqlConnection(Dataconnect))
            {
                string sql_query;
                sql_query = @"select c.CurrentID as CurrencyID, c.CurrentName as CurrencyName from tblCurrent as c";
                SqlCommand cmd = new SqlCommand(sql_query, conn);

                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                conn.Open();
                adap.Fill(BangDuLieu);
                return BangDuLieu;
            }
        }

        /// <summary>
        /// 10. SELECT - Lấy bảng thông tin của những PartCode cần cập nhật
        /// </summary>
        /// <param name="ListPartCode"></param>
        /// <returns></returns>
        ///
        // Result : PartCode || PartName || PartPrice  || PartPriceSale ||PartCurrentID
        public DataTable QueryInforItemPO_DAL(DataTable ListPartCode)
        {
            DataTable result = new DataTable();
            using (SqlConnection conn = new SqlConnection(Dataconnect))
            {
                SqlCommand cmd = new SqlCommand("QueryInforItemPO", conn); // Tên của stored procedure
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter tvpParam = cmd.Parameters.AddWithValue("@InforItemPO", ListPartCode);  // Tên bảng truyền vào
                tvpParam.SqlDbType = SqlDbType.Structured;
                tvpParam.TypeName = "dbo.tblListPartCode"; // Tên kiểu bảng bạn đã tạo trong SQL      // Tên bảng người dùng định nghĩa

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(result);
            }

            return result;
        }

        /// <summary>
        /// SELECT - Lấy bảng danh sách các loại đơn vị tính
        /// </summary>
        /// <returns></returns>
        public DataTable Get_tblUnitType_DAL()
        {
            DataTable BangDuLieu = new DataTable();
            using (SqlConnection conn = new SqlConnection(Dataconnect))
            {
                string sql_query;
                sql_query = @"select u.UnitID, u.UnitName from tblPOUnit as u";
                SqlCommand cmd = new SqlCommand(sql_query, conn);

                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                conn.Open();
                adap.Fill(BangDuLieu);
                return BangDuLieu;
            }
        }

        /// <summary>
        /// SELECT - Lấy bảng danh sách thông tin PO
        /// Có 3 loại
        /// Theo ngày từ đến ngày
        /// Chỉ duy nhất 1 ngày
        /// Theo PartCode
        /// </summary>
        /// <param name="startdate"></param>
        /// <param name="endate"></param>
        /// <returns></returns>
        public DataTable Get_POInformation_DAL(DateTime startdate, DateTime endate)
        {
            DataTable BangDuLieu = new DataTable();
            using (SqlConnection conn = new SqlConnection(Dataconnect))
            {
                string sql_query;
                sql_query = @"SELECT
                                p.PODateCreate,
                                p.PONumber,
                                t.POStatusName,
                                c.CurrentName,
                                s.SupplierName  ,
	                            p.POUser,
	                            p.TotalAmount
                            FROM
                                tblPO AS p
                            JOIN
                                tblPOStatus AS t  ON p.POStatusID = t.POStatusID
                            JOIN
                                tblCurrent AS c   ON p.POCurrentID = c.CurrentID
                            JOIN
                                tblSupplier AS s  ON p.POSupplierID = s.SupplierID
                            WHERE
                                p.PODateCreate >= @startdate
                                AND p.PODateCreate < @endate ";

                SqlCommand cmd = new SqlCommand(sql_query, conn);
                cmd.Parameters.AddWithValue("@startdate", startdate);
                cmd.Parameters.AddWithValue("@endate", endate);
                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                conn.Open();
                adap.Fill(BangDuLieu);
                return BangDuLieu;
            }
        }

        public DataTable Get_POInformation_DAL(DateTime startdate)
        {
            DataTable BangDuLieu = new DataTable();
            using (SqlConnection conn = new SqlConnection(Dataconnect))
            {
                string sql_query;
                sql_query = @"SELECT
                                p.PODateCreate,
                                p.PONumber,
                                t.POStatusName,
                                c.CurrentName,
                                s.SupplierName  ,
	                            p.POUser,
	                            p.TotalAmount
                            FROM
                                tblPO AS p
                            JOIN
                                tblPOStatus AS t  ON p.POStatusID = t.POStatusID
                            JOIN
                                tblCurrent AS c   ON p.POCurrentID = c.CurrentID
                            JOIN
                                tblSupplier AS s  ON p.POSupplierID = s.SupplierID
                            WHERE
                                p.PODateCreate = @startdate ; ";

                SqlCommand cmd = new SqlCommand(sql_query, conn);
                cmd.Parameters.AddWithValue("@startdate", startdate);

                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                conn.Open();
                adap.Fill(BangDuLieu);
                return BangDuLieu;
            }
        }

        public DataTable Get_POInformation_DAL(string PartCode)
        {
            DataTable BangDuLieu = new DataTable();
            using (SqlConnection conn = new SqlConnection(Dataconnect))
            {
                string sql_query;
                sql_query = @"WITH ListPONumber AS (
                                    SELECT i.PONumber
                                    FROM tblPOItems as i
	                                join tblPart as p on p.PartID = i.PartID
                                    WHERE i.PartID = (select PartID from tblPart where tblPart.PartCode =  @partcode )
                                )
                                SELECT
		                                p.PODateCreate,
		                                p.PONumber,
		                                t.POStatusName,
		                                c.CurrentName,
		                                s.SupplierName  ,
		                                p.POUser,
		                                p.TotalAmount
	                                FROM
		                                tblPO AS p
	                                JOIN
		                                tblPOStatus AS t  ON p.POStatusID = t.POStatusID
	                                JOIN
		                                tblCurrent AS c   ON p.POCurrentID = c.CurrentID
	                                JOIN
		                                tblSupplier AS s  ON p.POSupplierID = s.SupplierID
	                                JOIN ListPONumber as l on l.PONumber = p.PONumber ";

                SqlCommand cmd = new SqlCommand(sql_query, conn);
                cmd.Parameters.AddWithValue("@partcode", PartCode);

                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                conn.Open();
                adap.Fill(BangDuLieu);
                return BangDuLieu;
            }
        }

        public DataTable Get_tblPOItems_DAL(int PONumber)
        {
            DataTable BangDuLieu = new DataTable();
            using (SqlConnection conn = new SqlConnection(Dataconnect))
            {
                string sql_query;
                sql_query = @"select
	                            p.PartID as PartID,
                                t.PartCode as PartCode,
	                            t.PartName as PartName,
	                            p.Quantity as Quantity,
	                            u.UnitName as Unit,
	                            p.UnitPrice as Price,
	                            p.Discount as Discount,
	                            p.Amount as Amount,
	                            p.ItemsTax as Tax

                            from tblPOItems as p
                            join tblPart as t on t.PartID = p.PartID
                            join tblPOUnit as u on u.UnitID = p.UnitID
                            where p.PONumber = @PONumber ";

                SqlCommand cmd = new SqlCommand(sql_query, conn);
                cmd.Parameters.AddWithValue("@PONumber", PONumber);

                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                conn.Open();
                adap.Fill(BangDuLieu);
                return BangDuLieu;
            }
        }

        public DataTable Get_tblPOInformation_DAL(int PONumber)
        {
            DataTable BangDuLieu = new DataTable();
            using (SqlConnection conn = new SqlConnection(Dataconnect))
            {
                string sql_query;
                sql_query = @"select 
	                            p.POSupplierID , 
	                            p.PODateCreate,
	                            p.POCurrentID,
	                            p.POStatusID, 
	                            p.POUser , 
	                            p.POPaymentTerm, 
	                            p.PORemark, 
	                            p.TotalAmount,
	                            c.CurrentName,
	                            s.POStatusName

                            from tblPO as p
                            join tblCurrent as c on c.CurrentID = p.POCurrentID
                            join tblPOStatus as s on s.POStatusID = p.POStatusID
                            where p.PONumber = @PONumber ";

                SqlCommand cmd = new SqlCommand(sql_query, conn);
                cmd.Parameters.AddWithValue("@PONumber", PONumber);

                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                conn.Open();
                adap.Fill(BangDuLieu);
                return BangDuLieu;
            }
        }

        public DataTable Get_tblPOStatus_DAL()
        {
            DataTable BangDuLieu = new DataTable();
            using (SqlConnection conn = new SqlConnection(Dataconnect))
            {
                string sql_query;
                sql_query = @"select s.POStatusID, s.POStatusName from tblPOStatus as s ";

                SqlCommand cmd = new SqlCommand(sql_query, conn);
              

                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                conn.Open();
                adap.Fill(BangDuLieu);
                return BangDuLieu;
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
        public int Get_PONumber_DAL()
        {
            DataTable BangDuLieu = new DataTable();
            using (SqlConnection conn = new SqlConnection(Dataconnect))
            {
                string sql_query = @"  SELECT TOP 1 PONumber
                        FROM tblPO
                        WHERE CAST(PODateCreate AS DATE) = CAST(GETDATE() AS DATE)
                        ORDER BY PODateCreate DESC, PONumber DESC;";

                SqlCommand cmd = new SqlCommand(sql_query, conn);

                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                conn.Open();
                adap.Fill(BangDuLieu);
            }
            // PONUMBER =  yymmdd + 001
            string date = DateTime.Now.ToString("yy-MM-dd");
            date = date.Replace("-", "");

            int PONumber;
            if (BangDuLieu.Rows.Count > 0)
            {
                // Nếu có dữ liệu thì lấy số PONumber từ bảng tblPO
                string PONumberString = BangDuLieu.Rows[0][0].ToString();
                PONumber = Convert.ToInt32(PONumberString);
                PONumber += 1; // Tăng thêm 1 đơn hàng mới
            }
            else
            {
                // Nếu không có dữ liệu thì khởi tạo PONumber là 1
                string PONumberString = date + "001";
                PONumber = Convert.ToInt32(PONumberString);
            }

            return PONumber;
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
                string sql_query = @" select tblSupplier.SupplierName from tblSupplier";

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
                            select Top 1
                                s.SupplierName,
                                s.SupplierPhone,
                                s.SupplierTaxNumber,
                                s.SupplierLocation,
                                s.SupplierRepresentative,
                                s.SupplierID
                            from tblSupplier as s
                            where SupplierName = @SupName  ;
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
                            p.PartCode as PartCode,
                            p.PartName as PartName,
                            p.PartPriceSale as PartPriceSale,
                            p.PartID as PartID,
	                        p.PartPrice as PartPrice,
	                        p.PartCurrentID as PartCurrentID

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
        public bool InsertNewPO_DAL(int PONumber, int POSupplierID, DateTime PODateCreate, int POCurrencyID, int POStatusID, string POUser, string POPaymentTerm, string PORemark, decimal TotalAmount)
        {
            using (SqlConnection con = new SqlConnection(Dataconnect))
            {
                // Mở kết nối
                con.Open();

                // Tạo một giao dịch (Transaction) C#
                using (SqlTransaction transaction = con.BeginTransaction())
                {
                    string sql_query = @"insert into tblPO
                        ( PONumber, POSupplierID, PODateCreate, POCurrentID, POStatusID, POUser, POPaymentTerm, PORemark, TotalAmount)
                        Values ( @PONumber , @POSupplierID, @PODateCreate, @POCurrentID , @POStatusID, @POUser, @POPaymentTerm, @PORemark, @TotalAmount )  ";

                    SqlCommand cmd = new SqlCommand(sql_query, con, transaction);

                    // Sử dụng Add với kiểu dữ liệu cụ thể thay vì AddWithValue
                    cmd.Parameters.Add("@PONumber", SqlDbType.Int).Value = PONumber;
                    cmd.Parameters.Add("@POSupplierID", SqlDbType.Int).Value = POSupplierID;
                    cmd.Parameters.Add("@PODateCreate", SqlDbType.Date).Value = PODateCreate;
                    cmd.Parameters.Add("@POCurrentID", SqlDbType.Int).Value = POCurrencyID;
                    cmd.Parameters.Add("@POStatusID", SqlDbType.Int).Value = POStatusID;
                    cmd.Parameters.Add("@POUser", SqlDbType.NVarChar).Value = POUser;
                    cmd.Parameters.Add("@POPaymentTerm", SqlDbType.NVarChar).Value = POPaymentTerm;
                    cmd.Parameters.Add("@PORemark", SqlDbType.NVarChar).Value = PORemark;
                    cmd.Parameters.Add("@TotalAmount", SqlDbType.Decimal).Value = TotalAmount;

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

        public bool InsertListItems_to_tblPOItems_DAL(DataTable data_ListItems)
        {
            using (SqlConnection con = new SqlConnection(Dataconnect))
            {
                con.Open();
                using (SqlTransaction tran = con.BeginTransaction())
                {
                    try
                    {
                        using (SqlCommand cmd = new SqlCommand("dbo.Insert_in_tblPOItems", con, tran))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;

                            SqlParameter tvpParam = cmd.Parameters.AddWithValue("@ListItemInsert", data_ListItems);
                            tvpParam.SqlDbType = SqlDbType.Structured;
                            tvpParam.TypeName = "dbo.tblInsertItems_tblPOItems";

                            cmd.ExecuteNonQuery();
                        }

                        tran.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi: " + ex.Message);
                        tran.Rollback();
                        // Ghi log nếu cần
                        return false;
                    }
                }
            }
        }
    }
}