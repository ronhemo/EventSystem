<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserGroupView.aspx.cs" Inherits="WebSite.UserGroupView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>User Group View</h1>
    user group id: <asp:Label ID="lblUserGroupId" runat="server" Text="Label"></asp:Label><br />
    group: <asp:Label ID="lblUserGroupGroup" runat="server" Text="Label"></asp:Label><br />
    user: <asp:Label ID="lblUserGroupUser" runat="server" Text="Label"></asp:Label><br />


</asp:Content>
