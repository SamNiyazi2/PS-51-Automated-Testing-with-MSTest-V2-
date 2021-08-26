using System;
using System.Collections.Generic;
using System.Text;

// 08/26/2021 06:23 pm - SSN - [20210826-1806] - [002] - M05-04 - Sharing test data across multiple tests

namespace GameEngine.Tests
{
    public class DamageTestData
    {
        public static IEnumerable<object[]> GetTestData()
        {
            return new List<object[]>{
                    new object[] { 1,99},
                    new object[] { 0,100},
                    new object[] { 100,1},
                    new object[] { 101,1},
                    new object[] { 200,1},
                    new object[] { 50,50},
                    new object[] { 52,48}
                };
        }
    }
}
