Imports frelis

Public Class Sync
    Implements itSyncWallet
    Dim mWallet As Coin.Wallet
    Dim mRunning As Boolean
    Dim proc As Process
    Dim output As Text.StringBuilder = New Text.StringBuilder()
    Public Event Progress As itSyncWallet.ProgressEventHandler Implements itSyncWallet.Progress

    Public Function Start(Wallet As Coin.Wallet) As Boolean Implements itSyncWallet.Start
        mWallet = Wallet
        mRunning = True
        Dim t = Task.Run(Sub() Start_Sync())

        Return True
    End Function

    Public Function [Stop]() As Boolean Implements itSyncWallet.Stop
        mRunning = False
        Threading.Thread.Sleep(100)
        Try
            proc.Kill()
        Catch
        End Try
        Threading.Thread.Sleep(100)
        MsgBox(output.tostring)
        Return True
    End Function


    Private Sub Start_Sync()
        Try
            proc = clsAEON.Aeon_process
            Dim args As String
            args = "--wallet """ + mWallet.wallet_location + """"
            args = args + " --daemon-address=" + Settings.ReadSetting("AEON", "Nodes", "Selected Node")
            proc.StartInfo.Arguments = args
            proc.Start()
            Using out As IO.StreamReader = proc.StandardOutput
                Dim tmp As New Text.StringBuilder
                While mRunning
                    If out.Peek > -1 Then
                        Dim ch As Char = ChrW(out.Read())
                        tmp.Append(ch)
                    Else
                        If tmp.Length > 0 Then
                            output.AppendLine("--> " + tmp.ToString)
                            If tmp.ToString.StartsWith("aeon wallet") Then
                                proc.StandardInput.WriteLine(mWallet.password)
                            End If
                            tmp.Clear()
                        End If
                        Threading.Thread.Sleep(100)
                    End If
                End While
            End Using
        Catch ex As Exception
            Log.Error("Syncing", ex)
        End Try
    End Sub
End Class
