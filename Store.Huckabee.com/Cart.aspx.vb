Public Class Cart
    Inherits System.Web.UI.Page
    Public lstrCartItems As String = ""
    Public ldblSubTotal As Double = 0.0
    Public lblnHideCouponOption As Boolean = False


Private Sub btnAddToCart_Click(sender As Object, e As EventArgs) Handles btnAddToCart.Click

Response.Redirect("Shipping.aspx")

End Sub

Private Sub form1_Load(sender As Object, e As EventArgs) Handles form1.Load

End Sub
Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    '*  0 : Check to see if a session is set up and if not do so now.
    If (Session("Id") = "") Then
        Response.Redirect("Home.aspx")
    End If

    '*  1 : Define the local variables to be used here now.
    Dim lblnReturnCode As Boolean = False
    Dim litHtml As Literal
    Dim plcHolder As PlaceHolder
    Dim drpQty As DropDownList
    Dim llngLoopVariable As Long = 0
    Dim lobjDatabaseConnection As New SqlClient.SqlConnection
    Dim lobjDatabaseCommand As New SqlClient.SqlCommand
    Dim lobjDatabaseReader As SqlClient.SqlDataReader

    '*  2 : Start by making the connection to the database for accessing the system.
    lblnHideCouponOption = False
    lobjDatabaseConnection.ConnectionString = "Data Source=storefrontdb001;Initial Catalog=StoreFront;Persist Security Info=True;User ID=sa;Password=hdvGL15?Valtim"
    lobjDatabaseConnection.Open()
    lobjDatabaseCommand.Connection = lobjDatabaseConnection

    '*  3 : Fetch all items in the cart here now.
    plcHolder = Page.FindControl("plcCartItems")
    lobjDatabaseCommand.CommandTimeout = 0
    lobjDatabaseCommand.CommandText = "SELECT site.Items.ItemGroup, site.Items.BrandName, session.TempLineItems.Quantity, session.TempLineItems.ItemPrice, session.TempLineItems.ExtPrice, Site.Items.ThumbnailImage, session.TempLineItems.TempLineItemID, ISNULL(site.Items.Dimensions, '') AS Dimensions, ISNULL(site.Items.BulkPriceBreakQty, 0) as BulkPriceBreakQty FROM session.TempOrders WITH (NOLOCK) INNER JOIN session.TempLineItems WITH (NOLOCK) ON session.TempOrders.TempOrderID = session.TempLineItems.TempOrderID INNER JOIN site.Items WITH (NOLOCK) ON session.TempLineItems.ItemID = site.Items.ItemID WHERE (session.TempOrders.SessionID = " & Session("Id") & ")"
    lobjDatabaseReader = lobjDatabaseCommand.ExecuteReader
    lstrCartItems = ""
    Do While (lobjDatabaseReader.Read())
        If (plcHolder.Controls.Count > 0) Then
            litHtml = New Literal
            litHtml.Text = "<tr style=""height:20px;""><td>&nbsp;</td><td></td><td></td><td></td></tr>"
            plcHolder.Controls.Add(litHtml)
        End If
        litHtml = New Literal
        litHtml.Text = "<tr style=""text-align: left; vertical-align:top; border: 0px; padding: 0px; margin: 0px; border-width: 0px; background-repeat: repeat;"">"
        plcHolder.Controls.Add(litHtml)
        litHtml = New Literal
        litHtml.Text = "<td>"
        plcHolder.Controls.Add(litHtml)
        litHtml = New Literal
        litHtml.Text = "<img src=""" & lobjDatabaseReader.GetValue(5) & """ style=""width: 100%; height: auto;text-decoration: none""/><br />"
        plcHolder.Controls.Add(litHtml)
        litHtml = New Literal
        litHtml.Text = "</td>"
        plcHolder.Controls.Add(litHtml)
        litHtml = New Literal
        litHtml.Text = "<td style=""text-align: left; vertical-align:top; width: 10px; padding: 0px; margin: 0px;""></td>"
        plcHolder.Controls.Add(litHtml)
        litHtml = New Literal
        litHtml.Text = "<td style=""text-align: left; vertical-align:top; width: 35%; padding: 0px; margin: 0px;"">"
        plcHolder.Controls.Add(litHtml)
        litHtml = New Literal
        litHtml.Text = "<table border=""0"" style=""width:100%;"">"
        plcHolder.Controls.Add(litHtml)
        litHtml = New Literal
        litHtml.Text = "<tr style=""height:120px;vertical-align:top;"">"
        plcHolder.Controls.Add(litHtml)
        litHtml = New Literal
        litHtml.Text = "<td>"
        plcHolder.Controls.Add(litHtml)
        litHtml = New Literal
        litHtml.Text = "<label for=""label2"" style=""font-family:'Open Sans', Helvetica, sans-serif;font-weight:300;font-size:125%;color: #044C86;text-decoration: none;"">" & lobjDatabaseReader.GetValue(0) & "</label><br />"
        plcHolder.Controls.Add(litHtml)
        litHtml = New Literal
        litHtml.Text = "<label for=""label2"" style=""font-family:'Open Sans', Helvetica, sans-serif;font-weight:300;font-size:75%;color: grey; text-decoration: none;"">Design : </label>"
        plcHolder.Controls.Add(litHtml)
        litHtml = New Literal
        litHtml.Text = "<label for=""label2"" style=""font-family:'Open Sans', Helvetica, sans-serif;font-weight:300;font-size:90%;color: #044C86; text-decoration: none;"">" & lobjDatabaseReader.GetValue(1) & "</label> "
        plcHolder.Controls.Add(litHtml)
        If (lobjDatabaseReader.GetValue(8) > 0) Then
            If (lobjDatabaseReader.GetValue(2) >= lobjDatabaseReader.GetValue(8)) Then
                lblnHideCouponOption = True
            End If
            litHtml = New Literal
            litHtml.Text = "<label for=""label2"" style=""font-family:'Open Sans', Helvetica, sans-serif;font-weight:600;font-size:66%;color: #FF0000;text-decoration: none;""><i>* volume discount eligible</i></label>"
            plcHolder.Controls.Add(litHtml)
        End If
        If (lobjDatabaseReader.GetValue(7) <> "") Then
            litHtml.Text = "</br><label for=""label2"" style=""font-family:'Open Sans', Helvetica, sans-serif;font-weight:300;font-size:75%;color: grey; text-decoration: none;"">Size </label>"
            plcHolder.Controls.Add(litHtml)
            litHtml = New Literal
            litHtml.Text = "<label for=""label2"" style=""font-family:'Open Sans', Helvetica, sans-serif;font-weight:300;font-size:90%;color: #044C86; text-decoration: none;"">" & lobjDatabaseReader.GetValue(7) & "</label> "
            plcHolder.Controls.Add(litHtml)
        End If
        litHtml = New Literal
        litHtml.Text = "</td>"
        plcHolder.Controls.Add(litHtml)
        litHtml = New Literal
        litHtml.Text = "</tr>"
        plcHolder.Controls.Add(litHtml)
        litHtml = New Literal
        litHtml.Text = "<tr>"
        plcHolder.Controls.Add(litHtml)
        litHtml = New Literal
        litHtml.Text = "<td style=""vertical-align:bottom;"">"
        plcHolder.Controls.Add(litHtml)
        litHtml = New Literal
        litHtml.Text = "<label for=""label2"" style=""font-family:'Open Sans', Helvetica, sans-serif;font-weight:300;font-size:75%;color: #044C86; text-decoration: none;""><a href=""Remove.aspx?Id=" & lobjDatabaseReader.GetValue(6) & """ style=""font-family:'Open Sans', Helvetica, sans-serif;font-weight:300;color: #044C86; text-decoration: underline"">Remove</a></label>"
        plcHolder.Controls.Add(litHtml)
        litHtml = New Literal
        litHtml.Text = "</td>"
        plcHolder.Controls.Add(litHtml)
        litHtml = New Literal
        litHtml.Text = "</tr>"
        plcHolder.Controls.Add(litHtml)
        litHtml = New Literal
        litHtml.Text = "</table>"
        plcHolder.Controls.Add(litHtml)
        litHtml = New Literal
        litHtml.Text = "</td>"
        plcHolder.Controls.Add(litHtml)
        litHtml = New Literal
        litHtml.Text = "<td style=""text-align: right; vertical-align:top; width: 35%; padding: 0px; margin: 0px;"">"
        plcHolder.Controls.Add(litHtml)
        litHtml = New Literal
        litHtml.Text = "<table border=""0"" style=""width:100%;"">"
        plcHolder.Controls.Add(litHtml)
        litHtml = New Literal
        litHtml.Text = "<tr>"
        plcHolder.Controls.Add(litHtml)
        litHtml = New Literal
        litHtml.Text = "<td style=""vertical-align:top;""></td>"
        plcHolder.Controls.Add(litHtml)
        litHtml = New Literal
        litHtml.Text = "<td style=""width:176px;height; 30px;vertical-align:top; background-image: url('Images/CartItemQtyAndPriceBkgd.png'); background-repeat: no-repeat;"">"
        plcHolder.Controls.Add(litHtml)
        litHtml = New Literal
        litHtml.Text = "<table border=""0"" style=""width:100%;"">"
        plcHolder.Controls.Add(litHtml)
        litHtml = New Literal
        litHtml.Text = "<tr style=""vertical-align:top"">"
        plcHolder.Controls.Add(litHtml)
        litHtml = New Literal
        litHtml.Text = "<td style=""width:33%;vertical-align:text-top"">"
        plcHolder.Controls.Add(litHtml)
        drpQty = New DropDownList
            drpQty.ID = "drpQty" & lobjDatabaseReader.GetValue(6)
            drpQty.CssClass = "dropdown"
            drpQty.CausesValidation = True
            drpQty.AutoPostBack = True
            For llngLoopVariable = 1 To 500 Step 1
                drpQty.Items.Add(llngLoopVariable)
                If (lobjDatabaseReader.GetValue(2) = llngLoopVariable) Then
                    drpQty.Items(llngLoopVariable - 1).Selected = True
                End If
            Next llngLoopVariable
        plcHolder.Controls.Add(drpQty)
        AddHandler drpQty.SelectedIndexChanged, AddressOf CartQtyUpdated
        litHtml = New Literal
        litHtml.Text = "</td>"
        plcHolder.Controls.Add(litHtml)
        litHtml = New Literal
        litHtml.Text = "<td style=""vertical-align:top""><label for=""label2"" style=""font-family:'Open Sans', Helvetica, sans-serif;font-weight:300;font-size:100%;color: black;text-decoration: none;"">" & FormatCurrency(lobjDatabaseReader.GetValue(3), 2) & "</label></td>"
        plcHolder.Controls.Add(litHtml)
        litHtml = New Literal
        litHtml.Text = "</tr>"
        plcHolder.Controls.Add(litHtml)
        litHtml = New Literal
        litHtml.Text = "</table>"
        plcHolder.Controls.Add(litHtml)
        litHtml = New Literal
        litHtml.Text = "</td>"
        plcHolder.Controls.Add(litHtml)
        litHtml = New Literal
        litHtml.Text = "</tr>"
        plcHolder.Controls.Add(litHtml)
        litHtml = New Literal
        litHtml.Text = "</table>"
        plcHolder.Controls.Add(litHtml)
        litHtml = New Literal
        litHtml.Text = "</td>"
        plcHolder.Controls.Add(litHtml)
        litHtml = New Literal
        litHtml.Text = "</tr>"
        plcHolder.Controls.Add(litHtml)
        ldblSubTotal = (ldblSubTotal + lobjDatabaseReader.GetValue(4))
    Loop
    lobjDatabaseReader.Close()

    '*  5 : Close out the database connection, command and reader here now.
    lobjDatabaseCommand.Dispose()
    lobjDatabaseConnection.Close()
    lobjDatabaseConnection.Dispose()
    If (plcHolder.Controls.Count = 0) Then
        Response.Redirect("Home.aspx")
    End If

