namespace DudeDemo
{
    public class Wallet
    {
        public decimal TotalMoney { get; private set; }

        public void AddMoney(decimal deposit)
        {
            this.TotalMoney += deposit;
        }

        public void SubtractMoney(decimal debit)
        {
            this.TotalMoney -= debit;
        }
    }
}