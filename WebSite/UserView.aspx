<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserView.aspx.cs" Inherits="WebSite.UserView1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>User View</h1>
    user id: <asp:Label ID="lblUserId" runat="server" Text="Label"></asp:Label><br />
    first name: <asp:Label ID="lblUserFName" runat="server" Text="Label"></asp:Label><br />
    last name: <asp:Label ID="lblUserLName" runat="server" Text="Label"></asp:Label><br />
    phone: <asp:Label ID="lblUserPhone" runat="server" Text="Label"></asp:Label><br />
    email: <asp:Label ID="lblUserEmail" runat="server" Text="Label"></asp:Label><br />
    password: <asp:Label ID="lblUserPassword" runat="server" Text="Label"></asp:Label><br />
    role: <asp:Label ID="lblUserRole" runat="server" Text="Label"></asp:Label>

    <div id="UserView" runat="server">
        <h1>User Group List</h1>
        <hr />
        <a runat="server" class="btn btn-primary" id="linkToAddGroupToUser" href="#">שייך קבוצה לילד</a><br />
        <hr />
        <asp:Repeater ID="UserGroupRepeater" runat="server">
            <ItemTemplate>
                        <div class="card" style="width: 16rem; padding-bottom:5px;">
                            <div class="card-body">
                            group id: <%# Eval("group.groupname") %><br />
                            <a class="btn btn-success" href="UserGroupView.aspx?usergroupid=<%# Eval("usergroupid") %>">View</a><br />
                            <a class="btn btn-warning" href="UserGroupAddUpdate.aspx?usergroupid=<%# Eval("usergroupid") %>">Delete/Update</a><br />
                            </div>
                        </div>
            </ItemTemplate>
            <SeparatorTemplate>
                <br />
            </SeparatorTemplate>
        </asp:Repeater>

        <h1>Events Of User</h1>
        <a class="btn btn-secondary" href="EventAddUpdate.aspx">Add Event</a>
            <center>
            <table>
                <tr>
                    <td>
                        <div style="display: flex; justify-content: space-around;" runat="server">
                            <asp:Button ID="NextWeek" runat="server" CssClass="btn btn-outline-secondary" Text="next" OnClick="GetNextWeek"/>
                            <asp:DropDownList ID="MonthDropDownList" CssClass="btn btn-outline-secondary" AutoPostBack="true" runat="server" OnSelectedIndexChanged="MonthDropDownList_SelectedIndexChanged"></asp:DropDownList>
                            <asp:Button ID="PreviusWeek" runat="server" CssClass="btn btn-outline-secondary" Text="prev" OnClick="GetPrevWeek" />
                        </div>
                        <table  id="table" class="table table-bordered">      
                            <thead>
                                <tr id="row0">
                                    <th scope="col"></th>

                                    <th id="row0col1" scope="col"></th>

                                    <th id="row0col2" scope="col"></th>

                                    <th id="row0col3" scope="col"></th>

                                    <th id="row0col4" scope="col"></th>

                                    <th id="row0col5" scope="col"></th>
                            
                                    <th id="row0col6" scope="col"></th>

                                    <th id="row0col7" scope="col"></th>

                                </tr>
                            </thead>

                            <tr id="row1">
                                <th id="row1col0" scope="row">6:00</th>
                                <th id="row1col1"></th>
                                <th id="row1col2"></th>
                                <th id="row1col3"></th>
                                <th id="row1col4"></th>
                                <th id="row1col5"></th>
                                <th id="row1col6"></th>
                                <th id="row1col"></th>
                            </tr>



                            <tr id="row2">
                                <th id="row2col0" scope="row">7:00</th>
                                <th id="row2col1"></th>
                                <th id="row2col2"></th>
                                <th id="row2col3"></th>
                                <th id="row2col4"></th>
                                <th id="row2col5"></th>
                                <th id="row2col6"></th>
                                <th id="row2col7"></th>
                            </tr>



                            <tr id="row3">
                                <th id="row3col0" scope="row">8:00</th>
                                <th id="row3col1"></th>
                                <th id="row3col2"></th>
                                <th id="row3col3"></th>
                                <th id="row3col4"></th>
                                <th id="row3col5"></th>
                                <th id="row3col6"></th>
                                <th id="row3col7"></th>
                            </tr>



                            <tr id="row4">
                                <th id="row4col0" scope="row">9:00</th>
                                <th id="row4col1"></th>
                                <th id="row4col2"></th>
                                <th id="row4col3"></th>
                                <th id="row4col4"></th>
                                <th id="row4col5"></th>
                                <th id="row4col6"></th>
                                <th id="row4col7"></th>
                            </tr>



                            <tr id="row5">
                                <th id="row5col0" scope="row">10:00</th>
                                <th id="row5col1"></th>
                                <th id="row5col2"></th>
                                <th id="row5col3"></th>
                                <th id="row5col4"></th>
                                <th id="row5col5"></th>
                                <th id="row5col6"></th>
                                <th id="row5col7"></th>
                            </tr>



                            <tr id="row6">
                                <th id="row6col0" scope="row">11:00</th>
                                <th id="row6col1"></th>
                                <th id="row6col2"></th>
                                <th id="row6col3"></th>
                                <th id="row6col4"></th>
                                <th id="row6col5"></th>
                                <th id="row6col6"></th>
                                <th id="row6col7"></th>
                            </tr>



                            <tr id="row7">
                                <th id="row7col0" scope="row">12:00</th>
                                <th id="row7col1"></th>
                                <th id="row7col2"></th>
                                <th id="row7col3"></th>
                                <th id="row7col4"></th>
                                <th id="row7col5"></th>
                                <th id="row7col6"></th>
                                <th id="row7col7"></th>
                            </tr>



                            <tr id="row8">
                                <th id="row8col0" scope="row">13:00</th>
                                <th id="row8col1"></th>
                                <th id="row8col2"></th>
                                <th id="row8col3"></th>
                                <th id="row8col4"></th>
                                <th id="row8col5"></th>
                                <th id="row8col6"></th>
                                <th id="row8col7"></th>
                            </tr>



                            <tr id="row9">
                                <th id="row9col0" scope="row">14:00</th>
                                <th id="row9col1"></th>
                                <th id="row9col2"></th>
                                <th id="row9col3"></th>
                                <th id="row9col4"></th>
                                <th id="row9col5"></th>
                                <th id="row9col6"></th>
                                <th id="row9col7"></th>
                            </tr>



                            <tr id="row10">
                                <th id="row10col0" scope="row">15:00</th>
                                <th id="row10col1"></th>
                                <th id="row10col2"></th>
                                <th id="row10col3"></th>
                                <th id="row10col4"></th>
                                <th id="row10col5"></th>
                                <th id="row10col6"></th>
                                <th id="row10col7"></th>
                            </tr>



                            <tr id="row11">
                                <th id="row11col0" scope="row">16:00</th>
                                <th id="row11col1"></th>
                                <th id="row11col2"></th>
                                <th id="row11col3"></th>
                                <th id="row11col4"></th>
                                <th id="row11col5"></th>
                                <th id="row11col6"></th>
                                <th id="row11col7"></th>
                            </tr>



                            <tr id="row12">
                                <th id="row12col0" scope="row">17:00</th>
                                <th id="row12col1"></th>
                                <th id="row12col2"></th>
                                <th id="row12col3"></th>
                                <th id="row12col4"></th>
                                <th id="row12col5"></th>
                                <th id="row12col6"></th>
                                <th id="row12col7"></th>
                            </tr>

                        </table>
                    </td>
                </tr>
            </table>
        </center>
    </div>

</asp:Content>
