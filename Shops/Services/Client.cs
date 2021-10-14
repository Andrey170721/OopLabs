using System;

namespace Shops.Services
{
    public class Client
    {
        public Client(string newName, int newAmountMoney)
        {
            Name = newName;
            AmountMoney = newAmountMoney;
        }

        public string Name { get; }
        public int AmountMoney { get; }

        public Client Buy(int sum)
        {
            int remainMoney = AmountMoney - sum;
            if (remainMoney < 0)
            {
                throw new Exception("not enough money");
            }

            var changedClient = new Client(Name, remainMoney);
            return changedClient;
        }
    }
}