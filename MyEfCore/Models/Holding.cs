using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEfCore.Models
{
    public class Holding
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public List<Subsidiaries> Subsidiaries { get; set; }

    }

    public class Subsidiaries
    {
        public int id { get; set; }
        public string name { get; set; }
        public int subsidiaries_id { get; set; }
        [ForeignKey("subsidiaries_id")]
        public Holding Holding { get; set; }
    }
}
