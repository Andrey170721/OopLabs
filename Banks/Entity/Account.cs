namespace Banks.Entity
{
    public abstract class Account
    {
        public double AmountMoney { get; protected set; }
        public Bank Bank { get; protected set; }
        public Client Owner { get; protected set; }
        public abstract void Replenishment(double amount);
        public abstract void Withdraw(double amount);
        public abstract void Transfer(double amount, Account recipient);
        public abstract void PercentCounter();

        public abstract void AccrualPercent();
    }
}