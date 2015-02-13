Imports Microsoft.VisualBasic

Namespace SIGESWeb
    Public Class clsMyTableAdapter
        Private dtTabla As DataTable
        Private TotalRegistros As Integer

        ''' <summary>
        ''' Constructor para dummy de clase
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub New()

        End Sub

        ''' <summary>
        ''' Constructor de la tabla con los registros que van a pintarse en pantalla
        ''' </summary>
        ''' <param name="dt"></param>
        ''' <param name="Registros"></param>
        ''' <remarks></remarks>
        Public Sub New(ByVal dt As DataTable, ByVal Registros As Integer)
            dtTabla = dt
            TotalRegistros = Registros
        End Sub

        ''' <summary>
        ''' Retorna los datos almacenados en la tabla (los registros reales)
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetData() As DataTable
            Return dtTabla
        End Function

        ''' <summary>
        ''' Retorna el total de registros de la consulta completa
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function VirtualItemCount() As Integer
            Return TotalRegistros
        End Function

        Public Function GetData(ByVal filaInicial As Integer, ByVal MaximoRegistros As Integer) As DataTable
            Return dtTabla
        End Function
    End Class
End Namespace