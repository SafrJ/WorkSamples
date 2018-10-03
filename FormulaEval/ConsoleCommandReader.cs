using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaEval2
{
    class ConsoleCommandReader : ICommandReader
    {
        public string GetCommand()
        {
            return Console.ReadLine();
        }
    }
}
