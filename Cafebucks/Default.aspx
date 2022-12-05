<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Cafebucks.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Test Application</title>
    <link rel="stylesheet" href="bootstrap/dist/css/bootstrap.min.css" />
    <script src="bootstrap/dist/js/bootstrap.min.js" type="text/javascript"></script>
</head>
<body class="bg-light">

    <div class="container bg-white col-md-5 mt-4 p-3 rounded-2 shadow-lg">
        <h3 class="text-center">Registration Form</h3>
        <form id="form1" class="needs-validate" runat="server" novalidate="novalidate">
            <div>
                <label class="form-label">
                    Name:
                </label>
                <div class="row">
                    <div class="col"><asp:TextBox ID="txt_fname" runat="server" CssClass="form-control" placeholder="First Name"></asp:TextBox></div>
                    <div class="col"><asp:TextBox ID="txt_mname" runat="server" CssClass="form-control" placeholder="Middle Name"></asp:TextBox></div>
                    <div class="col"><asp:TextBox ID="txt_lname" runat="server" CssClass="form-control" placeholder="Last Name"></asp:TextBox></div>
                </div>
                
                <asp:RequiredFieldValidator ID="valid_name" ControlToValidate="txt_fname" ErrorMessage="* Name is required" runat="server" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>
            <div>
                <label class="form-label">
                    Username:
                </label>
                <asp:TextBox ID="txt_username" runat="server" CssClass="form-control" placeholder="Username"></asp:TextBox>
                <asp:RequiredFieldValidator ID="valid_username" ControlToValidate="txt_username" ErrorMessage="* Username is required" runat="server" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>
            <div>
                <label class="form-label">Gender: </label>
                <asp:RadioButtonList ID="radio_gender" runat="server" RepeatDirection="Horizontal" CellPadding="4">
                    <asp:ListItem Value="1">Male</asp:ListItem>
                    <asp:ListItem Value="0">Female</asp:ListItem>
                    <asp:ListItem Value="">Others</asp:ListItem>
                </asp:RadioButtonList>
                <asp:RequiredFieldValidator ID="valid_gender" runat="server" ControlToValidate="radio_gender" ErrorMessage="* Please select your gender" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>
            <div>
                <label class="form-label">
                    Email:
                </label>
                <asp:TextBox ID="txt_email" runat="server" CssClass="form-control" TextMode="Email" placeholder="E-mail"></asp:TextBox>
                <asp:RequiredFieldValidator ID="valid_email" runat="server" ControlToValidate="txt_email" ErrorMessage="* Email is required" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>
            <div>
                <label class="form-label">
                    Mobile No:
                </label>
                <asp:TextBox ID="txt_mobileno" runat="server" CssClass="form-control" TextMode="Phone" placeholder="Mobile no"></asp:TextBox>
                <asp:RequiredFieldValidator ID="valid_mobileno" runat="server" ControlToValidate="txt_mobileno" ErrorMessage="* Mobile no is required" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>
            <div>
                <label class="form-label">
                    Languages Known:
                </label>
                <div class="form-check form-check-inline">
                    <asp:CheckBox ID="check_hindi" runat="server" CssClass="form-check-input" /><label class="form-check-label">Hindi</label>
                </div>
                <div class="form-check form-check-inline">
                    <asp:CheckBox ID="check_english" runat="server" CssClass="form-check-input" /><label class="form-check-label">English</label>
                </div>
            </div>
            <div>
                <label class="form-label">
                    Password:
                </label>
                <asp:TextBox ID="txt_password" runat="server" CssClass="form-control" TextMode="Password" placeholder="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="valid_password" runat="server" ControlToValidate="txt_password" ErrorMessage="* Password is required" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>
            <div class="mb-3">
                <label class="form-label">Profile Picture:</label>
                <asp:FileUpload ID="file_profile" runat="server" CssClass="form-control" accept="image/*" />
            </div>
            <div class="mb-4">
                <asp:Button runat="server" ID="submitBTN" CssClass="btn btn-primary" OnClick="submitBTN_Click" Text="Submit" />
            </div>
            <div class="p-2">
                <div id="result_p" runat="server" Visible="false" class="text-danger">* User Already Exists</div>
            </div>
            <a href="Login.aspx">Already Have an account? Login here</a>
        </form>
    </div>
</body>
</html>
