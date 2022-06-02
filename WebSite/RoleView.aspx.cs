using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebSite
{
    public partial class RoleView : System.Web.UI.Page
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
                if (roleName == "מנהל מערכת")
                {
                    int roleid = 1;
                    ws = new MyWs.WebService();
                    try
                    {
                        roleid = int.Parse(Request.QueryString["roleid"]);
                    }
                    catch
                    {
                    }
                    r = ws.RoleGet(roleid);
                    lblRoleId.Text = r.RoleId.ToString();
                    lblRoleName.Text = r.RoleName.ToString();
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