using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketToRide
{
    class AdjacencyMatrix
    {
        List<Link> links;
        int[,] matrix;
        int size;

        public AdjacencyMatrix (PlayerColor color, List<Link> links, int size)
        {
            this.size = size;
            this.links = new List<Link>();
            foreach (Link link in links)
            {
                if ((PlayerColor)link.GetPlayerColor() == color)
                {
                    this.links.Add(link);
                }
            }

            matrix = new int[size, size];

            foreach (Link link in this.links)
            {
                matrix[link.GetFrom().GetId(), link.GetTo().GetId()] = link.GetLength();
                matrix[link.GetTo().GetId(), link.GetFrom().GetId()] = link.GetLength();
            }
        }        
    }
}
