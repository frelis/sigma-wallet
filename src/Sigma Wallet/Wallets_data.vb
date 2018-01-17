Imports System.Runtime.Serialization
Public Class Wallets_Data
    Public Structure config
        Dim wallets As List(Of Coin.Wallet)
    End Structure

    Private Shared mconfig As config = Nothing
    Public Shared Property Data() As config
        Get
            Return mconfig
        End Get
        Set(ByVal value As config)
            mconfig = value
        End Set
    End Property

    Public Shared Function SaveConfig() As Boolean
        Dim rst As Boolean = False
        Try
            Dim filename As String
            If Not IO.Directory.Exists(Info.DirDoc) Then IO.Directory.CreateDirectory(Info.DirDoc)
            filename = Info.DirDoc + "Σ Wallet.wallets"
            rst = Settings.write_settings(filename, mconfig)
        Catch ex As Exception
            Log.Error("Save Wallets", ex)
            rst = False
        End Try
        Return rst
    End Function
    Public Shared Function ReadConfig() As Boolean
        Dim rst As Boolean = False
        mconfig = Settings.read_settings(Of config)(Info.DirDoc + "Σ Wallet.wallets")
        If IsNothing(mconfig) Then
            mconfig = New config
        End If
        If IsNothing(mconfig.wallets) Then
            mconfig.wallets = New List(Of Coin.Wallet)
        End If
        rst = True
        Return rst
    End Function
End Class
