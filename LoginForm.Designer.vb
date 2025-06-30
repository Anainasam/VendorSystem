<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LoginForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.txtUsername = New System.Windows.Forms.MaskedTextBox()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.btnLogin = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.username = New System.Windows.Forms.Label()
        Me.txtConfirmPassword = New System.Windows.Forms.MaskedTextBox()
        Me.btnSignup = New System.Windows.Forms.Button()
        Me.lblToggleMode = New System.Windows.Forms.LinkLabel()
        Me.LabelConfirmPassword = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'txtUsername
        '
        Me.txtUsername.Location = New System.Drawing.Point(257, 101)
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.Size = New System.Drawing.Size(225, 22)
        Me.txtUsername.TabIndex = 1
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(257, 157)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(225, 22)
        Me.txtPassword.TabIndex = 2
        '
        'btnLogin
        '
        Me.btnLogin.Location = New System.Drawing.Point(306, 260)
        Me.btnLogin.Name = "btnLogin"
        Me.btnLogin.Size = New System.Drawing.Size(129, 43)
        Me.btnLogin.TabIndex = 3
        Me.btnLogin.Text = "Login"
        Me.btnLogin.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(106, 157)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(81, 20)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "password"
        '
        'username
        '
        Me.username.AutoSize = True
        Me.username.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.username.Location = New System.Drawing.Point(106, 103)
        Me.username.Name = "username"
        Me.username.Size = New System.Drawing.Size(83, 20)
        Me.username.TabIndex = 5
        Me.username.Text = "username"
        '
        'txtConfirmPassword
        '
        Me.txtConfirmPassword.Location = New System.Drawing.Point(257, 208)
        Me.txtConfirmPassword.Name = "txtConfirmPassword"
        Me.txtConfirmPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtConfirmPassword.Size = New System.Drawing.Size(225, 22)
        Me.txtConfirmPassword.TabIndex = 6
        Me.txtConfirmPassword.Visible = False
        '
        'btnSignup
        '
        Me.btnSignup.Location = New System.Drawing.Point(306, 327)
        Me.btnSignup.Name = "btnSignup"
        Me.btnSignup.Size = New System.Drawing.Size(129, 42)
        Me.btnSignup.TabIndex = 7
        Me.btnSignup.Text = "Create Account"
        Me.btnSignup.UseVisualStyleBackColor = True
        Me.btnSignup.Visible = False
        '
        'lblToggleMode
        '
        Me.lblToggleMode.AutoSize = True
        Me.lblToggleMode.Location = New System.Drawing.Point(312, 399)
        Me.lblToggleMode.Name = "lblToggleMode"
        Me.lblToggleMode.Size = New System.Drawing.Size(123, 16)
        Me.lblToggleMode.TabIndex = 8
        Me.lblToggleMode.TabStop = True
        Me.lblToggleMode.Text = "Create an Account?"
        '
        'LabelConfirmPassword
        '
        Me.LabelConfirmPassword.AutoSize = True
        Me.LabelConfirmPassword.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelConfirmPassword.Location = New System.Drawing.Point(106, 210)
        Me.LabelConfirmPassword.Name = "LabelConfirmPassword"
        Me.LabelConfirmPassword.Size = New System.Drawing.Size(145, 20)
        Me.LabelConfirmPassword.TabIndex = 9
        Me.LabelConfirmPassword.Text = "Confirm password"
        Me.LabelConfirmPassword.Visible = False
        '
        'LoginForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.LabelConfirmPassword)
        Me.Controls.Add(Me.lblToggleMode)
        Me.Controls.Add(Me.btnSignup)
        Me.Controls.Add(Me.txtConfirmPassword)
        Me.Controls.Add(Me.username)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnLogin)
        Me.Controls.Add(Me.txtPassword)
        Me.Controls.Add(Me.txtUsername)
        Me.Name = "LoginForm"
        Me.Text = "LoginForm"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtUsername As MaskedTextBox
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents btnLogin As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents username As Label
    Friend WithEvents txtConfirmPassword As MaskedTextBox
    Friend WithEvents btnSignup As Button
    Friend WithEvents lblToggleMode As LinkLabel
    Friend WithEvents LabelConfirmPassword As Label
End Class
