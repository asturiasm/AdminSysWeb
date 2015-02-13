Namespace SIGESWeb

    Public Class clsConstantes
        Public Const EndPointGuatecompras As String = "GCWsIntPubSoap"
        Public Shared EndPointSIGESGenerico As String = System.Configuration.ConfigurationManager.AppSettings("EndPointSIGESGenerico")
        Public Shared EndPointSIGESInsumos As String = System.Configuration.ConfigurationManager.AppSettings("EndPointInsumosWCF")

        'Constantes para uso de gestiones
        Public Const GestionLibreria As String = "blGestion"
        Public Const GestionInstancia As String = "SIGES.Gestion.clsControladoraGestion"
        Public Const GestionMetodo As String = "procesaGestion"

        'Constates para validacion de sesion
        Public Const ErrNoExisteUsr As Integer = -1
        Public Const ErrUsrEnSesion As Integer = -2
        Public Const ErrClaveInvalida As Integer = -3
        Public Const ErrSesionExpirada As Integer = -4
        Public Const ErrOrigenInvalido As Integer = -5
        Public Const ErrUsuarioInactivo As Integer = -6
        Public Const ErrUsuarioSinPermiso As Integer = -7
        Public Const ErrEntradasNoValidas As Integer = -8

        Public Const TimeOutSesion As Decimal = 7200    'timeout de la sesion en segundos
        Public Const EsperaFinSesionAuto As Decimal = 600    'tiempo de espera para el logout automatico

        'constantes para los tipos de datos
        Public Const TipoDatoBDDString As String = "C"
        Public Const TipoDatoBDDDate As String = "D"
        Public Const TipoDatoBDDInt As String = "N"
        Public Const TipoDatoBDDChar As String = "C"
        Public Const TipoDatoBDDBool As String = "B"

        'constantes para reportes
        Public Const NombreDSN As String = "Siaf2003"
        Public Const UsuarioBDDReportes As String = "SIGESWeb"
        Public Const PasswordBDDReportes As String = "SIGESWeb"
        Public Const PathRreportes As String = "c:\reportes\"
        Public Const PathExport As String = "c:\reportes\export\"
        Public Const NombreParamTitulo1 As String = "P_TITULO1"
        Public Const NombreParamTitulo2 As String = "P_TITULO2"
        Public Const NombreParamTitulo3 As String = "P_TITULO3"
        Public Const NombreParamUnidad As String = "P_UNIDAD"
        Public Const NombreParamTituloUnidad As String = "P_TITULO_UNIDAD"
        Public Const NombreParamReporte As String = "P_REPORTE"
        Public Const NombreParamFiltros As String = "P_FILTRO"
        Public Const NombreParamEstado As String = "P_ESTADO"


        Public Const C_ESTADOLOGIN_ON As Integer = 1
        Public Const C_ESTADOLOGIN_OFF As Integer = 0
        Public Const C_ESTADOLOGIN_EXPIRADO As Integer = 2

        Public Const C_ERROR_SIN_ERROR As Integer = 0
        Public Const C_ERROR_NO_EXISTE_USUARIO As Integer = -1
        Public Const C_ERROR_USUARIO_EN_OTRA_SESION As Integer = -2
        Public Const C_ERROR_CLAVE_INVALIDA As Integer = -3
        Public Const C_ERROR_DESCONOCIDO As Integer = -100

        'constantes para los tipos de objeto
        Public Const C_TIPO_OBJETO_REPORTE_VIRTUAL As Integer = 15
        Public Const C_TIPO_OBJETO_REPORTE As Integer = 4

        ' Modificada la direccion de envio de correos de soporte (se unificara la lista de soporte)
        '21/02/2007
        Public Const C_EMAIL_CONTACTENOS As String = "soporte@siafsag.gob.gt"
        Public Const C_EMAIL_CONTACTENOS_DESCENT As String = "soportedes@siafsag.gob.gt"
        Public Const C_EMAIL_CONTACTENOS_INVENTA As String = "soporte_inventarios@siafsag.gob.gt"
        Public Const C_EMAIL_CONTACTENOS_SIGES As String = "soporte@siafsag.gob.gt"
        Public Const C_SERVIDOR_MAIL As String = "172.25.5.122"

        'version minima del navegador
        Public Const C_BROWSER_TYPE As String = "IE"
        Public Const C_BROWSER_VERSION As String = "6.0"

        Public Const TablaCamposAdicionales As String = "CamposAdicionales"
        Public Const TablaCategorias As String = "Categorias"
        Public Const TablaAnotaciones As String = "Anotaciones"
        Public Const TablaGestion As String = "GESTION"
        Public Const TablaCDP As String = "CDP"
        Public Const TablaCabecera As String = "Cabecera"
        Public Const TablaCabeceraTemp As String = "CabeceraTEMP"
        Public Const TablaLiquidaciones As String = "Liquidaciones"
        Public Const TablaCarritoItems As String = "CarritoItems"
        Public Const TablaSistemaContable As String = "SISTEMA_CONTABLE"
        Public Const TablaExcepciones As String = "Excepciones"
        Public Const TablaMontos As String = "MontoSnip"
        Public Const TablaMontosAmortizacion As String = "Montos"
        Public Const TablaAdjuntos As String = "Adjuntos"

        'CONSTANTES USADAS PARA INTERFAZ CON SICOIN
        Public Const TablaSICOIN As String = "CABECERAS"
        Public Const TablaSICOINPartidas As String = "PARTIDAS"
        Public Const TablaSICOINDeducciones As String = "DEDUCCIONES"
        Public Const TablaSICOINFacturas As String = "FACTURAS"
        Public Const TablaSICOINBienes As String = "BIENES"
        Public Const TablaDocumentoOC As String = "OC_DOCUMENTO"
        Public Const TablaSICOINContraPartidas As String = "PARTIDAS_CPR" 'agregada el 23/02/2007
        Public Const TablaDatosOrdenCompra As String = "OrdenDeCompra" '[kherrera - 31/12/2010]

        'CONSTANTES PARA MANEJO DE GESTION
        Public Const TablaCGETAPA_PROCESO As String = "ETAPA_PROCESO"

        'Acciones - Orden de Compra
        Public Const Accion_NuevaOC As String = "NUEVA OC"
        Public Const Accion_AutorizarOC As String = "AUTORIZAR OC"
        Public Const Accion_RechazarOC As String = "RECHAZAR OC"
        Public Const Accion_ModificarOC As String = "MODIFICAR OC"
        Public Const Accion_AnularOC As String = "ANULAR OC"
        Public Const Accion_RegistrarOC As String = "REGISTRAR OC"
        Public Const Accion_PresupuestaCOM As String = "PRESUPUESTA COM"
        Public Const Accion_GenerarCUR As String = "GENERAR CUR"
        Public Const Accion_AnularDOC As String = "ANULAR DOC"
        Public Const Accion_RechazarCUR As String = "RECHAZAR CUR"
        Public Const Accion_AprobarCUR As String = "APROBAR CUR"
        Public Const Accion_Notificar As String = "NOTIFICAR"

        'Acciones - Liquidación - Orden de Compra
        Public Const Accion_AnularLIQ As String = "ANULAR LIQ"
        Public Const Accion_AutorizarLIQ As String = "AUTORIZAR LIQ"
        Public Const Accion_ModificarLIQ As String = "MODIFICAR LIQ"
        Public Const Accion_NuevaLIQ As String = "NUEVA LIQ"
        Public Const Accion_RechazarLIQ As String = "RECHAZAR LIQ"
        Public Const Accion_RegistrarLIQ As String = "REGISTRAR LIQ"
        Public Const Accion_AnularLIQAPR As String = "ANULAR LIQ-APR"

        'Tipo de Documento - Orden de Compra
        Public Const TipoDocumentoCompra As String = "COM"
        Public Const TipoDocumentoPago As String = "OCFA"
        Public Const TipoDocumentoDev As String = "FAC"
        Public Const TipoDocumentoDevSOL As String = "SOL"
        Public Const TipoDocumentoDevAPR As String = "APR"

        'Etapas - Orden de Compra
        Public Const EtapaGenerarCOM As String = "GENERAR COM"
        Public Const EtapaRegistroOC As String = "REGISTRO OC"
        Public Const EtapaGenerarDEV As String = "GENERA DEV"
        Public Const EtapaRegistroFAC As String = "REGISTRO FAC"

        'Gestiones
        Public Const GestionTipoGestionOC As String = "OC"

        'Múltiples sistemas contables
        Public Const ComportamientoGobCentral As String = "GOBIERNO_CENTRAL"
        Public Const ComportamientoGobCentralVal As Byte = 1
        Public Const ComportamientoDescentralizada As String = "DESCENTRALIZADA"
        Public Const ComportamientoDescentralizadaVal As Byte = 2

        'Control de Sesiones
        Public Const errorSesionExpirada As String = "La sesión ha expirado. Por favor, autentíquese de nuevo."
        Public Const errorLogin As String = "Es necesario que vuelva a autenticarse. Por favor intentelo nuevamente."
        Public Const CodificacionISO As String = "<?xml version=""1.0"" encoding=""ISO-8859-1"" ?>"
        Public Const includejQueryRegistro As String = "~/Scripts/jquery-1.10.2.min.js"
        Public Const includejQuery As String = "../Scripts/jquery-1.10.2.min.js"
        Public Const includeCDNjQuery As String = "http://ajax.microsoft.com/ajax/jQuery/jquery-1.10.2.min.js"
        Public Const includejQueryUI As String = "../Scripts/jquery-ui-1.10.3.min.js"
        'Formato Numérico
        Public Const FormatoNumerico As String = "#,##0.00;(#,##0.00);0.00"
    End Class

    Public Class clsConstantesPC

        'Tipo de Proceso
        Public Const ProcesoSolicitud As String = "SOL"
        Public Const ProcesoConsolidacion As String = "CON"
        Public Const ProcesoAdjudicacion As String = "ADJ"
        Public Const ProcesoLiquidacion As String = "LIQ"
        Public Const CYD As String = "CYD"
        Public Const COM_DEV_ADJ As String = "CDA"
        Public Const COM_DEV_LIQ As String = "CDL"
        Public Const COM_RDP_ADJ As String = "CRA"
        Public Const COM_RDP_LIQ As String = "CRL"

        'Etapa del proceso
        Public Const EtapaRegistro As String = "REG"

        'Acciones - Pedido
        Public Const Accion_RegistrarPC As String = "REGISTRAR"
        Public Const Accion_ModificarPC As String = "REGISTRAR"
        Public Const Accion_AnularPC As String = "ANULAR"
        Public Const Accion_EnviarPC As String = "ENVIAR"
        Public Const Accion_AutorizarPC As String = "AUTORIZAR"
        Public Const Accion_RechazarPC As String = "RECHAZAR"
        Public Const TablaConsolidacion As String = "TablaConsolidacion"
        Public Const TablaDetallePartidas As String = "DetallePartidas"
        Public Const TablaDetallePartidasSnip As String = "DetallePartidasSnip"

        'Tipo de Documento
        Public Const TipoDocumentoPC As Integer = 1

        Public Class TipoModificacion
            'Tipo de Modificacion
            Public Const COM_RPA As Integer = 1
            Public Const COM_RTO As Integer = 2
            Public Const COM_AUC As Integer = 3
            Public Const DEV_RTO As Integer = 4
            Public Const DEV_DEV_Parcial As Integer = 5
            Public Const DEV_DEV_Total As Integer = 6
            Public Const CYD_RTO As Integer = 7
            Public Const CYD_DEV_Total As Integer = 8
            Public Const CYD_DEV_Parcial As Integer = 9
        End Class

        Public Class TipoGestion
            Public Const ProcesoCompra As String = "PC"
            Public Const ExpedienteGastos As String = "EG"
        End Class

        Public Class TipoProceso
            Public Const Solicitud As String = "SOL"
            Public Const Consolidacion As String = "CON"
            Public Const Adjudicacion As String = "ADJ"
            Public Const Liquidacion As String = "LIQ"
            Public Const CYD As String = "CYD"
            Public Const COM_DEV_ADJ As String = "CDA"
            Public Const COM_DEV_LIQ As String = "CDL"
            Public Const COM_RDP_ADJ As String = "CRA"
            Public Const COM_RDP_LIQ As String = "CRL"
            Public Const ProcesoRevAdjudicacion As String = "RADJ"
            Public Const ProcesoRevLiquidacion As String = "RLIQ"
            Public Const ProcesoRevCYD As String = "RCYD"
            Public Const ProcesoRevCDA As String = "RCDA"
            Public Const ProcesoRevCDL As String = "RCDL"
            Public Const ProcesoRevCRA As String = "RCRA"
            Public Const ProcesoRevCRL As String = "RCRL"
        End Class

        Public Class Etapa
            Public Const Registro As String = "REG"
            Public Const Compromiso As String = "COM"
            Public Const Entrega As String = "ENT"
            Public Const Liquidacion As String = "LIQ"
            Public Const Pago As String = "PAG"
            Public Const CYD As String = "CYD"
            Public Const COM_DEV As String = "COMD"
        End Class

        Public Class Accion
            Public Const Registrar As String = "REGISTRAR"
            Public Const Modificar As String = "MODIFICAR"
            Public Const Anular As String = "ANULAR"
            Public Const Enviar As String = "ENVIAR"
            Public Const Consolidar As String = "CONSOLIDAR"
            Public Const Recibir As String = "RECIBIR"
            Public Const Rechazar As String = "RECHAZAR"
            Public Const RechazarLiquidacion As String = "RECHAZARLIQ"
            Public Const RechazarSolicitud As String = "RECHAZAR_SOL"
            Public Const Licitar As String = "LICITAR"
            Public Const Generar As String = "GENERAR"
            Public Const Solicitar As String = "SOLICITAR"
            Public Const Aprobar As String = "APROBAR"
            Public Const Autorizar As String = "AUTORIZAR"
            Public Const Pagar As String = "PAGAR"
            Public Const Liquidar As String = "LIQUIDAR"
            Public Const Finalizar As String = "FINALIZAR"
        End Class

        Public Class Estado
            Public Const Registrado As String = "REGISTRADO"
            Public Const Anulado As String = "ANULADO"
            Public Const Enviado As String = "ENVIADO"
            Public Const Recibido As String = "RECIBIDO"
            Public Const Consolidado As String = "CONSOLIDADO"
            Public Const PorAdjudicar As String = "POR ADJUDICAR"
            Public Const Autorizado As String = "AUTORIZADO"
            Public Const Generado As String = "GENERADO"
            Public Const Solicitado As String = "SOLICITADO"
            Public Const Aprobado As String = "APROBADO"
            Public Const Pagado As String = "PAGADO"
        End Class
    End Class

    Public Class clsConstantesConta
        Public Const TipoDocumentoComprobanteFiscal As Integer = 5
    End Class

    Public Class clsConstantesCDP
        Public Const GestionTipo As String = "CDP"
        Public Const ProcesoRegistro As String = "REC"
        Public Const ProcesoProgramacion As String = "PRG"
        Public Const AccionCrearCDP As String = "CREAR CDP"
        Public Const AccionCrearPRG As String = "CREAR PRG"
        Public Const AccionSolicitarCDP As String = "SOLICITAR CDP"
        Public Const AccionSolicitarPRG As String = "AUTORIZAR PRG"
        Public Const AccionEnviarPRG As String = "ENVIAR PRG"
        Public Const GlaseGastoOGA As String = "OGA"
        Public Const ClaseGastoSUE As String = "SUE"
        Public Const ClaseGastoTRF As String = "TRF"
        Public Const TablaEstructuras As String = "Estructuras"
        Public Const TablaAdjuntos As String = "Adjuntos"
        Public Const TablaEstructurasPPR As String = "EstructurasPPR"
    End Class

    Public Class clsConstantesSNIP
        Public Const GestionTipo As String = "SNIP"
        Public Const ProcesoProgramacion As String = "MP"
        Public Const TablaEstructuras As String = "Estructuras"
        Public Const TablaPartidas As String = "Partidas"
        Public Const TablaAdjuntos As String = "Adjuntos"
        Public Const TablaEstructuraMeta As String = "EstructuraMeta"
    End Class

    Public Class clsConstantesContratos
        Public Const TablaObjetoContrato As String = "CO_OBJETO_CONTRATO"
        Public Const TablaModalidadEjecucion As String = "CO_MODALIDAD_EJECUCION"
        Public Const TablaTipoContrato As String = "CO_TIPO_CONTRATO"
        Public Const tablaAnticipo As String = "CO_ANTICIPO"
        Public Const TablaDocumentoAdjunto As String = "CO_DOCUMENTO_ADJUNTO"
        Public Const TablaAnticipoFianza As String = "CO_ANTICIPO_FIANZA"
        Public Const TablaAnticipoFuentes As String = "CO_ANTICIPO_FUENTE"
        Public Const TipoDeduccionAnticipo As Decimal = 302

        'Public Const EstadoAutorizado As String = "AUTORIZADO"
        Public Const EstadoActivado As String = "ACTIVADO"
        Public Const EstadoRegistrado As String = "REGISTRADO"
        Public Const EstadoAvanceEjecutado As String = "EJECUTADO"
        Public Const EstadoAvanceDistribuido As String = "DISTRIBUIDO"
        Public Const EstadoAnticipoDistribuido As String = "DISTRIBUIDO"
        Public Const EstadoEnEjecucion As String = "EN EJECUCION"
        Public Const TipoAdjuntoContrato As Integer = 1
        Public Const TipoAcuerdoMinisterial As Integer = 2
        Public Const TipoResolucion As Integer = 13
        Public Const TablaProyectoTramo As String = "Tramos"
        Public Const TablaContratoEtapa As String = "Etapas"
        Public Const TablaContratoGarantia As String = "Garantias"
        Public Const TablaContratoAdjunto As String = "Adjuntos"
        Public Const TablaContratoSegmento As String = "Segmentos"
        Public Const TablaContratoSegmentoMOD As String = "SegmentosMOD"
        Public Const TablaProgramacionAnual As String = "ProgAnual"
        Public Const TablaProgramacionMensual As String = "ProgMensual"
        Public Const TablaContratoEstructura As String = "Estructuras"
        Public Const TablaAvancesComponentes As String = "Componentes"
        Public Const TablaAvancesDefinitivos As String = "Definitivos"
        Public Const TablaAvancesModificaciones As String = "Modificaciones"
        Public Const TablaAvancesDeducciones As String = "Deducciones"
        Public Const TablaAvancesBienes As String = "Bienes"
        Public Const TablaAvancesSobrecostosMod As String = "SobrecostosMod"
        Public Const TablaCesion As String = "CesionContrato"
        Public Const TablaEstructurasPPR As String = "CO_PARTIDA_PPR"
        Public Const TipoFaseProgramacionIndicativa As String = "INDI"
        Public Const TipoFaseProgramacion As String = "PRG"
        Public Const TipoFaseReProgramacion As String = "REPR"
        Public Const TablaProgramacion As String = "Prog"
        Public Const DocRespaldoFactura As Integer = 5
        Public Const DocRespaldoRecibo As Integer = 6
        Public Const DocRespaldoSecuenciaLicitacion As Integer = 1
        Public Const DocRespaldoSecuenciaCotizacion As Integer = 2
        Public Const DocRespaldoSecuenciaCompraDirecta As Integer = 4
        Public Const DocRespaldoSecuenciaCompraExterior As Integer = 10
        Public Const DocRespaldoSecuenciaReciboAutorizado As Integer = 9
        Public Const CO_TIPO_DOCUMENTO_ADJ_RESP_ANTICIPO As Integer = 6

        '[CBARRERA] - 12-12-2008 - Agregando constantes para contratos
        '[CBARRERA] - 20-12-2008 - Agregando nuevas constantes para proceso de gestion
        '----------------------------------------------------------------
        'Gestiones de Contratos
        Public Const GestionTipoGestionCTR As String = "CTR"

        'TIpo de procesos de Contratos
        Public Const ProcesoRegistroCTR As String = "RECT" 'registro de contratos
        Public Const ProcesoCesionCED As String = "CED"
        Public Const ProcesoProgramaPRG As String = "PROG" 'Programacion de Contratos
        Public Const ProcesoAnticipoANT As String = "ANT"  'Anticipo de Contratos
        Public Const ProcesoModificaMOD As String = "MOD"  'Modificacion de datos generales 
        Public Const ProcesoModificaCORR As String = "CORR"  'Correccion de datos generales 
        Public Const ProcesoModfAltMOAL As String = "MOAL" 'Modificacion de Plazos, etc (Alteracion)
        Public Const ProcesoEjecutaAV As String = "EJAV"   'Ejecucion de Avances
        Public Const ProcesoEjecutaPago As String = "EJPA"   'Ejecucion de Avances
        Public Const ProcesoEjecutaRevPago As String = "RTPA" 'Reversión de pagos aprobados
        Public Const ProcesoRecepcionRECE As String = "RECE" 'Recepción de obra
        Public Const ProcesoLiquidacionLIQU As String = "LIQU" 'Liquidación de Contratos
        Public Const ProcesoRescisionRSCI As String = "RSCI" 'Rescisión de Contratos
        Public Const ProcesoNCAP As String = "NCAP" 'Gastos no Capitalizables

        'Etapas - contratos
        Public Const EtapaRegistrarCTR As String = "REGISTRA CTR"    'Etapa de Registro del Contrato
        Public Const EtapaProgramarPRG As String = "PROGRAMA CTR"    'Etapa de Programacion del Contrato
        Public Const EtapaAnticipoANT As String = "ANTICIPO CTR"     'Etapa de Anticipo del contrato
        Public Const EtapaModificaMOD As String = "MODIFICA CTR"     'Etapa de Modificacion de datos generales
        Public Const EtapaModificaMOAL As String = "MODIFICA CAL"    'Etapa de Modificacion de plazos, etc (alteracion)
        Public Const EtapaEjecucionAV As String = "EJECUTA AV"
        Public Const EtapaRegistraRECE As String = "REGISTRA RECE"   'Etapa de Registro de Recepción de la obra
        Public Const EtapaRegistraLIQU As String = "REGISTRA LIQU"   'Etapa de Registro de liquidación
        Public Const EtapaRegistraRSCI As String = "REGISTRA RSCI"   'Etapa de Registro de rescisión
        Public Const EtapaRegistraNCAP As String = "REG_GNOCAP"      'Gastos no Capitalizables


        'Acciones -  Contratos
        'acciones de la etapa REGISTRA CTR
        '-----------------------------------------------------------
        Public Const Accion_NuevoCTR As String = "NUEVO CTR"
        Public Const Accion_ModificaCTR As String = "MODIFICAR CTR"
        Public Const Accion_ActivaCTR As String = "ACTIVAR CTR"
        Public Const Accion_ProgCeroCTR As String = "PROG CERO"
        Public Const Accion_CrearCesion As String = "CREAR CESION"
        Public Const Accion_AutorizarCesion As String = "AUTORIZA CESION"
        Public Const Accion_GenerarCesion As String = "GENERAR CESION"
        Public Const Accion_AprobarCesion As String = "ACTIVA CESION"
        '-----------------------------------------------------------

        'acciones de la etapa PROGRAMA PRG
        '-----------------------------------------------------------
        Public Const Accion_NuevoPRG As String = "NUEVO PRG"
        Public Const Accion_AutorizarPRG As String = "AUTORIZAR PRG"
        Public Const Accion_AsignarEstructPRG As String = "ASIGNA EST"
        Public Const Accion_DistribuirPRG As String = "DISTRIBUIR PRG"
        Public Const Accion_AprobarPRG As String = "APRUEBA PRG"
        '-----------------------------------------------------------

        'Acciones de la etapa ANTICIPO CTR
        '-----------------------------------------------------------
        Public Const Accion_RegistrarANT As String = "REGISTRAR ANT"
        Public Const Accion_ModificarANT As String = "MODIFICAR ANT"
        Public Const Accion_SolicitarANT As String = "SOLICITAR ANT"
        Public Const Accion_DistribuirANT As String = "DISTRIBUIR ANT"
        Public Const Accion_AprobarANT As String = "APROBAR ANT"
        Public Const Accion_ErrarANT As String = "ERRAR ANT"
        Public Const Accion_ErrarANTDIST As String = "ERRAR DIST"
        '-----------------------------------------------------------

        'Acciones de la etapa MODIFICA CTR
        '-----------------------------------------------------------
        Public Const Accion_NuevaMOD As String = "NUEVA MOD"
        Public Const Accion_ModificaMOD As String = "MODIFICA MOD"
        Public Const Accion_AutorizaMOD As String = "AUTORIZA MOD"
        Public Const Accion_RechazaMOD As String = "RECHAZA MOD"

        Public Const Accion_NuevaCORR As String = "NUEVA CORR"
        Public Const Accion_ModificaCORR As String = "MODIFICA CORR"
        Public Const Accion_AutorizaCORR As String = "AUTORIZA CORR"
        Public Const Accion_RechazaCORR As String = "RECHAZA CORR"
        '-----------------------------------------------------------

        'Acciones de la etapa MODIFICA CALT
        '-----------------------------------------------------------
        Public Const Accion_NuevaMOAL As String = "NUEVA MOAL"
        Public Const Accion_AutorizaMOAL As String = "AUTORIZA MOAL"
        Public Const Accion_AsignaMOAL As String = "ASIGNA MOAL"
        Public Const Accion_DistribuirMOAL As String = "DISTRIBUIR MOAL"
        Public Const Accion_ApruebaMOAL As String = "APRUEBA MOAL"
        Public Const Accion_RechazaMOAL As String = "RECHAZA MOAL"
        '-----------------------------------------------------------

        'Acciones de la etapa EJECUTA AV
        '------------------------------------------------------------
        Public Const Accion_NuevaAV As String = "NUEVO AV"
        Public Const Accion_AutorizaAV As String = "AUTORIZAR AV"
        Public Const Accion_AsignaAV As String = "ASIGNA EST"
        Public Const Accion_DistribuirAV As String = "DISTRIBUIR AV"
        Public Const Accion_ApruebaAV As String = "APRUEBA AV"
        Public Const Accion_RechazaAV As String = "RECHAZA AV"
        '------------------------------------------------------------

        'Acciones de la etapa EJECUTA PAG
        '------------------------------------------------------------
        Public Const Accion_NuevaPAG As String = "NUEVO PAG"
        Public Const Accion_AutorizaPAG As String = "AUTORIZA PAG"
        Public Const Accion_DistribuirPAG As String = "DISTRIBUIR PAG"
        Public Const Accion_ApruebaPAG As String = "APRUEBA PAG"
        Public Const Accion_RechazaPAG As String = "RECHAZA PAG"
        '------------------------------------------------------------

        'Acciones de la etapa REVIERTE PAG
        '------------------------------------------------------------
        Public Const Accion_NuevaRevPAG As String = "NUEVA REV"
        Public Const Accion_AutorizaRevPAG As String = "AUTORIZA REV"
        Public Const Accion_ApruebaRevPAG As String = "APRUEBA REV"
        '------------------------------------------------------------

        'Acciones de la etapa REGISTRA RECE
        '------------------------------------------------------------
        Public Const Accion_NuevaRECE As String = "NUEVO RECE"
        Public Const Accion_ModificarRECE As String = "MODIFICAR RECE"
        Public Const Accion_AprobarRECE As String = "APROBAR RECE"
        Public Const Accion_ErrarRECE As String = "ERRAR RECE"
        '------------------------------------------------------------

        'Acciones de la etapa REGISTRA LIQU
        '------------------------------------------------------------
        Public Const Accion_NuevaLIQU As String = "NUEVO LIQU"
        Public Const Accion_ModificarLIQU As String = "MODIFICAR LIQU"
        Public Const Accion_AprobarLIQU As String = "APROBAR LIQU"
        Public Const Accion_ErrarLIQU As String = "ERRAR LIQU"
        '------------------------------------------------------------

        'Acciones de la etapa REGISTRA RECE
        '------------------------------------------------------------
        Public Const Accion_NuevaRSCI As String = "NUEVO RSCI"
        Public Const Accion_ModificarRSCI As String = "MODIFICAR RSCI"
        Public Const Accion_AprobarRSCI As String = "APROBAR RSCI"
        Public Const Accion_ErrarRSCI As String = "ERRAR RSCI"
        '------------------------------------------------------------

        'Acciones de la etapa REGISTRA GASTOS NO CAPITALIZABLES
        '------------------------------------------------------------
        Public Const Accion_NuevaNCAP As String = "NUEVO GAST"
        Public Const Accion_ModificarNCAP As String = "MODIFICAR GAST"
        Public Const Accion_AprobarNCAP As String = "AUTORIZAR GAST"
        Public Const Accion_ErrarNCAP As String = "ERRAR GAST"
        '------------------------------------------------------------

        'Constantes para Tipo de Documento Respaldo Contratos
        'AEscobar
        Public Class TIPOS_DOCUMENTO
            Public Const Acuerdos As Integer = 1
            Public Const Resoluciones As Integer = 2
            Public Const ComprobanteFiscal As Integer = 5
            Public Const ComprobanteAdmin As Integer = 6
        End Class
        'Constantes para Secuencia del Documento Respaldo Contratos
        'AEscobar
        Public Class SECUENCIA
            Public Const AcuerdoMin As Integer = 1
            Public Const OrdenCompra As Integer = 2
            Public Const Resolucion As Integer = 3
            Public Const ContratoObra As Integer = 3
            Public Const ContratoServicio As Integer = 4
            Public Const ProgramacionA As Integer = 26
            Public Const ReciboCaja As Integer = 27
            Public Const FacturaLic As Integer = 1
            Public Const FacturaCot As Integer = 2
            Public Const Dictamen As Integer = 11
            Public Const ConvenioOrgDelegado As Integer = 28
            Public Const ActaRecepcionObra As Integer = 31
            Public Const ActaLiquidacionObra As Integer = 32
        End Class

        ' Public Class TIPOS_DOC_RESPALDO
        'Public Const A As Integer = 4
        'End Class

        Public Class TIPOS_DE_CONTRATO
            Public Const ORIGINAL As Integer = 1
            Public Const AMPLIATORIO As Integer = 2
            Public Const CESION As Integer = 3
            Public Const POR_EXCEPCION As Integer = 4
            Public Const POR_EXCEPCION_ART44 As Integer = 5  'Artículo 44
            Public Const POR_EXCEPCION_ART105 As Integer = 6 'Artículo 105
            Public Const POR_EXCEPCION_ORGDEL As Integer = 7 'Organismos Delegados
        End Class

        Public Class ModalidadContratacion
            Public Const CompraDirecta As Integer = 1
            Public Const Cotizacion As Integer = 2
            Public Const Licitacion As Integer = 3
            Public Const ContratoAbierto As Integer = 4
            Public Const ExcepcionOtros As Integer = 5
        End Class

        Public Class CO_TIPO_MODIFICACION
            Public Const OC As Integer = 5
            Public Const ATE As Integer = 6
            Public Const OTS As Integer = 7
            Public Const SOBRECOSTO As Integer = 9
            Public Const MODCERO As Integer = 8
            Public Const AMPLIATORIA As Integer = 10
            Public Const DIFERENCIAL_CAMBIARIO As Integer = 13
        End Class

        Public Class CO_MODALIDADES_EJECUCION
            Public Const EJE_DIR As Integer = 1
            Public Const FIDEICOMISO As Integer = 2
            Public Const CONVENIO As Integer = 3
            Public Const PRESTAMO As Integer = 4
            Public Const DONACION As Integer = 5
            Public Const MIXTA As Integer = 6
        End Class

        Public Class CO_MODALIDAD_PAGO
            Public Const PagoDirectoNacional As Integer = 1
            Public Const PagoDirectoExteriorSubCta4 As Integer = 2
            Public Const PagoRegularizadoExteriorSubCta2 As Integer = 3
            Public Const PagoDirectoExteriorSubCta5 As Integer = 4
            Public Const PagoRegularizadoExteriorSubCta3 As Integer = 5
        End Class

        Public Class MetodosCompra
            Public Const MetodoCompraDirecta As Decimal = 1
            Public Const MetodoCompraExcepcion As Decimal = 5
        End Class

        Public Class TIPO_FECHA_INICIO_PLAZO
            Public Const NOTIFICACION As Decimal = 1
            Public Const PAGO_ANTICIPO As Decimal = 2
            Public Const OTRA As Decimal = 3
        End Class

        Public Class MODALIDADES_EJECUCION_MIXTA
            Public Const FIDEICOMISO As Integer = 1
            Public Const COVENIO As Integer = 2
            Public Const DONACION As Integer = 3
        End Class
    End Class

    Public Class clsConstantesNomina
        Public Class clsDescuentosExternos
            Public Const C_ERRPuestoNoExiste As Integer = 1
            Public Const C_ERRPuestoVacante As Integer = 2
            Public Const C_ERREmpleadoNoExiste As Integer = 3
            Public Const C_ERRDocIdDiferente As Integer = 4
            Public Const C_ERRDescNoAsignado As Integer = 5
            Public Const C_ERRMontoMayor0 As Integer = 6
            Public Const C_ERRNoExisteTransExt As Integer = 7
            Public Const C_ERREmpleadoInactivo As Integer = 8
            Public Const C_ERRPuestoInactivo As Integer = 9
            Public Const C_ERREmpleadoOtroPuesto As Integer = 10
            Public Const C_ERRDescuentoDuplicado As Integer = 11
            Public Const C_ERRMesIncorrecto As Integer = 12
            Public Const C_ERRAnioIncorrecto As Integer = 13
            Public Const C_ERREmpleadoSinPago As Integer = 14
            Public Const C_ERRSobregiro As Integer = 15
        End Class
        Public Class clsTablas
            Public Const Cabecera As String = "CABECERA"
            Public Const Controles As String = "CONTROLES"
            Public Const UnidadCompradora As String = "UNIDAD_COMPRADORA"
            Public Const Estructuras As String = "ESTRUCTURAS"
            Public Const BonoAsignacion As String = "NNM_BONO_ASIGNACION"
            Public Const BonoDetalle As String = "BONO_DETALLE"
            Public Const DescuentoAsignacion As String = "DESCUENTO_ASIGNACION"
            Public Const DescuentoEntidad As String = "DESCUENTO_ENTIDAD"
            Public Const DescuentoDetalle As String = "DESCUENTO_DETALLE"
            Public Const DescuentoTipoNomina As String = "DESCUENTO_TIPO_NOMINA"
            Public Const BonoTipoNomina As String = "BONO_TIPO_NOMINA"
            Public Const BonoEntidad As String = "BONO_ENTIDAD"
            Public Const BonoDependencia As String = "BONO_DEPENDENCIA"
            Public Const Puestos As String = "PUESTOS"
            Public Const Partidas As String = "PARTIDAS"
            Public Const Politicas As String = "POLITICA"
            Public Const EntidadSecretaria As Decimal = 11130016
            Public Const EntidadVicePresidencia As Decimal = 11130003
            Public Const Acuerdo As String = "NRH_ACUERDO"
        End Class

        Public Class clsEstados
            Public Const DISTRIBUIDO As String = "DISTRIBUIDO"
            Public Const CARGADO As String = "CARGADO"
            Public Const APERTURADO As String = "APERTURADO"
            Public Const AUTORIZADO As String = "AUTORIZADO"

        End Class

        'Public Class clsGestionBonos

        '    'Gestiones de Contratos
        '    Public Const GestionTipoGestionBON As String = "BON"

        '    'TIpo de procesos de BONOS
        '    Public Const ProcesoRegistroREBO As String = "REBO"
        '    Public Const ProcesoModificaMOBO As String = "MOBO"


        '    'Etapas - BONOS
        '    Public Const EtapaRegistrarBON As String = "REGISTRA BON"    'Etapa de Registro del Bonos
        '    Public Const EtapaModificarBON As String = "MODIFICA BON"    'Etapa de Modificacion de Bonos


        '    'Acciones -  BONOS
        '    '-----------------------------------------------------------
        '    Public Const Accion_NuevoREBO As String = "NUEVO REBO"
        '    Public Const Accion_AutorizarREBO As String = "AUTORIZAR REBO"
        '    Public Const Accion_ModificarREBO As String = "MODIFICAR REBO"
        '    Public Const Accion_RechazarREBO As String = "RECHAZAR REBO"
        '    '-----------------------------------------------------------

        '    '-----------------------------------------------------------
        '    Public Const Accion_NuevaMOBO As String = "NUEVA MOBO"
        '    Public Const Accion_AutorizaMOBO As String = "MODIFICA MOBO"
        '    Public Const Accion_ModificaMOBO As String = "AUTORIZA MOBO"
        '    Public Const Accion_RechazaMOBO As String = "RECHAZA MOBO"
        '    '-----------------------------------------------------------

        'End Class

        'Public Class clsGestionDescuentos

        '    'Gestiones de DESCUENTOS
        '    Public Const GestionTipoGestionDES As String = "DES"

        '    'TIpo de procesos de DESCUENTOS
        '    Public Const ProcesoRegistroREDE As String = "REDE"
        '    Public Const ProcesoModificaMODE As String = "MODE"


        '    'Etapas - DESCUENTOS
        '    Public Const EtapaRegistrarDES As String = "REGISTRA DES"    'Etapa de Registro del Descuentos
        '    Public Const EtapaModificarDES As String = "MODIFICA DES"    'Etapa de Modificacion de Descuentos 


        '    'Acciones -  DESCUENTOS
        '    '-----------------------------------------------------------
        '    Public Const Accion_NuevoREDE As String = "NUEVO REDE"
        '    Public Const Accion_AutorizarREDE As String = "AUTORIZAR REDE"
        '    Public Const Accion_ModificarREDE As String = "MODIFICAR REDE"
        '    Public Const Accion_RechazarREDE As String = "RECHAZAR REDE"
        '    '-----------------------------------------------------------

        '    '-----------------------------------------------------------
        '    Public Const Accion_NuevaMODE As String = "NUEVA MODE"
        '    Public Const Accion_AutorizaMODE As String = "AUTORIZA MODE"
        '    Public Const Accion_ModificaMODE As String = "MODIFICA MODE"
        '    Public Const Accion_RechazaMODE As String = "RECHAZA MODE"
        '    '-----------------------------------------------------------

        'End Class

        Public Class clsGestionNomina

            'Gestiones de NOMINA
            Public Const GestionTipoGestionNOM As String = "NOM"

            'TIpo de procesos de NOMINA
            Public Const ProcesoREBO As String = "REBO"
            Public Const ProcesoMOBO As String = "MOBO"
            Public Const ProcesoREDE As String = "REDE"
            Public Const ProcesoMODE As String = "MODE"
            Public Const ProcesoLIQ As String = "LIQ"
            Public Const ProcesoMAPR As String = "MAPR"
            Public Const ProcesoMPRE As String = "MPRE"
            Public Const ProcesoAC21 As String = "AC21"



            'Etapas - NOMINA
            Public Const EtapaRegistrarBONO As String = "REGISTRA BONO"    'Etapa de Registro del Bonos
            Public Const EtapaModificarBONO As String = "MODIFICA BONO"    'Etapa de Modificacion de Bonos
            Public Const EtapaRegistrarDESC As String = "REGISTRA DESC"    'Etapa de Registro del Descuentos
            Public Const EtapaModificarDESC As String = "MODIFICA DESC"    'Etapa de Modificacion de Descuentos 
            Public Const EtapaEjecutarLIQ As String = "EJEC LIQ"    'Liquidacion de Nomina
            Public Const EtapaRegistraMov As String = "REGISTRA MOV"    'se ingresa el movimiento
            Public Const EtapaRegistraMova As String = "REGISTRA MOV A"    'Se ingresa el movimiento ya autorizado


            'Acciones -  NOMINA
            '-----------------------------------------------------------
            Public Const Accion_NuevoREBO As String = "NUEVO REBO"
            Public Const Accion_AutorizarREBO As String = "AUTORIZAR REBO"
            Public Const Accion_ModificarREBO As String = "MODIFICAR REBO"
            Public Const Accion_RechazarREBO As String = "RECHAZAR REBO"
            '-----------------------------------------------------------

            '-----------------------------------------------------------
            Public Const Accion_NuevaMOBO As String = "NUEVA MOBO"
            Public Const Accion_AutorizaMOBO As String = "AUTORIZA MOBO"
            Public Const Accion_ModificaMOBO As String = "MODIFICA MOBO"
            Public Const Accion_RechazaMOBO As String = "RECHAZA MOBO"
            '-----------------------------------------------------------

            '-----------------------------------------------------------
            Public Const Accion_NuevoREDE As String = "NUEVO REDE"
            Public Const Accion_AutorizarREDE As String = "AUTORIZAR REDE"
            Public Const Accion_ModificarREDE As String = "MODIFICAR REDE"
            Public Const Accion_RechazarREDE As String = "RECHAZAR REDE"
            '-----------------------------------------------------------

            '-----------------------------------------------------------
            Public Const Accion_NuevaMODE As String = "NUEVA MODE"
            Public Const Accion_AutorizaMODE As String = "AUTORIZA MODE"
            Public Const Accion_ModificaMODE As String = "MODIFICA MODE"
            Public Const Accion_RechazaMODE As String = "RECHAZA MODE"
            '-----------------------------------------------------------

            '-----------------------------------------------------------
            Public Const Accion_NuevaLIQ As String = "NUEVA LIQ"
            Public Const Accion_ModificaLIQ As String = "MODIFICAR LIQ"
            Public Const Accion_AperturaLIQ As String = "APERTURAR LIQ"
            Public Const Accion_GeneraLIQ As String = "GENERAR LIQ"
            Public Const Accion_REGeneraLIQ As String = "REGENERAR LIQ"
            Public Const Accion_AutorizarLIQ As String = "AUTORIZAR LIQ"
            Public Const Accion_GenCurLIQ As String = "GEN CUR LIQ"
            Public Const Accion_EnviaLIQ As String = "ENVIAR LIQ"
            Public Const Accion_ApruebaCurLIQ As String = "APROB CUR LIQ"
            Public Const Accion_GenArchivoLIQ As String = "GEN ARCH LIQ"

            Public Const Accion_DesAperturar As String = "DES APERTURAR"
            Public Const Accion_DesGenerar As String = "DES GENERAR"
            Public Const Accion_DesAutorizar As String = "DES AUTORIZAR"
            Public Const Accion_EliminarCur As String = "ELIMINAR CUR"

            '-----------------------------------------------------------


            '-----------------------------------------------------------
            Public Const Accion_RevertirMOV As String = "REVERTIR MOV"
            Public Const Accion_NuevoMOV As String = "NUEVO MOV"
            Public Const Accion_NuevoMOVCTR As String = "NUEVO MOV CTR"
            Public Const Accion_ModificarMOV As String = "MODIFICAR MOV"
            Public Const Accion_ErrarMOV As String = "ERRAR MOV"
            Public Const Accion_RechazaMOV As String = "RECHAZAR MOV"
            Public Const Accion_LiquidarMOV As String = "LIQUIDAR MOV"
            Public Const Accion_FinalizarMOV As String = "FINALIZAR MOV"
            Public Const Accion_AutorizarMOV As String = "AUTORIZAR MOV"
            '-----------------------------------------------------------

            '-----------------------------------------------------------
            Public Const Accion_RevertirMOVA As String = "REVERTIR MOV"
            Public Const Accion_NuevoMOVA As String = "NUEVO MOV"
            Public Const Accion_ModificarMOVA As String = "MODIFICAR MOV"
            Public Const Accion_LiquidarMOVA As String = "LIQUIDAR MOV"
            Public Const Accion_FinalizarMOVA As String = "FINALIZAR MOV"
            '-----------------------------------------------------------

            '-----------------------------------------------------------

            Public Const Accion_NuevoACDO As String = "NUEVO ACDO"
            Public Const Accion_ModificarACDO As String = "MODIFICAR ACDO"
            Public Const Accion_AutorizarACDO As String = "AUTORIZAR ACDO"
            Public Const Accion_FinalizarACDO As String = "FINALIZAR ACDO"
            Public Const Accion_ErrarACDO As String = "ERRAR ACDO"
            Public Const Accion_DesAutorizarACDO As String = "DESAUTO ACDO"
            '-----------------------------------------------------------
        End Class

        Public Class Acreditamiento
            Public Enum ESTADO_ARCHIVO As Integer
                Aprobado = 3
                Rechazado = 4
                Generado = 13
                Descargado = 14
                Confirmado_Banco = 17
                Cargado = 18
            End Enum
        End Class

    End Class

    Public Class clsConstantesReportes
        Public Const filasPreview As String = " and rownum < 25 "
    End Class

    Public Class clsConstantesCategoria
        Public Const OderdenDeCompra As Integer = 1
        Public Const Contrato As Integer = 2
        Public Const Nomina As Integer = 3
        Public Const Login As Integer = 4
        Public Const Otro As Integer = 99
    End Class

    Public Class clsConstantesSubCategoria
        Public Const TipoMantenimiento As Short = 1
        Public Const TipoAnteproyecto As Short = 2
        Public Const TipoProyecto As Short = 3
        Public Const TipoEjecucion As Short = 4
        Public Const ErroresNoControlados As Short = 4
        Public Const TipoOtro As Short = 99
    End Class

    Public Class clsConfiguracionNomina
        Public Const tablaConfiguracion As String = "ConfigNomina"
    End Class

    Public Class clsConstantesProyectos
        Public Class clsTablas
            Public Const Cabecera As String = "CABECERA"
            Public Const Controles As String = "CONTROLES"
            Public Const UnidadCompradora As String = "UNIDAD_COMPRADORA"
            Public Const Estructuras As String = "ESTRUCTURAS"
            Public Const Partidas As String = "PARTIDAS"
            Public Const Proyectos As String = "PROYECTOS"
            Public Const EntidadObligacionesDelEstado As Decimal = 11130018
        End Class

        Public Class clsEstados
            Public Const REGISTRADO As String = "REGISTRADO"
            Public Const ACTIVADO As String = "ACTIVADO"
            Public Const EN_REPROGRAMACION As String = "EN REPROGRAMACION"
            Public Const ASIGNADO As String = "ASIGNADO"
            Public Const AUTORIZADO As String = "AUTORIZADO"
            Public Const FINALIZADO As String = "FINALIZADO"
            Public Const RECHAZADO As String = "RECHAZADO"
            Public Const ENVIADO As String = "ENVIADO"
            Public Const APROBADO As String = "APROBADO"
            Public Const DISTRIBUIDO As String = "DISTRIBUIDO"

            Public Const EstadoREGISTRADO As String = "REGISTRADO"
            Public Const EstadoACTIVADO As String = "ACTIVADO"

            Public Const EstadoEN_REPROGRAMACION As String = "EN REPROGRAMACION"
            Public Const EstadoAUTORIZADO As String = "AUTORIZADO"
            Public Const Estado As String = "APROBADO"
            Public Const EstadoENVIADO_SINIP As String = "ENVIADO SINIP"
            Public Const EstadoFINALIZADO As String = "FINALIZADO"

            Public Const EstadoENVIADO_PRESUPUESTO As String = "ENVIADO PRESUPUESTO"
            Public Const EstadoAPROBADO_PRESUPUESTO As String = "APROBADO PRESUPUESTO"
            Public Const EstadoENVIADO_FISICO As String = "ENVIADO FISICO"
            Public Const EstadoAPROBADO_FISICO As String = "APROBADO FISICO"

            Public Const EstadoEN_EJECUCION As String = "EN EJECUCION"
        End Class

        Public Class clsGestion

            'Gestiones
            Public Const TipoGestionSNIP As String = "SNIP"

            'Tipo de procesos
            Public Const ProcesoMP As String = "MP" ' Modificación Presupuestaria
            Public Const ProcesoCA As String = "CA" ' Creación y Apertura
            Public Const ProcesoAP As String = "AP" ' Gestión de Aprobación de la Modificación

            'Etapas
            Public Const EtapaACT As String = "ACT"    'Etapa de activación de proyectos
            Public Const EtapaPR As String = "PR"    'Etapa de programación de proyectos
            Public Const EtapaENV As String = "ENV"    'Etapa de envío de modificación a SICOIN

            'Acciones
            '-----------------------------------------------------------
            Public Const AccionCREAR As String = "CREAR"
            Public Const AccionACTIVAR As String = "ACTIVAR"
            Public Const AccionDESACTIVAR As String = "DESACTIVAR"
            Public Const AccionINICIAR_MP As String = "INICIAR MP"
            Public Const AccionRECHAZAR_MP As String = "RECHAZAR MP"
            Public Const AccionAUTORIZAR As String = "AUTORIZAR"
            Public Const AccionDESAUTORIZAR As String = "DESAUTORIZAR"
            Public Const AccionFINALIZAR As String = "FINALIZAR"
            Public Const AccionRECHAZAR As String = "RECHAZAR"
            Public Const AccionCREAR_APR As String = "CREAR"
            Public Const AccionENVIAR As String = "ENVIAR"
            Public Const AccionREVERSAR As String = "REVERSAR"
            Public Const AccionAPROBAR As String = "APROBAR"
            Public Const AccionDISTRIBUIR As String = "DISTRIBUIR"
            '-----------------------------------------------------------

        End Class
    End Class

    Public Class clsConstantesFPR
        Public Const TipoGestion As String = "FPR"
        'Procesos
        Public Const TipoProcesoCONF As String = "CONF"
        Public Const TipoProcesoCC As String = "S_CC"
        Public Const TipoProcesoUE As String = "S_UE"
        Public Const TipoProcesoRecomendadoEntidad As String = "RENT"
        Public Const TipoProcesoAprobadoEntidad As String = "AENT"

        'Acciones
        Public Const AccionNUEVA_CONF As String = "NUEVA CONF"
        Public Const AccionMODIFICAR_CONF As String = "MODIFICAR CONF"
        Public Const AccionAUTORIZAR_CONF As String = "AUTORIZAR CONF"
        Public Const AccionERRAR_CONF As String = "ERRAR CONF"
        Public Const AccionDESAUTO_CONF As String = "DESAUTO CONF"
        Public Const AccionFINALIZAR_CONF As String = "FINALIZAR CONF"
        Public Const AccionDESFIN_CONF As String = "DESFIN CONF"
        Public Const AccionAPERTURAR_ENT As String = "APERTURAR ENT"
        Public Const AccionDESAPERTURAR_ENT As String = "DESAPERT ENT"
        Public Const AccionFINALIZAR_ENT As String = "FINALIZAR ENT"
        Public Const AccionDESFIN_ENT As String = "DESFIN ENT"


        'Acciones Politica CC
        Public Const AccionNUEVA_CC As String = "NUEVA CC"
        Public Const AccionPROGRAMAR_CC As String = "PROGRAMAR CC"
        Public Const AccionDESPROGRAMAR_CC As String = "DES_PROG CC"
        Public Const AccionCONSOLIDAR_CC As String = "CONSOLIDAR CC"
        Public Const AccionDESCONSOLIDAR_CC As String = "DES_CONS CC"
        Public Const AccionAUTORIZAR_CC As String = "AUTORIZAR"
        Public Const AccionDES_AUTORIZAR As String = "DES_AUTORIZAR"
        Public Const AccionFINALIZAR_CC As String = "FINALIZAR CC"
        Public Const AccionELIMINAR_CC As String = "ELIMINAR_CC"

        'Acciones Politica UE
        Public Const AccionNUEVA_UE As String = "NUEVA UE"
        Public Const AccionAUTORIZAR_UE As String = "AUTORIZAR UE"
        Public Const AccionDESAUTORIZAR_UE As String = "DESAUTORIZAR UE"
        Public Const AccionFINALIZAR_UE As String = "FINALIZAR UE"

        Public Const RenglonesNomina As String = "21,29,31"

        'Tablas
        Public Class clsTablas
            Public Const CentroCosto As String = "OC_UNIDAD_COMPRADORA"
            Public Const SubProducto As String = "FPR_PRODUCTO"
            Public Const SubProductoCategoria As String = "FPR_PRODUCTO_CATEGORIA"
            Public Const SubProductoCC As String = "FPR_CC_PRODUCTO"
            Public Const InsumoCat As String = "FPR_INSUMO_CATEGORIA"
            Public Const SubProductoEstructura As String = "FPR_PRODUCTO_ESTRUCTURA"
            Public Const CCExcepcion As String = "FPR_CC_EXCEPCION"
            Public Const SubProductoCCReceta As String = "FPR_CC_DET_RECETA"
            Public Const Entidad As String = "ENTIDAD"
            Public Const Politica As String = "FPR_POLITICA"
        End Class
        'Estados Productos
        Public Class estadoProductos
            Public Const REGISTRADO As String = "REGISTRADO"
            Public Const ACTIVADO As String = "ACTIVADO"
            Public Const ELIMINADO As String = "ELIMINADO"
        End Class
    End Class

    Public Class clsConstantesEPR
        Public Const TipoGestion As String = "EPR"
        'Procesos
        Public Const TipoProcesoEJE As String = "EJE"

        Public Const TipoProcesoPROG As String = "PROG"
        Public Const TipoProcesoPMET As String = "PMET"
        Public Const TipoProcesoEMET As String = "EMET"

        Public Const TipoProcesoC_UE As String = "C_UE"
        Public Const TipoProcesoC_UD As String = "C_UD"
        Public Const TipoProcesoCMET As String = "CMET"

        'Acciones
        Public Const AccionAPERTURAR_ENT As String = "APERTURAR ENT"

        Public Const AccionCrear As String = "CREAR"
        Public Const AccionModificar As String = "MODIFICAR"
        Public Const AccionSOLICITAR As String = "SOLICITAR"
        Public Const AccionERRAR As String = "ERRAR"
        Public Const AccionREV_SOLICITART As String = "REV_SOLICITAR"
        Public Const AccionRECHAZAR As String = "RECHAZAR"
        Public Const AccionAPROBAR As String = "APROBAR"
        Public Const AccionENVIAR As String = "ENVIAR"
    End Class

    Public Class clsConstantesFID
        Public Const TipoGestion As String = "FID"
        'Procesos
        Public Const TipoProcesoFGAS As String = "FGAS"
        Public Const TipoProcesoFANT As String = "FANT"
        Public Const TipoProcesoFEST As String = "FEST"
        Public Const TipoProcesoFPRE As String = "FPRE"
        Public Const TipoProcesoFACT As String = "FACT"
        Public Const TipoProcesoFAMO As String = "FAMO"
        Public Const TipoProcesoFINT As String = "FINT"
        Public Const TipoProcesoFCAR As String = "FCAR"


        'Acciones
        Public Const AccionCrear As String = "CREAR"
        Public Const AccionModificar As String = "MODIFICAR"
        Public Const AccionERRAR As String = "ERRAR"
        Public Const AccionAPROBAR As String = "APROBAR"

    End Class

    Namespace ConstantesBS
        Public Class Tablas
            Public Const Gestion As String = clsConstantes.TablaGestion
            Public Const Segmento As String = "BS_SEGMENTO"
            Public Const Familia As String = "BS_FAMILIA"
            Public Const Clase As String = "BS_CLASE"
            Public Const Articulo As String = "BS_ARTICULO"
            Public Const Combinacion As String = "BS_COMBINACION"
            Public Const CombinacionDominio As String = "BS_COMBINACION_DOMINIO"
            Public Const CombinacionImagen As String = "BS_COMB_IMG"
            Public Const Presentacion As String = "BS_PRESENTACION"
            Public Const Dimension As String = "BS_DIMENSION"
            Public Const Dominio As String = "BS_DOMINIO"
            Public Const Solicitud As String = "BS_SOLICITUD"
            Public Const SolicitudCar As String = "BS_SOLICITUD_CARACTERISTICAS"
            Public Const SolicitudAdj As String = "BS_SOLICITUD_ADJUNTO"
            Public Const SolicitudPres As String = "BS_SOLICITUD_PRESENTACION"
            Public Const Renglon As String = "CP_OBJETOS_GASTO"
            Public Const UnidadMedida As String = "BS_UNIDAD_MEDIDA"
            Public Const SolicitudImagen As String = "BS_SOL_IMG"

            Public Const ArticuloDominio As String = "BS_ARTICULO_DOMINIO"
            Public Const CombinacionReferencia As String = "BS_COMBINACION_REFENCIA"
        End Class

        Public Class Librerias
            Public Const Gestion As String = "blGestion"
            Public Const Insumos As String = "blBienesServicios"
        End Class

        Public Class Instancias
            Public Const Controladora As String = "SIGES.BienesServicios.bl.clsControladoraConfiguracion"
            Public Const Ticket As String = "SIGES.BienesServicios.bl.clsTicket"
            Public Const Gestion As String = "SIGES.Gestion.clsControladoraGestion"
        End Class

        Public Class Metodos
            Public Const ProcesarGestion As String = "procesaGestion"
            Public Const CrearDominio As String = "CrearDominio"
            Public Const AsignarMasivo As String = "AsignarMasivo"
        End Class

        Public Class TipoGestion
            Public Const Insumos As String = "BS"
        End Class

        Public Class TipoProceso
            Public Const SolicitudInsumos As String = "TSI"
        End Class

        Public Class TipoEtapa
            Public Const Registro As String = "REG"
        End Class

        Public Class Accion
            Public Const FinalizarTicket As String = "FINALIZAR"
            Public Const AsignarTicket As String = "ASIGNAR"
        End Class
    End Namespace
End Namespace
