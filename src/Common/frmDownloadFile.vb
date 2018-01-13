Imports System.ComponentModel
Imports System.Net

Public Class frmDownloadFile
    Public Function DownloadFile(from As String, dest As String) As Boolean
        Try
            Dim client As Net.WebClient = New Net.WebClient()
            lblfile.Text = from
            AddHandler client.DownloadProgressChanged, AddressOf client_DownloadProgressChanged
            AddHandler client.DownloadFileCompleted, AddressOf client_DownloadFileCompleted
            client.UseDefaultCredentials = True
            client.DownloadFileAsync(New Uri(from), dest)
            Me.ShowDialog()

            Return True
        Catch ex As Exception
            If Me.Visible Then Me.Close()
            MsgBox("Falied to download:" + vbNewLine + from)
        End Try
        Return False
    End Function

    Private Sub client_DownloadFileCompleted(sender As Object, e As AsyncCompletedEventArgs)
        Me.Close()
        If Not e.Error Is Nothing Then
            MsgBox(e.Error.Message)
        End If
    End Sub

    Private Sub client_DownloadProgressChanged(sender As Object, e As DownloadProgressChangedEventArgs)
        Dim bytesIn As Long = e.BytesReceived
        Dim totalBytes As Long = e.TotalBytesToReceive
        ProgressBar1.Value = CInt(bytesIn / totalBytes * 100)
    End Sub
End Class