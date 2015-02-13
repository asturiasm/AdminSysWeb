Imports Microsoft.VisualBasic
Imports Telerik.Web.UI
Imports System.Web
Imports System.Web.Caching
Imports System.Threading

Namespace SIGESWeb.PaginasBase
    ''' <summary>
    ''' Reemplazo de pagina base que hereda de la clase de página base diseñada para interactuar con la capa de datos a través de POCOs y con uso mínimo de variables de sesión
    ''' </summary>
    ''' <remarks></remarks>
    Public MustInherit Class clsPaginaBasePC
        Inherits clsPaginaBase
        Dim webenv As HttpApplication
    End Class
End Namespace