<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DashboardForm
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
        Me.contentPanel = New System.Windows.Forms.Panel()
        Me.panelButtons = New System.Windows.Forms.Panel()
        Me.btnLogout = New System.Windows.Forms.Button()
        Me.btnPurchaseReport = New System.Windows.Forms.Button()
        Me.btnPurchase = New System.Windows.Forms.Button()
        Me.btnVendor = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.btnCustomer = New System.Windows.Forms.Button()
        Me.btnBackup = New System.Windows.Forms.Button()
        Me.btnStockTransfer = New System.Windows.Forms.Button()
        Me.panelButtons.SuspendLayout()
        Me.SuspendLayout()
        '
        'contentPanel
        '
        Me.contentPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.contentPanel.Location = New System.Drawing.Point(0, 0)
        Me.contentPanel.Name = "contentPanel"
        Me.contentPanel.Size = New System.Drawing.Size(800, 450)
        Me.contentPanel.TabIndex = 4
        '
        'panelButtons
        '
        Me.panelButtons.Controls.Add(Me.btnStockTransfer)
        Me.panelButtons.Controls.Add(Me.btnLogout)
        Me.panelButtons.Controls.Add(Me.btnPurchaseReport)
        Me.panelButtons.Controls.Add(Me.btnPurchase)
        Me.panelButtons.Controls.Add(Me.btnVendor)
        Me.panelButtons.Controls.Add(Me.btnExit)
        Me.panelButtons.Controls.Add(Me.btnCustomer)
        Me.panelButtons.Controls.Add(Me.btnBackup)
        Me.panelButtons.Dock = System.Windows.Forms.DockStyle.Top
        Me.panelButtons.Location = New System.Drawing.Point(0, 0)
        Me.panelButtons.Name = "panelButtons"
        Me.panelButtons.Size = New System.Drawing.Size(800, 87)
        Me.panelButtons.TabIndex = 5
        '
        'btnLogout
        '
        Me.btnLogout.Location = New System.Drawing.Point(708, 17)
        Me.btnLogout.Name = "btnLogout"
        Me.btnLogout.Size = New System.Drawing.Size(80, 70)
        Me.btnLogout.TabIndex = 8
        Me.btnLogout.Text = "Logout"
        Me.btnLogout.UseVisualStyleBackColor = True
        '
        'btnPurchaseReport
        '
        Me.btnPurchaseReport.Location = New System.Drawing.Point(286, 12)
        Me.btnPurchaseReport.Name = "btnPurchaseReport"
        Me.btnPurchaseReport.Size = New System.Drawing.Size(83, 70)
        Me.btnPurchaseReport.TabIndex = 7
        Me.btnPurchaseReport.Text = "Purchase Report"
        Me.btnPurchaseReport.UseVisualStyleBackColor = True
        '
        'btnPurchase
        '
        Me.btnPurchase.Location = New System.Drawing.Point(200, 12)
        Me.btnPurchase.Name = "btnPurchase"
        Me.btnPurchase.Size = New System.Drawing.Size(80, 70)
        Me.btnPurchase.TabIndex = 6
        Me.btnPurchase.Text = "Purchase"
        Me.btnPurchase.UseVisualStyleBackColor = True
        '
        'btnVendor
        '
        Me.btnVendor.BackColor = System.Drawing.Color.White
        Me.btnVendor.Location = New System.Drawing.Point(12, 12)
        Me.btnVendor.Name = "btnVendor"
        Me.btnVendor.Size = New System.Drawing.Size(88, 70)
        Me.btnVendor.TabIndex = 0
        Me.btnVendor.Text = "Vendor"
        Me.btnVendor.UseVisualStyleBackColor = False
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(622, 17)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(80, 70)
        Me.btnExit.TabIndex = 3
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'btnCustomer
        '
        Me.btnCustomer.Location = New System.Drawing.Point(106, 12)
        Me.btnCustomer.Name = "btnCustomer"
        Me.btnCustomer.Size = New System.Drawing.Size(88, 70)
        Me.btnCustomer.TabIndex = 1
        Me.btnCustomer.Text = "Customer"
        Me.btnCustomer.UseVisualStyleBackColor = True
        '
        'btnBackup
        '
        Me.btnBackup.Location = New System.Drawing.Point(375, 12)
        Me.btnBackup.Name = "btnBackup"
        Me.btnBackup.Size = New System.Drawing.Size(86, 70)
        Me.btnBackup.TabIndex = 2
        Me.btnBackup.Text = "Backup DB"
        Me.btnBackup.UseVisualStyleBackColor = True
        '
        'btnStockTransfer
        '
        Me.btnStockTransfer.Location = New System.Drawing.Point(467, 12)
        Me.btnStockTransfer.Name = "btnStockTransfer"
        Me.btnStockTransfer.Size = New System.Drawing.Size(86, 70)
        Me.btnStockTransfer.TabIndex = 3
        Me.btnStockTransfer.Text = "Stock Transfer"
        Me.btnStockTransfer.UseVisualStyleBackColor = True
        '
        'DashboardForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.panelButtons)
        Me.Controls.Add(Me.contentPanel)
        Me.Name = "DashboardForm"
        Me.Text = "DashboardForm"
        Me.panelButtons.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents contentPanel As Panel
    Friend WithEvents panelButtons As Panel
    Friend WithEvents btnVendor As Button
    Friend WithEvents btnExit As Button
    Friend WithEvents btnCustomer As Button
    Friend WithEvents btnBackup As Button
    Friend WithEvents btnPurchase As Button
    Friend WithEvents btnPurchaseReport As Button
    Friend WithEvents btnLogout As Button
    Friend WithEvents btnStockTransfer As Button
End Class
