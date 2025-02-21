using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySqLite
{
    public class City
    {
        public int id { get; set; }
        public int country_id { get; set; }
        public string name { get; set; }
        public int population { get; set; }
    }
}
