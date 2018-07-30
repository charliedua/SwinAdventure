using NUnit.Framework;

namespace SwinAdventure.UnitTests.Services
{
    [TestFixture]
    public class ItemUnitTests
    {
        [Test]
        public void TestItemIsIdentifiable()
        {
            Item shovel = new Item(new string[] { "shovel", "spade" },
                "a shovel", 
                "This is a might fine ...");
            Assert.True(shovel.AreYou("shovel"),
                "The item is not identifiable");
        }

        /*
        [Test]
        public void TestShortDescription()
        {
            Item shovel = new Item(new string[] { "shovel", "spade" },
                "a shovel",
                "This is a might fine ...");
            Assert.True(shovel.ShortDescription == "a shovel(shovel)", 
                "Short description is not correct!");
        }
        */

        [Test]
        public void TestFullDescription()
        {
            Item shovel = new Item(new string[] { "shovel", "spade" },
                "a shovel",
                "This is a might fine");
            Assert.True(shovel.FullDescription == "This is a might fine", 
                "Full description is not correct");
        }
    }
}