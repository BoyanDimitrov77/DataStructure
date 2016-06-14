using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem13
{
    /*
    class Program
    {
        static void Main(string[] args)
        {
            
            

            LinkedQueue<int> queueTop = new LinkedQueue<int>();
            queueTop.Enqueue(7);
            queueTop.Enqueue(9);
            queueTop.Enqueue(1);

            for (int i = 0; i < queueTop.Counter; i++)
            {
                Console.WriteLine(queueTop.Dequeue);
            }

        }
*/


    


    class LinkedQueueNode<T> where T :IComparable<T>
    {

       

        private T value;
        LinkedQueueNode<T> next;
        LinkedQueueNode<T> previous;

        public T Value
        {
            get { return this.value; }
            set { this.value = value; }
        }

        public LinkedQueueNode<T> Next
        {
            get { return this.next; }
            set { this.next = next; }
        }

        public LinkedQueueNode<T> Previous
        {
            get { return this.previous; }
            set { this.previous = previous; }
        }

        public LinkedQueueNode(T value)
        {
            this.value = value;
            this.next = null;
            this.previous = null;
        }
        public LinkedQueueNode(T value, LinkedQueueNode<T>nextNode, LinkedQueueNode<T> previousNode)
        {
            this.value = value;
            this.next = nextNode;
            this.previous = previousNode;
        }



    }


    class LinkedQueue<T> where T : IComparable<T>
    {
        private LinkedQueueNode<T> head;
        private LinkedQueueNode<T> tail;
        private int counter;

        public int Counter
        {
            get { return this.counter; }
        }


        public LinkedQueue()
        {
            this.head = null;
            this.tail = null;
            this.counter = 0;
        }

        public void Enqueue(T value)
        {
            if (this.tail == null)
            {
                this.tail = new LinkedQueueNode<T>(value);
                this.head = tail;
            }
            else
            {
                LinkedQueueNode<T> newNode = new LinkedQueueNode<T>(value, null, this.tail);
                this.tail.Next = newNode;
                this.tail = newNode;
            }
            this.counter++;
        }

        public T Dequeue()
        {
            if (this.counter > 0)
            {
                T element = head.Value;
                if (head.Next == null)
                {
                    this.head = null;
                    this.tail = null;
                }
                else
                {
                    this.head = this.head.Next;
                    this.head.Previous = null;
                }

                this.counter--;
                return element;
            }
            else
            {
                throw new NullReferenceException("No elements in the queue!");
            }
        }

        public T Peek()
        {

            if (this.counter > 0)
            {
                T element = this.head.Value;
                return element;
            }
            else
            {
                throw new NullReferenceException("No elements in the queue!");
            }
        }

        public void Clear()
        {
            this.head = null;
            this.tail = null;
            this.counter = 0;
        }

        public bool Contain(T Value)
        {
            if (this.counter >0){

                LinkedQueueNode<T> node = this.head;
                while (node.Next != null)
                {
                    if (node.Value.Equals(Value))
                    {
                        return true;
                    }
                    node = node.Next;
                }




            }
            else
            {
                throw new NullReferenceException("No elements in the queue!");
            }

            return false;

        }

    }
}
