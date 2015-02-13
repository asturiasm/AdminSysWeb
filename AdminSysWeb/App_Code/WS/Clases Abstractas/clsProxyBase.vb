Imports Microsoft.VisualBasic
Imports System.ServiceModel

Namespace SIGESWeb
    Public MustInherit Class clsProxyBase(Of T As Class)
        Implements ICommunicationObject, IDisposable
        Private _ChannelFactory As ChannelFactory(Of T) = Nothing
        Private _Channel As T = Nothing

        Public Property ChannelFactory As ChannelFactory(Of T)
            Get
                Return _ChannelFactory
            End Get
            Set(value As ChannelFactory(Of T))
                _ChannelFactory = value
            End Set
        End Property

#Region "Constructores"
        Public Sub New()
            _ChannelFactory = New ChannelFactory(Of T)()
            CreateProxy()
        End Sub

        Public Sub New(ByVal endpointConfigurationName As String)
            _ChannelFactory = New ChannelFactory(Of T)(endpointConfigurationName)
            CreateProxy()
        End Sub

        Public Sub New(ByVal binding As Channels.Binding)
            _ChannelFactory = New ChannelFactory(Of T)(binding)
            CreateProxy()
        End Sub

        Public Sub New(ByVal EndPoint As Description.ServiceEndpoint)
            _ChannelFactory = New ChannelFactory(Of T)(EndPoint)
            CreateProxy()
        End Sub

        Public Sub New(ByVal endpointConfigurationName As String, ByVal remoteAddress As ServiceModel.EndpointAddress)
            _ChannelFactory = New ChannelFactory(Of T)(endpointConfigurationName, remoteAddress)
            CreateProxy()
        End Sub

        Public Sub New(ByVal binding As Channels.Binding, ByVal remoteAddress As String)
            _ChannelFactory = New ChannelFactory(Of T)(binding, remoteAddress)
            CreateProxy()
        End Sub

        Public Sub New(ByVal binding As Channels.Binding, ByVal remoteAddress As ServiceModel.EndpointAddress)
            _ChannelFactory = New ChannelFactory(Of T)(binding, remoteAddress)
            CreateProxy()
        End Sub
#End Region

