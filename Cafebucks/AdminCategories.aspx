<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="AdminCategories.aspx.cs" Inherits="Cafebucks.AdminCategories" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main class="cate__main">

        <div class="container">
            <div class="cate_form_panel">
                <div class=".form">
                    <h3 class="text-center mb-4">Insert Category</h3>
                    <div class="mb-3">
                        <label class="form-label">Category Name:</label>
                        <asp:TextBox ID="txtCategory" runat="server" CssClass="form-control" placeholder="Category name" />
                    </div>
                    <div class="mb-3">
                        <asp:Button ID="btnSubmit" runat="server" CssClass='add_category button' Text="Enter" OnClick="btnSubmit_Click" />
                    </div>
                </div>
            </div>

            <div class="cate_table_panel">
                <h3>Category List</h3>
                <div class="table-responsive">
                    <asp:GridView ID="gviewCategory" runat="server" AutoGenerateColumns="false" DataKeyNames="categoryId" CssClass="table table-hover table-bordered" OnRowEditing="GridView1_RowEditing" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowUpdating="gviewCategory_RowUpdating" OnRowDeleting="gviewCategory_RowDeleting">
                        <Columns>
                            <asp:TemplateField HeaderText="SrNo">
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
                            <asp:CheckBoxField DataField="isActive" HeaderText="Is Active" />
                            <asp:TemplateField HeaderText="Actions">
                                <ItemTemplate>
                                    <asp:Button ID="btnEdit" runat="server" CommandName="Edit" CssClass="btn btn-sm btn-warning" Text="Edit" />
                                    <asp:Button ID="btnDelete" runat="server" CommandName="Delete" CssClass="btn btn-sm btn-danger" Text="Delete" />
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:LinkButton ID="btnUpdate" runat="server" CommandName="Update" CssClass="btn btn-sm btn-success"><i class="fa fa-save"></i> Save</asp:LinkButton>
                                    <asp:Button ID="btnCancel" runat="server" CommandName="Cancel" CssClass="btn btn-sm btn-danger" Text="Cancel" />
                                </EditItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </main>
</asp:Content>
