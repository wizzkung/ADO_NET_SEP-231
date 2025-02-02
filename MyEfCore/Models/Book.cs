using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyEfCore.Models
{
    public partial class Book
    {
        public Book()
        {
            BookCategory = new HashSet<BookCategory>();
        }

        [Key]
        public int book_id { get; set; }
        public string? book_name { get; set; }

        public virtual ICollection<BookCategory> BookCategory { get; set; }
    }
}
