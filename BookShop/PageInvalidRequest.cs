using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop
{
    class PageInvalidRequest : IPage
    {
        public void Print()
        {
            Console.WriteLine("<!DOCTYPE html>");
            Console.WriteLine(@"<html lang=""en"" xmlns=""http://www.w3.org/1999/xhtml"">");
            Console.WriteLine("<head>");
            Console.WriteLine("\t" + @"<meta charset=""utf-8"" />");
            Console.WriteLine("\t<title>Nezarka.net: Online Shopping for Books</title>");
            Console.WriteLine("</head>");
            Console.WriteLine("<body>");
            Console.WriteLine("<p>Invalid request.</p>");
            Console.WriteLine("</body>");
            Console.WriteLine("</html>");
        }
    }
}
