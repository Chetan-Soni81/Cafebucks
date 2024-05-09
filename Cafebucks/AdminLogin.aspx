<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="AdminLogin.aspx.cs" Inherits="Cafebucks.AdminLogin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main class='admin_login_main container-fuild bg-light'>
        <div class='admin_login_panel bg-white'>
            <h3>Admin Login</h3>
            <div class="mb-3">
                <label class="form-label">Username:</label>
                <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control" placeholder='Username' autofocus="true" />
                <asp:RequiredFieldValidator ID="validUsername" runat="server" CssClass="text-danger" Display="Dynamic" ControlToValidate="txtUsername" ErrorMessage="* Username is required" ValidationGroup="Login"></asp:RequiredFieldValidator>
            </div>
            <div class="mb-3">
                <label class="form-label">Password: </label>
                <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password" placeholder="Password" />
                <asp:RequiredFieldValidator ID="validPassword" runat="server" CssClass="text-danger" Display="Dynamic" ControlToValidate="txtPassword" ErrorMessage="* Password is required" ValidationGroup="Login" />
            </div>
            <div class="mb-3">
                <asp:Button ID="btnSubmit" runat="server" Text="Login" CssClass="button" ValidationGroup="Login" OnClick="btnSubmit_Click" />
            </div>
        </div>
    </main>


</asp:Content>
