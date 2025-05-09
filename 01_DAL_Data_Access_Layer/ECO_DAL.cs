using System;
using System.Collections.Generic;

//using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PLM_Lynx._01_DAL_Data_Access_Layer
{
    public class ECO_DAL
    {
        private string Dataconnect = Properties.Settings.Default.Datacon;

        /// 01. SELECT - Danh sách các Part Child khi nhập vào Part Parent
        /// <param name="KeySearch"></param>
        /// <returns> Bảng chứa danh sách các Part Chứa từ khóa đó
        public DataTable GetListChildDAL(string ParentCode)
        {
            DataTable BangDuLieu = new DataTable();
            using (SqlConnection conn = new SqlConnection(Dataconnect))
            {
                string sql_query = @"
                                    SELECT tblPart.PartCode, tblPart.PartName, tblRelation.Quantity FROM tblPart
                                    INNER JOIN tblRelation
                                    ON tblPart.PartID = tblRelation.ChildID WHERE tblRelation.ParentID = (
                                    SELECT TOP 1 PartID
                                    FROM tblPart
                                    WHERE PartCode = @PartCode );";

                SqlCommand cmd = new SqlCommand(sql_query, conn);
                cmd.Parameters.AddWithValue("@PartCode", ParentCode);

                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                conn.Open();
                adap.Fill(BangDuLieu);
            }
            return BangDuLieu;
        }

        /// 02. [UPDATE] Cập nhật Quantity của tblRelation
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="role"></param>
        /// <param name="position"></param>
        /// <param name="dept"></param>
        /// <returns></returns>
        public bool CapnhatQuantityDAL(string parentcode, string childcode, int quantity)
        {
            using (SqlConnection con = new SqlConnection(Dataconnect))
            {
                //-------------------------
                string sql_query;
                sql_query = @"
                                update tblRelation
                                set Quantity = @Quantity, RelationStatus = 'Modified'
                                where ParentID = (select top 1 PartID from tblPart where PartCode = @ParentCode)
                                and ChildID = (select top 1 PartID from tblPart where PartCode =  @ChildCode )
                    ";
                SqlCommand cmd = new SqlCommand(sql_query, con);
                cmd.Parameters.Add("@ParentCode", SqlDbType.NVarChar).Value = parentcode;
                cmd.Parameters.Add("@ChildCode", SqlDbType.NVarChar).Value = childcode;
                cmd.Parameters.Add("@Quantity", SqlDbType.Int).Value = quantity;

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


        public bool CapnhatQuantityDAL(DataTable updateTable)
        {
            using (SqlConnection con = new SqlConnection(Dataconnect))
            {
                con.Open();
                using (SqlTransaction tran = con.BeginTransaction())
                {
                    try
                    {
                        
                        using (SqlCommand cmd = new SqlCommand("dbo.UpdateQuantities", con, tran))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                          
                            SqlParameter tvpParam = cmd.Parameters.AddWithValue("@Updates", updateTable);
                            tvpParam.SqlDbType = SqlDbType.Structured;
                            tvpParam.TypeName = "dbo.tblUpdateQuantity";

                            
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
        /// 03. UPDATE - Update Log File của Part ParentCode về việc sửa số lượng
        /// </summary>
        /// <param name="parentcode"></param>
        /// <param name="childcode"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public bool CapnhatLogPartDAL(string parentcode, string childcode, int quantity)
        {
            using (SqlConnection con = new SqlConnection(Dataconnect))
            {
                //-------------------------
                string sql_query;
                sql_query = @"
                                update tblPart
                                set PartLog =CONCAT(FORMAT(GETDATE(), 'MM-dd-yyyy HH:mm'), ' Change_Quantity ', @ChildCode, ' - ', @Quantity, CHAR(13), CHAR(10), '|', PartLog)
                                where PartCode = @ParentCode
                    ";
                SqlCommand cmd = new SqlCommand(sql_query, con);
                cmd.Parameters.Add("@ParentCode", SqlDbType.NVarChar).Value = parentcode;
                cmd.Parameters.Add("@ChildCode", SqlDbType.NVarChar).Value = childcode;
                cmd.Parameters.Add("@Quantity", SqlDbType.NVarChar).Value = quantity.ToString();

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

        /// 04. [DELETE] Xóa 1 ràng buộc của 2 Part trong DataBase bằng tblRelation
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public bool XoaRelationDAL(DataTable deleteTable)
        {
            using (SqlConnection con = new SqlConnection(Dataconnect))
            {
                con.Open();
                using (SqlTransaction tran = con.BeginTransaction())
                {
                    try
                    {

                        using (SqlCommand cmd = new SqlCommand("dbo.DeleteRelation", con, tran))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;

                            SqlParameter tvpParam = cmd.Parameters.AddWithValue("@Deletes", deleteTable);
                            tvpParam.SqlDbType = SqlDbType.Structured;
                            tvpParam.TypeName = "dbo.tblDeleteRelation";


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
        /// 05. Xóa 1 ràng buộc của 2 Part bảng tblRelationTemp
        /// </summary>
        /// <param name="parentcode"></param>
        /// <param name="childcode"></param>
        /// <returns></returns>
        public bool Delete_tblRelationTemp_DAL(string parentcode, string childcode)
        {
            using (SqlConnection con = new SqlConnection(Dataconnect))
            {
                string sql_query;
                sql_query = @"delete tblRelationTemp
                            where ParentID = (select top 1 PartID from tblPart where PartCode = @ParentCode )
                            and ChildID = (select top 1 PartID from tblPart where PartCode = @ChildCode )";
                SqlCommand cmd = new SqlCommand(sql_query, con);
                cmd.Parameters.Add("@ParentCode", SqlDbType.NVarChar).Value = parentcode;
                cmd.Parameters.Add("@ChildCode", SqlDbType.NVarChar).Value = childcode;
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

        public bool Delete_tblRelationTemp_DAL(DataTable delete_table)
        {
            using (SqlConnection con = new SqlConnection(Dataconnect))
            {
                con.Open();
                using (SqlTransaction tran = con.BeginTransaction())
                {
                    try
                    {

                        using (SqlCommand cmd = new SqlCommand("dbo.DeleteRelationTemp", con, tran))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;

                            SqlParameter tvpParam = cmd.Parameters.AddWithValue("@DeletesTemp", delete_table);
                            tvpParam.SqlDbType = SqlDbType.Structured;
                            tvpParam.TypeName = "dbo.tblInsertRelation";


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

        public bool DeleteLogPartDAL(string parentcode, string childcode)
        {
            using (SqlConnection con = new SqlConnection(Dataconnect))
            {
                //-------------------------
                string sql_query;
                sql_query = @"
                                update tblPart
                                set PartLog =CONCAT(FORMAT(GETDATE(), 'MM-dd-yyyy HH:mm'), ' Delete Relation ', @ChildCode,  CHAR(13), CHAR(10), '|', PartLog)
                                where PartCode = @ParentCode
                    ";
                SqlCommand cmd = new SqlCommand(sql_query, con);
                cmd.Parameters.Add("@ParentCode", SqlDbType.NVarChar).Value = parentcode;
                cmd.Parameters.Add("@ChildCode", SqlDbType.NVarChar).Value = childcode;

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

        //------------------------------------------------
        /// 05. SELECT - Lấy thông tin của  1 part code
        /// <param name="KeySearch"></param>
        /// <returns> Bảng chứa danh sách các Part Chứa từ khóa đó
        public DataTable GetInforPartDAL(string PartCode)
        {
            DataTable BangDuLieu = new DataTable();
            using (SqlConnection conn = new SqlConnection(Dataconnect))
            {
                // string sql_query = @" select * from tblPart where PartCode = @PartCode";
                string sql_query;
                sql_query = @"SELECT
                                p.PartCode,
                                p.PartName,
                                p.PartDescript,
                                s.Stage as PartStage,
                                p.PartLog,
                                p.PartPrice,
                                p.PartMaterial,
                                p.PartStageID
                            FROM tblPart AS p
                            JOIN tblPartStage AS s ON p.PartStageID = s.IDStage
                            WHERE p.PartCode = @PartCode;
                    ";

                SqlCommand cmd = new SqlCommand(sql_query, conn);
                cmd.Parameters.AddWithValue("@PartCode", PartCode);

                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                conn.Open();
                adap.Fill(BangDuLieu);
            }
            return BangDuLieu;
        }

        /// <summary>
        /// 06. UPDATE - Cập nhật thông tin của 1 Part
        /// </summary>
        /// <param name="parentcode"></param>
        /// <param name="childcode"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public bool Update_InforPart_DAL(string PartCode, int PartStageID, string PartMaterial, int ECONo)
        {
            using (SqlConnection con = new SqlConnection(Dataconnect))
            {
                DateTime PartDate = DateTime.Now.Date;
                string sql_query = @"
                                    UPDATE tblPart
                                    SET
                                        PartLog = CONCAT( @ECONo,  CHAR(13), CHAR(10), '|', PartLog),
                                        PartMaterial = @PartMaterial,
                                        PartStageID = @PartStageID,
                                        PartDate = @PartDate    
                                    WHERE PartCode = @PartCode";

                con.Open();
                SqlTransaction transaction = con.BeginTransaction();  // Bắt đầu Transaction

                try
                {
                    using (SqlCommand cmd = new SqlCommand(sql_query, con, transaction))
                    {
                        cmd.Parameters.Add("@PartCode", SqlDbType.NVarChar).Value = PartCode;
                        cmd.Parameters.Add("@PartMaterial", SqlDbType.NVarChar).Value = PartMaterial;
                        cmd.Parameters.Add("@PartStageID", SqlDbType.Int).Value = PartStageID;
                        cmd.Parameters.Add("@ECONo", SqlDbType.NVarChar).Value = ECONo.ToString();
                        cmd.Parameters.Add("@PartDate", SqlDbType.Date).Value = PartDate;

                        int result = cmd.ExecuteNonQuery();

                        if (result == 1)
                        {
                            transaction.Commit();  // Commit nếu thành công
                            return true;
                        }
                        else
                        {
                            transaction.Rollback();  // Rollback nếu không cập nhật được dòng nào
                            return false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();  // Rollback nếu có lỗi xảy ra
                    Console.WriteLine("Lỗi: " + ex.Message);
                    return false;
                }
            }
        }


        /// <summary>
        /// 07. UPDATE - Cập nhật thông tin của tblECO  : Theo Dạng Aprroved
        /// </summary>
        /// <param name="IDApproved"></param>
        /// <param name="NameApproved"></param>
        /// <param name="ECONo"></param>
        /// <returns></returns>
        public bool Update_tblECO_Approved_DAL(int IDApproved, string NameApproved , int ECONo)
        {
            using (SqlConnection con = new SqlConnection(Dataconnect))
            {
                DateTime dt = DateTime.Now.Date;
                string Log = "Approved " + dt.ToString("yyyy/MM/dd") + " || ";

                string sql_query = @"
                                    
                                    UPDATE tblECO
                                    SET ECOStatusID = 2  , 
                                    ECOLog = CONCAT( @Log ,  CHAR(13), CHAR(10), '|', ECOLog)  ,
                                    ECOIDApproved = @IDApproved ,
                                    ECONameApproved = @NameApproved 

                                    WHERE ECONo = @ECONo";

                con.Open();
                SqlTransaction transaction = con.BeginTransaction();  // Bắt đầu Transaction

                try
                {
                    using (SqlCommand cmd = new SqlCommand(sql_query, con, transaction))
                    {
                        cmd.Parameters.Add("@ECONo", SqlDbType.Int).Value = ECONo;
                        cmd.Parameters.Add("@Log", SqlDbType.NVarChar).Value = Log;
                        cmd.Parameters.Add("@IDApproved", SqlDbType.Int).Value = IDApproved;
                        cmd.Parameters.Add("@NameApproved", SqlDbType.NVarChar).Value = NameApproved;

                        int result = cmd.ExecuteNonQuery();

                        if (result == 1)
                        {
                            transaction.Commit();  // Commit nếu thành công
                            return true;
                        }
                        else
                        {
                            transaction.Rollback();  // Rollback nếu không cập nhật được dòng nào
                            return false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();  // Rollback nếu có lỗi xảy ra
                    Console.WriteLine("Lỗi: " + ex.Message);
                    return false;
                }
            }
        }


        public bool Update_tblECO_Approved_DAL(int IDApproved, string NameApproved, int ECONo, string ECOContent)
        {
            using (SqlConnection con = new SqlConnection(Dataconnect))
            {
                DateTime dt = DateTime.Now.Date;
                string Log = "Approved " + dt.ToString("yyyy/MM/dd") + " || ";

                string sql_query = @"
                                    
                                    UPDATE tblECO
                                    SET ECOStatusID = 2  , 
                                    ECOLog = CONCAT( @Log ,  CHAR(13), CHAR(10), '|', ECOLog)  ,
                                    ECOIDApproved = @IDApproved ,
                                    ECOContent = @ECOContent,       
                                    ECONameApproved = @NameApproved 

                                    WHERE ECONo = @ECONo";

                con.Open();
                SqlTransaction transaction = con.BeginTransaction();  // Bắt đầu Transaction

                try
                {
                    using (SqlCommand cmd = new SqlCommand(sql_query, con, transaction))
                    {
                        cmd.Parameters.Add("@ECONo", SqlDbType.Int).Value = ECONo;
                        cmd.Parameters.Add("@Log", SqlDbType.NVarChar).Value = Log;
                        cmd.Parameters.Add("@IDApproved", SqlDbType.Int).Value = IDApproved;
                        cmd.Parameters.Add("@NameApproved", SqlDbType.NVarChar).Value = NameApproved;
                        cmd.Parameters.Add("@ECOContent", SqlDbType.NVarChar).Value = ECOContent;

                        int result = cmd.ExecuteNonQuery();

                        if (result == 1)
                        {
                            transaction.Commit();  // Commit nếu thành công
                            return true;
                        }
                        else
                        {
                            transaction.Rollback();  // Rollback nếu không cập nhật được dòng nào
                            return false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();  // Rollback nếu có lỗi xảy ra
                    Console.WriteLine("Lỗi: " + ex.Message);
                    return false;
                }
            }
        }


        public bool Update_tblECO_Canceled_DAL(int IDApproved, string NameApproved, int ECONo)
        {
            using (SqlConnection con = new SqlConnection(Dataconnect))
            {
                DateTime dt = DateTime.Now.Date;
                string Log = "Canceled " + dt.ToString("yyyy/MM/dd") + " || ";

                string sql_query = @"
                                    
                                    UPDATE tblECO
                                    SET ECOStatusID = 3  , 
                                    ECOLog = CONCAT( @Log ,  CHAR(13), CHAR(10), '|', ECOLog)  ,
                                    ECOIDApproved = @IDApproved ,
                                    ECONameApproved = @NameApproved 

                                    WHERE ECONo = @ECONo";

                con.Open();
                SqlTransaction transaction = con.BeginTransaction();  // Bắt đầu Transaction

                try
                {
                    using (SqlCommand cmd = new SqlCommand(sql_query, con, transaction))
                    {
                        cmd.Parameters.Add("@ECONo", SqlDbType.Int).Value = ECONo;
                        cmd.Parameters.Add("@Log", SqlDbType.NVarChar).Value = Log;
                        cmd.Parameters.Add("@IDApproved", SqlDbType.Int).Value = IDApproved;
                        cmd.Parameters.Add("@NameApproved", SqlDbType.NVarChar).Value = NameApproved;

                        int result = cmd.ExecuteNonQuery();

                        if (result == 1)
                        {
                            transaction.Commit();  // Commit nếu thành công
                            return true;
                        }
                        else
                        {
                            transaction.Rollback();  // Rollback nếu không cập nhật được dòng nào
                            return false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();  // Rollback nếu có lỗi xảy ra
                    Console.WriteLine("Lỗi: " + ex.Message);
                    return false;
                }
            }
        }

        public bool Write_ECONo_to_tblPart_DAL(string PartCode, string ECONo)
        {
            using (SqlConnection con = new SqlConnection(Dataconnect))
            {
                
                DateTime PartDate = DateTime.Now.Date;
                string sql_query = @"
                                    UPDATE tblPart
                                    SET PartLog = CONCAT( @ECONo ,  CHAR(13), CHAR(10), '|', PartLog) , 
                                        PartDate = @PartDate
                                    WHERE PartCode = @PartCode";

                con.Open();
                SqlTransaction transaction = con.BeginTransaction();  // Bắt đầu Transaction

                try
                {
                    using (SqlCommand cmd = new SqlCommand(sql_query, con, transaction))
                    {
                        cmd.Parameters.Add("@ECONo", SqlDbType.NVarChar).Value = ECONo;
                        cmd.Parameters.Add("@PartCode", SqlDbType.NVarChar).Value = PartCode;
                        cmd.Parameters.Add("@PartDate", SqlDbType.Date).Value = PartDate;

                        int result = cmd.ExecuteNonQuery();

                        if (result == 1)
                        {
                            transaction.Commit();  // Commit nếu thành công
                            return true;
                        }
                        else
                        {
                            transaction.Rollback();  // Rollback nếu không cập nhật được dòng nào
                            return false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();  // Rollback nếu có lỗi xảy ra
                    Console.WriteLine("Lỗi: " + ex.Message);
                    return false;
                }
            }
        }




        /// <summary>
        /// 07. Lấy thông tin về ECO mới nhất hiện tại
        /// </summary>
        /// <returns></returns>
        public tblECO GetLastest_ECO_DAL()
        {
            tblECO _tbl_Eco = null;

            using (SqlConnection conn = new SqlConnection(Dataconnect))
            {
                string sql_query = @"
                       SELECT TOP 1 tblECO.ECONo, tblECO.ECODate 
                        FROM tblECO 
                        WHERE CAST(tblECO.ECODate AS DATE) = CAST(GETDATE() AS DATE)
                        ORDER BY ECODate DESC, ECONo DESC ";

                SqlCommand cmd = new SqlCommand(sql_query, conn);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read()) // Nếu đọc được giá trị thì :
                {
                    _tbl_Eco = new tblECO
                    {
                        ECONo = Convert.ToInt32(reader[0]),
                        ECODate = Convert.ToDateTime(reader[1])
                    };
                }

                conn.Close();
            }

            return _tbl_Eco;
        }

        public bool InsertNewECO_DAL(int ECONo, int IDProposal, string NameProposal, int ECOTypeID, string ECOContent)
        {
            using (SqlConnection con = new SqlConnection(Dataconnect))
            {
                try
                {
                    con.Open(); // Mở kết nối

                    // Ghi các giá trị
                    DateTime ECODate = DateTime.Now.Date;
                    string ECOLog = "Created " + ECODate.ToString("yyyy/MM/dd") + " || ";
                    int ECOStatusID = 1;

                    // Tạo nội dung JSON hợp lệ

                    // Tạo giao dịch
                    using (SqlTransaction transaction = con.BeginTransaction())
                    {
                        string sql_query = @"
                    INSERT INTO tblECO
                    (ECONo, ECODate, ECOLog, ECOTypeID, ECOIDProposal, ECONameProposal, ECOStatusID, ECOContent)
                    VALUES
                    (@ECONo, @ECODate, @ECOLog, @ECOTypeID, @ECOIDProposal, @ECONameProposal, @ECOStatusID, @ECOContent)";

                        using (SqlCommand cmd = new SqlCommand(sql_query, con, transaction))
                        {
                            // Thêm các tham số với kiểu dữ liệu chính xác
                            cmd.Parameters.Add("@ECONo", SqlDbType.Int).Value = ECONo;
                            cmd.Parameters.Add("@ECODate", SqlDbType.DateTime).Value = ECODate;
                            cmd.Parameters.Add("@ECOLog", SqlDbType.NVarChar, 100).Value = ECOLog;
                            cmd.Parameters.Add("@ECOTypeID", SqlDbType.Int).Value = ECOTypeID;
                            cmd.Parameters.Add("@ECOIDProposal", SqlDbType.Int).Value = IDProposal;
                            cmd.Parameters.Add("@ECONameProposal", SqlDbType.NVarChar, 40).Value = NameProposal;
                            cmd.Parameters.Add("@ECOStatusID", SqlDbType.Int).Value = ECOStatusID;
                            cmd.Parameters.Add("@ECOContent", SqlDbType.NVarChar).Value = ECOContent;

                            // Thực thi câu lệnh SQL
                            int result = cmd.ExecuteNonQuery();

                            // Nếu không có lỗi, xác nhận giao dịch
                            transaction.Commit();

                            return result > 0; // Trả về true nếu thêm thành công
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Lỗi: " + ex.Message);
                    return false;
                }
            }
        }

        /// 04. SELECT - Lấy danh sách j5, 10, 15 ECO Gần nhất
        /// <param name="NoRow"></param>
        /// <returns></returns>
        public DataTable GetListNearECO_DAL(int NoRow)
        {
            DataTable BangDuLieu = new DataTable();
            using (SqlConnection conn = new SqlConnection(Dataconnect))
            {
                string sql_query = $@"SELECT TOP {NoRow} e.ECONo, e.ECODate, t.ECOType, e.ECONameProposal, e.ECONameApproved, s.ECOStatus, e.ECOContent  , e.ECOTypeID  , e.ECOStatusID
                                        FROM tblECO as e
                                        JOIN tblECOStatus as s ON e.ECOStatusID = s.ECOStatusID
                                        JOIN tblECOType  as t ON e.ECOTypeID = t.ECOTypeID
                                        ORDER BY e.ECODate DESC , e.ECONo Desc";

                SqlCommand cmd = new SqlCommand(sql_query, conn);
                cmd.Parameters.AddWithValue("@NoRow", NoRow);

                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                conn.Open();
                adap.Fill(BangDuLieu);
            }
            return BangDuLieu;
        }

        /// <summary>
        /// 05. SELECT - Lấy danh sách tất cả Stage trong bảng tblPartStage
        /// </summary>
        /// <returns></returns>
        public DataTable GettblPartStage_DAL()
        {
            DataTable BangDuLieu = new DataTable();
            using (SqlConnection conn = new SqlConnection(Dataconnect))
            {
                string sql_query;
                sql_query = @" select  s.IDStage, s.Stage from tblPartStage as s ";

                SqlCommand cmd = new SqlCommand(sql_query, conn);

                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                conn.Open();
                adap.Fill(BangDuLieu);
            }
            return BangDuLieu;
        }

        public bool DeleteECO_DAL(int ECONo)
        {
            using (SqlConnection con = new SqlConnection(Dataconnect))
            {
                string sql_query = @" DELETE FROM tblECO where ECONo = @ECONo";

                con.Open();
                using (SqlTransaction transaction = con.BeginTransaction())
                {
                    try
                    {
                        using (SqlCommand cmd = new SqlCommand(sql_query, con, transaction))
                        {
                            cmd.Parameters.Add("@ECONo", SqlDbType.Int).Value = ECONo;

                            int result = cmd.ExecuteNonQuery();

                            // Nếu xóa thành công ít nhất 1 dòng thì commit transaction
                            if (result > 0)
                            {
                                transaction.Commit();
                                return true;
                            }
                            else
                            {
                                transaction.Rollback();
                                return false;
                            }
                        }
                    }
                    catch (Exception)
                    {
                        transaction.Rollback(); // Hoàn tác nếu có lỗi
                        return false;
                    }
                }
            }
        }

        public bool InsertNewRelation_in_tblRelationTemp_DAL(string ParentCode, string ChildCode, int Quantity)
        {
            using (SqlConnection con = new SqlConnection(Dataconnect))
            {
                // Mở kết nối
                con.Open();

                // Tạo một giao dịch (Transaction) C#
                using (SqlTransaction transaction = con.BeginTransaction())
                {
                    string sql_query;
                    sql_query = " INSERT INTO tblRelationTemp ( ParentID, ChildID )" +
                        "VALUES (" +
                        " (SELECT TOP 1 PartID FROM tblPart WHERE PartCode = @ParentCode )," +
                        " (SELECT TOP 1 PartID FROM tblPart WHERE PartCode = @ChildCode ) ); " +
                        " update tblRelationTemp set Quantity = @Quantity" +
                        " where ParentID = (SELECT TOP 1 PartID FROM tblPart WHERE PartCode = @ParentCode)  and " +
                        "        ChildID = (SELECT TOP 1 PartID FROM tblPart WHERE PartCode = @ChildCode ) ";

                    SqlCommand cmd = new SqlCommand(sql_query, con, transaction);

                    // Sử dụng Add với kiểu dữ liệu cụ thể thay vì AddWithValue
                    cmd.Parameters.Add("@ParentCode", SqlDbType.NVarChar).Value = ParentCode;
                    cmd.Parameters.Add("@ChildCode", SqlDbType.NVarChar).Value = ChildCode;
                    cmd.Parameters.Add("@Quantity", SqlDbType.SmallInt).Value = Quantity;

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