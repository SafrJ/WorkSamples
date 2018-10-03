using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaEval2
{
    class IntegerCalculator : IAlgorithm
    {
        Stack<int> results;
        int? cachedResult;

        public IntegerCalculator()
        {
            this.results = new Stack<int>();
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

                int value = results.Pop();

                results.Push(value * -1);
            }

        }

        public void Visit(BinaryAdd node)
        {
            if (!cachedResult.HasValue)
            {
                node.LeftChild.Accept(this);
                node.RightChild.Accept(this);

                int valueTwo = results.Pop();
                int valueOne = results.Pop();

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

                int valueTwo = results.Pop();
                int valueOne = results.Pop();

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

                int valueTwo = results.Pop();
                int valueOne = results.Pop();

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

                int valueTwo = results.Pop();
                int valueOne = results.Pop();

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
           
            writer.WriteResult((int)cachedResult);
        }

    }
}
