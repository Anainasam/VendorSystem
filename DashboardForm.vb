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
        MsgBox("Backup feature coming soon!") ' Will implement later
    End Sub

    ' ❌ Exit
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Application.Exit()
    End Sub

    Private Sub btnPurchaseReport_Click(sender As Object, e As EventArgs) Handles btnPurchaseReport.Click
        LoadControl(New PurchaseReportControl())
    End Sub

End Class
