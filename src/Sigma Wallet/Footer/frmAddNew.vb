﻿Imports frelis

Friend Class frmAddNew
    Private mCoins As New List(Of itCoin)
    Private mWallet As New Coin.Wallet

    Friend Function Open(Coins As List(Of itCoin)) As Coin.Wallet
        mCoins = Coins
        Me.ShowDialog()
        Return mWallet
    End Function

    Private Sub frmAddNew_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For Each coin As itCoin In mCoins
            Dim opt As New RadioButton
            opt.Text = coin.CoinName
            opt.Name = "opt" + coin.CoinName
            opt.Margin = New Padding(15, 5, 10, 10)
            AddHandler opt.CheckedChanged, AddressOf optCheckedChanged
            flowpanel.Controls.Add(opt)
        Next
        If mCoins.Count = 1 Then
            CType(Me.flowpanel.Controls.Item("opt" + mCoins(0).CoinName), RadioButton).Checked = True
            btnNext_Click(sender, e)
        End If
    End Sub

    Private Sub optCheckedChanged(sender As Object, e As EventArgs)
        If btnNext.Enabled = False Then btnNext.Enabled = True
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        Me.Enabled = False
        Try
            For Each opt As Control In flowpanel.Controls
                If opt.Name.StartsWith("opt") Then
                    If CType(opt, RadioButton).Checked Then
                        For Each coin As itCoin In mCoins
                            If coin.CoinName = opt.Text Then
                                For Each ucrtl As Control In Me.Controls
                                    If ucrtl.Name = "uc" + coin.CoinName Then
                                        NewWalleVisible(ucrtl)
                                        Me.Enabled = True
                                        Exit Sub
                                    End If
                                Next
                                Dim uc As UserControl
                                uc = coin.NewWalletControl
                                uc.Name = "uc" + coin.CoinName
                                Me.Controls.Add(uc)
                                AddHandler coin.NewWalletCreated, AddressOf NewWalletCreated
                                uc.Parent = Me
                                uc.Dock = DockStyle.Fill
                                NewWalleVisible(uc)
                                AddHandler uc.VisibleChanged, AddressOf NewWalleNotVisible
                            End If
                        Next
                        Exit For
                    End If
                End If
            Next
        Catch ex As Exception
            Log.Error("New Wallet btnNext", ex)
        End Try
        Me.Enabled = True
    End Sub

    Private Sub NewWalletCreated(newWallet As Coin.Wallet)
        mWallet = newWallet
        Me.Close()
    End Sub

    Private Sub NewWalleNotVisible(sender As Object, e As EventArgs)
        If sender.GetType.BaseType.Name = "UserControl" Then
            Dim uc As UserControl = CType(sender, UserControl)
            If uc.Visible = False Then
                For Each c As Control In Me.Controls
                    c.Visible = False
                Next
                Me.flowpanel.Visible = True
                Me.btnNext.Visible = True
            End If
        End If
    End Sub

    Sub NewWalleVisible(newWalletControl As Control)
        For Each c As Control In Me.Controls
            If c.Name <> newWalletControl.Name Then c.Visible = False
        Next
        newWalletControl.Visible = True
    End Sub

End Class