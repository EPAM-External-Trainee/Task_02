using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ThreeDimensionalArray;

namespace ThreeDimensionalVectorUnitTests
{
    /// <summary>
    /// Class that tests methods of the Vector class
    /// </summary>
    [TestClass]
    public class ThreeDimensionalVectorTests
    {
        [DataTestMethod, Description("Testing the properties of the vector lengths. Positive test result.")]
        [DynamicData(nameof(GetVectorsWithPositiveNumbersForLengthTest), DynamicDataSourceType.Method)]
        public void LengthProperty_OneVector_PositiveTestResult(Vector vector, double excpectedLength)
        {
            Assert.AreEqual(excpectedLength, vector.Length);
        }

        /// <summary>
        /// Creating multiple objects of the Vector class for testing the properties of the vector lengths
        /// </summary>
        /// <returns>Object array</returns>
        private static IEnumerable<object[]> GetVectorsWithPositiveNumbersForLengthTest()
        {
            yield return new object[] { new Vector(5, 1, 4), 22 };
            yield return new object[] { new Vector(10, 20, 30), 1310 };
            yield return new object[] { new Vector(6, 12, 9), 231 };
        }

        [DataTestMethod, Description("Testing an overloaded unary operator + for Vector. Positive test result.")]
        [DynamicData(nameof(GetVectorsForUnaryOperatorPlusTest), DynamicDataSourceType.Method)]
        public void OverloadedUnaryOperatorPlus_OneVector_PositiveTestResult(Vector vector, Vector excpectedVector)
        {
            Assert.AreEqual(excpectedVector, +vector);
        }

        /// <summary>
        /// Creating multiple objects of the Vector class for testing an overloaded unary operator +
        /// </summary>
        /// <returns>Object array</returns>
        private static IEnumerable<object[]> GetVectorsForUnaryOperatorPlusTest()
        {
            yield return new object[] { new Vector(5, 1, 4), new Vector(5, 1, 4), };
            yield return new object[] { new Vector(10, 20, 30), new Vector(10, 20, 30) };
            yield return new object[] { new Vector(6, 12, 9), new Vector(6, 12, 9) };
        }

        [DataTestMethod, Description("Testing an overloaded unary operator - for Vector. Positive test result.")]
        [DynamicData(nameof(GetVectorsForUnaryOperatorMinusTest), DynamicDataSourceType.Method)]
        public void OverloadedUnaryOperatorMinus_OneVector_PositiveTestResult(Vector vector, Vector excpectedVector)
        {
            Assert.AreEqual(excpectedVector, -vector);
        }

        /// <summary>
        /// Creating multiple objects of the Vector class for testing an overloaded unary operator -
        /// </summary>
        /// <returns>Object array</returns>
        private static IEnumerable<object[]> GetVectorsForUnaryOperatorMinusTest()
        {
            yield return new object[] { new Vector(5, 1, 4), new Vector(-5, -1, -4), };
            yield return new object[] { new Vector(10, 20, 30), new Vector(-10, -20, -30) };
            yield return new object[] { new Vector(-6, 12, 9), new Vector(6, -12, -9) };
        }

        [DataTestMethod, Description("Testing an overloaded unary operator ++ for Vector. Positive test result.")]
        [DynamicData(nameof(GetVectorsForUnaryOperatorPlusPlusTest), DynamicDataSourceType.Method)]
        public void OverloadedUnaryOperatorPlusPlus_OneVector_PositiveTestResult(Vector vector, Vector excpectedVector)
        { 
            Assert.AreEqual(excpectedVector, ++vector);
        }

        /// <summary>
        /// Creating multiple objects of the Vector class for testing an overloaded unary operator ++
        /// </summary>
        /// <returns>Object array</returns>
        private static IEnumerable<object[]> GetVectorsForUnaryOperatorPlusPlusTest() 
        {
            yield return new object[] { new Vector(5, 1, 4), new Vector(6, 2, 5), };
            yield return new object[] { new Vector(10, 20, 30), new Vector(11, 21, 31) };
            yield return new object[] { new Vector(-6, 12, 9), new Vector(-5, 13, 10) };
        }

        [DataTestMethod, Description("Testing an overloaded unary operator -- for Vector. Positive test result.")]
        [DynamicData(nameof(GetVectorsForUnaryOperatorMinusMinusTest), DynamicDataSourceType.Method)]
        public void OverloadedUnaryOperatorMinusMinus_OneVector_PositiveTestResult(Vector vector, Vector excpectedVector)
        {
            Assert.AreEqual(excpectedVector, --vector);
        }

