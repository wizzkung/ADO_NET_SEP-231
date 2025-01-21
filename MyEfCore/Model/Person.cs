using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEfCore.Model
{
    public class Person
    {
      
            public int Id { get; set; }
            public string Name { get; set; }
            public DateTime BirthDate { get; set; }

            // Связь 1 к 1
            public IdentityCard IdentityCard { get; set; }

    }

    public class IdentityCard
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public DateTime IssueDate { get; set; }

        // Внешний ключ и связь 1 к 1
        [ForeignKey("Person")]
        public int PersonId { get; set; }
        public Person Person { get; set; }
    }
}
