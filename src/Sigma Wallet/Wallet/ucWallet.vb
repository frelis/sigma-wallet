Imports frelis

Public Class ucWallet
#Region "Variables and Properties"
    Public Event DeleteWallet()
    Private mAppIcon As Drawing.Icon
    Public WriteOnly Property Icon() As Drawing.Icon
        Set(ByVal value As Drawing.Icon)
            mAppIcon = value
        End Set
    End Property

    Private mCoin As itCoin = Nothing
    Private mCoins As New List(Of itCoin)
    Public WriteOnly Property Coins() As List(Of itCoin)
        Set(ByVal value As List(Of itCoin))
            mCoins = value
            mCoin = Nothing
            If mWallet.name <> "" Then
                For Each c As itCoin In mCoins
                    If c.CoinName = Wallet.coin Then mCoin = c
                Next
            End If
        End Set
    End Property

    Private mWallet As Coin.Wallet
    Public Property Wallet() As Coin.Wallet
        Get
            Return mWallet
        End Get
        Set(ByVal value As Coin.Wallet)
            mWallet = value
            mCoin = Nothing
            If mCoins.Count > 0 Then
                For Each c As itCoin In mCoins
                    If c.CoinName = Wallet.coin Then mCoin = c
                Next
            End If
            UpdateWallet()
        End Set
    End Property
#End Region
#Region "Expande Colapse"
    Private Sub AddEvents(ByVal ctls As Control.ControlCollection)
        For Each ctl As Control In ctls
            AddHandler ctl.MouseEnter, AddressOf Control_Enter
            AddHandler ctl.MouseLeave, AddressOf Control_Leave
            AddEvents(ctl.Controls)
        Next
    End Sub

    Private Sub Control_Leave(sender As Object, e As EventArgs)
        Expand()
    End Sub

    Private Sub Control_Enter(sender As Object, e As EventArgs)
        Expand()
    End Sub

    Private Sub Expand()
        Static notexpanded As Integer = Me.Height
        Static expanded As Integer = CInt(Me.Height * 220 / 115)
        If Me.ClientRectangle.Contains(Me.PointToClient(Control.MousePosition)) Then
            If Me.Height <> expanded Then
                Me.Height = expanded
                Me.Refresh()
            End If
        Else
            If Me.Height <> notexpanded Then
                Me.Height = notexpanded
                Me.Refresh()
            End If
        End If
    End Sub
#End Region
    Private Sub ucWallet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblName.Text = "!"
        lblCoin.Text = "!"
        lblWallet.Text = "!"
        lblValue.Text = "!"
        lblStatus.Text = "!"
        Lang.Translate_Control_Container(Me)

        Me.BackColor = Template.Current.background
        Me.pnlHeader.BackColor = Template.Current.background_alt
        AddHandler Me.MouseEnter, AddressOf Control_Enter
        AddHandler Me.MouseLeave, AddressOf Control_Leave
        AddEvents(Me.Controls)
        UpdateWallet()
    End Sub

    Private Sub ucWallet_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        e.Graphics.DrawRectangle(New Pen(Template.Current.border, 3), Me.ClientRectangle)
    End Sub

    Private Sub UpdateWallet()
        lblName.Text = mWallet.name
        lblCoin.Text = mWallet.coin
        lblWallet.Text = mWallet.wallet
        lblValue.Text = Lang.Str("Balance: {0}", mWallet.amount)
        SetStatus(mWallet, mCoin)
    End Sub