        /// <summary>
        /// Creating multiple objects of the Vector class for testing an overloaded unary operator --
        /// </summary>
        /// <returns>Object array</returns>
        private static IEnumerable<object[]> GetVectorsForUnaryOperatorMinusMinusTest()
        {
            yield return new object[] { new Vector(5, 1, 4), new Vector(4, 0, 3), };
            yield return new object[] { new Vector(10, 20, 30), new Vector(9, 19, 29) };
            yield return new object[] { new Vector(6, -12, 9), new Vector(5, -13, 8) };
        }

        [DataTestMethod, Description("Testing an overloaded operator + between Vector and number. Positive test result.")]
        [DynamicData(nameof(GetVectorsAndNumbersForOperatorPlusTest), DynamicDataSourceType.Method)]
        public void OverloadedOperatorPlus_VectorAndNumber_PositiveTestResult(Vector vector, double value, Vector excpectedVector)
        {
            Assert.AreEqual(excpectedVector, vector + value);
        }

        /// <summary>
        /// Creating multiple objects of the Vector class for testing an overloaded operator + between vector and number
        /// </summary>
        /// <returns>Object array</returns>
        private static IEnumerable<object[]> GetVectorsAndNumbersForOperatorPlusTest() 
        {
            yield return new object[] { new Vector(5, 1, 4), 2, new Vector(7, 3, 6), };
            yield return new object[] { new Vector(10, 20, 30), -5, new Vector(5, 15, 25) };
            yield return new object[] { new Vector(6, -12, 9), 3.6, new Vector(9.6, -8.4, 12.6) };
        }

        [DataTestMethod, Description("Testing an overloaded operator - between Vector and number. Positive test result.")]
        [DynamicData(nameof(GetVectorsAndNumbersForOperatorMinusTest), DynamicDataSourceType.Method)]
        public void OverloadedOperatorMinus_VectorAndNumber_PositiveTestResult(Vector vector, double value, Vector excpectedVector)
        {
            Assert.AreEqual(excpectedVector, vector - value);
        }

        /// <summary>
        /// Creating multiple objects of the Vector class for testing an overloaded operator - between vector and number
        /// </summary>
        /// <returns>Object array</returns>
        private static IEnumerable<object[]> GetVectorsAndNumbersForOperatorMinusTest()
        {
            yield return new object[] { new Vector(5, 1, 4), 2, new Vector(3, -1, 2), };
            yield return new object[] { new Vector(10, 20, 30), -5, new Vector(15, 25, 35) };
            yield return new object[] { new Vector(6, -12, 9), 3.3, new Vector(2.7, -15.3, 5.7) };
        }

        [DataTestMethod, Description("Testing an overloaded operator * between Vector and number. Positive test result.")]
        [DynamicData(nameof(GetVectorsAndNumbersForOperatorMultiplyTest), DynamicDataSourceType.Method)]
        public void OverloadedOperatorMultiply_VectorAndNumber_PositiveTestResult(Vector vector, double value, Vector excpectedVector)
        { 
            Assert.AreEqual(excpectedVector, vector * value);
        }

        /// <summary>
        /// Creating multiple objects of the Vector class for testing an overloaded operator * between vector and number
        /// </summary>
        /// <returns>Object array</returns>
        private static IEnumerable<object[]> GetVectorsAndNumbersForOperatorMultiplyTest() 
        {
            yield return new object[] { new Vector(5, -1, 4), 5, new Vector(25, -5, 20), };
            yield return new object[] { new Vector(10, 20, 30), -2.5, new Vector(-25, -50, -75) };
            yield return new object[] { new Vector(6, -12, 9), 100, new Vector(600, -1200, 900) };
        }

        [DataTestMethod, Description("Testing an overloaded operator / between Vector and zero. Throw DivideByZeroException.")]
        [DynamicData(nameof(GetVectorsAndNumbersForOperatorDivisionZeroTest), DynamicDataSourceType.Method)]
        public void OverloadedOperatorDivision_VectorAndZero_ThrowDivideByZeroException(Vector vector, double value)
        {
            Assert.ThrowsException<DivideByZeroException>(() => vector / value);
        }

        /// <summary>
        /// Creating multiple objects of the Vector class for testing an overloaded operator / between vector and zero
        /// </summary>
        /// <returns>Object array</returns>
        private static IEnumerable<object[]> GetVectorsAndNumbersForOperatorDivisionZeroTest()
        {
            yield return new object[] { new Vector(5, -1, 4), 0 };
            yield return new object[] { new Vector(10, 20, 30), 0 };
            yield return new object[] { new Vector(6, -12, 9), 0 };
        }


        [DataTestMethod, Description("Testing an overloaded operator / between Vector and number. Positive test result.")]
        [DynamicData(nameof(GetVectorsAndNumbersForOperatorDivisionTest), DynamicDataSourceType.Method)]
        public void OverloadedOperatorDivision_VectorAndNumber_PositiveTestResult(Vector vector, double value, Vector excpectedVector)
        {
            Assert.AreEqual(excpectedVector, vector / value);
        }

