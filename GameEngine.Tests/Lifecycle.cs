using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

// 08/26/2021 02:51 pm - SSN - [20210826-1451] - [001] - M04-06 - Running additional code within a test class

namespace GameEngine.Tests
{
    [TestClass]
    public class Lifecycle
    {


        [ClassInitialize]
        public static void LifecycleClassInit(TestContext context)
        {
            Console.WriteLine("Lifecylce_ClassInit [ClassInitialize]:");
        }


        [ClassCleanup]
        public static void LifecyleClassCleanup()
        {
            Console.WriteLine("LifecycleClassCleanup [ClassCleanup]:");
        }


        [TestInitialize]
        public void LifecycleTestInit()
        {
            Console.WriteLine("    LifecycleTestInit ([TestInitialize]): Firing");
        }


        [TestCleanup]
        public void LifecycleTestClean()
        {
            Console.WriteLine("    LifecycleTestClean ([TestCleanup]): Firing");
        }






        [TestMethod]
        public void TestA()
        {
            Console.WriteLine("        Test A starting");
        }


        [TestMethod]
        public void TestB()
        {
            Console.WriteLine("        Test B starting");
        }





    }
}
