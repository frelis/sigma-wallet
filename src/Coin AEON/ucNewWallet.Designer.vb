<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucNewWallet
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
        Me.txtAEONName = New System.Windows.Forms.TextBox()
        Me.btnAEONCreate = New System.Windows.Forms.Button()
        Me.txtAEONSeed = New System.Windows.Forms.TextBox()
        Me.lblAEONSeed = New System.Windows.Forms.Label()
        Me.txtAEONPassword = New System.Windows.Forms.TextBox()
        Me.lblAEONPassword = New System.Windows.Forms.Label()
        Me.lblAEONName = New System.Windows.Forms.Label()
        Me.optAEONExisting = New System.Windows.Forms.RadioButton()
        Me.optAEONNew = New System.Windows.Forms.RadioButton()
        Me.lblName = New System.Windows.Forms.Label()
        Me.btnBack = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'txtAEONName
        '
        Me.txtAEONName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAEONName.Location = New System.Drawing.Point(14, 114)
        Me.txtAEONName.Name = "txtAEONName"
        Me.txtAEONName.Size = New System.Drawing.Size(473, 26)
        Me.txtAEONName.TabIndex = 11
        '
        'btnAEONCreate
        '
        Me.btnAEONCreate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAEONCreate.Enabled = False
        Me.btnAEONCreate.Location = New System.Drawing.Point(382, 399)
        Me.btnAEONCreate.Name = "btnAEONCreate"
        Me.btnAEONCreate.Size = New System.Drawing.Size(105, 37)
        Me.btnAEONCreate.TabIndex = 17
        Me.btnAEONCreate.Text = "Create"
        Me.btnAEONCreate.UseVisualStyleBackColor = True
        '
        'txtAEONSeed
        '
        Me.txtAEONSeed.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAEONSeed.Location = New System.Drawing.Point(14, 251)
        Me.txtAEONSeed.Multiline = True
        Me.txtAEONSeed.Name = "txtAEONSeed"
        Me.txtAEONSeed.Size = New System.Drawing.Size(473, 142)
        Me.txtAEONSeed.TabIndex = 16
        Me.txtAEONSeed.Visible = False
        '
        'lblAEONSeed
        '
        Me.lblAEONSeed.AutoSize = True
        Me.lblAEONSeed.Location = New System.Drawing.Point(10, 228)
        Me.lblAEONSeed.Name = "lblAEONSeed"
        Me.lblAEONSeed.Size = New System.Drawing.Size(95, 20)
        Me.lblAEONSeed.TabIndex = 15
        Me.lblAEONSeed.Text = "Wallet Seed"
        Me.lblAEONSeed.Visible = False
        '
        'txtAEONPassword
        '
        Me.txtAEONPassword.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAEONPassword.Location = New System.Drawing.Point(14, 182)
        Me.txtAEONPassword.Name = "txtAEONPassword"
        Me.txtAEONPassword.Size = New System.Drawing.Size(473, 26)
        Me.txtAEONPassword.TabIndex = 14
        '
        'lblAEONPassword
        '
        Me.lblAEONPassword.AutoSize = True
        Me.lblAEONPassword.Location = New System.Drawing.Point(10, 159)
        Me.lblAEONPassword.Name = "lblAEONPassword"
        Me.lblAEONPassword.Size = New System.Drawing.Size(126, 20)
        Me.lblAEONPassword.TabIndex = 13
        Me.lblAEONPassword.Text = "Wallet Password"
        '
        'lblAEONName
        '
        Me.lblAEONName.AutoSize = True
        Me.lblAEONName.Location = New System.Drawing.Point(10, 91)
        Me.lblAEONName.Name = "lblAEONName"
        Me.lblAEONName.Size = New System.Drawing.Size(99, 20)
        Me.lblAEONName.TabIndex = 12
        Me.lblAEONName.Text = "Wallet Name"
        '
        'optAEONExisting
        '
        Me.optAEONExisting.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.optAEONExisting.AutoSize = True
        Me.optAEONExisting.Location = New System.Drawing.Point(260, 43)
        Me.optAEONExisting.Name = "optAEONExisting"
        Me.optAEONExisting.Size = New System.Drawing.Size(137, 24)
        Me.optAEONExisting.TabIndex = 10
        Me.optAEONExisting.TabStop = True
        Me.optAEONExisting.Text = "Existing Wallet"
        Me.optAEONExisting.UseVisualStyleBackColor = True
        '
        'optAEONNew
        '
        Me.optAEONNew.AutoSize = True
        Me.optAEONNew.Location = New System.Drawing.Point(14, 43)
        Me.optAEONNew.Name = "optAEONNew"
        Me.optAEONNew.Size = New System.Drawing.Size(113, 24)
        Me.optAEONNew.TabIndex = 9
        Me.optAEONNew.TabStop = True
        Me.optAEONNew.Text = "New Wallet"
        Me.optAEONNew.UseVisualStyleBackColor = True
        '
        'lblName
        '
        Me.lblName.AutoSize = True
        Me.lblName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblName.Location = New System.Drawing.Point(10, 5)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(58, 20)
        Me.lblName.TabIndex = 18
        Me.lblName.Text = "AEON"
        '
        'btnBack
        '
        Me.btnBack.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnBack.Location = New System.Drawing.Point(14, 399)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(105, 37)
        Me.btnBack.TabIndex = 19
        Me.btnBack.Text = "<< Back"
        Me.btnBack.UseVisualStyleBackColor = True
        '
        'ucNewWallet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.btnBack)
        Me.Controls.Add(Me.lblName)
        Me.Controls.Add(Me.txtAEONName)
        Me.Controls.Add(Me.btnAEONCreate)
        Me.Controls.Add(Me.txtAEONSeed)
        Me.Controls.Add(Me.lblAEONSeed)
        Me.Controls.Add(Me.txtAEONPassword)
        Me.Controls.Add(Me.lblAEONPassword)
        Me.Controls.Add(Me.lblAEONName)
        Me.Controls.Add(Me.optAEONExisting)
        Me.Controls.Add(Me.optAEONNew)
        Me.Name = "ucNewWallet"
        Me.Size = New System.Drawing.Size(499, 449)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtAEONName As Windows.Forms.TextBox
    Friend WithEvents btnAEONCreate As Windows.Forms.Button
    Friend WithEvents txtAEONSeed As Windows.Forms.TextBox
    Friend WithEvents lblAEONSeed As Windows.Forms.Label
    Friend WithEvents txtAEONPassword As Windows.Forms.TextBox
    Friend WithEvents lblAEONPassword As Windows.Forms.Label
    Friend WithEvents lblAEONName As Windows.Forms.Label
    Friend WithEvents optAEONExisting As Windows.Forms.RadioButton
    Friend WithEvents optAEONNew As Windows.Forms.RadioButton
    Friend WithEvents lblName As Windows.Forms.Label
    Friend WithEvents btnBack As Windows.Forms.Button
End Class
