using System.Collections.Generic;
using System.Transactions;
using Banks.Entity;

namespace Banks.Services
{
    public class CentralBank
    {
        private List<Bank> _banks = new List<Bank>();
        private int _id = 0;
        public void CreateBank(string name)
        {
            _banks.Add(new Bank(_id, name));
            _id++;
        }

        public AddClient(string name, string surname)
        {
            
        }

        public AddClient(string name, string surname, int passport, string address)
        {
            
        }
        public void Transaction(Bank sender, Bank recipient, int money)
        {
            
        }
    }
}