namespace Banks.Entity
{
    public class Transaction
    {
        public Transaction(int id, Account sender, Account recipient, double amount)
        {
            Id = id;
            Sender = sender;
            Recipient = recipient;
            Amount = amount;
        }

        public Account Sender { get; }
        public Account Recipient { get; }
        public double Amount { get; }
        public int Id { get; }
    }
}