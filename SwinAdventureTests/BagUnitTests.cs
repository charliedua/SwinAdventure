using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SwinAdventure.Tests
{
    [TestClass()]
    public class BagUnitTests
    {
        [TestMethod()]
        public void TestBagLocatesItems()
        {
            Bag bag = new Bag(new string[] { "chest" }, "Chest", "this is desc");
            Item shovel = new Item(new string[] { "shovel", "spade" },
                "a shovel",
                "This is a might fine");
            bag.Inventory.Put(shovel);
            Assert.IsTrue(bag.Locate("shovel").FirstId == shovel.FirstId,
                "The bag can't locate items");
        }

        [TestMethod()]
        public void TestBagLocatesItself()
        {
            Bag bag = new Bag(new string[] { "chest" }, "Chest", "this is desc");
            Assert.IsTrue(bag.Locate("chest") == bag,
                "The bag can't locate itself");
        }

        [TestMethod()]
        public void TestBagLocatesNothing()
        {
            Bag bag = new Bag(new string[] { "chest" }, "Chest", "this is desc");
            Assert.IsTrue(bag.Locate("shovel") == null,
                "The bag is locating something");
        }

        [TestMethod()]
        public void TestBagFullDescription()
        {
            Bag bag = new Bag(new string[] { "chest" }, "Chest", "this is desc");
            Assert.IsTrue((bag.Name + bag.Inventory.ItemList) == bag.FullDescription,
                "the Full Description is incorrect");
        }

        [TestMethod()]
        public void TestBagInBag()
        {
            Bag bag = new Bag(new string[] { "chest" }, "Chest", "this is desc");
            Bag bag2 = new Bag(new string[] { "chest2" }, "Chest2", "this is desc of chest 2");
            bag.Inventory.Put(bag2);
            Item shovel = new Item(new string[] { "shovel", "spade" },
                "a shovel",
                "This is a might fine");
            bag.Inventory.Put(shovel);
            Assert.IsTrue(bag.Locate("chest2") == bag2,
                "The bag can't locate other bag within it");
            Assert.IsTrue(bag.Locate("shovel") == shovel,
                "The bag can't locate items within it when there is a bag within it");
            Item shovel2 = new Item(new string[] { "shovel2", "spade2" },
                "a shovel2",
                "This is a might fine2");
            bag2.Inventory.Put(shovel2);
            Assert.IsFalse(bag.Locate("shovel2") == shovel2,
                "The bag is locating stuff that is not meant to");
        }
    }
}