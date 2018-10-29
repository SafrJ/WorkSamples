using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketToRide
{
    class Task : ICard
    {
        City from;
        City to;
        int points;
        CardType type;

        public Task(City from, City to, int points, CardType type)
        {
            this.type = type;
            this.from = from;
            this.to = to;
            this.points = points;
        }

        public CardType GetCardType()
        {
            return type;
        }

        public CardColor GetCardColor()
        {
            return CardColor.All;
        }

        public City GetFromName()
        {
            return from;
        }

        public City GetTo()
        {
            return to;
        }

        public City GetFrom()
        {
            return from;
        }

        public int GetPoints()
        {
            return points;
        }

        public override string ToString()
        {
            return "Cesta z " + from.ToString() + " do " + to.ToString() + " za " + points.ToString() + " bodů.";
        }
    }
}
