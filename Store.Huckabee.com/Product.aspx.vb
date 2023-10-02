Public Class Product
    Inherits System.Web.UI.Page
    Public lstrProductImageToDisplay As String = ""
    Public lstrProductNameToDisplay As String = ""
    Public lstrProductItemPrice As String = ""
    Public lstrProductNarrative As String = ""
    Public llngPriceBreakOnQuantity As Long = 0
    Public lstrPriceAfterQuantityMet As String = ""
    Public lstrProductSizes As String = ""


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    '*  0 : Check to see if a session is set up and if not do so now.
    If (Session("Id") = "") Then

        '*  A : Declare the local variables used to get the connection here.
        Dim lobjSessionDatabaseConnection As New SqlClient.SqlConnection
        Dim lobjSessionDatabaseCommand As New SqlClient.SqlCommand

        '*  B : Make the connection and get the session id here now.
        lobjSessionDatabaseConnection.ConnectionString = "Data Source=storefrontdb001;Initial Catalog=StoreFront;Persist Security Info=True;User ID=sa;Password=hdvGL15?Valtim"
        lobjSessionDatabaseConnection.Open()
        lobjSessionDatabaseCommand.Connection = lobjSessionDatabaseConnection
        lobjSessionDatabaseCommand.CommandType = CommandType.StoredProcedure
        lobjSessionDatabaseCommand.CommandText = "session.InitialCall"
        lobjSessionDatabaseCommand.Parameters.Add("@ClientID", SqlDbType.VarChar, 50)
        lobjSessionDatabaseCommand.Parameters.Add("@Channel", SqlDbType.VarChar, 50)
        lobjSessionDatabaseCommand.Parameters.Add("@IPAddress", SqlDbType.VarChar, 50)
        lobjSessionDatabaseCommand.Parameters.Add("@BrowserUsed", SqlDbType.VarChar, 500)
        lobjSessionDatabaseCommand.Parameters.Add("@UserID", SqlDbType.VarChar, 50)
        lobjSessionDatabaseCommand.Parameters.Add("@SessionID", SqlDbType.Int)
        lobjSessionDatabaseCommand.Parameters("@SessionID").Direction = ParameterDirection.Output
        lobjSessionDatabaseCommand.Parameters("@BrowserUsed").Value = Request.UserAgent
        lobjSessionDatabaseCommand.Parameters("@IPAddress").Value = Request.ServerVariables("REMOTE_ADDR")
        lobjSessionDatabaseCommand.ExecuteNonQuery()

        '*  C : Now set the session for use throughout the life of the shopping experience.
        Session.Add("Id", lobjSessionDatabaseCommand.Parameters("@SessionID").Value.ToString)
        Session.Add("CartCount", "0")
        lobjSessionDatabaseCommand.Dispose()
        lobjSessionDatabaseConnection.Close()
        lobjSessionDatabaseConnection.Dispose()

    End If

    '* 00 : Record the visit to this page now to keep track of interest in the products here now.
    If Not (IsPostBack) Then

        '*  A : Declare the local variables used to get the connection here.
        Dim lobjTrackingDatabaseConnection As New SqlClient.SqlConnection
        Dim lobjTrackingDatabaseCommand As New SqlClient.SqlCommand
        Dim lstrReferrerId As String = "0"
        Dim lstrReferringSite As String = ""
        Dim lstrProductId As String = "0"

        '*  B : Make the connection and get the session id here now.
        If (Request.QueryString("r") <> "") Then
           lstrReferrerId = Request.QueryString("r")
        End If
        If Not (IsNothing(Request.UrlReferrer)) Then
            lstrReferringSite = Request.UrlReferrer.ToString()
        End If
        If (Request.QueryString("ID") <> "") Then
           lstrProductId = Request.QueryString("ID")
        End If
        lobjTrackingDatabaseConnection.ConnectionString = "Data Source=storefrontdb001;Initial Catalog=StoreFront;Persist Security Info=True;User ID=sa;Password=hdvGL15?Valtim"
        lobjTrackingDatabaseConnection.Open()
        lobjTrackingDatabaseCommand.Connection = lobjTrackingDatabaseConnection
        lobjTrackingDatabaseCommand.CommandText = "INSERT INTO TrackingProductViews SELECT " & Session("Id") & ", " & lstrProductId & ", '" & Request.ServerVariables("REMOTE_ADDR") & "', '" & Request.UserAgent & "', '" & Replace(lstrReferringSite, "'", "''") & "', GETDATE(), " & lstrReferrerId
        lobjTrackingDatabaseCommand.ExecuteNonQuery()
        lobjTrackingDatabaseCommand.Dispose()
        lobjTrackingDatabaseConnection.Close()
        lobjTrackingDatabaseConnection.Dispose()

    End If

    '*  1 : Define the local variables to be used here now.
    Dim lblnReturnCode As Boolean = False
    Dim litHtml As Literal
    Dim img As Image
    Dim plcHolder As PlaceHolder
    Dim drpDown As DropDownList
    Dim lobjAsyncPostBackTrigger As AsyncPostBackTrigger
    Dim lobjDatabaseConnection As New SqlClient.SqlConnection
    Dim lobjDatabaseCommand As New SqlClient.SqlCommand
    Dim lobjDatabaseReader As SqlClient.SqlDataReader

    '*  2 : Start by making the connection to the database for accessing the system.        
    lobjDatabaseConnection.ConnectionString = "Data Source=storefrontdb001;Initial Catalog=StoreFront;Persist Security Info=True;User ID=sa;Password=hdvGL15?Valtim"
    lobjDatabaseConnection.Open()
    lobjDatabaseCommand.Connection = lobjDatabaseConnection

    '*  3 : Start by fetching the promotional banner that need to be run first.
    lobjDatabaseCommand.CommandTimeout = 0
    lobjDatabaseCommand.CommandText = "SELECT BrandName, ItemGroup, Price, ProductImage, LongDesc, ISNULL(BulkPriceBreakQty, 0) AS BulkPriceBreakQty, ISNULL(BulkPrice, 0) AS BulkPrice FROM site.Items WITH (nolock) WHERE (ItemId = " & Request.QueryString("ID") & ")"
    lobjDatabaseReader = lobjDatabaseCommand.ExecuteReader
    If (lobjDatabaseReader.Read()) Then
        If (Session("WarningImage") = "") Then
            img = New Image
            img.CssClass = "productimage"
            img.ImageUrl = lobjDatabaseReader.GetValue(3)
            plcProductImage.Controls.Clear()
            plcProductImage.Controls.Add(img)
        Else
            img = New Image
            img.CssClass = "productimage"
            img.ImageUrl = Session("WarningImage")
            Session("WarningImage") = ""
            plcProductImage.Controls.Clear()
            plcProductImage.Controls.Add(img)
        End If
        lstrProductNameToDisplay = lobjDatabaseReader.GetValue(0) & " " & lobjDatabaseReader.GetValue(1)
        lstrProductItemPrice = FormatCurrency(lobjDatabaseReader.GetValue(2), 2)
        lstrProductNarrative = lobjDatabaseReader.GetValue(4)
        llngPriceBreakOnQuantity = lobjDatabaseReader.GetValue(5)
        lstrPriceAfterQuantityMet = lobjDatabaseReader.GetValue(6)
    End If
    lobjDatabaseReader.Close()

    '*  4 : Check to see if there is more than one size to choose from.
    lobjDatabaseCommand.CommandTimeout = 0
    lobjDatabaseCommand.CommandText = "SELECT Dimensions FROM site.Items WITH (nolock) WHERE (ItemGroup IN (SELECT ItemGroup FROM site.Items AS Items_1 WITH (nolock) WHERE (Dimensions IS NOT NULL) AND (site.Items.IsActive = 1) AND (ItemID = " & Request.QueryString("ID") & "))) and (BrandName IN (SELECT BrandName FROM site.Items AS Items_1 WITH (nolock) WHERE (Dimensions IS NOT NULL) AND (site.Items.IsActive = 1) AND (ItemID = " & Request.QueryString("ID") & "))) ORDER BY ItemId Asc"
    lobjDatabaseReader = lobjDatabaseCommand.ExecuteReader
    lstrProductSizes = ""
    drpDown = New DropDownList
    drpDown.ID = "drpSize"
    drpDown.CssClass = "dropdown2"
    drpDown.CausesValidation = True
    drpDown.AutoPostBack = True
    AddHandler drpDown.SelectedIndexChanged, AddressOf ProductDimensionChanged
    Do While (lobjDatabaseReader.Read())
        drpDown.Items.Add(lobjDatabaseReader.GetValue(0))
        lstrProductSizes = lstrProductSizes + "<option value=""" & lobjDatabaseReader.GetValue(0) & """>" & lobjDatabaseReader.GetValue(0) & "</option>"
    Loop
    If (Len(lstrProductSizes) > 0) Then
        plcHolder = Page.FindControl("plcDimensions")
        litHtml = New Literal
        litHtml.Text = "<label for=""label2"" style=""font-family:'Open Sans', Helvetica, sans-serif;font-weight:300;font-size:100%;color: black;text-decoration: none;"">Size :&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</label>"
        plcHolder.Controls.Add(litHtml)
        plcHolder.Controls.Add(drpDown)
        litHtml = New Literal
        litHtml.Text = "<br />"
        plcHolder.Controls.Add(litHtml)
    End If
    lobjDatabaseReader.Close()

    '*  5 : Close out the database connection, command and reader here now.
    lobjDatabaseCommand.Dispose()
    lobjDatabaseConnection.Close()
    lobjDatabaseConnection.Dispose()

    '*  6 : Postback here.
    If (IsPostBack) Then
        If (Session("ItemAdded") <> "") Then
            plcHolder = Page.FindControl("plcItemAdded")
            litHtml = New Literal
            litHtml.Text = "<label for=""label2"" style=""font-family:'Open Sans', Helvetica, sans-serif;font-weight:300;font-size:80%;color: red; text-decoration: none;"">Your item has been added.</label>"
            plcHolder.Controls.Add(litHtml)
            Session("ItemAdded") = ""
        Else
            plcHolder = Page.FindControl("plcItemAdded")
            plcHolder.Controls.Clear()
        End If
    End If

    End Sub

Private Sub btnAddToCart_Click(sender As Object, e As ImageClickEventArgs) Handles btnAddToCart.Click

    '*  0 : Check to see if a session is set up and if not do so now.
    If (Session("Id") = "") Then
        Response.Redirect("Home.aspx")
    End If

    '*  1 : Define the local variables to be used here now.
    Dim drpDimensions As DropDownList
    Dim plcHolder As PlaceHolder
    Dim litHtml As Literal
    Dim lblnReturnCode As Boolean = False
    Dim llngOrderId As Long = 0
    Dim llngCurrentProductId As Long = 0
    Dim llngPriorQuantityForProduct As Long = 0
    Dim lobjDatabaseConnection As New SqlClient.SqlConnection
    Dim lobjDatabaseCommand As New SqlClient.SqlCommand
    Dim lobjDatabaseReader As SqlClient.SqlDataReader

    '*  2 : Start by making the connection to the database for accessing the system.        
    lobjDatabaseConnection.ConnectionString = "Data Source=storefrontdb001;Initial Catalog=StoreFront;Persist Security Info=True;User ID=sa;Password=hdvGL15?Valtim"
    lobjDatabaseConnection.Open()
    lobjDatabaseCommand.Connection = lobjDatabaseConnection
    Session("CouponUsed") = ""

    '*  3 : Start by fetching the order number and seeing if we need to create it here first.
    lobjDatabaseCommand.CommandTimeout = 0
    lobjDatabaseCommand.CommandText = "SELECT TempOrderID FROM session.TempOrders WITH (nolock) WHERE(SessionID = " & Session("Id") & ")"
    lobjDatabaseReader = lobjDatabaseCommand.ExecuteReader
    lblnReturnCode = lobjDatabaseReader.Read()
    If lblnReturnCode = False Then
        lobjDatabaseReader.Close()
        lobjDatabaseCommand.CommandText = "INSERT INTO session.TempOrders (SessionID) VALUES (" & Session("Id") & ")"
        lobjDatabaseCommand.ExecuteNonQuery()
        lobjDatabaseCommand.CommandText = "SELECT TempOrderID FROM session.TempOrders WITH (nolock) WHERE(SessionID = " & Session("Id") & ")"
        lobjDatabaseReader = lobjDatabaseCommand.ExecuteReader
        If (lobjDatabaseReader.Read()) Then
            llngOrderId = lobjDatabaseReader.GetValue(0)
        End If
        lobjDatabaseReader.Close()
    Else
        llngOrderId = lobjDatabaseReader.GetValue(0)
        lobjDatabaseReader.Close()
    End If
    Session.Add("OrderId", llngOrderId)

    '*  4 : Check to see if the item is a different size than the default size here now.
    llngCurrentProductId = Request.QueryString("ID")
    drpDimensions = Page.FindControl("drpSize")
    If Not (IsNothing(drpDimensions)) Then
        lobjDatabaseCommand.CommandTimeout = 0
        lobjDatabaseCommand.CommandText = "Select ItemID, Price FROM site.Items WITH (NOLOCK) WHERE (ItemGroup IN (SELECT ItemGroup FROM site.Items AS Items_1 WHERE (ItemID = " & Request.QueryString("ID") & "))) and (BrandName IN (SELECT BrandName FROM site.Items AS Items_2 WHERE (ItemID = " & Request.QueryString("ID") & "))) AND (Dimensions = '" & drpDimensions.SelectedValue & "')"
        lobjDatabaseReader = lobjDatabaseCommand.ExecuteReader
        If (lobjDatabaseReader.Read()) Then
            llngCurrentProductId = lobjDatabaseReader.GetValue(0)
            lstrProductItemPrice = FormatCurrency(lobjDatabaseReader.GetValue(1))
        End If
        lobjDatabaseReader.Close()
    End If

    '*  5 : Now check to see if the line exsists and we are adding it or simply updating the quantity.
    lobjDatabaseCommand.CommandTimeout = 0
    lobjDatabaseCommand.CommandText = "SELECT session.TempLineItems.TempLineItemID, session.TempLineItems.Quantity, session.TempLineItems.ExtPrice FROM session.TempOrders with (nolock) INNER JOIN session.TempLineItems with (nolock) ON session.TempOrders.TempOrderID = session.TempLineItems.TempOrderID WHERE (session.TempOrders.SessionID = " & Session("Id") & ") AND (session.TempLineItems.ItemID = " & llngCurrentProductId & ")"
    lobjDatabaseReader = lobjDatabaseCommand.ExecuteReader
    lblnReturnCode = lobjDatabaseReader.Read()
    llngPriorQuantityForProduct = 0
    If (lblnReturnCode) Then
        llngPriorQuantityForProduct = lobjDatabaseReader.GetValue(1)
    End If
    lobjDatabaseReader.Close()
    If lblnReturnCode Then
        If ((drpQty.SelectedValue + llngPriorQuantityForProduct) >= llngPriceBreakOnQuantity) And (llngPriceBreakOnQuantity > 0) Then
            lobjDatabaseCommand.CommandText = "UPDATE session.TempLineItems SET session.TempLineItems.Quantity = session.TempLineItems.Quantity + " & Me.drpQty.SelectedItem.Value.ToString & ",  session.TempLineItems.ItemPrice = " & CDbl(lstrPriceAfterQuantityMet) & ", session.TempLineItems.ExtPrice = ((session.TempLineItems.Quantity + " & Me.drpQty.SelectedItem.Value.ToString & ") * " & CDbl(lstrPriceAfterQuantityMet) & ") WHERE (session.TempLineItems.TempOrderID = " & llngOrderId & ") AND (session.TempLineItems.ItemID = " & llngCurrentProductId & ")"
        Else
            lobjDatabaseCommand.CommandText = "UPDATE session.TempLineItems SET session.TempLineItems.Quantity = session.TempLineItems.Quantity + " & Me.drpQty.SelectedItem.Value.ToString & ",  session.TempLineItems.ItemPrice = " & CDbl(lstrProductItemPrice) & ", session.TempLineItems.ExtPrice = ((session.TempLineItems.Quantity + " & Me.drpQty.SelectedItem.Value.ToString & ") * " & CDbl(lstrProductItemPrice) & ") WHERE (session.TempLineItems.TempOrderID = " & llngOrderId & ") AND (session.TempLineItems.ItemID = " & llngCurrentProductId & ")"
        End If
        lobjDatabaseCommand.ExecuteNonQuery()
        Session.Add("ItemAdded", "Done")
    Else
        '*  Code here for qty driven pricing
        If (drpQty.SelectedValue >= llngPriceBreakOnQuantity) And (llngPriceBreakOnQuantity > 0) Then
            lobjDatabaseCommand.CommandText = "INSERT INTO session.TempLineItems (TempOrderID, ItemID, Quantity, ItemPrice, ExtPrice) VALUES (" & llngOrderId & ", " & llngCurrentProductId & ", " & Me.drpQty.SelectedItem.Value.ToString & ", " & CDbl(lstrPriceAfterQuantityMet) & ", " & CDbl(lstrPriceAfterQuantityMet) * Me.drpQty.SelectedItem.Value & ")"
        Else
            lobjDatabaseCommand.CommandText = "INSERT INTO session.TempLineItems (TempOrderID, ItemID, Quantity, ItemPrice, ExtPrice) VALUES (" & llngOrderId & ", " & llngCurrentProductId & ", " & Me.drpQty.SelectedItem.Value.ToString & ", " & CDbl(lstrProductItemPrice) & ", " & CDbl(lstrProductItemPrice) * Me.drpQty.SelectedItem.Value & ")"
        End If
        lobjDatabaseCommand.ExecuteNonQuery()
        Session("CartCount") = (Int(Session("CartCount")) + 1)
        Session.Add("ItemAdded", "Done")
    End If
    plcHolder = Page.FindControl("plcItemAdded")
    litHtml = New Literal
    litHtml.Text = "<label for=""label2"" style=""font-family:'Open Sans', Helvetica, sans-serif;font-weight:300;font-size:80%;color: red; text-decoration: none;"">Your item has been added.</label>"
    plcHolder.Controls.Add(litHtml)

    '*  4 : Close out the database connection, command and reader here now.
    lobjDatabaseCommand.Dispose()
    lobjDatabaseConnection.Close()
    lobjDatabaseConnection.Dispose()
    Me.btnCheckOut.Visible = True

End Sub

Protected Sub btnCheckOut_Click(sender As Object, e As ImageClickEventArgs) Handles btnCheckOut.Click
    Response.Redirect("Cart.aspx")
End Sub
Protected Sub ProductDimensionChanged(sender As Object, e As EventArgs)

    '*  1 : Define the local variables to be used here now.
    Dim drpDimensions As DropDownList
    Dim img As Image
    Dim litHtml As Literal
    Dim plcHolder As PlaceHolder
    Dim lblnReturnCode As Boolean = False
    Dim lstrProductId As String = ""
    Dim lstrProductDimension As String = ""
    Dim lobjDatabaseConnection As New SqlClient.SqlConnection
    Dim lobjDatabaseCommand As New SqlClient.SqlCommand
    Dim lobjDatabaseReader As SqlClient.SqlDataReader

    '*  2 : Start by making the connection to the database for accessing the system.
    drpDimensions = sender
    lstrProductDimension = drpDimensions.SelectedValue
    lstrProductId = Request.QueryString("ID")
    lobjDatabaseConnection.ConnectionString = "Data Source=storefrontdb001;Initial Catalog=StoreFront;Persist Security Info=True;User ID=sa;Password=hdvGL15?Valtim"
    lobjDatabaseConnection.Open()
    lobjDatabaseCommand.Connection = lobjDatabaseConnection

    '*  3 : Update the ordered qty on this item now.
    lobjDatabaseCommand.CommandTimeout = 0
    lobjDatabaseCommand.CommandText = "SELECT isnull(Warning, '') as Warning, isnull(ProductImage, '') as ProductImage FROM site.Items with (nolock) WHERE (ItemGroup IN (SELECT ItemGroup FROM site.Items AS Items_1 WITH (nolock) WHERE (ItemID = " & lstrProductId & "))) AND (BrandName IN (SELECT BrandName FROM site.Items AS Items_1 WITH (nolock) WHERE (ItemID = " & lstrProductId & "))) AND (Dimensions = '" & lstrProductDimension & "')"
    lobjDatabaseReader = lobjDatabaseCommand.ExecuteReader
    plcHolder = Page.FindControl("plcProductWarning")
    If (lobjDatabaseReader.Read()) Then
        If (lobjDatabaseReader.GetValue(0).ToString <> "") Then
            litHtml = New Literal
            litHtml.Text = "<label for=""label2"" style=""font-family:'Open Sans', Helvetica, sans-serif;font-weight:300;font-size:100%;color: red;text-decoration: none;"">" & lobjDatabaseReader.GetValue(0) & "</label>"
            plcHolder.Controls.Add(litHtml)
            img = New Image
            img.CssClass = "productimage"
            img.ImageUrl = lobjDatabaseReader.GetValue(1)
            plcProductImage.Controls.Clear()
            plcProductImage.Controls.Add(img)
            Session.Add("WarningImage", lobjDatabaseReader.GetValue(1))
            plcHolder.Visible = True
        Else
            img = New Image
            img.CssClass = "productimage"
            img.ImageUrl = lobjDatabaseReader.GetValue(1)
            plcProductImage.Controls.Clear()
            plcProductImage.Controls.Add(img)
            plcHolder.Controls.Clear()
            plcHolder.Visible = False
        End If
    End If

    '*  4 : Close out the database connection, command and reader here now.
    lobjDatabaseCommand.Dispose()
    lobjDatabaseConnection.Close()
    lobjDatabaseConnection.Dispose()


End Sub
End Class