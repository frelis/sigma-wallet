﻿Public Interface itModule
    Event WalletChange(Wallet As Coin.Wallet)
    Event RefreshMain(sender As Windows.Forms.Control)
    WriteOnly Property AppIcon As Drawing.Icon
    ReadOnly Property Control As Windows.Forms.UserControl
    WriteOnly Property Coins As List(Of itCoin)
    Property Wallet As Coin.Wallet
End Interface
