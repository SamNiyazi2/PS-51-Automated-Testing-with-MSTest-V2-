using Microsoft.VisualStudio.TestTools.UnitTesting;

// 08/27/2021 04:18 am - SSN - [20210827-0415] - [001] - M06-03 - Creating custom numeric assert

namespace GameEngine.Tests
{
    public static class CustomAsserts
    {

        public static void IsInRange(this Assert assert, int actual, int expectedMinimumValue, int expectedMaximumValue)
        {
            if (actual < expectedMinimumValue || actual > expectedMaximumValue)
            {
                throw new AssertFailedException($"[{actual}] was not in the range ({expectedMinimumValue} - {expectedMaximumValue})");
            }
        }

    }
}
