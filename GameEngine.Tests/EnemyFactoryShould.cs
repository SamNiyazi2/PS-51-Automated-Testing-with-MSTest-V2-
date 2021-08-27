using GameEngine;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;

// 08/26/2021 12:21 pm - SSN - [20210826-1220] - [001] - M03-09 - Asserting that the correct exceptions are thrown

namespace GameEngine.Tests
{
    [TestClass]

    //[TestCategory("Enemy creation")]
    [EnemyCreationCategory]

    public class EnemyFactoryShould
    {

        [TestMethod]
        public void NotAllowNullName()
        {

            // Arrange
            Console.WriteLine("Creating EnemyFactory");
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


            Assert.AreEqual(enemyName, ex.RequestedEnemyName);

        }


        // 08/26/2021 12:43 pm - SSN - [20210826-1241] - [001] - M03-10 - Asserting object types and references
        [TestMethod]
        public void CreateNormalEnemyByDefault()
        {

            // Arrange

            var sut = new EnemyFactory();

            var enemy = sut.Create("Zombie");


            // Act


            // Assert

            Assert.IsInstanceOfType(enemy, typeof(NormalEnemy));

        }


        // 08/26/2021 12:48 pm - SSN - [20210826-1241] - [002] - M03-10 - Asserting object types and references
        [TestMethod]
        public void CreateNormalEnemyByDefault_NotTypeExample()
        {

            // Arrange

            var sut = new EnemyFactory();

            var enemy = sut.Create("Zombie");


            // Act


            // Assert

            Assert.IsNotInstanceOfType(enemy, typeof(BossEnemy));

        }


        // 08/26/2021 12:50 pm - SSN - [20210826-1241] - [003] - M03-10 - Asserting object types and references
        [TestMethod]
        public void CrateBossEnemy()
        {

            // Arrange

            var sut = new EnemyFactory();
            Enemy enemy = sut.Create("Zombie King", isBoss: true);

            // Act


            // Assert

            Assert.IsInstanceOfType(enemy, typeof(BossEnemy));

        }


        // 08/26/2021 12:54 pm - SSN - [20210826-1241] - [004] - M03-10 - Asserting object types and references
        [TestMethod]
        public void CreateSeparateInstances()
        {

            // Arrange

            EnemyFactory sut = new EnemyFactory();

            Enemy enemy1 = sut.Create("Zombie");
            Enemy enemy2 = sut.Create("Zombie");

            Enemy enemy3 = enemy1;

            // Act


            // Assert

            Assert.AreNotSame(enemy1, enemy2);
            Assert.AreNotEqual(enemy1, enemy2);

            Assert.AreSame(enemy1, enemy3);
            Assert.AreEqual(enemy1, enemy3);

        }
    }
}


