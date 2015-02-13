Imports Microsoft.VisualBasic
Imports System.Collections
Imports System.Web.UI
Imports System.Web.UI.HtmlControls
Imports System.Text
Imports System.Data
Imports System.Web.UI.WebControls

Namespace SIGESWeb
    Public MustInherit Class PaginaBaseMasterPage
        Inherits System.Web.UI.MasterPage
        Private ws As clsSIGESProxyWrapper

        Public Sub New()
            ws = SIGESWeb.clsInstanciaAplicacion.InstanciaWSGenerico(Me.Context)
        End Sub

        Private Function Pagina(Optional ByVal ArchivoQuerys As String = "") As String
            Return System.IO.Path.GetDirectoryName(Me.Request.AppRelativeCurrentExecutionFilePath).Replace("~\", String.Empty) & "\" & _
                   IIf(ArchivoQuerys = "", System.IO.Path.GetFileNameWithoutExtension(Me.Request.CurrentExecutionFilePath), ArchivoQuerys)
        End Function

        Protected Function getDataByPage(ByVal Query As String) As DataSet
            Return ws.getDatabyPage(Pagina, Query, CByte(Session("SistemaContable")), Nothing)
        End Function

        Protected Function getDataByPage(ByVal Query As String, ByVal Parametros() As clsParametro, Optional ByVal ArchivoQuerys As String = "") As DataSet
            '1.0 Casteando hacia objeto nativo para envío de parámetros
            Dim temp As New System.Collections.Generic.List(Of wsSIGES.Parametro)
            For i As Integer = 0 To Parametros.Length - 1
                temp.Add(Parametros(i).objetoWS)
            Next
            Return ws.getDatabyPage(Pagina(ArchivoQuerys), Query, CByte(Session("SistemaContable")), temp.ToArray)
        End Function

        Public Function getDataByPage(ByVal Query As String, ByVal Ejercicio As String, ByVal Entidad As String, ByVal UE As String, ByVal UC As String, ByVal Parametros() As clsParametro) As DataSet
            Const NuevosCampos As Integer = 4 'Se pone 4 porque se cuenta desde el 0, en realidad son 5
            Dim intArreglo As Integer = NuevosCampos
            If Not IsNothing(Parametros) Then intArreglo += Parametros.Length
            Dim arrParametros(intArreglo) As clsParametro
            'Agregando los nuevos campos
            arrParametros(0) = New clsParametro("ejercicio", Ejercicio.ToString())
            arrParametros(1) = New clsParametro("entidad", Entidad.ToString())
            arrParametros(2) = New clsParametro("unidad_ejecutora", UE.ToString())
            arrParametros(3) = New clsParametro("unidad_desconcentrada", "0")
            arrParametros(4) = New clsParametro("unidad_compradora", UC.ToString())
            'Agregando los campos que pueden venir como parámetro
            If Not IsNothing(Parametros) Then
                For i As Integer = 0 To Parametros.Length - 1
                    arrParametros(i + NuevosCampos + 1) = Parametros(i)
                Next
            End If

            Return getDataByPage(Query, arrParametros)
        End Function

#Region "Archivos Adjuntos"
        Private Function ExisteArchivo(ByVal NombreArchivo As String, ByVal Tabla As Object) As Boolean
            Dim dtDatos As DataTable = Nothing
            Dim drResult() As DataRow

            If Not IsNothing(Tabla) Then
                dtDatos = CType(Tabla, DataTable)
                drResult = dtDatos.Select("NOMBRE = '" & NombreArchivo & "'")
                Return drResult.Length > 0
            End If
            Return False
        End Function

        ''' <summary>
        ''' Función para almacenamiento de archivos
        ''' </summary>
        ''' <param name="TipoDocumento"></param>
        ''' <param name="DescripcionTipo"></param>
        ''' <param name="Descripcion"></param>
        ''' <param name="Usuario"></param>
        ''' <param name="Tabla"></param>
        ''' <param name="objUpload"></param>
        ''' <remarks></remarks>
        Protected Function CargarArchivoAdjunto(ByVal TipoDocumento As Decimal, _
                                           ByVal DescripcionTipo As String, _
                                           ByVal Descripcion As String, _
                                           ByVal Usuario As String, _
                                           ByRef Tabla As Object, _
                                           ByRef objUpload As FileUpload) As Boolean
            Dim dr As DataRow
            Dim dtDatos As DataTable
            Dim dsTiposValidos As DataSet

            If objUpload.HasFile = True Then
                Try
                    '1.0 Validando que el archivo sea un tipo de dato válido
                    Dim arrParametros(0) As clsParametro
                    arrParametros(0) = New clsParametro("tipo_archivo", System.IO.Path.GetExtension(objUpload.PostedFile.FileName).ToUpper())
                    dsTiposValidos = Me.getDataByPage("ArchivoValido", arrParametros)
                    '1.1 No se permite agregar 2 archivos con el mismo nombre
                    If ExisteArchivo(System.IO.Path.GetFileName(objUpload.PostedFile.FileName), Tabla) Then
                        clsUtil.MensajeJava(Me.Page, "No puede anexar un documento con un nombre de archivo que ya fue anexado, debe primero eliminar el documento existente", False)
                        Return False
                    End If
                    If Not IsNothing(dsTiposValidos) AndAlso _
                       dsTiposValidos.Tables.Count > 0 Then
                        If dsTiposValidos.Tables(0).Rows.Count > 0 Then
                            If objUpload.PostedFile.ContentLength > (dsTiposValidos.Tables(0).Rows(0).Item("CAPACIDAD_MAXIMA") * 1024) * 1024 Then
                                objUpload.Dispose()
                                clsUtil.MensajeJava(Me.Page, "El tamaño del archivo excede la capacidad máxima permitida para este tipo de archivo, que es de " & dsTiposValidos.Tables(0).Rows(0).Item("CAPACIDAD_MAXIMA") & " MB.\nSe abortará la carga del mismo.", False)
                                Return False
                            End If
                        Else
                            objUpload.Dispose()
                            clsUtil.MensajeJava(Me.Page, "No puede cargar archivos de este tipo al sistema, se abortará la carga del mismo.", False)
                            Return False
                        End If
                    End If

                    '2.0 Anexando archivo adjunto
                    If Not IsNothing(Tabla) Then
                        dtDatos = CType(Tabla, DataTable)
                    Else
                        dtDatos = New DataTable
                        dtDatos.Columns.Add("CORRELATIVO", System.Type.GetType("System.Decimal"))
                        dtDatos.Columns.Add("TIPO_DOCUMENTO", System.Type.GetType("System.Decimal"))
                        dtDatos.Columns.Add("FECHA_REGISTRO", System.Type.GetType("System.String"))
                        dtDatos.Columns.Add("TIPO_DOCUMENTO_DESCR", System.Type.GetType("System.String"))
                        dtDatos.Columns.Add("NOMBRE", System.Type.GetType("System.String"))
                        dtDatos.Columns.Add("DESCRIPCION", System.Type.GetType("System.String"))
                        dtDatos.Columns.Add("USUARIO", System.Type.GetType("System.String"))
                        dtDatos.Columns.Add("CONTENT_TYPE", System.Type.GetType("System.String"))
                        dtDatos.Columns.Add("DOCUMENTO", System.Type.GetType("System.Byte[]"))
                    End If

                    '1.1 Recuperando máximo correlativo
                    If IsNothing(ViewState("CORRELATIVO_ADJUNTOS")) Then ViewState("CORRELATIVO_ADJUNTOS") = 0
                    ViewState("CORRELATIVO_ADJUNTOS") += 1
                    '1.2 Almacenando información del nuevo adjunto
                    dr = dtDatos.NewRow()
                    dr.Item("CORRELATIVO") = ViewState("CORRELATIVO_ADJUNTOS")
                    dr.Item("TIPO_DOCUMENTO") = TipoDocumento
                    dr.Item("FECHA_REGISTRO") = Format(Now(), "dd/MM/yyyy")
                    dr.Item("TIPO_DOCUMENTO_DESCR") = DescripcionTipo
                    dr.Item("NOMBRE") = System.IO.Path.GetFileName(objUpload.PostedFile.FileName)
                    dr.Item("DESCRIPCION") = Descripcion
                    dr.Item("USUARIO") = Usuario
                    dr.Item("CONTENT_TYPE") = objUpload.PostedFile.ContentType()
                    dr.Item("DOCUMENTO") = objUpload.FileBytes
                    dtDatos.Rows.Add(dr)
                    Tabla = dtDatos
                    Return True
                Catch ex As Exception
                    clsUtil.MensajeJava(Me.Page, "Error al intentar anexar archivo adjunto,\nError: " & Server.HtmlEncode(ex.Message.ToString), False)
                End Try
            Else
                clsUtil.MensajeJava(Me.Page, "Error, debe indicar un archivo a adjuntar", False)
            End If
            Return False
        End Function
#End Region

#Region "Botón Salir"
        Protected Overridable Sub Salir_Click_Handler(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
            If (SalirDeForma()) Then
                Dim mywebutil As clsWebUtil = Nothing
                If IsNothing(mywebutil) Then mywebutil = New clsWebUtil(Me.Context.ApplicationInstance, Cache)
                mywebutil.generic_exit()
            End If
        End Sub

        ''Aplicar
        Protected Overridable Function SalirDeForma() As Boolean
            Return True
        End Function
#End Region
    End Class
End Namespace