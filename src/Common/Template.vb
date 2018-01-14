Imports frelis

Public Class Template
    Structure stConfig
        Dim current_template As String
        Dim templates As List(Of stTemplate)
    End Structure
    Structure stTemplate
        Dim name As String
        Dim background As Drawing.Color
        Dim background_alt As Drawing.Color
        Dim text As Drawing.Color
        Dim text_alt As Drawing.Color
        Dim selected As Drawing.Color
        Dim nonselected As Drawing.Color
        Dim border As Drawing.Color
        Dim button As Drawing.Color
    End Structure
    Private Shared mCurrent As stTemplate
    Public Shared ReadOnly Property Current() As stTemplate
        Get
            If mCurrent.name = "" Then
                mCurrent = Read_Templates_config()
            End If
            Return mCurrent
        End Get
    End Property
    Private Shared mConfig As stConfig
    Public Shared ReadOnly Property Templates() As stConfig
        Get
            If mConfig.current_template = "" Then
                mCurrent = Read_Templates_config()
            End If
            Return mConfig
        End Get
    End Property

    Private Shared Function Read_Templates_config() As stTemplate
        Try
            Dim save As Boolean = False
            mCurrent = New stTemplate
            If Not IO.File.Exists(Info.DirData + "templates.json") Then
                IO.File.Copy(Info.DirExe + "templates.json", Info.DirData + "templates.json")
            End If
            mConfig = Settings.read_settings(Of stConfig)(Info.DirData + "templates.json")
            If IsNothing(mConfig) Then mConfig = New stConfig
            If mConfig.current_template = "" Then mConfig.current_template = "Orange"
            If IsNothing(mConfig.templates) Then mConfig.templates = New List(Of stTemplate)
            If mConfig.templates.Count = 0 Then
                mConfig.templates.Add(Default_Template)
                save = True
            End If
            For Each t As stTemplate In mConfig.templates
                If t.name = mConfig.current_template Then mCurrent = t
            Next
            If mCurrent.name = "" Then
                mConfig.current_template = "Orange"
                For Each t As stTemplate In mConfig.templates
                    If t.name = mConfig.current_template Then mCurrent = t
                Next
                If mCurrent.name = "" Then
                    mConfig.templates.Add(Default_Template)
                    mCurrent = Default_Template()
                End If
                save = True
            End If
            If save Then Save_templates
        Catch ex As Exception
            Log.Error("Read Templates", ex)
        End Try
        Return mCurrent
    End Function

    Private Shared Sub Save_templates()
        Try
            Settings.write_settings(Info.DirData + "templates.json", mConfig)
        Catch ex As Exception
            Log.Error("Save Templates", ex)
        End Try
    End Sub

    Private Shared Function Default_Template() As stTemplate
        Dim rst As New stTemplate
        rst.name = "Orange"
        rst.background = Drawing.Color.FromArgb(&HEC, &HE9, &HD8)
        rst.background_alt = Drawing.Color.FromArgb(&H99, &H99, &H99)
        rst.text = Drawing.Color.FromArgb(&H0, &H0, &H0)
        rst.text_alt = Drawing.Color.FromArgb(&H37, &H37, &H37)
        rst.selected = Drawing.Color.FromArgb(&HFF, &H66, &H0)
        rst.nonselected = Drawing.Color.FromArgb(&HFF, &HFF, &HFF)
        rst.border = Drawing.Color.FromArgb(&H64, &H64, &H64)
        rst.button = Drawing.Color.FromArgb(&H37, &H37, &H37)

        Return rst
    End Function

    Private Shared Function System_Template() As stTemplate
        Dim rst As New stTemplate
        rst.name = "System"
        rst.background = Drawing.SystemColors.Control
        Return rst
    End Function
End Class
