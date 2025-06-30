Imports System.Data.SqlClient
Imports System.Configuration

Public Class CustomerControl
    Dim connectionString As String = ConfigurationManager.ConnectionStrings("VendorDB").ConnectionString
    Dim cnn As New SqlConnection(connectionString)

    Private Sub CustomerControl_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetID()
        GridView1.DataSource = GetData()
    End Sub

    Private Function GetData() As DataTable
        Try
            Dim dt As New DataTable()
            cnn.Open()

            Dim query As String
            If SessionInfo.IsAdmin Then
                query = "SELECT * FROM Setup.Customer"
            Else
                query = "SELECT * FROM Setup.Customer WHERE Username = @User"
            End If

            Dim cmd As New SqlCommand(query, cnn)
            If Not SessionInfo.IsAdmin Then
                cmd.Parameters.AddWithValue("@User", SessionInfo.LoggedInUsername)
            End If

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

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If txtId.Text = "" Or txtName.Text = "" Then
            MsgBox("Please enter Customer ID and Name.")
            Exit Sub
        End If

        Try
            Dim cmd As New SqlCommand("INSERT INTO Setup.Customer (ID, CustomerName, Address, Email, PhoneNumber, Username) 
                                       VALUES (@ID, @Name, @Address, @Email, @Phone, @User)", cnn)
            cmd.Parameters.AddWithValue("@ID", txtId.Text)
            cmd.Parameters.AddWithValue("@Name", txtName.Text)
            cmd.Parameters.AddWithValue("@Address", txtAddress.Text)
            cmd.Parameters.AddWithValue("@Email", txtEmail.Text)
            cmd.Parameters.AddWithValue("@Phone", txtPhone.Text)
            cmd.Parameters.AddWithValue("@User", SessionInfo.LoggedInUsername)

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

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Try
            Dim cmd As New SqlCommand("UPDATE Setup.Customer SET CustomerName=@Name, Address=@Address, Email=@Email, PhoneNumber=@Phone 
                                       WHERE ID=@ID AND Username=@User", cnn)
            cmd.Parameters.AddWithValue("@ID", txtId.Text)
            cmd.Parameters.AddWithValue("@Name", txtName.Text)
            cmd.Parameters.AddWithValue("@Address", txtAddress.Text)
            cmd.Parameters.AddWithValue("@Email", txtEmail.Text)
            cmd.Parameters.AddWithValue("@Phone", txtPhone.Text)
            cmd.Parameters.AddWithValue("@User", SessionInfo.LoggedInUsername)

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

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If txtId.Text = "" Then
            MsgBox("Please enter a valid ID to delete.")
            Exit Sub
        End If

        Try
            Dim cmd As New SqlCommand("DELETE FROM Setup.Customer WHERE ID=@ID AND Username=@User", cnn)
            cmd.Parameters.AddWithValue("@ID", txtId.Text)
            cmd.Parameters.AddWithValue("@User", SessionInfo.LoggedInUsername)

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
