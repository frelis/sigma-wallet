<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucFooter
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btnAddNew = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnAddNew
        '
        Me.btnAddNew.Location = New System.Drawing.Point(12, 12)
        Me.btnAddNew.Name = "btnAddNew"
        Me.btnAddNew.Size = New System.Drawing.Size(171, 38)
        Me.btnAddNew.TabIndex = 0
        Me.btnAddNew.Text = "Add Wallet"
        Me.btnAddNew.UseVisualStyleBackColor = True
        '
        'ucFooter
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.btnAddNew)
        Me.Name = "ucFooter"
        Me.Size = New System.Drawing.Size(413, 63)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnAddNew As Button
End Class
