namespace Shops.Services
{
    public class Shop
    {
        public Shop(int newID, string newName, string newAddress)
        {
            ID = newID;
            Name = newName;
            Address = newAddress;
        }

        public int ID { get; }
        public string Name { get; }
        public string Address { get; }
    }
}