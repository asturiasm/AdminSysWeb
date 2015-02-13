Imports System.Diagnostics
Imports System.Xml
Imports Telerik.Web.UI
Imports System.Web.UI

Namespace SIGESWeb
    Public Class clsUtil

        ''' <summary>
        ''' Convierte a decimal un tipo string, validando que si el mismo viene vacío, retorna 0.
        ''' </summary>
        ''' <param name="Texto"></param>
        ''' <returns>Equivalente en tipo decimal</returns>
        ''' <remarks></remarks>
        Public Shared Function ToDecimal(ByVal Texto As String) As Decimal
            If Texto.Length > 0 Then
                Return Convert.ToDecimal(Texto)
            Else
                Return 0
            End If
        End Function

        Public Shared Sub Sumarizar(ByVal ds As DataSet, ByVal tabla As DataTable)
            Dim valor As Double = 0
            Dim i, j As Integer

            For i = 0 To tabla.Rows.Count - 1
                tabla.Rows(i).Item("TOTAL") = 0
            Next

            tabla.PrimaryKey = New DataColumn() {tabla.Columns("NOMBRE")}

            For i = 0 To ds.Tables("MAINDATA").Rows.Count - 1
                For j = 0 To tabla.Rows.Count - 1
                    With ds.Tables("MAINDATA").Rows(i)
                        tabla.Rows(j).Item("TOTAL") += IIf(IsDBNull(.Item(tabla.Rows(j).Item("NOMBRE"))), 0, .Item(tabla.Rows(j).Item("NOMBRE")))
                    End With
                Next
            Next

            tabla.AcceptChanges()
            ds.RejectChanges()
        End Sub

        Private Shared Function darPosicionMetodo(ByVal metodo As String) As Integer
            Dim i As Integer = 1
            Dim last As Integer
            i = InStr(i, metodo, ".") + 1
            While i > 1
                last = i
                i = InStr(i, metodo, ".") + 1
            End While
            Return last
        End Function

        Public Shared Sub darInformacionMetodo(ByVal operacion As String, ByVal data As DataSet, ByRef assemblyname As String, ByRef clase As String, ByRef metodo As String)
            Dim i As Integer

            For i = 0 To data.Tables("TOOLBAR").Rows.Count - 1
                With data.Tables("TOOLBAR").Rows(i)
                    If UCase(Trim(.Item("NOMBRE_FISICO"))) = operacion Then
                        assemblyname = Trim(.Item("ASSEMBLYNAME"))
                        clase = Mid(Trim(.Item("METODO")), 1, darPosicionMetodo(Trim(.Item("METODO"))) - 2)
                        metodo = Mid(Trim(.Item("METODO")), darPosicionMetodo(Trim(.Item("METODO"))), Len(Trim(.Item("METODO"))))
                        Exit Sub
                    End If
                End With
            Next
        End Sub

        Public Shared Sub agregarParametro(ByVal param As System.Xml.XmlDocument, ByVal ds As DataSet, ByVal parametro As String, ByVal tipodato As String, Optional ByVal aliasname As String = "")
            Dim nodo As System.Xml.XmlElement
            Dim myalias As String = IIf(aliasname = "", parametro, aliasname)
            If param.SelectSingleNode("PARAMETROS/P" & myalias) Is Nothing Then
                nodo = param.CreateElement("P" & myalias)
                nodo.SetAttribute("TIPODATO", tipodato)
                nodo.InnerText = ds.Tables(0).Rows(0).Item(parametro)
                param.SelectSingleNode("PARAMETROS").AppendChild(nodo)
            Else
                param.SelectSingleNode("PARAMETROS/P" & myalias).InnerText = ds.Tables(0).Rows(0).Item(parametro)
            End If
        End Sub

        Public Shared Sub agregarParametroVAL(ByVal param As System.Xml.XmlDocument, ByVal value As String, ByVal parametro As String, ByVal tipodato As String, Optional ByVal aliasname As String = "")
            Dim nodo As System.Xml.XmlElement
            Dim myalias As String = IIf(aliasname = "", parametro, aliasname)
            If param.SelectSingleNode("PARAMETROS/P" & myalias) Is Nothing Then
                nodo = param.CreateElement("P" & myalias)
                nodo.SetAttribute("TIPODATO", tipodato)
                nodo.InnerText = value
                param.SelectSingleNode("PARAMETROS").AppendChild(nodo)
            Else
                param.SelectSingleNode("PARAMETROS/P" & myalias).InnerText = value
            End If
        End Sub


        Public Shared Sub agregarParametro(ByVal param As System.Xml.XmlDocument, ByVal parametro As String, ByVal tipodato As String, ByVal initialvalue As String, Optional ByVal aliasname As String = "")
            Dim nodo As System.Xml.XmlElement
            Dim myalias As String = IIf(aliasname = "", parametro, aliasname)
            If param.SelectSingleNode("PARAMETROS/P" & myalias) Is Nothing Then
                nodo = param.CreateElement("P" & myalias)
                nodo.SetAttribute("TIPODATO", tipodato)
                nodo.InnerText = initialvalue
                param.SelectSingleNode("PARAMETROS").AppendChild(nodo)
            Else
                param.SelectSingleNode("PARAMETROS/P" & myalias).InnerText = initialvalue
            End If
        End Sub


        Public Shared Function DropDownListdata(ByVal columnName As String, ByVal myds As DataSet) As String
            Dim i As Integer

            For i = 0 To myds.Tables("COLUMNAS_MAINDATA").Rows.Count - 1
                With myds.Tables("COLUMNAS_MAINDATA").Rows(i)
                    If (Trim(.Item("DATAFIELD")) = columnName) Then
                        If Not IsDBNull(.Item("DATALIST")) Then
                            Return Trim(.Item("DATALIST"))
                        Else
                            Return ""
                        End If
                    End If
                End With
            Next
            Return ""
        End Function

        Private Shared Function debeHabilitarse(ByVal allowinsert As String, ByVal allowupdate As String, ByVal action As String) As Boolean
            Select Case action
                Case "UPDATE"
                    Return (allowupdate = "S")
                Case "INSERT"
                    Return (allowinsert = "S")
                Case "DISABLEALL"
                    Return False
            End Select
            Return False
        End Function

        Public Shared Sub DisableControls(ByVal mypage As System.Web.UI.Page, ByVal myds As DataSet, ByVal action As String)
            Dim myctrl As Control
            Dim txtbox As TextBox
            Dim chkbox As CheckBox
            Dim ddlist As DropDownList
            Dim txtval As String
            Dim i As Integer

            For i = 0 To myds.Tables("COLUMNAS_MAINDATA").Rows.Count - 1
                With myds.Tables("COLUMNAS_MAINDATA").Rows(i)
                    myctrl = mypage.FindControl(Trim(.Item("DATAFIELD")))
                    If Not (myctrl Is Nothing) Then
                        Select Case CType(myctrl.GetType, Type).ToString
                            Case "System.Web.UI.WebControls.TextBox"
                                txtbox = CType(myctrl, TextBox)
                                txtbox.Enabled = debeHabilitarse(.Item("PERMITIR_INSERT"), .Item("PERMITIR_UPDATE"), action)
                                txtval = DropDownListdata(txtbox.ID, myds)
                                If txtval <> "" Then
                                    ddlist = mypage.FindControl(txtbox.ID & "_" & txtval)
                                    If Not ddlist Is Nothing Then ddlist.Enabled = txtbox.Enabled
                                End If
                            Case "System.Web.UI.WebControls.CheckBox"
                                chkbox = CType(myctrl, CheckBox)
                                chkbox.Enabled = debeHabilitarse(.Item("PERMITIR_INSERT"), .Item("PERMITIR_UPDATE"), action)
                            Case "System.Web.UI.WebControls.DropDownList"
                                ddlist = CType(myctrl, DropDownList)
                                ddlist.Enabled = debeHabilitarse(.Item("PERMITIR_INSERT"), .Item("PERMITIR_UPDATE"), action)
                        End Select
                    End If
                End With
            Next
        End Sub

        Public Shared Sub SetButtonIcon(ByVal dt As DataTable, ByVal boton As ImageButton, ByVal operacion As String)
            Dim i As Integer
            If operacion = "VER_REGISTRO" Then
                boton.Visible = False
                Exit Sub
            End If

            For i = 0 To dt.Rows.Count - 1
                With dt.Rows(i)
                    If UCase(Trim(.Item("NOMBRE_FISICO"))) = operacion Then
                        boton.ImageUrl = "../img/" & UCase(.Item("ETIQUETA")) & ".gif"
                        boton.ToolTip = .Item("NOMBRE_LOGICO")
                    End If
                End With
            Next
        End Sub

        Public Shared Sub LoadData(ByRef mypage As System.Web.UI.Page, ByVal ds As DataSet, ByVal dls As DataSet, ByVal RecuperarDatos As Boolean, ByVal dr As DataRow)
            Dim ddldata As String
            Dim ctrl As System.Web.UI.Control
            Dim ddlval As DropDownList
            Dim tval As TextBox
            Dim cval As CheckBox
            Dim lblT As Label
            Dim hdf As HiddenField
            Dim masktb As Telerik.Web.UI.RadMaskedTextBox
            Dim numtb As Telerik.Web.UI.RadNumericTextBox
            Dim tvaltb As Telerik.Web.UI.RadTextBox
            Dim vDataList As String
            Dim i As Integer

            For i = 0 To ds.Tables("COLUMNAS_MAINDATA").Rows.Count - 1
                'Codigo anulado porque no debería aplicar nunca que este campo tenga espacios en blanco
                '    .Item("DATAFIELD") = Trim(.Item("DATAFIELD"))
                With ds.Tables("COLUMNAS_MAINDATA").Rows(i)
                    ctrl = mypage.FindControl(.Item("DATAFIELD"))
                    If Not (ctrl Is Nothing) Then
                        Select Case ctrl.GetType.ToString()
                            Case "Telerik.Web.UI.RadTextBox"
                                ddldata = DropDownListdata(.Item("DATAFIELD"), ds)
                                If ddldata <> "" Then
                                    ddlval = CType(mypage.FindControl(.Item("DATAFIELD") & "_" & ddldata), DropDownList)
                                    ddlval.DataSource = dls.Tables(ddldata).DefaultView()
                                    ddlval.DataTextField = "DESCRIPCION"
                                    ddlval.DataValueField = "LLAVE"
                                    ddlval.DataBind()
                                    If RecuperarDatos = True Then
                                        Try
                                            If Not IsDBNull(dr.Item(.Item("DATAFIELD"))) Then
                                                ddlval.Items.FindByValue(dr.Item(.Item("DATAFIELD"))).Selected = True
                                            End If
                                        Catch e As Exception
                                            Try
                                                ddlval.Items.FindByValue(CType(ctrl, Telerik.Web.UI.RadTextBox).Text).Selected = True
                                            Catch e2 As Exception
                                                ddlval.Items(0).Selected = True
                                            End Try
                                        End Try
                                    End If
                                End If
                                If RecuperarDatos = True Then
                                    tvaltb = CType(ctrl, Telerik.Web.UI.RadTextBox)
                                    Try
                                        If .Item("TIPO_DATO") = "D" OrElse .Item("TIPO_DATO") = "F" Then
                                            'si el dato es de tipo fecha se arregla el formato
                                            If IsDBNull(dr.Item(.Item("DATAFIELD"))) Then
                                                tvaltb.Text = ""
                                            Else
                                                If .Item("TIPO_DATO") = "D" Then
                                                    tvaltb.Text = Format(DateSerial(Year(dr.Item(.Item("DATAFIELD"))), Month(dr.Item(.Item("DATAFIELD"))), Day(dr.Item(.Item("DATAFIELD")))), "dd/MM/yyyy")
                                                Else
                                                    tvaltb.Text = Format(DateSerial(Year(dr.Item(.Item("DATAFIELD"))), Month(dr.Item(.Item("DATAFIELD"))), Day(dr.Item(.Item("DATAFIELD")))), "dd/MM/yyyy") & " " & Format(TimeSerial(Hour(dr.Item(.Item("DATAFIELD"))), Minute(dr.Item(.Item("DATAFIELD"))), Second(dr.Item(.Item("DATAFIELD")))), "hh:mm:ss tt")
                                                    tvaltb.MaxLength = 22
                                                End If
                                            End If
                                        Else
                                            tvaltb.Text = IIf(IsDBNull(dr.Item(.Item("DATAFIELD"))), "", dr.Item(.Item("DATAFIELD")))
                                        End If
                                    Catch e As Exception
                                        Try
                                            tvaltb.Text = CType(ctrl, TextBox).Text
                                        Catch e2 As Exception
                                            tvaltb.Text = "0"
                                        End Try
                                    End Try
                                End If
                            Case "System.Web.UI.WebControls.TextBox"
                                ddldata = DropDownListdata(.Item("DATAFIELD"), ds)
                                If ddldata <> "" Then
                                    ddlval = CType(mypage.FindControl(.Item("DATAFIELD") & "_" & ddldata), DropDownList)
                                    ddlval.DataSource = dls.Tables(ddldata).DefaultView()
                                    ddlval.DataTextField = "DESCRIPCION"
                                    ddlval.DataValueField = "LLAVE"
                                    ddlval.DataBind()
                                    If RecuperarDatos = True Then
                                        Try
                                            If Not IsDBNull(dr.Item(.Item("DATAFIELD"))) Then
                                                ddlval.Items.FindByValue(dr.Item(.Item("DATAFIELD"))).Selected = True
                                            End If
                                        Catch e As Exception
                                            Try
                                                ddlval.Items.FindByValue(CType(ctrl, TextBox).Text).Selected = True
                                            Catch e2 As Exception
                                                ddlval.Items(0).Selected = True
                                            End Try
                                        End Try
                                    End If
                                End If
                                If RecuperarDatos = True Then
                                    tval = CType(ctrl, TextBox)
                                    Try
                                        If .Item("TIPO_DATO") = "D" OrElse .Item("TIPO_DATO") = "F" Then
                                            'si el dato es de tipo fecha se arregla el formato
                                            If IsDBNull(dr.Item(.Item("DATAFIELD"))) Then
                                                tval.Text = ""
                                            Else
                                                If .Item("TIPO_DATO") = "D" Then
                                                    tval.Text = Format(DateSerial(Year(dr.Item(.Item("DATAFIELD"))), Month(dr.Item(.Item("DATAFIELD"))), Day(dr.Item(.Item("DATAFIELD")))), "dd/MM/yyyy")
                                                Else
                                                    tval.Text = Format(DateSerial(Year(dr.Item(.Item("DATAFIELD"))), Month(dr.Item(.Item("DATAFIELD"))), Day(dr.Item(.Item("DATAFIELD")))), "dd/MM/yyyy") & " " & Format(TimeSerial(Hour(dr.Item(.Item("DATAFIELD"))), Minute(dr.Item(.Item("DATAFIELD"))), Second(dr.Item(.Item("DATAFIELD")))), "hh:mm:ss tt")
                                                    tval.MaxLength = 22
                                                End If
                                            End If
                                        Else
                                            tval.Text = IIf(IsDBNull(dr.Item(.Item("DATAFIELD"))), "", dr.Item(.Item("DATAFIELD")))
                                        End If
                                    Catch e As Exception
                                        Try
                                            tval.Text = CType(ctrl, TextBox).Text
                                        Catch e2 As Exception
                                            tval.Text = "0"
                                        End Try
                                    End Try
                                End If
                            Case "System.Web.UI.WebControls.CheckBox"
                                If RecuperarDatos = True Then
                                    cval = CType(ctrl, CheckBox)
                                    cval.Checked = False
                                    If .IsNull("DATAFIELD") = False AndAlso _
                                       dr.Item(.Item("DATAFIELD")) = "S" Then
                                        cval.Checked = True
                                    End If
                                End If
                            Case "System.Web.UI.WebControls.DropDownList"
                                ddlval = CType(ctrl, DropDownList)
                                vDataList = DropDownListdata(.Item("DATAFIELD"), ds)
                                If vDataList <> "" Then
                                    ddlval.DataSource = dls.Tables(vDataList).DefaultView()
                                    ddlval.DataTextField = "DESCRIPCION"
                                    ddlval.DataValueField = "LLAVE"
                                    ddlval.DataBind()
                                End If
                                If RecuperarDatos Then
                                    Try
                                        ddlval.Items.FindByValue(dr.Item(.Item("DATAFIELD"))).Selected = True
                                    Catch errx As Exception
                                    End Try
                                End If
                            Case "System.Web.UI.WebControls.Label"
                                If RecuperarDatos Then
                                    lblT = CType(ctrl, Label)
                                    lblT.Text = IIf(Not dr.Item(.Item("DATAFIELD")) Is System.DBNull.Value, dr.Item(.Item("DATAFIELD")), String.Empty)
                                End If
                            Case "System.Web.UI.WebControls.HiddenField"
                                If RecuperarDatos Then
                                    hdf = CType(ctrl, HiddenField)
                                    hdf.Value = IIf(Not dr.Item(.Item("DATAFIELD")) Is System.DBNull.Value, dr.Item(.Item("DATAFIELD")), String.Empty)
                                End If
                            Case "Telerik.Web.UI.RadMaskedTextBox"
                                If RecuperarDatos Then
                                    masktb = CType(ctrl, RadMaskedTextBox)
                                    masktb.Text = IIf(Not dr.Item(.Item("DATAFIELD")) Is System.DBNull.Value, dr.Item(.Item("DATAFIELD")), String.Empty)
                                End If
                            Case "Telerik.Web.UI.RadNumericTextBox"
                                If RecuperarDatos Then
                                    numtb = CType(ctrl, RadNumericTextBox)
                                    numtb.Text = IIf(Not dr.Item(.Item("DATAFIELD")) Is System.DBNull.Value, dr.Item(.Item("DATAFIELD")), String.Empty)
                                End If
                        End Select
                    End If
                End With
            Next
        End Sub

        Public Shared Sub LoadData2(ByRef mypage As System.Web.UI.Page, ByVal ds As DataSet, ByVal dls As DataSet, ByVal operacion As String, ByVal dr As DataRow, Optional ByVal dr2 As DataRow = Nothing)
            Dim ddldata As String
            Dim ctrl As System.Web.UI.Control
            Dim ddlval As DropDownList
            Dim tval As TextBox
            Dim cval As CheckBox
            Dim lblT As Label
            Dim vDataList As String
            Dim i As Integer


            For i = 0 To ds.Tables("COLUMNAS_MAINDATA").Rows.Count - 1
                'Codigo anulado porque no debería aplicar nunca que este campo tenga espacios en blanco
                '    .Item("DATAFIELD") = Trim(.Item("DATAFIELD"))
                With ds.Tables("COLUMNAS_MAINDATA").Rows(i)
                    ctrl = mypage.FindControl(.Item("DATAFIELD"))
                    Dim dato As New Object
                    If Not IsNothing(dr) AndAlso dr.Table.Columns.Contains(.Item("DATAFIELD")) AndAlso Not IsDBNull(dr.Item(.Item("DATAFIELD"))) Then
                        'Si el dato esta en la tabla principal
                        dato = dr.Item(.Item("DATAFIELD"))
                    Else
                        'Si el dato esta en la consulta statement
                        If Not IsNothing(dr2) AndAlso dr2.Table.Columns.Contains(.Item("DATAFIELD")) _
                        AndAlso Not IsDBNull(dr2.Item(.Item("DATAFIELD"))) Then
                            dato = dr2.Item(.Item("DATAFIELD"))
                        Else
                            dato = DBNull.Value
                        End If
                    End If

                    If Not (ctrl Is Nothing) Then
                        Select Case ctrl.GetType.ToString()
                            Case "System.Web.UI.WebControls.TextBox"
                                ddldata = DropDownListdata(.Item("DATAFIELD"), ds)
                                If ddldata <> "" Then
                                    ddlval = CType(mypage.FindControl(.Item("DATAFIELD") & "_" & ddldata), DropDownList)
                                    ddlval.DataSource = dls.Tables(ddldata).DefaultView()
                                    ddlval.DataTextField = "DESCRIPCION"
                                    ddlval.DataValueField = "LLAVE"
                                    ddlval.DataBind()
                                    If InStr(operacion, "CREAR") = 0 Then
                                        Try
                                            If Not IsDBNull(dato) Then
                                                ddlval.Items.FindByValue(dato).Selected = True
                                            End If
                                        Catch e As Exception
                                            Try
                                                ddlval.Items.FindByValue(CType(ctrl, TextBox).Text).Selected = True
                                            Catch e2 As Exception
                                                ddlval.Items(0).Selected = True
                                            End Try
                                        End Try
                                    End If
                                End If
                                If InStr(operacion, "CREAR") = 0 Then
                                    tval = CType(ctrl, TextBox)
                                    Try
                                        If .Item("TIPO_DATO") = "D" OrElse .Item("TIPO_DATO") = "F" Then
                                            'si el dato es de tipo fecha se arregla el formato
                                            If IsDBNull(dato) Then
                                                tval.Text = ""
                                            Else
                                                If .Item("TIPO_DATO") = "D" Then
                                                    tval.Text = Format(DateSerial(Year(dato), Month(dato), Day(dato)), "dd/MM/yyyy")
                                                Else
                                                    tval.Text = Format(DateSerial(Year(dato), Month(dato), Day(dato)), "dd/MM/yyyy") & " " & Format(TimeSerial(Hour(dato), Minute(dato), Second(dato)), "hh:mm:ss tt")
                                                    tval.MaxLength = 22
                                                End If
                                            End If
                                        Else
                                            tval.Text = IIf(IsDBNull(dato), "", dato)
                                        End If
                                    Catch e As Exception
                                        Try
                                            tval.Text = CType(ctrl, TextBox).Text
                                        Catch e2 As Exception
                                            tval.Text = "0"
                                        End Try
                                    End Try
                                End If
                            Case "System.Web.UI.WebControls.CheckBox"
                                If InStr(operacion, "CREAR") = 0 Then
                                    cval = CType(ctrl, CheckBox)
                                    cval.Checked = False
                                    If .IsNull("DATAFIELD") = False AndAlso _
                                       dato = "S" Then
                                        cval.Checked = True
                                    End If
                                End If
                            Case "System.Web.UI.WebControls.DropDownList"
                                ddlval = CType(ctrl, DropDownList)
                                vDataList = DropDownListdata(.Item("DATAFIELD"), ds)
                                If vDataList <> "" Then
                                    ddlval.DataSource = dls.Tables(vDataList).DefaultView()
                                    ddlval.DataTextField = "DESCRIPCION"
                                    ddlval.DataValueField = "LLAVE"
                                    ddlval.DataBind()
                                End If
                                If InStr(operacion, "CREAR") = 0 Then
                                    Try
                                        ddlval.Items.FindByValue(dato).Selected = True
                                    Catch errx As Exception
                                    End Try
                                End If
                            Case "System.Web.UI.WebControls.Label"
                                If InStr(operacion, "CREAR") = 0 Then
                                    lblT = CType(ctrl, Label)
                                    lblT.Text = IIf(Not dato Is System.DBNull.Value, dato, String.Empty)
                                End If
                        End Select
                    End If
                End With
            Next
        End Sub

        Public Shared Function LoadFromPage(ByVal mypage As System.Web.UI.Page, ByVal operacion As String, ByVal ds As DataSet) As DataRow
            Dim dr As DataRow
            Dim tval As TextBox
            Dim cval As CheckBox
            Dim lval As Label
            Dim hdf As HiddenField
            Dim ddlval As DropDownList
            Dim i As Integer
            Dim ctrl As System.Web.UI.Control
            Dim ctrltype As Type
            Dim tmpdato As String
            Dim fechatmp As DateTime
            Dim masktb As Telerik.Web.UI.RadMaskedTextBox
            Dim numtb As Telerik.Web.UI.RadNumericTextBox
            Dim telerikTextBox As RadTextBox

            If InStr(operacion, "CREAR") = 0 Then
                dr = ds.Tables(0).Rows(0)
            Else
                dr = ds.Tables(0).NewRow
            End If
            For i = 0 To ds.Tables(0).Columns.Count - 1
                With ds.Tables(0).Columns(i)
                    ctrl = mypage.FindControl(.ColumnName)

                    If Not (ctrl Is Nothing) Then
                        ctrltype = ctrl.GetType
                        Select Case ctrl.GetType.ToString()
                            Case "System.Web.UI.WebControls.HiddenField"
                                hdf = CType(ctrl, HiddenField)
                                If hdf.Value.Length = 0 Then
                                    dr.Item(.ColumnName) = System.DBNull.Value
                                Else
                                    dr.Item(.ColumnName) = hdf.Value
                                End If
                            Case "Telerik.Web.UI.RadMaskedTextBox"
                                masktb = CType(ctrl, RadMaskedTextBox)
                                If masktb.Text.Length = 0 Then
                                    dr.Item(.ColumnName) = System.DBNull.Value
                                Else
                                    dr.Item(.ColumnName) = masktb.Text
                                End If
                            Case "Telerik.Web.UI.RadNumericTextBox"
                                numtb = CType(ctrl, RadNumericTextBox)
                                If numtb.Text.Length = 0 Then
                                    dr.Item(.ColumnName) = System.DBNull.Value
                                Else
                                    dr.Item(.ColumnName) = numtb.Text
                                End If
                            Case "System.Web.UI.WebControls.Label"
                                lval = CType(ctrl, Label)
                                If lval.Text.Length = 0 Then
                                    dr.Item(.ColumnName) = System.DBNull.Value
                                Else
                                    dr.Item(.ColumnName) = lval.Text
                                End If
                            Case "Telerik.Web.UI.RadTextBox"
                                telerikTextBox = CType(ctrl, RadTextBox)
                                If IsDBNull(dr.Item(.ColumnName)) Then
                                    tmpdato = ""
                                Else
                                    If .DataType.ToString() = "System.DateTime" Then
                                        tmpdato = Format(dr.Item(.ColumnName), "dd/MM/yyyy")
                                    Else
                                        tmpdato = CStr(dr.Item(.ColumnName))
                                    End If
                                End If

                                If telerikTextBox.Text <> tmpdato Then
                                    If .DataType.ToString() = "System.DateTime" Then
                                        If telerikTextBox.Text.Length > 0 Then
                                            'si el campo es tipo fecha se construye la fecha
                                            fechatmp = DateSerial(CInt(Mid(telerikTextBox.Text, 7, 4)), CInt(Mid(telerikTextBox.Text, 4, 2)), CInt(Mid(telerikTextBox.Text, 1, 2)))
                                            If Trim(telerikTextBox.Text).Length > 10 Then
                                                'si trae la hora se le agrega
                                                fechatmp = fechatmp.AddHours(CDbl(Mid(telerikTextBox.Text, 12, 2)))
                                                fechatmp = fechatmp.AddMinutes(CDbl(Mid(telerikTextBox.Text, 15, 2)))
                                                fechatmp = fechatmp.AddSeconds(CDbl(Mid(telerikTextBox.Text, 18, 2)))
                                            End If
                                            dr.Item(.ColumnName) = fechatmp
                                        Else
                                            dr.Item(.ColumnName) = System.DBNull.Value
                                        End If
                                    Else
                                        If .DataType.ToString() = "System.Decimal" Then
                                            If telerikTextBox.Text = "" Then
                                                dr.Item(.ColumnName) = System.DBNull.Value
                                            ElseIf IsNumeric(telerikTextBox.Text) Then
                                                dr.Item(.ColumnName) = CDec(telerikTextBox.Text)
                                            Else
                                                Throw New Exception("Se ha ingresado un valor incorrecto en " & .ColumnName)
                                            End If
                                        Else
                                            dr.Item(.ColumnName) = telerikTextBox.Text
                                        End If
                                    End If
                                End If
                            Case "System.Web.UI.WebControls.TextBox"
                                tval = CType(ctrl, TextBox)
                                If IsDBNull(dr.Item(.ColumnName)) Then
                                    tmpdato = ""
                                Else
                                    If .DataType.ToString() = "System.DateTime" Then
                                        tmpdato = Format(dr.Item(.ColumnName), "dd/MM/yyyy")
                                    Else
                                        tmpdato = CStr(dr.Item(.ColumnName))
                                    End If
                                End If

                                If tval.Text <> tmpdato Then
                                    If .DataType.ToString() = "System.DateTime" Then
                                        If tval.Text.Length > 0 Then
                                            'si el campo es tipo fecha se construye la fecha
                                            fechatmp = DateSerial(CInt(Mid(tval.Text, 7, 4)), CInt(Mid(tval.Text, 4, 2)), CInt(Mid(tval.Text, 1, 2)))
                                            If Trim(tval.Text).Length > 10 Then
                                                'si trae la hora se le agrega
                                                fechatmp = fechatmp.AddHours(CDbl(Mid(tval.Text, 12, 2)))
                                                fechatmp = fechatmp.AddMinutes(CDbl(Mid(tval.Text, 15, 2)))
                                                fechatmp = fechatmp.AddSeconds(CDbl(Mid(tval.Text, 18, 2)))
                                            End If
                                            dr.Item(.ColumnName) = fechatmp
                                        Else
                                            dr.Item(.ColumnName) = System.DBNull.Value
                                        End If
                                    Else
                                        If .DataType.ToString() = "System.Decimal" Then
                                            If tval.Text = "" Then
                                                dr.Item(.ColumnName) = System.DBNull.Value
                                            ElseIf IsNumeric(tval.Text) Then
                                                dr.Item(.ColumnName) = CDec(tval.Text)
                                            Else
                                                Throw New Exception("Se ha ingresado un valor incorrecto en " & .ColumnName)
                                            End If
                                        Else
                                            dr.Item(.ColumnName) = tval.Text
                                        End If
                                    End If
                                End If
                            Case "System.Web.UI.WebControls.CheckBox"
                                cval = CType(ctrl, CheckBox)
                                If IsDBNull(dr.Item(.ColumnName)) Then
                                    dr.Item(.ColumnName) = IIf(cval.Checked, "S", "N")
                                ElseIf dr.Item(.ColumnName) <> IIf(cval.Checked, "S", "N") Then
                                    dr.Item(.ColumnName) = IIf(cval.Checked, "S", "N")
                                End If
                            Case "System.Web.UI.WebControls.DropDownList"
                                ddlval = CType(ctrl, DropDownList)
                                If ddlval.SelectedIndex > -1 AndAlso _
                                   ddlval.Items(ddlval.SelectedIndex).Value <> IIf(IsDBNull(dr.Item(.ColumnName)), "", dr.Item(.ColumnName)) Then
                                    dr.Item(.ColumnName) = ddlval.Items(ddlval.SelectedIndex).Value
                                End If
                        End Select
                    End If
                End With
            Next
            Return dr
        End Function

        Public Shared Function Caracter(ByVal num_car As Integer, ByVal carac As String) As String
            Dim i As Integer
            Dim cadena As String = ""
            For i = 1 To num_car
                cadena = cadena & carac
            Next
            Return cadena
        End Function

        Public Shared Sub DataFormat(ByVal mypage As System.Web.UI.Page, ByVal myds As DataSet)
            Dim myctrl As System.Web.UI.Control
            Dim mytxtbox As System.Web.UI.WebControls.TextBox
            Dim ctrltype As Type
            Dim i As Integer

            For i = 0 To myds.Tables("COLUMNAS_MAINDATA").Rows.Count - 1
                With myds.Tables("COLUMNAS_MAINDATA").Rows(i)
                    If .Item("TIPO_DATO") = "N" OrElse .Item("TIPO_DATO") = "C" Then
                        myctrl = mypage.FindControl(Trim(.Item("DATAFIELD")))
                        If Not (myctrl Is Nothing) Then
                            ctrltype = myctrl.GetType
                            If ctrltype.ToString = "System.Web.UI.WebControls.TextBox" Then
                                mytxtbox = CType(myctrl, System.Web.UI.WebControls.TextBox)
                                If .Item("TIPO_DATO") = "N" Then
                                    mytxtbox.Style.Add("text-align", "right")
                                End If
                                If Not IsDBNull(.Item("DECIMALES")) Then
                                    mytxtbox.Text = Format(Val(mytxtbox.Text), "###,###,###,##0." & Caracter(.Item("DECIMALES"), "0"))
                                Else
                                    If Not IsDBNull(.Item("LONGITUD")) Then
                                        If .Item("TIPO_DATO") <> "C" Then
                                            mytxtbox.Text = Format(Val(mytxtbox.Text), Caracter(.Item("LONGITUD") - 1, "0") & "#")
                                        Else
                                            mytxtbox.MaxLength = .Item("LONGITUD")
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    End If
                End With
            Next
        End Sub

        Public Shared Function BuildXMLMensaje(ByVal strTitulo As String, _
                                                ByVal strTexto As String, _
                                                ByVal bolBotonRegresar As Boolean, _
                                                Optional ByVal strLink As String = "", _
                                                Optional ByVal strParametros As String = "", _
                                                Optional ByVal strTextoLink As String = "") As System.Xml.XmlDocument

            Dim oxml As New System.Xml.XmlDocument
            Dim nxml As System.Xml.XmlElement


            nxml = oxml.CreateElement("MENSAJE")
            oxml.AppendChild(nxml)

            nxml = oxml.CreateElement("TITULO")
            nxml.InnerText = strTitulo
            oxml.SelectSingleNode("MENSAJE").AppendChild(nxml)

            nxml = oxml.CreateElement("TEXTO")
            nxml.InnerText = strTexto
            oxml.SelectSingleNode("MENSAJE").AppendChild(nxml)

            nxml = oxml.CreateElement("REGRESAR")
            nxml.InnerText = IIf(bolBotonRegresar, "S", "N")
            oxml.SelectSingleNode("MENSAJE").AppendChild(nxml)


            If strLink <> "" And bolBotonRegresar Then
                nxml = oxml.CreateElement("LINK")
                nxml.InnerText = strLink
                oxml.SelectSingleNode("MENSAJE").AppendChild(nxml)

                If strParametros <> "" Then
                    nxml = oxml.CreateElement("PARAMETROS")
                    nxml.InnerText = strParametros
                    oxml.SelectSingleNode("MENSAJE").AppendChild(nxml)
                End If
            End If

            If strTextoLink <> "" Then
                nxml = oxml.CreateElement("TEXTOLINK")
                nxml.InnerText = strTextoLink
                oxml.SelectSingleNode("MENSAJE").AppendChild(nxml)
            End If

            BuildXMLMensaje = oxml
            oxml = Nothing
            nxml = Nothing
        End Function

        'Retorna un dataRow conteniendo el parametro general buscado dentro de una tabla de parametros generales.  
        'Parametros:
        '   dtParametros            -> tabla de parametros generales
        '   strColNombreParametro   -> Nombre de la columna donde se encuentra el nombre del parametro a buscar
        '   strNombreParametro      -> Nombre del parametro a buscar

        Public Shared Function GetParameterRow(ByVal dtParametros As DataTable, ByVal strColNombreParametro As String, ByVal strNombreParametro As String) As DataRow
            Dim i As Integer

            Try
                For i = 0 To dtParametros.Rows.Count - 1
                    If dtParametros.Rows(i).Item(strColNombreParametro) = strNombreParametro Then
                        Return dtParametros.Rows(i)
                    End If
                Next
                Return Nothing
            Catch
                Return Nothing
            End Try
        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="strNit"></param>
        ''' <param name="strMensaje"></param>
        ''' <returns></returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[jsamayoa]	20/08/2007	Created
        ''' 	[jsamayoa]	20/08/2007	Se agregó validadión de dígitos y letras
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Shared Function ValidaNit(ByVal strNit As String, ByRef strMensaje As String) As Boolean
            Dim suma As Integer
            Dim largo As Integer
            Dim indice As Integer
            Dim diferencia As Integer
            Dim digito As String
            Dim valor1 As Integer
            Dim valor2 As Integer
            Dim residuo As Integer
            Dim digitov As String
            'Esta variable es para los casos especiales de NIT que no usan digito verificador
            Dim NitEspecial As Boolean
            Dim strNitOriginal As String

            strNitOriginal = strNit

            digitov = Mid(strNit, Len(strNit), 1)
            strNit = Mid(strNit, 1, Len(strNit) - 1)

            NitEspecial = False
            If Not IsNumeric(strNit) Then
                '        strMensaje = "El nit debe ser numérico"
                '        ValidaNit = False
                '        Exit Function
                NitEspecial = True
            Else
                If InStr(strNitOriginal, "-") <> 0 Then
                    strMensaje = "El nit no debe incluir guión"
                    ValidaNit = False
                    Exit Function
                End If
            End If

            If Not NitEspecial Then
                If Not IsNumeric(digitov) Then
                    digitov = UCase(digitov)
                    If digitov <> "K" Then
                        strMensaje = "Nit inválido"
                        ValidaNit = False
                        Exit Function
                    End If
                End If

                largo = Len(strNit)
                indice = largo
                While indice <= largo And indice >= 1
                    valor1 = largo - indice + 2
                    valor2 = CInt(Mid(strNit, indice, 1))
                    suma = suma + valor2 * valor1
                    indice = indice - 1
                End While
                residuo = suma Mod 11
                diferencia = 11 - residuo

                If diferencia = 10 Then
                    digito = "K"
                ElseIf diferencia = 11 Then
                    digito = "0"
                Else
                    digito = CStr(diferencia)
                End If

                If digito <> digitov Then
                    strMensaje = "Nit inválido"
                    ValidaNit = False
                    Exit Function
                End If
            End If

            ValidaNit = True
        End Function


        Public Shared Function ValidarBrowser(ByVal mypage As System.Web.UI.Page) As String

            ValidarBrowser = ""
            If mypage.Request.Browser.Browser <> clsConstantes.C_BROWSER_TYPE Then
                ValidarBrowser = "El navegador que está utilizando no es Internet Explorer. Puede que algunas opciones de la aplicación no funcionen correctamente."
                Exit Function
            End If

            If Val(mypage.Request.Browser.MajorVersion & "." & mypage.Request.Browser.MinorVersion) < clsConstantes.C_BROWSER_VERSION Then
                ValidarBrowser = "La versión del navegador que está utilizando (" & _
                                 mypage.Request.Browser.MajorVersion & "." & mypage.Request.Browser.MinorVersion & _
                                 ") se encuentra desactualizada. Puede que algunas opciones del SIGESWeb no funcionen correctamente."
                Exit Function
            End If
        End Function

        ''' <summary>v1.0 by Roberto Lopez
        ''' Este metodo imprime un mensaje en pantalla
        ''' </summary>
        ''' <param name="pagina"></param>
        ''' este metodo sirve para identificar a que pagina pertenece el mensaje
        ''' <param name="mensaje"></param>
        ''' mensaje string
        ''' <remarks></remarks>
        Public Shared Sub MensajeJava(ByVal pagina As Page, ByVal mensaje As String, Optional ByVal EsScriptManager As Boolean = False)
            ''se genera el script que luego se va a registrar en la pantalla
            Dim s As String = "alert (' " & mensaje.Trim() & "');"
            ''genero un GUID que constituia el key de el java script registrado, si en lugar de usar este GUID usamos un nombre estatico no puede imprimir dos mensajes.
            Dim sGUID As String = System.Guid.NewGuid().ToString
            ''verifica que no existan repetidos.
            If (Not pagina.ClientScript.IsStartupScriptRegistered(pagina.GetType(), sGUID)) Then
                If Not EsScriptManager Then
                    pagina.ClientScript.RegisterStartupScript(pagina.GetType(), sGUID, s, True)
                Else
                    ScriptManager.RegisterStartupScript(pagina, pagina.GetType(), sGUID, s, True)
                End If
            End If
        End Sub

        ''' <summary>
        ''' Genera un script
        ''' </summary>
        ''' <param name="pagina"></param>
        ''' <param name="script"></param>
        ''' <param name="EsScriptManager"></param>
        ''' <remarks></remarks>
        Public Shared Sub ScriptJava(ByVal pagina As Page, ByVal script As String, Optional ByVal EsScriptManager As Boolean = False)
            ''genero un GUID que constituia el key de el java script registrado, si en lugar de usar este GUID usamos un nombre estatico no puede imprimir dos mensajes.
            Dim sGUID As String = System.Guid.NewGuid().ToString
            ''verifica que no existan repetidos.
            If (Not pagina.ClientScript.IsStartupScriptRegistered(pagina.GetType(), sGUID)) Then
                If Not EsScriptManager Then
                    pagina.ClientScript.RegisterStartupScript(pagina.GetType(), sGUID, script, True)
                Else
                    ScriptManager.RegisterStartupScript(pagina, pagina.GetType(), sGUID, script, True)
                End If
            End If
        End Sub

        ''' <summary>v1.0 by Roberto Lopez
        ''' Este metodo imprime un mensaje en el log de windows
        ''' </summary>
        ''' mensaje string
        ''' <remarks></remarks>
        ''' 
        Public Shared Sub MensajeLog(ByVal pSource As String, ByVal pMensaje As String, ByVal pCategoria As Integer, ByVal pSubCategoria As Short)
            Dim sLog As String
            Dim sMachine As String
            sLog = "SIGES"
            sMachine = "."
            Dim DataSource As EventSourceCreationData = New EventSourceCreationData(pSource, sMachine)
            DataSource.LogName = sLog
            Dim ELog As New EventLog(sLog, sMachine, pSource)
            ''Categoria= SIGES = 500
            ''Sub Categoria
            ELog.WriteEntry(pMensaje, EventLogEntryType.Error, pCategoria, pSubCategoria)
        End Sub

        Public Shared Function ValidaNOG(ByVal strNOG As String, ByRef strMensaje As String) As Boolean
            Dim suma As Integer
            Dim largo As Integer
            Dim indice As Integer
            Dim diferencia As Integer
            Dim digito As String
            Dim valor1 As Integer
            Dim valor2 As Integer
            Dim residuo As Integer
            Dim digitov As String

            strNOG = Trim(strNOG)
            If strNOG = "0" Then strNOG = "0000000000"

            'se separa el nog y el digito verificador
            digitov = Mid(strNOG, Len(strNOG), 1)
            strNOG = Mid(strNOG, 1, Len(strNOG) - 1)
            largo = Len(strNOG)
            indice = largo
            suma = 0

            'se verifica que el nog sea numerico
            If Not IsNumeric(strNOG) Then
                strMensaje = "El formato del NOG debe ser numerico" '-2
                ValidaNOG = False
                Exit Function
            End If

            While indice <= largo And indice >= 1
                valor1 = largo - indice + 2
                valor2 = CInt(Mid(strNOG, indice, 1))
                suma = suma + valor2 * valor1
                indice = indice - 1
            End While

            residuo = suma Mod 11
            diferencia = 11 - residuo

            If diferencia = 11 Then
                digito = "0"
            Else
                digito = CStr(diferencia)
            End If

            If digito <> digitov Then
                strMensaje = "El NOG no es valido (digito verificador incorrecto)" '-3
                ValidaNOG = False
                Exit Function
            End If

            ValidaNOG = True
        End Function


        Public Shared Function CantidadEnLetras(ByVal tyCantidad As Double) As String
            Dim lyCantidad As Double
            Dim lyCentavos As Double
            Dim lnDigito As Byte
            Dim lnPrimerDigito As Byte
            Dim lnSegundoDigito As Byte
            Dim lnTercerDigito As Byte
            Dim lcBloque As String = ""
            Dim lnNumeroBloques As Byte
            Dim lnBloqueCero As Byte
            Dim laUnidades(29) As String
            Dim laDecenas(9) As String
            Dim laCentenas(9) As String
            Dim i As Byte

            lyCantidad = Int(tyCantidad)
            lyCentavos = (tyCantidad - lyCantidad) * 100

            laUnidades(0) = "UN"
            laUnidades(1) = "DOS"
            laUnidades(2) = "TRES"
            laUnidades(3) = "CUATRO"
            laUnidades(4) = "CINCO"
            laUnidades(5) = "SEIS"
            laUnidades(6) = "SIETE"
            laUnidades(7) = "OCHO"
            laUnidades(8) = "NUEVE"
            laUnidades(9) = "DIEZ"
            laUnidades(10) = "ONCE"
            laUnidades(11) = "DOCE"
            laUnidades(12) = "TRECE"
            laUnidades(13) = "CATORCE"
            laUnidades(14) = "QUINCE"
            laUnidades(15) = "DIECISEIS"
            laUnidades(16) = "DIECISIETE"
            laUnidades(17) = "DIECIOCHO"
            laUnidades(18) = "DIECINUEVE"
            laUnidades(19) = "VEINTE"
            laUnidades(20) = "VEINTIUN"
            laUnidades(21) = "VEINTIDOS"
            laUnidades(22) = "VEINTITRES"
            laUnidades(23) = "VEINTICUATRO"
            laUnidades(24) = "VEINTICINCO"
            laUnidades(25) = "VEINTISEIS"
            laUnidades(26) = "VEINTISIETE"
            laUnidades(27) = "VEINTIOCHO"
            laUnidades(28) = "VEINTINUEVE"

            laDecenas(0) = "DIEZ"
            laDecenas(1) = "VEINTE"
            laDecenas(2) = "TREINTA"
            laDecenas(3) = "CUARENTA"
            laDecenas(4) = "CINCUENTA"
            laDecenas(5) = "SESENTA"
            laDecenas(6) = "SETENTA"
            laDecenas(7) = "OCHENTA"
            laDecenas(8) = "NOVENTA"

            laCentenas(0) = "CIENTO"
            laCentenas(1) = "DOSCIENTOS"
            laCentenas(2) = "TRESCIENTOS"
            laCentenas(3) = "CUATROCIENTOS"
            laCentenas(4) = "QUINIENTOS"
            laCentenas(5) = "SEISCIENTOS"
            laCentenas(6) = "SETECIENTOS"
            laCentenas(7) = "OCHOCIENTOS"
            laCentenas(8) = "NOVECIENTOS"

            lnNumeroBloques = 1
            Do
                lnPrimerDigito = 0
                lnSegundoDigito = 0
                lnTercerDigito = 0
                lcBloque = ""
                lnBloqueCero = 0
                For i = 1 To 3
                    lnDigito = lyCantidad Mod 10
                    If lnDigito <> 0 Then
                        Select Case i
                            Case 1
                                lcBloque = " " & laUnidades(lnDigito - 1)
                                lnPrimerDigito = lnDigito
                            Case 2
                                If lnDigito <= 2 Then
                                    lcBloque = " " & laUnidades((lnDigito * 10) + lnPrimerDigito - 1)
                                Else
                                    lcBloque = " " & laDecenas(lnDigito - 1) & IIf(lnPrimerDigito <> 0, " Y", "") & lcBloque
                                End If
                                lnSegundoDigito = lnDigito
                            Case 3
                                lcBloque = " " & IIf(lnDigito = 1 And lnPrimerDigito = 0 And lnSegundoDigito = 0, "CIEN", laCentenas(lnDigito - 1)) & lcBloque
                                lnTercerDigito = lnDigito
                        End Select
                    Else
                        lnBloqueCero = lnBloqueCero + 1
                    End If
                    lyCantidad = Int(lyCantidad / 10)
                    If lyCantidad = 0 Then
                        Exit For
                    End If
                Next i
                Select Case lnNumeroBloques
                    Case 1
                        CantidadEnLetras = lcBloque
                    Case 2
                        CantidadEnLetras = lcBloque & IIf(lnBloqueCero = 3, "", " MIL") & CantidadEnLetras(tyCantidad)
                    Case 3
                        CantidadEnLetras = lcBloque & IIf(lnPrimerDigito = 1 And lnSegundoDigito = 0 And lnTercerDigito = 0, " MILLON", " MILLONES") & CantidadEnLetras(tyCantidad)
                    Case Else
                        CantidadEnLetras = ""
                End Select
                lnNumeroBloques = lnNumeroBloques + 1
            Loop Until lyCantidad = 0
            CantidadEnLetras = CantidadEnLetras & IIf(tyCantidad > 1, " QUETZALES CON ", " QUETZAL CON ") & CStr(Format(lyCentavos, "00")) & "/100"
            Return ""
        End Function

        Public Shared Function BuscarValorEnLista(ByRef Lista As ListBox, ByVal Texto As String) As Boolean
            Dim Elemento As ListItem

            If Texto.Length > 0 Then
                Elemento = Lista.Items.FindByValue(Texto)
                If Not IsNothing(Elemento) Then
                    If Not IsNothing(Lista.SelectedItem) Then Lista.SelectedItem.Selected = False
                    Elemento.Selected = True
                Else
                    Lista.SelectedIndex = 0
                    Return (False)
                End If
            Else
                Lista.ClearSelection()
            End If
            Return (True)
        End Function

        'Permite Buscar y colocar en la Lista el valor correspondiente al contenido de Texto
        Public Shared Function BuscarValorEnLista(ByRef Lista As DropDownList, ByVal Texto As TextBox) As Boolean
            Dim Elemento As ListItem

            If Texto.Text <> "" Then
                Elemento = Lista.Items.FindByValue(Texto.Text)
                If Not IsNothing(Elemento) Then
                    If Not IsNothing(Lista.SelectedItem) Then Lista.SelectedItem.Selected = False
                    Elemento.Selected = True
                Else
                    If Lista.Items.Count > 0 Then Lista.SelectedIndex = 0
                    Return (False)
                End If
            Else
                Lista.ClearSelection()
            End If
            Return (True)
        End Function

        'Permite Buscar y colocar en la Lista el valor correspondiente al contenido de Texto
        Public Shared Function BuscarValorEnLista(ByRef Lista As RadComboBox, ByVal Texto As TextBox) As Boolean
            'Dim Elemento As ListItem

            If Texto.Text <> "" Then
                'Elemento = Lista.Items.FindItemByValue(Texto.Text)
                If Not IsNothing(Lista.Items.FindItemByValue(Texto.Text)) Then
                    If Not IsNothing(Lista.SelectedItem) Then Lista.SelectedItem.Selected = False
                    Lista.SelectedItem.Selected = True
                Else
                    If Lista.Items.Count > 0 Then Lista.SelectedIndex = 0
                    Return (False)
                End If
            Else
                Lista.ClearSelection()
            End If
            Return (True)
        End Function

        Public Shared Function BuscarTextoEnLista(ByRef Lista As DropDownList, ByVal Texto As String) As Boolean
            Dim Elemento As ListItem

            If Texto.Length > 0 AndAlso _
               Lista.Items.Count > 0 Then
                Elemento = Lista.Items.FindByText(Texto)
                If Not IsNothing(Elemento) Then
                    If Not IsNothing(Lista.SelectedItem) Then Lista.SelectedItem.Selected = False
                    Elemento.Selected = True
                Else
                    Lista.SelectedIndex = 0
                    Return (False)
                End If
            Else
                Lista.ClearSelection()
            End If
            Return (True)
        End Function

        Public Shared Function BuscarValorEnLista(ByRef Lista As DropDownList, ByVal Texto As String) As Boolean
            Dim Elemento As ListItem

            If Texto.Length > 0 AndAlso _
               Lista.Items.Count > 0 Then
                Elemento = Lista.Items.FindByValue(Texto)
                If Not IsNothing(Elemento) Then
                    If Not IsNothing(Lista.SelectedItem) Then Lista.SelectedItem.Selected = False
                    Elemento.Selected = True
                Else
                    Lista.SelectedIndex = 0
                    Return (False)
                End If
            Else
                Lista.ClearSelection()
            End If
            Return (True)
        End Function

        Public Shared Function BuscarValorEnLista(ByRef Lista As DropDownList, ByVal Texto As Integer) As Boolean
            Dim Elemento As ListItem

            Elemento = Lista.Items.FindByValue(CStr(Texto))
            If Not IsNothing(Elemento) Then
                If Not IsNothing(Lista.SelectedItem) Then Lista.SelectedItem.Selected = False
                Elemento.Selected = True
            Else
                Lista.SelectedIndex = 0
                Return (False)
            End If

            Return (True)
        End Function

        Public Shared Function BuscarValorEnLista(ByRef Lista As RadComboBox, ByVal Texto As String) As Boolean
            Dim Elemento As RadComboBoxItem

            Elemento = Lista.Items.FindItemByValue(Texto)
            If Not IsNothing(Elemento) Then
                If Not IsNothing(Lista.SelectedItem) Then Lista.SelectedItem.Selected = False
                Elemento.Selected = True
            Else
                Lista.SelectedIndex = 0
                Return (False)
            End If

            Return (True)
        End Function

        Public Shared Function BuscarValorEnListaByText(ByRef Lista As RadComboBox, ByVal Texto As String) As Boolean
            Dim Elemento As RadComboBoxItem

            Elemento = Lista.Items.FindItemByText(Texto)
            If Not IsNothing(Elemento) Then
                If Not IsNothing(Lista.SelectedItem) Then Lista.SelectedItem.Selected = False
                Elemento.Selected = True
            Else
                Lista.SelectedIndex = 0
                Return (False)
            End If

            Return (True)
        End Function

        Public Shared Sub AgregarElementoLista(ByRef Lista As DropDownList, ByVal valor As String, ByVal texto As String)
            Dim LstTemp As ListItem

            LstTemp = New ListItem
            LstTemp.Value = valor
            LstTemp.Text = texto
            Lista.Items.Add(LstTemp)
            LstTemp = Nothing
        End Sub

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Indica si ha sido marcada al menos un item de la lista
        ''' </summary>
        ''' <param name="Lista"></param>
        ''' <returns>True si existe al menos un item seleccionado, False en caso contrario</returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[jsamayoa]	24/08/2006	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Shared Function ItemsMarcados(ByVal Lista As ListItemCollection) As Boolean
            Dim i As Integer

            For i = 0 To Lista.Count - 1
                If Lista(i).Selected = True Then
                    Return True
                End If
            Next
            Return False
        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Retorna los valores de los items marcados separados por comas
        ''' </summary>
        ''' <param name="Lista"></param>
        ''' <returns></returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[jsamayoa]	24/08/2006	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Shared Function ConcatenacionItems(ByVal Lista As ListItemCollection) As String
            Dim i As Integer
            Dim strResult As New System.Text.StringBuilder

            For i = 0 To Lista.Count - 1
                If Lista(i).Selected = True Then
                    If strResult.Length > 0 Then strResult.Append(",")
                    strResult.Append(Lista(i).Value)
                End If
            Next
            Return strResult.ToString()
        End Function

        Public Shared Sub MoverItems(ByRef Origen As ListBox, ByRef Destino As ListBox, ByVal Numero As Boolean)
            Dim i As Integer
            Dim LstTmp As New ListItemCollection

            For i = 0 To Origen.Items.Count - 1
                If Origen.Items(i).Selected = True Then
                    LstTmp.Add(Origen.Items(i))
                End If
            Next
            For i = 0 To LstTmp.Count - 1
                Destino.Items.Insert(PosicionOrdenada(Destino, LstTmp(i), Numero), LstTmp(i))
                Origen.Items.Remove(LstTmp(i))
            Next
        End Sub

        Public Shared Function PosicionOrdenada(ByRef Lista As ListBox, ByRef Elemento As ListItem, ByVal Numero As Boolean) As Integer
            Dim i As Integer

            'Caso cuando no hay elementos
            If Lista.Items.Count = 0 Then Return 0

            'Buscando hasta encontrar un elemento con valor mayor al elemento que se desea insertar, para insertar de manera
            'ordenada
            For i = 0 To Lista.Items.Count - 1
                If Numero = True Then
                    If CDec(Lista.Items(i).Value) > CDec(Elemento.Value) Then Return i
                Else
                    If Lista.Items(i).Value > Elemento.Value Then Return i
                End If

            Next
            Return Lista.Items.Count
        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Funcion que sera utilizada para validar si la sesion del usuario ha expirado.
        ''' Con esto se controlara el error desplegado al vencerse la sesion.
        ''' </summary>
        ''' <param name="strUsuario"></param>
        ''' <returns></returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[cbarrera]	01/02/2007	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Shared Function ExpiroSesion(ByVal strUsuario As String) As Boolean
            If Trim(strUsuario).Equals("") Then Return True
            Return False
        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Valida que un texto pueda solo y únicamente contener números y letras
        ''' </summary>
        ''' <param name="texto"></param>
        ''' <param name="CampoVacio">Indica si puede ser válido que un texto venga vacío</param>
        ''' <returns></returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[jsamayoa]	20/08/2007	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Shared Function ValidarNumerosYLetras(ByVal texto As String, ByVal CampoVacio As Boolean) As Boolean
            Dim Caracter As Char
            If CampoVacio = False Then Caracter = "+" Else Caracter = "*"
            Dim Validador As New System.Text.RegularExpressions.Regex("^[a-z0-9]" & Caracter & "$", System.Text.RegularExpressions.RegexOptions.IgnoreCase)

            Return Validador.Match(texto).Success
        End Function

        Public Shared Function ValidarNumerosEnteros(ByVal texto As String, ByVal CampoVacio As Boolean) As Boolean
            Dim Caracter As Char
            If CampoVacio = False Then Caracter = "+" Else Caracter = "*"
            Dim Validador As New System.Text.RegularExpressions.Regex("^[0-9]" & Caracter & "$", System.Text.RegularExpressions.RegexOptions.IgnoreCase)

            Return Validador.Match(texto).Success
        End Function

        Public Shared Function PCase(ByVal strInput As String) As String
            Dim I As Integer
            Dim CurrentChar, PrevChar As Char
            Dim strOutput As String

            PrevChar = ""
            strOutput = ""

            For I = 1 To Len(strInput)
                CurrentChar = Mid(strInput, I, 1)

                Select Case PrevChar
                    Case "", ".", "-", ",", """", "'"
                        strOutput = strOutput & UCase(CurrentChar)
                    Case Else
                        strOutput = strOutput & LCase(CurrentChar)
                End Select
                PrevChar = CurrentChar
            Next I
            Return strOutput
        End Function

        Public Shared Sub TituloPantalla(ByVal ControlTitulo As ctrlTitulos.ctrlTitulos.ctrlTitulo, ByVal TextoTitulos As String)

            Dim arrTitulos() As String
            Dim i As Integer

            arrTitulos = Split(TextoTitulos, "-")
            For i = 0 To UBound(arrTitulos)
                ControlTitulo.AgregarTitulo(Trim(arrTitulos(i)))
            Next
            ControlTitulo.PathImagen = "../img/bullet.gif"
            ControlTitulo.Estilo = "titulopagina"
        End Sub

        '--------------------------------------------------------------------
        'RellenaStringLeft: Rellena un string con caracteres en la izquierda
        'JAGUILAR 14/10/2009 Creación
        Public Shared Function RellenaStringLeft(ByVal strCadena As String, _
                                          ByVal strRelleno As Char, _
                                          ByVal intLargo As Integer) As String
            Dim i As Integer
            Dim intCantidadRelleno As Integer


            intCantidadRelleno = intLargo - Len(strCadena)
            For i = 1 To intCantidadRelleno
                strCadena = strRelleno & strCadena
            Next

            RellenaStringLeft = strCadena

        End Function

        Public Shared Sub AgregarComentario(ByRef dsDatos As DataSet, ByVal NombreTabla As String, ByVal usuario As String, ByVal comentario As String, Optional ByVal id As Decimal = 0)

            Dim dt As New DataTable
            Dim dr As DataRow
            If Not dsDatos.Tables.Contains("NCA_COMENTARIO_OPERACION") Then
                dt.TableName = "NCA_COMENTARIO_OPERACION"
                dt.Columns.Add("TABLA", System.Type.GetType("System.String"))
                dt.Columns.Add("COMENTARIO", System.Type.GetType("System.Decimal"))
                dt.Columns.Add("ID_OPERACION", System.Type.GetType("System.Decimal"))
                dt.Columns.Add("USUARIO", System.Type.GetType("System.String"))
                dt.Columns.Add("FECHA", System.Type.GetType("System.DateTime"))
                dt.Columns.Add("ESTADO_OPERACION", System.Type.GetType("System.Decimal"))
                dt.Columns.Add("DESCRIPCION", System.Type.GetType("System.String"))
                dsDatos.Tables.Add(dt)
            Else
                dt = dsDatos.Tables("NCA_COMENTARIO_OPERACION")
            End If
            dr = dt.NewRow
            dr.Item("TABLA") = NombreTabla
            dr.Item("USUARIO") = usuario
            dr.Item("DESCRIPCION") = comentario

            'si se envia el id se agrega
            If id <> 0 Then
                dr.Item("ID_OPERACION") = id
            End If

            'dt.Rows.Add(dr)
            dsDatos.Tables(dt.TableName).Rows.Add(dr)

        End Sub

        'Permite Buscar y colocar en la Lista el valor correspondiente al Texto
        Public Shared Function BuscarValorEnListaTexto(ByVal Lista As DropDownList, ByVal Texto As String) As Boolean
            Dim i As Integer
            Dim found As Boolean = False
            If Texto <> "" Then
                For i = 0 To Lista.Items.Count - 1
                    If Lista.Items(i).Value = Texto Then
                        Lista.SelectedIndex = i
                        found = True
                        Exit For
                    End If
                Next i
                If Not (found) Then
                    Lista.SelectedIndex = 0
                    Return False
                End If
            Else
                Lista.SelectedIndex = 0
            End If
            Return True

        End Function

        Public Shared Function IsNull(ByVal obj As Object, ByVal def As Object) As Object
            If IsNothing(obj) Then
                Return def
            Else
                If IsDBNull(obj) Then
                    Return def
                End If
            End If

            Return obj
        End Function

        Public Shared Sub CargarDatosConfigToDS(ByVal pagina As Page)
            Dim dsDatos As DataSet = CType(pagina.Session("DATAROW"), DataSet)
            Dim dr As DataRow
            If dsDatos.Tables.Contains(clsConfiguracionNomina.tablaConfiguracion) Then _
                dsDatos.Tables.Remove(clsConfiguracionNomina.tablaConfiguracion)
            dsDatos.Tables.Add(clsConfiguracionNomina.tablaConfiguracion)
            With dsDatos.Tables(clsConfiguracionNomina.tablaConfiguracion)
                .Columns.Add("EJERCICIO", Type.GetType("System.Decimal"))
                .Columns.Add("ENTIDAD", Type.GetType("System.Decimal"))
                .Columns.Add("UNIDAD_EJECUTORA", Type.GetType("System.Decimal"))
                .Columns.Add("UNIDAD_DESCONCENTRADA", Type.GetType("System.Decimal"))
                .Columns.Add("CONFIG_NOMINA", Type.GetType("System.String"))

                dr = dsDatos.Tables(clsConfiguracionNomina.tablaConfiguracion).NewRow
                dr.Item("EJERCICIO") = CType(pagina.FindControl("EJERCICIO"), TextBox).Text
                dr.Item("ENTIDAD") = CType(pagina.FindControl("ENTIDAD"), TextBox).Text
                dr.Item("UNIDAD_EJECUTORA") = _
                    CType(pagina.Session("PARAMETROS"), XmlDocument).SelectSingleNode("PARAMETROS/PUNIDAD_EJECUTORA"). _
                        InnerText
                dr.Item("UNIDAD_DESCONCENTRADA") = CType(pagina.FindControl("UNIDAD_DESCONCENTRADA"), TextBox).Text
                dr.Item("CONFIG_NOMINA") = _
                    CType(pagina.Session("PARAMETROS"), XmlDocument).SelectSingleNode("PARAMETROS/PCONFIG_NOMINA"). _
                        InnerText
                .Rows.Add(dr)
            End With
        End Sub

        Public Shared Function validaEmpleadoEnClasesPasivas(ByVal empleado As Decimal) As Boolean
            Dim cadenaNombre As String = String.Empty
            Dim strsql As String
            Dim ws As New wsSIGES.DataRetrievalWCFClient(clsConstantes.EndPointSIGESGenerico)

            'cadenaNombre += IIf(IsDBNull(Primer_Nombre.Text), "", Primer_Nombre.Text)
            'cadenaNombre += IIf(IsDBNull(Segundo_Nombre.Text), "", Segundo_Nombre.Text)
            'cadenaNombre += IIf(IsDBNull(Tercer_nombre.Text), "", Tercer_nombre.Text)
            'If Not IsDBNull(.Item("APELLIDO_CASADA")) Then
            '    cadenaNombre += "DE"
            'End If            
            strsql = "select * from rrhh_jubilados where "
            strsql += "replace(upper(nombre_jubilado),' ','') = "
            strsql += "(select replace(upper(nombre_completo),' ','') from nrh_empleado where empleado=" & empleado & ")"
            strsql += "and estado_jubilado = 'A'"
            ws.Open()
            Dim dsJubilados As DataSet = ws.getDatabySQL(strsql, False, "<p></p>", "rrhh_jubilados")
            ws.Close()
            If dsJubilados.Tables.Count > 0 Then
                If dsJubilados.Tables(0).Rows.Count > 0 Then
                    Return True
                End If
            End If
            Return False
        End Function
    End Class



End Namespace
