Public Class frmMain
    Dim coins As New List(Of itCoin)

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Application.EnableVisualStyles()
        Me.BackColor = Template.Current.background
        Me.flowpanel.BackColor = Template.Current.background
    End Sub
    Private Sub Form1_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Dim coin As itCoin
        coin = New AEON_NewWallet
        coin.AppIcon = Me.Icon
        coins.Add(coin)
        Config.ReadConfig()
        Dim m As itModule

        m = New Header
        m.AppIcon = Me.Icon
        m.Coins = coins
        flowpanel.Controls.Add(m.Control)
        AddHandler m.RefreshMain, AddressOf ResizeMain

        For Each w As Coin.Wallet In Config.Data.wallets
            m = New Wallet
            m.AppIcon = Me.Icon
            m.Coins = coins
            m.Wallet = w
            flowpanel.Controls.Add(m.Control)
            AddHandler m.RefreshMain, AddressOf ResizeMain

        Next
        m = New Footer
        m.AppIcon = Me.Icon
        m.Coins = coins
        flowpanel.Controls.Add(m.Control)
        AddHandler m.RefreshMain, AddressOf ResizeMain
        frmMain_Resize(sender, e)
    End Sub

    Private Sub ResizeMain(sender As Control)
        frmMain_Resize(sender, New EventArgs)
    End Sub

    Private Sub UpdateWallets()
        frmMain_Resize(Me, New EventArgs)
    End Sub

    Private Sub frmMain_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        For Each c As Control In flowpanel.Controls
            If flowpanel.VerticalScroll.Visible Then
                c.Width = flowpanel.Width - 5 - SystemInformation.VerticalScrollBarWidth
            Else
                c.Width = flowpanel.Width - 5
            End If
        Next
    End Sub
End Class
