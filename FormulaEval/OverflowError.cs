using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaEval2
{
    sealed class OverflowError : Error
    {
        private static OverflowError instance;
        public override string Text { get => "Overflow Error"; }

        private OverflowError() { }

        public static OverflowError Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new OverflowError();
                }
                return instance;
            }
        }
    }
}
