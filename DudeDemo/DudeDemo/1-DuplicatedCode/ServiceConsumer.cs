namespace DudeDemo
{
    using System;

    public class ServiceConsumer
    {
        private readonly Func<IMyWebService> clientFactory;

        public ServiceConsumer(Func<IMyWebService> clientFactory)
        {
            this.clientFactory = clientFactory;
        }

        public DateTime? GetBirthdayFor(string username)
        {
            DateTime? bday;
            bool successful = false;
            var client = this.clientFactory.Invoke();

            try
            {
                bday = client.GetBirthdayFor(username);
                client.Close();
                successful = true;
            }
            finally
            {
                if (!successful)
                {
                    client.Abort();
                }
            }
            return bday;
        }

        public bool ValidateThatUsernameIsAvailable(string username)
        {
            bool valid = false;
            bool successful = false;
            var client = this.clientFactory.Invoke();

            try
            {
                valid = client.CheckUsernameIsValid(username);
                client.Close();
                successful = true;
            }
            finally
            {
                if (!successful)
                {
                    client.Abort();
                }
            }
            return valid;
        }
    }
}