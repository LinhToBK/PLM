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
        public bool XoaRelationDAL(string parentcode, string childcode)
        {
            using (SqlConnection con = new SqlConnection(Dataconnect))
            {

                string sql_query;
                sql_query = @"delete tblRelation 
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
                string sql_query = @" select * from tblPart where PartCode = @PartCode";
                                    

                SqlCommand cmd = new SqlCommand(sql_query, conn);
                cmd.Parameters.AddWithValue("@PartCode", PartCode);

                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                conn.Open();
                adap.Fill(BangDuLieu);
            }
            return BangDuLieu;
        }


        /// <summary>
        /// 06. Cập nhật thông tin của 1 Part : Bao gồm Part Name, PartDescription, Part Stage, Part Log
        /// </summary>
        /// <param name="parentcode"></param>
        /// <param name="childcode"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public bool CapnhatInforPartDAL(string partcode, string partname, string partdescipt, string partstage, string statuspartstage)
        {
            using (SqlConnection con = new SqlConnection(Dataconnect))
            {
                //-------------------------
                string sql_query;
                sql_query = @"
                                update tblPart
                        set PartLog =CONCAT(FORMAT(GETDATE(), 'MM-dd-yyyy HH:mm'), ' Update Infor :  ', @StatusStage , CHAR(13), CHAR(10), '|', PartLog) ,
	                    PartName = @PartName ,
	                    PartDescript = @PartDescript ,
	                    PartStage = @PartStage 
                        where PartCode = @PartCode
                    ";
                SqlCommand cmd = new SqlCommand(sql_query, con);
                cmd.Parameters.Add("@StatusStage", SqlDbType.NVarChar).Value = statuspartstage;
                cmd.Parameters.Add("@PartName", SqlDbType.NVarChar).Value = partname;
                cmd.Parameters.Add("@PartDescript", SqlDbType.NVarChar).Value = partdescipt;
                cmd.Parameters.Add("@PartStage", SqlDbType.NChar).Value = partstage;
                cmd.Parameters.Add("@PartCode", SqlDbType.NVarChar).Value = partcode;



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
