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
        public static void Sort(int[] array, int first, int last)
        {
            if (first >= last || first < 0) return;

            int pivot = array[(first + last) / 2];
            int p = HoarePartition.Partition(array, first, last, pivot);
            Sort(HoarePartition.Partition, array, first, p);
            Sort(HoarePartition.Partition, array, p + 1, last);
        }
    }
    public class Quickselect
    {
        public static int /* valeur pas index */ Select(Func<int[], int, int, int, int> partition, int[] array, int first, int last, int target)
        {
            if (first >= last || first < 0) return array[last];

            int valeurPivot = array[(first + last) / 2];

            int indexPivot = partition(array, first, last, /* Valeur, pas index */ valeurPivot);
            if (target > indexPivot)
            {
                return Select(partition, array, indexPivot, last, target);
            }
            else
            {
                return Select(partition, array, first, indexPivot, target);
            }
        }

        struct Metres { public int v; }
        struct Secondes { public int v; }
        struct VitesseMpS { public int v; }

        public static T Select<T>(T[] array, int first, int last, int target)
        {
            if (first >= last || first < 0) return array[last];

            T pivot = array[(first + last) / 2];

            int p = HoarePartition.Partition(array, first, last, pivot);

            if (target > p)
            {
                return Select(array, p, last, target);
            }
            else
            {
                return Select(array, first, p, target);
            }
        }
    }
}