using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SwinAdventure.Tests
{
    [TestClass()]
    public class InventoryUnitTests
    {
        [TestMethod()]
        public void TestFetchItem()
        {
            Item shovel = new Item(new string[] { "shovel", "spade" },
                "a shovel",
                "This is a might fine ...");
            Inventory inventory = new Inventory();
            inventory.Put(shovel);
            Item newitem = inventory.Fetch("shovel");
            Assert.IsTrue(newitem.FirstId == shovel.FirstId,
                "Item is not fetched after putting");
            Assert.IsTrue(inventory.HasItem("shovel"),
                "Item was removed from inventory, Shouldn't have been");
        }

        [TestMethod()]
        public void TestFindItem()
        {
            Item shovel = new Item(new string[] { "shovel", "spade" },
                "a shovel",
                "This is a might fine ...");
            Inventory inventory = new Inventory();
            inventory.Put(shovel);
            Assert.IsTrue(inventory.HasItem("shovel"),
                "Inventory doesn't contain item sent through put");
        }

        // Working on this one
        [TestMethod()]
        public void TestItemList()
        {
            Item shovel = new Item(new string[] { "shovel", "spade" },
                "a shovel",
                "This is a might fine ...");
            Item pan = new Item(new string[] { "pan" }, "a pan", "This is awesome");
            Inventory inventory = new Inventory();
            inventory.Put(shovel);
            inventory.Put(pan);
            Assert.IsTrue(inventory.ItemList == $"\t{shovel.ShortDescription}\n" +
                $"\t{pan.ShortDescription}\n");
        }

        [TestMethod()]
        public void TestNoFindItem()
        {
            Item shovel = new Item(new string[] { "shovel", "spade" },
                "a shovel",
                "This is a might fine ...");
            Inventory inventory = new Inventory();
            Assert.IsFalse(inventory.HasItem("cat"),
                "Inventory shouldn't contain this item sent through put");
        }

        [TestMethod()]
        public void TestTakeItem()
        {
            Item shovel = new Item(new string[] { "shovel", "spade" },
                "a shovel",
                "This is a might fine ...");
            Inventory inventory = new Inventory();
            inventory.Put(shovel);
            Item newitem = inventory.Take("shovel");
            Assert.IsTrue(newitem.FirstId == shovel.FirstId,
                "Item can't be taken after putting");
            Assert.IsFalse(inventory.HasItem("shovel"),
                "Item was't removed from inventory");
        }
    }
}