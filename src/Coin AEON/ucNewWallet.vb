Public Class ucNewWallet
    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Me.Visible = False
    End Sub

    Private Sub optAEONNew_CheckedChanged(sender As Object, e As EventArgs) Handles optAEONNew.CheckedChanged
        If optAEONNew.Checked Then EnablebtnAEONCreate()
    End Sub

    Private Sub txtAEONName_TextChanged(sender As Object, e As EventArgs) Handles txtAEONName.TextChanged
        EnablebtnAEONCreate()
    End Sub

    Private Sub txtAEONPassword_TextChanged(sender As Object, e As EventArgs) Handles txtAEONPassword.TextChanged
        EnablebtnAEONCreate()
    End Sub

    Private Sub txtAEONSeed_TextChanged(sender As Object, e As EventArgs) Handles txtAEONSeed.TextChanged
        EnablebtnAEONCreate()
    End Sub

    Private Sub btnAEONCreate_Click(sender As Object, e As EventArgs) Handles btnAEONCreate.Click
        Dim aeon As New clsAEON
        If optAEONNew.Checked Then
            Dim rst As String
            txtAEONSeed.Text = ""
            rst = aeon.CreateNew(txtAEONName.Text, txtAEONPassword.Text)
            txtAEONSeed.Text = rst
        End If
    End Sub

    Private Sub EnablebtnAEONCreate()
        If optAEONNew.Checked Then
            If txtAEONName.Text.Trim <> "" And txtAEONPassword.Text.Trim <> "" Then
                btnAEONCreate.Enabled = True
            Else
                btnAEONCreate.Enabled = False
            End If
        ElseIf optAEONExisting.Checked Then
            If txtAEONName.Text.Trim <> "" And txtAEONPassword.Text.Trim <> "" Then
                btnAEONCreate.Enabled = True
            Else
                btnAEONCreate.Enabled = False
            End If
        Else
            btnAEONCreate.Enabled = False
        End If
    End Sub
End Class
