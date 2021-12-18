using Banks.Entity;
using Banks.Services;

namespace Banks
{
    internal static class Program
    {
        private static void Main()
        {
            var service = new Service();
            Bank bank = service.CreateBank("Sberbank", 3.5, 7.9, 100000, 1);
            Client client = service.AddClient("IVAN", "IVANOV", 307553, "Moscow");
            Account account = service.AddAccount(client, bank, "Debit");
            service.Replenishment(account, 5000);
            Client client2 = service.AddClient("Andrey", "Andreev");
            Account account2 = service.AddAccount(client2, bank, "Debit");
            service.Transfer(account, account2, 3000);
        }
    }
}
