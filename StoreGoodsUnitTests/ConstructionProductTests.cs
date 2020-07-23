using Microsoft.VisualStudio.TestTools.UnitTesting;
using StoreGoods;
using System.Collections.Generic;

namespace StoreGoodsUnitTests
{
    /// <summary>
    /// Class that tests methods of СonstructionProduct class
    /// </summary>
    [TestClass]
    public class ConstructionProductTests
    {
        [DataTestMethod, Description("Testing the overloaded "+" operator of two objects of class ConstructionProduct")]
        [DynamicData(nameof(GetConstructionProductObjectsForTestingOperatorPlus), DynamicDataSourceType.Method)]
        public void OverloadedBinaryPlusOperator_TwoConstructionProductObjects_PositiveTestResult(ConstructionProduct product1, ConstructionProduct product2, ConstructionProduct expectedProduct)
        {
            Assert.AreEqual(expectedProduct, product1 + product2);
        }

        /// <summary>
        /// Creating multiple objects of the ConstructionProduct class for testing the overloaded binary operator plus
        /// </summary>
        /// <returns>Object array</returns>
        private static IEnumerable<object[]> GetConstructionProductObjectsForTestingOperatorPlus()
        {
            yield return new object[] { new ConstructionProduct("Concrete", "Construction product", 16m), new ConstructionProduct("Board", "Construction product", 11m), new ConstructionProduct("Concrete-Board", "Construction product", 13.5m) };
            yield return new object[] { new ConstructionProduct("Cement", "Construction product", 21m), new ConstructionProduct("Ferroconcrete", "Construction product", 33m), new ConstructionProduct("Cement-Ferroconcrete", "Construction product", 27m) };
            yield return new object[] { new ConstructionProduct("Sand", "Construction product", 1m), new ConstructionProduct("Clay", "Construction product", 3m), new ConstructionProduct("Sand-Clay", "Construction product", 2m) };
        }

        [DataTestMethod, Description("Testing the overloaded implicit operator FoodProduct casting FoodProduct to ConstructionProduct")]
        [DynamicData(nameof(GetProductObjectsForTestingCastOperatorFoodProduct), DynamicDataSourceType.Method)]
        public void OverloadedImplicitCastOperatorFoodProduct_CastingConstructionToFoodProduct_PositiveTestResult(FoodProduct expectedProduct, ConstructionProduct constructionProduct)
        {
            Assert.AreEqual(expectedProduct, (FoodProduct)constructionProduct);
        }

        /// <summary>
        /// Creating multiple objects of the ConstructionProduct and FoodProduct class for testing implicit cast operator FoodProduct
        /// </summary>
        /// <returns>Object array</returns>
        private static IEnumerable<object[]> GetProductObjectsForTestingCastOperatorFoodProduct()
        {
            yield return new object[] { new FoodProduct("Potato", "Food product", 0.5m), new ConstructionProduct("Potato", "Food product", 0.5m) };
            yield return new object[] { new FoodProduct("Meat", "Food product", 21m), new ConstructionProduct("Meat", "Food product", 21m) };
            yield return new object[] { new FoodProduct("Milk", "Food product", 1m), new ConstructionProduct("Milk", "Food product", 1m) };
        }

        [DataTestMethod, Description("Testing the overloaded implicit operator ElectricalProduct casting ConstructionProduct to an ElectricalProduct")]
        [DynamicData(nameof(GetProductObjectsForTestingCastOperatorElectricalProduct), DynamicDataSourceType.Method)]
        public void OverloadedImplicitCastOperatorElectricalProduct_CastingConstructionToElectricalProduct_PositiveTestResult(ElectricalProduct expectedProduct, ConstructionProduct constructionProduct)
        {
            Assert.AreEqual(expectedProduct, (ElectricalProduct)constructionProduct);
        }

        /// <summary>
        /// Creating multiple objects of the ConstructionProduct and ElectricalProduct class for testing implicit cast operator ElectricalProduct
        /// </summary>
        /// <returns>Object array</returns>
        private static IEnumerable<object[]> GetProductObjectsForTestingCastOperatorElectricalProduct()
        {
            yield return new object[] { new ElectricalProduct("Laptop", "Electrical product", 55m), new ConstructionProduct("Laptop", "Electrical product", 55m) };
            yield return new object[] { new ElectricalProduct("Radio", "Electrical product", 19m), new ConstructionProduct("Radio", "Electrical product", 19m) };
            yield return new object[] { new ElectricalProduct("Smartphone", "Electrical product", 31m), new ConstructionProduct("Smartphone", "Electrical product", 31m) };
        }

        [DataTestMethod, Description("Testing an overloaded cast operator to Decimal")]
        [DynamicData(nameof(GetDataForTestingCastOperatorToDecimal), DynamicDataSourceType.Method)]
        public void OverloadedDecimalCastOperator(ConstructionProduct constructionProduct, decimal value)
        {
            Assert.IsTrue(constructionProduct == value);
        }

        /// <summary>
        /// Creating multiple objects of the ConstructionProduct class for testing implicit cast operator to Decimal
        /// </summary>
        /// <returns>Object array</returns>
        private static IEnumerable<object[]> GetDataForTestingCastOperatorToDecimal()
        {
            yield return new object[] { new ConstructionProduct("Concrete", "Construction product", 16m), 16m };
            yield return new object[] { new ConstructionProduct("Cement", "Construction product", 21m), 21m };
            yield return new object[] { new ConstructionProduct("Sand", "Construction product", 1m), 1m };
        }

        [DataTestMethod, Description("Testing an overloaded cast operator to Int32")]
        [DynamicData(nameof(GetDataForTestingCastOperatorToInt32), DynamicDataSourceType.Method)]
        public void OverloadedInt32CastOperator(ConstructionProduct constructionProduct, int value)
        {
            Assert.IsTrue(constructionProduct == value);
        }

        /// <summary>
        /// Creating multiple objects of the ConstructionProduct class for testing implicit cast operator to Int32
        /// </summary>
        /// <returns>Object array</returns>
        private static IEnumerable<object[]> GetDataForTestingCastOperatorToInt32()
        {
            yield return new object[] { new ConstructionProduct("Concrete", "Construction product", 16.44m), 1644 };
            yield return new object[] { new ConstructionProduct("Cement", "Construction product", 21.1m), 2110 };
            yield return new object[] { new ConstructionProduct("Sand", "Construction product", 1m), 100 };
        }
    }
}