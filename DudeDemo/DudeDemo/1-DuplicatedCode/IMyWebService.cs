namespace DudeDemo
{
    using System;
    using System.ServiceModel;

    public interface IMyWebService : IClientChannel
    {
        bool CheckUsernameIsValid(string username);

        DateTime GetBirthdayFor(string username);
    }
}