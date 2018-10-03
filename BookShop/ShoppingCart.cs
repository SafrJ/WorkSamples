using System.Collections.Generic;


namespace BookShop
{
    class ShoppingCart
    {
        public int CustomerId { get; set; }
        public List<ShoppingCartItem> Items = new List<ShoppingCartItem>();

        public void AddBookToCart (int bookId)
        {
            ShoppingCartItem cartItem;
            if ((cartItem = Items.Find(item => item.BookId == bookId)) == null)
            {
                Items.Add(new ShoppingCartItem() { BookId = bookId, Count = 1 });
            }
            else
            {
                cartItem.Count++;
            }

        }

        public bool RemoveBookFromCart(int bookId)
        {
            ShoppingCartItem cartItem;
            if ((cartItem = Items.Find(item => item.BookId == bookId)) == null)
            {
                return false;
            }
            else
            {
                cartItem.Count--;
                if (cartItem.Count == 0)
                {
                    Items.Remove(cartItem);
                }

                return true;
            }
        }

    }
}
