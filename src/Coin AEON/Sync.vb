Imports frelis

Public Class Sync
    Implements itSyncWallet
    Dim mWallet As Coin.Wallet
    Dim mRunning As Boolean
    Public Event Progress As itSyncWallet.ProgressEventHandler Implements itSyncWallet.Progress

    Public Function Start(Wallet As Coin.Wallet) As Boolean Implements itSyncWallet.Start
        mWallet = Wallet
        mRunning = True
        Dim t = Task.Run(Sub() Start_Sync())

        Return True
    End Function

    Public Function [Stop]() As Boolean Implements itSyncWallet.Stop
        mRunning = False
        Return True
    End Function


    Private Sub Start_Sync()
        Dim proc As Process = clsAEON.Aeon_process
        Dim args As String
        args = "--wallet """ + mWallet.wallet_location + """"
        args = args + " --daemon-address=" + Settings.ReadSetting("AEON", "Nodes", "Selected Node")
        args = args + " exit"
        AddHandler proc.OutputDataReceived, AddressOf DataReceived
        proc.Start()
        proc.BeginOutputReadLine()
        While mRunning
            Threading.Thread.Sleep(100)
        End While
    End Sub

    Private Sub DataReceived(sender As Object, e As DataReceivedEventArgs)
        MsgBox("""" + e.Data + """")
    End Sub
End Class
