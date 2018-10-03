using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaEval2
{
    abstract class FormulaNode
    {
        public abstract void Accept(IAlgorithm algorithm);
    }
}
