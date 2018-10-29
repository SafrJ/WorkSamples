using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketToRide
{
    class Card : ICard
    {
        CardType type;
        CardColor color;

        public Card(CardType type, CardColor color)
        {
            this.type = type;
            this.color = color;
        }

        public Card(CardType type)
        {
            this.type = type;
        }

        public CardType GetCardType()
        {
            return type;
        }

        public CardColor GetCardColor()
        {
            return color;
        }

        public override string ToString()
        {
            if (type == CardType.Locomotive)
            {
                return "Locomotive";
            }
            else
                return color.ToString() + " " + type.ToString();
        }
    }
}
