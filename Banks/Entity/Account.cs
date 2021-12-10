using System.Dynamic;

namespace Banks.Entity
{
    public abstract class Account
    {
        protected int amountMoney;
        public abstract int Replenishment(int money);
        public abstract int Withdraw(int money);
        public abstract int Transfer(int money, Client client);
        public abstract void CancelingTransaction(int id);
    }