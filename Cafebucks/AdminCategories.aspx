<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="AdminCategories.aspx.cs" Inherits="Cafebucks.AdminCategories" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main class="cate__main">

        <div class="container">
            <div class="cate_form_panel">
                <h3>Insert Category</h3>
                <div class="mb-3">
                    <label class="form-label">Category Name:</label>
                    <asp:TextBox ID="txtCategory" runat="server" placeholder="Category name" />
                </div>
                <div class="mb-3">
                    <asp:Button ID="btnSubmit" runat="server" CssClass='add_category' Text="Enter" OnClick="btnSubmit_Click" />
                </div>
            </div>

            <div class="cate_table_panel">
                <h3>Category List</h3>
                <div class="table-responsive">
                    <asp:GridView ID="gviewCategory" runat="server" AutoGenerateColumns="false" OnRowEditing="GridView1_RowEditing" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowUpdating="gviewCategory_RowUpdating" OnRowDeleting="gviewCategory_RowDeleting">
                        <Columns>
                            <asp:BoundField DataField="categoryId" HeaderText="Id" />
                            <asp:BoundField DataField="categoryName" HeaderText="Category Name" />
                            <asp:CheckBoxField DataField="isActive" HeaderText="Is Active" />
                            <asp:CommandField ShowEditButton="true" />
                            <asp:CommandField ShowDeleteButton="true" />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </main>
</asp:Content>
