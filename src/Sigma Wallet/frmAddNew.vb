Public Class frmAddNew
    Private Sub optAeon_CheckedChanged(sender As Object, e As EventArgs) Handles optWalletAeon.CheckedChanged
        If optWalletAeon.Checked Then btnStep1Next.Enabled = True
    End Sub

    Private Sub btnStep1Next_Click(sender As Object, e As EventArgs) Handles btnStep1Next.Click
        If optWalletAeon.Checked Then ShowTabPage(tpAEON)
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

#Region "Handle Tab pages visibility"
    Private Sub HideTabPage(ByVal tp As TabPage)
        If tabctrl.TabPages.Contains(tp) Then tabctrl.TabPages.Remove(tp)
    End Sub

    Private Sub ShowTabPage(ByVal tp As TabPage)
        ShowTabPage(tp, tabctrl.TabPages.Count)
    End Sub

    Private Sub ShowTabPage(ByVal tp As TabPage, ByVal index As Integer)
        If tabctrl.TabPages.Contains(tp) Then Return
        InsertTabPage(tp, index)
    End Sub

    Private Sub InsertTabPage(ByVal tabpage As TabPage, ByVal index As Integer)
        If index < 0 OrElse index > tabctrl.TabCount Then Throw New ArgumentException("Index out of Range.")
        tabctrl.TabPages.Add(tabpage)
        If index < tabctrl.TabCount - 1 Then
            Do
                SwapTabPages(tabpage, (tabctrl.TabPages(tabctrl.TabPages.IndexOf(tabpage) - 1)))
            Loop While tabctrl.TabPages.IndexOf(tabpage) <> index
        End If

        tabctrl.SelectedTab = tabpage
    End Sub

    Private Sub SwapTabPages(ByVal tp1 As TabPage, ByVal tp2 As TabPage)
        If tabctrl.TabPages.Contains(tp1) = False OrElse tabctrl.TabPages.Contains(tp2) = False Then
            Throw New ArgumentException("TabPages must be in the TabControls TabPageCollection.")
        End If
        Dim Index1 As Integer = tabctrl.TabPages.IndexOf(tp1)
        Dim Index2 As Integer = tabctrl.TabPages.IndexOf(tp2)
        tabctrl.TabPages(Index1) = tp2
        tabctrl.TabPages(Index2) = tp1
    End Sub

    Private Sub frmAddNew_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        HideTabPage(tpAEON)
    End Sub

    Private Sub optAEONNew_CheckedChanged(sender As Object, e As EventArgs) Handles optAEONNew.CheckedChanged
        If optAEONNew.Checked Then EnablebtnAEONCreate()
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

    Private Sub txtAEONName_TextChanged(sender As Object, e As EventArgs) Handles txtAEONName.TextChanged
        EnablebtnAEONCreate()
    End Sub

    Private Sub txtAEONPassword_TextChanged(sender As Object, e As EventArgs) Handles txtAEONPassword.TextChanged
        EnablebtnAEONCreate()
    End Sub

    Private Sub txtAEONSeed_TextChanged(sender As Object, e As EventArgs) Handles txtAEONSeed.TextChanged
        EnablebtnAEONCreate()
    End Sub
#End Region


End Class