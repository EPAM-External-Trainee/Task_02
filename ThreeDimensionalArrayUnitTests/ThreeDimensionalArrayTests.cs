using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ThreeDimensionalArray;

namespace ThreeDimensionalArrayUnitTests
{
    [TestClass]
    public class ThreeDimensionalArrayTests
    {
        [DataTestMethod, Description("Testing the properties of the vector lengths. Positive test result.")]
        [DynamicData(nameof(GetVectorsWithPositiveNumbersForLengthTest), DynamicDataSourceType.Method)]
        public void LengthProperty_OneVector_PositiveTestResult(Vector vector, double excpectedLength)
        {
            Assert.AreEqual(excpectedLength, vector.Length);
        }

        private static IEnumerable<object[]> GetVectorsWithPositiveNumbersForLengthTest()
        {
            yield return new object[] { new Vector(5, 1, 4), 22 };
            yield return new object[] { new Vector(10, 20, 30), 1310 };
            yield return new object[] { new Vector(6, 12, 9), 231 };
        }

        // Здесь будут тесты унарных операций




























        [DataTestMethod, Description("Testing an overloaded operator + for two vectors with positive numbers. Positive test result.")]
        [DynamicData(nameof(GetVectorsWithPositiveNumbersForPlusOperator), DynamicDataSourceType.Method)]
        public void OverloadOperatorPlus_TwoPositiveVectors_PositiveTestResult(Vector vector, Vector actualVector, Vector excpectedVector)
        {
            Assert.AreEqual(excpectedVector, vector + actualVector);
        }

        /// <summary>
        /// Creating multiple objects of the Vector class with positive numbers
        /// </summary>
        /// <returns>Vector array</returns>
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
        /// <returns>Vector array</returns>
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
        /// <returns>Vector array</returns>
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
        /// <returns>Vector array</returns>
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
        /// <returns>Vector array</returns>
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
        /// <returns>Vector array</returns>
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
        /// <returns>Vector array</returns>
        private static IEnumerable<object[]> GetVectorsWithPosAndNegNumbersForMultiplyOperator()
        {
            yield return new object[] { new Vector(-10, 20, 30), new Vector(-1, -2, 3), new Vector(120, 0, 40) };
            yield return new object[] { new Vector(10, -20, 30), new Vector(4, -5, -6), new Vector(270, 180, 30) };
            yield return new object[] { new Vector(-10, -20, -30), new Vector(-7, -8, 9), new Vector(-420, 300, -60) };
        }

        [DataTestMethod, Description("Testing an overloaded operator / for two vectors. Throw DivideByZeroException.")]
        [DynamicData(nameof(GetVectorsWithPosAndNegNumbersWithZerosForDivisionOperator), DynamicDataSourceType.Method)]
        public void OverloadOperatorDivision_TwoVectors_ThrowDivideByZeroException(Vector vector, Vector actualVector, Vector excpectedVector)
        {
            Assert.ThrowsException<DivideByZeroException>(() => vector / actualVector);
        }

        /// <summary>
        /// Creating multiple objects of the Vector class with positive and negative numbers
        /// </summary>
        /// <returns>Vector array</returns>
        private static IEnumerable<object[]> GetVectorsWithPosAndNegNumbersWithZerosForDivisionOperator()
        {
            yield return new object[] { new Vector(-10, 20, 30), new Vector(-1, 0, 3), new Vector(10, 0, 10) };
            yield return new object[] { new Vector(10, -20, 30), new Vector(4, -5, 0), new Vector(2.5, 4, 0) };
            yield return new object[] { new Vector(-10, -20, -30), new Vector(0, -8, 9), new Vector(0, 2.5, -3.33) };
        }

        [DataTestMethod, Description("Testing an overloaded operator / for two vectors. Positive test result.")]
        [DynamicData(nameof(GetVectorsWithPosAndNegNumbersForDivisionOperator), DynamicDataSourceType.Method)]
        public void OverloadOperatorDivision_TwoVectors_PositiveTestResult(Vector vector, Vector actualVector, Vector excpectedVector)
        {
            Assert.AreEqual(excpectedVector, vector / actualVector);
        }

        /// <summary>
        /// Creating multiple objects of the Vector class with positive and negative numbers
        /// </summary>
        /// <returns>Vector array</returns>
        private static IEnumerable<object[]> GetVectorsWithPosAndNegNumbersForDivisionOperator()
        {
            yield return new object[] { new Vector(-10, 20, 30), new Vector(-1, -2, 3), new Vector(10, -10, 10) };
            yield return new object[] { new Vector(10, -20, 30), new Vector(4, -5, -6), new Vector(2.5, 4, -5) };
            yield return new object[] { new Vector(-10, -20, -30), new Vector(-7, -8, 9), new Vector(1.43, 2.5, -3.33) };
        }
    }
}