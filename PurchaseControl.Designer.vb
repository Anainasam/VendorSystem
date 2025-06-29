<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PurchaseControl
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
        Me.cmbVendor = New System.Windows.Forms.ComboBox()
        Me.txtItem = New System.Windows.Forms.TextBox()
        Me.txtAmount = New System.Windows.Forms.TextBox()
        Me.dtpDate = New System.Windows.Forms.DateTimePicker()
        Me.txtId = New System.Windows.Forms.TextBox()
        Me.GridView1 = New System.Windows.Forms.DataGridView()
        Me.btnNew = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtQuantity = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtWarehouse = New System.Windows.Forms.ComboBox()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmbVendor
        '
        Me.cmbVendor.FormattingEnabled = True
        Me.cmbVendor.Location = New System.Drawing.Point(194, 133)
        Me.cmbVendor.Name = "cmbVendor"
        Me.cmbVendor.Size = New System.Drawing.Size(161, 24)
        Me.cmbVendor.TabIndex = 0
        '
        'txtItem
        '
        Me.txtItem.Location = New System.Drawing.Point(194, 179)
        Me.txtItem.Name = "txtItem"
        Me.txtItem.Size = New System.Drawing.Size(100, 22)
        Me.txtItem.TabIndex = 1
        '
        'txtAmount
        '
        Me.txtAmount.Location = New System.Drawing.Point(194, 224)
        Me.txtAmount.Name = "txtAmount"
        Me.txtAmount.Size = New System.Drawing.Size(100, 22)
        Me.txtAmount.TabIndex = 2
        '
        'dtpDate
        '
        Me.dtpDate.Location = New System.Drawing.Point(194, 325)
        Me.dtpDate.Name = "dtpDate"
        Me.dtpDate.Size = New System.Drawing.Size(200, 22)
        Me.dtpDate.TabIndex = 3
        '
        'txtId
        '
        Me.txtId.Location = New System.Drawing.Point(194, 90)
        Me.txtId.Name = "txtId"
        Me.txtId.Size = New System.Drawing.Size(100, 22)
        Me.txtId.TabIndex = 4
        '
        'GridView1
        '
        Me.GridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridView1.Location = New System.Drawing.Point(22, 468)
        Me.GridView1.Name = "GridView1"
        Me.GridView1.RowHeadersWidth = 51
        Me.GridView1.RowTemplate.Height = 24
        Me.GridView1.Size = New System.Drawing.Size(906, 228)
        Me.GridView1.TabIndex = 5
        '
        'btnNew
        '
        Me.btnNew.Location = New System.Drawing.Point(104, 416)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(75, 23)
        Me.btnNew.TabIndex = 6
        Me.btnNew.Text = "New"
        Me.btnNew.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(194, 416)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 7
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnUpdate
        '
        Me.btnUpdate.Location = New System.Drawing.Point(286, 416)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(75, 23)
        Me.btnUpdate.TabIndex = 8
        Me.btnUpdate.Text = "Update"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(385, 416)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(75, 23)
        Me.btnDelete.TabIndex = 9
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(19, 93)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 16)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Purchase Id"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(19, 141)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 16)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Vendor name"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(19, 185)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(32, 16)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Item"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(19, 227)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(52, 16)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "Amount"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(19, 325)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(94, 16)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "Purchase date"
        '
        'txtQuantity
        '
        Me.txtQuantity.Location = New System.Drawing.Point(194, 270)
        Me.txtQuantity.Name = "txtQuantity"
        Me.txtQuantity.Size = New System.Drawing.Size(100, 22)
        Me.txtQuantity.TabIndex = 15
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(19, 276)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(55, 16)
        Me.Label6.TabIndex = 16
        Me.Label6.Text = "Quantity"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(19, 378)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(131, 16)
        Me.Label7.TabIndex = 17
        Me.Label7.Text = "Warehouse Location"
        '
        'txtWarehouse
        '
        Me.txtWarehouse.FormattingEnabled = True
        Me.txtWarehouse.Location = New System.Drawing.Point(194, 370)
        Me.txtWarehouse.Name = "txtWarehouse"
        Me.txtWarehouse.Size = New System.Drawing.Size(121, 24)
        Me.txtWarehouse.TabIndex = 18
        '
        'PurchaseControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.txtWarehouse)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtQuantity)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnUpdate)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnNew)
        Me.Controls.Add(Me.GridView1)
        Me.Controls.Add(Me.txtId)
        Me.Controls.Add(Me.dtpDate)
        Me.Controls.Add(Me.txtAmount)
        Me.Controls.Add(Me.txtItem)
        Me.Controls.Add(Me.cmbVendor)
        Me.Name = "PurchaseControl"
        Me.Size = New System.Drawing.Size(1339, 699)
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cmbVendor As ComboBox
    Friend WithEvents txtItem As TextBox
    Friend WithEvents txtAmount As TextBox
    Friend WithEvents dtpDate As DateTimePicker
    Friend WithEvents txtId As TextBox
    Friend WithEvents GridView1 As DataGridView
    Friend WithEvents btnNew As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents btnUpdate As Button
    Friend WithEvents btnDelete As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents txtQuantity As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents txtWarehouse As ComboBox
End Class