#Region "Copy address to clipboard"
    Private Sub picCopywalletAdress_Click(sender As Object, e As EventArgs) Handles picCopywalletAdress.Click
        Copy2Clipboard()
    End Sub

    Private Sub lblWallet_Click(sender As Object, e As EventArgs) Handles lblWallet.Click
        Copy2Clipboard()
    End Sub

    Private Sub Copy2Clipboard()
        Try
            Clipboard.SetData(DataFormats.Text, CType(mWallet.wallet, Object))
            Dim ok As New ucSuccess
            ok.Open(Me.FindForm, Lang.Str("Address of {0} copied to clipboard", Wallet.name), 3)
        Catch ex As Exception
            Log.Error("Copy to Clipboard", ex)
        End Try
    End Sub

    Private Sub picCopywalletAdress_MouseEnter(sender As Object, e As EventArgs) Handles picCopywalletAdress.MouseEnter
        Me.Cursor = Cursors.Hand
    End Sub

    Private Sub picCopywalletAdress_MouseLeave(sender As Object, e As EventArgs) Handles picCopywalletAdress.MouseLeave
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub lblWallet_MouseEnter(sender As Object, e As EventArgs) Handles lblWallet.MouseEnter
        Me.Cursor = Cursors.Hand
    End Sub

    Private Sub lblWallet_MouseLeave(sender As Object, e As EventArgs) Handles lblWallet.MouseLeave
        Me.Cursor = Cursors.Default
    End Sub
#End Region
    Dim sync As itSyncWallet
    Private Sub btnSync_Click(sender As Object, e As EventArgs) Handles btnSync.Click
        If IsNothing(mCoin) Then Exit Sub
        btnSync.Enabled = False
        Try
            If btnSync.Text = Lang.Str("B_Start Sync_") Then
                btnDelete.Enabled = False
                lblprogress.Text = Lang.Str("Start Syncing...")
                btnSync.Text = Lang.Str("B_Stop Sync_")
                sync = mCoin.Sync
                AddHandler sync.Syncing_Start, AddressOf StartSync
                AddHandler sync.Syncing_Step, AddressOf UpdateProgress
                AddHandler sync.Syncing_Stop, AddressOf StopSync
                sync.Start(mWallet)
            Else
                sync.Stop()
                lblprogress.Text = ""
                btnSync.Text = Lang.Str("B_Start Sync_")
                btnDelete.Enabled = True
            End If
        Catch ex As Exception
            Log.Error("Sync Button", ex)
        End Try
        btnSync.Enabled = True
    End Sub

    Private Sub StopSync(Finished As Boolean)
        UpdateStatus("Syncing stopped", Color.DarkRed)
    End Sub

    Private Sub StartSync(BlockChainHeight As Long)
        UpdateStatus("Syncing...", Color.Black)
    End Sub

    Private Sub UpdateProgress(IniPos As Long, CurrentPos As Long, EndPos As Long)
        If Me.InvokeRequired Then
            Dim args() As Object = {IniPos, CurrentPos, EndPos}
            Me.Invoke(New Action(Of Long, Long, Long)(AddressOf UpdateProgress), args)
            Return
        End If

        Dim lbl As String
        If EndPos = 0 Then
            lbl = Lang.Str("Block: {0}", CurrentPos)
        Else
            lbl = Lang.Str("Block: {0} of {1}", CurrentPos, EndPos)
            If lblprogress.Text <> lbl Then lblprogress.Text = lbl
            If EndPos <> IniPos Then
                progbarSync.Value = CInt((CurrentPos - IniPos) / (EndPos - IniPos) * 100)
            Else
                progbarSync.Value = progbarSync.Maximum
            End If
        End If
    End Sub

    Private Sub ucWallet_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Me.Refresh()
    End Sub

    Private Sub SetStatus(w As Coin.Wallet, c As itCoin)
        If w.last_sync.Year < 2010 Then
            UpdateStatus("Never Synced", Color.DarkRed)
        End If
    End Sub

    Private Sub UpdateStatus(text As String, cor As Color)
        If Me.InvokeRequired Then
            Dim args() As Object = {text, cor}
            Me.Invoke(New Action(Of String, Color)(AddressOf UpdateStatus), args)
            Return
        End If
        lblStatus.Text = Lang.Str(text)
        lblStatus.ForeColor = cor
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click

        Wallets_Data.ReadConfig()
        For Each w As Coin.Wallet In Wallets_Data.Data.wallets
            If w.coin = mWallet.coin AndAlso w.name = mWallet.name Then
                Wallets_Data.Data.wallets.Remove(w)
                Exit For
            End If
        Next
        Wallets_Data.SaveConfig()
        mCoin.Delete(mWallet)
        Me.Visible = False
        RaiseEvent DeleteWallet()
    End Sub

    Private Sub btnMov_Click(sender As Object, e As EventArgs) Handles btnMov.Click

    End Sub
End Class
