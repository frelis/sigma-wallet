Public Interface itCoin
    ReadOnly Property CoinName As String
    ReadOnly Property CoinIcon As System.Drawing.Icon
    WriteOnly Property AppIcon As System.Drawing.Icon
    ReadOnly Property NewWalletControl As Windows.Forms.UserControl
    Event NewWalletCreated(newWallet As Coin.Wallet)
    ReadOnly Property Sync As itSyncWallet
    ReadOnly Property Settings As List(Of itSettings)
    Function Delete(Wallet As Coin.Wallet) As Boolean
End Interface

Public Interface itSyncWallet
    Event Syncing_Start(BlockChainHeight As Long)
    Event Syncing_Step(IniPos As Long, CurrentPos As Long, EndPos As Long)
    Event Syncing_Stop(Finished As Boolean)
    Event New_Amount(incremental As Decimal, total As Decimal)
    Function Start(Wallet As Coin.Wallet) As Boolean
    Function [Stop]() As Boolean
End Interface

Public Interface itSettings
    ReadOnly Property Name As String
    ReadOnly Property SettingsControl As Windows.Forms.UserControl
End Interface
