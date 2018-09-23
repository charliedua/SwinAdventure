using NUnit.Framework;

namespace SwinAdventure.UnitTests.Services
{
    [TestFixture]
    public class PlayerUnitTests
    {
        [Test]
        public static void PLayerLocatesinLocation()
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
            Assert.NotNull(player.Locate("shovel"));
        }

        [Test]
        public static void TestPlayerFullDescription()
        {
            Player player = new Player("Charlie", "This is you my friend");
            Item shovel = new Item(new string[] { "shovel", "spade" },
                "a shovel",
                "This is a might fine ...");
            Item pan = new Item(new string[] { "pan" }, "a pan", "This is awesome");
            player.Inventory.Put(shovel);
            player.Inventory.Put(pan);
            Assert.True(player.FullDescription == $"You are carrying:\n{player.Inventory.ItemList}");
        }

        [Test]
        public static void TestPlayerILocatesItems()
        {
            Player player = new Player("Charlie", "This is you my friend");
            Item shovel = new Item(new string[] { "shovel", "spade" },
                "a shovel",
                "This is a might fine ...");
            Item pan = new Item(new string[] { "pan" }, "a pan", "This is awesome");
            player.Inventory.Put(shovel);
            player.Inventory.Put(pan);
            Assert.True(shovel.FirstId == player.Locate("shovel").FirstId, "Player can't Locate objects");
        }

        [Test]
        public static void TestPlayerIsIdentifiable()
        {
            Player player = new Player("Charlie", "This is you my friend");
            Assert.True(player.AreYou("me"),
                "The player is not identifiable");
            Assert.True(player.AreYou("inventory"),
                 "The player is not identifiable");
        }

        [Test]
        public static void TestPlayerLocatesItself()
        {
            Player player = new Player("Charlie", "This is you my friend");
            Assert.True(player.Locate("me").FirstId == player.FirstId);
            Assert.True(player.Locate("inventory").FirstId == player.FirstId);
        }

        [Test]
        public static void TestPlayerLocatesNothing()
        {
            Player player = new Player("Charlie", "This is you my friend");
            Assert.True(player.Locate("XYZ") == null);
        }
    }
}