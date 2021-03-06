﻿Imports frelis

Public Class Header
    Implements itModule

#Region "Varibles"
    Private mAppIcon As Drawing.Icon = Nothing
    Private mCoins As New List(Of itCoin)
#End Region
    Public Event WalletChange As itModule.WalletChangeEventHandler Implements itModule.WalletChange

    Public WriteOnly Property AppIcon As Icon Implements itModule.AppIcon
        Set(value As Icon)
            mAppIcon = value
        End Set
    End Property

    Public ReadOnly Property Control As UserControl Implements itModule.Control
        Get
            Dim uc As New ucHeader
            uc.Coins = mCoins
            If Not IsNothing(mAppIcon) Then uc.Icon = mAppIcon
            Return uc
        End Get
    End Property

    Public WriteOnly Property Coins As List(Of itCoin) Implements itModule.Coins
        Set(value As List(Of itCoin))
            mCoins = value
        End Set
    End Property

    Public Property Wallet As Coin.Wallet Implements itModule.Wallet
        Get
            Throw New NotImplementedException()
        End Get
        Set(value As Coin.Wallet)
            Throw New NotImplementedException()
        End Set
    End Property

    Public ReadOnly Property Name As String Implements itModule.Name
        Get
            Return "Header"
        End Get
    End Property
End Class