End Sub
Protected Sub CartQtyUpdated(sender As Object, e As EventArgs)

    '*  1 : Define the local variables to be used here now.
    Dim drpDimensions As DropDownList
    Dim lblnReturnCode As Boolean = False
    Dim llngLineItemId As Long = 0
    Dim llngVolumePriceBreak As Long = 0
    Dim lstrVolumePrice As String = ""
    Dim lstrRegularPrice As String = ""
    Dim lobjDatabaseConnection As New SqlClient.SqlConnection
    Dim lobjDatabaseCommand As New SqlClient.SqlCommand
    Dim lobjDatabaseReader As SqlClient.SqlDataReader

    '*  2 : Start by making the connection to the database for accessing the system.
    drpDimensions = sender
    llngLineItemId = Replace(drpDimensions.ID, "drpQty", "")
    lobjDatabaseConnection.ConnectionString = "Data Source=storefrontdb001;Initial Catalog=StoreFront;Persist Security Info=True;User ID=sa;Password=hdvGL15?Valtim"
    lobjDatabaseConnection.Open()
    lobjDatabaseCommand.Connection = lobjDatabaseConnection

    '*  3 : Check to see if this item has a price break in it for offering volume discount.
    lobjDatabaseCommand.CommandTimeout = 0
    lobjDatabaseCommand.CommandText = "SELECT ISNULL(BulkPriceBreakQty, 0) AS BulkPriceBreakQty, ISNULL(BulkPrice, 0) AS BulkPrice, site.Items.Price FROM session.TempOrders WITH (NOLOCK) INNER JOIN session.TempLineItems WITH (NOLOCK) ON session.TempOrders.TempOrderID = session.TempLineItems.TempOrderID INNER JOIN site.Items WITH (NOLOCK) ON session.TempLineItems.ItemID = site.Items.ItemID WHERE (session.TempLineItems.TempLineItemID = " & llngLineItemId & ")"
    lobjDatabaseReader = lobjDatabaseCommand.ExecuteReader
    If (lobjDatabaseReader.Read()) Then
        llngVolumePriceBreak = lobjDatabaseReader.GetValue(0)
        lstrVolumePrice = lobjDatabaseReader.GetValue(1)
        lstrRegularPrice = lobjDatabaseReader.GetValue(2)
    End If
    lobjDatabaseReader.Close()

    '*  4 : Update the ordered qty on this item now.
    lobjDatabaseCommand.CommandTimeout = 0
    If (drpDimensions.SelectedValue >= llngVolumePriceBreak) And (llngVolumePriceBreak > 0) Then
        lobjDatabaseCommand.CommandText = "UPDATE session.TempLineItems SET session.TempLineItems.Quantity = " & drpDimensions.SelectedValue & ",  session.TempLineItems.ItemPrice = " & CDbl(lstrVolumePrice) & ", session.TempLineItems.ExtPrice = ((" & drpDimensions.SelectedValue & ") * " & CDbl(lstrVolumePrice) & ") WHERE (session.TempLineItems.TempLineItemID = " & llngLineItemId & ")"
    Else
        lobjDatabaseCommand.CommandText = "UPDATE session.TempLineItems SET session.TempLineItems.Quantity = " & drpDimensions.SelectedValue & ",  session.TempLineItems.ItemPrice = " & CDbl(lstrRegularPrice) & ", session.TempLineItems.ExtPrice = ((" & drpDimensions.SelectedValue & ") * " & CDbl(lstrRegularPrice) & ") WHERE (session.TempLineItems.TempLineItemID = " & llngLineItemId & ")"
    End If
    lobjDatabaseCommand.ExecuteNonQuery()

    '*  5 : Close out the database connection, command and reader here now.
    lobjDatabaseCommand.Dispose()
    lobjDatabaseConnection.Close()
    lobjDatabaseConnection.Dispose()
    Response.Redirect("Cart.aspx")


