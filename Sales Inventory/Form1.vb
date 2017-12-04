Public Class frmQuantity
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        lblQuantity.Text = "ENTER QUANTITY"
        Me.Close()
    End Sub

    Private Sub lblClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblClose.Click
        lblQuantity.Text = "ENTER QUANTITY"
        Me.Close()
    End Sub

    Private Sub btnEnter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEnter.Click
        enterQuantity()
    End Sub

    Private Sub txtQuantity_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtQuantity.KeyDown
        If e.KeyCode = Keys.Enter Then
            enterQuantity()
        End If
    End Sub

    Private Sub enterQuantity()
        If Not txtQuantity.Text = "" Then
            If lblQuantity.Text = "AMOUNT TENDERED" Then
                If txtQuantity.Text >= due Then
                    change = txtQuantity.Text - frmCashier.lblTotal.Text
                    frmPurchase.lblChange.Text = change
                    Me.Close()
                    getTrans()
                    Dim trans As String = ""
                    Dim transNum As String
                    If Not RS.EOF Then
                        transNum = Microsoft.VisualBasic.Right(RS.Fields("transNum").Value, 6)
                        If Now.ToShortDateString = RS.Fields("transdate").Value Then
                            Dim c As Integer = 1
                            Dim num As String = ""
                            Do While num.Contains("0")
                                num = Microsoft.VisualBasic.Left(transNum, c)
                                c += 1
                            Loop
                            c = 6 - c
                            num = Microsoft.VisualBasic.Right(transNum, c)
                            num = num + 1
                            c = 0
                            Dim l As Integer = 6 - Len(num)
                            Do Until c = l
                                trans = trans & "0"
                                c += 1
                            Loop
                            trans = trans & num
                        Else
                            trans = "000001"
                        End If
                    Else
                        trans = "000001"
                    End If
                    transNum = Now.Year & "-" & Now.Day & "-" & Now.Month & "-" & trans
                    Dim i = 0
                    Dim count As Integer = frmCashier.lvwPurchase.Items.Count
                    Dim itemCount As Integer = 0
                    Try
                        Do Until i = count
                            Dim stock As Integer
                            Dim id As Integer = frmCashier.lvwPurchase.Items(i).SubItems(0).Text
                            getStock(id)
                            If Not RS.EOF Then
                                Dim num As Integer = CInt(frmCashier.lvwPurchase.Items(i).SubItems(3).Text)
                                saveDetails(transNum, id, num)
                                stock = RS.Fields(0).Value - frmCashier.lvwPurchase.Items(i).SubItems(3).Text
                                buyProducts(frmCashier.lvwPurchase.Items(i).Text, stock, frmCashier.lvwPurchase.Items(i).SubItems(3).Text)
                                itemCount = itemCount + num
                            End If
                            i += 1
                        Loop
                    Catch ex As Exception
                    End Try
                    i = 0
                    receipt = vbNewLine
                    receipt = receipt & "                           GOD BLESS ENTERPRISES" & vbNewLine
                    receipt = receipt & "                RealStreet, Brgy. Cayare, San Miguel, Leyte" & vbNewLine
                    receipt = receipt & "                                               " & Now.ToShortDateString & vbNewLine & vbNewLine
                    receipt = receipt & "Transaction No.  " & transNum & vbNewLine & vbNewLine
                    receipt = receipt & "Cashier:  " & logged & vbNewLine & vbNewLine
                    Do Until frmCashier.lvwPurchase.Items.Count = i
                        receipt = receipt & "--------------------------------------------------------------------------" & vbNewLine
                        receipt = receipt & "   " & frmCashier.lvwPurchase.Items(i).SubItems(1).Text & vbNewLine & "   " & frmCashier.lvwPurchase.Items(i).SubItems(3).Text & "   @   "
                        receipt = receipt & "   " & frmCashier.lvwPurchase.Items(i).SubItems(2).Text & vbNewLine & "   Sub Total                                           " & frmCashier.lvwPurchase.Items(i).SubItems(4).Text & vbNewLine
                        'start here
                        i += 1
                    Loop
                    receipt = receipt & "==========================================" & vbNewLine
                    receipt = receipt & "   TOTAL                                               " & due * 0.88 & vbNewLine
                    receipt = receipt & "   VAT 12%                                             " & due * 0.12 & vbNewLine
                    receipt = receipt & "   AMOUNT DUE                                   " & due & vbNewLine & vbNewLine
                    receipt = receipt & "   Amount Tendered                           " & txtQuantity.Text & vbNewLine
                    receipt = receipt & "   Change                                               " & change & vbNewLine & vbNewLine
                    receipt = receipt & "   This Serves as your official receipt" & vbNewLine
                    receipt = receipt & "   Thank you! Come again!" & vbNewLine
                    saveTrans(transNum, itemCount, Now.ToShortDateString, receipt)
                    frmPurchase.lblc.Visible = True
                    frmPurchase.lblChange.Visible = True
                    'frmPurchase.ShowDialog()
                    PrintPreviewDialog1.ShowDialog()
                    frmCashier.lvwPurchase.Items.Clear()
                    frmCashier.lblTotal.ResetText()
                    frmAdmin.dailyReport()
                    frmCashier.txtProdCode.Clear()
                    frmCashier.txtProdName.Clear()
                    frmCashier.txtCat.Clear()
                    frmCashier.txtProdPrice.Clear()
                    lblQuantity.Text = "ENTER QUANTITY"
                Else
                    MessageBox.Show("Amount Tendered is low!", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    txtQuantity.Focus()
                    txtQuantity.SelectAll()
                End If
            Else
                checkStock(pid)
                If Not RS.EOF Then
                    If RS.Fields("prod_stock").Value >= txtQuantity.Text Then
                        quantity = txtQuantity.Text
                        Me.Close()
                    Else
                        MessageBox.Show("Item quantity  is greater than the remaining stock!" & vbNewLine & "Remaining stock is " & RS.Fields("prod_stock").Value, "Stop", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        txtQuantity.Focus()
                        txtQuantity.SelectAll()
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub txtQuantity_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtQuantity.TextChanged
        If Not IsNumeric(txtQuantity.Text) And Not String.IsNullOrEmpty(txtQuantity.Text) Then
            Dim length As Integer = 0
            length = Len(txtQuantity.Text) - 1
            txtQuantity.Text = Microsoft.VisualBasic.Left(txtQuantity.Text, length)
        End If
    End Sub

    Private Sub frmQuantity_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        txtQuantity.Focus()
    End Sub

    Private Sub frmQuantity_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtQuantity.TabIndex = 0
        quantity = Nothing
    End Sub

    Private Sub PrintPreviewDialog1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintPreviewDialog1.Load
        PrintPreviewDialog1.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedDialog
        PrintPreviewDialog1.SetBounds(frmCashier.Width * 0.05, frmCashier.Height * 0.05, frmCashier.Width * 0.9, frmCashier.Height * 0.9)
        PrintPreviewDialog1.FormBorderStyle = Windows.Forms.FormBorderStyle.None
    End Sub

    Private Sub PrintDetails(ByRef e As System.Drawing.Printing.PrintPageEventArgs)
        Static LastIndex As Integer = 0
        Static CurrentPage As Integer = 0

        Dim DpiGraphics As Graphics = Me.CreateGraphics
        Dim DpiX As Integer = DpiGraphics.DpiX
        Dim DpiY As Integer = DpiGraphics.DpiY

        DpiGraphics.Dispose()

        Dim TextRect As Rectangle = Rectangle.Empty
        Dim StringFormat As New StringFormat
        Dim tex As Rectangle = Rectangle.Empty

        Dim PageNumberWidth As Single = e.Graphics.MeasureString(CStr(CurrentPage), Font).Width

        StringFormat.FormatFlags = StringFormatFlags.NoWrap
        StringFormat.Trimming = StringTrimming.EllipsisCharacter
        StringFormat.LineAlignment = StringAlignment.Center
        CurrentPage += 1

        tex.X = (e.MarginBounds.X) - 50
        tex.Y = (e.MarginBounds.Y) + 90

        e.Graphics.DrawString(receipt, frmPurchase.rtbReceipt.Font, Brushes.Black, tex, StringFormat)

        e.Graphics.DrawString(CStr(CurrentPage), Font, Brushes.Black, (e.PageBounds.Width - PageNumberWidth) / 2, e.PageBounds.Bottom - Font.Height * 2)
        StringFormat.Dispose()
        LastIndex = 0
        CurrentPage = 0
    End Sub

    Private Sub PrintDocument1_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Dim font1 As New Font("Times New Roman", 20, FontStyle.Regular)
        PrintDetails(e)
    End Sub
End Class