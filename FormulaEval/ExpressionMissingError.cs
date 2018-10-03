using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaEval2
{
    sealed class ExpressionMissingError : Error
    {
        private static ExpressionMissingError instance;
        public override string Text { get => "Expression Missing"; }

        private ExpressionMissingError() { }

        public static ExpressionMissingError Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ExpressionMissingError();
                }
                return instance;
            }
        }
    }
}
