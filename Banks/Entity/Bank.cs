using System.Collections.Generic;
using Banks.Tools;

namespace Banks.Entity
{
    public class Bank
    {
        public Bank(int id, string name, double percentOnBalance, double creditPercent, double creditLimit, int depositTime)
        {
            Name = name;
            Id = id;
            Clients = new List<Client>();
            CreditPercent = creditPercent;
            PercentOnBalance = percentOnBalance;
            CreditLimit = creditLimit;
            DepositTime = depositTime;
            Accounts = new List<Account>();
            if (percentOnBalance > 100 ||
                percentOnBalance < 0 ||
                creditPercent > 100 ||
                creditPercent < 0) throw new BankException("invalid percent");
        }

        public double PercentOnBalance { get; }
        public double CreditPercent { get; }
        public int DepositTime { get; }
        public double CreditLimit { get; }
        public List<Client> Clients { get; }
        public List<Account> Accounts { get; }

        public string Name { get; }
        public int Id { get; }
        public void AddClient(Client client)
        {
            Clients.Add(client);
        }

        public void AddAccount(Account account)
        {
            Accounts.Add(account);
        }
    }
}