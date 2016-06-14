namespace SortingHomework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class MergeSorter<T> : ISorter<T> where T : IComparable<T>
    {
        private T[] temp;
                    
        
        public void Sort(IList<T> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException("Empty list");
            }


            this.temp = new T[collection.Count];
            this.merge_sort(collection,0,collection.Count-1);
        }

        public void merge_sort(IList<T> collection,int leftIndex,int rightIndex)
        {
            if (leftIndex>=rightIndex)
            {
                return ;
            }

           
            int middle = (leftIndex+rightIndex )/ 2;

            this.merge_sort(collection, leftIndex, middle);
            this.merge_sort(collection, middle + 1, rightIndex);

            this.merge(collection, leftIndex, middle, rightIndex);
        }

        private void merge(IList<T> collection, int leftIndex, int middle, int rightIndex)
        {
            int leftPointer = leftIndex;
            int rightPointer = middle+1;
            int temP = leftIndex;

            while(leftPointer<=middle && rightPointer <= rightIndex)
            {

                if (collection[leftPointer].CompareTo(collection[rightPointer]) < 0)
                {
                    temp[temP++] = collection[leftPointer++];
                }
                else
                {
                    temp[temP++] = collection[rightPointer++];
                }
            }

            while (leftPointer <= middle)
            {
                temp[temP++] = collection[leftPointer++];
            }
            while (rightPointer <= rightIndex)
            {
                temp[temP++] = collection[rightPointer++];
            }

            for (int i = leftIndex; i <=rightIndex; i++)
            {
                collection[i] = temp[i];
               
            }
            

        }

       
    }
}
