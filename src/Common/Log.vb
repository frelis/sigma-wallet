Public Class Log
    Shared Sub [Error](Origin As String, ex As Exception)
        Report.Error(Origin, ex)
        Dim t As Threading.Thread = New Threading.Thread(Sub() MsgBox(Lang.Str("E_" + ex.Message + "_"), MsgBoxStyle.Critical, Lang.Str("T_" + Origin + "_")))
        t.Start()
    End Sub

    Public Shared Sub Warning(title As String, text As String)
        Dim t As Threading.Thread = New Threading.Thread(Sub() MsgBox(Lang.Str("W_" + text + "_"), MsgBoxStyle.Information, Lang.Str("T_" + title + "_")))
        t.Start()
    End Sub
End Class
