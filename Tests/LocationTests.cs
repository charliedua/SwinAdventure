using NUnit.Framework;

namespace SwinAdventure.UnitTests.Services
{
    [TestFixture]
    public class LocationTests
    {
        [Test]
        public static void InitializerTest()
        {
            Location location = new Location(new string[] { "id" }, "Name", "description");
            Assert.NotNull(location.Inventory, "the inventory is null");
            Assert.NotNull(location.ShortDescription, "the description is not set");
            Assert.NotNull(location.Name, "the name is not set");
        }

        [Test]
        public static void LocateTest()
        {
            Item item = new Item(new string[] { "item" }, "name", "description");
            Location location = new Location(new string[] { "id" }, "Name", "description");
            location.Inventory.Put(item);
            var test = location.Locate("item");
            var expected = item;
            Assert.AreEqual(test, expected, "the item is not returned correctly");
        }

        [Test]
        public static void IndentifyThemselvesTest()
        {
            Location location = new Location(new string[] { "id" }, "Name", "description");
            Assert.NotNull(location.Locate("id"));
        }
    }
}