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
    public class EmployeTest
    {
        [TestMethod()]
        public void MoveUpTest()
        {
            ChefRang CR = new ChefRang(1, 100, 50);
            CR.MoveUp(20);
            Assert.AreEqual(30, CR.Y);
        }

        [TestMethod()]
        public void MoveDownTest()
        {
            ChefRang CR = new ChefRang(1, 100, 50);
            CR.MoveDown(20);
            Assert.AreEqual(70, CR.Y);
        }

        [TestMethod()]
        public void MoveLeftTest()
        {
            ChefRang CR = new ChefRang(1, 100, 50);
            CR.MoveLeft(20);
            Assert.AreEqual(80, CR.X);
        }

        [TestMethod()]
        public void MoveRightTest()
        {
            ChefRang CR = new ChefRang(1, 100, 50);
            CR.MoveRight(20);
            Assert.AreEqual(120, CR.X);
        }
    }
}