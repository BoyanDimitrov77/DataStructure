using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem12
{
    class AutoResizeableStack<T> where T : IComparable<T>
    {
        private const int defaultCapasity = 16;
        private int count;
        private int currentCapasity;
        private T[] item;

        public int Count
        {
            get { return this.count; }
        }

        public int Capasity
        {
            get { return this.currentCapasity; }
        }

        public AutoResizeableStack()
        {
            this.item = new T[defaultCapasity];
            this.currentCapasity = defaultCapasity;
            this.count = 0;

        }

        public void Push(T newElementInStack)
        {
            if (this.count < this.currentCapasity)
            {
                this.item[count] = newElementInStack;
            }
            else
            {
                AutoResize();
                this.item[this.count] = newElementInStack;
            }


        }

       public T Pop(T removeElementFromStack)
        {
            if (this.count <= 0)
            {
                Console.WriteLine("Stack is empty");
            }

            T ElementFromTop = item[count - 1];
            this.item[count - 1] = default(T); //for genneric type(value=0)
            this.count--;
            return ElementFromTop;


        }

        public T Peek(T pickElementFromStack)
        {
            if (this.count <= 0)
            {
                Console.WriteLine("Stack is empty");
            }

            T ElementFromTop = item[count - 1];
            return ElementFromTop;
        }

        public void AutoResize()
        {

            int newCapasity = 2 * this.currentCapasity;
            T[] newArray = new T[2 * newCapasity];

            for (int i = 0; i < currentCapasity; i++)
            {
                newArray[i] = this.item[i];
            }

            this.currentCapasity = newCapasity;
            this.item = newArray;
        }

        public bool Contain(T Element)
        {
            if (this.count <= 0)
            {
                Console.WriteLine("Stack is empty");
            }

            for (int i = 0; i < this.count - 1; i++)
            {
                if (item[i].Equals(Element))
                {
                    return true;
                }
            }
            return false;
        }


        static void Main(string[] args)
        {
            AutoResizeableStack<int> stack = new AutoResizeableStack<int>();
            stack.Push(1);
            stack.Push(6);

            stack.Push(7);
            stack.Push(10);
            stack.Push(12);

            for (int i = 0; i < stack.Count; i++)
            {
                Console.WriteLine(stack.Pop(i));
            }

        }
    }
}
