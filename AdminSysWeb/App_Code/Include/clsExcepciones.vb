Imports Microsoft.VisualBasic
Imports System.Xml

Namespace SIGESWeb
    ''' <summary>
    ''' Manejador de excepciones que por su naturaleza o falta de definición formal se queman en el sistema
    ''' </summary>
    ''' <remarks></remarks>
    Public Class clsExcepciones        
        Private objXML As XmlDocument
        Private ws As wsSIGES.DataRetrievalWCFClient

        Public Sub New()
            ws = New wsSIGES.DataRetrievalWCFClient(clsConstantes.EndPointSIGESGenerico)
            ws.Open()
            objXML = New XmlDocument
            objXML.LoadXml(ws.GetExcepciones())
            ws.Close()
        End Sub

        ''' <summary>
        ''' Recupera el XPath propio de cada excepción
        ''' </summary>
        ''' <param name="Excepcion"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function RecuperarExcepcion(ByVal Excepcion As Decimal) As String
            Dim strXPathEx As String = "excepciones/excepcion[@id=" & Excepcion.ToString() & "]"

            Return strXPathEx
        End Function

        ''' <summary>
        ''' Indica si un contrato esta dentro de los que comprenden esta excepción de comportamiento
        ''' </summary>
        ''' <param name="Contrato"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function ExcepcionContratoFactura(ByVal Contrato As String) As Boolean
            Dim strXPath As String = RecuperarExcepcion(1) & "/contratos[nec='" & Contrato & "']"

            Return objXML.SelectNodes(strXPath).Count > 0
        End Function

        ''' <summary>
        ''' Indica si una fuente que no es de apoyo presupuestario puede usarse en el escenario de formulación de nómina
        ''' </summary>
        ''' <param name="Entidad"></param>
        ''' <param name="Fuente"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function ValidarApoyoPresupuestario(ByVal Entidad As String, ByVal Fuente As String) As Boolean
            Dim strXPath As String = RecuperarExcepcion(2) & "/fuente[@id='" & Fuente & "']/entidades[entidad='" & Entidad & "']"
            Return objXML.SelectNodes(strXPath).Count > 0
        End Function

        ''' <summary>
        ''' Indica si una unidad compradora tiene habilitada la excepción para registrar adjuntos en ordenes de compra
        ''' </summary>
        ''' <param name="Entidad"></param>
        ''' <param name="UE"></param>
        ''' <param name="UC"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function RequiereDocumentoAdjunto(ByVal Entidad As String, ByVal UE As String, ByVal UC As String) As Boolean
            Dim strXPath As String = RecuperarExcepcion(3) & "/entidad[@id='" & Entidad & "']/unidad_ejecutora[@id='" & UE & "'][unidad_compradora='" & UC & "']"
            Return objXML.SelectNodes(strXPath).Count > 0
        End Function

        ''' <summary>
        ''' Retorna los renglones adicionales que una entidad pueda formular
        ''' </summary>
        ''' <param name="Entidad"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function FormulaRenglonesAdicionales(ByVal Entidad As String) As String
            Dim strXPath As String = RecuperarExcepcion(4) & "/entidad[@id='" & Entidad & "']/renglones//renglon"
            Dim renglones As XmlNodeList = objXML.SelectNodes(strXPath)
            Dim strResult As String = String.Empty

            For i As Integer = 0 To renglones.Count - 1
                strResult &= renglones.Item(i).InnerText
                If i < (renglones.Count - 1) Then strResult &= ","
            Next
            Return strResult
        End Function

        ''' <summary>
        ''' Retorna los renglones adicionales que una entidad pueda formular
        ''' </summary>
        ''' <param name="Entidad"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function FormulaRenglonesExcepcion(ByVal Entidad As String, ByVal Renglon As Integer) As String
            Dim strRenglon As String = CStr(Renglon).PadLeft(3, "0")
            Dim strXPath As String = RecuperarExcepcion(4) & "/entidad[@id='" & Entidad & "']/renglones[renglon='" & strRenglon & "']"
            Return objXML.SelectNodes(strXPath).Count > 0
        End Function

        ''' <summary>
        ''' Recupera deducciones para contratos
        ''' </summary>
        ''' <param name="Entidad"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function DeduccionesContratos(ByVal Entidad As String) As String
            Dim strXPath As String = RecuperarExcepcion(5) & "/entidad[@id='" & Entidad & "']//deduccion"
            Dim Deducciones As XmlNodeList = objXML.SelectNodes(strXPath)
            Dim strResult As String = objXML.SelectSingleNode(RecuperarExcepcion(5) & "/deducciones").InnerText

            If Deducciones.Count > 0 Then 'Si hay deducciones adicionales por entidad
                strResult &= ","
                For i As Integer = 0 To Deducciones.Count - 1
                    strResult &= Deducciones.Item(i).InnerText
                    If i < (Deducciones.Count - 1) Then strResult &= ","
                Next
            End If
            Return strResult
        End Function

        ''' <summary>
        ''' Retorna la cantidad de proyectos que al aperturar el aprobado de formulación podrán modificarse de forma parcial
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function ProyectosModificablesParciales() As Integer
            Dim strXPath As String = RecuperarExcepcion(6) & "/proyectos_modificables_parcialmente"
            Dim strResult As String = "0"
            If IsNothing(objXML.SelectSingleNode(strXPath)) = False Then
                strResult = objXML.SelectSingleNode(strXPath).InnerText
            End If
            Return CInt(strResult)
        End Function

        Public Function PermiteNoAmortizarAnticipo(ByVal Contrato As String) As Boolean
            Dim strXPath As String = RecuperarExcepcion(8) & "/contratos[nec='" & Contrato & "']"

            Return objXML.SelectNodes(strXPath).Count > 0
        End Function
    End Class
End Namespace