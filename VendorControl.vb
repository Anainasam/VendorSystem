Imports System.Data.SqlClient
Imports System.Configuration

Public Class VendorControl
    Dim connectionString As String = ConfigurationManager.ConnectionStrings("VendorDB").ConnectionString
    Dim cnn As New SqlConnection(connectionString)

    Private Sub VendorControl_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetID()
        GridView1.DataSource = GetData()
        ' 🔧 Initialize search ComboBox
        cmbSearchBy.Items.Clear()
        cmbSearchBy.Items.AddRange(New String() {"VendorName", "Email", "PhoneNumber"})
        cmbSearchBy.SelectedIndex = 0

    End Sub

    Private Function GetData() As DataTable
        Try
            Dim dt As New DataTable()
            cnn.Open()
            Dim cmd As New SqlCommand("SELECT * FROM Setup.Vendor", cnn)
            Dim reader As SqlDataReader = cmd.ExecuteReader()
            dt.Load(reader)
            cnn.Close()
            Return dt
        Catch ex As Exception
            MsgBox(ex.Message)
            cnn.Close()
            Return Nothing
        End Try
    End Function

    Private Sub GetID()
        Try
            cnn.Open()
            Dim cmd As New SqlCommand("IF NOT EXISTS (SELECT * FROM Setup.Vendor) SELECT 1 ELSE SELECT MAX(ID) + 1 FROM Setup.Vendor", cnn)
            txtId.Text = cmd.ExecuteScalar().ToString()
            cnn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            cnn.Close()
        End Try
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If txtId.Text = "" Or txtName.Text = "" Then
            MsgBox("Please fill all required fields.")
            Exit Sub
        End If

        Try
            Dim cmd As New SqlCommand("INSERT INTO Setup.Vendor (ID, VendorName, Address, Email, PhoneNumber) 
                                       VALUES (@ID, @Name, @Address, @Email, @Phone)", cnn)
            cmd.Parameters.AddWithValue("@ID", txtId.Text)
            cmd.Parameters.AddWithValue("@Name", txtName.Text)
            cmd.Parameters.AddWithValue("@Address", txtAddress.Text)
            cmd.Parameters.AddWithValue("@Email", txtEmail.Text)
            cmd.Parameters.AddWithValue("@Phone", txtPhone.Text)

            cnn.Open()
            cmd.ExecuteNonQuery()
            cnn.Close()

            MsgBox("Vendor saved successfully.")
            GridView1.DataSource = GetData()
            ClearFields()
            GetID()
        Catch ex As Exception
            MsgBox(ex.Message)
            cnn.Close()
        End Try
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Try
            Dim cmd As New SqlCommand("UPDATE Setup.Vendor SET VendorName=@Name, Address=@Address, Email=@Email, PhoneNumber=@Phone WHERE ID=@ID", cnn)
            cmd.Parameters.AddWithValue("@ID", txtId.Text)
            cmd.Parameters.AddWithValue("@Name", txtName.Text)
            cmd.Parameters.AddWithValue("@Address", txtAddress.Text)
            cmd.Parameters.AddWithValue("@Email", txtEmail.Text)
            cmd.Parameters.AddWithValue("@Phone", txtPhone.Text)

            cnn.Open()
            cmd.ExecuteNonQuery()
            cnn.Close()

            MsgBox("Vendor updated successfully.")
            GridView1.DataSource = GetData()
            ClearFields()
            GetID()
        Catch ex As Exception
            MsgBox(ex.Message)
            cnn.Close()
        End Try
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If txtId.Text = "" Then
            MsgBox("Please enter a valid ID to delete.")
            Exit Sub
        End If

        Try
            Dim cmd As New SqlCommand("DELETE FROM Setup.Vendor WHERE ID=@ID", cnn)
            cmd.Parameters.AddWithValue("@ID", txtId.Text)

            cnn.Open()
            cmd.ExecuteNonQuery()
            cnn.Close()

            MsgBox("Vendor deleted successfully.")
            GridView1.DataSource = GetData()
            ClearFields()
            GetID()
        Catch ex As Exception
            MsgBox(ex.Message)
            cnn.Close()
        End Try
    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        ClearFields()
        GetID()
    End Sub

    Private Sub ClearFields()
        txtId.Clear()
        txtName.Clear()
        txtAddress.Clear()
        txtEmail.Clear()
        txtPhone.Clear()
    End Sub

    Private Sub SearchVendors()
        Try
            Dim searchField As String = cmbSearchBy.SelectedItem?.ToString()
            Dim searchValue As String = txtSearch.Text.Trim()

            If String.IsNullOrEmpty(searchField) OrElse String.IsNullOrEmpty(searchValue) Then
                MsgBox("Please select a field and enter a search value.")
                Exit Sub
            End If

            Dim dt As New DataTable()
            cnn.Open()
            Dim query As String = $"SELECT * FROM Setup.Vendor WHERE {searchField} LIKE @value"
            Dim cmd As New SqlCommand(query, cnn)
            cmd.Parameters.AddWithValue("@value", "%" & searchValue & "%")

            Dim reader As SqlDataReader = cmd.ExecuteReader()
            dt.Load(reader)
            cnn.Close()

            GridView1.DataSource = dt
        Catch ex As Exception
            MsgBox("Search failed: " & ex.Message)
            cnn.Close()
        End Try
    End Sub
    ' 🔍 Search Button Click
    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        SearchVendors()
    End Sub

    ' ❌ Clear Search Button Click
    Private Sub btnClearSearch_Click(sender As Object, e As EventArgs) Handles btnClearSearch.Click
        txtSearch.Clear()
        If cmbSearchBy.Items.Count > 0 Then cmbSearchBy.SelectedIndex = 0
        GridView1.DataSource = GetData() ' Reload full data
    End Sub

End Class
