Imports System.Windows.Forms

Public Class ucNodes
    Dim mNodes As List(Of Coin.Node)
    Dim mSettings As Settings.SettingsData
    Dim mSelectedNode As String

    Private Sub ucNodes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim cfg As Coin.Coin_Settings
        cfg = Settings.read_settings(Of Coin.Coin_Settings)("settings_aeon.json")
        If IsNothing(cfg.nodes) Then cfg.nodes = New List(Of Coin.Node)
        mNodes = cfg.nodes
        For Each n As Coin.Node In mNodes
            lvwNodes.Items.Add(n.hostname + ":" + n.port.ToString)
        Next
        mSettings = Settings.Read()
        mSelectedNode = Settings.ReadSetting(mSettings, "AEON", "Nodes", "Selected Node")
        If mSelectedNode <> "" Then
            For Each lvwi As Windows.Forms.ListViewItem In lvwNodes.Items
                If lvwi.Text = mSelectedNode Then
                    lvwi.BackColor = Drawing.Color.LightBlue
                End If
            Next
        End If

    End Sub

    Private Sub ucNodes_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        lvwNodes.Columns(0).Width = lvwNodes.Width - lvwNodes.Columns(1).Width - Windows.Forms.SystemInformation.VerticalScrollBarWidth - 5
    End Sub

    Private Sub btnSpeed_Click(sender As Object, e As EventArgs) Handles btnSpeed.Click
        Me.Enabled = False
        Me.Cursor = Cursors.WaitCursor
        Dim canautoselect As Boolean = True
        Dim index2select As Integer
        Dim minping As Long = Long.MaxValue
        For Each lvwi As Windows.Forms.ListViewItem In lvwNodes.Items
            Dim rst As String = ""
            If lvwi.BackColor = Drawing.Color.LightBlue Then canautoselect = False
            Try
                If lvwi.SubItems.Count = 1 Then
                    lvwi.SubItems.Add("Checking ...")
                Else
                    lvwi.SubItems(1).Text = "Checking ..."
                End If
                Application.DoEvents()
                Dim ping As New Net.NetworkInformation.Ping
                Dim rpl As Net.NetworkInformation.PingReply
                rpl = ping.Send(lvwi.Text.Substring(0, lvwi.Text.IndexOf(":"c)), 2000)
                If rpl.Status = Net.NetworkInformation.IPStatus.Success Then
                    Using tcptest As New Net.Sockets.TcpClient
                        Try
                            tcptest.SendTimeout = rpl.RoundtripTime * 4
                            tcptest.ReceiveTimeout = rpl.RoundtripTime * 4
                            tcptest.Connect(lvwi.Text.Substring(0, lvwi.Text.IndexOf(":"c)), CInt(lvwi.Text.Substring(lvwi.Text.IndexOf(":"c) + 1)))
                            If tcptest.Connected Then
                                rst = rpl.RoundtripTime.ToString + " ms"
                            Else
                                rst = "No Server"
                            End If

                        Catch ex As Exception
                            rst = "No Server"
                        End Try
                        tcptest.Close()
                    End Using
                    If rpl.RoundtripTime < minping Then
                        index2select = lvwi.Index
                        minping = rpl.RoundtripTime
                    End If
                ElseIf rpl.Status = Net.NetworkInformation.IPStatus.TimedOut Then
                    rst = "Timeout"
                Else
                    rst = rpl.Status
                End If
            Catch ex As Exception
                rst = ex.Message
                Log.Error("Checking AEON Nodes", ex)
            End Try
            lvwi.SubItems(1).Text = rst
            lvwi.EnsureVisible()
            Application.DoEvents()
        Next
        If canautoselect Then
            lvwNodes.Items(index2select).Selected = True
        End If
        Me.Enabled = True
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub lvwNodes_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lvwNodes.SelectedIndexChanged
        Try
            If lvwNodes.SelectedItems.Count > 0 Then
                lvwNodes.SelectedItems(0).EnsureVisible()
                Settings.WriteSetting(mSettings, "AEON", "Nodes", "Selected Node", lvwNodes.SelectedItems(0).Text)
                lvwNodes.SelectedItems(0).BackColor = Drawing.Color.LightBlue
            End If
        Catch ex As Exception
            Log.Error("Select AEON Node", ex)
        End Try
    End Sub
End Class
