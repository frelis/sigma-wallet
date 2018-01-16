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

    Public Structure Wallet
        Dim name As String
        Dim order As Integer
        Dim coin As String
        Dim wallet_location As String
        Dim wallet As String
        Dim seed As String
        Dim viewkey As String
        Dim password As String
        Dim amount As Decimal
        Dim last_sync As DateTime
        Dim history As List(Of Movement)
    End Structure

    Public Structure Movement
        Dim TimeStamp As Date
        Dim amount As Decimal
        Dim text As String
    End Structure
End Class
