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
        Me.progbarSync = New System.Windows.Forms.ProgressBar()
        Me.btnSync = New System.Windows.Forms.Button()
        Me.lblprogress = New System.Windows.Forms.Label()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnMov = New System.Windows.Forms.Button()
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
        Me.pnlHeader.Size = New System.Drawing.Size(476, 40)
        Me.pnlHeader.TabIndex = 2
        '
        'lblCoin
        '
        Me.lblCoin.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCoin.Location = New System.Drawing.Point(368, 8)
        Me.lblCoin.Name = "lblCoin"
        Me.lblCoin.Size = New System.Drawing.Size(93, 28)
        Me.lblCoin.TabIndex = 2
        Me.lblCoin.Text = "!Coin"
        Me.lblCoin.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblName
        '
        Me.lblName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblName.Location = New System.Drawing.Point(9, 8)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(308, 28)
        Me.lblName.TabIndex = 1
        Me.lblName.Text = "!Name"
        '
        'lblValue
        '
        Me.lblValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblValue.Location = New System.Drawing.Point(9, 43)
        Me.lblValue.Name = "lblValue"
        Me.lblValue.Size = New System.Drawing.Size(196, 28)
        Me.lblValue.TabIndex = 3
        Me.lblValue.Text = "!Balance: 123.123"
        '
        'lblWallet
        '
        Me.lblWallet.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblWallet.AutoEllipsis = True
        Me.lblWallet.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWallet.Location = New System.Drawing.Point(34, 74)
        Me.lblWallet.Name = "lblWallet"
        Me.lblWallet.Padding = New System.Windows.Forms.Padding(10, 0, 0, 0)
        Me.lblWallet.Size = New System.Drawing.Size(436, 32)
        Me.lblWallet.TabIndex = 4
        Me.lblWallet.Text = "!Wallet Address"
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
        'progbarSync
        '
        Me.progbarSync.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.progbarSync.Location = New System.Drawing.Point(8, 123)
        Me.progbarSync.Name = "progbarSync"
        Me.progbarSync.Size = New System.Drawing.Size(324, 14)
        Me.progbarSync.Step = 1
        Me.progbarSync.TabIndex = 6
        '
        'btnSync
        '
        Me.btnSync.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSync.Location = New System.Drawing.Point(338, 123)
        Me.btnSync.Name = "btnSync"
        Me.btnSync.Size = New System.Drawing.Size(124, 38)
        Me.btnSync.TabIndex = 7
        Me.btnSync.Text = "_Start Sync_"
        Me.btnSync.UseVisualStyleBackColor = True
        '
        'lblprogress
        '
        Me.lblprogress.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblprogress.AutoEllipsis = True
        Me.lblprogress.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblprogress.Location = New System.Drawing.Point(4, 140)
        Me.lblprogress.Name = "lblprogress"
        Me.lblprogress.Size = New System.Drawing.Size(328, 31)
        Me.lblprogress.TabIndex = 8
        Me.lblprogress.Text = "!"
        Me.lblprogress.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblStatus
        '
        Me.lblStatus.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblStatus.AutoEllipsis = True
        Me.lblStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatus.Location = New System.Drawing.Point(212, 43)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(249, 28)
        Me.lblStatus.TabIndex = 9
        Me.lblStatus.Text = "_Never Synced_"
        Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(3, 174)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(124, 38)
        Me.btnDelete.TabIndex = 10
        Me.btnDelete.Text = "_Delete_"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnMov
        '
        Me.btnMov.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMov.Location = New System.Drawing.Point(338, 174)
        Me.btnMov.Name = "btnMov"
        Me.btnMov.Size = New System.Drawing.Size(124, 38)
        Me.btnMov.TabIndex = 11
        Me.btnMov.Text = "_Movements_"
        Me.btnMov.UseVisualStyleBackColor = True
        '
        'ucWallet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.btnMov)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.lblprogress)
        Me.Controls.Add(Me.btnSync)
        Me.Controls.Add(Me.progbarSync)
        Me.Controls.Add(Me.picCopywalletAdress)
        Me.Controls.Add(Me.lblWallet)
        Me.Controls.Add(Me.lblValue)
        Me.Controls.Add(Me.pnlHeader)
        Me.Name = "ucWallet"
        Me.Size = New System.Drawing.Size(476, 268)
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
    Friend WithEvents progbarSync As ProgressBar
    Friend WithEvents btnSync As Button
    Friend WithEvents lblprogress As Label
    Friend WithEvents lblStatus As Label
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnMov As Button
End Class
