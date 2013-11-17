namespace DudeDemo
{
    using System.Collections.Generic;

    public class Paperboy
    {
        private decimal PiggyBank;

        public Paperboy()
        {
            this.Customers = new List<Customer>();
            this.DeliquentCustomers = new List<Customer>();
        }

        private List<Customer> Customers { get; set; }

        private List<Customer> DeliquentCustomers { get; set; }

        public void CollectPayments(decimal amount)
        {
            foreach (var customer in this.Customers)
            {
                var wallet = customer.MyWallet;
                if (wallet.TotalMoney < amount)
                {
                    // come back later and get payment
                    this.DeliquentCustomers.Add(customer);
                }
                else
                {
                    wallet.SubtractMoney(amount);
                    this.PiggyBank += amount;
                }
            }
        }

        private string GetReceipt(decimal amount)
        {
            return "Thank you! Here is your receipt for " + amount.ToString("C");
        }
    }
}