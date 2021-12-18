using Banks.Tools;

namespace Banks.Entity
{
    public class DepositAccount : Account
    {
        private bool _isDeadlinePassed;
        private double _percentSum;
        private double _percentOnBalance;
        private int _monthCounter;
        private int _depositTime;
        public DepositAccount(Bank bank, Client owner, int depositTime, double percentOnBalance)
        {
            if (depositTime < 0) throw new BankException("invalid depositTime");
            AmountMoney = 0;
            Bank = bank;
            Owner = owner;
            _percentOnBalance = percentOnBalance;
            _isDeadlinePassed = false;
            _depositTime = depositTime;
        }

        public override void Replenishment(double amount)
        {
            AmountMoney += amount;
        }

        public override void Withdraw(double amount)
        {
            if (!_isDeadlinePassed) throw new BankException("the time of the deposit has not expired yet");
            if (!Owner.IsVerified()) throw new BankException("Client is not Verified");
            AmountMoney -= amount;
        }

        public override void Transfer(double amount, Account recipient)
        {
            if (!Owner.IsVerified()) throw new BankException("Client is not Verified");
            Replenishment(amount);
            recipient.Withdraw(amount);
        }

        public override void PercentCounter()
        {
            _percentSum += AmountMoney * ((_percentOnBalance / 365) / 100);
        }

        public override void AccrualPercent()
        {
            AmountMoney += _percentSum;
            _monthCounter++;
            if (_monthCounter >= _depositTime) _isDeadlinePassed = true;
        }
    }
}