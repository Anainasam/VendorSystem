Imports System.Data.SqlClient
Imports System.Configuration

Public Class UserManagementControl
    Dim connectionString As String = ConfigurationManager.ConnectionStrings("VendorDB").ConnectionString
    Dim cnn As New SqlConnection(connectionString)

    Private Sub UserManagementControl_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadUsers()
    End Sub

    Private Sub LoadUsers()
        Try
            cnn.Open()
            Dim dt As New DataTable()
            Dim cmd As New SqlCommand("SELECT ID, Username FROM Setup.Users", cnn)
            Dim reader As SqlDataReader = cmd.ExecuteReader()
            dt.Load(reader)
            cnn.Close()
            GridViewUsers.DataSource = dt
        Catch ex As Exception
            MsgBox("Error loading users: " & ex.Message)
            cnn.Close()
        End Try
    End Sub

    Private Sub btnAddUser_Click(sender As Object, e As EventArgs) Handles btnAddUser.Click
        If txtUsername.Text = "" Or txtPassword.Text = "" Then
            MsgBox("Please fill both username and password.")
            Exit Sub
        End If

        Try
            cnn.Open()
            Dim cmd As New SqlCommand("INSERT INTO Setup.Users (Username, Password) VALUES (@Username, @Password)", cnn)
            cmd.Parameters.AddWithValue("@Username", txtUsername.Text)
            cmd.Parameters.AddWithValue("@Password", txtPassword.Text) ' In production, hash passwords!
            cmd.ExecuteNonQuery()
            cnn.Close()

            MsgBox("✅ User created successfully.")
            txtUsername.Clear()
            txtPassword.Clear()
            LoadUsers()
        Catch ex As SqlException When ex.Number = 2627
            MsgBox("❌ Username already exists.")
            cnn.Close()
        Catch ex As Exception
            MsgBox("❌ Error: " & ex.Message)
            cnn.Close()
        End Try
    End Sub

End Class
