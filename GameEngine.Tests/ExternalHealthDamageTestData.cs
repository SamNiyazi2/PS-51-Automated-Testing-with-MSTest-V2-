using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

// 08/26/2021 06:36 pm - SSN - [20210826-1831] - [001] - M05-05 - Getting test data from external sources

namespace GameEngine.Tests
{
    public class ExternalHealthDamageTestData
    {

        public static IEnumerable<object[]> GetTestData
        {

            get
            {
                string[] csvLines = File.ReadAllLines("Damages_test_data.csv");
                var testCases = new List<object[]>();

                foreach (var line in csvLines)
                {
                    IEnumerable<int> values = line.Split(',').Select(int.Parse);

                    testCases.Add(values.Cast<object>().ToArray());
                }

                return testCases;
            }

        }


    }
}