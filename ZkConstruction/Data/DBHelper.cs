using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZkConstruction.Data
{
    public class DBHelper
    {
        public static string ConnectionString
        {
            get
            {
                //return "server=localhost; database=ZkCons; integrated security=true;";
                //return "server=SERVER;database=Cons;User Id=Construction;Password=CONS!!@@;";
                return "server=119.73.122.59;database=Cons;User Id=Construction;Password=CONS!!@@;";
            }
        }
    }
}
