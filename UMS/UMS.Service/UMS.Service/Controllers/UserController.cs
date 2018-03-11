using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json.Linq;
using System.Web.Http.Cors;
using UMS.DAL.Lib;
namespace UMS.Service.Controllers
{
    public class UserController : ApiController
    {
        static readonly IUserRepository repository = new UserRepository();

        //This function is used for get all user list
        public IEnumerable<User> GetAllUsers()
        {
            return repository.GetAllUsers();
        }
        //This function is used for get user by id
        public User Get(int Id)
        {
            User l_objuser = repository.Get(Id);
            if (l_objuser == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return l_objuser;
        }
        //This function is used for save the user details
        public HttpResponseMessage Post(User l_objuser)
        {
            repository.AddUser(l_objuser);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        //This function is used for update the user by id
        public HttpResponseMessage Put(User l_objuser)
        {
            repository.UpdateUser(l_objuser);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        //This function is used for delete the user by id
        [HttpDelete]
        public void delete(int id)
        {
            repository.delete(id);
        }
    }
}