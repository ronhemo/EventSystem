using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebSite
{
    public partial class RoleAddUpdate : System.Web.UI.Page
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
                    if (!IsPostBack)
                    {
                        try
                        {
                            int roleid = int.Parse(Request.QueryString["roleid"]);
                            r = ws.RoleGet(roleid);
                            lblRoleId.Text = roleid.ToString();
                            txtRoleName.Text = r.RoleName;

                            BtnRoleAdd.Visible = false;
                            header.Text = "Role Update";
                        }
                        catch
                        {
                            BtnRoleUpdate.Visible = false;
                            BtnRoleDelete.Visible = false;

                            header.Text = "Role Add";

                        }
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

        protected void BtnRoleAdd_Click(object sender, EventArgs e)
        {
            MyWs.Role r = new MyWs.Role();
            char[] charsToTrim = { '*', ' ', '\'' };
            r.RoleName = txtRoleName.Text.Trim(charsToTrim);
            if (r.RoleName.Length > 0)
            {
                int x = ws.RoleAdd(r);
                if (x != -1)
                    Response.Redirect("RoleMng.aspx");
                else
                {
                    ErrorMessage.Text = "something went wrong :(";
                }
            }
            else
            {
                ErrorMessage.Text = "role name is empty!";
            }
        }

        protected void BtnRoleUpdate_Click(object sender, EventArgs e)
        {
            MyWs.Role r = new MyWs.Role();
            r.RoleId = int.Parse(lblRoleId.Text);
            char[] charsToTrim = { '*', ' ', '\'' };
            r.RoleName = txtRoleName.Text.Trim(charsToTrim);
            if (r.RoleName.Length > 0)
            {
                int x = ws.RoleUpdate(r);
                if (x != -1)
                    Response.Redirect("RoleMng.aspx");
                else
                {
                    ErrorMessage.Text = "something went wrong :(";
                }
            }
            else
            {
                ErrorMessage.Text = "role name is empty!";
            }
        }

        protected void BtnRoleDelete_Click(object sender, EventArgs e)
        {
            MyWs.Role r = new MyWs.Role();
            r.RoleId = int.Parse(lblRoleId.Text);
            int x = ws.RoleDelete(r);
            if (x != -1)
                Response.Redirect("RoleMng.aspx");
            else
            {
                ErrorMessage.Text = "something went wrong :(";
            }
        }
    }
}