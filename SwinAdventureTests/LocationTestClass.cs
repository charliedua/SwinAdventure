using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SwinAdventure.Tests
{
    [TestClass]
    public class LocationTestClass
    {
        [TestMethod]
        public void InitializerTest()
        {
            Location location = new Location(new string[] { "id" }, "Name", "description");
            Assert.IsNotNull(location.Inventory, "the inventory is null");
            Assert.IsNotNull(location.ShortDescription, "the description is not set");
            Assert.IsNotNull(location.Name, "the name is not set");
        }

        [TestMethod]
        public void LocateTest()
        {
            Item item = new Item(new string[] { "item" }, "name", "description");
            Location location = new Location(new string[] { "id" }, "Name", "description");
            location.Inventory.Put(item);
            var test = location.Locate("item");
            var expected = item;
            Assert.AreEqual(test, expected, "the item is not returned correctly");
        }

        [TestMethod]
        public void IndentifyThemselvesTest()
        {
            Location location = new Location(new string[] { "id" }, "Name", "description");
            Assert.IsNotNull(location.Locate("id"));
        }
    }
}