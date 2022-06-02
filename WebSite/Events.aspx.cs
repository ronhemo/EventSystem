using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebSite
{
    public partial class Events : System.Web.UI.Page
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
                if (roleName != "תלמיד")
                {
                    if (!IsPostBack)
                    {

                        MyWs.Group[] groups = ws.GroupList();
                        GroupDropDownList.DataSource = groups;
                        GroupDropDownList.DataTextField = "groupname";
                        GroupDropDownList.DataValueField = "groupid";
                        GroupDropDownList.DataBind();
                        MyWs.MyEvent[] events = ws.EventListOfGroupOnly(ws.GroupGet(int.Parse(GroupDropDownList.SelectedValue)));
                        Dictionary<string, string> dic = new Dictionary<string, string>();
                        List<Dictionary<string, string>> list = new List<Dictionary<string, string>>();
                        for (int i = 0; i < events.Length; i++)
                        {
                            MyWs.Group g = ws.GroupGet(events[i].GroupId);
                            dic.Add("eventid", events[i].EventId.ToString());
                            dic.Add("eventdate", events[i].EventDate.ToString());
                            dic.Add("groupid", events[i].GroupId.ToString());
                            dic.Add("userid", events[i].UserId.ToString());
                            dic.Add("description", events[i].Description);
                            dic.Add("groupcolor", g.GroupColor);
                            list.Add(dic);
                            dic = new Dictionary<string, string>();
                        }
                        EventRepeater.DataSource = list;
                        EventRepeater.DataBind();
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

        protected void GroupDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ws = new MyWs.WebService();
            MyWs.MyEvent[] events = ws.EventListOfGroup(ws.GroupGet(int.Parse(GroupDropDownList.SelectedValue)));
            Dictionary<string, string> dic = new Dictionary<string, string>();
            List<Dictionary<string, string>> list = new List<Dictionary<string, string>>();
            for (int i = 0; i < events.Length; i++)
            {
                MyWs.Group g = ws.GroupGet(events[i].GroupId);
                dic.Add("eventid", events[i].EventId.ToString());
                dic.Add("eventdate", events[i].EventDate.ToString());
                dic.Add("groupid", events[i].GroupId.ToString());
                dic.Add("userid", events[i].UserId.ToString());
                dic.Add("description", events[i].Description);
                dic.Add("groupcolor", g.GroupColor);
                list.Add(dic);
                dic = new Dictionary<string, string>();
            }
            EventRepeater.DataSource = list;
            EventRepeater.DataBind();
        }
    }
}