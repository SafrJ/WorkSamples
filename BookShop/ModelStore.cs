using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BookShop
{
    class ModelStore
    {
        private List<Book> books = new List<Book>();
        private List<Customer> customers = new List<Customer>();

        public List<Book> GetBooks()
        {
            return books;
        }

        public Book GetBook(int id)
        {
            return books.Find(b => b.Id == id);
        }

        public Customer GetCustomer(int id)
        {
            return customers.Find(c => c.Id == id);
        }

        public static ModelStore LoadFrom(TextReader reader)
        {
            var store = new ModelStore();

            try
            {
                if (reader.ReadLine() != "DATA-BEGIN")
                {
                    return null;
                }
                while (true)
                {
                    string line = reader.ReadLine();
                    if (line == null)
                    {
                        return null;
                    }
                    else if (line == "DATA-END")
                    {
                        break;
                    }

                    string[] tokens = line.Split(';');
                    switch (tokens[0])
                    {
                        case "BOOK":
                            {
                                int id = int.Parse(tokens[1]);
                                string title = tokens[2];
                                string author = tokens[3];
                                decimal price = decimal.Parse(tokens[4]);

                                if ((id < 0) || (price < 0))
                                    return null;
                                store.books.Add(new Book
                                {
                                    Id = id,
                                    Title = title,
                                    Author = author,
                                    Price = price
                                });
                            }
                            break;
                        case "CUSTOMER":
                            {
                                int id = int.Parse(tokens[1]);
                                if (id < 0)
                                    return null;

                                store.customers.Add(new Customer
                                {
                                    Id = id,
                                    FirstName = tokens[2],
                                    LastName = tokens[3]
                                });
                            }
                            break;
                        case "CART-ITEM":


                            var customer = store.GetCustomer(int.Parse(tokens[1]));
                            int bookId = int.Parse(tokens[2]);
                            int count = int.Parse(tokens[3]);
                            var book = store.GetBook(bookId);
                            if (customer == null || book == null || count < 1)
                            {
                                return null;
                            }

                            customer.ShoppingCart.Items.Add(new ShoppingCartItem
                            {
                                BookId = bookId,
                                Count = count
                            });
                            break;
                        default:
                            return null;
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex is FormatException || ex is IndexOutOfRangeException)
                {
                    return null;
                }
                throw;
            }

            return store;
        }
    }
}
