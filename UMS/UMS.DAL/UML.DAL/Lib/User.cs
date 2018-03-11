using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UMS.DAL.Lib
{
    public class User
    {
        public int userid { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string confirmpassword { get; set; }
        public int age { get; set; }
        public string dateofbirth { get; set; }
        public int preferredlanguage { get; set; }
        public bool passwordexpires { get; set; }

        //public List<LanguagesEnum> Preferred_Language { get; set; }
        //public int Force_Password_Change { get; set; }
    }
}