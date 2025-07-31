﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Data.AppMetaData
{
    public static class Router
    {
        public const string SingleRoute = "/{id}";
        public const string root = "Api";
        public const string version = "V1";
        public const string Rule = root + "/" + version + "/";
        public static class StudentRouting
        {
            
            public const string Prefix = Rule + "Student";
            public const string List = Prefix + "/List";
            public const string Create = Prefix + "/Create";
            public const string Update = Prefix + "/Update";
            public const string Delete = Prefix + "/Delete";
            public const string Paginated = Prefix + "/Paginated";

            public const string GetById = Prefix + SingleRoute;
        }
    }
}
