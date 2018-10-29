using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketToRide
{
    interface ICardPile
    {
        void AddCard(ICard card);
        ICard DrawCard();

        /// <summary>
        /// Vmíchá karty z discardPile do balíčku a smaže karty z discardPile
        /// </summary>
        /// <param name="discardPile"></param>
        void Shuffle(ICardPile discardPile);

        void Shuffle();

        int GetCount();

        List<ICard> GetCards();

        /// <summary>
        /// Smaže karty z balíčku
        /// </summary>
        void Empty();
    }
}
