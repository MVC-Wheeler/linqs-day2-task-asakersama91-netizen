using static task2.Bookcs;

namespace task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Authorcs> authors = new List<Authorcs>()
        {
            new  Authorcs { Id = 1, Name = "Ahmed Khaled Tawfik" },
            new Authorcs{ Id = 2, Name = "Taha Hussein" },
            new  Authorcs { Id = 3, Name = "Naguib Mahfouz" }
        };

            List<Book> books = new List<Book>()
        {
            new Book { Id = 1, Title = "Utopia", Pages = 320, AuthorId = 1 },
            new Book { Id = 2, Title = "The Days", Pages = 250, AuthorId = 2 },
            new Book { Id = 3, Title = "Palace Walk", Pages = 400, AuthorId = 3 },
            new Book { Id = 4, Title = "Poor", Pages = 180, AuthorId = 1 },
            new Book { Id = 5, Title = "Paradise", Pages = 350, AuthorId = 2 }
        };

            // q22
           
            var q22 = books.Join(authors, b => b.AuthorId, a => a.Id, (b, a) => new { a.Name, b.Title, b.Pages });
            foreach (var i in q22)
            {
                Console.WriteLine(i.Name + " " + i.Title + " " + i.Pages);
            }
            Console.WriteLine();


            // q23
         
            var q23 = books.GroupBy(b => b.AuthorId);
            foreach (var g in q23)
            {
                Console.WriteLine(g.Key + " " + g.Count());
            }
            Console.WriteLine();


            // q24
          
            var q24 = books.GroupBy(b => b.AuthorId);
            foreach (var g in q24)
            {
                Console.WriteLine(g.Key);
                foreach (var b in g)
                {
                    Console.WriteLine(b.Title);
                }
            }
            Console.WriteLine();


            // q25
       
            var q25 = books.Take(3);
            foreach (var b in q25)
            {
                Console.WriteLine(b);
            }
            Console.WriteLine();


            // q26
          
            var q26 = books.Skip(2);
            foreach (var b in q26)
            {
                Console.WriteLine(b);
            }
            Console.WriteLine();


            // q27
           
            var q27 = books.Skip(2).Take(3);
            foreach (var b in q27)
            {
                Console.WriteLine(b);
            }
            Console.WriteLine();


            // q28
         
            var q28 = books.TakeWhile(b => b.Pages < 300);
            foreach (var b in q28)
            {
                Console.WriteLine(b);
            }
            Console.WriteLine();


            // q29
        
            var q29 = books.SkipWhile(b => b.Pages < 250);
            foreach (var b in q29)
            {
                Console.WriteLine(b);
            }
            Console.WriteLine();


            // q30
         
            var q30 = books.Chunk(2);
            foreach (var g in q30)
            {
                foreach (var b in g)
                {
                    Console.WriteLine(b);
                }
            }
            Console.WriteLine();


            // q31
          
            var q31 = books.Select(b => b.AuthorId).Distinct();
            foreach (var x in q31)
            {
                Console.WriteLine(x);
            }
            Console.WriteLine();



        }
    }
}
