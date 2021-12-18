using Banks.Tools;

namespace Banks.Entity
{
    public class DebitAccount : Account
    {
        private double _percentSum = 0;
        private double _percentOnBalance;
        public DebitAccount(Bank bank, Client owner, double percentOnBalance)
        {
            AmountMoney = 0;
            Bank = bank;
            Owner = owner;
            _percentOnBalance = percentOnBalance;
        }

        public override void Replenishment(double amount)
        {
            AmountMoney = AmountMoney + amount;
        }

        public override void Withdraw(double amount)
        {
            if (!Owner.IsVerified()) throw new BankException("Client is not Verified");
            AmountMoney = AmountMoney - amount;
            if (AmountMoney < 0) throw new BankException("not enough money");
        }

        public override void Transfer(double amount, Account recipient)
        {
            if (!Owner.IsVerified()) throw new BankException("Client is not Verified");
            Withdraw(amount);
            recipient.Replenishment(amount);
        }

        public override void PercentCounter()
        {
            _percentSum += AmountMoney * ((_percentOnBalance / 365) / 100);
        }

        public override void AccrualPercent()
        {
            AmountMoney += _percentSum;
        }
    }
}