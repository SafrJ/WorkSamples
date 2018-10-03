using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaEval2
{
    class BinaryAddParser : IFormulaParser
    {
        FormulaNode leftNode;
        FormulaNode rightNode;

        public BinaryAddParser(FormulaNode leftNode, FormulaNode rightNode)
        {
            this.leftNode = leftNode;
            this.rightNode = rightNode;
        }

        public bool TryParse(string formula, out FormulaNode node)
        {
            if (formula == "+")
            {
                node = new BinaryAdd(leftNode, rightNode);
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
