using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Server.Tests
{
    [TestClass]
    public class BufferManagerTests
    {
        [TestMethod]
        public void BufferManagerTest_Initialization()
        {
            var bufferManager = new BufferManager(10000, 1024);
            Assert.AreEqual(9, bufferManager.TotalBufferUnits);
        }
    }
}
