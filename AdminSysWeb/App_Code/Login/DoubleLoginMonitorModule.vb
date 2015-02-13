Imports System.Collections.Generic
Imports System.Web
Imports System.Web.UI

Namespace DisableDoubleLogin
    Public Class DoubleLoginMonitorModule
        Implements IHttpModule

        Public ReadOnly Property ModuleName() As [String]
            Get
                Return "DoubleLoginMonitorModule"
            End Get
        End Property

        Public Sub Init(ByVal application As HttpApplication) Implements IHttpModule.Init
            AddHandler application.PreRequestHandlerExecute, New EventHandler(AddressOf Application_PreRequestHandlerExecute)

        End Sub

        Private Sub Application_PreRequestHandlerExecute(ByVal source As [Object], ByVal e As EventArgs)
            Dim application As HttpApplication = DirectCast(source, HttpApplication)
            Dim context As HttpContext = application.Context
            Dim sPath As String = System.Web.HttpContext.Current.Request.Url.AbsolutePath
            Dim oInfo As New System.IO.FileInfo(sPath)
            Dim sRet As String = oInfo.Name
            ' if double login, kick it out
            'main.aspx
            If LoginState.IsDoubleLogin(Not (sRet.ToLower.Equals("frmlogout.aspx") OrElse _
                                             sRet.ToLower.Equals("frmlogin.aspx") OrElse _
                                             sRet.ToLower.Equals("dummycla.aspx") OrElse _
                                             sRet.ToLower.Equals("main2010.aspx"))) Then
                HttpContext.Current.Response.Write("<script>" & vbCrLf)
                HttpContext.Current.Response.Write("alert('El usuario inicio una sesion en otra ubicación');")
                HttpContext.Current.Response.Write("window.open('../login/frmlogout.aspx', '_top');")
                HttpContext.Current.Response.Write(vbCrLf & "</script>")
                HttpContext.Current.Response.End()
                HttpContext.Current.Server.Transfer("../login/frmlogout.aspx", False)
            End If
        End Sub

        Private Sub Page_PreInit(ByVal sender As Object, ByVal e As EventArgs)

        End Sub

        Public Sub Dispose() Implements IHttpModule.Dispose
        End Sub
    End Class
End Namespace