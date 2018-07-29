using NUnit.Framework;

namespace SwinAdventure.UnitTests.Services
{
    [TestFixture]
    public class InventoryUnitTests
    {
        [Test]
        public void TestFindItem()
        {
            Item shovel = new Item(new string[] { "shovel", "spade" },
                "a shovel",
                "This is a might fine ...");
            Inventory inventory = new Inventory();
            inventory.Put(shovel);
            Assert.True(inventory.HasItem("shovel"),
                "Inventory doesn't contain item sent through put");
        }
        [Test]
        public void TestNoFindItem()
        {
            Item shovel = new Item(new string[] { "shovel", "spade" },
                "a shovel",
                "This is a might fine ...");
            Inventory inventory = new Inventory();
            Assert.False(inventory.HasItem("cat"),
                "Inventory shouldn't contain this item sent through put");
        }
        [Test]
        public void TestFetchItem()
        {
            Item shovel = new Item(new string[] { "shovel", "spade" },
                "a shovel",
                "This is a might fine ...");
            Inventory inventory = new Inventory();
            inventory.Put(shovel);
            Item newitem = inventory.Fetch("shovel");
            Assert.True(newitem.FirstId == shovel.FirstId,
                "Item is not fetched after putting");
            Assert.True(inventory.HasItem("shovel"),
                "Item was removed from inventory, Shouldn't have been");
        }
        [Test]
        public void TestTakeItem()
        {
            Item shovel = new Item(new string[] { "shovel", "spade" },
                "a shovel",
                "This is a might fine ...");
            Inventory inventory = new Inventory();
            inventory.Put(shovel);
            Item newitem = inventory.Take("shovel");
            Assert.True(newitem.FirstId == shovel.FirstId,
                "Item can't be taken after putting");
            Assert.False(inventory.HasItem("shovel"),
                "Item was't removed from inventory");
        }

        // Working on this one
        [Test]
        public void TestItemList()
        {
            Item shovel = new Item(new string[] { "shovel", "spade" },
                "a shovel",
                "This is a might fine ...");
            Inventory inventory = new Inventory();
            inventory.Put(shovel);
            Item newitem = inventory.Take("shovel");
            Assert.True(newitem.FirstId == shovel.FirstId,
                "Item can't be taken after putting");
            Assert.False(inventory.HasItem("shovel"),
                "Item was't removed from inventory");
        }


    }
}