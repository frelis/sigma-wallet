Imports System.ComponentModel
Imports System.Net

Public Class frmDownloadFile
    Public Function DownloadFile(from As String, dest As String) As Boolean
        Try
            Dim client As Net.WebClient = New Net.WebClient()
            lblfile.Text = Shorten_text(from, lblfile)
            AddHandler client.DownloadProgressChanged, AddressOf client_DownloadProgressChanged
            AddHandler client.DownloadFileCompleted, AddressOf client_DownloadFileCompleted
            client.UseDefaultCredentials = True
            client.DownloadFileAsync(New Uri(from), dest)
            Me.ShowDialog()
            Return True
        Catch ex As Exception
            If Me.Visible Then Me.Close()
            Log.Error("Download File", ex)
        End Try
        Return False
    End Function

    Private Sub client_DownloadFileCompleted(sender As Object, e As AsyncCompletedEventArgs)
        Me.Close()
        If Not e.Error Is Nothing Then
            Log.Error("Download File Completed", e.Error)
        End If
    End Sub

    Private Sub client_DownloadProgressChanged(sender As Object, e As DownloadProgressChangedEventArgs)
        Dim bytesIn As Long = e.BytesReceived
        Dim totalBytes As Long = e.TotalBytesToReceive
        ProgressBar1.Value = CInt(bytesIn / totalBytes * 100)
    End Sub

    Private Function Shorten_text(txt As String, lbl As Windows.Forms.Label) As String
        Dim textSize As Drawing.Size = Windows.Forms.TextRenderer.MeasureText(txt, lbl.Font)
        If textSize.Width < lbl.Width Then Return txt
        Dim txtp() As String = txt.Split("/"c)
        Return txtp(0) + "//" + txtp(2) + "/../" + txtp(txtp.Length - 1)
    End Function
End Class