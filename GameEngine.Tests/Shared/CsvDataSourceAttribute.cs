// 08/27/2021 09:47 am - SSN - [20210827-0942] - [001] - M06-06 - Creating and using custom test data source attriibutes


using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace GameEngine.Tests
{
    public class CsvDataSourceAttribute : Attribute, ITestDataSource
    {
        public string FileName { get; } = "Damages_test_data.csv";

        public CsvDataSourceAttribute(string fileName)
        {
            FileName = fileName;
        }


        public IEnumerable<object[]> GetData(MethodInfo methodInfo)
        {
            string[] csvLines = File.ReadAllLines(FileName);
            var testCases = new List<object[]>();

            foreach (var line in csvLines)
            {
                IEnumerable<int> values = line.Split(',').Select(int.Parse);

                testCases.Add(values.Cast<object>().ToArray());
            }

            return testCases;
        }

        public string GetDisplayName(MethodInfo methodInfo, object[] data)
        {
            if (data == null) return null;

            return $"{methodInfo.Name} ({string.Join(",", data)})";
        }
    }
}
