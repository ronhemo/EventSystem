<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GroupAddUpdate.aspx.cs" Inherits="WebSite.GroupAddUpdate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <h1><asp:Label ID="header" runat="server" Text="header"></asp:Label></h1>
   
        
    <asp:Label ID="lblGroupId" runat="server" Visible="false"></asp:Label><br />
    group name: <asp:TextBox ID="txtGroupName" runat="server"></asp:TextBox><br />
    parent: <asp:DropDownList ID="MasterGDropDownList" runat="server"></asp:DropDownList><br />
    color: <input ID="inputGroupColor" runat="server" type="color"/><br />
    <asp:Button CssClass="btn btn-primary" ID="BtnGroupAdd" runat="server" Text="Group Add" OnClick="BtnGroupAdd_Click" />
    <asp:Button CssClass="btn btn-warning" ID="BtnGroupUpdate" runat="server" Text="Group Update" OnClick="BtnGroupUpdate_Click" />
    <asp:Button CssClass="btn btn-danger" ID="BtnGroupDelete" runat="server" Text="Group Delete" OnClick="BtnGroupDelete_Click" />
    <br />
    <asp:Label ID="ErrorMessage" runat="server" ForeColor="Red" Text=""></asp:Label>

</asp:Content>
