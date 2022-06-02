using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace ws
{
    /// <summary>
    /// Summary description for WebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        #region USER
        [WebMethod]

        public MyUser UserGet(int userid)
        {
            return new MyUser(userid);
        }
        //[WebMethod]
        //public int UserAdd(MyUser u)
        //{
        //    return u.AddNew();
        //}
        [WebMethod]
        public int UserAdd(MyUser u)
        {
            return u.AddNew();
        }
        [WebMethod]
        public int UserUpdate(MyUser u)
        {
            return u.Update();
        }
        [WebMethod]
        public int UserDelete(MyUser u)
        {
           
            return u.Delete();
        }
        [WebMethod]
        public List<MyUser> UserList()
        {
            return MyUser.UserList();
        }
        [WebMethod]
        public List<MyUser> UserStudentList()
        {
            return MyUser.UserStudentList();
        }
        [WebMethod]
        public MyUser Login(string userEmail, string pass)
        {
            return MyUser.Login(userEmail, pass);
        }
        #endregion
        #region group
        [WebMethod]

        public Group GroupGet(int groupid)
        {
            return new Group(groupid);
        }
        [WebMethod]
        public int GroupAdd(Group g)
        {
            return g.AddNew();
        }
        [WebMethod]
        public int GroupUpdate(Group g)
        {
            return g.Update();
        }
        [WebMethod]
        public int GroupDelete(Group g)
        {
            return g.Delete();
        }
        [WebMethod]
        public List<Group> GroupList()
        {
            return Group.GroupList();
        }
        /// <summary>
        /// group list of user also parents
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        [WebMethod]
        public List<Group> GroupListOfUser(MyUser u)
        {
            return Group.GroupListOfUser(u);
        }
        /// <summary>
        /// group list of user only base
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        [WebMethod]
        public List<Group> GroupListOnlyOfUser(MyUser u)
        {
            return Group.GroupListOnlyOfUser(u);
        }
        [WebMethod]
        public Group GroupOfEvent(MyEvent ev)
        {
            return Group.GroupOfEvent(ev);
        }

        [WebMethod]
        public List<Group> GroupChildOfGroup(Group g)
        {
            return Group.GroupChildOfGroup(g);
        }
        [WebMethod]
        public List<Group> MasterGroupList()
        {
            return Group.MasterGroupList();
        }
        [WebMethod]
        public List<Group> GroupChildOfGroupList(List<Group> gL)
        {
            return Group.GroupChildOfGroupList(gL);
        }
        [WebMethod]
        public List<Group> MasterGroupListOfUser(MyUser u)
        {
            return Group.MasterGroupListOfUser(u);
        }
        #endregion
        #region usergroup
        [WebMethod]

        public UserGroup UserGroupGet(int usergroupid)
        {
            return new UserGroup(usergroupid);
        }
        [WebMethod]
        public int UserGroupAdd(UserGroup ug)
        {
            return ug.AddNew();
        }
        [WebMethod]
        public int UserGroupUpdate(UserGroup ug)
        {
            return ug.Update();
        }
        [WebMethod]
        public int UserGroupDelete(UserGroup ug)
        {
            return ug.Delete();
        }
        [WebMethod]
        public List<UserGroup> UserGroupList()
        {
            return UserGroup.UserGroupList();
        }
        [WebMethod]
        public List<UserGroup> UserGroupListOfUser(MyUser u)
        {
            return UserGroup.UserGroupListOfUser(u);
        }
        #endregion
        #region ROLE
        [WebMethod]

        public Role RoleGet(int roleid)
        {
            return new Role(roleid);
        }
        //[WebMethod]
        //public int UserAdd(MyUser u)
        //{
        //    return u.AddNew();
        //}
        [WebMethod]
        public int RoleAdd(Role r)
        {
            return r.AddNew();
        }
        [WebMethod]
        public int RoleUpdate(Role r)
        {
            return r.Update();
        }
        [WebMethod]
        public int RoleDelete(Role r)
        {
            return r.Delete();
        }
        [WebMethod]
        public List<Role> RoleList()
        {
            return Role.RoleList();
        }
        [WebMethod]
        public List<Role> RoleListNoAdmin()
        {
            return Role.RoleListNoAdmin();
        }
        #endregion
        #region Event
        [WebMethod]

        public MyEvent EventGet(int eventid)
        {
            return new MyEvent(eventid);
        }
        [WebMethod]
        public int EventAdd(MyEvent e)
        {

            return e.AddNew();
        }
        [WebMethod]
        public int EventUpdate(MyEvent e)
        {
            return e.Update();
        }
        [WebMethod]
        public int EventDelete(MyEvent e)
        {
            return e.Delete();
        }
        [WebMethod]
        public List<MyEvent> EventList()
        {
            return MyEvent.EventList();
        }
        [WebMethod]
        public List<MyEvent> EventListOfGroup(Group g)
        {
            return MyEvent.EventListOfGroup(g);
        }
        [WebMethod]
        public List<MyEvent> EventListOfGroupOnly(Group g)
        {
            return MyEvent.EventListOfGroupOnly(g);
        }
        [WebMethod]
        public List<MyEvent> EventListOfUser(MyUser u)
        {
            return MyEvent.EventListOfUser(u);
        }
        [WebMethod]
        public List<MyEvent> EventListOfWeek(DateTime startDate, DateTime endDate)
        {
            return MyEvent.EventListOfWeek(startDate, endDate);
        }
        [WebMethod]
        public List<MyEvent> EventListOfGroupByDates(Group g, DateTime startDate, DateTime endDate)
        {
            return MyEvent.EventListOfGroupByDates(g, startDate, endDate);
        }
        [WebMethod]
        public List<MyEvent> EventListOfGroupsByDates(int[] groupIdlst, DateTime startDate, DateTime endDate)
        {
            return MyEvent.EventListOfGroupsByDates(groupIdlst, startDate, endDate);
        }
        [WebMethod]
        public List<MyEvent> EventListOfUserByDates(MyUser u, DateTime startDate, DateTime endDate)
        {
            return MyEvent.EventListOfUserByDates(u, startDate, endDate);
        }
        #endregion

    }
}
