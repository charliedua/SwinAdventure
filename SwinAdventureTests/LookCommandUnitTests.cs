using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SwinAdventure.Tests
{
    [TestClass()]
    public class LookCommandUnitTests
    {
        [TestMethod]
        public void LookTest()
        {
            LookCommand command = new LookCommand();
            Player player = new Player("player one", "i am player one");
            Location location = new Location(new string[] { "test" }, "test", "this is a test string");
            player.Location = location;
            string actual = command.Execute(player, new string[] { "look" });
            string expected = "this is a test string";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void TestLookAtMe()
        {
            LookCommand command = new LookCommand();
            Player player = new Player("player one", "i am player one");
            Bag smallBag = new Bag(new string[] { "bag", "small" },
                "a Small Bag",
                "A bag to store a couple items in. It's not very big...");
            player.Inventory.Put(smallBag);
            string test = command.Execute(
                player,
                new string[] { "look", "at", "inventory" });
            string expected = $"You are carrying:\n{player.Inventory.ItemList}";
            Assert.IsTrue(test == expected,
                "The Look command can't look at the person");
        }

        [TestMethod()]
        public void TestLookAtGem()
        {
            LookCommand command = new LookCommand();
            Player player = new Player("player one", "i am player one");
            Item gem = new Item(new string[] { "gem" }, "a Gem", "Desc for Gem");
            player.Inventory.Put(gem);
            Assert.IsTrue(command.Execute(
                player,
                new string[] { "look", "at", "gem" }) ==
                gem.FullDescription,
                "The Look command can't look at item");
        }

        [TestMethod()]
        public void TestLookAtUnk()
        {
            LookCommand command = new LookCommand();
            Player player = new Player("player one", "i am player one");
            var test = command.Execute(player, new string[] { "look", "at", "gem" });
            var expected = "I cannot find the gem";
            Assert.IsTrue(test == expected, "The command can't find nothing");
        }

        [TestMethod()]
        public void TestLookAtGemInMe()
        {
            LookCommand command = new LookCommand();
            Player player = new Player("player one", "i am player one");
            Item Gem = new Item(new string[] { "gem" }, "a Gem", "Desc for Gem");
            player.Inventory.Put(Gem);
            string test = command.Execute(player, new string[]
            {
                "look", "at", "gem", "in", "inventory"
            });
            string expected = Gem.FullDescription;
            Assert.IsTrue(test == expected,
                "can't look at gem in inventory");
        }

        [TestMethod()]
        public void TestLookAtGemInBag()
        {
            Bag bag = new Bag(new string[] { "chest" }, "Chest", "this is desc");
            LookCommand command = new LookCommand();
            Player player = new Player("player one", "i am player one");
            Item gem = new Item(new string[] { "gem" }, "a Gem", "Desc for Gem");
            bag.Inventory.Put(gem);
            player.Inventory.Put(bag);
            string test = command.Execute(player, new string[]
            {
                "look", "at", "gem", "in", "chest"
            });
            string expected = gem.FullDescription;
            Assert.IsTrue(expected == test,
                "Can't look at gem in bag");
        }

        [TestMethod()]
        public void TestLookAtGemInNoBag()
        {
            LookCommand command = new LookCommand();
            Player player = new Player("player one", "i am player one");
            string test = command.Execute(player, new string[]
            {
                "look", "at", "gem", "in", "bag"
            });
            string expected = "I cannot find the bag";
            Assert.IsTrue(expected == test,
                "Can't generate errors for no bag");
        }

        [TestMethod()]
        public void TestLookAtNoGemInBag()
        {
            Bag bag = new Bag(new string[] { "chest" }, "Chest", "this is desc");
            LookCommand command = new LookCommand();
            Player player = new Player("player one", "i am player one");
            player.Inventory.Put(bag);
            string test = command.Execute(player, new string[]
            {
                "look", "at", "gem", "in", "chest"
            });
            string expected = "I cannot find the gem in the Chest";
            Assert.IsTrue(expected == test,
                "Can't generate errors for no gem in the ");
        }

        [TestMethod()]
        public void TestInvalidLook()
        {
            LookCommand command = new LookCommand();
            Player player = new Player("player one", "i am player one");
            string test = command.Execute(player, new string[]
            {
                "look", "around", "me"
            });
            string expected = "What do you want to look at?";
            Assert.IsTrue(test == expected,
                "Error finding error");

            test = command.Execute(player, new string[]
            {
                "hello", "this", "is"
            });
            expected = "Error in look input";
            Assert.IsTrue(test == expected,
                "Error finding error");

            test = command.Execute(player, new string[]
            {
                "look", "at", "a", "at", "b"
            });
            expected = "What do you want to look in?";
            Assert.IsTrue(test == expected,
                "Error finding error");
        }
    }
}