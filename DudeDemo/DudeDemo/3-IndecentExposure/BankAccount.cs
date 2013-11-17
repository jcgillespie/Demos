namespace DudeDemo
{
    using System;

    public class BankAccount
    {
        public string AccountNumber { get; set; }

        public decimal Balance { get; private set; }

        public decimal Deposit(decimal amount)
        {
            amount = Math.Abs(amount);

            this.Balance += amount;
            return this.Balance;
        }

        public decimal Withdrawal(decimal amount)
        {
            amount = Math.Abs(amount);
            if (this.Balance < amount)
            { throw new InvalidOperationException("Insufficient funds."); }
            this.Balance -= amount;
            return this.Balance;
        }
    }
}