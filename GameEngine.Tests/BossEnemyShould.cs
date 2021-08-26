using GameEngine;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

// 08/26/2021 10:02 am - SSN - [20210826-0958] - [001] - M03-05 - Asserting on double values with delta

namespace GameEngine.Tests
{
    [TestClass]
    public class BossEnemyShould
    {

        [TestMethod]
        public void HaveCorrectSpecialAttackPower()
        {

            // Arrange

            var sut = new BossEnemy();


            //double expectedResult = 166.6;
            //double delta = 0.07;

            double expectedResult = 166.666;
            double delta = 0.0007;
            int testCount = 0;

            // Act


            // Assert
            // Testing minimum applicable value for delta
            if (false)
            {

                double testDelta = delta - 0.0001;

                while (testDelta > 0.00001)
                {
                    testCount++;
                    Assert.AreEqual(expectedResult, sut.SpecialAttackPower, testDelta, $"Error 2 testDelta : [{testDelta }] testCount: [{testCount}]");
                    testDelta -= 0.0001;
                }
            }

            Assert.AreEqual(expectedResult, sut.SpecialAttackPower, delta, $"Error 3 ");

        }
    }
}
