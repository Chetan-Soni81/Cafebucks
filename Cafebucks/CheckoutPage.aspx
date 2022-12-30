<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="CheckoutPage.aspx.cs" Inherits="Cafebucks.CheckoutPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid d-flex p-4 gap-4 bg-light">
        <div class="col-md-8">

            <div class="px-4 py-3 border shadow-sm d-flex align-items-start bg-white">
                <div>
                    <h3 class="fs-6 fw-semibold">LOGIN</h3>
                    <h3 class="fs-6 fw-normal">
                        <asp:Label ID="lblUsername" runat="server" Text="Chetan Soni" />
                        <asp:Label ID="lblPhoneNo" CssClass="fw-semibold" runat="server" Text="+918840744109" /></h3>
                </div>

                <div class="ms-auto d">
                    <asp:Button ID="BtnChangeAccount" runat="server" CssClass="btn border text-primary px-4 rounded-0" Text="Change" />
                </div>
            </div>

            <div class="px-4 py-3 border shadow-sm bg-white mt-3 d-flex align-items-start">
                <div>
                    <h3 class="fs-6 text-uppercase fw-semibold">Delivery Address</h3>
                    <h3 class="fs-6 fw-normal">
                        <asp:Label ID="lblAddress" runat="server" Text="Chetan Stationers, near Rajkaran Inter College, Jamunia Bagh, Faizabad, Uttar Pradesh - 224001" /></h3>
                </div>

                <div class="ms-auto d-flex align-items-center">
                    <asp:Button ID="BtnChangeAddress" runat="server" CssClass="btn border text-primary px-4 rounded-0" Text="Change" />
                </div>
            </div>

            <div class="border shadow-sm bg-white mt-3 ">
                <div class="w-100 bg-primary text-white py-3 px-4">
                    <h3 class="fs-6 text-uppercase">Order Summary</h3>
                </div>
                <asp:Repeater ID="repeatOrderItems" runat="server">
                    <ItemTemplate>
                        <div class="px-4 py-3">

                            <div class="d-flex gap-3 ">
                                <div class="col-2">
                                    <asp:Image ID="imageThumbnail" runat="server" CssClass="img-fluid" ImageUrl='<%# Eval("Thumbnail") %>' AlternateText="Thumbnail" />
                                </div>

                                <div class="col-6 d-flex row">
                                    <div>
                                        <h3>
                                            <asp:Label ID="lblProductName" runat="server" CssClass="fs-5 " Text='<%# Eval("ProductName") %>' /></h3>
                                        <asp:Label ID="lblProductCate" runat="server" Text='<%# Eval("CategoryName") %>' />
                                    </div>
                                    <div class="mt-auto mb-1">
                                        <span class="fs-4 fw-bold text-success">₹<asp:Label ID="lblPrice" runat="server" Text='<%# Eval("Price") %>' />
                                        </span>
                                    </div>
                                </div>
                                <div class="col-auto p-3 border-start">
                                    <span class="fw-semibold">Delivery within
                                <asp:Label ID="lblDeliveryTime" runat="server" Text="40 minutes" />
                                        <%--|
                                <asp:Label ID="lblDeliveryCost" runat="server" CssClass="d-block text-success" Text="Free" />--%>
                                    </span>
                                </div>
                            </div>

                            <div class="d-flex mt-3 border-bottom pb-1">
                                <div class="d-flex align-items-center px-4">
                                    <div class="d-flex align-items-center">
                                        <span>Quantity: </span>
                                        <asp:LinkButton ID="btnMinus" runat="server" CssClass="btn btn-link px-2" CommandArgument='<%# Eval("Id") + "," + Eval("Quantity") %>' OnClick="btnMinus_Click">
                                <i class='fas fa-minus'></i>
                                        </asp:LinkButton>

                                        <asp:TextBox ID="txtQuantity" runat="server" ReadOnly="true" min="1" Width="64" Text='<%# Eval("Quantity")%>' TextMode="Number" CssClass="form-control form-control-sm" />

                                        <asp:LinkButton ID="btnPlus" runat="server" CssClass="btn btn-link px-2" CommandArgument='<%# Eval("Id") + "," + Eval("Quantity") %>' OnClick="btnPlus_Click">
                                <i class='fas fa-plus'></i>
                                        </asp:LinkButton>
                                    </div>
                                </div>

                                <div>
                                    <asp:LinkButton ID="BtnRemoveitem" runat="server" CommandArgument='<%# Eval("Id") %>' CssClass="btn fw-semibold linkbtn" Text="REMOVE" OnClick="BtnRemoveItem_Click" />
                                </div>
                            </div>
                        </div>
                        <asp:HiddenField ID="lblProductId" runat="server" Value='<%# Eval("ProductId") %>' />
                        <asp:HiddenField ID="lblProductPrice" runat="server" Value='<%# Eval("ProductPrice") %>' />
                    </ItemTemplate>
                </asp:Repeater>


            </div>
        </div>

        <div class="col-md-3">
            <div class="border shadow-sm bg-white p-4">
                <div class="border-bottom mb-3">
                    <h3 class="text-uppercase fs-5 fw-semibold text-secondary ">price details</h3>
                </div>
                <div>
                    <div class="d-flex px-3 mb-3">
                        <span>Price(<asp:Label ID="lblTotalItems" runat="server" Text="1" /> item)</span>

                        <span class="ms-auto">₹<asp:Label ID="lblFinalPrice" runat="server" Text="999" /></span>
                    </div>
                    <div class="d-flex px-3 mb-3">
                        <span>Delivery Charges</span>
                        <span class="ms-auto"><asp:Label ID="lblDeliveryCharges" runat="server" Text="Free" /></span>
                    </div>
                    <div class="d-flex px-3 mb-3">
                        <span>GST %</span>
                        <span class="ms-auto"><asp:Label ID="lblAddedGst" runat="server" Text="0.00" /></span>
                    </div>
                    <hr />
                    <div class="d-flex px-3 fw-semibold fs-5">
                        <span>Total Payable</span>
                        <span class="ms-auto text-success">₹<asp:Label ID="lblTotalPayable" runat="server" Text="999" /></span>
                    </div>
                    
                    <div class="d-flex px-3 mt-3">
                        <asp:Button ID="BtnPlaceOrder" runat="server" Text="Place Order" BackColor="DarkGreen" ForeColor="White" CssClass="btn btn-tang w-100 fs-5 fw-semibold" OnClick="BtnPlaceOrder_Click"/>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
