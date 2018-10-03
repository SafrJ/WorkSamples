using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectorSerizalizer
{
    public interface ISerializer
    {
        int IndentSpaceCount { set; }
        bool TreatStringAsEnumerable { set; }
        void Serialize(System.IO.TextWriter writer, object graph);
    }
}
