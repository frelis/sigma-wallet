Public Class Security
    Public Shared Function CalculateMD5Hash(ByVal input As String) As String
        Dim md5 As System.Security.Cryptography.MD5 = System.Security.Cryptography.MD5.Create()
        Dim inputBytes As Byte() = System.Text.Encoding.Unicode.GetBytes(input)
        Dim hash As Byte() = md5.ComputeHash(inputBytes)
        Dim sb As Text.StringBuilder = New Text.StringBuilder()
        For i As Integer = 0 To hash.Length - 1
            sb.Append(hash(i).ToString("X2"))
        Next
        Return sb.ToString()
    End Function
End Class
