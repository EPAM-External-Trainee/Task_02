using Microsoft.VisualStudio.TestTools.UnitTesting;
using StoreGoods;
using System.Collections.Generic;

namespace StoreGoodsUnitTests
{
    /// <summary>
    /// Class that tests methods of FoodProduct class
    /// </summary>
    [TestClass]
    public class FoodProductTests
    {
        [DataTestMethod, Description("Testing the overloaded "+" operator of two objects of class FoodProduct")]
        [DynamicData(nameof(GetFoodProductObjectsForTestingOperatorPlus), DynamicDataSourceType.Method)]
        public void OverloadedBinaryPlusOperator_TwoFoodProductObjects_PositiveTestResult(FoodProduct product1, FoodProduct product2, FoodProduct expectedProduct)
        {
            Assert.AreEqual(expectedProduct, product1 + product2);
        }

        /// <summary>
        /// Creating multiple objects of the FoodProduct class for testing the overloaded binary operator plus
        /// </summary>
        /// <returns>Object array</returns>
        private static IEnumerable<object[]> GetFoodProductObjectsForTestingOperatorPlus()
        {
            yield return new object[] { new FoodProduct("Potato", "Food product", 0.5m), new FoodProduct("Pasta", "Food product", 0.2m), new FoodProduct("Potato-Pasta", "Food product", 0.35m) };
            yield return new object[] { new FoodProduct("Meat", "Food product", 1.4m), new FoodProduct("Cucumber", "Food product", 0.1m), new FoodProduct("Meat-Cucumber", "Food product", 0.75m) };
            yield return new object[] { new FoodProduct("Milk", "Food product", 1m), new FoodProduct("Mandarin", "Food product", 0.2m), new FoodProduct("Milk-Mandarin", "Food product", 0.6m) };
        }

        [DataTestMethod, Description("Testing the overloaded implicit operator ElectricalProduct casting FoodProduct to ElectricalProduct")]
        [DynamicData(nameof(GetProductObjectsForTestingCastOperatorElectricalProduct), DynamicDataSourceType.Method)]
        public void OverloadedImplicitCastOperatorElectricalProduct_CastingFoodToElectricalProduct_PositiveTestResult(ElectricalProduct expectedProduct, FoodProduct foodProduct)
        {
            Assert.AreEqual(expectedProduct, (ElectricalProduct)foodProduct);
        }

        /// <summary>
        /// Creating multiple objects of the ElectricalProduct and FoodProduct class for testing implicit cast operator ElectricalProduct
        /// </summary>
        /// <returns>Object array</returns>
        private static IEnumerable<object[]> GetProductObjectsForTestingCastOperatorElectricalProduct()
        {
            yield return new object[] { new ElectricalProduct("Potato", "Food product", 0.5m), new FoodProduct("Potato", "Food product", 0.5m) };
            yield return new object[] { new ElectricalProduct("Mandarin", "Food product", 0.2m), new FoodProduct("Mandarin", "Food product", 0.2m) };
            yield return new object[] { new ElectricalProduct("Pasta", "Food product", 0.2m), new FoodProduct("Pasta", "Food product", 0.2m) };
        }

        [DataTestMethod, Description("Testing the overloaded implicit operator ConstructionProduct casting FoodProduct to ConstructionProduct")]
        [DynamicData(nameof(GetProductObjectsForTestingCastOperatorConstructionProduct), DynamicDataSourceType.Method)]
        public void OverloadedImplicitCastOperatorConstructionProduct_CastingFoodToConstructionProduct_PositiveTestResult(ConstructionProduct expectedProduct, FoodProduct foodProduct)
        {
            Assert.AreEqual(expectedProduct, (ConstructionProduct)foodProduct);
        }

        /// <summary>
        /// Creating multiple objects of the ConstructionProduct and FoodProduct class for testing implicit cast operator ConstructionProduct
        /// </summary>
        /// <returns>Object array</returns>
        private static IEnumerable<object[]> GetProductObjectsForTestingCastOperatorConstructionProduct()
        {
            yield return new object[] { new ConstructionProduct("Meat", "Food product", 1.4m), new FoodProduct("Meat", "Food product", 1.4m) };
            yield return new object[] { new ConstructionProduct("Cucumber", "Food product", 0.1m), new FoodProduct("Cucumber", "Food product", 0.1m) };
            yield return new object[] { new ConstructionProduct("Potato", "Food product", 0.5m), new FoodProduct("Potato", "Food product", 0.5m) };
        }

        [DataTestMethod, Description("Testing an overloaded cast operator to Decimal")]
        [DynamicData(nameof(GetDataForTestingCastOperatorToDecimal), DynamicDataSourceType.Method)]
        public void OverloadedDecimalCastOperator(FoodProduct foodProduct, decimal value)
        {
            Assert.IsTrue(foodProduct == value);
        }

        /// <summary>
        /// Creating multiple objects of the FoodProduct class for testing implicit cast operator to Decimal
        /// </summary>
        /// <returns>Object array</returns>
        private static IEnumerable<object[]> GetDataForTestingCastOperatorToDecimal()
        {
            yield return new object[] { new FoodProduct("Potato", "Food product", 0.5m), 0.5m };
            yield return new object[] { new FoodProduct("Mandarin", "Food product", 0.2m), 0.2m };
            yield return new object[] { new FoodProduct("Pasta", "Food product", 1.2m), 1.2m };
        }

        [DataTestMethod, Description("Testing an overloaded cast operator to Int32")]
        [DynamicData(nameof(GetDataForTestingCastOperatorToInt32), DynamicDataSourceType.Method)]
        public void OverloadedInt32CastOperator(FoodProduct foodProduct, int value)
        {
            Assert.IsTrue(foodProduct == value);
        }

        /// <summary>
        /// Creating multiple objects of the FoodProduct class for testing implicit cast operator to Int32
        /// </summary>
        /// <returns>Object array</returns>
        private static IEnumerable<object[]> GetDataForTestingCastOperatorToInt32()
        {
            yield return new object[] { new FoodProduct("Potato", "Food product", 0.5m), 50 };
            yield return new object[] { new FoodProduct("Mandarin", "Food product", 0.2m), 20 };
            yield return new object[] { new FoodProduct("Pasta", "Food product", 1.2m), 120 };
        }
    }
}