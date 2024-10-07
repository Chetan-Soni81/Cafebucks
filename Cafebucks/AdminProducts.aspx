<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="AdminProducts.aspx.cs" Inherits="Cafebucks.AdminProducts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="p-3 container-fluid bg-light">
        <div class="container-fluid p-4 bg-white">
            <div class=".form">
                <h3 class="text-center">Add Product</h3>
                <div class="mb-3">
                    <label class="form-label">Product Name:</label>
                    <asp:TextBox ID="txtProductName" runat="server" CssClass="form-control" placeholder="Product Name" />
                    <asp:RequiredFieldValidator ID="validProdName" runat="server" ControlToValidate="txtProductName" ForeColor="Red" Display="Dynamic" ErrorMessage="* Product Name is Required" ValidationGroup="FormValid" />
                </div>
                <div class="mb-3">
                    <label class="form-label">Price: </label>
                    <asp:TextBox ID="txtPrice" runat="server" TextMode="Number" CssClass="form-control" placeholder='Price' />
                    <asp:RequiredFieldValidator ID="validPrice" runat="server" ControlToValidate="txtPrice" ForeColor="Red" Display="Dynamic" ErrorMessage="* Price is Required" ValidationGroup="FormValid" />
                </div>
                <div class="mb-3">
                    <label class="form-label">Category:</label>
                    <asp:DropDownList ID="dropCategory" runat="server" CssClass="form-select rounded-0" DataValueField="categoryId" DataTextField="categoryName" />
                    <asp:RequiredFieldValidator ID="validCategory" runat="server" ControlToValidate="dropCategory" ForeColor="Red" Display="Dynamic" ErrorMessage="* Product Category is required" ValidationGroup="FormValid" />
                </div>
                <div class="mb-3">
                    <label class="form-label">Sub Category:</label>
                    <asp:DropDownList ID="dropSubCategory" runat="server" CssClass="form-select rounded-0" DataValueField="categoryId" DataTextField="categoryName" />
                </div>
                <div class="mb-3">
                    <label class="form-label">Thumbnail Image:</label>
                    <asp:FileUpload ID="fileThumbnail" runat="server" accept="image/*" CssClass="form-control" />
                    <asp:RequiredFieldValidator ID="validThumbnail" runat="server" ControlToValidate="fileThumbnail" ForeColor="Red" Display="Dynamic" ErrorMessage="* Thumbnail Image is required" ValidationGroup="FormValid" />
                </div>
                <div class="mb-3">
                    <label class="form-label">Images:</label>
                    <asp:FileUpload ID="fileImages" runat="server" accept="image/*" AllowMultiple="true" CssClass="form-control" />
                </div>
                <div class="mb-3">
                    <label class="form-label">Product Description:</label>
                    <asp:TextBox ID="txtDescription" runat="server" Rows="5" TextMode="MultiLine" CssClass="form-control rounded-0" placeholder="Product Description" />
                    <asp:RequiredFieldValidator ID="validDescription" runat="server" ControlToValidate="txtDescription" ForeColor="Red" Display="Dynamic" ErrorMessage="* Product Description is required" ValidationGroup="FormValid" />
                </div>
                <div class="mb-3">
                    <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-success " Text="Add" ValidationGroup="FormValid" OnClick="btnSubmit_Click" />
                    <asp:Button ID="btnReset" runat="server" CssClass="btn btn-primary" Text="Reset" />
                </div>
            </div>
        </div>
        <div class="prod_table_panel bg-white ">
            <h3>Product List</h3>
            <div class="table-responsive">
                <asp:GridView runat="server" ID="gviewProducts" DataKeyNames="productId" CssClass="table table-hover table-bordered overflow-auto " AutoGenerateColumns="False" OnRowEditing="gviewProducts_RowEditing" OnRowCancelingEdit="gviewProducts_RowCancelingEdit" OnRowUpdating="gviewProducts_RowUpdating" OnRowDeleting="gviewProducts_RowDeleting">
                    <Columns>
                        <asp:TemplateField HeaderText="Name">
                            <ItemTemplate>
                                <asp:Label ID="lblProductName" runat="server" Text='<%# Eval("productName") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtProductName" runat="server" Text='<%# Eval("productName") %>' CssClass="w-100 px-2" autofocus="true" />
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Price">
                            <ItemTemplate>
                                &#8377; <asp:Label ID="lblPrice" runat="server" Text='<%# Eval("price") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtPrice" runat="server" Text='<%# Eval("price") %>' CssClass="w-100 px-2"></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Category">
                            <ItemTemplate>
                                <asp:Label ID="lblCategory" runat="server" Text='<%# Eval("categoryName") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>

                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Sub-Category">
                            <ItemTemplate>
                                <asp:Label ID="lblSubCategory" runat="server" Text='<%# Eval("subcategoryName") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>

                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Thumbnail">
                            <ItemTemplate>
                                <asp:Image ID="imgProduct" runat="server" ImageUrl='<%# Eval("thumbnail") %>' Height="50" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="description" HeaderText="Description" ItemStyle-Width="325" />
                        <asp:CheckBoxField DataField="isAvailable" HeaderText="Is-Available" />
                        <asp:CheckBoxField DataField="isActive" HeaderText="Is-Active" />
                        <asp:TemplateField HeaderText="Actions">
                            <ItemTemplate>
                                    <asp:LinkButton ID="btnEdit" runat="server" CommandName="Edit" CssClass="btn btn-sm btn-primary"><i class="fa-solid fa-pen-to-square"></i> Edit</asp:LinkButton>
                                    <asp:LinkButton ID="btnDelete" runat="server" CommandName="Delete" CssClass="btn btn-sm btn-dark"><i class="fa-solid fa-trash"></i> Delete</asp:LinkButton>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:LinkButton ID="btnUpdate" runat="server" CommandName="Update" CssClass="btn btn-sm btn-success"><i class="fa fa-save"></i> Save</asp:LinkButton>
                                    <asp:LinkButton ID="btnCancel" runat="server" CommandName="Cancel" CssClass="btn btn-sm btn-danger"><i class="fa-solid fa-xmark"></i> Cancel</asp:LinkButton>
                                </EditItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <HeaderStyle CssClass="table-dark" />
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
