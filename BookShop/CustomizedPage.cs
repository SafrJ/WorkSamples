using System;

namespace BookShop
{
    abstract class CustomizedPage : IPage
    {
        protected Customer customer;

        public CustomizedPage (Customer customer)
        {
            this.customer = customer;
        }

        public abstract void Print();

        protected void PrintHead ()
        {
            Console.WriteLine(@"<!DOCTYPE html>");
            Console.WriteLine(@"<html lang=""en"" xmlns=""http://www.w3.org/1999/xhtml"">");
            Console.WriteLine(@"<head>");
            Console.WriteLine("\t" + @"<meta charset=""utf-8"" />");
            Console.WriteLine("\t" + @"<title>Nezarka.net: Online Shopping for Books</title>");
            Console.WriteLine(@"</head>");
            Console.WriteLine(@"<body>");
            Console.WriteLine("\t" + @"<style type=""text/css"">");
            Console.WriteLine("\t\t" + @"table, th, td {");
            Console.WriteLine("\t\t\t" + @"border: 1px solid black;");
            Console.WriteLine("\t\t\t" + @"border-collapse: collapse;");
            Console.WriteLine("\t\t" + @"}");
            Console.WriteLine("\t\t" + @"table {");
            Console.WriteLine("\t\t\t" + @"margin-bottom: 10px;");
            Console.WriteLine("\t\t" + @"}");
            Console.WriteLine("\t\t" + @"pre {");
            Console.WriteLine("\t\t\t" + @"line-height: 70%;");
            Console.WriteLine("\t\t" + @"}");
            Console.WriteLine("\t" + @"</style>");
            Console.WriteLine("\t" + @"<h1><pre>  v,<br />Nezarka.NET: Online Shopping for Books</pre></h1>");
            Console.WriteLine("\t" + customer.FirstName + ", here is your menu:");
            Console.WriteLine("\t" + @"<table>");
            Console.WriteLine("\t\t" + @"<tr>");
            Console.WriteLine("\t\t\t" + @"<td><a href=""/Books"">Books</a></td>");
            Console.WriteLine("\t\t\t" + @"<td><a href=""/ShoppingCart"">Cart (" + customer.ShoppingCart.Items.Count + ")</a></td>");
            Console.WriteLine("\t\t" + @"</tr>");
            Console.WriteLine("\t" + @"</table>");
        }
    }
}
