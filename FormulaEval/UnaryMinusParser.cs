using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaEval2
{
    class UnaryMinusParser : IFormulaParser
    {
        FormulaNode number;

        public UnaryMinusParser(FormulaNode node)
        {
            number = node;
        }

        public bool TryParse(string formula, out FormulaNode node)
        {
            if (formula == "~")
            {
                node = new UnaryMinus(number);
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
