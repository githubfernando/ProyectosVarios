using AppCleanImageDAL;
using AppCleanImageDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCleanImageBLL
{
    public class RouteBLL
    {
        private readonly Route data;

        public RouteBLL()
        {
            data = new Route();
        }

        public List<ImageRoutingDAO> GetRoutes(int IdProject)
        {
            return data.GetRoutes(IdProject);
        }
    }
}
