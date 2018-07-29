using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace SwinAdventure.UnitTests.Services
{
    [TestFixture]
    public class IdentifiableObjectTests
    {
        [Test]
        public void TestAreYou()
        {
            IdentifiableObject id = new IdentifiableObject(new string[] { "id1", "id2" });
            Assert.IsTrue(id.AreYou("id1"));
            Assert.IsTrue(id.AreYou("id2"));
        }

        [Test]
        public void TestNotAreYou()
        {
            IdentifiableObject id = new IdentifiableObject(new string[] { "id1", "id2" });
            Assert.IsFalse(id.AreYou("id3"));
        }

        [Test]
        public void TestCaseSensitive()
        {
            IdentifiableObject id = new IdentifiableObject(new string[] { "id1", "id2" });
            Assert.IsTrue(id.AreYou("ID1"));
        }

        [Test]
        public void TestFirstId()
        {
            IdentifiableObject id = new IdentifiableObject(new string[] { "id1", "id2" });
            Assert.IsTrue(id.FirstId == "id1");
        }

        [Test]
        public void TestAddId()
        {
            IdentifiableObject id = new IdentifiableObject(new string[] { "id1", "id2" });
            id.AddIdentiﬁer("id3");
            Assert.IsTrue(id.AreYou("id3"));
        }
    }

    [TestFixture]
    public class GameObjectTests
    {
        [Test]
        public void ConstructorTest()
        {

        }
    }
}