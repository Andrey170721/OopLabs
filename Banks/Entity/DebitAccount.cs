using System;
using System.Threading;
using Banks.Tools;

namespace Banks.Entity
{
    public class DebitAccount : Account
    {
        private float _percent = 0;
        private float _percentOnBalance;
        public DebitAccount(Bank bank, Client owner, float percentOnBalance)
        {
            amountMoney = 0;
            Bank = bank;
            Owner = owner;
            _percentOnBalance = percentOnBalance;
            TimerCallback tm = new TimerCallback(PercentCounter);
            TimerCallback tm2 = new TimerCallback(AccrualPercent);
            Timer timer1 = new Timer(tm, null, 0, 5184000);
            Timer timer2 = new Timer(tm2, null, 0, 155520000);
        }

        public override void Replenishment(float amount)
        {
            amountMoney = amountMoney + amount;
        }

        public override void Withdraw(float amount)
        {
            amountMoney = amountMoney - amount;
            if (amountMoney < 0) throw new BankException("not enough money");
        }

        public override void Transfer(float amount, Account recipient)
        {
            Withdraw(amount);
            recipient.Replenishment(amount);
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
        }
    }
}