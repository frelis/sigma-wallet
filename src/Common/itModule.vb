Public Interface itModule
    WriteOnly Property AppIcon As Drawing.Icon
    ReadOnly Property Control As Windows.Forms.UserControl
    Property Coins As List(Of itCoin)

End Interface
