using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SwinAdventure.Tests
{
    [TestClass()]
    public class ItemUnitTests
    {
        [TestMethod()]
        public void TestItemIsIdentifiable()
        {
            Item shovel = new Item(new string[] { "shovel", "spade" },
                "a shovel",
                "This is a might fine ...");
            Assert.IsTrue(shovel.AreYou("shovel"),
                "The item is not identifiable");
        }

        [TestMethod()]
        public void TestShortDescription()
        {
            Item shovel = new Item(new string[] { "shovel", "spade" },
                "a shovel",
                "This is a might fine ...");
            Assert.IsTrue(shovel.ShortDescription == "a shovel (shovel)",
                "Short description is not correct!");
        }

        [TestMethod()]
        public void TestFullDescription()
        {
            Item shovel = new Item(new string[] { "shovel", "spade" },
                "a shovel",
                "This is a might fine");
            Assert.IsTrue(shovel.FullDescription == "This is a might fine",
                "Full description is not correct");
        }
    }
}