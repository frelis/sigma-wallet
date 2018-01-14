Public Class ucWallet
#Region "Variables and Properties"
    Private mAppIcon As Drawing.Icon
    Public WriteOnly Property Icon() As Drawing.Icon
        Set(ByVal value As Drawing.Icon)
            mAppIcon = value
        End Set
    End Property

    Private mCoins As List(Of itCoin)
    Public WriteOnly Property Coins() As List(Of itCoin)
        Set(ByVal value As List(Of itCoin))
            mCoins = value
        End Set
    End Property

    Private mWallet As Settings.wallet
    Public Property Wallet() As Settings.wallet
        Get
            Return mWallet
        End Get
        Set(ByVal value As Settings.wallet)
            mWallet = value
            lblName.Text = mWallet.name
            lblCoin.Text = mWallet.coin
            lblWallet.Text = mWallet.wallet
            UpdateAmount(mWallet.amount)
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
        Static expanded As Integer = CInt(Me.Height * 200 / 115)
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
        MouseOn()
    End Sub

    Private Sub picCopywalletAdress_MouseLeave(sender As Object, e As EventArgs) Handles picCopywalletAdress.MouseLeave
        MouseOff()
    End Sub

    Private Sub lblWallet_MouseEnter(sender As Object, e As EventArgs) Handles lblWallet.MouseEnter
        MouseOn()
    End Sub

    Private Sub lblWallet_MouseLeave(sender As Object, e As EventArgs) Handles lblWallet.MouseLeave
        MouseOff()
    End Sub
    Private Sub MouseOn()
        lblWallet.BackColor = Template.Current.selected
        picCopywalletAdress.BackColor = Template.Current.selected
    End Sub

    Private Sub MouseOff()
        lblWallet.BackColor = Template.Current.background
        picCopywalletAdress.BackColor = Template.Current.background
    End Sub
#End Region


End Class
