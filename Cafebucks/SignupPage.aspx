<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="SignupPage.aspx.cs" Inherits="Cafebucks.SignupPage" %>
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
    <div class="col-sm-12 col-md form__panel">
            <h3 class='mb-3 text-center'>Registration Form</h3>
            <div class="mb-3">
                <label class="form-label">First Name: </label>
                <asp:TextBox ID="txtFname" runat="server" CssClass="form-control" placeholder='First Name'/>
            </div>
            <div class="mb-3">
              <Label class="form-label">Last Name:</Label>
              <asp:TextBox ID="txtLname" runat="server" CssClass="form-control" placeholder='Last Name'/>
            </div>
            <div class='mb-3'>
              <Label class="form-label">Username:</Label>
              <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control" placeholder='Username' />
            </div>
            <div class="mb-3">
              <Label class="form-label">E-mail:</Label>
              <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder='E-mail'/>
            </div>
            <div class="mb-3">
              <Label class="form-label">Password:</Label>
              <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password" placeholder='Password' />
            </div>
            <div class="mb-3">
              <asp:Button ID="btnSignup" runat="server" CssClass='btn btn-success w-100 radius-0' Text="Register" OnClick="btnSignup_Click"/>
            </div>
            <div class='mb-3 text-center fw-4'>
              <span>Already registered? <a href='/LoginPage.aspx' style="text-decoration: none; font-weight : 600">Login here</a></span>
            </div>
        </div>
      </div>
    </main>
</asp:Content>
