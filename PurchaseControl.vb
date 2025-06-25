Imports System.Data.SqlClient
Imports System.Configuration

Public Class PurchaseControl
    Dim connectionString As String = ConfigurationManager.ConnectionStrings("VendorDB").ConnectionString
    Dim cnn As New SqlConnection(connectionString)

    Private Sub PurchaseControl_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadVendors()
        LoadPurchases()
    End Sub

    Private Sub LoadVendors()
        Try
            cnn.Open()
            Dim cmd As New SqlCommand("SELECT VendorName FROM Setup.Vendor", cnn)
            Dim reader As SqlDataReader = cmd.ExecuteReader()
            cmbVendor.Items.Clear()
            While reader.Read()
                cmbVendor.Items.Add(reader("VendorName").ToString())
            End While
            cnn.Close()
        Catch ex As Exception
            MsgBox("Error loading vendors: " & ex.Message)
            cnn.Close()
        End Try
    End Sub

    Private Sub LoadPurchases()
        Try
            Dim dt As New DataTable()
            cnn.Open()
            Dim cmd As New SqlCommand("SELECT * FROM Setup.Purchase", cnn)
            Dim reader As SqlDataReader = cmd.ExecuteReader()
            dt.Load(reader)
            cnn.Close()
            GridView1.DataSource = dt
        Catch ex As Exception
            MsgBox(ex.Message)
            cnn.Close()
        End Try
    End Sub

    Private Sub ClearFields()
        txtId.Clear()
        cmbVendor.SelectedIndex = -1
        txtItem.Clear()
        txtAmount.Clear()
        dtpDate.Value = DateTime.Now
    End Sub

    ' 🔹 Save Button
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If cmbVendor.Text = "" Or txtItem.Text = "" Or txtAmount.Text = "" Then
            MsgBox("Please fill all fields.")
            Exit Sub
        End If

        Try
            Dim cmd As New SqlCommand("INSERT INTO Setup.Purchase (VendorName, Item, Amount, PurchaseDate)
                                       VALUES (@Vendor, @Item, @Amount, @Date)", cnn)
            cmd.Parameters.AddWithValue("@Vendor", cmbVendor.Text)
            cmd.Parameters.AddWithValue("@Item", txtItem.Text)
            cmd.Parameters.AddWithValue("@Amount", Convert.ToDecimal(txtAmount.Text))
            cmd.Parameters.AddWithValue("@Date", dtpDate.Value)

            cnn.Open()
            cmd.ExecuteNonQuery()
            cnn.Close()

            MsgBox("Purchase saved.")
            LoadPurchases()
            ClearFields()
        Catch ex As Exception
            MsgBox(ex.Message)
            cnn.Close()
        End Try
    End Sub

    ' 🔹 Update Button
    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If txtId.Text = "" Then
            MsgBox("Please select a record to update.")
            Exit Sub
        End If

        Try
            Dim cmd As New SqlCommand("UPDATE Setup.Purchase SET VendorName=@Vendor, Item=@Item, Amount=@Amount, PurchaseDate=@Date WHERE PurchaseID=@ID", cnn)
            cmd.Parameters.AddWithValue("@Vendor", cmbVendor.Text)
            cmd.Parameters.AddWithValue("@Item", txtItem.Text)
            cmd.Parameters.AddWithValue("@Amount", Convert.ToDecimal(txtAmount.Text))
            cmd.Parameters.AddWithValue("@Date", dtpDate.Value)
            cmd.Parameters.AddWithValue("@ID", txtId.Text)

            cnn.Open()
            cmd.ExecuteNonQuery()
            cnn.Close()

            MsgBox("Purchase updated.")
            LoadPurchases()
            ClearFields()
        Catch ex As Exception
            MsgBox(ex.Message)
            cnn.Close()
        End Try
    End Sub

    ' 🔹 Delete Button
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If txtId.Text = "" Then
            MsgBox("Please select a record to delete.")
            Exit Sub
        End If

        Try
            Dim cmd As New SqlCommand("DELETE FROM Setup.Purchase WHERE PurchaseID=@ID", cnn)
            cmd.Parameters.AddWithValue("@ID", txtId.Text)

            cnn.Open()
            cmd.ExecuteNonQuery()
            cnn.Close()

            MsgBox("Purchase deleted.")
            LoadPurchases()
            ClearFields()
        Catch ex As Exception
            MsgBox(ex.Message)
            cnn.Close()
        End Try
    End Sub

    ' 🔹 New Button
    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        ClearFields()
    End Sub

    ' 🔹 GridView Row Click → Fill Form
    Private Sub GridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles GridView1.CellClick
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow = GridView1.Rows(e.RowIndex)
            txtId.Text = row.Cells("PurchaseID").Value.ToString()
            cmbVendor.Text = row.Cells("VendorName").Value.ToString()
            txtItem.Text = row.Cells("Item").Value.ToString()
            txtAmount.Text = row.Cells("Amount").Value.ToString()
            dtpDate.Value = Convert.ToDateTime(row.Cells("PurchaseDate").Value)
        End If
    End Sub


End Class

