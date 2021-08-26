using GameEngine;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// 08/26/2021 08:51 am - SSN - [20210826-0850] - [001] - M02-05 - Creating a new test project

namespace GameEngne.Tests
{
    [TestClass]
    public class PlayerCharacterShould
    {
        [TestMethod]
        public void BeExperiencedWhenNew()
        {

            var sut = new PlayerCharacter();

            Assert.IsTrue(sut.IsNoob);

        }

        [TestMethod]
        public void NotHaveNickNameyDefault()
        {

            var sut = new PlayerCharacter();

            Assert.IsNull(sut.Nickname);

        }


        // 08/26/2021 09:26 am - SSN - [20210826-0925] - [001] - M03-04 - Asserting numeric results
        [TestMethod]
        public void StartWithDefaultHealth()
        {


            // Arrange

            var sut = new PlayerCharacter();
            var expectedValue = 100;

            // Act


            // Assert

            Assert.AreEqual(expectedValue, sut.Health);

        }


        // 08/26/2021 09:32 am - SSN - [20210826-0925] - [002] - M03-04 - Asserting numeric results

        [TestMethod]
        public void TakeDamage()
        {

            // Arrange

            var sut = new PlayerCharacter();

            var expectedResults = 99;

            // Act

            sut.TakeDamage(1);


            // Assert

            Assert.AreEqual(expectedResults, sut.Health);

        }


        // 08/26/2021 09:37 am - SSN - [20210826-0925] - [003] - M03-04 - Asserting numeric results
        [TestMethod]
        public void TakeDamage_NotEqual()
        {

            // Arrange

            var sut = new PlayerCharacter();
            var notExpectedResult = 100;

            // Act

            sut.TakeDamage(1);

            // Assert

            Assert.AreNotEqual(notExpectedResult, sut.Health);



        }


        // 08/26/2021 09:44 am - SSN - [20210826-0925] - [004] - M03-04 - Asserting numeric results

        [TestMethod]
        public void IncreaseHealthAfterSleeping()
        {


            // Arrange

            var sut = new PlayerCharacter();


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


    }
}
