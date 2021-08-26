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
    }
}
