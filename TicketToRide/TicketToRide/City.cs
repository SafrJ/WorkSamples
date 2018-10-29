using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketToRide
{
    class City
    {
        string name;
        Tuple<int,int> coords;
        int id;
        List<City> neighbors;

        public City(string name, int x, int y, int id)
        {
            this.name = name;
            this.coords = new Tuple<int, int>(x, y);
            this.id = id;
            this.neighbors = new List<City>();
        }

        public override string ToString()
        {
            return name;
        }

        public Tuple<int,int> GetCoords()
        {
            return coords;
        }

        public int GetId()
        {
            return id;
        }

        public void AddNeighbor (City city)
        {
            neighbors.Add(city);
        }

        public List<City> GetNeighbors()
        {
            return neighbors;
        }

        public void ClearNeighbors()
        {
            neighbors = new List<City>();
        }

    }
}
