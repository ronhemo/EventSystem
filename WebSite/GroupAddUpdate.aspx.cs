using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebSite
{
    public partial class GroupAddUpdate : System.Web.UI.Page
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
                    if (!IsPostBack)
                    {
                        MasterGDropDownList.DataSource = ws.GroupList();
                        MasterGDropDownList.DataTextField = "groupname";
                        MasterGDropDownList.DataValueField = "groupid";
                        MasterGDropDownList.DataBind();
                        MasterGDropDownList.Items.Insert(0, new ListItem("none", "0"));


                        try
                        {
                            int groupid = int.Parse(Request.QueryString["groupid"]);
                            MyWs.Group g = ws.GroupGet(groupid);
                            lblGroupId.Text = groupid.ToString();
                            txtGroupName.Text = g.GroupName;
                            MasterGDropDownList.SelectedValue = g.MasterG.ToString();
                            inputGroupColor.Value = g.GroupColor;
                            BtnGroupAdd.Visible = false;
                            header.Text = "Group Update";
                        }
                        catch
                        {
                            BtnGroupUpdate.Visible = false;
                            BtnGroupDelete.Visible = false;
                            header.Text = "Group Add";

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

        protected void BtnGroupAdd_Click(object sender, EventArgs e)
        {
            MyWs.Group g = new MyWs.Group();
            char[] charsToTrim = { '*', ' ', '\'' };
            g.GroupName = txtGroupName.Text.Trim(charsToTrim);
            g.MasterG = int.Parse(MasterGDropDownList.SelectedValue);
            g.GroupColor = inputGroupColor.Value;
            if(g.GroupName.Length > 0)
            {
                int x = ws.GroupAdd(g);
                if (x != -1)
                    Response.Redirect("GroupMng.aspx");
                else
                {
                    ErrorMessage.Text = "something went wrong :(";
                }
            }
            else
            {
                ErrorMessage.Text = "group name is empty!";
            }

        }

        protected void BtnGroupUpdate_Click(object sender, EventArgs e)
        {
            MyWs.Group g = new MyWs.Group();
            g.GroupId = int.Parse(lblGroupId.Text);
            char[] charsToTrim = { '*', ' ', '\'' };
            g.GroupName = txtGroupName.Text.Trim(charsToTrim);
            g.MasterG = int.Parse(MasterGDropDownList.SelectedValue);
            g.GroupColor = inputGroupColor.Value;
            if (g.GroupName.Length > 0)
            {
                int x = ws.GroupUpdate(g);
                if (x != -1)
                    Response.Redirect("GroupMng.aspx");
                else
                {
                    ErrorMessage.Text = "something went wrong :(";
                }
            }
            else
            {
                ErrorMessage.Text = "group name is empty!";
            }
        }

        protected void BtnGroupDelete_Click(object sender, EventArgs e)
        {
            MyWs.Group g = new MyWs.Group();
            g.GroupId = int.Parse(lblGroupId.Text);
            int x = ws.GroupDelete(g);
            if (x != -1)
                Response.Redirect("GroupMng.aspx");
            else
            {
                ErrorMessage.Text = "something went wrong :(";
            }
        }
    }
}