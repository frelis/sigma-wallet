Imports System.Net.Security
Imports System.Security.Cryptography.X509Certificates
Imports frelis

Public Class Report
    Private Structure msg
        Dim instalation_id As String
        Dim version As String
        Dim timestamp As DateTime
        Dim type As String
        Dim name As String
        Dim obj As Object
    End Structure

    Public Shared Function get_id() As String
        Static ID As String = ""
        If ID = "" Then
            IgnoreBadCertificates()
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
        Dim m As New msg
        m.instalation_id = get_id()
        m.version = get_version()
        m.timestamp = Now
        m.type = "error"
        m.name = title
        m.obj = ex
        Task.Run(Sub() Send_Report(m))
    End Sub

    Shared Sub Lang(lang As String, txt As String)
        Dim m As New msg
        m.instalation_id = get_id()
        m.version = get_version()
        m.timestamp = Now
        m.type = "lang"
        m.name = lang
        m.obj = txt
        Task.Run(Sub() Send_Report(m))
    End Sub

    Private Shared Sub Send_Report(m As msg)
        Try
            If False Then
                IO.File.AppendAllText("Report.txt", Now.ToString + vbTab + m.type + vbTab + m.name + vbTab + m.obj.ToString + vbNewLine)
            Else
                Dim req As Net.WebRequest = Net.WebRequest.Create("https://report.numberbit.com:56565/sigma-wallet/")
                Dim jsonDataBytes As Byte() = Text.Encoding.UTF8.GetBytes(Newtonsoft.Json.JsonConvert.SerializeObject(m, Newtonsoft.Json.Formatting.Indented))

                req.UseDefaultCredentials = True
                req.ContentType = "application/json"
                req.Method = "POST"
                req.ContentLength = jsonDataBytes.Length

                Using stream As IO.Stream = req.GetRequestStream()
                    stream.Write(jsonDataBytes, 0, jsonDataBytes.Length)
                End Using
                Dim response As Net.WebResponse = req.GetResponse()
                response.Dispose()
                response = Nothing
                req = Nothing
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Shared Sub IgnoreBadCertificates()
        System.Net.ServicePointManager.ServerCertificateValidationCallback = New System.Net.Security.RemoteCertificateValidationCallback(AddressOf AcceptAllCertifications)
    End Sub

    Private Shared Function AcceptAllCertifications(sender As Object, certificate As X509Certificate, chain As X509Chain, sslPolicyErrors As SslPolicyErrors) As Boolean
        Return True
    End Function
End Class
