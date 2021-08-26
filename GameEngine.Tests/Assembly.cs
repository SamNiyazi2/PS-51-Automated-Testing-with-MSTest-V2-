
// 08/26/2021 03:41 pm - SSN - [20210826-1537] - [001] - M04-07 - Running additional code at the assembly level

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameEngine.Tests
{
    [TestClass]
    public class Assembly
    {

        [AssemblyInitialize]
        public static void AssemblyInit(TestContext testContext)
        {
            System.Console.WriteLine("Assembly.AssemblyInit [AssemblyInitialize]:");
        }


        [AssemblyCleanup]
        public static void AssemblyCleanup()
        {
            System.Console.WriteLine("Assembly.AssemblyCleanup [AssemblyCleanup]:");
        }


    }
}
