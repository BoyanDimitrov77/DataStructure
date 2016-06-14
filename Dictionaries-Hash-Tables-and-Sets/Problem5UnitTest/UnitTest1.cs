using System;
using System.Linq;
using Problem5;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Problem5UnitTest
{
    [TestClass]
    public class HashSetTest
    {
        [TestMethod]
        public void Add()
        {
            var hash = new HashSet<int>();

            hash.Add(1);
            Assert.AreEqual(1, hash.Count);

            hash.Add(1);
            Assert.AreEqual(1, hash.Count);

            Assert.IsTrue(hash.Contains(1));


        }

        [TestMethod]
        public void AddMultipleElemnt()
        {
            var hash = new HashSet<int>();

            for (int i = 0; i < 1000; i++)
            {
                hash.Add(i);
            }

            Assert.IsTrue(Enumerable.Range(0, 1000).SequenceEqual(hash));
            Assert.AreEqual(1000, hash.Count);
        }


        [TestMethod]
        public void MultipleRemove()
        {
            var hash = new HashSet<int>();

            for (int i = 0; i < 1000; i++)
            {
                hash.Add(i);
            }

            for (int i = 0; i < 300; i++)
            {
                hash.Remove(i);
            }

            Assert.IsTrue(Enumerable.Range(0, 300).SequenceEqual(hash));
            Assert.AreEqual(300, hash.Count);
        }

        [TestMethod]

        public void RemoveValidElement()
        {
            var hash = new HashSet<int> { 1,1,1};
            var real = hash.Remove(1);

            Assert.IsTrue(real);
            Assert.AreEqual(0, hash.Count);
            Assert.IsTrue(hash.Contains(1));
        }

        [TestMethod]
        public void RemoveInvalid()
        {
            var hash = new HashSet<int>();

            var real = hash.Remove(3);

            Assert.IsFalse(real);
        }

        [TestMethod]
        public void Clear()
        {
            var hash = new HashSet<int> { 1,2,3};

            hash.Clear();

            Assert.AreEqual(0, hash.Count);

        }

        [TestMethod]

        public void Union()
        {
            var hash = new HashSet<int> { 1, 2, 3 };

            hash.Union(new[] { 1, 2, 3, 4, });

            Assert.IsTrue(Enumerable.Range(1, 4).SequenceEqual(hash));
        }

        [TestMethod]
        public void Intersect()
        {
            var hash = new HashSet<int> { 1, 2, 3 };

            hash.Intersect(new[] { 2, 3, 4, });

            Assert.IsTrue(Enumerable.Range(2, 2).SequenceEqual(hash));
        }


    }
}
