<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RoleMng.aspx.cs" Inherits="WebSite.RoleMng" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Role List</h1>
    <hr />
    <a class="btn btn-secondary" href="RoleAddUpdate.aspx" >Add Role</a>
    <hr />
    <asp:Repeater ID="RoleRepeater" runat="server">
        <ItemTemplate>
            <div class="card" style="width: 16rem; padding-bottom:5px;">
                <div class="card-body">
                    <h5 class="card-title">role: <%# Eval("rolename") %></h5>
                    <a class="btn btn-success" href="RoleView.aspx?roleid=<%# Eval("roleid") %>">View</a>
                    <a class="btn btn-warning" href="RoleAddUpdate.aspx?roleid=<%# Eval("roleid") %>">Update</a>
                </div>
            </div>

        </ItemTemplate>
        <SeparatorTemplate>
            <br />
        </SeparatorTemplate>
    </asp:Repeater>

</asp:Content>
