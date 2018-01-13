Public Class Settings
    Public Structure wallet_handler
        Dim version As String
        Dim source As String
        Dim platform As String
        Dim coin As String
    End Structure
    Public Shared Function Get_Handler_settings() As List(Of wallet_handler)
        Dim rst As New List(Of wallet_handler)
        Try
            If IO.File.Exists(Info.DirExe + "wallet_settings.json") Then
                Dim jsonFile As String = IO.File.ReadAllText(Info.DirExe + "wallet_settings.json")
                Using ms As IO.MemoryStream = New IO.MemoryStream(System.Text.Encoding.UTF8.GetBytes(jsonFile))
                    Dim ser As Runtime.Serialization.Json.DataContractJsonSerializer = New Runtime.Serialization.Json.DataContractJsonSerializer(rst.GetType)
                    rst = CType(ser.ReadObject(ms), List(Of wallet_handler))
                End Using
            End If
        Catch ex As Exception
            MsgBox(ex, MsgBoxStyle.Critical, "Get_Handler_settings")
        End Try
        Return rst
    End Function
End Class
