Imports Microsoft.VisualBasic
Imports System.ServiceModel
Imports wsSIGES
Imports System.Collections.Generic
Imports System.Web.UI.Page


Namespace SIGESWeb
    Public Class clsSIGESProxyWrapper
        Inherits SIGESWeb.WS.Clases_Abstractas.clsObjetoProxy
        Private wsSIGES As wsSIGES.DataRetrievalWCFClient

        Private Sub AbrirConexion()
            wsSIGES = New wsSIGES.DataRetrievalWCFClient(System.Web.HttpContext.Current.Application("EndPointSIGESGenerico"))
            wsSIGES.Open()
        End Sub

        Private Sub CerrarConexion()
            Try
                wsSIGES.Close() 'Intenta cerrar una conexion que estaría fallida
            Catch
                Try
                    wsSIGES.Abort() 'Abortando conexion fallida
                Catch 'Absorbiendo el error
                End Try
            End Try
        End Sub

        Public Function ActualizarSesionUsuario(ByVal userid As String, ByVal fechahora As Date) As Boolean
            Try
                AbrirConexion()
                Return wsSIGES.ActualizarSesionUsuario(userid, fechahora)
            Catch
                Return Nothing
            Finally
                CerrarConexion()
            End Try
        End Function

        Public Function BeginDynamicTransaction(ByVal data As System.Data.DataSet, ByVal assemblyname As String, ByVal inst As String, ByVal metodo As String, ByVal isfunction As Boolean, ByVal datatype As String, ByVal usuario As String, ByVal tabla As String, ByVal usar_diccionario As Boolean, ByVal interactivo As Boolean, ByVal callback As System.AsyncCallback, ByVal asyncState As Object) As System.IAsyncResult
            Try
                AbrirConexion()
                Return wsSIGES.BeginDynamicTransaction(data, assemblyname, inst, metodo, isfunction, datatype, usuario, tabla, usar_diccionario, interactivo, callback, asyncState)
            Catch
                Return Nothing
            Finally
                CerrarConexion()
            End Try
        End Function

        Public Function bloqueoSemaforo() As Boolean
            Try
                AbrirConexion()
                Return wsSIGES.bloqueoSemaforo()
            Catch
                Return Nothing
            Finally
                CerrarConexion()
            End Try
        End Function

        Public Function CambioClave(ByVal strUsuario As String, ByVal strPassword As String) As Boolean
            Try
                AbrirConexion()
                Return wsSIGES.CambioClave(strUsuario, strPassword)
            Catch
                Return Nothing
            Finally
                CerrarConexion()
            End Try
        End Function

        'Public Function darMenuUsuario(ByVal Usuario As String, ByVal esfechacierre As Boolean, ByVal condTipoAcceso As String, ByVal objeto_raiz As String) As System.Data.DataSet
        '    Try
        '        AbrirConexion()
        '        Return wsSIGES.darMenuUsuario(Usuario, esfechacierre, condTipoAcceso, objeto_raiz)
        '    Catch
        '        Return Nothing
        '    Finally
        '        CerrarConexion()
        '    End Try
        'End Function

        Public Function MenuUsuario(Usuario As String, ObjetoInicial As String) As wsSIGES.clsObjeto()
            Try
                AbrirConexion()
                Return wsSIGES.MenuUsuario(Usuario, ObjetoInicial)
            Catch
                Return Nothing
            Finally
                CerrarConexion()
            End Try
        End Function

        Public Function DatosUsuario(ByVal userid As String) As String
            Try
                AbrirConexion()
                Return wsSIGES.DatosUsuario(userid)
            Catch
                Return Nothing
            Finally
                CerrarConexion()
            End Try
        End Function

        Public Function DynamicTransaction(ByVal data As System.Data.DataSet, ByVal assemblyname As String, ByVal inst As String, ByVal metodo As String, ByVal isfunction As Boolean, ByVal datatype As String, ByVal usuario As String, ByVal tabla As String, ByVal usar_diccionario As Boolean, ByVal interactivo As Boolean) As String
            Try
                AbrirConexion()
                Return wsSIGES.DynamicTransaction(data, assemblyname, inst, metodo, isfunction, datatype, usuario, tabla, usar_diccionario, interactivo)
            Catch
                Return Nothing
            Finally
                CerrarConexion()
            End Try
        End Function

        Public Function EjecutarDML(ByVal dml As String) As String
            Try
                AbrirConexion()
                Return wsSIGES.EjecutarDML(dml)
            Catch
                Return Nothing
            Finally
                CerrarConexion()
            End Try
        End Function

        Public Function EjecutarDMLMetadatos(ByVal dml As String) As String
            Try
                AbrirConexion()
                Return wsSIGES.EjecutarDMLMetadatos(dml)
            Catch
                Return Nothing
            Finally
                CerrarConexion()
            End Try
        End Function

        Public Function EjecutarTarea(ByVal data As System.Data.DataSet, ByVal assemblyname As String, ByVal inst As String, ByVal metodo As String, ByVal isfunction As Boolean, ByVal datatype As String, ByVal usuario As String, ByVal tabla As String, ByVal usar_diccionario As Boolean, ByVal interactivo As Boolean) As String
            Try
                AbrirConexion()
                Return wsSIGES.EjecutarTarea(data, assemblyname, inst, metodo, isfunction, datatype, usuario, tabla, usar_diccionario, interactivo)
            Catch
                Return Nothing
            Finally
                CerrarConexion()
            End Try
        End Function

        Public Function Ejercicios() As Integer()
            Try
                AbrirConexion()
                Return wsSIGES.Ejercicios()
            Catch
                Return Nothing
            Finally
                CerrarConexion()
            End Try
        End Function

        Public Function esAccesible(ByVal objeto As String, ByVal usuario As String, ByVal condTipoAcceso As String) As Boolean
            Try
                AbrirConexion()
                Return wsSIGES.esAccesible(objeto, usuario, condTipoAcceso)
            Catch
                Return Nothing
            Finally
                CerrarConexion()
            End Try
        End Function

        Public Function esSecretaria(Entidad As Decimal) As Boolean
            Try
                AbrirConexion()
                Return wsSIGES.esSecretaria(Entidad)
            Catch
                Return Nothing
            Finally
                CerrarConexion()
            End Try
        End Function

        Public Function execStoredProcedure(ByVal strSQL As String) As String
            Try
                AbrirConexion()
                wsSIGES.Endpoint.Binding.ReceiveTimeout = New TimeSpan(0, 30, 0)
                Return wsSIGES.execStoredProcedure(strSQL)
            Catch
                Return Nothing
            Finally
                CerrarConexion()
            End Try
        End Function

        Public Function expiraTiempoClave(ByVal userid As String, ByVal cantidadDias As Integer) As Boolean
            Try
                AbrirConexion()
                Return wsSIGES.expiraTiempoClave(userid, cantidadDias)
                Return Nothing
            Finally
                CerrarConexion()
            End Try
        End Function

        Public Function FuncionesUsuario(ByVal userid As String) As String
            Try
                AbrirConexion()
                Return wsSIGES.FuncionesUsuario(userid)
            Finally
                CerrarConexion()
            End Try
        End Function

        Public Function getDatabyID(ByVal id_objeto As String, ByVal parametros As String, ByVal usuario As String, ByVal condTipoAcceso As String, ByVal OrigenSelect As Byte) As System.Data.DataSet
            Try
                AbrirConexion()
                Return wsSIGES.getDatabyID(id_objeto, parametros, usuario, condTipoAcceso, OrigenSelect)
            Finally
                CerrarConexion()
            End Try
        End Function

        Public Function getDatabyIDRank(ByVal id_objeto As String, ByVal parametros As String, ByVal usuario As String, ByVal condTipoAcceso As String, ByVal OrigenSelect As Byte, ByVal NoPagina As Integer, ByVal pQuerySQL As String, ByVal pNoFilas As Decimal) As System.Data.DataSet
            Try
                AbrirConexion()
                Return wsSIGES.getDatabyIDRank(id_objeto, parametros, usuario, condTipoAcceso, OrigenSelect, NoPagina, pQuerySQL, pNoFilas)
            Finally
                CerrarConexion()
            End Try
        End Function

        Public Function getDatabyIDReporte(ByVal id_objeto As String, ByVal usuario As String, ByVal bSintaxsisCR As Boolean) As System.Data.DataSet
            Try
                AbrirConexion()
                Return wsSIGES.getDatabyIDReporte(id_objeto, usuario, bSintaxsisCR)
            Finally
                CerrarConexion()
            End Try
        End Function

        Public Function getDatabyPage(ByVal Pagina As String, ByVal Query As String, ByVal Comportamiento As Byte, ByVal Parametros() As Parametro) As System.Data.DataSet
            Try
                AbrirConexion()
                Return wsSIGES.getDatabyPage(Pagina, Query, Comportamiento, Parametros)
            Finally
                CerrarConexion()
            End Try
        End Function

        Public Function getDatabyPagebyUC(ByVal Pagina As String, ByVal Query As String, ByVal Comportamiento As Byte, ByVal Ejercicio As Decimal, ByVal Entidad As Decimal, ByVal UE As Decimal, ByVal UC As Decimal, ByVal Parametros() As Parametro) As System.Data.DataSet
            Try
                AbrirConexion()
                Return wsSIGES.getDatabyPagebyUC(Pagina, Query, Comportamiento, Ejercicio, Entidad, UE, UC, Parametros)
            Finally
                CerrarConexion()
            End Try
        End Function

        Public Function getDatabyPageRank(ByVal Pagina As String, ByVal Query As String, ByVal Comportamiento As Byte, ByVal Parametros() As Parametro, ByVal NoPagina As Integer, ByVal pNoFilas As Decimal, ByVal pFiltro As String, ByVal TamanoPagina As Integer) As System.Data.DataSet
            Try
                AbrirConexion()
                Return wsSIGES.getDatabyPageRank(Pagina, Query, Comportamiento, Parametros, NoPagina, pNoFilas, pFiltro, TamanoPagina)
            Finally
                CerrarConexion()
            End Try
        End Function

        Public Function getDatabySQL(ByVal sqlstmt As String, ByVal getFromDictionary As Boolean, ByVal parametros As String, ByVal table As String) As System.Data.DataSet
            Try
                AbrirConexion()
                Return wsSIGES.getDatabySQL(sqlstmt, getFromDictionary, parametros, table)
            Finally
                CerrarConexion()
            End Try
        End Function

        Public Function getDatabySQLbyPool(ByVal sqlstmt As String, ByVal PoolName As String, ByVal parametros As String, ByVal table As String) As System.Data.DataSet
            Try
                AbrirConexion()
                Return wsSIGES.getDatabySQLbyPool(sqlstmt, PoolName, parametros, table)
            Finally
                CerrarConexion()
            End Try
        End Function

        Public Function getDatabySQLID(ByVal id_objeto As String, ByVal getFromDictionary As Boolean, ByVal parametros As String, ByVal usuario As String, ByVal OrigenSelect As Byte) As System.Data.DataSet
            Try
                AbrirConexion()
                Return wsSIGES.getDatabySQLID(id_objeto, getFromDictionary, parametros, usuario, OrigenSelect)
            Finally
                CerrarConexion()
            End Try
        End Function

        Public Function GetExcepciones() As String
            Try
                AbrirConexion()
                Return wsSIGES.GetExcepciones()
            Finally
                CerrarConexion()
            End Try
        End Function

        Public Function getLOV(ByVal IDLOV As String, ByVal params As String, ByVal use_diccionario As Boolean, ByVal OrigenSelect As Byte, ByVal usuario As String) As System.Data.DataSet
            Try
                AbrirConexion()
                Return wsSIGES.getLOV(IDLOV, params, use_diccionario, OrigenSelect, usuario)
            Finally
                CerrarConexion()
            End Try
        End Function

        Public Function getPredicadoGranularidad(ByVal pivot_table As String, ByVal usuario As String) As String
            Try
                AbrirConexion()
                Return wsSIGES.getPredicadoGranularidad(pivot_table, usuario)
            Finally
                CerrarConexion()
            End Try
        End Function

        Public Function getPredicadoGranularidadAdFunciones(ByVal pivot_table As String, ByVal usuario As String, ByVal tipoFuncion As String) As String
            Try
                AbrirConexion()
                Return wsSIGES.getPredicadoGranularidadAdFunciones(pivot_table, usuario, tipoFuncion)
            Finally
                CerrarConexion()
            End Try
        End Function

        Public Function getTipoDatabase() As String
            Try
                AbrirConexion()
                Return wsSIGES.getTipoDatabase()
            Finally
                CerrarConexion()
            End Try
        End Function

        Public Function getUnidadesCompradoras(ByVal pivot_table As String, ByVal usuario As String, ByVal sqlstmt As String, ByVal getFromDictionary As Boolean, ByVal parametros As String) As System.Data.DataSet
            Try
                AbrirConexion()
                Return wsSIGES.getUnidadesCompradoras(pivot_table, usuario, sqlstmt, getFromDictionary, parametros)
            Finally
                CerrarConexion()
            End Try
        End Function

        Public Function LimpiarTareas(ByVal usuario As String) As String
            Try
                AbrirConexion()
                Return wsSIGES.LimpiarTareas(usuario)
            Finally
                CerrarConexion()
            End Try
        End Function

        Public Function LinkOnExpand(ByVal id_objeto As String, ByVal usuario As String, ByVal condTipoAcceso As String) As Boolean
            Try
                AbrirConexion()
                Return wsSIGES.LinkOnExpand(id_objeto, usuario, condTipoAcceso)
            Finally
                CerrarConexion()
            End Try
        End Function

        Public Function loadListaReportes(ByVal id_objeto As String) As System.Data.DataSet
            Try
                AbrirConexion()
                Return wsSIGES.loadListaReportes(id_objeto)
            Finally
                CerrarConexion()
            End Try
        End Function

        Public Function loadParametros(ByVal id_objeto As String, ByVal parametros As String) As System.Data.DataSet
            Try
                AbrirConexion()
                Return wsSIGES.loadParametros(id_objeto, parametros)
            Finally
                CerrarConexion()
            End Try
        End Function

        Public Function loadTabGroup(ByVal id_objeto As String, ByVal usuario As String, ByVal condTipoAcceso As String, ByVal tabroot As Boolean) As System.Data.DataSet
            Try
                AbrirConexion()
                Return wsSIGES.loadTabGroup(id_objeto, usuario, condTipoAcceso, tabroot)
            Finally
                CerrarConexion()
            End Try
        End Function

        Public Function LogIN(ByVal userid As String, ByVal pwd As String, ByVal SID As String) As Integer
            Try
                AbrirConexion()
                Return wsSIGES.LogIN(userid, pwd, SID)
            Finally
                CerrarConexion()
            End Try
        End Function

        Public Function LogOff(ByVal userid As String) As Boolean
            Try
                AbrirConexion()
                Return wsSIGES.LogOff(userid)
            Finally
                CerrarConexion()
            End Try
        End Function

        Public Function ObtenerTareas(ByVal usuario As String) As String
            Try
                AbrirConexion()
                Return wsSIGES.ObtenerTareas(usuario)
            Finally
                CerrarConexion()
            End Try
        End Function

        Public Function puedeCambiarClave(ByVal userid As String) As Boolean
            Try
                AbrirConexion()
                Return wsSIGES.puedeCambiarClave(userid)
            Finally
                CerrarConexion()
            End Try
        End Function

        Public Function SolicitaEjecucionSNIP(ByVal EjercicioEjecucion As Integer, ByVal SNIP As Decimal, ByVal Usuario As String, ByVal FaseEjecucion As Byte, ByVal TipoEjecucion As Byte, ByVal datos As System.Data.DataSet) As String
            Try
                AbrirConexion()
                Return wsSIGES.SolicitaEjecucionSNIP(EjercicioEjecucion, SNIP, Usuario, FaseEjecucion, TipoEjecucion, datos)
            Finally
                CerrarConexion()
            End Try
        End Function

        Public Function TienePermiso(ByVal Usuario As String, ByVal Permiso As String, ByVal condTipoAcceso As String) As Boolean
            Try
                AbrirConexion()
                Return wsSIGES.TienePermiso(Usuario, Permiso, condTipoAcceso)
            Finally
                CerrarConexion()
            End Try
        End Function

        Public Function ValidaUsuario(ByVal userid As String, ByVal pwd As String) As Integer
            Try
                AbrirConexion()
                Return wsSIGES.ValidaUsuario(userid, pwd)
            Finally
                CerrarConexion()
            End Try
        End Function

        Public Function CargarToolBar(objeto As String, usuario As String) As wsSIGES.clsToolBar
            Try
                AbrirConexion()
                Return wsSIGES.CargarToolbar(objeto, usuario)
            Finally
                CerrarConexion()
            End Try
        End Function

        Public Function CargarHistorialAnotacion(Gestion As Decimal, ItemInicial As Integer, Lote As Integer) As wsSIGES.clsSeguimientoAnotacionRank
            Try
                AbrirConexion()
                Return wsSIGES.HistorialGestion(Gestion, ItemInicial, Lote)
            Catch
                Return Nothing
            Finally
                CerrarConexion()
            End Try
        End Function

        Public Function ObjetoInicial(Usuario As String) As String
            Try
                AbrirConexion()
                Return wsSIGES.ObjetoInicial(Usuario)
            Catch
                Return Nothing
            Finally
                CerrarConexion()
            End Try
        End Function

        Public Function TabGroup(Usuario As String) As wsSIGES.clsObjeto()
            Try
                AbrirConexion()
                Return wsSIGES.TabGroup(Usuario)
            Catch
                Return Nothing
            Finally
                CerrarConexion()
            End Try
        End Function

        Public Function Entidades(Ejercicio As Integer, Usuario As String, ItemInicial As Integer, Lote As Integer, Filtro As String) As wsSIGES.clsEntidadRank
            Try
                AbrirConexion()
                Return wsSIGES.Entidades(Ejercicio, Usuario, ItemInicial, Lote, Filtro)
            Catch
                Return Nothing
            Finally
                CerrarConexion()
            End Try
        End Function

        Public Function UnidadesCompradoras(ObjetoInicial As wsSIGES.ModuloSIGES, Ejercicio As Integer, Entidad As Integer, UE As Integer, Usuario As String, ItemInicial As Integer, Lote As Integer, Filtro As String) As wsSIGES.clsUnidadCompradoraRank
            Try
                AbrirConexion()
                Return wsSIGES.UnidadesCompradoras(ObjetoInicial, Ejercicio, Entidad, UE, Usuario, ItemInicial, Lote, Filtro)
            Catch
                Return Nothing
            Finally
                CerrarConexion()
            End Try
        End Function

        Public Function NoticiasVigentes() As wsSIGES.clsNoticia()
            Try                
                AbrirConexion()
                Return wsSIGES.NoticiasVigentes()
            Catch ex As Exception
                RegistrarError(ex)
                Return Nothing
            Finally
                CerrarConexion()
            End Try
        End Function

        Public Function TicketsAsignados(Usuario As String) As wsSIGES.clsTicketInsumo()
            Try
                AbrirConexion()
                Return wsSIGES.TicketsAsignados(Usuario)
            Catch ex As Exception
                RegistrarError(ex)
                Return Nothing
            Finally
                CerrarConexion()
            End Try
        End Function

        Public Function TicketsFinalizados(Usuario As String) As wsSIGES.clsTicketInsumo()
            Try
                AbrirConexion()
                Return wsSIGES.TicketsFinalizados(Usuario)
            Catch ex As Exception
                RegistrarError(ex)
                Return Nothing
            Finally
                CerrarConexion()
            End Try
        End Function

        Public Function TicketsGenerados(Usuario As String) As wsSIGES.clsTicketInsumo()
            Try
                AbrirConexion()
                Return wsSIGES.TicketsGenerados(Usuario)
            Catch ex As Exception
                RegistrarError(ex)
                Return Nothing
            Finally
                CerrarConexion()
            End Try

        End Function

        Public Function TicketsRechazados(Usuario As String) As wsSIGES.clsTicketInsumo()
            Try
                AbrirConexion()
                Return wsSIGES.TicketsRechazados(Usuario)
            Catch ex As Exception
                RegistrarError(ex)
                Return Nothing
            Finally
                CerrarConexion()
            End Try
        End Function

        Public Function TicketsReporte(Usuario As String) As wsSIGES.clsTicketReporte()
            Try
                AbrirConexion()
                Return wsSIGES.TicketsReporte(Usuario)
            Catch ex As Exception
                RegistrarError(ex)
                Return Nothing
            Finally
                CerrarConexion()
            End Try
        End Function
    End Class
End Namespace