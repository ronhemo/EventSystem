<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RoleAddUpdate.aspx.cs" Inherits="WebSite.RoleAddUpdate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1><asp:Label ID="header" runat="server" Text="header"></asp:Label></h1>
   
        
    <asp:Label ID="lblRoleId" runat="server" Visible="false"></asp:Label><br />
    Role name: <asp:TextBox ID="txtRoleName" runat="server"></asp:TextBox><br />
          
    <asp:Button CssClass="btn btn-primary" ID="BtnRoleAdd" runat="server" Text="Role Add" OnClick="BtnRoleAdd_Click" />
    <asp:Button CssClass="btn btn-warning" ID="BtnRoleUpdate" runat="server" Text="Role Update" OnClick="BtnRoleUpdate_Click" />
    <asp:Button CssClass="btn btn-danger" ID="BtnRoleDelete" runat="server" Text="Role Delete" OnClick="BtnRoleDelete_Click" />
    <br />
    <asp:Label ID="ErrorMessage" runat="server" ForeColor="Red" Text=""></asp:Label>
</asp:Content>
