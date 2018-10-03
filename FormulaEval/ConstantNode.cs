using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaEval2
{
    class ConstantNode : FormulaNode
    {
        int value;

        public int Value { get => value; }

        public ConstantNode(int value)
        {
            this.value = value;
        }

        public override void Accept(IAlgorithm algorithm)
        {
            algorithm.Visit(this);
        }
    }
}
