Imports System.Data.SqlClient
Imports System.Configuration

Public Class StockTransferControl
    Dim connectionString As String = ConfigurationManager.ConnectionStrings("VendorDB").ConnectionString
    Dim cnn As New SqlConnection(connectionString)

    Private Sub StockTransferControl_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadItems()
        LoadWarehouses()
        LoadTransfers()
    End Sub

    ' Load unique items into dropdown
    Private Sub LoadItems()
        Try
            cnn.Open()
            Dim cmd As New SqlCommand("SELECT DISTINCT Item FROM Setup.Purchase", cnn)
            Dim reader = cmd.ExecuteReader()
            cmbItem.Items.Clear()
            While reader.Read()
                cmbItem.Items.Add(reader("Item").ToString())
            End While
            cnn.Close()
        Catch ex As Exception
            MsgBox("Error loading items: " & ex.Message)
            cnn.Close()
        End Try
    End Sub

    ' Load unique warehouse locations
    Private Sub LoadWarehouses()
        Try
            cnn.Open()
            Dim cmd As New SqlCommand("SELECT DISTINCT Warehouse FROM Setup.Purchase", cnn)
            Dim reader = cmd.ExecuteReader()
            cmbFromWarehouse.Items.Clear()
            cmbToWarehouse.Items.Clear()
            While reader.Read()
                cmbFromWarehouse.Items.Add(reader("Warehouse").ToString())
                cmbToWarehouse.Items.Add(reader("Warehouse").ToString())
            End While
            cnn.Close()
        Catch ex As Exception
            MsgBox("Error loading warehouses: " & ex.Message)
            cnn.Close()
        End Try
    End Sub

    ' Load stock transfer grid
    Private Sub LoadTransfers()
        Try
            cnn.Open()
            Dim dt As New DataTable()
            Dim cmd As New SqlCommand("SELECT PurchaseID, VendorName, Item, Warehouse, Quantity FROM Setup.Purchase", cnn)
            Dim reader = cmd.ExecuteReader()
            dt.Load(reader)
            cnn.Close()
            gridTransfers.DataSource = dt
        Catch ex As Exception
            MsgBox("Error loading grid: " & ex.Message)
            cnn.Close()
        End Try
    End Sub

    ' 🔁 Perform Stock Transfer
    Private Sub btnTransfer_Click(sender As Object, e As EventArgs) Handles btnTransfer.Click
        If cmbItem.Text = "" Or cmbFromWarehouse.Text = "" Or cmbToWarehouse.Text = "" Or txtTransferQty.Text = "" Then
            MsgBox("Please fill all fields.")
            Exit Sub
        End If

        Dim item = cmbItem.Text
        Dim fromWH = cmbFromWarehouse.Text
        Dim toWH = cmbToWarehouse.Text
        Dim qty As Integer = Convert.ToInt32(txtTransferQty.Text)

        If fromWH = toWH Then
            MsgBox("Cannot transfer to the same warehouse.")
            Exit Sub
        End If

        Try
            cnn.Open()

            ' 🔍 Get FROM warehouse entry (exact vendor + item + warehouse match)
            Dim fromCmd As New SqlCommand("SELECT TOP 1 Quantity, VendorName FROM Setup.Purchase WHERE Item=@Item AND Warehouse=@FromWH ORDER BY PurchaseID", cnn)
            fromCmd.Parameters.AddWithValue("@Item", item)
            fromCmd.Parameters.AddWithValue("@FromWH", fromWH)

            Dim reader = fromCmd.ExecuteReader()
            If Not reader.Read() Then
                MsgBox("Source warehouse entry not found.")
                reader.Close()
                cnn.Close()
                Exit Sub
            End If

            Dim fromQty = Convert.ToInt32(reader("Quantity"))
            Dim vendor = reader("VendorName").ToString()
            reader.Close()

            If fromQty < qty Then
                MsgBox("Not enough stock available in the source warehouse.")
                cnn.Close()
                Exit Sub
            End If

            ' 🔍 Ensure TO warehouse already has the same vendor + item
            Dim checkToCmd As New SqlCommand("SELECT COUNT(*) FROM Setup.Purchase WHERE Item=@Item AND Warehouse=@ToWH AND VendorName=@Vendor", cnn)
            checkToCmd.Parameters.AddWithValue("@Item", item)
            checkToCmd.Parameters.AddWithValue("@ToWH", toWH)
            checkToCmd.Parameters.AddWithValue("@Vendor", vendor)
            Dim exists = Convert.ToInt32(checkToCmd.ExecuteScalar())

            If exists = 0 Then
                MsgBox("Transfer failed: Destination warehouse does not have this item by this vendor.")
                cnn.Close()
                Exit Sub
            End If

            ' ✅ Reduce stock from FROM warehouse
            Dim reduceCmd As New SqlCommand("UPDATE Setup.Purchase SET Quantity = Quantity - @Qty WHERE Item=@Item AND Warehouse=@FromWH AND VendorName=@Vendor", cnn)
            reduceCmd.Parameters.AddWithValue("@Qty", qty)
            reduceCmd.Parameters.AddWithValue("@Item", item)
            reduceCmd.Parameters.AddWithValue("@FromWH", fromWH)
            reduceCmd.Parameters.AddWithValue("@Vendor", vendor)
            reduceCmd.ExecuteNonQuery()

            ' ✅ Add stock to TO warehouse
            Dim updateCmd As New SqlCommand("UPDATE Setup.Purchase SET Quantity = Quantity + @Qty WHERE Item=@Item AND Warehouse=@ToWH AND VendorName=@Vendor", cnn)
            updateCmd.Parameters.AddWithValue("@Qty", qty)
            updateCmd.Parameters.AddWithValue("@Item", item)
            updateCmd.Parameters.AddWithValue("@ToWH", toWH)
            updateCmd.Parameters.AddWithValue("@Vendor", vendor)
            updateCmd.ExecuteNonQuery()

            cnn.Close()

            MsgBox("Stock transferred successfully.")
            txtTransferQty.Clear()
            LoadTransfers()

        Catch ex As Exception
            MsgBox("Transfer failed: " & ex.Message)
            cnn.Close()
        End Try
    End Sub
End Class
