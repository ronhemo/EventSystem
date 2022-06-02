<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserAddUpdate.aspx.cs" Inherits="WebSite.UserAddUpdate1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1><asp:Label ID="header" runat="server" Text="header"></asp:Label></h1>
   
        
    <asp:Label ID="lblUserId" runat="server" Visible="false"></asp:Label><br />
    first name: <asp:TextBox ID="txtUserFName" runat="server"></asp:TextBox><br />
    last name: <asp:TextBox ID="txtUserLName" runat="server"></asp:TextBox><br />
    phone: <asp:TextBox ID="txtUserPhone" runat="server"></asp:TextBox><br />
    email: <asp:TextBox ID="txtUserEmail" runat="server"></asp:TextBox><br />
    password: <asp:TextBox ID="txtUserPassword" runat="server"></asp:TextBox><br />
          
    role:   <asp:DropDownList ID="RoleDropDownList" runat="server"></asp:DropDownList><br />
    <asp:Button CssClass="btn btn-primary" ID="BtnUserAdd" runat="server" Text="User Add" OnClick="BtnUserAdd_Click" />
    <asp:Button CssClass="btn btn-warning" ID="BtnUserUpdate" runat="server" Text="User Update" OnClick="BtnUserUpdate_Click" />
    <asp:Button CssClass="btn btn-danger" ID="BtnUserDelete" runat="server" Text="User Delete" OnClick="BtnUserDelete_Click" />
    <br />
    <asp:Label ID="ErrorMessage" runat="server" ForeColor="Red" Text=""></asp:Label>

</asp:Content>
