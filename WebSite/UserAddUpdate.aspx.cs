using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebSite
{
    public partial class UserAddUpdate1 : System.Web.UI.Page
    {
        MyWs.WebService ws;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["myuser"] != null)
            {
                ws = new MyWs.WebService();
                if (!IsPostBack)
                {
                    MyWs.MyUser u = (MyWs.MyUser)Session["myuser"];
                    string roleName = ws.RoleGet(u.RoleId).RoleName;
                    if(roleName == "מנהל מערכת")
                    {
                        RoleDropDownList.DataSource = ws.RoleList();
                        RoleDropDownList.DataTextField = "rolename";
                        RoleDropDownList.DataValueField = "roleid";
                        RoleDropDownList.DataBind();
                    }
                    else if(roleName == "רכז" || roleName == "מנהל מוסד")
                    {
                        RoleDropDownList.DataSource = ws.RoleListNoAdmin();
                        RoleDropDownList.DataTextField = "rolename";
                        RoleDropDownList.DataValueField = "roleid";
                        RoleDropDownList.DataBind();
                    }
                    else
                    {
                        Response.Redirect("Default.aspx");
                    }

                    try
                    {
                        int userid = int.Parse(Request.QueryString["userid"]);
                        u = ws.UserGet(userid);
                        lblUserId.Text = userid.ToString();
                        txtUserFName.Text = u.FName;
                        txtUserLName.Text = u.LName;
                        txtUserPhone.Text = u.UserPhone;
                        txtUserEmail.Text = u.UserEmail;
                        txtUserPassword.Text = u.UserPass;

                        RoleDropDownList.SelectedValue = u.RoleId.ToString();
                        BtnUserAdd.Visible = false;
                        header.Text = "User Update";
                    }
                    catch
                    {
                        BtnUserUpdate.Visible = false;
                        BtnUserDelete.Visible = false;

                        header.Text = "User Add";

                    }

                }
            }
            else
            {
                Response.Redirect("Default.aspx");
            }
        }

        protected void BtnUserAdd_Click(object sender, EventArgs e)
        {
            MyWs.MyUser u = new MyWs.MyUser();
            char[] charsToTrim = { '*', ' ', '\'' };
            u.FName = txtUserFName.Text.Trim(charsToTrim);
            u.LName = txtUserLName.Text.Trim(charsToTrim);
            u.UserPhone = txtUserPhone.Text.Trim(charsToTrim);
            u.UserEmail = txtUserEmail.Text.Trim(charsToTrim);
            u.UserPass = txtUserPassword.Text.Trim(charsToTrim);
            u.RoleId = int.Parse(RoleDropDownList.SelectedValue);
            
                

            if (u.FName.Length > 0 && u.LName.Length > 0 && u.UserPhone.Length > 0 && u.UserEmail.Length > 0 && u.UserPass.Length > 0)
            {
                int x = ws.UserAdd(u);
                if (x != -1)
                    Response.Redirect("UserMng.aspx");
                else
                {
                    ErrorMessage.Text = "something went wrong :(";
                }
            }
            else
            {
                ErrorMessage.Text = "check empty areas!";
            }
        }

        protected void BtnUserUpdate_Click(object sender, EventArgs e)
        {
            MyWs.MyUser u = new MyWs.MyUser();
            u.UserId = int.Parse(lblUserId.Text);
            char[] charsToTrim = { '*', ' ', '\'' };
            u.FName = txtUserFName.Text.Trim(charsToTrim);
            u.LName = txtUserLName.Text.Trim(charsToTrim);
            u.UserPhone = txtUserPhone.Text.Trim(charsToTrim);
            u.UserEmail = txtUserEmail.Text.Trim(charsToTrim);
            u.UserPass = txtUserPassword.Text.Trim(charsToTrim);
            u.RoleId = int.Parse(RoleDropDownList.SelectedValue);



            if (u.FName.Length > 0 && u.LName.Length > 0 && u.UserPhone.Length > 0 && u.UserEmail.Length > 0 && u.UserPass.Length > 0)
            {
                int x = ws.UserUpdate(u);
                if (x != -1)
                    Response.Redirect("UserMng.aspx");
                else
                {
                    ErrorMessage.Text = "something went wrong :(";
                }
            }
            else
            {
                ErrorMessage.Text = "check empty areas!";
            }
        }

        protected void BtnUserDelete_Click(object sender, EventArgs e)
        {
            MyWs.MyUser u = new MyWs.MyUser();
            u.UserId = int.Parse(lblUserId.Text);
            int x = ws.UserDelete(u);
            if (x != -1)
                Response.Redirect("UserMng.aspx");
            else
            {
                ErrorMessage.Text = "something went wrong :(";
            }
        }
    }
}