Imports frelis

Public Class Wallet
    Implements itModule

#Region "Varibles"
    Private mAppIcon As Drawing.Icon = Nothing
    Private mCoins As New List(Of itCoin)
    Private mWallet As Coin.Wallet
#End Region
    Public Event WalletChange As itModule.WalletChangeEventHandler Implements itModule.WalletChange
    Public Event RefreshMain As itModule.RefreshMainEventHandler Implements itModule.RefreshMain

    Public WriteOnly Property AppIcon As Icon Implements itModule.AppIcon
        Set(value As Icon)
            mAppIcon = value
        End Set
    End Property

    Public ReadOnly Property Control As UserControl Implements itModule.Control
        Get
            Dim uc As New ucWallet
            AddHandler uc.GotFocus, AddressOf Resize
            uc.Coins = mCoins
            If Not IsNothing(mAppIcon) Then uc.Icon = mAppIcon
            uc.Wallet = mWallet
            Return uc
        End Get
    End Property

    Private Sub Resize(sender As Object, e As EventArgs)
        RaiseEvent RefreshMain(Nothing)
    End Sub

    Public WriteOnly Property Coins As List(Of itCoin) Implements itModule.Coins
        Set(value As List(Of itCoin))
            mCoins = value
        End Set
    End Property

    Private Property itModule_Wallet As Coin.Wallet Implements itModule.Wallet
        Get
            Return mWallet
        End Get
        Set(value As Coin.Wallet)
            mWallet = value
        End Set
    End Property
End Class
