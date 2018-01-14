<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ucWallet
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ucWallet))
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.lblCoin = New System.Windows.Forms.Label()
        Me.lblName = New System.Windows.Forms.Label()
        Me.lblValue = New System.Windows.Forms.Label()
        Me.lblWallet = New System.Windows.Forms.Label()
        Me.picCopywalletAdress = New System.Windows.Forms.PictureBox()
        Me.pnlHeader.SuspendLayout()
        CType(Me.picCopywalletAdress, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlHeader
        '
        Me.pnlHeader.Controls.Add(Me.lblCoin)
        Me.pnlHeader.Controls.Add(Me.lblName)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(475, 40)
        Me.pnlHeader.TabIndex = 2
        '
        'lblCoin
        '
        Me.lblCoin.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCoin.Location = New System.Drawing.Point(368, 8)
        Me.lblCoin.Name = "lblCoin"
        Me.lblCoin.Size = New System.Drawing.Size(93, 28)
        Me.lblCoin.TabIndex = 2
        Me.lblCoin.Text = "Coin"
        Me.lblCoin.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblName
        '
        Me.lblName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblName.Location = New System.Drawing.Point(9, 8)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(308, 28)
        Me.lblName.TabIndex = 1
        Me.lblName.Text = "Name"
        '
        'lblValue
        '
        Me.lblValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblValue.Location = New System.Drawing.Point(9, 43)
        Me.lblValue.Name = "lblValue"
        Me.lblValue.Size = New System.Drawing.Size(197, 28)
        Me.lblValue.TabIndex = 3
        Me.lblValue.Text = "Balance: "
        '
        'lblWallet
        '
        Me.lblWallet.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblWallet.AutoEllipsis = True
        Me.lblWallet.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWallet.Location = New System.Drawing.Point(35, 74)
        Me.lblWallet.Name = "lblWallet"
        Me.lblWallet.Padding = New System.Windows.Forms.Padding(10, 0, 0, 0)
        Me.lblWallet.Size = New System.Drawing.Size(437, 32)
        Me.lblWallet.TabIndex = 4
        Me.lblWallet.Text = "Wallet Address"
        Me.lblWallet.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'picCopywalletAdress
        '
        Me.picCopywalletAdress.Image = CType(resources.GetObject("picCopywalletAdress.Image"), System.Drawing.Image)
        Me.picCopywalletAdress.Location = New System.Drawing.Point(8, 74)
        Me.picCopywalletAdress.Name = "picCopywalletAdress"
        Me.picCopywalletAdress.Size = New System.Drawing.Size(32, 32)
        Me.picCopywalletAdress.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picCopywalletAdress.TabIndex = 5
        Me.picCopywalletAdress.TabStop = False
        '
        'ucWallet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.picCopywalletAdress)
        Me.Controls.Add(Me.lblWallet)
        Me.Controls.Add(Me.lblValue)
        Me.Controls.Add(Me.pnlHeader)
        Me.Name = "ucWallet"
        Me.Size = New System.Drawing.Size(475, 115)
        Me.pnlHeader.ResumeLayout(False)
        CType(Me.picCopywalletAdress, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlHeader As Panel
    Friend WithEvents lblCoin As Label
    Friend WithEvents lblName As Label
    Friend WithEvents lblValue As Label
    Friend WithEvents lblWallet As Label
    Friend WithEvents picCopywalletAdress As PictureBox
End Class
