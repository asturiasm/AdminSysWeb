Namespace SIGESWeb

Partial Class frmMensajeExito
        Inherits PaginaBase

#Region " C�digo generado por el Dise�ador de Web Forms "

    'El Dise�ador de Web Forms requiere esta llamada.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: el Dise�ador de Web Forms requiere esta llamada de m�todo
        'No lo modifique con el editor de c�digo.
        InitializeComponent()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Introducir aqu� el c�digo de usuario para inicializar la p�gina
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
