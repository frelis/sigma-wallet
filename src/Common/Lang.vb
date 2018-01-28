Public Class Lang
    Private Shared mdict As New Dictionary(Of String, String)
    Private Shared mlang As String = "none"

    Shared Sub Load(lang As String)
        mdict = Settings.read_settings(Of Dictionary(Of String, String))(Info.DirExe + "lang_" + lang.ToLower + ".json")
        mlang = lang
        If mdict Is Nothing Then mdict = New Dictionary(Of String, String)
    End Sub

    Shared Function Str(key As String) As String
        Try
            Return mdict(key)
        Catch
            Report.Lang(mlang, "Missing: " + key)
            Return "!_" + key
        End Try
    End Function

    Shared Function Str(key As String, ParamArray values() As Object) As String
        Try
            Return String.Format(mdict(key), values)
        Catch
            Report.Lang(mlang, "Missing: " + key)
            Return String.Format("!_" + key, values)
        End Try
    End Function

    Private Shared Sub Write_Invalid_Name(ByVal str As String)
        Report.Lang(mlang, "Invalid: " + str)
    End Sub

    Private Shared Sub Write_Invalid_Name(ByVal ctl As Windows.Forms.Control)
        Dim str As String = ""
        If Not IsNothing(ctl.Parent) Then str = ctl.Parent.Name + "->"
        str += ctl.GetType.ToString + "->" + ctl.Name + ":" + ctl.Text
        Report.Lang(mlang, "Invalid: " + str)
    End Sub

    Private Shared Sub Write_Invalid_Name(ByVal mnu As Windows.Forms.ToolStripItem)
        Dim str As String = ""
        If Not IsNothing(mnu.Owner) Then str = mnu.Owner.Name + "--"
        str += mnu.GetType.ToString + "->" + mnu.Name + ":" + mnu.Text
        Report.Lang(mlang, "Invalid: " + str)
    End Sub

    Private Shared Sub Translate_Control(Prefix As String, ByRef ctl As Windows.Forms.Control)
        If ctl.Text = "" Then Exit Sub

        If ctl.Text(0) = "!" Then
            ctl.Text = ctl.Text.Substring(1)
        Else
            If ctl.Text(0) <> "_" OrElse ctl.Text(ctl.Text.Length - 1) <> "_" Then
                Write_Invalid_Name(ctl)
                ctl.Text = "_+_" + ctl.Text
            Else
                ctl.Text = Str(Prefix + ctl.Text)
            End If
        End If
    End Sub

    Private Shared Sub Translate_Control(Prefix As String, ByRef col As Windows.Forms.DataGridViewColumn)
        If col.HeaderText = "" Then Exit Sub

        If col.HeaderText(0) = "!" Then
            col.HeaderText = col.HeaderText.Substring(1)
        Else
            If col.HeaderText(0) <> "_" OrElse col.HeaderText(col.HeaderText.Length - 1) <> "_" Then
                Write_Invalid_Name(col.DataGridView.GetType.ToString + "->" + col.DataGridView.Name + ".Coluna:" + col.HeaderText)
                col.HeaderText = "_+_" + col.HeaderText
            Else
                col.HeaderText = Str(Prefix + col.HeaderText)
            End If
        End If
    End Sub

    Private Shared Sub Translate_Control(Prefix As String, ByRef ctx As Windows.Forms.ContextMenuStrip)
        For Each cti As Windows.Forms.ToolStripItem In ctx.Items
            If cti.Text = "" Then Continue For
            If cti.Text(0) = "!" Then
                cti.Text = cti.Text.Substring(1)
            Else
                If cti.Text(0) <> "_" OrElse cti.Text(cti.Text.Length - 1) <> "_" Then
                    Write_Invalid_Name(cti)
                    cti.Text = "_+_" + cti.Text
                Else
                    cti.Text = Str(Prefix + cti.Text)
                End If
            End If
        Next
    End Sub

    Private Shared Sub Translate_Control(Prefix As String, ByRef col As Windows.Forms.ColumnHeader)
        If col.Text = "" Then Exit Sub

        If col.Text(0) = "!" Then
            col.Text = col.Text.Substring(1)
        Else
            If col.Text(0) <> "_" OrElse col.Text(col.Text.Length - 1) <> "_" Then
                Write_Invalid_Name(col.ListView.GetType.ToString + "->" + col.ListView.Name + ".Coluna:" + col.Text)
                col.Text = "_+_" + col.Text
            Else
                col.Text = Str(Prefix + col.Text)
            End If
        End If
    End Sub

    Private Shared Sub Translate_Control(Prefix As String, ByRef tp As Windows.Forms.TabPage)
        Translate_Control_Container(CType(tp, Windows.Forms.Control))
        If tp.Text = "" Then Exit Sub
        If tp.Text(0) = "!" Then
            tp.Text = tp.Text.Substring(1)
        Else
            If tp.Text(0) <> "_" OrElse tp.Text(tp.Text.Length - 1) <> "_" Then
                Write_Invalid_Name(tp)
                tp.Text = "_+_" + tp.Text
            Else
                tp.Text = Str(Prefix + tp.Text)
            End If
        End If
    End Sub

    Shared Sub Translate_Control_Container(ByRef container As Windows.Forms.Control)
        For Each ctl As Windows.Forms.Control In container.Controls
            Select Case ctl.GetType.ToString.Replace("System.Windows.Forms.", "")
                Case "Label", "LinkLabel", "CheckBox", "RadioButton"
                    Translate_Control("L", ctl)
                Case "GroupBox"
                    Translate_Control("L", ctl)
                    Translate_Control_Container(ctl)
                Case "DataGridView"
                    For Each col As Windows.Forms.DataGridViewColumn In CType(ctl, Windows.Forms.DataGridView).Columns
                        Translate_Control("L", col)
                    Next
                    If Not IsNothing(ctl.ContextMenuStrip) Then Translate_Control("B", ctl.ContextMenuStrip)
                Case "TabControl"
                    Dim tPage As Windows.Forms.TabPage
                    For Each tPage In CType(ctl, Windows.Forms.TabControl).TabPages
                        Translate_Control("L", tPage)
                    Next
                Case "Button"
                    Translate_Control("B", ctl)
                    If Not IsNothing(ctl.ContextMenuStrip) Then Translate_Control("B", ctl.ContextMenuStrip)
                Case "TextBox", "ComboBox", "TreeView", "DateTimePicker", "PictureBox",
                    "ProgressBar", "ListBox", "WebBrowser", "StatusStrip", "RichTextBox",
                    "MaskedTextBox"
                    'Not Translatable
                Case "Panel", "SplitContainer", "SplitterPanel", "FlowLayoutPanel"
                    Translate_Control_Container(ctl)
                Case "ListView"
                    For Each col As Windows.Forms.ColumnHeader In CType(ctl, Windows.Forms.ListView).Columns
                        Translate_Control("L", col)
                    Next
                    If Not IsNothing(ctl.ContextMenuStrip) Then Translate_Control("B", ctl.ContextMenuStrip)
                Case Else
                    Write_Invalid_Name(ctl)
                    ctl.Text = "_*_" + ctl.Text
            End Select
        Next
    End Sub

End Class
