using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Lab5
{
    public class User
    {
        [PrimaryKey]
        public string username { get; set; }
        public string password { get; set; }

        public bool isAdmin { get; set; }

    }
}
