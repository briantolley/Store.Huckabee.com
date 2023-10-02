<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Thankyou.aspx.vb" Inherits="Store.Huckabee.com.Thankyou" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Thank You</title>
    <link rel="shortcut icon" type="image/png" href="Images/icon.png" />
    <script type="text/javascript" src="jquery-1.11.2.min.js"></script>
    <link href="http://fonts.googleapis.com/css?family=Open+Sans:400italic,400,300,600,700,800" rel="stylesheet" type="text/css"/>
    <link href="https://fonts.googleapis.com/css?family=Open+Sans:400italic,400,300,600,700,800" rel="stylesheet" type="text/css"/>
    <style>
        .dropdown {
            border-radius: 5px;
            right: 400px;
            top: 500px;
            font-family:'Open Sans', Helvetica, sans-serif; 
            font-weight:300; 
            font-size:80%;
        }
        .button {
            border-style: 0; 
            opacity:1;
            -moz-opacity:1;
            filter:alpha(opacity=100);
            border-width: 0px; 
            height:40px; 
            width: 120px; 
            border-radius: 5px; 
            background-color: #D6252E; 
            font-family:'Open Sans', Helvetica, sans-serif; 
            font-weight:600; 
            font-size:100%; 
            color: white; 
            text-decoration: none;
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
                                <br /><br /><br /><br /><label for="label2" style="font-family:'Open Sans', Helvetica, sans-serif;font-weight:600;font-size:100%;color: #044C86;text-decoration: none;">Thank you for your order.<br />You should soon recieve an order confirmation e-mail.</label></br> 
                            </td>
                            <td style="width:80px;text-align:right;">
                                <br /><br /><br /><br /><img src="Images/CartItemVerticalSeperator.png" />
                            </td>
                            <td style="text-align:center;">
                                <br /><label for="productdesignsgrouplabel" style="font-family:'Open Sans', Helvetica, sans-serif;font-weight:600;font-size:24px;"><span style="white-space:nowrap">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;PRODUCT DESIGNS</span></label><br /><br />
                                <table style="text-align: right;">
                                    <tr>
                                        <td style="vertical-align:top">
                                            <a href="Catalog.aspx?Design=%22Huckabee%202016%22" style="color: #000000;text-decoration: none">
                                                <img src="Images/HuckabeeBrandsHuckabee2016.png" style="width: 70%; height: auto"/><br />
                                                <label for="label2" style="font-family:'Open Sans', Helvetica, sans-serif;font-weight:600;font-size:100%;color: #000000;text-decoration: none;">"Huckabee 2016"&nbsp;&nbsp;&nbsp;<br /><br /></label>
                                            </a>
                                        </td>
                                        <td style="vertical-align:top">
                                            <a href="Catalog.aspx?Design=%22I%20Like%20Mike%22" style="color: #000000;text-decoration: none">
                                                <img src="Images/HuckabeeBrandsILikeMike.png" style="width: 70%; height: auto"/><br />
                                                <label for="label2" style="font-family:'Open Sans', Helvetica, sans-serif;font-weight:600;font-size:100%;color: #000000;text-decoration: none;">"I Like Mike"&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br /><br /></label>
                                            </a>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="vertical-align:top">
                                            <a href="Catalog.aspx?Design=%22Hope%20To%20Higher%20Ground%22" style="color: #000000;text-decoration: none">
                                                <img src="Images/HuckabeeBrandsHopeToHigherGround.png" style="width: 70%; height: auto"/><br />
                                                <label for="label2" style="font-family:'Open Sans', Helvetica, sans-serif;font-weight:600;font-size:100%;color: #000000;text-decoration: none;">"Hope To Higher&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />Ground"&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br /><br /></label>
                                            </a>
                                        </td>
                                        <td style="vertical-align:top">
                                            <a href="Catalog.aspx?Design=%22Defeat%20The%20Clinton%20Machine%22" style="color: #000000;text-decoration: none">
                                                <img src="Images/HuckabeeBrandsDefeatTheClintonMachine.png" style="width: 70%; height: auto"/><br />
                                                <label for="label2" style="font-family:'Open Sans', Helvetica, sans-serif;font-weight:600;font-size:100%;color: #000000;text-decoration: none;">"Defeat The Clinton Machine"&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br /><br /></label>
                                            </a>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="vertical-align:top">
                                            <a href="Catalog.aspx?Design=%22I'm%20With%20Huck%22" style="color: #000000;text-decoration: none">
                                                <img src="Images/HuckabeeBrandsImWithHuck.png" style="width: 70%; height: auto"/><br />
                                                <label for="label2" style="font-family:'Open Sans', Helvetica, sans-serif;font-weight:600;font-size:100%;color: #000000;text-decoration: none;">"I'm With Huck"&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br /><br /></label>
                                            </a>
                                        </td>
                                       <td style="vertical-align:top">
                                            <a href="Catalog.aspx?Design=%22Why%20I'm%20a%20Republican%22" style="color: #000000;text-decoration: none">
                                                <img src="Images/Logo_whyrepublican260-blue.png" style="width: 70%; height: auto"/><br />
                                                <label for="label2" style="font-family:'Open Sans', Helvetica, sans-serif;font-weight:600;font-size:100%;color: #000000;text-decoration: none;">""Why I'm a Republican"&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br /><br /></label>
                                            </a>
                                        </td>
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
