<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="BuyProductPage.aspx.cs" Inherits="Cafebucks.BuyProductPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="container single__product my-5 px-5">
                <div class="row mt-5">
                    <div class="col-lg-5 col-md-12 col-12">
                        <asp:Image ID="imageProduct" runat="server" alt="product thumbnail" CssClass="img-fluid w-100"/>
                        <%-- <img src={`data:image/png;base64,${product.image}`} alt="product" class='img-fluid w-100' /> %>

<%--                        <div class='small_img_group'>
                            <div class="small_img_col">
                                <img src={`data:image/png;base64,${product.image}`} alt='product1' class='small_img' />
                            </div>
                            <div class="small_img_col">
                                <img src={`data:image/png;base64,${product.image}`} alt='product1' class='small_img' />
                            </div>
                            <div class="small_img_col">
                                <img src={`data:image/png;base64,${product.image}`} alt='product1' class='small_img' />
                            </div>
                            <div class="small_img_col">
                                <img src={`data:image/png;base64,${product.image}`} alt='product1' class='small_img' />
                            </div>
                        </div>--%>
                        
                    </div>
                    <div class="col-lg-6 col-12 ms-4 product__desc">
                        <h6>Home / <asp:Label ID="lblCategory" runat="server" Text="Undefined"/></h6>
                        <h3><asp:Label ID="lblProductName" runat="server" Text="Unknown" /></h3>
                        <h2><strike class="me-1">₹<asp:Label ID="lblOriginalPrice" runat="server" Text="Unknown" /></strike>  ₹<asp:Label ID="lblDiscounted" runat="server" Text="Unknown" /></h2>
                        <RatingStar />
                        <select >
                            <option value="S">Small</option>
                            <option value="M">Medium</option>
                            <option value="L">Large</option>
                        </select>
                        <asp:TextBox ID="txtQuantity" runat="server" TextMode="Number" placeholder='1' Text="1" />
                        <asp:LinkButton ID="btnAddtocart" runat="server" CssClass='buy__btn text-decoration-none' OnClick="btnAddtocart_Click"> Add To Cart</asp:LinkButton>
                        <h4>Product Details</h4>
                        <span><asp:Label ID="lblDescription" runat="server" Text="Lorem ipsum dolor sit amet consectetur adipisicing elit. Atque repudiandae voluptate maiores consequuntur consequatur aperiam, id magni, suscipit numquam quasi laborum voluptatum, quibusdam sequi labore?"/></span>
                    </div>
                </div>
            </section>
            <section class='container related__panel mb-3'>
                <h3 class='text-center'>Other Products</h3>
                <div class="product__repeater">
                    <asp:Repeater runat="server" ID="repeatProduct">
                    <ItemTemplate>
                        <div class="thumb-wrapper">
                            <div class="img-box">
                                <img src='<%# Eval("thumbnail")%>' class="img-fluid" alt='<%# Eval("productName") %>' />
                            </div>
                            <div class="thumb-content">
                                <h4><%# Eval("productName") %></h4>
                                <p class="item-price"><span><%#Eval("price") %></span></p>
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
                </div>
            </section>
</asp:Content>
