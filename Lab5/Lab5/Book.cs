using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Lab5
{
    public class Book
    {
        [PrimaryKey, AutoIncrement]
        public int bId { get; set; }
        public string bTitle { get; set; }
        public string bImg { get; set; }
        public string bCost { get; set; }
    }
}
