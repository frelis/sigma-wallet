<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucNodes
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
        Me.lvwNodes = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btnSpeed = New System.Windows.Forms.Button()
        Me.lblNodesList = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lvwNodes
        '
        Me.lvwNodes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvwNodes.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2})
        Me.lvwNodes.FullRowSelect = True
        Me.lvwNodes.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lvwNodes.Location = New System.Drawing.Point(6, 23)
        Me.lvwNodes.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.lvwNodes.MultiSelect = False
        Me.lvwNodes.Name = "lvwNodes"
        Me.lvwNodes.Size = New System.Drawing.Size(265, 155)
        Me.lvwNodes.TabIndex = 0
        Me.lvwNodes.UseCompatibleStateImageBehavior = False
        Me.lvwNodes.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "_Node Address_"
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "_Response Time_"
        Me.ColumnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnSpeed
        '
        Me.btnSpeed.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSpeed.Location = New System.Drawing.Point(6, 181)
        Me.btnSpeed.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.btnSpeed.Name = "btnSpeed"
        Me.btnSpeed.Size = New System.Drawing.Size(113, 21)
        Me.btnSpeed.TabIndex = 1
        Me.btnSpeed.Text = "_Check Nodes_"
        Me.btnSpeed.UseVisualStyleBackColor = True
        '
        'lblNodesList
        '
        Me.lblNodesList.AutoSize = True
        Me.lblNodesList.Location = New System.Drawing.Point(3, 6)
        Me.lblNodesList.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblNodesList.Name = "lblNodesList"
        Me.lblNodesList.Size = New System.Drawing.Size(65, 13)
        Me.lblNodesList.TabIndex = 2
        Me.lblNodesList.Text = "_Nodes list_"
        '
        'ucNodes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.lblNodesList)
        Me.Controls.Add(Me.btnSpeed)
        Me.Controls.Add(Me.lvwNodes)
        Me.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Name = "ucNodes"
        Me.Size = New System.Drawing.Size(276, 203)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lvwNodes As Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As Windows.Forms.ColumnHeader
    Friend WithEvents btnSpeed As Windows.Forms.Button
    Friend WithEvents lblNodesList As Windows.Forms.Label
End Class