        /// <summary>
        /// Creating multiple objects of the Vector class for testing an overloaded operator / between vector and number
        /// </summary>
        /// <returns>Object array</returns>
        private static IEnumerable<object[]> GetVectorsAndNumbersForOperatorDivisionTest()
        {
            yield return new object[] { new Vector(5, -1, 4), 7, new Vector(0.71, -0.14, 0.57), };
            yield return new object[] { new Vector(10, 20, 30), -2.5, new Vector(-4, -8, -12) };
            yield return new object[] { new Vector(6, -12, 9), 100, new Vector(0.06, -0.12, 0.09) };
        }

        [DataTestMethod, Description("Testing an overloaded operator == between two vectors. Positive test result.")]
        [DynamicData(nameof(GetVectorsAndNumbersForOperatorEqualsTest), DynamicDataSourceType.Method)]
        public void OverloadedOperatorEqual_TwoVectors_PositiveTestResult(Vector vector1, Vector vector2)
        {
            Assert.IsTrue(vector1 == vector2);
        }

        /// <summary>
        /// Creating multiple objects of the Vector class for testing an overloaded operator == two vectors
        /// </summary>
        /// <returns>Object array</returns>
        private static IEnumerable<object[]> GetVectorsAndNumbersForOperatorEqualsTest()
        {
            yield return new object[] { new Vector(5, 3, 11), new Vector(5, 3, 11), };
            yield return new object[] { new Vector(7, 1, 2), new Vector(7, 1, 2) };
            yield return new object[] { new Vector(12, 19, 21), new Vector(12, 19, 21) };
        }

        [DataTestMethod, Description("Testing an overloaded operator + for two vectors with positive numbers. Positive test result.")]
        [DynamicData(nameof(GetVectorsWithPositiveNumbersForPlusOperator), DynamicDataSourceType.Method)]
        public void OverloadOperatorPlus_TwoPositiveVectors_PositiveTestResult(Vector vector, Vector actualVector, Vector excpectedVector)
        {
            Assert.AreEqual(excpectedVector, vector + actualVector);
        }

        /// <summary>
        /// Creating multiple objects of the Vector class with positive numbers
        /// </summary>
        /// <returns>Object array</returns>
        private static IEnumerable<object[]> GetVectorsWithPositiveNumbersForPlusOperator()
        {
            yield return new object[] { new Vector(10, 20, 30), new Vector(1, 2, 3), new Vector(11, 22, 33) };
            yield return new object[] { new Vector(10, 20, 30), new Vector(4, 5, 6), new Vector(14, 25, 36) };
            yield return new object[] { new Vector(10, 20, 30), new Vector(7, 8, 9), new Vector(17, 28, 39) };
        }

        [DataTestMethod, Description("Testing an overloaded operator + for two vectors with negative numbers. Positive test result.")]
        [DynamicData(nameof(GetVectorsWithNegativeNumbersForPlusOperator), DynamicDataSourceType.Method)]
        public void OverloadOperatorPlus_TwoNegativeVectors_PositiveTestResult(Vector vector, Vector actualVector, Vector excpectedVector)
        {
            Assert.AreEqual(excpectedVector, vector + actualVector);
        }

        /// <summary>
        /// Creating multiple objects of the Vector class with negative numbers
        /// </summary>
        /// <returns>Object array</returns>
        private static IEnumerable<object[]> GetVectorsWithNegativeNumbersForPlusOperator()
        {
            yield return new object[] { new Vector(10, 20, 30), new Vector(-1, -2, -3), new Vector(9, 18, 27) };
            yield return new object[] { new Vector(10, 20, 30), new Vector(-4, -5, -6), new Vector(6, 15, 24) };
            yield return new object[] { new Vector(10, 20, 30), new Vector(-7, -8, -9), new Vector(3, 12, 21) };
        }

        [DataTestMethod, Description("Testing an overloaded operator + for two vectors with positive and negative numbers. Positive test result.")]
        [DynamicData(nameof(GetVectorsWithPosAndNegNumbersForPlusOperator), DynamicDataSourceType.Method)]
        public void OverloadOperatorPlus_TwoVectorsWithPosAndNegNumbers_PositiveTestResult(Vector vector, Vector actualVector, Vector excpectedVector)
        {
            Assert.AreEqual(excpectedVector, vector + actualVector);
        }

        /// <summary>
        /// Creating multiple objects of the Vector class with positive and negative numbers
        /// </summary>
        /// <returns>Object array</returns>
        private static IEnumerable<object[]> GetVectorsWithPosAndNegNumbersForPlusOperator()
        {
            yield return new object[] { new Vector(-10, 20, 30), new Vector(-1, -2, 3), new Vector(-11, 18, 33) };
            yield return new object[] { new Vector(10, -20, 30), new Vector(4, -5, -6), new Vector(14, -25, 24) };
            yield return new object[] { new Vector(-10, -20, -30), new Vector(-7, -8, 9), new Vector(-17, -28, -21) };
        }

