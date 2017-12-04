Public Class frmLogin

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
        clearFields()
    End Sub

    Private Sub lblClose_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblClose.MouseEnter
        lblClose.BackColor = Color.LightSteelBlue
    End Sub

    Private Sub lblClose_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblClose.MouseLeave
        lblClose.BackColor = Color.White
    End Sub

    Private Sub lblClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblClose.Click
        Me.Close()
        clearFields()
    End Sub

    Private Sub btnCancel_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.GotFocus
        btn1()
    End Sub

    Private Sub btnCancel_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.LostFocus
        btn2()
    End Sub

    Private Sub btnCancel_MouseEnterr(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.MouseEnter
        btn1()
    End Sub

    Private Sub btnCancel_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.MouseLeave
        btn2()
    End Sub

    Private Sub btnLogin_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLogin.GotFocus
        btn3()
    End Sub

    Private Sub btnLogin_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLogin.LostFocus
        btn4()
    End Sub

    Private Sub btnLogin_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLogin.MouseEnter
        btn3()
    End Sub

    Private Sub btnLogin_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLogin.MouseLeave
        btn4()
    End Sub

    Private Sub btn1()
        btnCancel.BackColor = Color.LightSteelBlue
    End Sub

    Private Sub btn2()
        btnCancel.ForeColor = Color.RoyalBlue
        btnCancel.BackColor = Color.White
    End Sub

    Private Sub btn3()
        btnLogin.BackColor = Color.LightSteelBlue
    End Sub

    Private Sub btn4()
        btnLogin.ForeColor = Color.RoyalBlue
        btnLogin.BackColor = Color.White
    End Sub

    Private Sub btnLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogin.Click
        If String.IsNullOrEmpty(txtUser.Text) Then
            MessageBox.Show("Please enter username!", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtUser.Focus()
            txtUser.SelectAll()
        ElseIf String.IsNullOrEmpty(txtPass.Text) Then
            MessageBox.Show("Please enter password!", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtPass.Focus()
            txtPass.SelectAll()
        Else
            CheckInfo(txtUser.Text, txtPass.Text)
            If Not RS.EOF Then
                UserID = RS.Fields("emp_ID").Value
                getAllEmp(UserID)
                If Not RS.EOF Then
                    logged = RS.Fields("emp_Lname").Value & ", " & RS.Fields("emp_Fname").Value & " " & Microsoft.VisualBasic.Left(RS.Fields("emp_Mname").Value, 1) & "."
                    frmAdmin.lblUname.Visible = True
                    frmAdmin.lblEmpName.Visible = True
                    frmAdmin.pnlInfo.Visible = True
                    frmAdmin.pbUserPic.Visible = True
                    frmAdmin.lbUID.Visible = True
                    frmAdmin.pbUserPic.ImageLocation = My.Computer.FileSystem.CurrentDirectory & "/files/" & RS.Fields("emp_pic").Value
                    frmAdmin.lblUname.Text = "(" & txtUser.Text & ")"
                    frmAdmin.lblEmpName.Text = RS.Fields("emp_Lname").Value & ", " & RS.Fields("emp_Fname").Value & " " & Microsoft.VisualBasic.Left(RS.Fields("emp_Mname").Value, 1) & "."
                    frmAdmin.lblAddress.Text = RS.Fields("emp_Address").Value
                    frmAdmin.lblGender.Text = RS.Fields("emp_Gender").Value
                    frmAdmin.lbUID.Text = RS.Fields("emp_id").Value
                    Dim age As Long
                    age = DateDiff(DateInterval.Month, Now, RS.Fields("emp_Bdate").Value)
                    frmAdmin.lblAge.Text = Microsoft.VisualBasic.Left((age / 12) * (-1), 2)
                    getSpecificPosition(RS.Fields("emp_PosID").Value)
                    position = RS.Fields("PosName").Value
                    If position = "Administrator" Then
                        frmAdmin.pnlLinks.Visible = True
                        frmAdmin.pnlCash.Visible = False
                        frmAdmin.tsmTitle.Text = "ADMINISTRATOR"
                    Else
                        frmAdmin.pnlLinks.Visible = False
                        frmAdmin.pnlCash.Visible = True
                        frmAdmin.tsmTitle.Text = "CASHIER"
                    End If
                    frmAdmin.lblLogin.Text = "LOGOUT"
                    frmAdmin.MANAGEToolStripMenuItem.Enabled = True
                    clearFields()
                    Me.Close()
                End If
                Else
                    MessageBox.Show("Username/Password not found. Please check your username/password!", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    txtUser.Focus()
                    txtUser.SelectAll()
                End If
            End If
    End Sub

    Private Sub frmLogin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        clearFields()
    End Sub

    Private Sub clearFields()
        txtPass.Clear()
        txtUser.Clear()
        txtUser.Focus()
    End Sub
End Class