namespace Banks.Entity
{
    public class Bank
    {
        public Bank(int id, string name)
        {
            Name = name;
            Id = id;
        }

        public string Name { get; }
        public int Id { get; }
        
        public Client AddClient()
        {
            
        }

        public Account AddAccount()
        {
            
        }

        public void Withdraw()
        {
            
        }

        public void Transaction()
        {
            
        }

        public void Replenishment()
        {
            
        }
    }
}