End Sub

Protected Sub btnCoupon_Click(sender As Object, e As EventArgs) Handles btnCoupon.Click

    '*  1 : Define the local variables to be used here now.
    Dim lblnReturnCode As Boolean = False
    Dim lobjDatabaseConnection As New SqlClient.SqlConnection
    Dim lobjDatabaseCommand As New SqlClient.SqlCommand
    Dim lobjDatabaseWriteConnection As New SqlClient.SqlConnection
    Dim lobjDatabaseWriteCommand As New SqlClient.SqlCommand
    Dim lobjDatabaseReader As SqlClient.SqlDataReader

    '*  2 : Start by making the connection to the database for accessing the system.r
    lobjDatabaseConnection.ConnectionString = "Data Source=storefrontdb001;Initial Catalog=StoreFront;Persist Security Info=True;User ID=sa;Password=hdvGL15?Valtim"
    lobjDatabaseConnection.Open()
    lobjDatabaseCommand.Connection = lobjDatabaseConnection
    lobjDatabaseWriteConnection.ConnectionString = "Data Source=storefrontdb001;Initial Catalog=StoreFront;Persist Security Info=True;User ID=sa;Password=hdvGL15?Valtim"
    lobjDatabaseWriteConnection.Open()
    lobjDatabaseWriteCommand.Connection = lobjDatabaseWriteConnection

    '*  3 : Update the ordered qty on this item now.
    Session("CouponUsed") = ""
    Session("CouponType") = ""
    Session("CouponResponse") = ""
    lobjDatabaseCommand.CommandTimeout = 0
    lobjDatabaseCommand.CommandText = "SELECT IsActive, ISNULL(RemainingUses, -1) as RemainingUses, ISNULL(StartsOn, '') AS StartsOn, ISNULL(EndsOn, '') AS EndsOn, ISNULL(DiscountPctg, 0) AS DiscountPctg, ISNULL(WaiveShipping, 0) AS WaiveShipping FROM site.Coupons with (nolock) WHERE (CouponCode = '" & Trim(Me.txtCouponCode.Text) & "')"
    lobjDatabaseReader = lobjDatabaseCommand.ExecuteReader
    If (lobjDatabaseReader.Read()) Then

        '*  A : Check to see if the coupon is still active before evaluating any other conditions.
        If (lobjDatabaseReader.GetValue(0) <> 1) Then
            Session.Add("CouponResponse", "The coupon code you provided is no longer active.")
        Else

            '*  A : The first evaluation to consider is if the remaining uses has a value but there is no start and end pair.
            '*  This would indicate a coupon that is good until all consumed by the end users regardless of a date range.
            If ((lobjDatabaseReader.GetValue(1) > 0) And (lobjDatabaseReader.GetValue(2).ToString = "1/1/1900 12:00:00 AM" And lobjDatabaseReader.GetValue(3).ToString = "1/1/1900 12:00:00 AM")) Then
                Session.Add("CouponUsed", Me.btnCoupon.Text)
                Session.Add("CouponType", "Token")
                Session.Add("CouponPctg", 1 - lobjDatabaseReader.GetValue(4))
                Session.Add("CouponWaiveShipping", lobjDatabaseReader.GetValue(5))
            End If

            '*  B : The second evaluation to consider is if there is a start and end pair, but no remaining uses.
            '*  This would indicate a coupon that is good for the entirety of a set period of time.
            If ((lobjDatabaseReader.GetValue(1) <= 0) And (lobjDatabaseReader.GetValue(2).ToString <> "1/1/1900 12:00:00 AM" And lobjDatabaseReader.GetValue(3).ToString <> "1/1/1900 12:00:00 AM")) Then
                If (lobjDatabaseReader.GetValue(2) <= Now() And lobjDatabaseReader.GetValue(3) >= Now()) Then
                    Session.Add("CouponUsed", Me.btnCoupon.Text)
                    Session.Add("CouponType", "Time")
                    Session.Add("CouponPctg", 1 - lobjDatabaseReader.GetValue(4))
                    Session.Add("CouponWaiveShipping", lobjDatabaseReader.GetValue(5))
                Else
                    Session.Add("CouponResponse", "The coupon code you provided has expired.")
                End If
            End If

            '*  C : The third evaluation to consider is if there is a start and end pair and a remaining uses.
            '*  This would indicate a coupon that is good for a set period of time for the first x number of people only.
            If ((lobjDatabaseReader.GetValue(1) > 0) And (lobjDatabaseReader.GetValue(2).ToString <> "1/1/1900 12:00:00 AM" And lobjDatabaseReader.GetValue(3).ToString <> "1/1/1900 12:00:00 AM")) Then
                If (lobjDatabaseReader.GetValue(2) <= Now() And lobjDatabaseReader.GetValue(3) >= Now()) Then
                    Session.Add("CouponUsed", Me.btnCoupon.Text)
                    Session.Add("CouponType", "TokenAndTime")
                    Session.Add("CouponPctg", 1 - lobjDatabaseReader.GetValue(4))
                    Session.Add("CouponWaiveShipping", lobjDatabaseReader.GetValue(5))
                Else
                    Session.Add("CouponResponse", "The coupon code you provided has expired.")
                End If
            End If

            '*  D : If both the coupon used and the response are empty the usees are out.
            If (Session("CouponUsed") = "") And (Session("CouponResponse") = "") Then
                Session.Add("CouponResponse", "The coupon code you provided has been exhausted.")
            End If

        End If
    Else
        Session.Add("CouponResponse", "The coupon code you provided could not be found.")
    End If
    lobjDatabaseReader.Close()

    '*  4 : Based on the assignment of the coupon code now update the prices to the cart here.
    If (Session("CouponUsed") <> "") And (Session("CouponWaiveShipping") = 0) Then
        If (InStr(Session("CouponType"), "Token") > 0) Then
            lobjDatabaseCommand.CommandText = "UPDATE site.Coupons SET RemainingUses = (RemainingUses - 1) WHERE (CouponCode = '" & Me.txtCouponCode.Text & "')"
            lobjDatabaseCommand.ExecuteNonQuery()
        End If
        If (Session("CouponPctg") = 1) Then
            lobjDatabaseCommand.CommandText = "SELECT session.TempLineItems.TempLineItemID, site.Items.CampaignPrice, site.Items.CampaignPrice * session.TempLineItems.Quantity FROM session.TempLineItems WITH (NOLOCK) INNER JOIN site.Items WITH (NOLOCK) ON session.TempLineItems.ItemID = site.Items.ItemID WHERE (session.TempLineItems.TempOrderID = " & Session("OrderId") & ")"
            lobjDatabaseReader = lobjDatabaseCommand.ExecuteReader
            ldblSubTotal = 0
            Do While (lobjDatabaseReader.Read())
                lobjDatabaseWriteCommand.CommandText = "UPDATE session.TempLineItems SET ItemPrice = " & lobjDatabaseReader.GetValue(1) & ", ExtPrice = " & lobjDatabaseReader.GetValue(2) & " WHERE session.TempLineItems.TempLineItemID = " & lobjDatabaseReader.GetValue(0)
                lobjDatabaseWriteCommand.ExecuteNonQuery()
                ldblSubTotal = (ldblSubTotal + lobjDatabaseReader.GetValue(2))
            Loop
            lobjDatabaseReader.Close()
        Else
            lobjDatabaseCommand.CommandText = "SELECT session.TempLineItems.TempLineItemID, site.Items.CampaignPrice, site.Items.CampaignPrice * session.TempLineItems.Quantity, Price, Price * session.TempLineItems.Quantity FROM session.TempLineItems WITH (NOLOCK) INNER JOIN site.Items WITH (NOLOCK) ON session.TempLineItems.ItemID = site.Items.ItemID WHERE (session.TempLineItems.TempOrderID = " & Session("OrderId") & ")"
            lobjDatabaseReader = lobjDatabaseCommand.ExecuteReader
            ldblSubTotal = 0
            Do While (lobjDatabaseReader.Read())
                lobjDatabaseWriteCommand.CommandText = "UPDATE session.TempLineItems SET ItemPrice = " & lobjDatabaseReader.GetValue(3) * CDbl(Session("CouponPctg")) & ", ExtPrice = " & lobjDatabaseReader.GetValue(4) * CDbl(Session("CouponPctg")) & " WHERE session.TempLineItems.TempLineItemID = " & lobjDatabaseReader.GetValue(0)
                lobjDatabaseWriteCommand.ExecuteNonQuery()
                ldblSubTotal = (ldblSubTotal + (lobjDatabaseReader.GetValue(4) * CDbl(Session("CouponPctg"))))
            Loop
            lobjDatabaseReader.Close()
        End If
    End If

    '*  5 : Insert the attempted coupon action for auditing purposes here now.
    If (Session("CouponResponse") <> "") Then
        lobjDatabaseCommand.CommandText = "INSERT INTO TrackingCouponAttempts SELECT GETDATE(), " & Session("Id") & ", '" & Request.ServerVariables("REMOTE_ADDR") & "', '" & Replace(Request.UserAgent, "'", "''") & "', '" & Me.txtCouponCode.Text & "', '" & Session("CouponResponse") & "'"
    Else
        lobjDatabaseCommand.CommandText = "INSERT INTO TrackingCouponAttempts SELECT GETDATE(), " & Session("Id") & ", '" & Request.ServerVariables("REMOTE_ADDR") & "', '" & Replace(Request.UserAgent, "'", "''") & "', '" & Me.txtCouponCode.Text & "', 'Coupon was used successfully.'"
    End If
    lobjDatabaseCommand.ExecuteNonQuery()

    '*  5 : Close up all the connections to the database here now.
    lobjDatabaseCommand.Dispose()
    lobjDatabaseWriteCommand.Dispose()
    lobjDatabaseWriteConnection.Close()
    lobjDatabaseConnection.Close()
    lobjDatabaseWriteConnection.Dispose()
    lobjDatabaseConnection.Close()
    Response.Redirect("Cart.aspx")

End Sub
End Class