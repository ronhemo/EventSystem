using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebSite
{
    public partial class UserGroupAddUpdate : System.Web.UI.Page
    {
        MyWs.WebService ws;
        public static List<MyWs.Group> GetBaseGroups(List<MyWs.Group> masterGroups, List<MyWs.Group> baseGroups)
        {
            MyWs.WebService ws = new MyWs.WebService();
            foreach (var item in masterGroups)
            {
                if(ws.GroupChildOfGroup(item).Length == 0)
                {
                    baseGroups.Add(item);
                }
            }
            foreach (var group in ws.GroupChildOfGroupList(masterGroups.ToArray()))
            {
                masterGroups.Clear();
                masterGroups.Add(group);
                GetBaseGroups(masterGroups, baseGroups);
            }
            return baseGroups;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            ws = new MyWs.WebService();
            if (Session["myuser"] != null)
            {
                MyWs.MyUser u = (MyWs.MyUser)Session["myuser"];
                MyWs.Role r = ws.RoleGet(u.RoleId);
                string roleName = r.RoleName;
                if (roleName != "מורה" && roleName != "תלמיד")
                {
                    if (!IsPostBack)
                    {
                        MyWs.Group[] masterGroups = ws.MasterGroupList();
                        List <MyWs.Group> baseGroups = new List<MyWs.Group>();


                        GroupDropDownList.DataSource = GetBaseGroups(masterGroups.ToList(), baseGroups);
                        GroupDropDownList.DataTextField = "groupname";
                        GroupDropDownList.DataValueField = "groupid";
                        GroupDropDownList.DataBind();
                        UserDropDownList.DataSource = ws.UserStudentList();
                        UserDropDownList.DataTextField = "fname";
                        UserDropDownList.DataValueField = "userid";
                        UserDropDownList.DataBind();
                        header.Text = "User Group Add";
                        BtnUserGroupDelete.Visible = false;
                        BtnUserGroupUpdate.Visible = false;
                        try
                        {
                            int userGroupId = int.Parse(Request.QueryString["usergroupid"]);
                            MyWs.UserGroup uG = ws.UserGroupGet(userGroupId);
                            lblUserGroupId.Text = userGroupId.ToString();
                            header.Text = "User Group Update/Delete";
                            UserDropDownList.SelectedValue = uG.UserId.ToString();
                            GroupDropDownList.SelectedValue = uG.GroupId.ToString();
                            GroupUserName.InnerText = string.Format("user: {0}", UserDropDownList.SelectedItem.Text);
                            BtnUserGroupAdd.Visible = false;
                            BtnUserGroupDelete.Visible = true;
                            BtnUserGroupUpdate.Visible = true;
                        }
                        catch { }
                        try
                        {
                            int userId = int.Parse(Request.QueryString["userid"]);
                            u = ws.UserGet(userId);
                            header.Text = "User Group Add";
                            UserDropDownList.SelectedValue = u.UserId.ToString();
                            GroupUserName.InnerText = string.Format("user: {0}", UserDropDownList.SelectedItem.Text);
                            GroupUserName.Visible = true;
                            UserDrop.Visible = false;
                        }
                        catch { }
                        try
                        {
                            int groupId = int.Parse(Request.QueryString["groupid"]);
                            MyWs.Group g = ws.GroupGet(groupId);
                            header.Text = "Add User to Group";
                            GroupDropDownList.SelectedValue = g.GroupId.ToString();
                            GroupUserName.InnerText = string.Format("group: {0}", GroupDropDownList.SelectedItem.Text);
                            GroupUserName.Visible = true;
                            GroupDrop.Visible = false;
                        }
                        catch { }
                    }

                }
                else
                {
                    Response.Redirect("Default.aspx");
                }

            }
            else
            {
                Response.Redirect("Default.aspx");
            }
        }

        protected void BtnUserGroupAdd_Click(object sender, EventArgs e)
        {
            bool exist = false;
            MyWs.UserGroup ug = new MyWs.UserGroup();
            ug.GroupId = int.Parse(GroupDropDownList.SelectedValue);
            ug.UserId = int.Parse(UserDropDownList.SelectedValue);
            foreach (var item in ws.GroupListOfUser(ws.UserGet(ug.UserId)))
            {
                if(item.GroupId == ug.GroupId)
                {
                    exist = true;
                }
            }
            if (exist)
            {
                ErrorMessage.Text = "user already assigned to this group";
            }
            else
            {
                int x = ws.UserGroupAdd(ug);
                if (x != -1)
                    Response.Redirect("UserMng.aspx");
                else
                {
                    ErrorMessage.Text = "something went wrong :(";
                }
            }
        }

        protected void BtnUserGroupUpdate_Click(object sender, EventArgs e)
        {
            MyWs.UserGroup ug = new MyWs.UserGroup();
            bool exist = false;
            ug.UserGroupId = int.Parse(lblUserGroupId.Text);
            ug.GroupId = int.Parse(GroupDropDownList.SelectedValue);
            ug.UserId = int.Parse(UserDropDownList.SelectedValue);
            foreach (var item in ws.GroupListOfUser(ws.UserGet(ug.UserId)))
            {
                if (item.GroupId == ug.GroupId)
                {
                    exist = true;
                }
            }
            if (exist)
            {
                ErrorMessage.Text = "user already assigned to this group";
            }
            else
            {
                int x = ws.UserGroupUpdate(ug);
                if (x != -1)
                    Response.Redirect("UserMng.aspx");
                else
                {
                    ErrorMessage.Text = "something went wrong :(";
                }
            }

        }

        protected void BtnUserGroupDelete_Click(object sender, EventArgs e)
        {
            MyWs.UserGroup ug = new MyWs.UserGroup();
            ug.UserGroupId = int.Parse(lblUserGroupId.Text);
            int x = ws.UserGroupDelete(ug);
            if (x != -1)
                Response.Redirect("UserMng.aspx");
            else
            {
                ErrorMessage.Text = "something went wrong :(";
            }
        }
    }
}