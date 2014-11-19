namespace AspNetTotp.Totp
{
    using System;
    using System.Threading.Tasks;

    using Microsoft.AspNet.Identity;

    using OtpSharp;

    public class TotpTimeBasedUserTokenProvider<TUser, TKey> : IUserTokenProvider<TUser, TKey>
        where TKey : IEquatable<TKey> where TUser : class, IUser<TKey>, ITotpUser
    {
        public Task<string> GenerateAsync(string purpose, UserManager<TUser, TKey> manager, TUser user)
        {
            return Task.FromResult((string)null);
        }

        public Task<bool> ValidateAsync(string purpose, string token, UserManager<TUser, TKey> manager, TUser user)
        {
            if (!user.IsTotpEnabled())
            {
                return Task.FromResult(false);
            }

            long timeStepMatched;
            var totp = new Totp(user.TotpSecretKey);
            bool valid = totp.VerifyTotp(token, out timeStepMatched, new VerificationWindow(2, 2));

            return Task.FromResult(valid);
        }

        public Task NotifyAsync(string token, UserManager<TUser, TKey> manager, TUser user)
        {
            return Task.FromResult(true);
        }

        public Task<bool> IsValidProviderForUserAsync(UserManager<TUser, TKey> manager, TUser user)
        {
            return Task.FromResult(user.IsTotpEnabled());
        }
    }
}