using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;


public class MyUser : DbAction
{
    public int UserId { get; set; }
    public string FName { get; set; }
    public string LName { get; set; }
    public string UserPhone { get; set; }
    public string UserEmail { get; set; }
    public string UserPass { get; set; }
    public int RoleId { get; set; }
    public MyUser()
    {

    }
    public MyUser(int userId)
    {
        this.UserId = userId;
        Init();
    }
    public int Init()
    {
        string q = string.Format("select * from TblUser where userid={0} ", this.UserId);
        DataSet ds = DbQ.ExecuteQuery(q);
        if (ds.Tables[0].Rows.Count > 0)
        {
            this.FName = ds.Tables[0].Rows[0]["fname"].ToString();
            this.LName = ds.Tables[0].Rows[0]["lname"].ToString();
            this.UserPhone = ds.Tables[0].Rows[0]["userphone"].ToString();
            this.UserEmail = ds.Tables[0].Rows[0]["useremail"].ToString();
            this.UserPass = ds.Tables[0].Rows[0]["userpass"].ToString();
            this.RoleId = int.Parse(ds.Tables[0].Rows[0]["roleid"].ToString());

        }
        else
        {
            return -1;

        }
        return 0;

    }

    public int AddNew()
    {
        string q = string.Format("INSERT INTO TblUser(fname, lname, userphone, useremail, userpass, roleid) VALUES('{0}', '{1}', '{2}', '{3}', '{4}', {5});", this.FName, this.LName, this.UserPhone, UserEmail, this.UserPass, this.RoleId);
        return DbQ.ExecuteNonQuery(q);
    }

    public int Update()
    {

        string q = string.Format("UPDATE TblUser Set fname='{0}', lname='{1}', userphone='{2}', useremail='{3}', userpass='{4}', roleid={5}  WHERE UserId={6} ", this.FName, this.LName, this.UserPhone, this.UserEmail, this.UserPass,
            this.RoleId, this.UserId);
        return DbQ.ExecuteNonQuery(q);
    }

    public int Delete()
    {
        string q = string.Format("DELETE From Tbluser WHERE UserId={0}", this.UserId);
        return DbQ.ExecuteNonQuery(q);
    }
    public static List<MyUser> UserList()
    {
        int uid = 0;
        List<MyUser> lst = new List<MyUser>();
        string q = "select userid from TblUser";
        DataSet ds = DbQ.ExecuteQuery(q);
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                uid = int.Parse(ds.Tables[0].Rows[i]["userid"].ToString());
                lst.Add(new MyUser(uid));
            }
        }
        return lst;
    }
    public static List<MyUser> UserStudentList()
    {
        int uid = 0;
        List<MyUser> lst = new List<MyUser>();
        string q = "select userid from TblUser where roleid = 4";
        DataSet ds = DbQ.ExecuteQuery(q);
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                uid = int.Parse(ds.Tables[0].Rows[i]["userid"].ToString());
                lst.Add(new MyUser(uid));
            }
        }
        return lst;
    }
    public static MyUser Login(string userEmail, string userpass)
    {
        MyUser u = null;
        string q = string.Format("select userid from TblUser where useremail='{0}' and userpass='{1}' ", userEmail, userpass);
        DataSet ds = DbQ.ExecuteQuery(q);
        if (ds.Tables[0].Rows.Count > 0)
        {
            try
            {
                int uid = int.Parse(ds.Tables[0].Rows[0]["userid"].ToString());
                u = new MyUser(uid);
            }
            catch
            {

            }
            return u;
        }
        else
            return null;
    }

}