        [DataTestMethod, Description("Testing an overloaded operator - for two vectors with positive numbers. Positive test result.")]
        [DynamicData(nameof(GetVectorsWithPositiveNumbersForMinusOperator), DynamicDataSourceType.Method)]
        public void OverloadOperatorMinus_TwoPositiveVectors_PositiveTestResult(Vector vector, Vector actualVector, Vector excpectedVector)
        {
            Assert.AreEqual(excpectedVector, vector - actualVector);
        }

        /// <summary>
        /// Creating multiple objects of the Vector class with positive numbers
        /// </summary>
        /// <returns>Object array</returns>
        private static IEnumerable<object[]> GetVectorsWithPositiveNumbersForMinusOperator()
        {
            yield return new object[] { new Vector(10, 20, 30), new Vector(1, 2, 3), new Vector(9, 18, 27) };
            yield return new object[] { new Vector(10, 20, 30), new Vector(4, 5, 6), new Vector(6, 15, 24) };
            yield return new object[] { new Vector(10, 20, 30), new Vector(7, 8, 9), new Vector(3, 12, 21) };
        }

        [DataTestMethod, Description("Testing an overloaded operator - for two vectors with negative numbers. Positive test result.")]
        [DynamicData(nameof(GetVectorsWithNegativeNumbersForMinusOperator), DynamicDataSourceType.Method)]
        public void OverloadOperatorMinus_TwoNegativeVectors_PositiveTestResult(Vector vector, Vector actualVector, Vector excpectedVector)
        {
            Assert.AreEqual(excpectedVector, vector - actualVector);
        }

        /// <summary>
        /// Creating multiple objects of the Vector class with negative numbers
        /// </summary>
        /// <returns>Object array</returns>
        private static IEnumerable<object[]> GetVectorsWithNegativeNumbersForMinusOperator()
        {
            yield return new object[] { new Vector(10, 20, 30), new Vector(-1, -2, -3), new Vector(11, 22, 33) };
            yield return new object[] { new Vector(10, 20, 30), new Vector(-4, -5, -6), new Vector(14, 25, 36) };
            yield return new object[] { new Vector(10, 20, 30), new Vector(-7, -8, -9), new Vector(17, 28, 39) };
        }

        [DataTestMethod, Description("Testing an overloaded operator - for two vectors with positive and negative numbers. Positive test result.")]
        [DynamicData(nameof(GetVectorsWithPosAndNegNumbersForMinusOperator), DynamicDataSourceType.Method)]
        public void OverloadOperatorMinus_TwoVectorsWithPosAndNegNumbers_PositiveTestResult(Vector vector, Vector actualVector, Vector excpectedVector)
        { 
            Assert.AreEqual(excpectedVector, vector - actualVector);
        }

        /// <summary>
        /// Creating multiple objects of the Vector class with positive and negative numbers
        /// </summary>
        /// <returns>Object array</returns>
        private static IEnumerable<object[]> GetVectorsWithPosAndNegNumbersForMinusOperator() 
        {
            yield return new object[] { new Vector(-10, 20, 30), new Vector(-1, -2, 3), new Vector(-9, 22, 27) };
            yield return new object[] { new Vector(10, -20, 30), new Vector(4, -5, -6), new Vector(6, -15, 36) };
            yield return new object[] { new Vector(-10, -20, -30), new Vector(-7, -8, 9), new Vector(-3, -12, -39) };
        }

        [DataTestMethod, Description("Testing an overloaded operator * for two vectors. Positive test result.")]
        [DynamicData(nameof(GetVectorsWithPosAndNegNumbersForMultiplyOperator), DynamicDataSourceType.Method)]
        public void OverloadOperatorMultiply_TwoVectors_PositiveTestResult(Vector vector, Vector actualVector, Vector excpectedVector)
        {
            Assert.AreEqual(excpectedVector, vector * actualVector);
        }

        /// <summary>
        /// Creating multiple objects of the Vector class with positive and negative numbers
        /// </summary>
        /// <returns>Object array</returns>
        private static IEnumerable<object[]> GetVectorsWithPosAndNegNumbersForMultiplyOperator()
        {
            yield return new object[] { new Vector(-10, 20, 30), new Vector(-1, -2, 3), new Vector(120, 0, 40) };
            yield return new object[] { new Vector(10, -20, 30), new Vector(4, -5, -6), new Vector(270, 180, 30) };
            yield return new object[] { new Vector(-10, -20, -30), new Vector(-7, -8, 9), new Vector(-420, 300, -60) };
        }
    }
}