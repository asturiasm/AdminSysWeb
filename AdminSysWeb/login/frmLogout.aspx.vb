Namespace SIGESWeb

    Partial Class frmLogout
        Inherits System.Web.UI.Page

#Region " Código generado por el Diseñador de Web Forms "

        'El Diseñador de Web Forms requiere esta llamada.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub

        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: el Diseñador de Web Forms requiere esta llamada de método
            'No lo modifique con el editor de código.
            InitializeComponent()
        End Sub

#End Region

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            If Not IsPostBack Then
                If Not IsNothing(Session("Usuario")) Then
                    Dim wsServicio As clsSIGESProxyWrapper = SIGESWeb.clsInstanciaAplicacion.InstanciaWSGenerico(Me.Context)
                    wsServicio.LogOff(Session("Usuario"))
                    Session("FechaHoraIngreso") = Nothing
                    Session("Usuario") = Nothing
                    Session.Abandon()
                End If
            End If
        End Sub

        Private Sub Linkbutton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Linkbutton2.Click
            Response.Redirect("frmLogin.aspx")
        End Sub
    End Class
End Namespace
