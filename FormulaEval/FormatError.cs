using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaEval2
{
    sealed class FormatError : Error
    {
        private static FormatError instance;
        public override string Text { get => "Format Error"; }

        private FormatError() { }

        public static FormatError Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new FormatError();
                }
                return instance;
            }
        }
    }
}
