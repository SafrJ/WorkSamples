using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaEval2
{
    interface IAlgorithm
    {
        void Visit(ConstantNode node);
        void Visit(UnaryMinus node);
        void Visit(BinaryAdd node);
        void Visit(BinarySub node);
        void Visit(BinaryMul node);
        void Visit(BinaryDiv node);

        void CallResultWriter(IResultWriter writer);
    }
}
