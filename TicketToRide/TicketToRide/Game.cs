using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicketToRide
{
    class Game
    {
        CardPile cards;
        CardPile discarded;
        CardPile mainTasks;
        CardPile tasks;
        CardPile tasksDiscarded;
        List<Player> players;
        int activePlayer;
        List<ICard> cardsOnTable;
        GameVisualizer gv;
        int actionPoints;
        //List<City> cities;
        //Dictionary<string, City> cities;
        Map gameMap;
        bool firstRound;
        bool lastRound;

        public Task DrawTask()
        {
            return (Task)tasks.DrawCard();
        }

        public Game(GameForm form)
        {
            InputReader ir = new InputReader();

            this.gameMap = ir.GetMap();
            this.cards = ir.GetCards();
            this.discarded = new CardPile();
            this.mainTasks = ir.GetMainTasks();
            this.tasks = ir.GetTasks();
            this.tasksDiscarded = new CardPile();
            this.players = ir.GetPlayers();
            this.activePlayer = 0;
            this.cardsOnTable = new List<ICard>();
            this.gv = new GameVisualizer(form, this);
            this.actionPoints = 2;
            this.firstRound = true;
            this.lastRound = false;
        }

        public void StartGame()
        {
            //Zamicha startovni balicky
            this.cards.Shuffle();
            this.mainTasks.Shuffle();
            this.tasks.Shuffle();

            //Rozda karty hracum
            foreach (Player player in players)
            {
                for (int i = 0; i < 4; i++)
                {
                    player.GiveCard(cards.DrawCard());
                }
                player.GiveCard(mainTasks.DrawCard());
                for (int i = 0; i < 3; i++)
                {
                    player.GiveCard(tasks.DrawCard());
                }
            }

            //Vylozi na stul 5 vagonu
            for (int i = 0; i < 5; i++)
            {
                cardsOnTable.Add(cards.DrawCard());
            }

            //Zobrazi novinky na stole
            gv.FirstTurn();
        }

        public Player GetActivePlayer()
        {
            return players[activePlayer];
        }

        public List<ICard> GetCardsOnTable()
        {
            return cardsOnTable;
        }

        public void PlayerDiscardsCard (ICard card)
        {
            players[activePlayer].DiscardCard(card);
            discarded.AddCard(card);
            gv.UpdateTable();
        }

        public void PlayerDiscardsCard(CardColor color)
        {
            players[activePlayer].DiscardCard(color);
            discarded.AddCard(new Card(CardType.Wagon, color));
            gv.UpdateTable();
        }

        public void PlayerDrawsCard(int position)
        {
            ICard card = cardsOnTable[position];
            if ((card.GetCardColor() == CardColor.All))
            {
                if (actionPoints == 2)
                {
                    players[activePlayer].GiveCard(cardsOnTable[position]);
                    cardsOnTable[position] = cards.DrawCard();
                    actionPoints = 0;
                }
                else
                if (actionPoints == 1)
                {
                    MessageBox.Show("Už nemůžeš lízat lokomotivu", "Lokomotiva nelze líznout", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Už nemůžeš lízat kartu", "Karta nelze líznout", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            if ((card.GetCardColor() != CardColor.All))
            {
                if (actionPoints > 0)
                {
                    players[activePlayer].GiveCard(cardsOnTable[position]);
                    if (cards.GetCount() > 0)
                    {
                        cardsOnTable[position] = cards.DrawCard();
                    }
                    else
                    {
                        cards.Shuffle(discarded);
                        if (cards.GetCount() > 0)
                        {
                            cardsOnTable[position] = cards.DrawCard();
                        }
                    }
                    actionPoints--;
                }
                else
                    MessageBox.Show("Už nemůžeš lízat kartu", "Karta nelze líznout", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            gv.UpdateTable();

        }

        public void PlayerDrawsCardBlind()
        {
            if (actionPoints > 0)
            {
                if (cards.GetCount() > 0)
                {
                    ICard card = cards.DrawCard();
                    players[activePlayer].GiveCard(card);

                    if (card.GetCardColor() == CardColor.All)
                    {
                        actionPoints--;
                    }
                    actionPoints--;
                    gv.UpdateTable();
                }
                else
                {
                    cards.Shuffle(discarded);
                    if (cards.GetCount() == 0)
                        MessageBox.Show("Nejsou další karty", "Došly karty", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Už nemůžeš lízat kartu", "Karta nelze líznout", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void NextPlayer ()
        {
            if (players[activePlayer].GetWagonsCount() < 3)
            {
                lastRound = true;
            }
            actionPoints = 2;
            activePlayer++;
            activePlayer = activePlayer % players.Count;
            if (activePlayer == 0)
                firstRound = false;
            if (firstRound)
                gv.FirstTurn();
            else
            {
                if (!lastRound)
                    gv.NextPlayer();
                else
                {
                    if (activePlayer == 0)
                    {
                        EndGame();
                    }
                    else
                    {
                        gv.NextPlayer();
                    }
                }
                
            }
        }

        public int GetAP ()
        {
            return actionPoints;
        }

        public List<City> GetCities()
        {
            //List<City> result = new List<City>();
            //for (int i = 0; i < cities.Count; i++)
            //{
            //    result.Add(cities[i]);
            //}

            //return result;

            return gameMap.GetCities();
        }

        public Map GetGameMap()
        {
            return gameMap;
        }

        public bool FirstRound()
        {
            return firstRound;
        }

        public void BuildRail(Link link)
        {
            actionPoints = 0;
            players[activePlayer].AddPointsForBuild(link.GetLength());
            link.SetPlayerColor(players[activePlayer].GetPlayerColor());
            gv.UpdateTable();
        }

        public bool IsLastRound()
        {
            return lastRound;
        }

        public int[,] CountPoints()
        {
            int[,] result = new int[players.Count, 3];
            int i = 0;
            foreach (Player player in players)
            {
                result[i, 0] = player.GetPoints();
                List<City> playerCities = gameMap.CreateGraph(player.GetPlayerColor());
                result[i, 1] = CheckTasks(player, playerCities);
                if (LongestTrackOwner().Contains(player))
                {
                    result[i, 2] = 10;
                }
                else
                {
                    result[i, 2] = 0;
                }
                i++;
                
            }

            return result;
        }

        public List<Player> GetPlayers()
        {
            return players;
        }

        public List<Link> GetAvailibleLinks()
        {
            List<Link> result = new List<Link>();

            foreach (Link link in gameMap.GetFreeLinks())
            {
                switch (link.GetLinkColor())
                {
                    case CardColor.All:
                        if ((players[activePlayer].GetCardCount(CardColor.All) + (players[activePlayer].GetCardCount(CardColor.Pink))) >= link.GetLength())
                        {
                            result.Add(link);
                            break;
                        }
                        if ((players[activePlayer].GetCardCount(CardColor.All) + (players[activePlayer].GetCardCount(CardColor.Orange))) >= link.GetLength())
                        {
                            result.Add(link);
                            break;
                        }
                        if ((players[activePlayer].GetCardCount(CardColor.All) + (players[activePlayer].GetCardCount(CardColor.Black))) >= link.GetLength())
                        {
                            result.Add(link);
                            break;
                        }
                        if ((players[activePlayer].GetCardCount(CardColor.All) + (players[activePlayer].GetCardCount(CardColor.Blue))) >= link.GetLength())
                        {
                            result.Add(link);
                            break;
                        }
                        if ((players[activePlayer].GetCardCount(CardColor.All) + (players[activePlayer].GetCardCount(CardColor.Green))) >= link.GetLength())
                        {
                            result.Add(link);
                            break;
                        }
                        if ((players[activePlayer].GetCardCount(CardColor.All) + (players[activePlayer].GetCardCount(CardColor.Red))) >= link.GetLength())
                        {
                            result.Add(link);
                            break;
                        }
                        if ((players[activePlayer].GetCardCount(CardColor.All) + (players[activePlayer].GetCardCount(CardColor.White))) >= link.GetLength())
                        {
                            result.Add(link);
                            break;
                        }
                        if ((players[activePlayer].GetCardCount(CardColor.All) + (players[activePlayer].GetCardCount(CardColor.Yellow))) >= link.GetLength())
                        {
                            result.Add(link);
                            break;
                        }
                        break;
                    case CardColor.Pink:
                        if ((players[activePlayer].GetCardCount(CardColor.All) + (players[activePlayer].GetCardCount(CardColor.Pink))) >= link.GetLength())
                            result.Add(link);
                        break;
                    case CardColor.Orange:
                        if ((players[activePlayer].GetCardCount(CardColor.All) + (players[activePlayer].GetCardCount(CardColor.Orange))) >= link.GetLength())
                            result.Add(link);
                        break;
                    case CardColor.Red:
                        if ((players[activePlayer].GetCardCount(CardColor.All) + (players[activePlayer].GetCardCount(CardColor.Red))) >= link.GetLength())
                            result.Add(link);
                        break;
                    case CardColor.Black:
                        if ((players[activePlayer].GetCardCount(CardColor.All) + (players[activePlayer].GetCardCount(CardColor.Black))) >= link.GetLength())
                            result.Add(link);
                        break;
                    case CardColor.Green:
                        if ((players[activePlayer].GetCardCount(CardColor.All) + (players[activePlayer].GetCardCount(CardColor.Green))) >= link.GetLength())
                            result.Add(link);
                        break;
                    case CardColor.White:
                        if ((players[activePlayer].GetCardCount(CardColor.All) + (players[activePlayer].GetCardCount(CardColor.White))) >= link.GetLength())
                            result.Add(link);
                        break;
                    case CardColor.Yellow:
                        if ((players[activePlayer].GetCardCount(CardColor.All) + (players[activePlayer].GetCardCount(CardColor.Yellow))) >= link.GetLength())
                            result.Add(link);
                        break;
                    case CardColor.Blue:
                        if ((players[activePlayer].GetCardCount(CardColor.All) + (players[activePlayer].GetCardCount(CardColor.Blue))) >= link.GetLength())
                            result.Add(link);
                        break;
                    default:
                        break;
                }

            }

            return result;
        }

        private int CheckTasks(Player player, List<City> playerCities)
        {
            int result = 0;
            foreach (Task task in player.GetTasks().GetCards())
            {
                if (IsConected(task.GetFrom(), task.GetTo(), player.GetPlayerColor()))
                    result = result + task.GetPoints();
                else
                    result = result - task.GetPoints();
            }
            return result;
        }

        private List<Player> LongestTrackOwner()
        {
            List<Player> result = new List<Player>();

            int maxOfPlayers = 0;

            foreach (Player player in players)
            {
                int max = -1;
                foreach (City city in gameMap.CreateGraph(player.GetPlayerColor()))
                {
                    int pom = DFS(city, gameMap.GetColoredLinks(player.GetPlayerColor()), 0, new List<City>());

                    if (pom > max)
                        max = pom;
                }

                if (maxOfPlayers == max)
                {
                    result.Add(player);
                }
                else
                {
                    if (maxOfPlayers < max)
                    {
                        maxOfPlayers = max;
                        result.RemoveRange(0, result.Count);
                        result.Add(player);
                    }
                }
            }
            return result;
        }


        private int DFS(City city, List<Link> links, int lenght, List<City> visited)
        {
            visited.Add(city);
            int max = lenght;
            foreach (Link link in links)
            {
                int pom;

                if (link.GetFrom() == city && !visited.Contains(link.GetTo()))
                {
                    pom = DFS(link.GetTo(), links, lenght + link.GetLength(), visited);
                    if (max < pom)
                        max = pom;
                }
                if (link.GetTo() == city && !visited.Contains(link.GetFrom()))
                {
                    pom = DFS(link.GetFrom(), links, lenght + link.GetLength(), visited);
                    if (max < pom)
                        max = pom;
                }
            }

            return max;
        }
            


        

        public bool IsConected(City cityOne, City cityTwo, PlayerColor color)
        {
            gameMap.CreateGraph(color);
            Queue<City> queue = new Queue<City>();
            List<City> visited = new List<City>();

            queue.Enqueue(cityOne);
            visited.Add(cityOne);
            while (queue.Count != 0)
            {
                City city = queue.Dequeue();
                foreach (City newCity in city.GetNeighbors())
                {
                    if (newCity == cityTwo)
                    {
                        return true;
                    }
                    if (!visited.Contains(newCity))
                    {
                        queue.Enqueue(newCity);
                        visited.Add(newCity);
                    }
                }
            }
            return false;
        }
        
        void EndGame()
        {
            gv.ShowPoints(CountPoints());
        }

    }
}
