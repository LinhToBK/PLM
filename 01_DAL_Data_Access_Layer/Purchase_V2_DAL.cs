using Azure.Core;
using Microsoft.Data.SqlClient;
using Microsoft.Office.Interop.Excel;
using SolidWorks.Interop.sldworks;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.IdentityModel.Metadata;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Forms;
using DataTable = System.Data.DataTable;

namespace PLM_Lynx._01_DAL_Data_Access_Layer
{
    public class Purchase_V2_DAL
    {
        private string Dataconnect = Properties.Settings.Default.Datacon;

        /// <summary>
        /// 01. SELECT - Lấy dữ liệu từ bảng tblPur_Supplier
        /// </summary>
        /// <returns></returns>
        public DataTable Select_tblPur_Supplier_DAL()
        {
            DataTable BangDuLieu = new DataTable();
            using (SqlConnection conn = new SqlConnection(Dataconnect))
            {
                string sql_query = @" select
	                                    s.SupplierID,
	                                    s.SupplierCode,
	                                    s.SupplierName,
	                                    s.SupplierLocation,
	                                    s.SupplierPhone,
	                                    s.SupplierTaxNumber,
	                                    s.SupplierNote,
	                                    s.SupplierContactPerson
                                    from tblPur_Supplier as s";

                SqlCommand cmd = new SqlCommand(sql_query, conn);

                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                conn.Open();
                adap.Fill(BangDuLieu);
            }
            return BangDuLieu;
        }

