Public Class frmStart

    Private Sub frmStart_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Timer2.Start()
    End Sub

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        Bar1.Increment(100)
        If Bar1.Value = Bar1.Maximum Then
            Timer2.Stop()
            Me.Hide()
            ConnectDB()
            frmAdmin.Show()
        End If
    End Sub
End Class