Imports System.Configuration
Imports System.Data.SqlClient

Public Class DashboardForm

    ' 🔄 Generic method to load any user control into the content panel
    Private Sub LoadControl(control As UserControl)
        contentPanel.Controls.Clear()
        control.Dock = DockStyle.Fill
        contentPanel.Controls.Add(control)
    End Sub

    ' 🚀 Dashboard Load
    Private Sub DashboardForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Only show User Management button if admin
        btnUserManagement.Visible = SessionInfo.IsAdmin

        ' Don't load any control by default
        contentPanel.Controls.Clear()
    End Sub

    ' 📦 Vendor Button Click
    Private Sub btnVendor_Click(sender As Object, e As EventArgs) Handles btnVendor.Click
        LoadControl(New VendorControl())
    End Sub

    ' 👤 Customer Button Click
    Private Sub btnCustomer_Click(sender As Object, e As EventArgs) Handles btnCustomer.Click
        LoadControl(New CustomerControl())
    End Sub

    ' 🛒 Purchase Button Click
    Private Sub btnPurchase_Click(sender As Object, e As EventArgs) Handles btnPurchase.Click
        LoadControl(New PurchaseControl())
    End Sub

    ' 📤 Purchase Report
    Private Sub btnPurchaseReport_Click(sender As Object, e As EventArgs) Handles btnPurchaseReport.Click
        LoadControl(New PurchaseReportControl())
    End Sub

    ' 🔄 Stock Transfer
    Private Sub btnStockTransfer_Click(sender As Object, e As EventArgs) Handles btnStockTransfer.Click
        LoadControl(New StockTransferControl())
    End Sub

    ' 👥 User Management (Admin Only)

    Private Sub btnUserManagement_Click(sender As Object, e As EventArgs) Handles btnUserManagement.Click
        LoadControl(New UserManagementControl())
    End Sub

    ' 🔐 Backup Button
    Private Sub btnBackup_Click(sender As Object, e As EventArgs) Handles btnBackup.Click
        BackupUserData()
    End Sub

    ' ⏏ Backup Logic (Admin gets .bak, users get Excel)
    Private Sub BackupUserData()
        Try
            Dim connectionString As String = ConfigurationManager.ConnectionStrings("VendorDB").ConnectionString

            If SessionInfo.IsAdmin Then
                ' 🔐 Admin: Full .bak backup
                Using cnn As New SqlConnection(connectionString)
                    Dim saveDialog As New SaveFileDialog()
                    saveDialog.Filter = "Backup Files|*.bak"
                    saveDialog.Title = "Save Full Database Backup (.bak)"
                    saveDialog.FileName = "VendorDB_Backup_" & DateTime.Now.ToString("yyyyMMdd_HHmmss") & ".bak"

                    If saveDialog.ShowDialog() = DialogResult.OK Then
                        Dim backupFilePath As String = saveDialog.FileName
                        Dim backupQuery As String = "BACKUP DATABASE VendorDB TO DISK = @path"

                        cnn.Open()
                        Using cmd As New SqlCommand(backupQuery, cnn)
                            cmd.Parameters.AddWithValue("@path", backupFilePath)
                            cmd.ExecuteNonQuery()
                        End Using
                        cnn.Close()

                        MsgBox("✅ Full backup (.bak) completed successfully!", MsgBoxStyle.Information)
                    End If
                End Using

            Else
                ' 👤 Normal user: Export only their data to Excel
                Using cnn As New SqlConnection(connectionString)
                    Dim dt As New DataTable()
                    Dim username As String = SessionInfo.LoggedInUsername

                    ' 👇 All SELECTs must return same number of columns (9)
                    Dim query As String = "
                    SELECT 'Vendor' AS TableName, 
                           CAST(ID AS NVARCHAR) AS ID, 
                           VendorName AS Col1, 
                           Address AS Col2, 
                           Email AS Col3, 
                           PhoneNumber AS Col4, 
                           NULL AS Col5, 
                           NULL AS Col6, 
                           Username
                    FROM Setup.Vendor WHERE Username = @Username

                    UNION ALL

                    SELECT 'Customer' AS TableName, 
                           CAST(ID AS NVARCHAR) AS ID, 
                           CustomerName AS Col1, 
                           Address AS Col2, 
                           Email AS Col3, 
                           PhoneNumber AS Col4, 
                           NULL AS Col5, 
                           NULL AS Col6, 
                           Username
                    FROM Setup.Customer WHERE Username = @Username

                    UNION ALL

                    SELECT 'Purchase' AS TableName, 
                           CAST(PurchaseID AS NVARCHAR) AS ID, 
                           VendorName AS Col1, 
                           Item AS Col2, 
                           CAST(Amount AS NVARCHAR) AS Col3, 
                           FORMAT(PurchaseDate, 'yyyy-MM-dd') AS Col4, 
                           CAST(Quantity AS NVARCHAR) AS Col5, 
                           Warehouse AS Col6, 
                           Username
                    FROM Setup.Purchase WHERE Username = @Username
                "

                    Using cmd As New SqlCommand(query, cnn)
                        cmd.Parameters.AddWithValue("@Username", username)
                        cnn.Open()
                        Dim reader As SqlDataReader = cmd.ExecuteReader()
                        dt.Load(reader)
                    End Using

                    Dim sfd As New SaveFileDialog()
                    sfd.Filter = "Excel File|*.xls"
                    sfd.FileName = "UserDataBackup_" & username & "_" & DateTime.Now.ToString("yyyyMMdd_HHmmss") & ".xls"

                    If sfd.ShowDialog() = DialogResult.OK Then
                        Dim excelApp As Object = CreateObject("Excel.Application")
                        Dim workbook = excelApp.Workbooks.Add()
                        Dim worksheet = workbook.Sheets(1)

                        ' Write headers
                        For i As Integer = 0 To dt.Columns.Count - 1
                            worksheet.Cells(1, i + 1).Value = dt.Columns(i).ColumnName
                        Next

                        ' Write data
                        For i As Integer = 0 To dt.Rows.Count - 1
                            For j As Integer = 0 To dt.Columns.Count - 1
                                worksheet.Cells(i + 2, j + 1).Value = dt.Rows(i)(j).ToString()
                            Next
                        Next

                        worksheet.Columns.AutoFit()
                        workbook.SaveAs(sfd.FileName)
                        workbook.Close(False)
                        excelApp.Quit()

                        MsgBox("✅ Your data has been exported to Excel!", MsgBoxStyle.Information)
                    End If
                End Using
            End If

        Catch ex As Exception
            MsgBox("❌ Backup failed: " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub


    ' 🚪 Logout
    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        Me.Hide()
        Dim loginForm As New LoginForm()
        loginForm.Show()
        Me.Close()
    End Sub

    ' ❌ Exit
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Application.Exit()
    End Sub

End Class
