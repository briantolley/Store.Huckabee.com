<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Home.aspx.vb" Inherits="Store.Huckabee.com.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Huckabee Gear</title>
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
                    <table style="table-layout: fixed;border: 0px; height: 393px;width: 100%; padding: 0px; margin: 0px; border-width: 0px; empty-cells: hide; border-collapse: collapse; border-spacing: 0px;">
                        <tr style="background-color: #262626; text-align: center;border: 0px; width: 100%; padding: 0px; margin: 0px; border-width: 0px;">
                            <td style="background-color: #262626; width: 10%; text-align: center;">
                                <div id="previous" class="owl-prev"><img src="Images/LeftLightChevron.gif" style="height:20%; width: 20%;"/></div>
                            </td>
                            <td style="background-color: #262626; text-align: center;border: 0px; width: 100%; padding: 0px; margin: 0px; border-width: 0px;">
                                <div id="banner-slider" class="owl-carousel">
                                    <% =lstrBannerSliderItems %>
                                </div>
                            </td>
                            <td style="background-color: #262626; width: 10%; text-align: center;">
                                <div id="next" class="owl-next"><img src="Images/RightLightChevron.gif" style="height:20%; width: 20%;"/></div>
                            </td>
                        </tr>
                    </table>                              
                    <script type="text/javascript">
                        $(document).ready(function () {
                            var owl = $("#banner-slider");
                            owl.owlCarousel({
                                items: 1,
                                singleitem: true,
                                autoHeight: true,
                                slidespeed: 200,
                                autoPlay: true,
                                pagination: false,
                                navigation: false,
                                itemsScaleUp: true,
                                itemsDesktop: [1199, 1],
                                itemsDesktopSmall: [979, 1],
                                itemsTablet: [768, 1],
                                itemsMobile: [479, 1]
                            });
                            $("#previous").click(function () {
                                owl.trigger('owl.prev');
                            });
                            $("#next").click(function () {
                                owl.trigger('owl.next');
                            });
                        });
                    </script>
                    <table style="table-layout: fixed;border: 0px; width: 100%; padding: 0px; margin: 0px; border-width: 0px; empty-cells: hide; border-collapse: collapse; border-spacing: 0px;">
                        <tr style="background-color: white; text-align: center;border: 0px; width: 100%; padding: 0px; margin: 0px; border-width: 0px;">
                            <td style="background-color: white; width: 10%; text-align: center;">
                                <table style ="table-layout: fixed;border: 0px; width: 100%; padding: 0px; margin: 0px; border-width: 0px; empty-cells: hide; border-collapse: collapse; border-spacing: 0px;">
                                    <tr style="background-color: white; text-align: center;border: 0px; width: 100%; padding: 0px; margin: 0px; border-width: 0px;">
                                        <td style="background-color: white;text-align: center;"></td>
                                        <td style="background-color: white; width: 30%; text-align: center;">
                                            <br /><br />
                                            <label for="featuredproductsgrouplabel" style="font-family:'Open Sans', Helvetica, sans-serif;font-weight:800;font-size:200%; height: 100%; width: 100%; "><span style="white-space:nowrap">FEATURED PRODUCTS</span></label>
                                        </td>
                                        <td style="background-color: white; text-align: center;"></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr style="background-color: white; text-align: center;border: 0px; width: 100%; padding: 0px; margin: 0px; border-width: 0px;">
                            <td style="background-color: white; width: 10%; text-align: center;">
                                <br /><br />
                                <table style="table-layout: fixed;border: 0px; width: 100%; padding: 0px; margin: 0px; border-width: 0px; empty-cells: hide; border-collapse: collapse; border-spacing: 0px;">
                                    <tr style="background-color: white; text-align: center;border: 0px; width: 100%; padding: 0px; margin: 0px; border-width: 0px;">
                                        <td style="background-color: white; width: 10%; text-align: center;">
                                            <div id="ProdPrevious" class="owl-prev"><img src="Images/LeftDarkChevron.png" style="height:20%; width: 20%;"/></div>
                                        </td>
                                        <td style="background-color: white; text-align: center;border: 0px; width: 100%; padding: 0px; margin: 0px; border-width: 0px;">
                                            <div id="product-slider" class="owl-carousel" style="padding: 0px; margin: 0px; border-width: 0px;">
                                                <% = lstrProductSliderItems%>
                                            </div>
                                        </td>
                                        <td style="background-color: white; width: 10%; text-align:center;">
                                            <div id="ProdNext" class="owl-next"><img src="Images/RightDarkChevron.png" style="height:20%; width: 20%;"/></div>
                                        </td>
                                    </tr>
                                </table>
                                <script type="text/javascript">
                                    $(document).ready(function () {
                                        var productowl = $("#product-slider");
                                        productowl.owlCarousel({
                                            items: 4,
                                            slidespeed: 100,
                                            autoPlay: true,
                                            pagination: false,
                                            navigation: false,
                                            itemsDesktop: [1199, 4],
                                            itemsDesktopSmall: [979, 3],
                                            itemsTablet: [768, 2]
                                        });
                                        $("#ProdPrevious").click(function () {
                                            productowl.trigger('owl.prev');
                                        });
                                        $("#ProdNext").click(function () {
                                            productowl.trigger('owl.next');
                                        });
                                    });
                                </script>
                            </td>
                        </tr>
                        <tr style="background-color: white; text-align: center;border: 0px; width: 100%; padding: 0px; margin: 0px; border-width: 0px;">
                            <td style="background-color: white; width: 10%; text-align: center;">
                                <br /><br />
                                <img src="Images/HuckabeeSubHeaderSeperator.png" />
                            </td>
                        </tr>
                        <tr style="background-color: white; text-align: center;border: 0px; width: 100%; padding: 0px; margin: 0px; border-width: 0px;">
                            <td style="background-color: white; width: 10%; text-align: center;">
                                <table style ="table-layout: fixed;border: 0px; width: 100%; padding: 0px; margin: 0px; border-width: 0px; empty-cells: hide; border-collapse: collapse; border-spacing: 0px;">
                                    <tr style="background-color: white; text-align: center;border: 0px; width: 100%; padding: 0px; margin: 0px; border-width: 0px;">
                                        <td style="background-color: white;text-align: center;"></td>
                                        <td style="background-color: white; width: 30%; text-align: center;">
                                            <br /><br />
                                            <label for="productdesignsgrouplabel" style="font-family:'Open Sans', Helvetica, sans-serif;font-weight:800;font-size:31px;"><span style="white-space:nowrap">PRODUCT DESIGNS</span></label>
                                        </td>
                                        <td style="background-color: white; text-align: center;"></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr style="background-color: white; text-align: center;border: 0px; width: 100%; padding: 0px; margin: 0px; border-width: 0px;">
                            <td style="background-color: white; width: 10%; text-align: center;">
                                <br /><br />
                                <table style="table-layout: fixed;border: 0px; width: 100%; padding: 0px; margin: 0px; border-width: 0px; empty-cells: hide; border-collapse: collapse; border-spacing: 0px;">
                                    <tr style="background-color: white; text-align: center;border: 0px; width: 100%; padding: 0px; margin: 0px; border-width: 0px;">
                                        <td style="background-color: white; width: 10%; text-align: center;">
                                            <div id="brandprev" class="owl-prev"><img src="Images/LeftDarkChevron.png" style="height:20%; width: 20%;"/></div>
                                        </td>
                                        <td style="background-color: white; text-align: center;border: 0px; width: 100%; padding: 0px; margin: 0px; border-width: 0px;">
                                            <div id="brands-slider" class="owl-carousel"  style="padding: 0px; margin: 0px; border-width: 0px;">
                                                <% =lstrDesignSliderItems %>
                                            </div>
                                        </td>
                                        <td style="background-color: white; width: 10%; text-align:center;">
                                            <div id="brandnext" class="owl-next"><img src="Images/RightDarkChevron.png" style="height:20%; width: 20%;"/></div>
                                        </td>
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
                                <br /><br />
                            </td>
                        </tr>
                    </table>
                    <!-- #include file="Includes/Footer.aspx -->
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
