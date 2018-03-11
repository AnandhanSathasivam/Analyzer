using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UMS.DAL.Lib
{
    public class Languages
    {
        public int Value { get; set; }
        public string Lanaguage { get; set; }
    }
    public enum LanguagesEnum
    {
        Tamil = 1,
        English = 2
    }
}