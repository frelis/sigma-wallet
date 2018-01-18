Public Class ucHeader
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

    Private Sub picConfig_Click(sender As Object, e As EventArgs) Handles picConfig.Click
        Dim frm As New frmSettings
        frm.Icon = Me.FindForm.Icon
        frm.Open(mCoins)
    End Sub

    Private Sub picConfig_MouseEnter(sender As Object, e As EventArgs) Handles picConfig.MouseEnter
        Me.Cursor = Cursors.Hand
    End Sub

    Private Sub picConfig_MouseLeave(sender As Object, e As EventArgs) Handles picConfig.MouseLeave
        Me.Cursor = Cursors.Default
    End Sub
End Class
