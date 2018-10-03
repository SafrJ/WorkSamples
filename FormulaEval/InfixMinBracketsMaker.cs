using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaEval2
{
    class InfixMinBracketsMaker : IAlgorithm
    {
        StringBuilder sb;
        Stack<OperationPriorities> prevPriorities;

        public InfixMinBracketsMaker()
        {
            sb = new StringBuilder();
            prevPriorities = new Stack<OperationPriorities>();
            prevPriorities.Push(OperationPriorities.Init);
        }

        public void CallResultWriter(IResultWriter writer)
        {
            writer.WriteResult(sb.ToString());
        }

        public void Visit(ConstantNode node)
        {
            sb.Append(node.Value);
        }

        public void Visit(UnaryMinus node)
        {
            prevPriorities.Pop();
            prevPriorities.Push(OperationPriorities.UnaryMinus);
            sb.Append("-");
            node.Child.Accept(this);
        }

        public void Visit(BinaryAdd node)
        {
            OperationPriorities priority = prevPriorities.Pop();
            if ((int)priority > 1 || priority == OperationPriorities.Sub)
            {
                sb.Append("(");
                prevPriorities.Push(OperationPriorities.Add);
                node.LeftChild.Accept(this);
                sb.Append("+");
                prevPriorities.Push(OperationPriorities.Add);
                node.RightChild.Accept(this);
                sb.Append(")");
            }
            else
            {
                prevPriorities.Push(OperationPriorities.Add);
                node.LeftChild.Accept(this);
                sb.Append("+");
                prevPriorities.Push(OperationPriorities.Add);
                node.RightChild.Accept(this);
            }
        }

        public void Visit(BinarySub node)
        {
            OperationPriorities priority = prevPriorities.Pop();
            if ((int)priority > 1)
            {
                sb.Append("(");
                prevPriorities.Push(OperationPriorities.Sub);
                node.LeftChild.Accept(this);
                sb.Append("-");
                prevPriorities.Push(OperationPriorities.Sub);
                node.RightChild.Accept(this);
                sb.Append(")");
            }
            else
            {
                prevPriorities.Push(OperationPriorities.Sub);
                node.LeftChild.Accept(this);
                sb.Append("-");
                prevPriorities.Push(OperationPriorities.Sub);
                node.RightChild.Accept(this);
            }
        }

        public void Visit(BinaryMul node)
        {
            OperationPriorities priority = prevPriorities.Pop();
            if ((int)priority > 6 || priority == OperationPriorities.Div)
            {
                sb.Append("(");
                prevPriorities.Push(OperationPriorities.Mul);
                node.LeftChild.Accept(this);
                sb.Append("*");
                prevPriorities.Push(OperationPriorities.Mul);
                node.RightChild.Accept(this);
                sb.Append(")");
            }
            else
            {
                prevPriorities.Push(OperationPriorities.Mul);
                node.LeftChild.Accept(this);
                sb.Append("*");
                prevPriorities.Push(OperationPriorities.Mul);
                node.RightChild.Accept(this);
            }
        }

        public void Visit(BinaryDiv node)
        {
            OperationPriorities priority = prevPriorities.Pop();
            if ((int)priority > 6)
            {
                sb.Append("(");
                prevPriorities.Push(OperationPriorities.Div);
                node.LeftChild.Accept(this);
                sb.Append("/");
                prevPriorities.Push(OperationPriorities.Div);
                node.RightChild.Accept(this);
                sb.Append(")");
            }
            else
            {
                prevPriorities.Push(OperationPriorities.Div);
                node.LeftChild.Accept(this);
                sb.Append("/");
                prevPriorities.Push(OperationPriorities.Div);
                node.RightChild.Accept(this);
            }
        }
    }
}
