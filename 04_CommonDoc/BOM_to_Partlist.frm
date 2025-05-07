VERSION 5.00
Begin {C62A69F0-16DC-11CE-9E98-00AA00574A4F} UserForm2 
   Caption         =   "UserForm2"
   ClientHeight    =   4500
   ClientLeft      =   120
   ClientTop       =   465
   ClientWidth     =   8955.001
   OleObjectBlob   =   "BOM_to_Partlist.frx":0000
   StartUpPosition =   1  'CenterOwner
End
Attribute VB_Name = "UserForm2"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False

Option Explicit
'=====================================================
'Copyright (c) Mechanic Team - RD Filter VACE. All rights reserved.
''' <Summary> '''
'Name program : CONVERT BOM TO PARLIST - IN EXCEL
' P.I.C : TO VAN LINH - MECHANIC MEMBER
' PHONE NUMBER : +84333568236

' CONTENT REVISION
'   REVISION 0 : 5/5/2023
'   BEGIN....
'=====================================================
Private Sub btn_Run_now_Click()

    ' ======== Step 0 : Original setup ============
        Application.DisplayAlerts = False
        Application.ScreenUpdating = False
        Application.EnableEvents = False
        Application.Calculation = xlCalculationManual
    '
    
    ' ======== Step 1 : Copy_data to new file====== ( Back up file _)
        ' -----Step 1.1 Creat variable -----
        Dim sheetmoi As Worksheet
        Dim Row_end As Integer
        Dim current_sheet As Worksheet
        
        Set current_sheet = ActiveSheet
        
        ' ----- 1.2 Creat new sheet like " sheetmoi -----
        Set sheetmoi = Worksheets.Add
        sheetmoi.Name = "BOM to Parlist - Convert"
        
        '----- 1.3 Get row_end------
        Row_end = current_sheet.UsedRange.Rows(current_sheet.UsedRange.Rows.Count).Row
        'MsgBox ("Dong cuoi cung la : " & Row_end)

        ' -----1.4 Copy tu sheet hientai sang sheetmoi
        current_sheet.Select
            Range(Cells(1, 1), Cells(Row_end, 10)).Copy Destination:=sheetmoi.Cells(1, 1)
            'MsgBox ("Copy xong roi nhe ")
        
    ' ======= Step 2 : Handle data on "sheet moi" =====
        Dim Row_begin  As Integer
        Dim Col_quantity As Integer
        Dim Col_Parlist As Integer
        Dim i_count As Integer
        Dim check_mother As Integer
        Row_begin = CInt(tbx_level_row.Value) + 1
        Col_quantity = CInt(tbx_Quantity_Col.Value)
        Col_Parlist = Col_quantity + 1
        sheetmoi.Select
            Cells(Row_begin - 1, Col_Parlist) = "Quantity on Partlist"
            Cells(Row_begin, Col_quantity) = 1
            Cells(Row_begin, Col_Parlist) = 1
            For i_count = Row_begin + 1 To Row_end
                ' Kiem tra xem mother la vi tri nao
                check_mother = 1
                Do Until (Cells(i_count, 1) - Cells(i_count - check_mother, 1) = 1)
                    check_mother = check_mother + 1
                Loop
                Cells(i_count, Col_Parlist) = Cells(i_count, Col_quantity) * Cells(i_count - check_mother, Col_Parlist)
            Next i_count
            MsgBox ("Done")
    
End Sub

Private Sub Image1_Click()

End Sub
