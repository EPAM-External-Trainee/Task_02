namespace StoreGoods
{
    public abstract class Product
    {
        protected string Name { get; set; }

        protected string Type { get; set; }

        protected decimal Price { get; set; }

        protected Product(string name, string type, decimal price)
        {
            Type = type;
            Name = name;
            Price = price;
        }

        public override string ToString() => $"Product name: {Name}, type: {Type}, price: {Price}$";
    }
}