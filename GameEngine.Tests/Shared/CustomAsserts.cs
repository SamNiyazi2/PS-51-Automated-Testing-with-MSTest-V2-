using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

// 08/27/2021 04:18 am - SSN - [20210827-0415] - [001] - M06-03 - Creating custom numeric assert

namespace GameEngine.Tests
{
    public static class CustomAsserts
    {

        #region Assert

        public static void IsInRange(this Assert assert, int actual, int expectedMinimumValue, int expectedMaximumValue)
        {
            if (actual < expectedMinimumValue || actual > expectedMaximumValue)
            {
                throw new AssertFailedException($"[{actual}] was not in the range ({expectedMinimumValue} - {expectedMaximumValue})");
            }
        }

        #endregion Assert



        // 08/27/2021 08:13 am - SSN - [20210827-0810] - [001] - M06-04 - Creating custom collection asserts
        #region CollectionAssert


        public static void AllItemsNotNullOrWhiteSpace(this CollectionAssert collectionAssert, ICollection<string> collection)
        {
            if (collection.Any(string.IsNullOrWhiteSpace))
            {
                throw new AssertFailedException("One or more items are null or white space.");
            }

        }


        public static void AllItemsSatisfy<T>(this CollectionAssert collectionAssert, ICollection<T> collection, Predicate<T> predicate)
        {
            if (!collection.Any(r => predicate(r)))
            {
                throw new AssertFailedException("All items do not satisfy predicate.");
            }
        }


        public static void All<T>(this CollectionAssert collectionAssert, ICollection<T> collection, Action<T> assert)
        {

            foreach (var item in collection)
            {
                assert(item);
            }
        }


        public static void AtLeastOneItemSatisfies<T> ( this CollectionAssert collectionAssert, ICollection<T> collection , Predicate<T> predicate, string errorMessage="")
        {
            if (!collection.Any(item => predicate(item)))
            {
                string _errorMessage =  string.IsNullOrWhiteSpace(errorMessage) ? "." : ": " + errorMessage ;

                throw new AssertFailedException($"No item satisfy the predicate{_errorMessage}");
            }
        }


        #endregion CollectionAssert




        #region StringAssert
        
        public static void NotNullOrWhiteSpace ( this StringAssert stringAssert, string actual)
        {
            if ( string.IsNullOrWhiteSpace(actual))
            {
                throw new AssertFailedException("Value is null of white space.");
            }
        }


        #endregion StringAssert

    }

}
