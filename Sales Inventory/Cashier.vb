Public Class frmCashier
    Dim code As String
    Dim exist As Boolean
    Dim lid As Integer
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        End
    End Sub

    Private Sub Button18_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button18.Click
        frmAdmin.Show()
        Me.Close()
    End Sub

    Private Sub frmCashier_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        frmAdmin.Show()
    End Sub

    Private Sub frmCashier_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lblDisplay.ResetText()
        txtBarcode.Clear()
        code = ""
        txtBarcode.Focus()
        col()
    End Sub

    Private Sub clickButton(ByVal num As String)
        If lblDisplay.Text.Length < 13 Then
            code = code & num
            lblDisplay.Text = code
            txtBarcode.Text = code
            txtBarcode.Select()
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        clickButton("1")
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        clickButton("2")
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        clickButton("3")
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        clickButton("4")
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        clickButton("5")
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        clickButton("6")
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        clickButton("7")
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        clickButton("8")
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        clickButton("9")
    End Sub

    Private Sub ButtonPoint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonPoint.Click
        clickButton(".")
    End Sub

    Private Sub Button0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button0.Click
        clickButton("0")
    End Sub

    Private Sub Button00_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button00.Click
        clickButton("00")
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        lblDisplay.ResetText()
        txtBarcode.Clear()
        code = ""
        txtBarcode.Select()
    End Sub

    Private Sub btnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBack.Click
        backSpace()
    End Sub

    Private Sub backSpace()
        If Not lblDisplay.Text = Nothing Then
            Dim length As Integer
            length = Len(lblDisplay.Text) - 1
            code = Microsoft.VisualBasic.Left(lblDisplay.Text, length)
            lblDisplay.Text = code
            txtBarcode.Text = code
            txtBarcode.Select()
        End If
    End Sub

    Private Sub txtBarcode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBarcode.KeyDown
        If e.KeyCode = Keys.Enter Then
            pressEnter()
        End If
    End Sub

    Private Sub pressEnter()
        If String.IsNullOrEmpty(txtBarcode.Text) Then
            MessageBox.Show("Please Enter a code", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Else
            checkCode(txtBarcode.Text)
            If Not RS.EOF Then
                pid = RS.Fields("PID").Value
                frmQuantity.txtQuantity.Clear()
                frmQuantity.lblQuantity.Text = "ENTER QUANTITY"
                frmQuantity.ShowDialog()
                If Not quantity = Nothing Then
                    GetProductInfo(pid)
                    checkExist()
                    If exist = True Then
                        lvwPurchase.Items(lid).SubItems(3).Text = lvwPurchase.Items(lid).SubItems(3).Text + quantity
                        lvwPurchase.Items(lid).SubItems(4).Text = lvwPurchase.Items(lid).SubItems(3).Text * lvwPurchase.Items(lid).SubItems(2).Text
                        exist = False
                    Else
                        purchaseList()
                    End If
                    quantity = Nothing
                    lblDisplay.ResetText()
                    txtBarcode.Clear()
                    code = ""
                    txtBarcode.Select()
                    getTotal()
                    txtProdCode.Clear()
                    txtProdName.Clear()
                    txtCat.Clear()
                    txtProdPrice.Clear()
                End If
            End If
        End If
    End Sub

    Private Sub checkExist()
        Dim i As Integer = 0
        Do Until lvwPurchase.Items.Count = i
            If lvwPurchase.Items(i).SubItems(0).Text = pid Then
                exist = True
                lid = i
                Exit Sub
            End If
            i += 1
        Loop
    End Sub

    Private Sub purchaseList()
        Dim list As New ListViewItem
        list = lvwPurchase.Items.Add(RS.Fields("PID").Value)
        list.SubItems.Add(RS.Fields("prod_name").Value)
        list.SubItems.Add(RS.Fields("prod_price").Value)
        list.SubItems.Add(quantity)
        list.SubItems.Add(quantity * RS.Fields("prod_price").Value)
    End Sub

    Private Sub col()
        lvwPurchase.Columns.Clear()
        lvwPurchase.Columns.Add("PID", 0)
        lvwPurchase.Columns.Add("Product Name", 200)
        lvwPurchase.Columns.Add("Price", 150)
        lvwPurchase.Columns.Add("Quantity", 150)
        lvwPurchase.Columns.Add("Sub Total", 150)
    End Sub
    Private Sub txtBarcode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBarcode.TextChanged
        If Not IsNumeric(txtBarcode.Text) Then
            lblDisplay.Text = txtBarcode.Text
            backSpace()
        Else
            lblDisplay.Text = txtBarcode.Text
            checkCode(txtBarcode.Text)
            If Not RS.EOF Then
                txtProdName.Text = RS.Fields("prod_name").Value
                txtProdCode.Text = RS.Fields("prod_code").Value
                txtProdPrice.Text = RS.Fields("prod_price").Value
                GetCatName(RS.Fields("prod_cat").Value)
                txtCat.Text = RS.Fields(0).Value
            Else
                txtProdCode.Clear()
                txtProdName.Clear()
                txtCat.Clear()
                txtProdPrice.Clear()
            End If
        End If
        code = lblDisplay.Text
    End Sub

    Private Sub lblDisplay_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblDisplay.TextChanged
        If lblDisplay.Text.Length > 13 Then
            code = Microsoft.VisualBasic.Right(lblDisplay.Text, Len(lblDisplay.Text) - 1)
            lblDisplay.Text = code
        End If
    End Sub

    Private Sub btnEnter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEnter.Click
        pressEnter()
    End Sub

    Private Sub btnRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemove.Click
        Try
            lvwPurchase.Items.Remove(lvwPurchase.SelectedItems(0))
            txtBarcode.Focus()
            getTotal()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        Try
            frmQuantity.txtQuantity.Clear()
            frmQuantity.txtQuantity.Text = lvwPurchase.SelectedItems(0).SubItems(3).Text
            frmQuantity.ShowDialog()
            If quantity > 0 Then
                lvwPurchase.SelectedItems(0).SubItems(3).Text = quantity
                lvwPurchase.SelectedItems(0).SubItems(4).Text = quantity * lvwPurchase.SelectedItems(0).SubItems(2).Text
                txtBarcode.Focus()
                getTotal()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub getTotal()
        Dim total As Double
        Dim i As Integer = 0
        Do Until lvwPurchase.Items.Count = i
            total = total + lvwPurchase.Items(i).SubItems(4).Text
            i += 1
        Loop
        lblTotal.Text = total
    End Sub

    Private Sub btnPurchase_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPurchase.Click
        If Not lvwPurchase.Items.Count = 0 Then
            frmQuantity.lblQuantity.Text = "AMOUNT TENDERED"
            frmQuantity.txtQuantity.Clear()
            due = lblTotal.Text
            frmQuantity.ShowDialog()
            txtBarcode.Clear()
            txtBarcode.Focus()
        End If
    End Sub
End Class