using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaEval2
{
    class UnaryMasterParser : IFormulaParser
    {
        FormulaNode child;

        public UnaryMasterParser(FormulaNode child)
        {
            this.child = child;
        }

        public bool TryParse(string formula, out FormulaNode node)
        {
            if (new UnaryMinusParser(child).TryParse(formula,out node))
            {
                return true;
            }
            node = null;
            return false;
        }
    }
}
