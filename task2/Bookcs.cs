using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2
{
    public class Bookcs
    {
        public class Book
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public int Pages { get; set; }
            public int AuthorId { get; set; }

            public override string ToString()
            {
                return $"Id: {Id}, Title: {Title}, Pages: {Pages}, AuthorId: {AuthorId}";
            }
        }
    }
}
