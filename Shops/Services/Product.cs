namespace Shops.Services
{
    public class Product
    {
        public Product(string newName, int newNumber, int newPrice)
        {
            Name = newName;
            Number = newNumber;
            Price = newPrice;
        }

        public string Name { get; }
        public int Number { get; }
        public int Price { get; }

        public Product ChangePrice(int newPrice)
        {
            var changedProduct = new Product(Name, Number, newPrice);
            return changedProduct;
        }

        public Product ChangeNumber(int newNumber)
        {
            var changedProduct = new Product(Name, newNumber, Price);
            return changedProduct;
        }
    }
}