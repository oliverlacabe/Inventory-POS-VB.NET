Public Class frmAddCategory

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        txtCat.Clear()
        Me.Close()
    End Sub

    Private Sub lblClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblClose.Click
        txtCat.Clear()
        Me.Close()
    End Sub

    Private Sub btnLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If String.IsNullOrEmpty(txtCat.Text) Then
            MessageBox.Show("Please enter a category name.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtCat.Focus()
        Else
            CheckCat(txtCat.Text)
            If RS.EOF Then
                AddCat(txtCat.Text)
                MessageBox.Show("Category " & txtCat.Text & " added.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtCat.Clear()
                txtCat.Focus()
                frmAdmin.refreshCBOCategory()
            Else
                MessageBox.Show("Category " & txtCat.Text & " already exist.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtCat.SelectAll()
                txtCat.Focus()
            End If
        End If
    End Sub
End Class