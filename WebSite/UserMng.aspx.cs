using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebSite
{
    public partial class UserMng : System.Web.UI.Page
    {
        MyWs.WebService ws;
        protected void Page_Load(object sender, EventArgs e)
        {
            ws = new MyWs.WebService();
            if(Session["myuser"] != null)
            {
                MyWs.MyUser u = (MyWs.MyUser)Session["myuser"];
                MyWs.Role r = ws.RoleGet(u.RoleId);
                string roleName = r.RoleName;
                if (roleName == "מנהל מערכת")
                {
                    MyWs.MyUser[] users = ws.UserList();
                    List<MyWs.MyUser> students = new List<MyWs.MyUser>();
                    List<MyWs.MyUser> teachers = new List<MyWs.MyUser>();
                    List<MyWs.MyUser> racazs = new List<MyWs.MyUser>();
                    List<MyWs.MyUser> sMRs = new List<MyWs.MyUser>();
                    List<MyWs.MyUser> ms = new List<MyWs.MyUser>();
                    for (int i = 0; i < users.Length; i++)
                    {
                        string role = ws.RoleGet(users[i].RoleId).RoleName;
                        if(role == "תלמיד")
                        {
                            students.Add(users[i]);
                        }
                        else if(role == "מורה")
                        {
                            teachers.Add(users[i]);
                        }
                        else if(role == "רכז")
                        {
                            racazs.Add(users[i]);
                        }
                        else if(role == "מנהל מוסד")
                        {
                            sMRs.Add(users[i]);
                        }
                        else if(role == "מנהל מערכת")
                        {
                            ms.Add(users[i]);
                        }
                    }
                    StudentRepeater.DataSource = students;
                    StudentRepeater.DataBind();
                    TeacherRepeater.DataSource = teachers;
                    TeacherRepeater.DataBind();
                    RacazRepeater.DataSource = racazs;
                    RacazRepeater.DataBind();
                    SMReapeter.DataSource = sMRs;
                    SMReapeter.DataBind();
                    MRepeater.DataSource = ms;
                    MRepeater.DataBind();
                }
                else if(roleName == "מנהל מוסד")
                {
                    MyWs.MyUser[] users = ws.UserList();
                    List<MyWs.MyUser> students = new List<MyWs.MyUser>();
                    List<MyWs.MyUser> teachers = new List<MyWs.MyUser>();
                    List<MyWs.MyUser> racazs = new List<MyWs.MyUser>();
                    List<MyWs.MyUser> sMRs = new List<MyWs.MyUser>();
                    for (int i = 0; i < users.Length; i++)
                    {
                        string role = ws.RoleGet(users[i].RoleId).RoleName;
                        if (role == "תלמיד")
                        {
                            students.Add(users[i]);
                        }
                        else if (role == "מורה")
                        {
                            teachers.Add(users[i]);
                        }
                        else if (role == "רכז")
                        {
                            racazs.Add(users[i]);
                        }
                        else if (role == "מנהל מוסד")
                        {
                            sMRs.Add(users[i]);
                        }
                    }
                    StudentRepeater.DataSource = students;
                    StudentRepeater.DataBind();
                    TeacherRepeater.DataSource = teachers;
                    TeacherRepeater.DataBind();
                    RacazRepeater.DataSource = racazs;
                    RacazRepeater.DataBind();
                    SMReapeter.DataSource = sMRs;
                    SMReapeter.DataBind();
                    SysManagerView.Visible = false;
                    
                }
                else if (roleName == "רכז")
                {
                    MyWs.MyUser[] users = ws.UserList();
                    List<MyWs.MyUser> newUsers = new List<MyWs.MyUser>();
                    for (int i = 0; i < users.Length; i++)
                    {
                        if(ws.RoleGet(users[i].RoleId).RoleName == "תלמיד"){
                            newUsers.Add(users[i]);
                        }
                    }
                    StudentRepeater.DataSource = newUsers.ToArray();
                    StudentRepeater.DataBind();
                    RacazNotView.Visible = false;
                }
                else
                {
                    Response.Redirect("Default.aspx");
                }
            }

            
        }
    }
}