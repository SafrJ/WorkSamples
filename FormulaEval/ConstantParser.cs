using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaEval2
{
    class ConstantParser : IFormulaParser
    {
        public bool TryParse(string formula, out FormulaNode node)
        {
            int value;
            if (int.TryParse(formula, out value))
            {
                node = new ConstantNode(value);
                return true;
            }
            else
            {
                node = null;
                return false;
            }
        }
    }
}
