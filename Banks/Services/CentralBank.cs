using System.Collections.Generic;
using System.Transactions;
using Banks.Entity;

namespace Banks.Services
{
    public class CentralBank
    {
        private int _id = 0;
        private List<Bank> _banks;

        public CentralBank()
        {
            _banks = new List<Bank>();
        }

        public Bank CreateBank(string name, float percentOnBalance, float creditPercent, float creditLimit, int depositTime)
        {
            Bank bank = new Bank(_id, name, percentOnBalance, creditPercent, creditLimit, depositTime);
            _banks.Add(bank);
            _id++;
            return bank;
        }

        public Bank FindBank(Client client)
        {
            Bank bank = _banks.Find(b => b.Clients.Contains(client));
            return bank;
        }
    }
}