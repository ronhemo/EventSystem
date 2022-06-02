using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebSite
{
    public partial class Site : System.Web.UI.MasterPage
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
                lblGreetUser.Text = "Welcome " + roleName + ", " + u.FName;
                if (roleName == "מנהל מערכת")
                {
                    AdminView.Visible = true;
                }
                else if (roleName == "מנהל מוסד")
                {
                    ManagerView.Visible = true;
                    
                }
                else if (roleName == "רכז")
                {
                    RakazView.Visible = true;
                }
                else if (roleName == "מורה")
                {
                    TeacherView.Visible = true;
                }
                else if (roleName == "תלמיד")
                {
                    StudentView.Visible = true;
                }
                else
                {
                    Response.Redirect("Default.aspx");
                }
            }
            else
            {
                Response.Redirect("Login.aspx");
            }

        }
            
        protected void Log_Out(object sender, EventArgs e)
            {
                Session.Abandon();
                Session.Clear();
                Response.Redirect("Login.aspx");
            }
    }
}