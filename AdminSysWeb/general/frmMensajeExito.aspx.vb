Namespace SIGESWeb

Partial Class frmMensajeExito
        Inherits PaginaBase

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
        'Introducir aquí el código de usuario para inicializar la página
            LblMensaje.Text = Session("MensajeError")
            MyBase.showInfo("Aviso", "<b>" + Session("MensajeError") + "</b>", True, False)
            Session("MensajeError") = Nothing
        End Sub

        Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles salir.Click
            Session("GO_TO_PAGINA_ACTUAL_" & Session("OBJETO")) = True
            Response.Redirect("../" & Session("FORMA_ACTUAL"))
        End Sub
End Class

End Namespace
