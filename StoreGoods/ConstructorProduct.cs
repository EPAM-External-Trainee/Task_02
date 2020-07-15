using System;

namespace StoreGoods
{
    class ConstructorProduct : Product
    {
        public ConstructorProduct(string name, string type, decimal price) : base(name, type, price) { }

        public static ConstructorProduct operator +(ConstructorProduct product1, ConstructorProduct product2) => new ConstructorProduct($"{product1.Name}-{product2.Name}", product1.Name, Math.Round((product1.Price + product2.Price) / 2, 2));

        public static implicit operator FoodProduct(ConstructorProduct product) => new FoodProduct(product.Name, product.Type, product.Price);

        public static implicit operator ElectricalProduct(ConstructorProduct product) => new ElectricalProduct(product.Name, product.Type, product.Price);

        public static implicit operator decimal(ConstructorProduct product) => product.Price;

        public static implicit operator int(ConstructorProduct product) => Convert.ToInt32(product.Price * 100);

        public override bool Equals(object obj) => obj is ConstructorProduct product && Name == product.Name && Type == product.Type && Price == product.Price;

        public override int GetHashCode() => Name.GetHashCode() + Type.GetHashCode() + Price.GetHashCode();
    }
}