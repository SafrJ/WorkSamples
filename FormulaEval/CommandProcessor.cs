using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaEval2
{
    class CommandProcessor : ICommandProcessor
    {
        FormulaNode formulaNode = null;
        bool end = false;
        public bool End => end;
        IResultWriter writer;
        IntegerCalculator intAlgo;
        DoubleCalculator doubleAlgo;

        public CommandProcessor(IResultWriter writer)
        {
            this.writer = writer;
        }


        public void ProcessCommand(string formula)
        {
            try
            {
                switch (formula)
                {
                    case null:
                        {
                            end = true;
                            break;
                        }
                    case "end":
                        {
                            end = true;
                            break;
                        }
                    case "p":
                        {
                            if (formulaNode != null)
                            {
                                IAlgorithm algorithm = new InfixBracketsMaker();
                                formulaNode.Accept(algorithm);
                                algorithm.CallResultWriter(writer);
                            }
                            else
                            {
                                writer.WriteError(ExpressionMissingError.Instance);
                            }
                            break;
                        }
                    case "P":
                        {
                            if (formulaNode != null)
                            {
                                IAlgorithm algorithm = new InfixMinBracketsMaker();
                                formulaNode.Accept(algorithm);
                                algorithm.CallResultWriter(writer);
                            }
                            else
                            {
                                writer.WriteError(ExpressionMissingError.Instance);
                            }
                            break;
                        }
                    case "i":
                        {
                            if (formulaNode != null)
                            {
                                if (intAlgo == null)
                                {
                                    intAlgo = new IntegerCalculator();
                                    formulaNode.Accept(intAlgo);
                                }
                                intAlgo.CallResultWriter(writer);
                            }
                            else
                            {
                                writer.WriteError(ExpressionMissingError.Instance);
                            }
                            break;
                        }
                    case "":
                        {
                            break;
                        }
                    case "d":
                        {
                            if (formulaNode != null)
                            {
                                if (doubleAlgo == null)
                                {
                                    doubleAlgo = new DoubleCalculator();
                                }
                                formulaNode.Accept(doubleAlgo);
                                doubleAlgo.CallResultWriter(writer);
                            }
                            else
                            {
                                writer.WriteError(ExpressionMissingError.Instance);
                            }
                            break;
                        }
                    default:
                        {
                            if (formula.StartsWith("="))
                            {
                                formulaNode = null;
                                doubleAlgo = null;
                                intAlgo = null;
                                if (!new PreorderParser().TryParse(formula.Remove(0, 2), out formulaNode))
                                {
                                    writer.WriteError(FormatError.Instance);
                                }
                            }
                            else
                            {
                                writer.WriteError(FormatError.Instance);
                            }
                            break;
                        }
                }
            }
            catch (DivideByZeroException)
            {
                writer.WriteError(DivisionError.Instance);
            }
            catch (OverflowException)
            {
                writer.WriteError(OverflowError.Instance);
            }
            catch (FormatException)
            {
                writer.WriteError(FormatError.Instance);
            }
            catch (InvalidOperationException)
            {
                writer.WriteError(FormatError.Instance);
            }
            catch (ArgumentOutOfRangeException)
            {
                writer.WriteError(FormatError.Instance);
            }
        }


    }
}
