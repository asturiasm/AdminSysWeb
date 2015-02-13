Imports System.Diagnostics

Public Class clsLOG
    Private objLOG As EventLog
    Private Const LogName As String = "SIGES"
    Private Const SourceName As String = "Web"
    Private Const CapacidadMaxima As Decimal = 32700

    ''' <summary>
    ''' Instancia por default
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()
        objLOG = New EventLog(LogName, System.Environment.MachineName.ToString, SourceName)
    End Sub

    ''' <summary>
    ''' Instancia indicando un sourcename definido
    ''' </summary>
    ''' <param name="strSourceName"></param>
    ''' <remarks></remarks>
    Public Sub New(ByVal strSourceName As String)
        objLOG = New EventLog(LogName, System.Environment.MachineName.ToString, strSourceName)
    End Sub

    Public Sub AgregarLog(ByVal Mensaje As String, ByVal TipoEvento As EventLogEntryType)
        If Mensaje.Length > CapacidadMaxima Then Mensaje = Mensaje.Substring(0, CapacidadMaxima)
        objLOG.WriteEntry(Mensaje, TipoEvento)
    End Sub
End Class