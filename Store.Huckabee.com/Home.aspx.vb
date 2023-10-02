Public Class Home
    Inherits System.Web.UI.Page
    Public lstrBannerSliderItems As String = ""
    Public lstrProductSliderItems As String = ""
    Public lstrDesignSliderItems As String = ""


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    If Request.ServerVariables("SERVER_PORT") = 80 Then
            Response.Redirect("https://" & Request.ServerVariables("HTTP_HOST"))
    End If

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

    '*  1 : Define the local variables to be used here now.
    Dim lblnReturnCode As Boolean = False
    Dim lobjDatabaseConnection As New SqlClient.SqlConnection
    Dim lobjDatabaseCommand As New SqlClient.SqlCommand
    Dim lobjDatabaseReader As SqlClient.SqlDataReader

    '*  2 : Start by making the connection to the database for accessing the system.        
    lobjDatabaseConnection.ConnectionString = "Data Source=storefrontdb001;Initial Catalog=StoreFront;Persist Security Info=True;User ID=sa;Password=hdvGL15?Valtim"
    lobjDatabaseConnection.Open()
    lobjDatabaseCommand.Connection = lobjDatabaseConnection

    '*  3 : Start by fetching the promotional banner that need to be run first.
    lobjDatabaseCommand.CommandTimeout = 0
    lobjDatabaseCommand.CommandText = "SELECT ItemID, PromoBannerImage FROM site.Items WITH (nolock) WHERE (PromoBannerImage Is Not NULL) AND (site.Items.IsActive = 1) ORDER BY PromoBannerOrder ASC"
    lobjDatabaseReader = lobjDatabaseCommand.ExecuteReader
    lstrBannerSliderItems = ""
    Do While (lobjDatabaseReader.Read())
        lstrBannerSliderItems = lstrBannerSliderItems + "<div class=""owl-item""><a href=""Product.aspx?Id=" & lobjDatabaseReader.GetValue(0) & """><img src=""" & lobjDatabaseReader.GetValue(1) & """ style=""vertical-align:middle; width: 100%; height: 100%"" /></a></div>"
    Loop
    lobjDatabaseReader.Close()

    '*  4 : Continue by fetching the featured products that need to be loaded next.
    lobjDatabaseCommand.CommandTimeout = 0
    lobjDatabaseCommand.CommandText = "SELECT ItemID, BrandName, ItemGroup, Price, ThumbnailImage, ISNULL(BulkPriceBreakQty, 0) AS BulkPriceBreakQty FROM site.Items WITH (NOLOCK) WHERE (ItemID IN (SELECT MIN(ItemID) AS ItemID FROM site.Items AS Items_1 GROUP BY BrandName, ItemGroup HAVING (BrandName IS NOT NULL))) AND (ThumbnailImage IS NOT NULL) ORDER BY CreateDate DESC"
    lobjDatabaseReader = lobjDatabaseCommand.ExecuteReader
    lstrProductSliderItems = ""
    Do While (lobjDatabaseReader.Read())
        lstrProductSliderItems = lstrProductSliderItems + "<div class=""owl-item"">"
        lstrProductSliderItems = lstrProductSliderItems + "<a href=""Product.aspx?Id=" & lobjDatabaseReader.GetValue(0) & """ style=""color: #000000;text-decoration: none"">"
        lstrProductSliderItems = lstrProductSliderItems + "<img src=""" & lobjDatabaseReader.GetValue(4) & """ style=""width: 70%; height: auto;text-decoration: none""/><br />"
        lstrProductSliderItems = lstrProductSliderItems + "<label for=""label2"" style=""font-family:'Open Sans', Helvetica, sans-serif;font-weight:600;font-size:100%;color: #000000;text-decoration: none;"">" & lobjDatabaseReader.GetValue(1) & "</label><br />"
        lstrProductSliderItems = lstrProductSliderItems + "<label for=""label2"" style=""font-family:'Open Sans', Helvetica, sans-serif;font-weight:300;font-size:100%;color: #000000;text-decoration: none;"">" & lobjDatabaseReader.GetValue(2) & "</label><br />"
        lstrProductSliderItems = lstrProductSliderItems + "<label for=""label2"" style=""font-family:'Open Sans', Helvetica, sans-serif;font-weight:800;font-size:100%;color: #000000;text-decoration: none;"">" & FormatCurrency(lobjDatabaseReader.GetValue(3), 2) & "</label>"
        If (lobjDatabaseReader.GetValue(5) > 0) Then
            lstrProductSliderItems = lstrProductSliderItems + "<label for=""label2"" style=""font-family:'Open Sans', Helvetica, sans-serif;font-weight:600;font-size:100%;color: #000000;text-decoration: none;"">*</label><br><label for=""label2"" style=""font-family:'Open Sans', Helvetica, sans-serif;font-weight:600;font-size:66%;color: #FF0000;text-decoration: none;""><i>* volume discount eligible</i></label>"
        Else
            lstrProductSliderItems = lstrProductSliderItems + "</br>"
        End If
        lstrProductSliderItems = lstrProductSliderItems + "</br>"
        lstrProductSliderItems = lstrProductSliderItems + "<img src=""Images/ButtonBuyNow.png"" style=""text-decoration: none""/><br />"
        lstrProductSliderItems = lstrProductSliderItems + "</a>"
        lstrProductSliderItems = lstrProductSliderItems + "</div>"
    Loop
    lobjDatabaseReader.Close()

    '*  4 : Close out the database connection, command and reader here now.
    lobjDatabaseCommand.Dispose()
    lobjDatabaseConnection.Close()
    lobjDatabaseConnection.Dispose()

    lstrDesignSliderItems = ""
    lstrDesignSliderItems = lstrDesignSliderItems + "<div class=""owl-item"">"
    lstrDesignSliderItems = lstrDesignSliderItems + "<a href=""Catalog.aspx?Design=%22Why%20I'm%20a%20Republican%22"" style=""color: #000000;text-decoration: none"">"
    lstrDesignSliderItems = lstrDesignSliderItems + "<img src=""Images/Logo_whyrepublican260-blue.png"" style=""width: 70%; height: auto""/><br />"
    lstrDesignSliderItems = lstrDesignSliderItems + "<label for=""label2"" style=""font-family:'Open Sans', Helvetica, sans-serif;font-weight:600;font-size:100%;color: #000000;text-decoration: none;"">""Why I'm a Republican""</label>"
    lstrDesignSliderItems = lstrDesignSliderItems + "</a>"
    lstrDesignSliderItems = lstrDesignSliderItems + "</div>"
    lstrDesignSliderItems = lstrDesignSliderItems + "<div class=""owl-item"">"
    lstrDesignSliderItems = lstrDesignSliderItems + "<a href=""Catalog.aspx?Design=%22Huckabee%202016%22"" style=""color: #000000;text-decoration: none"">"
    lstrDesignSliderItems = lstrDesignSliderItems + "<img src=""Images/HuckabeeBrandsHuckabee2016.png"" style=""width: 70%; height: auto""/><br />"
    lstrDesignSliderItems = lstrDesignSliderItems + "<label for=""label2"" style=""font-family:'Open Sans', Helvetica, sans-serif;font-weight:600;font-size:100%;color: #000000;text-decoration: none;"">""Huckabee 2016""</label>"
    lstrDesignSliderItems = lstrDesignSliderItems + "</a>"
    lstrDesignSliderItems = lstrDesignSliderItems + "</div>"
    lstrDesignSliderItems = lstrDesignSliderItems + "<div class=""owl-item"">"
    lstrDesignSliderItems = lstrDesignSliderItems + "<a href=""Catalog.aspx?Design=%22I%20Like%20Mike%22"" style=""color: #000000;text-decoration: none"">"
    lstrDesignSliderItems = lstrDesignSliderItems + "<img src=""Images/HuckabeeBrandsILikeMike.png"" style=""width: 70%; height: auto""/><br />"
    lstrDesignSliderItems = lstrDesignSliderItems + "<label for=""label2"" style=""font-family:'Open Sans', Helvetica, sans-serif;font-weight:600;font-size:100%;color: #000000;text-decoration: none;"">""I Like Mike""</label>"
    lstrDesignSliderItems = lstrDesignSliderItems + "</a>"
    lstrDesignSliderItems = lstrDesignSliderItems + "</div>"
    lstrDesignSliderItems = lstrDesignSliderItems + "<div class=""owl-item"">"
    lstrDesignSliderItems = lstrDesignSliderItems + "<a href=""Catalog.aspx?Design=%22Hope%20To%20Higher%20Ground%22"" style=""color: #000000;text-decoration: none"">"
    lstrDesignSliderItems = lstrDesignSliderItems + "<img src=""Images/HuckabeeBrandsHopeToHigherGround.png"" style=""width: 70%; height: auto""/><br />"
    lstrDesignSliderItems = lstrDesignSliderItems + "<label for=""label2"" style=""font-family:'Open Sans', Helvetica, sans-serif;font-weight:600;font-size:100%;color: #000000;text-decoration: none;"">""Hope To Higher Ground""</label>"
    lstrDesignSliderItems = lstrDesignSliderItems + "</a>"
    lstrDesignSliderItems = lstrDesignSliderItems + "</div>"
    lstrDesignSliderItems = lstrDesignSliderItems + "<div class=""owl-item"">"
    lstrDesignSliderItems = lstrDesignSliderItems + "<a href=""Catalog.aspx?Design=%22Defeat%20The%20Clinton%20Machine%22"" style=""color: #000000;text-decoration: none"">"
    lstrDesignSliderItems = lstrDesignSliderItems + "<img src=""Images/HuckabeeBrandsDefeatTheClintonMachine.png"" style=""width: 70%; height: auto""/><br />"
    lstrDesignSliderItems = lstrDesignSliderItems + "<label for=""label2"" style=""font-family:'Open Sans', Helvetica, sans-serif;font-weight:600;font-size:100%;color: #000000;text-decoration: none;"">""Defeat The Clinton Machine""</label>"
    lstrDesignSliderItems = lstrDesignSliderItems + "</a>"
    lstrDesignSliderItems = lstrDesignSliderItems + "</div>"
    lstrDesignSliderItems = lstrDesignSliderItems + "<div class=""owl-item"">"
    lstrDesignSliderItems = lstrDesignSliderItems + "<a href=""Catalog.aspx?Design=%22I'm%20With%20Huck%22"" style=""color: #000000;text-decoration: none"">"
    lstrDesignSliderItems = lstrDesignSliderItems + "<img src=""Images/HuckabeeBrandsImWithHuck.png"" style=""width: 70%; height: auto""/><br />"
    lstrDesignSliderItems = lstrDesignSliderItems + "<label for=""label2"" style=""font-family:'Open Sans', Helvetica, sans-serif;font-weight:600;font-size:100%;color: #000000;text-decoration: none;"">""I'm With Huck""</label>"
    lstrDesignSliderItems = lstrDesignSliderItems + "</a>"
    lstrDesignSliderItems = lstrDesignSliderItems + "</div>"

    End Sub

End Class