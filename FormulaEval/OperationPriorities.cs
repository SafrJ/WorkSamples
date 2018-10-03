using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaEval2
{
    enum OperationPriorities
    {
        Init = -1,
        UnaryMinus = 10,
        Add = 0,
        Sub = 1,
        Mul = 5,
        Div = 6
    }
}
