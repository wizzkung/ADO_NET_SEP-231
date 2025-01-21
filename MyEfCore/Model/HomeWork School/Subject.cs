using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEfCore.Model.HomeWork_School
{
    public class Subject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public int TeacherID { get; set; }
        public Teacher Teacher { get; set; }
        public ICollection<Student> Students { get; set; } = new List<Student>();

    }
}
