Imports System.Data.SqlClient
Imports System.Configuration

Public Class LoginForm
    Dim connectionString As String = ConfigurationManager.ConnectionStrings("VendorDB").ConnectionString

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Try
            Using cnn As New SqlConnection(connectionString)
                cnn.Open()
                Using cmd As New SqlCommand("SELECT COUNT(*) FROM Setup.Users WHERE Username=@user AND Password=@pass", cnn)
                    cmd.Parameters.AddWithValue("@user", txtUsername.Text)
                    cmd.Parameters.AddWithValue("@pass", txtPassword.Text)

                    Dim result = Convert.ToInt32(cmd.ExecuteScalar())

                    If result > 0 Then
                        MsgBox("Login successful!")

                        DashboardForm.Show()
                        Hide()

                    Else
                        MsgBox("Invalid credentials.")
                    End If
                End Using
            End Using
        Catch ex As Exception
            MsgBox("An error occurred during login. Please contact support.")
            ' Optionally log ex.Message somewhere safe
        End Try
    End Sub


End Class