using System.Net.Sockets;
using System.Security.Cryptography;

namespace Banks.Entity
{
    public class Client
    {
        public Client(string name, string surname)
        {
            Name = name;
            Surname = surname;
            IsVerified = false;
        }

        public void AddPassport(int passport)
        {
            
        }

        public AddAddress(string address)
        {
            
        }

        public string Name { get; }
        public string Surname { get; }
        public int Passport { get; }
        public string Address { get; }
        public bool IsVerified { get; }
    }
}