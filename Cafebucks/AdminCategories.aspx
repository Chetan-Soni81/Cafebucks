<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="AdminCategories.aspx.cs" Inherits="Cafebucks.AdminCategories" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main class="cate__main bg-light">

        <div class="container">
            <div class="cate_form_panel bg-white">
                <div class=".form">
                    <h3 class="text-center mb-4">Create Category</h3>
                    <div class="mb-3">
                        <label class="form-label">Category Name:</label>
                        <asp:TextBox ID="txtCategory" runat="server" CssClass="form-control" placeholder="Category Name" ValidationGroup="Add" />
                        <asp:RequiredFieldValidator ID="validCategory" runat="server" ForeColor="Red" Display="Dynamic" ControlToValidate="txtCategory" ErrorMessage="* Category Name is required" ValidationGroup="Add"/>
                    </div>
                    <div class="mb-3">
                        <asp:Button ID="btnSubmit" runat="server" CssClass='add_category button' Text="Enter" ValidationGroup="Add" OnClick="btnSubmit_Click" />
                    </div>
                </div>
            </div>

            <div class="cate_table_panel bg-white">
                <h3>Category List</h3>
                <div class="table-responsive">
                    <asp:GridView ID="gviewCategory" runat="server" AutoGenerateColumns="false" DataKeyNames="categoryId" CssClass="table table-hover table-bordered" OnRowEditing="GridView1_RowEditing" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowUpdating="gviewCategory_RowUpdating" OnRowDeleting="gviewCategory_RowDeleting">
                        <Columns>
                            <asp:TemplateField HeaderText="SrNo" ItemStyle-Width="100">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex + 1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Category Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblCategoryName" runat="server" Text='<%# Eval("categoryName") %>' />
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtCategoryName" runat="server" Text='<%# Eval("categoryName") %>' />
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Is Active">
                                <ItemTemplate>
                                    <asp:Label ID="lblIsActive" runat="server" Text='<%# Eval("isActive") %>' />
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:CheckBox ID="chkIsActive" runat="server" Checked='<%# Eval("isActive") %>' />
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Actions" ItemStyle-Width="200">
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
    </main>
</asp:Content>
