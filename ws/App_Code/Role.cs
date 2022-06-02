using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;


public class Role : DbAction
{
    public int RoleId { get; set; }
    public string RoleName { get; set; }
    public Role()
    {

    }
    public Role(int roleId)
    {
        this.RoleId = roleId;
        Init();
    }

    public int Init()
    {
        string q = string.Format("select * from Tblrole where roleid={0} ", this.RoleId);
        DataSet ds = DbQ.ExecuteQuery(q);
        if (ds.Tables[0].Rows.Count > 0)
        {
            this.RoleName = ds.Tables[0].Rows[0]["rolename"].ToString();
        }
        else
        {
            return -1;

        }
        return 0;
    }

    public int AddNew()
    {
        string q = string.Format("INSERT INTO Tblrole(rolename) VALUES('{0}');", this.RoleName);
        return DbQ.ExecuteNonQuery(q);
    }

    public int Update()
    {
        string q = string.Format("UPDATE Tblrole Set rolename='{0}' WHERE roleId={1} ", this.RoleName, this.RoleId);
        return DbQ.ExecuteNonQuery(q);
    }

    public int Delete()
    {
        string q = string.Format("DELETE From Tblrole WHERE roleId={0}", this.RoleId);
        return DbQ.ExecuteNonQuery(q);
    }
    public static List<Role> RoleList()
    {
        int rid = 0;
        List<Role> lst = new List<Role>();
        string q = "select roleid from TblRole";
        DataSet ds = DbQ.ExecuteQuery(q);
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                rid = int.Parse(ds.Tables[0].Rows[i]["roleid"].ToString());
                lst.Add(new Role(rid));
            }
        }
        return lst;
    }
    public static List<Role> RoleListNoAdmin()
    {
        int rid = 0;
        List<Role> lst = new List<Role>();
        string q = "select roleid from TblRole where NOT roleid = 1";
        DataSet ds = DbQ.ExecuteQuery(q);
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                rid = int.Parse(ds.Tables[0].Rows[i]["roleid"].ToString());
                lst.Add(new Role(rid));
            }
        }
        return lst;
    }
}
