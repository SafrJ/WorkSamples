using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaEval2
{
    class BinarySubParser : IFormulaParser
    {
        FormulaNode leftNode;
        FormulaNode rightNode;

        public BinarySubParser(FormulaNode leftNode, FormulaNode rightNode)
        {
            this.leftNode = leftNode;
            this.rightNode = rightNode;
        }

        public bool TryParse(string formula, out FormulaNode node)
        {
            if (formula == "-")
            {
                node = new BinarySub(leftNode, rightNode);
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
