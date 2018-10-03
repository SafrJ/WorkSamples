using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaEval2
{
    sealed class DivisionError : Error
    {
        private static DivisionError instance;
        public override string Text { get => "Divide Error"; }

        private DivisionError() {}

        public static DivisionError Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DivisionError();
                }
                return instance;
            }
        }

    }
}
