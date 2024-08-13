using Microsoft.VisualStudio.TestTools.UnitTesting;
using GraphCheck;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphCheck.Tests
{
    [TestClass()]
    public class GraphCheckerTests
    {
        private GraphChecker checker;

        [TestMethod()]
        public void ReadingCorrectMatrixTest()
        {
            checker = new GraphChecker("CorrectMatrix.txt");
            Assert.AreEqual(true, checker.DFSCheck());
        }

        [TestMethod()]
        public void IsolatedVertexTest()
        {
            checker = new GraphChecker("IsolatedMatrix.txt");
            Assert.AreEqual(true, checker.DFSCheck());
        }
    }
}