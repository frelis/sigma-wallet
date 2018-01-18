Public Class ucWallet
#Region "Variables and Properties"
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
            lblName.Text = mWallet.name
            lblCoin.Text = mWallet.coin
            lblWallet.Text = mWallet.wallet
            UpdateAmount(mWallet.amount)
            mCoin = Nothing
            If mCoins.Count > 0 Then
                For Each c As itCoin In mCoins
                    If c.CoinName = Wallet.coin Then mCoin = c
                Next
            End If
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
        Static expanded As Integer = CInt(Me.Height * 174 / 115)
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
        Me.BackColor = Template.Current.background
        Me.pnlHeader.BackColor = Template.Current.background_alt
        AddHandler Me.MouseEnter, AddressOf Control_Enter
        AddHandler Me.MouseLeave, AddressOf Control_Leave
        AddEvents(Me.Controls)
    End Sub

    Private Sub ucWallet_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        e.Graphics.DrawRectangle(New Pen(Template.Current.border, 3), Me.ClientRectangle)
    End Sub

    Private Sub UpdateAmount(amount As Decimal)
        lblValue.Text = "Balance: " + amount.ToString("0.000")
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
            ok.Open(Me.FindForm, "Address of " + Wallet.name + " copied to clipboard", 3)
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
            If btnSync.Text = "Start Sync" Then
                sync = mCoin.Sync
                AddHandler sync.Progress, AddressOf UpdateProgress
                sync.Start(mWallet)
            Else
                sync.Stop()
            End If
        Catch ex As Exception
            Log.Error("Sync Buton", ex)
        End Try
        btnSync.Enabled = True
    End Sub

    Private Sub UpdateProgress(IniPos As Long, CurrentPos As Long, EndPos As Long)
        Dim lbl As String
        lbl = IniPos.ToString + " of " + EndPos.ToString
        If lblprogress.Text <> lbl Then lblprogress.Text = lbl
        progbarSync.Value = CInt((CurrentPos - IniPos) / (EndPos - IniPos))
    End Sub
End Class
