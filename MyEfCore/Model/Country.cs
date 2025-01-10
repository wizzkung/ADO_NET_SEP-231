using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEfCore.Model
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
       public string Capital { get; set; }
    }
}
