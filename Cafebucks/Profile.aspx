<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="Cafebucks.Profile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container col-md-5 mt-4 p-3 rounded-2 shadow-lg">
        <h3 class="text-center">User Details</h3>
        <div class="mb-2 d-flex justify-content-center">
            <asp:Image ID="img_profile" runat="server" CssClass=" w-50 " />
        </div>
        <div class="mb-2">
            <label class="fw-bold">Name: </label>
            <asp:Label ID="lbl_name" runat="server" Text="Name of the user"></asp:Label>
        </div>
        <div class="mb-2">
            <label class="fw-bold">Username: </label>
            <asp:Label ID="lbl_username" runat="server" Text="Username of the user"></asp:Label>
        </div>
        <div class="mb-2">
            <label class="fw-bold">Gender: </label>
            <asp:Label ID="lbl_gender" runat="server" Text="Gender of the user"></asp:Label>
        </div>
        <div class="mb-2">
            <label class="fw-bold">E-mail: </label>
            <asp:Label ID="lbl_email" runat="server" Text="E-mail of the user"></asp:Label>
        </div>
        <div class="mb-2">
            <label class="fw-bold">Mobile No.: </label>
            <asp:Label ID="lbl_mobileno" runat="server" Text="Mobile no. of the user"></asp:Label>
        </div>
        <div class="mb-2">
            <label class="fw-bold">Languages Known: </label>
            <asp:Label ID="lbl_langs" runat="server" Text="Languages known to the user"></asp:Label>
        </div>
    </div>
</asp:Content>
