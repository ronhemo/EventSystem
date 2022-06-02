<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EventAddUpdate.aspx.cs" Inherits="WebSite.EventAddUpdate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1><asp:Label ID="header" runat="server" Text="header"></asp:Label></h1>
   
        
    <asp:Label ID="lblEventId" runat="server" Visible="false"></asp:Label><br />
    event date: <asp:TextBox ID="txtEventDate" runat="server" Textmode = "Date" required></asp:TextBox><br />
    event hour: <asp:TextBox ID="txtEventHour" runat="server" TextMode="Time" required></asp:TextBox><br />
    description: <asp:TextBox ID="txtEventDescription" runat="server"></asp:TextBox><br />

    group: <asp:DropDownList ID="GroupDropDownList" runat="server"></asp:DropDownList><br />
    user: <asp:Label ID="CreatorName" runat="server" Text="Label"></asp:Label><br />
    <asp:Label ID="CreatorId" runat="server" Text="Label" Visible="false"></asp:Label>
    <asp:Button CssClass="btn btn-primary" ID="BtnEventAdd" runat="server" Text="Event Add" OnClick="BtnEventAdd_Click" />
    <asp:Button CssClass="btn btn-warning" ID="BtnEventUpdate" runat="server" Text="Event Update" OnClick="BtnEventUpdate_Click" />
    <asp:Button CssClass="btn btn-danger" ID="BtnEventDelete" runat="server" Text="Event Delete" OnClick="BtnEventDelete_Click" />
    <br />
    <asp:Label ID="ErrorMessage" runat="server" ForeColor="Red" Text=""></asp:Label>

</asp:Content>
