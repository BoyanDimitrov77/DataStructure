namespace SortingHomework
{
    using System;
    using System.Collections.Generic;

    public class SortableCollection<T> where T : IComparable<T>
    {
        private readonly IList<T> items;
        private Random rmd = new Random();

        public SortableCollection()
        {
            this.items = new List<T>();
        }

        public SortableCollection(IEnumerable<T> items)
        {
            this.items = new List<T>(items);
        }

        public IList<T> Items
        {
            get
            {
                return this.items;
            }
        }

      

        public void Sort(ISorter<T> sorter)
        {
            sorter.Sort(this.items);
        }

        public bool LinearSearch(T item)
        {

            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].Equals(item))
                {
                    return true;
                   
                }
               
            }
            return false;
        }

        public bool BinarySearch(T item)
        {

            int result= binary_search(items, item, 0, items.Count - 1);

            if (result != -1)
            {
                return true;
            }
            else
            {
                return false;
            }

           


                    
            throw new NotImplementedException();
        }

        //private int binary_search(IList<T> items, T key, int imin, int imax)
        //{
        //    if (items == null)
        //    {
        //        throw new ArgumentNullException("List is empty");
        //    }



        //    while (imin <= imax)
        //    {
        //        int middle = imin + ((imax - imin) >> 1);
        //       // int middle = (imin+imax)/2;

        //        if (items[middle].CompareTo(key) < 0)
        //        {
        //            imin = middle + 1;
        //        }
        //        else if (items[middle].CompareTo(key) > 0)
        //        {
        //            imax = middle - 1;
        //        }
        //        else
        //        {
        //            return middle;
        //        }
        //    }

        //    return -1;

        //}

        private int binary_search(IList<T> items, T key, int imin, int imax)
        {
            if (imax < imin)
            {
                return -1;
            }

            int middle = (imin + imax) / 2;

            if (items[middle].CompareTo(key) < 0)
            {
                return binary_search(items, key,middle + 1, imax);
            }else if (items[middle].CompareTo(key) > 0)
            {
                return binary_search(items, key, imin, middle -1);
            }
            else
            {
                return middle;
            }

           

        }

        public void Shuffle()
        {

            for (int i = items.Count; i > 1; i--)
            {
                int randomIndex = rmd.Next(i);
                Swap<T>(items, i, randomIndex);
            }

        }

        private void Swap<T1>(IList<T> items, int i, int randomIndex)
        {
            T temp = items[randomIndex];
            items[randomIndex] = items[i-1];
            items[i - 1] = temp;
        }

        public void PrintAllItemsOnConsole()
        {
            for (int i = 0; i < this.items.Count; i++)
            {
                if (i == 0)
                {
                    Console.Write(this.items[i]);
                }
                else
                {
                    Console.Write(" " + this.items[i]);
                }
            }

            Console.WriteLine();
        }

        
    }
}
