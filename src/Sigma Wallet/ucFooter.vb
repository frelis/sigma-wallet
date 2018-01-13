Public Class ucFooter
    Private Sub AddNew_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Width = Me.Parent.Width
    End Sub

    Private Sub btnAddNew_Click(sender As Object, e As EventArgs) Handles btnAddNew.Click
        Me.Enabled = False
        Try
            Dim frm As New frmAddNew
            frm.ShowDialog()
        Catch ex As Exception

        End Try
        Me.Enabled = True
    End Sub
End Class
