using GameEngine;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

// 08/26/2021 08:51 am - SSN - [20210826-0850] - [001] - M02-05 - Creating a new test project

namespace GameEngine.Tests
{
    [TestClass]
    public class PlayerCharacterShould
    {


        // 08/27/2021 04:06 am - SSN - [20210827-0403] - [001] - M06-02 - Initial test code refactoring
        PlayerCharacter sut;

        [TestInitialize]
        public void TestInitialize()
        {
            sut = new PlayerCharacter();
        }



        [TestMethod]
        [TestCategory("Player defaults")]
        // [Ignore("Testing Ignore attribute")]
        public void BeExperiencedWhenNew()
        {

            // var sut = new PlayerCharacter();

            Assert.IsTrue(sut.IsNoob);

        }

        [TestMethod]
        [TestCategory("Player defaults")]
        // [Ignore("Testing Ignore attribute")]
        public void NotHaveNickNameyDefault()
        {

            // var sut = new PlayerCharacter();

            Assert.IsNull(sut.Nickname);

        }


        // 08/26/2021 09:26 am - SSN - [20210826-0925] - [001] - M03-04 - Asserting numeric results
        [TestMethod]
        [TestCategory("Player defaults")]
        public void StartWithDefaultHealth()
        {


            // Arrange

            // var sut = new PlayerCharacter();
            var expectedValue = 100;

            // Act


            // Assert

            Assert.AreEqual(expectedValue, sut.Health);

        }


        // 08/26/2021 09:32 am - SSN - [20210826-0925] - [002] - M03-04 - Asserting numeric results

        [TestMethod]
        [TestCategory("Player health")]
        public void TakeDamage_v1()
        {

            // Arrange

            // var sut = new PlayerCharacter();

            var expectedResults = 99;

            // Act

            sut.TakeDamage(1);


            // Assert

            Assert.AreEqual(expectedResults, sut.Health);

        }


        // 08/26/2021 06:08 pm - SSN - [20210826-1806] - [001] - M05-04 - Sharing test data across multiple tests
        //public static IEnumerable<object[]> Damages_SampleData
        //{
        //    get
        //    {
        //        return new List<object[]>{
        //            new object[] { 1,99},
        //            new object[] { 0,100},
        //            new object[] { 100,1},
        //            new object[] { 101,1},
        //            new object[] { 50,50}
        //        };
        //    }
        //}

        //public static IEnumerable<object[]> Damages_SampleData_v2()
        //{
        //        return new List<object[]>{
        //            new object[] { 1,99},
        //            new object[] { 0,100},
        //            new object[] { 100,1},
        //            new object[] { 101,1},
        //            new object[] { 50,50},
        //            new object[] { 52,48}
        //        };
        //}

        // 08/26/2021 05:46 pm - SSN - [20210826-1744] - [001] - M05-03 - Specifying test data at the test method level
        [DataTestMethod]
        //[DataRow(1, 99)]
        //[DataRow(0, 100)]
        //[DataRow(100, 1)]
        //[DataRow(101, 1)]
        //[DataRow(50, 50)]
        // [DynamicData(nameof(Damages_SampleData))]
        // [DynamicData(nameof(Damages_SampleData_v2),DynamicDataSourceType.Method)]
        // [DynamicData(nameof(DamageTestData.GetTestData), typeof(DamageTestData), DynamicDataSourceType.Method)]
        [DynamicData(nameof(ExternalHealthDamageTestData.GetTestData), typeof(ExternalHealthDamageTestData))]
        [TestCategory("Player health")]
        public void TakeDamage_v2(int damage, int expectedResult)
        {

            // Arrange

            // var sut = new PlayerCharacter();


            // Act

            sut.TakeDamage(damage);


            // Assert

            Assert.AreEqual(expectedResult, sut.Health);

        }




        // 08/26/2021 09:37 am - SSN - [20210826-0925] - [003] - M03-04 - Asserting numeric results
        [TestMethod]
        [TestCategory("Player health")]
        public void TakeDamage_NotEqual()
        {

            // Arrange

            // var sut = new PlayerCharacter();
            var notExpectedResult = 100;

            // Act

            sut.TakeDamage(1);

            // Assert

            Assert.AreNotEqual(notExpectedResult, sut.Health);



        }


        // 08/26/2021 09:44 am - SSN - [20210826-0925] - [004] - M03-04 - Asserting numeric results

        [TestMethod]
        [TestCategory("Player health")]
        public void IncreaseHealthAfterSleeping_v1()
        {


            // Arrange

            // var sut = new PlayerCharacter();


            int testCount = 1000;
            int counter = 0;

            while (++counter < testCount)
            {

                // Act
                var minLimit = sut.Health;
                var maxLimit = minLimit + 100;

                sut.Sleep();


                // Assert

                // Assert.IsTrue(sut.Health >= 101 && sut.Health <= 200, $"Health final value {sut.Health}");
                Assert.IsTrue(sut.Health >= minLimit && sut.Health <= maxLimit, $"Health final value {sut.Health}");

            }

            Assert.AreEqual(testCount, counter, $"Ran test {testCount} times.");

        }


