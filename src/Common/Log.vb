Public Class Log
    Shared Sub [Error](Origin As String, ex As Exception)
        Report.Error(Origin, ex)
        MsgBox(Lang.Str("E_" + ex.Message + "_"), MsgBoxStyle.Critical, Lang.Str("T_" + Origin + "_"))
    End Sub

    Public Shared Sub Warning(title As String, text As String)
        MsgBox(Lang.Str("W_" + text + "_"), MsgBoxStyle.Information, Lang.Str("T_" + title + "_"))
    End Sub
End Class
