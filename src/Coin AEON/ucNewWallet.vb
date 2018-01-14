Public Class ucNewAEONWallet
    Public Event NewWalletCreated(NewWallet As Coin.Wallet)

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Me.Visible = False
    End Sub

    Private Sub optAEONNew_CheckedChanged(sender As Object, e As EventArgs) Handles optAEONNew.CheckedChanged
        If optAEONNew.Checked Then
            EnablebtnAEONCreate()
        End If
    End Sub
    Private Sub optAEONExisting_CheckedChanged(sender As Object, e As EventArgs) Handles optAEONExisting.CheckedChanged
        If optAEONExisting.Checked Then
            EnablebtnAEONCreate()
        End If
    End Sub
    Private Sub HelpText(v As String)
        Throw New NotImplementedException()
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
            Dim rst As Coin.Wallet
            txtAEONSeed.Text = ""
            rst = aeon.CreateNew(txtAEONName.Text.Trim, txtAEONPassword.Text.Trim)
            If rst.coin <> "" Then
                RaiseEvent NewWalletCreated(rst)
            End If
        ElseIf optAEONExisting.Checked Then
            Dim aux() As String = txtAEONSeed.Text.Trim.Split(" "c)
            If aux.Length >= 24 Then
                txtAEONSeed.SuspendLayout()
                txtAEONSeed.Text = ""
                For i As Integer = 0 To 22
                    txtAEONSeed.Text = txtAEONSeed.Text + aux(i).Trim.ToLower + " "
                Next
                txtAEONSeed.Text = txtAEONSeed.Text + aux(23).Trim.ToLower
                txtAEONSeed.ResumeLayout()
            End If
        End If
    End Sub

    Private Sub EnablebtnAEONCreate()
        If optAEONNew.Checked Then
            txtAEONSeed.Visible = False
            lblAEONSeed.Visible = False
            If txtAEONName.Text.Trim <> "" And txtAEONPassword.Text.Trim <> "" Then
                btnAEONCreate.Enabled = True
                lblHelp.Text = "Click ""Create"" to create your new wallet."
            Else
                If txtAEONName.Text.Trim = "" Then
                    lblHelp.Text = "Choose a name for your wallet."
                Else
                    lblHelp.Text = "Choose a password for your wallet."
                End If
                btnAEONCreate.Enabled = False
            End If
        ElseIf optAEONExisting.Checked Then
            txtAEONSeed.Visible = True
            lblAEONSeed.Visible = True
            If txtAEONName.Text.Trim <> "" And txtAEONPassword.Text.Trim <> "" Then
                Dim aux() As String = txtAEONSeed.Text.Trim.Split(" "c)
                If aux.Length >= 24 Then
                    lblHelp.Text = "Click ""Create"" to create your new wallet."
                    btnAEONCreate.Enabled = True
                Else
                    lblHelp.Text = "Insert the 24 seed words of your wallet."
                    btnAEONCreate.Enabled = False
                End If
            Else
                If txtAEONName.Text.Trim = "" Then
                    lblHelp.Text = "Choose a name for your wallet."
                Else
                    lblHelp.Text = "Insert the password of your wallet."
                End If
                btnAEONCreate.Enabled = False
            End If
        Else
            btnAEONCreate.Enabled = False
        End If
    End Sub
End Class
