using NUnit.Framework;
using SwinAdventure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
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
                new string[] { "look", "at", "inventory" }) ==
                $"You are carrying:\n{player.Inventory.ItemList}",
                "The Look command can't look at the person");
        }

        //Left here
        [Test]
        public void TestLookAtUnk()
        {

        }

        [Test]
        public void TestLookAtGemInMe()
        {

        }

        [Test]
        public void TestLookAtGemInBag()
        {

        }

        [Test]
        public void TestLookAtGemInNoBag()
        {

        }

        [Test]
        public void TestLookAtNoGemInBag()
        {

        }

        [Test]
        public void TestInvalidLook()
        {

        }
    }
}
