<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GroupView.aspx.cs" Inherits="WebSite.GroupView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Group View</h1>
    group id: <asp:Label ID="lblGroupId" runat="server" Text="Label"></asp:Label><br />
    group name: <asp:Label ID="lblGroupName" runat="server" Text="Label"></asp:Label><br />
    group master: <asp:Label ID="lblMasterG" runat="server" Text="Label"></asp:Label><br />
    group color: <input ID="inputGroupColor" runat="server" type="color"/><br />


    <h1>Groups Events</h1>
    <asp:Repeater ID="GroupEventRepeater" runat="server">
        <ItemTemplate>
            <div class="card" style="border:solid 4px <%#((System.Collections.Generic.Dictionary<string, string>)Container.DataItem)["groupcolor"]%>">
                event description is <%#((System.Collections.Generic.Dictionary<string, string>)Container.DataItem)["description"]%> at <%#((System.Collections.Generic.Dictionary<string, string>)Container.DataItem)["eventdate"]%><br /> 
                <a href="EventView.aspx?eventid=<%#((System.Collections.Generic.Dictionary<string, string>)Container.DataItem)["eventid"]%>">view</a><br />
                <a href="EventAddUpdate.aspx?eventid=<%#((System.Collections.Generic.Dictionary<string, string>)Container.DataItem)["eventid"]%>">Update/Delete</a><br />
            </div>
        </ItemTemplate>
        <SeparatorTemplate>
            <br />
        </SeparatorTemplate>
    </asp:Repeater>
</asp:Content>
