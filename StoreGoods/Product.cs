namespace StoreGoods
{
    /// <summary>
    /// Сlass that describes the store's product
    /// </summary>
    public abstract class Product
    {
        /// <summary>
        /// Product name
        /// </summary>
        protected string Name { get; set; }

        /// <summary>
        /// Product type
        /// </summary>
        protected string Type { get; set; }

        /// <summary>
        /// Product price
        /// </summary>
        protected decimal Price { get; set; }

        /// <summary>
        /// Constructor for creating an instance of the class
        /// </summary>
        /// <param name="name">Product name</param>
        /// <param name="type">Product type</param>
        /// <param name="price">Product price</param>
        protected Product(string name, string type, decimal price)
        {
            Type = type;
            Name = name;
            Price = price;
        }

        public override string ToString() => $"Product name: {Name}, type: {Type}, price: {Price}$";
    }
}