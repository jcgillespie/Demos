namespace DudeDemo
{
    using System.Collections.Generic;

    public class Breakfast
    {
        public Breakfast()
        {
            this.Items = new List<Food>();
        }

        public List<Food> Items { get; private set; }

        public void Make(IEnumerable<Spam> spam, IEnumerable<Egg> eggs)
        {
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
        }
    }

    public class Egg
    {
        public virtual Food Scramble()
        {
            var food = new Food { Name = "Scrambled Eggs" };
            return food;
        }
    }

    public class Food
    {
        public string Name { get; set; }
    }

    public class Spam
    {
        public virtual Food Fry()
        {
            var food = new Food { Name = "Fried Spam" };
            return food;
        }
    }
}