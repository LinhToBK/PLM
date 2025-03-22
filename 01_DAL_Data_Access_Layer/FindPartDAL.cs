using System;
using System.Collections.Generic;
using System.Data;
//using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLM_Lynx._01_DAL_Data_Access_Layer
{
    public class FindPartDAL
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
                            p.PartDescript, 
                            p.PartStage,
                            p.PartID,
                            p.PartPrice
                           
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

        /// 02. SELECT - Lấy danh sách chi tiết con
        /// <param name="IDPart"></param>
        /// <returns></returns>
        public DataTable GetChildDAL ( int IDPart )
        {
            DataTable BangDuLieu = new DataTable();
            using (SqlConnection conn = new SqlConnection(Dataconnect))
            {
                string sql_query = @" exec GetPartChild @PartID =  @ID ";

                SqlCommand cmd = new SqlCommand(sql_query, conn);
                cmd.Parameters.AddWithValue("@ID", IDPart);

                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                conn.Open();
                adap.Fill(BangDuLieu);
            }
            return BangDuLieu;
        }

        /// 03. SELECT - Lấy danh sách chi tiết cha
        /// <param name="IDPart"></param>
        /// <returns></returns>
        public DataTable GetParentDAL ( int IDPart )
        {
            DataTable BangDuLieu = new DataTable();
            using (SqlConnection conn = new SqlConnection(Dataconnect))
            {
                //select * from tblPart where tblPart.PartID in (select tblRelation.ParentID from tblRelation where ChildID = 35 ) 
                //
                string sql_query = @"select * from tblPart where tblPart.PartID in (select tblRelation.ParentID from tblRelation where ChildID = @ID )";

                SqlCommand cmd = new SqlCommand(sql_query, conn);
                cmd.Parameters.AddWithValue("@ID", IDPart);

                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                conn.Open();
                adap.Fill(BangDuLieu);
            }
            return BangDuLieu;
        }



        /// 04. SELECT - Lấy danh sách 10, 5 part vừa được thêm gần nhất
        /// <param name="NoRow"></param>
        /// <returns></returns>
        public DataTable GetListNearDAL (int NoRow)
        {
            DataTable BangDuLieu = new DataTable();
            using (SqlConnection conn = new SqlConnection(Dataconnect))
            {
                //select top 10 PartCode, PartName, PartDescript, PartStage , PartFile from tblPart order by PartID desc 
                // TOP không thể sử dụng truyền tham số
                // thay vào đó, sử dụng phép nối chuỗi động
                string sql_query = $@"select top {NoRow} PartCode, PartName, PartDescript, PartStage , PartLog from tblPart order by PartID desc";

                SqlCommand cmd = new SqlCommand(sql_query, conn);
                cmd.Parameters.AddWithValue("@NoRow", NoRow);

                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                conn.Open();
                adap.Fill(BangDuLieu);
            }
            return BangDuLieu;
        }


        public DataTable GetBOMDAL(int IDPart)
        {
            DataTable BangDuLieu = new DataTable();
            using (SqlConnection conn = new SqlConnection(Dataconnect))
            {
                string sql_query ;
                sql_query = @"   -- Tạo bảng tạm
                                CREATE TABLE #TempTable (
                                    Levels INT,
                                    PartCode NVARCHAR(10),
                                    PartName NVARCHAR(100),
                                    Quantity INT,
                                    PartDescript NVARCHAR(MAX),
                                    PartStage NChar(2)  ,
                                    Dir  NVARCHAR(MAX) 
                                );
                                -- Chèn Dữ liệu PartID vào trước
                                INSERT INTO #TempTable (Levels, PartCode, PartName, Quantity, PartDescript, PartStage, Dir)
                                SELECT 
                                    1 , 
                                    PartCode, 
                                    PartName, 
                                    1 AS Quantity, -- Gán NULL nếu không có sẵn dữ liệu Quantity
                                    PartDescript, 
                                    PartStage ,
                                    '0' as dir
                                FROM tblPart
                                WHERE PartID = @ID;

                                INSERT INTO #TempTable
                                EXEC BOMInfor @PartID = @ID;

                                select * from #TempTable

                                drop table #TempTable
";

                SqlCommand cmd = new SqlCommand(sql_query, conn);
                cmd.Parameters.AddWithValue("@ID", IDPart);

                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                conn.Open();
                adap.Fill(BangDuLieu);
            }
            return BangDuLieu;
        }


        

    }
}
