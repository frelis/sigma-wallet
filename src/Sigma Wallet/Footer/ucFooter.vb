Imports frelis

Public Class ucFooter
    Public Event NewWallet(wallet As Coin.Wallet)
#Region "Variables and Properties"
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

    Private mWallet As Coin.Wallet
    Public Property Wallet() As Coin.Wallet
        Get
            Return mWallet
        End Get
        Set(ByVal value As Coin.Wallet)
            mWallet = value
        End Set
    End Property
#End Region

    Private Sub btnAddNew_Click(sender As Object, e As EventArgs) Handles btnAddNew.Click
        Me.Enabled = False
        Try
            Dim frm As New frmAddNew
            Dim wallet As Coin.Wallet
            wallet = frm.Open(mCoins)
            If wallet.coin <> "" Then
                Wallets_Data.Data.wallets.Add(wallet)
                Wallets_Data.SaveConfig()

                Dim p As Control = Me.Parent
                Dim m As itModule
                m = New Wallet
                m.AppIcon = mAppIcon
                m.Coins = mCoins
                m.Wallet = wallet
                p.Controls.Remove(Me)
                p.Controls.Add(m.Control)
                p.Controls.Add(Me)

                RaiseEvent NewWallet(wallet)
            End If
        Catch ex As Exception
            Log.Error("Add New Wallet Button", ex)
        End Try
        Me.Enabled = True
    End Sub

    Private Sub ucFooter_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.BackColor = Template.Current.background_alt
        Lang.Translate_Control_Container(Me)
    End Sub

    Private Sub ucFooter_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        e.Graphics.DrawRectangle(New Pen(Template.Current.border, 3), Me.ClientRectangle)
    End Sub

    Private Sub ucFooter_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Me.Refresh()
    End Sub
End Class
