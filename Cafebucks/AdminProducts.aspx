<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="AdminProducts.aspx.cs" Inherits="Cafebucks.AdminProducts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="admin_prod_main">
        <div class="prod_form_panel">
            <div class=".form">
                <h3 class="text-center">Add Product</h3>
                <div class="mb-3">
                    <label class="form-label">Product Name:</label>
                    <asp:TextBox ID="txtProductName" runat="server" CssClass="form-control" placeholder="Product Name" />
                    <asp:RequiredFieldValidator ID="validProdName" runat="server" ControlToValidate="txtProductName" ErrorMessage="* Product Name is Required" ValidationGroup="FormValid" />
                </div>
                <div class="mb-3">
                    <label class="form-label">Price: </label>
                    <asp:TextBox ID="txtPrice" runat="server" TextMode="Number" CssClass="form-control" placeholder='Price' />
                    <asp:RequiredFieldValidator ID="validPrice" runat="server" ControlToValidate="txtPrice" ErrorMessage="* Price is Required" ValidationGroup="FormValid" />
                </div>
                <div class="mb-3">
                    <label class="form-label">Category:</label>
                    <asp:DropDownList ID="dropCategory" runat="server" CssClass="form-control rounded-0" DataValueField="categoryId" DataTextField="categoryName" />
                    <asp:RequiredFieldValidator ID="validCategory" runat="server" ControlToValidate="dropCategory" ErrorMessage="* Product Category is required" ValidationGroup="FormValid" />
                </div>
                <div class="mb-3">
                    <label class="form-label">Sub Category:</label>
                    <asp:DropDownList ID="dropSubCategory" runat="server" CssClass="form-control rounded-0" DataValueField="categoryId" DataTextField="categoryName" />
                </div>
                <div class="mb-3">
                    <label class="form-label">Thumbnail Image:</label>
                    <asp:FileUpload ID="fileThumbnail" runat="server" accept="image/*" CssClass="form-control" />
                    <asp:RequiredFieldValidator ID="validThumbnail" runat="server" ControlToValidate="fileThumbnail" ErrorMessage="* Thumbnail Image is required" ValidationGroup="FormValid" />
                </div>
                <div class="mb-3">
                    <label class="form-label">Images:</label>
                    <asp:FileUpload ID="fileImages" runat="server" accept="image/*" AllowMultiple="true" CssClass="form-control" />
                </div>
                <div class="mb-3">
                    <label class="form-label">Product Description:</label>
                    <asp:TextBox ID="txtDescription" runat="server" Rows="5" TextMode="MultiLine" CssClass="form-control rounded-0" placeholder="Product Description" />
                    <asp:RequiredFieldValidator ID="validDescription" runat="server" ControlToValidate="txtDescription" ErrorMessage="* Description is required" ValidationGroup="FormValid" />
                </div>
                <div class="mb-3">
                    <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-success " Text="Add" ValidationGroup="FormValid" OnClick="btnSubmit_Click" />
                    <asp:Button ID="btnReset" runat="server" CssClass="btn btn-primary" Text="Reset" />
                </div>
            </div>
        </div>
        <div class="prod_table_panel ">
            <h3>Product List</h3>
            <div class="table-responsive">
                <asp:GridView runat="server" ID="gviewProducts" DataKeyNames="" CssClass="table table-hover overflow-auto " AutoGenerateColumns="False" OnRowEditing="gviewProducts_RowEditing" OnRowCancelingEdit="gviewProducts_RowCancelingEdit" OnRowUpdating="gviewProducts_RowUpdating" OnRowDeleting="gviewProducts_RowDeleting">
                    <Columns>
                        <asp:BoundField DataField="productName" HeaderText="Product Name" />
                        <asp:BoundField DataField="price" HeaderText="Product Price" />
                        <asp:BoundField DataField="category" HeaderText="Product Category" />
                        <asp:BoundField DataField="subcategory" HeaderText="Product Subcategory" />
                        <asp:TemplateField HeaderText="Product Thumbnail">
                            <ItemTemplate>
                                <asp:Image ID="imgProduct" runat="server" ImageUrl='<%# Eval("mainImage") %>' Height="50" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="description" HeaderText="Product description" />
                        <asp:CheckBoxField DataField="isAvailable" HeaderText="Is Available" />
                        <asp:CheckBoxField DataField="isActive" HeaderText="Is Active" />
                        <asp:TemplateField></asp:TemplateField>
                        <asp:TemplateField HeaderText="Actions">
                            <EditItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" CommandName="Update" Text="Update"></asp:LinkButton>
                                &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel"></asp:LinkButton>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <span class="d-flex">
                                    <asp:Button ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit" CssClass="btn btn-warning rounded-0" Text="Edit"></asp:Button>
                                    <asp:Button ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Delete" CommandArgument='<%# Eval("productid") %>' CssClass="btn btn-danger  rounded-0 ms-2" ForeColor="White" Text="Delete"></asp:Button>
                                </span>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
