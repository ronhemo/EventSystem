using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebSite
{
    public partial class UserGroupView : System.Web.UI.Page
    {
        MyWs.WebService ws;
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
                    int usergroupid = 1;
                    try
                    {
                        usergroupid = int.Parse(Request.QueryString["usergroupid"]);
                    }
                    catch
                    {
                    }
                    MyWs.UserGroup ug = ws.UserGroupGet(usergroupid);
                    lblUserGroupId.Text = ug.UserGroupId.ToString();
                    MyWs.Group g = ws.GroupGet(ug.GroupId);
                    lblUserGroupGroup.Text = g.GroupName;
                    u = ws.UserGet(ug.UserId);
                    lblUserGroupUser.Text = u.FName + " " + u.LName;
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

    }
}