Public Class Shipping
    Inherits System.Web.UI.Page
    Public lstrCartItems As String = ""
    Public ldblSubTotal As Double = 0.0

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    '*  0 : Check to see if a session is set up and if not do so now.
    If (Session("Id") = "") Then
        Response.Redirect("Home.aspx")
    End If

    '*  1 : Define the local variables to be used here now.
    Dim lblnReturnCode As Boolean = False
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

    '*  4 : Fetch the current weight of all items in the cart here.
    If Not (IsPostBack) Then
        lobjDatabaseCommand.CommandTimeout = 0
        lobjDatabaseCommand.CommandText = "SELECT SUM(site.Items.Weight * session.TempLineItems.Quantity) AS TotalWeight FROM session.TempOrders WITH (nolock) INNER JOIN session.TempLineItems WITH (nolock) ON session.TempOrders.TempOrderID = session.TempLineItems.TempOrderID INNER JOIN site.Items WITH (nolock) ON session.TempLineItems.ItemID = site.Items.ItemID GROUP BY session.TempOrders.SessionID HAVING (session.TempOrders.SessionID = " & Session("Id") & ")"
        lobjDatabaseReader = lobjDatabaseCommand.ExecuteReader
        If (lobjDatabaseReader.Read()) Then
            Session.Add("Weight", lobjDatabaseReader.GetValue(0))
            Me.drpShipToMethod.Items.Clear()
            Me.drpShipToMethod.Items.Add("")
            If (lobjDatabaseReader.GetValue(0) < 1.0) Then
                Me.drpShipToMethod.Items.Add("UPS Super Saver")
            End If
            If (lobjDatabaseReader.GetValue(0) >= 1.0) And (lobjDatabaseReader.GetValue(0) <= 9.0) Then
                Me.drpShipToMethod.Items.Add("UPS Super Saver")
            End If
            Me.drpShipToMethod.Items.Add("UPS Ground")
            Me.drpShipToMethod.Items.Add("UPS Next Day")
        End If
        lobjDatabaseReader.Close()

        '*  4 : Fetch all items in the cart here now.
        lobjDatabaseCommand.CommandTimeout = 0
        lobjDatabaseCommand.CommandText = "Select DISTINCT Session.TempOrders.SessionID, ISNULL(Session.TempLineItems.ShipFirstName, '') AS ShipFirstName, Session.TempLineItems.ShipLastName, Session.TempLineItems.ShipEmail, Session.TempLineItems.ShipPhone, Session.TempLineItems.ShipAddress1, Session.TempLineItems.ShipCity, Session.TempLineItems.ShipState, Session.TempLineItems.ShipZip, Session.TempLineItems.ShipMethod FROM session.TempLineItems WITH (NOLOCK) INNER JOIN session.TempOrders WITH (NOLOCK) ON session.TempLineItems.TempOrderID = session.TempOrders.TempOrderID WHERE (session.TempOrders.SessionID = " & Session("Id") & ")"
        lobjDatabaseReader = lobjDatabaseCommand.ExecuteReader
        If (lobjDatabaseReader.Read()) Then
            If (lobjDatabaseReader.GetValue(1) <> "") Then
                Me.txtShipToFirstName.Text = lobjDatabaseReader.GetValue(1)
                Me.txtShipToLastName.Text = lobjDatabaseReader.GetValue(2)
                Me.txtShipToAddress.Text = lobjDatabaseReader.GetValue(5)
                Me.txtShipToCity.Text = lobjDatabaseReader.GetValue(6)
                Me.drpShipToState.SelectedValue = lobjDatabaseReader.GetValue(7)
                Me.txtShipToEmailAddress.Text = lobjDatabaseReader.GetValue(3)
                Me.txtShipToPhone.Text = lobjDatabaseReader.GetValue(4)
                Me.txtShipToZipCode.Text = lobjDatabaseReader.GetValue(8)
                Select Case UCase(lobjDatabaseReader.GetValue(9))
                    Case "UPS SURE POST", "UPS MAIL INNOVATIONS"
                        Me.drpShipToMethod.SelectedValue = "UPS Super Saver"
                    Case Else
                        Me.drpShipToMethod.SelectedValue = lobjDatabaseReader.GetValue(9)
                End Select
                Me.drpShipToMethod.SelectedValue = lobjDatabaseReader.GetValue(9)
            End If
        End If
        lobjDatabaseReader.Close()
    End If

    '*  4 : Close out the database connection, command and reader here now.
    lobjDatabaseCommand.Dispose()
    lobjDatabaseConnection.Close()
    lobjDatabaseConnection.Dispose()

    End Sub

