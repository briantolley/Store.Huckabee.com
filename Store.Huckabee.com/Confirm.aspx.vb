Imports CyberSource
Imports CyberSource.CyberSourceServices
Public Class Confirm
    Inherits System.Web.UI.Page
    Public llngTempOrderId As Long = 0
    Public lstrCartItems As String = ""
    Public lstrFinalizedItems As String = ""
    Public lstrShippingDetails As String = ""
    Public lstrBillingDetails As String = ""
    Public ldblSubTotal As Double = 0.0
    Public lstrShippingMethod As String = ""
    Public ldblShippingFee As Double = 0.0
    Public ldblTaxes As Double = 0.0
    Public MerchantProcessor As New CyberSourceServices
    Public TaxShipTo As New Address
    Public TaxBillTo As New Address
    Public ClientCard As New CreditCard
Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    '*  0 : Check to see if a session is set up and if not do so now.
    If (Session("Id") = "") Then
        Response.Redirect("Home.aspx")
    End If
    ldblShippingFee = Session("ShippingFee")
    lstrShippingMethod = Session("ShippingMethod")
    ldblTaxes = Session("Taxes")

    '*  1 : Define the local variables to be used here now.
    Dim lblnReturnCode As Boolean = False
    Dim lstrShipToState As String = ""
    Dim lobjDatabaseConnection As New SqlClient.SqlConnection
    Dim lobjDatabaseCommand As New SqlClient.SqlCommand
    Dim lobjDatabaseReader As SqlClient.SqlDataReader
    Dim MerchantProcessorLineItem As New LineItem
    Dim llngLineItemNumber As Long = 0

    '*  2 : Start by making the connection to the database for accessing the system. 
    MerchantProcessor.MerchantReferenceCode = "148705832705344"
    lobjDatabaseConnection.ConnectionString = "Data Source=storefrontdb001;Initial Catalog=StoreFront;Persist Security Info=True;User ID=sa;Password=hdvGL15?Valtim"
    lobjDatabaseConnection.Open()
    lobjDatabaseCommand.Connection = lobjDatabaseConnection

    '*  4 : Fetch all items in the cart here now.
    lobjDatabaseCommand.CommandTimeout = 0
    lobjDatabaseCommand.CommandText = "SELECT site.Items.ItemGroup, site.Items.BrandName, session.TempLineItems.Quantity, session.TempLineItems.ItemPrice, session.TempLineItems.ExtPrice, Site.Items.ThumbnailImage, session.TempLineItems.TempLineItemID, ISNULL(site.Items.Dimensions, '') AS Dimensions, session.TempOrders.ShippingTotal, session.TempOrders.TempOrderID, session.TempLineItems.ItemID FROM session.TempOrders WITH (NOLOCK) INNER JOIN session.TempLineItems WITH (NOLOCK) ON session.TempOrders.TempOrderID = session.TempLineItems.TempOrderID INNER JOIN site.Items WITH (NOLOCK) ON session.TempLineItems.ItemID = site.Items.ItemID WHERE (session.TempOrders.SessionID = " & Session("Id") & ")"
    lobjDatabaseReader = lobjDatabaseCommand.ExecuteReader
    lstrCartItems = ""
    lstrFinalizedItems = ""
    Do While (lobjDatabaseReader.Read())
        llngTempOrderId = lobjDatabaseReader.GetValue(9)
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
        lstrFinalizedItems = lstrFinalizedItems + "<tr style=""vertical-align:top;"">"
        lstrFinalizedItems = lstrFinalizedItems + "<td style=""width:16px;""></td>"
        lstrFinalizedItems = lstrFinalizedItems + "<td style=""width:220px; font-family:'Open Sans', Helvetica, sans-serif;font-weight:300;font-size:80%;color: black;"">"
        lstrFinalizedItems = lstrFinalizedItems + lobjDatabaseReader.GetValue(0) & " " & lobjDatabaseReader.GetValue(1)
        lstrFinalizedItems = lstrFinalizedItems + "</td>"
        lstrFinalizedItems = lstrFinalizedItems + "<td style=""text-align:right;width:30px; font-family:'Open Sans', Helvetica, sans-serif;font-weight:300;font-size:80%;color: black;"">"
        lstrFinalizedItems = lstrFinalizedItems + lobjDatabaseReader.GetValue(2).ToString
        lstrFinalizedItems = lstrFinalizedItems + "</td>"
        lstrFinalizedItems = lstrFinalizedItems + "<td style=""text-align:right;width:40px;font-family:'Open Sans', Helvetica, sans-serif;font-weight:300;font-size:80%;color: black;"">"
        lstrFinalizedItems = lstrFinalizedItems + FormatCurrency(lobjDatabaseReader.GetValue(3), 2)
        lstrFinalizedItems = lstrFinalizedItems + "</td>"
        lstrFinalizedItems = lstrFinalizedItems + "<td style=""text-align:right;width:60px;font-family:'Open Sans', Helvetica, sans-serif;font-weight:300;font-size:80%;color: black;"">"
        lstrFinalizedItems = lstrFinalizedItems + FormatCurrency(lobjDatabaseReader.GetValue(4), 2)
        lstrFinalizedItems = lstrFinalizedItems + "</td>"
        lstrFinalizedItems = lstrFinalizedItems + "</tr>"

        '*  4.5 : Add each item line for tax purposes if to be processed.
        MerchantProcessorLineItem.ID = llngLineItemNumber.ToString
        MerchantProcessorLineItem.UnitPrice = lobjDatabaseReader.GetValue(3).ToString
        MerchantProcessorLineItem.ProductCode = lobjDatabaseReader.GetValue(6).ToString
        MerchantProcessorLineItem.Quantity = lobjDatabaseReader.GetValue(2)
        MerchantProcessorLineItem.ProductName = lobjDatabaseReader.GetValue(0).ToString
        MerchantProcessorLineItem.ProductSKU = lobjDatabaseReader.GetValue(10).ToString
        MerchantProcessor.addLineItem(MerchantProcessorLineItem)
        llngLineItemNumber = (llngLineItemNumber + 1)

    Loop
    lobjDatabaseReader.Close()

    '*  5 : Fetch shipping information here now.
    lobjDatabaseCommand.CommandTimeout = 0
    lobjDatabaseCommand.CommandText = "Select DISTINCT Session.TempOrders.SessionID, ISNULL(Session.TempLineItems.ShipFirstName, '') AS ShipFirstName, Session.TempLineItems.ShipLastName, Session.TempLineItems.ShipEmail, Session.TempLineItems.ShipPhone, Session.TempLineItems.ShipAddress1, Session.TempLineItems.ShipCity, Session.TempLineItems.ShipState, Session.TempLineItems.ShipZip, Session.TempLineItems.ShipMethod FROM session.TempLineItems WITH (NOLOCK) INNER JOIN session.TempOrders WITH (NOLOCK) ON session.TempLineItems.TempOrderID = session.TempOrders.TempOrderID WHERE (session.TempOrders.SessionID = " & Session("Id") & ")"
    lobjDatabaseReader = lobjDatabaseCommand.ExecuteReader
    lstrShippingDetails = ""
    If (lobjDatabaseReader.Read()) Then
        lstrShippingDetails = lstrShippingDetails & lobjDatabaseReader.GetValue(1) & " " & lobjDatabaseReader.GetValue(2) & "<br />"
        lstrShippingDetails = lstrShippingDetails & lobjDatabaseReader.GetValue(5) & "<br />"
        lstrShippingDetails = lstrShippingDetails & lobjDatabaseReader.GetValue(6) & ", " & lobjDatabaseReader.GetValue(7) & ", " & lobjDatabaseReader.GetValue(8) & "<br />"
        lstrShippingDetails = lstrShippingDetails & lobjDatabaseReader.GetValue(9)
        lstrShipToState = UCase(lobjDatabaseReader.GetValue(7))
        TaxShipTo.FirstName = lobjDatabaseReader.GetValue(1).ToString
        TaxShipTo.LastName = lobjDatabaseReader.GetValue(2).ToString
        TaxShipTo.AddressLine1 = lobjDatabaseReader.GetValue(5).ToString
        TaxShipTo.City = lobjDatabaseReader.GetValue(6).ToString
        TaxShipTo.State = lobjDatabaseReader.GetValue(7).ToString
        TaxShipTo.PostalCode = lobjDatabaseReader.GetValue(8).ToString
        TaxShipTo.Country = "US"
        TaxShipTo.Email = lobjDatabaseReader.GetValue(3).ToString
        MerchantProcessor.ShippingAddress = TaxShipTo
    End If
    lobjDatabaseReader.Close()

    '*  5 : Fetch shipping information here now.
    lobjDatabaseCommand.CommandTimeout = 0
    lobjDatabaseCommand.CommandText = "Select BillName, CCNum, CCMonth, CCYear, CCCV, BillFirstName, BillLastName, BillAddress1, BillCity, BillState, BillZip, Employer, Occupation FROM session.TempOrders WITH (nolock) INNER JOIN session.TempPayments WITH (nolock) ON session.TempOrders.TempOrderID = session.TempPayments.TempOrderID WHERE (Session.TempOrders.SessionID = " & Session("Id") & ")"
    lobjDatabaseReader = lobjDatabaseCommand.ExecuteReader
    lstrBillingDetails = ""
    If (lobjDatabaseReader.Read()) Then
        lstrBillingDetails = lstrBillingDetails & lobjDatabaseReader.GetValue(5) & " " & lobjDatabaseReader.GetValue(6) & "<br />"
        lstrBillingDetails = lstrBillingDetails & lobjDatabaseReader.GetValue(7) & "<br />"
        lstrBillingDetails = lstrBillingDetails & lobjDatabaseReader.GetValue(8) & ", " & lobjDatabaseReader.GetValue(9) & ", " & lobjDatabaseReader.GetValue(10) & "<br />"
        lstrBillingDetails = lstrBillingDetails & "*********" & Right(lobjDatabaseReader.GetValue(1), 4)
        TaxBillTo.FirstName = lobjDatabaseReader.GetValue(5).ToString
        TaxBillTo.LastName = lobjDatabaseReader.GetValue(6).ToString
        TaxBillTo.AddressLine1 = lobjDatabaseReader.GetValue(7).ToString
        TaxBillTo.City = lobjDatabaseReader.GetValue(8).ToString
        TaxBillTo.State = lobjDatabaseReader.GetValue(9).ToString
        TaxBillTo.PostalCode = lobjDatabaseReader.GetValue(10).ToString
        TaxBillTo.Country = "US"
        TaxBillTo.Email = "noreply@valtim.com"
        MerchantProcessor.BillingAddress = TaxBillTo
        ClientCard.AccountNumber = lobjDatabaseReader.GetValue(1).ToString
        ClientCard.ExpirationMonth = lobjDatabaseReader.GetValue(2).ToString
        ClientCard.ExpirationYear = lobjDatabaseReader.GetValue(3).ToString
        ClientCard.CVNumber = lobjDatabaseReader.GetValue(4).ToString
        MerchantProcessor.Card = ClientCard
    End If
    lobjDatabaseReader.Close()

    '*  6 : Fire off the tax check logic here now.
    If Not (IsPostBack) Then
        If (lstrShipToState = "VA") Then

            '*  Here is where we will now check the taxt logic
            Dim TaxTotal As TaxInformation = MerchantProcessor.getTaxInformation()
            ldblTaxes = TaxTotal.TaxTotal
            lobjDatabaseCommand.CommandTimeout = 0
            lobjDatabaseCommand.CommandText = "Update session.TempOrders SET TaxTotal = " & ldblTaxes & " WHERE (SessionID = " & Session("Id") & ")"
            lobjDatabaseCommand.ExecuteNonQuery()
            Session.Add("Taxes", ldblTaxes)

        End If
    End If

    '*  7 : Close out the database connection, command and reader here now.
    lobjDatabaseCommand.Dispose()
    lobjDatabaseConnection.Close()
    lobjDatabaseConnection.Dispose()

