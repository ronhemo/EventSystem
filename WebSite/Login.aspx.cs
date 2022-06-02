using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebSite
{
    public partial class Login1 : System.Web.UI.Page
    {
        MyWs.WebService ws;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void User_Login(object sender, EventArgs e)
        {
            ws = new MyWs.WebService();
            MyWs.MyUser u = ws.Login(textBoxEmail.Text, textBoxPass.Text);
            if (u != null)
            {
                Session["myuser"] = u;
                Response.Redirect("Default.aspx");

            }
            else
            {
                ErrorMsg.Text = "email or password incorect";
            }
        }
    }
}