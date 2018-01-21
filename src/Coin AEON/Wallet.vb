Imports System.Windows.Forms
Imports frelis

Public Class AEON_Coin
    Implements itCoin

#Region "Variables"
    Private mAppIcon As Drawing.Icon
#End Region

    Public ReadOnly Property CoinName As String Implements itCoin.CoinName
        Get
            Return clsAEON.Name
        End Get
    End Property

    Public ReadOnly Property CoinIcon As System.Drawing.Icon Implements itCoin.CoinIcon
        Get
            Throw New NotImplementedException()
        End Get
    End Property

    Public WriteOnly Property AppIcon As System.Drawing.Icon Implements itCoin.AppIcon
        Set(value As System.Drawing.Icon)
            mAppIcon = value
        End Set
    End Property

    Public ReadOnly Property NewWalletControl As UserControl Implements itCoin.NewWalletControl
        Get
            Dim uc As New ucNewAEONWallet
            AddHandler uc.NewWalletCreated, AddressOf NewWallet
            Return uc
        End Get
    End Property

    Public ReadOnly Property Sync As itSyncWallet Implements itCoin.Sync
        Get
            Dim x As New clsAEON.Sync
            Return x
        End Get
    End Property

    Public ReadOnly Property Settings As List(Of itSettings) Implements itCoin.Settings
        Get
            Dim x As New List(Of itSettings)
            x.Add(New clsNodes)
            Return x
        End Get
    End Property

    Public Event NewWalletCreated As itCoin.NewWalletCreatedEventHandler Implements itCoin.NewWalletCreated
    Private Sub NewWallet(NewWallet As Coin.Wallet)
        RaiseEvent NewWalletCreated(NewWallet)
    End Sub
End Class
