<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ProductCatelog.aspx.cs" Inherits="Cafebucks.ProductCatelog" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script>

</script>
    <main class='catalog__main'>
        <div class='filter__panel'>
            <div class="filter__title" onclick="{togglePanel}">
                <span class='filter__icon-filter'>
                    <bsfunnel />
                </span>
                <h3>Filter</h3>
                <span class="filter__icon-arrow" ref="{arrow}">
                    <bsfillcaretdownfill />
                </span>

            </div>
            <div class="filter__content" id="filterContent">
                <div class='filter__content-title'>
                    <h3>By Category</h3>
                    <span></span>
                </div>

                <asp:Repeater ID="repeatCategories" runat="server">
                    <ItemTemplate>
                        <div class="filter__content-options">
                            <span><%# Eval("categoryName") %></span>
                            <asp:CheckBox ID="CheckBox1" runat="server" />
                        </div>
                    </ItemTemplate>
                </asp:Repeater>

                <div class='filter__content-title'>
                    <h3>By Price</h3>
                    <span></span>
                </div>

                <div class='filter__content-range'>
                    <span>Min:</span>
                    <select name="" id="">
                        <option value="0">Min</option>
                    </select>
                    <span>Max:</span>
                    <select name="" id="">
                        <option value="<%# Eval(Int32.MaxValue.ToString())%>">Max</option>
                    </select>
                </div>
            </div>
        </div>
        <div class="catalog__panel">
            <section class="catalog__sort">
                <div>Newest</div>
                <div>Price High-To-Low</div>
                <div>Price Low-To-High</div>
                <div>Popularity</div>
            </section>
            <section class="catalog__repeater">
                <asp:Repeater runat="server" ID="repeatProduct">
                    <ItemTemplate>
                        <div class="thumb-wrapper">
                            <div class="img-box">
                                <img src='<%# Eval("mainImage")%>' class="img-fluid" alt='<%# Eval("productName") %>' />
                            </div>
                            <div class="thumb-content">
                                <h4><%# Eval("productName") %></h4>
                                <p class="item-price"><span>₹<%#Eval("price") %></span></p>
                                <div class="star-rating">
                                    <ul class="list-inline">
                                        <li class="list-inline-item"><i class="fa-solid fa-star" style="color: #ffc000;"></i></li>
                                        <li class="list-inline-item"><i class="fa-solid fa-star" style="color: #ffc000;"></i></li>
                                        <li class="list-inline-item"><i class="fa-solid fa-star" style="color: #ffc000;"></i></li>
                                        <li class="list-inline-item"><i class="fa-solid fa-star" style="color: #ffc000;"></i></li>
                                        <li class="list-inline-item"><i class="fa-solid fa-star" style="color: #ffc000;"></i></li>
                                    </ul>
                                </div>
                                <a href='BuyProductPage.aspx?product=<%#Eval("productId") %>' class="btn">Buy Now</a>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </section>
        </div>
    </main>
</asp:Content>
