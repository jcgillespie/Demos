namespace DudeDemo.Tests
{
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class BreakfastTests
    {
        public TestContext TestContext { get; set; }

        [TestCategory("Breakfast")]
        [TestMethod]
        public void CanMakeBreakfast()
        {
            var eggs = Enumerable.Range(0, 6).Select(n => new Egg()).ToList();
            var spam = Enumerable.Range(0, 12).Select(n => new Spam()).ToList();
            var totalItems = eggs.Count + spam.Count;
            var breakfast = new Breakfast();

            breakfast.Make(spam, eggs);

            Assert.IsNotNull(breakfast);
            Assert.AreEqual(totalItems, breakfast.Items.Count);
        }

        [TestCategory("Breakfast")]
        [TestMethod]
        public void CanMakeBreakfastLogged()
        {
            var logger = new Logger((s) => this.TestContext.WriteLine(s));

            var eggs = Enumerable.Range(0, 6).Select(n => new LoggedEgg(logger)).ToList();
            var spam = Enumerable.Range(0, 12).Select(n => new LoggedSpam(logger)).ToList();
            var totalItems = eggs.Count + spam.Count;
            var breakfast = new LoggedBreakfast(logger);

            breakfast.Make(spam, eggs);

            Assert.IsNotNull(breakfast);
            Assert.AreEqual(totalItems, breakfast.Items.Count);
        }
    }
}