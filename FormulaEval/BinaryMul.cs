﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaEval2
{
    sealed class BinaryMul : BinaryOperationNode
    {
        public BinaryMul(FormulaNode leftChild, FormulaNode rightChild) : base(leftChild, rightChild)
        {
        }

        public override void Accept(IAlgorithm algorithm)
        {
            algorithm.Visit(this);
        }
    }
}
