﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCleanImageDAO
{
    public class ImageRoutingDAO
    {
        public int Id { get; set; }
        public string Route { get; set; }
        public bool Active { get; set; }
        public int IdProject { get; set; }
    }
}
