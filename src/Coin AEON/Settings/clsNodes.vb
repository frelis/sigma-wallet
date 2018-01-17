Imports System.Windows.Forms
Imports frelis

Public Class clsNodes
    Implements itSettings

    Public ReadOnly Property Name As String Implements itSettings.Name
        Get
            Return "Nodes"
        End Get
    End Property

    Public ReadOnly Property SettingsControl As UserControl Implements itSettings.SettingsControl
        Get
            Return New ucNodes
        End Get
    End Property
End Class
