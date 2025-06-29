Imports System.Data.SqlClient
Imports System.Configuration

Public Class PurchaseControl
    Dim connectionString As String = ConfigurationManager.ConnectionStrings("VendorDB").ConnectionString
    Dim cnn As New SqlConnection(connectionString)

    Private Sub PurchaseControl_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadVendors()
        LoadPurchases()
        ClearFields() ' Also calls GetNextPurchaseID
    End Sub

    Private Sub LoadVendors()
        Try
            cnn.Open()
            Dim cmd As New SqlCommand("SELECT VendorName FROM Setup.Vendor", cnn)
            Dim reader As SqlDataReader = cmd.ExecuteReader()
            cmbVendor.Items.Clear()
            While reader.Read()
                cmbVendor.Items.Add(reader("VendorName").ToString())
            End While
            cnn.Close()
        Catch ex As Exception
            MsgBox("Error loading vendors: " & ex.Message)
            cnn.Close()
        End Try
    End Sub

    Private Sub LoadPurchases()
        Try
            Dim dt As New DataTable()
            cnn.Open()
            Dim cmd As New SqlCommand("SELECT * FROM Setup.Purchase ORDER BY PurchaseID DESC", cnn)
            Dim reader As SqlDataReader = cmd.ExecuteReader()
            dt.Load(reader)
            cnn.Close()
            GridView1.DataSource = dt
        Catch ex As Exception
            MsgBox(ex.Message)
            If cnn.State = ConnectionState.Open Then
                cnn.Close()
            End If
        End Try
    End Sub

    Private Sub GetNextPurchaseID()
        Try
            cnn.Open()
            Dim cmd As New SqlCommand("IF NOT EXISTS (SELECT * FROM Setup.Purchase) SELECT 1 ELSE SELECT MAX(PurchaseID) + 1 FROM Setup.Purchase", cnn)
            txtId.Text = cmd.ExecuteScalar().ToString()
            cnn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            If cnn.State = ConnectionState.Open Then cnn.Close()
        End Try
    End Sub

    Private Sub ClearFields()
        txtId.Clear()
        cmbVendor.SelectedIndex = -1
        txtItem.Clear()
        txtAmount.Clear()
        txtQuantity.Clear()
        txtWarehouse.Text = ""  'Changed from Clear() to Text = ""
        dtpDate.Value = DateTime.Now
        GetNextPurchaseID()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If cmbVendor.Text = "" Or txtItem.Text = "" Or txtAmount.Text = "" Or txtQuantity.Text = "" Or txtWarehouse.Text = "" Then
            MsgBox("Please fill all fields.")
            Exit Sub
        End If

        Try
            Dim cmd As New SqlCommand("INSERT INTO Setup.Purchase (VendorName, Item, Amount, PurchaseDate, Quantity, Warehouse) VALUES (@Vendor, @Item, @Amount, @Date, @Qty, @Warehouse); SELECT SCOPE_IDENTITY();", cnn)
            cmd.Parameters.AddWithValue("@Vendor", cmbVendor.Text)
            cmd.Parameters.AddWithValue("@Item", txtItem.Text)
            cmd.Parameters.AddWithValue("@Amount", Convert.ToDecimal(txtAmount.Text))
            cmd.Parameters.AddWithValue("@Date", dtpDate.Value)
            cmd.Parameters.AddWithValue("@Qty", Convert.ToInt32(txtQuantity.Text))
            cmd.Parameters.AddWithValue("@Warehouse", txtWarehouse.Text)

            cnn.Open()
            Dim insertedID = Convert.ToInt32(cmd.ExecuteScalar())
            cnn.Close()

            txtId.Text = insertedID.ToString()
            MsgBox("Purchase saved. Purchase ID: " & insertedID)

            LoadPurchases()
            ' Optionally clear after showing ID
        Catch ex As Exception
            MsgBox("Error: " & ex.Message)
            cnn.Close()
        End Try
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If txtId.Text = "" Then
            MsgBox("Please select a record to update.")
            Exit Sub
        End If

        Try
            Dim cmd As New SqlCommand("UPDATE Setup.Purchase SET VendorName=@Vendor, Item=@Item, Amount=@Amount, PurchaseDate=@Date, Quantity=@Quantity, Warehouse=@Warehouse WHERE PurchaseID=@ID", cnn)
            cmd.Parameters.AddWithValue("@Vendor", cmbVendor.Text)
            cmd.Parameters.AddWithValue("@Item", txtItem.Text)
            cmd.Parameters.AddWithValue("@Amount", Convert.ToDecimal(txtAmount.Text))
            cmd.Parameters.AddWithValue("@Date", dtpDate.Value)
            cmd.Parameters.AddWithValue("@ID", txtId.Text)
            cmd.Parameters.AddWithValue("@Quantity", Convert.ToInt32(txtQuantity.Text))
            cmd.Parameters.AddWithValue("@Warehouse", txtWarehouse.Text)

            cnn.Open()
            cmd.ExecuteNonQuery()
            cnn.Close()

            MsgBox("Purchase updated.")
            LoadPurchases()
            ClearFields()
        Catch ex As Exception
            MsgBox(ex.Message)
            cnn.Close()
        End Try
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If txtId.Text = "" Then
            MsgBox("Please select a record to delete.")
            Exit Sub
        End If

        Try
            Dim cmd As New SqlCommand("DELETE FROM Setup.Purchase WHERE PurchaseID=@ID", cnn)
            cmd.Parameters.AddWithValue("@ID", txtId.Text)

            cnn.Open()
            cmd.ExecuteNonQuery()
            cnn.Close()

            MsgBox("Purchase deleted.")
            LoadPurchases()
            ClearFields()
        Catch ex As Exception
            MsgBox(ex.Message)
            cnn.Close()
        End Try
    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        ClearFields()
    End Sub

    Private Sub GridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles GridView1.CellClick
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow = GridView1.Rows(e.RowIndex)
            txtId.Text = If(row.Cells("PurchaseID").Value IsNot Nothing, row.Cells("PurchaseID").Value.ToString(), "")
            cmbVendor.Text = If(row.Cells("VendorName").Value IsNot DBNull.Value AndAlso row.Cells("VendorName").Value IsNot Nothing, row.Cells("VendorName").Value.ToString(), "")
            txtItem.Text = If(row.Cells("Item").Value IsNot DBNull.Value AndAlso row.Cells("Item").Value IsNot Nothing, row.Cells("Item").Value.ToString(), "")
            txtAmount.Text = If(row.Cells("Amount").Value IsNot DBNull.Value AndAlso row.Cells("Amount").Value IsNot Nothing, row.Cells("Amount").Value.ToString(), "0")

            If row.Cells("PurchaseDate").Value IsNot DBNull.Value AndAlso row.Cells("PurchaseDate").Value IsNot Nothing Then
                dtpDate.Value = Convert.ToDateTime(row.Cells("PurchaseDate").Value)
            Else
                dtpDate.Value = DateTime.Now
            End If

            txtQuantity.Text = If(row.Cells("Quantity").Value IsNot DBNull.Value AndAlso row.Cells("Quantity").Value IsNot Nothing, row.Cells("Quantity").Value.ToString(), "0")
            txtWarehouse.Text = If(row.Cells("Warehouse").Value IsNot DBNull.Value AndAlso row.Cells("Warehouse").Value IsNot Nothing, row.Cells("Warehouse").Value.ToString(), "")
        End If
    End Sub
End Class
