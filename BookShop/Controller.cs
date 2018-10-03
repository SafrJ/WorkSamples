using System;

namespace BookShop
{
    class Controller
    {
        ModelStore modelStore;
        PagePrinter pagePrinter;

        public Controller(ModelStore modelStore, PagePrinter pagePrinter)
        {
            this.modelStore = modelStore;
            this.pagePrinter = pagePrinter;
        }

        public void ProcessCommand(string command)
        {
            try
            {
                string[] splitedCommand = command.Split(' ');
                {

                    if (splitedCommand[0] != "GET")
                    {
                        InvalidCommand();
                        return;
                    }

                    //Checks if customer exists
                    int customerId = int.Parse(splitedCommand[1]);
                    if (modelStore.GetCustomer(customerId) == null)
                    {
                        InvalidCommand();
                        return;
                    }

                    if (splitedCommand[2].StartsWith("http://www.nezarka.net/"))
                        splitedCommand[2] = splitedCommand[2].Remove(0, 23);
                    else
                    {
                        InvalidCommand();
                        return;
                    }


                    string[] splitedShortCommand = splitedCommand[2].Split('/');

                    switch (splitedShortCommand[0])
                    {
                        case "Books":
                            {
                                if (splitedShortCommand.Length == 1)
                                {
                                    ShowBooks(customerId);
                                    return;
                                }
                                if (splitedShortCommand.Length == 3)
                                {
                                    int bookId = int.Parse(splitedShortCommand[2]);
                                    if (modelStore.GetBook(bookId) == null)
                                    {
                                        InvalidCommand();
                                        return;
                                    }
                                    else
                                    {
                                        if (splitedShortCommand[1] == "Detail")
                                        {
                                            ShowBookDetail(customerId, bookId);
                                            return;
                                        }
                                    }
                                }
                                InvalidCommand();
                                return;
                            }
                        case "ShoppingCart":
                            {
                                if (splitedShortCommand.Length == 1)
                                {
                                    ShowShoppingCart(customerId);
                                    return;
                                }
                                if (splitedShortCommand.Length == 3)
                                {
                                    int bookId = int.Parse(splitedShortCommand[2]);
                                    if (modelStore.GetBook(bookId) == null)
                                    {
                                        InvalidCommand();
                                        return;
                                    }
                                    else
                                    {
                                        if (splitedShortCommand[1] == "Add")
                                        {
                                            AddToCart(customerId, bookId);
                                            return;
                                        }
                                        if (splitedShortCommand[1] == "Remove")
                                        {
                                            RemoveFromCart(customerId, bookId);
                                            return;
                                        }
                                    }
                                    InvalidCommand();
                                    return;
                                }
                                InvalidCommand();
                                return;
                            }
                        default:
                            InvalidCommand();
                            return;
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex is FormatException || ex is IndexOutOfRangeException)
                {
                    InvalidCommand();
                    return;
                }
                throw;
            }
        }

        private void RemoveFromCart(int customerId, int bookId)
        {
            if (!(modelStore.GetCustomer(customerId).ShoppingCart.RemoveBookFromCart(bookId)))
            {
                InvalidCommand();
            }
            else
                ShowShoppingCart(customerId);

        }

        private void AddToCart(int customerId, int bookId)
        {
            modelStore.GetCustomer(customerId).ShoppingCart.AddBookToCart(bookId);
            ShowShoppingCart(customerId);
        }

        private void InvalidCommand()
        {
            pagePrinter.ShowInvalidCommand();
        }

        private void ShowBooks(int customerId)
        {
            pagePrinter.ShowBooks(customerId);
        }

        private void ShowBookDetail(int customerId, int bookId)
        {
            pagePrinter.ShowBookDetail(customerId, bookId);
        }

        private void ShowShoppingCart(int customerId)
        {
            pagePrinter.ShowShoppingCart(customerId);
        }



    }
}
