Imports System.Data.SqlClient
Imports System.Configuration

Public Class CustomerControl
    Dim connectionString As String = ConfigurationManager.ConnectionStrings("VendorDB").ConnectionString
    Dim cnn As New SqlConnection(connectionString)

    Private Sub CustomerControl_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetID()
        GridView1.DataSource = GetData()
    End Sub

    ' 🔍 Load all customers into grid
    Private Function GetData() As DataTable
        Try
            Dim dt As New DataTable()
            cnn.Open()
            Dim cmd As New SqlCommand("SELECT * FROM Setup.Customer", cnn)
            Dim reader As SqlDataReader = cmd.ExecuteReader()
            dt.Load(reader)
            cnn.Close()
            Return dt
        Catch ex As Exception
            MsgBox("Error loading customers: " & ex.Message)
            cnn.Close()
            Return Nothing
        End Try
    End Function

    ' 🆔 Auto-generate Customer ID
    Private Sub GetID()
        Try
            cnn.Open()
            Dim cmd As New SqlCommand("IF NOT EXISTS (SELECT * FROM Setup.Customer) SELECT 1 ELSE SELECT MAX(ID) + 1 FROM Setup.Customer", cnn)
            txtId.Text = cmd.ExecuteScalar().ToString()
            cnn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            cnn.Close()
        End Try
    End Sub

    ' 💾 Save new customer
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If txtId.Text = "" Or txtName.Text = "" Then
            MsgBox("Please enter Customer ID and Name.")
            Exit Sub
        End If

        Try
            Dim cmd As New SqlCommand("INSERT INTO Setup.Customer (ID, CustomerName, Address, Email, PhoneNumber)
                                       VALUES (@ID, @Name, @Address, @Email, @Phone)", cnn)
            cmd.Parameters.AddWithValue("@ID", txtId.Text)
            cmd.Parameters.AddWithValue("@Name", txtName.Text)
            cmd.Parameters.AddWithValue("@Address", txtAddress.Text)
            cmd.Parameters.AddWithValue("@Email", txtEmail.Text)
            cmd.Parameters.AddWithValue("@Phone", txtPhone.Text)

            cnn.Open()
            cmd.ExecuteNonQuery()
            cnn.Close()

            MsgBox("Customer added successfully.")
            GridView1.DataSource = GetData()
            ClearFields()
            GetID()
        Catch ex As Exception
            MsgBox("Error: " & ex.Message)
            cnn.Close()
        End Try
    End Sub

    ' ✏️ Update existing customer
    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Try
            Dim cmd As New SqlCommand("UPDATE Setup.Customer SET CustomerName=@Name, Address=@Address, Email=@Email, PhoneNumber=@Phone
                                       WHERE ID=@ID", cnn)
            cmd.Parameters.AddWithValue("@ID", txtId.Text)
            cmd.Parameters.AddWithValue("@Name", txtName.Text)
            cmd.Parameters.AddWithValue("@Address", txtAddress.Text)
            cmd.Parameters.AddWithValue("@Email", txtEmail.Text)
            cmd.Parameters.AddWithValue("@Phone", txtPhone.Text)

            cnn.Open()
            cmd.ExecuteNonQuery()
            cnn.Close()

            MsgBox("Customer updated successfully.")
            GridView1.DataSource = GetData()
            ClearFields()
            GetID()
        Catch ex As Exception
            MsgBox(ex.Message)
            cnn.Close()
        End Try
    End Sub

    ' ❌ Delete customer
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If txtId.Text = "" Then
            MsgBox("Please enter a valid ID to delete.")
            Exit Sub
        End If

        Try
            Dim cmd As New SqlCommand("DELETE FROM Setup.Customer WHERE ID=@ID", cnn)
            cmd.Parameters.AddWithValue("@ID", txtId.Text)

            cnn.Open()
            cmd.ExecuteNonQuery()
            cnn.Close()

            MsgBox("Customer deleted successfully.")
            GridView1.DataSource = GetData()
            ClearFields()
            GetID()
        Catch ex As Exception
            MsgBox(ex.Message)
            cnn.Close()
        End Try
    End Sub

    ' 🆕 Clear fields
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
End Class
