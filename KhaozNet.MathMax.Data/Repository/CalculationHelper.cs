using System;
using Flee.PublicTypes;
using KhaozNet.MathMax.Domain.Result;

namespace KhaozNet.MathMax.Data.Repository
{
    public static class CalculationHelper
    {
        public static Result<double> EvaluateExpression(string expression)
        {
            try
            {
                ExpressionContext context = new ExpressionContext();

                //IDynamicExpression eDynamic = context.CompileDynamic(expression);
                //double result = (double)eDynamic.Evaluate();
                
                IGenericExpression<double> eGeneric = context.CompileGeneric<double>(expression.CleanInput());
                double result = eGeneric.Evaluate();

                return new Result<double>(true, result, string.Empty);
            }
            catch (Exception ex)
            {
                return new Result<double>(false, 0, ex.Message);
            }
        }

        private static string CleanInput(this string input)
        {
            return input.Trim()
                .Replace(" ", "")
                .Replace("−", "-") //8 − 7;
                .Replace("×", "*") //8 x 7;
                .Replace("x", "*")
                .Replace("÷", "/"); //8 ÷ 7;
        }
    }
}
