using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebSite
{
    public partial class GroupMng : System.Web.UI.Page
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
                    try
                    {
                        int masterG = int.Parse(Request.QueryString["masterG"]);
                        MyWs.Group[] childs = ws.GroupChildOfGroup(ws.GroupGet(masterG));
                        GroupRepeater.DataSource = childs;
                        GroupRepeater.DataBind();
                        GroupTitle.InnerText = ws.GroupGet(masterG).GroupName;
                        MyWs.Group g = ws.GroupGet(masterG);
                        lblGroupId.Text = g.GroupId.ToString();
                        lblGroupName.Text = g.GroupName.ToString();
                        color.Text = g.GroupColor;
                        color.BackColor = (System.Drawing.Color)new System.Drawing.ColorConverter().ConvertFromString(g.GroupColor);
                        MyWs.Group mg = ws.GroupGet(g.MasterG);
                        if(ws.GroupChildOfGroup(g).Length == 0)
                        {
                            LinkStudentToGroup.Visible = true;
                            LinkStudentToGroup.NavigateUrl = string.Format("UserGroupAddUpdate.aspx?groupid={0}", g.GroupId);
                        }
                        if (mg.GroupName == null)
                        {
                            lblMasterG.Text = "none";
                        }
                        else
                        {
                            lblMasterG.Text = mg.GroupName.ToString();
                        }
                        GroupInfo.Visible = true;
                    }
                    catch
                    {
                        MyWs.Group[] masterGroups = ws.MasterGroupList();
                        GroupRepeater.DataSource = masterGroups;
                        GroupRepeater.DataBind();
                        GroupTitle.InnerText = "Master Groups";
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
    }
}