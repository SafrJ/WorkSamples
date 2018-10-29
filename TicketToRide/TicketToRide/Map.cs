using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketToRide
{
    class Map
    {
        List<City> cities;
        List<Link> links;

        public Map(List<City> cities, List<Link> links)
        {
            this.cities = cities;
            this.links = links;
        }


        public List<City> GetCities()
        {
            return cities;
        }

        public List<Link> GetLinks()
        {
            return links;
        }

        public List<Link> GetFreeLinks()
        {
            List<Link> result = new List<Link>();

            foreach (Link link in links)
            {
                if (link.GetPlayerColor() == 5)
                {
                    result.Add(link);
                }
            }

            return result;
        }

        public List<Link> GetColoredLinks (PlayerColor color)
        {
            List<Link> result = new List<Link>();

            foreach (Link link in links)
            {
                if (link.GetPlayerColor() == (int)color)
                {
                    result.Add(link);
                }
            }

            return result;
        }

        public List<City> CreateGraph(PlayerColor color)
        {
            foreach (City city in cities)
            {
                city.ClearNeighbors();
            }

            foreach (Link link in links)
            {
                if (link.GetPlayerColor() == (int)color)
                {
                    link.GetFrom().AddNeighbor(link.GetTo());
                    link.GetTo().AddNeighbor(link.GetFrom());
                }
            }

            return cities;
        }

        public List<Link> GetLinks(PlayerColor color)
        {
            List<Link> result = new List<Link>();
            foreach (Link link in links)
            {
                if (link.GetPlayerColor() == (int)color)
                {
                    result.Add(link);
                }
            }

            return result;
        }
    }
}
