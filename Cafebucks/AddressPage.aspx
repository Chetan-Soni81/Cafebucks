<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="AddressPage.aspx.cs" Inherits="Cafebucks.AddressPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="bg-light">

    
    <div class="container p-4 gap-3 d-flex">
        <div class="col-md-8 col-lg-8 border p-3 bg-white">
            <h4 class="mb-3">Billing address</h4>
            <div class="needs-validation" novalidate="">
                <div class="row g-3">
                    <div class="col-sm-6">
                        <label for="firstName" class="form-label">First name</label>
                        <asp:TextBox ID="txtFirstName" runat="server" CssClass="form-control" placeholder="Firstname" />
                        <div class="invalid-feedback">
                            Valid first name is required.
                        </div>
                    </div>

                    <div class="col-sm-6">
                        <label for="lastName" class="form-label">Last name</label>
                        <asp:TextBox ID="txtLastName" runat="server" CssClass="form-control" placeholder="Lastname" />
                        <div class="invalid-feedback">
                            Valid last name is required.
                        </div>
                    </div>

                    <div class="col-4">
                        <label for="username" class="form-label">Mobile No.</label>
                        <div class="input-group has-validation">
                            <span class="input-group-text">+91</span>
                            <asp:TextBox ID="txtMobileNo" runat="server" TextMode="Phone" CssClass="form-control" placeholder="XXXXXXXXXX" />
                            <div class="invalid-feedback">
                                Your username is required.
                            </div>
                        </div>
                    </div>

                    <div class="col-8">
                        <label for="email" class="form-label">Email <span class="text-muted">(Optional)</span></label>
                        <asp:TextBox ID="txtEmail" runat="server" TextMode="email" CssClass="form-control" placeholder="you@example.com" />
                        <div class="invalid-feedback">
                            Please enter a valid email address for shipping updates.
                        </div>
                    </div>

                    <div class="col-5">
                        <label for="address" class="form-label">Building or House Name/No.</label>
                        <asp:TextBox ID="txtBuilding" runat="server" CssClass="form-control" Placeholder="House or Building" />
                        <div class="invalid-feedback">
                            Please enter your shipping address.
                        </div>
                    </div>

                    <div class="col-7">
                        <label class="form-label">Landmark</label>
                        <asp:TextBox ID="txtLandmark" runat="server" CssClass="form-control" placeholder="Landmark" />
                        <div class="invalid-feedback">
                            Please enter your shipping address.
                        </div>
                    </div>

                    <div class="col-12">
                        <label for="address2" class="form-label">Street</label>
                        <asp:TextBox Id="txtStreet" runat="server" CssClass="form-control" placeholder="Street" />
                    </div>

                    <div class="col-md-5">
                        <label for="country" class="form-label">State</label>
                        <asp:DropDownList ID="dropStates" runat="server" CssClass="form-select" DataTextField="stateName" DataValueField="stateId" OnSelectedIndexChanged="DropState_SelectedIndexChanged" AutoPostBack="true">
                            <asp:ListItem Value="">---Please Select a State---</asp:ListItem>
                        </asp:DropDownList>
                        <div class="invalid-feedback">
                            Please select a valid country.
                        </div>
                    </div>

                    <div class="col-md-4">
                        <label for="state" class="form-label">City</label>
                        <asp:DropDownList ID="dropCities" runat="server" CssClass="form-select" DataTextField="cityName" DataValueField="cityId">
                            <asp:ListItem Value="">---Please Select a City---</asp:ListItem>
                        </asp:DropDownList>
                        <div class="invalid-feedback">
                            Please provide a valid state.
                        </div>
                    </div>

                    <div class="col-md-3">
                        <label for="zip" class="form-label">Pin Code</label>
                        <asp:TextBox ID="txtPinCode" runat="server" CssClass="form-control" Placeholder="XXXXXX" TextMode="Number"/>
                        <div class="invalid-feedback">
                            Zip code required.
                        </div>
                    </div>
                </div>

                <hr class="my-4">

                <div class="form-check">
                    <input type="checkbox" class="form-check-input" id="same-address">
                    <label class="form-check-label" for="same-address">Shipping address is the same as my billing address</label>
                </div>

                <div class="form-check">
                    <input type="checkbox" class="form-check-input" id="save-info">
                    <label class="form-check-label" for="save-info">Save this information for next time</label>
                </div>

                <hr class="my-4">

                <asp:Button ID="BtnSave" runat="server" CssClass="w-100 btn btn-primary btn-lg" Text="Continue to checkout" OnClick="BtnSave_Click" />
            </div>
        </div>

        <div class="col-sm col-md-4 border p-4 bg-white">
            <h4>Addresses Saved</h4>
            <hr />
            <div class="d-flex gap-3 flex-column">
                <asp:Repeater ID="repeaterAddress" runat="server" >
                    <ItemTemplate>
                        <div class="rounded-3 border p-3 shadow-sm">
                            <asp:HiddenField ID="HiddenAddressID" runat="server" Value='<%# Eval("AddressID") %>' />
                    <section>
                        <h5 class="fs-6"><span><asp:Label ID="LblName" runat="server" Value='<%# Eval("Name") %>' /></span> - <span><asp:Label ID="LblPhone" runat="server" Value='<%# Eval("PhoneNo") %>' /></span></h5>
                    </section>
                    <%if (Convert.ToBoolean(Eval("Email")))
                      {%>
                            <seciton>
                                <h6 class="text-muted">Email: <span><asp:Label ID="lblEmail" runat="server" Value='<%# Eval("Email") %>' /></span></h6>
                            </seciton>
                      <%} %>
                    <section>
                        <span class=""><asp:Label ID=LblAddressText runat="server" Value='<%# Eval("AddressText") %>' /></span>
                    </section>
                    <section class="d-flex">
                        <span class="ms-auto">
                            <asp:LinkButton ID="BtnEdit" runat="server" Text="Edit" CssClass="btn text-primary" />
                            <asp:LinkButton ID="BtnDelete" runat="server" Text="Delete" CssClass="btn text-primary" />
                        </span>
                    </section>
                </div>
                    </ItemTemplate>
                </asp:Repeater>

                <div class="rounded-3 border p-3 shadow-sm">
                    <section>
                        <h5 class="fs-6"><span>Chetan Soni</span> - <span>+918849744109</span></h5>
                    </section>
                    <section>
                        <h6 class="text-muted">Email: <span>chetansoni8101@gmail.com</span></h6>
                    </section>
                    <section>
                        <span class="">Chetan Soni Chetan Stationers, near Rajkaran Inter College, Jamunia Bagh, Faizabad, Ayodhya - 224001, Uttar Pradesh</span>
                    </section>
                    <section class="d-flex">
                        <span class="ms-auto">
                            <asp:LinkButton ID="BtnEdit" runat="server" Text="Edit" CssClass="btn text-primary" />
                            <asp:LinkButton ID="BtnDelete" runat="server" Text="Delete" CssClass="btn text-primary" />
                        </span>
                    </section>
                </div>
                <div class="rounded-3 border p-3 shadow-sm">
                    <section>
                        <h5 class="fs-6"><span>Chetan Soni</span> - <span>+918849744109</span></h5>
                    </section>
                    <section>
                        <span class="">Chetan Soni Chetan Stationers, near Rajkaran Inter College, Jamunia Bagh, Faizabad, Ayodhya - 224001, Uttar Pradesh</span>
                    </section>
                    <section class="d-flex">
                        <span class="ms-auto">
                            <asp:LinkButton ID="LinkButton1" runat="server" Text="Edit" CssClass="btn text-primary" />
                            <asp:LinkButton ID="LinkButton2" runat="server" Text="Delete" CssClass="btn text-primary" />
                        </span>
                    </section>
                </div>
            </div>
        </div>
    </div>
</div>
</asp:Content>
