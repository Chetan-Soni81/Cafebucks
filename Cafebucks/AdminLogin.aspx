<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="AdminLogin.aspx.cs" Inherits="Cafebucks.AdminLogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
            <main class='admin_login_main'>
            <div class='admin_login_panel'>
                    <h3>Admin Login</h3>
                    <div class="mb-3">
                        <label class="form-label">Username:</label>
                        <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control" placeholder='Username' />
                    </div>
                    <div class="mb-3">
                        <lable class="form-label">Password: </lable>
                        <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password"  placeholder="Password" />
                    </div>
                    <div class="mb-3">
                        <asp:Button ID="btnSubmit" runat="server" Text="Login" CssClass="button" OnClick="btnSubmit_Click"/>
                    </div>
            </div>
        </main>


</asp:Content>
