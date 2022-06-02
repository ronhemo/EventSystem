using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebSite
{
    public partial class EventView : System.Web.UI.Page
    {
        MyWs.WebService ws;
        protected void Page_Load(object sender, EventArgs e)
        {
            ws = new MyWs.WebService();
            if (Session["myuser"] != null)
            {
                MyWs.MyUser u = (MyWs.MyUser)Session["myuser"];
                int eventid = 1;

                try
                {
                    eventid = int.Parse(Request.QueryString["eventid"]);
                }
                catch
                {
                }
                MyWs.MyEvent ev = ws.EventGet(eventid);
                lblEventId.Text = ev.EventId.ToString();
                lblEventDate.Text = ev.EventDate.ToString();
                lblEventDescription.Text = ev.Description;
                MyWs.Group g = ws.GroupGet(ev.GroupId);
                lblEventGroup.Text = g.GroupName;
                u = ws.UserGet(ev.UserId);
                lblEventUser.Text = u.FName + " " + u.LName;
            }
            else
            {
                Response.Redirect("Default.aspx");
            }

        }
    
    }
}