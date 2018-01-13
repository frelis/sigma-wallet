<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAddNew
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
        Me.tabctrl = New System.Windows.Forms.TabControl()
        Me.tpWalletType = New System.Windows.Forms.TabPage()
        Me.btnStep1Next = New System.Windows.Forms.Button()
        Me.optWalletAeon = New System.Windows.Forms.RadioButton()
        Me.tpAEON = New System.Windows.Forms.TabPage()
        Me.btnAEONCreate = New System.Windows.Forms.Button()
        Me.txtAEONSeed = New System.Windows.Forms.TextBox()
        Me.lblAEONSeed = New System.Windows.Forms.Label()
        Me.txtAEONPassword = New System.Windows.Forms.TextBox()
        Me.lblAEONPassword = New System.Windows.Forms.Label()
        Me.lblAEONName = New System.Windows.Forms.Label()
        Me.txtAEONName = New System.Windows.Forms.TextBox()
        Me.optAEONExisting = New System.Windows.Forms.RadioButton()
        Me.optAEONNew = New System.Windows.Forms.RadioButton()
        Me.tabctrl.SuspendLayout()
        Me.tpWalletType.SuspendLayout()
        Me.tpAEON.SuspendLayout()
        Me.SuspendLayout()
        '
        'tabctrl
        '
        Me.tabctrl.Alignment = System.Windows.Forms.TabAlignment.Bottom
        Me.tabctrl.Controls.Add(Me.tpWalletType)
        Me.tabctrl.Controls.Add(Me.tpAEON)
        Me.tabctrl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabctrl.Location = New System.Drawing.Point(0, 0)
        Me.tabctrl.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.tabctrl.Name = "tabctrl"
        Me.tabctrl.SelectedIndex = 0
        Me.tabctrl.Size = New System.Drawing.Size(289, 283)
        Me.tabctrl.TabIndex = 0
        '
        'tpWalletType
        '
        Me.tpWalletType.Controls.Add(Me.btnStep1Next)
        Me.tpWalletType.Controls.Add(Me.optWalletAeon)
        Me.tpWalletType.Location = New System.Drawing.Point(4, 4)
        Me.tpWalletType.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.tpWalletType.Name = "tpWalletType"
        Me.tpWalletType.Padding = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.tpWalletType.Size = New System.Drawing.Size(281, 257)
        Me.tpWalletType.TabIndex = 0
        Me.tpWalletType.Text = "Step 1: Wallet Type"
        Me.tpWalletType.UseVisualStyleBackColor = True
        '
        'btnStep1Next
        '
        Me.btnStep1Next.Enabled = False
        Me.btnStep1Next.Location = New System.Drawing.Point(207, 229)
        Me.btnStep1Next.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.btnStep1Next.Name = "btnStep1Next"
        Me.btnStep1Next.Size = New System.Drawing.Size(70, 24)
        Me.btnStep1Next.TabIndex = 1
        Me.btnStep1Next.Text = "Next >>"
        Me.btnStep1Next.UseVisualStyleBackColor = True
        '
        'optWalletAeon
        '
        Me.optWalletAeon.AutoSize = True
        Me.optWalletAeon.Location = New System.Drawing.Point(13, 20)
        Me.optWalletAeon.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.optWalletAeon.Name = "optWalletAeon"
        Me.optWalletAeon.Size = New System.Drawing.Size(88, 17)
        Me.optWalletAeon.TabIndex = 0
        Me.optWalletAeon.TabStop = True
        Me.optWalletAeon.Text = "AEON Wallet"
        Me.optWalletAeon.UseVisualStyleBackColor = True
        '
        'tpAEON
        '
        Me.tpAEON.Controls.Add(Me.txtAEONName)
        Me.tpAEON.Controls.Add(Me.btnAEONCreate)
        Me.tpAEON.Controls.Add(Me.txtAEONSeed)
        Me.tpAEON.Controls.Add(Me.lblAEONSeed)
        Me.tpAEON.Controls.Add(Me.txtAEONPassword)
        Me.tpAEON.Controls.Add(Me.lblAEONPassword)
        Me.tpAEON.Controls.Add(Me.lblAEONName)
        Me.tpAEON.Controls.Add(Me.optAEONExisting)
        Me.tpAEON.Controls.Add(Me.optAEONNew)
        Me.tpAEON.Location = New System.Drawing.Point(4, 4)
        Me.tpAEON.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.tpAEON.Name = "tpAEON"
        Me.tpAEON.Padding = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.tpAEON.Size = New System.Drawing.Size(281, 257)
        Me.tpAEON.TabIndex = 1
        Me.tpAEON.Text = "Step 2: AEON Wallet"
        Me.tpAEON.UseVisualStyleBackColor = True
        '
        'btnAEONCreate
        '
        Me.btnAEONCreate.Enabled = False
        Me.btnAEONCreate.Location = New System.Drawing.Point(207, 229)
        Me.btnAEONCreate.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.btnAEONCreate.Name = "btnAEONCreate"
        Me.btnAEONCreate.Size = New System.Drawing.Size(70, 24)
        Me.btnAEONCreate.TabIndex = 8
        Me.btnAEONCreate.Text = "Create"
        Me.btnAEONCreate.UseVisualStyleBackColor = True
        '
        'txtAEONSeed
        '
        Me.txtAEONSeed.Location = New System.Drawing.Point(8, 155)
        Me.txtAEONSeed.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.txtAEONSeed.Multiline = True
        Me.txtAEONSeed.Name = "txtAEONSeed"
        Me.txtAEONSeed.Size = New System.Drawing.Size(272, 68)
        Me.txtAEONSeed.TabIndex = 7
        '
        'lblAEONSeed
        '
        Me.lblAEONSeed.AutoSize = True
        Me.lblAEONSeed.Location = New System.Drawing.Point(5, 140)
        Me.lblAEONSeed.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblAEONSeed.Name = "lblAEONSeed"
        Me.lblAEONSeed.Size = New System.Drawing.Size(65, 13)
        Me.lblAEONSeed.TabIndex = 6
        Me.lblAEONSeed.Text = "Wallet Seed"
        '
        'txtAEONPassword
        '
        Me.txtAEONPassword.Location = New System.Drawing.Point(8, 105)
        Me.txtAEONPassword.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.txtAEONPassword.Name = "txtAEONPassword"
        Me.txtAEONPassword.Size = New System.Drawing.Size(272, 20)
        Me.txtAEONPassword.TabIndex = 5
        '
        'lblAEONPassword
        '
        Me.lblAEONPassword.AutoSize = True
        Me.lblAEONPassword.Location = New System.Drawing.Point(5, 90)
        Me.lblAEONPassword.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblAEONPassword.Name = "lblAEONPassword"
        Me.lblAEONPassword.Size = New System.Drawing.Size(86, 13)
        Me.lblAEONPassword.TabIndex = 4
        Me.lblAEONPassword.Text = "Wallet Password"
        '
        'lblAEONName
        '
        Me.lblAEONName.AutoSize = True
        Me.lblAEONName.Location = New System.Drawing.Point(5, 44)
        Me.lblAEONName.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblAEONName.Name = "lblAEONName"
        Me.lblAEONName.Size = New System.Drawing.Size(68, 13)
        Me.lblAEONName.TabIndex = 3
        Me.lblAEONName.Text = "Wallet Name"
        '
        'txtAEONName
        '
        Me.txtAEONName.Location = New System.Drawing.Point(8, 59)
        Me.txtAEONName.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.txtAEONName.Name = "txtAEONName"
        Me.txtAEONName.Size = New System.Drawing.Size(272, 20)
        Me.txtAEONName.TabIndex = 2
        '
        'optAEONExisting
        '
        Me.optAEONExisting.AutoSize = True
        Me.optAEONExisting.Location = New System.Drawing.Point(124, 12)
        Me.optAEONExisting.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.optAEONExisting.Name = "optAEONExisting"
        Me.optAEONExisting.Size = New System.Drawing.Size(94, 17)
        Me.optAEONExisting.TabIndex = 1
        Me.optAEONExisting.TabStop = True
        Me.optAEONExisting.Text = "Existing Wallet"
        Me.optAEONExisting.UseVisualStyleBackColor = True
        '
        'optAEONNew
        '
        Me.optAEONNew.AutoSize = True
        Me.optAEONNew.Location = New System.Drawing.Point(8, 12)
        Me.optAEONNew.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.optAEONNew.Name = "optAEONNew"
        Me.optAEONNew.Size = New System.Drawing.Size(80, 17)
        Me.optAEONNew.TabIndex = 0
        Me.optAEONNew.TabStop = True
        Me.optAEONNew.Text = "New Wallet"
        Me.optAEONNew.UseVisualStyleBackColor = True
        '
        'frmAddNew
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(289, 283)
        Me.Controls.Add(Me.tabctrl)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Name = "frmAddNew"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "frmAddNew"
        Me.tabctrl.ResumeLayout(False)
        Me.tpWalletType.ResumeLayout(False)
        Me.tpWalletType.PerformLayout()
        Me.tpAEON.ResumeLayout(False)
        Me.tpAEON.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents tabctrl As TabControl
    Friend WithEvents tpWalletType As TabPage
    Friend WithEvents btnStep1Next As Button
    Friend WithEvents optWalletAeon As RadioButton
    Friend WithEvents tpAEON As TabPage
    Friend WithEvents optAEONNew As RadioButton
    Friend WithEvents btnAEONCreate As Button
    Friend WithEvents txtAEONSeed As TextBox
    Friend WithEvents lblAEONSeed As Label
    Friend WithEvents txtAEONPassword As TextBox
    Friend WithEvents lblAEONPassword As Label
    Friend WithEvents lblAEONName As Label
    Friend WithEvents txtAEONName As TextBox
    Friend WithEvents optAEONExisting As RadioButton
End Class
