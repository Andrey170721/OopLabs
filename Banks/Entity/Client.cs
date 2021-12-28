using Banks.Tools;

namespace Banks.Entity
{
    public class Client
    {
        private int _passport = 0;
        private string _address = null;
        public Client(string name, string surname)
        {
            Name = name;
            Surname = surname;
        }

        public Client(string name, string surname, int passport, string address)
        {
            if ((passport < 100000) || (passport > 1000000))
            {
                throw new BankException("invalid passport number");
            }

            _passport = passport;
            _address = address;
        }

        public string Name { get; }
        public string Surname { get; }

        public void AddPassport(int passport)
        {
            if ((passport < 100000) || (passport > 1000000))
            {
                throw new BankException("invalid passport number");
            }

            _passport = passport;
        }

        public void AddAddress(string address)
        {
            _address = address;
        }

        public bool IsVerified()
        {
            if (_passport != 0 && _address != null)
            {
                return true;
            }

            return false;
        }
    }
}