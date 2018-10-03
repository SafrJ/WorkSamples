using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaEval2
{
    interface ICommandProcessor
    {
        bool End { get; }
        void ProcessCommand(string formula);
    }
}
