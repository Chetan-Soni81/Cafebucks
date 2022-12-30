<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Cafebucks.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="https://cdnjs.cloudflare.com/ajax/libs/toastr.js/latest/toastr.min.js" integrity="sha512-VEd+nq25CkR676O+pLBnDW09R7VQX9Mdiij052gVCp5yVH3jGtH70Ho/UUv4mJDsEdTvqRCFZg0NKGiojGnUCw==" crossorigin="anonymous" referrerpolicy="no-referrer"></script>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/toastr.js/latest/toastr.css" integrity="sha512-3pIirOrwegjM6erE5gPSwkUzO+3cTjpnV9lexlNZqvupR64iZBnOOTiiLPb9M36zpMScbmUNIcHUqKD47M719g==" crossorigin="anonymous" referrerpolicy="no-referrer" />

    <script type="text/javascript">
 
    function showpop1(msg, title) {
         
        // alert("ok");
        toastr.options = {
            "closeButton":false,
            "debug":false,
            "newestOnTop":false,
            "progressBar":true,
            "positionClass":"toast-top-right",
            "preventDuplicates":true,
            "onclick":null,
            "showDuration":"300",
            "hideDuration":"1500",
            "timeOut":"12000",
            "extendedTimeOut":"1000",
            "showEasing":"swing",
            "hideEasing":"linear",
            "showMethod":"fadeIn",
            "hideMethod":"fadeOut"
        }
        // toastr['success'](msg, title);
        var d = Date();
 
        toastr.success(msg, title);
        return false;
    }
    </script>

    <div class='home__main'>
        <div class="home__panel">
            <div class="home__bg">
                <img src="images/home-bg.jpg" alt="background" />
            </div>
            <div class="home__content">
                <h1 class="title">CaféBucks
                </h1>
                <p>
                    Discover the best Food and Drinks in Ayodhya-Faizabad
                </p>
                <div class="search__container">
                    <div class="search__box">
                        <div class="search__option">
                            <i class="fa-solid fa-location-dot text-danger"></i>
                            <input type="text" placeholder='Ayodhya-Faizabad' />
                            <i class="fa-solid fa-caret-down"></i>
                        </div>
                        <div class="search__divider"></div>
                        <hr class='search_v_divider' />
                        <div class="search__text">
                            <i class="fa-solid fa-magnifying-glass"></i>
                            <input placeholder='Search for Restaurant, cuisine or a dish' />
                        </div>
                    </div>
                </div>
            </div>

        </div>

        <div class="card__repeater">
            <div class="card">
                <img src="images/card-dish.jpg" class="card-img-top" alt="..." />
                <div class="card-body">
                    <h5 class="card-title">Order Food</h5>
                    <p class="card-text">Some quick example text to build on the card title and make up the bulk of the card's content.</p>
                    <a href="/" class="btn btn-primary">Go somewhere</a>
                </div>
            </div>

            <div class="card">
                <img src="images/card-restaurant.jpg" class="card-img-top" alt="..." />
                <div class="card-body">
                    <h5 class="card-title">Check Restaurants</h5>
                    <p class="card-text">Some quick example text to build on the card title and make up the bulk of the card's content.</p>
                    <a href="/" class="btn btn-primary">Go somewhere</a>
                </div>
            </div>

            <div class="card">
                <img src="images/card-cuisine.jpg" class="card-img-top" alt="..." />
                <div class="card-body">
                    <h5 class="card-title">Explore Cuisines</h5>
                    <p class="card-text">Some quick example text to build on the card title and make up the bulk of the card's content.</p>
                    <a href="/" class="btn btn-primary">Go somewhere</a>
                </div>
            </div>

            <div class="card">
                <img src="images/card-cuisine.jpg" class="card-img-top" alt="..." />
                <div class="card-body">
                    <h5 class="card-title">Hot Deals</h5>
                    <p class="card-text">Some quick example text to build on the card title and make up the bulk of the card's content.</p>
                    <a href="/" class="btn btn-primary">Go somewhere</a>
                </div>
            </div>
        </div>
    </div>

    <asp:Button ID="btnPopup" runat="server" Text="Click me!!!" OnClick="btnPopup_Click"/>
</asp:Content>
