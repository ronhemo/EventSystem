<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Events.aspx.cs" Inherits="WebSite.Events" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Event List</h1>
    groups: <asp:DropDownList CssClass="btn btn-outline-secondary" ID="GroupDropDownList" AutoPostBack="true" runat="server" OnSelectedIndexChanged="GroupDropDownList_SelectedIndexChanged"></asp:DropDownList><br />
    <hr />
    <a class="btn btn-secondary" href="EventAddUpdate.aspx" >Add Event</a>
    <hr />
    <asp:Repeater ID="EventRepeater" runat="server">
        <ItemTemplate>
            <div class="card" style="width: 16rem; padding-bottom:5px; border:solid 4px <%#((System.Collections.Generic.Dictionary<string, string>)Container.DataItem)["groupcolor"]%>;">
                <div class="card-body">
                <h5 class="card-title">Event: <%#((System.Collections.Generic.Dictionary<string, string>)Container.DataItem)["description"]%></h5>
                Date: <%#((System.Collections.Generic.Dictionary<string, string>)Container.DataItem)["eventdate"]%><br /> 
                <a class="btn btn-success" href="EventView.aspx?eventid=<%#((System.Collections.Generic.Dictionary<string, string>)Container.DataItem)["eventid"]%>">view</a><br />
                <a class="btn btn-warning" href="EventAddUpdate.aspx?eventid=<%#((System.Collections.Generic.Dictionary<string, string>)Container.DataItem)["eventid"]%>">Update</a><br />
                </div>
            </div>
        </ItemTemplate>
        <SeparatorTemplate>
            <br />
        </SeparatorTemplate>
    </asp:Repeater>

</asp:Content>