Private Sub btnPayment_Click(sender As Object, e As EventArgs) Handles btnPayment.Click

    '*  1 : Validate the local boxes before allowing to advance here now.
    Me.txtShipToFirstName.BorderColor = Drawing.Color.LightGray
    Me.txtShipToLastName.BorderColor = Drawing.Color.LightGray
    Me.txtShipToAddress.BorderColor = Drawing.Color.LightGray
    Me.txtShipToCity.BorderColor = Drawing.Color.LightGray
    Me.drpShipToState.BorderColor = Drawing.Color.LightGray
    Me.txtShipToEmailAddress.BorderColor = Drawing.Color.LightGray
    Me.txtShipToPhone.BorderColor = Drawing.Color.LightGray
    Me.txtShipToZipCode.BorderColor = Drawing.Color.LightGray
    Me.drpShipToMethod.BorderColor = Drawing.Color.LightGray
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
    If (Me.txtShipToEmailAddress.Text = "") Then
        Me.txtShipToEmailAddress.BorderColor = Drawing.Color.Red
        Me.txtShipToEmailAddress.Focus()
        Exit Sub
    End If
    If (Me.txtShipToPhone.Text = "") Then
        Me.txtShipToPhone.BorderColor = Drawing.Color.Red
        Me.txtShipToPhone.Focus()
        Exit Sub
    End If
    If (Me.drpShipToMethod.SelectedValue = "") Then
        Me.drpShipToMethod.BorderColor = Drawing.Color.Red
        Me.drpShipToMethod.Focus()
        Exit Sub
    End If

    '*  2 : Define the local variables to be used here now.
    Dim lblnReturnCode As Boolean = False
    Dim lobjDatabaseConnection As New SqlClient.SqlConnection
    Dim lobjDatabaseWriterConnection As New SqlClient.SqlConnection
    Dim lobjDatabaseCommand As New SqlClient.SqlCommand
    Dim lobjDatabaseWriterCommand As New SqlClient.SqlCommand
    Dim lobjDatabaseReader As SqlClient.SqlDataReader

    '*  3 : Start by making the connection to the database for accessing the system.        
    lobjDatabaseConnection.ConnectionString = "Data Source=storefrontdb001;Initial Catalog=StoreFront;Persist Security Info=True;User ID=sa;Password=hdvGL15?Valtim"
    lobjDatabaseConnection.Open()
    lobjDatabaseCommand.Connection = lobjDatabaseConnection
    lobjDatabaseWriterConnection.ConnectionString = "Data Source=storefrontdb001;Initial Catalog=StoreFront;Persist Security Info=True;User ID=sa;Password=hdvGL15?Valtim"
    lobjDatabaseWriterConnection.Open()
    lobjDatabaseWriterCommand.Connection = lobjDatabaseWriterConnection

    '*  4 : Start by fetching the promotional banner that need to be run first.
    lobjDatabaseCommand.CommandTimeout = 0
    lobjDatabaseCommand.CommandText = "SELECT session.TempLineItems.TempLineItemID FROM session.TempOrders WITH (NOLOCK) INNER JOIN session.TempLineItems WITH (NOLOCK) ON session.TempOrders.TempOrderID = session.TempLineItems.TempOrderID INNER JOIN site.Items WITH (NOLOCK) ON session.TempLineItems.ItemID = site.Items.ItemID WHERE (session.TempOrders.SessionID = " & Session("Id") & ")"
    lobjDatabaseReader = lobjDatabaseCommand.ExecuteReader
    Do While (lobjDatabaseReader.Read())
        Dim lstrShippingMethod As String = ""
        If (UCase(Me.drpShipToMethod.SelectedValue) = "UPS SUPER SAVER") Then
            If (Session("Weight") < 1) Then
                lstrShippingMethod = "UPS Mail Innovations"
            Else
                lstrShippingMethod = "UPS Sure Post"
            End If
        Else
            lstrShippingMethod = Me.drpShipToMethod.SelectedValue
        End If
        lobjDatabaseWriterCommand.CommandText = "UPDATE session.TempLineItems SET ShipFirstName = '" & Replace(Me.txtShipToFirstName.Text, "'", "''") & "', ShipLastName = '" & Replace(Me.txtShipToLastName.Text, "'", "''") & "', ShipEmail = '" & Replace(Me.txtShipToEmailAddress.Text, "'", "''") & "', ShipPhone = '" & Replace(Me.txtShipToPhone.Text, "'", "''") & "', ShipAddress1 = '" & Replace(Me.txtShipToAddress.Text, "'", "''") & "', ShipCity = '" & Replace(Me.txtShipToCity.Text, "'", "''") & "', ShipState = '" & Replace(Me.drpShipToState.SelectedValue, "'", "''") & "', ShipZip = '" & Replace(Me.txtShipToZipCode.Text, "'", "''") & "', ShipMethod = '" & Replace(lstrShippingMethod, "'", "''") & "' WHERE Session.TempLineItems.TempLineItemID = " & lobjDatabaseReader.GetValue(0)
        lobjDatabaseWriterCommand.ExecuteNonQuery()
    Loop
    lobjDatabaseReader.Close()

    '*  6 : Close out the database connection, command and reader here now.
    lobjDatabaseCommand.Dispose()
    lobjDatabaseWriterCommand.Dispose()
    lobjDatabaseConnection.Close()
    lobjDatabaseWriterConnection.Close()
    lobjDatabaseConnection.Dispose()
    lobjDatabaseWriterConnection.Dispose()
    Response.Redirect("Payment.aspx")

