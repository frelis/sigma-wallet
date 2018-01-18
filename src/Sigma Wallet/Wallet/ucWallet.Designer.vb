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
        Me.pnlHeader.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(317, 26)
        Me.pnlHeader.TabIndex = 2
        '
        'lblCoin
        '
        Me.lblCoin.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCoin.Location = New System.Drawing.Point(245, 5)
        Me.lblCoin.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblCoin.Name = "lblCoin"
        Me.lblCoin.Size = New System.Drawing.Size(62, 18)
        Me.lblCoin.TabIndex = 2
        Me.lblCoin.Text = "Coin"
        Me.lblCoin.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblName
        '
        Me.lblName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblName.Location = New System.Drawing.Point(6, 5)
        Me.lblName.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(205, 18)
        Me.lblName.TabIndex = 1
        Me.lblName.Text = "Name"
        '
        'lblValue
        '
        Me.lblValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblValue.Location = New System.Drawing.Point(6, 28)
        Me.lblValue.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblValue.Name = "lblValue"
        Me.lblValue.Size = New System.Drawing.Size(131, 18)
        Me.lblValue.TabIndex = 3
        Me.lblValue.Text = "Balance: "
        '
        'lblWallet
        '
        Me.lblWallet.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblWallet.AutoEllipsis = True
        Me.lblWallet.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWallet.Location = New System.Drawing.Point(23, 48)
        Me.lblWallet.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblWallet.Name = "lblWallet"
        Me.lblWallet.Padding = New System.Windows.Forms.Padding(7, 0, 0, 0)
        Me.lblWallet.Size = New System.Drawing.Size(291, 21)
        Me.lblWallet.TabIndex = 4
        Me.lblWallet.Text = "Wallet Address"
        Me.lblWallet.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'picCopywalletAdress
        '
        Me.picCopywalletAdress.Image = CType(resources.GetObject("picCopywalletAdress.Image"), System.Drawing.Image)
        Me.picCopywalletAdress.Location = New System.Drawing.Point(5, 48)
        Me.picCopywalletAdress.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.picCopywalletAdress.Name = "picCopywalletAdress"
        Me.picCopywalletAdress.Size = New System.Drawing.Size(21, 21)
        Me.picCopywalletAdress.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picCopywalletAdress.TabIndex = 5
        Me.picCopywalletAdress.TabStop = False
        '
        'progbarSync
        '
        Me.progbarSync.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.progbarSync.Location = New System.Drawing.Point(5, 80)
        Me.progbarSync.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.progbarSync.Name = "progbarSync"
        Me.progbarSync.Size = New System.Drawing.Size(227, 9)
        Me.progbarSync.Step = 1
        Me.progbarSync.TabIndex = 6
        '
        'btnSync
        '
        Me.btnSync.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSync.Location = New System.Drawing.Point(237, 80)
        Me.btnSync.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.btnSync.Name = "btnSync"
        Me.btnSync.Size = New System.Drawing.Size(71, 25)
        Me.btnSync.TabIndex = 7
        Me.btnSync.Text = "Start Sync"
        Me.btnSync.UseVisualStyleBackColor = True
        '
        'lblprogress
        '
        Me.lblprogress.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblprogress.AutoEllipsis = True
        Me.lblprogress.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblprogress.Location = New System.Drawing.Point(3, 91)
        Me.lblprogress.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblprogress.Name = "lblprogress"
        Me.lblprogress.Size = New System.Drawing.Size(230, 14)
        Me.lblprogress.TabIndex = 8
        Me.lblprogress.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblStatus
        '
        Me.lblStatus.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblStatus.AutoEllipsis = True
        Me.lblStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatus.Location = New System.Drawing.Point(141, 28)
        Me.lblStatus.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(166, 18)
        Me.lblStatus.TabIndex = 9
        Me.lblStatus.Text = "Never Sync"
        Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'ucWallet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.lblprogress)
        Me.Controls.Add(Me.btnSync)
        Me.Controls.Add(Me.progbarSync)
        Me.Controls.Add(Me.picCopywalletAdress)
        Me.Controls.Add(Me.lblWallet)
        Me.Controls.Add(Me.lblValue)
        Me.Controls.Add(Me.pnlHeader)
        Me.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Name = "ucWallet"
        Me.Size = New System.Drawing.Size(317, 77)
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
End Class
