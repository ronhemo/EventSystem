<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EventView.aspx.cs" Inherits="WebSite.EventView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="div" runat="server">
        <h1>Event View</h1>
        event id: <asp:Label ID="lblEventId" runat="server" Text="Label"></asp:Label><br />
        event date: <asp:Label ID="lblEventDate" runat="server" Text="Label"></asp:Label><br />
        description: <asp:Label ID="lblEventDescription" runat="server" Text="Label"></asp:Label><br />
        group: <asp:Label ID="lblEventGroup" runat="server" Text="Label"></asp:Label><br />
        creator user: <asp:Label ID="lblEventUser" runat="server" Text="Label"></asp:Label><br />
    </div>
</asp:Content>
