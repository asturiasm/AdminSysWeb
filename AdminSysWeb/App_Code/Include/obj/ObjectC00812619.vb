Imports Microsoft.VisualBasic
Namespace SIGESWeb
    Public Class ObjectC00812619
        Inherits ObjectManager



        Public Overrides Sub Page_Load(ByRef page As SIGESWeb.PaginaBase, ByVal sender As System.Object, ByVal e As System.EventArgs)

            If (Not page.IsPostBack()) Then

                Dim param As System.Xml.XmlDocument = page.Session("PARAMETROS")

                clsUtil.agregarParametroVAL(param, DateAdd(DateInterval.Year, 1, Now).ToString("yyyy"), "EJER_EJECUCION", "N")
                clsUtil.agregarParametroVAL(param, DateAdd(DateInterval.Year, 1, Now).ToString("yyyy"), "EJER_FORMULACION", "N")

                'CType(page.FindControlByID("LISTA_EJERCICIOS"), DropDownList).Text = DateAdd(DateInterval.Year, 1, Now).ToString("yyyy")


            End If
        End Sub

        Public Overrides Sub After_Page_Load(ByRef page As SIGESWeb.PaginaBase, ByVal sender As System.Object, ByVal e As System.EventArgs)
            ''Page load
            'If (Not page.IsPostBack()) Then
            '    Dim objEncrypt As clsEncrypt.Encryption = New clsEncrypt.Encryption(page.Session("key"))
            '    Dim url As String = "../" + "general/frmMantenimiento.aspx" + "?ST=Y&ID=" + objEncrypt.EncriptarSTR(Trim("00812622"))
            '    page.llamarScript("$(document).ready(function(){browserManager.open('" & url & "')});")
            'End If
        End Sub
    End Class

End Namespace
