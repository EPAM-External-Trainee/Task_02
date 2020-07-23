using System;
using System.Collections.Generic;
using MathPolynomial;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PolynomialUnitTests
{
    /// <summary>
    /// Class that tests methods of Polynomial class
    /// </summary>
    [TestClass]
    public class PolynomialTests
    {
        [DataTestMethod, Description("Testing the overloaded plus operator between two polynomials with the same degrees. Positive test result.")]
        [DynamicData(nameof(GetPolynomialsWithSameDegreeForTestingOperatorPlus), DynamicDataSourceType.Method)]
        public void OverloadedBinaryPlusOperator_TwoPolynomials_SameDegree_PositiveTestResult(Polynomial p, Polynomial actualP, Polynomial excpectedP)
        {
            Assert.AreEqual(excpectedP, p + actualP);
        }

        /// <summary> 
        /// Creating multiple objects of the Polynomial class for testing the overloaded binary operator plus with equal degrees
        /// </summary>
        /// <returns>Object array</returns>
        private static IEnumerable<object[]> GetPolynomialsWithSameDegreeForTestingOperatorPlus()
        {
            yield return new object[] { new Polynomial(5, 1, 4), new Polynomial(1, 2, 3), new Polynomial(6, 3, 7) };
            yield return new object[] { new Polynomial(9, 5, 2), new Polynomial(3, 2, 1), new Polynomial(12, 7, 3) };
            yield return new object[] { new Polynomial(-1, 4, 0.5), new Polynomial(4, 5, 7), new Polynomial(3, 9, 7.5) };
        }

        [DataTestMethod, Description("Testing the overloaded plus operator between two polynomials with different degrees. Positive test result.")]
        [DynamicData(nameof(GetPolynomialsWithDifferentDegreeForTestingOperatorPlus), DynamicDataSourceType.Method)]
        public void OverloadedBinaryPlusOperator_TwoPolynomials_DifferentDegree_PositiveTestResult(Polynomial p, Polynomial actualP, Polynomial excpectedP)
        {
            Assert.AreEqual(excpectedP, p + actualP);
        }

        /// <summary>
        /// Creating multiple objects of the Polynomial class for testing the overloaded binary operator plus with the different degrees
        /// </summary>
        /// <returns>Object array</returns>
        private static IEnumerable<object[]> GetPolynomialsWithDifferentDegreeForTestingOperatorPlus() 
        {
            yield return new object[] { new Polynomial(5, 1), new Polynomial(1, 2, 3), new Polynomial(6, 3, 3) };
            yield return new object[] { new Polynomial(9, 5, 2), new Polynomial(3, 2, 1, 0), new Polynomial(12, 7, 3, 0) };
            yield return new object[] { new Polynomial(-1, 4, 0.5, 5), new Polynomial(4, 5, 7), new Polynomial(3, 9, 7.5, 5) };
        }

        [DataTestMethod, Description("Testing the overloaded minus operator between two polynomials with the same degrees. Positive test result.")]
        [DynamicData(nameof(GetPolynomialsWithSameDegreeForTestingOperatorMinus), DynamicDataSourceType.Method)]
        public void OverloadedBinaryMinusOperator_TwoPolynomials_SameDegree_PositiveTestResult(Polynomial p, Polynomial actualP, Polynomial excpectedP)
        {
            Assert.AreEqual(excpectedP, p - actualP);
        }

        /// <summary>
        /// Creating multiple objects of the Polynomial class for testing the overloaded binary operator minus with the same degrees
        /// </summary>
        /// <returns>Object array</returns> 
        private static IEnumerable<object[]> GetPolynomialsWithSameDegreeForTestingOperatorMinus()
        {
            yield return new object[] { new Polynomial(5, 1, 2), new Polynomial(6, 2, 3), new Polynomial(-1, -1, -1) };
            yield return new object[] { new Polynomial(9, 5, 2), new Polynomial(3, 2, 1), new Polynomial(6, 3, 1) };
            yield return new object[] { new Polynomial(-1, 4, 0.5), new Polynomial(-4, 4, 7), new Polynomial(3, 0, -6.5) };
        }

        [DataTestMethod, Description("Testing the overloaded minus operator between two polynomials with the different degrees. Positive test result.")]
        [DynamicData(nameof(GetPolynomialsWithDifferentDegreeForTestingOperatorMinus), DynamicDataSourceType.Method)]
        public void OverloadedBinaryMinusOperator_TwoPolynomials_DifferentDegree_PositiveTestResult(Polynomial p, Polynomial actualP, Polynomial excpectedP)
        {
            Assert.AreEqual(excpectedP, p - actualP);
        }

        /// <summary>
        /// Creating multiple objects of the Polynomial class for testing the overloaded binary operator minus with the different degrees
        /// </summary>
        /// <returns>Object array</returns> 
        private static IEnumerable<object[]> GetPolynomialsWithDifferentDegreeForTestingOperatorMinus()
        {
            yield return new object[] { new Polynomial(5, 1), new Polynomial(1, 2, 3), new Polynomial(4, -1, -3) };
            yield return new object[] { new Polynomial(9, 5, 2), new Polynomial(3, 2, 1, 0), new Polynomial(6, 3, 1, 0) };
            yield return new object[] { new Polynomial(-1, 4, 0.5, 5), new Polynomial(4, 5, 7), new Polynomial(-5, -1, -6.5, 5) };
        }

        [DataTestMethod, Description("Testing the overloaded multiplication operator between two polynomials with the same degrees. Positive test result.")]
        [DynamicData(nameof(GetPolynomialsWithSameDegreeForTestingOperatorMultiplication), DynamicDataSourceType.Method)]
        public void OverloadedBinaryMultiplicationOperator_TwoPolynomials_SameDegree_PositiveTestResult(Polynomial p, Polynomial actualP, Polynomial excpectedP)
        {
            Assert.AreEqual(excpectedP, p * actualP);
        }

        /// <summary>
        /// Creating multiple objects of the Polynomial class for testing the overloaded binary operator multiplication with the same degrees
        /// </summary>
        /// <returns>Object array</returns>  
        private static IEnumerable<object[]> GetPolynomialsWithSameDegreeForTestingOperatorMultiplication()
        {
            yield return new object[] { new Polynomial(5, 7, 3), new Polynomial(1, 2, 3), new Polynomial(5, 17, 32, 27, 9) };
            yield return new object[] { new Polynomial(9, 5, 2), new Polynomial(3, 2, 1), new Polynomial(27, 33, 25, 9, 2) };
            yield return new object[] { new Polynomial(-1, 4, 0.5), new Polynomial(4, 5, 7), new Polynomial(-4, 11, 15, 30.5, 3.5) };
        }

        [DataTestMethod, Description("Testing the overloaded multiplication operator between two polynomials with the different degrees. Positive test result.")]
        [DynamicData(nameof(GetPolynomialsWithDifferentDegreeForTestingOperatorMultiplication), DynamicDataSourceType.Method)]
        public void OverloadedBinaryMultiplicationOperator_TwoPolynomials_DifferentDegree_PositiveTestResult(Polynomial p, Polynomial actualP, Polynomial excpectedP)
        {
            Assert.AreEqual(excpectedP, p * actualP);
        }

        /// <summary>
        /// Creating multiple objects of the Polynomial class for testing the overloaded binary operator multiplication with the different degrees
        /// </summary>
        /// <returns>Object array</returns>   
        private static IEnumerable<object[]> GetPolynomialsWithDifferentDegreeForTestingOperatorMultiplication()
        {
            yield return new object[] { new Polynomial(5, 7, 3), new Polynomial(1, 2), new Polynomial(5, 17, 17, 6) };
            yield return new object[] { new Polynomial(9, 5), new Polynomial(3, 2, 1), new Polynomial(27, 33, 19, 5) };
            yield return new object[] { new Polynomial(-1, 4, 0.5), new Polynomial(4, 5, 7, 10), new Polynomial(-4, 11, 15, 20.5, 43.5, 5) };
        }

        [DataTestMethod, Description("Testing the overloaded division operator between two polynomials with the same degrees. Positive test result.")]
        [DynamicData(nameof(GetPolynomialsWithSameDegreeForTestingOperatorDivision), DynamicDataSourceType.Method)]
        public void OverloadedBinaryDivisionOperator_TwoPolynomials_SameDegree_PositiveTestResult(Polynomial p, Polynomial actualP, Polynomial excpectedP)
        {
            Assert.AreEqual(excpectedP, p / actualP);
        }

        /// <summary>
        /// Creating multiple objects of the Polynomial class for testing the overloaded binary operator division with the same degrees
        /// </summary>
        /// <returns>Object array</returns>   
        private static IEnumerable<object[]> GetPolynomialsWithSameDegreeForTestingOperatorDivision()
        {
            yield return new object[] { new Polynomial(8, 12, 99, 150), new Polynomial(40, 7, 3, 25), new Polynomial(0.2) };
            yield return new object[] { new Polynomial(9, 5), new Polynomial(9, 5), new Polynomial(1) };
            yield return new object[] { new Polynomial(-1, 4, 0.5), new Polynomial(4, 5, 7), new Polynomial(-0.25) };
        }

        [DataTestMethod, Description("Testing the overloaded division operator between two polynomials with the different degrees. Positive test result.")]
        [DynamicData(nameof(GetPolynomialsWithDifferentDegreeForTestingOperatorDivision), DynamicDataSourceType.Method)]
        public void OverloadedBinaryDivisionOperator_TwoPolynomials_DifferentDegree_PositiveTestResult(Polynomial p, Polynomial actualP, Polynomial excpectedP)
        {
            Assert.AreEqual(excpectedP, p / actualP);
        }

        /// <summary>
        /// Creating multiple objects of the Polynomial class for testing the overloaded binary operator division with the different degrees
        /// </summary>
        /// <returns>Object array</returns>   
        private static IEnumerable<object[]> GetPolynomialsWithDifferentDegreeForTestingOperatorDivision()
        {
            yield return new object[] { new Polynomial(7, 2), new Polynomial(5, 5, 2), new Polynomial(0) };
            yield return new object[] { new Polynomial(9, 5, 6), new Polynomial(3, 2, 4, 12), new Polynomial(0) };
            yield return new object[] { new Polynomial(9, 5, 6, 0.3, -12), new Polynomial(3, 2, 4, 12), new Polynomial(3, -0.33) };
        }

        [DataTestMethod, Description("Testing the overloaded multiplication operator between polynomial and number. Positive test result.")]
        [DynamicData(nameof(GetPolynomialsAndNumberForTestingOperatorMultiplication), DynamicDataSourceType.Method)]
        public void OverloadedMultiplicationOperator_PolynomialAndNumber_PositiveTestResult(Polynomial p, double number, Polynomial excpectedP)
        {
            Assert.AreEqual(excpectedP, p * number);
        }

        /// <summary>
        /// Creating multiple objects of the Polynomial class for testing the overloaded binary operator multiplication with the different degrees
        /// </summary>
        /// <returns>Object array</returns>   
        private static IEnumerable<object[]> GetPolynomialsAndNumberForTestingOperatorMultiplication()
        {
            yield return new object[] { new Polynomial(5, 7, 3), 5, new Polynomial(25, 35, 15) };
            yield return new object[] { new Polynomial(9, 5), 6, new Polynomial(54, 30) };
            yield return new object[] { new Polynomial(-1, 4, 0.5), -3, new Polynomial(3, -12, -1.5) };
        }

        [DataTestMethod, Description("Testing the overloaded division operator between polynomial and zero. Throw DivideByZeroException.")]
        [DynamicData(nameof(GetPolynomialAndZeroForTestingOperatorDivision), DynamicDataSourceType.Method)]
        public void OverloadedDivisionOperator_PolynomialAndZero_ThrowDivideByZeroException(Polynomial p, double number)
        {
            Assert.ThrowsException<DivideByZeroException>(() => p / number);
        }

        /// <summary>
        /// Creating multiple objects of the Polynomial class for testing the overloaded binary operator division 
        /// </summary>
        /// <returns>Object array</returns>   
        private static IEnumerable<object[]> GetPolynomialAndZeroForTestingOperatorDivision()
        {
            yield return new object[] { new Polynomial(5, 7, 3), 0 };
            yield return new object[] { new Polynomial(9, 5), 0 };
            yield return new object[] { new Polynomial(-1, 4, 0.5), 0 };
        }

        [DataTestMethod, Description("Testing the overloaded division operator between polynomial and number. Positive test result.")]
        [DynamicData(nameof(GetPolynomialsAndNumberForTestingOperatorDivision), DynamicDataSourceType.Method)]
        public void OverloadedDivisionOperator_PolynomialAndNumber_PositiveTestResult(Polynomial p, double number, Polynomial excpectedP)
        {
            Assert.AreEqual(excpectedP, p / number);
        }

        /// <summary>
        /// Creating multiple objects of the Polynomial class for testing the overloaded binary operator division
        /// </summary>
        /// <returns>Object array</returns>   
        private static IEnumerable<object[]> GetPolynomialsAndNumberForTestingOperatorDivision()
        {
            yield return new object[] { new Polynomial(5, 7, 3), 5, new Polynomial(1, 1.4, 0.6) };
            yield return new object[] { new Polynomial(9, 5), 6, new Polynomial(1.5, 0.83) };
            yield return new object[] { new Polynomial(-1, 4, 0.5), -3, new Polynomial(0.33, -1.33, -0.17) };
        }

        [DataTestMethod, Description("Testing the overloaded operator equal between two polynomials. Positive test result.")]
        [DynamicData(nameof(GetPolynomialsForTestingOperatorEqual), DynamicDataSourceType.Method)]
        public void OverloadedEqualOperator_TwoPolynomials_PositiveTestResult(Polynomial p1, Polynomial p2)
        {
            Assert.IsTrue(p1 == p2);
        }

        /// <summary>
        /// Creating multiple objects of the Polynomial class for testing the overloaded binary operator equal
        /// </summary>
        /// <returns>Object array</returns>   
        private static IEnumerable<object[]> GetPolynomialsForTestingOperatorEqual()
        {
            yield return new object[] { new Polynomial(5, 7, 3), new Polynomial(5, 7, 3) };
            yield return new object[] { new Polynomial(9, 5), new Polynomial(9, 5) };
            yield return new object[] { new Polynomial(-1, 4, 0.5), new Polynomial(-1, 4, 0.5) };
        }
    }
}