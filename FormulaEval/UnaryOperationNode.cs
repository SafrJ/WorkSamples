using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaEval2
{
    abstract class UnaryOperationNode : OperationNode
    {
        protected FormulaNode child;
        public FormulaNode Child { get { return child; } }

        public UnaryOperationNode(FormulaNode child)
        {
            this.child = child;
        }
    }
}
