using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AppHarborFoo.Tests
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class MyTests
    {
        //[TestMethod()]
        //public void TestFailure()
        //{
        //    throw new InvalidOperationException("I'm designed to stop deployment!");
        //}

        [TestMethod()]
        public void TestSuccess()
        {
            // ...whereas I'm designed to allow deployment!
        }
    }
}
