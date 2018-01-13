Imports frelis

Public Class ucFooter
    Private mAppIcon As Drawing.Icon
    Public Property Icon() As Drawing.Icon
        Get
            Return mAppIcon
        End Get
        Set(ByVal value As Drawing.Icon)
            mAppIcon = value
        End Set
    End Property

    Public Property Coins As List(Of itCoin)

    Private Sub btnAddNew_Click(sender As Object, e As EventArgs) Handles btnAddNew.Click
        Me.Enabled = False
        Try
            Dim frm As New frmAddNew
            frm.Coins = Coins
            frm.ShowDialog()
        Catch ex As Exception
            Log.Error("Add New Wallet Button", ex)
        End Try
        Me.Enabled = True
    End Sub
End Class
