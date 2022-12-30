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
                    <asp:GridView ID="gviewCategory" runat="server" AutoGenerateColumns="false" CssClass="table table-hover" OnRowEditing="GridView1_RowEditing" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowUpdating="gviewCategory_RowUpdating" OnRowDeleting="gviewCategory_RowDeleting">
                        <Columns>
                            <asp:BoundField DataField="categoryId" HeaderText="Id" />
                            <asp:BoundField DataField="categoryName" HeaderText="Category Name" />
                            <asp:CheckBoxField DataField="isActive" HeaderText="Is Active" />
                            <asp:CommandField ShowEditButton="true" ControlStyle-CssClass="button update_btn text-decoration-none"/>
                            <asp:CommandField ShowDeleteButton="true" ControlStyle-CssClass="button delete_btn text-decoration-none"/>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </main>
</asp:Content>
