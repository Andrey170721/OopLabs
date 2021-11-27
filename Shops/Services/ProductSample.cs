namespace Shops.Services
{
    public class ProductSample
    {
        public ProductSample(string newName, int newNumber)
        {
            Name = newName;
            Number = newNumber;
        }

        public string Name { get; }
        public int Number { get; }
    }
}