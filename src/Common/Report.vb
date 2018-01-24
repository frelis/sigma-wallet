Public Class Report
    Private Structure rpt
        Dim id As String
        Dim version As String
        Dim timestamp As DateTime
        Dim type As String
        Dim name As Object
        Dim content As Object
    End Structure

    Public Shared Function get_id() As String
        Static ID As String = ""
        If ID = "" Then
            If IO.File.Exists(Info.DirData + "InstalationID.txt") Then
                ID = IO.File.ReadAllText(Info.DirData + "InstalationID.txt")
                If ID.Length <> 32 Then
                    ID = Security.CalculateMD5Hash(Now.Ticks.ToString + Info.DirData + System.Environment.MachineName)
                    IO.File.WriteAllText(Info.DirData + "InstalationID.txt", ID)
                End If
            Else
                ID = Security.CalculateMD5Hash(Now.Ticks.ToString + Info.DirData + System.Environment.MachineName)
                IO.File.WriteAllText(Info.DirData + "InstalationID.txt", ID)
            End If
        End If
        Return ID
    End Function

    Private Shared Function get_version() As String
        Return Windows.Forms.Application.ProductVersion
    End Function

    Shared Sub [Error](title As String, ex As Exception)
        Dim r As New rpt
        r.id = get_id()
        r.version = get_version()
        r.timestamp = Now
        r.type = "error"
        r.name = "title"
        r.content = ex
    End Sub

End Class
