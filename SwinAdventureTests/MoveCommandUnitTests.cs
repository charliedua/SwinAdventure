using Microsoft.VisualStudio.TestTools.UnitTesting;

using SwinAdventure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure.Tests
{
    [TestClass()]
    public class MoveCommandUnitTests
    {
        private Player player = new Player("test", "test");
        private Location Home = new Location(new string[] { "home" }, "Home", "This is where you live");
        private Location Shop = new Location(new string[] { }, "Shop", "You can shop it");
        private Command command = new MoveCommand();

        public MoveCommandUnitTests()
        {
            Home.Inventory.Put(new Path(new string[] { "north", "n" }, "North", "You go through a Door", Home, Shop));
            Shop.Inventory.Put(new Path(new string[] { "south", "s" }, "South", "You go through a Door", Shop, Home));
        }

        [TestMethod()]
        public void MoveTest()
        {
            player.Location = Home;
            string actual = command.Execute(player, new string[] { "move", "n" });
            string expected = "You Head North\nYou go through a Door\nYou have arrived in a Shop";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void MoveBackTest()
        {
            player.Location = Home;
            command.Execute(player, new string[] { "move", "n" });
            string actual = command.Execute(player, new string[] { "move", "s" });
            string expected = "You Head South\nYou go through a Door\nYou have arrived in a Home";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void InvalidParamaterMoveTest()
        {
            player.Location = Home;
            string actual = command.Execute(player, new string[] { "go", "left" });
            string expected = "Cant Move there, Path locked or doesn't exist";
            Assert.AreEqual(expected, actual);
        }
    }
}