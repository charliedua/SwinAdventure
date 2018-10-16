using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SwinAdventure.Tests
{
    [TestClass()]
    public class IdentifiableObjectTests
    {
        [TestMethod()]
        public void TestAreYou()
        {
            IdentifiableObject id = new IdentifiableObject(new string[] { "id1", "id2" });
            Assert.IsTrue(id.AreYou("id1"));
            Assert.IsTrue(id.AreYou("id2"));
        }

        [TestMethod()]
        public void TestNotAreYou()
        {
            IdentifiableObject id = new IdentifiableObject(new string[] { "id1", "id2" });
            Assert.IsFalse(id.AreYou("id3"));
        }

        [TestMethod()]
        public void TestCaseSensitive()
        {
            IdentifiableObject id = new IdentifiableObject(new string[] { "id1", "id2" });
            Assert.IsTrue(id.AreYou("ID1"));
        }

        [TestMethod()]
        public void TestFirstId()
        {
            IdentifiableObject id = new IdentifiableObject(new string[] { "id1", "id2" });
            Assert.IsTrue(id.FirstId == "id1");
        }

        [TestMethod()]
        public void TestAddId()
        {
            IdentifiableObject id = new IdentifiableObject(new string[] { "id1", "id2" });
            id.AddIdentiﬁer("id3");
            Assert.IsTrue(id.AreYou("id3"));
        }
    }
}