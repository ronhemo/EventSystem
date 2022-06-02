using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace WebSite
{
    public partial class EventAddUpdate : System.Web.UI.Page
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
                        GroupDropDownList.DataSource = ws.GroupList();
                        GroupDropDownList.DataTextField = "groupname";
                        GroupDropDownList.DataValueField = "groupid";
                        GroupDropDownList.DataBind();
                        try
                        {
                            int eventid = int.Parse(Request.QueryString["eventid"]);
                            MyWs.MyEvent ev = ws.EventGet(eventid);
                            lblEventId.Text = eventid.ToString();
                            txtEventDate.Text = ev.EventDate.ToString("yyyy-MM-dd");
                            txtEventHour.Text = ev.EventDate.ToString("HH:mm");
                            txtEventDescription.Text = ev.Description;
                            GroupDropDownList.SelectedValue = ev.GroupId.ToString();
                            CreatorId.Text = u.UserId.ToString();
                            CreatorName.Text = u.FName;
                            BtnEventAdd.Visible = false;
                            header.Text = "Event Update";
                        }
                        catch
                        {
                            BtnEventUpdate.Visible = false;
                            BtnEventDelete.Visible = false;

                            header.Text = "Event Add";
                        }
                        try
                        {
                            int userid = int.Parse(Request.QueryString["userid"]);
                            CreatorId.Text = userid.ToString();
                            CreatorName.Text = ws.UserGet(userid).FName;
                            BtnEventUpdate.Visible = false;
                            BtnEventDelete.Visible = false;
                            header.Text = "Event Add";
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

        protected void BtnEventAdd_Click(object sender, EventArgs e)
        {
            MyWs.MyEvent ev = new MyWs.MyEvent();
            DateTime d = DateTime.Parse(txtEventDate.Text);
            DateTime h = DateTime.Parse(txtEventHour.Text);
            DateTime nd = new DateTime(d.Year, d.Month, d.Day, h.Hour, h.Minute, 0);
            ev.EventDate = nd;
            char[] charsToTrim = { '*', ' ', '\'' };
            ev.Description = txtEventDescription.Text.Trim(charsToTrim);
            ev.GroupId = int.Parse(GroupDropDownList.SelectedValue);
            ev.UserId = int.Parse(CreatorId.Text);
            if(ev.Description.Length > 0)
            {
                int x = ws.EventAdd(ev);
                if (x != -1)
                    Response.Redirect("Calander.aspx");
                else
                {
                    ErrorMessage.Text = "something went wrong";
                }
            }
            else
            {
                ErrorMessage.Text = "description is empty!";
            }


        }

        protected void BtnEventUpdate_Click(object sender, EventArgs e)
        {
            MyWs.MyEvent ev = new MyWs.MyEvent();
            ev.EventId = int.Parse(lblEventId.Text);
            DateTime d = DateTime.Parse(txtEventDate.Text);
            DateTime h = DateTime.Parse(txtEventHour.Text);
            DateTime nd = new DateTime(d.Year, d.Month, d.Day, h.Hour, h.Minute, 0);
            ev.EventDate = nd;
            char[] charsToTrim = { '*', ' ', '\'' };
            ev.Description = txtEventDescription.Text.Trim(charsToTrim);
            ev.GroupId = int.Parse(GroupDropDownList.SelectedValue);
            ev.UserId = int.Parse(CreatorId.Text);
            if (ev.Description.Length > 0)
            {
                int x = ws.EventUpdate(ev);
                if (x != -1)
                    Response.Redirect("Calander.aspx");
                else
                {
                    ErrorMessage.Text = "something went wrong";
                }
            }
            else
            {
                ErrorMessage.Text = "description is empty!";
            }
        }

        protected void BtnEventDelete_Click(object sender, EventArgs e)
        {
            MyWs.MyEvent ev = new MyWs.MyEvent();
            ev.EventId = int.Parse(lblEventId.Text);
            int x = ws.EventDelete(ev);
            if (x != -1)
                Response.Redirect("Calander.aspx");
            else
            {
                ErrorMessage.Text = "couldnt delete";
            }
        }
    }
}