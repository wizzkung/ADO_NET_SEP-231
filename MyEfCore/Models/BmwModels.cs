using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEfCore.Models
{
    public class BmwModels
    {
        public int id { get; set; }
        public string series_name { get; set; }
        public int serial_number_bmw { get; set; }
        [ForeignKey("serial_number_bmw")]
        public virtual BMW BMW { get; set; }
    }
}
