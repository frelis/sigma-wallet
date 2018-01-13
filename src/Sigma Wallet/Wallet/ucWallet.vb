Imports frelis

Public Class ucWallet
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
        End Set
    End Property

    Private Sub ucWallet_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Dim expand As Single = 200 / 84
    Private Sub ucWallet_GotFocus(sender As Object, e As EventArgs) Handles Me.GotFocus
        Me.Height = CInt(Me.Height * expand)
    End Sub

    Private Sub ucWallet_LostFocus(sender As Object, e As EventArgs) Handles Me.LostFocus
        Me.Height = CInt(Me.Height / expand)
    End Sub
End Class
