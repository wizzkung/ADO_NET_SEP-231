using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEfCore.Models
{
    public class Family
    {

    }

    [Table("Parent")]
    public class Parent
    {
        public int id { get; set; }
        public string name { get; set; }
        public virtual List<Child> Child { get; set; }
    }

    public class Child
    {
        public int id { get; set; }
        public string name { get; set; }
        public int parent_id { get; set; }
        [ForeignKey("parent_id")]
        public virtual Parent Parent { get; set; }
    }
}
