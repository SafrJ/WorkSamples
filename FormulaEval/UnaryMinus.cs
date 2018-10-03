using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaEval2
{
    sealed class UnaryMinus : UnaryOperationNode
    {

        public UnaryMinus(FormulaNode child) : base(child)
        {
        }     

        public override void Accept(IAlgorithm algorithm)
        {
            algorithm.Visit(this);
        }
    }
}
