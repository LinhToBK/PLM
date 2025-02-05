using Microsoft.Office.Core;
using System;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace PLM_Lynx._03_GUI_User_Interface._3_5_Purchase
{
    public class ExcelRunning
    {
        // Declare the variable
        public string _orderDate { get; set; }

        public string _orderPOno { get; set; }

        // Company Information
        public string _companyName { get; set; }
        public string _companyLocation { get; set; }
        public string _companyTelephone { get; set; }
        public string _companyTaxcode { get; set; }

        // Supplier Information
        public string _supplierName { get; set; }
        public string _supplierLocation { get; set; }
        public string _supplierTelephone { get; set; }
        public string _supplierTaxcode { get; set; }

        // Partlist
        public System.Data.DataTable Partlist { get; set; }
        public string _totalVND { get; set; }

        // Remark
        public string _remark { get; set; }
        public string _purchasePerson { get; set; }
        public string _paymentterms { get; set; }

        public void PurchaseTemplate_A()
        {
            // Hiển thị SaveFileDialog
            SaveFileDialog sv = new SaveFileDialog
            {
                Filter = "Excel Files|*.xlsx",
                Title = "Save an Excel File",
                FileName = "Purchase Order " + _orderPOno + ".xlsx"
            };

            if (sv.ShowDialog() == DialogResult.OK)
            {
                string filepath = sv.FileName;
                try
                {
                    // Tạo ứng dụng Excel
                    Excel.Application excelApp = new Excel.Application
                    {
                        Visible = true // Ẩn Excel trong khi xử lý
                    };
                    //Tạo Workbook và Worksheet
                    Excel.Workbook workbook = excelApp.Workbooks.Add(Type.Missing);
                    Excel.Worksheet worksheet = workbook.Sheets[1];
                    worksheet = workbook.ActiveSheet;
                    string namesheet = "PURCHASE_ORDER " + _orderPOno;
                    worksheet.Name = namesheet;

                    Excel.Range rgn;

                    // Định dạng chung
                    rgn = worksheet.Cells[1, 1];
                    rgn.Range["A1:Z300"].Font.Name = "Aptos Narrow"; //Font chữ
                    rgn.Range["A1:B3"].Font.Size = 11;
                    rgn.Range["A1:B3"].Font.Bold = false;

                    // Merge và điền thông tin vào các ô

                    // 1/ Order date
                    rgn.Range["A2:C2"].MergeCells = true;
                    rgn.Range["A2:C2"].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    rgn.Range["A2:C2"].Value = "Order Date : " + _orderDate;

                    // 2) PURCHASE ORDER
                    rgn.Range["E2:J3"].MergeCells = true;
                    rgn.Range["E2:J3"].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    rgn.Range["E2:J3"].VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    rgn.Range["E2:J3"].Font.Size = 22;
                    rgn.Range["E2:J3"].Font.Bold = true;
                    rgn.Range["E2:J3"].Font.ColorIndex = 3; // red

                    rgn.Range["E2:J3"].Value = "PURCHASE ORDER";

                    // 3) Insert Image
                    rgn.Range["L1:M3"].MergeCells = true;
                    rgn.Range["L1:M3"].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                    string ImageCompanyPath = Properties.Settings.Default.ABCCoLtd;

                    if (System.IO.File.Exists(ImageCompanyPath))
                    {
                        // Lấy tọa độ của ô
                        float cellLeft = (float)rgn.Range["L1:M3"].Left;   // Vị trí từ lề trái
                        float cellTop = (float)rgn.Range["L1:M3"].Top;     // Vị trí từ lề trên
                        float cellWidth = (float)rgn.Range["L1:M3"].Width; // Chiều rộng ô
                        float cellHeight = (float)rgn.Range["L1:M3"].Height; // Chiều cao ô

                        // Chèn ảnh vào vị trí ô
                        var picture = worksheet.Shapes.AddPicture(
                            ImageCompanyPath,
                            LinkToFile: MsoTriState.msoFalse,
                            SaveWithDocument: MsoTriState.msoTrue,
                            Left: cellLeft,  // Vị trí lề trái của ô
                            Top: cellTop,    // Vị trí lề trên của ô
                            Width: cellWidth,  // Đặt chiều rộng khớp với ô
                            Height: cellHeight // Đặt chiều cao khớp với ô
                        );
                    }
                    else
                    {
                        rgn.Range["L1:M3"].Value = "Không tìm thấy ảnh";
                    }

                    //-----------------------------------------
                    // =====> Fill Information of Company
                    //-----------------------------------------
                    // 4) Company Name 
                    rgn.Range["A5:E5"].MergeCells = true;
                    rgn.Range["A5:E5"].HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                    rgn.Range["A5:E5"].VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    rgn.Range["A5:E5"].Value = _companyName;
                    rgn.Range["A5:E5"].Font.Bold = true;
                    rgn.Range["A5:E5"].BorderAround2(Excel.XlLineStyle.xlContinuous);


                    // 5) Company Location 
                    rgn.Range["A6:E6"].MergeCells = true;
                    rgn.Range["A6:E6"].HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                    rgn.Range["A6:E6"].VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    rgn.Range["A6:E6"].Value = _companyLocation;
                    


                    // 6) Company Telephone
                    rgn.Range["A8:E8"].MergeCells = true;
                    rgn.Range["A8:E8"].HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                    rgn.Range["A8:E8"].VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    rgn.Range["A8:E8"].Value = @"Tel : " + _companyTelephone;

                    // 7) Company Tax Code
                    rgn.Range["A9:E9"].MergeCells = true;
                    rgn.Range["A9:E9"].HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                    rgn.Range["A9:E9"].VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    rgn.Range["A9:E9"].Value = _companyTaxcode;


                    //-----------------------------------------
                    //=====> Fill Information of Supplier =====
                    //-----------------------------------------
                    // 8) Supplier -> Name 
                    rgn.Range["F5:J5"].MergeCells = true;
                    rgn.Range["F5:J5"].HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                    rgn.Range["F5:J5"].VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    rgn.Range["F5:J5"].Value = _supplierName;
                    rgn.Range["F5:J5"].Font.Bold = true;
                    rgn.Range["F5:J5"].BorderAround2 (Excel.XlLineStyle.xlContinuous);



                    // 9) Supplier=> Location 
                    rgn.Range["F6:J6"].MergeCells = true;
                    rgn.Range["F6:J6"].HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                    rgn.Range["F6:J6"].VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    rgn.Range["F6:J6"].Value = _supplierLocation;


                    // 10) Supplier > Telephone
                    rgn.Range["F8:J8"].MergeCells = true;
                    rgn.Range["F8:J8"].HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                    rgn.Range["F8:J8"].VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    rgn.Range["F8:J8"].Value = @"Tel : " + _supplierTelephone;

                    // 11) Supplier =>Tax Code
                    rgn.Range["F9:J9"].MergeCells = true;
                    rgn.Range["F9:J9"].HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                    rgn.Range["F9:J9"].VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    rgn.Range["F9:J9"].Value = _supplierTaxcode;


                    //-----------------------------------------
                    //=====> Fill  Shipping
                    //-----------------------------------------
                    // SHIP TO / BILL TO
                    rgn.Range["K5:N5"].MergeCells = true;
                    rgn.Range["K5:N5"].HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                    rgn.Range["K5:N5"].VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    rgn.Range["K5:N5"].Value = @"SHIP TO / BILL TO";
                    rgn.Range["K5:N5"].Font.Bold = true;


                    // => To company
                    rgn.Range["K6:N6"].MergeCells = true;
                    rgn.Range["K6:N6"].HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                    rgn.Range["K6:N6"].VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    rgn.Range["K6:N6"].Value = _companyName;


                    // => to Location
                    rgn.Range["K7:N7"].MergeCells = true;
                    rgn.Range["K7:N7"].HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                    rgn.Range["K7:N7"].VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    rgn.Range["K7:N7"].Value = @"Tel : " + _companyLocation;

                    // 15) to Telephone
                    rgn.Range["K8:N8"].MergeCells = true;
                    rgn.Range["K8:N8"].HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                    rgn.Range["K8:N8"].VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    rgn.Range["K8:N8"].Value = _companyTelephone;


                    //-----------------------------------------
                    //=====> Fill  Term
                    //-----------------------------------------
                    
                    var chooserange = rgn.Range["A11:A12"];

                    // Purchase Order
                    chooserange.MergeCells = true;
                    chooserange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    chooserange.VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    chooserange.Value = "Purchase \n Order";
                    // Fill PO Number
                    chooserange = rgn.Range["B11:D12"];
                    chooserange.MergeCells = true;
                    chooserange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    chooserange.VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    chooserange.Value = _orderPOno.Replace("_" ,"/");
                    // Payment Terms
                    chooserange = rgn.Range["E11:E12"];
                    chooserange.MergeCells = true;
                    chooserange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    chooserange.VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    chooserange.Value = "Payment \n Terms";
                    // Fill Payment Terms
                    chooserange = rgn.Range["F11:N12"];
                    chooserange.MergeCells = true;
                    chooserange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    chooserange.VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    chooserange.Value = _paymentterms ;


                    // Fill Partlist







                    //  =========>  Lưu file Excel
                    workbook.SaveAs(filepath);
                    workbook.Close();
                    excelApp.Quit();

                    MessageBox.Show("Đã lưu PO thành công ");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            //try
            //{
            //    // Tạo ứng dụng Excel
            //    Excel.Application excelApp = new Excel.Application
            //    {
            //        Visible = true // Ẩn Excel trong khi xử lý
            //    };

            //    // Tạo Workbook và Worksheet
            //    Excel.Workbook workbook = excelApp.Workbooks.Add(Type.Missing);
            //    Excel.Worksheet worksheet = workbook.Sheets[1];
            //    worksheet = workbook.ActiveSheet;
            //    worksheet.Name = "ExportedWithChild";

            //    // Ghi tiêu đề cột
            //    for (int i = 1; i <= dgv.Columns.Count; i++)
            //    {
            //        worksheet.Cells[1, i] = dgv.Columns[i - 1].HeaderText;
            //    }

            //    // Ghi dữ liệu từ DataGridView
            //    for (int i = 0; i < dgv.Rows.Count; i++)
            //    {
            //        for (int j = 0; j < dgv.Columns.Count; j++)
            //        {
            //            worksheet.Cells[i + 2, j + 1] = dgv.Rows[i].Cells[j].Value?.ToString();
            //        }
            //    }

            //    // Lưu file Excel
            //    workbook.SaveAs(filePath);
            //    workbook.Close();
            //    excelApp.Quit();

            //    MessageBox.Show("Xuất Dữ Liệu Thành Công !", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }
    }
}