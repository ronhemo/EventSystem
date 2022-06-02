using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;


public class UserGroup:DbAction
{
    public int UserGroupId { get; set; }
    public int GroupId { get; set; }
    public Group Group { get; set; }
    public int UserId { get; set; }
    public UserGroup()
    {

    }
    public UserGroup(int userGroupId)
    {
        this.UserGroupId = userGroupId;
        Init();
    }

    public int Init()
    {
        string q = string.Format("select * from TblUserGroup where usergroupid={0} ", this.UserGroupId);
        DataSet ds = DbQ.ExecuteQuery(q);
        if (ds.Tables[0].Rows.Count > 0)
        {
            this.UserId = int.Parse(ds.Tables[0].Rows[0]["userid"].ToString());

            this.GroupId = int.Parse(ds.Tables[0].Rows[0]["groupid"].ToString());
            this.Group =new Group( this.GroupId );
        }
        else
        {
            return -1;

        }
        return 0;
    }

    public int AddNew()
    {
        string q = string.Format("INSERT INTO TblUserGroup(groupid, userid) VALUES({0}, {1});", this.GroupId, this.UserId);
        return DbQ.ExecuteNonQuery(q);
    }

    public int Update()
    {
        string q = string.Format("UPDATE TblUserGroup Set groupid={0}, userid={1} WHERE usergroupId={2} ", this.GroupId, this.UserId, this.UserGroupId);
        return DbQ.ExecuteNonQuery(q);
    }

    public int Delete()
    {
        string q = string.Format("DELETE From Tblusergroup WHERE usergroupId={0}", this.UserGroupId);
        return DbQ.ExecuteNonQuery(q);
    }
    public static List<UserGroup> UserGroupList()
    {
        int ugid = 0;
        List<UserGroup> lst = new List<UserGroup>();
        string q = "select usergroupid from TblUserGroup";
        DataSet ds = DbQ.ExecuteQuery(q);
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ugid = int.Parse(ds.Tables[0].Rows[i]["usergroupid"].ToString());
                lst.Add(new UserGroup(ugid));
            }
        }
        return lst;
    }
    public static List<UserGroup> UserGroupListOfUser(MyUser u)
    {
        int ugid = 0;
        List<UserGroup> lst = new List<UserGroup>();
        string q = string.Format("select usergroupid from TblUserGroup where userid={0}", u.UserId);
        DataSet ds = DbQ.ExecuteQuery(q);
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ugid = int.Parse(ds.Tables[0].Rows[i]["usergroupid"].ToString());
                lst.Add(new UserGroup(ugid));
            }
        }
        return lst;
    }
}
