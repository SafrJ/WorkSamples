using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaEval2
{
    interface IFormulaParser
    {
        bool TryParse(string formula, out FormulaNode node);
    }
}
