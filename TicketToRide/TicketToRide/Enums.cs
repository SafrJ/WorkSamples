using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketToRide
{
    public enum CardType : byte { Locomotive, Wagon, Task, MainTask };
    public enum CardColor : byte { All, Pink, Orange, Red, Black, Green, White, Yellow, Blue };
    public enum PlayerColor : byte { Blue, Red, Black, Yellow, Green, None };
    public enum LinkType : byte { Rail, Ship, Tunnel };
}
