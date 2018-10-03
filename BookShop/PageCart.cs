using System;
using System.Collections.Generic;

namespace BookShop
{
    class PageCart : CustomizedPage
    {
        List<Book> books;
        decimal totalPrice = 0;

        public PageCart(Customer customer, List<Book> books) : base(customer)
        {
            this.books = books;
        }

        public override void Print()
        {
            PrintHead();

            if (customer.ShoppingCart.Items.Count == 0)
            {
                Console.WriteLine("\tYour shopping cart is EMPTY.");
            }
            else
            {
                Console.WriteLine("\tYour shopping cart:");
                PrintItems(customer.ShoppingCart.Items);
            }

            Console.WriteLine("</body>");
            Console.WriteLine("</html>");
        }

        private void PrintItems(List<ShoppingCartItem> items)
        {
            Console.WriteLine("\t<table>");
            Console.WriteLine("\t\t<tr>");
            Console.WriteLine("\t\t\t<th>Title</th>");
            Console.WriteLine("\t\t\t<th>Count</th>");
            Console.WriteLine("\t\t\t<th>Price</th>");
            Console.WriteLine("\t\t\t<th>Actions</th>");
            Console.WriteLine("\t\t</tr>");

            foreach (var oneItem in items)
            {
                PrintItem(oneItem);
            }

            Console.WriteLine("\t</table>");
            Console.WriteLine("\tTotal price of all items: " + totalPrice + " EUR");
        }

        private void PrintItem(ShoppingCartItem item)
        {
            Book book = books.Find(b => b.Id == item.BookId);

            Console.WriteLine("\t\t<tr>");
            Console.WriteLine("\t\t\t" + @"<td><a href=""/Books/Detail/" + book.Id + @""">" + book.Title + "</a></td>");
            Console.WriteLine("\t\t\t<td>" + item.Count + "</td>");

            PrintPrice(item.Count, book.Price);

            Console.WriteLine("\t\t\t" + @"<td>&lt;<a href=""/ShoppingCart/Remove/" + book.Id + @""">Remove</a>&gt;</td>");
            Console.WriteLine("\t\t</tr>");
        }

        private void PrintPrice(int count, decimal price)
        {
            if (count == 1)
            {
                Console.WriteLine("\t\t\t<td>" + price + " EUR</td>");
                totalPrice += price;
            }
            else
            {
                Console.WriteLine("\t\t\t<td>" + count + " * " + price + " = " + count*price +" EUR</td>");
                totalPrice += (price * count);
            }
        }
    }
}
