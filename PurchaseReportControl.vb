Imports System.Data.SqlClient
Imports System.Configuration

Public Class PurchaseReportControl
    Dim connectionString As String = ConfigurationManager.ConnectionStrings("VendorDB").ConnectionString
    Dim cnn As New SqlConnection(connectionString)

    Private Sub PurchaseReportControl_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadPurchases()
    End Sub

    ' 📋 Load data into GridView from Setup.Purchase
    Private Sub LoadPurchases()
        Try
            Dim dt As New DataTable()
            cnn.Open()

            Dim query As String
            Dim cmd As SqlCommand

            If SessionInfo.IsAdmin Then
                query = "SELECT * FROM Setup.Purchase"
                cmd = New SqlCommand(query, cnn)
            Else
                query = "SELECT * FROM Setup.Purchase WHERE Username = @Username"
                cmd = New SqlCommand(query, cnn)
                cmd.Parameters.AddWithValue("@Username", SessionInfo.LoggedInUsername)
            End If

            Dim reader As SqlDataReader = cmd.ExecuteReader()
            dt.Load(reader)
            cnn.Close()

            purchaseGrid.DataSource = dt
        Catch ex As Exception
            MsgBox("Error loading purchases: " & ex.Message)
            cnn.Close()
        End Try
    End Sub

    ' 📤 Export to Excel (Late Binding — No Reference Needed)
    Private Sub btnExportExcel_Click(sender As Object, e As EventArgs) Handles btnExportExcel.Click
        If purchaseGrid.Rows.Count = 0 Then
            MsgBox("No data to export.")
            Exit Sub
        End If

        Try
            Dim excelApp As Object = CreateObject("Excel.Application")
            Dim workbook As Object = excelApp.Workbooks.Add()
            Dim worksheet As Object = workbook.Sheets(1)

            ' Set column headers
            For i As Integer = 1 To purchaseGrid.Columns.Count
                worksheet.Cells(1, i).Value = purchaseGrid.Columns(i - 1).HeaderText
            Next

            ' Set data rows
            For i As Integer = 0 To purchaseGrid.Rows.Count - 1
                For j As Integer = 0 To purchaseGrid.Columns.Count - 1
                    worksheet.Cells(i + 2, j + 1).Value = purchaseGrid.Rows(i).Cells(j).Value?.ToString()
                Next
            Next

            worksheet.Columns.AutoFit()
            excelApp.Visible = True

        Catch ex As Exception
            MsgBox("Export failed: " & ex.Message)
        End Try
    End Sub
End Class
