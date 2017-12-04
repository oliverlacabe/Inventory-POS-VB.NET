Public Class frmAdmin
    Dim prodID As Integer = Nothing
    Dim retVal, add, changeImage As Boolean
    Dim defaultPhoto, extHolder, imageLocation, imgName, idHolder, empID As String
    Dim part1 As String = ""
    Dim part2 As String = ""
    Dim part3 As String = ""
    Dim part4 As String = ""
    Dim part5 As String = ""
    Dim part6 As String = ""

    Private Sub frmAdmin_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        End
    End Sub

    Private Sub frmAdmin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pnl()
        Timer1.Start()
        refreshCBOCategory()
        refreshProdList()
        refBatch()
        SelectEmp()
        refreshEmpList()
        SelectEmp()
        refreshEmpListUpdate()
        panelsDisable()
        refcboEmp()
        pnlHome.Enabled = True
        pnlHome.BringToFront()
        pbEmp.ImageLocation = My.Computer.FileSystem.CurrentDirectory & "\he.png"
        pbImageUpdate.ImageLocation = My.Computer.FileSystem.CurrentDirectory & "\he.png"
        imageLocation = My.Computer.FileSystem.CurrentDirectory & "\he.png"
    End Sub

    Private Sub lblClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblClose.Click
        End
    End Sub

    Private Sub frmAdmin_ResizeEnd(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ResizeEnd
        pnl()
    End Sub

    Private Sub pnl()
        pnlSide.Width = Me.Width * 0.2
    End Sub

    Private Sub Label2_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label2.MouseHover
        Label2.BackColor = Color.LightSteelBlue
    End Sub

    Private Sub Label2_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label2.MouseLeave
        Label2.BackColor = Color.White
    End Sub

    Private Sub lblClose_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblClose.MouseHover
        lblClose.BackColor = Color.LightSteelBlue
    End Sub

    Private Sub lblClose_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblClose.MouseLeave
        lblClose.BackColor = Color.White
    End Sub

    Private Sub panelsDisable()
        pnlHome.Enabled = False
        pnlLOgs.Enabled = False
        pnlProducts.Enabled = False
        pnlReports.Enabled = False
        pnlUsers.Enabled = False
    End Sub

    Private Sub lblHome_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblHome.Click
        panelsDisable()
        pnlHome.Enabled = True
        pnlHome.BringToFront()
        lblDescription.Text = "Welcome to POS manage and monitor" & vbNewLine & "your sales in an easy way."

    End Sub

    Private Sub lblProducts_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblProducts.Click
        panelsDisable()
        pnlProducts.Enabled = True
        pnlProducts.BringToFront()
        lblDescription.Text = "Monitor your product availability and" & vbNewLine & "update your stock in a convenient way."
    End Sub

    Private Sub lblUsers_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblUsers.Click
        panelsDisable()
        pnlUsers.Enabled = True
        pnlUsers.BringToFront()
        lblDescription.Text = "Add new users and manage their" & vbNewLine & "informations."
    End Sub

    Private Sub lblReports_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblReports.Click
        panelsDisable()
        pnlReports.Enabled = True
        pnlReports.BringToFront()
        lblDescription.Text = "View your daily, or monthly " & vbNewLine & "reports about your sales" & vbNewLine & "and print them."
        resetReport()
    End Sub

    Private Sub lblLogs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblLogs.Click
        panelsDisable()
        pnlLOgs.Enabled = True
        pnlLOgs.BringToFront()
        lblDescription.Text = "Shows what your system is doing"
    End Sub

    Private Sub lblHome_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblHome.MouseHover
        lblHome.ForeColor = Color.White
        Cursor = Cursors.Hand
    End Sub

    Private Sub lblHome_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblHome.MouseLeave
        lblHome.ForeColor = Color.Gainsboro
        Cursor = Cursors.Arrow
    End Sub

    Private Sub lblProducts_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblProducts.MouseHover
        lblProducts.ForeColor = Color.White
        Cursor = Cursors.Hand
    End Sub

    Private Sub lblProducts_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblProducts.MouseLeave
        lblProducts.ForeColor = Color.Gainsboro
        Cursor = Cursors.Arrow
    End Sub

    Private Sub lblUsers_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblUsers.MouseHover
        lblUsers.ForeColor = Color.White
        Cursor = Cursors.Hand
    End Sub

    Private Sub lblUsers_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblUsers.MouseLeave
        lblUsers.ForeColor = Color.Gainsboro
        Cursor = Cursors.Arrow
    End Sub

    Private Sub lblReports_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblReports.MouseHover
        lblReports.ForeColor = Color.White
        Cursor = Cursors.Hand
    End Sub

    Private Sub lblReports_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblReports.MouseLeave
        lblReports.ForeColor = Color.Gainsboro
        Cursor = Cursors.Arrow
    End Sub

    Private Sub lblLogs_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblLogs.MouseHover
        lblLogs.ForeColor = Color.White
        Cursor = Cursors.Hand
    End Sub

    Private Sub lblLogs_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblLogs.MouseLeave
        lblLogs.ForeColor = Color.Gainsboro
        Cursor = Cursors.Arrow
    End Sub

    Private Sub lblLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblLogin.Click
        If lblLogin.Text = "LOGIN" Then
            pbUserPic.ImageLocation = My.Computer.FileSystem.CurrentDirectory & "/he.png"
            frmLogin.ShowDialog()
        Else
            pnlLinks.Visible = False
            pnlCash.Visible = False
            panelsDisable()
            pnlHome.Enabled = True
            pnlHome.BringToFront()
            lblLogin.Text = "LOGIN"
            lblDescription.Text = "Welcome to POS manage and monitor" & vbNewLine & "your sales in an easy way."
            tsmTitle.Text = "GOD BLESS"
            MANAGEToolStripMenuItem.Enabled = False
            lblUname.Visible = False
            lblEmpName.Visible = False
            pnlInfo.Visible = False
            pbUserPic.Visible = False
            lbUID.Visible = False
            UserID = Nothing
        End If
    End Sub

    Private Sub lblLogin_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblLogin.MouseHover
        lblLogin.BackColor = Color.LightSteelBlue
    End Sub

    Private Sub lblLogin_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblLogin.MouseLeave
        lblLogin.BackColor = Color.White
    End Sub

    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label2.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub btnAddCat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddCat.Click
        frmAddCategory.ShowDialog()
    End Sub

    Public Sub refreshCBOCategory()
        cboSelectCategory.Items.Clear()
        cboProdCatUP.Items.Clear()
        cboSearchAP.Items.Clear()
        cboSearchPA.Items.Clear()
        cboSearchUP.Items.Clear()
        cboSearchAP.Items.Add("All")
        cboSearchPA.Items.Add("All")
        cboSearchUP.Items.Add("All")
        SelectCat()
        If Not RS.EOF Then
            Do Until RS.EOF
                cboSelectCategory.Items.Add(RS.Fields("cat_name").Value)
                cboProdCatUP.Items.Add(RS.Fields("cat_name").Value)
                cboSearchAP.Items.Add(RS.Fields("cat_name").Value)
                cboSearchPA.Items.Add(RS.Fields("cat_name").Value)
                cboSearchUP.Items.Add(RS.Fields("cat_name").Value)
                RS.MoveNext()
            Loop
        End If
    End Sub

    Public Sub refreshProdList()
        lvwProdListAP.Clear()
        lvwProdListPA.Clear()
        lvwProdListUP.Clear()

        lvwProdListAP.Columns.Add("Description", 250)
        lvwProdListAP.Columns.Add("Price", 150)
        lvwProdListAP.Columns.Add("Stock", 150)

        lvwProdListPA.Columns.Add("ID", 0)
        lvwProdListPA.Columns.Add("Description", 250)
        lvwProdListPA.Columns.Add("Price", 150)
        lvwProdListPA.Columns.Add("Stock", 150)

        lvwProdListUP.Columns.Add("ID", 0)
        lvwProdListUP.Columns.Add("Description", 250)
        lvwProdListUP.Columns.Add("Price", 150)
        lvwProdListUP.Columns.Add("Stock", 150)
        Dim list As New ListViewItem

        SelectProd()
        If Not RS.EOF Then
            Do Until RS.EOF
                list = lvwProdListAP.Items.Add(RS.Fields("prod_name").Value)
                list.SubItems.Add(RS.Fields("prod_price").Value)
                list.SubItems.Add(RS.Fields("prod_stock").Value)

                list = lvwProdListPA.Items.Add(RS.Fields("PID").Value)
                list.SubItems.Add(RS.Fields("prod_name").Value)
                list.SubItems.Add(RS.Fields("prod_price").Value)
                list.SubItems.Add(RS.Fields("prod_stock").Value)

                list = lvwProdListUP.Items.Add(RS.Fields("PID").Value)
                list.SubItems.Add(RS.Fields("prod_name").Value)
                list.SubItems.Add(RS.Fields("prod_price").Value)
                list.SubItems.Add(RS.Fields("prod_stock").Value)
                RS.MoveNext()
            Loop
        End If
    End Sub

    Private Sub btnClearAP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearAP.Click
        clearADD()
    End Sub

    Private Sub clearADD()
        cboSelectCategory.Text = Nothing
        txtProdCodeAP.Clear()
        txtProdNameAP.Clear()
        txtProdPriceAP.Clear()
        txtProdNameAP.Focus()
    End Sub

    Private Sub btnAddProduct_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddProduct.Click
        checkCode(txtProdCodeAP.Text)
        If RS.EOF Then
            If String.IsNullOrEmpty(cboSelectCategory.Text) Then
                MessageBox.Show("Please enter a category.", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Error)
                cboSelectCategory.Focus()
            ElseIf String.IsNullOrEmpty(txtProdNameAP.Text) Then
                MessageBox.Show("Please enter a productname.", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtProdNameAP.Focus()
            ElseIf String.IsNullOrEmpty(txtProdCodeAP.Text) Then
                MessageBox.Show("Please enter a productcode.", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtProdCodeAP.Focus()
            ElseIf Not IsNumeric(txtProdCodeAP.Text) Then
                MessageBox.Show("Invalid product code input. Please check your code", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtProdCodeAP.SelectAll()
                txtProdCodeAP.Focus()
            ElseIf Not txtProdCodeAP.Text.Length = 13 Then
                MessageBox.Show("Invalid product code input. Please check your code", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtProdCodeAP.SelectAll()
                txtProdCodeAP.Focus()
            ElseIf String.IsNullOrEmpty(txtProdPriceAP.Text) Then
                MessageBox.Show("Please enter a price.", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtProdPriceAP.Focus()
            ElseIf Not IsNumeric(txtProdPriceAP.Text) Then
                MessageBox.Show("Invalid price input.", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtProdPriceAP.SelectAll()
                txtProdPriceAP.Focus()
            Else
                GetCatID(cboSelectCategory.Text)
                AddProduct(txtProdNameAP.Text, txtProdCodeAP.Text, RS.Fields("cat_ID").Value, txtProdPriceAP.Text)
                refreshProdList()
                clearADD()
            End If
        Else
            MessageBox.Show("Product code already exist.", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtProdCodeUP.SelectAll()
            txtProdCodeUP.Focus()
        End If
    End Sub

    Private Sub getList()
        Try
            prodID = CInt(lvwProdListUP.SelectedItems(0).Text)
            GetProductInfo(prodID)
            If Not RS.EOF Then
                txtProdCodeUP.Text = RS.Fields("prod_code").Value
                txtProdNameUP.Text = RS.Fields("prod_name").Value
                txtProdPriceUP.Text = RS.Fields("prod_price").Value
                GetCatName(RS.Fields("prod_cat").Value)
                cboProdCatUP.Text = RS.Fields("cat_name").Value
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub lvwProdListUP_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvwProdListUP.Click
        getList()
    End Sub

    Private Sub lvwProdListUP_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lvwProdListUP.KeyDown
        getList()
    End Sub

    Private Sub lvwProdListUP_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lvwProdListUP.KeyUp
        getList()
    End Sub

    Private Sub btnClearUP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearUP.Click
        clearUP()
    End Sub
    Private Sub clearUP()
        cboProdCatUP.Text = Nothing
        txtProdCodeUP.Clear()
        txtProdNameUP.Clear()
        txtProdPriceUP.Clear()
        prodID = Nothing
        lvwProdListUP.Update()
    End Sub

    Private Sub btnUpdateProd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdateProd.Click
        If Not prodID = Nothing Then
            checkCode2(txtProdCodeUP.Text, prodID)
            If RS.EOF Then
                If String.IsNullOrEmpty(cboProdCatUP.Text) Then
                    MessageBox.Show("Please enter a category.", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    cboProdCatUP.Focus()
                ElseIf String.IsNullOrEmpty(txtProdNameUP.Text) Then
                    MessageBox.Show("Please enter a productname.", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    txtProdNameUP.Focus()
                ElseIf String.IsNullOrEmpty(txtProdCodeUP.Text) Then
                    MessageBox.Show("Please enter a productcode.", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    txtProdCodeUP.Focus()
                ElseIf Not IsNumeric(txtProdCodeUP.Text) Then
                    MessageBox.Show("Invalid product code input. Please check your code", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    txtProdCodeUP.SelectAll()
                    txtProdCodeUP.Focus()
                ElseIf Not txtProdCodeUP.Text.Length = 13 Then
                    MessageBox.Show("Invalid product code input. Please check your code", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    txtProdCodeUP.SelectAll()
                    txtProdCodeUP.Focus()
                ElseIf String.IsNullOrEmpty(txtProdPriceUP.Text) Then
                    MessageBox.Show("Please enter a price.", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    txtProdPriceUP.Focus()
                ElseIf Not IsNumeric(txtProdPriceUP.Text) Then
                    MessageBox.Show("Invalid price input.", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    txtProdPriceUP.SelectAll()
                    txtProdPriceUP.Focus()
                Else
                    GetCatID(cboProdCatUP.Text)
                    UpdateProd(prodID, txtProdNameUP.Text, txtProdCodeUP.Text, RS.Fields("cat_ID").Value, txtProdPriceUP.Text)
                    clearUP()
                    refreshProdList()
                End If
            Else
                MessageBox.Show("Product code already exist.", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtProdCodeUP.SelectAll()
                txtProdCodeUP.Focus()
            End If
        End If
    End Sub

    Private Sub btnClearPA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearPA.Click
        clearSA()
    End Sub

    Private Sub clearSA()
        lblProdCat.ResetText()
        lblProdCode.ResetText()
        lblProdPrice.ResetText()
        lblProdName.ResetText()
        lblAvailable.ResetText()
        lblTotalStock.ResetText()
        txtAdditional.Clear()
        cboSBatch.Text = Nothing
        dtpExpiration.Value = Now
        prodID = Nothing
    End Sub

    Private Sub getStockList()
        Try
            prodID = CInt(lvwProdListPA.SelectedItems(0).Text)
            GetProductInfo(prodID)
            If Not RS.EOF Then
                lblAvailable.Text = RS.Fields("prod_stock").Value
                lblProdCode.Text = RS.Fields("prod_code").Value
                lblProdName.Text = RS.Fields("prod_name").Value
                lblProdPrice.Text = RS.Fields("prod_price").Value
                lblTotalStock.Text = RS.Fields("prod_stock").Value
                GetCatName(RS.Fields("prod_cat").Value)
                lblProdCat.Text = RS.Fields("cat_name").Value
                txtAdditional.Clear()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub lvwProdListPA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvwProdListPA.Click
        getStockList()
    End Sub

    Private Sub txtAdditional_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAdditional.TextChanged
        Try
            If IsNumeric(txtAdditional.Text) And Not String.IsNullOrEmpty(lblAvailable.Text) Then
                Dim sum As Integer = CInt(txtAdditional.Text) + CInt(lblAvailable.Text)
                If sum > CInt(lblAvailable.Text) Then
                    lblTotalStock.Text = sum.ToString
                    btnAddStock.Enabled = True
                    lblError.Visible = False
                Else
                    btnAddStock.Enabled = False
                    lblError.Visible = True
                End If
            Else
                btnAddStock.Enabled = False
                lblError.Visible = True
                If txtAdditional.Text = Nothing Or lblAvailable.Text = Nothing Then
                    lblTotalStock.Text = lblAvailable.Text
                    lblError.Visible = False
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Input too big", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Private Sub lvwProdListPA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lvwProdListPA.KeyDown
        getStockList()
    End Sub

    Private Sub lvwProdListPA_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lvwProdListPA.KeyUp
        getStockList()
    End Sub

    Private Sub btnAddStock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddStock.Click
        If dtpExpiration.Value <= Now Then
            MessageBox.Show("Product is expired!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            dtpExpiration.Focus()
        ElseIf String.IsNullOrEmpty(cboSBatch.Text) Then
            MessageBox.Show("Please select batch id!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboSBatch.Focus()
        Else
            AddStock(prodID, CInt(lblTotalStock.Text))
            AddDelivery(prodID, txtAdditional.Text, dtpExpiration.Text, cboSBatch.Text)
            refreshProdList()
            clearSA()
        End If
    End Sub

    Private Sub cboSearchPA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSearchPA.SelectedIndexChanged
        SearchCat(cboSearchPA.Text)
        searchPA()
    End Sub

    Private Sub cboSearchPA_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboSearchPA.TextChanged
        SelectProdByInput(cboSearchPA.Text)
        searchPA()
    End Sub

    Private Sub cboSearchUP_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSearchUP.SelectedIndexChanged
        SearchCat(cboSearchUP.Text)
        searchUP()
    End Sub

    Private Sub cboSearchUP_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboSearchUP.TextChanged
        SelectProdByInput(cboSearchUP.Text)
        searchUP()
    End Sub

    Private Sub cboSearchAP_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSearchAP.SelectedIndexChanged
        SearchCat(cboSearchAP.Text)
        searchAP()
    End Sub

    Private Sub cboSearchAP_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboSearchAP.TextChanged
        SelectProdByInput(cboSearchAP.Text)
        searchAP()
    End Sub

    Private Sub searchPA()
        If cboSearchPA.Text = "All" Then
            refreshProdList()
        Else
            lvwProdListPA.Clear()

            lvwProdListPA.Columns.Add("ID", 0)
            lvwProdListPA.Columns.Add("Description", 250)
            lvwProdListPA.Columns.Add("Price", 150)
            lvwProdListPA.Columns.Add("Stock", 150)

            Dim list As New ListViewItem

            If Not RS.EOF Then
                Do Until RS.EOF
                    list = lvwProdListPA.Items.Add(RS.Fields("PID").Value)
                    list.SubItems.Add(RS.Fields("prod_name").Value)
                    list.SubItems.Add(RS.Fields("prod_price").Value)
                    list.SubItems.Add(RS.Fields("prod_stock").Value)
                    RS.MoveNext()
                Loop
            End If
        End If
    End Sub

    Private Sub searchUP()
        If cboSearchUP.Text = "All" Then
            refreshProdList()
        Else
            lvwProdListUP.Clear()

            lvwProdListUP.Columns.Add("ID", 0)
            lvwProdListUP.Columns.Add("Description", 250)
            lvwProdListUP.Columns.Add("Price", 150)
            lvwProdListUP.Columns.Add("Stock", 150)

            Dim list As New ListViewItem

            If Not RS.EOF Then
                Do Until RS.EOF
                    list = lvwProdListUP.Items.Add(RS.Fields("PID").Value)
                    list.SubItems.Add(RS.Fields("prod_name").Value)
                    list.SubItems.Add(RS.Fields("prod_price").Value)
                    list.SubItems.Add(RS.Fields("prod_stock").Value)
                    RS.MoveNext()
                Loop
            End If
        End If
    End Sub

    Private Sub searchAP()
        If cboSearchAP.Text = "All" Then
            refreshProdList()
        Else
            lvwProdListAP.Clear()

            lvwProdListAP.Columns.Add("ID", 0)
            lvwProdListAP.Columns.Add("Description", 250)
            lvwProdListAP.Columns.Add("Price", 150)
            lvwProdListAP.Columns.Add("Stock", 150)

            Dim list As New ListViewItem

            If Not RS.EOF Then
                Do Until RS.EOF
                    list = lvwProdListAP.Items.Add(RS.Fields("PID").Value)
                    list.SubItems.Add(RS.Fields("prod_name").Value)
                    list.SubItems.Add(RS.Fields("prod_price").Value)
                    list.SubItems.Add(RS.Fields("prod_stock").Value)
                    RS.MoveNext()
                Loop
            End If
        End If
    End Sub

    Private Sub tbProducts_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbProducts.Click
        clearADD()
        clearSA()
        clearUP()
        clearBatch()
    End Sub

    Private Sub openImage()
        Dim result As DialogResult
        result = OpenFileDialog1.ShowDialog
        If result = DialogResult.OK Then
            If add = True Then
                pbEmp.ImageLocation = OpenFileDialog1.FileName
            Else
                pbImageUpdate.ImageLocation = OpenFileDialog1.FileName
            End If
            imageLocation = OpenFileDialog1.FileName
            retVal = True
        Else
            retVal = False
        End If
    End Sub
    Private Sub btnUpload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpload.Click
        add = True
        openImage()
    End Sub

    Public Sub saveImage()
        If retVal = False Then
            If add = False Then
                Exit Sub
            Else
                My.Computer.FileSystem.CopyFile(My.Computer.FileSystem.CurrentDirectory & "\he.png", My.Computer.FileSystem.CurrentDirectory & "\files\he.png")
                My.Computer.FileSystem.RenameFile(My.Computer.FileSystem.CurrentDirectory & "\files\he.png", lblIDno.Text & ".png")
                defaultPhoto = lblIDno.Text & ".png"
                imgName = lblIDno.Text & ".png"
            End If
        Else
            If add = False Then
                checkPic(lblIdUpdate.Text)
                If Not RS.EOF Then
                    My.Computer.FileSystem.DeleteFile(My.Computer.FileSystem.CurrentDirectory & "\files\" & RS.Fields("emp_pic").Value)
                End If
            End If

            My.Computer.FileSystem.CopyFile(OpenFileDialog1.FileName, My.Computer.FileSystem.CurrentDirectory & "\files\" & OpenFileDialog1.SafeFileName)
            Dim fileLength As Integer = Len(OpenFileDialog1.SafeFileName)
            Dim x As Integer = 1
            Do While x <= fileLength
                extHolder = Microsoft.VisualBasic.Right(OpenFileDialog1.SafeFileName, x)
                If extHolder.Contains(".") Then
                    x = fileLength + 1
                End If
                x = x + 1
            Loop

            If add = True Then
                My.Computer.FileSystem.RenameFile(My.Computer.FileSystem.CurrentDirectory & "\files\" & OpenFileDialog1.SafeFileName, lblIDno.Text & extHolder)
                imgName = lblIDno.Text & extHolder
            Else
                My.Computer.FileSystem.RenameFile(My.Computer.FileSystem.CurrentDirectory & "\files\" & OpenFileDialog1.SafeFileName, lblIdUpdate.Text & extHolder)
                imgName = lblIdUpdate.Text & extHolder
            End If
        End If
    End Sub

    Private Sub btnClearEmp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearEmp.Click
        clearAddEmp()
        clearUpdateEmp()
    End Sub

    Private Sub clearAddEmp()
        lblIDno.ResetText()
        txtFn.Clear()
        txtLn.Clear()
        txtMn.Clear()
        txtAddress.Clear()
        txtUserName.Clear()
        txtPass.Clear()
        txtRepeatPass.Clear()
        cboPosition.Text = Nothing
        dtpDOB.Text = Now
        dtpDateHired.Text = Now
        rdoFemale.Checked = False
        rdoMale.Checked = False
        pbEmp.ImageLocation = My.Computer.FileSystem.CurrentDirectory & "\he.png"
        imageLocation = My.Computer.FileSystem.CurrentDirectory & "\he.png"
    End Sub

    Private Sub clearUpdateEmp()
        lblIdUpdate.ResetText()
        txtFNUpdate.Clear()
        txtMNUpdate.Clear()
        txtAddressUpdate.Clear()
        txtLNUpdate.Clear()
        dtpDOBUpdate.Value = Now.ToShortDateString
        rdoFemaleUpdate.Checked = False
        rdoMaleUpdate.Checked = False
        pbImageUpdate.ImageLocation = My.Computer.FileSystem.CurrentDirectory & "\he.png"
        imageLocation = My.Computer.FileSystem.CurrentDirectory & "\he.png"
        empID = Nothing 
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        clearAddEmp()
        clearUpdateEmp()
        empID = Nothing
    End Sub

    Private Sub Timer1_Tick_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        staTimer.Text = FormatDateTime(Now, DateFormat.LongTime)
        staDate.Text = FormatDateTime(Now, DateFormat.LongDate)
        frmCashier.lblTime.Text = FormatDateTime(Now, DateFormat.LongTime)
        frmCashier.lblDate.Text = FormatDateTime(Now, DateFormat.LongDate)
    End Sub

    Private Sub btnAddEmp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddEmp.Click
        If String.IsNullOrEmpty(txtFn.Text) Then
            MessageBox.Show("Please enter your firstname.", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtFn.Focus()
        ElseIf String.IsNullOrEmpty(txtMn.Text) Then
            MessageBox.Show("Please enter your middletname.", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtMn.Focus()
        ElseIf String.IsNullOrEmpty(txtLn.Text) Then
            MessageBox.Show("Please enter your lasttname.", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtLn.Focus()
        ElseIf String.IsNullOrEmpty(txtAddress.Text) Then
            MessageBox.Show("Please enter your adddress.", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtAddress.Focus()
        ElseIf dtpDOB.Value.Year > Now.Year - 19 Then
            MessageBox.Show("Date of birth not accepted.", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Error)
            dtpDOB.Focus()
        ElseIf dtpDateHired.Value.ToShortDateString > Now Then
            MessageBox.Show("Invalid date of hire.", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Error)
            dtpDateHired.Focus()
        ElseIf String.IsNullOrEmpty(txtUserName.Text) Then
            MessageBox.Show("Please enter your username.", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtUserName.Focus()
        ElseIf String.IsNullOrEmpty(txtPass.Text) Then
            MessageBox.Show("Please enter your password.", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtPass.Focus()
        ElseIf String.IsNullOrEmpty(txtRepeatPass.Text) Then
            MessageBox.Show("Please retpye your password.", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtRepeatPass.Focus()
        ElseIf rdoFemale.Checked = False And rdoMale.Checked = False Then
            MessageBox.Show("Please enter your gender.", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtRepeatPass.Focus()
        Else
            Dim gender As String
            If dtpDOB.Value.Month.ToString.Length = 2 Then
                part2 = dtpDOB.Value.Month
            Else
                part2 = "0" & dtpDOB.Value.Month
            End If
            If dtpDOB.Value.Day.ToString.Length = 2 Then
                part6 = dtpDOB.Value.Day
            Else
                part6 = "0" & dtpDOB.Value.Day
            End If
            part5 = dtpDateHired.Value.Year & "-"
            lblIDno.Text = part5 & part1 & part2 & part6 & part3 & part4
            getPosID(cboPosition.Text)
            If rdoFemale.Checked = True Then
                gender = "Female"
            Else
                gender = "Male"
            End If
            If Not RS.EOF Then
                add = True
                saveImage()
                saveEmp(lblIDno.Text, txtFn.Text, txtLn.Text, txtMn.Text, txtAddress.Text, dtpDOB.Text, dtpDateHired.Text, RS.Fields("PosID").Value, txtUserName.Text, txtPass.Text, imgName, gender)
                clearAddEmp()
                SelectEmp()
                refreshEmpList()
                SelectEmp()
                refreshEmpListUpdate()
            End If
        End If
    End Sub

    Private Sub txtFn_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFn.LostFocus
        part3 = Microsoft.VisualBasic.Left(txtFn.Text, 1)
        lblIDno.Text = part5 & part1 & part2 & part6 & part3 & part4
    End Sub

    Private Sub txtMn_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMn.LostFocus
        part4 = Microsoft.VisualBasic.Left(txtMn.Text, 1)
        lblIDno.Text = part5 & part1 & part2 & part6 & part3 & part4
    End Sub

    Private Sub txtLn_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtLn.LostFocus
        part1 = Microsoft.VisualBasic.Left(txtLn.Text, 1)
        lblIDno.Text = part5 & part1 & part2 & part6 & part3 & part4
    End Sub

    Private Sub dtpDOB_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpDOB.LostFocus
        If dtpDOB.Value.Month.ToString.Length = 2 Then
            part2 = dtpDOB.Value.Month
        Else
            part2 = "0" & dtpDOB.Value.Month
        End If
        If dtpDOB.Value.Day.ToString.Length = 2 Then
            part6 = dtpDOB.Value.Day
        Else
            part6 = "0" & dtpDOB.Value.Day
        End If
        lblIDno.Text = part5 & part1 & part2 & part6 & part3 & part4
    End Sub

    Private Sub dtpDateHired_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpDateHired.LostFocus
        part5 = dtpDateHired.Value.Year & "-"
        lblIDno.Text = part5 & part1 & part2 & part6 & part3 & part4
    End Sub

    Private Sub refcboEmp()
        cboPosition.Items.Clear()
        getPosition()
        If Not RS.EOF Then
            Do Until RS.EOF
                cboPosition.Items.Add(RS.Fields("PosName").Value)
                RS.MoveNext()
            Loop
        End If
    End Sub

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        If empID = Nothing Then
            MessageBox.Show("Please select an employee", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf String.IsNullOrEmpty(txtFNUpdate.Text) Then
            MessageBox.Show("Please enter your firstname", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtFNUpdate.Focus()
        ElseIf String.IsNullOrEmpty(txtLNUpdate.Text) Then
            MessageBox.Show("Please enter your lastname", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtLNUpdate.Focus()
        ElseIf String.IsNullOrEmpty(txtMNUpdate.Text) Then
            MessageBox.Show("Please enter your middlename", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtMNUpdate.Focus()
        ElseIf String.IsNullOrEmpty(txtAddressUpdate.Text) Then
            MessageBox.Show("Please enter your Address", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtAddressUpdate.Focus()
        ElseIf dtpDOBUpdate.Value.Year > Now.Year - 19 Then
            MessageBox.Show("Date of birth not accepted", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Error)
            dtpDOBUpdate.Focus()
        Else
            add = False
            saveImage()
            Dim gender As String
            If rdoFemaleUpdate.Checked = True Then
                gender = "Female"
            Else
                gender = "Male"
            End If
            UpdateEmp(empID, txtFNUpdate.Text, txtLNUpdate.Text, txtMNUpdate.Text, txtAddressUpdate.Text, dtpDOBUpdate.Value.ToShortDateString, gender, imgName)
            SelectEmp()
            refreshEmpList()
            SelectEmp()
            refreshEmpListUpdate()
            If empID = UserID Then
                getAllEmp(empID)
                lblEmpName.Text = RS.Fields("emp_Lname").Value & ", " & RS.Fields("emp_Fname").Value & " " & Microsoft.VisualBasic.Left(RS.Fields("emp_Mname").Value, 1) & "."
                lblAddress.Text = RS.Fields("emp_Address").Value
                lblGender.Text = RS.Fields("emp_Gender").Value
                lbUID.Text = RS.Fields("emp_id").Value
                pbUserPic.ImageLocation = My.Computer.FileSystem.CurrentDirectory & "\files\" & RS.Fields("emp_pic").Value
            End If
            clearUpdateEmp()
        End If
    End Sub

    Private Sub btnChanePic_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChanePic.Click
        add = False
        openImage()
    End Sub

    Private Sub btnClearUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearUpdate.Click
        clearUpdateEmp()
    End Sub

    Private Sub lvwEmpListUpdate_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lvwEmpListUpdate.KeyDown
        getEmpInfo()
    End Sub

    Private Sub lvwEmpListUpdate_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lvwEmpListUpdate.KeyUp
        getEmpInfo()
    End Sub

    Private Sub lvwEmpListUpdate_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvwEmpListUpdate.SelectedIndexChanged
        getEmpInfo()
    End Sub

    Private Sub getEmpInfo()
        Try
            empID = lvwEmpListUpdate.SelectedItems(0).Text
            getAllEmp(empID)
            If Not RS.EOF Then
                lblIdUpdate.Text = empID
                txtFNUpdate.Text = RS.Fields("emp_Fname").Value
                txtLNUpdate.Text = RS.Fields("emp_Lname").Value
                txtMNUpdate.Text = RS.Fields("emp_Mname").Value
                txtAddressUpdate.Text = RS.Fields("emp_Address").Value
                dtpDOBUpdate.Value = RS.Fields("emp_Bdate").Value
                If RS.Fields("emp_Gender").Value.ToString = "Male" Then
                    rdoMaleUpdate.Checked = True
                Else
                    rdoFemaleUpdate.Checked = True
                End If
                pbImageUpdate.ImageLocation = My.Computer.FileSystem.CurrentDirectory & "\files\" & RS.Fields("emp_pic").Value
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub tsmTitle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmTitle.Click
        panelsDisable()
        pnlHome.Enabled = True
        pnlHome.BringToFront()
        lblDescription.Text = "Welcome to POS manage and monitor" & vbNewLine & "your sales in an easy way."
    End Sub

    Public Sub refreshEmpListUpdate()
        lvwEmpListUpdate.Clear()

        lvwEmpListUpdate.Columns.Add("ID", 100)
        lvwEmpListUpdate.Columns.Add("Name", 200)
        lvwEmpListUpdate.Columns.Add("Date of birth", 100)
        lvwEmpListUpdate.Columns.Add("Address", 150)
        Dim list As New ListViewItem
        If Not RS.EOF Then
            Do Until RS.EOF
                list = lvwEmpListUpdate.Items.Add(RS.Fields("emp_id").Value)
                list.SubItems.Add(RS.Fields("emp_Lname").Value & ", " & RS.Fields("emp_Fname").Value & " " & Microsoft.VisualBasic.Left(RS.Fields("emp_Mname").Value, 1) & ".")
                list.SubItems.Add(RS.Fields("emp_Bdate").Value)
                list.SubItems.Add(RS.Fields("emp_Address").Value)
                RS.MoveNext()
            Loop
        End If
    End Sub

    Public Sub refreshEmpList()
        lvwAddEmp.Clear()

        lvwAddEmp.Columns.Add("ID", 100)
        lvwAddEmp.Columns.Add("Name", 200)
        lvwAddEmp.Columns.Add("Date of birth", 100)
        lvwAddEmp.Columns.Add("Address", 150)
        Dim list As New ListViewItem

        If Not RS.EOF Then
            Do Until RS.EOF
                list = lvwAddEmp.Items.Add(RS.Fields("emp_id").Value)
                list.SubItems.Add(RS.Fields("emp_Lname").Value & ", " & RS.Fields("emp_Fname").Value & " " & Microsoft.VisualBasic.Left(RS.Fields("emp_Mname").Value, 1) & ".")
                list.SubItems.Add(RS.Fields("emp_Bdate").Value)
                list.SubItems.Add(RS.Fields("emp_Address").Value)
                RS.MoveNext()
            Loop
        End If
    End Sub

    Private Sub cboempFilter2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboempFilter2.SelectedIndexChanged
        If cboempFilter2.Text = "All" Then
            SelectEmp()
        Else
            SearchPos(cboempFilter2.Text)
        End If
        refreshEmpListUpdate()
    End Sub

    Private Sub cboempFilter2_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboempFilter2.TextChanged
        getEmpByInput(cboempFilter2.Text)
        refreshEmpListUpdate()
    End Sub

    Private Sub cboempFilter1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboempFilter1.SelectedIndexChanged
        If cboempFilter1.Text = "All" Then
            SelectEmp()
        Else
            SearchPos(cboempFilter1.Text)
        End If
        refreshEmpList()
    End Sub

    Private Sub cboempFilter1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboempFilter1.TextChanged
        getEmpByInput(cboempFilter1.Text)
        refreshEmpList()
    End Sub

    Private Sub rdoDaily_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoDaily.CheckedChanged
        gpSales.Visible = True
        gpFilter.Visible = False
        gpProduct.Visible = False
        lblReport.Text = "DAILY REPORT"
        lblNet.Visible = True
        lblTotal.Visible = True
        Button4.Visible = True
        dailyReport()
    End Sub

    Public Sub dailyReport()
        Dim t As Double
        If rdoDaily.Checked Then
            lvwReport.Clear()
            lvwReport.Columns.Add("Transaction No.", 140)
            lvwReport.Columns.Add("Cashier", 160)
            lvwReport.Columns.Add("Product Name", 180)
            lvwReport.Columns.Add("Items Sold", 100)
            lvwReport.Columns.Add("Total", 100)
            Dim list As New ListViewItem
            t = 0
            Dim tt As Double
            If rdoTransNum.Checked Then
                getTrans2(dtpReport.Value.ToShortDateString)
            Else
                getTrans3(dtpReport.Value.ToShortDateString)
            End If
            If Not RS.EOF Then
                Do Until RS.EOF
                    tt = RS.Fields("quantity").Value * RS.Fields("prod_price").Value
                    list = lvwReport.Items.Add(RS.Fields("transNum").Value)
                    list.SubItems.Add(RS.Fields("empID").Value)
                    list.SubItems.Add(RS.Fields("prod_name").Value)
                    list.SubItems.Add(RS.Fields("quantity").Value)
                    list.SubItems.Add(tt)
                    t = t + tt
                    RS.MoveNext()
                Loop
            End If
        ElseIf rdoMonthly.Checked Then
            lvwReport.Clear()
            lvwReport.Columns.Add("Transaction No.", 120)
            lvwReport.Columns.Add("Cashier", 140)
            lvwReport.Columns.Add("Product Name", 160)
            lvwReport.Columns.Add("Items Sold", 90)
            lvwReport.Columns.Add("Total", 60)
            lvwReport.Columns.Add("Trans Date", 110)
            Dim list As New ListViewItem
            t = 0
            Dim c As Integer = 1
            Dim tt As Double
            Do Until c = 31
                If rdoTransNum.Checked Then
                    getTrans4(dtpReport.Value.Month & "/" & c & "/" & dtpReport.Value.Year)
                Else
                    getTrans5(dtpReport.Value.Month & "/" & c & "/" & dtpReport.Value.Year)
                End If
                If Not RS.EOF Then
                    Do Until RS.EOF
                        tt = RS.Fields("quantity").Value * RS.Fields("prod_price").Value
                        list = lvwReport.Items.Add(RS.Fields("transNum").Value)
                        list.SubItems.Add(RS.Fields("empID").Value)
                        list.SubItems.Add(RS.Fields("prod_name").Value)
                        list.SubItems.Add(RS.Fields("quantity").Value)
                        list.SubItems.Add(tt)
                        list.SubItems.Add(RS.Fields("transdate").Value)
                        t = t + tt
                        RS.MoveNext()
                    Loop
                End If
                c += 1
            Loop
        ElseIf rdoDeliver.Checked Then
            lvwReport.Clear()
            lvwReport.Columns.Add("Batch ID.", 170)
            lvwReport.Columns.Add("Batch Name", 240)
            lvwReport.Columns.Add("Date", 120)
            lvwReport.Columns.Add("Time", 150)
            Dim l As New ListViewItem
            Dim c As Integer = 31
            Do Until c = 1
                getDelivery(dtpReport.Value.Month & "/" & c & "/" & dtpReport.Value.Year)
                If Not RS.EOF Then
                    Do Until RS.EOF
                        l = lvwReport.Items.Add(RS.Fields("batch_id").Value)
                        l.SubItems.Add(RS.Fields("batch_name").Value)
                        l.SubItems.Add(RS.Fields("delivery_date").Value)
                        l.SubItems.Add(RS.Fields("delivery_time").Value)
                        RS.MoveNext()
                    Loop
                End If
                c -= 1
            Loop
        End If
        lblTotal.Text = t
    End Sub

    Private Sub rdoDeliver_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoDeliver.CheckedChanged
        gpSales.Visible = True
        gpFilter.Visible = False
        gpProduct.Visible = False
        lblReport.Text = "DELIVERY REPORT"
        lblNet.Visible = False
        lblTotal.Visible = False
        Button4.Visible = True
        dailyReport()
    End Sub

    Private Sub rdoMonthly_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoMonthly.CheckedChanged
        gpSales.Visible = True
        gpFilter.Visible = False
        gpProduct.Visible = False
        lblReport.Text = "MONTHLY REPORT"
        lblNet.Visible = True
        lblTotal.Visible = True
        Button4.Visible = True
        dailyReport()
    End Sub

    Private Sub rdoProduct_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoProduct.CheckedChanged
        gpSales.Visible = False
        gpFilter.Visible = True
        gpProduct.Visible = True
        lblReport.Text = "PRODUCT AVAILABILTY REPORT"
        lblNet.Visible = False
        lblTotal.Visible = False
        Button4.Visible = False
        prod()
    End Sub

    Private Sub prod()
        If rdoProduct.Checked Then
            lvwReport.Clear()
            lvwReport.Columns.Add("Product Code.", 150)
            lvwReport.Columns.Add("Product Name", 190)
            lvwReport.Columns.Add("Price", 80)
            lvwReport.Columns.Add("Available Stock", 130)
            lvwReport.Columns.Add("Expiration Date", 130)
            Dim list As New ListViewItem
            If rdoPcode.Checked Then
                If rdoAll.Checked Then
                    getProd1()
                ElseIf rdoLow.Checked Then
                    getProd2()
                ElseIf rdoOut.Checked Then
                    getProd3()
                End If
            ElseIf rdoPname.Checked Then
                If rdoAll.Checked Then
                    getProd4()
                ElseIf rdoLow.Checked Then
                    getProd5()
                ElseIf rdoOut.Checked Then
                    getProd6()
                End If
            ElseIf rdoExp.Checked Then
                If rdoAll.Checked Then
                    getProd7()
                ElseIf rdoLow.Checked Then
                    getProd8()
                ElseIf rdoOut.Checked Then
                    getProd9()
                End If
            End If
        If Not RS.EOF Then
            Do Until RS.EOF
                List = lvwReport.Items.Add(RS.Fields("prod_code").Value)
                List.SubItems.Add(RS.Fields("prod_name").Value)
                List.SubItems.Add(RS.Fields("prod_price").Value)
                List.SubItems.Add(RS.Fields("stock").Value)
                List.SubItems.Add(RS.Fields("exp_date").Value)
                RS.MoveNext()
            Loop
        End If
        End If
    End Sub

    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        resetReport()
    End Sub

    Private Sub resetReport()
        gpSales.Visible = True
        gpFilter.Visible = False
        gpProduct.Visible = False
        rdoDaily.Checked = True
        rdoPname.Checked = True
        rdoTransNum.Checked = True
        rdoAll.Checked = True
        lblNet.Visible = True
        lblTotal.Visible = True
        Button4.Visible = True
        dtpReport.Value = Now
    End Sub

    Private Sub Label36_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label36.Click
        frmCashier.Show()
        Me.Hide()
    End Sub

    Private Sub Label36_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label36.MouseEnter
        Label36.ForeColor = Color.White
        Label36.Cursor = Cursors.Hand
    End Sub

    Private Sub Label36_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label36.MouseLeave
        Label36.ForeColor = Color.Gainsboro
        Label36.Cursor = Cursors.Arrow
    End Sub

    Private Sub rdoTransNum_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoTransNum.CheckedChanged
        dailyReport()
    End Sub

    Private Sub rdoEmployee_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoEmployee.CheckedChanged
        dailyReport()
    End Sub

    Private Sub dtpReport_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpReport.ValueChanged
        dailyReport()
    End Sub

    Private Sub rdoPname_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoPname.CheckedChanged
        prod()
    End Sub

    Private Sub rdoPcode_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoPcode.CheckedChanged
        prod()
    End Sub

    Private Sub rdoAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoAll.CheckedChanged
        prod()
    End Sub

    Private Sub rdoLow_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoLow.CheckedChanged

        prod()
    End Sub

    Private Sub rdoOut_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoOut.CheckedChanged
        prod()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        If lblReport.Text = "DELIVERY REPORT" Then
            Try
                bid = lvwReport.SelectedItems(0).Text
                frmdeliveries.ShowDialog()
            Catch ex As Exception
            End Try
        Else
            Try
                Dim pd As String = lvwReport.SelectedItems(0).Text
                getReceipt(pd)
                receipt = RS.Fields(0).Value
                frmPurchase.lblc.Visible = False
                frmPurchase.lblChange.Visible = False
                frmPurchase.ShowDialog()
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub tbProducts_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbProducts.SelectedIndexChanged
        createBatchId()
    End Sub
    Private Sub createBatchId()
        getBatch()
        Dim trans As String = ""
        Dim transNum As String
        If Not RS.EOF Then
            transNum = Microsoft.VisualBasic.Right(RS.Fields("batch_id").Value, 3)
            If Now.ToShortDateString = RS.Fields("delivery_date").Value Then
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
                Dim l As Integer = 3 - Len(num)
                Do Until c = l
                    trans = trans & "0"
                    c += 1
                Loop
                trans = trans & num
            Else
                trans = "001"
            End If
        Else
            trans = "001"
        End If
        transNum = Now.Year & "-" & Now.Day & "-" & Now.Month & "-" & trans
        txtBID.Text = transNum
    End Sub

    Private Sub btnAddBatch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddBatch.Click
        If String.IsNullOrEmpty(txtBname.Text) Then
            MessageBox.Show("Please enter a batch name.", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtBname.Focus()
        Else
            saveBatch(txtBID.Text, txtBname.Text, dtpDelivery.Text, dtpDeliveryTime.Text)
            createBatchId()
            refBatch()
        End If
    End Sub

    Private Sub refBatch()
        refcboBatch()
        With lvwBatch
            .Clear()
            .Columns.Add("id", 0)
            .Columns.Add("Batch ID", 150)
            .Columns.Add("Batch Name", 250)
            .Columns.Add("Delivery Date", 100)
            .Columns.Add("Delivery Time", 100)
            .Columns.Add("Status", 100)

            Dim lv As New ListViewItem

            getBatch2()
            If Not RS.EOF Then
                Do Until RS.EOF
                    lv = .Items.Add(RS.Fields("bid").Value)
                    lv.SubItems.Add(RS.Fields("batch_id").Value)
                    lv.SubItems.Add(RS.Fields("batch_name").Value)
                    lv.SubItems.Add(RS.Fields("delivery_date").Value)
                    lv.SubItems.Add(RS.Fields("delivery_time").Value)
                    lv.SubItems.Add(RS.Fields("status").Value)
                    RS.MoveNext()
                Loop
            End If
        End With
    End Sub

    Private Sub refcboBatch()
        With cboSBatch
            .Items.Clear()
            getBatch3()
            If Not RS.EOF Then
                Do Until RS.EOF
                    .Items.Add(RS.Fields("batch_id").Value)
                    RS.MoveNext()
                Loop
            End If
        End With
    End Sub

    Private Sub btnCloseBatch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCloseBatch.Click
        If lvwBatch.SelectedItems.Count > 0 Then
            closeBatch(lvwBatch.SelectedItems(0).Text)
            refBatch()
        Else
            MessageBox.Show("Please select a batch.", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub btnClearBatch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearBatch.Click
        clearBatch()
    End Sub

    Private Sub clearBatch()
        txtBname.Clear()
        dtpDelivery.Value = Now
        dtpDeliveryTime.Value = Now
    End Sub

    Private Sub rdoExp_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        prod()
    End Sub

    Private Sub PrintPreviewDialog1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintPreviewDialog1.Load
        PrintPreviewDialog1.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedDialog
        PrintPreviewDialog1.SetBounds(Me.Width * 0.05, Me.Height * 0.05, Me.Width * 0.9, Me.Height * 0.9)
        PrintPreviewDialog1.FormBorderStyle = Windows.Forms.FormBorderStyle.None
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        PrintPreviewDialog1.ShowDialog()
    End Sub


    Private Sub PrintDetails(ByRef e As System.Drawing.Printing.PrintPageEventArgs)
        Static LastIndex As Integer = 0
        Static CurrentPage As Integer = 0


        Dim DpiGraphics As Graphics = Me.CreateGraphics
        Dim DpiX As Integer = DpiGraphics.DpiX
        Dim DpiY As Integer = DpiGraphics.DpiY

        DpiGraphics.Dispose()

        Dim X, Y As Integer
        Dim ImageWidth As Integer
        Dim TextRect As Rectangle = Rectangle.Empty
        Dim TextLeftPad As Single = CSng(4 * (DpiX / 96)) '4 pixel pad on the left.
        Dim ColumnHeaderHeight As Single = CSng(lvwReport.Font.Height + (10 * (DpiX / 96))) '5 pixel pad on the top an bottom
        Dim StringFormat As New StringFormat
        Dim tex As Rectangle = Rectangle.Empty

        Dim PageNumberWidth As Single = e.Graphics.MeasureString(CStr(CurrentPage), lvwReport.Font).Width

        StringFormat.FormatFlags = StringFormatFlags.NoWrap
        StringFormat.Trimming = StringTrimming.EllipsisCharacter
        StringFormat.LineAlignment = StringAlignment.Center
        CurrentPage += 1

        tex.X = 366
        tex.Y = 75

        e.Graphics.DrawString("God Bless Store", lblReport.Font, Brushes.Black, tex, StringFormat)
        tex.X = 375
        tex.Y = 100
        e.Graphics.DrawString("Real St. Brgy. Cayare", Font, Brushes.Black, tex, StringFormat)
        tex.X = 385
        tex.Y = 120
        e.Graphics.DrawString("San Miguel, Leyte", Font, Brushes.Black, tex, StringFormat)
        tex.X = 695
        tex.Y = 160
        e.Graphics.DrawString("Date: " & Now.ToShortDateString, Font, Brushes.Black, tex, StringFormat)
        tex.X = 87
        tex.Y = 185
        e.Graphics.DrawString(lblReport.Text, lblReport.Font, Brushes.Black, tex, StringFormat)

        If lblReport.Text = "MONTHLY REPORT" Or lblReport.Text = "DAILY REPORT" Then
            tex.X = 665
            tex.Y = 190
            e.Graphics.DrawString("Sales Date: " & dtpReport.Value.ToShortDateString, Font, Brushes.Black, tex, StringFormat)
        End If


        X = CInt(e.MarginBounds.X) - 10
        Y = CInt(e.MarginBounds.Y) + 100

        For ColumnIndex As Integer = 0 To lvwReport.Columns.Count - 1
            TextRect.X = X
            TextRect.Y = Y
            TextRect.Width = lvwReport.Columns(ColumnIndex).Width
            TextRect.Height = ColumnHeaderHeight

            e.Graphics.DrawRectangle(Pens.Black, TextRect)

            TextRect.X += TextLeftPad
            TextRect.Width -= TextLeftPad

            e.Graphics.DrawString(lvwReport.Columns(ColumnIndex).Text, lvwReport.Font, Brushes.Black, TextRect, StringFormat)

            X += TextRect.Width + TextLeftPad
        Next


        Y += ColumnHeaderHeight

        For i = LastIndex To lvwReport.Items.Count - 1

            With lvwReport.Items(i)

                X = CInt(e.MarginBounds.X) - 10


                If Y + .Bounds.Height > e.MarginBounds.Bottom Then

                    LastIndex = i - 1
                    e.HasMorePages = True
                    StringFormat.Dispose()
                    e.Graphics.DrawString(CStr(CurrentPage), lvwReport.Font, Brushes.Black, (e.PageBounds.Width - PageNumberWidth) / 2, e.PageBounds.Bottom - lvwReport.Font.Height * 2)
                    Exit Sub
                End If

                ImageWidth = 0
                If lvwReport.SmallImageList IsNot Nothing Then

                    If Not String.IsNullOrEmpty(.ImageKey) Then
                        e.Graphics.DrawImage(lvwReport.SmallImageList.Images(.ImageKey), X, Y)
                    ElseIf .ImageIndex >= 0 Then
                        e.Graphics.DrawImage(lvwReport.SmallImageList.Images(.ImageIndex), X, Y)
                    End If

                    ImageWidth = lvwReport.SmallImageList.ImageSize.Width
                End If



                For ColumnIndex As Integer = 0 To lvwReport.Columns.Count - 1

                    TextRect.X = X
                    TextRect.Y = Y
                    TextRect.Width = lvwReport.Columns(ColumnIndex).Width
                    TextRect.Height = .Bounds.Height

                    If lvwReport.GridLines Then
                        e.Graphics.DrawRectangle(Pens.Black, TextRect)
                    End If

                    If ColumnIndex = 0 Then TextRect.X += ImageWidth

                    TextRect.X += TextLeftPad
                    TextRect.Width -= TextLeftPad

                    If ColumnIndex < .SubItems.Count Then

                        e.Graphics.DrawString(.SubItems(ColumnIndex).Text, lvwReport.Font, Brushes.Black, TextRect, StringFormat)
                    End If


                    X += TextRect.Width + TextLeftPad
                Next


                Y += .Bounds.Height

            End With
        Next
        tex.X = X - 150
        tex.Y = Y + 40
        e.Graphics.DrawString("Prepared By: ", Font, Brushes.Black, tex, StringFormat)
        tex.X = X - 135
        tex.Y = Y + 70
        e.Graphics.DrawString(logged, lblPrep.Font, Brushes.Black, tex, StringFormat)
        e.Graphics.DrawString(CStr(CurrentPage), lvwReport.Font, Brushes.Black, (e.PageBounds.Width - PageNumberWidth) / 2, e.PageBounds.Bottom - lvwReport.Font.Height * 2)
        StringFormat.Dispose()
        LastIndex = 0
        CurrentPage = 0
    End Sub

    Private Sub PrintDocument1_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Dim font1 As New Font("Times New Roman", 20, FontStyle.Regular)
        If lvwReport.View = View.Details Then
            PrintDetails(e)
        End If
    End Sub
End Class