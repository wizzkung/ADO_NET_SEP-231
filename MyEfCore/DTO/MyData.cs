using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEfCore.DTO
{
    internal class MyData
    {
    }
    [Keyless]
    public class BookCategory2
    {
        public string category_name { get; set; }
        public string book_name { get; set; }
    }
    [Keyless] //шоб не ругался на primarykey
    public class BookCategoryCount
    {
        public string category_name { get; set; }
        public int cnt { get; set; }
    }
}
