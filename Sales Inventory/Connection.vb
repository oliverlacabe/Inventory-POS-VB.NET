Module Connection
    Public CN As ADODB.Connection
    Public RS As ADODB.Recordset
    Public UserID, position, receipt, logged, bid As String
    Public quantity As Integer = Nothing
    Public pid As Integer
    Public change, due As Double

    Public Sub ConnectDB()
        CN = New ADODB.Connection
        RS = New ADODB.Recordset

        CN.CursorLocation = ADODB.CursorLocationEnum.adUseClient

        If CN.State = ADODB.ObjectStateEnum.adStateOpen Then CN.Close()

        CN.ConnectionString = "DRIVER={MySQL ODBC 5.2a Driver}; SERVER=localhost; DATABASE=GodBlessPOS; UID=root; pwd=;"

        Try
            CN.Open()
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End
        End Try
    End Sub
End Module
