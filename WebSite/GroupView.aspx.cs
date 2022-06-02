using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebSite
{
    public partial class GroupView : System.Web.UI.Page
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
                    int groupid = 1;

                    try
                    {
                        groupid = int.Parse(Request.QueryString["groupid"]);
                    }
                    catch
                    {
                    }
                    MyWs.Group g = ws.GroupGet(groupid);
                    lblGroupId.Text = g.GroupId.ToString();
                    lblGroupName.Text = g.GroupName.ToString();
                    MyWs.Group mg = ws.GroupGet(g.MasterG);
                    if (mg.GroupName == null)
                    {
                        lblMasterG.Text = "none";
                    }
                    else
                    {
                        lblMasterG.Text = mg.GroupName.ToString();
                    }


                    MyWs.MyEvent[] eventsOfGroup = ws.EventListOfGroupOnly(g);
                    Dictionary<string, string> dic = new Dictionary<string, string>();
                    List<Dictionary<string, string>> list = new List<Dictionary<string, string>>();
                    for (int i = 0; i < eventsOfGroup.Length; i++)
                    {
                        g = ws.GroupGet(eventsOfGroup[i].GroupId);
                        dic.Add("eventid", eventsOfGroup[i].EventId.ToString());
                        dic.Add("eventdate", eventsOfGroup[i].EventDate.ToString());
                        dic.Add("groupid", eventsOfGroup[i].GroupId.ToString());
                        dic.Add("userid", eventsOfGroup[i].UserId.ToString());
                        dic.Add("description", eventsOfGroup[i].Description);
                        dic.Add("groupcolor", g.GroupColor);
                        list.Add(dic);
                        dic = new Dictionary<string, string>();
                    }
                    GroupEventRepeater.DataSource = list;
                    GroupEventRepeater.DataBind();
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