Imports CyberSource
Imports CyberSource.CyberSourceServices
Public Class Test
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim MerchantProcessor As New CyberSourceServices
        Dim MerchantProcessorLineItem As New LineItem
        Dim TaxShipTo As New Address
        Dim ClientCard As New CreditCard

        MerchantProcessor.MerchantReferenceCode = "148705832705344"
        MerchantProcessorLineItem.ID = "0"
        MerchantProcessorLineItem.UnitPrice = "50.00"
        MerchantProcessorLineItem.ProductCode = "1234"
        MerchantProcessorLineItem.Quantity = 1
        MerchantProcessorLineItem.ProductName = "Test Product"
        MerchantProcessorLineItem.ProductSKU = "abcde"
        MerchantProcessor.addLineItem(MerchantProcessorLineItem)
        TaxShipTo.FirstName = "Valtim"
        TaxShipTo.LastName = "Test"
        TaxShipTo.AddressLine1 = "1095 Venture Drive"
        TaxShipTo.City = "Forest"
        TaxShipTo.State = "VA"
        TaxShipTo.PostalCode = "24523"
        TaxShipTo.Country = "US"
        TaxShipTo.Email = "test@valtim.com"
        MerchantProcessor.ShippingAddress = TaxShipTo
        MerchantProcessor.BillingAddress = TaxShipTo
        ClientCard.AccountNumber = "4111111111111111"
        ClientCard.ExpirationMonth = "12"
        ClientCard.ExpirationYear = "2015"
        ClientCard.CVNumber = "123"
        MerchantProcessor.Card = ClientCard
        Dim TaxTotal As TaxInformation = MerchantProcessor.getTaxInformation()
        Response.Write(TaxTotal.TaxTotal)

    End Sub

End Class