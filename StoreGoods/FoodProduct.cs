using System;
using System.Collections.Generic;

namespace StoreGoods
{
    class FoodProduct : Product
    {
        public FoodProduct(string name, string type, decimal price) : base(name, type, price) { }

        public static FoodProduct operator +(FoodProduct product1, FoodProduct product2) => new FoodProduct($"{product1.Name}-{product2.Name}", product1.Type, Math.Round((product1.Price + product2.Price) / 2, 2));

        public static implicit operator ElectricalProduct(FoodProduct product) => new ElectricalProduct(product.Name, product.Type, product.Price);

        public static implicit operator ConstructorProduct(FoodProduct product) => new ConstructorProduct(product.Name, product.Type, product.Price);

        public static implicit operator decimal(FoodProduct product) => product.Price;

        public static implicit operator int(FoodProduct product) => Convert.ToInt32(product.Price / 100);

        public override bool Equals(object obj) => obj is FoodProduct product && Name == product.Name && Type == product.Type && Price == product.Price;

        public override int GetHashCode()
        {
            int hashCode = 1368981669;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Type);
            hashCode = hashCode * -1521134295 + Price.GetHashCode();
            return hashCode;
        }
    }
}