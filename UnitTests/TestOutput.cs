using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Antra.Uzduotis;
using Antra.Uzduotis.Interface;
using Antra.Uzduotis.Controller;
using Antra.Uzduotis.Objects;
using System.Collections.Generic;

namespace UnitTests
{
    [TestClass]
    public class TestOutput
    {
        private IDepthFinder _depthFinder;

        [TestInitialize]
        public void TestInitialize()
        {
            _depthFinder = new DepthFinder();
        }

        private int calculateDepth(Saka rootNode)
        {
            int maximumDepth;

            using (var rootNodeEnum = new List<Saka> { rootNode }.GetEnumerator())
            {
                maximumDepth = _depthFinder.FindDepth(rootNodeEnum);
            }

            return maximumDepth;
        }

        [TestMethod]
        public void FindDepth_RootNodeOnly()
        {
            Saka rootNode = new Saka();

            Assert.AreEqual(1, calculateDepth(rootNode));
        }

        [TestMethod]
        public void FindDepth_OneChild()
        {
            Saka node0_1 = new Saka();
            Saka rootNode = new Saka(new List<Saka> { node0_1 });

            Assert.AreEqual(2, calculateDepth(rootNode));
        }

        [TestMethod]
        public void FindDepth_TwoChild_SameDepth()
        {
            Saka node0_2 = new Saka();
            Saka node0_1 = new Saka();
            Saka rootNode = new Saka(new List<Saka> { node0_1, node0_2 });

            Assert.AreEqual(2, calculateDepth(rootNode));
        }

        [TestMethod]
        public void FindDepth_Parent_WithChild()
        {
            Saka node1_1 = new Saka();
            Saka node0_2 = new Saka(new List<Saka> { node1_1 });
            Saka node0_1 = new Saka();
            Saka rootNode = new Saka(new List<Saka> { node0_1, node0_2 });

            Assert.AreEqual(3, calculateDepth(rootNode));
        }

        [TestMethod]
        public void FindDepth_Parent_OneChildEach()
        {
            Saka node1_2 = new Saka();
            Saka node1_1 = new Saka();
            Saka node0_2 = new Saka(new List<Saka> { node1_1 });
            Saka node0_1 = new Saka(new List<Saka> { node1_2 });
            Saka rootNode = new Saka(new List<Saka> { node0_1, node0_2 });

            Assert.AreEqual(3, calculateDepth(rootNode));
        }

        [TestMethod]
        public void FindDepth_NoSiblings()
        {
            Saka node3_1 = new Saka();
            Saka node2_1 = new Saka(new List<Saka> { node3_1 });
            Saka node1_1 = new Saka(new List<Saka> { node2_1 });
            Saka node0_1 = new Saka(new List<Saka> { node1_1 });
            Saka rootNode = new Saka(new List<Saka> { node0_1 });

            Assert.AreEqual(5, calculateDepth(rootNode));
        }
    }
}
