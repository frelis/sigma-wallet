Imports Newtonsoft.Json

Public Class Settings
    Public Structure wallet_handler
        Dim version As String
        Dim source As String
        Dim platform As String
        Dim coin As String
    End Structure

    Public Structure wallet
        Dim name As String
        Dim order As Integer
        Dim coin As String
        Dim wallet As String
        Dim seed As String
        Dim viewkey As String
        Dim password As String
        Dim amount As Decimal
        Dim history As List(Of movement)
    End Structure

    Public Structure movement
        Dim TimeStamp As Date
        Dim amount As Decimal
        Dim text As String
    End Structure

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


    Public Shared Function Get_Handler_settings(filename As String) As List(Of wallet_handler)
        Dim rst As List(Of wallet_handler)
        rst = read_settings(Of List(Of wallet_handler))(filename)
        Return rst
    End Function
End Class
