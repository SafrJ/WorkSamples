using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketToRide
{
    class Player
    {
        PlayerColor color;
        int points;
        int wagons;
        string name;
        CardPile tasksPile;
        Dictionary<CardColor, int> wagonPile;

        public Player (PlayerColor color, string name)
        {
            this.points = 0;
            this.color = color;
            this.wagons = 45;
            this.name = name;
            this.wagonPile = new Dictionary<CardColor, int>();
            this.tasksPile = new CardPile();
        } 
        
        public string GetName()
        {
            return name;
        }

        public int GetCardCount(CardColor color)
        {
            if (wagonPile.ContainsKey(color))
                return wagonPile[color];
            else
                return 0;
        }

        public int GetWagonsCount ()
        {
            return wagons;
        }

        public void DecWagons(int number)
        {
            wagons = wagons - number;
        }

        public void GiveCard(ICard card)
        {
            switch (card.GetCardType())
            {
                case CardType.Locomotive:
                    if (!wagonPile.ContainsKey(CardColor.All))
                    {
                        wagonPile.Add(CardColor.All, 1);
                    }
                    else
                    {
                        wagonPile[CardColor.All]++;
                    }
                    break;
                case CardType.Wagon:
                    if (!wagonPile.ContainsKey(card.GetCardColor()))
                    {
                        wagonPile.Add(card.GetCardColor(), 1);
                    }
                    else
                    {
                        wagonPile[card.GetCardColor()]++;
                    }
                    break;
                case CardType.Task:
                    tasksPile.AddCard(card);
                    break;
                case CardType.MainTask:
                    tasksPile.AddCard(card);
                    break;
                default:
                    break;
            }
        }

        public void DiscardCard(CardColor color)
        {
            wagonPile[color]--;
        }


        public void DiscardCard (ICard card)
        {
            switch (card.GetCardType())
            {
                case CardType.Locomotive:
                    wagonPile[card.GetCardColor()]--;
                    break;
                case CardType.Wagon:
                    wagonPile[card.GetCardColor()]--;
                    break;
                case CardType.Task:
                    tasksPile.RemoveCard(card);
                    break;
                case CardType.MainTask:
                    tasksPile.RemoveCard(card);
                    break;
                default:
                    break;
            }
        }

        public CardPile GetTasks()
        {
            return tasksPile;
        }

        public void AddPoints (int points)
        {
            this.points = this.points + points;
        }

        public void AddPointsForBuild(int wayLenght)
        {
            switch (wayLenght)
            {
                case 1:
                    this.points = this.points + 1;
                    break;
                case 2:
                    this.points = this.points + 2;
                    break;
                case 3:
                    this.points = this.points + 4;
                    break;
                case 4:
                    this.points = this.points + 7;
                    break;
                case 6:
                    this.points = this.points + 15;
                    break;
                case 8:
                    this.points = this.points + 21;
                    break;
                default:
                    break;
            }

            DecWagons(wayLenght);
        }

        public PlayerColor GetPlayerColor()
        {
            return color;
        }

        public int GetPoints()
        {
            return points;
        }
    }
}
