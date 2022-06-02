using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebSite
{
    public partial class UserView1 : System.Web.UI.Page
    {
        MyWs.WebService ws;

        public class Month
        {
            public string monthName { get; set; }
            public int monthId { get; set; }
            public Month(string monthName, int monthId)
            {
                this.monthName = monthName;
                this.monthId = monthId;
            }
            public static Month[] GetMonthsYear()
            {
                Month[] months = new Month[12];
                for (int i = 0; i < 12; i++)
                {
                    DateTime d = new DateTime(2020, i + 1, 5);
                    months[i] = new Month(d.ToString("MMMM"), i + 1);
                }
                return months;
            }
        }
        public void SetEventsToTable(MyWs.MyEvent[] events, List<Dictionary<string, string>> listDaysOfWeekDict)
        {
            string s;
            string myScriptValue = "";
            for (int i = 0; i < events.Length; i++)
            {
                int row = events[i].EventDate.Hour - 5;
                int col = -1;
                for (int j = 0; j < 7; j++)
                {
                    s = events[i].EventDate.ToString("dd/MM/yyyy");
                    if (listDaysOfWeekDict[j]["date"] == s)
                    {
                        col = 7 - int.Parse(listDaysOfWeekDict[j]["daynum"]);
                    }

                }
                if (col != -1 && row >= 1 && row <= 12)
                {

                    s = string.Format("row{0}col{1}", row, col);

                    string result = string.Format("<center><a style=\"border: 2px solid {0};\" target=_blank href=\"EventView.aspx?eventid={1}\"> {2} </a></center>", ws.GroupGet(events[i].GroupId).GroupColor, events[i].EventId, events[i].Description);
                    myScriptValue += string.Format("document.getElementById('{0}').innerHTML += '{1}';", s, result);

                }
            }
            string MY_SCRIPT_STRING = string.Format("<script>{0}</script>", myScriptValue);
            this.Controls.Add(new LiteralControl(MY_SCRIPT_STRING));
        }

        public class MyStaticValues
        {

            public static List<Dictionary<string, string>> ListDaysOfWeekDict { get; set; }
            public static DateTime DayOfWeek { get; set; }

            //sets week dates and names to week days in table
            public MyStaticValues()
            {
                DayOfWeek = DateTime.UtcNow;
                int dayOfWeek = (int)DayOfWeek.DayOfWeek;
                Dictionary<string, string> daysOfWeekDict = new Dictionary<string, string>();
                ListDaysOfWeekDict = new List<Dictionary<string, string>>();
                //put dates of week in dict
                for (int i = 6; i >= 0; i--)
                {
                    daysOfWeekDict.Add("daynum", i.ToString());
                    daysOfWeekDict.Add("day", Enum.GetName(typeof(DayOfWeek), i).ToString());
                    DateTime temp = DayOfWeek.AddDays(i - dayOfWeek);
                    daysOfWeekDict.Add("date", temp.ToString("dd/MM/yyyy"));
                    ListDaysOfWeekDict.Add(daysOfWeekDict);
                    daysOfWeekDict = new Dictionary<string, string>();
                }
            }
            public static void NextWeek()
            {
                DayOfWeek = DayOfWeek.AddDays(7);
                int dayOfWeek = (int)DayOfWeek.DayOfWeek;
                Dictionary<string, string> daysOfWeekDict = new Dictionary<string, string>();
                ListDaysOfWeekDict = new List<Dictionary<string, string>>();
                //put dates of week in dict
                for (int i = 6; i >= 0; i--)
                {
                    daysOfWeekDict.Add("daynum", i.ToString());
                    daysOfWeekDict.Add("day", Enum.GetName(typeof(DayOfWeek), i).ToString());
                    DateTime temp = DayOfWeek.AddDays(i - dayOfWeek);
                    daysOfWeekDict.Add("date", temp.ToString("dd/MM/yyyy"));
                    ListDaysOfWeekDict.Add(daysOfWeekDict);
                    daysOfWeekDict = new Dictionary<string, string>();
                }
            }
            public static void PreviousWeek()
            {
                DayOfWeek = DayOfWeek.AddDays(-7);
                int dayOfWeek = (int)DayOfWeek.DayOfWeek;
                Dictionary<string, string> daysOfWeekDict = new Dictionary<string, string>();
                ListDaysOfWeekDict = new List<Dictionary<string, string>>();
                //put dates of week in dict
                for (int i = 6; i >= 0; i--)
                {
                    daysOfWeekDict.Add("daynum", i.ToString());
                    daysOfWeekDict.Add("day", Enum.GetName(typeof(DayOfWeek), i).ToString());
                    DateTime temp = DayOfWeek.AddDays(i - dayOfWeek);
                    daysOfWeekDict.Add("date", temp.ToString("dd/MM/yyyy"));
                    ListDaysOfWeekDict.Add(daysOfWeekDict);
                    daysOfWeekDict = new Dictionary<string, string>();
                }
            }
            public static void UpdateMonth(int monthId)
            {
                DayOfWeek = DayOfWeek.AddMonths(monthId - DayOfWeek.Month);
                int dayOfWeek = (int)DayOfWeek.DayOfWeek;
                Dictionary<string, string> daysOfWeekDict = new Dictionary<string, string>();
                ListDaysOfWeekDict = new List<Dictionary<string, string>>();
                //put dates of week in dict
                for (int i = 6; i >= 0; i--)
                {
                    daysOfWeekDict.Add("daynum", i.ToString());
                    daysOfWeekDict.Add("day", Enum.GetName(typeof(DayOfWeek), i).ToString());
                    DateTime temp = DayOfWeek.AddDays(i - dayOfWeek);
                    daysOfWeekDict.Add("date", temp.ToString("dd/MM/yyyy"));
                    ListDaysOfWeekDict.Add(daysOfWeekDict);
                    daysOfWeekDict = new Dictionary<string, string>();
                }
            }
            public static List<string> GetJsControllers()
            {
                string s;
                string myScriptValue = "";
                List<string> jsControllers = new List<string>();
                //put dates of week in dict and sets week dates and names to week days in table
                for (int i = 6; i >= 0; i--)
                {
                    s = string.Format("row0col{0}", 7 - i);
                    if (ListDaysOfWeekDict[6 - i]["date"] == DateTime.UtcNow.ToString("dd/MM/yyyy"))
                    {
                        myScriptValue += string.Format("document.getElementById('{0}').innerHTML = '<u>{1}</u>';", s, ListDaysOfWeekDict[6 - i]["date"] + " " + ListDaysOfWeekDict[6 - i]["day"]);
                    }
                    else
                    {
                        myScriptValue += string.Format("document.getElementById('{0}').innerHTML = '{1}';", s, ListDaysOfWeekDict[6 - i]["date"] + " " + ListDaysOfWeekDict[6 - i]["day"]);

                    }
                }
                string MY_SCRIPT_STRING = string.Format("<script>{0}</script>", myScriptValue);
                jsControllers.Add(MY_SCRIPT_STRING);
                return jsControllers;
            }
        }
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
                        int userid = 2;
                        try
                        {
                            userid = int.Parse(Request.QueryString["userid"]);
                        }
                        catch
                        { }
                        u = ws.UserGet(userid);
                        r = ws.RoleGet(u.RoleId);
                        roleName = r.RoleName;
                        lblUserId.Text = u.UserId.ToString();
                        lblUserFName.Text = u.FName;
                        lblUserLName.Text = u.LName;
                        lblUserPhone.Text = u.UserPhone;
                        lblUserEmail.Text = u.UserEmail;
                        lblUserPassword.Text = u.UserPass;
                        lblUserRole.Text = r.RoleName.ToString();
                        if (roleName != "תלמיד")
                        {
                            UserView.Visible = false;
                        }
                        else
                        {
                            Month[] monthsYear = Month.GetMonthsYear();
                            MonthDropDownList.DataSource = monthsYear;
                            MonthDropDownList.DataTextField = "monthName";
                            MonthDropDownList.DataValueField = "monthId";
                            MonthDropDownList.DataBind();
                            linkToAddGroupToUser.HRef = string.Format("UserGroupAddUpdate.aspx?userid={0}", userid);
                            MyWs.UserGroup[] usergroups = ws.UserGroupListOfUser(u);
                            UserGroupRepeater.DataSource = usergroups;
                            UserGroupRepeater.DataBind();
                            MyStaticValues msv = new MyStaticValues();
                            //set month name
                            MonthDropDownList.SelectedValue = MyStaticValues.DayOfWeek.Month.ToString();
                            //set weeks days in table
                            List<string> jscontrolls = MyStaticValues.GetJsControllers();
                            for (int i = 0; i < jscontrolls.Count; i++)
                            {
                                this.Controls.Add(new LiteralControl(jscontrolls[i]));
                            }

                            //put data in table
                            MyWs.MyEvent[] events = ws.EventListOfUserByDates(u, DateTime.Parse(MyStaticValues.ListDaysOfWeekDict[6]["date"]), DateTime.Parse(MyStaticValues.ListDaysOfWeekDict[0]["date"]));
                            SetEventsToTable(events, MyStaticValues.ListDaysOfWeekDict);
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
        protected void GetNextWeek(object sender, EventArgs e)
        {
            ws = new MyWs.WebService();
            int userid = 2;
            try
            {
                userid = int.Parse(Request.QueryString["userid"]);
            }
            catch
            { }
            MyWs.MyUser u = ws.UserGet(userid);
            MyStaticValues.NextWeek();
            //set month name
            MonthDropDownList.SelectedValue = MyStaticValues.DayOfWeek.Month.ToString();
            //set weeks days in table
            List<string> jscontrolls = MyStaticValues.GetJsControllers();
            for (int i = 0; i < jscontrolls.Count; i++)
            {
                this.Controls.Add(new LiteralControl(jscontrolls[i]));
            }
            //put data in table
            MyWs.MyEvent[] events = ws.EventListOfUserByDates(u, DateTime.Parse(MyStaticValues.ListDaysOfWeekDict[6]["date"]), DateTime.Parse(MyStaticValues.ListDaysOfWeekDict[0]["date"]));
            SetEventsToTable(events, MyStaticValues.ListDaysOfWeekDict);
           
        }

        protected void GetPrevWeek(object sender, EventArgs e)
        {
            ws = new MyWs.WebService();
            int userid = 2;
            try
            {
                userid = int.Parse(Request.QueryString["userid"]);
            }
            catch
            { }
            MyWs.MyUser u = ws.UserGet(userid);
            MyStaticValues.PreviousWeek();
            //set month name
            MonthDropDownList.SelectedValue = MyStaticValues.DayOfWeek.Month.ToString();
            //set weeks days in table
            List<string> jscontrolls = MyStaticValues.GetJsControllers();
            for (int i = 0; i < jscontrolls.Count; i++)
            {
                this.Controls.Add(new LiteralControl(jscontrolls[i]));
            }
            //put data in table
            MyWs.MyEvent[] events = ws.EventListOfUserByDates(u, DateTime.Parse(MyStaticValues.ListDaysOfWeekDict[6]["date"]), DateTime.Parse(MyStaticValues.ListDaysOfWeekDict[0]["date"]));
            SetEventsToTable(events, MyStaticValues.ListDaysOfWeekDict);
        }

        protected void MonthDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ws = new MyWs.WebService();
            int userid = 2;
            try
            {
                userid = int.Parse(Request.QueryString["userid"]);
            }
            catch
            { }
            MyWs.MyUser u = ws.UserGet(userid);
            //update month
            MyStaticValues.UpdateMonth(int.Parse(MonthDropDownList.SelectedValue));
            //set month name
            MonthDropDownList.SelectedValue = MyStaticValues.DayOfWeek.Month.ToString();
            //set weeks days in table
            List<string> jscontrolls = MyStaticValues.GetJsControllers();
            for (int i = 0; i < jscontrolls.Count; i++)
            {
                this.Controls.Add(new LiteralControl(jscontrolls[i]));
            }
            //put data in table
            MyWs.MyEvent[] events = ws.EventListOfUserByDates(u, DateTime.Parse(MyStaticValues.ListDaysOfWeekDict[6]["date"]), DateTime.Parse(MyStaticValues.ListDaysOfWeekDict[0]["date"]));
            SetEventsToTable(events, MyStaticValues.ListDaysOfWeekDict);
            

        }
    }
}