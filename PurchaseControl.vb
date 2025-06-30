Imports System.Data.SqlClient
Imports System.Configuration

Public Class PurchaseControl
    Dim connectionString As String = ConfigurationManager.ConnectionStrings("VendorDB").ConnectionString
    Dim cnn As New SqlConnection(connectionString)

    Private Sub PurchaseControl_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadVendors()
        LoadWarehouses()
        LoadPurchases()
        ClearFields()
    End Sub

    ' 🔹 Load vendors specific to logged-in user
    Private Sub LoadVendors()
        Try
            cnn.Open()
            Dim cmd As New SqlCommand("SELECT VendorName FROM Setup.Vendor WHERE Username = @Username", cnn)
            cmd.Parameters.AddWithValue("@Username", SessionInfo.LoggedInUsername)

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

    ' 🔹 Load warehouse options based on user's past entries
    Private Sub LoadWarehouses()
        Try
            cnn.Open()
            Dim cmd As New SqlCommand("SELECT DISTINCT Warehouse FROM Setup.Purchase WHERE Username = @Username", cnn)
            cmd.Parameters.AddWithValue("@Username", SessionInfo.LoggedInUsername)

            Dim reader As SqlDataReader = cmd.ExecuteReader()
            txtWarehouse.Items.Clear()
            While reader.Read()
                If Not String.IsNullOrWhiteSpace(reader("Warehouse").ToString()) Then
                    txtWarehouse.Items.Add(reader("Warehouse").ToString())
                End If
            End While
            cnn.Close()
        Catch ex As Exception
            MsgBox("Error loading warehouses: " & ex.Message)
            cnn.Close()
        End Try
    End Sub

    ' 🔹 Load purchase records for current user or admin
    Private Sub LoadPurchases()
        Try
            Dim dt As New DataTable()
            cnn.Open()

            Dim query As String
            If SessionInfo.IsAdmin Then
                query = "SELECT * FROM Setup.Purchase ORDER BY PurchaseID DESC"
            Else
                query = "SELECT * FROM Setup.Purchase WHERE Username = @User ORDER BY PurchaseID DESC"
            End If

            Dim cmd As New SqlCommand(query, cnn)
            If Not SessionInfo.IsAdmin Then
                cmd.Parameters.AddWithValue("@User", SessionInfo.LoggedInUsername)
            End If

            Dim reader As SqlDataReader = cmd.ExecuteReader()
            dt.Load(reader)
            cnn.Close()
            GridView1.DataSource = dt
        Catch ex As Exception
            MsgBox("Error loading purchases: " & ex.Message)
            cnn.Close()
        End Try
    End Sub

    Private Sub GetNextPurchaseID()
        Try
            cnn.Open()
            Dim cmd As New SqlCommand("IF NOT EXISTS (SELECT * FROM Setup.Purchase) SELECT 1 ELSE SELECT MAX(PurchaseID) + 1 FROM Setup.Purchase", cnn)
            txtId.Text = cmd.ExecuteScalar().ToString()
            cnn.Close()
        Catch ex As Exception
            MsgBox("Error getting ID: " & ex.Message)
            cnn.Close()
        End Try
    End Sub

    Private Sub ClearFields()
        txtId.Clear()
        cmbVendor.SelectedIndex = -1
        txtItem.Clear()
        txtAmount.Clear()
        txtQuantity.Clear()
        txtWarehouse.Text = ""
        dtpDate.Value = DateTime.Now
        GetNextPurchaseID()
    End Sub

    ' 🔹 Save new purchase
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If cmbVendor.Text = "" Or txtItem.Text = "" Or txtAmount.Text = "" Or txtQuantity.Text = "" Or txtWarehouse.Text = "" Then
            MsgBox("Please fill all fields.")
            Exit Sub
        End If

        Try
            Dim cmd As New SqlCommand("INSERT INTO Setup.Purchase 
                (VendorName, Item, Amount, PurchaseDate, Quantity, Warehouse, Username) 
                VALUES (@Vendor, @Item, @Amount, @Date, @Qty, @Warehouse, @User); 
                SELECT SCOPE_IDENTITY();", cnn)

            cmd.Parameters.AddWithValue("@Vendor", cmbVendor.Text)
            cmd.Parameters.AddWithValue("@Item", txtItem.Text)
            cmd.Parameters.AddWithValue("@Amount", Convert.ToDecimal(txtAmount.Text))
            cmd.Parameters.AddWithValue("@Date", dtpDate.Value)
            cmd.Parameters.AddWithValue("@Qty", Convert.ToInt32(txtQuantity.Text))
            cmd.Parameters.AddWithValue("@Warehouse", txtWarehouse.Text)
            cmd.Parameters.AddWithValue("@User", SessionInfo.LoggedInUsername)

            cnn.Open()
            Dim insertedID = Convert.ToInt32(cmd.ExecuteScalar())
            cnn.Close()

            txtId.Text = insertedID.ToString()
            MsgBox("Purchase saved. Purchase ID: " & insertedID)

            LoadPurchases()
            LoadWarehouses()
        Catch ex As Exception
            MsgBox("Error saving: " & ex.Message)
            cnn.Close()
        End Try
    End Sub

    ' 🔹 Update existing purchase
    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If txtId.Text = "" Then
            MsgBox("Please select a record to update.")
            Exit Sub
        End If

        Try
            Dim cmd As New SqlCommand("UPDATE Setup.Purchase SET 
                VendorName=@Vendor, Item=@Item, Amount=@Amount, PurchaseDate=@Date, 
                Quantity=@Quantity, Warehouse=@Warehouse 
                WHERE PurchaseID=@ID AND Username=@User", cnn)

            cmd.Parameters.AddWithValue("@Vendor", cmbVendor.Text)
            cmd.Parameters.AddWithValue("@Item", txtItem.Text)
            cmd.Parameters.AddWithValue("@Amount", Convert.ToDecimal(txtAmount.Text))
            cmd.Parameters.AddWithValue("@Date", dtpDate.Value)
            cmd.Parameters.AddWithValue("@Quantity", Convert.ToInt32(txtQuantity.Text))
            cmd.Parameters.AddWithValue("@Warehouse", txtWarehouse.Text)
            cmd.Parameters.AddWithValue("@ID", txtId.Text)
            cmd.Parameters.AddWithValue("@User", SessionInfo.LoggedInUsername)

            cnn.Open()
            cmd.ExecuteNonQuery()
            cnn.Close()

            MsgBox("Purchase updated.")
            LoadPurchases()
            LoadWarehouses()
            ClearFields()
        Catch ex As Exception
            MsgBox("Error updating: " & ex.Message)
            cnn.Close()
        End Try
    End Sub

    ' 🔹 Delete selected purchase
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If txtId.Text = "" Then
            MsgBox("Please select a record to delete.")
            Exit Sub
        End If

        Try
            Dim cmd As New SqlCommand("DELETE FROM Setup.Purchase WHERE PurchaseID=@ID AND Username=@User", cnn)
            cmd.Parameters.AddWithValue("@ID", txtId.Text)
            cmd.Parameters.AddWithValue("@User", SessionInfo.LoggedInUsername)

            cnn.Open()
            cmd.ExecuteNonQuery()
            cnn.Close()

            MsgBox("Purchase deleted.")
            LoadPurchases()
            LoadWarehouses()
            ClearFields()
        Catch ex As Exception
            MsgBox("Error deleting: " & ex.Message)
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
            cmbVendor.Text = If(row.Cells("VendorName").Value IsNot DBNull.Value, row.Cells("VendorName").Value.ToString(), "")
            txtItem.Text = If(row.Cells("Item").Value IsNot DBNull.Value, row.Cells("Item").Value.ToString(), "")
            txtAmount.Text = If(row.Cells("Amount").Value IsNot DBNull.Value, row.Cells("Amount").Value.ToString(), "0")

            If row.Cells("PurchaseDate").Value IsNot DBNull.Value Then
                dtpDate.Value = Convert.ToDateTime(row.Cells("PurchaseDate").Value)
            Else
                dtpDate.Value = DateTime.Now
            End If

            txtQuantity.Text = If(row.Cells("Quantity").Value IsNot DBNull.Value, row.Cells("Quantity").Value.ToString(), "0")
            txtWarehouse.Text = If(row.Cells("Warehouse").Value IsNot DBNull.Value, row.Cells("Warehouse").Value.ToString(), "")
        End If
    End Sub
End Class
