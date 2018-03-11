using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace UMS.DAL.Lib
{
    public class UserRepository : IUserRepository
    {
        DBManager objDBhelper = new DBManager();
        private int l_nextId = 1;

        public UserRepository()
        {

        }

        public IEnumerable<User> GetAllUsers()
        {
            List<User> users = new List<User>();
            DataTable dt = new DataTable();
            dt = objDBhelper.GetDataTableUsingProc("USRMGMT_CRUD", "SELECT");

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    User usr = new User();
                    usr.userid = Convert.ToInt32(dt.Rows[i]["userid"]);
                    usr.firstname = Convert.ToString(dt.Rows[i]["firstname"]);
                    usr.lastname = Convert.ToString(dt.Rows[i]["lastname"]);
                    usr.username = Convert.ToString(dt.Rows[i]["username"]);
                    usr.password = Convert.ToString(dt.Rows[i]["password"]);
                    usr.age = Convert.ToInt32(dt.Rows[i]["age"]);
                    usr.dateofbirth = Convert.ToString(dt.Rows[i]["dateofbirth"]);
                    usr.preferredlanguage = Convert.ToInt32(dt.Rows[i]["preferredlanguage"]);
                    usr.passwordexpires = Convert.ToBoolean(dt.Rows[i]["passwordexpires"]);
                    users.Add(usr);
                }
            }
            return users;
        }
        public User Get(int Id)
        {
            User usr = new User();
            DataTable dt = new DataTable();
            dt = objDBhelper.GetTableUsingID("USRMGMT_CRUD", "EDIT", Id);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    usr.userid = Convert.ToInt32(dt.Rows[i]["userid"]);
                    usr.firstname = Convert.ToString(dt.Rows[i]["firstname"]);
                    usr.lastname = Convert.ToString(dt.Rows[i]["lastname"]);
                    usr.username = Convert.ToString(dt.Rows[i]["username"]);
                    usr.password = Convert.ToString(dt.Rows[i]["password"]);
                    usr.age = Convert.ToInt32(dt.Rows[i]["age"]);
                    usr.dateofbirth = Convert.ToString(dt.Rows[i]["dateofbirth"]);
                    usr.preferredlanguage = Convert.ToInt32(dt.Rows[i]["preferredlanguage"]);
                    usr.passwordexpires = Convert.ToBoolean(dt.Rows[i]["passwordexpires"]);
                }
            }
            return usr;
        }

        public void AddUser(User objuser)
        {
            objDBhelper.AddQuery("USRMGMT_CRUD", "INSERT", objuser.firstname, objuser.lastname, objuser.username, objuser.password, objuser.age, objuser.dateofbirth, Convert.ToInt16(objuser.preferredlanguage), Convert.ToInt16(objuser.passwordexpires));
        }

        public void delete(int Id)
        {
            objDBhelper.DeleteQuery("USRMGMT_CRUD", "DELETE", Id);
        }

        public bool UpdateUser(User objuser)
        {
            objDBhelper.UpdateQuery("USRMGMT_CRUD", "UPDATE",objuser.userid,objuser.firstname, objuser.lastname, objuser.username, objuser.password, objuser.age, objuser.dateofbirth, Convert.ToInt16(objuser.preferredlanguage), Convert.ToInt16(objuser.passwordexpires));
            return true;
        }
    }
}