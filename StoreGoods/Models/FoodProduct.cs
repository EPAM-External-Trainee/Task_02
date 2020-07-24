using System;

namespace StoreGoods
{
    /// <summary>
    /// Class that describes the store's food products
    /// </summary>
    public class FoodProduct : Product
    {
        /// <summary>
        /// Constructor for creating an instance of the class
        /// </summary>
        /// <param name="name">Product name</param>
        /// <param name="type">Product type</param>
        /// <param name="price">Product price</param>
        public FoodProduct(string name, string type, decimal price) : base(name, type, price) { }

        /// <summary>
        /// Overloaded operator "+" for two food products
        /// </summary>
        /// <param name="product1">First food product</param>
        /// <param name="product2">Second food product</param>
        /// <returns>The result of adding the two food products</returns>
        public static FoodProduct operator +(FoodProduct product1, FoodProduct product2) => new FoodProduct($"{product1.Name}-{product2.Name}", product1.Type, Math.Round((product1.Price + product2.Price) / 2, 2));

        /// <summary>
        /// Overloaded implicit operator for casting a food to an electrical product
        /// </summary>
        /// <param name="product">Food product</param>
        public static implicit operator ElectricalProduct(FoodProduct product) => new ElectricalProduct(product.Name, product.Type, product.Price);

        /// <summary>
        /// Overloaded implicit operator for casting a food to a construction product
        /// </summary>
        /// <param name="product">Food product</param>
        public static implicit operator ConstructionProduct(FoodProduct product) => new ConstructionProduct(product.Name, product.Type, product.Price);

        public override bool Equals(object obj) => obj is FoodProduct product && Name == product.Name && Type == product.Type && Price == product.Price;

        public override int GetHashCode()
        {
            int hashCode = 1368981669;
            hashCode = (hashCode * -1521134295) + Name.GetHashCode();
            hashCode = (hashCode * -1521134295) + Type.GetHashCode();
            hashCode = (hashCode * -1521134295) + Price.GetHashCode();
            return hashCode;
        }
    }
}