using System.Dynamic;

namespace Banks.Entity
{
    public abstract class Account
    {
        protected float amountMoney;
        public Bank Bank { get; protected set; }
        public Client Owner { get; protected set; }
        public abstract void Replenishment(float amount);
        public abstract void Withdraw(float amount);
        public abstract void Transfer(float amount, Account recipient);
        public abstract void CancelingTransaction(int id);
    }
}