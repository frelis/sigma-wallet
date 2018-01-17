Imports Newtonsoft.Json

Public Class Settings
#Region " Settings Structures"
    Public Class SettingsData
        Public sections As List(Of Section)
    End Class
    Public Class Section
        Public name As String
        Public sub_sections As List(Of SubSection)
    End Class
    Public Class SubSection
        Public name As String
        Public settings As List(Of Setting)
    End Class
    Public Class Setting
        Public name As String
        Public value As String
    End Class
#End Region

        Public Shared Function Read() As SettingsData
            Dim rst As SettingsData = Nothing
            If IO.File.Exists(Info.DirDoc + "Σ Wallet.json") Then
                rst = settings.read_settings(Of SettingsData)(Info.DirDoc + "Σ Wallet.json")
            End If
            If IsNothing(rst) Then
                rst = New SettingsData
            End If
            If IsNothing(rst.sections) Then
                rst.sections = New List(Of Section)
            End If
            Return rst
        End Function

        Public Shared Function ReadSetting(Settings As SettingsData, Section As String, SubSection As String, Setting As String) As String
            If IsNothing(Settings.sections) Then Return ""

            For Each sec As Section In Settings.sections
                If sec.name = Section.ToLower() Then
                    If IsNothing(sec.sub_sections) Then Return ""
                    For Each subsec As SubSection In sec.sub_sections
                        If subsec.name = SubSection.ToLower() Then
                            If IsNothing(subsec.settings) Then Return ""
                            For Each sett As Setting In subsec.settings
                                If sett.name = Setting.ToLower Then Return sett.value
                            Next
                        End If
                    Next
                End If
            Next
            Return ""
        End Function

        Public Shared Function WriteSetting(Settings As SettingsData, Section As String, SubSection As String, Setting As String, Value As String) As Boolean
            If IsNothing(Settings.sections) Then Settings.sections = New List(Of Section)
            Dim find As Boolean = False
            For Each sec As Section In Settings.sections
                If sec.name = Section.ToLower() Then find = True
            Next
            If Not find Then Settings.sections.Add(New Section With {.name = Section.ToLower(), .sub_sections = New List(Of SubSection)})
            For Each sec As Section In Settings.sections
                If sec.name = Section.ToLower() Then
                    find = False
                    If IsNothing(sec.sub_sections) Then sec.sub_sections = New List(Of SubSection)
                    For Each subsec As SubSection In sec.sub_sections
                        If subsec.name = SubSection.ToLower() Then find = True
                    Next
                    If Not find Then sec.sub_sections.Add(New SubSection With {.name = SubSection.ToLower(), .settings = New List(Of Setting)})
                    For Each subsec As SubSection In sec.sub_sections
                        If subsec.name = SubSection.ToLower() Then
                            find = False
                            If IsNothing(subsec.settings) Then subsec.settings = New List(Of Setting)
                            For Each sett As Setting In subsec.settings
                                If sett.name = Setting.ToLower Then find = True
                            Next
                            If Not find Then subsec.settings.Add(New Setting With {.name = Setting.ToLower(), .value = ""})
                            For Each sett As Setting In subsec.settings
                                If sett.name = Setting.ToLower Then sett.value = Value
                            Next
                        End If
                    Next
                End If
            Next

            Return Write(Settings)
        End Function

        Public Shared Function Write(Settings As SettingsData) As Boolean
            Dim rst As Boolean = False
            Try
                Dim filename As String
                If Not IO.Directory.Exists(Info.DirDoc) Then IO.Directory.CreateDirectory(Info.DirDoc)
                filename = Info.DirDoc + "Σ Wallet.json"
                rst = write_settings(filename, Settings)
            Catch ex As Exception
                Log.Error("Write  Settings", ex)
                rst = False
            End Try
            Return rst
        End Function

        Public Shared Function read_settings(Of T)(filename As String) As T
            Dim rst As T
            Try
                If IO.File.Exists(filename) Then
                    Dim jsonFile As String = IO.File.ReadAllText(filename)
                    rst = JsonConvert.DeserializeObject(Of T)(jsonFile)
                End If
            Catch ex As Exception
                Log.Error("Read Settings", ex)
            End Try
            Return rst
        End Function

        Public Shared Function write_settings(Of T)(filename As String, settings As T) As Boolean
            Dim rst As Boolean = False
            Try
                Dim serializer As New JsonSerializer()
                serializer.Formatting = Formatting.Indented
                Using fs As New IO.StreamWriter(filename)
                    Using jw As New JsonTextWriter(fs)
                        serializer.Serialize(jw, settings)
                    End Using
                End Using
            Catch ex As Exception
                Log.Error("Write Settings", ex)
            End Try
            Return rst
        End Function
    End Class
