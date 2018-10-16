using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SwinAdventure.Tests
{
    [TestClass()]
    public class PlayerUnitTests
    {
        [TestMethod()]
        public void PLayerLocatesinLocation()
        {
            Location location = new Location(new string[] { "here" }, "here", "the desc");
            Player player = new Player("Charlie", "This is you my friend");
            Item shovel = new Item(new string[] { "shovel", "spade" },
                "a shovel",
                "This is a might fine ...");
            Item pan = new Item(new string[] { "pan" }, "a pan", "This is awesome");
            location.Inventory.Put(shovel);
            player.Inventory.Put(pan);
            player.Location = location;
            Assert.IsNotNull(player.Locate("shovel"));
        }

        [TestMethod()]
        public void TestPlayerFullDescription()
        {
            Player player = new Player("Charlie", "This is you my friend");
            Item shovel = new Item(new string[] { "shovel", "spade" },
                "a shovel",
                "This is a might fine ...");
            Item pan = new Item(new string[] { "pan" }, "a pan", "This is awesome");
            player.Inventory.Put(shovel);
            player.Inventory.Put(pan);
            Assert.IsTrue(player.FullDescription == $"You are carrying:\n{player.Inventory.ItemList}");
        }

        [TestMethod()]
        public void TestPlayerILocatesItems()
        {
            Player player = new Player("Charlie", "This is you my friend");
            Item shovel = new Item(new string[] { "shovel", "spade" },
                "a shovel",
                "This is a might fine ...");
            Item pan = new Item(new string[] { "pan" }, "a pan", "This is awesome");
            player.Inventory.Put(shovel);
            player.Inventory.Put(pan);
            Assert.IsTrue(shovel.FirstId == player.Locate("shovel").FirstId, "Player can't Locate objects");
        }

        [TestMethod()]
        public void TestPlayerIsIdentifiable()
        {
            Player player = new Player("Charlie", "This is you my friend");
            Assert.IsTrue(player.AreYou("me"),
                "The player is not identifiable");
            Assert.IsTrue(player.AreYou("inventory"),
                 "The player is not identifiable");
        }

        [TestMethod()]
        public void TestPlayerLocatesItself()
        {
            Player player = new Player("Charlie", "This is you my friend");
            Assert.IsTrue(player.Locate("me").FirstId == player.FirstId);
            Assert.IsTrue(player.Locate("inventory").FirstId == player.FirstId);
        }

        [TestMethod()]
        public void TestPlayerLocatesNothing()
        {
            Player player = new Player("Charlie", "This is you my friend");
            Assert.IsTrue(player.Locate("XYZ") == null);
        }
    }
}