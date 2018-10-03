using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaEval2
{
    interface IResultWriter
    {
        void WriteResult(int result);
        void WriteResult(double result);
        void WriteResult(string result);
        void WriteError(Error error);
    }
}
