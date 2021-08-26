using GameEngine;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;

// 08/26/2021 12:21 pm - SSN - [20210826-1220] - [001] - M03-09 - Asserting that the correct exceptions are thrown

namespace GameEngne.Tests
{
    [TestClass]
    public class EnemyFactoryShould
    {

        [TestMethod]
        public void NotAllowNullName()
        {

            // Arrange

            var sut = new EnemyFactory();

            // Act


            // Assert

            Assert.ThrowsException<ArgumentNullException>(() => sut.Create(null));
            Assert.ThrowsExceptionAsync<ArgumentNullException>(async () => await Task.Run(() => sut.Create(null)));

        }


        [TestMethod]
        public void OnlyAllowKingOrQueenBossEnemies()
        {

            // Arrange

            var sut = new EnemyFactory();

            string enemyName = "Zombie";

            // Act


            // Assert

            EnemyCreationException ex = Assert.ThrowsException<EnemyCreationException>(() => sut.Create(enemyName, isBoss: true));


            Console.WriteLine("OnlyAllowKingOrQueenBossEnemies");
            Console.WriteLine("Typeof ex:");
            Console.WriteLine(ex.GetType().Name);


            Assert.AreEqual(enemyName, ex.RequestedEnemyName);

        }

    }
}


