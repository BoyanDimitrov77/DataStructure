using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SortingHomework;
using System.Linq;

namespace AlgoritmsTests
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class BinarySearch
    {

        
        [TestMethod]
        public void TestOnEmptyCollection()
        {
            var collection = new SortableCollection<int>();

            var searchedNumber = 22;
            var expected = FindElement(collection.Items, searchedNumber);
            var actual = collection.BinarySearch(searchedNumber);

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestSuccessAtBegining()
        {
            var array = new[] { 22, 11, 101, 33, 0, 101 };
            Array.Sort(array);

            var collection = new SortableCollection<int>(array);

            var searchedNumber = 0;
            var expected = FindElement(collection.Items, searchedNumber);
            var actual = collection.BinarySearch(searchedNumber);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestAtEdnd()
        {
            var array = new int[] { 22, 11, 101, 33, 0, 101 };
            Array.Sort(array);

            int searchElement = 101;
            var collection = new SortableCollection<int>(array);
            var expectedResult = this.FindElement(collection.Items, searchElement);
            var actualResult = collection.BinarySearch(searchElement);
        }

        [TestMethod]
        public void TestMiddle()
        {
            var array = new int[] {5,6,7 };
            Array.Sort(array);

            int searchElement = 6;
            var collection = new SortableCollection<int>(array);
            var expectedResult = this.FindElement(collection.Items, searchElement);
            var actualResult = collection.BinarySearch(searchElement);

        }
        [TestMethod]
        public void TestMissingElement()
        {
            var array = new int[] { 5, 6, 7 };
            Array.Sort(array);

            int searchElement = 8;
            var collection = new SortableCollection<int>(array);
            var expectedResult = this.FindElement(collection.Items, searchElement);
            var actualResult = collection.BinarySearch(searchElement);

        }
        [TestMethod]
        public void TestWithOneElement()
        {
            var array = new int[] {8};
            Array.Sort(array);

            int searchElement = 8;
            var collection = new SortableCollection<int>(array);
            var expectedResult = this.FindElement(collection.Items, searchElement);
            var actualResult = collection.BinarySearch(searchElement);
        }

        private int FindElement<T>(IList<T>collection,T item)where T : IComparable<T>
        {
            var items = collection.ToArray();
            var index = Array.BinarySearch(items, item);

            if (index >0)
            {
                return index;
            }
            else
            {
                return -1;
            }
        }
    }
}
