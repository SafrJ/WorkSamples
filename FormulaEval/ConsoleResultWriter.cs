using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaEval2
{
    class ConsoleResultWriter : IResultWriter
    {
        public void WriteResult(int result)
        {
            Console.WriteLine(result.ToString());
        }

        public void WriteError(Error error)
        {
            Console.WriteLine(error.Text);
        }

        public void WriteResult(double result)
        {
            Console.WriteLine(result.ToString("f05"));
        }

        public void WriteResult(string result)
        {
            Console.WriteLine(result);
        }
    }
}
