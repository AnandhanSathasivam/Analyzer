using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMS.DAL.Lib
{
   public interface IUserRepository
    {
       IEnumerable<User> GetAllUsers();
        User Get(int Id);
        void AddUser(User objusers);
        //User AddUser(User objusers);
        void delete(int Id);
        bool UpdateUser(User objusers);
    }
}
