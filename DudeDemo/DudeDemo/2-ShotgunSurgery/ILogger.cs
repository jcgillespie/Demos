namespace DudeDemo
{
    using System;

    public interface ILogger
    {
        void Log(string message);
    }

    public class Logger : ILogger
    {
        private readonly Action<string> logAction;

        public Logger(Action<string> logAction)
        {
            this.logAction = logAction;
        }

        public void Log(string message)
        {
            this.logAction(message);
        }
    }
}