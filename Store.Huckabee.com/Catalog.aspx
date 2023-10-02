<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Catalog.aspx.vb" Inherits="Store.Huckabee.com.Catalog" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title><% = lstrCatalogGroupName %></title>
    <link rel="shortcut icon" type="image/png" href="Images/icon.png" />
    <script type="text/javascript" src="jquery-1.11.2.min.js"></script>
    <script type="text/javascript" src="owl-carousel/owl.carousel.min.js"></script>
    <link rel="stylesheet" href="owl-carousel/owl.carousel.css"/>
    <link rel="stylesheet" href="owl-carousel/owl.theme.css"/>
    <link href="http://fonts.googleapis.com/css?family=Open+Sans:400italic,400,300,600,700,800" rel="stylesheet" type="text/css"/>
    <link href="https://fonts.googleapis.com/css?family=Open+Sans:400italic,400,300,600,700,800" rel="stylesheet" type="text/css"/>
</head>
<body style="padding: 0px; margin: 0px;"  >
    <form id="form1" runat="server">
        <table style="table-layout: fixed;border: 0px; width: 100%; height: 100%; padding: 0px; margin: 0px; border-width: 0px; empty-cells: hide; border-collapse: collapse; border-spacing: 0px;min-width:800px">
            <tr>
                <td>
                    <!-- #include file="Includes/Header.aspx -->
                    <table style="border-style: solid; table-layout: fixed; width: 100%; padding: 0px; margin: 0px; border-width: 1px 0px 0px 0px; empty-cells: hide; border-collapse: collapse; border-spacing: 0px; border-top-color: #BFBFBF; border-right-color: inherit; border-bottom-color: inherit; border-left-color: inherit;">
                        <tr style="text-align: center; height: 1px; border: 0px; width: 100%; padding: 0px; margin: 0px; border-width: 0px; background-repeat: repeat;">
                            <td style="width: 4.5%; text-align: center;"><br /><br /><br /><br /></td>
                            <td style="text-align: center;"><br /><label for="productdesignsgrouplabel" style="font-family:'Open Sans', Helvetica, sans-serif;font-weight:800;font-size:31px;"><span style="white-space:nowrap"><% =lstrCatalogGroupName %></span></label><br /><br /></td>
                            <td style="width: 4.75%; text-align: center;"></td>
                        </tr>
                        <tr style="background-color: white; text-align: center;border: 0px; width: 100%; padding: 0px; margin: 0px; border-width: 0px;">
                            <td style="width: 4.5%; text-align: center;"></td>
                            <td style="background-color: white; width: 10%; text-align: center;">
                                <table border="0" style="table-layout: fixed;border: 0px; width: 100%; height: 100%; padding: 0px; margin: 0px; border-width: 0px; empty-cells: hide; border-collapse: collapse; border-spacing: 0px;">
                                    <tr style="text-align: center; height: 80%; border: 0px; width: 100%; padding: 0px; margin: 0px; border-width: 0px; background-repeat: repeat;">
                                        <td style="background-position: right bottom; text-align: left; vertical-align: top;">
                                            <table border="0" style="table-layout: fixed;border: 0px; width: 100%; padding: 0px; margin: 0px; border-width: 0px; empty-cells: hide; border-collapse: collapse; border-spacing: 0px;">
                                                <tr style="text-align: left; border: 0px; width: 100%; padding: 0px; margin: 0px; border-width: 0px;">
                                                    <td style="text-align: left;"></td>
                                                </tr>
                                                <% =lstrCatalogItemsForSelectedGroup %>
                                                <tr style="text-align: left; height: 50px; border: 0px; width: 100%; padding: 0px; margin: 0px; border-width: 0px;">
                                                    <td style="text-align: left;"><br /><br /><img src="Images/HuckabeeSubHeaderSeperator.png" /></td>
                                                </tr>
                                                <tr style="text-align: left; height: 50px; border: 0px; width: 100%; padding: 0px; margin: 0px; border-width: 0px;">
                                                    <td style="text-align: center;"><br /><br /><label for="productdesignsgrouplabel" style="font-family:'Open Sans', Helvetica, sans-serif;font-weight:800;font-size:31px;"><span style="white-space:nowrap">PRODUCT DESIGNS</span><br /><br /></label></td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr style="text-align: center; height: 1px; border: 0px; width: 100%; padding: 0px; margin: 0px; border-width: 0px; background-repeat: repeat;">
                                        <td style="text-align: center;"></td>
                                    </tr>
                                </table>
                            </td>
                            <td style="width: 4.75%; text-align: center;"></td>
                        </tr>
                        <tr style="text-align: center; height: 1px; border: 0px; width: 100%; padding: 0px; margin: 0px; border-width: 0px; background-repeat: repeat;">
                            <td style="width: 4.5%; text-align: center;">
                                <div id="brandprev" class="owl-prev"><img src="Images/LeftDarkChevron.png" style="height:20%; width: 20%;"/></div>
                            </td>
                            <td style="text-align: center;">
                                <div id="brands-slider" class="owl-carousel"  style="padding: 0px; margin: 0px; border-width: 0px;">
                                <% =lstrDesignSliderItems %>
                                </div>
                            </td>
                            <td style="width: 4.75%; text-align: center;">
                                <div id="brandnext" class="owl-next"><img src="Images/RightDarkChevron.png" style="height:20%; width: 20%;"/></div>
                            </td>
                        </tr>
                        <tr style="text-align: center; height: 1px; border: 0px; width: 100%; padding: 0px; margin: 0px; border-width: 0px; background-repeat: repeat;">
                            <td style="width: 4.5%; text-align: center;"><br /></td>
                            <td style="text-align: center;"></td>
                            <td style="width: 4.75%; text-align: center;"></td>
                        </tr>
                    </table>
                    <script type="text/javascript">
                        $(document).ready(function () {
                            var brandowl = $("#brands-slider");
                            brandowl.owlCarousel({
                                items: 4,
                                slidespeed: 200,
                                autoPlay: true,
                                pagination: false,
                                navigation: false,
                                itemsDesktop: [1199, 4],
                                itemsDesktopSmall: [979, 3],
                                itemsTablet: [768, 2]
                            });
                            $("#brandprev").click(function () {
                                brandowl.trigger('owl.prev');
                            });
                            $("#brandnext").click(function () {
                                brandowl.trigger('owl.next');
                            });
                        });
                    </script>
                    <!-- #include file="Includes/Footer.aspx -->
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
