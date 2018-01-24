Public Class Lang
    Shared dict As New Dictionary(Of String, String)

    Shared Sub Load(lang As String)
        dict = Settings.read_settings(Of Dictionary(Of String, String))(Info.DirExe + "lang__" + lang + ".json")
        If dict Is Nothing Then dict = New Dictionary(Of String, String)
    End Sub

    Shared Function Str(key As String) As String
        Try
            Return dict(key)
        Catch
            Dim x As Dictionary(Of String, String)
            x = Settings.read_settings(Of Dictionary(Of String, String))(Info.DirData + "MissingStrings.json")
            If x Is Nothing Then x = New Dictionary(Of String, String)
            If x.ContainsKey(key) Then
                x(key) = CStr(CInt(x(key)) + 1)
            Else
                x.Add(key, "1")
            End If
            Settings.write_settings(Info.DirData + "MissingStrings.json", x)
            Return "!_" + key
        End Try
    End Function



    Private Shared Function Remove_Not_Translate_Char(ByVal txt As String) As String
        If txt(0) = "!" Then
            Return txt.Substring(1)
        End If
        Return txt
    End Function

    Private Shared Function Valid_Format(ByVal txt As String) As Boolean
        Try
            If txt(0) <> "_" OrElse txt(txt.Length - 1) <> "_" Then Return False
        Catch
            Return False
        End Try
        Return True
    End Function

    Private Shared Function Valid_Format(ByVal txt As String) As Boolean
        Try
            If txt(0) <> "_" OrElse txt(txt.Length - 1) <> "_" Then Return False
        Catch
            Return False
        End Try
        Return True
    End Function

    Private Shared Sub Translate_Control(Prefix As String, ByRef ctl As Windows.Forms.Control)
        If ctl.Text = "" Then Exit Sub

        If ctl.Text(0) = "!" Then
            ctl.Text = ctl.Text.Substring(1)
        Else
            If ctl.Text(0) <> "_" OrElse ctl.Text(ctl.Text.Length - 1) <> "_" Then
                Write_Invalid_Name_Control(ctl)
                ctl.Text = Str("_+_" + ctl.Text)
            Else
                ctl.Text = Str(Prefix + ctl.Text)
            End If
        End If
    End Sub


    Shared Sub Traduz_Control_Container(ByRef frm As Windows.Forms.Control)
        For Each ctl As Windows.Forms.Control In frm.Controls
            Select Case ctl.GetType.ToString.Replace("System.Windows.Forms.", "")
                Case "Label", "LinkLabel", "CheckBox", "RadioButton"
                    Translate_Control("L", ctl)
                Case "GroupBox"
                    Translate_Control("L", ctl)
                    Traduz_Control_Container(ctl)
                Case "DataGridView"
                    Dim col As Windows.Forms.DataGridViewColumn
                    For Each col In CType(ctl, Windows.Forms.DataGridView).Columns
                        If Should_not_Translate(col.HeaderText) Then
                            col.HeaderText = Remove_Not_Translate_Char(col.HeaderText)
                        Else
                            If Valid_Format(col.HeaderText) Then
                                ctl.Text = Me.S("L" + col.HeaderText)
                            Else
                                Write_Invalid_Name(ctl.GetType.ToString + "->" + ctl.Name + ".Coluna:" + col.HeaderText)
                                col.HeaderText = "_+_" + col.HeaderText
                            End If
                        End If
                    Next
                    If Not IsNothing(ctl.ContextMenuStrip) Then
                        Traduz_ContextMenu(ctl.ContextMenuStrip)
                    End If
                Case "TabControl"
                    Dim tPage As Windows.Forms.TabPage
                    For Each tPage In CType(ctl, Windows.Forms.TabControl).TabPages
                        If Should_not_Translate(tPage.Text) Then
                            tPage.Text = Remove_Not_Translate_Char(tPage.Text)
                        Else
                            If Valid_Format(tPage.Text) Then
                                tPage.Text = Me.S("L" + tPage.Text)
                            Else
                                Write_Invalid_Name(ctl.GetType.ToString + "->" + ctl.Name + ".TabPage:" + tPage.Text)
                                tPage.Text = "_+_" + tPage.Text
                            End If
                            Traduz_Control_Container(CType(tPage, Control))
                        End If
                    Next
                Case "Button"
                    Translate_Control("B", ctl)
                    If Not IsNothing(ctl.ContextMenuStrip) Then Traduz_ContextMenu(ctl.ContextMenuStrip)
                Case "TextBox", "ComboBox", "TreeView", "DateTimePicker", "PictureBox",
                    "ProgressBar", "ListBox", "WebBrowser", "StatusStrip", "RichTextBox",
                    "MaskedTextBox"
                    'Not Translatable
                Case "Panel", "SplitContainer", "SplitterPanel", "FlowLayoutPanel"
                    Traduz_Control_Container(ctl)
                Case "ListView"
                    Dim col As Windows.Forms.ListView.ColumnHeaderCollection
                    col = CType(ctl, Windows.Forms.ListView).Columns
                    Dim i As Integer
                    If col.Count > 0 Then
                        For i = 0 To col.Count - 1
                            If Sem_Tradução(col.Item(i).Text) Then
                                col.Item(i).Text = (Remove_Caracter_Especial(col.Item(i).Text))
                            Else
                                If Formato_Valido(col.Item(i).Text) Then
                                    col.Item(i).Text = Me.S("L" + col.Item(i).Text)
                                Else
                                    Write_Invalid_Name(ctl.GetType.ToString + "->" + ctl.Name + ".Coluna:" + col.Item(i).Text)
                                    col.Item(i).Text = "_+_" + col.Item(i).Text
                                End If
                            End If
                        Next
                    End If
                    If Not IsNothing(ctl.ContextMenuStrip) Then Traduz_ContextMenu(ctl.ContextMenuStrip)
                Case Else
                    Write_Invalid_Name_Control(ctl)
                    ctl.Text = "_*_" + ctl.Text
            End Select
        Next
    End Sub



End Class
