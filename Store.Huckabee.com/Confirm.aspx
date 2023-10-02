<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Confirm.aspx.vb" Inherits="Store.Huckabee.com.Confirm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Checkout - Order Confirmation</title>
    <link rel="shortcut icon" type="image/png" href="Images/icon.png" />
    <script type="text/javascript" src="jquery-1.11.2.min.js"></script>
    <link href="http://fonts.googleapis.com/css?family=Open+Sans:400italic,400,300,600,700,800" rel="stylesheet" type="text/css"/>
    <link href="https://fonts.googleapis.com/css?family=Open+Sans:400italic,400,300,600,700,800" rel="stylesheet" type="text/css"/>
    <style>
        .btnDown {
            width:100%;
            border-style: 0; 
            opacity:1;
            -moz-opacity:1;
            filter:alpha(opacity=100);
            border-width: 0px; 
            height:40px; 
            border-radius: 5px; 
            background-color: #808080; 
            font-family:'Open Sans', Helvetica, sans-serif;
            font-weight:600;
            font-size:100%; 
            color: white; 
            text-decoration: none;
        }
        .btnUp {
            width:100%;
            border-style: 0; 
            opacity:1;
            -moz-opacity:1;
            filter:alpha(opacity=100);
            border-width: 0px; 
            height:40px; 
            border-radius: 5px;
            background-color: #38FF01; 
            font-family:'Open Sans', Helvetica, sans-serif; 
            font-weight:600; 
            font-size:100%; 
            color: white; 
            text-decoration: none;
        }
        .check {
            height:30px;
            font-family:'Open Sans', Helvetica, sans-serif;
            font-weight:600;
            font-size:100%;
            color: black;
        }
        .select {
            height:29px;
            width:223px;
            border-radius: 4px 4px;
            font-family:'Open Sans', Helvetica, sans-serif;
            font-weight:600;
            font-size:100%;
            color: black;
            border-style:solid;
            border-color:lightgray;
            border-width: 1px;
        }
        .select2 {
            height:30px;
            width:223px;
            border-radius: 4px 4px;
            font-family:'Open Sans', Helvetica, sans-serif;
            font-weight:600;
            font-size:100%;
            color: black;
            border-style:solid;
            border-color:lightgray;
            border-width: 1px;
        }
        .select3 {
            height:30px;
            width:98px;
            border-radius: 4px 4px;
            font-family:'Open Sans', Helvetica, sans-serif;
            font-weight:600;
            font-size:100%;
            color: black;
            border-style:solid;
            border-color:lightgray;
            border-width: 1px;
        }
        .input {
            height:25px;
            width:100%;
            border-radius: 4px 4px;
            font-family:'Open Sans', Helvetica, sans-serif;
            font-weight:600;
            font-size:100%;
            color: black;
            border-style:solid;
            border-color:lightgray;
            border-width: 1px;
        }
        .label {
            height:25px;
            width:100%;
            font-family:'Open Sans', Helvetica, sans-serif;
            font-weight:600;
            font-size:100%;
            color: black;
        }
        .regularlabel {
            height:25px;
            width:100%;
            font-family:'Open Sans', Helvetica, sans-serif;
            font-weight:300;
            font-size:100%;
            color: black;
        }
        .softlabel {
            height:25px;
            width:100%;
            font-family:'Open Sans', Helvetica, sans-serif;
            font-weight:300;
            font-size:100%;
            color: lightgray;
        }    
    </style>
