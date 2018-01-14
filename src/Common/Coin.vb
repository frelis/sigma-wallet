Public Class Coin
    Public Structure Coin_Settings
        Dim handlers As List(Of Wallet_handler)
    End Structure

    Public Structure Wallet_handler
        Dim version As String
        Dim source As String
        Dim platform As String
        Dim coin As String
    End Structure

    Public Structure Wallet
        Dim name As String
        Dim order As Integer
        Dim coin As String
        Dim wallet As String
        Dim seed As String
        Dim viewkey As String
        Dim password As String
        Dim amount As Decimal
        Dim history As List(Of Movement)
    End Structure

    Public Structure Movement
        Dim TimeStamp As Date
        Dim amount As Decimal
        Dim text As String
    End Structure
End Class
