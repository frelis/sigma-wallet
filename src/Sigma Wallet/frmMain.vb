Public Class frmMain
    Dim coins As New List(Of itCoin)

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Application.EnableVisualStyles()
    End Sub
    Private Sub Form1_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Dim coin As itCoin
        coin = New AEON_NewWallet
        coin.AppIcon = Me.Icon
        coins.Add(coin)
        Config.ReadConfig()
        Dim cFooter As itModule
        cFooter = New Footer
        cFooter.AppIcon = Me.Icon
        cFooter.Coins = coins
        flowpanel.Controls.Add(cFooter.Control)
        frmMain_Resize(sender, e)
    End Sub

    Private Sub frmMain_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        For Each c As Control In flowpanel.Controls
            c.Width = flowpanel.Width - 5
        Next
    End Sub
End Class
