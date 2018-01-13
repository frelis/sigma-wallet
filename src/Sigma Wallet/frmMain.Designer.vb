<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.flowpanel = New System.Windows.Forms.FlowLayoutPanel()
        Me.SuspendLayout()
        '
        'flowpanel
        '
        Me.flowpanel.AutoScroll = True
        Me.flowpanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.flowpanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.flowpanel.Location = New System.Drawing.Point(0, 0)
        Me.flowpanel.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.flowpanel.Name = "flowpanel"
        Me.flowpanel.Size = New System.Drawing.Size(426, 598)
        Me.flowpanel.TabIndex = 0
        Me.flowpanel.WrapContents = False
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(426, 598)
        Me.Controls.Add(Me.flowpanel)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MinimumSize = New System.Drawing.Size(439, 627)
        Me.Name = "frmMain"
        Me.Text = "Σ Wallet"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents flowpanel As FlowLayoutPanel
End Class
