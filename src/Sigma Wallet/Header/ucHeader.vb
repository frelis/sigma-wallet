Public Class ucHeader
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
End Class
