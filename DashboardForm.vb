Imports System.Configuration
Imports System.Data.SqlClient

Public Class DashboardForm

    ' Load default control on form load (optional)
    Private Sub DashboardForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadControl(New VendorControl())
    End Sub

    ' 🔄 Generic method to load any user control into the content panel
    Private Sub LoadControl(control As UserControl)
        contentPanel.Controls.Clear()
        control.Dock = DockStyle.Fill
        contentPanel.Controls.Add(control)
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

    ' 🛠 Backup Button Click
    Private Sub btnBackup_Click(sender As Object, e As EventArgs) Handles btnBackup.Click
        BackupDatabase()
    End Sub


    ' ❌ Exit
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Application.Exit()
    End Sub

    Private Sub btnPurchaseReport_Click(sender As Object, e As EventArgs) Handles btnPurchaseReport.Click
        LoadControl(New PurchaseReportControl())
    End Sub

    Private Sub BackupDatabase()
        Try
            Dim connectionString As String = ConfigurationManager.ConnectionStrings("VendorDB").ConnectionString
            Using cnn As New SqlConnection(connectionString)
                ' 📁 Ask user where to save the .bak file
                Dim saveDialog As New SaveFileDialog()
                saveDialog.Filter = "Backup Files|*.bak"
                saveDialog.Title = "Save Database Backup"
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

                    MsgBox("✅ Backup completed successfully!", MsgBoxStyle.Information)
                End If
            End Using
        Catch ex As Exception
            MsgBox("❌ Backup failed: " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    ' 🚪 Logout Button Click
    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        ' Hide the dashboard
        Me.Hide()

        ' Show the login form again
        Dim loginForm As New LoginForm()
        loginForm.Show()
        Me.Close()

    End Sub

End Class
