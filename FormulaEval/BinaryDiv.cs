using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaEval2
{
    sealed class BinaryDiv : BinaryOperationNode
    {
        public BinaryDiv(FormulaNode leftChild, FormulaNode rightChild) : base(leftChild, rightChild)
        {
        }

        public override void Accept(IAlgorithm algorithm)
        {
            algorithm.Visit(this);
        }
    }
}
