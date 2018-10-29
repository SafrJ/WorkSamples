using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace TicketToRide
{
    class Link
    {
        City from;
        City to;
        LinkType type;
        int length;
        CardColor color;
        PlayerColor? player;


        public Link(City from, City to, LinkType type, int length, int color)
        {
            this.from = from;
            this.to = to;
            this.type = type;
            this.length = length;
            this.color = (CardColor)(color);
            this.player = null;
        }

        public void SetPlayerColor(int color)
        {
            player = (PlayerColor)(color);
        }

        public int GetPlayerColor()
        {
            if (player != null)
                return (int)(player);
            else
                return 5;
        }

        public City GetFrom()
        {
            return from;
        }

        public City GetTo()
        {
            return to;
        }

        public System.Drawing.Brush GetBrushColor()
        {
            if (player == null)
            {
                switch (color)
                {
                    case CardColor.All:
                        return System.Drawing.Brushes.Gray;
                    case CardColor.Pink:
                        return System.Drawing.Brushes.Pink;
                    case CardColor.Orange:
                        return System.Drawing.Brushes.Orange;
                    case CardColor.Red:
                        return System.Drawing.Brushes.Red;
                    case CardColor.Black:
                        return System.Drawing.Brushes.Black;
                    case CardColor.Green:
                        return System.Drawing.Brushes.Green;
                    case CardColor.White:
                        return System.Drawing.Brushes.LightGray;
                    case CardColor.Yellow:
                        return System.Drawing.Brushes.Yellow;
                    case CardColor.Blue:
                        return System.Drawing.Brushes.Blue;
                }

                return System.Drawing.Brushes.DarkKhaki;
            }

            else
            {
                switch (player)
                {
                    case PlayerColor.Black:
                        return System.Drawing.Brushes.Black;
                    case PlayerColor.Blue:
                        return System.Drawing.Brushes.Blue;
                    case PlayerColor.Green:
                        return System.Drawing.Brushes.Green;
                    case PlayerColor.Red:
                        return System.Drawing.Brushes.Red;
                    case PlayerColor.Yellow:
                        return System.Drawing.Brushes.Yellow;
                }
                return System.Drawing.Brushes.DarkKhaki;

            }

        }

        public LinkType GetLinkType()
        {
            return type;
        }
        
        public int GetLength()
        {
            return length;
        }

        public override string ToString()
        {
            string result = from.ToString() + " - " + to.ToString() + " s barvou " + color.ToString() + " a délkou " + length.ToString();
            return result;
        }

        public void SetPlayerColor (PlayerColor color)
        {
            player = color;
        }

        public CardColor GetLinkColor()
        {
            return color;
        }
    }

    
}

