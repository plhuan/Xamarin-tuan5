using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Lab5
{
    public class Cart
    {
        [PrimaryKey, AutoIncrement]
        public int cId { get; set; }
        public int bId { get; set; }
        public string totalAmount { get; set; }

    }
}
