<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucHeader
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ucHeader))
        Me.picConfig = New System.Windows.Forms.PictureBox()
        CType(Me.picConfig, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'picConfig
        '
        Me.picConfig.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.picConfig.Image = CType(resources.GetObject("picConfig.Image"), System.Drawing.Image)
        Me.picConfig.Location = New System.Drawing.Point(279, 8)
        Me.picConfig.Margin = New System.Windows.Forms.Padding(2)
        Me.picConfig.Name = "picConfig"
        Me.picConfig.Size = New System.Drawing.Size(32, 32)
        Me.picConfig.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picConfig.TabIndex = 0
        Me.picConfig.TabStop = False
        '
        'ucHeader
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.picConfig)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "ucHeader"
        Me.Size = New System.Drawing.Size(319, 50)
        CType(Me.picConfig, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents picConfig As PictureBox
End Class