        // 08/27/2021 04:23 am - SSN - [20210827-0415] - [002] - M06-03 - Creating custom numeric assert

        [TestMethod]
        [TestCategory("Player health")]
        public void IncreaseHealthAfterSleeping_v2()
        {


            // Arrange


            int testCount = 1000;
            int counter = 0;

            while (++counter < testCount)
            {

                // Act
                var minLimit = sut.Health;
                var maxLimit = minLimit + 100;

                sut.Sleep();


                // Assert

                Assert.That.IsInRange(sut.Health, minLimit, maxLimit);

            }

            Assert.AreEqual(testCount, counter, $"Ran test {testCount} times.");

        }



        // 08/26/2021 11:33 am - SSN - [20210826-1100] - [001] - M03-06 - Asserting simple string equality

        [TestMethod]
        public void CalculateFullName()
        {

            // Arrange

            // var sut = new PlayerCharacter();

            sut.FirstName = "Sarah";
            sut.LastName = "Smith";

            string expectedResults = sut.FirstName + " " + sut.LastName;



            // Act


            // Assert


            Assert.AreEqual(expectedResults, sut.FullName);

            Assert.AreEqual(expectedResults.ToUpper(), sut.FullName, true);

        }


        // 08/26/2021 11:39 am - SSN - [20210826-1100] - [002] - M03-06 - Asserting simple string equality

        [TestMethod]
        public void HaveFullNameStartingWithFirstName()
        {

            // Arrange

            // var sut = new PlayerCharacter();
            sut.FirstName = "Sarah";
            sut.LastName = "Smith";


            // Act


            // Assert

            StringAssert.StartsWith(sut.FullName, sut.FirstName);

        }


        // 08/26/2021 11:41 am - SSN - [20210826-1100] - [003] - M03-06 - Asserting simple string equality

        [TestMethod]
        public void HaveFullNameEndingWithLastName()
        {

            // Arrange

            // var sut = new PlayerCharacter();
            sut.FirstName = "Sarah";
            sut.LastName = "Smith";


            // Act


            // Assert

            StringAssert.EndsWith(sut.FullName, sut.LastName);

        }


        // 08/26/2021 11:43 am - SSN - [20210826-1100] - [004] - M03-06 - Asserting simple string equality

        [TestMethod]
        public void CalculateFullNameWithTitleCase()
        {


            // Arrange

            // var sut = new PlayerCharacter();

            sut.FirstName = "Sarah";
            sut.LastName = "Smith";

            // Act


            // Assert

            StringAssert.Matches(sut.FullName, new Regex("[A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+"));

        }


        // 08/26/2021 11:51 am - SSN - [20210826-1149] - [001] - M03-07 - Specialized string assertions
        [TestMethod]
        public void HaveALongBow()
        {


            // Arrange

            // var sut = new PlayerCharacter();


            // Act


            // Assert

            CollectionAssert.Contains(sut.Weapons, "Long Bow");

        }


        // 08/26/2021 11:53 am - SSN - [20210826-1149] - [002] - M03-07 - Specialized string assertions
        [TestMethod]
        public void HaveAllExpectedWeapons()
        {

            // Arrange

            // var sut = new PlayerCharacter();

            var expectedWeapons = new[]
            {
                "Long Bow",
                "Short Bow",
                "Short Sword",
            };

            // Act


            // Assert
            // Must match order.
            CollectionAssert.AreEqual(expectedWeapons, sut.Weapons);

        }


        // 08/26/2021 12:01 pm - SSN - [20210826-1149] - [003] - M03-07 - Specialized string assertions
        [TestMethod]
        public void HaveAllExpectedWeapons_AnyOrder()
        {

            // Arrange

            // var sut = new PlayerCharacter();

            var expectedWeapons = new[]
            {
                "Short Bow",
                "Long Bow",
                "Short Sword",
            };


            // Act


            // Assert

            CollectionAssert.AreEquivalent(expectedWeapons, sut.Weapons);

        }



        // 08/26/2021 12:03 pm - SSN - [20210826-1149] - [004] - M03-07 - Specialized string assertions

        [TestMethod]
        public void HaveNoDuplicateWeapons()
        {

            // Arrange

            // var sut = new PlayerCharacter();


            // Act


            // Assert

            CollectionAssert.AllItemsAreUnique(sut.Weapons);
        }


        // 08/26/2021 12:06 pm - SSN - [20210826-1149] - [005] - M03-07 - Specialized string assertions
        [TestMethod]
        public void HaveAtLeastOneKindOfSword()
        {

            // Arrange

            // var sut = new PlayerCharacter();

            // Act


            // Assert

            Assert.IsTrue(sut.Weapons.Any(weapon => weapon.ToLower().Contains("sword")));

        }


        // 08/26/2021 12:08 pm - SSN - [20210826-1149] - [006] - M03-07 - Specialized string assertions
        [TestMethod]
        public void HaveNoEmptyDefaultWeapons()
        {

            // Arrange

            // var sut = new PlayerCharacter();

            // Act


            // Assert

            Assert.IsFalse(sut.Weapons.Any(weapon => string.IsNullOrWhiteSpace(weapon)));

        }

    }

}
