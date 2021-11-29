using System.Collections.Generic;
using System.Transactions;
using Banks.Entity;

namespace Banks.Services
{
    public class CentralBank
    {
        private List<Bank> _banks = new List<Bank>();
        public void CreateBank()
        {
            
        }

        public void Transaction(Bank sender, Bank recipient, int money)
        {
            
        }
    }
}