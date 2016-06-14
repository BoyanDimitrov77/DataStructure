using Microsoft.VisualStudio.TestTools.UnitTesting;
using SortingHomework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritms.Tests
{
    [TestClass()]
    public class QuicksorterTests
    {
        [TestMethod()]
        public void TestOnEmptyCollectiom()
        {
            var collection = new SortableCollection<int>();
            collection.Sort(new Quicksorter<int>());
            Assert.AreEqual(true, this.checkAreEquals(collection));
        }

        [TestMethod()]
        public void TestAssendingElements()
        {
            var collection = new SortableCollection<int>(new[] { -10, -7, -6, -5, -1, 0, 1, 2, 3, 5, 6, 7 });
            collection.Sort(new Quicksorter<int>());

            Assert.AreEqual(true, this.checkAreEquals(collection));
        }
        [TestMethod()]
        public void TestDessendingElements()
        {
            var collection = new SortableCollection<int>(new[] { 7, 6, 5, 3, 2, 1, 0, -1, -5, -6, -7, -10 });
            collection.Sort(new Quicksorter<int>());

            Assert.AreEqual(true, this.checkAreEquals(collection));
        }
        [TestMethod()]
        public void TestOnNegativeNumbers()
        {
            var collection = new SortableCollection<int>(new[] { -1, -5, -33, -2, -101, -7 });
            collection.Sort(new Quicksorter<int>());

            Assert.AreEqual(true, this.checkAreEquals(collection));
        }
        [TestMethod()]
        public void TestOnPositiveNumbers()
        {
            var collection = new SortableCollection<int>(new[] { 22, 11, 101, 33, 5, 101 });
            collection.Sort(new Quicksorter<int>());

            Assert.AreEqual(true, this.checkAreEquals(collection));
        }

        private bool checkAreEquals<T>(SortableCollection<T> collection) where T : IComparable<T>
        {
            var copyCollection = collection.Items.ToArray();
            Array.Sort(copyCollection);

            for (int i = 0; i < collection.Items.Count; i++)
            {
                if (collection.Items[i].CompareTo(copyCollection[i]) != 0)
                {
                    return false;
                }
            }

            return true;

        }
    }
}