using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;


public class MyEvent : DbAction
{
    public int EventId { get; set; }
    public DateTime EventDate { get; set; }
    public string Description { get; set; }
    public int GroupId { get; set; }
    public int UserId { get; set; }
    public MyEvent()
    {

    }
    public MyEvent(int eventId)
    {
        this.EventId = eventId;
        Init();
    }
    public int AddNew()
    {
        string q = string.Format("INSERT INTO TblEvent(eventdate,  description, groupid, userid) VALUES('{0}', '{1}', {2}, {3});", this.EventDate,  this.Description, this.GroupId, this.UserId);
        return DbQ.ExecuteNonQuery(q);
    }

    public int Delete()
    {
        string q = string.Format("DELETE From Tblevent WHERE eventId={0}", this.EventId);
        return DbQ.ExecuteNonQuery(q);
    }

    public int Init()
    {
        string q = string.Format("select * from TblEvent where eventid={0} ", this.EventId);
        DataSet ds = DbQ.ExecuteQuery(q);
        if (ds.Tables[0].Rows.Count > 0)
        {
            this.EventDate = DateTime.Parse(ds.Tables[0].Rows[0]["eventdate"].ToString());
            this.Description = ds.Tables[0].Rows[0]["description"].ToString();
            this.GroupId = int.Parse(ds.Tables[0].Rows[0]["groupid"].ToString());
            this.UserId = int.Parse(ds.Tables[0].Rows[0]["userid"].ToString());
        }
        else
        {
            return -1;

        }
        return 0;
    }

    public int Update()
    {
        string q = string.Format("UPDATE TblEvent Set eventdate='{0}', description='{1}', groupid={2}, userid={3} WHERE eventid={4} ", this.EventDate, this.Description, this.GroupId, this.UserId, this.EventId);
        return DbQ.ExecuteNonQuery(q);
    }
    public static List<MyEvent> EventList()
    {
        int eid = 0;
        List<MyEvent> lst = new List<MyEvent>();
        string q = "select eventid from TblEvent";
        DataSet ds = DbQ.ExecuteQuery(q);
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                eid = int.Parse(ds.Tables[0].Rows[i]["eventid"].ToString());
                lst.Add(new MyEvent(eid));
            }
        }
        return lst;
    }
    //gives group and parent events
    public static List<MyEvent> EventListOfGroup(Group g)
    {
        int eid = 0;
        int gid = g.GroupId;
        List<MyEvent> lst = new List<MyEvent>();
        List<Group> groups = Group.GroupParentListOfGroup(new Group(gid));
        for (int i = 0; i < groups.Count; i++)
        {
            string q = string.Format("select eventid from TblEvent where groupid={0}", groups[i].GroupId);
            DataSet ds = DbQ.ExecuteQuery(q);
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
                {
                    eid = int.Parse(ds.Tables[0].Rows[j]["eventid"].ToString());
                    lst.Add(new MyEvent(eid));
                }
            }
        }
        return lst;
    }
    public static List<MyEvent> EventListOfGroupOnly(Group g)
    {
        int eid;
        int gid = g.GroupId;
        List<MyEvent> lst = new List<MyEvent>();

        string q = string.Format("select eventid from TblEvent where groupid={0}", g.GroupId);
        DataSet ds = DbQ.ExecuteQuery(q);
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
            {
                eid = int.Parse(ds.Tables[0].Rows[j]["eventid"].ToString());
                lst.Add(new MyEvent(eid));
            }
            }
        return lst;
    }
    public static List<MyEvent> EventListOfWeek(DateTime startDate,DateTime endDate)
    {
        int eid = 0;
        List<MyEvent> lst = new List<MyEvent>();
        string q = string.Format("select eventid from TblEvent where eventdate>=#{0}# and eventdate<=#{1}# order by eventdate;", startDate.ToString("yyyy-MM-dd"),endDate.ToString("yyyy-MM-dd"));
        DataSet ds = DbQ.ExecuteQuery(q);
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
            {
                eid = int.Parse(ds.Tables[0].Rows[j]["eventid"].ToString());
                lst.Add(new MyEvent(eid));
            }
        }
        return lst;
    }
    public static List<MyEvent> EventListOfUser(MyUser u)
    {
        List<Group> g = Group.GroupListOfUser(u);
        List<MyEvent> ev = new List<MyEvent>();
        for (int i = 0; i < g.Count; i++)
        {
            ev.AddRange(EventListOfGroup(g[i]));
        }
        return ev;
    }


    public static List<MyEvent> EventListOfGroupsByDates(int[] groupIdlst, DateTime startDate, DateTime endDate)
    {
        int eid = 0;
        int gid;
        List<MyEvent> lst = new List<MyEvent>();
        for (int i = 0; i < groupIdlst.Length; i++)
        {
            string q = string.Format("select eventid from TblEvent where groupid={0} and eventdate>=#{1}# and eventdate<=#{2}# order by eventdate;", groupIdlst[i], startDate.ToString("yyyy-MM-dd"), endDate.ToString("yyyy-MM-dd"));
            DataSet ds = DbQ.ExecuteQuery(q);
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
                {
                    eid = int.Parse(ds.Tables[0].Rows[j]["eventid"].ToString());
                    lst.Add(new MyEvent(eid));
                }
            }
        }
        return lst;
    }

    public static List<MyEvent> EventListOfGroupByDates(Group g, DateTime startDate, DateTime endDate)
    {
        int eid = 0;
        int gid = g.GroupId;
        List<MyEvent> lst = new List<MyEvent>();
        string q = string.Format("select eventid from TblEvent where groupid={0} and eventdate>=#{1}# and eventdate<=#{2}# order by eventdate;",g.GroupId, startDate.ToString("yyyy-MM-dd"), endDate.ToString("yyyy-MM-dd"));
        DataSet ds = DbQ.ExecuteQuery(q);
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
            {
                eid = int.Parse(ds.Tables[0].Rows[j]["eventid"].ToString());
                lst.Add(new MyEvent(eid));
            }
        }
        return lst;
    }
    public static List<MyEvent> EventListOfUserByDates(MyUser u, DateTime startDate, DateTime endDate)
    {
        List<Group> g = Group.GroupListOfUser(u);
        List<MyEvent> ev = new List<MyEvent>();
        for (int i = 0; i < g.Count; i++)
        {
            ev.AddRange(EventListOfGroupByDates(g[i], startDate, endDate));
        }
        return ev;
    }
}
