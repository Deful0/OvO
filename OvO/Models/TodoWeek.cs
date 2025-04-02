﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace OvO.Models
{
    public class TodoWeek
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Title2 { get; set; }

        public bool IsCompleted { get; set; }
    }
}
