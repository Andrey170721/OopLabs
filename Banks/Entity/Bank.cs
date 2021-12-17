using System.Collections.Generic;
using Banks.Tools;

namespace Banks.Entity
{
    public class Bank
    {
        private List<Account> _accounts = new List<Account>();
        public Bank(int id, string name, float percentOnBalance, float creditPercent, float creditLimit, int depositTime)
        {
            Name = name;
            Id = id;
            Clients = new List<Client>();
            CreditPercent = creditPercent;
            PercentOnBalance = percentOnBalance;
            CreditLimit = creditLimit;
            DepositTime = depositTime;
            if (percentOnBalance > 100 ||
                percentOnBalance < 0 ||
                creditPercent > 100 ||
                creditPercent < 0) throw new BankException("invalid percent");
        }

        public float PercentOnBalance { get; }
        public float CreditPercent { get; }
        public int DepositTime { get; }
        public float CreditLimit { get; }
        public List<Client> Clients { get; }

        public string Name { get; }
        public int Id { get; }
        public void AddClient(Client client)
        {
            Clients.Add(client);
        }

        public void AddAccount(Account account)
        {
            _accounts.Add(account);
        }
    }
}