End Sub

Private Sub Shipping_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete

    Me.txtShipToFirstName.Focus()

End Sub

Protected Sub txtShipToAddress_TextChanged(sender As Object, e As EventArgs) Handles txtShipToAddress.TextChanged

    '*  1 : Define the local variables to be used here now.
    Dim lstrAddressText As String = ""
    Dim lstrStateText As String = ""

    '*  2 : Build the text and then flatten to look for the PO BOX pattern. 
    lstrAddressText = txtShipToAddress.Text
    lstrAddressText = Replace(lstrAddressText, ".", "")
    lstrAddressText = Replace(lstrAddressText, " ", "")
    lstrAddressText = UCase(lstrAddressText)
    lstrStateText = drpShipToState.SelectedValue
    lstrStateText = UCase(lstrStateText)

    '*  3 : Now see if PO BOX appears in the address pattern and if so force a change to the shipping options.
    If (InStr(lstrAddressText, "POBOX") > 0) Then

        '*  4 : Repopulate the shipping method options based on the fact the ship to is a PO Box.
        Me.drpShipToMethod.Items.Clear()
        Me.drpShipToMethod.Items.Add("")
        Me.drpShipToMethod.Items.Add("UPS Super Saver")

    Else

        If (lstrStateText = "HI") Or (lstrStateText = "AK") Then

            '*  4 : Repopulate the shipping method options.
            Me.drpShipToMethod.Items.Clear()
            Me.drpShipToMethod.Items.Add("")
            If (Session("Weight") <= 9) Then
                Me.drpShipToMethod.Items.Add("UPS Super Saver")
            End If
            Me.drpShipToMethod.Items.Add("UPS Ground")

        Else

            '*  4 : Repopulate the shipping method options.
            Me.drpShipToMethod.Items.Clear()
            Me.drpShipToMethod.Items.Add("")
            If (Session("Weight") <= 9) Then
                Me.drpShipToMethod.Items.Add("UPS Super Saver")
            End If
            Me.drpShipToMethod.Items.Add("UPS Ground")
            Me.drpShipToMethod.Items.Add("UPS Next Day")

        End If

    End If

End Sub

Private Sub drpShipToState_SelectedIndexChanged(sender As Object, e As EventArgs) Handles drpShipToState.SelectedIndexChanged

    '*  1 : Define the local variables to be used here now.
    Dim lstrAddressText As String = ""
    Dim lstrStateText As String = ""

    '*  2 : Build the text and then flatten to look for the PO BOX pattern. 
    lstrAddressText = txtShipToAddress.Text
    lstrAddressText = Replace(lstrAddressText, ".", "")
    lstrAddressText = Replace(lstrAddressText, " ", "")
    lstrAddressText = UCase(lstrAddressText)
    lstrStateText = drpShipToState.SelectedValue
    lstrStateText = UCase(lstrStateText)

    '*  3 : Now see if state appears in the list where next day shipping can not be provided.
    If (InStr(lstrAddressText, "POBOX") > 0) Then

        '*  4 : Repopulate the shipping method options based on the fact the ship to is a PO Box.
        Me.drpShipToMethod.Items.Clear()
        Me.drpShipToMethod.Items.Add("")
        Me.drpShipToMethod.Items.Add("UPS Super Saver")

    Else

        If (lstrStateText = "HI") Or (lstrStateText = "AK") Then

            '*  4 : Repopulate the shipping method options.
            Me.drpShipToMethod.Items.Clear()
            Me.drpShipToMethod.Items.Add("")
            If (Session("Weight") <= 9) Then
                Me.drpShipToMethod.Items.Add("UPS Super Saver")
            End If
            Me.drpShipToMethod.Items.Add("UPS Ground")

        Else

            '*  4 : Repopulate the shipping method options.
            Me.drpShipToMethod.Items.Clear()
            Me.drpShipToMethod.Items.Add("")
            If (Session("Weight") <= 9) Then
                Me.drpShipToMethod.Items.Add("UPS Super Saver")
            End If
            Me.drpShipToMethod.Items.Add("UPS Ground")
            Me.drpShipToMethod.Items.Add("UPS Next Day")

        End If

    End If

End Sub
End Class