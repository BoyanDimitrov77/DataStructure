using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvlTrees
{
    public class BinarySearchTrees<T> : IEnumerable<T>
       where T : IComparable<T>
    {
        private int size;

        private class Node : IEnumerable<T>
        {
            public T Value { get; set; }
            public Node Left { get; set; }
            public Node Right { get; set; }


            public Node(T value)
            {
                this.Value = value;
                this.Left = null;
                this.Right = null;
            }

            public IEnumerator<T> GetEnumerator()   // DFS
            {
               //yield return this.Value;   -- pre-order
                if (this.Left != null)
                {
                   
                    foreach (var item in this.Left)
                    {
                        yield return item;
                    }
                }


                yield return this.Value;   //inner-order

                if (this.Right != null)
                {
                    foreach (var item in this.Right)
                    {
                        yield return item;
                    }
                     
                }
               //yield return this.Value;   -- post-order


            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return this.GetEnumerator();
            }
        }

        private Node root;

        public BinarySearchTrees()
        {
            this.size = 0;
            root = null;

        }

        public int Size
        {
            get { return this.size; }
        }

        private Node Add(Node node, T value)
        {
            if (node == null)
            {
                ++this.size;
                node = new Node(value);
                return node;
            }

            int cmp = value.CompareTo(node.Value);

            if (cmp == 0)
            {

                return node;
            }
            else if (cmp < 0)
            {
                node.Left = this.Add(node.Left, value);
            }
            else if (cmp > 0)
            {
                node.Right = this.Add(node.Right, value);
            }
            return node;
        }

        public void Add(T value)
        {
            this.root = this.Add(this.root, value);
        }

        public bool Contains(T value)
        {
            var node = this.root;

            while (node != null)
            {
                int cmp = value.CompareTo(node.Value);

                if (cmp == 0)
                {
                    return true;
                }

                if (cmp < 0)
                {
                    node = node.Left;

                }
                if (cmp > 0)
                {
                    node = node.Right;
                }


            }
            return false;
        }

        private Node Remove(Node node,T value)
        {

            if (node == null)
            {
                //The value isn't there
                return null;
            }

            int cmp = value.CompareTo(node.Value);

            if (cmp==0)
            {
                --this.size;
                if (node.Right == null)
                {
                    return node.Left;
                }
                if (node.Left == null)
                {
                    return node.Right;
                }

                //next value of size
                //we turn only left

                var parent = node.Right;  // allways have right child
                if (parent.Left == null)
                {
                    parent.Left = node.Left;
                    return parent;
                }

                while (parent.Left.Left != null)
                {
                    parent = parent.Left;
                }

                var minimal = parent.Left;
                parent.Left = minimal.Right;

                minimal.Left = node.Left;
                minimal.Right = node.Right;

                return minimal;
            }

            if (cmp < 0)
            {
                node.Left = this.Remove(node.Left, value);

            }
            else
            {
                node.Right = this.Remove(node.Right, value);
            }

            return node;
        }

        public void Remove(T value)
        {
            this.root = this.Remove(this.root, value);
        }

        public IEnumerator<T> GetEnumerator()
        {
            if (this.root != null)
            {
                foreach (var item in this.root)
                {
                    yield return item;
                }

            }

        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
