Public Interface itModule
    Event WalletChange(Wallet As Coin.Wallet)
    WriteOnly Property AppIcon As Drawing.Icon
    ReadOnly Property Control As Windows.Forms.UserControl
    WriteOnly Property Coins As List(Of itCoin)
    Property Wallet As Coin.Wallet
    ReadOnly Property Name As String
End Interface


