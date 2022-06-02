using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

public class Group : DbAction
{
    public int GroupId { get; set; }
    public string GroupName { get; set; }
    public int MasterG { get; set; }
    public string GroupColor { get; set; }
    public Group()
    {

    }
    public Group(int groupId)
    {
        this.GroupId = groupId;
        Init();
    }
    public int AddNew()
    {
        string q = string.Format("INSERT INTO Tblgroup(groupname, masterg, groupcolor) VALUES('{0}', {1}, '{2}');", this.GroupName, this.MasterG, this.GroupColor);
        return DbQ.ExecuteNonQuery(q);

    }

    public int Delete()
    {
        string q = string.Format("DELETE From Tblgroup WHERE groupId={0}", this.GroupId);
        return DbQ.ExecuteNonQuery(q);
    }

    public int Init()
    {
        string q = string.Format("select * from Tblgroup where groupid={0} ", this.GroupId);
        DataSet ds = DbQ.ExecuteQuery(q);
        if (ds.Tables[0].Rows.Count > 0)
        {
            this.GroupName = ds.Tables[0].Rows[0]["groupname"].ToString();
            this.MasterG = int.Parse(ds.Tables[0].Rows[0]["masterg"].ToString());
            this.GroupColor = ds.Tables[0].Rows[0]["groupcolor"].ToString();
        }
        else
        {
            return -1;

        }
        return 0;
    }

    public int Update()
    {
        string q = string.Format("UPDATE TblGroup Set groupname='{0}', masterg={1}, groupcolor='{2}' WHERE groupId={3} ", this.GroupName, this.MasterG, this.GroupColor, this.GroupId);
        return DbQ.ExecuteNonQuery(q);
    }
    public static List<Group> GroupList()
    {
        int gid = 0;
        List<Group> lst = new List<Group>();
        string q = "select groupid from Tblgroup";
        DataSet ds = DbQ.ExecuteQuery(q);
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                gid = int.Parse(ds.Tables[0].Rows[i]["groupid"].ToString());
                lst.Add(new Group(gid));
            }
        }
        return lst;
    }


    public static List<Group> GroupListOfUserGroup(UserGroup ug)
    {
        int gid = 0;
        List<Group> lst = new List<Group>();
        string q = string.Format("select groupid from Tblgroup where groupid={0}",ug.GroupId);
        DataSet ds = DbQ.ExecuteQuery(q);
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                gid = int.Parse(ds.Tables[0].Rows[i]["groupid"].ToString());
                lst.Add(new Group(gid));
            }
        }
        return lst;
    }

    public static Group GroupOfEvent(MyEvent ev)
    {
        int gid = 0;
        string q = string.Format("select groupid from Tblgroup where groupid={0}", ev.GroupId);
        DataSet ds = DbQ.ExecuteQuery(q);
        if (ds.Tables[0].Rows.Count > 0)
        {
           gid = int.Parse(ds.Tables[0].Rows[0]["groupid"].ToString());
        }
        return new Group(gid);
    }

    public static List<Group> GroupListOfUser(MyUser u)
    {
        
        int gid = 0;
        List<Group> grouplst = new List<Group>();
        List<UserGroup> lstug = UserGroup.UserGroupListOfUser(u);

        for (int i = 0; i < lstug.Count; i++)
        {
            grouplst.AddRange( GroupParentListOfGroup(new Group(lstug[i].GroupId)));

        }
        return grouplst;

    }
    public static List<Group> GroupListOnlyOfUser(MyUser u)
    {

        int gid = 0;
        List<Group> grouplst = new List<Group>();
        List<UserGroup> lstug = UserGroup.UserGroupListOfUser(u);

        for (int i = 0; i < lstug.Count; i++)
        {
            grouplst.Add(new Group(lstug[i].GroupId));

        }
        return grouplst;

    }
    //parent
    public static List<Group> GroupParentListOfGroup(Group g)
    {
        int gid = g.GroupId;
        int masterid = g.MasterG;
        List<Group> lst = new List<Group>();
        string q = string.Format("select groupid from Tblgroup where groupid={0}", masterid);
        DataSet ds = DbQ.ExecuteQuery(q);
        lst.Add(new Group(gid));
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                masterid = int.Parse(ds.Tables[0].Rows[i]["groupid"].ToString());
                lst.AddRange(GroupParentListOfGroup(new Group(masterid)));
            }

            return lst;
        }
        else
        {
            return lst;
        }

    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="g"></param>
    /// <returns></returns>
    //child
    public static List<Group> GroupChildOfGroup(Group g)
    {
        int gid = g.GroupId;
        int masterid = g.MasterG;
        List<Group> lst = new List<Group>();
        string q = string.Format("select groupid from Tblgroup where masterg={0}", gid);
        DataSet ds = DbQ.ExecuteQuery(q);
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                gid = int.Parse(ds.Tables[0].Rows[i]["groupid"].ToString());
                lst.Add(new Group(gid));
            }

            return lst;
        }
        else
        {
            return lst;
        }

    }
    public static List<Group> GroupChildOfGroupList(List<Group> gL)
    {
        List<Group> lst = new List<Group>();
        for (int i = 0; i < gL.Count; i++)
        {
            lst.AddRange(GroupChildOfGroup(gL[i]));
        }
        return lst;
    }





    public static List<Group> MasterGroupList()
    {
        int gid = 0;
        List<Group> lst = new List<Group>();
        string q = string.Format("select groupid from Tblgroup where masterg={0}", gid);
        DataSet ds = DbQ.ExecuteQuery(q);
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                gid = int.Parse(ds.Tables[0].Rows[i]["groupid"].ToString());
                lst.Add(new Group(gid));
            }
        }
        return lst;
    }
    public static List<Group> MasterGroupListOfUser(MyUser u)
    {
        List<Group> groupLst = GroupListOfUser(u);
        List<Group> lst = new List<Group>();
        for (int i = groupLst.Count-1; i >= 0 ; i--)
        {
            if(groupLst[i].MasterG == 0)
            {
                lst.Add(groupLst[i]);
            }
        }
        return lst;
    }

}
