namespace DudeDemo
{
    using System.Collections.Generic;
    using System.Linq;

    public class Bank
    {
        public Bank()
        {
            this.Vault = new List<BankAccount>();
        }

        public List<BankAccount> Vault { get; private set; }
    }
}