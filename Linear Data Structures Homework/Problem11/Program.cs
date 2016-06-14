using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem11
{
    class ListItem<T> where T :IComparable<T>
    {

   
       private T Value { get; set; }
        private ListItem<T> next;


      
        public ListItem<T> Next
        {
            get { return this.next; }
            set { this.next = value; }
        } 

        public T value
        {
            get { return this.Value; }
            set { this.Value = Value; }
        }
        public ListItem(T Value,ListItem<T> Next)
        {
            this.Value = Value;
            this.next = Next;

        }

        public ListItem(T Value)
        {
            this.Value = Value;
            this.next = null;
        }

    
       
    }



    class LinkedList<T> where T :IComparable<T>
    {


        private ListItem<T> Node { get; set; }
        private int Count { get; set; }

      public LinkedList(ListItem<T> Node)
        {
            this.Node = Node;
            Count++;
        }
       
        public LinkedList()
        {
            Node = null;
            Count = 0;
        }

        public LinkedList(T Value)
        {
            ListItem<T> tempNode = new ListItem<T>(Value);
            this.Node = tempNode;
           this.Count++;


        }

        public void AddElement(T Value)
        {
            if (this.Node == null)
            {
                this.Node = new ListItem<T>(Value);
            }
            else
            {
                ListItem<T> newN = new ListItem<T>(Value, this.Node);
                this.Node = newN;

            }
            this.Count++;
        }

        public void RemoveLast()
        {
            ListItem<T> currentItem = this.Node.Next;
            this.Node = currentItem;
            this.Count--;
            
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= this.Count)
            {
                throw new IndexOutOfRangeException(String.Format("Invalid index: {0}.", index));
            }
            else
            {

                if (this.Count - 1 == index)
                {
                    RemoveLast();
                }
                else
                {
                    ListItem<T> currentElement = this.Node;
                    for (int i = 0; i < this.Count-index-2; i++)
                    {
                        currentElement = currentElement.Next;
                    }
                    currentElement = currentElement.Next.Next;
                    this.Count--;
                }
            }

        }

        public void Remove(T Value)
        {
            ListItem<T> currentElement = this.Node;
            int index = this.Count - 1;

            while (currentElement.Next != null)
            {
                if (currentElement.value.Equals(Value))
                {
                    this.RemoveAt(index);
                }
                else
                {
                    currentElement = currentElement.Next;
                    index--;
                }
            }
        }

        public bool Contain(T Value)
        {
            ListItem<T> currentItem = this.Node;

            while (currentItem.Next != null)
            {
                if (currentItem.value.Equals(Value))
                {
                    return true;
                }
            }

            return false;

        }

        public void Clear()
        {
            this.Node = null;
        }

        public void AddItemAt(T value, int index)
        {
            if (index < 0 || index > this.Count)
            {
                throw new IndexOutOfRangeException(String.Format("Invalid index: {0}.", index));
            }
            else
            {
                if (index == this.Count)
                {
                    ListItem<T> newNode = new ListItem<T>(value, this.Node);
                    this.Node = newNode;
                }
                else
                {
                    ListItem<T> currentElement = this.Node;
                    ListItem<T> newNode = new ListItem<T>(value);
                    for (int i = 0; i < this.Count - index - 1; i++)
                    {
                        currentElement = currentElement.Next;
                    }
                    newNode.Next = currentElement.Next;
                    currentElement.Next = newNode;
                }
                this.Count++;
            }
        }

    }
}
