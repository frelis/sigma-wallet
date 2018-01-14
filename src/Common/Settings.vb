Imports Newtonsoft.Json

Public Class Settings
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
