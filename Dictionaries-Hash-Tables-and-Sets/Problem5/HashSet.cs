using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem5
{
    class HasSet<T>:IEnumerable<T>
    {
        private Dictionary<T, bool> items = new Dictionary<T, bool>();

        public int Count
        {
            get
            {
                return this.items.Count;
            }
        }

        public void Add(T value)
        {
            if (!this.Contains(value))
            {
                this.items.Add(value, true);
            }
        }

        public bool Cointain(T value)
        {
            return this.items.ContainsKey(value);
        }

        public bool Remove(T value)
        {
            return this.items.Remove(value);
        }

        public void Clear()
        {
            this.items.Clear();
        }

        public void Union(IEnumerable<T> items)
        {
            
            foreach (var item in items)
            {
                this.Add(item);
            }
        }

        public void Intersect(IEnumerable<T> items)
        {
            var other = new HashSet<T>();
            foreach (var item in items)
            {
                other.Add(item);

            }

            foreach (var item in this.items.Select(t=>t.Key).ToArray())
            {
                if (!other.Contains(item))
                {
                    this.Remove(item);

                }
            }


  
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this.items.Select(t => t.Key).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
