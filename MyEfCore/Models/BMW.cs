using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEfCore.Models
{
    [Table("BMW")]
    public class BMW
    {
        public int id { get; set; }
        public string series { get; set; }
        public DateTime creation_date { get; set; }
        public virtual List<BmwModels> BmwModels { get; set; }

    }

}
