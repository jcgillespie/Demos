namespace DudeDemo
{
    using System.Text;

    public class Address
    {
        public string City { get; set; }

        public string Line1 { get; set; }

        public string Line2 { get; set; }

        public string State { get; set; }

        public string Zip { get; set; }
    }

    public class Person
    {
        public string FirstName { get; set; }

        public Address HomeAddress { get; set; }

        public string LastName { get; set; }

        public Address WorkAddress { get; set; }

        public string FormatHomeAddress()
        {
            if (this.HomeAddress == null)
                return string.Empty;

            var labelBuilder = new StringBuilder();
            if (!string.IsNullOrEmpty(this.HomeAddress.Line1))
            {
                labelBuilder.AppendLine(this.HomeAddress.Line1);
            }

            if (!string.IsNullOrEmpty(this.HomeAddress.Line2))
            {
                labelBuilder.AppendLine(this.HomeAddress.Line2);
            }

            if (!string.IsNullOrEmpty(this.HomeAddress.City))
            {
                labelBuilder.Append(this.HomeAddress.City).Append(", ");
            }

            if (!string.IsNullOrEmpty(this.HomeAddress.State))
            {
                labelBuilder.Append(this.HomeAddress.State).Append(" ");
            }

            if (!string.IsNullOrEmpty(this.HomeAddress.Zip))
            {
                labelBuilder.Append(this.HomeAddress.Zip);
            }

            return labelBuilder.ToString();
        }
    }
}