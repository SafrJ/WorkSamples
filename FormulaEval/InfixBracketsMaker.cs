using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaEval2
{
    class InfixBracketsMaker : IAlgorithm
    {
        StringBuilder sb;

        public InfixBracketsMaker()
        {
            sb = new StringBuilder();
        }

        public void CallResultWriter(IResultWriter writer)
        {
            writer.WriteResult(sb.ToString());
        }

        public void Visit(ConstantNode node)
        {
            sb.Append(node.Value.ToString());
        }

        public void Visit(UnaryMinus node)
        {
            sb.Append("(-");
            node.Child.Accept(this);
            sb.Append(")");
        }

        public void Visit(BinaryAdd node)
        {
            sb.Append("(");
            node.LeftChild.Accept(this);
            sb.Append("+");
            node.RightChild.Accept(this);
            sb.Append(")");
        }

        public void Visit(BinarySub node)
        {
            sb.Append("(");
            node.LeftChild.Accept(this);
            sb.Append("-");
            node.RightChild.Accept(this);
            sb.Append(")");
        }

        public void Visit(BinaryMul node)
        {
            sb.Append("(");
            node.LeftChild.Accept(this);
            sb.Append("*");
            node.RightChild.Accept(this);
            sb.Append(")");
        }

        public void Visit(BinaryDiv node)
        {
            sb.Append("(");
            node.LeftChild.Accept(this);
            sb.Append("/");
            node.RightChild.Accept(this);
            sb.Append(")");
        }
    }
}
