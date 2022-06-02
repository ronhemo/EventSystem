<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RoleView.aspx.cs" Inherits="WebSite.RoleView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Role View</h1>
    Role id: <asp:Label ID="lblRoleId" runat="server" Text="Label"></asp:Label><br />
    Role Name: <asp:Label ID="lblRoleName" runat="server" Text="Label"></asp:Label><br />

</asp:Content>
