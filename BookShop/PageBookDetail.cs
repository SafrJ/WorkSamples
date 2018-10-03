using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop
{
    class PageBookDetail : CustomizedPage
    {
        Book book;

        public PageBookDetail(Customer customer, Book book) : base (customer)
        {
            this.book = book;
        }

        public override void Print()
        {
            PrintHead();

            Console.WriteLine("\tBook details:");
            Console.WriteLine("\t<h2>" + book.Title + "</h2>");
            Console.WriteLine("\t" + @"<p style=""margin-left: 20px"">");
            Console.WriteLine("\tAuthor: " + book.Author + "<br />");
            Console.WriteLine("\tPrice: " + book.Price + " EUR<br />");
            Console.WriteLine("\t</p>");
            Console.WriteLine("\t" + @"<h3>&lt;<a href=""/ShoppingCart/Add/" + book.Id + @""">Buy this book</a>&gt;</h3>");
            Console.WriteLine("</body>");
            Console.WriteLine("</html>");
        }
    }
}
