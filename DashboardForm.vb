
Public Class DashboardForm

    Private Sub btnVendor_Click(sender As Object, e As EventArgs) Handles btnVendor.Click
        VendorForm.Show()
    End Sub

    Private Sub btnCustomer_Click(sender As Object, e As EventArgs) Handles btnCustomer.Click
        ' You’ll create this form next
        CustomerForm.Show()
    End Sub

    Private Sub btnBackup_Click(sender As Object, e As EventArgs) Handles btnBackup.Click
        MsgBox("Backup feature coming soon!") ' We'll add actual backup code later
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Application.Exit()
    End Sub

End Class
