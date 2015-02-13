Imports Microsoft.VisualBasic

<Serializable()> Public Class SigesAsincSate


    Private termino As Boolean = False

    Public mensaje As String

    Public tituloExito As String = "Aviso"
    Public tituloError As String = "Error"

    Public mensajeExito As String = "Operación Realizada con Éxito"
    Public mensajeError As String = "Ha ocurrido un Error"

    Public scriptOk As String = ""
    Public scriptError As String = ""

    Public result As System.IAsyncResult

    Sub ProcessDnsInformation(ByVal result As IAsyncResult)
        Dim cb As Object = result.AsyncState
        Dim value As wsSIGES.DynamicTransactionResponse = cb.EndDynamicTransaction(result)         
        mensaje = value.DynamicTransactionResult
        termino = True
    End Sub

    Public Function isTermino() As Boolean
        Return termino
    End Function

    Public Function getCallback() As System.AsyncCallback
        Return AddressOf ProcessDnsInformation
    End Function
End Class
