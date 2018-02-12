Imports frelis

Public Class frmSettings
    Private mCoins As List(Of itCoin)
    Friend Sub Open(Coins As List(Of itCoin))
        mCoins = Coins
        Lang.Translate_Control_Container(Me)
        Me.Text = Lang.Str(Me.Text)
        For Each c In mCoins
            Dim t As TreeNode = tvwSections.Nodes.Add(c.CoinName)
            For Each s As itSettings In c.Settings
                t.Nodes.Add(Lang.Str(s.Name))
            Next
        Next
        tvwSections.ExpandAll()
        ShowControls(False)
        Me.ShowDialog()
    End Sub

    Private Sub ShowControls(show As Boolean)
        btnOk.Visible = show
        btnReset.Visible = show
        lblSettingsName.Visible = show
        pnl.Visible = show
    End Sub

    Private Sub tvwSections_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles tvwSections.AfterSelect
        If e.Node.Level = 1 Then
            For Each c In mCoins
                If e.Node.Parent.Text = c.CoinName Then
                    lblSettingsName.Text = c.CoinName
                    For Each s As itSettings In c.Settings
                        If e.Node.Text = Lang.Str(s.Name) Then
                            lblSettingsName.Text = lblSettingsName.Text + " : " + e.Node.Text
                            pnl.Controls.Clear()
                            pnl.Controls.Add(s.SettingsControl)
                            pnl.Controls.Item(0).Dock = DockStyle.Fill
                            Exit For
                        End If
                    Next
                    Exit For
                End If
            Next
            ShowControls(True)
        Else
            ShowControls(False)
        End If
    End Sub

    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        Me.Close()
    End Sub
End Class