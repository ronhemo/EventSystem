<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserGroupMng.aspx.cs" Inherits="WebSite.UserGroupMng" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>User Group List</h1>
    <hr />
    <a href="UserGroupAddUpdate.aspx" >Add User Group</a>
    <hr />
    <asp:Repeater ID="UserGroupRepeater" runat="server">
        <ItemTemplate>
            usergroupid: <%# Eval("usergroupid") %><br /> 
            <a href="UserGroupView.aspx?usergroupid=<%# Eval("usergroupid") %>">View</a><br />
            <a href="UserGroupAddUpdate.aspx?usergroupid=<%# Eval("usergroupid") %>">Update/Delete</a><br />
        </ItemTemplate>
        <SeparatorTemplate>
            <br />
        </SeparatorTemplate>
    </asp:Repeater>

    
</asp:Content>
