using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketToRide
{
    class CardPile : ICardPile
    {
        List<ICard> cards;


        public CardPile()
        {
            cards = new List<ICard>();
        }

        public void AddCard(ICard card)
        {
            cards.Add(card);
        }

        //Vrátí vrchní kartu z balíčku a odstraní jí z něj
        public ICard DrawCard()
        {
            if (cards.Count > 0)
            {
                ICard card = cards[0];
                cards.RemoveAt(0);
                return card;
            }
            else
                return null;
        }

        public void Shuffle()
        {
            cards.Shuffle();
        }

        //Přidá do balíčku obsah discardpile a zamíchá karty
        public void Shuffle(ICardPile discardPile)
        {
            cards.AddRange(discardPile.GetCards());
            discardPile.Empty();
            cards.Shuffle();
        }

        public int GetCount()
        {
            return cards.Count;
        }

        public List<ICard> GetCards()
        {
            return cards;
        }

        //Vyprázdní balíček karet, karty smaže!!
        public void Empty()
        {
            cards = new List<ICard>();
        }

        public void RemoveCard (ICard card)
        {
            if (cards.Contains(card))
            {
                cards.Remove(card);
            }
        }

    }
}
