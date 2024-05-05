<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="CartPage.aspx.cs" Inherits="Cafebucks.CartPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section class="h-100 h-custom">
        <div class="container py-5 h-100">
            <div class="row d-flex justify-content-center align-items-center h-100">
                <div class="col-12">
                    <div class="card card-registration card-registration-2 w-100" style="border-radius: 15px;">
                        <div class="card-body p-0">
                            <div class="row g-0">
                                <div class="col-lg-8">
                                    <div class="p-5">
                                        <div class="d-flex justify-content-between align-items-center mb-5">
                                            <h1 class="fw-bold mb-0 text-black">Shopping Cart</h1>
                                            <h6 class="mb-0 text-muted"><asp:Label ID="lblCount" runat="server" Text="0" /> items</h6>
                                        </div>

                                        <asp:Repeater ID="repeatCartItems" runat="server">
                                            <ItemTemplate>
                                                <hr class="my-4">
                                                <asp:HiddenField ID="txtProductId" runat="server" Value='<%# Eval("ProductId") %>' />
                                                <asp:HiddenField ID="txtProductPrice" runat="server" Value='<%# Eval("ProductPrice") %>' />
                                                <div class="row mb-4 d-flex justify-content-between align-items-center">
                                                    <div class="col-md-2 col-lg-2 col-xl-2">
                                                        <asp:Image ID="imageThumbnail" runat="server" CssClass="img-fluid rounded-3" ImageUrl='<%# Eval("Thumbnail") %>' AlternateText='<%# Eval("ProductName")%>' />
                                                    </div>
                                                    <div class="col-md-3 col-lg-3 col-xl-3">
                                                        <h6 class="text-muted"><asp:Label ID="txtCategory" runat="server" Text='<%# Eval("CategoryName") %>'/></h6>
                                                        <h6 class="text-black mb-0"><asp:Label ID="txtTitle" runat="server" Text='<%# Eval("ProductName")%>' /></h6>
                                                    </div>
                                                    <div class="col-md-3 col-lg-3 col-xl-2 d-flex">
                                                        <asp:LinkButton ID="btnMinus" runat="server" CssClass="btn btn-link px-2" CommandArgument='<%# Eval("Id") + "," + Eval("Quantity") %>' OnClick="btnMinus_Click">
                                                            <i class='fas fa-minus'></i>
                                                        </asp:LinkButton>

                                                        <asp:TextBox ID="txtQuantity" runat="server" ReadOnly="true" min="1" Text='<%# Eval("Quantity")%>' TextMode="Number" CssClass="form-control form-control-sm" />

                                                        <asp:LinkButton ID="btnPlus" runat="server" CssClass="btn btn-link px-2" CommandArgument='<%# Eval("Id") + "," + Eval("Quantity") %>' OnClick="btnPlus_Click">
                                                            <i class='fas fa-plus'></i>
                                                        </asp:LinkButton>
                                                    </div>
                                                    <div class="col-md-3 col-lg-2 col-xl-2 offset-lg-1">
                                                        <h6 class="mb-0">₹<asp:Label ID="lblPrice" runat="server" Text='<%# String.Format("{0:0.00}", Eval("Price").ToString())%>' /></h6>
                                                    </div>
                                                    <div class="col-md-1 col-lg-1 col-xl-1 text-end">
                                                        <asp:LinkButton ID="btnRemoveItem" runat="server" CommandName="cartItemId" CommandArgument='<%# Eval("Id") %>'  CssClass="text-muted" OnClick="btnRemoveItem_Click"><i class="fas fa-times"></i></asp:LinkButton>
                                                    </div>
                                                </div>
                                            </ItemTemplate>
                                        </asp:Repeater>

                                        <hr class="my-4">

                                        <%--<div class="row mb-4 d-flex justify-content-between align-items-center">
                                            <div class="col-md-2 col-lg-2 col-xl-2">
                                                <img
                                                    src="https://mdbcdn.b-cdn.net/img/Photos/new-templates/bootstrap-shopping-carts/img5.webp"
                                                    class="img-fluid rounded-3" alt="Cotton T-shirt">
                                            </div>
                                            <div class="col-md-3 col-lg-3 col-xl-3">
                                                <h6 class="text-muted">Shirt</h6>
                                                <h6 class="text-black mb-0">Cotton T-shirt</h6>
                                            </div>
                                            <div class="col-md-3 col-lg-3 col-xl-2 d-flex">
                                                <button class="btn btn-link px-2"
                                                    onclick="this.parentNode.querySelector('input[type=number]').stepDown()">
                                                    <i class="fas fa-minus"></i>
                                                </button>

                                                <input id="form1" min="0" name="quantity" value="1" type="number"
                                                    class="form-control form-control-sm" />

                                                <button class="btn btn-link px-2"
                                                    onclick="this.parentNode.querySelector('input[type=number]').stepUp()">
                                                    <i class="fas fa-plus"></i>
                                                </button>
                                            </div>
                                            <div class="col-md-3 col-lg-2 col-xl-2 offset-lg-1">
                                                <h6 class="mb-0">€ 44.00</h6>
                                            </div>
                                            <div class="col-md-1 col-lg-1 col-xl-1 text-end">
                                                <a href="#!" class="text-muted"><i class="fas fa-times"></i></a>
                                            </div>
                                        </div>

                                        <hr class="my-4">

                                        <div class="row mb-4 d-flex justify-content-between align-items-center">
                                            <div class="col-md-2 col-lg-2 col-xl-2">
                                                <img
                                                    src="https://mdbcdn.b-cdn.net/img/Photos/new-templates/bootstrap-shopping-carts/img6.webp"
                                                    class="img-fluid rounded-3" alt="Cotton T-shirt">
                                            </div>
                                            <div class="col-md-3 col-lg-3 col-xl-3">
                                                <h6 class="text-muted">Shirt</h6>
                                                <h6 class="text-black mb-0">Cotton T-shirt</h6>
                                            </div>
                                            <div class="col-md-3 col-lg-3 col-xl-2 d-flex">
                                                <button class="btn btn-link px-2"
                                                    onclick="this.parentNode.querySelector('input[type=number]').stepDown()">
                                                    <i class="fas fa-minus"></i>
                                                </button>

                                                <input id="form1" min="0" name="quantity" value="1" type="number"
                                                    class="form-control form-control-sm" />

                                                <button class="btn btn-link px-2"
                                                    onclick="this.parentNode.querySelector('input[type=number]').stepUp()">
                                                    <i class="fas fa-plus"></i>
                                                </button>
                                            </div>
                                            <div class="col-md-3 col-lg-2 col-xl-2 offset-lg-1">
                                                <h6 class="mb-0">€ 44.00</h6>
                                            </div>
                                            <div class="col-md-1 col-lg-1 col-xl-1 text-end">
                                                <a href="#!" class="text-muted"><i class="fas fa-times"></i></a>
                                            </div>
                                        </div>

                                        <hr class="my-4">

                                        <div class="row mb-4 d-flex justify-content-between align-items-center">
                                            <div class="col-md-2 col-lg-2 col-xl-2">
                                                <img
                                                    src="https://mdbcdn.b-cdn.net/img/Photos/new-templates/bootstrap-shopping-carts/img7.webp"
                                                    class="img-fluid rounded-3" alt="Cotton T-shirt">
                                            </div>
                                            <div class="col-md-3 col-lg-3 col-xl-3">
                                                <h6 class="text-muted">Shirt</h6>
                                                <h6 class="text-black mb-0">Cotton T-shirt</h6>
                                            </div>
                                            <div class="col-md-3 col-lg-3 col-xl-2 d-flex">
                                                <button class="btn btn-link px-2"
                                                    onclick="this.parentNode.querySelector('input[type=number]').stepDown()">
                                                    <i class="fas fa-minus"></i>
                                                </button>

                                                <input id="form1" min="0" name="quantity" value="1" type="number"
                                                    class="form-control form-control-sm" />

                                                <button class="btn btn-link px-2"
                                                    onclick="this.parentNode.querySelector('input[type=number]').stepUp()">
                                                    <i class="fas fa-plus"></i>
                                                </button>
                                            </div>
                                            <div class="col-md-3 col-lg-2 col-xl-2 offset-lg-1">
                                                <h6 class="mb-0">€ 44.00</h6>
                                            </div>
                                            <div class="col-md-1 col-lg-1 col-xl-1 text-end">
                                                <a href="#!" class="text-muted"><i class="fas fa-times"></i></a>
                                            </div>
                                        </div>

                                        <hr class="my-4">--%>

                                        <div class="pt-5">
                                            <h6 class="mb-0"><a href="ProductCatelog.aspx" class="text-body"><i
                                                class="fas fa-long-arrow-alt-left me-2"></i>Back to shop</a></h6>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-lg-4 bg-grey">
                                    <div class="p-5">
                                        <h3 class="fw-bold mb-5 mt-2 pt-1">Summary</h3>
                                        <hr class="my-4">

                                        <div class="d-flex justify-content-between mb-4">
                                            <h5 class="text-uppercase">items <asp:Label ID="lblTotalItems" runat="server" Text="0" /></h5>
                                            <h5>₹ <asp:Label ID="lblTotalPrice" runat="server" Text="0.00" /></h5>
                                        </div>

                                        <h5 class="text-uppercase mb-3">Shipping</h5>

                                        <div class="mb-4 pb-2">
                                            <asp:DropDownList ID="dropShipping" runat="server" CssClass="select p-2 w-100 rounded-2" AutoPostBack="true"  OnSelectedIndexChanged="dropShipping_SelectedIndexChanged">
                                                <asp:ListItem Value="1">Standard-Delivery- ₹20</asp:ListItem>
                                                <asp:ListItem Value="2">Express-Delivery- ₹50</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>

                                        <%--<h5 class="text-uppercase mb-3">Give code</h5>--%>

                                        <%--<div class="mb-5">
                                            <div class="form-outline">
                                                <input type="text" id="form3Examplea2" class="form-control form-control-lg" />
                                                <label class="form-label" for="form3Examplea2">Enter your code</label>
                                            </div>
                                        </div>--%>

                                        <hr class="my-4">

                                        <div class="d-flex justify-content-between mb-5">
                                            <h5 class="text-uppercase">Total price</h5>
                                            <h5>₹ <asp:Label ID="lblFinalPrice" runat="server" Text="0.00"/></h5>
                                        </div>

                                        <asp:Button ID="btnPlaceOrder" runat="server" CssClass="btn btn-dark w-100 btn-block btn-lg"
                                            data-mdb-ripple-color="dark" CommandName="cartitem_id" CommandArgument='<%# Eval("Id") %>' Text="Proceed to Checkout" OnClick="btnPlaceOrder_Click1" />

                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
