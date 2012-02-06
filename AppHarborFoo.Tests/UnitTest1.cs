using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AppHarborFoo.Tests
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class MyTests
    {
        [TestMethod()]
        public void TestFailure()
        {
            throw new InvalidOperationException("I'm designed to stop deployment!");
        }
    }
}
