using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaEval2
{
    abstract class OperationNode : FormulaNode
    {
        public abstract override void Accept(IAlgorithm algorithm);
    }
}
