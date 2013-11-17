namespace DudeDemo
{
    using System.Collections.Generic;

    public class LoggedBreakfast
    {
        private readonly ILogger logger;

        public LoggedBreakfast(ILogger logger)
        {
            this.logger = logger;
            this.Items = new List<Food>();
        }

        public List<Food> Items { get; private set; }

        public void Make(IEnumerable<Spam> spam, IEnumerable<Egg> eggs)
        {
            logger.Log("Enter Breakfast.Make()");

            foreach (var glob in spam)
            {
                var friedSpam = glob.Fry();
                this.Items.Add(friedSpam);
            }

            foreach (var egg in eggs)
            {
                var scrambledEgg = egg.Scramble();
                this.Items.Add(scrambledEgg);
            }

            logger.Log("Exit Breakfast.Make()");
        }
    }

    public class LoggedEgg : Egg
    {
        private readonly ILogger logger;

        public LoggedEgg(ILogger logger)
        {
            this.logger = logger;
        }

        public override Food Scramble()
        {
            logger.Log("Enter Egg.Scramble().");
            var food = new Food { Name = "Scrambled Eggs" };
            logger.Log("Exit Egg.Scramble().");
            return food;
        }
    }

    public class LoggedSpam : Spam
    {
        private readonly ILogger logger;

        public LoggedSpam(ILogger logger)
        {
            this.logger = logger;
        }

        public override Food Fry()
        {
            logger.Log("Enter Spam.Fry().");
            var food = new Food { Name = "Fried Spam" };
            logger.Log("Exit Spam.Fry().");
            return food;
        }
    }
}