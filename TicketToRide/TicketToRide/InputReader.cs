using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Reflection;

namespace TicketToRide
{
    class InputReader
    {
        StreamReader sr;
        CardPile cards;
        CardPile mainTasks;
        CardPile tasks;
        List<City> cities;
        Dictionary<string, City> citiesNames;
        List<Link> links;

        //Dictionary<string, City> cities;
        Stream stream;

        public InputReader()
        {
            this.cards = new CardPile();
            this.mainTasks = new CardPile();
            this.tasks = new CardPile();
            this.citiesNames = new Dictionary<string, City>();
            this.cities = new List<City>();
            this.links = new List<Link>();

            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = "TicketToRide.Resources.input.txt";

            this.stream = assembly.GetManifestResourceStream(resourceName);
            this.sr = new StreamReader(stream);

            ReadInput();
        }

        private void ReadInput()
        {
            int cities = 0;

            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                if (line[0] == 'T')
                {
                    AddTask(line);
                }
                else
                {
                    if (line[0] == 'M')
                    {
                        AddMainTask(line);
                    }
                    else
                    {
                        if (line[0] == 'W' || line[0] == 'L')
                        {
                            AddCard(line);
                        }
                        else
                        {
                            if (line[0] == 'C')
                            {
                                AddCity(line, cities);
                                cities++;
                            }
                            else
                            {
                                if (line[0] == 'R')
                                {
                                    AddLink(line);
                                }
                            }
                        }
                    }
                }
            }

        }

        void AddCity(string line, int id)
        {
            string[] lines = line.Split(' ');

            City newCity = new City(lines[1], int.Parse(lines[2]), int.Parse(lines[3]), id);
            cities.Add(newCity);
            citiesNames.Add(lines[1], newCity);
        }

        void AddCard(string line)
        {
            string[] lines = line.Split(' ');
            int number;
            switch (lines[0])
            {
                case "L":
                    if (int.TryParse(lines[1], out number))
                    {
                        for (int i = 0; i < number; i++)
                        {
                            cards.AddCard(new Card(CardType.Locomotive, CardColor.All));
                        }
                    }
                    break;
                case "W":
                    {
                        switch (lines[1])
                        {

                            case "P":
                                if (int.TryParse(lines[2], out number))
                                {
                                    for (int i = 0; i < number; i++)
                                    {
                                        cards.AddCard(new Card(CardType.Wagon, CardColor.Pink));
                                    }
                                }
                                break;
                            case "O":
                                if (int.TryParse(lines[2], out number))
                                {
                                    for (int i = 0; i < number; i++)
                                    {
                                        cards.AddCard(new Card(CardType.Wagon, CardColor.Orange));
                                    }
                                }
                                break;
                            case "R":
                                if (int.TryParse(lines[2], out number))
                                {
                                    for (int i = 0; i < number; i++)
                                    {
                                        cards.AddCard(new Card(CardType.Wagon, CardColor.Red));
                                    }
                                }
                                break;
                            case "K":
                                if (int.TryParse(lines[2], out number))
                                {
                                    for (int i = 0; i < number; i++)
                                    {
                                        cards.AddCard(new Card(CardType.Wagon, CardColor.Black));
                                    }
                                }
                                break;
                            case "G":
                                if (int.TryParse(lines[2], out number))
                                {
                                    for (int i = 0; i < number; i++)
                                    {
                                        cards.AddCard(new Card(CardType.Wagon, CardColor.Green));
                                    }
                                }
                                break;
                            case "W":
                                if (int.TryParse(lines[2], out number))
                                {
                                    for (int i = 0; i < number; i++)
                                    {
                                        cards.AddCard(new Card(CardType.Wagon, CardColor.White));
                                    }
                                }
                                break;
                            case "Y":
                                if (int.TryParse(lines[2], out number))
                                {
                                    for (int i = 0; i < number; i++)
                                    {
                                        cards.AddCard(new Card(CardType.Wagon, CardColor.Yellow));
                                    }
                                }
                                break;
                            case "B":
                                if (int.TryParse(lines[2], out number))
                                {
                                    for (int i = 0; i < number; i++)
                                    {
                                        cards.AddCard(new Card(CardType.Wagon, CardColor.Blue));
                                    }
                                }
                                break;
                        }
                        break;
                    }

            }
        }

        void AddMainTask(string line)
        {
            string[] lines = line.Split(' ');
            City firstCity;
            City secondCity;
            firstCity = citiesNames[lines[1]];
            secondCity = citiesNames[lines[2]];
            int points;
            if (int.TryParse(lines[3], out points))
                mainTasks.AddCard(new Task(firstCity, secondCity, points, CardType.MainTask));

        }

        void AddTask(string line)
        {
            string[] lines = line.Split(' ');
            City firstCity;
            City secondCity;
            firstCity = citiesNames[lines[1]];
            secondCity = citiesNames[lines[2]];
            int points;
            if (int.TryParse(lines[3], out points))
                tasks.AddCard(new Task(firstCity, secondCity, points, CardType.Task));
        }

        void AddLink (string line)
        {
            string[] lines = line.Split(' ');
            switch (line[2])
            {
                case 'R':
                    links.Add(new Link(citiesNames[lines[2]], citiesNames[lines[3]], LinkType.Rail, int.Parse(lines[4]), int.Parse(lines[5])));
                    break;
                case 'S':
                    links.Add(new Link(citiesNames[lines[2]], citiesNames[lines[3]], LinkType.Ship, int.Parse(lines[4]), int.Parse(lines[5])));
                    break;
                case 'T':
                    links.Add(new Link(citiesNames[lines[2]], citiesNames[lines[3]], LinkType.Tunnel, int.Parse(lines[4]), int.Parse(lines[5])));
                    break;
            }
        }

        public CardPile GetCards()
        {
            return cards;
        }

        public CardPile GetMainTasks()
        {
            return mainTasks;
        }

        public CardPile GetTasks()
        {
            return tasks;
        }

        public List<City> GetCities()
        {
            return cities;
        }
        public List<Player> GetPlayers()
        {
            List<Player> players = new List<Player>();

            int numPlayers = Settings.NumOfPlayers();
            for (int i = 0; i < numPlayers; i++)
            {
                players.Add(new Player((PlayerColor)(i), Settings.PlayerName(i)));
            }

            return players;
        }


        public Map GetMap()
        {
            Map gameMap = new Map(cities, links);

            return gameMap;
        }
    }
    
}
