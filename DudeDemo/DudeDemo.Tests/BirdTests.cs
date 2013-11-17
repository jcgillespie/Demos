namespace DudeDemo.Tests
{
    using DudeDemo.Switch;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class BirdTests
    {
        [TestClass]
        public class AfricanSwallowTests
        {
            [TestMethod]
            [TestCategory("Birds")]
            public void LadenSwallowSpeed()
            {
                var swallow = new Bird(Bird.AfricanSwallow);
                swallow.CoconutCount = 5;

                var speed = swallow.GetAirspeed();
                Assert.AreEqual(5m, speed);
            }

            [TestCategory("Birds")]
            [TestMethod]
            public void SprintingSwallow()
            {
                var swallow = new Bird(Bird.AfricanSwallow);
                swallow.BaseAirspeed = 50m;
                swallow.CoconutCount = 2;
                var speed = swallow.GetAirspeed();

                Assert.AreEqual(44m, speed);
            }

            [TestCategory("Birds")]
            [TestMethod]
            public void UnladenAirspeed()
            {
                var swallow = new Bird(Bird.AfricanSwallow);
                swallow.CoconutCount = 0;

                var speed = swallow.GetAirspeed();
                Assert.AreEqual(20m, speed);
            }
        }

        [TestClass]
        public class NorwegianBlueTests
        {
            [TestCategory("Birds")]
            [TestMethod]
            public void AirspeedNoNails()
            {
                var norwegian = new Bird(Bird.NorwegianBlue);
                norwegian.IsNailed = false;
                var speed = norwegian.GetAirspeed();

                Assert.AreEqual(10m, speed);
            }

            [TestCategory("Birds")]
            [TestMethod]
            public void AirspeedWithNails()
            {
                var norwegian = new Bird(Bird.NorwegianBlue);
                norwegian.IsNailed = true;
                var speed = norwegian.GetAirspeed();

                Assert.AreEqual(0m, speed);
            }
        }
    }
}