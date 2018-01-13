Imports frelis

Friend Class Footer
    Implements itModule

#Region "Varibles"
    Private mAppIcon As Drawing.Icon = Nothing
    Private mCoins As New List(Of itCoin)
#End Region

    Public WriteOnly Property AppIcon As Icon Implements itModule.AppIcon
        Set(value As Icon)
            mAppIcon = value
        End Set
    End Property

    Public ReadOnly Property Control As UserControl Implements itModule.Control
        Get
            Dim uc As New ucFooter
            uc.Coins = mCoins
            If Not IsNothing(mAppIcon) Then uc.Icon = mAppIcon
            Return uc
        End Get
    End Property

    Public Property Coins As List(Of itCoin) Implements itModule.Coins
        Get
            Return mCoins
        End Get
        Set(value As List(Of itCoin))
            mCoins = value
        End Set
    End Property
End Class
