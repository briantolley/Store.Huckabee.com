Public Class Remove
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    '*  0 : Check to see if a session is set up and if not do so now.
    If (Session("Id") = "") Then
        Response.Redirect("Home.aspx")
    End If

    '*  1 : Define the local variables to be used here now.
    Dim lblnReturnCode As Boolean = False
    Dim lobjDatabaseConnection As New SqlClient.SqlConnection
    Dim lobjDatabaseCommand As New SqlClient.SqlCommand

    '*  2 : Start by making the connection to the database for accessing the system.        
    lobjDatabaseConnection.ConnectionString = "Data Source=storefrontdb001;Initial Catalog=StoreFront;Persist Security Info=True;User ID=sa;Password=hdvGL15?Valtim"
    lobjDatabaseConnection.Open()
    lobjDatabaseCommand.Connection = lobjDatabaseConnection

    '*  3 : Remove the requested item from the system here now.
    lobjDatabaseCommand.CommandTimeout = 0
    lobjDatabaseCommand.CommandText = "DELETE FROM session.TempLineItems WHERE (session.TempLineItems.TempLineItemID = " & Request.QueryString("Id") & ")"
    lobjDatabaseCommand.ExecuteNonQuery()
    Session("CartCount") = (Int(Session("CartCount")) - 1)

    '*  4 : Close out the database connection, command and reader here now.
    lobjDatabaseCommand.Dispose()
    lobjDatabaseConnection.Close()
    lobjDatabaseConnection.Dispose()
    Response.Redirect("Cart.aspx")

    End Sub

End Class