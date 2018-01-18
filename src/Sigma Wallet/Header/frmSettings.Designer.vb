<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSettings
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
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.tvwSections = New System.Windows.Forms.TreeView()
        Me.btnOk = New System.Windows.Forms.Button()
        Me.btnReset = New System.Windows.Forms.Button()
        Me.pnl = New System.Windows.Forms.Panel()
        Me.lblSettingsName = New System.Windows.Forms.Label()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.tvwSections)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnOk)
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnReset)
        Me.SplitContainer1.Panel2.Controls.Add(Me.pnl)
        Me.SplitContainer1.Panel2.Controls.Add(Me.lblSettingsName)
        Me.SplitContainer1.Size = New System.Drawing.Size(617, 504)
        Me.SplitContainer1.SplitterDistance = 191
        Me.SplitContainer1.TabIndex = 0
        '
        'tvwSections
        '
        Me.tvwSections.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tvwSections.Location = New System.Drawing.Point(0, 0)
        Me.tvwSections.Name = "tvwSections"
        Me.tvwSections.Size = New System.Drawing.Size(191, 504)
        Me.tvwSections.TabIndex = 0
        '
        'btnOk
        '
        Me.btnOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOk.Location = New System.Drawing.Point(300, 454)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(110, 38)
        Me.btnOk.TabIndex = 4
        Me.btnOk.Text = "OK"
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'btnReset
        '
        Me.btnReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnReset.Location = New System.Drawing.Point(12, 454)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(110, 38)
        Me.btnReset.TabIndex = 3
        Me.btnReset.Text = "Reset"
        Me.btnReset.UseVisualStyleBackColor = True
        '
        'pnl
        '
        Me.pnl.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnl.AutoScroll = True
        Me.pnl.Location = New System.Drawing.Point(7, 32)
        Me.pnl.Name = "pnl"
        Me.pnl.Size = New System.Drawing.Size(412, 410)
        Me.pnl.TabIndex = 2
        '
        'lblSettingsName
        '
        Me.lblSettingsName.AutoSize = True
        Me.lblSettingsName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSettingsName.Location = New System.Drawing.Point(3, 9)
        Me.lblSettingsName.Name = "lblSettingsName"
        Me.lblSettingsName.Size = New System.Drawing.Size(63, 20)
        Me.lblSettingsName.TabIndex = 1
        Me.lblSettingsName.Text = "Label1"
        '
        'frmSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(617, 504)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "frmSettings"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Settings"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents tvwSections As TreeView
    Friend WithEvents btnOk As Button
    Friend WithEvents btnReset As Button
    Friend WithEvents pnl As Panel
    Friend WithEvents lblSettingsName As Label
End Class
