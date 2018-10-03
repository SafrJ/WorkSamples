using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaEval2
{
    class DoubleCalculator : IAlgorithm
    {
        Stack<double> results;
        double? cachedResult;

        public DoubleCalculator()
        {
            this.results = new Stack<double>();
            cachedResult = null;
        }

        public void Visit(ConstantNode node)
        {
            if (!cachedResult.HasValue)
            {
                results.Push(node.Value);
            }
        }

        public void Visit(UnaryMinus node)
        {
            if (!cachedResult.HasValue)
            {
                node.Child.Accept(this);

                double value = results.Pop();

                results.Push(value * -1);
            }

        }

        public void Visit(BinaryAdd node)
        {
            if (!cachedResult.HasValue)
            {
                node.LeftChild.Accept(this);
                node.RightChild.Accept(this);

                double valueTwo = results.Pop();
                double valueOne = results.Pop();

                checked
                {
                    results.Push(valueOne + valueTwo);
                }
            }
        }

        public void Visit(BinarySub node)
        {
            if (!cachedResult.HasValue)
            {
                node.LeftChild.Accept(this);
                node.RightChild.Accept(this);

                double valueTwo = results.Pop();
                double valueOne = results.Pop();

                checked
                {
                    results.Push(valueOne - valueTwo);
                }
            }
        }

        public void Visit(BinaryMul node)
        {
            if (!cachedResult.HasValue)
            {
                node.LeftChild.Accept(this);
                node.RightChild.Accept(this);

                double valueTwo = results.Pop();
                double valueOne = results.Pop();

                checked
                {
                    results.Push(valueOne * valueTwo);
                }
            }
        }

        public void Visit(BinaryDiv node)
        {
            if (!cachedResult.HasValue)
            {
                node.LeftChild.Accept(this);
                node.RightChild.Accept(this);

                double valueTwo = results.Pop();
                double valueOne = results.Pop();

                checked
                {
                    results.Push(valueOne / valueTwo);
                }
            }
        }

        public void CallResultWriter(IResultWriter writer)
        {
            if (!cachedResult.HasValue)
            {
                cachedResult = results.Pop();
            }

            writer.WriteResult((double)cachedResult);
        }

    }
}
