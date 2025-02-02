using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyEfCore.Models
{
    public partial class BookCategory
    {
        [Key]
        public int id { get; set; }
        public int? book_id { get; set; }
        public int? category_id { get; set; }
        public virtual Book? Book { get; set; }
        public virtual Category? Category { get; set; }
    }
}
