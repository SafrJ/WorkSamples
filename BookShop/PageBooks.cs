using System;
using System.Collections.Generic;

namespace BookShop
{
    class PageBooks : CustomizedPage
    {
        List<Book> books;

        public PageBooks(Customer customer, List<Book> books) : base (customer)
        {
            this.books = books;
        }

        public override void Print()
        {
            PrintHead();
            
            Console.WriteLine("\t" + @"Our books for you:");
            Console.WriteLine("\t" + @"<table>");

            PrintBooks(books);

            Console.WriteLine("\t" + @"</table>");
            Console.WriteLine(@"</body>");
            Console.WriteLine(@"</html>");
        }

        private void PrintBooks(IList<Book> books)
        {
            int i = 0;

            foreach (var book in books)
            {
                //First book in a row
                if (i % 3 == 0)
                {
                    Console.WriteLine("\t\t" + @"<tr>");
                }

                PrintBook(book);

                //Last book in a row
                if (i % 3 == 2)
                {
                    Console.WriteLine("\t\t" + @"</tr>");
                }

                i++;
            }

            if (i % 3 != 0)
            {
                Console.WriteLine("\t\t" + @"</tr>");
            }
        }

        private void PrintBook(Book book)
        {
            Console.WriteLine("\t\t\t" + @"<td style=""padding: 10px;"">");
            Console.WriteLine("\t\t\t\t" + @"<a href=""/Books/Detail/" + book.Id + @""">" + book.Title + "</a><br />");
            Console.WriteLine("\t\t\t\t" + @"Author: " + book.Author + "<br />");
            Console.WriteLine("\t\t\t\t" + @"Price: " + book.Price + @" EUR &lt;<a href=""/ShoppingCart/Add/" + book.Id + @""">Buy</a>&gt;");
            Console.WriteLine("\t\t\t" + @"</td>");
        }
    }
}
 