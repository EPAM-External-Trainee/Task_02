using System;

namespace StoreGoods
{
    /// <summary>
    /// Class that describes the store's construction products
    /// </summary>
    class ConstructionProduct : Product
    {
        /// <summary>
        /// Constructor for creating an instance of the class
        /// </summary>
        /// <param name="name">Product name</param>
        /// <param name="type">Product type</param>
        /// <param name="price">Product price</param>
        public ConstructionProduct(string name, string type, decimal price) : base(name, type, price) { }

        /// <summary>
        /// Overloaded operator "+" for two construction products
        /// </summary>
        /// <param name="product1">First construction product</param>
        /// <param name="product2">Second construction product</param>
        /// <returns>The result of adding the two construction products</returns>
        public static ConstructionProduct operator +(ConstructionProduct product1, ConstructionProduct product2) => new ConstructionProduct($"{product1.Name}-{product2.Name}", product1.Name, Math.Round((product1.Price + product2.Price) / 2, 2));

        /// <summary>
        /// Overloaded implicit operator for casting a construction product to a food product
        /// </summary>
        /// <param name="product">Construction product</param>
        public static implicit operator FoodProduct(ConstructionProduct product) => new FoodProduct(product.Name, product.Type, product.Price);

        /// <summary>
        /// Overloaded implicit operator for casting a construction product to a electrical product
        /// </summary>
        /// <param name="product">Construction product</param>
        public static implicit operator ElectricalProduct(ConstructionProduct product) => new ElectricalProduct(product.Name, product.Type, product.Price);

        /// <summary>
        /// Overloaded implicit operator for casting a construction product to Decimal
        /// </summary>
        /// <param name="product"></param>
        public static implicit operator decimal(ConstructionProduct product) => product.Price;

        /// <summary>
        /// Overloaded implicit operator for casting a construction product to Int32
        /// </summary>
        /// <param name="product"></param>
        public static implicit operator int(ConstructionProduct product) => Convert.ToInt32(product.Price * 100);

        public override bool Equals(object obj) => obj is ConstructionProduct product && Name == product.Name && Type == product.Type && Price == product.Price;

        public override int GetHashCode() => Name.GetHashCode() + Type.GetHashCode() + Price.GetHashCode();
    }
}