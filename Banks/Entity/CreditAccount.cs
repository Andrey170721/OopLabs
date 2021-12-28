using Banks.Tools;

namespace Banks.Entity
{
    public class CreditAccount : Account
    {
        private double _creditLimit;
        private double _creditPercent;
        private double _percentSum;
        public CreditAccount(Bank bank, Client owner, double creditLimit, double creditPercent)
        {
            AmountMoney = 0;
            Bank = bank;
            Owner = owner;
            _creditLimit = creditLimit;
            _creditPercent = creditPercent;
        }

        public override void Replenishment(double amount)
        {
            AmountMoney = AmountMoney + amount;
        }

        public override void Withdraw(double amount)
        {
            if (!Owner.IsVerified()) throw new BankException("Client is not Verified");
            AmountMoney = AmountMoney - amount;
            if (AmountMoney < 0 - _creditLimit) throw new BankException("credit limit exhausted");
        }

        public override void Transfer(double amount, Account recipient)
        {
            if (!Owner.IsVerified()) throw new BankException("Client is not Verified");
            Withdraw(amount);
            recipient.Replenishment(amount);
        }

        public override void PercentCounter()
        {
            _percentSum += AmountMoney * ((_creditPercent / 365) / 100);
        }

        public override void AccrualPercent()
        {
            AmountMoney -= _percentSum;
        }
    }
}