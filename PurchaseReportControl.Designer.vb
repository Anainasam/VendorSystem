<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PurchaseReportControl
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.purchaseGrid = New System.Windows.Forms.DataGridView()
        Me.btnExportExcel = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.purchaseGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'purchaseGrid
        '
        Me.purchaseGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.purchaseGrid.Location = New System.Drawing.Point(21, 271)
        Me.purchaseGrid.Name = "purchaseGrid"
        Me.purchaseGrid.RowHeadersWidth = 51
        Me.purchaseGrid.RowTemplate.Height = 24
        Me.purchaseGrid.Size = New System.Drawing.Size(789, 342)
        Me.purchaseGrid.TabIndex = 0
        '
        'btnExportExcel
        '
        Me.btnExportExcel.Location = New System.Drawing.Point(682, 641)
        Me.btnExportExcel.Name = "btnExportExcel"
        Me.btnExportExcel.Size = New System.Drawing.Size(128, 54)
        Me.btnExportExcel.TabIndex = 1
        Me.btnExportExcel.Text = "Export to Excel"
        Me.btnExportExcel.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(16, 195)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(157, 25)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Purchase Report"
        '
        'PurchaseReportControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnExportExcel)
        Me.Controls.Add(Me.purchaseGrid)
        Me.Name = "PurchaseReportControl"
        Me.Size = New System.Drawing.Size(1001, 738)
        CType(Me.purchaseGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents purchaseGrid As DataGridView
    Friend WithEvents btnExportExcel As Button
    Friend WithEvents Label1 As Label
End Class
