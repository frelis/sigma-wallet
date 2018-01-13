Public Class Info
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
