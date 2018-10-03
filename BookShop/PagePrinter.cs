using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop
{
    class PagePrinter
    {
        ModelStore modelStore;

        public PagePrinter(ModelStore modelStore)
        {
            this.modelStore = modelStore;
        }

        public void ShowInvalidCommand()
        {
            new PageInvalidRequest().Print();
        }

        public void ShowBooks(int customerId)
        {
            new PageBooks(modelStore.GetCustomer(customerId), modelStore.GetBooks()).Print();
        }

        public void ShowBookDetail(int customerId, int bookId)
        {
            new PageBookDetail(modelStore.GetCustomer(customerId), modelStore.GetBook(bookId)).Print();
        }

        public void ShowShoppingCart(int customerId)
        {
            new PageCart(modelStore.GetCustomer(customerId), modelStore.GetBooks()).Print();
        }

    }
}
