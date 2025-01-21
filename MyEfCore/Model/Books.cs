using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEfCore.Model
{
    public class Books
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }

        // Навигационное свойство для связи с жанрами
        public ICollection<Genre> Genres { get; set; }
    }


    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Навигационное свойство для связи с книгами
        public ICollection<Books> Books { get; set; }
    }
}
