using Microsoft.Office.Core;
using Microsoft.Office.Interop.Excel;
using PLM_Lynx._01_DAL_Data_Access_Layer;
using PLM_Lynx._02_BLL_Bussiness_Logic_Layer;
using System;
using System.Security.Cryptography;
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
                    rgn.Range["E2:J3"].VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    rgn.Range["E2:J3"].Font.Size = 22;
                    rgn.Range["E2:J3"].Font.Bold = true;
                    rgn.Range["E2:J3"].Font.ColorIndex = 3; // red

                    rgn.Range["E2:J3"].Value = "PURCHASE ORDER";

                    // 3) Insert Image
                    rgn.Range["L1:M3"].MergeCells = true;
                    rgn.Range["L1:M3"].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                    //string ImageCompanyPath = Properties.Settings.Default.ABCCoLtd;
                    string ImageCompanyPath = Environment.CurrentDirectory;
                    ImageCompanyPath = ImageCompanyPath + @"\04_CommonDoc\ABCCoLtd.jpg";
                    //MessageBox.Show(ImageCompanyPath);

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
                        rgn.Range["L1:M3"].Value = "Không tìm thấy logo công ty ";
                    }

                    //-----------------------------------------
                    // =====> Fill Information of Company
                    //-----------------------------------------
                    // 4) Company Name
                    rgn.Range["A5:E5"].MergeCells = true;
                    rgn.Range["A5:E5"].Value = _companyName;
                    rgn.Range["A5:E5"].Font.Bold = true;
                    rgn.Range["A5:E5"].HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                    rgn.Range["A5:E5"].VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    rgn.Range["A5:E5"].BorderAround2(Excel.XlLineStyle.xlContinuous);

                    // 5) Company Location
                    rgn.Range["A6:E7"].MergeCells = true;
                    rgn.Range["A6:E7"].Value = _companyLocation;
                    rgn.Range["A6:E7"].HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                    rgn.Range["A6:E7"].VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    rgn.Range["A6:E7"].BorderAround2(Excel.XlLineStyle.xlContinuous);

                    // 6) Company Telephone
                    rgn.Range["A8:E8"].MergeCells = true;
                    rgn.Range["A8:E8"].Value = @"Tel : " + _companyTelephone;
                    rgn.Range["A8:E8"].HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                    rgn.Range["A8:E8"].VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    rgn.Range["A8:E8"].BorderAround2(Excel.XlLineStyle.xlContinuous);

                    // 7) Company Tax Code
                    rgn.Range["A9:E9"].MergeCells = true;
                    rgn.Range["A9:E9"].Value = _companyTaxcode;
                    rgn.Range["A9:E9"].HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                    rgn.Range["A9:E9"].VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    rgn.Range["A9:E9"].BorderAround2(Excel.XlLineStyle.xlContinuous);

                    //-----------------------------------------
                    //=====> Fill Information of Supplier =====
                    //-----------------------------------------
                    // 8) Supplier -> Name
                    rgn.Range["F5:J5"].MergeCells = true;
                    rgn.Range["F5:J5"].HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                    rgn.Range["F5:J5"].VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    rgn.Range["F5:J5"].Value = _supplierName;
                    rgn.Range["F5:J5"].Font.Bold = true;
                    rgn.Range["F5:J5"].BorderAround2(Excel.XlLineStyle.xlContinuous);

                    // 9) Supplier=> Location
                    rgn.Range["F6:J7"].MergeCells = true;
                    rgn.Range["F6:J7"].BorderAround2(Excel.XlLineStyle.xlContinuous);
                    rgn.Range["F6:J7"].HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                    rgn.Range["F6:J7"].VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    rgn.Range["F6:J7"].Value = _supplierLocation;

                    // 10) Supplier > Telephone
                    rgn.Range["F8:J8"].MergeCells = true;
                    rgn.Range["F8:J8"].BorderAround2(Excel.XlLineStyle.xlContinuous);
                    rgn.Range["F8:J8"].HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                    rgn.Range["F8:J8"].VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    rgn.Range["F8:J8"].Value = @"Tel : " + _supplierTelephone;

                    // 11) Supplier =>Tax Code
                    rgn.Range["F9:J9"].MergeCells = true;
                    rgn.Range["F9:J9"].BorderAround2(Excel.XlLineStyle.xlContinuous);
                    rgn.Range["F9:J9"].HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                    rgn.Range["F9:J9"].VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    rgn.Range["F9:J9"].Value = _supplierTaxcode;

                    //-----------------------------------------
                    //=====> Fill  Shipping
                    //-----------------------------------------
                    // SHIP TO / BILL TO
                    rgn.Range["K5:N5"].MergeCells = true;
                    rgn.Range["K5:N5"].Font.Bold= true;
                    rgn.Range["K5:N5"].HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                    rgn.Range["K5:N5"].VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    rgn.Range["K5:N5"].Value = @"SHIP TO / BILL TO : " + _companyName;
                    rgn.Range["K5:N5"].BorderAround2(Excel.XlLineStyle.xlContinuous);

                    // => to Location
                    rgn.Range["K6:N7"].MergeCells = true;
                    rgn.Range["K6:N7"].BorderAround2(Excel.XlLineStyle.xlContinuous);
                    rgn.Range["K6:N7"].HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                    rgn.Range["K6:N7"].VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    rgn.Range["K6:N7"].Value = _companyLocation;

                    // 15) to Telephone
                    rgn.Range["K8:N8"].MergeCells = true;
                    rgn.Range["K8:N8"].BorderAround2(Excel.XlLineStyle.xlContinuous);
                    rgn.Range["K8:N8"].HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                    rgn.Range["K8:N8"].VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    rgn.Range["K8:N8"].Value = @"Tel : " + _companyTelephone;
                    rgn.Range["K9:N9"].MergeCells = true;
                    rgn.Range["K9:N9"].BorderAround2(Excel.XlLineStyle.xlContinuous);

                    //-----------------------------------------
                    //=====> Fill  Term
                    //-----------------------------------------

                    var chooserange = rgn.Range["A11:A12"];

                    // Purchase Order
                    chooserange.MergeCells = true;
                    chooserange.BorderAround2(Excel.XlLineStyle.xlContinuous);
                    chooserange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    chooserange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    chooserange.Value = "Purchase \n Order";
                    chooserange.Interior.ColorIndex = 4;

                    // Fill PO Number
                    chooserange = rgn.Range["B11:D12"];
                    chooserange.MergeCells = true;
                    chooserange.BorderAround2(Excel.XlLineStyle.xlContinuous);
                    chooserange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    chooserange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    chooserange.Value = _orderPOno.Replace("_", "/");
                    // Payment Terms
                    chooserange = rgn.Range["E11:E12"];
                    chooserange.MergeCells = true;
                    chooserange.ColumnWidth = 11;
                    chooserange.BorderAround2(Excel.XlLineStyle.xlContinuous);
                    chooserange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    chooserange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    chooserange.Value = "Payment \n Terms";
                    chooserange.Interior.ColorIndex = 4;
                    // Fill Payment Terms
                    chooserange = rgn.Range["F11:N12"];
                    chooserange.MergeCells = true;
                    
                    chooserange.BorderAround2(Excel.XlLineStyle.xlContinuous);
                    chooserange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    chooserange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    chooserange.Value = _paymentterms;
                    chooserange.WrapText = true;
                    chooserange.Rows.AutoFit();
                    chooserange.RowHeight = 30;



                    //  *****  Fill Partlist   *****

                    //   STT |  Part Number  | Part Name | Quantity | Unit Price | Discount | Unit | Amount

                    // Edit size of Cell
                    // => 01. STT
                    chooserange = rgn.Range["A14:A14"];
                    chooserange.ColumnWidth = 11;
                    chooserange.RowHeight = 15;
                    chooserange.Value = "STT";
                    chooserange.BorderAround2(Excel.XlLineStyle.xlContinuous);

                    // => 02. Part Number
                    chooserange = rgn.Range["B14:C14"];
                    chooserange.MergeCells = true;
                    chooserange.ColumnWidth = 8;
                    chooserange.Value = "Part Code";
                    chooserange.BorderAround2(Excel.XlLineStyle.xlContinuous);

                    // => 03. Part Name
                    chooserange = rgn.Range["D14:G14"];
                    chooserange.MergeCells = true;
                    chooserange.ColumnWidth = 8;
                    chooserange.Value = "Part Name";
                    chooserange.BorderAround2(Excel.XlLineStyle.xlContinuous);

                    // => 04. Quantity
                    chooserange = rgn.Range["H14:H14"];
                    chooserange.MergeCells = true;
                    chooserange.ColumnWidth = 8;
                    chooserange.Value = "Quantity";
                    chooserange.BorderAround2(Excel.XlLineStyle.xlContinuous);

                    // => 05. Unit Price
                    chooserange = rgn.Range["I14:J14"];
                    chooserange.MergeCells = true;
                    chooserange.ColumnWidth = 8;
                    chooserange.Value = "Unit Price";
                    chooserange.BorderAround2(Excel.XlLineStyle.xlContinuous);

                    // => 06. Discount
                    chooserange = rgn.Range["K14:K14"];
                    chooserange.MergeCells = true;
                    chooserange.ColumnWidth = 10;
                    chooserange.Value = "Discount";
                    chooserange.BorderAround2(Excel.XlLineStyle.xlContinuous);

                    // => 07. Unit
                    chooserange = rgn.Range["L14:L14"];
                    chooserange.MergeCells = true;
                    chooserange.ColumnWidth = 7;
                    chooserange.Value = "Unit";
                    chooserange.BorderAround2(Excel.XlLineStyle.xlContinuous);
                    // => 08. Amount
                    chooserange = rgn.Range["M14:N14"];
                    chooserange.MergeCells = true;
                    chooserange.ColumnWidth = 10;
                    chooserange.Value = "Amount";
                    chooserange.BorderAround2(Excel.XlLineStyle.xlContinuous);

                    // -Center Position of Text

                    rgn.Range["A14:N14"].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    rgn.Range["A14:N14"].VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                    rgn.Range["A14:N14"].Interior.ColorIndex = 7;
                    

                    // => Add Item in Partlist to Excel
                    int beginrow = 15;
                    int rowpartlist ;
                    

                    for (rowpartlist = 0; rowpartlist < Partlist.Rows.Count; rowpartlist++)
                    {
                        
                        // 00. STT
                        chooserange = rgn.Range[worksheet.Cells[1][beginrow + rowpartlist], worksheet.Cells[1][beginrow + rowpartlist]];
                        //chooserange.MergeCells = true;
                        chooserange.Value = rowpartlist + 1;
                        chooserange.BorderAround2(Excel.XlLineStyle.xlContinuous);
                        chooserange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        chooserange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                        chooserange.RowHeight = 25;

                        // Part Code | Part Name | Quantity | Unit Price | Discount | Amount
                        // 0         | 1         | 2        |     3      |     4    |    5 
                        //------------------------------------------------------------------
                        // 01. Part Code
                        chooserange = rgn.Range[worksheet.Cells[2][beginrow + rowpartlist], worksheet.Cells[3][beginrow + rowpartlist]];
                        chooserange.MergeCells = true;
                        chooserange.Value = Partlist.Rows[rowpartlist][0].ToString(); 
                        chooserange.BorderAround2(Excel.XlLineStyle.xlContinuous);
                        chooserange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        chooserange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                        // 02. Part Name
                        chooserange = rgn.Range[worksheet.Cells[4][beginrow + rowpartlist], worksheet.Cells[7][beginrow + rowpartlist]];
                        chooserange.MergeCells = true;
                        chooserange.Value = Partlist.Rows[rowpartlist][1].ToString();
                        chooserange.BorderAround2(Excel.XlLineStyle.xlContinuous);
                        chooserange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        chooserange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                        // 03. Quantity
                        chooserange = rgn.Range[worksheet.Cells[8][beginrow + rowpartlist], worksheet.Cells[8][beginrow + rowpartlist]];
                        chooserange.MergeCells = true;
                        chooserange.Value = Partlist.Rows[rowpartlist][2].ToString();
                        chooserange.BorderAround2(Excel.XlLineStyle.xlContinuous);
                        chooserange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        chooserange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                        // 03. Unit Price
                        chooserange = rgn.Range[worksheet.Cells[9][beginrow + rowpartlist], worksheet.Cells[10][beginrow + rowpartlist]];
                        chooserange.MergeCells = true;
                        chooserange.Value = Partlist.Rows[rowpartlist][3].ToString();
                        chooserange.NumberFormat = "#,##0";
                        chooserange.BorderAround2(Excel.XlLineStyle.xlContinuous);
                        chooserange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        chooserange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                        // 04. Discount
                        chooserange = rgn.Range[worksheet.Cells[11][beginrow + rowpartlist], worksheet.Cells[11][beginrow + rowpartlist]];
                        chooserange.MergeCells = true;
                        chooserange.Value = Partlist.Rows[rowpartlist][4].ToString();
                        chooserange.BorderAround2(Excel.XlLineStyle.xlContinuous);
                        chooserange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        chooserange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                        // 05. Unit
                        chooserange = rgn.Range[worksheet.Cells[12][beginrow + rowpartlist], worksheet.Cells[12][beginrow + rowpartlist]];
                        chooserange.MergeCells = true;
                        chooserange.Value = "pcs";
                        chooserange.BorderAround2(Excel.XlLineStyle.xlContinuous);
                        chooserange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        chooserange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                        // 06. Amount
                        chooserange = rgn.Range[worksheet.Cells[13][beginrow + rowpartlist], worksheet.Cells[14][beginrow + rowpartlist]];
                        chooserange.MergeCells = true;
                        chooserange.Value = Partlist.Rows[rowpartlist][5].ToString();
                        chooserange.NumberFormat = "#,##0";
                        chooserange.BorderAround2(Excel.XlLineStyle.xlContinuous);
                        chooserange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        chooserange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    }

                    rowpartlist = Partlist.Rows.Count;
                    int rowend = rowpartlist + beginrow + 1;


                    // Total 
                    chooserange = rgn.Range[worksheet.Cells[1][rowend], worksheet.Cells[12][rowend + 1]];
                    chooserange.MergeCells = true;
                    chooserange.Value = "ToTal";
                    chooserange.Interior.ColorIndex = 6;
                    chooserange.BorderAround2(Excel.XlLineStyle.xlContinuous);
                    chooserange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    chooserange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    // -- Total Summary
                    chooserange = rgn.Range[worksheet.Cells[13][rowend], worksheet.Cells[14][rowend + 1]];
                    chooserange.MergeCells = true;
                    chooserange.Value =_totalVND;
                    chooserange.NumberFormat = "#,##0";
                    chooserange.BorderAround2(Excel.XlLineStyle.xlContinuous);
                    chooserange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    chooserange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    chooserange.Interior.ColorIndex = 8;
                    chooserange.Value = _totalVND.ToString() + " VND";


                    // -- Remark 
                    rowend = rowend + 3;
                    chooserange = rgn.Range[worksheet.Cells[1][rowend], worksheet.Cells[7][rowend]];
                    chooserange.MergeCells = true;
                    chooserange.Value = "Remark";
                    chooserange.BorderAround2(Excel.XlLineStyle.xlContinuous);
                    chooserange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    chooserange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    // -- Buyer 

                    chooserange = rgn.Range[worksheet.Cells[8][rowend], worksheet.Cells[14][rowend]];
                    chooserange.MergeCells = true;
                    chooserange.Value = "Buyer";
                    chooserange.BorderAround2(Excel.XlLineStyle.xlContinuous);
                    chooserange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    chooserange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                    // -- Remark -Summary
                    rowend = rowend + 1;
                    chooserange = rgn.Range[worksheet.Cells[1][rowend], worksheet.Cells[7][rowend+4]];
                    chooserange.MergeCells = true;
                    chooserange.Value = _remark;
                    chooserange.BorderAround2(Excel.XlLineStyle.xlContinuous);
                    chooserange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    chooserange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    // -- Tel
                    chooserange = rgn.Range[worksheet.Cells[8][rowend], worksheet.Cells[9][rowend + 1]];
                    chooserange.MergeCells = true;
                    chooserange.Value = "Created By";
                    chooserange.BorderAround2(Excel.XlLineStyle.xlContinuous);
                    chooserange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    chooserange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    // -- Name of Buyer
                    chooserange = rgn.Range[worksheet.Cells[10][rowend], worksheet.Cells[14][rowend + 1]];
                    chooserange.MergeCells = true;
                    chooserange.Value = _purchasePerson ;
                    chooserange.BorderAround2(Excel.XlLineStyle.xlContinuous);
                    chooserange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    chooserange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    // -- Approved
                    rowend = rowend + 2;
                    chooserange = rgn.Range[worksheet.Cells[8][rowend], worksheet.Cells[9][rowend + 2]];
                    chooserange.MergeCells = true;
                    chooserange.Value = "Approved By";
                    chooserange.BorderAround2(Excel.XlLineStyle.xlContinuous);
                    chooserange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    chooserange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    //---
                    chooserange = rgn.Range[worksheet.Cells[10][rowend], worksheet.Cells[14][rowend + 2]];
                    chooserange.MergeCells = true;
                    chooserange.BorderAround2(Excel.XlLineStyle.xlContinuous);

                    // -- Company and Supplier Signed
                    rowend = rowend + 4;
                    chooserange = rgn.Range[worksheet.Cells[2][rowend], worksheet.Cells[5][rowend]];
                    chooserange.MergeCells = true;
                    chooserange.Value = "Order By";
                    chooserange.Font.Bold  = true;
                    // --
                    chooserange = rgn.Range[worksheet.Cells[8][rowend], worksheet.Cells[11][rowend]];
                    chooserange.MergeCells = true;
                    chooserange.Value = "Confirmed By";
                    chooserange.Font.Bold= true;
                    // --
                    rowend = rowend + 1;
                    chooserange = rgn.Range[worksheet.Cells[2][rowend], worksheet.Cells[5][rowend]];
                    chooserange.MergeCells = true;
                    chooserange.Value = _companyName;
                    // --
                    chooserange = rgn.Range[worksheet.Cells[8][rowend], worksheet.Cells[11][rowend]];
                    chooserange.MergeCells = true;
                    chooserange.Value = _supplierName;
                    // --
                    rowend = rowend + 1;
                    chooserange = rgn.Range[worksheet.Cells[2][rowend], worksheet.Cells[5][rowend]];
                    chooserange.MergeCells = true;
                    chooserange.Value = "Authorized Signature";
                    chooserange.Font.Bold = true;
                    // --
                    chooserange = rgn.Range[worksheet.Cells[8][rowend], worksheet.Cells[11][rowend]];
                    chooserange.MergeCells = true;
                    chooserange.Value = "Authorized Signature";
                    chooserange.Font.Bold = true;


                    // Set up Page Printer
                    rowend = rowend + 2;
                    
                    //worksheet.PageSetup.PrintArea = rgn.Range[worksheet.Cells[1][1], worksheet.Cells[14][rowend]];
                    worksheet.PageSetup.Zoom = false; // Tắt chế độ phóng to / thu nhỏ mặc định
                    worksheet.PageSetup.FitToPagesWide = 1; // Fit nội dung theo chiều rộng
                    worksheet.PageSetup.FitToPagesTall = false; // Không giới hạn chiều cao

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

           
        }
    }
}