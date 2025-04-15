using Microsoft.Data.SqlClient;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using DataTable = System.Data.DataTable;

namespace PLM_Lynx._01_DAL_Data_Access_Layer
{
    public class CommonInforDAL
    {
        private string Dataconnect = Properties.Settings.Default.Datacon;

        /// <summary>
        /// 01. SELECT - lấy thông của Company dựa trên tên công ty
        /// </summary>
        /// <param name="inforname"></param>
        /// <returns></returns>
        public tblCommonInfor GetCommonInforValue_DAL(string inforname)
        {
            tblCommonInfor _tblcommoninfor = null;

            using (SqlConnection conn = new SqlConnection(Dataconnect))
            {
                string sql_query = @"
                       select  tblCommonInfor.InforValue from tblCommonInfor where tblCommonInfor.InforName = @InforName  ";

                SqlCommand cmd = new SqlCommand(sql_query, conn);
                cmd.Parameters.AddWithValue("@InforName", inforname);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read()) // Nếu đọc được giá trị thì :
                {
                    _tblcommoninfor = new tblCommonInfor
                    {
                        InforValue = reader[0].ToString()
                    };
                }

                conn.Close();
            }

            return _tblcommoninfor;
        }

        /// <summary>
        /// 02. SELECT - Lấy danh sách các version
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllVersionInfor_DAL()
        {
            DataTable BangDuLieu = new DataTable();
            using (SqlConnection conn = new SqlConnection(Dataconnect))
            {
                string sql_query = @" select * from tblVersion ";

                SqlCommand cmd = new SqlCommand(sql_query, conn);

                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                conn.Open();
                adap.Fill(BangDuLieu);
            }
            return BangDuLieu;
        }

        /// <summary>
        /// 03. UPDATE - Cập nhật thông tin của công ty 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="location"></param>
        /// <param name="phone"></param>
        /// <param name="tax"></param>
        /// <returns></returns>
        public bool UpdateCompanyInfor_DAL(string name, string location, string phone, string tax)
        {
            using (SqlConnection con = new SqlConnection(Dataconnect))
            {
                con.Open();
                SqlTransaction transaction = con.BeginTransaction();

                try
                {
                    string sql_query = @"update tblCommonInfor set InforValue = @Name where InforName = 'CompanyName' ;
                                        update tblCommonInfor set InforValue = @Phone where InforName = 'CompanyPhoneNumber'   ;
                                        update tblCommonInfor set InforValue = @Location where InforName = 'CompanyLocation'     ;
                                        update tblCommonInfor set InforValue = @Tax where InforName = 'CompanyTaxCode' ;";

                    using (SqlCommand cmd = new SqlCommand(sql_query, con, transaction))
                    {
                        cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = name;
                        cmd.Parameters.Add("@Phone", SqlDbType.NVarChar).Value = phone;
                        cmd.Parameters.Add("@Tax", SqlDbType.NVarChar).Value = tax;
                        cmd.Parameters.Add("@Location", SqlDbType.NVarChar).Value = location;



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


        public bool InsertNewVersion_DAL(string ID, string content)
        {
            using (SqlConnection con = new SqlConnection(Dataconnect))
            {
                // Mở kết nối
                con.Open();

                // Tạo một giao dịch (Transaction) C#
                using (SqlTransaction transaction = con.BeginTransaction())
                {
                    string sql_query = @"insert tblVersion (versionID, versionContent) values (@ID, @Content) ";
                            

                    SqlCommand cmd = new SqlCommand(sql_query, con, transaction);

                    // Sử dụng Add với kiểu dữ liệu cụ thể thay vì AddWithValue
                    cmd.Parameters.Add("@ID", SqlDbType.NVarChar).Value = ID;
                    cmd.Parameters.Add("@Content", SqlDbType.NVarChar).Value = content;
                    

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
        /// 05. SELECT - Lấy thông tin tblECO dựa trên số ECO
        /// </summary>
        /// <returns></returns>
        public DataTable Get_ECO_Information_DAL(int ECONo)
        {
            DataTable BangDuLieu = new DataTable();
            using (SqlConnection conn = new SqlConnection(Dataconnect))
            {
                string sql_query = @" SELECT e.ECONo, e.ECODate, e.ECOLog, e.ECONameProposal, e.ECONameApproved, s.ECOStatus, t.ECOType, e.ECOContent , e.ECOStatusID, e.ECOTypeID
                                    FROM tblECO AS e
                                    JOIN tblECOStatus AS s ON e.ECOStatusID = s.ECOStatusID
                                    JOIN tblECOType AS t ON e.ECOTypeID = t.ECOTypeID
                                    WHERE e.ECONo = @ECONo ";
                

                SqlCommand cmd = new SqlCommand(sql_query, conn);
                cmd.Parameters.AddWithValue("@ECONo", ECONo);
                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                conn.Open();
                adap.Fill(BangDuLieu);
            }
            return BangDuLieu;
        }


    }
}