End Sub

Private Sub btnPayment_Click(sender As Object, e As EventArgs) Handles btnPayment.Click

Response.Redirect("Payment.aspx")

End Sub

Protected Sub btnPlaceOrder_Click(sender As Object, e As EventArgs) Handles btnPlaceOrder.Click

    '*  1 : Define the local variables to be used here now.
    Dim lblnReturnCode As Boolean = False
    Dim lstrReasonCode As String = ""
    Dim lstrReasonDescription As String = ""
    Dim lstrErrorMessage As String = ""
    Dim lobjSessionDatabaseConnection As New SqlClient.SqlConnection
    Dim lobjSessionDatabaseCommand As New SqlClient.SqlCommand
    Dim lobjSessionSqlParameter As SqlClient.SqlParameter

    '*  B : Make the connection and get the session id here now.
    lobjSessionDatabaseConnection.ConnectionString = "Data Source=storefrontdb001;Initial Catalog=StoreFront;Persist Security Info=True;User ID=sa;Password=hdvGL15?Valtim"
    lobjSessionDatabaseConnection.Open()
    lobjSessionDatabaseCommand.Connection = lobjSessionDatabaseConnection
    lobjSessionDatabaseCommand.CommandText = "UPDATE session.TempPayments SET AuthorizedAmount = " & (ldblSubTotal + ldblShippingFee + ldblTaxes) & " WHERE session.TempPayments.TempOrderID = " & llngTempOrderId
    lobjSessionDatabaseCommand.ExecuteNonQuery()

    '*  2 : Attempt to process the credit card here now.
    MerchantProcessor.PriceToAuthorize = (ldblSubTotal + ldblShippingFee + ldblTaxes)
    Dim authCapInfo As AuthAndCaptureInformation = MerchantProcessor.authorize(True)
    If (UCase(authCapInfo.Decision) = "ACCEPT") Then
        lobjSessionDatabaseCommand.CommandText = "UPDATE session.TempPayments SET PaidAmount = " & (ldblSubTotal + ldblShippingFee + ldblTaxes) & ", AuthorizedDecision = 'ACCEPT', AuthorizedNum = '" & authCapInfo.AuthorizeTransactionID & "', CaptureNum = '" & authCapInfo.AuthorizeTransactionID & "', CaptureDecision = 'ACCEPT', AuthorizedDate = GETDATE(), CaptureDate = GETDATE(), AuthorizedAmount = " & (ldblSubTotal + ldblShippingFee + ldblTaxes) & ", CaptureAmount = " & (ldblSubTotal + ldblShippingFee + ldblTaxes) & " WHERE session.TempPayments.TempOrderID = " & llngTempOrderId
        lobjSessionDatabaseCommand.ExecuteNonQuery()

        '*  "PaidAmount" temppayments table
        lobjSessionDatabaseCommand.CommandType = CommandType.StoredProcedure
        lobjSessionDatabaseCommand.CommandText = "session.order_finalize"
        lobjSessionSqlParameter = lobjSessionDatabaseCommand.Parameters.Add("@SessionID", SqlDbType.Int)
        lobjSessionSqlParameter.Value = llngTempOrderId
        lobjSessionSqlParameter.Direction = ParameterDirection.Input
        lobjSessionSqlParameter = lobjSessionDatabaseCommand.Parameters.Add("@FinalText", SqlDbType.VarChar)
        lobjSessionSqlParameter.Value = ""
        lobjSessionSqlParameter.Direction = ParameterDirection.Output
        lobjSessionDatabaseCommand.ExecuteNonQuery()
        Session("CartCount") = "0"
        Response.Redirect("Thankyou.aspx")
    Else
        Session.Add("ProcessingFailureNotice", "We are sorry but we were unable to process your order with the credit card information supplied.  Please select the previous button, correct your credit card information and try again.")
    End If


End Sub
End Class