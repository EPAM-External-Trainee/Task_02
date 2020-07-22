using System;

namespace StoreGoods
{
    /// <summary>
    /// Class that describes the store's electrical products
    /// </summary>
    class ElectricalProduct : Product
    {
        /// <summary>
        /// Constructor for creating an instance of the class
        /// </summary>
        /// <param name="name">Product name</param>
        /// <param name="type">Product type</param>
        /// <param name="price">Product price</param>
        public ElectricalProduct(string name, string type, decimal price) : base(name, type, price) { }

        /// <summary>
        /// Overloaded operator "+" for two electrical products
        /// </summary>
        /// <param name="product1">First electrical product</param>
        /// <param name="product2">Second electrical product</param>
        /// <returns>The result of adding the two electrical products</returns>
        public static ElectricalProduct operator +(ElectricalProduct product1, ElectricalProduct product2) => new ElectricalProduct($"{product1.Name}-{product2.Name}", product1.Type, Math.Round((product1.Price + product2.Price) / 2, 2));

        /// <summary>
        /// Overloaded implicit operator for casting an electrical product to a construction product
        /// </summary>
        /// <param name="product">Electrical product</param>
        public static implicit operator ConstructionProduct(ElectricalProduct product) => new ConstructionProduct(product.Name, product.Type, product.Price);

        /// <summary>
        /// Overloaded implicit operator for casting an electrical product to a food product
        /// </summary>
        /// <param name="product">Electrical product</param>
        public static implicit operator FoodProduct(ElectricalProduct product) => new FoodProduct(product.Name, product.Type, product.Price);

        public override bool Equals(object obj) => obj is ElectricalProduct product && Name == product.Name && Type == product.Type && Price == product.Price;

        public override int GetHashCode()
        {
            int hashCode = 1368981669;
            hashCode = hashCode * -1521134295 + Name.GetHashCode();
            hashCode = hashCode * -1521134295 + Type.GetHashCode();
            hashCode = hashCode * -1521134295 + Price.GetHashCode();
            return hashCode;
        }
    }
}