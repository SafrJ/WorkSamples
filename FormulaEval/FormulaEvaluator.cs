using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaEval2
{
    class FormulaEvaluator
    {
        static ICommandReader reader;
        static ICommandProcessor processor;

        static void Main(string[] args)
        {
            InitReader();
            InitProcessor();
            GetAndProcessInput();
        }

        private static void InitProcessor()
        {
            processor = new CommandProcessor(new ConsoleResultWriter());
        }

        private static void InitReader()
        {
            reader = new ConsoleCommandReader();
        }

        private static void GetAndProcessInput()
        {
           while (!processor.End)
           {
                processor.ProcessCommand(reader.GetCommand());
           }
        }
    }
}
