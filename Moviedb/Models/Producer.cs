﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Moviedb.Models
{
    public class Producer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public DateTime DOB { get; set; }
        public string Bio { get; set; }

    }
    
}