using Microsoft.VisualStudio.TestTools.UnitTesting;
using StoreGoods;
using System.Collections.Generic;

namespace StoreGoodsUnitTests
{
    /// <summary>
    /// Class that tests methods of ElectricalProduct class
    /// </summary>
    [TestClass]
    public class ElectricalProductTests
    {
        [DataTestMethod, Description("Testing the overloaded " + " operator of two objects of class ElectricalProduct")]
        [DynamicData(nameof(GetElectricalProductObjectsForTestingOperatorPlus), DynamicDataSourceType.Method)]
        public void OverloadedBinaryPlusOperator_TwoElectricalProductObjects_PositiveTestResult(ElectricalProduct product1, ElectricalProduct product2, ElectricalProduct expectedProduct)
        {
            Assert.AreEqual(expectedProduct, product1 + product2);
        }

        /// <summary>
        /// Creating multiple objects of the ElectricalProduct class for testing the overloaded binary operator plus
        /// </summary>
        /// <returns>Object array</returns>
        private static IEnumerable<object[]> GetElectricalProductObjectsForTestingOperatorPlus()
        {
            yield return new object[] { new ElectricalProduct("Laptop", "Electrical product", 55m), new ElectricalProduct("Kettle", "Electrical product", 10m), new ElectricalProduct("Laptop-Kettle", "Electrical product", 32.5m) };
            yield return new object[] { new ElectricalProduct("TV", "Electrical product", 21m), new ElectricalProduct("Fridge", "Electrical product", 33m), new ElectricalProduct("TV-Fridge", "Electrical product", 27m) };
            yield return new object[] { new ElectricalProduct("Radio", "Electrical product", 12m), new ElectricalProduct("Playstation", "Electrical product", 31m), new ElectricalProduct("Radio-Playstation", "Electrical product", 21.5m) };
        }

        [DataTestMethod, Description("Testing the overloaded implicit operator ConstructionProduct casting ElectricalProduct to ConstructionProduct")]
        [DynamicData(nameof(GetProductObjectsForTestingCastOperatorConstructionProduct), DynamicDataSourceType.Method)]
        public void OverloadedImplicitCastOperatorConstructionProduct_CastingElectricalToConstructionProduct_PositiveTestResult(ConstructionProduct expectedProduct, ElectricalProduct electricalProduct)
        {
            Assert.AreEqual(expectedProduct, (ConstructionProduct)electricalProduct);
        }

        /// <summary>
        /// Creating multiple objects of the ConstructionProduct and ElectricalProduct class for testing implicit cast operator ConstructionProduct
        /// </summary>
        /// <returns>Object array</returns>
        private static IEnumerable<object[]> GetProductObjectsForTestingCastOperatorConstructionProduct()
        {
            yield return new object[] { new ConstructionProduct("Laptop", "Electrical product", 55m), new ElectricalProduct("Laptop", "Electrical product", 55m) };
            yield return new object[] { new ConstructionProduct("Radio", "Electrical product", 19m), new ElectricalProduct("Radio", "Electrical product", 19m)};
            yield return new object[] { new ConstructionProduct("Smartphone", "Electrical product", 31m), new ElectricalProduct("Smartphone", "Electrical product", 31m) };
        }

        [DataTestMethod, Description("Testing the overloaded implicit operator FoodProduct casting ElectricalProduct to FoodProduct")]
        [DynamicData(nameof(GetProductObjectsForTestingCastOperatorFoodProduct), DynamicDataSourceType.Method)]
        public void OverloadedImplicitCastOperatorFoodProduct_CastingElectricalToFoodProduct_PositiveTestResult(FoodProduct expectedProduct, ElectricalProduct electricalProduct)
        {
            Assert.AreEqual(expectedProduct, (FoodProduct)electricalProduct);
        }

        /// <summary>
        /// Creating multiple objects of the ConstructionProduct and ElectricalProduct class for testing implicit cast operator ConstructionProduct
        /// </summary>
        /// <returns>Object array</returns>
        private static IEnumerable<object[]> GetProductObjectsForTestingCastOperatorFoodProduct()
        {
            yield return new object[] { new FoodProduct("Potato", "Food product", 0.5m), new ElectricalProduct("Potato", "Food product", 0.5m) };
            yield return new object[] { new FoodProduct("Meat", "Food product", 0.2m), new ElectricalProduct("Meat", "Food product", 0.2m) };
            yield return new object[] { new FoodProduct("Milk", "Food product", 1.6m), new ElectricalProduct("Milk", "Food product", 1.6m) };
        }

        [DataTestMethod, Description("Testing an overloaded cast operator to Decimal")]
        [DynamicData(nameof(GetDataForTestingCastOperatorToDecimal), DynamicDataSourceType.Method)]
        public void OverloadedDecimalCastOperator(ElectricalProduct electricalProduct, decimal value)
        {
            Assert.IsTrue(electricalProduct == value);
        }

        /// <summary>
        /// Creating multiple objects of the ElectricalProduct class for testing implicit cast operator to Decimal
        /// </summary>
        /// <returns>Object array</returns>
        private static IEnumerable<object[]> GetDataForTestingCastOperatorToDecimal()
        {
            yield return new object[] { new ElectricalProduct("Laptop", "Electrical product", 55m), 55m };
            yield return new object[] { new ElectricalProduct("TV", "Electrical product", 21m), 21m };
            yield return new object[] { new ElectricalProduct("Radio", "Electrical product", 12m), 12m };
        }

        [DataTestMethod, Description("Testing an overloaded cast operator to Int32")]
        [DynamicData(nameof(GetDataForTestingCastOperatorToInt32), DynamicDataSourceType.Method)]
        public void OverloadedInt32CastOperator(ElectricalProduct electricalProduct, int value)
        {
            Assert.IsTrue(electricalProduct == value);
        }

        /// <summary>
        /// Creating multiple objects of the ElectricalProduct class for testing implicit cast operator to Int32
        /// </summary>
        /// <returns>Object array</returns>
        private static IEnumerable<object[]> GetDataForTestingCastOperatorToInt32()
        {
            yield return new object[] { new ElectricalProduct("Laptop", "Electrical product", 55m), 5500 };
            yield return new object[] { new ElectricalProduct("TV", "Electrical product", 21m), 2100 };
            yield return new object[] { new ElectricalProduct("Radio", "Electrical product", 12m), 1200 };
        }
    }
}