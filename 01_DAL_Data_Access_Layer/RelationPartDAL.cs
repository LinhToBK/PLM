using System;
using System.Collections.Generic;
//using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLM_Lynx._01_DAL_Data_Access_Layer
{
    public class RelationPartDAL
    {
        private string Dataconnect = Properties.Settings.Default.Datacon;

        /// 01. SELECT - Lấy danh sách tìm kiếm theo từ khóa trên ô tìm kiếm
        /// <param name="KeySearch"></param>
        /// <returns> Bảng chứa danh sách các Part Chứa từ khóa đó
        public DataTable FindwithwordDAL(string KeySearch)
        {

            //  select p.PartCode, p.PartName, p.PartDescript, p.PartStage, p.PartPrice, p.PartLog, p.PartFile from tblPart as p  where PartName like '%BA%'
            //  Or PartCode like '%BA%' or PartDescript like '%BA%'
            DataTable BangDuLieu = new DataTable();
            using (SqlConnection conn = new SqlConnection(Dataconnect))
            {
                string sql_query = @"
                        SELECT 
                            p.PartCode, 
                            p.PartName, 
                            p.PartDescript
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


        /// <summary>
        /// 02. SELECT - Lấy thông tin của Part dựa trên PartCode
        /// </summary>
        /// <param name="PartCode"></param>
        /// <returns></returns>
        public DataTable GetInforPartDAL (string PartCode)
        {
            DataTable BangDuLieu = new DataTable();
            using (SqlConnection conn = new SqlConnection(Dataconnect))
            {
                string query;
                //query = "select PartCode, PartName, PartDescript, PartStage, PartLog, PartPrice , PartMaterial from tblPart where PartCode = @PartCode";

                query = @"SELECT 
                            p.PartCode, 
                            p.PartName, 
                            p.PartDescript, 
                            s.Stage,
                            p.PartLog, 
                            p.PartPrice, 
                            p.PartMaterial  
                        FROM tblPart AS p  
                        JOIN tblPartStage AS s ON p.PartStageID = s.IDStage  
                        WHERE p.PartCode = @PartCode ;";

                SqlCommand cmd = new SqlCommand(@query, conn);
                cmd.Parameters.AddWithValue("@PartCode", PartCode);
                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                conn.Open();
                adap.Fill(BangDuLieu);
            }
            return BangDuLieu;

        }


        /// <summary>
        /// 03. SELECT - Lấy danh sách các PartChild của 1 PartCode
        /// </summary>
        /// <param name="partcode"></param>
        /// <returns></returns>
        public DataTable FindChildDAL(string PartCode)
        {
            DataTable BangDuLieu = new DataTable();
            using (SqlConnection conn = new SqlConnection(Dataconnect))
            {
                string query;
                //query = @"select ChildID from tblRelation where ParentID = (select top 1 PartID from tblPart where PartCode = @PartCode ) ";

                query = @"select  PartCode  from tblPart	
                            where PartID in (  select ChildID   from tblRelation 
					        where ParentID = (select top 1 PartID from tblPart where PartCode = @PartCode))";
                SqlCommand cmd = new SqlCommand(@query, conn);
                cmd.Parameters.AddWithValue("@PartCode", PartCode);
                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                conn.Open();
                adap.Fill(BangDuLieu);
            }
            return BangDuLieu;
        }



        /// <summary>
        /// 04. SELECT - Lấy danh sách các PartParent của 1 PartCode
        /// </summary>
        /// <param name="PartCode"></param>
        /// <returns></returns>
        public DataTable FindParentDAL(string PartCode)
        {
            DataTable BangDuLieu = new DataTable();
            using (SqlConnection conn = new SqlConnection(Dataconnect))
            {
                string query;
                //query = @"select ParentID from tblRelation where ChildID = (select top 1 PartID from tblPart where PartCode = @PartCode) ";
                query = @"select  PartCode  from tblPart	
                        where PartID in (  select ParentID   from tblRelation 
					        where ChildID = (select top 1 PartID from tblPart where PartCode = @PartCode))";
                SqlCommand cmd = new SqlCommand(@query, conn);
                cmd.Parameters.AddWithValue("@PartCode", PartCode);
                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                conn.Open();
                adap.Fill(BangDuLieu);
            }
            return BangDuLieu;
        }



        /// <summary>
        /// 05. INSERT - Thêm 1 ràng buộc quan hệ cha con của 2 Part Code 
        /// </summary>
        /// <param name="ParentCode"></param>
        /// <param name="ChildCode"></param>
        /// <param name="Quantity"></param>
        /// <returns></returns>
        public bool InsertNewRelationDAL(string ParentCode, string ChildCode, int Quantity)
        {
            using (SqlConnection con = new SqlConnection(Dataconnect))
            {
                // Mở kết nối
                con.Open();

                // Tạo một giao dịch (Transaction) C#
                using (SqlTransaction transaction = con.BeginTransaction())
                {
                    string sql_query;
                    sql_query = " INSERT INTO tblRelation ( ParentID, ChildID )" +
                        "VALUES (" +
                        " (SELECT TOP 1 PartID FROM tblPart WHERE PartCode = @ParentCode )," +
                        " (SELECT TOP 1 PartID FROM tblPart WHERE PartCode = @ChildCode ) ); " +
                        " update tblRelation set Quantity = @Quantity" +
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
