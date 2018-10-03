using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaEval2
{
    abstract class BinaryOperationNode : OperationNode
    {
        FormulaNode leftChild;
        FormulaNode rightChild;

        public FormulaNode LeftChild { get => leftChild; }
        public FormulaNode RightChild { get => rightChild; }

        public BinaryOperationNode(FormulaNode leftChild, FormulaNode rightChild)
        {
            this.leftChild = leftChild;
            this.rightChild = rightChild;
        }
    }
}
