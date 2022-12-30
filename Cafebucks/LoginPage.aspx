<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="Cafebucks.LoginPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main>
        <div class='login__main'>
            <div class="col-12 col-md-8 slide__panel">
                <div class="carousel slide" data-bs-ride="carousel">
                    <div class="carousel-inner">
                        <div class="carousel-item active">
                            <img src="images/img-cor-1.jpg" class="d-block w-100" alt="...">
                        </div>
                        <div class="carousel-item">
                            <img src="images/img-cor-2.jpg" class="d-block w-100" alt="...">
                        </div>
                        <div class="carousel-item">
                            <img src="images/img-cor-3.jpg" class="d-block w-100" alt="...">
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-12 col-md form__panel">
                <h3 class='mb-3 text-center'>Login Form</h3>
                <div class='mb-3'>
                    <label class="form-label">Username:</label>
                    <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control" placeholder="Username" />
                </div>
                <div class="mb-3">
                    <label class="form-label">Password:</label>
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control" placeholder="Password" />
                </div>
                <div class="mb-3">
                    <asp:Button ID="btnLogin" runat="server" CssClass='btn btn-success w-100 radius-0' Text="Login" OnClick="btnLogin_Click" />
                </div>
                <div class='mb-3 text-center fw-4'>
                    <span>Not registered? <a href='/SignupPage.aspx' style="text-decoration: none; font-weight: 600">Register here</a></span>
                </div>
            </div>
        </div>
    </main>
</asp:Content>
