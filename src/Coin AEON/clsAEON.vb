Imports System.IO.Compression
Imports frelis

Friend Class clsAEON
    Public Const Name = "AEON"
    Private VERSION = "0.9.14.0"
    Private Shared mValid_handler As Boolean = False
    Private mBasePath = Info.DirData + Name.ToLower + Info.DirSep
    Private mHandler As String = "simplewallet.exe"
#Region "Private Methods"
    Private Function get_wallet_handler() As Boolean
        Dim rst As Boolean = False
        Try
            Dim cfg As Coin.Coin_Settings
            cfg = Settings.read_settings(Of Coin.Coin_Settings)("settings_aeon.json")
            If IsNothing(cfg.handlers) Then cfg.handlers = New List(Of Coin.Wallet_handler)
            Dim s As New Coin.Wallet_handler
            For Each s In cfg.handlers
                If s.coin = "aeon" AndAlso s.platform = Info.SystemType Then
                    rst = True
                    Exit For
                End If
            Next
            If rst = True Then
                rst = False
                If IO.File.Exists(mBasePath + mHandler) Then
                    If GetVersion("") = VERSION Then
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
                            If GetVersion("") = VERSION Then
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

    Private Function get_handler(name As String) As Boolean
        If Not mValid_handler Then get_wallet_handler()
        If Not mValid_handler Then Return False
        If name = "" Then Return True
        If Not IO.Directory.Exists(mBasePath + name) Then IO.Directory.CreateDirectory(mBasePath + name)
        If Not IO.File.Exists(mBasePath + name + Info.DirSep + mHandler) Then
            IO.File.Copy(mBasePath + mHandler, mBasePath + name + Info.DirSep + mHandler)
            Return True
        Else
            If Not GetVersion(name) = VERSION Then
                IO.File.Copy(mBasePath + mHandler, mBasePath + name + Info.DirSep + mHandler)
                Return True
            Else
                Return True
            End If
        End If
    End Function
    Private Function Aeon_process(name As String) As Process
        Dim proc As New Process()
        proc.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden
        proc.StartInfo.CreateNoWindow = True
        proc.StartInfo.UseShellExecute = False
        proc.StartInfo.RedirectStandardInput = True
        proc.StartInfo.RedirectStandardOutput = True
        proc.StartInfo.RedirectStandardError = True
        If name = "" Then
            proc.StartInfo.FileName = mBasePath + mHandler
        Else
            proc.StartInfo.FileName = mBasePath + name + Info.DirSep + mHandler
        End If
        If IO.File.Exists(proc.StartInfo.FileName.Replace(".exe", ".log")) Then
            Try
                IO.File.Delete(proc.StartInfo.FileName.Replace(".exe", ".log"))
            Catch
            End Try
        End If
        Return proc
    End Function

    Private Function GetVersion(name As String) As String
        Dim rst As String = ""
        Try
            Dim proc As Process = Aeon_process(name)

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
#End Region
    Friend Function CreateNew(name As String, password As String) As Coin.Wallet
        Dim rst As New Coin.Wallet
        Try
            Dim goodname As String = Security.CalculateMD5Hash(name)
            If Not get_handler(goodname) Then
                Log.Warning("Wallet handler not available", "Wallet handler is not avalaible, wallet was not created")
                Return rst
            End If
            Dim args As String
            args = "--generate-new-wallet """ + mBasePath + goodname + Info.DirSep + "wallet"""
            args = args + " --password """ + password + """"
            args = args + " exit"
            Dim proc As Process = Aeon_process(goodname)
            proc.StartInfo.Arguments = args
            proc.Start()
            proc.WaitForExit(10000)
            If Not proc.HasExited Then proc.Kill()

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
                    rst.wallet_location = mBasePath + goodname + Info.DirSep
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

    Friend Function CreateExisting(name As String, password As String, seed As String) As Coin.Wallet
        Dim rst As New Coin.Wallet
        Try
            Dim goodname As String = Security.CalculateMD5Hash(name)
            If Not get_handler(goodname) Then
                Log.Warning("Wallet handler not available", "Wallet handler is not avalaible, wallet was not created")
                Return rst
            End If

            Dim args As String
            args = "--restore-deterministic-wallet"
            args = args + " --generate-new-wallet """ + mBasePath + goodname + Info.DirSep + "wallet"""
            args = args + " --password """ + password + """"
            args = args + " --electrum-seed """ + seed + """"
            args = args + " exit"
            Dim proc As Process = Aeon_process(goodname)
            proc.StartInfo.Arguments = args
            proc.Start()
            proc.WaitForExit(10000)
            If Not proc.HasExited Then proc.Kill()

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
                    If rst.seed = seed Then
                        rst.coin = clsAEON.Name
                        rst.name = name
                        rst.wallet_location = mBasePath + goodname + Info.DirSep
                        rst.password = password
                        rst.amount = 0
                        rst.order = 999
                        rst.history = New List(Of Coin.Movement)
                    Else
                        Log.Warning("Create Existing AEON Wallet", "Seed result is not the same:" + vbNewLine + "Input seed: " + seed + vbNewLine + "Ouput seed: " + rst.seed)
                    End If
                Else
                    Log.Warning("Create Existing AEON Wallet", "Invalid Output Format:" + vbNewLine + outputrst)
                End If
            Else
                Log.Warning("Create Existing AEON Wallet", "Wrong Output Format:" + vbNewLine + outputrst)
            End If
        Catch ex As Exception
            Log.Error("Create Existing AEON Wallet", ex)
            rst.coin = ""
        End Try
        Return rst
    End Function

    Friend Function DeleteWallet(wallet As Coin.Wallet) As Boolean
        Dim rst As Boolean = False
        Try
            IO.Directory.Delete(wallet.wallet_location, True)
            rst = True
        Catch ex As Exception
            Log.Error("Delete AEON Wallet", ex)
            rst = False
        End Try
        Return rst
    End Function
#Region "Sync"
    Friend Class Sync
        Implements itSyncWallet
#Region "Variables Events"
        Dim mSyncRunning As Boolean
        Dim mSyncProccess As Process
        Dim mSyncWallet As Coin.Wallet
        Dim mSyncTask As Task
        Dim mSyncBlockChainHeight As Long
        Dim mSyncMinBlockChainHeight As Long
        Public Event Syncing_Start As itSyncWallet.Syncing_StartEventHandler Implements itSyncWallet.Syncing_Start
        Public Event Syncing_Step As itSyncWallet.Syncing_StepEventHandler Implements itSyncWallet.Syncing_Step
        Public Event Syncing_Stop As itSyncWallet.Syncing_StopEventHandler Implements itSyncWallet.Syncing_Stop
#End Region
        Public Function Start(w As Coin.Wallet) As Boolean Implements itSyncWallet.Start
            Dim rst As Boolean = False
            Dim cl As New clsAEON

            mSyncWallet = w
            Try
                Task.Run(Sub() BlockChainHeight())
                Dim folders As String() = w.wallet_location.Split(Info.DirSep)
                Dim goodname As String = folders(folders.Length - 2)
                If Not cl.get_handler(goodname) Then
                    Log.Warning("Wallet handler not available", "Wallet handler is not avalaible, wallet was not created")
                    Return False
                End If

                Dim args As String = "--wallet-file """ + w.wallet_location + "wallet"""
                args = args + " --daemon-address " + Settings.ReadSetting("AEON", "Nodes", "Selected Node")
                args = args + " exit"
                mSyncProccess = cl.Aeon_process(goodname)
                mSyncProccess.StartInfo.Arguments = args
                mSyncProccess.StartInfo.RedirectStandardError = False
                mSyncProccess.StartInfo.RedirectStandardOutput = False
                mSyncProccess.StartInfo.Arguments = args
                mSyncProccess.EnableRaisingEvents = True
                AddHandler mSyncProccess.Exited, AddressOf ProcessExited
                mSyncProccess.Start()
                mSyncRunning = True
                mSyncTask = Task.Run(Sub() Start_Sync())
                rst = True
            Catch ex As Exception
                Log.Error("Start Syncing Wallet", ex)
                rst = False
            End Try
            Return rst
        End Function

        Private Sub ProcessExited(sender As Object, e As EventArgs)
            RaiseEvent Syncing_Stop(False)
        End Sub

        Private Sub BlockChainHeight()
            Dim webClient As New System.Net.WebClient()
            mSyncBlockChainHeight = 0
            Try
                Dim result = webClient.DownloadString("http://" + Settings.ReadSetting("AEON", "Nodes", "Selected Node") + "/getheight")
                If result.Contains("""height""") Then
                    result = result.Substring(result.IndexOf("""height""") + 8)
                    result = result.Substring(result.IndexOf(":") + 1)
                    result = result.Substring(0, result.IndexOf(","))
                    mSyncBlockChainHeight = CLng(result) - 1
                End If
            Catch ex As Exception
                mSyncBlockChainHeight = 0
            End Try
        End Sub

        Public Function [Stop]() As Boolean Implements itSyncWallet.Stop
            mSyncRunning = False
            If mSyncProccess IsNot Nothing Then
                If Not mSyncProccess.HasExited Then
                    mSyncProccess.Kill()
                    Threading.Thread.Sleep(200)
                End If
                mSyncProccess.Close()
            End If
            Threading.Thread.Sleep(200)
            Return True
        End Function
        Private Sub Start_Sync()
            Dim line As New Text.StringBuilder

            While mSyncRunning AndAlso Not mSyncProccess.HasExited
                If IO.File.Exists(mSyncProccess.StartInfo.FileName.Replace(".exe", ".log")) Then
                    Threading.Thread.Sleep(50)
                    Using fs As IO.FileStream = IO.File.Open(mSyncProccess.StartInfo.FileName.Replace(".exe", ".log"), IO.FileMode.Open, IO.FileAccess.Read, IO.FileShare.ReadWrite)
                        While mSyncRunning AndAlso Not mSyncProccess.HasExited
                            Dim x As Integer = fs.ReadByte
                            If x > 0 Then
                                line.Append(ChrW(x))
                                If line.Length > 27 AndAlso line.ToString.EndsWith(vbNewLine) Then
                                    HandleLine(line.ToString.Substring(27).Trim)
                                    line.Clear()
                                End If
                            Else
                                Threading.Thread.Sleep(10)
                            End If
                        End While
                    End Using
                End If
                Threading.Thread.Sleep(10)
            End While
        End Sub

        Private Sub HandleLine(Line As String)
            Try
                If Line.StartsWith("Skipped block by timestamp") Then
                    Line = Line.Substring(35)
                    Line = Line.Substring(0, Line.IndexOf(","))
                    Dim pos As Long = CLng(Line)
                    If mSyncMinBlockChainHeight = 0 Then mSyncMinBlockChainHeight = pos
                    RaiseEvent Syncing_Step(mSyncMinBlockChainHeight, pos, mSyncBlockChainHeight)
                ElseIf Line.StartsWith("Processed block: <") Then
                    Line = Line.Substring(91)
                    Line = Line.Substring(0, Line.IndexOf(","))
                    Dim pos As Long = CLng(Line)
                    If mSyncMinBlockChainHeight = 0 Then mSyncMinBlockChainHeight = pos
                    RaiseEvent Syncing_Step(mSyncMinBlockChainHeight, pos, mSyncBlockChainHeight)
                ElseIf Line.StartsWith("aeon wallet v") Then
                    mSyncProccess.StandardInput.WriteLine(mSyncWallet.password)
                ElseIf Line.StartsWith("ERROR") Then
                    IO.File.AppendAllText(mSyncProccess.StartInfo.FileName + ".log", "--> " + Line + vbNewLine)
                    Log.Warning("Error in Syncing", Line)
                ElseIf Line.StartsWith("Starting refresh...") Then
                    RaiseEvent Syncing_Start(mSyncBlockChainHeight)
                Else
                    If Line.StartsWith("Loaded wallet keys file") Then
                    ElseIf Line.StartsWith("Opened wallet") Then
                    ElseIf Line.Contains("list of available commands.") Then
                    ElseIf Line.StartsWith("****************************************") Then
                    ElseIf Line.StartsWith("Refresh done, blocks received:") Then
                    ElseIf Line.StartsWith("Block is already in blockchain:") Then
                    Else
                        IO.File.AppendAllText(mSyncProccess.StartInfo.FileName + ".log", Line + vbNewLine)
                    End If
                End If
            Catch ex As Exception
                Log.Error("Handle Line", ex)
            End Try
        End Sub
    End Class

#End Region
End Class