#Region "Miembros de ICommunicationObject"
        Protected Overridable Sub CreateProxy()
            _Channel = _ChannelFactory.CreateChannel()
            Dim co As ICommunicationObject = DirectCast(_Channel, ICommunicationObject)
            AddHandler co.Faulted, AddressOf InnerChannelFaulted
        End Sub

        Protected Sub InnerChannelFaulted(ByVal sender As Object, ByVal e As EventArgs)
            OnFaulted()
        End Sub

        Protected Overridable Sub OnFaulted()
            Dim co As ICommunicationObject = DirectCast(_Channel, ICommunicationObject)
            co.Abort()
            CreateProxy()
        End Sub

        Public Sub Abort() Implements ICommunicationObject.Abort
            Dim co As ICommunicationObject = DirectCast(_Channel, ICommunicationObject)
            co.Abort()
        End Sub

        Public Function BeginClose(callback As AsyncCallback, state As Object) As IAsyncResult Implements ICommunicationObject.BeginClose
            Return (DirectCast(_Channel, ICommunicationObject).BeginClose(callback, state))
        End Function

        Public Function BeginClose(timeout As TimeSpan, callback As AsyncCallback, state As Object) As IAsyncResult Implements ICommunicationObject.BeginClose
            Return (DirectCast(_Channel, ICommunicationObject).BeginClose(timeout, callback, state))
        End Function

        Public Function BeginOpen(callback As AsyncCallback, state As Object) As IAsyncResult Implements ICommunicationObject.BeginOpen
            Return (DirectCast(_Channel, ICommunicationObject).BeginOpen(callback, state))
        End Function

        Public Function BeginOpen(timeout As TimeSpan, callback As AsyncCallback, state As Object) As IAsyncResult Implements ICommunicationObject.BeginOpen
            Return (DirectCast(_Channel, ICommunicationObject).BeginOpen(timeout, callback, state))
        End Function

        Public Sub Close() Implements ICommunicationObject.Close
            Dim co As ICommunicationObject = DirectCast(_Channel, ICommunicationObject)
            co.Close()
        End Sub

        Public Sub Close(timeout As TimeSpan) Implements ICommunicationObject.Close
            Dim co As ICommunicationObject = DirectCast(_Channel, ICommunicationObject)
            co.Close(timeout)
        End Sub

        Public Event Closed(sender As Object, e As EventArgs) Implements ICommunicationObject.Closed
        Public Event Closing(sender As Object, e As EventArgs) Implements ICommunicationObject.Closing

        Public Sub EndClose(result As IAsyncResult) Implements ICommunicationObject.EndClose
            Dim co As ICommunicationObject = DirectCast(_Channel, ICommunicationObject)
            co.EndClose(result)
        End Sub

        Public Sub EndOpen(result As IAsyncResult) Implements ICommunicationObject.EndOpen
            Dim co As ICommunicationObject = DirectCast(_Channel, ICommunicationObject)
            co.EndOpen(result)
        End Sub

        Public Event Faulted(sender As Object, e As EventArgs) Implements ICommunicationObject.Faulted

        Public Sub Open() Implements ICommunicationObject.Open
            Dim co As ICommunicationObject = DirectCast(_Channel, ICommunicationObject)
            co.Open()
        End Sub

        Public Sub Open(timeout As TimeSpan) Implements ICommunicationObject.Open
            Dim co As ICommunicationObject = DirectCast(_Channel, ICommunicationObject)
            co.Open(timeout)
        End Sub

        Public Event Opened(sender As Object, e As EventArgs) Implements ICommunicationObject.Opened
        Public Event Opening(sender As Object, e As EventArgs) Implements ICommunicationObject.Opening

        Public ReadOnly Property State As CommunicationState Implements ICommunicationObject.State
            Get
                Dim co As ICommunicationObject = DirectCast(_Channel, ICommunicationObject)
                Return co.State
            End Get
        End Property
#End Region

#Region "IDisposable Support"
        Private disposedValue As Boolean ' To detect redundant calls

        ' IDisposable
        Protected Overridable Sub Dispose(disposing As Boolean)
            If Not Me.disposedValue Then
                If disposing Then
                    Try
                        Dim co As ICommunicationObject = DirectCast(_Channel, ICommunicationObject)
                        RemoveHandler co.Faulted, AddressOf InnerChannelFaulted
                        co.Close()
                    Catch
                        Try
                            Dim co As ICommunicationObject = DirectCast(_Channel, ICommunicationObject)
                            co.Abort()
                        Catch

                        End Try
                    End Try
                    Try
                        _ChannelFactory.Close()
                    Catch
                        Try
                            _ChannelFactory.Abort()
                        Catch

                        End Try
                    End Try
                End If
                ' TODO: free unmanaged resources (unmanaged objects) and override Finalize() below.
                ' TODO: set large fields to null.
            End If
            Me.disposedValue = True
        End Sub

        ' TODO: override Finalize() only if Dispose(ByVal disposing As Boolean) above has code to free unmanaged resources.
        'Protected Overrides Sub Finalize()
        '    ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
        '    Dispose(False)
        '    MyBase.Finalize()
        'End Sub

        ' This code added by Visual Basic to correctly implement the disposable pattern.
        Public Sub Dispose() Implements IDisposable.Dispose
            ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
            Dispose(True)
            GC.SuppressFinalize(Me)
        End Sub
#End Region

