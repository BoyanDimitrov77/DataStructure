using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;


namespace Problem3
{
    class bBiDictionary<K1, K2, Tvalue>
    {

        private class Entry : IEquatable<Entry>
        {
            public K1 Key1 { get; set; }
            public K2 Key2 { get; set; }
            public Tvalue Value { get; set; }

            public Entry(K1 key1,K2 key2,Tvalue value)
            {
                this.Key1 = key1;
                this.Key2 = key2;
                this.Value = value;
            }


            public bool Equals(Entry other)
            {
                return other != null &&
                    this.Key1.Equals(other.Key1) &&
                    this.Key2.Equals(other.Key2) &&
                    this.Value.Equals(other.Value);

            }

            public override bool Equals(object obj)
            {
                return Equals(obj as Entry);
            }

            public override int GetHashCode()
            {
                int result = 1;

                result = (result * 70) * this.Key1.GetHashCode();
                result = (result * 70) * this.Key2.GetHashCode();
                result = (result * 70) * this.Value.GetHashCode();

                return result;
            }
        }


        private readonly MultiDictionary<K1, Entry> key1 = null;
        private readonly MultiDictionary<K2, Entry> key2 = null;
        private readonly MultiDictionary<Tuple<K1,K2>,Entry> Key1AndKey2=null;


        public void Add(K1 key1,K2 key2,Tvalue value)
        {
            var entry = new Entry(key1, key2, value);

            this.key1.Add(key1, entry);
            this.key2.Add(key2, entry);

            this.Key1AndKey2.Add(new Tuple<K1, K2>(key1, key2), entry);
        }

        public bBiDictionary(bool allowDuplicateValues)
        {
            this.key1 = new MultiDictionary<K1, Entry>(allowDuplicateValues);
            this.key2 = new MultiDictionary<K2, Entry>(allowDuplicateValues);
            this.Key1AndKey2 = new MultiDictionary<Tuple<K1, K2>, Entry>(allowDuplicateValues);
        }

        public int Count
        {
            get
            {
                Debug.Assert(
                    key1.KeyValuePairs.Count == Key1AndKey2.KeyValuePairs.Count &&
                    key2.KeyValuePairs.Count == Key1AndKey2.KeyValuePairs.Count
                );

                return this.Key1AndKey2.KeyValuePairs.Count;
            }
        }

        public ICollection<Tvalue> GetByFirstKey(K1 key1)
        {
            var getKey1 = this.key1[key1].Select(p => p.Value).ToArray();
            return getKey1;
        }

        public ICollection<Tvalue> GetBySecondKey(K2 key)
        {
            var getKey2 = this.key2[key].Select(p => p.Value).ToArray();
            return getKey2;
        }

        public ICollection<Tvalue> GetFirstAndSecondKey(K1 key1,K2 key2)
        {
            var pair = new Tuple<K1, K2>(key1, key2);
            var getKey1AndKey2 = this.Key1AndKey2[pair].Select(p => p.Value).ToArray();
            return getKey1AndKey2;
        }

        public void RemoveByFirstKey(K1 key1)
        {
            var entries = this.key1[key1];

            foreach (var item in entries)
            {
                this.key2.Remove(item.Key2, item);

                var key1Andkey2 = new Tuple<K1, K2>(item.Key1, item.Key2);
                this.Key1AndKey2.Remove(key1Andkey2, item);
            }

            this.key1.Remove(key1);

        }

        public void RemoveBySecondKey(K2 key2)
        {
            var entries = this.key2[key2];

            foreach (var item in entries)
            {
                this.key1.Remove(item.Key1, item);

                var key1Andkey2 = new Tuple<K1, K2>(item.Key1, item.Key2);
                this.Key1AndKey2.Remove(key1Andkey2, item);
            }

            this.key2.Remove(key2);
        }

        public void RemoveByFirstAndSecondKey(K1 key1,K2 key2)
        {
            var key1Andkey2 = new Tuple<K1, K2>(key1, key2);
            var entries = this.Key1AndKey2[key1Andkey2];

            foreach (var item in entries)
            {
                this.key1.Remove(item.Key1, item);
                this.key2.Remove(item.Key2, item);
            }

            this.Key1AndKey2.Remove(key1Andkey2);
        }

        
    }
    class Program
    {
        static void Main(string[] args)
        {

            bBiDictionary<string, int, string> collection = new bBiDictionary<string, int, string>(allowDuplicateValues: true);

            collection.Add("Dragan", 1, "C#");
            collection.Add("Petar", 5, "Java");
            collection.Add("Slavi", 7, "C#");
            collection.Add("Slavka", 10, "SQL");
            collection.Add("Milena", 0, "Rubi");
            collection.Add("Marina", 8, "JavaScript");
            collection.Add("Stoqn", 1, "C++");

            Console.WriteLine(string.Join(" ", collection.GetByFirstKey("Dragan")));
            Console.WriteLine(string.Join(" ", collection.GetBySecondKey(8)));
            Console.WriteLine(string.Join(" ", collection.GetFirstAndSecondKey("Stoqn", 1)));


            collection.RemoveByFirstKey("Slavka");
            Console.WriteLine(collection.Count);

            collection.RemoveBySecondKey(8);
            Console.WriteLine(collection.Count);

            collection.RemoveByFirstAndSecondKey("Milena", 0);
            Console.WriteLine(collection.Count);

        }
    }

}
