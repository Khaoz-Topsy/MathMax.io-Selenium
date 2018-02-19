using KhaozNet.MathMax.Data.Repository;
using KhaozNet.MathMax.Domain.Result;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KhaozNet.MathMax.Test
{
    [TestClass]
    public class FleeEvaluationTest
    {
        [TestMethod]
        public void TestAdditionInput()
        {
            Result<double> calculationResult = CalculationHelper.EvaluateExpression("3 + 5");

            Assert.IsTrue(calculationResult.IsSuccess);
            Assert.AreEqual(calculationResult.Value, 8);
        }
        [TestMethod]
        public void TestSubtractionInput_PositiveNumber()
        {
            Result<double> calculationResult = CalculationHelper.EvaluateExpression("8 - 5");

            Assert.IsTrue(calculationResult.IsSuccess);
            Assert.AreEqual(calculationResult.Value, 3);
        }
        [TestMethod]
        public void TestSubtractionInput_NegativeNumber()
        {
            Result<double> calculationResult = CalculationHelper.EvaluateExpression("3 - 5");

            Assert.IsTrue(calculationResult.IsSuccess);
            Assert.AreEqual(calculationResult.Value, -2);
        }
        [TestMethod]
        public void TestSubtractionInput_BadInput()
        {
            Result<double> calculationResult = CalculationHelper.EvaluateExpression("8 − 5");

            Assert.IsTrue(calculationResult.IsSuccess);
            Assert.AreEqual(calculationResult.Value, 3);
        }
        [TestMethod]
        public void TestMultiplicationInput()
        {
            Result<double> calculationResult = CalculationHelper.EvaluateExpression("8 * 5");

            Assert.IsTrue(calculationResult.IsSuccess);
            Assert.AreEqual(calculationResult.Value, 40);
        }
        [TestMethod]
        public void TestMultiplicationInput_BadInput()
        {
            Result<double> calculationResult = CalculationHelper.EvaluateExpression("3 x 2");

            Assert.IsTrue(calculationResult.IsSuccess);
            Assert.AreEqual(calculationResult.Value, 6);
        }
        [TestMethod]
        public void TestDivisionInput_WholeNumber()
        {
            Result<double> calculationResult = CalculationHelper.EvaluateExpression("40 / 5");

            Assert.IsTrue(calculationResult.IsSuccess);
            Assert.AreEqual(calculationResult.Value, 8);
        }
        [TestMethod]
        public void TestDivisionInput_DecimalNumber()
        {
            Result<double> calculationResult = CalculationHelper.EvaluateExpression("5 / 40");

            Assert.IsTrue(calculationResult.IsSuccess);
            //Assert.AreEqual(calculationResult.Value, 0.25);
        }
        [TestMethod]
        public void TestDivisionInput_BadInput()
        {
            Result<double> calculationResult = CalculationHelper.EvaluateExpression("40 ÷ 5");

            Assert.IsTrue(calculationResult.IsSuccess);
            Assert.AreEqual(calculationResult.Value, 8);
        }


        [TestMethod]
        public void TestComplexInput()
        {
            Result<double> calculationResult = CalculationHelper.EvaluateExpression("3 + 2 / 1");

            Assert.IsTrue(calculationResult.IsSuccess);
            Assert.AreEqual(calculationResult.Value, 5);
        }
        [TestMethod]
        public void TestComplexInput_BadInput()
        {
            Result<double> calculationResult = CalculationHelper.EvaluateExpression("20 ÷ 5 ÷ 2");

            Assert.IsTrue(calculationResult.IsSuccess);
            Assert.AreEqual(calculationResult.Value, 2);
        }
    }
}
