using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaEval2
{
    class BinaryMasterParser : IFormulaParser
    {
        FormulaNode leftNode;
        FormulaNode rightNode;

        public BinaryMasterParser(FormulaNode leftNode, FormulaNode rightNode)
        {
            this.leftNode = leftNode;
            this.rightNode = rightNode;
        }

        public bool TryParse(string formula, out FormulaNode node)
        {
            if (new BinaryAddParser(leftNode,rightNode).TryParse(formula,out node))
            {
                return true;
            }
            if (new BinarySubParser(leftNode, rightNode).TryParse(formula, out node))
            {
                return true;
            }
            if (new BinaryMulParser(leftNode, rightNode).TryParse(formula, out node))
            {
                return true;
            }
            if (new BinaryDivParser(leftNode, rightNode).TryParse(formula, out node))
            {
                return true;
            }

            node = null;
            return false;
        }
    }
}
