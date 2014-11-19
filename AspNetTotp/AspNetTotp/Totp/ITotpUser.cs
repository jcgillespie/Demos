namespace AspNetTotp.Totp
{
    public interface ITotpUser
    {
        byte[] TotpSecretKey { get; }

        void DisableTotp();

        void EnableTotp(byte[] key);

        bool IsTotpEnabled();
    }
}