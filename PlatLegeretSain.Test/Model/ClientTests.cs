using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlatLegeretSain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatLegeretSain.Model.Tests
{
    [TestClass()]
    public class ClientTests
    {
        [TestMethod()]
        public void ClientTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ManageClientTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void setStateTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void MoveUpTest()
        {
            Client client = new Client(10);
            client.MoveUp(20);
            Assert.AreEqual("back", client.orientation);
        }

        [TestMethod()]
        public void MoveDownTest()
        {
            Client client = new Client(10);
            client.MoveDown(20);
            Assert.AreEqual("front", client.orientation);
        }

        [TestMethod()]
        public void MoveLeftTest()
        {
            Client client = new Client(10);
            client.MoveLeft(20);
            Assert.AreEqual("left", client.orientation);
        }

        [TestMethod()]
        public void MoveRightTest()
        {
            Client client = new Client(10);
            client.MoveRight(20);
            Assert.AreEqual("right", client.orientation);
        }

        [TestMethod()]
        public void QuitterRestaurantTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SortirTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ChoixCommandeTest()
        {
            Assert.Fail();
        }
    }
}