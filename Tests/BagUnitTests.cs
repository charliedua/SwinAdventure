using NUnit.Framework;

namespace SwinAdventure.UnitTests.Services
{
    [TestFixture]
    public class BagUnitTests
    {
        [Test]
        public void TestBagLocatesItems()
        {
            Bag bag = new Bag(new string[] { "chest" }, "Chest", "this is desc");
            Item shovel = new Item(new string[] { "shovel", "spade" },
                "a shovel",
                "This is a might fine");
            bag.Inventory.Put(shovel);
            Assert.True(bag.Locate("shovel").FirstId == shovel.FirstId,
                "The bag can't locate items");
        }

        [Test]
        public void TestBagLocatesItself()
        {
            Bag bag = new Bag(new string[] { "chest" }, "Chest", "this is desc");
            Assert.True(bag.Locate("chest") == bag,
                "The bag can't locate itself");
        }

        [Test]
        public void TestBagLocatesNothing()
        {
            Bag bag = new Bag(new string[] { "chest" }, "Chest", "this is desc");
            Assert.True(bag.Locate("shovel") == null,
                "The bag is locating something");
        }

        [Test]
        public void TestBagFullDescription()
        {
            Bag bag = new Bag(new string[] { "chest" }, "Chest", "this is desc");
            Assert.True((bag.Name + bag.Inventory.ItemList) == bag.FullDescription, 
                "the Full Description is incorrect");
        }
        [Test]
        public void TestBagInBag()
        {
            Bag bag = new Bag(new string[] { "chest" }, "Chest", "this is desc");
            Bag bag2 = new Bag(new string[] { "chest2" }, "Chest2", "this is desc of chest 2");
            bag.Inventory.Put(bag2);
            Item shovel = new Item(new string[] { "shovel", "spade" },
                "a shovel",
                "This is a might fine");
            bag.Inventory.Put(shovel);
            Assert.True(bag.Locate("chest2") == bag2,
                "The bag can't locate other bag within it");
            Assert.True(bag.Locate("shovel") == shovel,
                "The bag can't locate items within it when there is a bag within it");
            Item shovel2 = new Item(new string[] { "shovel2", "spade2" },
                "a shovel2",
                "This is a might fine2");
            bag2.Inventory.Put(shovel2);
            Assert.False(bag.Locate("shovel2") == shovel2,
                "The bag is locating stuff that is not meant to");
        }
    }
}