</head>
<body style="padding: 0px; margin: 0px;"  >
    <form id="form1" runat="server">
        <table style="table-layout: fixed;border: 0px; width: 100%; height: 100%; padding: 0px; margin: 0px; border-width: 0px; empty-cells: hide; border-collapse: collapse; border-spacing: 0px;min-width:800px">
            <tr>
                <td>
                    <!-- #include file="Includes/Header.aspx -->
                    <table  border="0" style="border-style: solid; table-layout: fixed; width: 100%; padding: 0px; margin: 0px; border-width: 1px 0px 0px 0px; empty-cells: hide; border-collapse: collapse; border-spacing: 0px; border-top-color: #BFBFBF; border-right-color: inherit; border-bottom-color: inherit; border-left-color: inherit;">
                        <tr style="text-align: left; vertical-align: top; height: 400px; border: 0px; width: 100%; padding: 0px; margin: 0px; border-width: 0px; background-repeat: repeat;">
                            <td style="width:8.2%;"></td>
                            <td style="width:40%;">
                                <br /><br />
                                <table border="0" style="padding: 0px; margin: 0px; empty-cells: hide; border-collapse: collapse; border-spacing: 0px;width:100%;-moz-box-shadow: 5px 5px 1px #CCCCCC;-webkit-box-shadow: 5px 5px 1px #CCCCCC;box-shadow: 5px 5px 1px  #CCCCCC;">
                                    <tr>
                                        <td>
                                            <table border="0" style="padding: 0px; margin: 0px; empty-cells: hide; border-collapse: collapse; border-spacing: 0px;width:100%;">
                                                <tr style="height:50px;">
                                                    <td style="vertical-align:middle; font-family:'Open Sans', Helvetica, sans-serif;font-weight:600;font-size:100%;color: white;text-decoration: none;width:33.33%; border-radius: 5px 0px 0px 0px; background-color: #2A74D7;"><a href="Shipping.aspx" style="text-decoration: none;color: white;">&nbsp;&nbsp;&nbsp;Shipping</a></td>
                                                    <td style="width:3px; background-color: white;"></td>
                                                    <td style="vertical-align:middle; font-family:'Open Sans', Helvetica, sans-serif;font-weight:600;font-size:100%;color: white;text-decoration: none;width:33.33%; background-color: #2A74D7;"><a href="Payment.aspx" style="text-decoration: none;color: white;">&nbsp;&nbsp;&nbsp;Payment</a></td>
                                                    <td style="width:3px; background-color: white;"></td>
                                                    <td style="vertical-align:middle; font-family:'Open Sans', Helvetica, sans-serif;font-weight:600;font-size:100%;color: white;text-decoration: none;width:33.33%; border-radius: 0px 5px 0px 0px; background-color: #D6252E;">&nbsp;&nbsp;&nbsp;Confirmation</td>
                                                </tr>
                                            </table>    
                                            <table border="0" style="width:100%;">
                                                <tr style="height:3px; background-color: white;">
                                                    <td></td>
                                                </tr>
                                            </table>
                                            <table border="0" style="width:100%;background-color: #F2F2F2;">
                                                <tr style="vertical-align:top;height:100%; background-color: #F2F2F2;">
                                                    <td style="vertical-align:top;border-radius: 0px 0px 5px 5px;background-color: #F2F2F2;">
                                                        <br />
                                                        <table border="0" style="width:100%;">
                                                            <tr style="vertical-align:top;">
                                                                <td style="width:10px;"></td>
                                                                <td style="vertical-align:top;">
                                                                    <asp:Label ID="Label9" runat="server" Text="Label" CssClass="regularlabel">
                                                                        Below, please review the information you have provided for shipping and payment information in addition to the items you have selected to order.  Once you are satisfied please click the confirm button once only to complete your order.<br />
                                                                    </asp:Label>
                                                                    <asp:Label ID="Label10" runat="server" Text="Label" CssClass="softlabel">--------------------------------------------------------------------------------------</asp:Label>
                                                                </td>
                                                                <td style="width:15px;"></td>
                                                            </tr>
                                                            <tr style="vertical-align:top;">
                                                                <td style="width:16px;"></td>
                                                                <td style="vertical-align:top;">
                                                                    <asp:Label ID="Label12" runat="server" Text="Label" CssClass="label">&nbsp;1. Selected Products:</asp:Label>
                                                                    <table border="0" style="width:100%;padding: 0px; margin: 0px; empty-cells: hide; border-collapse: collapse; border-spacing: 0px;">
                                                                        <tr style="vertical-align:top;height:5px;">
                                                                            <td></td>
                                                                            <td></td>
                                                                            <td></td>
                                                                            <td></td>
                                                                            <td></td>
                                                                        </tr>
                                                                        <tr style="vertical-align:top;">
                                                                            <td style="width:16px;"></td>
                                                                            <td style="width:220px; font-family:'Open Sans', Helvetica, sans-serif;font-weight:600;font-size:80%;color: #044C86;">
                                                                                Item
                                                                            </td>
                                                                            <td style="text-align:right;width:30px; font-family:'Open Sans', Helvetica, sans-serif;font-weight:600;font-size:80%;color: #044C86;">
                                                                                Qty #
                                                                            </td>
                                                                            <td style="text-align:right;width:40px;font-family:'Open Sans', Helvetica, sans-serif;font-weight:600;font-size:80%;color: #044C86;">
                                                                                Unit $
                                                                            </td>
                                                                            <td style="text-align:right;width:60px;font-family:'Open Sans', Helvetica, sans-serif;font-weight:600;font-size:80%;color: #044C86;">
                                                                                Extnd $
                                                                            </td>
                                                                        </tr>
                                                                        <% =lstrFinalizedItems %>
                                                                        <tr style="vertical-align:top;height:1px;padding: 0px; margin: 0px; empty-cells: hide; border-collapse: collapse; border-spacing: 0px;">
                                                                            <td></td>
                                                                            <td style="border-style: solid none none none; border-width: 1px; border-color: #C0C0C0; vertical-align:top;">&nbsp;</td>
                                                                            <td style="border-style: solid none none none; border-width: 1px; border-color: #C0C0C0; vertical-align:top;">&nbsp;</td>
                                                                            <td style="border-style: solid none none none; border-width: 1px; border-color: #C0C0C0; vertical-align:top;">&nbsp;</td>
                                                                            <td style="border-style: solid none none none; border-width: 1px; border-color: #C0C0C0; vertical-align:top;">&nbsp;</td>
                                                                        </tr>
                                                                        <tr style="vertical-align:top;">
                                                                            <td style="width:16px;"></td>
                                                                            <td style="width:220px; font-family:'Open Sans', Helvetica, sans-serif;font-weight:300;font-size:80%;color: black;">
                                                                                Subtotal
                                                                            </td>
                                                                            <td style="text-align:right;width:30px; font-family:'Open Sans', Helvetica, sans-serif;font-weight:300;font-size:80%;color: black;"></td>
                                                                            <td style="text-align:right;width:40px;font-family:'Open Sans', Helvetica, sans-serif;font-weight:300;font-size:80%;color: black;"></td>
                                                                            <td style="text-align:right;width:60px;font-family:'Open Sans', Helvetica, sans-serif;font-weight:300;font-size:80%;color: black;">
                                                                                <% = FormatCurrency(ldblSubTotal, 2)%>
                                                                            </td>
                                                                        </tr>
                                                                        <tr style="vertical-align:top;">
                                                                            <td style="width:16px;"></td>
                                                                            <td style="width:220px; font-family:'Open Sans', Helvetica, sans-serif;font-weight:300;font-size:80%;color: black;">
                                                                                Taxes
                                                                            </td>
                                                                            <td style="text-align:right;width:30px; font-family:'Open Sans', Helvetica, sans-serif;font-weight:300;font-size:80%;color: black;"></td>
                                                                            <td style="text-align:right;width:60px;font-family:'Open Sans', Helvetica, sans-serif;font-weight:300;font-size:80%;color: black;"></td>
                                                                            <td style="text-align:right;width:60px;font-family:'Open Sans', Helvetica, sans-serif;font-weight:300;font-size:80%;color: black;">
                                                                                <% =FormatCurrency(ldblTaxes, 2)%>
                                                                            </td>
                                                                        </tr>
                                                                        <tr style="vertical-align:top;">
                                                                            <td style="width:16px;"></td>
                                                                            <td style="width:220px; font-family:'Open Sans', Helvetica, sans-serif;font-weight:300;font-size:80%;color: black;">
                                                                                Shipping
                                                                            </td>
                                                                            <td style="text-align:right;width:30px; font-family:'Open Sans', Helvetica, sans-serif;font-weight:300;font-size:80%;color: black;"></td>
                                                                            <td style="text-align:right;width:60px;font-family:'Open Sans', Helvetica, sans-serif;font-weight:300;font-size:80%;color: black;"></td>
                                                                            <td style="text-align:right;width:60px;font-family:'Open Sans', Helvetica, sans-serif;font-weight:300;font-size:80%;color: black;">
                                                                                <% =FormatCurrency(ldblShippingFee, 2)%>
                                                                            </td>
                                                                        </tr>
                                                                        <tr style="vertical-align:top;">
                                                                            <td style="width:16px;"></td>
                                                                            <td style="width:220px; font-family:'Open Sans', Helvetica, sans-serif;font-weight:600;font-size:80%;color: black;">
                                                                                Total
                                                                            </td>
                                                                            <td style="text-align:right;width:30px; font-family:'Open Sans', Helvetica, sans-serif;font-weight:300;font-size:80%;color: black;"></td>
                                                                            <td style="text-align:right;width:60px;font-family:'Open Sans', Helvetica, sans-serif;font-weight:300;font-size:80%;color: black;"></td>
                                                                            <td style="text-align:right;width:60px;font-family:'Open Sans', Helvetica, sans-serif;font-weight:600;font-size:80%;color: black;">
                                                                                <% = FormatCurrency(ldblSubTotal + ldblTaxes + ldblShippingFee, 2)%>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                                <td style="width:15px;"></td>
                                                            </tr>
                                                            <tr style="vertical-align:top;">
                                                                <td style="width:10px;"></td>
                                                                <td style="vertical-align:top;">
                                                                    <asp:Label ID="Label3" runat="server" Text="Label" CssClass="softlabel">--------------------------------------------------------------------------------------</asp:Label>
                                                                </td>
                                                                <td style="width:15px;"></td>
                                                            </tr>
                                                            <tr style="vertical-align:top;">
                                                                <td style="width:10px;"></td>
                                                                <td style="vertical-align:top;">
                                                                    <table border="0" style="width:100%;padding: 0px; margin: 0px; empty-cells: hide; border-collapse: collapse; border-spacing: 0px;">
                                                                        <tr>
                                                                            <td style="width:220px;">
                                                                                <asp:Label ID="Label1" runat="server" Text="Label" CssClass="label">&nbsp;2. Shipping:</asp:Label>
                                                                                <table border="0" style="width:100%;padding: 0px; margin: 0px; empty-cells: hide; border-collapse: collapse; border-spacing: 0px;">
                                                                                    <tr style="vertical-align:top;">
                                                                                        <td style="width:20px;"></td>
                                                                                        <td style="width:200px; font-family:'Open Sans', Helvetica, sans-serif;font-weight:300;font-size:80%;color: black;">
                                                                                            <% = lstrShippingDetails %>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="Label6" runat="server" Text="Label" CssClass="label">&nbsp;3. Billing:</asp:Label>
                                                                                <table border="0" style="width:100%;padding: 0px; margin: 0px; empty-cells: hide; border-collapse: collapse; border-spacing: 0px;">
                                                                                    <tr style="vertical-align:top;">
                                                                                        <td style="width:20px;"></td>
                                                                                        <td style="width:200px; font-family:'Open Sans', Helvetica, sans-serif;font-weight:300;font-size:80%;color: black;">
                                                                                            <% = lstrBillingDetails %>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                                <td style="width:15px;"></td>
                                                            </tr>
                                                            <tr style="vertical-align:top;">
                                                                <td style="width:10px;"></td>
                                                                <td style="vertical-align:top;">
                                                                    <asp:Label ID="Label2" runat="server" Text="Label" CssClass="softlabel">--------------------------------------------------------------------------------------</asp:Label>
                                                                </td>
                                                                <td style="width:15px;"></td>
                                                            </tr>
                                                            <tr style="vertical-align:top;">
                                                                <td style="width:10px;"></td>
                                                                <td style="vertical-align:top;">
                                                                    <table border="0" style="width:100%;padding: 0px; margin: 0px; empty-cells: hide; border-collapse: collapse; border-spacing: 0px;">
                                                                        <tr style="vertical-align:top;">
                                                                            <td style="vertical-align:top;width:48%">
                                                                                <asp:Button ID="btnPayment" runat="server" Text="Previous" CssClass="btnDown" />
                                                                            </td>
                                                                            <td style="width:2.5%;"></td>
                                                                            <td style="vertical-align:top;">
                                                                                <asp:Button ID="btnPlaceOrder" runat="server" Text="Confirm" CssClass="btnUp" />
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                                <td style="width:15px;"></td>
                                                            </tr>
                                                            <tr style="vertical-align:top;height:10px;">
                                                                <td style="width:10px;"></td>
                                                                <td style="vertical-align:top;"></td>
                                                                <td style="width:15px;"></td>
                                                            </tr>   
                                                            <tr style="vertical-align:top;height:10px;">
                                                                <td style="width:10px;"></td>
                                                                <td style="vertical-align:top;"></td>
                                                                <td style="width:15px;"></td>
                                                            </tr>
                                                        </table>    
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table><br />
                                <% If Len(Session("ProcessingFailureNotice")) > 0 Then%>
                                    <label for="label2" style="font-family:'Open Sans', Helvetica, sans-serif;font-weight:300;font-size:80%;color: red;text-decoration: none;"><% = Session("ProcessingFailureNotice")%></label><br /><br />
                                    <% Session("ProcessingFailureNotice") = ""%>
                                <% End If%>
                            </td>
                            <td style="width:80px;text-align:right;">
                                <br /><br /><br /><br /><img src="Images/CartItemVerticalSeperator.png" />&nbsp;&nbsp;&nbsp;
                            </td>
                            <td style="text-align:center;">
                                <table border="0" style="border-width: 0px; height:100%; border-style: none; table-layout: fixed; width: 100%; padding: 0px; margin: 0px; empty-cells: hide; border-collapse: collapse; border-spacing: 0px;">
                                    <tr style="text-align: left; vertical-align:top; height:100%; border: 0px; width: 100%; padding: 0px; margin: 0px; border-width: 0px; background-repeat: repeat;">
                                        <td style="width:25%;">
                                            <br /><br /><br /><br />
                                        </td>
                                        <td style="text-align: left; vertical-align:top; width: 10px; padding: 0px; margin: 0px;"></td>
                                        <td style="text-align: left; vertical-align:top; width: 45%; padding: 0px; margin: 0px;"></td>
                                        <td style="text-align: left; vertical-align:top; width: 25%; padding: 0px; margin: 0px;"></td>
                                    </tr>
                                    <% = lstrCartItems %>
                                    <tr style="background-position: bottom; padding: 0px; margin: 0px; empty-cells: hide; border-collapse: collapse; border-spacing: 0px; background-image: url('Images/HuckabeeSubHeaderSeperator.png'); background-repeat: no-repeat">
                                        <td style="width:25%;text-align: left; vertical-align:top; border-spacing: 0px;padding: 0px; margin: 0px;">&nbsp;</td>
                                        <td style="text-align: left; vertical-align:top; width: 10px; border-spacing: 0px;padding: 0px; margin: 0px;"></td>
                                        <td style="text-align: left; vertical-align:top; width: 45%; border-spacing: 0px;padding: 0px; margin: 0px;"></td>
                                        <td style="text-align: right; vertical-align:top; width: 25%; border-spacing: 0px;padding: 0px; margin: 0px;"><br /></td>
                                    </tr>
                                    <tr>
                                        <td style="width:25%;text-align:left;"><label for="label2" style="font-family:'Open Sans', Helvetica, sans-serif;font-weight:300;font-size:100%;color: black;text-decoration: none;">SUBTOTAL</label></td>
                                        <td style="text-align: left; vertical-align:top; width: 10px; padding: 0px; margin: 0px;"></td>
                                        <td style="text-align: left; vertical-align:top; width: 45%; padding: 0px; margin: 0px;"></td>
                                        <td style="text-align: right; vertical-align:top; width: 25%; padding: 0px; margin: 0px;">
                                            <label for="label2" style="font-family:'Open Sans', Helvetica, sans-serif;font-weight:300;font-size:100%;color: black;text-decoration: none;"><% =FormatCurrency(ldblSubTotal, 2)%>&nbsp;</label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width:25%;text-align:left;"><label for="label2" style="font-family:'Open Sans', Helvetica, sans-serif;font-weight:300;font-size:100%;color: black;text-decoration: none;">TAXES</label></td>
                                        <td style="text-align: left; vertical-align:top; width: 10px; padding: 0px; margin: 0px;"></td>
                                        <td style="text-align: left; vertical-align:top; width: 45%; padding: 0px; margin: 0px;"><label for="label2" style="font-family:'Open Sans', Helvetica, sans-serif;font-weight:300;font-size:100%;color: black;text-decoration: none;"></label></td>
                                        <td style="text-align: right; vertical-align:top; width: 25%; padding: 0px; margin: 0px;">
                                            <label for="label2" style="font-family:'Open Sans', Helvetica, sans-serif;font-weight:300;font-size:100%;color: black;text-decoration: none;"><% = FormatCurrency(ldblTaxes, 2)%>&nbsp;</label>
                                        </td>
                                    </tr> 
                                    <tr>
                                        <td style="width:25%;text-align:left;"><label for="label2" style="font-family:'Open Sans', Helvetica, sans-serif;font-weight:300;font-size:100%;color: black;text-decoration: none;">SHIPPING</label></td>
                                        <td style="text-align: left; vertical-align:top; width: 10px; padding: 0px; margin: 0px;"></td>
                                        <td style="text-align: left; vertical-align:top; width: 45%; padding: 0px; margin: 0px;"><label for="label2" style="font-family:'Open Sans', Helvetica, sans-serif;font-weight:300;font-size:100%;color: black;text-decoration: none;">( <% = UCase(lstrShippingMethod)%>)</label></td>
                                        <td style="text-align: right; vertical-align:top; width: 25%; padding: 0px; margin: 0px;">
                                            <label for="label2" style="font-family:'Open Sans', Helvetica, sans-serif;font-weight:300;font-size:100%;color: black;text-decoration: none;"><% =FormatCurrency(ldblShippingFee, 2)%>&nbsp;</label>
                                        </td>
                                    </tr>    
                                    <tr>
                                        <td><br /><br /></td>
                                        <td style="width:25%;text-align: left; vertical-align:top; width: 10px; padding: 0px; margin: 0px;"></td>
                                        <td style="text-align: left; vertical-align:top; width: 45%; padding: 0px; margin: 0px;"></td>
                                        <td style="text-align: right; vertical-align:top; width: 25%; padding: 0px; margin: 0px;"></td>
                                    </tr>  
                                </table>    
                            </td>
                            <td style="width:8.2%;"></td>
                        </tr>
                    </table>

                    <!-- #include file="Includes/Footer.aspx -->
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
