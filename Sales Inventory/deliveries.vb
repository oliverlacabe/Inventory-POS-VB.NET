Public Class frmdeliveries
    Private Sub deliveries_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With ListView1
            .Clear()
            .Columns.Add("Product Code", 100)
            .Columns.Add("Product Name", 180)
            .Columns.Add("Price", 80)
            .Columns.Add("Items Delivered", 120)
            .Columns.Add("Exp Date", 100)
            getDeliveries(bid)
            Dim list As New ListViewItem
            If Not RS.EOF Then
                Do Until RS.EOF
                    list = .Items.Add(RS.Fields("prod_code").Value)
                    list.SubItems.Add(RS.Fields("prod_name").Value)
                    list.SubItems.Add(RS.Fields("prod_price").Value)
                    list.SubItems.Add(RS.Fields("items_delivered").Value)
                    list.SubItems.Add(RS.Fields("exp_date").Value)
                    RS.MoveNext()
                Loop
            End If
        End With
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class