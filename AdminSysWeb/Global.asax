<%@ Application Language="VB" %>

<script runat="server">
    Public Sub LeerParametrosConfig()
        Application("APPName") = System.Configuration.ConfigurationManager.AppSettings("APPName")
        Application("PathPDFS") = System.Configuration.ConfigurationManager.AppSettings("PathPDFS")
        Application("PathRPTS") = System.Configuration.ConfigurationManager.AppSettings("PathRPTS")
        Application("PoolMetaData") = System.Configuration.ConfigurationManager.AppSettings("PoolMetaData")
        Application("PoolData") = System.Configuration.ConfigurationManager.AppSettings("PoolData")
        Application("UserDSN") = System.Configuration.ConfigurationManager.AppSettings("UserDSN")
        Application("PassDSN") = System.Configuration.ConfigurationManager.AppSettings("PassDSN")
        Application("NameDSN") = System.Configuration.ConfigurationManager.AppSettings("NameDSN")
        Application("Ambiente") = System.Configuration.ConfigurationManager.AppSettings("Ambiente")
        Application("Ambiente_Aplicacion") = System.Configuration.ConfigurationManager.AppSettings("Ambiente_Aplicacion")
        Application("validar_generacion_reportes_concurrentes") = System.Configuration.ConfigurationManager.AppSettings("validar_generacion_reportes_concurrentes")
        Application("PROD") = System.Configuration.ConfigurationManager.AppSettings("PROD")
        Application("EndPointSIGESGenerico") = System.Configuration.ConfigurationManager.AppSettings("EndPointSIGESGenerico")
        Application("EndPointDataReporterSoap") = System.Configuration.ConfigurationManager.AppSettings("EndPointDataReporterSoap")
        Application("EndPointNominaPpRWCF") = System.Configuration.ConfigurationManager.AppSettings("EndPointNominaPpRWCF")
        Application("EndPointFormulacionPpR") = System.Configuration.ConfigurationManager.AppSettings("EndPointFormulacionPpR")
        Application("EndPointComprasWCF") = System.Configuration.ConfigurationManager.AppSettings("EndPointComprasWCF")
        Application("EndPointAdminSysWCF") = System.Configuration.ConfigurationManager.AppSettings("EndPointAdminSysWCF")
    End Sub
    
    Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' Se Buscan listas de valores para WebCache que no se cargan bajo demanda        
        Dim ds As New DataSet()
        Dim param As New System.Xml.XmlDocument()
        Dim ejercicios As New DataSet()

        LeerParametrosConfig()

        param.LoadXml("<PARAMETROS>" & _
                        "<PEJER_FORMULACION TIPODATO=""N"">" & Year(Now()) + 1 & "</PEJER_FORMULACION>" & _
                        "<PEJER_EJECUCION TIPODATO=""N"">" & Year(Now()) & "</PEJER_EJECUCION>" & _
                        "<PPORCENTAJE_IVA TIPODATO=""N"">" & 12 & "</PPORCENTAJE_IVA>" & _
                        "</PARAMETROS>")
        Application("GLOBAL_PARAMETROS") = param
        'JSAMAYOA [24/07/2006] - Recuperación de datos desde SAT
        'MODIFICADO CAMBIO PASSWORD POR CBARRERA [12/02/2007]
        Application("SAT_USUARIO") = "SIAF_SAG"
        Application("SAT_CLAVE") = "SECRETO1"
        Dim ws As New SIGESWeb.clsSIGESProxyWrapper()
        ds = ws.getDatabySQL("SELECT ID_LISTA,SQL_STATEMENT,USAR_DICCIONARIO FROM AD_LISTAS_VALORES WHERE USAR_WEBCACHE = 'S' AND CARGAR_BAJO_DEMANDA = 'N'", True, param.InnerXml, Nothing)
        Dim dr As DataRow
        Dim tdata As New DataSet
        For Each dr In ds.Tables(0).Rows
            Try
                tdata = ws.getDatabySQL(dr.Item(1), IIf(dr.Item(2) = "S", True, False), param.InnerXml, Nothing)
                tdata.Tables(0).PrimaryKey = New DataColumn() {tdata.Tables(0).Columns("LLAVE")}
                Context.Cache.Insert(Trim(dr.Item(0)), tdata)
            Catch errcat As Exception
                errcat = Nothing
            End Try
        Next
        ds.Dispose()
        Dim jQuery As New ScriptResourceDefinition()
        jQuery.Path = SIGESWeb.clsConstantes.includejQueryRegistro
        jQuery.DebugPath = SIGESWeb.clsConstantes.includejQueryRegistro
        jQuery.CdnPath = SIGESWeb.clsConstantes.includeCDNjQuery
        jQuery.CdnDebugPath = SIGESWeb.clsConstantes.includeCDNjQuery
        ScriptManager.ScriptResourceMapping.AddDefinition("jquery", jQuery)
    End Sub
    
    Sub Application_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs on application shutdown
    End Sub
        
    Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs when an unhandled error occurs
        Try
            Dim objErr As Exception = Server.GetLastError().GetBaseException()
            Dim err As String = " Error En la aplicacion SIGESWEB " & _
                                " Error en: " + Request.Url.ToString() & _
                                " Codigo : " & Guid.NewGuid().tostring & _
                                " Message de Error:" & objErr.Message.ToString() & _
                                " Detalle:" + objErr.StackTrace.ToString()
            SIGESWeb.clsUtil.MensajeLog("AppNet", err, SIGESWeb.clsConstantesCategoria.Login, SIGESWeb.clsConstantesSubCategoria.ErroresNoControlados)
            Me.Server.Transfer("../general/frmMensajeErrorGeneral.aspx?ec=-100")
        Catch ex As InvalidCastException
            'do nothing
        End Try
    End Sub

    Sub Session_Start(ByVal sender As Object, ByVal e As EventArgs)
        Dim objEncrypt As New clsEncrypt.Encryption
        Session("key") = objEncrypt.GetKey
    End Sub

    Sub Session_End(ByVal sender As Object, ByVal e As EventArgs)
       
    End Sub
</script>