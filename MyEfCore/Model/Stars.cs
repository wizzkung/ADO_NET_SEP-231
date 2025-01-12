using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEfCore.Model
{
    public class Stars
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public decimal Size { get; set; }

        public string Column123 { get; set; } 
    }
}
