﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace OvO.Models
{
    public class TodoPay
    {

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Title3 { get; set; }

        public bool IsCompleted { get; set; }

    }
}
