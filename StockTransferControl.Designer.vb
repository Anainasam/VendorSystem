<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class StockTransferControl
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
        Me.cmbItem = New System.Windows.Forms.ComboBox()
        Me.cmbFromWarehouse = New System.Windows.Forms.ComboBox()
        Me.cmbToWarehouse = New System.Windows.Forms.ComboBox()
        Me.txtTransferQty = New System.Windows.Forms.TextBox()
        Me.btnTransfer = New System.Windows.Forms.Button()
        Me.gridTransfers = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        CType(Me.gridTransfers, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmbItem
        '
        Me.cmbItem.FormattingEnabled = True
        Me.cmbItem.Location = New System.Drawing.Point(193, 111)
        Me.cmbItem.Name = "cmbItem"
        Me.cmbItem.Size = New System.Drawing.Size(121, 24)
        Me.cmbItem.TabIndex = 0
        '
        'cmbFromWarehouse
        '
        Me.cmbFromWarehouse.FormattingEnabled = True
        Me.cmbFromWarehouse.Location = New System.Drawing.Point(193, 166)
        Me.cmbFromWarehouse.Name = "cmbFromWarehouse"
        Me.cmbFromWarehouse.Size = New System.Drawing.Size(121, 24)
        Me.cmbFromWarehouse.TabIndex = 1
        '
        'cmbToWarehouse
        '
        Me.cmbToWarehouse.FormattingEnabled = True
        Me.cmbToWarehouse.Location = New System.Drawing.Point(193, 224)
        Me.cmbToWarehouse.Name = "cmbToWarehouse"
        Me.cmbToWarehouse.Size = New System.Drawing.Size(121, 24)
        Me.cmbToWarehouse.TabIndex = 2
        '
        'txtTransferQty
        '
        Me.txtTransferQty.Location = New System.Drawing.Point(193, 279)
        Me.txtTransferQty.Name = "txtTransferQty"
        Me.txtTransferQty.Size = New System.Drawing.Size(121, 22)
        Me.txtTransferQty.TabIndex = 3
        '
        'btnTransfer
        '
        Me.btnTransfer.Location = New System.Drawing.Point(193, 324)
        Me.btnTransfer.Name = "btnTransfer"
        Me.btnTransfer.Size = New System.Drawing.Size(75, 23)
        Me.btnTransfer.TabIndex = 4
        Me.btnTransfer.Text = "Transfer"
        Me.btnTransfer.UseVisualStyleBackColor = True
        '
        'gridTransfers
        '
        Me.gridTransfers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridTransfers.Location = New System.Drawing.Point(50, 362)
        Me.gridTransfers.Name = "gridTransfers"
        Me.gridTransfers.RowHeadersWidth = 51
        Me.gridTransfers.RowTemplate.Height = 24
        Me.gridTransfers.Size = New System.Drawing.Size(876, 327)
        Me.gridTransfers.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(47, 114)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 16)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Item Name"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(47, 169)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(111, 16)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "From Warehouse"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(47, 224)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(97, 16)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "To Warehouse"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(47, 285)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(122, 16)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Quantity to Transfer"
        '
        'StockTransferControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.gridTransfers)
        Me.Controls.Add(Me.btnTransfer)
        Me.Controls.Add(Me.txtTransferQty)
        Me.Controls.Add(Me.cmbToWarehouse)
        Me.Controls.Add(Me.cmbFromWarehouse)
        Me.Controls.Add(Me.cmbItem)
        Me.Name = "StockTransferControl"
        Me.Size = New System.Drawing.Size(1204, 692)
        CType(Me.gridTransfers, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cmbItem As ComboBox
    Friend WithEvents cmbFromWarehouse As ComboBox
    Friend WithEvents cmbToWarehouse As ComboBox
    Friend WithEvents txtTransferQty As TextBox
    Friend WithEvents btnTransfer As Button
    Friend WithEvents gridTransfers As DataGridView
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
End Class
