using NUnit.Framework;
using SwinAdventure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure.UnitTests.Services
{
    [TestFixture]
    class LookCommandUnitTests
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
            Assert.True(command.Execute(
                player,
                new string[] { "look", "at", "inventory" }) ==
                $"You are carrying:\n{player.Inventory.ItemList}",
                "The Look command can't look at the person");
        }

        [Test]
        public void TestLookAtGem()
        {
            LookCommand command = new LookCommand();
            Player player = new Player("player one", "i am player one");
            Item Gem = new Item(new string[] { "gem" }, "a Gem", "Desc for Gem");
            player.Inventory.Put(Gem);
            Assert.True(command.Execute(
                player,
                new string[] { "look", "at", "gem" }) ==
                $"You are carrying:\n\t{Gem.FullDescription}",
                "The Look command can't look at item");
        }

        [Test]
        public void TestLookAtUnk()
        {
            LookCommand command = new LookCommand();
            Player player = new Player("player one", "i am player one");
            var test = command.Execute(player, new string[] { "look", "at", "gem" });
            var expected = "I can't find the gem";
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
            string expected = $"You are carrying:\n\t{Gem.FullDescription}";
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
                "look", "at", "gem", "in", "bag"
            });
            string expected = $"You are carrying:\n\t{gem.FullDescription}";
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
            string expected = "I can't find the bag";
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
                "look", "at", "gem", "in", "bag"
            });
            string expected = "I can't find the gem";
            Assert.True(expected == test,
                "Can't generate errors for no gem in bag");
        }

        [Test]
        public void TestInvalidLook()
        {
            LookCommand command = new LookCommand();
            Player player = new Player("player one", "i am player one");
            string test = command.Execute(player, new string[]
            {
                "look", "around"
            });
            string expected = "What do you want to look at?";
            Assert.True(test == expected, 
                "Error finding error");
            test = command.Execute(player, new string[]
            {
                "hello"
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
        }
    }
}
