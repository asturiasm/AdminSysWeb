Imports System.Collections
Imports System.Collections.Generic
Imports System.Web

Namespace DisableDoubleLogin
    ''' <summary>
    ''' This class Maintenance the login state
    ''' </summary>
    Public NotInheritable Class LoginState
        Private Sub New()
        End Sub

        ''' <summary>
        ''' getter/setter for the userid of current user
        ''' if the current user does not login in, getter return -1L
        ''' </summary>
        Public Shared Property CurrentUserID() As String
            Get
                If HttpContext.Current.Session Is Nothing OrElse HttpContext.Current.Session("Usuario") Is Nothing Then
                    Return "-1"
                End If
                Return HttpContext.Current.Session("Usuario")
            End Get
            Set(ByVal value As String)
                HttpContext.Current.Session("Usuario") = value
            End Set
        End Property
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Property allowMultipleSessions() As Boolean
            Get
                If HttpContext.Current.Session Is Nothing OrElse HttpContext.Current.Session("MultipleSesion") Is Nothing Then
                    Return False
                End If
                Return HttpContext.Current.Session("MultipleSesion")
            End Get
            Set(ByVal value As Boolean)
                HttpContext.Current.Session("MultipleSesion") = value
            End Set
        End Property

        ''' <summary>
        ''' getter, whether the current user is signed in
        ''' </summary>
        Public Shared ReadOnly Property InSignedIn() As Boolean
            Get
                Return CurrentUserID > 0
            End Get
        End Property


        ''' <summary>
        ''' check whether the current user is double login
        ''' </summary>
        ''' <returns>true:Yes, the user is double login; false:No</returns>
        Public Shared Function IsDoubleLogin(ByVal bValidate As Boolean) As Boolean
            Dim strId As String = String.Empty
            Dim wsServicio As New wsSIGES.DataRetrievalWCFClient(SIGESWeb.clsConstantes.EndPointSIGESGenerico)
            Dim dsDatos As DataSet

            If CurrentUserID = "-1" OrElse Not bValidate OrElse allowMultipleSessions Then Return False
            wsServicio.Open()
            dsDatos = wsServicio.getDatabySQL(String.Format("select sid,sesion_multiple from ad_usuarios where UPPER(usuario)='{0}'", UCase(CurrentUserID)), True, "<p></p>", "AD_USUARIOS")
            wsServicio.Close()
            If Not IsNothing(dsDatos) AndAlso _
               dsDatos.Tables.Count > 0 AndAlso _
               dsDatos.Tables(0).Rows.Count > 0 Then
                strId = dsDatos.Tables(0).Rows(0)("sid")
                allowMultipleSessions = dsDatos.Tables(0).Rows(0)("sesion_multiple").ToString.Equals("S")
            End If

            Dim validateDoubleLogin As Boolean = String.Compare(strId, HttpContext.Current.Session.SessionID) <> 0 AndAlso Not allowMultipleSessions
            Return validateDoubleLogin
        End Function
    End Class
End Namespace