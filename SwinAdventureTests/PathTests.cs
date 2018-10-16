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
    public class PathTests
    {
        [TestMethod()]
        public void MoveTest()
        {
            Player player = new Player("player one", "i am player one");
            Location location = new Location(new string[] { "test" }, "test", "this is a test string");
            Location location2 = new Location(new string[] { "test2" }, "test2", "this is a test2 string");
            player.Location = location;
            //location.Inventory.Put(new Path(new string[] { "north", "n" }, "North", "You go through a Fence", location, location2));
            //location2.Inventory.Put(new Path(new string[] { "south", "s" }, "South", "You go through a Fence", location2, location));
            Path testPath = new Path(new string[] { "north", "n" }, "North", "You go through a Fence", location, location2);
            testPath.Move(player);
            Assert.AreEqual(player.Location, location2);
        }
    }
}