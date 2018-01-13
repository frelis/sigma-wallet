Friend Class clsAEON
    Private VERSION = "0.9.14.0"
    Private mValid_handler As Boolean = False
    Private mHandler As String = Info.DirData + "aeon" + Info.DirSep + "simplewallet.exe"

    Public Function get_wallet_handler() As Boolean
        Dim rst As Boolean = False
        Try

            Dim settings As New List(Of Info.wallet_handler)
            settings = Info.Get_Handler_settings
            Dim s As New Info.wallet_handler
            For Each s In settings
                If s.coin = "aeon" AndAlso s.platform = Info.SystemType Then
                    rst = True
                    Exit For
                End If
            Next
            If rst = True Then
                rst = False

                If IO.File.Exists(mHandler) Then
                    If GetVersion() = VERSION Then
                        Return True
                    Else
                        IO.File.Delete(mHandler)
                    End If
                End If
                If IO.Directory.Exists(Info.DirData + "aeon" + Info.DirSep + "tmp") Then
                    IO.Directory.Delete(Info.DirData + "aeon" + Info.DirSep + "tmp", True)
                End If
                IO.Directory.CreateDirectory(Info.DirData + "aeon" + Info.DirSep + "tmp")

                Dim frm As New frmDownloadFile
                rst = frm.DownloadFile(s.source, Info.DirData + "aeon" + Info.DirSep + "tmp" + Info.DirSep + s.version + ".zip")
                If rst = True Then

                End If
            End If


        Catch ex As Exception

        End Try
        Return rst
    End Function

    Private Function Aeon_process() As Process
        Dim proc As New Process()
        proc.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden
        proc.StartInfo.RedirectStandardInput = True
        proc.StartInfo.RedirectStandardOutput = True
        proc.StartInfo.CreateNoWindow = True
        proc.StartInfo.UseShellExecute = False
        proc.StartInfo.FileName = mHandler
        Return proc
    End Function

    Public Function GetVersion() As String
        Dim rst As String = ""
        Try
            Dim proc As Process = Aeon_process()

            proc.StartInfo.Arguments = "--version"
            proc.Start()
            proc.WaitForExit()

            rst = proc.StandardOutput.ReadToEnd()
            proc = Nothing
            If rst.Contains(" v") Then
                rst = rst.Substring(rst.IndexOf("v") + 1)
                rst = rst.Replace("(", "").Replace(")", "")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            rst = ""
        End Try
        Return rst
    End Function

    Friend Function CreateNew(name As String, password As String) As String
        Dim rst As String
        Try
            If Not mValid_handler Then get_wallet_handler()
            If Not mValid_handler Then
                Return "Error: Wallet handler not available."
            End If
            Dim proc As Process = Aeon_process()
            proc.StartInfo.Arguments = "--generate-new-wallet ""test\" + name + """ --password """ + password + """ exit"
            proc.Start()
            proc.WaitForExit()

            rst = proc.StandardOutput.ReadToEnd()
            proc = Nothing
            If rst.Contains("Generated new wallet:") Then
                Dim lines() As String = rst.Split(vbNewLine)
                rst = ""
                For i As Integer = 0 To lines.Length - 1
                    If lines(i).Trim.StartsWith("PLEASE NOTE: the following 24 words") Then
                        If lines.Length - 1 >= i + 1 Then
                            If lines(i + 1).Length > 25 Then
                                rst = lines(i + 1).Trim
                            Else
                                If lines.Length - 1 >= i + 2 Then
                                    If lines(i + 2).Length > 25 Then
                                        rst = lines(i + 2).Trim
                                    End If
                                End If
                            End If
                        End If
                    End If
                Next
            Else
                rst = "Error: " + rst
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            rst = ""
        End Try
        Return rst
    End Function
End Class
