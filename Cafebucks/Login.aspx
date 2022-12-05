<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Cafebucks.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Test Application</title>
    <link rel="stylesheet" href="bootstrap/dist/css/bootstrap.min.css" />
    <script src="bootstrap/dist/js/bootstrap.min.js" type="text/javascript"></script>
</head>
<body class="bg-light">

    <div class="container bg-white col-md-5 mt-4 p-3 rounded-2 shadow-lg">
        <h3 class="text-center">Login Form</h3>
        <form id="form1" class="needs-validate" runat="server" novalidate="novalidate">
            <div>
                <label class="form-label">
                    Username:
                </label>
                <asp:TextBox ID="txt_username" runat="server" CssClass="form-control" placeholder="Username"></asp:TextBox>
                <asp:RequiredFieldValidator ID="valid_username" ControlToValidate="txt_username" ErrorMessage="* Username is required" runat="server" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>
            <div>
                <label class="form-label">
                    Password:
                </label>
                <asp:TextBox ID="txt_password" runat="server" CssClass="form-control" TextMode="Password" placeholder="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="valid_password" runat="server" ControlToValidate="txt_password" ErrorMessage="* Password is required" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>
            <asp:Label ID="lbl_result" runat="server" Visible="false" CssClass="form-label text-danger">* Username or Password Incorect</asp:Label>
            <div class="mb-4">
                <asp:Button runat="server" ID="submitBTN" CssClass="btn btn-primary" OnClick="submitBTN_Click" Text="Login" />
            </div>

            <a href="Default.aspx">Not Registered? Register Here</a>
        </form>
    </div>
</body>
</html>