#Region "Invoke"
        Protected Overloads Sub Invoke(ByVal operationName As String, ParamArray parametros As Object())
            Dim tipo As Type = GetType(T)
            Dim Metodo As System.Reflection.MethodInfo = tipo.GetMethod(operationName)

            Try
                Metodo.Invoke(_Channel, parametros)
            Catch ex As System.Reflection.TargetInvocationException
                Dim commEx As CommunicationException = TryCast(ex.InnerException, CommunicationException)
                If IsNothing(commEx) Then Throw ex.InnerException 'No es un error de comunicación, disparar excepción
                'Dim faultEx As FaultException = TryCast(commEx, FaultException)
                'If IsNothing(faultEx) = False Then Throw ex.InnerException 'Es un error controlado de la capa de aplicación, disparar excepción

                'Si es un error de comunicación no controlado, reintentar una vez más la operación
                'si por un timeout, un recycle o cualquier otra razón el puerto se cerró y el evento onFault lo pudo volver a abrir
                'este nuevo reintento debería pasar siendo transparente para el usuario.
                Try
                    Metodo.Invoke(_Channel, parametros)
                Catch ex2 As System.Reflection.TargetInvocationException
                    Throw ex2.InnerException 'Si volvió a fallar, notificar al usuario
                End Try
            End Try
        End Sub

        Protected Function InvokeBool(ByVal operationName As String, ParamArray parametros As Object()) As Boolean
            Dim tipo As Type = GetType(T)
            Dim Metodo As System.Reflection.MethodInfo = tipo.GetMethod(operationName)

            Try
                Return CType(Metodo.Invoke(_Channel, parametros), Boolean)
            Catch ex As System.Reflection.TargetInvocationException
                Dim commEx As CommunicationException = TryCast(ex.InnerException, CommunicationException)
                If IsNothing(commEx) Then Throw ex.InnerException 'No es un error de comunicación, disparar excepción
                'Dim faultEx As FaultException = TryCast(commEx, FaultException)
                'If IsNothing(faultEx) = False Then Throw ex.InnerException 'Es un error controlado de la capa de aplicación, disparar excepción

                'Si es un error de comunicación no controlado, reintentar una vez más la operación
                'si por un timeout, un recycle o cualquier otra razón el puerto se cerró y el evento onFault lo pudo volver a abrir
                'este nuevo reintento debería pasar siendo transparente para el usuario.
                Try
                    Return CType(Metodo.Invoke(_Channel, parametros), Boolean)
                Catch ex2 As System.Reflection.TargetInvocationException
                    Throw ex2.InnerException 'Si volvió a fallar, notificar al usuario
                End Try
            End Try
        End Function


        Protected Overloads Function Invoke(Of TResult As Class)(ByVal operationName As String, ParamArray parametros As Object()) As TResult
            Dim tipo As Type = GetType(T)
            Dim Metodo As System.Reflection.MethodInfo = tipo.GetMethod(operationName)
            Dim Resultado As TResult = Nothing

            Try
                Resultado = TryCast(Metodo.Invoke(_Channel, parametros), TResult)
                Return Resultado
            Catch ex As System.Reflection.TargetInvocationException
                Dim commEx As CommunicationException = TryCast(ex.InnerException, CommunicationException)
                If IsNothing(commEx) Then Throw ex.InnerException 'No es un error de comunicación, disparar excepción
                'Dim faultEx As FaultException = TryCast(commEx, FaultException)
                'If IsNothing(faultEx) = False Then Throw ex.InnerException 'Es un error controlado de la capa de aplicación, disparar excepción

                'Si es un error de comunicación no controlado, reintentar una vez más la operación
                'si por un timeout, un recycle o cualquier otra razón el puerto se cerró y el evento onFault lo pudo volver a abrir
                'este nuevo reintento debería pasar siendo transparente para el usuario.
                Try
                    Resultado = TryCast(Metodo.Invoke(_Channel, parametros), TResult)
                    Return Resultado
                Catch ex2 As System.Reflection.TargetInvocationException
                    Throw ex2.InnerException 'Si volvió a fallar, notificar al usuario
                End Try
            End Try
        End Function
#End Region
    End Class
End Namespace