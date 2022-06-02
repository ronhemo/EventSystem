<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GroupMng.aspx.cs" Inherits="WebSite.GroupMng" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <center>
        <a target="_blank" class="btn btn-secondary" href="GroupAddUpdate.aspx" >Add Group</a>
    </center>
    <hr />
    <div id="GroupInfo" runat="server" visible =" false">
            <h1>Group View</h1>
        group id: <asp:Label ID="lblGroupId" runat="server" Text="Label"></asp:Label><br />
        group name: <asp:Label ID="lblGroupName" runat="server" Text="Label"></asp:Label><br />
        group master: <asp:Label ID="lblMasterG" runat="server" Text="Label"></asp:Label><br />
        group color: <asp:Label ID="color" runat="server" Text=""></asp:Label><br />
        <asp:HyperLink ID="LinkStudentToGroup" CssClass="btn btn-primary" Visible="false" runat="server">שייך ילד לקבוצה</asp:HyperLink>

    </div>
    <div class="row">
        <center>
            <h1 id="GroupTitle" runat="server"></h1>
            <asp:Repeater ID="GroupRepeater" runat="server">
                <ItemTemplate>
                    <div class="card" style="width: 16rem; padding-bottom:5px;">
                        <div class="card-body">
                        <h5 class="card-title">group: <%# Eval("groupname") %></h5>
                        <a class="btn btn-success" href="GroupMng.aspx?masterG=<%# Eval("groupid") %>">View</a><br />
                        <a class="btn btn-warning" href="GroupAddUpdate.aspx?groupid=<%# Eval("groupid") %>">Update</a><br />
                        </div>
                    </div>
                </ItemTemplate>
                <SeparatorTemplate>
                    <br />
                </SeparatorTemplate>
            </asp:Repeater>
        </center>
    </div>

</asp:Content>
