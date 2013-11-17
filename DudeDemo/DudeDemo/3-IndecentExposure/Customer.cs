namespace DudeDemo
{
    using System.Linq;

    public class Customer
    {
        private static string myAccountNumber = "ABC123456789";
        private readonly Bank myBank;

        public Customer()
        {
            this.myBank = new Bank();
            this.MyWallet = new Wallet();
        }

        public Wallet MyWallet { get; private set; }

        public decimal GetMoney(decimal billAmount)
        {
            var myAccount = this.myBank.Vault.Single(v => v.AccountNumber == myAccountNumber);
            var remainingBalance = myAccount.Withdrawal(billAmount);

            return remainingBalance;
        }
    }
}