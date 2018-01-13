Public Class Log
    Shared Sub [Error](Origin As String, ex As Exception)
        MsgBox(ex.Message, MsgBoxStyle.Critical, "Error: " + Origin)
    End Sub
End Class
