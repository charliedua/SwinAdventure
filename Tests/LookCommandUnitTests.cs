using NUnit.Framework;

namespace SwinAdventure.UnitTests.Services
{
    [TestFixture]
    internal class LookCommandUnitTests
    {
        [Test]
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
            Assert.True(test == expected,
                "The Look command can't look at the person");
        }

        [Test]
        public void TestLookAtGem()
        {
            LookCommand command = new LookCommand();
            Player player = new Player("player one", "i am player one");
            Item gem = new Item(new string[] { "gem" }, "a Gem", "Desc for Gem");
            player.Inventory.Put(gem);
            Assert.True(command.Execute(
                player,
                new string[] { "look", "at", "gem" }) ==
                gem.FullDescription,
                "The Look command can't look at item");
        }

        [Test]
        public void TestLookAtUnk()
        {
            LookCommand command = new LookCommand();
            Player player = new Player("player one", "i am player one");
            var test = command.Execute(player, new string[] { "look", "at", "gem" });
            var expected = "I cannot find the gem";
            Assert.True(test == expected, "The command can't find nothing");
        }

        [Test]
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
            Assert.True(test == expected,
                "can't look at gem in inventory");
        }

        [Test]
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
            Assert.True(expected == test,
                "Can't look at gem in bag");
        }

        [Test]
        public void TestLookAtGemInNoBag()
        {
            LookCommand command = new LookCommand();
            Player player = new Player("player one", "i am player one");
            string test = command.Execute(player, new string[]
            {
                "look", "at", "gem", "in", "bag"
            });
            string expected = "I cannot find the bag";
            Assert.True(expected == test,
                "Can't generate errors for no bag");
        }

        [Test]
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
            Assert.True(expected == test,
                "Can't generate errors for no gem in the ");
        }

        [Test]
        public void TestInvalidLook()
        {
            LookCommand command = new LookCommand();
            Player player = new Player("player one", "i am player one");
            string test = command.Execute(player, new string[]
            {
                "look", "around", "me"
            });
            string expected = "What do you want to look at?";
            Assert.True(test == expected,
                "Error finding error");

            test = command.Execute(player, new string[]
            {
                "hello", "this", "is"
            });
            expected = "Error in look input";
            Assert.True(test == expected,
                "Error finding error");

            test = command.Execute(player, new string[]
            {
                "look", "at", "a", "at", "b"
            });
            expected = "What do you want to look in?";
            Assert.True(test == expected,
                "Error finding error");

            test = command.Execute(player, new string[]
            {
                "look"
            });
            expected = "I don’t know how to look like that";
            Assert.True(test == expected,
                "Error finding error");
        }
    }
}