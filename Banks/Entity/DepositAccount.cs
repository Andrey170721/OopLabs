namespace Banks.Entity
{
    public class DepositAccount : Account
    {
        public override int Replenishment(int money)
        {
            throw new System.NotImplementedException();
        }

        public override int Withdraw(int money)
        {
            throw new System.NotImplementedException();
        }

        public override int Transfer(int money, Client client)
        {
            throw new System.NotImplementedException();
        }

        public override void CancelingTransaction(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}