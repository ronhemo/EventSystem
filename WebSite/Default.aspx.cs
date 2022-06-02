using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebSite
{
    public partial class Default : System.Web.UI.Page
    {
        MyWs.WebService ws;
        protected void Page_Load(object sender, EventArgs e)
        {
            ws = new MyWs.WebService();
            if (Session["myuser"] != null)
            {
                MyWs.MyUser u = (MyWs.MyUser)Session["myuser"];
                PageTitle.InnerText = "!!למערכת אירועים " + u.FName + " " + u.LName + " ברוך הבא";
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }
    }
}