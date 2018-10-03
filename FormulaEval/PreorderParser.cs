using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaEval2
{
    class PreorderParser : IFormulaParser
    {
        Stack<FormulaNode> stack;

        public PreorderParser()
        {
            stack = new Stack<FormulaNode>();
        }

        public bool TryParse(string formula, out FormulaNode node)
        {
            node = null;
            string[] splitedFormula = formula.Split(' ');
            List<String> formulaParts = splitedFormula.ToList<string>();

            while (formulaParts.Count != 0)
            {
                bool validFormat = false;
                if (new ConstantParser().TryParse(formulaParts[formulaParts.Count-1], out node))
                {
                    validFormat = true;
                    stack.Push(node);
                    formulaParts.RemoveAt(formulaParts.Count - 1);
                    continue;
                }
                if (new UnaryMasterParser(stack.Peek()).TryParse(formulaParts[formulaParts.Count - 1], out node))
                {
                    validFormat = true;
                    stack.Pop();
                    stack.Push(node);
                    formulaParts.RemoveAt(formulaParts.Count - 1);
                    continue;
                }
                if (new BinaryMasterParser(stack.Peek(),stack.ElementAt(1)).TryParse(formulaParts[formulaParts.Count - 1], out node))
                {
                    validFormat = true;
                    stack.Pop();
                    stack.Pop();
                    stack.Push(node);
                    formulaParts.RemoveAt(formulaParts.Count - 1);
                    continue;
                }

                if (!validFormat)
                {
                    return false;
                }
            }

            if (stack.Count == 1)
            {
                node = stack.Pop();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
