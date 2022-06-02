<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserGroupAddUpdate.aspx.cs" Inherits="WebSite.UserGroupAddUpdate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1><asp:Label ID="header" runat="server" Text="header"></asp:Label></h1>
   
        
    <asp:Label ID="lblUserGroupId" runat="server" Visible="false"></asp:Label><br />
          
    <div id="GroupDrop" runat="server"> group: <asp:DropDownList ID="GroupDropDownList" runat="server"></asp:DropDownList><br /> </div>
    <div id="GroupUserName" runat="server" visible="false"></div>
    <div id="UserDrop" runat="server">user: <asp:DropDownList ID="UserDropDownList" runat="server"></asp:DropDownList><br /></div>
    <asp:Button  CssClass="btn btn-primary" ID="BtnUserGroupAdd" runat="server" Text="User Group Add" OnClick="BtnUserGroupAdd_Click" />
    <asp:Button  CssClass="btn btn-warning" ID="BtnUserGroupUpdate" runat="server" Text="User Group Update" OnClick="BtnUserGroupUpdate_Click" />
    <asp:Button  CssClass="btn btn-danger" ID="BtnUserGroupDelete" runat="server" Text="User Group Delete" OnClick="BtnUserGroupDelete_Click" />
    <br />
    <asp:Label ID="ErrorMessage" runat="server" ForeColor="Red" Text=""></asp:Label>

</asp:Content>
