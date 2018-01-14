Imports System.IO.Compression

Friend Class clsAEON
    Public Const Name = "AEON"
    Private VERSION = "0.9.14.0"
    Private Shared mValid_handler As Boolean = False
    Private mBasePath = Info.DirData + Name.ToLower + Info.DirSep
    Private mHandler As String = mBasePath + "simplewallet.exe"
    Private mWalletFilePath As String = mBasePath

    Public Function get_wallet_handler() As Boolean
        Dim rst As Boolean = False
        Try
            Dim cfg As Coin.Coin_Settings
            cfg = Settings.read_settings(Of Coin.Coin_Settings)("settings_aeon.json")
            If IsNothing(cfg.handler) Then cfg.handler = New List(Of Coin.Wallet_handler)
            Dim s As New Coin.Wallet_handler
            For Each s In cfg.handler
                If s.coin = "aeon" AndAlso s.platform = Info.SystemType Then
                    rst = True
                    Exit For
                End If
            Next
            If rst = True Then
                rst = False
                If IO.File.Exists(mHandler) Then
                    If GetVersion() = VERSION Then
                        mValid_handler = True
                        Return True
                    Else
                        IO.File.Delete(mHandler)
                    End If
                End If
                Dim tmpPath As String = mBasePath + "tmp" + Info.DirSep
                If IO.Directory.Exists(tmpPath) Then IO.Directory.Delete(tmpPath, True)
                IO.Directory.CreateDirectory(tmpPath)

                Dim frm As New frmDownloadFile
                Dim zipfile As String = IO.Path.GetFileName(s.source)
                rst = frm.DownloadFile(s.source, tmpPath + zipfile)
                If rst = True Then
                    Using archive As ZipArchive = IO.Compression.ZipFile.OpenRead(tmpPath + zipfile)
                        For Each entry As ZipArchiveEntry In archive.Entries
                            If entry.FullName.EndsWith("simplewallet.exe", StringComparison.OrdinalIgnoreCase) Then
                                entry.ExtractToFile(mHandler)
                            End If
                        Next
                        If IO.File.Exists(mHandler) Then
                            If GetVersion() = VERSION Then
                                mValid_handler = True
                                Return True
                            Else
                                IO.File.Delete(mHandler)
                            End If
                        End If
                    End Using
                Else
                    Log.Warning("Get AEON handle", "Was not Possilbe to download the Wallet handler .")
                End If
            Else
                Log.Warning("Get AEON handle", "Was not Possilbe to retrieve the Wallet handler definitions.")
            End If
        Catch ex As Exception
            Log.Error("Get AEON handler", ex)
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

            rst = proc.StandardOutput.ReadToEnd().Trim
            proc = Nothing
            If rst.Contains(" v") Then
                rst = rst.Substring(rst.IndexOf("v") + 1)
                rst = rst.Replace("(", "").Replace(")", "")
            End If
        Catch ex As Exception
            Log.Error("Get AEON Handler Version", ex)
            rst = ""
        End Try
        Return rst
    End Function

    Friend Function CreateNew(name As String, password As String) As Coin.Wallet
        Dim rst As New Coin.Wallet
        Try
            If Not mValid_handler Then get_wallet_handler()
            If Not mValid_handler Then
                Log.Warning("Wallet handler not available", "Wallet handler is not avalaible, wallet was not created")
                Return rst
            End If
            Dim proc As Process = Aeon_process()
            proc.StartInfo.Arguments = "--generate-new-wallet """ + mWalletFilePath + name + """ --password """ + password + """ exit"
            proc.Start()
            proc.WaitForExit()

            Dim outputrst As String
            outputrst = proc.StandardOutput.ReadToEnd()
            proc = Nothing
            If outputrst.Contains("Generated new wallet:") Then
                Dim lines() As String = outputrst.Split(vbNewLine)
                For i As Integer = 0 To lines.Length - 1
                    If lines(i).Trim.StartsWith("Generated new wallet:") Then
                        rst.wallet = lines(i).Trim.Substring(22)
                    ElseIf lines(i).Trim.StartsWith("view key:") Then
                        rst.viewkey = lines(i).Trim.Substring(10)
                    ElseIf lines(i).Trim.StartsWith("PLEASE NOTE: the following 24 words") Then
                        If lines.Length - 1 >= i + 1 Then
                            If lines(i + 1).Length > 25 Then
                                rst.seed = lines(i + 1).Trim
                            Else
                                If lines.Length - 1 >= i + 2 Then
                                    If lines(i + 2).Length > 25 Then
                                        rst.seed = lines(i + 2).Trim
                                    End If
                                End If
                            End If
                        End If
                    End If
                Next
                If rst.seed <> "" And rst.wallet <> "" And rst.viewkey <> "" Then
                    rst.coin = clsAEON.Name
                    rst.name = name
                    rst.password = password
                    rst.amount = 0
                    rst.order = 999
                    rst.history = New List(Of Coin.Movement)
                Else
                    Log.Warning("Create New AEON Wallet", "Invalid Ouput Format:" + vbNewLine + outputrst)
                End If
            Else
                Log.Warning("Create New AEON Wallet", "Wrong Output Format:" + vbNewLine + outputrst)
            End If
        Catch ex As Exception
            Log.Error("Create New AEON Wallet", ex)
            rst.coin = ""
        End Try
        Return rst
    End Function
End Class
