Imports CyberSource
Imports UPSShippingRates
Public Class Payment
    Inherits System.Web.UI.Page
    Public ldblShippingPublishedRate As Double = 0.0
    Public ldblSubTotal As Double = 0.0
    Public lstrCartItems As String = ""
    Public lstrShippingMethod As String = ""


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    '*  0 : Check to see if a session is set up and if not do so now.
    If (Session("Id") = "") Then
        Response.Redirect("Home.aspx")
    End If

    '*  1 : Define the local variables to be used here now.
    Dim lblnReturnCode As Boolean = False
    Dim ldsShippingRateDataSet As DataSet
    Dim lobjShippingRate As New UPSShippingRates.UPSShippingRates
    Dim lobjDatabaseConnection As New SqlClient.SqlConnection
    Dim lobjDatabaseCommand As New SqlClient.SqlCommand
    Dim lobjDatabaseReader As SqlClient.SqlDataReader

    '*  2 : Start by making the connection to the database for accessing the system.        
    lobjDatabaseConnection.ConnectionString = "Data Source=storefrontdb001;Initial Catalog=StoreFront;Persist Security Info=True;User ID=sa;Password=hdvGL15?Valtim"
    lobjDatabaseConnection.Open()
    lobjDatabaseCommand.Connection = lobjDatabaseConnection

    '*  3 : Fetch all items in the cart here now.
    lobjDatabaseCommand.CommandTimeout = 0
    lobjDatabaseCommand.CommandText = "SELECT site.Items.ItemGroup, site.Items.BrandName, session.TempLineItems.Quantity, session.TempLineItems.ItemPrice, session.TempLineItems.ExtPrice, Site.Items.ThumbnailImage, session.TempLineItems.TempLineItemID, ISNULL(site.Items.Dimensions, '') AS Dimensions FROM session.TempOrders WITH (NOLOCK) INNER JOIN session.TempLineItems WITH (NOLOCK) ON session.TempOrders.TempOrderID = session.TempLineItems.TempOrderID INNER JOIN site.Items WITH (NOLOCK) ON session.TempLineItems.ItemID = site.Items.ItemID WHERE (session.TempOrders.SessionID = " & Session("Id") & ")"
    lobjDatabaseReader = lobjDatabaseCommand.ExecuteReader
    lstrCartItems = ""
    Do While (lobjDatabaseReader.Read())
        lstrCartItems = lstrCartItems + "<tr style=""text-align: left; vertical-align:top; border: 0px; padding: 0px; margin: 0px; border-width: 0px; background-repeat: repeat;"">"
        lstrCartItems = lstrCartItems + "<td style=""width:25%;"">"
        lstrCartItems = lstrCartItems + "<img src=""" & lobjDatabaseReader.GetValue(5) & """ style=""width: 100%; height: auto;text-decoration: none""/><br />"
        lstrCartItems = lstrCartItems + "</td>"
        lstrCartItems = lstrCartItems + "<td style=""text-align: left; vertical-align:top; width: 10px; padding: 0px; margin: 0px;""></td>"
        lstrCartItems = lstrCartItems + "<td style=""text-align: left; vertical-align:top; width: 45%; padding: 0px; margin: 0px;"">"
        lstrCartItems = lstrCartItems + "<table border=""0"" style=""width:100%;"">"
        lstrCartItems = lstrCartItems + "<tr style=""height:120px;vertical-align:top;"">"
        lstrCartItems = lstrCartItems + "<td>"
        lstrCartItems = lstrCartItems + "<label for=""label2"" style=""font-family:'Open Sans', Helvetica, sans-serif;font-weight:300;font-size:125%;color: #044C86;text-decoration: none;"">" & lobjDatabaseReader.GetValue(0) & "</label><br />"
        lstrCartItems = lstrCartItems + "<label for=""label2"" style=""font-family:'Open Sans', Helvetica, sans-serif;font-weight:300;font-size:75%;color: grey; text-decoration: none;"">Design : </label>"
        lstrCartItems = lstrCartItems + "<label for=""label2"" style=""font-family:'Open Sans', Helvetica, sans-serif;font-weight:300;font-size:90%;color: #044C86; text-decoration: none;"">" & lobjDatabaseReader.GetValue(1) & "</label> "
        If (lobjDatabaseReader.GetValue(7) <> "") Then
            lstrCartItems = lstrCartItems + "<br><label for=""label2"" style=""font-family:'Open Sans', Helvetica, sans-serif;font-weight:300;font-size:75%;color: grey; text-decoration: none;"">Size </label>"
            lstrCartItems = lstrCartItems + "<label for=""label2"" style=""font-family:'Open Sans', Helvetica, sans-serif;font-weight:300;font-size:90%;color: #044C86; text-decoration: none;"">" & lobjDatabaseReader.GetValue(7) & "</label> "
        End If
        lstrCartItems = lstrCartItems + "<br><label for=""label2"" style=""font-family:'Open Sans', Helvetica, sans-serif;font-weight:300;font-size:75%;color: grey; text-decoration: none;"">Quantity </label>"
        lstrCartItems = lstrCartItems + "<label for=""label2"" style=""font-family:'Open Sans', Helvetica, sans-serif;font-weight:300;font-size:90%;color: #044C86; text-decoration: none;"">" & lobjDatabaseReader.GetValue(2) & "</label> "
        lstrCartItems = lstrCartItems + "</td>"
        lstrCartItems = lstrCartItems + "</tr>"
        lstrCartItems = lstrCartItems + "</table>"
        lstrCartItems = lstrCartItems + "</td>"
        lstrCartItems = lstrCartItems + "<td style=""text-align: right; vertical-align:top; width: 25%; padding: 0px; margin: 0px;"">"
        lstrCartItems = lstrCartItems + "<table border=""0"" style=""width:100%;"">"
        lstrCartItems = lstrCartItems + "<tr>"
        lstrCartItems = lstrCartItems + "<td style=""vertical-align:top;""></td>"
        lstrCartItems = lstrCartItems + "<td style=""width:60px;height; 30px;vertical-align:top;"">"
        lstrCartItems = lstrCartItems + "<label for=""label2"" style=""font-family:'Open Sans', Helvetica, sans-serif;font-weight:300;font-size:100%;color: black;text-decoration: none;"">" & FormatCurrency(lobjDatabaseReader.GetValue(4), 2) & "</label>"
        lstrCartItems = lstrCartItems + "</td>"
        lstrCartItems = lstrCartItems + "</tr>"
        lstrCartItems = lstrCartItems + "</table>"
        lstrCartItems = lstrCartItems + "</td>"
        lstrCartItems = lstrCartItems + "</tr>"
        ldblSubTotal = (ldblSubTotal + lobjDatabaseReader.GetValue(4))
    Loop
    lobjDatabaseReader.Close()

    '*  4 : Fetch all items in the cart here now.
    If Not (IsPostBack) Then
        lobjDatabaseCommand.CommandTimeout = 0
        lobjDatabaseCommand.CommandText = "SELECT session.TempLineItems.ShipAddress1, session.TempLineItems.ShipCity, session.TempLineItems.ShipState, session.TempLineItems.ShipZip, session.TempLineItems.ShipMethod, SUM(site.Items.Weight * session.TempLineItems.Quantity) AS Weight FROM session.TempLineItems WITH (NOLOCK) INNER JOIN session.TempOrders WITH (NOLOCK) ON session.TempLineItems.TempOrderID = session.TempOrders.TempOrderID INNER JOIN site.Items ON session.TempLineItems.ItemID = site.Items.ItemID WHERE (Session.TempOrders.SessionID = " & Session("Id") & ") GROUP BY session.TempLineItems.ShipAddress1, session.TempLineItems.ShipCity, session.TempLineItems.ShipState, session.TempLineItems.ShipZip, session.TempLineItems.ShipMethod"
        lobjDatabaseReader = lobjDatabaseCommand.ExecuteReader
        If (lobjDatabaseReader.Read()) Then
            If (UCase(lobjDatabaseReader.GetValue(4)) <> "UPS MAIL INNOVATIONS") Then
                lobjShippingRate.Weight = lobjDatabaseReader.GetValue(5)
                lobjShippingRate.AddressLine1 = lobjDatabaseReader.GetValue(0)
                lobjShippingRate.City = lobjDatabaseReader.GetValue(1)
                lobjShippingRate.State = lobjDatabaseReader.GetValue(2)
                lobjShippingRate.Zip = lobjDatabaseReader.GetValue(3)
                lstrShippingMethod = UCase(lobjDatabaseReader.GetValue(4))
                Select Case UCase(lobjDatabaseReader.GetValue(4))
                    Case "UPS GROUND"
                        lobjShippingRate.ServiceCode = "03"
                        lstrShippingMethod = "UPS GROUND"
                    Case "UPS NEXT DAY"
                        lobjShippingRate.ServiceCode = "01"
                        lstrShippingMethod = "UPS NEXT DAY"
                    Case "UPS SURE POST"
                        lobjShippingRate.ServiceCode = "93"
                        lstrShippingMethod = "UPS SUPER SAVER"
                End Select

                '*  Code for remote web service hosted on box that can support ssl 2.0 requirements of UPS
                'Dim strResult As String
                'Dim objResponse As System.Net.WebResponse
                'Dim objRequest As System.Net.WebRequest = System.Net.HttpWebRequest.Create("http://marketing.valtim.com/Ship.aspx?SessionId=" & Session("Id") & "&Weight=" & lobjShippingRate.Weight & "&Address=" & lobjShippingRate.AddressLine1 & "&City=" & lobjShippingRate.City & "&State=" & lobjShippingRate.State & "&Zip=" & lobjShippingRate.Zip & "&Method=" & lobjShippingRate.ServiceCode)
                'objResponse = objRequest.GetResponse()
                'Using sr As New System.IO.StreamReader(objResponse.GetResponseStream())
                'strResult = sr.ReadToEnd()
                'sr.Close()
                'End Using
                'ldblShippingPublishedRate = CDbl(Trim(Left(strResult.ToString, InStr(strResult.ToString, "<") - 1)))

                Try
                    ldsShippingRateDataSet = lobjShippingRate.GetRate()
                Catch lexcException As Exception
                    Response.Write(lexcException.Message)
                    Response.End()
                End Try
                ldblShippingPublishedRate = CDbl(ldsShippingRateDataSet.Tables(0).Rows(0).Item("PublishedRate").ToString)
            Else
                If (ldblSubTotal <= 3.5) Then
                    ldblShippingPublishedRate = 1.99
                Else
                    ldblShippingPublishedRate = 3.0
                End If
                lstrShippingMethod = "UPS SUPER SAVER"
            End If
            Session.Add("ShippingFee", ldblShippingPublishedRate)
            Session.Add("ShippingMethod", lstrShippingMethod)
            lobjDatabaseReader.Close()
            lobjDatabaseCommand.CommandTimeout = 0
            lobjDatabaseCommand.CommandText = "UPDATE session.TempOrders SET ShippingTotal = " & ldblShippingPublishedRate & " WHERE (session.TempOrders.SessionID = " & Session("Id") & ")"
            lobjDatabaseCommand.ExecuteNonQuery()
        Else
            lobjDatabaseReader.Close()
        End If
    Else
        ldblShippingPublishedRate = Session("ShippingFee")
        lstrShippingMethod = Session("ShippingMethod")
    End If

    '*  5 : Fetch all stored payment information here now.
    lobjDatabaseCommand.CommandTimeout = 0
    lobjDatabaseCommand.CommandText = "Select BillName, CCNum, CCMonth, CCYear, CCCV, BillFirstName, BillLastName, BillAddress1, BillCity, BillState, BillZip, Employer, Occupation FROM session.TempOrders WITH (nolock) INNER JOIN session.TempPayments WITH (nolock) ON session.TempOrders.TempOrderID = session.TempPayments.TempOrderID WHERE (Session.TempOrders.SessionID = " & Session("Id") & ")"
    lobjDatabaseReader = lobjDatabaseCommand.ExecuteReader
    If (lobjDatabaseReader.Read()) Then
        'Me.txtPayByNameOnCard.Text = lobjDatabaseReader.GetValue(0)
        'Me.txtPayByCardNumber.Text = lobjDatabaseReader.GetValue(1)
        'Me.drpPayByCardExpMonth.SelectedValue = lobjDatabaseReader.GetValue(2)
        'Me.drpPayByCardExpYear.SelectedValue = lobjDatabaseReader.GetValue(3)
        'Me.txtPayByCardCV.Text = lobjDatabaseReader.GetValue(4)
        Me.txtShipToFirstName.Text = lobjDatabaseReader.GetValue(5)
        Me.txtShipToLastName.Text = lobjDatabaseReader.GetValue(6)
        Me.txtShipToAddress.Text = lobjDatabaseReader.GetValue(7)
        Me.txtShipToCity.Text = lobjDatabaseReader.GetValue(8)
        Me.drpShipToState.SelectedValue = lobjDatabaseReader.GetValue(9)
        Me.txtShipToZipCode.Text = lobjDatabaseReader.GetValue(10)
        Me.txtPayByEmployer.Text = lobjDatabaseReader.GetValue(11)
        Me.txtPayByOccupation.Text = lobjDatabaseReader.GetValue(12)
    End If
    lobjDatabaseReader.Close()

    '*  5 : Close out the database connection, command and reader here now.
    lobjDatabaseCommand.Dispose()
    lobjDatabaseConnection.Close()
    lobjDatabaseConnection.Dispose()

    End Sub

Private Sub btnConfirm_Click(sender As Object, e As EventArgs) Handles btnConfirm.Click

    '*  1 : Validate the local boxes before allowing to advance here now.
    Me.txtPayByNameOnCard.BorderColor = Drawing.Color.LightGray
    Me.txtPayByCardNumber.BorderColor = Drawing.Color.LightGray
    Me.drpPayByCardExpMonth.BorderColor = Drawing.Color.LightGray
    Me.drpPayByCardExpYear.BorderColor = Drawing.Color.LightGray
    Me.txtPayByCardCV.BorderColor = Drawing.Color.LightGray
    Me.txtShipToFirstName.BorderColor = Drawing.Color.LightGray
    Me.txtShipToLastName.BorderColor = Drawing.Color.LightGray
    Me.txtShipToAddress.BorderColor = Drawing.Color.LightGray
    Me.txtShipToCity.BorderColor = Drawing.Color.LightGray
    Me.drpShipToState.BorderColor = Drawing.Color.LightGray
    Me.txtShipToZipCode.BorderColor = Drawing.Color.LightGray
    Me.txtPayByEmployer.BorderColor = Drawing.Color.LightGray
    Me.txtPayByOccupation.BorderColor = Drawing.Color.LightGray
    If (Me.txtPayByNameOnCard.Text = "") Then
        Me.txtPayByNameOnCard.BorderColor = Drawing.Color.Red
        Me.txtPayByNameOnCard.Focus()
        Exit Sub
    End If
    If (Me.txtPayByCardNumber.Text = "") Then
        Me.txtPayByCardNumber.BorderColor = Drawing.Color.Red
        Me.txtPayByCardNumber.Focus()
        Exit Sub
    End If
    If (Me.drpPayByCardExpMonth.SelectedValue = "") Then
        Me.drpPayByCardExpMonth.BorderColor = Drawing.Color.Red
        Me.drpPayByCardExpMonth.Focus()
        Exit Sub
    End If
    If (Me.drpPayByCardExpYear.SelectedValue = "") Then
        Me.drpPayByCardExpYear.BorderColor = Drawing.Color.Red
        Me.drpPayByCardExpYear.Focus()
        Exit Sub
    End If
    If (Me.txtPayByCardCV.Text = "") Then
        Me.txtPayByCardCV.BorderColor = Drawing.Color.Red
        Me.txtPayByCardCV.Focus()
        Exit Sub
    End If
    If (Me.txtShipToFirstName.Text = "") Then
        Me.txtShipToFirstName.BorderColor = Drawing.Color.Red
        Me.txtShipToFirstName.Focus()
        Exit Sub
    End If
    If (Me.txtShipToLastName.Text = "") Then
        Me.txtShipToLastName.BorderColor = Drawing.Color.Red
        Me.txtShipToLastName.Focus()
        Exit Sub
    End If
    If (Me.txtShipToAddress.Text = "") Then
        Me.txtShipToAddress.BorderColor = Drawing.Color.Red
        Me.txtShipToAddress.Focus()
        Exit Sub
    End If
    If (Me.txtShipToCity.Text = "") Then
        Me.txtShipToCity.BorderColor = Drawing.Color.Red
        Me.txtShipToCity.Focus()
        Exit Sub
    End If
    If (Me.drpShipToState.SelectedValue = "") Then
        Me.drpShipToState.BorderColor = Drawing.Color.Red
        Me.drpShipToState.Focus()
        Exit Sub
    End If
    If (Me.txtShipToZipCode.Text = "") Then
        Me.txtShipToZipCode.BorderColor = Drawing.Color.Red
        Me.txtShipToZipCode.Focus()
        Exit Sub
    End If
    If (Me.txtPayByEmployer.Text = "") Then
        Me.txtPayByEmployer.BorderColor = Drawing.Color.Red
        Me.txtPayByEmployer.Focus()
        Exit Sub
    End If
    If (Me.txtPayByOccupation.Text = "") Then
        Me.txtPayByOccupation.BorderColor = Drawing.Color.Red
        Me.txtPayByOccupation.Focus()
        Exit Sub
    End If

    '*  2 : Define the local variables to be used here now.
    Dim lblnReturnCode As Boolean = False
    Dim llngTempOrderId As Long = 0
    Dim llngTempPaymentId As Long = 0
    Dim lobjDatabaseConnection As New SqlClient.SqlConnection
    Dim lobjDatabaseCommand As New SqlClient.SqlCommand
    Dim lobjDatabaseReader As SqlClient.SqlDataReader

    '*  3 : Start by making the connection to the database for accessing the system
    lobjDatabaseConnection.ConnectionString = "Data Source=storefrontdb001;Initial Catalog=StoreFront;Persist Security Info=True;User ID=sa;Password=hdvGL15?Valtim"
    lobjDatabaseConnection.Open()
    lobjDatabaseCommand.Connection = lobjDatabaseConnection

    '*  4 : Start by fetching the promotional banner that need to be run first
    lobjDatabaseCommand.CommandTimeout = 0
    lobjDatabaseCommand.CommandText = "SELECT ISNULL(session.TempPayments.TempPaymentID, 0) AS TempPaymentID, session.TempOrders.TempOrderID FROM session.TempOrders WITH (nolock) LEFT OUTER JOIN session.TempPayments WITH (nolock) ON session.TempOrders.TempOrderID = session.TempPayments.TempOrderID WHERE (Session.TempOrders.SessionID = " & Session("Id") & ")"
    lobjDatabaseReader = lobjDatabaseCommand.ExecuteReader
    If (lobjDatabaseReader.Read()) Then
        llngTempPaymentId = lobjDatabaseReader.GetValue(0)
        llngTempOrderId = lobjDatabaseReader.GetValue(1)
    End If
    lobjDatabaseReader.Close()
    If (llngTempPaymentId > 0) Then
        lobjDatabaseCommand.CommandText = "UPDATE session.TempPayments SET BillName = '" & Replace(Me.txtPayByNameOnCard.Text, "'", "''") & "', CCNum = '" & Replace(Me.txtPayByCardNumber.Text, "'", "''") & "', CCMonth = '" & Replace(Me.drpPayByCardExpMonth.SelectedValue, "'", "''") & "', CCYear = '" & Replace(Me.drpPayByCardExpYear.SelectedValue, "'", "''") & "', CCCV = '" & Replace(Me.txtPayByCardCV.Text, "'", "''") & "', BillFirstName = '" & Replace(Me.txtShipToFirstName.Text, "'", "''") & "', BillLastName = '" & Replace(Me.txtShipToLastName.Text, "'", "''") & "', BillAddress1 = '" & Replace(Me.txtShipToAddress.Text, "'", "''") & "', BillCity = '" & Replace(Me.txtShipToCity.Text, "'", "''") & "', BillState = '" & Replace(Me.drpShipToState.SelectedValue, "'", "''") & "', BillZip = '" & Replace(Me.txtShipToZipCode.Text, "'", "''") & "', Employer = '" & Replace(Me.txtPayByEmployer.Text, "'", "''") & "', Occupation = '" & Replace(Me.txtPayByOccupation.Text, "'", "''") & "' WHERE session.TempPayments.TempPaymentID = " & llngTempPaymentId
    Else
        lobjDatabaseCommand.CommandText = "INSERT INTO session.TempPayments (TempOrderID, BillName, CCNum, CCMonth, CCYear, CCCV, BillFirstName, BillLastName, BillAddress1, BillCity, BillState, BillZip, Employer, Occupation) VALUES (" & llngTempOrderId & ", '" & Replace(Me.txtPayByNameOnCard.Text, "'", "''") & "', '" & Replace(Me.txtPayByCardNumber.Text, "'", "''") & "', '" & Replace(Me.drpPayByCardExpMonth.SelectedValue, "'", "''") & "', '" & Replace(Me.drpPayByCardExpYear.SelectedValue, "'", "''") & "', '" & Replace(Me.txtPayByCardCV.Text, "'", "''") & "', '" & Replace(Me.txtShipToFirstName.Text, "'", "''") & "', '" & Replace(Me.txtShipToLastName.Text, "'", "''") & "', '" & Replace(Me.txtShipToAddress.Text, "'", "''") & "', '" & Replace(Me.txtShipToCity.Text, "'", "''") & "', '" & Replace(Me.drpShipToState.SelectedValue, "'", "''") & "', '" & Replace(Me.txtShipToZipCode.Text, "'", "''") & "', '" & Replace(Me.txtPayByEmployer.Text, "'", "''") & "', '" & Replace(Me.txtPayByOccupation.Text, "'", "''") & "')"
    End If
    lobjDatabaseCommand.ExecuteNonQuery()

    '*  5 : Close out the database connection, command and reader here now.
    lobjDatabaseCommand.Dispose()
    lobjDatabaseConnection.Close()
    lobjDatabaseConnection.Dispose()
    Response.Redirect("Confirm.aspx")

End Sub

Private Sub btnShipping_Click(sender As Object, e As EventArgs) Handles btnShipping.Click

Response.Redirect("Shipping.aspx")

End Sub

Protected Sub chkSameShipToAndBillTo_CheckedChanged(sender As Object, e As EventArgs) Handles chkSameShipToAndBillTo.CheckedChanged

    '*  1 : Define the local variables to be used here now.
    Dim lobjDatabaseConnection As New SqlClient.SqlConnection
    Dim lobjDatabaseCommand As New SqlClient.SqlCommand
    Dim lobjDatabaseReader As SqlClient.SqlDataReader

    '*  2 : Start by making the connection to the database for accessing the system.        
    lobjDatabaseConnection.ConnectionString = "Data Source=storefrontdb001;Initial Catalog=StoreFront;Persist Security Info=True;User ID=sa;Password=hdvGL15?Valtim"
    lobjDatabaseConnection.Open()
    lobjDatabaseCommand.Connection = lobjDatabaseConnection

    '*  3 : Fetch ship to data to carry over to bill to data.
    If (Me.chkSameShipToAndBillTo.Checked) Then
        lobjDatabaseCommand.CommandTimeout = 0
        lobjDatabaseCommand.CommandText = "Select DISTINCT Session.TempLineItems.ShipFirstName,  Session.TempLineItems.ShipLastName, Session.TempLineItems.ShipAddress1, Session.TempLineItems.ShipCity, Session.TempLineItems.ShipState, Session.TempLineItems.ShipZip FROM session.TempLineItems WITH (NOLOCK) INNER JOIN session.TempOrders WITH (NOLOCK) ON session.TempLineItems.TempOrderID = session.TempOrders.TempOrderID WHERE (session.TempOrders.SessionID = " & Session("Id") & ")"
        lobjDatabaseReader = lobjDatabaseCommand.ExecuteReader
        If (lobjDatabaseReader.Read()) Then
            Me.txtShipToFirstName.Text = lobjDatabaseReader.GetValue(0)
            Me.txtShipToLastName.Text = lobjDatabaseReader.GetValue(1)
            Me.txtShipToAddress.Text = lobjDatabaseReader.GetValue(2)
            Me.txtShipToCity.Text = lobjDatabaseReader.GetValue(3)
            Me.drpShipToState.SelectedValue = lobjDatabaseReader.GetValue(4)
            Me.txtShipToZipCode.Text = lobjDatabaseReader.GetValue(5)
        End If
        lobjDatabaseReader.Close()
    Else
        Me.txtShipToFirstName.Text = ""
        Me.txtShipToLastName.Text = ""
        Me.txtShipToAddress.Text = ""
        Me.txtShipToCity.Text = ""
        Me.drpShipToState.SelectedValue = ""
        Me.txtShipToZipCode.Text = ""
    End If

    '*  5 : Close out the database connection, command and reader here now.
    lobjDatabaseCommand.Dispose()
    lobjDatabaseConnection.Close()
    lobjDatabaseConnection.Dispose()

End Sub
End Class