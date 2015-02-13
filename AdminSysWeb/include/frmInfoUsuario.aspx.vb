
Namespace SIGESWeb
    Partial Class frmInfoUsuario
        Inherits System.Web.UI.Page
        Dim ws As clsSIGESProxyWrapper

        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            ws = SIGESWeb.clsInstanciaAplicacion.InstanciaWSGenerico(Me.Context)
        End Sub

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Put user code to initialize the page here
            If Not IsPostBack Then
                InformacionUsuario()
            End If
        End Sub


        Private Sub InformacionUsuario()
            Dim dstemporal As DataSet
            Dim strSQL As String
            Dim strusuario As String

            strusuario = Request.QueryString("USR")


            strSQL = "SELECT NOMBRE, PUESTO " & _
                     "FROM AD_USUARIOS " & _
                     "WHERE UPPER(USUARIO) ='" & UCase(strusuario.Trim()) & "'"

            dstemporal = ws.getDatabySQL(strSQL, True, "<p></p>", Nothing)

            If Not IsNothing(dstemporal) AndAlso _
                   dstemporal.Tables.Count = 1 AndAlso _
                   dstemporal.Tables(0).Rows.Count = 1 Then

                Try
                    LBLRegistro.Text = dstemporal.Tables(0).Rows(0).Item("NOMBRE")
                    LBLAnotacion.Text = dstemporal.Tables(0).Rows(0).Item("PUESTO")
                Catch ex As Exception
                    LBLRegistro.Text = "ERROR AL ASIGNAR LOS DATOS DEL USUARIO..."
                    LBLAnotacion.Text = Val(ex)

                End Try
            Else
                LBLRegistro.Text = "EL USUARIO NO EXISTE EN SIGES"
                LBLAnotacion.Text = ""

            End If
        End Sub
    End Class

End Namespace
