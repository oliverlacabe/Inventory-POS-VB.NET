Public Class frmPurchase
    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        frmCashier.lvwPurchase.Items.Clear()
        frmCashier.lblTotal.ResetText()
        Me.Close()
    End Sub

    Private Sub frmPurchase_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        rtbReceipt.Text = receipt
    End Sub
End Class