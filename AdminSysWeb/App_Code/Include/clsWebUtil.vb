Imports System.Web.Caching
Imports System.Threading
Imports System.Web


Namespace SIGESWeb


    Public Class clsWebUtil
        Dim webenv As HttpApplication
        Dim cache As System.Web.Caching.Cache
        Dim ddlval As DropDownList
        Dim ds As DataSet
        Dim dls As DataSet
        Dim collectkey As Collection
        Dim sqlquery As String
        Dim tval As TextBox
        Dim cval As CheckBox
        Dim dr As DataRow
        Dim dr2 As DataRow

        Private Const C_TIPODATOBDD_STRING As String = "C"
        Private Const C_TIPODATOBDD_DATE As String = "D"
        Private Const C_TIPODATOBDD_INTEGER As String = "N"
        Private Const C_TIPODATOBDD_CHAR As String = "C"
        Private Const C_TIPODATOBDD_BOOLEAN As String = "B"


        Structure KeyStructure
            Dim ColName As String
            Dim GridColIndex As Integer
            Dim TipoDato As String
        End Structure

        Public Sub New(ByVal webapp As System.Web.HttpApplication, ByVal mycache As System.Web.Caching.Cache)
            webenv = webapp
            cache = mycache
        End Sub

        Public Sub generic_page_load_event(ByVal ispostback As Boolean, ByRef mypage As System.Web.UI.Page)
            generic_page_load_event(ispostback, mypage, Nothing)
        End Sub

        Public Sub generic_page_load_event(ByVal ispostback As Boolean, ByRef mypage As System.Web.UI.Page, ByVal abc As Object)
            generic_page_load_event(ispostback, mypage, Nothing)
        End Sub

        Public Sub generic_page_load_event(ByVal ispostback As Boolean, ByRef mypage As System.Web.UI.Page, ByVal Toolbar As DataTable)
            Dim objenc As clsEncrypt.Encryption
            Dim i As Integer
            Dim accion As String
            Dim opcion As String
            Dim ds_cols As DataTable
            Dim blCrear As Boolean
            Dim blRecuperarDatos As Boolean
            Dim ws As clsSIGESProxyWrapper = SIGESWeb.clsInstanciaAplicacion.InstanciaWSGenerico(webenv.Context)

            If Not IsNothing(webenv.Session("key")) OrElse _
               webenv.Session("key") = "" Then
                objenc = New clsEncrypt.Encryption(webenv.Session("key"))
            Else
                webenv.Response.Redirect("../login/frmLogin.htm")
            End If

            If webenv.Request.QueryString("WHERE") Is Nothing Then
                sqlquery = webenv.Session("SQLQUERY")
                'Verificar si la variable sqlquery trae el query, si no se lo asigna.
                If sqlquery Is Nothing Then
                    If Not webenv.Request.QueryString("TABLA") Is Nothing Then
                        webenv.Session("NombreTabla") = webenv.Request.QueryString("TABLA")
                    End If
                    sqlquery = "SELECT * FROM " & webenv.Session("NombreTabla") & " WHERE " & webenv.Request.QueryString("WHERE")
                End If
            Else
                If Not webenv.Request.QueryString("TABLA") Is Nothing Then
                    webenv.Session("NombreTabla") = webenv.Request.QueryString("TABLA")
                End If
                sqlquery = "SELECT * FROM " & webenv.Session("NombreTabla") & " WHERE " & webenv.Request.QueryString("WHERE")
            End If

            If Not ispostback Then
                If IsNothing(Toolbar) Then
                    clsUtil.SetButtonIcon(CType(webenv.Session("DATA"), DataSet).Tables("TOOLBAR"), mypage.FindControl("GRABAR"), webenv.Request.QueryString("OP"))
                Else
                    clsUtil.SetButtonIcon(Toolbar, mypage.FindControl("GRABAR"), webenv.Request.QueryString("OP"))
                End If

                webenv.Session("FechaHoraIngreso") = Now()

                blCrear = Not (InStr(webenv.Request.QueryString("OP"), "CREAR") = 0)
                If Not IsNothing(webenv.Request.QueryString("OP")) AndAlso _
                   webenv.Request.QueryString("OP").Equals("CREAR_CESION") Then
                    blRecuperarDatos = True
                Else
                    blRecuperarDatos = Not blCrear
                End If
                If blRecuperarDatos = True Then
                    ds = ws.getDatabySQL(sqlquery, IIf(webenv.Session("OBJETO_DICCIONARIO") = "S", True, False), "<P></P>", webenv.Session("NombreTabla"))
                    webenv.Session("DATAROW") = ds
                    If ds.Tables.Count = 0 OrElse _
                       ds.Tables(0).Rows.Count = 0 Then
                        Throw New Exception("No pudo recuperarse información para alimentar la página, esto es un error de configuración del sistema, favor comunicarse con el equipo de soporte técnico.")
                    End If
                    dr = ds.Tables(0).Rows(0)
                Else
                    ds = ws.getDatabySQL("select * from " & webenv.Session("NombreTabla") & " where 1 = 0 ", IIf(webenv.Session("OBJETO_DICCIONARIO") = "S", True, False), "<P></P>", webenv.Session("NombreTabla"))
                    webenv.Session("DATAROW") = ds
                End If
                ds.Tables(0).TableName = webenv.Session("NombreTabla")
                ds_cols = CType(webenv.Session("DATA"), DataSet).Tables("COLUMNAS_MAINDATA")
                dls = New DataSet
                For i = 0 To ds_cols.Rows.Count - 1
                    With ds_cols.Rows(i)
                        If Not IsDBNull(.Item("DATALIST")) AndAlso _
                           Trim(.Item("DATALIST")) <> "" AndAlso _
                           dls.Tables.IndexOf(Trim(.Item("DATALIST"))) = -1 Then
                            If Not IsNothing(cache(Trim(.Item("DATALIST")))) Then
                                dls.Tables.Add(CType(cache(Trim(.Item("DATALIST"))), DataSet).Tables(0).Copy())
                                dls.Tables(dls.Tables.Count - 1).TableName = Trim(.Item("DATALIST"))
                            Else
                                Dim tdata As New DataSet
                                tdata = ws.getDatabySQL("SELECT SQL_STATEMENT FROM AD_LISTAS_VALORES WHERE upper(ID_LISTA) = '" & UCase(Trim(.Item("DATALIST"))) & "'", True, CType(webenv.Session("PARAMETROS"), System.Xml.XmlDocument).InnerXml, Nothing)
                                dls.Tables.Add(CType(ws.getDatabySQL(tdata.Tables(0).Rows(0).Item(0), False, CType(webenv.Session("PARAMETROS"), System.Xml.XmlDocument).InnerXml, Nothing), DataSet).Tables(0).Copy())
                                dls.Tables(dls.Tables.Count - 1).TableName = Trim(.Item("DATALIST"))
                            End If
                        End If
                    End With
                Next

                opcion = IIf(blCrear, "CREAR", webenv.Request.QueryString("OP"))
                'Select Case webenv.Request.QueryString("OP")
                Select Case opcion
                    Case "CREAR", "PAGO_PARCIAL"
                        accion = "INSERT"
                    Case "MODIFICAR", "PAGO_TOTAL", "MODIFICAR_REV"
                        accion = "UPDATE"
                    Case Else
                        accion = "DISABLEALL"
                End Select
                clsUtil.DisableControls(mypage, CType(webenv.Session("DATA"), DataSet), accion)
                clsUtil.LoadData(mypage, CType(webenv.Session("DATA"), DataSet), dls, blRecuperarDatos, dr)
                dls.Dispose()
                clsUtil.DataFormat(mypage, CType(webenv.Session("DATA"), DataSet))
            End If
        End Sub

        Public Sub generic_page_load_event2(ByVal ispostback As Boolean, ByRef mypage As System.Web.UI.Page, ByVal abc As Object)
            Dim objenc As clsEncrypt.Encryption
            Dim i As Integer
            Dim accion As String
            Dim opcion As String
            Dim ds_cols As DataTable
            Dim ws As clsSIGESProxyWrapper = SIGESWeb.clsInstanciaAplicacion.InstanciaWSGenerico(webenv.Context)

            If Not IsNothing(webenv.Session("key")) OrElse _
               webenv.Session("key") = "" Then
                objenc = New clsEncrypt.Encryption(webenv.Session("key"))
            Else
                webenv.Response.Redirect("../login/frmLogin.htm")
            End If

            If webenv.Request.QueryString("WHERE") Is Nothing Then
                sqlquery = webenv.Session("SQLQUERY")
            Else
                If Not webenv.Request.QueryString("TABLA") Is Nothing Then
                    webenv.Session("NombreTabla") = webenv.Request.QueryString("TABLA")
                End If
                sqlquery = "SELECT * FROM " & webenv.Session("NombreTabla") & " WHERE " & webenv.Request.QueryString("WHERE")
            End If

            If Not ispostback Then
                clsUtil.SetButtonIcon(CType(webenv.Session("DATA"), DataSet).Tables("TOOLBAR"), mypage.FindControl("GRABAR"), webenv.Request.QueryString("OP"))
                webenv.Session("FechaHoraIngreso") = Now()

                If InStr(webenv.Request.QueryString("OP"), "CREAR") = 0 Then
                    ds = ws.getDatabySQL(sqlquery, IIf(webenv.Session("OBJETO_DICCIONARIO") = "S", True, False), "<P></P>", webenv.Session("NombreTabla"))
                    webenv.Session("DATAROW") = ds
                    Dim consulta As String = webenv.Session("WhereCondition").ToString.Replace(webenv.Session("NombreTabla") & ".", "")
                    Dim filaSeleccionada As DataRow() = CType(webenv.Session("DATA"), DataSet).Tables("MAINDATA").Select(consulta)
                    dr = ds.Tables(0).Rows(0)
                    'el dr2 contiene los campos que no estan en el dr
                    dr2 = filaSeleccionada(0)
                    'ds.Tables.Add(filaSeleccionada(0).Table.Copy)
                Else
                    ds = ws.getDatabySQL("select * from " & webenv.Session("NombreTabla") & " where 1 = 0 ", IIf(webenv.Session("OBJETO_DICCIONARIO") = "S", True, False), "<P></P>", webenv.Session("NombreTabla"))
                    webenv.Session("DATAROW") = ds
                    'seccion para inicializar valores default
                    ds.Tables(0).TableName = webenv.Session("NombreTabla")
                End If
                ds.Tables(0).TableName = webenv.Session("NombreTabla")
                ds_cols = CType(webenv.Session("DATA"), DataSet).Tables("COLUMNAS_MAINDATA")
                dls = New DataSet
                For i = 0 To ds_cols.Rows.Count - 1
                    With ds_cols.Rows(i)
                        If Not IsDBNull(.Item("DATALIST")) AndAlso _
                           .Item("DATALIST") <> "" AndAlso _
                           dls.Tables.IndexOf(Trim(.Item("DATALIST"))) = -1 Then
                            If Not IsNothing(cache(Trim(.Item("DATALIST")))) Then
                                dls.Tables.Add(CType(cache(Trim(.Item("DATALIST"))), DataSet).Tables(0).Copy())
                                dls.Tables(dls.Tables.Count - 1).TableName = Trim(.Item("DATALIST"))
                            Else
                                Dim tdata As New DataSet
                                tdata = ws.getDatabySQL("SELECT SQL_STATEMENT FROM AD_LISTAS_VALORES WHERE UPPER(ID_LISTA) = '" & UCase(Trim(.Item("DATALIST"))) & "'", True, CType(webenv.Session("PARAMETROS"), System.Xml.XmlDocument).InnerXml, Nothing)
                                dls.Tables.Add(CType(ws.getDatabySQL(tdata.Tables(0).Rows(0).Item(0), False, CType(webenv.Session("PARAMETROS"), System.Xml.XmlDocument).InnerXml, Nothing), DataSet).Tables(0).Copy())
                                dls.Tables(dls.Tables.Count - 1).TableName = Trim(.Item("DATALIST"))
                            End If
                        End If
                    End With
                Next

                opcion = IIf(InStr(webenv.Request.QueryString("OP"), "CREAR") > 0, "CREAR", webenv.Request.QueryString("OP"))
                'Select Case webenv.Request.QueryString("OP")
                Select Case opcion
                    Case "CREAR", "PAGO_PARCIAL"
                        accion = "INSERT"
                    Case "MODIFICAR", "PAGO_TOTAL"
                        accion = "UPDATE"
                    Case Else
                        accion = "DISABLEALL"
                End Select
                clsUtil.DisableControls(mypage, CType(webenv.Session("DATA"), DataSet), accion)
                clsUtil.LoadData2(mypage, CType(webenv.Session("DATA"), DataSet), dls, webenv.Request.QueryString("OP"), dr, dr2)
                dls.Dispose()
                clsUtil.DataFormat(mypage, CType(webenv.Session("DATA"), DataSet))
            End If
        End Sub

        Public Sub generic_exit()
            webenv.Session("GO_TO_PAGINA_ACTUAL_" & webenv.Session("OBJETO")) = True
            'webenv.Response.Redirect()
            webenv.Server.Transfer("../" & webenv.Session("FORMA_ACTUAL"))
        End Sub


        Public Delegate Function AccionGrabarDelegado(ByVal mypage As System.Web.UI.Page, ByVal Operacion As String, ByVal multirow As Boolean, ByVal HacerRedirect As Boolean, ByVal isFunction As Boolean, ByVal tipoRetorno As String) As String

        ''' <summary>
        ''' Sobrecarga optimizada
        ''' </summary>
        ''' <param name="mypage"></param>
        ''' <param name="HacerRedirect"></param>
        ''' <param name="isFunction"></param>
        ''' <param name="tipoRetorno"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function AccionGrabar(ByVal mypage As System.Web.UI.Page, ByVal HacerRedirect As Boolean, ByVal isFunction As Boolean, ByVal tipoRetorno As String) As String
            Dim operacion As String = IIf(webenv.Request.QueryString("OP") Is Nothing, webenv.Session("OP"), webenv.Request.QueryString("OP"))
            Return GrabarDatos(mypage, operacion, False, HacerRedirect, isFunction, tipoRetorno)
        End Function

        ''' <summary>
        ''' Sobrecarga de método que permite hacer override a la operación que viene en el querystring
        ''' </summary>
        ''' <param name="mypage"></param>
        ''' <param name="Operacion"></param>
        ''' <param name="multirow"></param>
        ''' <param name="HacerRedirect"></param>
        ''' <param name="isFunction"></param>
        ''' <param name="tipoRetorno"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function AccionGrabar(ByVal mypage As System.Web.UI.Page, ByVal Operacion As String, ByVal multirow As Boolean, ByVal HacerRedirect As Boolean, ByVal isFunction As Boolean, ByVal tipoRetorno As String) As String
            Return GrabarDatos(mypage, Operacion, multirow, HacerRedirect, isFunction, tipoRetorno)
        End Function

        ''' <summary>
        ''' Sobrecarga de método genérica
        ''' </summary>
        ''' <param name="mypage"></param>
        ''' <param name="abc">Dummy usado para guardar compatibilidad</param>
        ''' <param name="multirow"></param>
        ''' <param name="HacerRedirect"></param>
        ''' <param name="isFunction"></param>
        ''' <param name="tipoRetorno"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function AccionGrabar(ByVal mypage As System.Web.UI.Page, ByVal abc As Object, Optional ByVal multirow As Boolean = False, Optional ByVal HacerRedirect As Boolean = True, Optional ByVal isFunction As Boolean = False, Optional ByVal tipoRetorno As String = Nothing) As String
            Dim operacion As String = IIf(webenv.Request.QueryString("OP") Is Nothing, webenv.Session("OP"), webenv.Request.QueryString("OP"))
            Return GrabarDatos(mypage, operacion, multirow, HacerRedirect, isFunction, tipoRetorno)
        End Function

        Private Function GrabarDatos(ByVal mypage As System.Web.UI.Page, ByVal Operacion As String, ByVal multirow As Boolean, ByVal HacerRedirect As Boolean, ByVal isFunction As Boolean, ByVal tipoRetorno As String) As String
            Dim requestOper As String = Operacion
            Dim metodo As String = ""
            Dim clase As String = ""
            Dim assemblyname As String = ""
            Dim result As String = ""
            Dim ws As clsSIGESProxyWrapper = SIGESWeb.clsInstanciaAplicacion.InstanciaWSGenerico(webenv.Context)

            If Not multirow Then
                ds = CType(webenv.Session("DATAROW"), DataSet)
                If ds.Tables(0).Rows.Count > 0 AndAlso (InStr(requestOper, "CREAR") > 0) Then ds.Tables(0).Rows.Clear()
                dr = clsUtil.LoadFromPage(mypage, requestOper, ds)
            Else
                If webenv.Session("NoAutoLoad") Is Nothing Then
                    ds = ws.getDatabySQL(webenv.Session("SQLQUERY"), False, "<P></P>", webenv.Session("NombreTabla"))
                Else
                    ds = CType(webenv.Session("DATAROW"), DataSet)
                    webenv.Session("NoAutoLoad") = Nothing
                End If
            End If

            Try
                clsUtil.darInformacionMetodo(requestOper, CType(webenv.Session("DATA"), DataSet), assemblyname, clase, metodo)
            Catch ex As Exception
                webenv.Response.Redirect("../" & webenv.Session("MODULO") & "/C" & webenv.Session("objeto") & ".aspx?OP=" & requestOper)
            End Try

            If (InStr(requestOper, "CREAR") > 0) And Not (dr Is Nothing) Then
                'ds.Tables(0).Clear()
                ds.Tables(0).Rows.Add(dr)
                'If ds.Tables(0).Rows.Count > 1 Then ds.Tables(0).Rows(0).Delete()
            End If
            If requestOper = "ELIMINAR" Then
                ds.Tables(0).Rows(0).Delete()
            End If

            Try
                result = ws.DynamicTransaction(ds, assemblyname, clase, metodo, isFunction, tipoRetorno, webenv.Session("Usuario"), webenv.Session("NombreTabla"), webenv.Session("OBJETO_DICCIONARIO") = "S", True)
            Catch e As Exception
                result = e.Message
            End Try
            webenv.Session("MensajeError") = result

            'si es llamada a un metodo se verifica la respuesta OK
            'si es llamada a una function se debera validar el retorno en el lugar donde se llamo a AccionGrabar
            If Not isFunction Then
                If result = "OK" Then
                    If HacerRedirect Then
                        If Not IsNothing(webenv.Session("ValidaGrabar")) AndAlso webenv.Session("ValidaGrabar") = 1 Then webenv.Session("ValidaGrabar") = 0
                        If requestOper = "CREAR" Then
                            If webenv.Request.QueryString("id") = "" Then
                                webenv.Server.Transfer("../" & webenv.Session("MODULO") & "/C" & webenv.Session("OBJETO") & ".aspx?OP=CREAR")
                            Else
                                webenv.Server.Transfer("../" & webenv.Session("MODULO") & "/C" & webenv.Session("OBJETO") & ".aspx?OP=CREAR&id=" & Replace(webenv.Request.QueryString("ID"), " ", "+"))
                            End If
                        Else
                            webenv.Session("MensajeError") = "OPERACION REALIZADA CON EXITO"
                            webenv.Server.Transfer("../general/frmMensajeExito.aspx")
                        End If
                    End If
                Else
                    If HacerRedirect Then
                        webenv.Server.Transfer("../general/frmMensajeError.aspx")
                    End If
                End If
            End If
            Return result
        End Function

        ''' <summary>
        ''' Carga datos de una lista de valores asumiendo que la primer columna es el valor
        ''' y la segunda la descripción que se cargará en la lista proveída por el SQL
        ''' </summary>
        ''' <param name="Lista"></param>
        ''' <param name="SQL"></param>
        ''' <remarks></remarks>
        Public Sub CargarListaValores(ByRef Lista As DropDownList, ByVal SQL As String)
            Dim ds As DataSet
            Dim ws As clsSIGESProxyWrapper = SIGESWeb.clsInstanciaAplicacion.InstanciaWSGenerico(webenv.Context)

            ds = ws.getDatabySQL(SQL, False, "<p></p>", Nothing)
            If Not IsNothing(ds) AndAlso _
               ds.Tables.Count > 0 Then
                CargarListaValores(Lista, ds.Tables(0))
            Else
                Dim objLOG As clsLOG = New clsLOG()
                Throw New Exception("Error al cargar lista de valores: " & Lista.ID)
                objLOG.AgregarLog("Error al cargar lista de valores: " & Lista.ID & " query: " & SQL, Diagnostics.EventLogEntryType.Error)
            End If
        End Sub

        ''' <summary>
        ''' Carga datos de una lista de valores asumiendo que la primer columna es el valor
        ''' y la segunda la descripción que se cargará en la lista proveída por el SQL
        ''' </summary>
        ''' <param name="Lista"></param>
        ''' <remarks></remarks>
        Public Sub CargarListaValores(ByRef Lista As DropDownList, ByVal sLista As String, ByVal sParametros As String)
            Dim ds As DataSet
            Dim tdata As DataSet
            Dim ws As clsSIGESProxyWrapper = SIGESWeb.clsInstanciaAplicacion.InstanciaWSGenerico(webenv.Context)

            tdata = ws.getDatabySQL("SELECT SQL_STATEMENT FROM AD_LISTAS_VALORES WHERE UPPER(ID_LISTA) = '" & Trim(sLista).ToUpper & "'", True, "<p></p>", Nothing)
            'If tdata.Tables(0).Rows(0).Item(0)  Then
            ds = ws.getDatabySQL(tdata.Tables(0).Rows(0).Item(0), False, sParametros, Nothing)
            If ds.Tables(0).Rows.Count > 0 Then CargarListaValores(Lista, ds.Tables(0))
        End Sub

        ''' <summary>
        ''' Carga datos de una lista de valores asumiendo que la primer columna es el valor
        ''' y la segunda la descripción que se cargará en la lista proveída por el SQL, método especial para
        ''' cargar dos listas que tienen el mismo contenido
        ''' </summary>
        ''' <param name="Lista"></param>
        ''' <param name="SQL"></param>
        ''' <remarks></remarks>
        Public Sub CargarListaValores(ByRef Lista As DropDownList, ByRef Lista2 As DropDownList, ByVal SQL As String)
            Dim ds As DataSet
            Dim ws As clsSIGESProxyWrapper = SIGESWeb.clsInstanciaAplicacion.InstanciaWSGenerico(webenv.Context)

            ds = ws.getDatabySQL(SQL, False, "<p></p>", Nothing)
            CargarListaValores(Lista, ds.Tables(0))
            CargarListaValores(Lista2, ds.Tables(0))
        End Sub

        ''' <summary>
        ''' Carga datos de una lista de valores asumiendo que la primer columna es el valor
        ''' y la segunda la descripción que se cargará en la lista proveída por el SQL, método especial para
        ''' cargar tres listas que tienen el mismo contenido
        ''' </summary>
        ''' <param name="Lista"></param>
        ''' <param name="SQL"></param>
        ''' <remarks></remarks>
        Public Sub CargarListaValores(ByRef Lista As DropDownList, ByRef Lista2 As DropDownList, ByRef Lista3 As DropDownList, ByVal SQL As String)
            Dim ds As DataSet
            Dim ws As clsSIGESProxyWrapper = SIGESWeb.clsInstanciaAplicacion.InstanciaWSGenerico(webenv.Context)

            ds = ws.getDatabySQL(SQL, False, "<p></p>", Nothing)
            CargarListaValores(Lista, ds.Tables(0))
            CargarListaValores(Lista2, ds.Tables(0))
            CargarListaValores(Lista3, ds.Tables(0))
        End Sub


        ''' <summary>
        ''' Carga datos de una lista de valores asumiendo que la primer columna es el valor
        ''' y la segunda la descripción que se cargará en la lista proveída por la tabla
        ''' </summary>
        ''' <param name="Lista"></param>
        ''' <param name="Tabla">Origen de datos</param>
        ''' <remarks></remarks>
        Public Sub CargarListaValores(ByRef Lista As DropDownList, ByVal Tabla As DataTable)
            If Not IsNothing(Tabla) Then
                Lista.DataSource = Tabla.DefaultView()
                Lista.DataValueField = Tabla.Columns(0).ColumnName()
                Lista.DataTextField = Tabla.Columns(1).ColumnName()
                Lista.DataBind()
            End If
        End Sub

        ''' <summary>
        ''' Carga datos de una lista de valores indicando específicamente los nombres de campos de llave y descripción
        ''' </summary>
        ''' <param name="Lista"></param>
        ''' <param name="Tabla">Origen de datos</param>
        ''' <param name="CampoLlave">Nombre del campo llave</param>
        ''' <param name="CampoDescripcion">Nombre del campo descripción</param>
        ''' <remarks></remarks>
        Public Sub CargarListaValores(ByRef Lista As DropDownList, ByVal Tabla As DataTable, ByVal CampoLlave As String, ByVal CampoDescripcion As String)
            If Not IsNothing(Tabla) Then
                Lista.DataSource = Tabla.DefaultView()
                Lista.DataValueField = CampoLlave
                Lista.DataTextField = CampoDescripcion
                Lista.DataBind()
            End If
        End Sub

        Public Sub DownloadFile(ByVal fname As String, ByVal forceDownload As Boolean, ByVal Pagina As System.Web.UI.Page)
            Dim fullpath As String = System.IO.Path.GetFullPath(fname)
            Dim name As String = System.IO.Path.GetFileName(fullpath)
            Dim ext As String = System.IO.Path.GetExtension(fullpath)
            Dim type As String = String.Empty

            If Not IsDBNull(ext) Then
                ext = LCase(ext)
            End If
            Select Case ext
                Case ".htm", ".html" : type = "text/HTML"
                Case ".txt" : type = "text/plain"
                Case ".doc", ".rtf" : type = "Application/msword"
                Case ".csv", ".xls" : type = "Application/x-msexcel"
                Case ".xml" : type = "text/xml"
                Case Else : type = "text/plain"
            End Select
            If (forceDownload) Then
                Pagina.Response.AppendHeader("content-disposition", _
                "attachment; filename=" + name)
            End If
            If type.Length > 0 Then
                Pagina.Response.ContentType = type
            End If
            Pagina.Response.WriteFile(fullpath)
            Pagina.Response.End()
        End Sub

#Region "Funciones para controles Telerik"
        Public Sub CargarListaValores(ByRef Lista As Telerik.Web.UI.RadComboBox, ByVal SQL As String)
            Dim ds As DataSet            
            Dim ws As clsSIGESProxyWrapper = SIGESWeb.clsInstanciaAplicacion.InstanciaWSGenerico(webenv.Context)

            ds = ws.getDatabySQL(SQL, False, "<p></p>", "MAINDATA")
            If Not IsNothing(ds) AndAlso _
               ds.Tables.Count > 0 Then
                CargarListaValores(Lista, ds.Tables(0))
            Else
                Dim objLOG As clsLOG = New clsLOG()
                Throw New Exception("Error al cargar lista de valores: " & Lista.ID)
                objLOG.AgregarLog("Error al cargar lista de valores: " & Lista.ID & " query: " & SQL, Diagnostics.EventLogEntryType.Error)
            End If
        End Sub

        Public Sub CargarListaValores(ByRef Lista As Telerik.Web.UI.RadComboBox, ByVal Tabla As DataTable)
            If Not IsNothing(Tabla) Then
                Lista.DataSource = Tabla.DefaultView()
                Lista.DataValueField = Tabla.Columns(0).ColumnName()
                Lista.DataTextField = Tabla.Columns(1).ColumnName()
                Lista.DataBind()
                Lista.SelectedIndex = 0
            End If
        End Sub
#End Region
    End Class
End Namespace
