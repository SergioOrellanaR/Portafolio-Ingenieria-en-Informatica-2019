<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="TASKWebApp.View.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="tittle" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .carousel {
            margin: 30px 0;
            background: #ccc;
        }

            .carousel .item {
                text-align: center;
                overflow: hidden;
                height: 475px;
            }

                .carousel .item img {
                    max-width: 100%;
                    margin: 0 auto; /* Align slide image horizontally center in Bootstrap v3 */
                }

            .carousel .carousel-control {
                width: 50px;
                height: 50px;
                background: #000;
                margin: auto 0;
                opacity: 0.8;
            }

                .carousel .carousel-control:hover {
                    opacity: 0.9;
                }

                .carousel .carousel-control i {
                    font-size: 41px;
                    margin-top: 3px;
                }

        .carousel-caption h3, .carousel-caption p {
            color: #fff;
            display: inline-block;
            font-family: 'Oswald', sans-serif;
            text-shadow: none;
            margin-bottom: 20px;
        }

        .carousel-caption h3 {
            background: rgba(0,0,0,0.9);
            padding: 12px 24px;
            font-size: 40px;
            text-transform: uppercase;
        }

        .carousel-caption p {
            background: #20b0b9;
            padding: 10px 20px;
            font-size: 20px;
            font-weight: 300;
        }

        .carousel-indicators li, .carousel-indicators li.active {
            margin-left: 4px;
            margin-right: 4px;
        }

            .carousel-indicators li.active {
                background: #20b0b9;
                border-color: #20b0b9;
            }

        .carousel .nav {
            background: #eee;
        }

            .carousel .nav a {
                color: #333;
                border-radius: 0;
                font-size: 85%;
                padding: 10px 16px;
                background: transparent;
            }

            .carousel .nav .nav-item.active a {
                color: #fff;
                background: #20b0b9;
            }

            .carousel .nav strong {
                display: block;
                font-family: 'Roboto', sans-serif;
                font-size: 110%;
                text-transform: uppercase;
            }
    </style>

    <script type="text/javascript">
        $(document).ready(function () {
            // Highlight bottom nav links
            var clickEvent = false;
            $("#myCarousel").on("click", ".nav a", function () {
                clickEvent = true;
                $(this).parent().siblings().removeClass("active");
                $(this).parent().addClass("active");
            }).on("slid.bs.carousel", function (e) {
                if (!clickEvent) {
                    itemIndex = $(e.relatedTarget).index();
                    targetNavItem = $(".nav li[data-slide-to='" + itemIndex + "']");
                    $(".nav li").not(targetNavItem).removeClass("active");
                    targetNavItem.addClass("active");
                }
                clickEvent = false;
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentBody" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-12">
                <div id="myCarousel" class="carousel slide" data-ride="carousel">
                    <!-- Wrapper for carousel items -->
                    <div class="carousel-inner">
                        <div class="item carousel-item active">
                            <img src="https://www.tutorialrepublic.com/examples/images/slides/notebook.jpg" alt="">
                            <div class="carousel-caption">
                                <h3>Task Assignment System</h3>
                                <p>Tareas empresariales en tiempo real.</p>
                            </div>
                        </div>
                        <div class="item carousel-item">
                            <img src="https://www.tutorialrepublic.com/examples/images/slides/tablet.jpg" alt="">
                            <div class="carousel-caption">
                                <h3>Modernas herramientas de monitoreo</h3>
                                <p>Todo lo que necesitas, para mejorar la eficencia y productividad de tu empresa.</p>
                            </div>
                        </div>
                        <div class="item carousel-item">
                            <img src="https://www.tutorialrepublic.com/examples/images/slides/workstation.jpg" alt="">
                            <div class="carousel-caption">
                                <h3>Productividad y rendimiento</h3>
                                <p>Aprovecha al máximo las herramientas que Task Assignment System ofrece para tu empresa.</p>
                            </div>
                        </div>
                        <div class="item carousel-item">
                            <img src="https://www.tutorialrepublic.com/examples/images/slides/report.jpg" alt="">
                            <div class="carousel-caption">
                                <h3>Reportes al instante</h3>
                                <p>Con Task Assignment System obtén reportes de tus tareas empresariales al instante.</p>
                            </div>
                        </div>
                    </div>
                    <!-- End Carousel Inner -->
                    <ul class="nav nav-pills nav-justified">
                        <li data-target="#myCarousel" data-slide-to="0" class="nav-item active"><a href="#" class="nav-link"><strong>Quienes somos</strong>Task Assignment System</a></li>
                        <li data-target="#myCarousel" data-slide-to="1" class="nav-item"><a href="#" class="nav-link"><strong>Heramientas</strong>Software de calidad</a></li>
                        <li data-target="#myCarousel" data-slide-to="2" class="nav-item"><a href="#" class="nav-link"><strong>Ventajas</strong>Aumenta el rendimiento</a></li>
                        <li data-target="#myCarousel" data-slide-to="3" class="nav-item"><a href="#" class="nav-link"><strong>Innovación</strong>Tecnología de vanguardia</a></li>
                    </ul>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
