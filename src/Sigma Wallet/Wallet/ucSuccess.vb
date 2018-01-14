Public Class ucSuccess
    Public Sub Open(frm As Form, text As String, time_out As Integer)
        Try
            lblText.Text = text
            Parent = frm
            Top = 0
            Width = frm.Width
            pic1.Left = CInt((Width - pic1.Width) / 2)
            Me.Visible = True
            BackColor = Template.Current.border
            lblText.ForeColor = Template.Current.nonselected
            Me.BringToFront()
            Me.Refresh()
            Threading.Thread.Sleep(time_out * 1000)
            Me.Dispose()
        Catch ex As Exception
            Log.Error("Success Window", ex)
        End Try
    End Sub
End Class