        /// <summary>
        /// 02. INSERT - Thêm mới một nhà cung cấp vào bảng tblPur_Supplier
        /// </summary>
        /// <param name="Code"></param>
        /// <param name="Name"></param>
        /// <param name="Phone"></param>
        /// <param name="Tax"></param>
        /// <param name="Location"></param>
        /// <param name="Note"></param>
        /// <param name="contactperson"></param>
        /// <returns></returns>
        public bool Insert_NewSupplier_DAL(string Code, string Name, string Phone, string Tax, string Location, string Note, string contactperson)
        {
            using (SqlConnection con = new SqlConnection(Dataconnect))
            {
                // Mở kết nối
                con.Open();

                // Tạo một giao dịch (Transaction) C#
                using (SqlTransaction transaction = con.BeginTransaction())
                {
                    string sql_query = @"insert tblPur_Supplier
                                        (SupplierCode, SupplierName, SupplierLocation, SupplierPhone, SupplierTaxNumber, SupplierNote, SupplierContactPerson)
                                        VALUES (@Code, @Name, @Location, @Phone, @Tax, @Note , @contactperson );";

                    SqlCommand cmd = new SqlCommand(sql_query, con, transaction);

                    // Sử dụng Add với kiểu dữ liệu cụ thể thay vì AddWithValue
                    cmd.Parameters.Add("@Code", SqlDbType.NVarChar).Value = Code;
                    cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = Name;
                    cmd.Parameters.Add("@Phone", SqlDbType.NVarChar).Value = Phone;
                    cmd.Parameters.Add("@Tax", SqlDbType.NVarChar).Value = Tax;
                    cmd.Parameters.Add("@Location", SqlDbType.NVarChar).Value = Location;
                    cmd.Parameters.Add("@Note", SqlDbType.NVarChar).Value = Note;
                    cmd.Parameters.Add("@contactperson", SqlDbType.NVarChar).Value = contactperson;

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
        /// 03. UPDATE - Cập nhật thông tin nhà cung cấp đã tồn tại trong bảng tblPur_Supplier
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="Code"></param>
        /// <param name="Name"></param>
        /// <param name="Phone"></param>
        /// <param name="Tax"></param>
        /// <param name="Location"></param>
        /// <param name="Note"></param>
        /// <param name="ContactPerson"></param>
        /// <returns></returns>
        public bool Update_ExistingSupplier_DAL(int ID, string Code, string Name, string Phone, string Tax, string Location, string Note, string ContactPerson)
        {
            using (SqlConnection con = new SqlConnection(Dataconnect))
            {
                con.Open();
                SqlTransaction transaction = con.BeginTransaction();

                try
                {
                    string sql_query = @"UPDATE tblPur_Supplier SET
                                            SupplierCode = @Code ,
                                            SupplierName = @Name ,
                                            SupplierPhone = @Phone,
                                            SupplierTaxNumber = @TaxID,
                                            SupplierLocation = @Location ,
                                            SupplierContactPerson = @ContactPerson
                                            where SupplierID = @ID ";

                    using (SqlCommand cmd = new SqlCommand(sql_query, con, transaction))
                    {
                        //cmd.Parameters.AddWithValue("@ID", ID);
                        cmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
                        cmd.Parameters.Add("@Code", SqlDbType.NVarChar).Value = Code;
                        cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = Name;
                        cmd.Parameters.Add("@Phone", SqlDbType.NVarChar).Value = Phone;
                        cmd.Parameters.Add("@TaxID", SqlDbType.NVarChar).Value = Tax;
                        cmd.Parameters.Add("@Location", SqlDbType.NVarChar).Value = Location;
                        cmd.Parameters.Add("@Note", SqlDbType.NVarChar).Value = Note;
                        cmd.Parameters.Add("@ContactPerson", SqlDbType.NVarChar).Value = ContactPerson;

                        cmd.ExecuteNonQuery();
                    }

                    transaction.Commit();
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
        /// 04. SELECT - Lấy dữ liệu từ bảng tblPur_Status
        /// </summary>
        /// <returns></returns>
        public DataTable Select_tblPur_Status_DAL()
        {
            DataTable BangDuLieu = new DataTable();
            using (SqlConnection conn = new SqlConnection(Dataconnect))
            {
                string sql_query = @" select
                                        s.StatusID,
                                        s.StatusName
                                    from tblPur_Status as s";
                SqlCommand cmd = new SqlCommand(sql_query, conn);
                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                conn.Open();
                adap.Fill(BangDuLieu);
            }
            return BangDuLieu;
        }

        /// <summary>
        /// 05. INSERT - Thêm mới một trạng thái vào bảng tblPur_Status
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="Name"></param>
        /// <returns></returns>
        public bool Update_ExistingStatus_DAL(int ID, string Name)
        {
            using (SqlConnection con = new SqlConnection(Dataconnect))
            {
                con.Open();
                SqlTransaction transaction = con.BeginTransaction();
                try
                {
                    string sql_query = @"UPDATE tblPur_Status SET
                                            StatusName = @Name
                                            where StatusID = @ID ";
                    using (SqlCommand cmd = new SqlCommand(sql_query, con, transaction))
                    {
                        cmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
                        cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = Name;
                        cmd.ExecuteNonQuery();
                    }
                    transaction.Commit();
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
        /// 06. SELECT - Lấy dữ liệu từ bảng tblPur_Unit
        /// </summary>
        /// <returns></returns>
        public DataTable Select_tblPur_Unit_DAL()
        {
            DataTable BangDuLieu = new DataTable();
            using (SqlConnection conn = new SqlConnection(Dataconnect))
            {
                string sql_query = @" select
	                                        s.UnitID,
	                                        s.UnitName,
	                                        s.UnitValue,
	                                        s.UnitContent
                                        from tblPur_Unit as s";
                SqlCommand cmd = new SqlCommand(sql_query, conn);
                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                conn.Open();
                adap.Fill(BangDuLieu);
            }
            return BangDuLieu;
        }

        /// <summary>
        /// 07. INSERT - Thêm mới một đơn vị vào bảng tblPur_Unit
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="Value"></param>
        /// <param name="Content"></param>
        /// <returns></returns>
        public bool Insert_NewUnit_DAL(string Name, decimal Value, string Content)
        {
            using (SqlConnection con = new SqlConnection(Dataconnect))
            {
                // Mở kết nối
                con.Open();

                // Tạo một giao dịch (Transaction) C#
                using (SqlTransaction transaction = con.BeginTransaction())
                {
                    string sql_query = @"insert tblPur_Unit
                                        (UnitName, UnitValue, UnitContent )
                                        Values (@Name, @Value, @Content ) ";

                    SqlCommand cmd = new SqlCommand(sql_query, con, transaction);

                    // Sử dụng Add với kiểu dữ liệu cụ thể thay vì AddWithValue
                    cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = Name;
                    cmd.Parameters.Add("@Value", SqlDbType.Decimal).Value = Value;
                    cmd.Parameters.Add("@Content", SqlDbType.NVarChar).Value = Content;

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
        /// 08. UPDATE - Cập nhật thông tin đơn vị đã tồn tại trong bảng tblPur_Unit
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="Name"></param>
        /// <param name="Value"></param>
        /// <param name="Content"></param>
        /// <returns></returns>
        public bool Update_ExistingUnit_DAL(int ID, string Name, decimal Value, string Content)
        {
            using (SqlConnection con = new SqlConnection(Dataconnect))
            {
                con.Open();
                SqlTransaction transaction = con.BeginTransaction();

                try
                {
                    string sql_query = @"Update tblPur_Unit set
                                            UnitName = @Name,
                                            UnitValue = @Value,
                                            UnitContent = @Content
                                        where UnitID = @ID ";

                    using (SqlCommand cmd = new SqlCommand(sql_query, con, transaction))
                    {
                        cmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
                        cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = Name;
                        cmd.Parameters.Add("@Value", SqlDbType.Decimal).Value = Value;
                        cmd.Parameters.Add("@Content", SqlDbType.NVarChar).Value = Content;

                        cmd.ExecuteNonQuery();
                    }

                    transaction.Commit();
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
        /// 09. SELECT - Lấy dữ liệu từ bảng tblPur_Currency
        /// </summary>
        /// <returns></returns>
        public DataTable Select_tblPur_Currency_DAL()
        {
            DataTable BangDuLieu = new DataTable();
            using (SqlConnection conn = new SqlConnection(Dataconnect))
            {
                string sql_query = @" select
	                                    s.CurrencyID,
	                                    s.CurrencyName,
	                                    s.CurrencyRate
                                    from tblPur_Currency as s";
                SqlCommand cmd = new SqlCommand(sql_query, conn);
                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                conn.Open();
                adap.Fill(BangDuLieu);
            }
            return BangDuLieu;
        }

        /// <summary>
        /// 10. INSERT - Thêm mới một loại tiền tệ vào bảng tblPur_Currency
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="Rate"></param>
        /// <returns></returns>
        public bool Insert_NewCurrency_DAL(string Name, decimal Rate)
        {
            using (SqlConnection con = new SqlConnection(Dataconnect))
            {
                // Mở kết nối
                con.Open();

                // Tạo một giao dịch (Transaction) C#
                using (SqlTransaction transaction = con.BeginTransaction())
                {
                    string sql_query = @"insert tblPur_Currency
                                            (CurrencyName,CurrencyRate)
                                        Values (@Name, @Rate) ";

                    SqlCommand cmd = new SqlCommand(sql_query, con, transaction);

                    // Sử dụng Add với kiểu dữ liệu cụ thể thay vì AddWithValue
                    cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = Name;
                    cmd.Parameters.Add("@Rate", SqlDbType.Decimal).Value = Rate;
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
        /// 11. UPDATE - Cập nhật thông tin loại tiền tệ đã tồn tại trong bảng tblPur_Currency
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="Name"></param>
        /// <param name="Rate"></param>
        /// <returns></returns>
        public bool Update_ExistingCurrency_DAL(int ID, string Name, decimal Rate)
        {
            using (SqlConnection con = new SqlConnection(Dataconnect))
            {
                con.Open();
                SqlTransaction transaction = con.BeginTransaction();

                try
                {
                    string sql_query = @"update tblPur_Currency set
                                            CurrencyName = @Name,
                                            CurrencyRate = @Rate
                                            where  CurrencyID = @ID ";

                    using (SqlCommand cmd = new SqlCommand(sql_query, con, transaction))
                    {
                        cmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
                        cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = Name;
                        cmd.Parameters.Add("@Rate", SqlDbType.Decimal).Value = Rate;

                        cmd.ExecuteNonQuery();
                    }

                    transaction.Commit();
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
        /// 12. SELECT - Lấy dữ liệu từ bảng tblPur_WareHouse
        /// </summary>
        /// <returns></returns>
        public DataTable Select_tblPur_WareHouse_DAL()
        {
            DataTable BangDuLieu = new DataTable();
            using (SqlConnection conn = new SqlConnection(Dataconnect))
            {
                string sql_query = @" select
	                                    s.WareHouseID,
	                                    s.WareHouseName
                                    from tblPur_WareHouse as s";
                SqlCommand cmd = new SqlCommand(sql_query, conn);
                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                conn.Open();
                adap.Fill(BangDuLieu);
            }
            return BangDuLieu;
        }

        /// <summary>
        /// 13. INSERT - Thêm mới một kho hàng vào bảng tblPur_WareHouse
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        public bool Insert_NewWareHouse_DAL(string Name)
        {
            using (SqlConnection con = new SqlConnection(Dataconnect))
            {
                // Mở kết nối
                con.Open();

                // Tạo một giao dịch (Transaction) C#
                using (SqlTransaction transaction = con.BeginTransaction())
                {
                    string sql_query = @"insert tblPur_WareHouse
                                            (CurrencyName)
                                        Values (@Name) ";

                    SqlCommand cmd = new SqlCommand(sql_query, con, transaction);

                    // Sử dụng Add với kiểu dữ liệu cụ thể thay vì AddWithValue
                    cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = Name;

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
        /// 14 . UPDATE - Cập nhật thông tin kho hàng đã tồn tại trong bảng tblPur_WareHouse
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="Name"></param>
        /// <returns></returns>
        public bool Update_ExistingWareHouse_DAL(int ID, string Name)
        {
            using (SqlConnection con = new SqlConnection(Dataconnect))
            {
                con.Open();
                SqlTransaction transaction = con.BeginTransaction();

                try
                {
                    string sql_query = @"update tblPur_WareHouse set
                                            WareHouseName = @Name
                                            where WareHouseID = @ID ";

                    using (SqlCommand cmd = new SqlCommand(sql_query, con, transaction))
                    {
                        cmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
                        cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = Name;

                        cmd.ExecuteNonQuery();
                    }

                    transaction.Commit();
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
        /// 15. SELECT - Lấy dữ liệu từ bảng tblPur_Tax
        /// </summary>
        /// <returns></returns>
        public DataTable Select_tblPur_Tax_DAL()
        {
            DataTable BangDuLieu = new DataTable();
            using (SqlConnection conn = new SqlConnection(Dataconnect))
            {
                string sql_query = @" select
                                        s.TaxID,
                                        s.TaxName,
                                        s.TaxValue
                                    from tblPur_Tax as s";
                SqlCommand cmd = new SqlCommand(sql_query, conn);
                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                conn.Open();
                adap.Fill(BangDuLieu);
            }
            return BangDuLieu;
        }

        /// <summary>
        /// 16. SELT - Lấy dữ liệu khi tìm kiếm từ khóa KeySearch trong bảng tblPur_Part và tblPart
        /// </summary>
        /// <param name="KeySearch"></param>
        /// <returns></returns>
        public DataTable Select_Data_by_KeySearch_DAL(string KeySearch)
        {
            DataTable BangDuLieu = new DataTable();
            using (SqlConnection conn = new SqlConnection(Dataconnect))
            {
                string sql_query = @"
                            select
                                    p.PartCode,
                                    p.PartName,
                                    t.PartPurchasePrice,
                                    t.PartSalePrice,
                                    t.TaxCode,
	                                t.SupplierIDPrefer,
	                                t.TaxIDPrefer,
	                                t.Eable_Purchase,
	                                t.Eable_Inventory,
	                                t.Eable_Sale

                            from tblPur_Part as t
                            join tblPart as p on t.PartID = p.PartID
                            WHERE
                                p.PartName LIKE '%' + @KeySearch + '%'
                                OR p.PartCode LIKE '%' + @KeySearch + '%'
                                OR p.PartDescript LIKE '%' + @KeySearch + '%' ";

                SqlCommand cmd = new SqlCommand(sql_query, conn);
                cmd.Parameters.AddWithValue("@KeySearch", KeySearch);

                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                conn.Open();
                adap.Fill(BangDuLieu);
            }
            return BangDuLieu;
        }

        /// <summary>
        /// 17. SELECT - Lấy dữ liệu từ bảng tblPur_Part_ theo danh sách mã linh kiện (ListPartCode) truyền vào
        /// </summary>
        /// <param name="ListPartCode"></param>
        /// <returns></returns>
        public DataTable Select_tblPur_Part_DAL(DataTable ListPartCode)
        {
            DataTable result = new DataTable();
            using (SqlConnection conn = new SqlConnection(Dataconnect))
            {
                SqlCommand cmd = new SqlCommand("Select_Data_for_Purchase", conn); // Tên của stored procedure
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter tvpParam = cmd.Parameters.AddWithValue("@tbl_tblPart_Pur", ListPartCode);  // Tên bảng truyền vào
                tvpParam.SqlDbType = SqlDbType.Structured;
                tvpParam.TypeName = "dbo.tblListPartCode"; // Tên kiểu bảng bạn đã tạo trong SQL      // Tên bảng người dùng định nghĩa

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(result);
            }

            return result;
            // return datatable
            // PartCode, PartName, PartPurchasePrice, PartSalePrice, Eable_Purchase, Eable_Inventory, Eable_Sale, TaxCode, SupplierIDPrefer, TaxIDPrefer
        }

        /// <summary>
        /// 18. SELECT - Lấy dữ liệu từ bảng tblPur_Part theo danh sách mã linh kiện (ListPartCode) truyền vào
        /// </summary>
        /// <param name="ListPartCode"></param>
        /// <returns></returns>
        public DataTable Select_PartID_PartCode_DAL(DataTable ListPartCode)
        {
            DataTable result = new DataTable();
            using (SqlConnection conn = new SqlConnection(Dataconnect))
            {
                
                string sql_query = @"   SELECT 
                                            p.PartID,
                                            t.PartCode
                                        FROM tblPur_Part AS p
                                        JOIN tblPart AS t ON t.PartID = p.PartID
                                        JOIN @tblPartCode AS c ON c.PartCode = t.PartCode; ";
                SqlCommand cmd = new SqlCommand(sql_query, conn);
                SqlParameter tvpParam_Update = cmd.Parameters.AddWithValue("@tblPartCode", ListPartCode);
                tvpParam_Update.SqlDbType = SqlDbType.Structured;
                tvpParam_Update.TypeName = "tblListPartCode ";

                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                conn.Open();
                adap.Fill(result);


            }

            return result;
            // return datatable
            // PartCode, PartName, PartPurchasePrice, PartSalePrice, Eable_Purchase, Eable_Inventory, Eable_Sale, TaxCode, SupplierIDPrefer, TaxIDPrefer
        }
        /// <summary>
        /// 19. UPDATE - Cập nhật dữ liệu cho bảng tblPur_Part
        /// </summary>
        /// <param name="tblUpdated_Part"></param>
        /// <returns></returns>
        public bool Update_tblPur_Part_DAL(DataTable tblUpdated_Part)
        {
            using (SqlConnection con = new SqlConnection(Dataconnect))
            {
                con.Open();
                using (SqlTransaction tran = con.BeginTransaction())
                {
                    try
                    {
                        using (SqlCommand cmd = new SqlCommand("dbo.[Update_tblPur_Part]", con, tran))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;

                            SqlParameter tvpParam = cmd.Parameters.AddWithValue("@tblUpdated_Part", tblUpdated_Part);
                            tvpParam.SqlDbType = SqlDbType.Structured;
                            tvpParam.TypeName = "dbo.[tblPur_Part_User_Defined]";

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
        /// 20. SELECT - Lấy số PO mới nhất trong ngày
        /// </summary>
        /// <returns></returns>
        public int Select_Newest_PONumber_DAL()
        {
            int NewestPONumber = 0;
            DataTable BangDuLieu = new DataTable();
            using (SqlConnection conn = new SqlConnection(Dataconnect))
            {
                string sql_query = @"
                            SELECT  p.PONumber
                            FROM tblPur_PO AS p
                            WHERE CAST(p.PODateCreate AS DATE) = CAST(GETDATE() AS DATE)
                            ORDER BY p.PONumber desc; ";

                SqlCommand cmd = new SqlCommand(sql_query, conn);

                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                conn.Open();
                adap.Fill(BangDuLieu);
            }

            if(BangDuLieu == null || BangDuLieu.Rows.Count == 0)
            {
                string date = DateTime.Now.ToString("yyMMdd");
                NewestPONumber = Convert.ToInt32(date + "001"); 
            }   
            else
            {
                NewestPONumber = Convert.ToInt32(BangDuLieu.Rows[0]["PONumber"].ToString()) + 1;

            }    

            return NewestPONumber;
        }
        /// <summary>
        /// 21. INSERT - Thêm mới một đơn đặt hàng (Purchase Order) vào bảng tblPur_PO
        /// </summary>
        /// <param name="PODateCreate"></param>
        /// <param name="POEstimateDeliveryDate"></param>
        /// <param name="POSupplierID"></param>
        /// <param name="POSupplierContactPerson"></param>
        /// <param name="POCurrencyID"></param>
        /// <param name="POUser"></param>
        /// <param name="POStatusID"></param>
        /// <param name="PORemark"></param>
        /// <param name="POPaymentTerm"></param>
        /// <param name="WarehouseID"></param>
        /// <param name="POTotalPayment"></param>
        /// <param name="tblPur_PO_Detail"></param>
        /// <returns></returns>
        public bool Insert_New_PO_DAL(
            DateTime PODateCreate,
            DateTime POEstimateDeliveryDate,
            int POSupplierID,
            string POSupplierContactPerson,
            int POCurrencyID,
            string POUser,
            int POStatusID,
            string PORemark,
            string POPaymentTerm,
            int WarehouseID,
            decimal POTotalPayment,
            int POTaxID,
            DataTable tblPur_PO_Detail)
        {
            using (SqlConnection con = new SqlConnection(Dataconnect))
            {
                con.Open();

                using (SqlTransaction transaction = con.BeginTransaction())
                {
                    try
                    {
                        using (SqlCommand cmd = new SqlCommand("Insert_New_PO", con, transaction))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;

                            // Truyền các tham số đầu vào
                            cmd.Parameters.Add("@PONumber", SqlDbType.Int).Value = Select_Newest_PONumber_DAL();
                            cmd.Parameters.Add("@PODateCreate", SqlDbType.Date).Value = PODateCreate;
                            cmd.Parameters.Add("@POEstimateDeliveryDate", SqlDbType.Date).Value = POEstimateDeliveryDate;
                            cmd.Parameters.Add("@POSupplierID", SqlDbType.Int).Value = POSupplierID;
                            cmd.Parameters.Add("@POSupplierContactPerson", SqlDbType.NVarChar, 100).Value = POSupplierContactPerson;
                            cmd.Parameters.Add("@POCurrencyID", SqlDbType.Int).Value = POCurrencyID;
                            cmd.Parameters.Add("@POUser", SqlDbType.NVarChar, 50).Value = POUser;
                            cmd.Parameters.Add("@POStatusID", SqlDbType.Int).Value = POStatusID;
                            cmd.Parameters.Add("@PORemark", SqlDbType.NVarChar, 200).Value = PORemark;
                            cmd.Parameters.Add("@POPaymentTerm", SqlDbType.NVarChar, 100).Value = POPaymentTerm;
                            cmd.Parameters.Add("@WareHouseID", SqlDbType.Int).Value = WarehouseID;
                            cmd.Parameters.Add("@POToTalPayment", SqlDbType.Decimal).Value = POTotalPayment;
                            cmd.Parameters.Add("@POTaxID", SqlDbType.Int).Value = POTaxID; // Thêm tham số cho POTaxID

                            // Thêm bảng chi tiết kiểu TVP (Table-Valued Parameter)
                            SqlParameter tvpParam = cmd.Parameters.AddWithValue("@tbl_Details", tblPur_PO_Detail);
                            tvpParam.SqlDbType = SqlDbType.Structured;
                            tvpParam.TypeName = "tbl_Pur_PO_Detail_Defined"; // Phải khớp với type bạn tạo trong SQL

                            // Thực thi stored procedure
                            cmd.ExecuteNonQuery();
                        }

                        transaction.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        Console.WriteLine("Error: " + ex.Message);
                        return false;
                    }
                }
            }
        }

        /// <summary>
        /// 22. SELECT - Lấy dữ liệu từ bảng tblPur_PO, tblPur_PO_Detail với SupplierID
        /// </summary>
        /// <param name="SupplierID"></param>
        /// <returns></returns>
        public DataTable Select_tblPur_Part_with_SupplierID_DAL(int SupplierID)
        {
            DataTable BangDuLieu = new DataTable();
            using (SqlConnection conn = new SqlConnection(Dataconnect))
            {
                string sql_query = @" WITH PO_Detail AS (
                                            SELECT
                                                d.PONumber,
                                                d.PartID,
                                                d.UnitPrice,
                                                d.Quantity_Order,
                                                d.Discount,
                                                d.Amount
                                            FROM tblPur_PO_Detail AS d
                                        ),
                                        Part_Info AS (
                                            SELECT
                                                t.PartID,
                                                k.PartCode,
                                                k.PartName
                                            FROM tblPur_Part AS t
                                            INNER JOIN tblPart AS k ON k.PartID = t.PartID
                                        )
                                        SELECT
                                            p.PONumber,
                                         p.PODateCreate,
                                            pi.PartCode,
                                            pi.PartName,
                                            d.UnitPrice,
                                            d.Quantity_Order,
                                            d.Discount,
                                            d.Amount
                                        FROM tblPur_PO AS p
                                        INNER JOIN PO_Detail AS d ON d.PONumber = p.PONumber
                                        INNER JOIN Part_Info AS pi ON pi.PartID = d.PartID
                                        WHERE p.POSupplierID = @SupplierID order by PODateCreate desc; ";

                SqlCommand cmd = new SqlCommand(sql_query, conn);
                cmd.Parameters.Add("@SupplierID", SqlDbType.Int).Value = SupplierID;
                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                conn.Open();
                adap.Fill(BangDuLieu);
            }

            return BangDuLieu;
        }

        /// <summary>
        /// 23. SELECT - Lấy dữ liệu từ bảng tblPur_PO 
        /// Có 2 hàm  dùng cho việc lấy 100 dòng hay không lấy 100 dòng
        /// </summary>
        /// <param name="SupplierID"></param>
        /// <returns></returns>
        public DataTable Select_tblPur_PO_by_SupplierID_DAL(int SupplierID)
        {
            DataTable BangDuLieu = new DataTable();
            using (SqlConnection conn = new SqlConnection(Dataconnect))
            {
                string sql_query = @"select
                                        p.PONumber,
                                        p.PODateCreate,
                                        p.POEstimateDeliveryDate,
                                        s.SupplierName,
                                        p.POSupplierContactPerson,
                                        p.POUser,
                                        t.StatusName,
                                        w.WareHouseName,
                                        p.POToTalPayment, 
                                        c.CurrencyName,
	                                    x.TaxName
	
                                    from tblPur_PO  as p
                                    inner join tblPur_Supplier as s on s.SupplierID = p.POSupplierID
                                    inner join tblPur_Currency as c on c.CurrencyID = p.POCurrencyID 
                                    inner join tblPur_WareHouse as w on w.WareHouseID = p.WareHouseID
                                    inner join tblPur_Status as t on t.StatusID = p.POStatusID
                                    inner join tblPur_Tax as x on x.TaxID = p.POTaxID
                                    Where p.POSupplierID = @SupplierID ";
                SqlCommand cmd = new SqlCommand(sql_query, conn);
                cmd.Parameters.Add("@SupplierID", SqlDbType.Int).Value = SupplierID;
                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                conn.Open();
                adap.Fill(BangDuLieu);
            }

            return BangDuLieu;
        }

        public DataTable Select_tblPur_PO_by_SupplierID_DAL(int SupplierID , int ShowRow)
        {
            DataTable BangDuLieu = new DataTable();
            using (SqlConnection conn = new SqlConnection(Dataconnect))
            {
                string sql_query = @"select
                                        p.PONumber,
                                        p.PODateCreate,
                                        p.POEstimateDeliveryDate,
                                        s.SupplierName,
                                        p.POSupplierContactPerson,
                                        p.POUser,
                                        t.StatusName,
                                        w.WareHouseName,
                                        p.POToTalPayment, 
                                        c.CurrencyName,
	                                    x.TaxName
	
                                    from tblPur_PO  as p
                                    inner join tblPur_Supplier as s on s.SupplierID = p.POSupplierID
                                    inner join tblPur_Currency as c on c.CurrencyID = p.POCurrencyID 
                                    inner join tblPur_WareHouse as w on w.WareHouseID = p.WareHouseID
                                    inner join tblPur_Status as t on t.StatusID = p.POStatusID
                                    inner join tblPur_Tax as x on x.TaxID = p.POTaxID

                                    Where p.POSupplierID = @SupplierID 
                                    ORDER BY p.PODateCreate DESC
                                    OFFSET 0 ROWS FETCH NEXT @ShowRow ROWS ONLY; ";
                SqlCommand cmd = new SqlCommand(sql_query, conn);
                cmd.Parameters.Add("@SupplierID", SqlDbType.Int).Value = SupplierID;
                cmd.Parameters.Add("@ShowRow", SqlDbType.Int).Value = ShowRow;
                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                conn.Open();
                adap.Fill(BangDuLieu);
            }

            return BangDuLieu;
        }

        /// <summary>
        /// 24. SELECT - Lấy dữ liệu từ bảng tblPur_PO theo ngày tạo trong 1 khoảng thời gian
        /// </summary>
        /// <param name="DateFrom"></param>
        /// <param name="DateTo"></param>
        /// <returns></returns>
        public DataTable Select_tblPur_PO_by_CreateDate_DAL(DateTime DateFrom , DateTime DateTo)
        {
            DataTable BangDuLieu = new DataTable();
            using (SqlConnection conn = new SqlConnection(Dataconnect))
            {
                string sql_query = @"select
                                        p.PONumber,
                                        p.PODateCreate,
                                        p.POEstimateDeliveryDate,
                                        s.SupplierName,
                                        p.POSupplierContactPerson,
                                        p.POUser,
                                        t.StatusName,
                                        w.WareHouseName,
                                        p.POToTalPayment, 
                                        c.CurrencyName,
	                                    x.TaxName
	
                                    from tblPur_PO  as p
                                    inner join tblPur_Supplier as s on s.SupplierID = p.POSupplierID
                                    inner join tblPur_Currency as c on c.CurrencyID = p.POCurrencyID 
                                    inner join tblPur_WareHouse as w on w.WareHouseID = p.WareHouseID
                                    inner join tblPur_Status as t on t.StatusID = p.POStatusID
                                    inner join tblPur_Tax as x on x.TaxID = p.POTaxID

                                    WHERE p.PODateCreate >= @DateFrom AND p.PODateCreate <= @DateTo
                                    ORDER BY p.PONumber DESC ";
                                    
                SqlCommand cmd = new SqlCommand(sql_query, conn);
                cmd.Parameters.Add("@DateFrom", SqlDbType.DateTime).Value = DateFrom.Date;
                cmd.Parameters.Add("@DateTo", SqlDbType.DateTime).Value = DateTo.Date;
                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                conn.Open();
                adap.Fill(BangDuLieu);
            }

            return BangDuLieu;
        }

        public DataTable Select_tblPur_PO_by_CreateDate_DAL(DateTime DateFrom, DateTime DateTo , int ShowRow)
        {
            DataTable BangDuLieu = new DataTable();
            using (SqlConnection conn = new SqlConnection(Dataconnect))
            {
                string sql_query = @"select
                                        p.PONumber,
                                        p.PODateCreate,
                                        p.POEstimateDeliveryDate,
                                        s.SupplierName,
                                        p.POSupplierContactPerson,
                                        p.POUser,
                                        t.StatusName,
                                        w.WareHouseName,
                                        p.POToTalPayment, 
                                        c.CurrencyName,
	                                    x.TaxName
	
                                    from tblPur_PO  as p
                                    inner join tblPur_Supplier as s on s.SupplierID = p.POSupplierID
                                    inner join tblPur_Currency as c on c.CurrencyID = p.POCurrencyID 
                                    inner join tblPur_WareHouse as w on w.WareHouseID = p.WareHouseID
                                    inner join tblPur_Status as t on t.StatusID = p.POStatusID
                                    inner join tblPur_Tax as x on x.TaxID = p.POTaxID

                                    WHERE p.PODateCreate >= @DateFrom AND p.PODateCreate <= @DateTo
                                    ORDER BY p.PONumber DESC 
                                    OFFSET 0 ROWS FETCH NEXT @ShowRow ROWS ONLY; ";

                SqlCommand cmd = new SqlCommand(sql_query, conn);
                cmd.Parameters.Add("@DateFrom", SqlDbType.DateTime).Value = DateFrom.Date;
                cmd.Parameters.Add("@DateTo", SqlDbType.DateTime).Value = DateTo.Date;
                cmd.Parameters.Add("@ShowRow", SqlDbType.Int).Value = ShowRow;
                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                conn.Open();
                adap.Fill(BangDuLieu);
            }

            return BangDuLieu;
        }


        /// <summary>
        /// 25. SELECT - Lấy dữ liệu từ bảng tblPur_PO theo PONumber
        /// </summary>
        /// <param name="PONumber"></param>
        /// <returns></returns>
        public DataTable Select_tblPur_PO_by_PONumber_DAL(int PONumber)
        {
            DataTable BangDuLieu = new DataTable();
            using (SqlConnection conn = new SqlConnection(Dataconnect))
            {
                string sql_query = @"select 
	                                    p.PONumber,
	                                    p.PODateCreate,
	                                    p.POEstimateDeliveryDate,
	                                    p.POSupplierID,
	                                    p.POSupplierContactPerson,
	                                    p.POCurrencyID,
	                                    p.POUser,
	                                    p.POStatusID,
	                                    p.PORemark,
	                                    p.POPaymentTerm,
	                                    p.WareHouseID,
	                                    p.POToTalPayment,
                                        p.POTaxID
                                    from tblPur_PO as p
                                    where p.PONumber = @PONumber ";

                SqlCommand cmd = new SqlCommand(sql_query, conn);
                cmd.Parameters.Add("@PONumber", SqlDbType.Int).Value = PONumber;

                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                conn.Open();
                adap.Fill(BangDuLieu);
            }

            return BangDuLieu;
        }

        /// <summary>
        /// 26. SELECT - Lấy dữ liệu từ bảng tblPur_PO_Detail theo PONumber
        /// </summary>
        /// <param name="PONumber"></param>
        /// <returns></returns>
        public DataTable Select_tblPur_PO_Detail_by_PONumber_DAL(int PONumber)
        {
            DataTable BangDuLieu = new DataTable();
            using (SqlConnection conn = new SqlConnection(Dataconnect))
            {
                string sql_query = @"select
	                                    p.PartCode,
	                                    p.PartName,
	                                    d.Quantity_Order as Quantity, 
	                                    d.UnitPrice ,
	                                    u.UnitName as Unit,
	                                    d.Discount,
	                                    d.Amount as Total,
	                                    t.TaxCode,
                                        d.PODetail_RowID as RowID
                                    from tblPur_PO_Detail as d
                                    inner join tblPart as p on p.PartID = d.PartID
                                    inner join tblPur_Unit as u on u.UnitID = d.UnitID
                                    inner join tblPur_Part as t on t.PartID = p.PartID
                                    Where d.PONumber = @PONumber ";

                SqlCommand cmd = new SqlCommand(sql_query, conn);
                cmd.Parameters.Add("@PONumber", SqlDbType.Int).Value = PONumber;

                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                conn.Open();
                adap.Fill(BangDuLieu);
            }

            return BangDuLieu;
        }

        /// <summary>
        /// 27. UPDATE - Cập nhật thông tin đơn đặt hàng (Purchase Order) đã tồn tại trong bảng tblPur_PO
        /// </summary>
        /// <param name="PONumber"></param>
        /// <param name="_dcreate"></param>
        /// <param name="_destimate"></param>
        /// <param name="SupID"></param>
        /// <param name="SupPerson"></param>
        /// <param name="CurID"></param>
        /// <param name="user"></param>
        /// <param name="StatusID"></param>
        /// <param name="Remark"></param>
        /// <param name="PaymentTerm"></param>
        /// <param name="WareHouseID"></param>
        /// <param name="TotalPayment"></param>
        /// <param name="TaxID"></param>
        /// <param name="tblUpdate"></param>
        /// <param name="tblDelete"></param>
        /// <param name="tblInsert"></param>
        /// <returns></returns>
        public bool Update_Existing_PO_DAL(int PONumber, DateTime _dcreate, DateTime _destimate,int SupID, string SupPerson, int CurID , string user, int StatusID, string Remark, 
            string PaymentTerm, int WareHouseID, decimal TotalPayment, int TaxID,  DataTable tblUpdate, DataTable tblDelete, DataTable tblInsert)
        {
            using (SqlConnection con = new SqlConnection(Dataconnect))
            {
                con.Open();

                using (SqlTransaction transaction = con.BeginTransaction())
                {
                    try
                    {
                        using (SqlCommand cmd = new SqlCommand("Update_Existing_PO", con, transaction))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;

                            // Truyền các tham số đầu vào
                            cmd.Parameters.Add("@PONumber", SqlDbType.Int).Value = PONumber;
                            cmd.Parameters.Add("@PODateCreate", SqlDbType.Date).Value = _dcreate;
                            cmd.Parameters.Add("@POEstimateDeliveryDate", SqlDbType.Date).Value = _destimate;
                            cmd.Parameters.Add("@POSupplierID", SqlDbType.Int).Value = SupID;
                            cmd.Parameters.Add("@POSupplierContactPerson", SqlDbType.NVarChar, 100).Value = SupPerson;
                            cmd.Parameters.Add("@POCurrencyID", SqlDbType.Int).Value =CurID;
                            cmd.Parameters.Add("@POUser", SqlDbType.NVarChar, 50).Value = user;
                            cmd.Parameters.Add("@POStatusID", SqlDbType.Int).Value = StatusID;
                            cmd.Parameters.Add("@PORemark", SqlDbType.NVarChar, 200).Value = Remark;
                            cmd.Parameters.Add("@POPaymentTerm", SqlDbType.NVarChar, 100).Value = PaymentTerm;
                            cmd.Parameters.Add("@WareHouseID", SqlDbType.Int).Value = WareHouseID;
                            cmd.Parameters.Add("@POToTalPayment", SqlDbType.Decimal).Value = TotalPayment;
                            cmd.Parameters.Add("@POTaxID", SqlDbType.Int).Value = TaxID; 

                            // Thêm bảng chi tiết kiểu TVP (Table-Valued Parameter)
                            SqlParameter tvpParam_Update = cmd.Parameters.AddWithValue("@tbl_Pur_PO_Detail_Update", tblUpdate);
                            tvpParam_Update.SqlDbType = SqlDbType.Structured;
                            tvpParam_Update.TypeName = "tbl_Pur_PO_Detail_Full_Defined "; // Phải khớp với type bạn tạo trong SQL

                            SqlParameter tvpParam_Delete = cmd.Parameters.AddWithValue("@tbl_Pur_PO_Detail_Delete", tblDelete);
                            tvpParam_Delete.SqlDbType = SqlDbType.Structured;
                            tvpParam_Delete.TypeName = "tbl_Pur_PO_Detail_Full_Defined"; // Phải khớp với type bạn tạo trong SQL

                            SqlParameter tvpParam_Insert = cmd.Parameters.AddWithValue("@tbl_Pur_PO_Detail_Insert", tblInsert);
                            tvpParam_Insert.SqlDbType = SqlDbType.Structured;
                            tvpParam_Insert.TypeName = "tbl_Pur_PO_Detail_Defined"; // Phải khớp với type bạn tạo trong SQL

                            // Thực thi stored procedure
                            cmd.ExecuteNonQuery();
                        }

                        transaction.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        Console.WriteLine("Error: " + ex.Message);
                        return false;
                    }
                }
            }
        }

        /// <summary>
        /// 27. SELECT - Lấy dữ liệu từ bảng tblPur_PO_Detail cho việc tạo GRPO
        /// </summary>
        /// <param name="tbl_ListPONumber"></param>
        /// <returns></returns>
        public DataTable Select_tbl_Pur_PO_Detail_for_GRPO_DAL(DataTable tbl_ListPONumber)
        {
            DataTable BangDuLieu = new DataTable();
            using (SqlConnection conn = new SqlConnection(Dataconnect))
            {
                string sql_query = @"       SELECT 
                                                d.PONumber,
                                                t.PartCode,
                                                r.TaxCode,
                                                d.Quantity_Order,
                                                1 AS Received_Quantity ,
                                                d.UnitPrice AS Price,
                                                u.UnitName AS Unit,
                                                d.Discount,
                                                p.TaxName,
                                                d.Amount AS Total,
                                                p.CurrencyName as Currency,
		                                        p.POUser ,
		                                        p.POWareHouse as WareHouse
                                            FROM tblPur_PO_Detail AS d
                                            INNER JOIN @PONumbers AS p ON p.PONumber = d.PONumber
                                            INNER JOIN tblPart AS t ON t.PartID = d.PartID
                                            INNER JOIN tblPur_Part AS r ON r.PartID = d.PartID
                                            INNER JOIN tblPur_Unit AS u ON d.UnitID = u.UnitID Order by d.PONumber desc;";

                SqlCommand cmd = new SqlCommand(sql_query, conn);
                SqlParameter tvpParam_Update = cmd.Parameters.AddWithValue("@PONumbers", tbl_ListPONumber);
                tvpParam_Update.SqlDbType = SqlDbType.Structured;
                tvpParam_Update.TypeName = "tbl_List_PONumber ";

                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                conn.Open();
                adap.Fill(BangDuLieu);
            }

            return BangDuLieu;
        }

    }
}