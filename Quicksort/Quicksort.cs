using System;

namespace Quicksort
{
    public class Quicksort
    {
        public static void Sort(Func<int[], int, int, int, int> partition, int[] array, int first, int last)
        {
            if (first >= last || first < 0) return;

            int pivot = array[(first + last) / 2];
            int p = partition(array, first, last, pivot);
            Sort(partition, array, first, p);
            Sort(partition, array, p + 1, last);
        }
    }
    public class Quickselect
    {
        public static int Select(Func<int[], int, int, int, int> partition, int[] array, int first, int last, int target)
        {
            if (first >= last || first < 0) return array[last];

            int pivot = array[(first + last) / 2];

            int p = partition(array, first, last, pivot);
            if(target > pivot)
			{
                return Select(partition, array, p, last, target);
			} else
            {
                return Select(partition, array, first, p, target);
            }
        }
    }
}