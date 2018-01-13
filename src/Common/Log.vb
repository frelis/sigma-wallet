Public Class Log
    Shared Sub [Error](Origin As String, ex As Exception)
        MsgBox(ex.Message, MsgBoxStyle.Critical, "Error: " + Origin)
    End Sub

    Public Shared Sub Warning(title As String, text As String)
        MsgBox(text, MsgBoxStyle.Information, title)
    End Sub
End Class
