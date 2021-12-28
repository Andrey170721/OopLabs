using System.Collections.Generic;
using Banks.Entity;
using Banks.Tools;

namespace Banks.Services
{
    public class Service
    {
        private List<Client> _clients = new List<Client>();
        private CentralBank _centralBank = new CentralBank();
        private List<Transaction> _transactions = new List<Transaction>();
        private int _id = 0;

        public Bank CreateBank(string name, double percentOnBalance, double creditPercent, double creditLimit, int depositTime)
        {
            Bank bank = _centralBank.CreateBank(name, percentOnBalance, creditPercent, creditLimit, depositTime);
            return bank;
        }

        public Client AddClient(string name, string surname, int passport, string address)
        {
            var newClient = new Client(name, surname, passport, address);
            _clients.Add(newClient);
            return newClient;
        }

        public Client AddClient(string name, string surname)
        {
            var newClient = new Client(name, surname);
            _clients.Add(newClient);
            return newClient;
        }

        public Account AddAccount(Client client, Bank bank, string accountType)
        {
            Account account;
            switch (accountType)
            {
                case "Credit":
                    account = new CreditAccount(bank, client, bank.CreditLimit, bank.CreditPercent);
                    break;
                case "Debit":
                    account = new DebitAccount(bank, client, bank.PercentOnBalance);
                    break;
                case "Deposit":
                    account = new DepositAccount(bank, client, bank.DepositTime, bank.PercentOnBalance);
                    break;
                default:
                    throw new BankException("Invalid AccountType");
            }

            bank.AddAccount(account);
            bank.AddClient(client);
            return account;
        }

        public void Replenishment(Account account, double amount)
        {
            account.Replenishment(amount);
        }

        public void Withdraw(Account account, double amount)
        {
            account.Withdraw(amount);
        }

        public int Transfer(Account sender, Account recipient, double amount)
        {
            sender.Transfer(amount, recipient);
            var transaction = new Transaction(_id, sender, recipient, amount);
            _transactions.Add(transaction);
            _id++;
            return _id;
        }

        public void CancelTransaction(int id)
        {
            Transaction transaction = _transactions.Find(t => t.Id == id);
            transaction?.Recipient.Transfer(transaction.Amount, transaction.Sender);
        }
    }
}