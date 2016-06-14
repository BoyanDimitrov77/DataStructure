namespace SortingHomework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class SelectionSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException("Null collection");
            }

            for (int i = 0; i < collection.Count-1; i++)
            {
                int MinValue = i;

                for (int j = i+1; j < collection.Count; j++)
                {
                    if (collection[j].CompareTo(collection[MinValue])>0 )
                    {
                        MinValue = j;
                     
                    }
                    
                }
                if (MinValue != i)
                {
                    swap(collection,i,MinValue);
                }
            }

        }

        private void swap(IList<T> collection, int i, int minValue)
        {
           T temp=collection[i];
            collection[i] = collection[minValue];
            collection[minValue] = temp;
        }
    }

    
}
