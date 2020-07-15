using System;

namespace StoreGoods
{
    class ElectricalProduct : Product
    {
        public ElectricalProduct(string name, string type, decimal price) : base(name, type, price) { }

        public static ElectricalProduct operator +(ElectricalProduct product1, ElectricalProduct product2) => new ElectricalProduct($"{product1.Name}-{product2.Name}", product1.Type, Math.Round((product1.Price + product2.Price) / 2, 2));

        public static implicit operator ConstructorProduct(ElectricalProduct product) => new ConstructorProduct(product.Name, product.Type, product.Price);

        public static implicit operator FoodProduct(ElectricalProduct electricalProduct) => new FoodProduct(electricalProduct.Name, electricalProduct.Type, electricalProduct.Price);

        public static implicit operator int(ElectricalProduct electricalProduct) => Convert.ToInt32(electricalProduct.Price * 100);

        public static implicit operator decimal(ElectricalProduct electricalProduct) => electricalProduct.Price;

        public override bool Equals(object obj) => obj is ElectricalProduct product && Name == product.Name && Type == product.Type && Price == product.Price;

        public override int GetHashCode() => Name.GetHashCode() + Type.GetHashCode() + Price.GetHashCode();
    }
}