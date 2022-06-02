<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserMng.aspx.cs" Inherits="WebSite.UserMng" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>User List</h1>
    <hr />
    <a href="UserAddUpdate.aspx" class="btn btn-secondary" >Add User</a>
    <hr />
    <h1>Students</h1>
    <asp:Repeater ID="StudentRepeater" runat="server">
        <ItemTemplate>
            <div class="card" style="width: 16rem; padding-bottom:5px;">
                <div class="card-body">
                    <h5 class="card-title">User: <%# Eval("FName") %> <%# Eval("LName") %></h5>
                    <a href="UserView.aspx?userid=<%# Eval("userid") %>" class="btn btn-success">view</a>
                    <a href="UserAddUpdate.aspx?userid=<%# Eval("userid") %>" class="btn btn-warning">Update</a>
                </div>
            </div>
        </ItemTemplate>
        <SeparatorTemplate>
            <br />
        </SeparatorTemplate>
    </asp:Repeater>

    <div id="RacazNotView" runat="server">
    <hr />
        <h1>Teachers</h1>
        <asp:Repeater ID="TeacherRepeater" runat="server">
            <ItemTemplate>
                <div class="card" style="width: 16rem; padding-bottom:5px;">
                    <div class="card-body">
                        <h5 class="card-title">User: <%# Eval("FName") %> <%# Eval("LName") %></h5>
                        <a href="UserView.aspx?userid=<%# Eval("userid") %>" class="btn btn-success">view</a>
                        <a href="UserAddUpdate.aspx?userid=<%# Eval("userid") %>" class="btn btn-warning">Update</a>
                    </div>
                </div>
            </ItemTemplate>
            <SeparatorTemplate>
                <br />
            </SeparatorTemplate>
        </asp:Repeater>
        <hr />
        <h1>Racazim</h1>
        <asp:Repeater ID="RacazRepeater" runat="server">
            <ItemTemplate>
                <div class="card" style="width: 16rem; padding-bottom:5px;">
                    <div class="card-body">
                        <h5 class="card-title">User: <%# Eval("FName") %> <%# Eval("LName") %></h5>
                        <a href="UserView.aspx?userid=<%# Eval("userid") %>" class="btn btn-success">view</a>
                        <a href="UserAddUpdate.aspx?userid=<%# Eval("userid") %>" class="btn btn-warning">Update</a>
                    </div>
                </div>
            </ItemTemplate>
            <SeparatorTemplate>
                <br />
            </SeparatorTemplate>
        </asp:Repeater>
        <hr />
        <h1>School Managers</h1>
        <asp:Repeater ID="SMReapeter" runat="server">
            <ItemTemplate>
                <div class="card" style="width: 16rem; padding-bottom:5px;">
                    <div class="card-body">
                        <h5 class="card-title">User: <%# Eval("FName") %> <%# Eval("LName") %></h5>
                        <a href="UserView.aspx?userid=<%# Eval("userid") %>" class="btn btn-success">view</a>
                        <a href="UserAddUpdate.aspx?userid=<%# Eval("userid") %>" class="btn btn-warning">Update</a>
                    </div>
                </div>
            </ItemTemplate>
            <SeparatorTemplate>
                <br />
            </SeparatorTemplate>
        </asp:Repeater>

        <div id="SysManagerView" runat="server">
            <hr />
            <h1>System Managers</h1>
            <asp:Repeater ID="MRepeater" runat="server">
                <ItemTemplate>
                    <div class="card" style="width: 16rem; padding-bottom:5px;">
                        <div class="card-body">
                            <h5 class="card-title">User: <%# Eval("FName") %> <%# Eval("LName") %></h5>
                            <a href="UserView.aspx?userid=<%# Eval("userid") %>" class="btn btn-success">view</a>
                            <a href="UserAddUpdate.aspx?userid=<%# Eval("userid") %>" class="btn btn-warning">Update</a>
                        </div>
                    </div>
                </ItemTemplate>
                <SeparatorTemplate>
                    <br />
                </SeparatorTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>