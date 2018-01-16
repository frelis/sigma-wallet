Public Interface itCoin
    ReadOnly Property CoinName As String
    ReadOnly Property CoinIcon As System.Drawing.Icon
    WriteOnly Property AppIcon As System.Drawing.Icon
    ReadOnly Property NewWalletControl As Windows.Forms.UserControl
    Event NewWalletCreated(newWallet As Coin.Wallet)
    ReadOnly Property Sync As itSyncWallet
End Interface

Public Interface itSyncWallet
    Event Progress(IniPos As Long, CurrentPos As Long, EndPos As Long)
    Function Start(Wallet As Coin.Wallet) As Boolean
    Function [Stop]() As Boolean
End Interface
