<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Payment.aspx.vb" Inherits="Store.Huckabee.com.Payment" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Checkout - Payment Information</title>
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
                                                    <td style="vertical-align:middle; font-family:'Open Sans', Helvetica, sans-serif;font-weight:600;font-size:100%;color: white;text-decoration: none;width:33.33%; background-color: #D6252E;">&nbsp;&nbsp;&nbsp;Payment</td>
                                                    <td style="width:3px; background-color: white;"></td>
                                                    <td style="vertical-align:middle; font-family:'Open Sans', Helvetica, sans-serif;font-weight:600;font-size:100%;color: white;text-decoration: none;width:33.33%; border-radius: 0px 5px 0px 0px; background-color: #2A74D7;">&nbsp;&nbsp;&nbsp;Confirmation</td>
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
                                                                        Below, please provide payment information for your order.   All purchases are treated as contributions and are not tax deductible.<br />
                                                                    </asp:Label>
                                                                    <asp:Label ID="Label10" runat="server" Text="Label" CssClass="softlabel">----------------------------------------------------------------------------------------</asp:Label>
                                                                </td>
                                                                <td style="width:15px;"></td>
                                                            </tr>
                                                            <tr style="vertical-align:top;">
                                                                <td style="width:10px;"></td>
                                                                <td style="vertical-align:top;">
                                                                    <asp:Label ID="Label12" runat="server" Text="Label" CssClass="label">&nbsp;Name on Card</asp:Label>
                                                                    <asp:TextBox ID="txtPayByNameOnCard" runat="server" CssClass="input"></asp:TextBox>
                                                                </td>
                                                                <td style="width:15px;"></td>
                                                            </tr>
                                                            <tr style="vertical-align:top;height:10px;">
                                                                <td style="width:10px;"></td>
                                                                <td style="vertical-align:top;"></td>
                                                                <td style="width:15px;"></td>
                                                            </tr>
                                                            <tr style="vertical-align:top;">
                                                                <td style="width:10px;"></td>
                                                                <td style="vertical-align:top;">
                                                                    <asp:Label ID="Label15" runat="server" Text="Label" CssClass="label">&nbsp;Card Number</asp:Label>
                                                                    <asp:TextBox ID="txtPayByCardNumber" runat="server" CssClass="input"></asp:TextBox>
                                                                </td>
                                                                <td style="width:15px;"></td>
                                                            </tr>
                                                            <tr style="vertical-align:top;height:10px;">
                                                                <td style="width:10px;"></td>
                                                                <td style="vertical-align:top;"></td>
                                                                <td style="width:15px;"></td>
                                                            </tr>
                                                            <tr style="vertical-align:top;">
                                                                <td style="width:10px;"></td>
                                                                <td style="vertical-align:top;">
                                                                    <table border="0" style="width:100%;padding: 0px; margin: 0px; empty-cells: hide; border-collapse: collapse; border-spacing: 0px;">
                                                                        <tr style="vertical-align:top;">
                                                                            <td style="vertical-align:top;">
                                                                                <asp:Label ID="Label11" runat="server" Text="Label" CssClass="label">&nbsp;Month</asp:Label>
                                                                                <asp:DropDownList ID="drpPayByCardExpMonth" CssClass="select3" runat="server">
                                                                                    <asp:ListItem></asp:ListItem>
                                                                                    <asp:ListItem>01</asp:ListItem>
                                                                                    <asp:ListItem>02</asp:ListItem>
                                                                                    <asp:ListItem>03</asp:ListItem>
                                                                                    <asp:ListItem>04</asp:ListItem>
                                                                                    <asp:ListItem>05</asp:ListItem>
                                                                                    <asp:ListItem>06</asp:ListItem>
                                                                                    <asp:ListItem>07</asp:ListItem>
                                                                                    <asp:ListItem>08</asp:ListItem>
                                                                                    <asp:ListItem>09</asp:ListItem>
                                                                                    <asp:ListItem>10</asp:ListItem>
                                                                                    <asp:ListItem>11</asp:ListItem>
                                                                                    <asp:ListItem>12</asp:ListItem>
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                            <td style="width:10px;"></td>
                                                                            <td style="vertical-align:top;">
                                                                                <asp:Label ID="Label16" runat="server" Text="Label" CssClass="label">&nbsp;Year</asp:Label>
                                                                                <asp:DropDownList ID="drpPayByCardExpYear" CssClass="select3" runat="server">
                                                                                    <asp:ListItem></asp:ListItem>
                                                                                    <asp:ListItem>2015</asp:ListItem>
                                                                                    <asp:ListItem>2016</asp:ListItem>
                                                                                    <asp:ListItem>2017</asp:ListItem>
                                                                                    <asp:ListItem>2018</asp:ListItem>
                                                                                    <asp:ListItem>2019</asp:ListItem>
                                                                                    <asp:ListItem>2020</asp:ListItem>
                                                                                    <asp:ListItem>2021</asp:ListItem>
                                                                                    <asp:ListItem>2022</asp:ListItem>
                                                                                    <asp:ListItem>2023</asp:ListItem>
                                                                                    <asp:ListItem>2024</asp:ListItem>
                                                                                    <asp:ListItem>2025</asp:ListItem>
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                            <td style="width:10px;"></td>
                                                                            <td style="vertical-align:top;">
                                                                                <asp:Label ID="Label17" runat="server" Text="Label" CssClass="label">&nbsp;Security Code</asp:Label>
                                                                                <asp:TextBox ID="txtPayByCardCV" runat="server" CssClass="input"></asp:TextBox>
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
                                                            <tr style="vertical-align:top;">
                                                                <td style="width:10px;"></td>
                                                                <td style="vertical-align:top;">
                                                                    <asp:Label ID="Label18" runat="server" Text="Label" CssClass="softlabel">----------------------------------------------------------------------------------------</asp:Label>
                                                                </td>
                                                                <td style="width:15px;"></td>
                                                            </tr>
                                                            <tr style="vertical-align:top;height:10px;">
                                                                <td style="width:10px;"></td>
                                                                <td style="vertical-align:top;"><asp:CheckBox ID="chkSameShipToAndBillTo" runat="server" Text="Billing and Shipping Address are the Same." CssClass="check" AutoPostBack="True" CausesValidation="True" /></td>
                                                                <td style="width:15px;"></td>
                                                            </tr>
                                                            <tr style="vertical-align:top;height:10px;">
                                                                <td style="width:10px;"></td>
                                                                <td style="vertical-align:top;"></td>
                                                                <td style="width:15px;"></td>
                                                            </tr>
                                                            <tr style="vertical-align:top;">
                                                                <td style="width:10px;"></td>
                                                                <td style="vertical-align:top;">
                                                                    <table border="0" style="width:100%;padding: 0px; margin: 0px; empty-cells: hide; border-collapse: collapse; border-spacing: 0px;">
                                                                        <tr style="vertical-align:top;">
                                                                            <td style="vertical-align:top;">
                                                                                <asp:Label ID="Label1" runat="server" Text="Label" CssClass="label">&nbsp;First</asp:Label>
                                                                                <asp:TextBox ID="txtShipToFirstName" runat="server" CssClass="input"></asp:TextBox>
                                                                            </td>
                                                                            <td style="width:10px;"></td>
                                                                            <td style="vertical-align:top;">
                                                                                <asp:Label ID="Label4" runat="server" Text="Label" CssClass="label">&nbsp;Last</asp:Label>
                                                                                <asp:TextBox ID="txtShipToLastName" runat="server" CssClass="input"></asp:TextBox>
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
                                                            <tr style="vertical-align:top;">
                                                                <td style="width:10px;"></td>
                                                                <td style="vertical-align:top;">
                                                                    <asp:Label ID="Label2" runat="server" Text="Label" CssClass="label">&nbsp;Address *</asp:Label>
                                                                    <asp:TextBox ID="txtShipToAddress" runat="server" CssClass="input"></asp:TextBox>
                                                                </td>
                                                                <td style="width:15px;"></td>
                                                            </tr>
                                                            <tr style="vertical-align:top;height:10px;">
                                                                <td style="width:10px;"></td>
                                                                <td style="vertical-align:top;"></td>
                                                                <td style="width:15px;"></td>
                                                            </tr>
                                                            <tr style="vertical-align:top;">
                                                                <td style="width:10px;"></td>
                                                                <td style="vertical-align:top;">
                                                                    <asp:Label ID="Label3" runat="server" Text="Label" CssClass="label">&nbsp;City *</asp:Label>
                                                                    <asp:TextBox ID="txtShipToCity" runat="server" CssClass="input"></asp:TextBox>
                                                                </td>
                                                                <td style="width:15px;"></td>
                                                            </tr>
                                                            <tr style="vertical-align:top;height:10px;">
                                                                <td style="width:10px;"></td>
                                                                <td style="vertical-align:top;"></td>
                                                                <td style="width:15px;"></td>
                                                            </tr>
                                                            <tr style="vertical-align:top;">
                                                                <td style="width:10px;"></td>
                                                                <td style="vertical-align:top;">
                                                                    <table border="0" style="width:100%;padding: 0px; margin: 0px; empty-cells: hide; border-collapse: collapse; border-spacing: 0px;">
                                                                        <tr style="vertical-align:top;">
                                                                            <td style="vertical-align:top;">
                                                                                <asp:Label ID="Label5" runat="server" Text="Label" CssClass="label">&nbsp;State*</asp:Label>
                                                                                <asp:DropDownList ID="drpShipToState" CssClass="select" runat="server">
                                                                                    <asp:ListItem></asp:ListItem>
                                                                                    <asp:ListItem>AK</asp:ListItem>
                                                                                    <asp:ListItem>AL</asp:ListItem>
                                                                                    <asp:ListItem>AR</asp:ListItem>
                                                                                    <asp:ListItem>AS</asp:ListItem>
                                                                                    <asp:ListItem>AZ</asp:ListItem>
                                                                                    <asp:ListItem>CA</asp:ListItem>
                                                                                    <asp:ListItem>CO</asp:ListItem>
                                                                                    <asp:ListItem>CT</asp:ListItem>
                                                                                    <asp:ListItem>DC</asp:ListItem>
                                                                                    <asp:ListItem>DE</asp:ListItem>
                                                                                    <asp:ListItem>FL</asp:ListItem>
                                                                                    <asp:ListItem>FM</asp:ListItem>
                                                                                    <asp:ListItem>GA</asp:ListItem>
                                                                                    <asp:ListItem>GU</asp:ListItem>
                                                                                    <asp:ListItem>HI</asp:ListItem>
                                                                                    <asp:ListItem>IA</asp:ListItem>
                                                                                    <asp:ListItem>ID</asp:ListItem>
                                                                                    <asp:ListItem>IL</asp:ListItem>
                                                                                    <asp:ListItem>IN</asp:ListItem>
                                                                                    <asp:ListItem>KS</asp:ListItem>
                                                                                    <asp:ListItem>KY</asp:ListItem>
                                                                                    <asp:ListItem>LA</asp:ListItem>
                                                                                    <asp:ListItem>MA</asp:ListItem>
                                                                                    <asp:ListItem>MD</asp:ListItem>
                                                                                    <asp:ListItem>ME</asp:ListItem>
                                                                                    <asp:ListItem>MH</asp:ListItem>
                                                                                    <asp:ListItem>MI</asp:ListItem>
                                                                                    <asp:ListItem>MN</asp:ListItem>
                                                                                    <asp:ListItem>MO</asp:ListItem>
                                                                                    <asp:ListItem>MP</asp:ListItem>
                                                                                    <asp:ListItem>MS</asp:ListItem>
                                                                                    <asp:ListItem>MT</asp:ListItem>
                                                                                    <asp:ListItem>NC</asp:ListItem>
                                                                                    <asp:ListItem>ND</asp:ListItem>
                                                                                    <asp:ListItem>NE</asp:ListItem>
                                                                                    <asp:ListItem>NH</asp:ListItem>
                                                                                    <asp:ListItem>NJ</asp:ListItem>
                                                                                    <asp:ListItem>NM</asp:ListItem>
                                                                                    <asp:ListItem>NV</asp:ListItem>
                                                                                    <asp:ListItem>NY</asp:ListItem>
                                                                                    <asp:ListItem>OH</asp:ListItem>
                                                                                    <asp:ListItem>OK</asp:ListItem>
                                                                                    <asp:ListItem>OR</asp:ListItem>
                                                                                    <asp:ListItem>PA</asp:ListItem>
                                                                                    <asp:ListItem>PR</asp:ListItem>
                                                                                    <asp:ListItem>PW</asp:ListItem>
                                                                                    <asp:ListItem>RI</asp:ListItem>
                                                                                    <asp:ListItem>SC</asp:ListItem>
                                                                                    <asp:ListItem>SD</asp:ListItem>
                                                                                    <asp:ListItem>TN</asp:ListItem>
                                                                                    <asp:ListItem>TX</asp:ListItem>
                                                                                    <asp:ListItem>UM</asp:ListItem>
                                                                                    <asp:ListItem>UT</asp:ListItem>
                                                                                    <asp:ListItem>VA</asp:ListItem>
                                                                                    <asp:ListItem>VI</asp:ListItem>
                                                                                    <asp:ListItem>VT</asp:ListItem>
                                                                                    <asp:ListItem>WA</asp:ListItem>
                                                                                    <asp:ListItem>WI</asp:ListItem>
                                                                                    <asp:ListItem>WV</asp:ListItem>
                                                                                    <asp:ListItem>WY</asp:ListItem>
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                            <td style="width:10px;"></td>
                                                                            <td style="vertical-align:top;">
                                                                                <asp:Label ID="Label6" runat="server" Text="Label" CssClass="label">&nbsp;Zip Code*</asp:Label>
                                                                                <asp:TextBox ID="txtShipToZipCode" runat="server" CssClass="input"></asp:TextBox>
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
                                                            <tr style="vertical-align:top;">
                                                                <td style="width:10px;"></td>
                                                                <td style="vertical-align:top;">
                                                                    <asp:Label ID="Label8" runat="server" Text="Label" CssClass="softlabel">----------------------------------------------------------------------------------------</asp:Label>
                                                                    <asp:Label ID="Label7" runat="server" Text="Label" CssClass="regularlabel">
                                                                        Huckabee for President, Inc. is a political organization registered with the Internal Revenue Service. Contributions are subject to the limits and prohibitions of the Federal Election Campaign Act. Contributions from corporations, foreign nationals or federal government contractors are prohibited. We must use our best efforts to maintain the name, mailing address, occupation and name of employer of individuals whose contributions exceed $200 per calendar year. We must report information to the Federal Election Committee..
                                                                    </asp:Label>
                                                                </td>
                                                                <td style="width:15px;"></td>
                                                            </tr>
                                                            <tr style="vertical-align:top;height:20px;">
                                                                <td style="width:10px;"></td>
                                                                <td style="vertical-align:top;"></td>
                                                                <td style="width:15px;"></td>
                                                            </tr>
                                                            <tr style="vertical-align:top;">
                                                                <td style="width:10px;"></td>
                                                                <td style="vertical-align:top;">
                                                                    <table border="0" style="width:100%;padding: 0px; margin: 0px; empty-cells: hide; border-collapse: collapse; border-spacing: 0px;">
                                                                        <tr style="vertical-align:top;">
                                                                            <td style="vertical-align:top;">
                                                                                <asp:Label ID="Label13" runat="server" Text="Label" CssClass="label">&nbsp;Employer *</asp:Label>
                                                                                <asp:TextBox ID="txtPayByEmployer" runat="server" CssClass="input"></asp:TextBox>
                                                                            </td>
                                                                            <td style="width:10px;"></td>
                                                                            <td style="vertical-align:top;">
                                                                                <asp:Label ID="Label14" runat="server" Text="Label" CssClass="label">&nbsp;Occupation *</asp:Label>
                                                                                <asp:TextBox ID="txtPayByOccupation" runat="server" CssClass="input"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                                <td style="width:15px;"></td>
                                                            </tr>
                                                            <tr style="vertical-align:top;height:20px;">
                                                                <td style="width:10px;"></td>
                                                                <td style="vertical-align:top;"></td>
                                                                <td style="width:15px;"></td>
                                                            </tr>
                                                            <tr style="vertical-align:top;">
                                                                <td style="width:10px;"></td>
                                                                <td style="vertical-align:top;">
                                                                    <table border="0" style="width:100%;padding: 0px; margin: 0px; empty-cells: hide; border-collapse: collapse; border-spacing: 0px;">
                                                                        <tr style="vertical-align:top;">
                                                                            <td style="vertical-align:top;width:48%">
                                                                                <asp:Button ID="btnShipping" runat="server" Text="Previous" CssClass="btnDown" />
                                                                            </td>
                                                                            <td style="width:2.5%;"></td>
                                                                            <td style="vertical-align:top;">
                                                                                <asp:Button ID="btnConfirm" runat="server" Text="Next" CssClass="btnUp" />
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
                                                        </table>    
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table><br /><br /><br />
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
                                    <% =lstrCartItems %>
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
                                            <label for="label2" style="font-family:'Open Sans', Helvetica, sans-serif;font-weight:300;font-size:100%;color: black;text-decoration: none;"><% = FormatCurrency(ldblSubTotal, 2)%>&nbsp;</label>
                                        </td>
                                    </tr> 
                                    <tr>
                                        <td style="width:25%;text-align:left;"><label for="label2" style="font-family:'Open Sans', Helvetica, sans-serif;font-weight:300;font-size:100%;color: black;text-decoration: none;">SHIPPING</label></td>
                                        <td style="text-align: left; vertical-align:top; width: 10px; padding: 0px; margin: 0px;"></td>
                                        <td style="text-align: left; vertical-align:top; width: 45%; padding: 0px; margin: 0px;"><label for="label2" style="font-family:'Open Sans', Helvetica, sans-serif;font-weight:300;font-size:100%;color: black;text-decoration: none;">(<% =lstrShippingMethod%>)</label></td>
                                        <td style="text-align: right; vertical-align:top; width: 25%; padding: 0px; margin: 0px;">
                                            <label for="label2" style="font-family:'Open Sans', Helvetica, sans-serif;font-weight:300;font-size:100%;color: black;text-decoration: none;"><% = FormatCurrency(ldblShippingPublishedRate, 2)%>&nbsp;</label>
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
