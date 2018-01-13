Public Class Info
#Region "Settings"
    Public Structure wallet_handler
        Dim version As String
        Dim source As String
        Dim platform As String
        Dim coin As String
    End Structure
    Public Shared Function Get_Handler_settings() As List(Of wallet_handler)
        Dim rst As New List(Of wallet_handler)
        Try
            If IO.File.Exists(DirExe() + "wallet_handler.json") Then
                Dim jsonFile As String = IO.File.ReadAllText(DirExe() + "wallet_handler.json")
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

#End Region
    Shared Function SystemType() As String
        If Environment.OSVersion.Platform = PlatformID.Win32NT Then

            If Environment.Is64BitOperatingSystem Then
                Return "win64"
            Else
                Return "win32"
            End If
        End If
        Return "unknown"
    End Function
#Region "Paths"
    Shared Function DirExe() As String
        Return (IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + DirSep()).Replace(DirSep() + DirSep(), DirSep)
    End Function

    Shared Function DirData() As String
        Return (Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + DirSep() + "My Wallet" + DirSep()).Replace(DirSep() + DirSep(), DirSep)
    End Function

    Shared Function DirDoc() As String
        Return (Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + DirSep() + "My Wallet" + DirSep()).Replace(DirSep() + DirSep(), DirSep)
    End Function
    Shared Function DirSep() As String
        Return IO.Path.DirectorySeparatorChar
    End Function
#End Region
End Class
