using System.Threading;
using Banks.Tools;

namespace Banks.Entity
{
    public class DepositAccount : Account
    {
        private bool _isDeadlinePassed;
        private float _percent;
        private float _percentOnBalance;
        public DepositAccount(Bank bank, Client owner, int depositTime, float percentOnBalance)
        {
            if (depositTime < 0) throw new BankException("invalid depositTime");
            amountMoney = 0;
            Bank = bank;
            Owner = owner;
            _percentOnBalance = percentOnBalance;
            _isDeadlinePassed = false;
            TimerCallback tm = new TimerCallback(PercentCounter);
            TimerCallback tm2 = new TimerCallback(AccrualPercent);
            Timer timer1 = new Timer(tm, null, 0, 5184000);
            Timer timer2 = new Timer(tm2, null, 0, depositTime * 30 * 24 * 60 * 60 * 60);
        }

        public override void Replenishment(float amount)
        {
            amountMoney += amount;
        }

        public override void Withdraw(float amount)
        {
            if (!_isDeadlinePassed) throw new BankException("the time of the deposit has not expired yet");
            amountMoney -= amount;
        }

        public override void Transfer(float amount, Account recipient)
        {
            Replenishment(amount);
            recipient.Withdraw(amount);
        }

        public override void CancelingTransaction(int id)
        {
            throw new System.NotImplementedException();
        }

        private void PercentCounter(object obj)
        {
            _percent += amountMoney * ((_percentOnBalance / 365) / 100);
        }

        private void AccrualPercent(object obj)
        {
            amountMoney += _percent;
            _isDeadlinePassed = true;
        }
    }
}