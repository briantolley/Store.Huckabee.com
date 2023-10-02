Public Class Catalog
    Inherits System.Web.UI.Page
    Public lstrCatalogGroupName As String = ""
    Public lstrCatalogItemsForSelectedGroup As String = ""
    Public lstrDesignSliderItems As String = ""

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

    '*  1 : Define the local variables to be used here now.
    Dim lblnReturnCode As Boolean = False
    Dim llngColumnLoopVariable As Long = 0
    Dim llngRowLoopVariable As Long = 0
    Dim lobjDatabaseConnection As New SqlClient.SqlConnection
    Dim lobjDatabaseCommand As New SqlClient.SqlCommand
    Dim lobjDatabaseReader As SqlClient.SqlDataReader

    '*  2 : Start by making the connection to the database for accessing the system.
    lobjDatabaseConnection.ConnectionString = "Data Source=storefrontdb001;Initial Catalog=StoreFront;Persist Security Info=True;User ID=sa;Password=hdvGL15?Valtim"
    lobjDatabaseConnection.Open()
    lobjDatabaseCommand.Connection = lobjDatabaseConnection

    '*  3 : Start by determining the filter approach need to get the data we want now.
    If (Request.QueryString("Type") <> "") Then
        lstrCatalogGroupName = Request.QueryString("Type")
        If (UCase(lstrCatalogGroupName) <> "VOLUME DISCOUNTS") Then
            lobjDatabaseCommand.CommandText = "SELECT Min(ItemID), BrandName, ItemGroup, Min(Price), ThumbnailImage, ISNULL(BulkPriceBreakQty, 0) AS BulkPriceBreakQty FROM site.Items WITH (nolock) GROUP BY ItemClass, BrandName, ItemGroup, ThumbnailImage, site.Items.IsActive, Warning, BulkPriceBreakQty HAVING (ItemClass = '" & Replace(Request.QueryString("Type"), "'", "''") & "') AND (site.Items.IsActive = 1)  AND (ThumbnailImage IS NOT NULL) AND (Warning IS NULL) ORDER BY ItemGroup, Min(ItemID)"
        Else
            lobjDatabaseCommand.CommandText = "SELECT Min(ItemID), BrandName, ItemGroup, Min(Price), ThumbnailImage, ISNULL(BulkPriceBreakQty, 0) AS BulkPriceBreakQty FROM site.Items WITH (nolock) GROUP BY ItemClass, BrandName, ItemGroup, ThumbnailImage, site.Items.IsActive, Warning, BulkPriceBreakQty HAVING (BulkPriceBreakQty > 0) AND (site.Items.IsActive = 1)  AND (ThumbnailImage IS NOT NULL) AND (Warning IS NULL) ORDER BY ItemGroup, Min(ItemID)"
        End If
    Else
        lstrCatalogGroupName = Request.QueryString("Design")
        lobjDatabaseCommand.CommandText = "SELECT Min(ItemID), BrandName, ItemGroup, Min(Price), ThumbnailImage, ISNULL(BulkPriceBreakQty, 0) AS BulkPriceBreakQty FROM site.Items WITH (nolock) GROUP BY ItemClass, BrandName, ItemGroup, ThumbnailImage, site.Items.IsActive, Warning, BulkPriceBreakQty HAVING (BrandName = '" & Replace(Request.QueryString("Design"), "'", "''") & "') AND (ThumbnailImage IS NOT NULL) AND (site.Items.IsActive = 1) AND (Warning IS NULL) ORDER BY ItemGroup, BrandName, Min(ItemID)"
    End If
    lobjDatabaseCommand.CommandTimeout = 0

    '*  4 : Now fetch the information and populate the screen here.
    lobjDatabaseReader = lobjDatabaseCommand.ExecuteReader
    lstrCatalogItemsForSelectedGroup = ""
    Do While (lobjDatabaseReader.Read())

        '*  A : Check to see if this is the start of a new row and more than the zero row.
        If (llngColumnLoopVariable = 0) And (llngRowLoopVariable > 0) Then
            lstrCatalogItemsForSelectedGroup = lstrCatalogItemsForSelectedGroup + "<tr style=""text-align: left; height: 50px; border: 0px; width: 100%; padding: 0px; margin: 0px; border-width: 0px;"">"
            lstrCatalogItemsForSelectedGroup = lstrCatalogItemsForSelectedGroup + "<td style=""text-align: left;"">&nbsp;</td>"
            lstrCatalogItemsForSelectedGroup = lstrCatalogItemsForSelectedGroup + "</tr>"
        End If

        '*  B : Check to see if this is the start of a new row here.
        If (llngColumnLoopVariable = 0) Then
            lstrCatalogItemsForSelectedGroup = lstrCatalogItemsForSelectedGroup + "<tr style=""text-align: left; border: 0px; width: 100%; padding: 0px; margin: 0px; border-width: 0px;"">"
            lstrCatalogItemsForSelectedGroup = lstrCatalogItemsForSelectedGroup + "<td style=""text-align: left;"">"
            lstrCatalogItemsForSelectedGroup = lstrCatalogItemsForSelectedGroup + "<table border=""0"" style=""table-layout: fixed;border: 0px; width: 100%; padding: 0px; margin: 0px; border-width: 0px; empty-cells: hide; border-collapse: collapse; border-spacing: 0px;"">"
            lstrCatalogItemsForSelectedGroup = lstrCatalogItemsForSelectedGroup + "<tr style=""text-align: left; border: 0px; width: 100%; padding: 0px; margin: 0px; border-width: 0px;"">"
            lstrCatalogItemsForSelectedGroup = lstrCatalogItemsForSelectedGroup + "<td style=""text-align: center;width:25%"">"
        End If

        '*  C : Now add the additional column's specific data here now.
        lstrCatalogItemsForSelectedGroup = lstrCatalogItemsForSelectedGroup + "<a href=""Product.aspx?Id=" & lobjDatabaseReader.GetValue(0) & """ style=""color: #000000;text-decoration: none"">"
        lstrCatalogItemsForSelectedGroup = lstrCatalogItemsForSelectedGroup + "<img src=""" & lobjDatabaseReader.GetValue(4) & """ style=""width: 70%; height: auto;text-decoration: none""/><br />"
        lstrCatalogItemsForSelectedGroup = lstrCatalogItemsForSelectedGroup + "<label for=""label2"" style=""font-family:'Open Sans', Helvetica, sans-serif;font-weight:600;font-size:100%;color: #000000;text-decoration: none;"">" & lobjDatabaseReader.GetValue(1) & "</label><br />"
        lstrCatalogItemsForSelectedGroup = lstrCatalogItemsForSelectedGroup + "<label for=""label2"" style=""font-family:'Open Sans', Helvetica, sans-serif;font-weight:300;font-size:100%;color: #000000;text-decoration: none;"">" & lobjDatabaseReader.GetValue(2) & "</label><br />"
        lstrCatalogItemsForSelectedGroup = lstrCatalogItemsForSelectedGroup + "<label for=""label2"" style=""font-family:'Open Sans', Helvetica, sans-serif;font-weight:800;font-size:100%;color: #000000;text-decoration: none;"">" & FormatCurrency(lobjDatabaseReader.GetValue(3), 2) & "</label>"
        If (lobjDatabaseReader.GetValue(5) > 0) Then
            lstrCatalogItemsForSelectedGroup = lstrCatalogItemsForSelectedGroup + "<label for=""label2"" style=""font-family:'Open Sans', Helvetica, sans-serif;font-weight:600;font-size:100%;color: #000000;text-decoration: none;"">*</label><br><label for=""label2"" style=""font-family:'Open Sans', Helvetica, sans-serif;font-weight:600;font-size:66%;color: #FF0000;text-decoration: none;""><i>* volume discount eligible</i></label>"
        Else
            lstrCatalogItemsForSelectedGroup = lstrCatalogItemsForSelectedGroup + "</br>"
        End If
        lstrCatalogItemsForSelectedGroup = lstrCatalogItemsForSelectedGroup + "</br>"
        lstrCatalogItemsForSelectedGroup = lstrCatalogItemsForSelectedGroup + "<img src=""Images/ButtonBuyNow.png"" style=""text-decoration: none""/><br />"
        lstrCatalogItemsForSelectedGroup = lstrCatalogItemsForSelectedGroup + "</a>"

        '*  D : Check to see where we are on the column and how to close out this step of the loop.
        If (llngColumnLoopVariable < 3) Then
            lstrCatalogItemsForSelectedGroup = lstrCatalogItemsForSelectedGroup + "</td>"
            lstrCatalogItemsForSelectedGroup = lstrCatalogItemsForSelectedGroup + "<td style=""text-align: center;width:25%"">"
            llngColumnLoopVariable = (llngColumnLoopVariable + 1)
        Else
            lstrCatalogItemsForSelectedGroup = lstrCatalogItemsForSelectedGroup + "</td>"
            lstrCatalogItemsForSelectedGroup = lstrCatalogItemsForSelectedGroup + "</tr> "
            lstrCatalogItemsForSelectedGroup = lstrCatalogItemsForSelectedGroup + "</table> "
            lstrCatalogItemsForSelectedGroup = lstrCatalogItemsForSelectedGroup + "</td>"
            lstrCatalogItemsForSelectedGroup = lstrCatalogItemsForSelectedGroup + "</tr>"
            llngRowLoopVariable = (llngRowLoopVariable + 1)
            llngColumnLoopVariable = 0
        End If

    Loop
    lobjDatabaseReader.Close()

    '*  E : Handle the clean up here now.
    Do While (llngColumnLoopVariable <> 0)
        If (llngColumnLoopVariable < 3) Then
            lstrCatalogItemsForSelectedGroup = lstrCatalogItemsForSelectedGroup + "</td>"
            lstrCatalogItemsForSelectedGroup = lstrCatalogItemsForSelectedGroup + "<td style=""text-align: center;width:25%"">"
            llngColumnLoopVariable = (llngColumnLoopVariable + 1)
        Else
            lstrCatalogItemsForSelectedGroup = lstrCatalogItemsForSelectedGroup + "</td>"
            lstrCatalogItemsForSelectedGroup = lstrCatalogItemsForSelectedGroup + "</tr> "
            lstrCatalogItemsForSelectedGroup = lstrCatalogItemsForSelectedGroup + "</table> "
            lstrCatalogItemsForSelectedGroup = lstrCatalogItemsForSelectedGroup + "</td>"
            lstrCatalogItemsForSelectedGroup = lstrCatalogItemsForSelectedGroup + "</tr>"
            llngRowLoopVariable = (llngRowLoopVariable + 1)
            llngColumnLoopVariable = 0
        End If
    Loop

    '*  5 : Close out the database connection, command and reader here now.
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