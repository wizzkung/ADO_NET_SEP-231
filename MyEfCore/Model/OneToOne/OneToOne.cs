using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEfCore.Model.OneToOne
{
    public class OneToOne
    {
    }
    [NotMapped]
    [Table("Employee")]
    public class Employee
    {
        public int id { get; set; }
        public string last_name { get; set; }
        public string first_name { get; set; }
        public string gender { get; set; }

    }
    [NotMapped]
    [Table("Salary")]
    public class Salary
    {
        public int id { get; set; }
        public int employee_id { get; set; }
        public decimal salary { get; set; }
       public Employee Employee { get; set; }

    }


}
