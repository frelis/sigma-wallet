Public Class Coin
    Public Structure Coin_Settings
        Dim handlers As List(Of Wallet_handler)
        Dim nodes As List(Of node)
    End Structure

    Public Structure Wallet_handler
        Dim version As String
        Dim source As String
        Dim platform As String
        Dim coin As String
    End Structure

    Public Structure Node
        Dim name As String
        Dim protocol As String
        Dim hostname As String
        Dim port As Integer
    End Structure

    Public Class Wallet
        Public name As String
        Public order As Integer
        Public coin As String
        Public wallet_location As String
        Public wallet As String
        Public seed As String
        Public viewkey As String
        Public password As String
        Public amount As Decimal
        Public amount_available As Decimal
        Public last_sync As DateTime
        Public history As List(Of Movement)
    End Class

    Public Class Movement
        Public timestamp As Date
        Public amount As Decimal
        Public block As String
        Public text As String
        Public mixins As List(Of String)
    End Class
End Class
