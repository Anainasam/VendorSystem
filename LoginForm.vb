Imports System.Data.SqlClient
Imports System.Configuration

Public Class LoginForm
    Dim connectionString As String = ConfigurationManager.ConnectionStrings("VendorDB").ConnectionString
    Dim isSignupMode As Boolean = False

    ' Global values to store logged in user
    Public Shared LoggedInUsername As String
    Public Shared LoggedInRole As String

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Try
            Using cnn As New SqlConnection(connectionString)
                cnn.Open()
                Dim cmd As New SqlCommand("SELECT Role FROM Setup.Users WHERE Username=@user AND Password=@pass", cnn)
                cmd.Parameters.AddWithValue("@user", txtUsername.Text)
                cmd.Parameters.AddWithValue("@pass", txtPassword.Text)

                Dim role = Convert.ToString(cmd.ExecuteScalar())

                If role IsNot Nothing Then
                    MsgBox("Login successful!")
                    ' Inside If result > 0 Then
                    SessionInfo.LoggedInUsername = txtUsername.Text

                    ' Check if user is admin
                    If txtUsername.Text.ToLower() = "admin" Then
                        SessionInfo.IsAdmin = True
                    Else
                        SessionInfo.IsAdmin = False
                    End If

                    LoggedInUsername = txtUsername.Text
                    LoggedInRole = role

                    DashboardForm.Show()
                    Me.Hide()
                Else
                    MsgBox("Invalid credentials.")
                End If
            End Using
        Catch ex As Exception
            MsgBox("An error occurred during login. Please contact support.")
        End Try
    End Sub

    Private Sub btnSignup_Click(sender As Object, e As EventArgs) Handles btnSignup.Click
        If txtUsername.Text = "" Or txtPassword.Text = "" Or txtConfirmPassword.Text = "" Then
            MsgBox("Please fill all fields.")
            Return
        End If

        If txtPassword.Text <> txtConfirmPassword.Text Then
            MsgBox("Passwords do not match.")
            Return
        End If

        Try
            Using cnn As New SqlConnection(connectionString)
                cnn.Open()

                ' Check if username already exists
                Dim checkCmd As New SqlCommand("SELECT COUNT(*) FROM Setup.Users WHERE Username = @Username", cnn)
                checkCmd.Parameters.AddWithValue("@Username", txtUsername.Text)
                Dim exists As Integer = Convert.ToInt32(checkCmd.ExecuteScalar())

                If exists > 0 Then
                    MsgBox("Username already exists.")
                    Return
                End If

                ' Insert new user
                Dim insertCmd As New SqlCommand("INSERT INTO Setup.Users (Username, Password, Role) VALUES (@Username, @Password, 'user')", cnn)
                insertCmd.Parameters.AddWithValue("@Username", txtUsername.Text)
                insertCmd.Parameters.AddWithValue("@Password", txtPassword.Text)
                insertCmd.ExecuteNonQuery()

                MsgBox("Account created successfully! You can now log in.")

                ' Switch back to login mode
                lblToggleMode.Text = "Create an account?"
                btnLogin.Visible = True
                btnSignup.Visible = False
                txtConfirmPassword.Visible = False
                LabelConfirmPassword.Visible = False
                isSignupMode = False
            End Using
        Catch ex As Exception
            MsgBox("Error during sign up: " & ex.Message)
        End Try
    End Sub

    Private Sub lblToggleMode_Click(sender As Object, e As EventArgs) Handles lblToggleMode.Click
        isSignupMode = Not isSignupMode

        If isSignupMode Then
            lblToggleMode.Text = "Already have an account?"
            btnLogin.Visible = False
            btnSignup.Visible = True
            txtConfirmPassword.Visible = True
            LabelConfirmPassword.Visible = True
        Else
            lblToggleMode.Text = "Create an account?"
            btnLogin.Visible = True
            btnSignup.Visible = False
            txtConfirmPassword.Visible = False
            LabelConfirmPassword.Visible = False
        End If
    End Sub
End Class
