﻿using AppCleanImageDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCleanImageDAL
{
    public interface IRoute
    {
        List<ImageRoutingDAO> GetRoutes(int IdProject);
    }
}
